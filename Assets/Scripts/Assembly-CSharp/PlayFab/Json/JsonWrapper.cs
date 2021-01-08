namespace PlayFab.Json
{
    public static class JsonWrapper
	{
		public static ISerializer Instance
		{
			get
			{
				return JsonWrapper._instance;
			}
			set
			{
				JsonWrapper._instance = value;
			}
		}

		public static T DeserializeObject<T>(string json)
		{
			return JsonWrapper._instance.DeserializeObject<T>(json);
		}

		public static T DeserializeObject<T>(string json, object jsonSerializerStrategy)
		{
			return JsonWrapper._instance.DeserializeObject<T>(json, jsonSerializerStrategy);
		}

		public static object DeserializeObject(string json)
		{
			return JsonWrapper._instance.DeserializeObject(json);
		}

		public static string SerializeObject(object json)
		{
			return JsonWrapper._instance.SerializeObject(json);
		}

		public static string SerializeObject(object json, object jsonSerializerStrategy)
		{
			return JsonWrapper._instance.SerializeObject(json, jsonSerializerStrategy);
		}

		private static ISerializer _instance = new SimpleJsonInstance();
	}
}
