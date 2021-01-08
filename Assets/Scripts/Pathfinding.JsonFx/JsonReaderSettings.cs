using System;
using System.Collections.Generic;

namespace Pathfinding.Serialization.JsonFx
{
	public class JsonReaderSettings
	{
        public bool HandleCyclicReferences { get; }

		public bool AllowUnquotedObjectKeys
		{
			get
			{
				return this.allowUnquotedObjectKeys;
			}
		}

		internal bool IsTypeHintName(string name)
		{
			return !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(this.typeHintName) && StringComparer.Ordinal.Equals(this.typeHintName, name);
		}

		public virtual JsonConverter GetConverter(Type type)
		{
			for (int i = 0; i < this.converters.Count; i++)
			{
				if (this.converters[i].CanConvert(type))
				{
					return this.converters[i];
				}
			}
			return null;
		}

		internal readonly TypeCoercionUtility Coercion = new TypeCoercionUtility();

		private bool allowUnquotedObjectKeys;

		private string typeHintName;

		protected List<JsonConverter> converters = new List<JsonConverter>();
	}
}
