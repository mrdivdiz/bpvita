using PlayFab;
using UnityEngine;

public class PlayFabSharedSettings : ScriptableObject
{
	public string TitleId;

	public string ProductionEnvironmentUrl = string.Empty;

	public WebRequestType RequestType;

	public int RequestTimeout = 2000;

	public bool RequestKeepAlive = true;

	public bool CompressApiData = true;

	public PlayFabLogLevel LogLevel = PlayFabLogLevel.Warning | PlayFabLogLevel.Error;

	public string LoggerHost = string.Empty;

	public int LoggerPort;

	public bool EnableRealTimeLogging;

	public int LogCapLimit = 30;
}
