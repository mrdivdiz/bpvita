namespace Pathfinding.Serialization.JsonFx
{
    public class JsonDeserializationException : JsonSerializationException
	{
		public JsonDeserializationException(string message, int index) : base(message)
		{
			this.index = index;
		}

		private int index = -1;
	}
}
