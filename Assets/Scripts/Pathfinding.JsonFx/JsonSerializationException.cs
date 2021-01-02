using System;

namespace Pathfinding.Serialization.JsonFx
{
	public class JsonSerializationException : InvalidOperationException
	{
		public JsonSerializationException(string message) : base(message)
		{
		}
	}
}
