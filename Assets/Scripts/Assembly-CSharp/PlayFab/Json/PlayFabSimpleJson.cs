using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;

namespace PlayFab.Json
{
	[GeneratedCode("simple-json", "1.0.0")]
	public static class PlayFabSimpleJson
	{
		static PlayFabSimpleJson()
		{
			PlayFabSimpleJson.EscapeTable = new char[93];
			PlayFabSimpleJson.EscapeTable[34] = '"';
			PlayFabSimpleJson.EscapeTable[92] = '\\';
			PlayFabSimpleJson.EscapeTable[8] = 'b';
			PlayFabSimpleJson.EscapeTable[12] = 'f';
			PlayFabSimpleJson.EscapeTable[10] = 'n';
			PlayFabSimpleJson.EscapeTable[13] = 'r';
			PlayFabSimpleJson.EscapeTable[9] = 't';
		}

		public static object DeserializeObject(string json)
		{
			object result;
			if (PlayFabSimpleJson.TryDeserializeObject(json, out result))
			{
				return result;
			}
			throw new SerializationException("Invalid JSON string");
		}

		public static bool TryDeserializeObject(string json, out object obj)
		{
			bool result = true;
			if (json != null)
			{
				int num = 0;
				obj = PlayFabSimpleJson.ParseValue(json, ref num, ref result);
			}
			else
			{
				obj = null;
			}
			return result;
		}

		public static object DeserializeObject(string json, Type type, IJsonSerializerStrategy jsonSerializerStrategy = null)
		{
			object obj = PlayFabSimpleJson.DeserializeObject(json);
			if (type == null || (obj != null && ReflectionUtils.IsAssignableFrom(obj.GetType(), type)))
			{
				return obj;
			}
			return (jsonSerializerStrategy ?? PlayFabSimpleJson.CurrentJsonSerializerStrategy).DeserializeObject(obj, type);
		}

		public static T DeserializeObject<T>(string json, IJsonSerializerStrategy jsonSerializerStrategy = null)
		{
			return (T)((object)PlayFabSimpleJson.DeserializeObject(json, typeof(T), jsonSerializerStrategy));
		}

		public static string SerializeObject(object json, IJsonSerializerStrategy jsonSerializerStrategy = null)
		{
			if (PlayFabSimpleJson._serializeObjectBuilder == null)
			{
				PlayFabSimpleJson._serializeObjectBuilder = new StringBuilder(2000);
			}
			PlayFabSimpleJson._serializeObjectBuilder.Length = 0;
			if (jsonSerializerStrategy == null)
			{
				jsonSerializerStrategy = PlayFabSimpleJson.CurrentJsonSerializerStrategy;
			}
			bool flag = PlayFabSimpleJson.SerializeValue(jsonSerializerStrategy, json, PlayFabSimpleJson._serializeObjectBuilder);
			return (!flag) ? null : PlayFabSimpleJson._serializeObjectBuilder.ToString();
		}

		public static string EscapeToJavascriptString(string jsonString)
		{
			if (string.IsNullOrEmpty(jsonString))
			{
				return jsonString;
			}
			StringBuilder stringBuilder = new StringBuilder();
			int i = 0;
			while (i < jsonString.Length)
			{
				char c = jsonString[i++];
				if (c == '\\')
				{
					int num = jsonString.Length - i;
					if (num >= 2)
					{
						char c2 = jsonString[i];
						if (c2 == '\\')
						{
							stringBuilder.Append('\\');
							i++;
						}
						else if (c2 == '"')
						{
							stringBuilder.Append("\"");
							i++;
						}
						else if (c2 == 't')
						{
							stringBuilder.Append('\t');
							i++;
						}
						else if (c2 == 'b')
						{
							stringBuilder.Append('\b');
							i++;
						}
						else if (c2 == 'n')
						{
							stringBuilder.Append('\n');
							i++;
						}
						else if (c2 == 'r')
						{
							stringBuilder.Append('\r');
							i++;
						}
					}
				}
				else
				{
					stringBuilder.Append(c);
				}
			}
			return stringBuilder.ToString();
		}

		private static IDictionary<string, object> ParseObject(string json, ref int index, ref bool success)
		{
			IDictionary<string, object> dictionary = new JsonObject();
			PlayFabSimpleJson.NextToken(json, ref index);
			bool flag = false;
			while (!flag)
			{
				PlayFabSimpleJson.TokenType tokenType = PlayFabSimpleJson.LookAhead(json, index);
				if (tokenType == PlayFabSimpleJson.TokenType.NONE)
				{
					success = false;
					return null;
				}
				if (tokenType == PlayFabSimpleJson.TokenType.COMMA)
				{
					PlayFabSimpleJson.NextToken(json, ref index);
				}
				else
				{
					if (tokenType == PlayFabSimpleJson.TokenType.CURLY_CLOSE)
					{
						PlayFabSimpleJson.NextToken(json, ref index);
						return dictionary;
					}
					string key = PlayFabSimpleJson.ParseString(json, ref index, ref success);
					if (!success)
					{
						success = false;
						return null;
					}
					tokenType = PlayFabSimpleJson.NextToken(json, ref index);
					if (tokenType != PlayFabSimpleJson.TokenType.COLON)
					{
						success = false;
						return null;
					}
					object value = PlayFabSimpleJson.ParseValue(json, ref index, ref success);
					if (!success)
					{
						success = false;
						return null;
					}
					dictionary[key] = value;
				}
			}
			return dictionary;
		}

		private static JsonArray ParseArray(string json, ref int index, ref bool success)
		{
			JsonArray jsonArray = new JsonArray();
			PlayFabSimpleJson.NextToken(json, ref index);
			bool flag = false;
			while (!flag)
			{
				PlayFabSimpleJson.TokenType tokenType = PlayFabSimpleJson.LookAhead(json, index);
				if (tokenType == PlayFabSimpleJson.TokenType.NONE)
				{
					success = false;
					return null;
				}
				if (tokenType == PlayFabSimpleJson.TokenType.COMMA)
				{
					PlayFabSimpleJson.NextToken(json, ref index);
				}
				else
				{
					if (tokenType == PlayFabSimpleJson.TokenType.SQUARED_CLOSE)
					{
						PlayFabSimpleJson.NextToken(json, ref index);
						break;
					}
					object item = PlayFabSimpleJson.ParseValue(json, ref index, ref success);
					if (!success)
					{
						return null;
					}
					jsonArray.Add(item);
				}
			}
			return jsonArray;
		}

		private static object ParseValue(string json, ref int index, ref bool success)
		{
			switch (PlayFabSimpleJson.LookAhead(json, index))
			{
			case PlayFabSimpleJson.TokenType.CURLY_OPEN:
				return PlayFabSimpleJson.ParseObject(json, ref index, ref success);
			case PlayFabSimpleJson.TokenType.SQUARED_OPEN:
				return PlayFabSimpleJson.ParseArray(json, ref index, ref success);
			case PlayFabSimpleJson.TokenType.STRING:
				return PlayFabSimpleJson.ParseString(json, ref index, ref success);
			case PlayFabSimpleJson.TokenType.NUMBER:
				return PlayFabSimpleJson.ParseNumber(json, ref index, ref success);
			case PlayFabSimpleJson.TokenType.TRUE:
				PlayFabSimpleJson.NextToken(json, ref index);
				return true;
			case PlayFabSimpleJson.TokenType.FALSE:
				PlayFabSimpleJson.NextToken(json, ref index);
				return false;
			case PlayFabSimpleJson.TokenType.NULL:
				PlayFabSimpleJson.NextToken(json, ref index);
				return null;
			}
			success = false;
			return null;
		}

		private static string ParseString(string json, ref int index, ref bool success)
		{
			if (PlayFabSimpleJson._parseStringBuilder == null)
			{
				PlayFabSimpleJson._parseStringBuilder = new StringBuilder(2000);
			}
			PlayFabSimpleJson._parseStringBuilder.Length = 0;
			PlayFabSimpleJson.EatWhitespace(json, ref index);
			char c = json[index++];
			bool flag = false;
			while (!flag)
			{
				if (index == json.Length)
				{
					break;
				}
				c = json[index++];
				if (c == '"')
				{
					flag = true;
					break;
				}
				if (c == '\\')
				{
					if (index == json.Length)
					{
						break;
					}
					c = json[index++];
					if (c == '"')
					{
						PlayFabSimpleJson._parseStringBuilder.Append('"');
					}
					else if (c == '\\')
					{
						PlayFabSimpleJson._parseStringBuilder.Append('\\');
					}
					else if (c == '/')
					{
						PlayFabSimpleJson._parseStringBuilder.Append('/');
					}
					else if (c == 'b')
					{
						PlayFabSimpleJson._parseStringBuilder.Append('\b');
					}
					else if (c == 'f')
					{
						PlayFabSimpleJson._parseStringBuilder.Append('\f');
					}
					else if (c == 'n')
					{
						PlayFabSimpleJson._parseStringBuilder.Append('\n');
					}
					else if (c == 'r')
					{
						PlayFabSimpleJson._parseStringBuilder.Append('\r');
					}
					else if (c == 't')
					{
						PlayFabSimpleJson._parseStringBuilder.Append('\t');
					}
					else if (c == 'u')
					{
						int num = json.Length - index;
						if (num < 4)
						{
							break;
						}
						uint num2;
						if (!(success = uint.TryParse(json.Substring(index, 4), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out num2)))
						{
							return string.Empty;
						}
						if (55296u <= num2 && num2 <= 56319u)
						{
							index += 4;
							num = json.Length - index;
							uint num3;
							if (num < 6 || !(json.Substring(index, 2) == "\\u") || !uint.TryParse(json.Substring(index + 2, 4), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out num3) || 56320u > num3 || num3 > 57343u)
							{
								success = false;
								return string.Empty;
							}
							PlayFabSimpleJson._parseStringBuilder.Append((char)num2);
							PlayFabSimpleJson._parseStringBuilder.Append((char)num3);
							index += 6;
						}
						else
						{
							PlayFabSimpleJson._parseStringBuilder.Append(PlayFabSimpleJson.ConvertFromUtf32((int)num2));
							index += 4;
						}
					}
				}
				else
				{
					PlayFabSimpleJson._parseStringBuilder.Append(c);
				}
			}
			if (!flag)
			{
				success = false;
				return null;
			}
			return PlayFabSimpleJson._parseStringBuilder.ToString();
		}

		private static string ConvertFromUtf32(int utf32)
		{
			if (utf32 < 0 || utf32 > 1114111)
			{
				throw new ArgumentOutOfRangeException("utf32", "The argument must be from 0 to 0x10FFFF.");
			}
			if (55296 <= utf32 && utf32 <= 57343)
			{
				throw new ArgumentOutOfRangeException("utf32", "The argument must not be in surrogate pair range.");
			}
			if (utf32 < 65536)
			{
				return new string((char)utf32, 1);
			}
			utf32 -= 65536;
			return new string(new char[]
			{
				(char)((utf32 >> 10) + 55296),
				(char)(utf32 % 1024 + 56320)
			});
		}

		private static object ParseNumber(string json, ref int index, ref bool success)
		{
			PlayFabSimpleJson.EatWhitespace(json, ref index);
			int lastIndexOfNumber = PlayFabSimpleJson.GetLastIndexOfNumber(json, index);
			int length = lastIndexOfNumber - index + 1;
			string text = json.Substring(index, length);
			object result;
			if (text.IndexOf(".", StringComparison.OrdinalIgnoreCase) != -1 || text.IndexOf("e", StringComparison.OrdinalIgnoreCase) != -1)
			{
				double num;
				success = double.TryParse(json.Substring(index, length), NumberStyles.Any, CultureInfo.InvariantCulture, out num);
				result = num;
			}
			else if (text.IndexOf("-", StringComparison.OrdinalIgnoreCase) == -1)
			{
				ulong num2;
				success = ulong.TryParse(json.Substring(index, length), NumberStyles.Any, CultureInfo.InvariantCulture, out num2);
				result = num2;
			}
			else
			{
				long num3;
				success = long.TryParse(json.Substring(index, length), NumberStyles.Any, CultureInfo.InvariantCulture, out num3);
				result = num3;
			}
			index = lastIndexOfNumber + 1;
			return result;
		}

		private static int GetLastIndexOfNumber(string json, int index)
		{
			int i;
			for (i = index; i < json.Length; i++)
			{
				if ("0123456789+-.eE".IndexOf(json[i]) == -1)
				{
					break;
				}
			}
			return i - 1;
		}

		private static void EatWhitespace(string json, ref int index)
		{
			while (index < json.Length)
			{
				if (" \t\n\r\b\f".IndexOf(json[index]) == -1)
				{
					break;
				}
				index++;
			}
		}

		private static PlayFabSimpleJson.TokenType LookAhead(string json, int index)
		{
			int num = index;
			return PlayFabSimpleJson.NextToken(json, ref num);
		}

		private static PlayFabSimpleJson.TokenType NextToken(string json, ref int index)
		{
			PlayFabSimpleJson.EatWhitespace(json, ref index);
			if (index == json.Length)
			{
				return PlayFabSimpleJson.TokenType.NONE;
			}
			char c = json[index];
			index++;
			switch (c)
			{
			case ',':
				return PlayFabSimpleJson.TokenType.COMMA;
			case '-':
			case '0':
			case '1':
			case '2':
			case '3':
			case '4':
			case '5':
			case '6':
			case '7':
			case '8':
			case '9':
				return PlayFabSimpleJson.TokenType.NUMBER;
			default:
				switch (c)
				{
				case '[':
					return PlayFabSimpleJson.TokenType.SQUARED_OPEN;
				default:
					switch (c)
					{
					case '{':
						return PlayFabSimpleJson.TokenType.CURLY_OPEN;
					default:
					{
						if (c == '"')
						{
							return PlayFabSimpleJson.TokenType.STRING;
						}
						index--;
						int num = json.Length - index;
						if (num >= 5 && json[index] == 'f' && json[index + 1] == 'a' && json[index + 2] == 'l' && json[index + 3] == 's' && json[index + 4] == 'e')
						{
							index += 5;
							return PlayFabSimpleJson.TokenType.FALSE;
						}
						if (num >= 4 && json[index] == 't' && json[index + 1] == 'r' && json[index + 2] == 'u' && json[index + 3] == 'e')
						{
							index += 4;
							return PlayFabSimpleJson.TokenType.TRUE;
						}
						if (num >= 4 && json[index] == 'n' && json[index + 1] == 'u' && json[index + 2] == 'l' && json[index + 3] == 'l')
						{
							index += 4;
							return PlayFabSimpleJson.TokenType.NULL;
						}
						return PlayFabSimpleJson.TokenType.NONE;
					}
					case '}':
						return PlayFabSimpleJson.TokenType.CURLY_CLOSE;
					}
					break;
				case ']':
					return PlayFabSimpleJson.TokenType.SQUARED_CLOSE;
				}
				break;
			case ':':
				return PlayFabSimpleJson.TokenType.COLON;
			}
		}

		private static bool SerializeValue(IJsonSerializerStrategy jsonSerializerStrategy, object value, StringBuilder builder)
		{
			bool flag = true;
			string text = value as string;
			if (value == null)
			{
				builder.Append("null");
			}
			else if (text != null)
			{
				flag = PlayFabSimpleJson.SerializeString(text, builder);
			}
			else
			{
				IDictionary<string, object> dictionary = value as IDictionary<string, object>;
				Type type = value.GetType();
				Type[] genericTypeArguments = ReflectionUtils.GetGenericTypeArguments(type);
				bool flag2 = type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Dictionary<, >) && genericTypeArguments[0] == typeof(string);
				if (flag2)
				{
					IDictionary dictionary2 = value as IDictionary;
					flag = PlayFabSimpleJson.SerializeObject(jsonSerializerStrategy, dictionary2.Keys, dictionary2.Values, builder);
				}
				else if (dictionary != null)
				{
					flag = PlayFabSimpleJson.SerializeObject(jsonSerializerStrategy, dictionary.Keys, dictionary.Values, builder);
				}
				else
				{
					IDictionary<string, string> dictionary3 = value as IDictionary<string, string>;
					if (dictionary3 != null)
					{
						flag = PlayFabSimpleJson.SerializeObject(jsonSerializerStrategy, dictionary3.Keys, dictionary3.Values, builder);
					}
					else
					{
						IEnumerable enumerable = value as IEnumerable;
						if (enumerable != null)
						{
							flag = PlayFabSimpleJson.SerializeArray(jsonSerializerStrategy, enumerable, builder);
						}
						else if (PlayFabSimpleJson.IsNumeric(value))
						{
							flag = PlayFabSimpleJson.SerializeNumber(value, builder);
						}
						else if (value is bool)
						{
							builder.Append((!(bool)value) ? "false" : "true");
						}
						else
						{
							object value2;
							flag = jsonSerializerStrategy.TrySerializeNonPrimitiveObject(value, out value2);
							if (flag)
							{
								PlayFabSimpleJson.SerializeValue(jsonSerializerStrategy, value2, builder);
							}
						}
					}
				}
			}
			return flag;
		}

		private static bool SerializeObject(IJsonSerializerStrategy jsonSerializerStrategy, IEnumerable keys, IEnumerable values, StringBuilder builder)
		{
			builder.Append("{");
			IEnumerator enumerator = keys.GetEnumerator();
			IEnumerator enumerator2 = values.GetEnumerator();
			bool flag = true;
			while (enumerator.MoveNext() && enumerator2.MoveNext())
			{
				object obj = enumerator.Current;
				object value = enumerator2.Current;
				if (!flag)
				{
					builder.Append(",");
				}
				string text = obj as string;
				if (text != null)
				{
					PlayFabSimpleJson.SerializeString(text, builder);
				}
				else if (!PlayFabSimpleJson.SerializeValue(jsonSerializerStrategy, value, builder))
				{
					return false;
				}
				builder.Append(":");
				if (!PlayFabSimpleJson.SerializeValue(jsonSerializerStrategy, value, builder))
				{
					return false;
				}
				flag = false;
			}
			builder.Append("}");
			return true;
		}

		private static bool SerializeArray(IJsonSerializerStrategy jsonSerializerStrategy, IEnumerable anArray, StringBuilder builder)
		{
			builder.Append("[");
			bool flag = true;
			IEnumerator enumerator = anArray.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object value = enumerator.Current;
					if (!flag)
					{
						builder.Append(",");
					}
					if (!PlayFabSimpleJson.SerializeValue(jsonSerializerStrategy, value, builder))
					{
						return false;
					}
					flag = false;
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
			builder.Append("]");
			return true;
		}

		private static bool SerializeString(string aString, StringBuilder builder)
		{
			if (aString.IndexOfAny(PlayFabSimpleJson.EscapeCharacters) == -1)
			{
				builder.Append('"');
				builder.Append(aString);
				builder.Append('"');
				return true;
			}
			builder.Append('"');
			int num = 0;
			char[] array = aString.ToCharArray();
			for (int i = 0; i < array.Length; i++)
			{
				char c = array[i];
				if ((int)c >= PlayFabSimpleJson.EscapeTable.Length || PlayFabSimpleJson.EscapeTable[(int)c] == '\0')
				{
					num++;
				}
				else
				{
					if (num > 0)
					{
						builder.Append(array, i - num, num);
						num = 0;
					}
					builder.Append('\\');
					builder.Append(PlayFabSimpleJson.EscapeTable[(int)c]);
				}
			}
			if (num > 0)
			{
				builder.Append(array, array.Length - num, num);
			}
			builder.Append('"');
			return true;
		}

		private static bool SerializeNumber(object number, StringBuilder builder)
		{
			if (number is decimal)
			{
				builder.Append(((decimal)number).ToString("R", CultureInfo.InvariantCulture));
			}
			else if (number is double)
			{
				builder.Append(((double)number).ToString("R", CultureInfo.InvariantCulture));
			}
			else if (number is float)
			{
				builder.Append(((float)number).ToString("R", CultureInfo.InvariantCulture));
			}
			else if (PlayFabSimpleJson.NumberTypes.IndexOf(number.GetType()) != -1)
			{
				builder.Append(number);
			}
			return true;
		}

		private static bool IsNumeric(object value)
		{
			return value is sbyte || value is byte || value is short || value is ushort || value is int || value is uint || value is long || value is ulong || value is float || value is double || value is decimal;
		}

		public static IJsonSerializerStrategy CurrentJsonSerializerStrategy
		{
			get
			{
				IJsonSerializerStrategy result;
				if ((result = PlayFabSimpleJson._currentJsonSerializerStrategy) == null)
				{
					result = (PlayFabSimpleJson._currentJsonSerializerStrategy = PlayFabSimpleJson.PocoJsonSerializerStrategy);
				}
				return result;
			}
			set
			{
				PlayFabSimpleJson._currentJsonSerializerStrategy = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static PocoJsonSerializerStrategy PocoJsonSerializerStrategy
		{
			get
			{
				PocoJsonSerializerStrategy result;
				if ((result = PlayFabSimpleJson._pocoJsonSerializerStrategy) == null)
				{
					result = (PlayFabSimpleJson._pocoJsonSerializerStrategy = new PocoJsonSerializerStrategy());
				}
				return result;
			}
		}

		private const int BUILDER_INIT = 2000;

		private static readonly char[] EscapeTable;

		private static readonly char[] EscapeCharacters = new char[]
		{
			'"',
			'\\',
			'\b',
			'\f',
			'\n',
			'\r',
			'\t'
		};

		internal static readonly List<Type> NumberTypes = new List<Type>
		{
			typeof(bool),
			typeof(byte),
			typeof(ushort),
			typeof(uint),
			typeof(ulong),
			typeof(sbyte),
			typeof(short),
			typeof(int),
			typeof(long),
			typeof(double),
			typeof(float),
			typeof(decimal)
		};

		[ThreadStatic]
		private static StringBuilder _serializeObjectBuilder;

		[ThreadStatic]
		private static StringBuilder _parseStringBuilder;

		private static IJsonSerializerStrategy _currentJsonSerializerStrategy;

		private static PocoJsonSerializerStrategy _pocoJsonSerializerStrategy;

		private enum TokenType : byte
		{
			NONE,
			CURLY_OPEN,
			CURLY_CLOSE,
			SQUARED_OPEN,
			SQUARED_CLOSE,
			COLON,
			COMMA,
			STRING,
			NUMBER,
			TRUE,
			FALSE,
			NULL
		}
	}
}
