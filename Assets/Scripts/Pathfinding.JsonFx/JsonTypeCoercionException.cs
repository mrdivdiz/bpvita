using System;

namespace Pathfinding.Serialization.JsonFx
{
	public class JsonTypeCoercionException : ArgumentException
	{
		public JsonTypeCoercionException(string message) : base(message)
		{
		}

		public JsonTypeCoercionException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
