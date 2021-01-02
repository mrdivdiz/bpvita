using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace Pathfinding.Serialization.JsonFx
{
	public class JsonReader
	{
		public JsonReader(string input) : this(input, new JsonReaderSettings())
		{
		}

		public JsonReader(string input, JsonReaderSettings settings)
		{
			this.Settings = settings;
			this.Source = input;
			this.SourceLength = this.Source.Length;
		}

		public object Deserialize(int start, Type type)
		{
			this.index = start;
			this.depth = -1;
			return this.Read(type, false);
		}

		public object Read(Type expectedType, bool typeIsHint)
		{
			this.depth++;
			if (object.Equals(expectedType, typeof(object)))
			{
				expectedType = null;
			}
			JsonToken jsonToken = this.Tokenize();
			if (!object.Equals(expectedType, null) && !expectedType.IsPrimitive)
			{
				JsonConverter converter = this.Settings.GetConverter(expectedType);
				if (converter != null)
				{
					if (this.depth <= 0)
					{
						if (!converter.convertAtDepthZero)
						{
							goto IL_D3;
						}
					}
					try
					{
						object obj = this.Read(typeof(Dictionary<string, object>), false);
						Dictionary<string, object> dictionary = obj as Dictionary<string, object>;
						if (dictionary == null)
						{
							return null;
						}
						object result = converter.Read(this, expectedType, dictionary);
						this.depth--;
						return result;
					}
					catch (JsonTypeCoercionException ex)
					{
					}
					this.depth--;
					return null;
				}
				IL_D3:
				if (typeof(IJsonSerializable).IsAssignableFrom(expectedType))
				{
					IJsonSerializable jsonSerializable = this.Settings.Coercion.InstantiateObject(expectedType) as IJsonSerializable;
					jsonSerializable.ReadJson(this);
					this.depth--;
					return jsonSerializable;
				}
			}
			switch (jsonToken)
			{
			case JsonToken.Undefined:
				this.index += JsonReader.LiteralUndefined.Length;
				this.depth--;
				return null;
			case JsonToken.Null:
				this.index += JsonReader.LiteralNull.Length;
				this.depth--;
				return null;
			case JsonToken.False:
				this.index += JsonReader.LiteralFalse.Length;
				this.depth--;
				return false;
			case JsonToken.True:
				this.index += JsonReader.LiteralTrue.Length;
				this.depth--;
				return true;
			case JsonToken.NaN:
				this.index += JsonReader.LiteralNotANumber.Length;
				this.depth--;
				return double.NaN;
			case JsonToken.PositiveInfinity:
				this.index += JsonReader.LiteralPositiveInfinity.Length;
				this.depth--;
				return double.PositiveInfinity;
			case JsonToken.NegativeInfinity:
				this.index += JsonReader.LiteralNegativeInfinity.Length;
				this.depth--;
				return double.NegativeInfinity;
			case JsonToken.Number:
			{
				object result2 = this.ReadNumber((!typeIsHint) ? expectedType : null);
				this.depth--;
				return result2;
			}
			case JsonToken.String:
			{
				object result2 = this.ReadString((!typeIsHint) ? expectedType : null);
				this.depth--;
				return result2;
			}
			case JsonToken.ArrayStart:
			{
				object result2 = this.ReadArray((!typeIsHint) ? expectedType : null);
				this.depth--;
				return result2;
			}
			case JsonToken.ObjectStart:
			{
				object result2 = this.ReadObject((!typeIsHint) ? expectedType : null);
				this.depth--;
				return result2;
			}
			}
			this.depth--;
			return null;
		}

		private object ReadObject(Type objectType)
		{
			Type genericDictionaryType = null;
			Dictionary<string, MemberInfo> dictionary = null;
			object obj;
			if (!object.Equals(objectType, null))
			{
				obj = this.Settings.Coercion.InstantiateObject(objectType, out dictionary);
				this.previouslyDeserialized.Add(obj);
				if (dictionary == null)
				{
					genericDictionaryType = this.GetGenericDictionaryType(objectType);
				}
			}
			else
			{
				obj = new Dictionary<string, object>();
			}
			object obj2 = obj;
			this.PopulateObject(ref obj, objectType, dictionary, genericDictionaryType);
			if (obj2 != obj && !object.Equals(objectType, null))
			{
				this.previouslyDeserialized.RemoveAt(this.previouslyDeserialized.Count - 1);
			}
			return obj;
		}

		private Type GetGenericDictionaryType(Type objectType)
		{
			Type @interface = TypeCoercionUtility.GetTypeInfo(objectType).GetInterface(JsonReader.TypeGenericIDictionary);
			if (@interface != null)
			{
				Type[] genericArguments = @interface.GetGenericArguments();
				if (genericArguments.Length == 2)
				{
					if (!object.Equals(genericArguments[0], typeof(string)))
					{
						throw new JsonDeserializationException(string.Format("Types which implement Generic IDictionary<TKey, TValue> need to have string keys to be deserialized. ({0})", new object[]
						{
							objectType
						}), this.index);
					}
					if (!object.Equals(genericArguments[1], typeof(object)))
					{
						return genericArguments[1];
					}
				}
			}
			return null;
		}

		private void PopulateObject(ref object result, Type objectType, Dictionary<string, MemberInfo> memberMap, Type genericDictionaryType)
		{
			if (this.Source[this.index] != '{')
			{
				throw new JsonDeserializationException("Expected JSON object.", this.index);
			}
			IDictionary dictionary = result as IDictionary;
			if (dictionary == null && !object.Equals(TypeCoercionUtility.GetTypeInfo(objectType).GetInterface(JsonReader.TypeGenericIDictionary), null))
			{
				throw new JsonDeserializationException(string.Format("Types which implement Generic IDictionary<TKey, TValue> also need to implement IDictionary to be deserialized. ({0})", new object[]
				{
					objectType
				}), this.index);
			}
			JsonToken jsonToken;
			for (;;)
			{
				this.index++;
				if (this.index >= this.SourceLength)
				{
					break;
				}
				jsonToken = this.Tokenize(this.Settings.AllowUnquotedObjectKeys);
				if (jsonToken == JsonToken.ObjectEnd)
				{
					goto Block_5;
				}
				if (jsonToken != JsonToken.String && jsonToken != JsonToken.UnquotedName)
				{
					goto Block_7;
				}
				string text = (jsonToken != JsonToken.String) ? this.ReadUnquotedKey() : ((string)this.ReadString(null));
				MemberInfo memberInfo;
				Type type;
				if (object.Equals(genericDictionaryType, null) && memberMap != null)
				{
					type = TypeCoercionUtility.GetMemberInfo(memberMap, text, out memberInfo);
				}
				else
				{
					type = genericDictionaryType;
					memberInfo = null;
				}
				jsonToken = this.Tokenize();
				if (jsonToken != JsonToken.NameDelim)
				{
					goto Block_11;
				}
				this.index++;
				if (this.index >= this.SourceLength)
				{
					goto Block_12;
				}
				if (this.Settings.HandleCyclicReferences && text == "@ref")
				{
					int num = (int)this.Read(typeof(int), false);
					result = this.previouslyDeserialized[num];
					jsonToken = this.Tokenize();
				}
				else
				{
					object obj = this.Read(type, false);
					if (dictionary != null)
					{
						if (object.Equals(objectType, null) && this.Settings.IsTypeHintName(text))
						{
							result = this.Settings.Coercion.ProcessTypeHint(dictionary, obj as string, out objectType, out memberMap);
						}
						else
						{
							dictionary[text] = obj;
						}
					}
					else if (this.Settings.IsTypeHintName(text))
					{
						result = this.Settings.Coercion.ProcessTypeHint(result, obj as string, out objectType, out memberMap);
					}
					else
					{
						this.Settings.Coercion.SetMemberValue(result, type, memberInfo, obj);
					}
					jsonToken = this.Tokenize();
				}
				if (jsonToken != JsonToken.ValueDelim)
				{
					goto IL_28A;
				}
			}
			throw new JsonDeserializationException("Unterminated JSON object.", this.index);
			Block_5:
			goto IL_28A;
			Block_7:
			throw new JsonDeserializationException("Expected JSON object property name.", this.index);
			Block_11:
			throw new JsonDeserializationException("Expected JSON object property name delimiter.", this.index);
			Block_12:
			throw new JsonDeserializationException("Unterminated JSON object.", this.index);
			IL_28A:
			if (jsonToken != JsonToken.ObjectEnd)
			{
				throw new JsonDeserializationException("Unterminated JSON object.", this.index);
			}
			this.index++;
		}

		private IEnumerable ReadArray(Type arrayType)
		{
			if (this.Source[this.index] != '[')
			{
				throw new JsonDeserializationException("Expected JSON array.", this.index);
			}
			bool flag = !object.Equals(arrayType, null);
			bool typeIsHint = !flag;
			Type type = null;
			if (flag)
			{
				if (arrayType.HasElementType)
				{
					type = arrayType.GetElementType();
				}
				else if (TypeCoercionUtility.GetTypeInfo(arrayType).IsGenericType)
				{
					Type[] genericArguments = arrayType.GetGenericArguments();
					if (genericArguments.Length == 1)
					{
						type = genericArguments[0];
					}
				}
			}
			List<object> list = (this.jsArrays.Count <= 0) ? new List<object>() : this.jsArrays.Pop();
			list.Clear();
			JsonToken jsonToken;
			for (;;)
			{
				this.index++;
				if (this.index >= this.SourceLength)
				{
					break;
				}
				jsonToken = this.Tokenize();
				if (jsonToken == JsonToken.ArrayEnd)
				{
					goto Block_8;
				}
				object obj = this.Read(type, typeIsHint);
				list.Add(obj);
				if (obj == null)
				{
					if (!object.Equals(type, null) && TypeCoercionUtility.GetTypeInfo(type).IsValueType)
					{
						type = null;
					}
					flag = true;
				}
				else if (!object.Equals(type, null) && !TypeCoercionUtility.GetTypeInfo(type).IsAssignableFrom(TypeCoercionUtility.GetTypeInfo(obj.GetType())))
				{
					if (TypeCoercionUtility.GetTypeInfo(obj.GetType()).IsAssignableFrom(TypeCoercionUtility.GetTypeInfo(type)))
					{
						type = obj.GetType();
					}
					else
					{
						type = null;
						flag = true;
					}
				}
				else if (!flag)
				{
					type = obj.GetType();
					flag = true;
				}
				jsonToken = this.Tokenize();
				if (jsonToken != JsonToken.ValueDelim)
				{
					goto IL_1AB;
				}
			}
			throw new JsonDeserializationException("Unterminated JSON array.", this.index);
			Block_8:
			IL_1AB:
			if (jsonToken != JsonToken.ArrayEnd)
			{
				throw new JsonDeserializationException("Unterminated JSON array.", this.index);
			}
			this.index++;
			this.jsArrays.Push(list);
			if (object.Equals(type, null) || object.Equals(type, typeof(object)))
			{
				return list.ToArray();
			}
			if (arrayType != null && arrayType.IsGenericType && object.Equals(arrayType.GetGenericTypeDefinition(), typeof(List<>)))
			{
				IList list2 = Activator.CreateInstance(arrayType, new object[]
				{
					list.Count
				}) as IList;
				for (int i = 0; i < list.Count; i++)
				{
					list2.Add(list[i]);
				}
				return list2;
			}
			Array array = Array.CreateInstance(type, new int[]
			{
				list.Count
			});
			for (int j = 0; j < list.Count; j++)
			{
				array.SetValue(list[j], new int[]
				{
					j
				});
			}
			return array;
		}

		private string ReadUnquotedKey()
		{
			int num = this.index;
			do
			{
				this.index++;
			}
			while (this.Tokenize(true) == JsonToken.UnquotedName);
			return this.Source.Substring(num, this.index - num);
		}

		private object ReadString(Type expectedType)
		{
			if (this.Source[this.index] != '"' && this.Source[this.index] != '\'')
			{
				throw new JsonDeserializationException("Expected JSON string.", this.index);
			}
			char c = this.Source[this.index];
			this.index++;
			if (this.index >= this.SourceLength)
			{
				throw new JsonDeserializationException("Unterminated JSON string.", this.index);
			}
			JsonReader.builder.Length = 0;
			int num = this.index;
			while (this.Source[this.index] != c)
			{
				if (this.Source[this.index] == '\\')
				{
					JsonReader.builder.Append(this.Source, num, this.index - num);
					this.index++;
					if (this.index >= this.SourceLength)
					{
						throw new JsonDeserializationException("Unterminated JSON string.", this.index);
					}
					char c2 = this.Source[this.index];
					switch (c2)
					{
					case 'n':
						JsonReader.builder.Append('\n');
						break;
					default:
						if (c2 != '0')
						{
							if (c2 != 'b')
							{
								if (c2 != 'f')
								{
									JsonReader.builder.Append(this.Source[this.index]);
								}
								else
								{
									JsonReader.builder.Append('\f');
								}
							}
							else
							{
								JsonReader.builder.Append('\b');
							}
						}
						break;
					case 'r':
						JsonReader.builder.Append('\r');
						break;
					case 't':
						JsonReader.builder.Append('\t');
						break;
					case 'u':
					{
						int utf;
						if (this.index + 4 < this.SourceLength && int.TryParse(this.Source.Substring(this.index + 1, 4), NumberStyles.AllowHexSpecifier, NumberFormatInfo.InvariantInfo, out utf))
						{
							JsonReader.builder.Append(char.ConvertFromUtf32(utf));
							this.index += 4;
						}
						else
						{
							JsonReader.builder.Append(this.Source[this.index]);
						}
						break;
					}
					}
					this.index++;
					if (this.index >= this.SourceLength)
					{
						throw new JsonDeserializationException("Unterminated JSON string.", this.index);
					}
					num = this.index;
				}
				else
				{
					this.index++;
					if (this.index >= this.SourceLength)
					{
						throw new JsonDeserializationException("Unterminated JSON string.", this.index);
					}
				}
			}
			JsonReader.builder.Append(this.Source, num, this.index - num);
			this.index++;
			string text = JsonReader.builder.ToString();
			if (!object.Equals(expectedType, null) && !object.Equals(expectedType, typeof(string)))
			{
				return this.Settings.Coercion.CoerceType(expectedType, text);
			}
			return text;
		}

		private object ReadNumber(Type expectedType)
		{
			bool flag = false;
			bool flag2 = false;
			int num = this.index;
			int num2 = 0;
			if (this.Source[this.index] == '-')
			{
				this.index++;
				if (this.index >= this.SourceLength || !char.IsDigit(this.Source[this.index]))
				{
					throw new JsonDeserializationException("Illegal JSON number.", this.index);
				}
			}
			while (this.index < this.SourceLength && char.IsDigit(this.Source[this.index]))
			{
				this.index++;
			}
			if (this.index < this.SourceLength && this.Source[this.index] == '.')
			{
				flag = true;
				this.index++;
				if (this.index >= this.SourceLength || !char.IsDigit(this.Source[this.index]))
				{
					throw new JsonDeserializationException("Illegal JSON number.", this.index);
				}
				while (this.index < this.SourceLength && char.IsDigit(this.Source[this.index]))
				{
					this.index++;
				}
			}
			int num3 = this.index - num - ((!flag) ? 0 : 1);
			if (this.index < this.SourceLength && (this.Source[this.index] == 'e' || this.Source[this.index] == 'E'))
			{
				flag2 = true;
				this.index++;
				if (this.index >= this.SourceLength)
				{
					throw new JsonDeserializationException("Illegal JSON number.", this.index);
				}
				int num4 = this.index;
				if (this.Source[this.index] == '-' || this.Source[this.index] == '+')
				{
					this.index++;
					if (this.index >= this.SourceLength || !char.IsDigit(this.Source[this.index]))
					{
						throw new JsonDeserializationException("Illegal JSON number.", this.index);
					}
				}
				else if (!char.IsDigit(this.Source[this.index]))
				{
					throw new JsonDeserializationException("Illegal JSON number.", this.index);
				}
				while (this.index < this.SourceLength && char.IsDigit(this.Source[this.index]))
				{
					this.index++;
				}
				int.TryParse(this.Source.Substring(num4, this.index - num4), NumberStyles.Integer, NumberFormatInfo.InvariantInfo, out num2);
			}
			string s = this.Source.Substring(num, this.index - num);
			if (!flag && !flag2 && num3 < 19)
			{
				decimal num5 = decimal.Parse(s, NumberStyles.Integer, NumberFormatInfo.InvariantInfo);
				if (!object.Equals(expectedType, null))
				{
					return this.Settings.Coercion.CoerceType(expectedType, num5);
				}
				if (num5 >= -2147483648m && num5 <= 2147483647m)
				{
					return (int)num5;
				}
				if (num5 >= -9223372036854775808m && num5 <= 9223372036854775807m)
				{
					return (long)num5;
				}
				return num5;
			}
			else
			{
				if (object.Equals(expectedType, typeof(decimal)))
				{
					return decimal.Parse(s, NumberStyles.Float, NumberFormatInfo.InvariantInfo);
				}
				double num6 = double.Parse(s, NumberStyles.Float, NumberFormatInfo.InvariantInfo);
				if (!object.Equals(expectedType, null))
				{
					return this.Settings.Coercion.CoerceType(expectedType, num6);
				}
				return num6;
			}
		}

		public static object Deserialize(string value)
		{
			return JsonReader.Deserialize(value, 0, null);
		}

		public static T Deserialize<T>(string value)
		{
			return (T)((object)JsonReader.Deserialize(value, 0, typeof(T)));
		}

		public static object Deserialize(string value, int start, Type type)
		{
			return new JsonReader(value).Deserialize(start, type);
		}

		private JsonToken Tokenize()
		{
			return this.Tokenize(false);
		}

		private JsonToken Tokenize(bool allowUnquotedString)
		{
			if (this.index >= this.SourceLength)
			{
				return JsonToken.End;
			}
			while (char.IsWhiteSpace(this.Source[this.index]))
			{
				this.index++;
				if (this.index >= this.SourceLength)
				{
					return JsonToken.End;
				}
			}
			if (this.Source[this.index] == "/*"[0])
			{
				if (this.index + 1 >= this.SourceLength)
				{
					throw new JsonDeserializationException("Illegal JSON sequence. (end of stream while parsing possible comment)", this.index);
				}
				this.index++;
				bool flag = false;
				if (this.Source[this.index] == "/*"[1])
				{
					flag = true;
				}
				else if (this.Source[this.index] != "//"[1])
				{
					throw new JsonDeserializationException("Illegal JSON sequence.", this.index);
				}
				this.index++;
				if (flag)
				{
					int num = this.index - 2;
					if (this.index + 1 >= this.SourceLength)
					{
						throw new JsonDeserializationException("Unterminated comment block.", num);
					}
					while (this.Source[this.index] != "*/"[0] || this.Source[this.index + 1] != "*/"[1])
					{
						this.index++;
						if (this.index + 1 >= this.SourceLength)
						{
							throw new JsonDeserializationException("Unterminated comment block.", num);
						}
					}
					this.index += 2;
					if (this.index >= this.SourceLength)
					{
						return JsonToken.End;
					}
				}
				else
				{
					while ("\r\n".IndexOf(this.Source[this.index]) < 0)
					{
						this.index++;
						if (this.index >= this.SourceLength)
						{
							return JsonToken.End;
						}
					}
				}
				while (char.IsWhiteSpace(this.Source[this.index]))
				{
					this.index++;
					if (this.index >= this.SourceLength)
					{
						return JsonToken.End;
					}
				}
			}
			if (this.Source[this.index] == '+')
			{
				this.index++;
				if (this.index >= this.SourceLength)
				{
					return JsonToken.End;
				}
			}
			char c = this.Source[this.index];
			switch (c)
			{
			case '[':
				return JsonToken.ArrayStart;
			default:
				switch (c)
				{
				case '{':
					return JsonToken.ObjectStart;
				default:
				{
					if (c == '"' || c == '\'')
					{
						return JsonToken.String;
					}
					if (c == ',')
					{
						return JsonToken.ValueDelim;
					}
					if (c == ':')
					{
						return JsonToken.NameDelim;
					}
					if (char.IsDigit(this.Source[this.index]) || (this.Source[this.index] == '-' && this.index + 1 < this.SourceLength && char.IsDigit(this.Source[this.index + 1])))
					{
						return JsonToken.Number;
					}
					if (this.MatchLiteral(JsonReader.LiteralFalse))
					{
						return JsonToken.False;
					}
					if (this.MatchLiteral(JsonReader.LiteralTrue))
					{
						return JsonToken.True;
					}
					if (this.MatchLiteral(JsonReader.LiteralNull))
					{
						return JsonToken.Null;
					}
					if (this.MatchLiteral(JsonReader.LiteralNotANumber))
					{
						return JsonToken.NaN;
					}
					if (this.MatchLiteral(JsonReader.LiteralPositiveInfinity))
					{
						return JsonToken.PositiveInfinity;
					}
					if (this.MatchLiteral(JsonReader.LiteralNegativeInfinity))
					{
						return JsonToken.NegativeInfinity;
					}
					if (this.MatchLiteral(JsonReader.LiteralUndefined))
					{
						return JsonToken.Undefined;
					}
					if (allowUnquotedString)
					{
						return JsonToken.UnquotedName;
					}
					string text = this.Source.Substring(Math.Max(0, this.index - 5), Math.Min(this.SourceLength - this.index - 1, 20));
					throw new JsonDeserializationException(string.Concat(new object[]
					{
						"Illegal JSON sequence. (when parsing '",
						this.Source[this.index],
						"' ",
						(int)this.Source[this.index],
						") at index ",
						this.index,
						"\nAround: '",
						text,
						"'"
					}), this.index);
				}
				case '}':
					return JsonToken.ObjectEnd;
				}
				break;
			case ']':
				return JsonToken.ArrayEnd;
			}
		}

		private bool MatchLiteral(string literal)
		{
			int length = literal.Length;
			if (this.index + length > this.SourceLength)
			{
				return false;
			}
			for (int i = 0; i < length; i++)
			{
				if (literal[i] != this.Source[this.index + i])
				{
					return false;
				}
			}
			return true;
		}

		internal static readonly string LiteralFalse = "false";

		internal static readonly string LiteralTrue = "true";

		internal static readonly string LiteralNull = "null";

		internal static readonly string LiteralUndefined = "undefined";

		internal static readonly string LiteralNotANumber = "NaN";

		internal static readonly string LiteralPositiveInfinity = "Infinity";

		internal static readonly string LiteralNegativeInfinity = "-Infinity";

		internal static readonly string TypeGenericIDictionary = "System.Collections.Generic.IDictionary`2";

		private readonly JsonReaderSettings Settings = new JsonReaderSettings();

		private readonly string Source;

		private readonly int SourceLength;

		private int index;

		private int depth;

		private readonly List<object> previouslyDeserialized = new List<object>();

		private readonly Stack<List<object>> jsArrays = new Stack<List<object>>();

		private static StringBuilder builder = new StringBuilder();
	}
}
