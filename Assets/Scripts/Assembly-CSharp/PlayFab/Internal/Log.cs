namespace PlayFab.Internal
{
    public static class Log
	{
		public static void Debug(string text, params object[] args)
		{
			if ((PlayFabSettings.LogLevel & PlayFabLogLevel.Debug) != PlayFabLogLevel.None)
			{
				UnityEngine.Debug.Log(PlayFabUtil.timeStamp + " DEBUG: " + PlayFabUtil.Format(text, args));
			}
		}

		public static void Info(string text, params object[] args)
		{
			if ((PlayFabSettings.LogLevel & PlayFabLogLevel.Info) != PlayFabLogLevel.None)
			{
				UnityEngine.Debug.Log(PlayFabUtil.timeStamp + " INFO: " + PlayFabUtil.Format(text, args));
			}
		}

		public static void Warning(string text, params object[] args)
		{
			if ((PlayFabSettings.LogLevel & PlayFabLogLevel.Warning) != PlayFabLogLevel.None)
			{
				UnityEngine.Debug.LogWarning(PlayFabUtil.timeStamp + " WARNING: " + PlayFabUtil.Format(text, args));
			}
		}

		public static void Error(string text, params object[] args)
		{
			if ((PlayFabSettings.LogLevel & PlayFabLogLevel.Error) != PlayFabLogLevel.None)
			{
				UnityEngine.Debug.LogError(PlayFabUtil.timeStamp + " ERROR: " + PlayFabUtil.Format(text, args));
			}
		}
	}
}
