using System;
using System.Collections.Generic;

namespace Pathfinding.Serialization.JsonFx
{
	public abstract class JsonConverter
	{
		public abstract bool CanConvert(Type t);

		public object Read(JsonReader reader, Type type, Dictionary<string, object> value)
		{
			return this.ReadJson(type, value);
		}

		public abstract object ReadJson(Type type, Dictionary<string, object> value);

		public bool convertAtDepthZero;
	}
}
