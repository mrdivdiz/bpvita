using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;

namespace PlayFab.Json
{
    [GeneratedCode("simple-json", "1.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class JsonArray : List<object>
	{
		public JsonArray()
		{
		}

		public JsonArray(int capacity) : base(capacity)
		{
		}

		public override string ToString()
		{
			return PlayFabSimpleJson.SerializeObject(this, null) ?? string.Empty;
		}
	}
}
