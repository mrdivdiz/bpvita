using System;
using PlayFab.ClientModels;
using PlayFab.SharedModels;
using UnityEngine;

namespace PlayFab.Internal
{
    public static class PlayFabDeviceUtil
	{
		private static void DoAttributeInstall()
		{
			if (!PlayFabDeviceUtil._needsAttribution || PlayFabSettings.DisableAdvertising)
			{
				return;
			}
			AttributeInstallRequest attributeInstallRequest = new AttributeInstallRequest();
			string advertisingIdType = PlayFabSettings.AdvertisingIdType;
			if (advertisingIdType != null)
			{
				if (!(advertisingIdType == "Adid"))
				{
					if (advertisingIdType == "Idfa")
					{
						attributeInstallRequest.Idfa = PlayFabSettings.AdvertisingIdValue;
					}
				}
				else
				{
					attributeInstallRequest.Adid = PlayFabSettings.AdvertisingIdValue;
				}
			}
			AttributeInstallRequest request = attributeInstallRequest;
			PlayFabClientAPI.AttributeInstall(request, new Action<AttributeInstallResult>(PlayFabDeviceUtil.OnAttributeInstall), null, null, null);
		}

		private static void OnAttributeInstall(AttributeInstallResult result)
		{
			PlayFabSettings.AdvertisingIdType += "_Successful";
		}

		private static void SendDeviceInfoToPlayFab()
		{
			if (PlayFabSettings.DisableDeviceInfo || !PlayFabDeviceUtil._gatherInfo)
			{
				return;
			}
            DeviceInfoRequest deviceInfoRequest = new DeviceInfoRequest
            {
				Info = new PlayFabDataGatherer()
			};
			string apiEndpoint = "/Client/ReportDeviceInfo";
			PlayFabRequestCommon request = deviceInfoRequest;
			AuthType authType = AuthType.LoginSession;
			Action<EmptyResult> resultCallback = new Action<EmptyResult>(PlayFabDeviceUtil.OnGatherSuccess);
			PlayFabHttp.MakeApiCall(apiEndpoint, request, authType, resultCallback, new Action<PlayFabError>(PlayFabDeviceUtil.OnGatherFail), null, null, false);
		}

		private static void OnGatherSuccess(EmptyResult result)
		{
		}

		private static void OnGatherFail(PlayFabError error)
		{
		}

		public static void OnPlayFabLogin(PlayFabResultCommon result)
		{
			LoginResult loginResult = result as LoginResult;
			RegisterPlayFabUserResult registerPlayFabUserResult = result as RegisterPlayFabUserResult;
			if (loginResult == null && registerPlayFabUserResult == null)
			{
				return;
			}
			PlayFabDeviceUtil._needsAttribution = false;
			PlayFabDeviceUtil._gatherInfo = false;
			if (loginResult != null && loginResult.SettingsForUser != null)
			{
				PlayFabDeviceUtil._needsAttribution = loginResult.SettingsForUser.NeedsAttribution;
			}
			else if (registerPlayFabUserResult != null && registerPlayFabUserResult.SettingsForUser != null)
			{
				PlayFabDeviceUtil._needsAttribution = registerPlayFabUserResult.SettingsForUser.NeedsAttribution;
			}
			if (loginResult != null && loginResult.SettingsForUser != null)
			{
				PlayFabDeviceUtil._gatherInfo = loginResult.SettingsForUser.GatherDeviceInfo;
			}
			else if (registerPlayFabUserResult != null && registerPlayFabUserResult.SettingsForUser != null)
			{
				PlayFabDeviceUtil._gatherInfo = registerPlayFabUserResult.SettingsForUser.GatherDeviceInfo;
			}
			if (PlayFabSettings.AdvertisingIdType != null && PlayFabSettings.AdvertisingIdValue != null)
			{
				PlayFabDeviceUtil.DoAttributeInstall();
			}
			else
			{
				PlayFabDeviceUtil.GetAdvertIdFromUnity();
			}
			PlayFabDeviceUtil.SendDeviceInfoToPlayFab();
		}

		private static void GetAdvertIdFromUnity()
		{
			Application.RequestAdvertisingIdentifierAsync(delegate(string advertisingId, bool trackingEnabled, string error)
			{
				PlayFabSettings.DisableAdvertising = !trackingEnabled;
				if (!trackingEnabled)
				{
					return;
				}
				PlayFabSettings.AdvertisingIdType = "Adid";
				PlayFabSettings.AdvertisingIdValue = advertisingId;
				PlayFabDeviceUtil.DoAttributeInstall();
			});
		}

		private static bool _needsAttribution;

		private static bool _gatherInfo;

		private class DeviceInfoRequest : PlayFabRequestCommon
		{
			public PlayFabDataGatherer Info;
		}
	}
}
