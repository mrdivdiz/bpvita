using System;
using UnityEngine;

namespace PlayFab
{
	public static class PlayFabSettings
	{
		private static PlayFabSharedSettings PlayFabSharedPrivate
		{
			get
			{
				if (PlayFabSettings._playFabShared == null)
				{
					PlayFabSettings._playFabShared = PlayFabSettings.GetSharedSettingsObjectPrivate();
				}
				return PlayFabSettings._playFabShared;
			}
		}

		[Obsolete("This field will become private after Mar 1, 2017", false)]
		public static PlayFabSharedSettings PlayFabShared
		{
			get
			{
				if (PlayFabSettings._playFabShared == null)
				{
					PlayFabSettings._playFabShared = PlayFabSettings.GetSharedSettingsObjectPrivate();
				}
				return PlayFabSettings._playFabShared;
			}
		}

		[Obsolete("This field will become private after Mar 1, 2017", false)]
		public static string DefaultPlayFabApiUrl
		{
			get
			{
				return ".playfabapi.com";
			}
		}

		private static PlayFabSharedSettings GetSharedSettingsObjectPrivate()
		{
			PlayFabSharedSettings[] array = Resources.LoadAll<PlayFabSharedSettings>("PlayFabSharedSettings");
			if (array.Length != 1)
			{
				throw new Exception("The number of PlayFabSharedSettings objects should be 1: " + array.Length);
			}
			return array[0];
		}

		private static string ProductionEnvironmentUrlPrivate
		{
			get
			{
				return string.IsNullOrEmpty(PlayFabSettings.PlayFabSharedPrivate.ProductionEnvironmentUrl) ? ".playfabapi.com" : PlayFabSettings.PlayFabSharedPrivate.ProductionEnvironmentUrl;
			}
			set
			{
				PlayFabSettings.PlayFabSharedPrivate.ProductionEnvironmentUrl = value;
			}
		}

		[Obsolete("This field will become private after Mar 1, 2017", false)]
		public static string ProductionEnvironmentUrl
		{
			get
			{
				return PlayFabSettings.ProductionEnvironmentUrlPrivate;
			}
			set
			{
				PlayFabSettings.ProductionEnvironmentUrlPrivate = value;
			}
		}

		public static string TitleId
		{
			get
			{
				return PlayFabSettings.PlayFabSharedPrivate.TitleId;
			}
			set
			{
				PlayFabSettings.PlayFabSharedPrivate.TitleId = value;
			}
		}

		public static PlayFabLogLevel LogLevel
		{
			get
			{
				return PlayFabSettings.PlayFabSharedPrivate.LogLevel;
			}
			set
			{
				PlayFabSettings.PlayFabSharedPrivate.LogLevel = value;
			}
		}

		public static WebRequestType RequestType
		{
			get
			{
				return PlayFabSettings.PlayFabSharedPrivate.RequestType;
			}
			set
			{
				PlayFabSettings.PlayFabSharedPrivate.RequestType = value;
			}
		}

		public static int RequestTimeout
		{
			get
			{
				return PlayFabSettings.PlayFabSharedPrivate.RequestTimeout;
			}
			set
			{
				PlayFabSettings.PlayFabSharedPrivate.RequestTimeout = value;
			}
		}

		public static bool RequestKeepAlive
		{
			get
			{
				return PlayFabSettings.PlayFabSharedPrivate.RequestKeepAlive;
			}
			set
			{
				PlayFabSettings.PlayFabSharedPrivate.RequestKeepAlive = value;
			}
		}

		public static bool CompressApiData
		{
			get
			{
				return PlayFabSettings.PlayFabSharedPrivate.CompressApiData;
			}
			set
			{
				PlayFabSettings.PlayFabSharedPrivate.CompressApiData = value;
			}
		}

		public static string LoggerHost
		{
			get
			{
				return PlayFabSettings.PlayFabSharedPrivate.LoggerHost;
			}
			set
			{
				PlayFabSettings.PlayFabSharedPrivate.LoggerHost = value;
			}
		}

		public static int LoggerPort
		{
			get
			{
				return PlayFabSettings.PlayFabSharedPrivate.LoggerPort;
			}
			set
			{
				PlayFabSettings.PlayFabSharedPrivate.LoggerPort = value;
			}
		}

		public static bool EnableRealTimeLogging
		{
			get
			{
				return PlayFabSettings.PlayFabSharedPrivate.EnableRealTimeLogging;
			}
			set
			{
				PlayFabSettings.PlayFabSharedPrivate.EnableRealTimeLogging = value;
			}
		}

		public static int LogCapLimit
		{
			get
			{
				return PlayFabSettings.PlayFabSharedPrivate.LogCapLimit;
			}
			set
			{
				PlayFabSettings.PlayFabSharedPrivate.LogCapLimit = value;
			}
		}

		public static string GetFullUrl(string apiCall)
		{
			string productionEnvironmentUrlPrivate = PlayFabSettings.ProductionEnvironmentUrlPrivate;
			string result;
			if (productionEnvironmentUrlPrivate.StartsWith("http"))
			{
				result = productionEnvironmentUrlPrivate + apiCall;
			}
			else
			{
				result = "https://" + PlayFabSettings.TitleId + productionEnvironmentUrlPrivate + apiCall;
			}
			return result;
		}

		public const string AD_TYPE_IDFA = "Idfa";

		public const string AD_TYPE_ANDROID_ID = "Adid";

		public static string AdvertisingIdType;

		public static string AdvertisingIdValue;

		public static bool DisableAdvertising;

		public static bool DisableDeviceInfo;

		private static PlayFabSharedSettings _playFabShared;

		public const string SdkVersion = "2.39.180409";

		public const string BuildIdentifier = "jbuild_unitysdk_sdk-unity-4-slave_0";

		public const string VersionString = "UnitySDK-2.39.180409";

		private const string DefaultPlayFabApiUrlPrivate = ".playfabapi.com";
	}
}
