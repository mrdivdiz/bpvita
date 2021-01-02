using System;
using System.Reflection;

namespace Pathfinding.Serialization.JsonFx
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
	public sealed class JsonIgnoreAttribute : Attribute
	{
		public static bool IsJsonIgnore(object value)
		{
			if (value == null)
			{
				return false;
			}
			Type type = value.GetType();
			ICustomAttributeProvider customAttributeProvider;
			if (TypeCoercionUtility.GetTypeInfo(type).IsEnum)
			{
				customAttributeProvider = TypeCoercionUtility.GetTypeInfo(type).GetField(Enum.GetName(type, value));
			}
			else
			{
				customAttributeProvider = (value as ICustomAttributeProvider);
			}
			if (customAttributeProvider == null)
			{
				throw new ArgumentException();
			}
			return customAttributeProvider.IsDefined(typeof(JsonIgnoreAttribute), true);
		}
	}
}
