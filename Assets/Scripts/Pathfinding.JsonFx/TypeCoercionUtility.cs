using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace Pathfinding.Serialization.JsonFx
{
	internal class TypeCoercionUtility
	{
		public static Type GetTypeInfo(Type tp)
		{
			return tp;
		}

		private Dictionary<Type, Dictionary<string, MemberInfo>> MemberMapCache
		{
			get
			{
				if (this.memberMapCache == null)
				{
					this.memberMapCache = new Dictionary<Type, Dictionary<string, MemberInfo>>();
				}
				return this.memberMapCache;
			}
		}

		internal object ProcessTypeHint(IDictionary result, string typeInfo, out Type objectType, out Dictionary<string, MemberInfo> memberMap)
		{
			if (string.IsNullOrEmpty(typeInfo))
			{
				objectType = null;
				memberMap = null;
				return result;
			}
			Type type = Type.GetType(typeInfo, false);
			if (object.Equals(type, null))
			{
				objectType = null;
				memberMap = null;
				return result;
			}
			objectType = type;
			return this.CoerceType(type, result, out memberMap);
		}

		internal object ProcessTypeHint(object result, string typeInfo, out Type objectType, out Dictionary<string, MemberInfo> memberMap)
		{
			Type type = Type.GetType(typeInfo, false);
			if (object.Equals(type, null))
			{
				objectType = null;
				memberMap = null;
				return result;
			}
			objectType = type;
			return this.InstantiateObject(objectType, out memberMap);
		}

		internal object InstantiateObject(Type objectType)
		{
			return Activator.CreateInstance(objectType);
		}

		internal object InstantiateObject(Type objectType, out Dictionary<string, MemberInfo> memberMap)
		{
			object result = this.InstantiateObject(objectType);
			memberMap = this.GetMemberMap(objectType);
			return result;
		}

		public Dictionary<string, MemberInfo> GetMemberMap(Type objectType)
		{
			if (TypeCoercionUtility.GetTypeInfo(typeof(IDictionary)).IsAssignableFrom(TypeCoercionUtility.GetTypeInfo(objectType)))
			{
				return null;
			}
			return this.CreateMemberMap(objectType);
		}

		private Dictionary<string, MemberInfo> CreateMemberMap(Type objectType)
		{
			Dictionary<string, MemberInfo> dictionary;
			if (this.MemberMapCache.TryGetValue(objectType, out dictionary))
			{
				return dictionary;
			}
			dictionary = new Dictionary<string, MemberInfo>();
			for (Type type = objectType; type != null; type = type.BaseType)
			{
				foreach (PropertyInfo propertyInfo in type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
				{
					if (propertyInfo.CanRead && propertyInfo.CanWrite)
					{
						if (!JsonIgnoreAttribute.IsJsonIgnore(propertyInfo))
						{
							string jsonName = JsonNameAttribute.GetJsonName(propertyInfo);
							if (string.IsNullOrEmpty(jsonName))
							{
								dictionary[propertyInfo.Name] = propertyInfo;
							}
							else
							{
								dictionary[jsonName] = propertyInfo;
							}
						}
					}
				}
				FieldInfo[] fields = TypeCoercionUtility.GetTypeInfo(objectType).GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (FieldInfo fieldInfo in fields)
				{
					if (fieldInfo.IsPublic || fieldInfo.GetCustomAttributes(typeof(JsonMemberAttribute), true).Length != 0)
					{
						if (!JsonIgnoreAttribute.IsJsonIgnore(fieldInfo))
						{
							string jsonName2 = JsonNameAttribute.GetJsonName(fieldInfo);
							if (string.IsNullOrEmpty(jsonName2))
							{
								dictionary[fieldInfo.Name] = fieldInfo;
							}
							else
							{
								dictionary[jsonName2] = fieldInfo;
							}
						}
					}
				}
			}
			this.MemberMapCache[objectType] = dictionary;
			return dictionary;
		}

		internal static Type GetMemberInfo(Dictionary<string, MemberInfo> memberMap, string memberName, out MemberInfo memberInfo)
		{
			if (memberMap != null && memberMap.TryGetValue(memberName, out memberInfo))
			{
				if (memberInfo is PropertyInfo)
				{
					return ((PropertyInfo)memberInfo).PropertyType;
				}
				if (memberInfo is FieldInfo)
				{
					return ((FieldInfo)memberInfo).FieldType;
				}
			}
			memberInfo = null;
			return null;
		}

		internal void SetMemberValue(object result, Type memberType, MemberInfo memberInfo, object value)
		{
			if (memberInfo is PropertyInfo)
			{
				((PropertyInfo)memberInfo).SetValue(result, this.CoerceType(memberType, value), null);
			}
			else if (memberInfo is FieldInfo)
			{
				((FieldInfo)memberInfo).SetValue(result, this.CoerceType(memberType, value));
			}
		}

		internal object CoerceType(Type targetType, object value)
		{
			bool flag = TypeCoercionUtility.IsNullable(targetType);
			if (value == null)
			{
				if (!this.allowNullValueTypes && TypeCoercionUtility.GetTypeInfo(targetType).IsValueType && !flag)
				{
					throw new JsonTypeCoercionException(string.Format("{0} does not accept null as a value", new object[]
					{
						targetType.FullName
					}));
				}
				return value;
			}
			else
			{
				if (flag)
				{
					Type[] genericArguments = targetType.GetGenericArguments();
					if (genericArguments.Length == 1)
					{
						targetType = genericArguments[0];
					}
				}
				Type type = value.GetType();
				if (TypeCoercionUtility.GetTypeInfo(targetType).IsAssignableFrom(TypeCoercionUtility.GetTypeInfo(type)))
				{
					return value;
				}
				if (TypeCoercionUtility.GetTypeInfo(targetType).IsEnum)
				{
					if (value is string)
					{
						if (!Enum.IsDefined(targetType, value))
						{
							foreach (FieldInfo fieldInfo in TypeCoercionUtility.GetTypeInfo(targetType).GetFields())
							{
								string jsonName = JsonNameAttribute.GetJsonName(fieldInfo);
								if (((string)value).Equals(jsonName))
								{
									value = fieldInfo.Name;
									break;
								}
							}
						}
						return Enum.Parse(targetType, (string)value);
					}
					value = this.CoerceType(Enum.GetUnderlyingType(targetType), value);
					return Enum.ToObject(targetType, value);
				}
				else
				{
					if (value is IDictionary)
					{
						Dictionary<string, MemberInfo> dictionary;
						return this.CoerceType(targetType, (IDictionary)value, out dictionary);
					}
					if (TypeCoercionUtility.GetTypeInfo(typeof(IEnumerable)).IsAssignableFrom(TypeCoercionUtility.GetTypeInfo(targetType)) && TypeCoercionUtility.GetTypeInfo(typeof(IEnumerable)).IsAssignableFrom(TypeCoercionUtility.GetTypeInfo(type)))
					{
						return this.CoerceList(targetType, type, (IEnumerable)value);
					}
					if (value is string)
					{
						if (object.Equals(targetType, typeof(DateTime)))
						{
							DateTime dateTime;
							if (DateTime.TryParse((string)value, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.AllowLeadingWhite | DateTimeStyles.AllowTrailingWhite | DateTimeStyles.AllowInnerWhite | DateTimeStyles.NoCurrentDateDefault | DateTimeStyles.RoundtripKind, out dateTime))
							{
								return dateTime;
							}
						}
						else
						{
							if (object.Equals(targetType, typeof(Guid)))
							{
								return new Guid((string)value);
							}
							if (object.Equals(targetType, typeof(char)))
							{
								if (((string)value).Length == 1)
								{
									return ((string)value)[0];
								}
							}
							else if (object.Equals(targetType, typeof(Uri)))
							{
								Uri result;
								if (Uri.TryCreate((string)value, UriKind.RelativeOrAbsolute, out result))
								{
									return result;
								}
							}
							else if (object.Equals(targetType, typeof(Version)))
							{
								return new Version((string)value);
							}
						}
					}
					else if (object.Equals(targetType, typeof(TimeSpan)))
					{
						return new TimeSpan((long)this.CoerceType(typeof(long), value));
					}
					TypeConverter converter = TypeDescriptor.GetConverter(targetType);
					if (converter.CanConvertFrom(type))
					{
						return converter.ConvertFrom(value);
					}
					converter = TypeDescriptor.GetConverter(type);
					if (converter.CanConvertTo(targetType))
					{
						return converter.ConvertTo(value, targetType);
					}
					object result2;
					try
					{
						result2 = Convert.ChangeType(value, targetType);
					}
					catch (Exception innerException)
					{
						throw new JsonTypeCoercionException(string.Format("Error converting {0} to {1}", new object[]
						{
							value.GetType().FullName,
							targetType.FullName
						}), innerException);
					}
					return result2;
				}
			}
		}

		private object CoerceType(Type targetType, IDictionary value, out Dictionary<string, MemberInfo> memberMap)
		{
			object result = this.InstantiateObject(targetType, out memberMap);
			if (memberMap != null)
			{
				IEnumerator enumerator = value.Keys.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						MemberInfo memberInfo2;
						Type memberInfo = TypeCoercionUtility.GetMemberInfo(memberMap, obj as string, out memberInfo2);
						this.SetMemberValue(result, memberInfo, memberInfo2, value[obj]);
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
			}
			return result;
		}

		private object CoerceList(Type targetType, Type arrayType, IEnumerable value)
		{
			if (targetType.IsArray)
			{
				return this.CoerceArray(targetType.GetElementType(), value);
			}
			ConstructorInfo[] constructors = targetType.GetConstructors();
			ConstructorInfo constructorInfo = null;
			foreach (ConstructorInfo constructorInfo2 in constructors)
			{
				ParameterInfo[] parameters = constructorInfo2.GetParameters();
				if (parameters.Length == 0)
				{
					constructorInfo = constructorInfo2;
				}
				else if (parameters.Length == 1 && TypeCoercionUtility.GetTypeInfo(parameters[0].ParameterType).IsAssignableFrom(TypeCoercionUtility.GetTypeInfo(arrayType)))
				{
					try
					{
						return constructorInfo2.Invoke(new object[]
						{
							value
						});
					}
					catch
					{
					}
				}
			}
			if (object.Equals(constructorInfo, null))
			{
				throw new JsonTypeCoercionException(string.Format("Only objects with default constructors can be deserialized. ({0})", new object[]
				{
					targetType.FullName
				}));
			}
			object obj;
			try
			{
				obj = constructorInfo.Invoke(null);
			}
			catch (TargetInvocationException ex)
			{
				if (ex.InnerException != null)
				{
					throw new JsonTypeCoercionException(ex.InnerException.Message, ex.InnerException);
				}
				throw new JsonTypeCoercionException("Error instantiating " + targetType.FullName, ex);
			}
			MethodInfo method = TypeCoercionUtility.GetTypeInfo(targetType).GetMethod("AddRange");
			ParameterInfo[] array2 = (!object.Equals(method, null)) ? method.GetParameters() : null;
			Type type = (array2 != null && array2.Length == 1) ? array2[0].ParameterType : null;
			if (!object.Equals(type, null) && TypeCoercionUtility.GetTypeInfo(type).IsAssignableFrom(TypeCoercionUtility.GetTypeInfo(arrayType)))
			{
				try
				{
					method.Invoke(obj, new object[]
					{
						value
					});
				}
				catch (TargetInvocationException ex2)
				{
					if (ex2.InnerException != null)
					{
						throw new JsonTypeCoercionException(ex2.InnerException.Message, ex2.InnerException);
					}
					throw new JsonTypeCoercionException("Error calling AddRange on " + targetType.FullName, ex2);
				}
				return obj;
			}
			method = TypeCoercionUtility.GetTypeInfo(targetType).GetMethod("Add");
			array2 = ((!object.Equals(method, null)) ? method.GetParameters() : null);
			type = ((array2 != null && array2.Length == 1) ? array2[0].ParameterType : null);
			if (!object.Equals(type, null))
			{
				IEnumerator enumerator = value.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						object value2 = enumerator.Current;
						try
						{
							method.Invoke(obj, new object[]
							{
								this.CoerceType(type, value2)
							});
						}
						catch (TargetInvocationException ex3)
						{
							if (ex3.InnerException != null)
							{
								throw new JsonTypeCoercionException(ex3.InnerException.Message, ex3.InnerException);
							}
							throw new JsonTypeCoercionException("Error calling Add on " + targetType.FullName, ex3);
						}
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
				return obj;
			}
			object result;
			try
			{
				result = Convert.ChangeType(value, targetType);
			}
			catch (Exception innerException)
			{
				throw new JsonTypeCoercionException(string.Format("Error converting {0} to {1}", new object[]
				{
					value.GetType().FullName,
					targetType.FullName
				}), innerException);
			}
			return result;
		}

		private Array CoerceArray(Type elementType, IEnumerable value)
		{
			int num = 0;
			IEnumerator enumerator = value.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					num++;
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
			Array array = Array.CreateInstance(elementType, new int[]
			{
				num
			});
			int num2 = 0;
			IEnumerator enumerator2 = value.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					object value2 = enumerator2.Current;
					array.SetValue(this.CoerceType(elementType, value2), new int[]
					{
						num2
					});
					num2++;
				}
			}
			finally
			{
				IDisposable disposable2;
				if ((disposable2 = (enumerator2 as IDisposable)) != null)
				{
					disposable2.Dispose();
				}
			}
			return array;
		}

		private static bool IsNullable(Type type)
		{
			return TypeCoercionUtility.GetTypeInfo(type).IsGenericType && typeof(Nullable<>).Equals(type.GetGenericTypeDefinition());
		}

		private Dictionary<Type, Dictionary<string, MemberInfo>> memberMapCache;

		private bool allowNullValueTypes = true;
	}
}
