using System;
using PlayFab.ClientModels;
using PlayFab.Internal;
using PlayFab.SharedModels;

namespace PlayFab.Events
{
    public class PlayFabEvents
	{
		private PlayFabEvents()
		{
		}

		public event PlayFabResultEvent<LoginResult> OnLoginResultEvent;

		public event PlayFabRequestEvent<AcceptTradeRequest> OnAcceptTradeRequestEvent;

		public event PlayFabResultEvent<AcceptTradeResponse> OnAcceptTradeResultEvent;

		public event PlayFabRequestEvent<AddFriendRequest> OnAddFriendRequestEvent;

		public event PlayFabResultEvent<AddFriendResult> OnAddFriendResultEvent;

		public event PlayFabRequestEvent<AddGenericIDRequest> OnAddGenericIDRequestEvent;

		public event PlayFabResultEvent<AddGenericIDResult> OnAddGenericIDResultEvent;

		public event PlayFabRequestEvent<AddOrUpdateContactEmailRequest> OnAddOrUpdateContactEmailRequestEvent;

		public event PlayFabResultEvent<AddOrUpdateContactEmailResult> OnAddOrUpdateContactEmailResultEvent;

		public event PlayFabRequestEvent<AddSharedGroupMembersRequest> OnAddSharedGroupMembersRequestEvent;

		public event PlayFabResultEvent<AddSharedGroupMembersResult> OnAddSharedGroupMembersResultEvent;

		public event PlayFabRequestEvent<AddUsernamePasswordRequest> OnAddUsernamePasswordRequestEvent;

		public event PlayFabResultEvent<AddUsernamePasswordResult> OnAddUsernamePasswordResultEvent;

		public event PlayFabRequestEvent<AddUserVirtualCurrencyRequest> OnAddUserVirtualCurrencyRequestEvent;

		public event PlayFabResultEvent<ModifyUserVirtualCurrencyResult> OnAddUserVirtualCurrencyResultEvent;

		public event PlayFabRequestEvent<AndroidDevicePushNotificationRegistrationRequest> OnAndroidDevicePushNotificationRegistrationRequestEvent;

		public event PlayFabResultEvent<AndroidDevicePushNotificationRegistrationResult> OnAndroidDevicePushNotificationRegistrationResultEvent;

		public event PlayFabRequestEvent<AttributeInstallRequest> OnAttributeInstallRequestEvent;

		public event PlayFabResultEvent<AttributeInstallResult> OnAttributeInstallResultEvent;

		public event PlayFabRequestEvent<CancelTradeRequest> OnCancelTradeRequestEvent;

		public event PlayFabResultEvent<CancelTradeResponse> OnCancelTradeResultEvent;

		public event PlayFabRequestEvent<ConfirmPurchaseRequest> OnConfirmPurchaseRequestEvent;

		public event PlayFabResultEvent<ConfirmPurchaseResult> OnConfirmPurchaseResultEvent;

		public event PlayFabRequestEvent<ConsumeItemRequest> OnConsumeItemRequestEvent;

		public event PlayFabResultEvent<ConsumeItemResult> OnConsumeItemResultEvent;

		public event PlayFabRequestEvent<CreateSharedGroupRequest> OnCreateSharedGroupRequestEvent;

		public event PlayFabResultEvent<CreateSharedGroupResult> OnCreateSharedGroupResultEvent;

		public event PlayFabRequestEvent<ExecuteCloudScriptRequest> OnExecuteCloudScriptRequestEvent;

		public event PlayFabResultEvent<ExecuteCloudScriptResult> OnExecuteCloudScriptResultEvent;

		public event PlayFabRequestEvent<GetAccountInfoRequest> OnGetAccountInfoRequestEvent;

		public event PlayFabResultEvent<GetAccountInfoResult> OnGetAccountInfoResultEvent;

		public event PlayFabRequestEvent<ListUsersCharactersRequest> OnGetAllUsersCharactersRequestEvent;

		public event PlayFabResultEvent<ListUsersCharactersResult> OnGetAllUsersCharactersResultEvent;

		public event PlayFabRequestEvent<GetCatalogItemsRequest> OnGetCatalogItemsRequestEvent;

		public event PlayFabResultEvent<GetCatalogItemsResult> OnGetCatalogItemsResultEvent;

		public event PlayFabRequestEvent<GetCharacterDataRequest> OnGetCharacterDataRequestEvent;

		public event PlayFabResultEvent<GetCharacterDataResult> OnGetCharacterDataResultEvent;

		public event PlayFabRequestEvent<GetCharacterInventoryRequest> OnGetCharacterInventoryRequestEvent;

		public event PlayFabResultEvent<GetCharacterInventoryResult> OnGetCharacterInventoryResultEvent;

		public event PlayFabRequestEvent<GetCharacterLeaderboardRequest> OnGetCharacterLeaderboardRequestEvent;

		public event PlayFabResultEvent<GetCharacterLeaderboardResult> OnGetCharacterLeaderboardResultEvent;

		public event PlayFabRequestEvent<GetCharacterDataRequest> OnGetCharacterReadOnlyDataRequestEvent;

		public event PlayFabResultEvent<GetCharacterDataResult> OnGetCharacterReadOnlyDataResultEvent;

		public event PlayFabRequestEvent<GetCharacterStatisticsRequest> OnGetCharacterStatisticsRequestEvent;

		public event PlayFabResultEvent<GetCharacterStatisticsResult> OnGetCharacterStatisticsResultEvent;

		public event PlayFabRequestEvent<GetContentDownloadUrlRequest> OnGetContentDownloadUrlRequestEvent;

		public event PlayFabResultEvent<GetContentDownloadUrlResult> OnGetContentDownloadUrlResultEvent;

		public event PlayFabRequestEvent<CurrentGamesRequest> OnGetCurrentGamesRequestEvent;

		public event PlayFabResultEvent<CurrentGamesResult> OnGetCurrentGamesResultEvent;

		public event PlayFabRequestEvent<GetFriendLeaderboardRequest> OnGetFriendLeaderboardRequestEvent;

		public event PlayFabResultEvent<GetLeaderboardResult> OnGetFriendLeaderboardResultEvent;

		public event PlayFabRequestEvent<GetFriendLeaderboardAroundPlayerRequest> OnGetFriendLeaderboardAroundPlayerRequestEvent;

		public event PlayFabResultEvent<GetFriendLeaderboardAroundPlayerResult> OnGetFriendLeaderboardAroundPlayerResultEvent;

		public event PlayFabRequestEvent<GetFriendsListRequest> OnGetFriendsListRequestEvent;

		public event PlayFabResultEvent<GetFriendsListResult> OnGetFriendsListResultEvent;

		public event PlayFabRequestEvent<GameServerRegionsRequest> OnGetGameServerRegionsRequestEvent;

		public event PlayFabResultEvent<GameServerRegionsResult> OnGetGameServerRegionsResultEvent;

		public event PlayFabRequestEvent<GetLeaderboardRequest> OnGetLeaderboardRequestEvent;

		public event PlayFabResultEvent<GetLeaderboardResult> OnGetLeaderboardResultEvent;

		public event PlayFabRequestEvent<GetLeaderboardAroundCharacterRequest> OnGetLeaderboardAroundCharacterRequestEvent;

		public event PlayFabResultEvent<GetLeaderboardAroundCharacterResult> OnGetLeaderboardAroundCharacterResultEvent;

		public event PlayFabRequestEvent<GetLeaderboardAroundPlayerRequest> OnGetLeaderboardAroundPlayerRequestEvent;

		public event PlayFabResultEvent<GetLeaderboardAroundPlayerResult> OnGetLeaderboardAroundPlayerResultEvent;

		public event PlayFabRequestEvent<GetLeaderboardForUsersCharactersRequest> OnGetLeaderboardForUserCharactersRequestEvent;

		public event PlayFabResultEvent<GetLeaderboardForUsersCharactersResult> OnGetLeaderboardForUserCharactersResultEvent;

		public event PlayFabRequestEvent<GetPaymentTokenRequest> OnGetPaymentTokenRequestEvent;

		public event PlayFabResultEvent<GetPaymentTokenResult> OnGetPaymentTokenResultEvent;

		public event PlayFabRequestEvent<GetPhotonAuthenticationTokenRequest> OnGetPhotonAuthenticationTokenRequestEvent;

		public event PlayFabResultEvent<GetPhotonAuthenticationTokenResult> OnGetPhotonAuthenticationTokenResultEvent;

		public event PlayFabRequestEvent<GetPlayerCombinedInfoRequest> OnGetPlayerCombinedInfoRequestEvent;

		public event PlayFabResultEvent<GetPlayerCombinedInfoResult> OnGetPlayerCombinedInfoResultEvent;

		public event PlayFabRequestEvent<GetPlayerProfileRequest> OnGetPlayerProfileRequestEvent;

		public event PlayFabResultEvent<GetPlayerProfileResult> OnGetPlayerProfileResultEvent;

		public event PlayFabRequestEvent<GetPlayerSegmentsRequest> OnGetPlayerSegmentsRequestEvent;

		public event PlayFabResultEvent<GetPlayerSegmentsResult> OnGetPlayerSegmentsResultEvent;

		public event PlayFabRequestEvent<GetPlayerStatisticsRequest> OnGetPlayerStatisticsRequestEvent;

		public event PlayFabResultEvent<GetPlayerStatisticsResult> OnGetPlayerStatisticsResultEvent;

		public event PlayFabRequestEvent<GetPlayerStatisticVersionsRequest> OnGetPlayerStatisticVersionsRequestEvent;

		public event PlayFabResultEvent<GetPlayerStatisticVersionsResult> OnGetPlayerStatisticVersionsResultEvent;

		public event PlayFabRequestEvent<GetPlayerTagsRequest> OnGetPlayerTagsRequestEvent;

		public event PlayFabResultEvent<GetPlayerTagsResult> OnGetPlayerTagsResultEvent;

		public event PlayFabRequestEvent<GetPlayerTradesRequest> OnGetPlayerTradesRequestEvent;

		public event PlayFabResultEvent<GetPlayerTradesResponse> OnGetPlayerTradesResultEvent;

		public event PlayFabRequestEvent<GetPlayFabIDsFromFacebookIDsRequest> OnGetPlayFabIDsFromFacebookIDsRequestEvent;

		public event PlayFabResultEvent<GetPlayFabIDsFromFacebookIDsResult> OnGetPlayFabIDsFromFacebookIDsResultEvent;

		public event PlayFabRequestEvent<GetPlayFabIDsFromGameCenterIDsRequest> OnGetPlayFabIDsFromGameCenterIDsRequestEvent;

		public event PlayFabResultEvent<GetPlayFabIDsFromGameCenterIDsResult> OnGetPlayFabIDsFromGameCenterIDsResultEvent;

		public event PlayFabRequestEvent<GetPlayFabIDsFromGenericIDsRequest> OnGetPlayFabIDsFromGenericIDsRequestEvent;

		public event PlayFabResultEvent<GetPlayFabIDsFromGenericIDsResult> OnGetPlayFabIDsFromGenericIDsResultEvent;

		public event PlayFabRequestEvent<GetPlayFabIDsFromGoogleIDsRequest> OnGetPlayFabIDsFromGoogleIDsRequestEvent;

		public event PlayFabResultEvent<GetPlayFabIDsFromGoogleIDsResult> OnGetPlayFabIDsFromGoogleIDsResultEvent;

		public event PlayFabRequestEvent<GetPlayFabIDsFromKongregateIDsRequest> OnGetPlayFabIDsFromKongregateIDsRequestEvent;

		public event PlayFabResultEvent<GetPlayFabIDsFromKongregateIDsResult> OnGetPlayFabIDsFromKongregateIDsResultEvent;

		public event PlayFabRequestEvent<GetPlayFabIDsFromSteamIDsRequest> OnGetPlayFabIDsFromSteamIDsRequestEvent;

		public event PlayFabResultEvent<GetPlayFabIDsFromSteamIDsResult> OnGetPlayFabIDsFromSteamIDsResultEvent;

		public event PlayFabRequestEvent<GetPlayFabIDsFromTwitchIDsRequest> OnGetPlayFabIDsFromTwitchIDsRequestEvent;

		public event PlayFabResultEvent<GetPlayFabIDsFromTwitchIDsResult> OnGetPlayFabIDsFromTwitchIDsResultEvent;

		public event PlayFabRequestEvent<GetPublisherDataRequest> OnGetPublisherDataRequestEvent;

		public event PlayFabResultEvent<GetPublisherDataResult> OnGetPublisherDataResultEvent;

		public event PlayFabRequestEvent<GetPurchaseRequest> OnGetPurchaseRequestEvent;

		public event PlayFabResultEvent<GetPurchaseResult> OnGetPurchaseResultEvent;

		public event PlayFabRequestEvent<GetSharedGroupDataRequest> OnGetSharedGroupDataRequestEvent;

		public event PlayFabResultEvent<GetSharedGroupDataResult> OnGetSharedGroupDataResultEvent;

		public event PlayFabRequestEvent<GetStoreItemsRequest> OnGetStoreItemsRequestEvent;

		public event PlayFabResultEvent<GetStoreItemsResult> OnGetStoreItemsResultEvent;

		public event PlayFabRequestEvent<GetTimeRequest> OnGetTimeRequestEvent;

		public event PlayFabResultEvent<GetTimeResult> OnGetTimeResultEvent;

		public event PlayFabRequestEvent<GetTitleDataRequest> OnGetTitleDataRequestEvent;

		public event PlayFabResultEvent<GetTitleDataResult> OnGetTitleDataResultEvent;

		public event PlayFabRequestEvent<GetTitleNewsRequest> OnGetTitleNewsRequestEvent;

		public event PlayFabResultEvent<GetTitleNewsResult> OnGetTitleNewsResultEvent;

		public event PlayFabRequestEvent<GetTitlePublicKeyRequest> OnGetTitlePublicKeyRequestEvent;

		public event PlayFabResultEvent<GetTitlePublicKeyResult> OnGetTitlePublicKeyResultEvent;

		public event PlayFabRequestEvent<GetTradeStatusRequest> OnGetTradeStatusRequestEvent;

		public event PlayFabResultEvent<GetTradeStatusResponse> OnGetTradeStatusResultEvent;

		public event PlayFabRequestEvent<GetUserDataRequest> OnGetUserDataRequestEvent;

		public event PlayFabResultEvent<GetUserDataResult> OnGetUserDataResultEvent;

		public event PlayFabRequestEvent<GetUserInventoryRequest> OnGetUserInventoryRequestEvent;

		public event PlayFabResultEvent<GetUserInventoryResult> OnGetUserInventoryResultEvent;

		public event PlayFabRequestEvent<GetUserDataRequest> OnGetUserPublisherDataRequestEvent;

		public event PlayFabResultEvent<GetUserDataResult> OnGetUserPublisherDataResultEvent;

		public event PlayFabRequestEvent<GetUserDataRequest> OnGetUserPublisherReadOnlyDataRequestEvent;

		public event PlayFabResultEvent<GetUserDataResult> OnGetUserPublisherReadOnlyDataResultEvent;

		public event PlayFabRequestEvent<GetUserDataRequest> OnGetUserReadOnlyDataRequestEvent;

		public event PlayFabResultEvent<GetUserDataResult> OnGetUserReadOnlyDataResultEvent;

		public event PlayFabRequestEvent<GetWindowsHelloChallengeRequest> OnGetWindowsHelloChallengeRequestEvent;

		public event PlayFabResultEvent<GetWindowsHelloChallengeResponse> OnGetWindowsHelloChallengeResultEvent;

		public event PlayFabRequestEvent<GrantCharacterToUserRequest> OnGrantCharacterToUserRequestEvent;

		public event PlayFabResultEvent<GrantCharacterToUserResult> OnGrantCharacterToUserResultEvent;

		public event PlayFabRequestEvent<LinkAndroidDeviceIDRequest> OnLinkAndroidDeviceIDRequestEvent;

		public event PlayFabResultEvent<LinkAndroidDeviceIDResult> OnLinkAndroidDeviceIDResultEvent;

		public event PlayFabRequestEvent<LinkCustomIDRequest> OnLinkCustomIDRequestEvent;

		public event PlayFabResultEvent<LinkCustomIDResult> OnLinkCustomIDResultEvent;

		public event PlayFabRequestEvent<LinkFacebookAccountRequest> OnLinkFacebookAccountRequestEvent;

		public event PlayFabResultEvent<LinkFacebookAccountResult> OnLinkFacebookAccountResultEvent;

		public event PlayFabRequestEvent<LinkGameCenterAccountRequest> OnLinkGameCenterAccountRequestEvent;

		public event PlayFabResultEvent<LinkGameCenterAccountResult> OnLinkGameCenterAccountResultEvent;

		public event PlayFabRequestEvent<LinkGoogleAccountRequest> OnLinkGoogleAccountRequestEvent;

		public event PlayFabResultEvent<LinkGoogleAccountResult> OnLinkGoogleAccountResultEvent;

		public event PlayFabRequestEvent<LinkIOSDeviceIDRequest> OnLinkIOSDeviceIDRequestEvent;

		public event PlayFabResultEvent<LinkIOSDeviceIDResult> OnLinkIOSDeviceIDResultEvent;

		public event PlayFabRequestEvent<LinkKongregateAccountRequest> OnLinkKongregateRequestEvent;

		public event PlayFabResultEvent<LinkKongregateAccountResult> OnLinkKongregateResultEvent;

		public event PlayFabRequestEvent<LinkSteamAccountRequest> OnLinkSteamAccountRequestEvent;

		public event PlayFabResultEvent<LinkSteamAccountResult> OnLinkSteamAccountResultEvent;

		public event PlayFabRequestEvent<LinkTwitchAccountRequest> OnLinkTwitchRequestEvent;

		public event PlayFabResultEvent<LinkTwitchAccountResult> OnLinkTwitchResultEvent;

		public event PlayFabRequestEvent<LinkWindowsHelloAccountRequest> OnLinkWindowsHelloRequestEvent;

		public event PlayFabResultEvent<LinkWindowsHelloAccountResponse> OnLinkWindowsHelloResultEvent;

		public event PlayFabRequestEvent<LoginWithAndroidDeviceIDRequest> OnLoginWithAndroidDeviceIDRequestEvent;

		public event PlayFabRequestEvent<LoginWithCustomIDRequest> OnLoginWithCustomIDRequestEvent;

		public event PlayFabRequestEvent<LoginWithEmailAddressRequest> OnLoginWithEmailAddressRequestEvent;

		public event PlayFabRequestEvent<LoginWithFacebookRequest> OnLoginWithFacebookRequestEvent;

		public event PlayFabRequestEvent<LoginWithGameCenterRequest> OnLoginWithGameCenterRequestEvent;

		public event PlayFabRequestEvent<LoginWithGoogleAccountRequest> OnLoginWithGoogleAccountRequestEvent;

		public event PlayFabRequestEvent<LoginWithIOSDeviceIDRequest> OnLoginWithIOSDeviceIDRequestEvent;

		public event PlayFabRequestEvent<LoginWithKongregateRequest> OnLoginWithKongregateRequestEvent;

		public event PlayFabRequestEvent<LoginWithPlayFabRequest> OnLoginWithPlayFabRequestEvent;

		public event PlayFabRequestEvent<LoginWithSteamRequest> OnLoginWithSteamRequestEvent;

		public event PlayFabRequestEvent<LoginWithTwitchRequest> OnLoginWithTwitchRequestEvent;

		public event PlayFabRequestEvent<LoginWithWindowsHelloRequest> OnLoginWithWindowsHelloRequestEvent;

		public event PlayFabRequestEvent<MatchmakeRequest> OnMatchmakeRequestEvent;

		public event PlayFabResultEvent<MatchmakeResult> OnMatchmakeResultEvent;

		public event PlayFabRequestEvent<OpenTradeRequest> OnOpenTradeRequestEvent;

		public event PlayFabResultEvent<OpenTradeResponse> OnOpenTradeResultEvent;

		public event PlayFabRequestEvent<PayForPurchaseRequest> OnPayForPurchaseRequestEvent;

		public event PlayFabResultEvent<PayForPurchaseResult> OnPayForPurchaseResultEvent;

		public event PlayFabRequestEvent<PurchaseItemRequest> OnPurchaseItemRequestEvent;

		public event PlayFabResultEvent<PurchaseItemResult> OnPurchaseItemResultEvent;

		public event PlayFabRequestEvent<RedeemCouponRequest> OnRedeemCouponRequestEvent;

		public event PlayFabResultEvent<RedeemCouponResult> OnRedeemCouponResultEvent;

		public event PlayFabRequestEvent<RegisterForIOSPushNotificationRequest> OnRegisterForIOSPushNotificationRequestEvent;

		public event PlayFabResultEvent<RegisterForIOSPushNotificationResult> OnRegisterForIOSPushNotificationResultEvent;

		public event PlayFabRequestEvent<RegisterPlayFabUserRequest> OnRegisterPlayFabUserRequestEvent;

		public event PlayFabResultEvent<RegisterPlayFabUserResult> OnRegisterPlayFabUserResultEvent;

		public event PlayFabRequestEvent<RegisterWithWindowsHelloRequest> OnRegisterWithWindowsHelloRequestEvent;

		public event PlayFabRequestEvent<RemoveContactEmailRequest> OnRemoveContactEmailRequestEvent;

		public event PlayFabResultEvent<RemoveContactEmailResult> OnRemoveContactEmailResultEvent;

		public event PlayFabRequestEvent<RemoveFriendRequest> OnRemoveFriendRequestEvent;

		public event PlayFabResultEvent<RemoveFriendResult> OnRemoveFriendResultEvent;

		public event PlayFabRequestEvent<RemoveGenericIDRequest> OnRemoveGenericIDRequestEvent;

		public event PlayFabResultEvent<RemoveGenericIDResult> OnRemoveGenericIDResultEvent;

		public event PlayFabRequestEvent<RemoveSharedGroupMembersRequest> OnRemoveSharedGroupMembersRequestEvent;

		public event PlayFabResultEvent<RemoveSharedGroupMembersResult> OnRemoveSharedGroupMembersResultEvent;

		public event PlayFabRequestEvent<DeviceInfoRequest> OnReportDeviceInfoRequestEvent;

		public event PlayFabResultEvent<EmptyResult> OnReportDeviceInfoResultEvent;

		public event PlayFabRequestEvent<ReportPlayerClientRequest> OnReportPlayerRequestEvent;

		public event PlayFabResultEvent<ReportPlayerClientResult> OnReportPlayerResultEvent;

		public event PlayFabRequestEvent<RestoreIOSPurchasesRequest> OnRestoreIOSPurchasesRequestEvent;

		public event PlayFabResultEvent<RestoreIOSPurchasesResult> OnRestoreIOSPurchasesResultEvent;

		public event PlayFabRequestEvent<SendAccountRecoveryEmailRequest> OnSendAccountRecoveryEmailRequestEvent;

		public event PlayFabResultEvent<SendAccountRecoveryEmailResult> OnSendAccountRecoveryEmailResultEvent;

		public event PlayFabRequestEvent<SetFriendTagsRequest> OnSetFriendTagsRequestEvent;

		public event PlayFabResultEvent<SetFriendTagsResult> OnSetFriendTagsResultEvent;

		public event PlayFabRequestEvent<SetPlayerSecretRequest> OnSetPlayerSecretRequestEvent;

		public event PlayFabResultEvent<SetPlayerSecretResult> OnSetPlayerSecretResultEvent;

		public event PlayFabRequestEvent<StartGameRequest> OnStartGameRequestEvent;

		public event PlayFabResultEvent<StartGameResult> OnStartGameResultEvent;

		public event PlayFabRequestEvent<StartPurchaseRequest> OnStartPurchaseRequestEvent;

		public event PlayFabResultEvent<StartPurchaseResult> OnStartPurchaseResultEvent;

		public event PlayFabRequestEvent<SubtractUserVirtualCurrencyRequest> OnSubtractUserVirtualCurrencyRequestEvent;

		public event PlayFabResultEvent<ModifyUserVirtualCurrencyResult> OnSubtractUserVirtualCurrencyResultEvent;

		public event PlayFabRequestEvent<UnlinkAndroidDeviceIDRequest> OnUnlinkAndroidDeviceIDRequestEvent;

		public event PlayFabResultEvent<UnlinkAndroidDeviceIDResult> OnUnlinkAndroidDeviceIDResultEvent;

		public event PlayFabRequestEvent<UnlinkCustomIDRequest> OnUnlinkCustomIDRequestEvent;

		public event PlayFabResultEvent<UnlinkCustomIDResult> OnUnlinkCustomIDResultEvent;

		public event PlayFabRequestEvent<UnlinkFacebookAccountRequest> OnUnlinkFacebookAccountRequestEvent;

		public event PlayFabResultEvent<UnlinkFacebookAccountResult> OnUnlinkFacebookAccountResultEvent;

		public event PlayFabRequestEvent<UnlinkGameCenterAccountRequest> OnUnlinkGameCenterAccountRequestEvent;

		public event PlayFabResultEvent<UnlinkGameCenterAccountResult> OnUnlinkGameCenterAccountResultEvent;

		public event PlayFabRequestEvent<UnlinkGoogleAccountRequest> OnUnlinkGoogleAccountRequestEvent;

		public event PlayFabResultEvent<UnlinkGoogleAccountResult> OnUnlinkGoogleAccountResultEvent;

		public event PlayFabRequestEvent<UnlinkIOSDeviceIDRequest> OnUnlinkIOSDeviceIDRequestEvent;

		public event PlayFabResultEvent<UnlinkIOSDeviceIDResult> OnUnlinkIOSDeviceIDResultEvent;

		public event PlayFabRequestEvent<UnlinkKongregateAccountRequest> OnUnlinkKongregateRequestEvent;

		public event PlayFabResultEvent<UnlinkKongregateAccountResult> OnUnlinkKongregateResultEvent;

		public event PlayFabRequestEvent<UnlinkSteamAccountRequest> OnUnlinkSteamAccountRequestEvent;

		public event PlayFabResultEvent<UnlinkSteamAccountResult> OnUnlinkSteamAccountResultEvent;

		public event PlayFabRequestEvent<UnlinkTwitchAccountRequest> OnUnlinkTwitchRequestEvent;

		public event PlayFabResultEvent<UnlinkTwitchAccountResult> OnUnlinkTwitchResultEvent;

		public event PlayFabRequestEvent<UnlinkWindowsHelloAccountRequest> OnUnlinkWindowsHelloRequestEvent;

		public event PlayFabResultEvent<UnlinkWindowsHelloAccountResponse> OnUnlinkWindowsHelloResultEvent;

		public event PlayFabRequestEvent<UnlockContainerInstanceRequest> OnUnlockContainerInstanceRequestEvent;

		public event PlayFabResultEvent<UnlockContainerItemResult> OnUnlockContainerInstanceResultEvent;

		public event PlayFabRequestEvent<UnlockContainerItemRequest> OnUnlockContainerItemRequestEvent;

		public event PlayFabResultEvent<UnlockContainerItemResult> OnUnlockContainerItemResultEvent;

		public event PlayFabRequestEvent<UpdateAvatarUrlRequest> OnUpdateAvatarUrlRequestEvent;

		public event PlayFabResultEvent<EmptyResult> OnUpdateAvatarUrlResultEvent;

		public event PlayFabRequestEvent<UpdateCharacterDataRequest> OnUpdateCharacterDataRequestEvent;

		public event PlayFabResultEvent<UpdateCharacterDataResult> OnUpdateCharacterDataResultEvent;

		public event PlayFabRequestEvent<UpdateCharacterStatisticsRequest> OnUpdateCharacterStatisticsRequestEvent;

		public event PlayFabResultEvent<UpdateCharacterStatisticsResult> OnUpdateCharacterStatisticsResultEvent;

		public event PlayFabRequestEvent<UpdatePlayerStatisticsRequest> OnUpdatePlayerStatisticsRequestEvent;

		public event PlayFabResultEvent<UpdatePlayerStatisticsResult> OnUpdatePlayerStatisticsResultEvent;

		public event PlayFabRequestEvent<UpdateSharedGroupDataRequest> OnUpdateSharedGroupDataRequestEvent;

		public event PlayFabResultEvent<UpdateSharedGroupDataResult> OnUpdateSharedGroupDataResultEvent;

		public event PlayFabRequestEvent<UpdateUserDataRequest> OnUpdateUserDataRequestEvent;

		public event PlayFabResultEvent<UpdateUserDataResult> OnUpdateUserDataResultEvent;

		public event PlayFabRequestEvent<UpdateUserDataRequest> OnUpdateUserPublisherDataRequestEvent;

		public event PlayFabResultEvent<UpdateUserDataResult> OnUpdateUserPublisherDataResultEvent;

		public event PlayFabRequestEvent<UpdateUserTitleDisplayNameRequest> OnUpdateUserTitleDisplayNameRequestEvent;

		public event PlayFabResultEvent<UpdateUserTitleDisplayNameResult> OnUpdateUserTitleDisplayNameResultEvent;

		public event PlayFabRequestEvent<ValidateAmazonReceiptRequest> OnValidateAmazonIAPReceiptRequestEvent;

		public event PlayFabResultEvent<ValidateAmazonReceiptResult> OnValidateAmazonIAPReceiptResultEvent;

		public event PlayFabRequestEvent<ValidateGooglePlayPurchaseRequest> OnValidateGooglePlayPurchaseRequestEvent;

		public event PlayFabResultEvent<ValidateGooglePlayPurchaseResult> OnValidateGooglePlayPurchaseResultEvent;

		public event PlayFabRequestEvent<ValidateIOSReceiptRequest> OnValidateIOSReceiptRequestEvent;

		public event PlayFabResultEvent<ValidateIOSReceiptResult> OnValidateIOSReceiptResultEvent;

		public event PlayFabRequestEvent<ValidateWindowsReceiptRequest> OnValidateWindowsStoreReceiptRequestEvent;

		public event PlayFabResultEvent<ValidateWindowsReceiptResult> OnValidateWindowsStoreReceiptResultEvent;

		public event PlayFabRequestEvent<WriteClientCharacterEventRequest> OnWriteCharacterEventRequestEvent;

		public event PlayFabResultEvent<WriteEventResponse> OnWriteCharacterEventResultEvent;

		public event PlayFabRequestEvent<WriteClientPlayerEventRequest> OnWritePlayerEventRequestEvent;

		public event PlayFabResultEvent<WriteEventResponse> OnWritePlayerEventResultEvent;

		public event PlayFabRequestEvent<WriteTitleEventRequest> OnWriteTitleEventRequestEvent;

		public event PlayFabResultEvent<WriteEventResponse> OnWriteTitleEventResultEvent;

		public event PlayFabErrorEvent OnGlobalErrorEvent;

		public static PlayFabEvents Init()
		{
			if (PlayFabEvents._instance == null)
			{
				PlayFabEvents._instance = new PlayFabEvents();
			}
			PlayFabHttp.ApiProcessingEventHandler += PlayFabEvents._instance.OnProcessingEvent;
			PlayFabHttp.ApiProcessingErrorEventHandler += PlayFabEvents._instance.OnProcessingErrorEvent;
			return PlayFabEvents._instance;
		}

		public void UnregisterInstance(object instance)
		{
			if (this.OnLoginResultEvent != null)
			{
				foreach (Delegate @delegate in this.OnLoginResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(@delegate.Target, instance))
					{
						this.OnLoginResultEvent -= (PlayFabResultEvent<LoginResult>)@delegate;
					}
				}
			}
			if (this.OnAcceptTradeRequestEvent != null)
			{
				foreach (Delegate delegate2 in this.OnAcceptTradeRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate2.Target, instance))
					{
						this.OnAcceptTradeRequestEvent -= (PlayFabRequestEvent<AcceptTradeRequest>)delegate2;
					}
				}
			}
			if (this.OnAcceptTradeResultEvent != null)
			{
				foreach (Delegate delegate3 in this.OnAcceptTradeResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate3.Target, instance))
					{
						this.OnAcceptTradeResultEvent -= (PlayFabResultEvent<AcceptTradeResponse>)delegate3;
					}
				}
			}
			if (this.OnAddFriendRequestEvent != null)
			{
				foreach (Delegate delegate4 in this.OnAddFriendRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate4.Target, instance))
					{
						this.OnAddFriendRequestEvent -= (PlayFabRequestEvent<AddFriendRequest>)delegate4;
					}
				}
			}
			if (this.OnAddFriendResultEvent != null)
			{
				foreach (Delegate delegate5 in this.OnAddFriendResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate5.Target, instance))
					{
						this.OnAddFriendResultEvent -= (PlayFabResultEvent<AddFriendResult>)delegate5;
					}
				}
			}
			if (this.OnAddGenericIDRequestEvent != null)
			{
				foreach (Delegate delegate6 in this.OnAddGenericIDRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate6.Target, instance))
					{
						this.OnAddGenericIDRequestEvent -= (PlayFabRequestEvent<AddGenericIDRequest>)delegate6;
					}
				}
			}
			if (this.OnAddGenericIDResultEvent != null)
			{
				foreach (Delegate delegate7 in this.OnAddGenericIDResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate7.Target, instance))
					{
						this.OnAddGenericIDResultEvent -= (PlayFabResultEvent<AddGenericIDResult>)delegate7;
					}
				}
			}
			if (this.OnAddOrUpdateContactEmailRequestEvent != null)
			{
				foreach (Delegate delegate8 in this.OnAddOrUpdateContactEmailRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate8.Target, instance))
					{
						this.OnAddOrUpdateContactEmailRequestEvent -= (PlayFabRequestEvent<AddOrUpdateContactEmailRequest>)delegate8;
					}
				}
			}
			if (this.OnAddOrUpdateContactEmailResultEvent != null)
			{
				foreach (Delegate delegate9 in this.OnAddOrUpdateContactEmailResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate9.Target, instance))
					{
						this.OnAddOrUpdateContactEmailResultEvent -= (PlayFabResultEvent<AddOrUpdateContactEmailResult>)delegate9;
					}
				}
			}
			if (this.OnAddSharedGroupMembersRequestEvent != null)
			{
				foreach (Delegate delegate10 in this.OnAddSharedGroupMembersRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate10.Target, instance))
					{
						this.OnAddSharedGroupMembersRequestEvent -= (PlayFabRequestEvent<AddSharedGroupMembersRequest>)delegate10;
					}
				}
			}
			if (this.OnAddSharedGroupMembersResultEvent != null)
			{
				foreach (Delegate delegate11 in this.OnAddSharedGroupMembersResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate11.Target, instance))
					{
						this.OnAddSharedGroupMembersResultEvent -= (PlayFabResultEvent<AddSharedGroupMembersResult>)delegate11;
					}
				}
			}
			if (this.OnAddUsernamePasswordRequestEvent != null)
			{
				foreach (Delegate delegate12 in this.OnAddUsernamePasswordRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate12.Target, instance))
					{
						this.OnAddUsernamePasswordRequestEvent -= (PlayFabRequestEvent<AddUsernamePasswordRequest>)delegate12;
					}
				}
			}
			if (this.OnAddUsernamePasswordResultEvent != null)
			{
				foreach (Delegate delegate13 in this.OnAddUsernamePasswordResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate13.Target, instance))
					{
						this.OnAddUsernamePasswordResultEvent -= (PlayFabResultEvent<AddUsernamePasswordResult>)delegate13;
					}
				}
			}
			if (this.OnAddUserVirtualCurrencyRequestEvent != null)
			{
				foreach (Delegate delegate14 in this.OnAddUserVirtualCurrencyRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate14.Target, instance))
					{
						this.OnAddUserVirtualCurrencyRequestEvent -= (PlayFabRequestEvent<AddUserVirtualCurrencyRequest>)delegate14;
					}
				}
			}
			if (this.OnAddUserVirtualCurrencyResultEvent != null)
			{
				foreach (Delegate delegate15 in this.OnAddUserVirtualCurrencyResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate15.Target, instance))
					{
						this.OnAddUserVirtualCurrencyResultEvent -= (PlayFabResultEvent<ModifyUserVirtualCurrencyResult>)delegate15;
					}
				}
			}
			if (this.OnAndroidDevicePushNotificationRegistrationRequestEvent != null)
			{
				foreach (Delegate delegate16 in this.OnAndroidDevicePushNotificationRegistrationRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate16.Target, instance))
					{
						this.OnAndroidDevicePushNotificationRegistrationRequestEvent -= (PlayFabRequestEvent<AndroidDevicePushNotificationRegistrationRequest>)delegate16;
					}
				}
			}
			if (this.OnAndroidDevicePushNotificationRegistrationResultEvent != null)
			{
				foreach (Delegate delegate17 in this.OnAndroidDevicePushNotificationRegistrationResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate17.Target, instance))
					{
						this.OnAndroidDevicePushNotificationRegistrationResultEvent -= (PlayFabResultEvent<AndroidDevicePushNotificationRegistrationResult>)delegate17;
					}
				}
			}
			if (this.OnAttributeInstallRequestEvent != null)
			{
				foreach (Delegate delegate18 in this.OnAttributeInstallRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate18.Target, instance))
					{
						this.OnAttributeInstallRequestEvent -= (PlayFabRequestEvent<AttributeInstallRequest>)delegate18;
					}
				}
			}
			if (this.OnAttributeInstallResultEvent != null)
			{
				foreach (Delegate delegate19 in this.OnAttributeInstallResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate19.Target, instance))
					{
						this.OnAttributeInstallResultEvent -= (PlayFabResultEvent<AttributeInstallResult>)delegate19;
					}
				}
			}
			if (this.OnCancelTradeRequestEvent != null)
			{
				foreach (Delegate delegate20 in this.OnCancelTradeRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate20.Target, instance))
					{
						this.OnCancelTradeRequestEvent -= (PlayFabRequestEvent<CancelTradeRequest>)delegate20;
					}
				}
			}
			if (this.OnCancelTradeResultEvent != null)
			{
				foreach (Delegate delegate21 in this.OnCancelTradeResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate21.Target, instance))
					{
						this.OnCancelTradeResultEvent -= (PlayFabResultEvent<CancelTradeResponse>)delegate21;
					}
				}
			}
			if (this.OnConfirmPurchaseRequestEvent != null)
			{
				foreach (Delegate delegate22 in this.OnConfirmPurchaseRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate22.Target, instance))
					{
						this.OnConfirmPurchaseRequestEvent -= (PlayFabRequestEvent<ConfirmPurchaseRequest>)delegate22;
					}
				}
			}
			if (this.OnConfirmPurchaseResultEvent != null)
			{
				foreach (Delegate delegate23 in this.OnConfirmPurchaseResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate23.Target, instance))
					{
						this.OnConfirmPurchaseResultEvent -= (PlayFabResultEvent<ConfirmPurchaseResult>)delegate23;
					}
				}
			}
			if (this.OnConsumeItemRequestEvent != null)
			{
				foreach (Delegate delegate24 in this.OnConsumeItemRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate24.Target, instance))
					{
						this.OnConsumeItemRequestEvent -= (PlayFabRequestEvent<ConsumeItemRequest>)delegate24;
					}
				}
			}
			if (this.OnConsumeItemResultEvent != null)
			{
				foreach (Delegate delegate25 in this.OnConsumeItemResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate25.Target, instance))
					{
						this.OnConsumeItemResultEvent -= (PlayFabResultEvent<ConsumeItemResult>)delegate25;
					}
				}
			}
			if (this.OnCreateSharedGroupRequestEvent != null)
			{
				foreach (Delegate delegate26 in this.OnCreateSharedGroupRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate26.Target, instance))
					{
						this.OnCreateSharedGroupRequestEvent -= (PlayFabRequestEvent<CreateSharedGroupRequest>)delegate26;
					}
				}
			}
			if (this.OnCreateSharedGroupResultEvent != null)
			{
				foreach (Delegate delegate27 in this.OnCreateSharedGroupResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate27.Target, instance))
					{
						this.OnCreateSharedGroupResultEvent -= (PlayFabResultEvent<CreateSharedGroupResult>)delegate27;
					}
				}
			}
			if (this.OnExecuteCloudScriptRequestEvent != null)
			{
				foreach (Delegate delegate28 in this.OnExecuteCloudScriptRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate28.Target, instance))
					{
						this.OnExecuteCloudScriptRequestEvent -= (PlayFabRequestEvent<ExecuteCloudScriptRequest>)delegate28;
					}
				}
			}
			if (this.OnExecuteCloudScriptResultEvent != null)
			{
				foreach (Delegate delegate29 in this.OnExecuteCloudScriptResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate29.Target, instance))
					{
						this.OnExecuteCloudScriptResultEvent -= (PlayFabResultEvent<ExecuteCloudScriptResult>)delegate29;
					}
				}
			}
			if (this.OnGetAccountInfoRequestEvent != null)
			{
				foreach (Delegate delegate30 in this.OnGetAccountInfoRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate30.Target, instance))
					{
						this.OnGetAccountInfoRequestEvent -= (PlayFabRequestEvent<GetAccountInfoRequest>)delegate30;
					}
				}
			}
			if (this.OnGetAccountInfoResultEvent != null)
			{
				foreach (Delegate delegate31 in this.OnGetAccountInfoResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate31.Target, instance))
					{
						this.OnGetAccountInfoResultEvent -= (PlayFabResultEvent<GetAccountInfoResult>)delegate31;
					}
				}
			}
			if (this.OnGetAllUsersCharactersRequestEvent != null)
			{
				foreach (Delegate delegate32 in this.OnGetAllUsersCharactersRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate32.Target, instance))
					{
						this.OnGetAllUsersCharactersRequestEvent -= (PlayFabRequestEvent<ListUsersCharactersRequest>)delegate32;
					}
				}
			}
			if (this.OnGetAllUsersCharactersResultEvent != null)
			{
				foreach (Delegate delegate33 in this.OnGetAllUsersCharactersResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate33.Target, instance))
					{
						this.OnGetAllUsersCharactersResultEvent -= (PlayFabResultEvent<ListUsersCharactersResult>)delegate33;
					}
				}
			}
			if (this.OnGetCatalogItemsRequestEvent != null)
			{
				foreach (Delegate delegate34 in this.OnGetCatalogItemsRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate34.Target, instance))
					{
						this.OnGetCatalogItemsRequestEvent -= (PlayFabRequestEvent<GetCatalogItemsRequest>)delegate34;
					}
				}
			}
			if (this.OnGetCatalogItemsResultEvent != null)
			{
				foreach (Delegate delegate35 in this.OnGetCatalogItemsResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate35.Target, instance))
					{
						this.OnGetCatalogItemsResultEvent -= (PlayFabResultEvent<GetCatalogItemsResult>)delegate35;
					}
				}
			}
			if (this.OnGetCharacterDataRequestEvent != null)
			{
				foreach (Delegate delegate36 in this.OnGetCharacterDataRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate36.Target, instance))
					{
						this.OnGetCharacterDataRequestEvent -= (PlayFabRequestEvent<GetCharacterDataRequest>)delegate36;
					}
				}
			}
			if (this.OnGetCharacterDataResultEvent != null)
			{
				foreach (Delegate delegate37 in this.OnGetCharacterDataResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate37.Target, instance))
					{
						this.OnGetCharacterDataResultEvent -= (PlayFabResultEvent<GetCharacterDataResult>)delegate37;
					}
				}
			}
			if (this.OnGetCharacterInventoryRequestEvent != null)
			{
				foreach (Delegate delegate38 in this.OnGetCharacterInventoryRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate38.Target, instance))
					{
						this.OnGetCharacterInventoryRequestEvent -= (PlayFabRequestEvent<GetCharacterInventoryRequest>)delegate38;
					}
				}
			}
			if (this.OnGetCharacterInventoryResultEvent != null)
			{
				foreach (Delegate delegate39 in this.OnGetCharacterInventoryResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate39.Target, instance))
					{
						this.OnGetCharacterInventoryResultEvent -= (PlayFabResultEvent<GetCharacterInventoryResult>)delegate39;
					}
				}
			}
			if (this.OnGetCharacterLeaderboardRequestEvent != null)
			{
				foreach (Delegate delegate40 in this.OnGetCharacterLeaderboardRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate40.Target, instance))
					{
						this.OnGetCharacterLeaderboardRequestEvent -= (PlayFabRequestEvent<GetCharacterLeaderboardRequest>)delegate40;
					}
				}
			}
			if (this.OnGetCharacterLeaderboardResultEvent != null)
			{
				foreach (Delegate delegate41 in this.OnGetCharacterLeaderboardResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate41.Target, instance))
					{
						this.OnGetCharacterLeaderboardResultEvent -= (PlayFabResultEvent<GetCharacterLeaderboardResult>)delegate41;
					}
				}
			}
			if (this.OnGetCharacterReadOnlyDataRequestEvent != null)
			{
				foreach (Delegate delegate42 in this.OnGetCharacterReadOnlyDataRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate42.Target, instance))
					{
						this.OnGetCharacterReadOnlyDataRequestEvent -= (PlayFabRequestEvent<GetCharacterDataRequest>)delegate42;
					}
				}
			}
			if (this.OnGetCharacterReadOnlyDataResultEvent != null)
			{
				foreach (Delegate delegate43 in this.OnGetCharacterReadOnlyDataResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate43.Target, instance))
					{
						this.OnGetCharacterReadOnlyDataResultEvent -= (PlayFabResultEvent<GetCharacterDataResult>)delegate43;
					}
				}
			}
			if (this.OnGetCharacterStatisticsRequestEvent != null)
			{
				foreach (Delegate delegate44 in this.OnGetCharacterStatisticsRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate44.Target, instance))
					{
						this.OnGetCharacterStatisticsRequestEvent -= (PlayFabRequestEvent<GetCharacterStatisticsRequest>)delegate44;
					}
				}
			}
			if (this.OnGetCharacterStatisticsResultEvent != null)
			{
				foreach (Delegate delegate45 in this.OnGetCharacterStatisticsResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate45.Target, instance))
					{
						this.OnGetCharacterStatisticsResultEvent -= (PlayFabResultEvent<GetCharacterStatisticsResult>)delegate45;
					}
				}
			}
			if (this.OnGetContentDownloadUrlRequestEvent != null)
			{
				foreach (Delegate delegate46 in this.OnGetContentDownloadUrlRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate46.Target, instance))
					{
						this.OnGetContentDownloadUrlRequestEvent -= (PlayFabRequestEvent<GetContentDownloadUrlRequest>)delegate46;
					}
				}
			}
			if (this.OnGetContentDownloadUrlResultEvent != null)
			{
				foreach (Delegate delegate47 in this.OnGetContentDownloadUrlResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate47.Target, instance))
					{
						this.OnGetContentDownloadUrlResultEvent -= (PlayFabResultEvent<GetContentDownloadUrlResult>)delegate47;
					}
				}
			}
			if (this.OnGetCurrentGamesRequestEvent != null)
			{
				foreach (Delegate delegate48 in this.OnGetCurrentGamesRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate48.Target, instance))
					{
						this.OnGetCurrentGamesRequestEvent -= (PlayFabRequestEvent<CurrentGamesRequest>)delegate48;
					}
				}
			}
			if (this.OnGetCurrentGamesResultEvent != null)
			{
				foreach (Delegate delegate49 in this.OnGetCurrentGamesResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate49.Target, instance))
					{
						this.OnGetCurrentGamesResultEvent -= (PlayFabResultEvent<CurrentGamesResult>)delegate49;
					}
				}
			}
			if (this.OnGetFriendLeaderboardRequestEvent != null)
			{
				foreach (Delegate delegate50 in this.OnGetFriendLeaderboardRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate50.Target, instance))
					{
						this.OnGetFriendLeaderboardRequestEvent -= (PlayFabRequestEvent<GetFriendLeaderboardRequest>)delegate50;
					}
				}
			}
			if (this.OnGetFriendLeaderboardResultEvent != null)
			{
				foreach (Delegate delegate51 in this.OnGetFriendLeaderboardResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate51.Target, instance))
					{
						this.OnGetFriendLeaderboardResultEvent -= (PlayFabResultEvent<GetLeaderboardResult>)delegate51;
					}
				}
			}
			if (this.OnGetFriendLeaderboardAroundPlayerRequestEvent != null)
			{
				foreach (Delegate delegate52 in this.OnGetFriendLeaderboardAroundPlayerRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate52.Target, instance))
					{
						this.OnGetFriendLeaderboardAroundPlayerRequestEvent -= (PlayFabRequestEvent<GetFriendLeaderboardAroundPlayerRequest>)delegate52;
					}
				}
			}
			if (this.OnGetFriendLeaderboardAroundPlayerResultEvent != null)
			{
				foreach (Delegate delegate53 in this.OnGetFriendLeaderboardAroundPlayerResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate53.Target, instance))
					{
						this.OnGetFriendLeaderboardAroundPlayerResultEvent -= (PlayFabResultEvent<GetFriendLeaderboardAroundPlayerResult>)delegate53;
					}
				}
			}
			if (this.OnGetFriendsListRequestEvent != null)
			{
				foreach (Delegate delegate54 in this.OnGetFriendsListRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate54.Target, instance))
					{
						this.OnGetFriendsListRequestEvent -= (PlayFabRequestEvent<GetFriendsListRequest>)delegate54;
					}
				}
			}
			if (this.OnGetFriendsListResultEvent != null)
			{
				foreach (Delegate delegate55 in this.OnGetFriendsListResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate55.Target, instance))
					{
						this.OnGetFriendsListResultEvent -= (PlayFabResultEvent<GetFriendsListResult>)delegate55;
					}
				}
			}
			if (this.OnGetGameServerRegionsRequestEvent != null)
			{
				foreach (Delegate delegate56 in this.OnGetGameServerRegionsRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate56.Target, instance))
					{
						this.OnGetGameServerRegionsRequestEvent -= (PlayFabRequestEvent<GameServerRegionsRequest>)delegate56;
					}
				}
			}
			if (this.OnGetGameServerRegionsResultEvent != null)
			{
				foreach (Delegate delegate57 in this.OnGetGameServerRegionsResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate57.Target, instance))
					{
						this.OnGetGameServerRegionsResultEvent -= (PlayFabResultEvent<GameServerRegionsResult>)delegate57;
					}
				}
			}
			if (this.OnGetLeaderboardRequestEvent != null)
			{
				foreach (Delegate delegate58 in this.OnGetLeaderboardRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate58.Target, instance))
					{
						this.OnGetLeaderboardRequestEvent -= (PlayFabRequestEvent<GetLeaderboardRequest>)delegate58;
					}
				}
			}
			if (this.OnGetLeaderboardResultEvent != null)
			{
				foreach (Delegate delegate59 in this.OnGetLeaderboardResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate59.Target, instance))
					{
						this.OnGetLeaderboardResultEvent -= (PlayFabResultEvent<GetLeaderboardResult>)delegate59;
					}
				}
			}
			if (this.OnGetLeaderboardAroundCharacterRequestEvent != null)
			{
				foreach (Delegate delegate60 in this.OnGetLeaderboardAroundCharacterRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate60.Target, instance))
					{
						this.OnGetLeaderboardAroundCharacterRequestEvent -= (PlayFabRequestEvent<GetLeaderboardAroundCharacterRequest>)delegate60;
					}
				}
			}
			if (this.OnGetLeaderboardAroundCharacterResultEvent != null)
			{
				foreach (Delegate delegate61 in this.OnGetLeaderboardAroundCharacterResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate61.Target, instance))
					{
						this.OnGetLeaderboardAroundCharacterResultEvent -= (PlayFabResultEvent<GetLeaderboardAroundCharacterResult>)delegate61;
					}
				}
			}
			if (this.OnGetLeaderboardAroundPlayerRequestEvent != null)
			{
				foreach (Delegate delegate62 in this.OnGetLeaderboardAroundPlayerRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate62.Target, instance))
					{
						this.OnGetLeaderboardAroundPlayerRequestEvent -= (PlayFabRequestEvent<GetLeaderboardAroundPlayerRequest>)delegate62;
					}
				}
			}
			if (this.OnGetLeaderboardAroundPlayerResultEvent != null)
			{
				foreach (Delegate delegate63 in this.OnGetLeaderboardAroundPlayerResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate63.Target, instance))
					{
						this.OnGetLeaderboardAroundPlayerResultEvent -= (PlayFabResultEvent<GetLeaderboardAroundPlayerResult>)delegate63;
					}
				}
			}
			if (this.OnGetLeaderboardForUserCharactersRequestEvent != null)
			{
				foreach (Delegate delegate64 in this.OnGetLeaderboardForUserCharactersRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate64.Target, instance))
					{
						this.OnGetLeaderboardForUserCharactersRequestEvent -= (PlayFabRequestEvent<GetLeaderboardForUsersCharactersRequest>)delegate64;
					}
				}
			}
			if (this.OnGetLeaderboardForUserCharactersResultEvent != null)
			{
				foreach (Delegate delegate65 in this.OnGetLeaderboardForUserCharactersResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate65.Target, instance))
					{
						this.OnGetLeaderboardForUserCharactersResultEvent -= (PlayFabResultEvent<GetLeaderboardForUsersCharactersResult>)delegate65;
					}
				}
			}
			if (this.OnGetPaymentTokenRequestEvent != null)
			{
				foreach (Delegate delegate66 in this.OnGetPaymentTokenRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate66.Target, instance))
					{
						this.OnGetPaymentTokenRequestEvent -= (PlayFabRequestEvent<GetPaymentTokenRequest>)delegate66;
					}
				}
			}
			if (this.OnGetPaymentTokenResultEvent != null)
			{
				foreach (Delegate delegate67 in this.OnGetPaymentTokenResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate67.Target, instance))
					{
						this.OnGetPaymentTokenResultEvent -= (PlayFabResultEvent<GetPaymentTokenResult>)delegate67;
					}
				}
			}
			if (this.OnGetPhotonAuthenticationTokenRequestEvent != null)
			{
				foreach (Delegate delegate68 in this.OnGetPhotonAuthenticationTokenRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate68.Target, instance))
					{
						this.OnGetPhotonAuthenticationTokenRequestEvent -= (PlayFabRequestEvent<GetPhotonAuthenticationTokenRequest>)delegate68;
					}
				}
			}
			if (this.OnGetPhotonAuthenticationTokenResultEvent != null)
			{
				foreach (Delegate delegate69 in this.OnGetPhotonAuthenticationTokenResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate69.Target, instance))
					{
						this.OnGetPhotonAuthenticationTokenResultEvent -= (PlayFabResultEvent<GetPhotonAuthenticationTokenResult>)delegate69;
					}
				}
			}
			if (this.OnGetPlayerCombinedInfoRequestEvent != null)
			{
				foreach (Delegate delegate70 in this.OnGetPlayerCombinedInfoRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate70.Target, instance))
					{
						this.OnGetPlayerCombinedInfoRequestEvent -= (PlayFabRequestEvent<GetPlayerCombinedInfoRequest>)delegate70;
					}
				}
			}
			if (this.OnGetPlayerCombinedInfoResultEvent != null)
			{
				foreach (Delegate delegate71 in this.OnGetPlayerCombinedInfoResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate71.Target, instance))
					{
						this.OnGetPlayerCombinedInfoResultEvent -= (PlayFabResultEvent<GetPlayerCombinedInfoResult>)delegate71;
					}
				}
			}
			if (this.OnGetPlayerProfileRequestEvent != null)
			{
				foreach (Delegate delegate72 in this.OnGetPlayerProfileRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate72.Target, instance))
					{
						this.OnGetPlayerProfileRequestEvent -= (PlayFabRequestEvent<GetPlayerProfileRequest>)delegate72;
					}
				}
			}
			if (this.OnGetPlayerProfileResultEvent != null)
			{
				foreach (Delegate delegate73 in this.OnGetPlayerProfileResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate73.Target, instance))
					{
						this.OnGetPlayerProfileResultEvent -= (PlayFabResultEvent<GetPlayerProfileResult>)delegate73;
					}
				}
			}
			if (this.OnGetPlayerSegmentsRequestEvent != null)
			{
				foreach (Delegate delegate74 in this.OnGetPlayerSegmentsRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate74.Target, instance))
					{
						this.OnGetPlayerSegmentsRequestEvent -= (PlayFabRequestEvent<GetPlayerSegmentsRequest>)delegate74;
					}
				}
			}
			if (this.OnGetPlayerSegmentsResultEvent != null)
			{
				foreach (Delegate delegate75 in this.OnGetPlayerSegmentsResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate75.Target, instance))
					{
						this.OnGetPlayerSegmentsResultEvent -= (PlayFabResultEvent<GetPlayerSegmentsResult>)delegate75;
					}
				}
			}
			if (this.OnGetPlayerStatisticsRequestEvent != null)
			{
				foreach (Delegate delegate76 in this.OnGetPlayerStatisticsRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate76.Target, instance))
					{
						this.OnGetPlayerStatisticsRequestEvent -= (PlayFabRequestEvent<GetPlayerStatisticsRequest>)delegate76;
					}
				}
			}
			if (this.OnGetPlayerStatisticsResultEvent != null)
			{
				foreach (Delegate delegate77 in this.OnGetPlayerStatisticsResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate77.Target, instance))
					{
						this.OnGetPlayerStatisticsResultEvent -= (PlayFabResultEvent<GetPlayerStatisticsResult>)delegate77;
					}
				}
			}
			if (this.OnGetPlayerStatisticVersionsRequestEvent != null)
			{
				foreach (Delegate delegate78 in this.OnGetPlayerStatisticVersionsRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate78.Target, instance))
					{
						this.OnGetPlayerStatisticVersionsRequestEvent -= (PlayFabRequestEvent<GetPlayerStatisticVersionsRequest>)delegate78;
					}
				}
			}
			if (this.OnGetPlayerStatisticVersionsResultEvent != null)
			{
				foreach (Delegate delegate79 in this.OnGetPlayerStatisticVersionsResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate79.Target, instance))
					{
						this.OnGetPlayerStatisticVersionsResultEvent -= (PlayFabResultEvent<GetPlayerStatisticVersionsResult>)delegate79;
					}
				}
			}
			if (this.OnGetPlayerTagsRequestEvent != null)
			{
				foreach (Delegate delegate80 in this.OnGetPlayerTagsRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate80.Target, instance))
					{
						this.OnGetPlayerTagsRequestEvent -= (PlayFabRequestEvent<GetPlayerTagsRequest>)delegate80;
					}
				}
			}
			if (this.OnGetPlayerTagsResultEvent != null)
			{
				foreach (Delegate delegate81 in this.OnGetPlayerTagsResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate81.Target, instance))
					{
						this.OnGetPlayerTagsResultEvent -= (PlayFabResultEvent<GetPlayerTagsResult>)delegate81;
					}
				}
			}
			if (this.OnGetPlayerTradesRequestEvent != null)
			{
				foreach (Delegate delegate82 in this.OnGetPlayerTradesRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate82.Target, instance))
					{
						this.OnGetPlayerTradesRequestEvent -= (PlayFabRequestEvent<GetPlayerTradesRequest>)delegate82;
					}
				}
			}
			if (this.OnGetPlayerTradesResultEvent != null)
			{
				foreach (Delegate delegate83 in this.OnGetPlayerTradesResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate83.Target, instance))
					{
						this.OnGetPlayerTradesResultEvent -= (PlayFabResultEvent<GetPlayerTradesResponse>)delegate83;
					}
				}
			}
			if (this.OnGetPlayFabIDsFromFacebookIDsRequestEvent != null)
			{
				foreach (Delegate delegate84 in this.OnGetPlayFabIDsFromFacebookIDsRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate84.Target, instance))
					{
						this.OnGetPlayFabIDsFromFacebookIDsRequestEvent -= (PlayFabRequestEvent<GetPlayFabIDsFromFacebookIDsRequest>)delegate84;
					}
				}
			}
			if (this.OnGetPlayFabIDsFromFacebookIDsResultEvent != null)
			{
				foreach (Delegate delegate85 in this.OnGetPlayFabIDsFromFacebookIDsResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate85.Target, instance))
					{
						this.OnGetPlayFabIDsFromFacebookIDsResultEvent -= (PlayFabResultEvent<GetPlayFabIDsFromFacebookIDsResult>)delegate85;
					}
				}
			}
			if (this.OnGetPlayFabIDsFromGameCenterIDsRequestEvent != null)
			{
				foreach (Delegate delegate86 in this.OnGetPlayFabIDsFromGameCenterIDsRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate86.Target, instance))
					{
						this.OnGetPlayFabIDsFromGameCenterIDsRequestEvent -= (PlayFabRequestEvent<GetPlayFabIDsFromGameCenterIDsRequest>)delegate86;
					}
				}
			}
			if (this.OnGetPlayFabIDsFromGameCenterIDsResultEvent != null)
			{
				foreach (Delegate delegate87 in this.OnGetPlayFabIDsFromGameCenterIDsResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate87.Target, instance))
					{
						this.OnGetPlayFabIDsFromGameCenterIDsResultEvent -= (PlayFabResultEvent<GetPlayFabIDsFromGameCenterIDsResult>)delegate87;
					}
				}
			}
			if (this.OnGetPlayFabIDsFromGenericIDsRequestEvent != null)
			{
				foreach (Delegate delegate88 in this.OnGetPlayFabIDsFromGenericIDsRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate88.Target, instance))
					{
						this.OnGetPlayFabIDsFromGenericIDsRequestEvent -= (PlayFabRequestEvent<GetPlayFabIDsFromGenericIDsRequest>)delegate88;
					}
				}
			}
			if (this.OnGetPlayFabIDsFromGenericIDsResultEvent != null)
			{
				foreach (Delegate delegate89 in this.OnGetPlayFabIDsFromGenericIDsResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate89.Target, instance))
					{
						this.OnGetPlayFabIDsFromGenericIDsResultEvent -= (PlayFabResultEvent<GetPlayFabIDsFromGenericIDsResult>)delegate89;
					}
				}
			}
			if (this.OnGetPlayFabIDsFromGoogleIDsRequestEvent != null)
			{
				foreach (Delegate delegate90 in this.OnGetPlayFabIDsFromGoogleIDsRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate90.Target, instance))
					{
						this.OnGetPlayFabIDsFromGoogleIDsRequestEvent -= (PlayFabRequestEvent<GetPlayFabIDsFromGoogleIDsRequest>)delegate90;
					}
				}
			}
			if (this.OnGetPlayFabIDsFromGoogleIDsResultEvent != null)
			{
				foreach (Delegate delegate91 in this.OnGetPlayFabIDsFromGoogleIDsResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate91.Target, instance))
					{
						this.OnGetPlayFabIDsFromGoogleIDsResultEvent -= (PlayFabResultEvent<GetPlayFabIDsFromGoogleIDsResult>)delegate91;
					}
				}
			}
			if (this.OnGetPlayFabIDsFromKongregateIDsRequestEvent != null)
			{
				foreach (Delegate delegate92 in this.OnGetPlayFabIDsFromKongregateIDsRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate92.Target, instance))
					{
						this.OnGetPlayFabIDsFromKongregateIDsRequestEvent -= (PlayFabRequestEvent<GetPlayFabIDsFromKongregateIDsRequest>)delegate92;
					}
				}
			}
			if (this.OnGetPlayFabIDsFromKongregateIDsResultEvent != null)
			{
				foreach (Delegate delegate93 in this.OnGetPlayFabIDsFromKongregateIDsResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate93.Target, instance))
					{
						this.OnGetPlayFabIDsFromKongregateIDsResultEvent -= (PlayFabResultEvent<GetPlayFabIDsFromKongregateIDsResult>)delegate93;
					}
				}
			}
			if (this.OnGetPlayFabIDsFromSteamIDsRequestEvent != null)
			{
				foreach (Delegate delegate94 in this.OnGetPlayFabIDsFromSteamIDsRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate94.Target, instance))
					{
						this.OnGetPlayFabIDsFromSteamIDsRequestEvent -= (PlayFabRequestEvent<GetPlayFabIDsFromSteamIDsRequest>)delegate94;
					}
				}
			}
			if (this.OnGetPlayFabIDsFromSteamIDsResultEvent != null)
			{
				foreach (Delegate delegate95 in this.OnGetPlayFabIDsFromSteamIDsResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate95.Target, instance))
					{
						this.OnGetPlayFabIDsFromSteamIDsResultEvent -= (PlayFabResultEvent<GetPlayFabIDsFromSteamIDsResult>)delegate95;
					}
				}
			}
			if (this.OnGetPlayFabIDsFromTwitchIDsRequestEvent != null)
			{
				foreach (Delegate delegate96 in this.OnGetPlayFabIDsFromTwitchIDsRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate96.Target, instance))
					{
						this.OnGetPlayFabIDsFromTwitchIDsRequestEvent -= (PlayFabRequestEvent<GetPlayFabIDsFromTwitchIDsRequest>)delegate96;
					}
				}
			}
			if (this.OnGetPlayFabIDsFromTwitchIDsResultEvent != null)
			{
				foreach (Delegate delegate97 in this.OnGetPlayFabIDsFromTwitchIDsResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate97.Target, instance))
					{
						this.OnGetPlayFabIDsFromTwitchIDsResultEvent -= (PlayFabResultEvent<GetPlayFabIDsFromTwitchIDsResult>)delegate97;
					}
				}
			}
			if (this.OnGetPublisherDataRequestEvent != null)
			{
				foreach (Delegate delegate98 in this.OnGetPublisherDataRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate98.Target, instance))
					{
						this.OnGetPublisherDataRequestEvent -= (PlayFabRequestEvent<GetPublisherDataRequest>)delegate98;
					}
				}
			}
			if (this.OnGetPublisherDataResultEvent != null)
			{
				foreach (Delegate delegate99 in this.OnGetPublisherDataResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate99.Target, instance))
					{
						this.OnGetPublisherDataResultEvent -= (PlayFabResultEvent<GetPublisherDataResult>)delegate99;
					}
				}
			}
			if (this.OnGetPurchaseRequestEvent != null)
			{
				foreach (Delegate delegate100 in this.OnGetPurchaseRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate100.Target, instance))
					{
						this.OnGetPurchaseRequestEvent -= (PlayFabRequestEvent<GetPurchaseRequest>)delegate100;
					}
				}
			}
			if (this.OnGetPurchaseResultEvent != null)
			{
				foreach (Delegate delegate101 in this.OnGetPurchaseResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate101.Target, instance))
					{
						this.OnGetPurchaseResultEvent -= (PlayFabResultEvent<GetPurchaseResult>)delegate101;
					}
				}
			}
			if (this.OnGetSharedGroupDataRequestEvent != null)
			{
				foreach (Delegate delegate102 in this.OnGetSharedGroupDataRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate102.Target, instance))
					{
						this.OnGetSharedGroupDataRequestEvent -= (PlayFabRequestEvent<GetSharedGroupDataRequest>)delegate102;
					}
				}
			}
			if (this.OnGetSharedGroupDataResultEvent != null)
			{
				foreach (Delegate delegate103 in this.OnGetSharedGroupDataResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate103.Target, instance))
					{
						this.OnGetSharedGroupDataResultEvent -= (PlayFabResultEvent<GetSharedGroupDataResult>)delegate103;
					}
				}
			}
			if (this.OnGetStoreItemsRequestEvent != null)
			{
				foreach (Delegate delegate104 in this.OnGetStoreItemsRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate104.Target, instance))
					{
						this.OnGetStoreItemsRequestEvent -= (PlayFabRequestEvent<GetStoreItemsRequest>)delegate104;
					}
				}
			}
			if (this.OnGetStoreItemsResultEvent != null)
			{
				foreach (Delegate delegate105 in this.OnGetStoreItemsResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate105.Target, instance))
					{
						this.OnGetStoreItemsResultEvent -= (PlayFabResultEvent<GetStoreItemsResult>)delegate105;
					}
				}
			}
			if (this.OnGetTimeRequestEvent != null)
			{
				foreach (Delegate delegate106 in this.OnGetTimeRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate106.Target, instance))
					{
						this.OnGetTimeRequestEvent -= (PlayFabRequestEvent<GetTimeRequest>)delegate106;
					}
				}
			}
			if (this.OnGetTimeResultEvent != null)
			{
				foreach (Delegate delegate107 in this.OnGetTimeResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate107.Target, instance))
					{
						this.OnGetTimeResultEvent -= (PlayFabResultEvent<GetTimeResult>)delegate107;
					}
				}
			}
			if (this.OnGetTitleDataRequestEvent != null)
			{
				foreach (Delegate delegate108 in this.OnGetTitleDataRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate108.Target, instance))
					{
						this.OnGetTitleDataRequestEvent -= (PlayFabRequestEvent<GetTitleDataRequest>)delegate108;
					}
				}
			}
			if (this.OnGetTitleDataResultEvent != null)
			{
				foreach (Delegate delegate109 in this.OnGetTitleDataResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate109.Target, instance))
					{
						this.OnGetTitleDataResultEvent -= (PlayFabResultEvent<GetTitleDataResult>)delegate109;
					}
				}
			}
			if (this.OnGetTitleNewsRequestEvent != null)
			{
				foreach (Delegate delegate110 in this.OnGetTitleNewsRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate110.Target, instance))
					{
						this.OnGetTitleNewsRequestEvent -= (PlayFabRequestEvent<GetTitleNewsRequest>)delegate110;
					}
				}
			}
			if (this.OnGetTitleNewsResultEvent != null)
			{
				foreach (Delegate delegate111 in this.OnGetTitleNewsResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate111.Target, instance))
					{
						this.OnGetTitleNewsResultEvent -= (PlayFabResultEvent<GetTitleNewsResult>)delegate111;
					}
				}
			}
			if (this.OnGetTitlePublicKeyRequestEvent != null)
			{
				foreach (Delegate delegate112 in this.OnGetTitlePublicKeyRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate112.Target, instance))
					{
						this.OnGetTitlePublicKeyRequestEvent -= (PlayFabRequestEvent<GetTitlePublicKeyRequest>)delegate112;
					}
				}
			}
			if (this.OnGetTitlePublicKeyResultEvent != null)
			{
				foreach (Delegate delegate113 in this.OnGetTitlePublicKeyResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate113.Target, instance))
					{
						this.OnGetTitlePublicKeyResultEvent -= (PlayFabResultEvent<GetTitlePublicKeyResult>)delegate113;
					}
				}
			}
			if (this.OnGetTradeStatusRequestEvent != null)
			{
				foreach (Delegate delegate114 in this.OnGetTradeStatusRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate114.Target, instance))
					{
						this.OnGetTradeStatusRequestEvent -= (PlayFabRequestEvent<GetTradeStatusRequest>)delegate114;
					}
				}
			}
			if (this.OnGetTradeStatusResultEvent != null)
			{
				foreach (Delegate delegate115 in this.OnGetTradeStatusResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate115.Target, instance))
					{
						this.OnGetTradeStatusResultEvent -= (PlayFabResultEvent<GetTradeStatusResponse>)delegate115;
					}
				}
			}
			if (this.OnGetUserDataRequestEvent != null)
			{
				foreach (Delegate delegate116 in this.OnGetUserDataRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate116.Target, instance))
					{
						this.OnGetUserDataRequestEvent -= (PlayFabRequestEvent<GetUserDataRequest>)delegate116;
					}
				}
			}
			if (this.OnGetUserDataResultEvent != null)
			{
				foreach (Delegate delegate117 in this.OnGetUserDataResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate117.Target, instance))
					{
						this.OnGetUserDataResultEvent -= (PlayFabResultEvent<GetUserDataResult>)delegate117;
					}
				}
			}
			if (this.OnGetUserInventoryRequestEvent != null)
			{
				foreach (Delegate delegate118 in this.OnGetUserInventoryRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate118.Target, instance))
					{
						this.OnGetUserInventoryRequestEvent -= (PlayFabRequestEvent<GetUserInventoryRequest>)delegate118;
					}
				}
			}
			if (this.OnGetUserInventoryResultEvent != null)
			{
				foreach (Delegate delegate119 in this.OnGetUserInventoryResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate119.Target, instance))
					{
						this.OnGetUserInventoryResultEvent -= (PlayFabResultEvent<GetUserInventoryResult>)delegate119;
					}
				}
			}
			if (this.OnGetUserPublisherDataRequestEvent != null)
			{
				foreach (Delegate delegate120 in this.OnGetUserPublisherDataRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate120.Target, instance))
					{
						this.OnGetUserPublisherDataRequestEvent -= (PlayFabRequestEvent<GetUserDataRequest>)delegate120;
					}
				}
			}
			if (this.OnGetUserPublisherDataResultEvent != null)
			{
				foreach (Delegate delegate121 in this.OnGetUserPublisherDataResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate121.Target, instance))
					{
						this.OnGetUserPublisherDataResultEvent -= (PlayFabResultEvent<GetUserDataResult>)delegate121;
					}
				}
			}
			if (this.OnGetUserPublisherReadOnlyDataRequestEvent != null)
			{
				foreach (Delegate delegate122 in this.OnGetUserPublisherReadOnlyDataRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate122.Target, instance))
					{
						this.OnGetUserPublisherReadOnlyDataRequestEvent -= (PlayFabRequestEvent<GetUserDataRequest>)delegate122;
					}
				}
			}
			if (this.OnGetUserPublisherReadOnlyDataResultEvent != null)
			{
				foreach (Delegate delegate123 in this.OnGetUserPublisherReadOnlyDataResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate123.Target, instance))
					{
						this.OnGetUserPublisherReadOnlyDataResultEvent -= (PlayFabResultEvent<GetUserDataResult>)delegate123;
					}
				}
			}
			if (this.OnGetUserReadOnlyDataRequestEvent != null)
			{
				foreach (Delegate delegate124 in this.OnGetUserReadOnlyDataRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate124.Target, instance))
					{
						this.OnGetUserReadOnlyDataRequestEvent -= (PlayFabRequestEvent<GetUserDataRequest>)delegate124;
					}
				}
			}
			if (this.OnGetUserReadOnlyDataResultEvent != null)
			{
				foreach (Delegate delegate125 in this.OnGetUserReadOnlyDataResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate125.Target, instance))
					{
						this.OnGetUserReadOnlyDataResultEvent -= (PlayFabResultEvent<GetUserDataResult>)delegate125;
					}
				}
			}
			if (this.OnGetWindowsHelloChallengeRequestEvent != null)
			{
				foreach (Delegate delegate126 in this.OnGetWindowsHelloChallengeRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate126.Target, instance))
					{
						this.OnGetWindowsHelloChallengeRequestEvent -= (PlayFabRequestEvent<GetWindowsHelloChallengeRequest>)delegate126;
					}
				}
			}
			if (this.OnGetWindowsHelloChallengeResultEvent != null)
			{
				foreach (Delegate delegate127 in this.OnGetWindowsHelloChallengeResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate127.Target, instance))
					{
						this.OnGetWindowsHelloChallengeResultEvent -= (PlayFabResultEvent<GetWindowsHelloChallengeResponse>)delegate127;
					}
				}
			}
			if (this.OnGrantCharacterToUserRequestEvent != null)
			{
				foreach (Delegate delegate128 in this.OnGrantCharacterToUserRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate128.Target, instance))
					{
						this.OnGrantCharacterToUserRequestEvent -= (PlayFabRequestEvent<GrantCharacterToUserRequest>)delegate128;
					}
				}
			}
			if (this.OnGrantCharacterToUserResultEvent != null)
			{
				foreach (Delegate delegate129 in this.OnGrantCharacterToUserResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate129.Target, instance))
					{
						this.OnGrantCharacterToUserResultEvent -= (PlayFabResultEvent<GrantCharacterToUserResult>)delegate129;
					}
				}
			}
			if (this.OnLinkAndroidDeviceIDRequestEvent != null)
			{
				foreach (Delegate delegate130 in this.OnLinkAndroidDeviceIDRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate130.Target, instance))
					{
						this.OnLinkAndroidDeviceIDRequestEvent -= (PlayFabRequestEvent<LinkAndroidDeviceIDRequest>)delegate130;
					}
				}
			}
			if (this.OnLinkAndroidDeviceIDResultEvent != null)
			{
				foreach (Delegate delegate131 in this.OnLinkAndroidDeviceIDResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate131.Target, instance))
					{
						this.OnLinkAndroidDeviceIDResultEvent -= (PlayFabResultEvent<LinkAndroidDeviceIDResult>)delegate131;
					}
				}
			}
			if (this.OnLinkCustomIDRequestEvent != null)
			{
				foreach (Delegate delegate132 in this.OnLinkCustomIDRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate132.Target, instance))
					{
						this.OnLinkCustomIDRequestEvent -= (PlayFabRequestEvent<LinkCustomIDRequest>)delegate132;
					}
				}
			}
			if (this.OnLinkCustomIDResultEvent != null)
			{
				foreach (Delegate delegate133 in this.OnLinkCustomIDResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate133.Target, instance))
					{
						this.OnLinkCustomIDResultEvent -= (PlayFabResultEvent<LinkCustomIDResult>)delegate133;
					}
				}
			}
			if (this.OnLinkFacebookAccountRequestEvent != null)
			{
				foreach (Delegate delegate134 in this.OnLinkFacebookAccountRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate134.Target, instance))
					{
						this.OnLinkFacebookAccountRequestEvent -= (PlayFabRequestEvent<LinkFacebookAccountRequest>)delegate134;
					}
				}
			}
			if (this.OnLinkFacebookAccountResultEvent != null)
			{
				foreach (Delegate delegate135 in this.OnLinkFacebookAccountResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate135.Target, instance))
					{
						this.OnLinkFacebookAccountResultEvent -= (PlayFabResultEvent<LinkFacebookAccountResult>)delegate135;
					}
				}
			}
			if (this.OnLinkGameCenterAccountRequestEvent != null)
			{
				foreach (Delegate delegate136 in this.OnLinkGameCenterAccountRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate136.Target, instance))
					{
						this.OnLinkGameCenterAccountRequestEvent -= (PlayFabRequestEvent<LinkGameCenterAccountRequest>)delegate136;
					}
				}
			}
			if (this.OnLinkGameCenterAccountResultEvent != null)
			{
				foreach (Delegate delegate137 in this.OnLinkGameCenterAccountResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate137.Target, instance))
					{
						this.OnLinkGameCenterAccountResultEvent -= (PlayFabResultEvent<LinkGameCenterAccountResult>)delegate137;
					}
				}
			}
			if (this.OnLinkGoogleAccountRequestEvent != null)
			{
				foreach (Delegate delegate138 in this.OnLinkGoogleAccountRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate138.Target, instance))
					{
						this.OnLinkGoogleAccountRequestEvent -= (PlayFabRequestEvent<LinkGoogleAccountRequest>)delegate138;
					}
				}
			}
			if (this.OnLinkGoogleAccountResultEvent != null)
			{
				foreach (Delegate delegate139 in this.OnLinkGoogleAccountResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate139.Target, instance))
					{
						this.OnLinkGoogleAccountResultEvent -= (PlayFabResultEvent<LinkGoogleAccountResult>)delegate139;
					}
				}
			}
			if (this.OnLinkIOSDeviceIDRequestEvent != null)
			{
				foreach (Delegate delegate140 in this.OnLinkIOSDeviceIDRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate140.Target, instance))
					{
						this.OnLinkIOSDeviceIDRequestEvent -= (PlayFabRequestEvent<LinkIOSDeviceIDRequest>)delegate140;
					}
				}
			}
			if (this.OnLinkIOSDeviceIDResultEvent != null)
			{
				foreach (Delegate delegate141 in this.OnLinkIOSDeviceIDResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate141.Target, instance))
					{
						this.OnLinkIOSDeviceIDResultEvent -= (PlayFabResultEvent<LinkIOSDeviceIDResult>)delegate141;
					}
				}
			}
			if (this.OnLinkKongregateRequestEvent != null)
			{
				foreach (Delegate delegate142 in this.OnLinkKongregateRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate142.Target, instance))
					{
						this.OnLinkKongregateRequestEvent -= (PlayFabRequestEvent<LinkKongregateAccountRequest>)delegate142;
					}
				}
			}
			if (this.OnLinkKongregateResultEvent != null)
			{
				foreach (Delegate delegate143 in this.OnLinkKongregateResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate143.Target, instance))
					{
						this.OnLinkKongregateResultEvent -= (PlayFabResultEvent<LinkKongregateAccountResult>)delegate143;
					}
				}
			}
			if (this.OnLinkSteamAccountRequestEvent != null)
			{
				foreach (Delegate delegate144 in this.OnLinkSteamAccountRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate144.Target, instance))
					{
						this.OnLinkSteamAccountRequestEvent -= (PlayFabRequestEvent<LinkSteamAccountRequest>)delegate144;
					}
				}
			}
			if (this.OnLinkSteamAccountResultEvent != null)
			{
				foreach (Delegate delegate145 in this.OnLinkSteamAccountResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate145.Target, instance))
					{
						this.OnLinkSteamAccountResultEvent -= (PlayFabResultEvent<LinkSteamAccountResult>)delegate145;
					}
				}
			}
			if (this.OnLinkTwitchRequestEvent != null)
			{
				foreach (Delegate delegate146 in this.OnLinkTwitchRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate146.Target, instance))
					{
						this.OnLinkTwitchRequestEvent -= (PlayFabRequestEvent<LinkTwitchAccountRequest>)delegate146;
					}
				}
			}
			if (this.OnLinkTwitchResultEvent != null)
			{
				foreach (Delegate delegate147 in this.OnLinkTwitchResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate147.Target, instance))
					{
						this.OnLinkTwitchResultEvent -= (PlayFabResultEvent<LinkTwitchAccountResult>)delegate147;
					}
				}
			}
			if (this.OnLinkWindowsHelloRequestEvent != null)
			{
				foreach (Delegate delegate148 in this.OnLinkWindowsHelloRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate148.Target, instance))
					{
						this.OnLinkWindowsHelloRequestEvent -= (PlayFabRequestEvent<LinkWindowsHelloAccountRequest>)delegate148;
					}
				}
			}
			if (this.OnLinkWindowsHelloResultEvent != null)
			{
				foreach (Delegate delegate149 in this.OnLinkWindowsHelloResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate149.Target, instance))
					{
						this.OnLinkWindowsHelloResultEvent -= (PlayFabResultEvent<LinkWindowsHelloAccountResponse>)delegate149;
					}
				}
			}
			if (this.OnLoginWithAndroidDeviceIDRequestEvent != null)
			{
				foreach (Delegate delegate150 in this.OnLoginWithAndroidDeviceIDRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate150.Target, instance))
					{
						this.OnLoginWithAndroidDeviceIDRequestEvent -= (PlayFabRequestEvent<LoginWithAndroidDeviceIDRequest>)delegate150;
					}
				}
			}
			if (this.OnLoginWithCustomIDRequestEvent != null)
			{
				foreach (Delegate delegate151 in this.OnLoginWithCustomIDRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate151.Target, instance))
					{
						this.OnLoginWithCustomIDRequestEvent -= (PlayFabRequestEvent<LoginWithCustomIDRequest>)delegate151;
					}
				}
			}
			if (this.OnLoginWithEmailAddressRequestEvent != null)
			{
				foreach (Delegate delegate152 in this.OnLoginWithEmailAddressRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate152.Target, instance))
					{
						this.OnLoginWithEmailAddressRequestEvent -= (PlayFabRequestEvent<LoginWithEmailAddressRequest>)delegate152;
					}
				}
			}
			if (this.OnLoginWithFacebookRequestEvent != null)
			{
				foreach (Delegate delegate153 in this.OnLoginWithFacebookRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate153.Target, instance))
					{
						this.OnLoginWithFacebookRequestEvent -= (PlayFabRequestEvent<LoginWithFacebookRequest>)delegate153;
					}
				}
			}
			if (this.OnLoginWithGameCenterRequestEvent != null)
			{
				foreach (Delegate delegate154 in this.OnLoginWithGameCenterRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate154.Target, instance))
					{
						this.OnLoginWithGameCenterRequestEvent -= (PlayFabRequestEvent<LoginWithGameCenterRequest>)delegate154;
					}
				}
			}
			if (this.OnLoginWithGoogleAccountRequestEvent != null)
			{
				foreach (Delegate delegate155 in this.OnLoginWithGoogleAccountRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate155.Target, instance))
					{
						this.OnLoginWithGoogleAccountRequestEvent -= (PlayFabRequestEvent<LoginWithGoogleAccountRequest>)delegate155;
					}
				}
			}
			if (this.OnLoginWithIOSDeviceIDRequestEvent != null)
			{
				foreach (Delegate delegate156 in this.OnLoginWithIOSDeviceIDRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate156.Target, instance))
					{
						this.OnLoginWithIOSDeviceIDRequestEvent -= (PlayFabRequestEvent<LoginWithIOSDeviceIDRequest>)delegate156;
					}
				}
			}
			if (this.OnLoginWithKongregateRequestEvent != null)
			{
				foreach (Delegate delegate157 in this.OnLoginWithKongregateRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate157.Target, instance))
					{
						this.OnLoginWithKongregateRequestEvent -= (PlayFabRequestEvent<LoginWithKongregateRequest>)delegate157;
					}
				}
			}
			if (this.OnLoginWithPlayFabRequestEvent != null)
			{
				foreach (Delegate delegate158 in this.OnLoginWithPlayFabRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate158.Target, instance))
					{
						this.OnLoginWithPlayFabRequestEvent -= (PlayFabRequestEvent<LoginWithPlayFabRequest>)delegate158;
					}
				}
			}
			if (this.OnLoginWithSteamRequestEvent != null)
			{
				foreach (Delegate delegate159 in this.OnLoginWithSteamRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate159.Target, instance))
					{
						this.OnLoginWithSteamRequestEvent -= (PlayFabRequestEvent<LoginWithSteamRequest>)delegate159;
					}
				}
			}
			if (this.OnLoginWithTwitchRequestEvent != null)
			{
				foreach (Delegate delegate160 in this.OnLoginWithTwitchRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate160.Target, instance))
					{
						this.OnLoginWithTwitchRequestEvent -= (PlayFabRequestEvent<LoginWithTwitchRequest>)delegate160;
					}
				}
			}
			if (this.OnLoginWithWindowsHelloRequestEvent != null)
			{
				foreach (Delegate delegate161 in this.OnLoginWithWindowsHelloRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate161.Target, instance))
					{
						this.OnLoginWithWindowsHelloRequestEvent -= (PlayFabRequestEvent<LoginWithWindowsHelloRequest>)delegate161;
					}
				}
			}
			if (this.OnMatchmakeRequestEvent != null)
			{
				foreach (Delegate delegate162 in this.OnMatchmakeRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate162.Target, instance))
					{
						this.OnMatchmakeRequestEvent -= (PlayFabRequestEvent<MatchmakeRequest>)delegate162;
					}
				}
			}
			if (this.OnMatchmakeResultEvent != null)
			{
				foreach (Delegate delegate163 in this.OnMatchmakeResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate163.Target, instance))
					{
						this.OnMatchmakeResultEvent -= (PlayFabResultEvent<MatchmakeResult>)delegate163;
					}
				}
			}
			if (this.OnOpenTradeRequestEvent != null)
			{
				foreach (Delegate delegate164 in this.OnOpenTradeRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate164.Target, instance))
					{
						this.OnOpenTradeRequestEvent -= (PlayFabRequestEvent<OpenTradeRequest>)delegate164;
					}
				}
			}
			if (this.OnOpenTradeResultEvent != null)
			{
				foreach (Delegate delegate165 in this.OnOpenTradeResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate165.Target, instance))
					{
						this.OnOpenTradeResultEvent -= (PlayFabResultEvent<OpenTradeResponse>)delegate165;
					}
				}
			}
			if (this.OnPayForPurchaseRequestEvent != null)
			{
				foreach (Delegate delegate166 in this.OnPayForPurchaseRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate166.Target, instance))
					{
						this.OnPayForPurchaseRequestEvent -= (PlayFabRequestEvent<PayForPurchaseRequest>)delegate166;
					}
				}
			}
			if (this.OnPayForPurchaseResultEvent != null)
			{
				foreach (Delegate delegate167 in this.OnPayForPurchaseResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate167.Target, instance))
					{
						this.OnPayForPurchaseResultEvent -= (PlayFabResultEvent<PayForPurchaseResult>)delegate167;
					}
				}
			}
			if (this.OnPurchaseItemRequestEvent != null)
			{
				foreach (Delegate delegate168 in this.OnPurchaseItemRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate168.Target, instance))
					{
						this.OnPurchaseItemRequestEvent -= (PlayFabRequestEvent<PurchaseItemRequest>)delegate168;
					}
				}
			}
			if (this.OnPurchaseItemResultEvent != null)
			{
				foreach (Delegate delegate169 in this.OnPurchaseItemResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate169.Target, instance))
					{
						this.OnPurchaseItemResultEvent -= (PlayFabResultEvent<PurchaseItemResult>)delegate169;
					}
				}
			}
			if (this.OnRedeemCouponRequestEvent != null)
			{
				foreach (Delegate delegate170 in this.OnRedeemCouponRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate170.Target, instance))
					{
						this.OnRedeemCouponRequestEvent -= (PlayFabRequestEvent<RedeemCouponRequest>)delegate170;
					}
				}
			}
			if (this.OnRedeemCouponResultEvent != null)
			{
				foreach (Delegate delegate171 in this.OnRedeemCouponResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate171.Target, instance))
					{
						this.OnRedeemCouponResultEvent -= (PlayFabResultEvent<RedeemCouponResult>)delegate171;
					}
				}
			}
			if (this.OnRegisterForIOSPushNotificationRequestEvent != null)
			{
				foreach (Delegate delegate172 in this.OnRegisterForIOSPushNotificationRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate172.Target, instance))
					{
						this.OnRegisterForIOSPushNotificationRequestEvent -= (PlayFabRequestEvent<RegisterForIOSPushNotificationRequest>)delegate172;
					}
				}
			}
			if (this.OnRegisterForIOSPushNotificationResultEvent != null)
			{
				foreach (Delegate delegate173 in this.OnRegisterForIOSPushNotificationResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate173.Target, instance))
					{
						this.OnRegisterForIOSPushNotificationResultEvent -= (PlayFabResultEvent<RegisterForIOSPushNotificationResult>)delegate173;
					}
				}
			}
			if (this.OnRegisterPlayFabUserRequestEvent != null)
			{
				foreach (Delegate delegate174 in this.OnRegisterPlayFabUserRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate174.Target, instance))
					{
						this.OnRegisterPlayFabUserRequestEvent -= (PlayFabRequestEvent<RegisterPlayFabUserRequest>)delegate174;
					}
				}
			}
			if (this.OnRegisterPlayFabUserResultEvent != null)
			{
				foreach (Delegate delegate175 in this.OnRegisterPlayFabUserResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate175.Target, instance))
					{
						this.OnRegisterPlayFabUserResultEvent -= (PlayFabResultEvent<RegisterPlayFabUserResult>)delegate175;
					}
				}
			}
			if (this.OnRegisterWithWindowsHelloRequestEvent != null)
			{
				foreach (Delegate delegate176 in this.OnRegisterWithWindowsHelloRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate176.Target, instance))
					{
						this.OnRegisterWithWindowsHelloRequestEvent -= (PlayFabRequestEvent<RegisterWithWindowsHelloRequest>)delegate176;
					}
				}
			}
			if (this.OnRemoveContactEmailRequestEvent != null)
			{
				foreach (Delegate delegate177 in this.OnRemoveContactEmailRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate177.Target, instance))
					{
						this.OnRemoveContactEmailRequestEvent -= (PlayFabRequestEvent<RemoveContactEmailRequest>)delegate177;
					}
				}
			}
			if (this.OnRemoveContactEmailResultEvent != null)
			{
				foreach (Delegate delegate178 in this.OnRemoveContactEmailResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate178.Target, instance))
					{
						this.OnRemoveContactEmailResultEvent -= (PlayFabResultEvent<RemoveContactEmailResult>)delegate178;
					}
				}
			}
			if (this.OnRemoveFriendRequestEvent != null)
			{
				foreach (Delegate delegate179 in this.OnRemoveFriendRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate179.Target, instance))
					{
						this.OnRemoveFriendRequestEvent -= (PlayFabRequestEvent<RemoveFriendRequest>)delegate179;
					}
				}
			}
			if (this.OnRemoveFriendResultEvent != null)
			{
				foreach (Delegate delegate180 in this.OnRemoveFriendResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate180.Target, instance))
					{
						this.OnRemoveFriendResultEvent -= (PlayFabResultEvent<RemoveFriendResult>)delegate180;
					}
				}
			}
			if (this.OnRemoveGenericIDRequestEvent != null)
			{
				foreach (Delegate delegate181 in this.OnRemoveGenericIDRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate181.Target, instance))
					{
						this.OnRemoveGenericIDRequestEvent -= (PlayFabRequestEvent<RemoveGenericIDRequest>)delegate181;
					}
				}
			}
			if (this.OnRemoveGenericIDResultEvent != null)
			{
				foreach (Delegate delegate182 in this.OnRemoveGenericIDResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate182.Target, instance))
					{
						this.OnRemoveGenericIDResultEvent -= (PlayFabResultEvent<RemoveGenericIDResult>)delegate182;
					}
				}
			}
			if (this.OnRemoveSharedGroupMembersRequestEvent != null)
			{
				foreach (Delegate delegate183 in this.OnRemoveSharedGroupMembersRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate183.Target, instance))
					{
						this.OnRemoveSharedGroupMembersRequestEvent -= (PlayFabRequestEvent<RemoveSharedGroupMembersRequest>)delegate183;
					}
				}
			}
			if (this.OnRemoveSharedGroupMembersResultEvent != null)
			{
				foreach (Delegate delegate184 in this.OnRemoveSharedGroupMembersResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate184.Target, instance))
					{
						this.OnRemoveSharedGroupMembersResultEvent -= (PlayFabResultEvent<RemoveSharedGroupMembersResult>)delegate184;
					}
				}
			}
			if (this.OnReportDeviceInfoRequestEvent != null)
			{
				foreach (Delegate delegate185 in this.OnReportDeviceInfoRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate185.Target, instance))
					{
						this.OnReportDeviceInfoRequestEvent -= (PlayFabRequestEvent<DeviceInfoRequest>)delegate185;
					}
				}
			}
			if (this.OnReportDeviceInfoResultEvent != null)
			{
				foreach (Delegate delegate186 in this.OnReportDeviceInfoResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate186.Target, instance))
					{
						this.OnReportDeviceInfoResultEvent -= (PlayFabResultEvent<EmptyResult>)delegate186;
					}
				}
			}
			if (this.OnReportPlayerRequestEvent != null)
			{
				foreach (Delegate delegate187 in this.OnReportPlayerRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate187.Target, instance))
					{
						this.OnReportPlayerRequestEvent -= (PlayFabRequestEvent<ReportPlayerClientRequest>)delegate187;
					}
				}
			}
			if (this.OnReportPlayerResultEvent != null)
			{
				foreach (Delegate delegate188 in this.OnReportPlayerResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate188.Target, instance))
					{
						this.OnReportPlayerResultEvent -= (PlayFabResultEvent<ReportPlayerClientResult>)delegate188;
					}
				}
			}
			if (this.OnRestoreIOSPurchasesRequestEvent != null)
			{
				foreach (Delegate delegate189 in this.OnRestoreIOSPurchasesRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate189.Target, instance))
					{
						this.OnRestoreIOSPurchasesRequestEvent -= (PlayFabRequestEvent<RestoreIOSPurchasesRequest>)delegate189;
					}
				}
			}
			if (this.OnRestoreIOSPurchasesResultEvent != null)
			{
				foreach (Delegate delegate190 in this.OnRestoreIOSPurchasesResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate190.Target, instance))
					{
						this.OnRestoreIOSPurchasesResultEvent -= (PlayFabResultEvent<RestoreIOSPurchasesResult>)delegate190;
					}
				}
			}
			if (this.OnSendAccountRecoveryEmailRequestEvent != null)
			{
				foreach (Delegate delegate191 in this.OnSendAccountRecoveryEmailRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate191.Target, instance))
					{
						this.OnSendAccountRecoveryEmailRequestEvent -= (PlayFabRequestEvent<SendAccountRecoveryEmailRequest>)delegate191;
					}
				}
			}
			if (this.OnSendAccountRecoveryEmailResultEvent != null)
			{
				foreach (Delegate delegate192 in this.OnSendAccountRecoveryEmailResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate192.Target, instance))
					{
						this.OnSendAccountRecoveryEmailResultEvent -= (PlayFabResultEvent<SendAccountRecoveryEmailResult>)delegate192;
					}
				}
			}
			if (this.OnSetFriendTagsRequestEvent != null)
			{
				foreach (Delegate delegate193 in this.OnSetFriendTagsRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate193.Target, instance))
					{
						this.OnSetFriendTagsRequestEvent -= (PlayFabRequestEvent<SetFriendTagsRequest>)delegate193;
					}
				}
			}
			if (this.OnSetFriendTagsResultEvent != null)
			{
				foreach (Delegate delegate194 in this.OnSetFriendTagsResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate194.Target, instance))
					{
						this.OnSetFriendTagsResultEvent -= (PlayFabResultEvent<SetFriendTagsResult>)delegate194;
					}
				}
			}
			if (this.OnSetPlayerSecretRequestEvent != null)
			{
				foreach (Delegate delegate195 in this.OnSetPlayerSecretRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate195.Target, instance))
					{
						this.OnSetPlayerSecretRequestEvent -= (PlayFabRequestEvent<SetPlayerSecretRequest>)delegate195;
					}
				}
			}
			if (this.OnSetPlayerSecretResultEvent != null)
			{
				foreach (Delegate delegate196 in this.OnSetPlayerSecretResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate196.Target, instance))
					{
						this.OnSetPlayerSecretResultEvent -= (PlayFabResultEvent<SetPlayerSecretResult>)delegate196;
					}
				}
			}
			if (this.OnStartGameRequestEvent != null)
			{
				foreach (Delegate delegate197 in this.OnStartGameRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate197.Target, instance))
					{
						this.OnStartGameRequestEvent -= (PlayFabRequestEvent<StartGameRequest>)delegate197;
					}
				}
			}
			if (this.OnStartGameResultEvent != null)
			{
				foreach (Delegate delegate198 in this.OnStartGameResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate198.Target, instance))
					{
						this.OnStartGameResultEvent -= (PlayFabResultEvent<StartGameResult>)delegate198;
					}
				}
			}
			if (this.OnStartPurchaseRequestEvent != null)
			{
				foreach (Delegate delegate199 in this.OnStartPurchaseRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate199.Target, instance))
					{
						this.OnStartPurchaseRequestEvent -= (PlayFabRequestEvent<StartPurchaseRequest>)delegate199;
					}
				}
			}
			if (this.OnStartPurchaseResultEvent != null)
			{
				foreach (Delegate delegate200 in this.OnStartPurchaseResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate200.Target, instance))
					{
						this.OnStartPurchaseResultEvent -= (PlayFabResultEvent<StartPurchaseResult>)delegate200;
					}
				}
			}
			if (this.OnSubtractUserVirtualCurrencyRequestEvent != null)
			{
				foreach (Delegate delegate201 in this.OnSubtractUserVirtualCurrencyRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate201.Target, instance))
					{
						this.OnSubtractUserVirtualCurrencyRequestEvent -= (PlayFabRequestEvent<SubtractUserVirtualCurrencyRequest>)delegate201;
					}
				}
			}
			if (this.OnSubtractUserVirtualCurrencyResultEvent != null)
			{
				foreach (Delegate delegate202 in this.OnSubtractUserVirtualCurrencyResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate202.Target, instance))
					{
						this.OnSubtractUserVirtualCurrencyResultEvent -= (PlayFabResultEvent<ModifyUserVirtualCurrencyResult>)delegate202;
					}
				}
			}
			if (this.OnUnlinkAndroidDeviceIDRequestEvent != null)
			{
				foreach (Delegate delegate203 in this.OnUnlinkAndroidDeviceIDRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate203.Target, instance))
					{
						this.OnUnlinkAndroidDeviceIDRequestEvent -= (PlayFabRequestEvent<UnlinkAndroidDeviceIDRequest>)delegate203;
					}
				}
			}
			if (this.OnUnlinkAndroidDeviceIDResultEvent != null)
			{
				foreach (Delegate delegate204 in this.OnUnlinkAndroidDeviceIDResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate204.Target, instance))
					{
						this.OnUnlinkAndroidDeviceIDResultEvent -= (PlayFabResultEvent<UnlinkAndroidDeviceIDResult>)delegate204;
					}
				}
			}
			if (this.OnUnlinkCustomIDRequestEvent != null)
			{
				foreach (Delegate delegate205 in this.OnUnlinkCustomIDRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate205.Target, instance))
					{
						this.OnUnlinkCustomIDRequestEvent -= (PlayFabRequestEvent<UnlinkCustomIDRequest>)delegate205;
					}
				}
			}
			if (this.OnUnlinkCustomIDResultEvent != null)
			{
				foreach (Delegate delegate206 in this.OnUnlinkCustomIDResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate206.Target, instance))
					{
						this.OnUnlinkCustomIDResultEvent -= (PlayFabResultEvent<UnlinkCustomIDResult>)delegate206;
					}
				}
			}
			if (this.OnUnlinkFacebookAccountRequestEvent != null)
			{
				foreach (Delegate delegate207 in this.OnUnlinkFacebookAccountRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate207.Target, instance))
					{
						this.OnUnlinkFacebookAccountRequestEvent -= (PlayFabRequestEvent<UnlinkFacebookAccountRequest>)delegate207;
					}
				}
			}
			if (this.OnUnlinkFacebookAccountResultEvent != null)
			{
				foreach (Delegate delegate208 in this.OnUnlinkFacebookAccountResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate208.Target, instance))
					{
						this.OnUnlinkFacebookAccountResultEvent -= (PlayFabResultEvent<UnlinkFacebookAccountResult>)delegate208;
					}
				}
			}
			if (this.OnUnlinkGameCenterAccountRequestEvent != null)
			{
				foreach (Delegate delegate209 in this.OnUnlinkGameCenterAccountRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate209.Target, instance))
					{
						this.OnUnlinkGameCenterAccountRequestEvent -= (PlayFabRequestEvent<UnlinkGameCenterAccountRequest>)delegate209;
					}
				}
			}
			if (this.OnUnlinkGameCenterAccountResultEvent != null)
			{
				foreach (Delegate delegate210 in this.OnUnlinkGameCenterAccountResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate210.Target, instance))
					{
						this.OnUnlinkGameCenterAccountResultEvent -= (PlayFabResultEvent<UnlinkGameCenterAccountResult>)delegate210;
					}
				}
			}
			if (this.OnUnlinkGoogleAccountRequestEvent != null)
			{
				foreach (Delegate delegate211 in this.OnUnlinkGoogleAccountRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate211.Target, instance))
					{
						this.OnUnlinkGoogleAccountRequestEvent -= (PlayFabRequestEvent<UnlinkGoogleAccountRequest>)delegate211;
					}
				}
			}
			if (this.OnUnlinkGoogleAccountResultEvent != null)
			{
				foreach (Delegate delegate212 in this.OnUnlinkGoogleAccountResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate212.Target, instance))
					{
						this.OnUnlinkGoogleAccountResultEvent -= (PlayFabResultEvent<UnlinkGoogleAccountResult>)delegate212;
					}
				}
			}
			if (this.OnUnlinkIOSDeviceIDRequestEvent != null)
			{
				foreach (Delegate delegate213 in this.OnUnlinkIOSDeviceIDRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate213.Target, instance))
					{
						this.OnUnlinkIOSDeviceIDRequestEvent -= (PlayFabRequestEvent<UnlinkIOSDeviceIDRequest>)delegate213;
					}
				}
			}
			if (this.OnUnlinkIOSDeviceIDResultEvent != null)
			{
				foreach (Delegate delegate214 in this.OnUnlinkIOSDeviceIDResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate214.Target, instance))
					{
						this.OnUnlinkIOSDeviceIDResultEvent -= (PlayFabResultEvent<UnlinkIOSDeviceIDResult>)delegate214;
					}
				}
			}
			if (this.OnUnlinkKongregateRequestEvent != null)
			{
				foreach (Delegate delegate215 in this.OnUnlinkKongregateRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate215.Target, instance))
					{
						this.OnUnlinkKongregateRequestEvent -= (PlayFabRequestEvent<UnlinkKongregateAccountRequest>)delegate215;
					}
				}
			}
			if (this.OnUnlinkKongregateResultEvent != null)
			{
				foreach (Delegate delegate216 in this.OnUnlinkKongregateResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate216.Target, instance))
					{
						this.OnUnlinkKongregateResultEvent -= (PlayFabResultEvent<UnlinkKongregateAccountResult>)delegate216;
					}
				}
			}
			if (this.OnUnlinkSteamAccountRequestEvent != null)
			{
				foreach (Delegate delegate217 in this.OnUnlinkSteamAccountRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate217.Target, instance))
					{
						this.OnUnlinkSteamAccountRequestEvent -= (PlayFabRequestEvent<UnlinkSteamAccountRequest>)delegate217;
					}
				}
			}
			if (this.OnUnlinkSteamAccountResultEvent != null)
			{
				foreach (Delegate delegate218 in this.OnUnlinkSteamAccountResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate218.Target, instance))
					{
						this.OnUnlinkSteamAccountResultEvent -= (PlayFabResultEvent<UnlinkSteamAccountResult>)delegate218;
					}
				}
			}
			if (this.OnUnlinkTwitchRequestEvent != null)
			{
				foreach (Delegate delegate219 in this.OnUnlinkTwitchRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate219.Target, instance))
					{
						this.OnUnlinkTwitchRequestEvent -= (PlayFabRequestEvent<UnlinkTwitchAccountRequest>)delegate219;
					}
				}
			}
			if (this.OnUnlinkTwitchResultEvent != null)
			{
				foreach (Delegate delegate220 in this.OnUnlinkTwitchResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate220.Target, instance))
					{
						this.OnUnlinkTwitchResultEvent -= (PlayFabResultEvent<UnlinkTwitchAccountResult>)delegate220;
					}
				}
			}
			if (this.OnUnlinkWindowsHelloRequestEvent != null)
			{
				foreach (Delegate delegate221 in this.OnUnlinkWindowsHelloRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate221.Target, instance))
					{
						this.OnUnlinkWindowsHelloRequestEvent -= (PlayFabRequestEvent<UnlinkWindowsHelloAccountRequest>)delegate221;
					}
				}
			}
			if (this.OnUnlinkWindowsHelloResultEvent != null)
			{
				foreach (Delegate delegate222 in this.OnUnlinkWindowsHelloResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate222.Target, instance))
					{
						this.OnUnlinkWindowsHelloResultEvent -= (PlayFabResultEvent<UnlinkWindowsHelloAccountResponse>)delegate222;
					}
				}
			}
			if (this.OnUnlockContainerInstanceRequestEvent != null)
			{
				foreach (Delegate delegate223 in this.OnUnlockContainerInstanceRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate223.Target, instance))
					{
						this.OnUnlockContainerInstanceRequestEvent -= (PlayFabRequestEvent<UnlockContainerInstanceRequest>)delegate223;
					}
				}
			}
			if (this.OnUnlockContainerInstanceResultEvent != null)
			{
				foreach (Delegate delegate224 in this.OnUnlockContainerInstanceResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate224.Target, instance))
					{
						this.OnUnlockContainerInstanceResultEvent -= (PlayFabResultEvent<UnlockContainerItemResult>)delegate224;
					}
				}
			}
			if (this.OnUnlockContainerItemRequestEvent != null)
			{
				foreach (Delegate delegate225 in this.OnUnlockContainerItemRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate225.Target, instance))
					{
						this.OnUnlockContainerItemRequestEvent -= (PlayFabRequestEvent<UnlockContainerItemRequest>)delegate225;
					}
				}
			}
			if (this.OnUnlockContainerItemResultEvent != null)
			{
				foreach (Delegate delegate226 in this.OnUnlockContainerItemResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate226.Target, instance))
					{
						this.OnUnlockContainerItemResultEvent -= (PlayFabResultEvent<UnlockContainerItemResult>)delegate226;
					}
				}
			}
			if (this.OnUpdateAvatarUrlRequestEvent != null)
			{
				foreach (Delegate delegate227 in this.OnUpdateAvatarUrlRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate227.Target, instance))
					{
						this.OnUpdateAvatarUrlRequestEvent -= (PlayFabRequestEvent<UpdateAvatarUrlRequest>)delegate227;
					}
				}
			}
			if (this.OnUpdateAvatarUrlResultEvent != null)
			{
				foreach (Delegate delegate228 in this.OnUpdateAvatarUrlResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate228.Target, instance))
					{
						this.OnUpdateAvatarUrlResultEvent -= (PlayFabResultEvent<EmptyResult>)delegate228;
					}
				}
			}
			if (this.OnUpdateCharacterDataRequestEvent != null)
			{
				foreach (Delegate delegate229 in this.OnUpdateCharacterDataRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate229.Target, instance))
					{
						this.OnUpdateCharacterDataRequestEvent -= (PlayFabRequestEvent<UpdateCharacterDataRequest>)delegate229;
					}
				}
			}
			if (this.OnUpdateCharacterDataResultEvent != null)
			{
				foreach (Delegate delegate230 in this.OnUpdateCharacterDataResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate230.Target, instance))
					{
						this.OnUpdateCharacterDataResultEvent -= (PlayFabResultEvent<UpdateCharacterDataResult>)delegate230;
					}
				}
			}
			if (this.OnUpdateCharacterStatisticsRequestEvent != null)
			{
				foreach (Delegate delegate231 in this.OnUpdateCharacterStatisticsRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate231.Target, instance))
					{
						this.OnUpdateCharacterStatisticsRequestEvent -= (PlayFabRequestEvent<UpdateCharacterStatisticsRequest>)delegate231;
					}
				}
			}
			if (this.OnUpdateCharacterStatisticsResultEvent != null)
			{
				foreach (Delegate delegate232 in this.OnUpdateCharacterStatisticsResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate232.Target, instance))
					{
						this.OnUpdateCharacterStatisticsResultEvent -= (PlayFabResultEvent<UpdateCharacterStatisticsResult>)delegate232;
					}
				}
			}
			if (this.OnUpdatePlayerStatisticsRequestEvent != null)
			{
				foreach (Delegate delegate233 in this.OnUpdatePlayerStatisticsRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate233.Target, instance))
					{
						this.OnUpdatePlayerStatisticsRequestEvent -= (PlayFabRequestEvent<UpdatePlayerStatisticsRequest>)delegate233;
					}
				}
			}
			if (this.OnUpdatePlayerStatisticsResultEvent != null)
			{
				foreach (Delegate delegate234 in this.OnUpdatePlayerStatisticsResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate234.Target, instance))
					{
						this.OnUpdatePlayerStatisticsResultEvent -= (PlayFabResultEvent<UpdatePlayerStatisticsResult>)delegate234;
					}
				}
			}
			if (this.OnUpdateSharedGroupDataRequestEvent != null)
			{
				foreach (Delegate delegate235 in this.OnUpdateSharedGroupDataRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate235.Target, instance))
					{
						this.OnUpdateSharedGroupDataRequestEvent -= (PlayFabRequestEvent<UpdateSharedGroupDataRequest>)delegate235;
					}
				}
			}
			if (this.OnUpdateSharedGroupDataResultEvent != null)
			{
				foreach (Delegate delegate236 in this.OnUpdateSharedGroupDataResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate236.Target, instance))
					{
						this.OnUpdateSharedGroupDataResultEvent -= (PlayFabResultEvent<UpdateSharedGroupDataResult>)delegate236;
					}
				}
			}
			if (this.OnUpdateUserDataRequestEvent != null)
			{
				foreach (Delegate delegate237 in this.OnUpdateUserDataRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate237.Target, instance))
					{
						this.OnUpdateUserDataRequestEvent -= (PlayFabRequestEvent<UpdateUserDataRequest>)delegate237;
					}
				}
			}
			if (this.OnUpdateUserDataResultEvent != null)
			{
				foreach (Delegate delegate238 in this.OnUpdateUserDataResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate238.Target, instance))
					{
						this.OnUpdateUserDataResultEvent -= (PlayFabResultEvent<UpdateUserDataResult>)delegate238;
					}
				}
			}
			if (this.OnUpdateUserPublisherDataRequestEvent != null)
			{
				foreach (Delegate delegate239 in this.OnUpdateUserPublisherDataRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate239.Target, instance))
					{
						this.OnUpdateUserPublisherDataRequestEvent -= (PlayFabRequestEvent<UpdateUserDataRequest>)delegate239;
					}
				}
			}
			if (this.OnUpdateUserPublisherDataResultEvent != null)
			{
				foreach (Delegate delegate240 in this.OnUpdateUserPublisherDataResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate240.Target, instance))
					{
						this.OnUpdateUserPublisherDataResultEvent -= (PlayFabResultEvent<UpdateUserDataResult>)delegate240;
					}
				}
			}
			if (this.OnUpdateUserTitleDisplayNameRequestEvent != null)
			{
				foreach (Delegate delegate241 in this.OnUpdateUserTitleDisplayNameRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate241.Target, instance))
					{
						this.OnUpdateUserTitleDisplayNameRequestEvent -= (PlayFabRequestEvent<UpdateUserTitleDisplayNameRequest>)delegate241;
					}
				}
			}
			if (this.OnUpdateUserTitleDisplayNameResultEvent != null)
			{
				foreach (Delegate delegate242 in this.OnUpdateUserTitleDisplayNameResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate242.Target, instance))
					{
						this.OnUpdateUserTitleDisplayNameResultEvent -= (PlayFabResultEvent<UpdateUserTitleDisplayNameResult>)delegate242;
					}
				}
			}
			if (this.OnValidateAmazonIAPReceiptRequestEvent != null)
			{
				foreach (Delegate delegate243 in this.OnValidateAmazonIAPReceiptRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate243.Target, instance))
					{
						this.OnValidateAmazonIAPReceiptRequestEvent -= (PlayFabRequestEvent<ValidateAmazonReceiptRequest>)delegate243;
					}
				}
			}
			if (this.OnValidateAmazonIAPReceiptResultEvent != null)
			{
				foreach (Delegate delegate244 in this.OnValidateAmazonIAPReceiptResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate244.Target, instance))
					{
						this.OnValidateAmazonIAPReceiptResultEvent -= (PlayFabResultEvent<ValidateAmazonReceiptResult>)delegate244;
					}
				}
			}
			if (this.OnValidateGooglePlayPurchaseRequestEvent != null)
			{
				foreach (Delegate delegate245 in this.OnValidateGooglePlayPurchaseRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate245.Target, instance))
					{
						this.OnValidateGooglePlayPurchaseRequestEvent -= (PlayFabRequestEvent<ValidateGooglePlayPurchaseRequest>)delegate245;
					}
				}
			}
			if (this.OnValidateGooglePlayPurchaseResultEvent != null)
			{
				foreach (Delegate delegate246 in this.OnValidateGooglePlayPurchaseResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate246.Target, instance))
					{
						this.OnValidateGooglePlayPurchaseResultEvent -= (PlayFabResultEvent<ValidateGooglePlayPurchaseResult>)delegate246;
					}
				}
			}
			if (this.OnValidateIOSReceiptRequestEvent != null)
			{
				foreach (Delegate delegate247 in this.OnValidateIOSReceiptRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate247.Target, instance))
					{
						this.OnValidateIOSReceiptRequestEvent -= (PlayFabRequestEvent<ValidateIOSReceiptRequest>)delegate247;
					}
				}
			}
			if (this.OnValidateIOSReceiptResultEvent != null)
			{
				foreach (Delegate delegate248 in this.OnValidateIOSReceiptResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate248.Target, instance))
					{
						this.OnValidateIOSReceiptResultEvent -= (PlayFabResultEvent<ValidateIOSReceiptResult>)delegate248;
					}
				}
			}
			if (this.OnValidateWindowsStoreReceiptRequestEvent != null)
			{
				foreach (Delegate delegate249 in this.OnValidateWindowsStoreReceiptRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate249.Target, instance))
					{
						this.OnValidateWindowsStoreReceiptRequestEvent -= (PlayFabRequestEvent<ValidateWindowsReceiptRequest>)delegate249;
					}
				}
			}
			if (this.OnValidateWindowsStoreReceiptResultEvent != null)
			{
				foreach (Delegate delegate250 in this.OnValidateWindowsStoreReceiptResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate250.Target, instance))
					{
						this.OnValidateWindowsStoreReceiptResultEvent -= (PlayFabResultEvent<ValidateWindowsReceiptResult>)delegate250;
					}
				}
			}
			if (this.OnWriteCharacterEventRequestEvent != null)
			{
				foreach (Delegate delegate251 in this.OnWriteCharacterEventRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate251.Target, instance))
					{
						this.OnWriteCharacterEventRequestEvent -= (PlayFabRequestEvent<WriteClientCharacterEventRequest>)delegate251;
					}
				}
			}
			if (this.OnWriteCharacterEventResultEvent != null)
			{
				foreach (Delegate delegate252 in this.OnWriteCharacterEventResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate252.Target, instance))
					{
						this.OnWriteCharacterEventResultEvent -= (PlayFabResultEvent<WriteEventResponse>)delegate252;
					}
				}
			}
			if (this.OnWritePlayerEventRequestEvent != null)
			{
				foreach (Delegate delegate253 in this.OnWritePlayerEventRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate253.Target, instance))
					{
						this.OnWritePlayerEventRequestEvent -= (PlayFabRequestEvent<WriteClientPlayerEventRequest>)delegate253;
					}
				}
			}
			if (this.OnWritePlayerEventResultEvent != null)
			{
				foreach (Delegate delegate254 in this.OnWritePlayerEventResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate254.Target, instance))
					{
						this.OnWritePlayerEventResultEvent -= (PlayFabResultEvent<WriteEventResponse>)delegate254;
					}
				}
			}
			if (this.OnWriteTitleEventRequestEvent != null)
			{
				foreach (Delegate delegate255 in this.OnWriteTitleEventRequestEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate255.Target, instance))
					{
						this.OnWriteTitleEventRequestEvent -= (PlayFabRequestEvent<WriteTitleEventRequest>)delegate255;
					}
				}
			}
			if (this.OnWriteTitleEventResultEvent != null)
			{
				foreach (Delegate delegate256 in this.OnWriteTitleEventResultEvent.GetInvocationList())
				{
					if (object.ReferenceEquals(delegate256.Target, instance))
					{
						this.OnWriteTitleEventResultEvent -= (PlayFabResultEvent<WriteEventResponse>)delegate256;
					}
				}
			}
		}

		private void OnProcessingErrorEvent(PlayFabRequestCommon request, PlayFabError error)
		{
			if (PlayFabEvents._instance.OnGlobalErrorEvent != null)
			{
				PlayFabEvents._instance.OnGlobalErrorEvent(request, error);
			}
		}

		private void OnProcessingEvent(ApiProcessingEventArgs e)
		{
			if (e.EventType == ApiProcessingEventType.Pre)
			{
				Type type = e.Request.GetType();
				if (type == typeof(AcceptTradeRequest) && PlayFabEvents._instance.OnAcceptTradeRequestEvent != null)
				{
					PlayFabEvents._instance.OnAcceptTradeRequestEvent((AcceptTradeRequest)e.Request);
					return;
				}
				if (type == typeof(AddFriendRequest) && PlayFabEvents._instance.OnAddFriendRequestEvent != null)
				{
					PlayFabEvents._instance.OnAddFriendRequestEvent((AddFriendRequest)e.Request);
					return;
				}
				if (type == typeof(AddGenericIDRequest) && PlayFabEvents._instance.OnAddGenericIDRequestEvent != null)
				{
					PlayFabEvents._instance.OnAddGenericIDRequestEvent((AddGenericIDRequest)e.Request);
					return;
				}
				if (type == typeof(AddOrUpdateContactEmailRequest) && PlayFabEvents._instance.OnAddOrUpdateContactEmailRequestEvent != null)
				{
					PlayFabEvents._instance.OnAddOrUpdateContactEmailRequestEvent((AddOrUpdateContactEmailRequest)e.Request);
					return;
				}
				if (type == typeof(AddSharedGroupMembersRequest) && PlayFabEvents._instance.OnAddSharedGroupMembersRequestEvent != null)
				{
					PlayFabEvents._instance.OnAddSharedGroupMembersRequestEvent((AddSharedGroupMembersRequest)e.Request);
					return;
				}
				if (type == typeof(AddUsernamePasswordRequest) && PlayFabEvents._instance.OnAddUsernamePasswordRequestEvent != null)
				{
					PlayFabEvents._instance.OnAddUsernamePasswordRequestEvent((AddUsernamePasswordRequest)e.Request);
					return;
				}
				if (type == typeof(AddUserVirtualCurrencyRequest) && PlayFabEvents._instance.OnAddUserVirtualCurrencyRequestEvent != null)
				{
					PlayFabEvents._instance.OnAddUserVirtualCurrencyRequestEvent((AddUserVirtualCurrencyRequest)e.Request);
					return;
				}
				if (type == typeof(AndroidDevicePushNotificationRegistrationRequest) && PlayFabEvents._instance.OnAndroidDevicePushNotificationRegistrationRequestEvent != null)
				{
					PlayFabEvents._instance.OnAndroidDevicePushNotificationRegistrationRequestEvent((AndroidDevicePushNotificationRegistrationRequest)e.Request);
					return;
				}
				if (type == typeof(AttributeInstallRequest) && PlayFabEvents._instance.OnAttributeInstallRequestEvent != null)
				{
					PlayFabEvents._instance.OnAttributeInstallRequestEvent((AttributeInstallRequest)e.Request);
					return;
				}
				if (type == typeof(CancelTradeRequest) && PlayFabEvents._instance.OnCancelTradeRequestEvent != null)
				{
					PlayFabEvents._instance.OnCancelTradeRequestEvent((CancelTradeRequest)e.Request);
					return;
				}
				if (type == typeof(ConfirmPurchaseRequest) && PlayFabEvents._instance.OnConfirmPurchaseRequestEvent != null)
				{
					PlayFabEvents._instance.OnConfirmPurchaseRequestEvent((ConfirmPurchaseRequest)e.Request);
					return;
				}
				if (type == typeof(ConsumeItemRequest) && PlayFabEvents._instance.OnConsumeItemRequestEvent != null)
				{
					PlayFabEvents._instance.OnConsumeItemRequestEvent((ConsumeItemRequest)e.Request);
					return;
				}
				if (type == typeof(CreateSharedGroupRequest) && PlayFabEvents._instance.OnCreateSharedGroupRequestEvent != null)
				{
					PlayFabEvents._instance.OnCreateSharedGroupRequestEvent((CreateSharedGroupRequest)e.Request);
					return;
				}
				if (type == typeof(ExecuteCloudScriptRequest) && PlayFabEvents._instance.OnExecuteCloudScriptRequestEvent != null)
				{
					PlayFabEvents._instance.OnExecuteCloudScriptRequestEvent((ExecuteCloudScriptRequest)e.Request);
					return;
				}
				if (type == typeof(GetAccountInfoRequest) && PlayFabEvents._instance.OnGetAccountInfoRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetAccountInfoRequestEvent((GetAccountInfoRequest)e.Request);
					return;
				}
				if (type == typeof(ListUsersCharactersRequest) && PlayFabEvents._instance.OnGetAllUsersCharactersRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetAllUsersCharactersRequestEvent((ListUsersCharactersRequest)e.Request);
					return;
				}
				if (type == typeof(GetCatalogItemsRequest) && PlayFabEvents._instance.OnGetCatalogItemsRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetCatalogItemsRequestEvent((GetCatalogItemsRequest)e.Request);
					return;
				}
				if (type == typeof(GetCharacterDataRequest) && PlayFabEvents._instance.OnGetCharacterDataRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetCharacterDataRequestEvent((GetCharacterDataRequest)e.Request);
					return;
				}
				if (type == typeof(GetCharacterInventoryRequest) && PlayFabEvents._instance.OnGetCharacterInventoryRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetCharacterInventoryRequestEvent((GetCharacterInventoryRequest)e.Request);
					return;
				}
				if (type == typeof(GetCharacterLeaderboardRequest) && PlayFabEvents._instance.OnGetCharacterLeaderboardRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetCharacterLeaderboardRequestEvent((GetCharacterLeaderboardRequest)e.Request);
					return;
				}
				if (type == typeof(GetCharacterDataRequest) && PlayFabEvents._instance.OnGetCharacterReadOnlyDataRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetCharacterReadOnlyDataRequestEvent((GetCharacterDataRequest)e.Request);
					return;
				}
				if (type == typeof(GetCharacterStatisticsRequest) && PlayFabEvents._instance.OnGetCharacterStatisticsRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetCharacterStatisticsRequestEvent((GetCharacterStatisticsRequest)e.Request);
					return;
				}
				if (type == typeof(GetContentDownloadUrlRequest) && PlayFabEvents._instance.OnGetContentDownloadUrlRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetContentDownloadUrlRequestEvent((GetContentDownloadUrlRequest)e.Request);
					return;
				}
				if (type == typeof(CurrentGamesRequest) && PlayFabEvents._instance.OnGetCurrentGamesRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetCurrentGamesRequestEvent((CurrentGamesRequest)e.Request);
					return;
				}
				if (type == typeof(GetFriendLeaderboardRequest) && PlayFabEvents._instance.OnGetFriendLeaderboardRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetFriendLeaderboardRequestEvent((GetFriendLeaderboardRequest)e.Request);
					return;
				}
				if (type == typeof(GetFriendLeaderboardAroundPlayerRequest) && PlayFabEvents._instance.OnGetFriendLeaderboardAroundPlayerRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetFriendLeaderboardAroundPlayerRequestEvent((GetFriendLeaderboardAroundPlayerRequest)e.Request);
					return;
				}
				if (type == typeof(GetFriendsListRequest) && PlayFabEvents._instance.OnGetFriendsListRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetFriendsListRequestEvent((GetFriendsListRequest)e.Request);
					return;
				}
				if (type == typeof(GameServerRegionsRequest) && PlayFabEvents._instance.OnGetGameServerRegionsRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetGameServerRegionsRequestEvent((GameServerRegionsRequest)e.Request);
					return;
				}
				if (type == typeof(GetLeaderboardRequest) && PlayFabEvents._instance.OnGetLeaderboardRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetLeaderboardRequestEvent((GetLeaderboardRequest)e.Request);
					return;
				}
				if (type == typeof(GetLeaderboardAroundCharacterRequest) && PlayFabEvents._instance.OnGetLeaderboardAroundCharacterRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetLeaderboardAroundCharacterRequestEvent((GetLeaderboardAroundCharacterRequest)e.Request);
					return;
				}
				if (type == typeof(GetLeaderboardAroundPlayerRequest) && PlayFabEvents._instance.OnGetLeaderboardAroundPlayerRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetLeaderboardAroundPlayerRequestEvent((GetLeaderboardAroundPlayerRequest)e.Request);
					return;
				}
				if (type == typeof(GetLeaderboardForUsersCharactersRequest) && PlayFabEvents._instance.OnGetLeaderboardForUserCharactersRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetLeaderboardForUserCharactersRequestEvent((GetLeaderboardForUsersCharactersRequest)e.Request);
					return;
				}
				if (type == typeof(GetPaymentTokenRequest) && PlayFabEvents._instance.OnGetPaymentTokenRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetPaymentTokenRequestEvent((GetPaymentTokenRequest)e.Request);
					return;
				}
				if (type == typeof(GetPhotonAuthenticationTokenRequest) && PlayFabEvents._instance.OnGetPhotonAuthenticationTokenRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetPhotonAuthenticationTokenRequestEvent((GetPhotonAuthenticationTokenRequest)e.Request);
					return;
				}
				if (type == typeof(GetPlayerCombinedInfoRequest) && PlayFabEvents._instance.OnGetPlayerCombinedInfoRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetPlayerCombinedInfoRequestEvent((GetPlayerCombinedInfoRequest)e.Request);
					return;
				}
				if (type == typeof(GetPlayerProfileRequest) && PlayFabEvents._instance.OnGetPlayerProfileRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetPlayerProfileRequestEvent((GetPlayerProfileRequest)e.Request);
					return;
				}
				if (type == typeof(GetPlayerSegmentsRequest) && PlayFabEvents._instance.OnGetPlayerSegmentsRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetPlayerSegmentsRequestEvent((GetPlayerSegmentsRequest)e.Request);
					return;
				}
				if (type == typeof(GetPlayerStatisticsRequest) && PlayFabEvents._instance.OnGetPlayerStatisticsRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetPlayerStatisticsRequestEvent((GetPlayerStatisticsRequest)e.Request);
					return;
				}
				if (type == typeof(GetPlayerStatisticVersionsRequest) && PlayFabEvents._instance.OnGetPlayerStatisticVersionsRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetPlayerStatisticVersionsRequestEvent((GetPlayerStatisticVersionsRequest)e.Request);
					return;
				}
				if (type == typeof(GetPlayerTagsRequest) && PlayFabEvents._instance.OnGetPlayerTagsRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetPlayerTagsRequestEvent((GetPlayerTagsRequest)e.Request);
					return;
				}
				if (type == typeof(GetPlayerTradesRequest) && PlayFabEvents._instance.OnGetPlayerTradesRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetPlayerTradesRequestEvent((GetPlayerTradesRequest)e.Request);
					return;
				}
				if (type == typeof(GetPlayFabIDsFromFacebookIDsRequest) && PlayFabEvents._instance.OnGetPlayFabIDsFromFacebookIDsRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetPlayFabIDsFromFacebookIDsRequestEvent((GetPlayFabIDsFromFacebookIDsRequest)e.Request);
					return;
				}
				if (type == typeof(GetPlayFabIDsFromGameCenterIDsRequest) && PlayFabEvents._instance.OnGetPlayFabIDsFromGameCenterIDsRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetPlayFabIDsFromGameCenterIDsRequestEvent((GetPlayFabIDsFromGameCenterIDsRequest)e.Request);
					return;
				}
				if (type == typeof(GetPlayFabIDsFromGenericIDsRequest) && PlayFabEvents._instance.OnGetPlayFabIDsFromGenericIDsRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetPlayFabIDsFromGenericIDsRequestEvent((GetPlayFabIDsFromGenericIDsRequest)e.Request);
					return;
				}
				if (type == typeof(GetPlayFabIDsFromGoogleIDsRequest) && PlayFabEvents._instance.OnGetPlayFabIDsFromGoogleIDsRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetPlayFabIDsFromGoogleIDsRequestEvent((GetPlayFabIDsFromGoogleIDsRequest)e.Request);
					return;
				}
				if (type == typeof(GetPlayFabIDsFromKongregateIDsRequest) && PlayFabEvents._instance.OnGetPlayFabIDsFromKongregateIDsRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetPlayFabIDsFromKongregateIDsRequestEvent((GetPlayFabIDsFromKongregateIDsRequest)e.Request);
					return;
				}
				if (type == typeof(GetPlayFabIDsFromSteamIDsRequest) && PlayFabEvents._instance.OnGetPlayFabIDsFromSteamIDsRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetPlayFabIDsFromSteamIDsRequestEvent((GetPlayFabIDsFromSteamIDsRequest)e.Request);
					return;
				}
				if (type == typeof(GetPlayFabIDsFromTwitchIDsRequest) && PlayFabEvents._instance.OnGetPlayFabIDsFromTwitchIDsRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetPlayFabIDsFromTwitchIDsRequestEvent((GetPlayFabIDsFromTwitchIDsRequest)e.Request);
					return;
				}
				if (type == typeof(GetPublisherDataRequest) && PlayFabEvents._instance.OnGetPublisherDataRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetPublisherDataRequestEvent((GetPublisherDataRequest)e.Request);
					return;
				}
				if (type == typeof(GetPurchaseRequest) && PlayFabEvents._instance.OnGetPurchaseRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetPurchaseRequestEvent((GetPurchaseRequest)e.Request);
					return;
				}
				if (type == typeof(GetSharedGroupDataRequest) && PlayFabEvents._instance.OnGetSharedGroupDataRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetSharedGroupDataRequestEvent((GetSharedGroupDataRequest)e.Request);
					return;
				}
				if (type == typeof(GetStoreItemsRequest) && PlayFabEvents._instance.OnGetStoreItemsRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetStoreItemsRequestEvent((GetStoreItemsRequest)e.Request);
					return;
				}
				if (type == typeof(GetTimeRequest) && PlayFabEvents._instance.OnGetTimeRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetTimeRequestEvent((GetTimeRequest)e.Request);
					return;
				}
				if (type == typeof(GetTitleDataRequest) && PlayFabEvents._instance.OnGetTitleDataRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetTitleDataRequestEvent((GetTitleDataRequest)e.Request);
					return;
				}
				if (type == typeof(GetTitleNewsRequest) && PlayFabEvents._instance.OnGetTitleNewsRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetTitleNewsRequestEvent((GetTitleNewsRequest)e.Request);
					return;
				}
				if (type == typeof(GetTitlePublicKeyRequest) && PlayFabEvents._instance.OnGetTitlePublicKeyRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetTitlePublicKeyRequestEvent((GetTitlePublicKeyRequest)e.Request);
					return;
				}
				if (type == typeof(GetTradeStatusRequest) && PlayFabEvents._instance.OnGetTradeStatusRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetTradeStatusRequestEvent((GetTradeStatusRequest)e.Request);
					return;
				}
				if (type == typeof(GetUserDataRequest) && PlayFabEvents._instance.OnGetUserDataRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetUserDataRequestEvent((GetUserDataRequest)e.Request);
					return;
				}
				if (type == typeof(GetUserInventoryRequest) && PlayFabEvents._instance.OnGetUserInventoryRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetUserInventoryRequestEvent((GetUserInventoryRequest)e.Request);
					return;
				}
				if (type == typeof(GetUserDataRequest) && PlayFabEvents._instance.OnGetUserPublisherDataRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetUserPublisherDataRequestEvent((GetUserDataRequest)e.Request);
					return;
				}
				if (type == typeof(GetUserDataRequest) && PlayFabEvents._instance.OnGetUserPublisherReadOnlyDataRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetUserPublisherReadOnlyDataRequestEvent((GetUserDataRequest)e.Request);
					return;
				}
				if (type == typeof(GetUserDataRequest) && PlayFabEvents._instance.OnGetUserReadOnlyDataRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetUserReadOnlyDataRequestEvent((GetUserDataRequest)e.Request);
					return;
				}
				if (type == typeof(GetWindowsHelloChallengeRequest) && PlayFabEvents._instance.OnGetWindowsHelloChallengeRequestEvent != null)
				{
					PlayFabEvents._instance.OnGetWindowsHelloChallengeRequestEvent((GetWindowsHelloChallengeRequest)e.Request);
					return;
				}
				if (type == typeof(GrantCharacterToUserRequest) && PlayFabEvents._instance.OnGrantCharacterToUserRequestEvent != null)
				{
					PlayFabEvents._instance.OnGrantCharacterToUserRequestEvent((GrantCharacterToUserRequest)e.Request);
					return;
				}
				if (type == typeof(LinkAndroidDeviceIDRequest) && PlayFabEvents._instance.OnLinkAndroidDeviceIDRequestEvent != null)
				{
					PlayFabEvents._instance.OnLinkAndroidDeviceIDRequestEvent((LinkAndroidDeviceIDRequest)e.Request);
					return;
				}
				if (type == typeof(LinkCustomIDRequest) && PlayFabEvents._instance.OnLinkCustomIDRequestEvent != null)
				{
					PlayFabEvents._instance.OnLinkCustomIDRequestEvent((LinkCustomIDRequest)e.Request);
					return;
				}
				if (type == typeof(LinkFacebookAccountRequest) && PlayFabEvents._instance.OnLinkFacebookAccountRequestEvent != null)
				{
					PlayFabEvents._instance.OnLinkFacebookAccountRequestEvent((LinkFacebookAccountRequest)e.Request);
					return;
				}
				if (type == typeof(LinkGameCenterAccountRequest) && PlayFabEvents._instance.OnLinkGameCenterAccountRequestEvent != null)
				{
					PlayFabEvents._instance.OnLinkGameCenterAccountRequestEvent((LinkGameCenterAccountRequest)e.Request);
					return;
				}
				if (type == typeof(LinkGoogleAccountRequest) && PlayFabEvents._instance.OnLinkGoogleAccountRequestEvent != null)
				{
					PlayFabEvents._instance.OnLinkGoogleAccountRequestEvent((LinkGoogleAccountRequest)e.Request);
					return;
				}
				if (type == typeof(LinkIOSDeviceIDRequest) && PlayFabEvents._instance.OnLinkIOSDeviceIDRequestEvent != null)
				{
					PlayFabEvents._instance.OnLinkIOSDeviceIDRequestEvent((LinkIOSDeviceIDRequest)e.Request);
					return;
				}
				if (type == typeof(LinkKongregateAccountRequest) && PlayFabEvents._instance.OnLinkKongregateRequestEvent != null)
				{
					PlayFabEvents._instance.OnLinkKongregateRequestEvent((LinkKongregateAccountRequest)e.Request);
					return;
				}
				if (type == typeof(LinkSteamAccountRequest) && PlayFabEvents._instance.OnLinkSteamAccountRequestEvent != null)
				{
					PlayFabEvents._instance.OnLinkSteamAccountRequestEvent((LinkSteamAccountRequest)e.Request);
					return;
				}
				if (type == typeof(LinkTwitchAccountRequest) && PlayFabEvents._instance.OnLinkTwitchRequestEvent != null)
				{
					PlayFabEvents._instance.OnLinkTwitchRequestEvent((LinkTwitchAccountRequest)e.Request);
					return;
				}
				if (type == typeof(LinkWindowsHelloAccountRequest) && PlayFabEvents._instance.OnLinkWindowsHelloRequestEvent != null)
				{
					PlayFabEvents._instance.OnLinkWindowsHelloRequestEvent((LinkWindowsHelloAccountRequest)e.Request);
					return;
				}
				if (type == typeof(LoginWithAndroidDeviceIDRequest) && PlayFabEvents._instance.OnLoginWithAndroidDeviceIDRequestEvent != null)
				{
					PlayFabEvents._instance.OnLoginWithAndroidDeviceIDRequestEvent((LoginWithAndroidDeviceIDRequest)e.Request);
					return;
				}
				if (type == typeof(LoginWithCustomIDRequest) && PlayFabEvents._instance.OnLoginWithCustomIDRequestEvent != null)
				{
					PlayFabEvents._instance.OnLoginWithCustomIDRequestEvent((LoginWithCustomIDRequest)e.Request);
					return;
				}
				if (type == typeof(LoginWithEmailAddressRequest) && PlayFabEvents._instance.OnLoginWithEmailAddressRequestEvent != null)
				{
					PlayFabEvents._instance.OnLoginWithEmailAddressRequestEvent((LoginWithEmailAddressRequest)e.Request);
					return;
				}
				if (type == typeof(LoginWithFacebookRequest) && PlayFabEvents._instance.OnLoginWithFacebookRequestEvent != null)
				{
					PlayFabEvents._instance.OnLoginWithFacebookRequestEvent((LoginWithFacebookRequest)e.Request);
					return;
				}
				if (type == typeof(LoginWithGameCenterRequest) && PlayFabEvents._instance.OnLoginWithGameCenterRequestEvent != null)
				{
					PlayFabEvents._instance.OnLoginWithGameCenterRequestEvent((LoginWithGameCenterRequest)e.Request);
					return;
				}
				if (type == typeof(LoginWithGoogleAccountRequest) && PlayFabEvents._instance.OnLoginWithGoogleAccountRequestEvent != null)
				{
					PlayFabEvents._instance.OnLoginWithGoogleAccountRequestEvent((LoginWithGoogleAccountRequest)e.Request);
					return;
				}
				if (type == typeof(LoginWithIOSDeviceIDRequest) && PlayFabEvents._instance.OnLoginWithIOSDeviceIDRequestEvent != null)
				{
					PlayFabEvents._instance.OnLoginWithIOSDeviceIDRequestEvent((LoginWithIOSDeviceIDRequest)e.Request);
					return;
				}
				if (type == typeof(LoginWithKongregateRequest) && PlayFabEvents._instance.OnLoginWithKongregateRequestEvent != null)
				{
					PlayFabEvents._instance.OnLoginWithKongregateRequestEvent((LoginWithKongregateRequest)e.Request);
					return;
				}
				if (type == typeof(LoginWithPlayFabRequest) && PlayFabEvents._instance.OnLoginWithPlayFabRequestEvent != null)
				{
					PlayFabEvents._instance.OnLoginWithPlayFabRequestEvent((LoginWithPlayFabRequest)e.Request);
					return;
				}
				if (type == typeof(LoginWithSteamRequest) && PlayFabEvents._instance.OnLoginWithSteamRequestEvent != null)
				{
					PlayFabEvents._instance.OnLoginWithSteamRequestEvent((LoginWithSteamRequest)e.Request);
					return;
				}
				if (type == typeof(LoginWithTwitchRequest) && PlayFabEvents._instance.OnLoginWithTwitchRequestEvent != null)
				{
					PlayFabEvents._instance.OnLoginWithTwitchRequestEvent((LoginWithTwitchRequest)e.Request);
					return;
				}
				if (type == typeof(LoginWithWindowsHelloRequest) && PlayFabEvents._instance.OnLoginWithWindowsHelloRequestEvent != null)
				{
					PlayFabEvents._instance.OnLoginWithWindowsHelloRequestEvent((LoginWithWindowsHelloRequest)e.Request);
					return;
				}
				if (type == typeof(MatchmakeRequest) && PlayFabEvents._instance.OnMatchmakeRequestEvent != null)
				{
					PlayFabEvents._instance.OnMatchmakeRequestEvent((MatchmakeRequest)e.Request);
					return;
				}
				if (type == typeof(OpenTradeRequest) && PlayFabEvents._instance.OnOpenTradeRequestEvent != null)
				{
					PlayFabEvents._instance.OnOpenTradeRequestEvent((OpenTradeRequest)e.Request);
					return;
				}
				if (type == typeof(PayForPurchaseRequest) && PlayFabEvents._instance.OnPayForPurchaseRequestEvent != null)
				{
					PlayFabEvents._instance.OnPayForPurchaseRequestEvent((PayForPurchaseRequest)e.Request);
					return;
				}
				if (type == typeof(PurchaseItemRequest) && PlayFabEvents._instance.OnPurchaseItemRequestEvent != null)
				{
					PlayFabEvents._instance.OnPurchaseItemRequestEvent((PurchaseItemRequest)e.Request);
					return;
				}
				if (type == typeof(RedeemCouponRequest) && PlayFabEvents._instance.OnRedeemCouponRequestEvent != null)
				{
					PlayFabEvents._instance.OnRedeemCouponRequestEvent((RedeemCouponRequest)e.Request);
					return;
				}
				if (type == typeof(RegisterForIOSPushNotificationRequest) && PlayFabEvents._instance.OnRegisterForIOSPushNotificationRequestEvent != null)
				{
					PlayFabEvents._instance.OnRegisterForIOSPushNotificationRequestEvent((RegisterForIOSPushNotificationRequest)e.Request);
					return;
				}
				if (type == typeof(RegisterPlayFabUserRequest) && PlayFabEvents._instance.OnRegisterPlayFabUserRequestEvent != null)
				{
					PlayFabEvents._instance.OnRegisterPlayFabUserRequestEvent((RegisterPlayFabUserRequest)e.Request);
					return;
				}
				if (type == typeof(RegisterWithWindowsHelloRequest) && PlayFabEvents._instance.OnRegisterWithWindowsHelloRequestEvent != null)
				{
					PlayFabEvents._instance.OnRegisterWithWindowsHelloRequestEvent((RegisterWithWindowsHelloRequest)e.Request);
					return;
				}
				if (type == typeof(RemoveContactEmailRequest) && PlayFabEvents._instance.OnRemoveContactEmailRequestEvent != null)
				{
					PlayFabEvents._instance.OnRemoveContactEmailRequestEvent((RemoveContactEmailRequest)e.Request);
					return;
				}
				if (type == typeof(RemoveFriendRequest) && PlayFabEvents._instance.OnRemoveFriendRequestEvent != null)
				{
					PlayFabEvents._instance.OnRemoveFriendRequestEvent((RemoveFriendRequest)e.Request);
					return;
				}
				if (type == typeof(RemoveGenericIDRequest) && PlayFabEvents._instance.OnRemoveGenericIDRequestEvent != null)
				{
					PlayFabEvents._instance.OnRemoveGenericIDRequestEvent((RemoveGenericIDRequest)e.Request);
					return;
				}
				if (type == typeof(RemoveSharedGroupMembersRequest) && PlayFabEvents._instance.OnRemoveSharedGroupMembersRequestEvent != null)
				{
					PlayFabEvents._instance.OnRemoveSharedGroupMembersRequestEvent((RemoveSharedGroupMembersRequest)e.Request);
					return;
				}
				if (type == typeof(DeviceInfoRequest) && PlayFabEvents._instance.OnReportDeviceInfoRequestEvent != null)
				{
					PlayFabEvents._instance.OnReportDeviceInfoRequestEvent((DeviceInfoRequest)e.Request);
					return;
				}
				if (type == typeof(ReportPlayerClientRequest) && PlayFabEvents._instance.OnReportPlayerRequestEvent != null)
				{
					PlayFabEvents._instance.OnReportPlayerRequestEvent((ReportPlayerClientRequest)e.Request);
					return;
				}
				if (type == typeof(RestoreIOSPurchasesRequest) && PlayFabEvents._instance.OnRestoreIOSPurchasesRequestEvent != null)
				{
					PlayFabEvents._instance.OnRestoreIOSPurchasesRequestEvent((RestoreIOSPurchasesRequest)e.Request);
					return;
				}
				if (type == typeof(SendAccountRecoveryEmailRequest) && PlayFabEvents._instance.OnSendAccountRecoveryEmailRequestEvent != null)
				{
					PlayFabEvents._instance.OnSendAccountRecoveryEmailRequestEvent((SendAccountRecoveryEmailRequest)e.Request);
					return;
				}
				if (type == typeof(SetFriendTagsRequest) && PlayFabEvents._instance.OnSetFriendTagsRequestEvent != null)
				{
					PlayFabEvents._instance.OnSetFriendTagsRequestEvent((SetFriendTagsRequest)e.Request);
					return;
				}
				if (type == typeof(SetPlayerSecretRequest) && PlayFabEvents._instance.OnSetPlayerSecretRequestEvent != null)
				{
					PlayFabEvents._instance.OnSetPlayerSecretRequestEvent((SetPlayerSecretRequest)e.Request);
					return;
				}
				if (type == typeof(StartGameRequest) && PlayFabEvents._instance.OnStartGameRequestEvent != null)
				{
					PlayFabEvents._instance.OnStartGameRequestEvent((StartGameRequest)e.Request);
					return;
				}
				if (type == typeof(StartPurchaseRequest) && PlayFabEvents._instance.OnStartPurchaseRequestEvent != null)
				{
					PlayFabEvents._instance.OnStartPurchaseRequestEvent((StartPurchaseRequest)e.Request);
					return;
				}
				if (type == typeof(SubtractUserVirtualCurrencyRequest) && PlayFabEvents._instance.OnSubtractUserVirtualCurrencyRequestEvent != null)
				{
					PlayFabEvents._instance.OnSubtractUserVirtualCurrencyRequestEvent((SubtractUserVirtualCurrencyRequest)e.Request);
					return;
				}
				if (type == typeof(UnlinkAndroidDeviceIDRequest) && PlayFabEvents._instance.OnUnlinkAndroidDeviceIDRequestEvent != null)
				{
					PlayFabEvents._instance.OnUnlinkAndroidDeviceIDRequestEvent((UnlinkAndroidDeviceIDRequest)e.Request);
					return;
				}
				if (type == typeof(UnlinkCustomIDRequest) && PlayFabEvents._instance.OnUnlinkCustomIDRequestEvent != null)
				{
					PlayFabEvents._instance.OnUnlinkCustomIDRequestEvent((UnlinkCustomIDRequest)e.Request);
					return;
				}
				if (type == typeof(UnlinkFacebookAccountRequest) && PlayFabEvents._instance.OnUnlinkFacebookAccountRequestEvent != null)
				{
					PlayFabEvents._instance.OnUnlinkFacebookAccountRequestEvent((UnlinkFacebookAccountRequest)e.Request);
					return;
				}
				if (type == typeof(UnlinkGameCenterAccountRequest) && PlayFabEvents._instance.OnUnlinkGameCenterAccountRequestEvent != null)
				{
					PlayFabEvents._instance.OnUnlinkGameCenterAccountRequestEvent((UnlinkGameCenterAccountRequest)e.Request);
					return;
				}
				if (type == typeof(UnlinkGoogleAccountRequest) && PlayFabEvents._instance.OnUnlinkGoogleAccountRequestEvent != null)
				{
					PlayFabEvents._instance.OnUnlinkGoogleAccountRequestEvent((UnlinkGoogleAccountRequest)e.Request);
					return;
				}
				if (type == typeof(UnlinkIOSDeviceIDRequest) && PlayFabEvents._instance.OnUnlinkIOSDeviceIDRequestEvent != null)
				{
					PlayFabEvents._instance.OnUnlinkIOSDeviceIDRequestEvent((UnlinkIOSDeviceIDRequest)e.Request);
					return;
				}
				if (type == typeof(UnlinkKongregateAccountRequest) && PlayFabEvents._instance.OnUnlinkKongregateRequestEvent != null)
				{
					PlayFabEvents._instance.OnUnlinkKongregateRequestEvent((UnlinkKongregateAccountRequest)e.Request);
					return;
				}
				if (type == typeof(UnlinkSteamAccountRequest) && PlayFabEvents._instance.OnUnlinkSteamAccountRequestEvent != null)
				{
					PlayFabEvents._instance.OnUnlinkSteamAccountRequestEvent((UnlinkSteamAccountRequest)e.Request);
					return;
				}
				if (type == typeof(UnlinkTwitchAccountRequest) && PlayFabEvents._instance.OnUnlinkTwitchRequestEvent != null)
				{
					PlayFabEvents._instance.OnUnlinkTwitchRequestEvent((UnlinkTwitchAccountRequest)e.Request);
					return;
				}
				if (type == typeof(UnlinkWindowsHelloAccountRequest) && PlayFabEvents._instance.OnUnlinkWindowsHelloRequestEvent != null)
				{
					PlayFabEvents._instance.OnUnlinkWindowsHelloRequestEvent((UnlinkWindowsHelloAccountRequest)e.Request);
					return;
				}
				if (type == typeof(UnlockContainerInstanceRequest) && PlayFabEvents._instance.OnUnlockContainerInstanceRequestEvent != null)
				{
					PlayFabEvents._instance.OnUnlockContainerInstanceRequestEvent((UnlockContainerInstanceRequest)e.Request);
					return;
				}
				if (type == typeof(UnlockContainerItemRequest) && PlayFabEvents._instance.OnUnlockContainerItemRequestEvent != null)
				{
					PlayFabEvents._instance.OnUnlockContainerItemRequestEvent((UnlockContainerItemRequest)e.Request);
					return;
				}
				if (type == typeof(UpdateAvatarUrlRequest) && PlayFabEvents._instance.OnUpdateAvatarUrlRequestEvent != null)
				{
					PlayFabEvents._instance.OnUpdateAvatarUrlRequestEvent((UpdateAvatarUrlRequest)e.Request);
					return;
				}
				if (type == typeof(UpdateCharacterDataRequest) && PlayFabEvents._instance.OnUpdateCharacterDataRequestEvent != null)
				{
					PlayFabEvents._instance.OnUpdateCharacterDataRequestEvent((UpdateCharacterDataRequest)e.Request);
					return;
				}
				if (type == typeof(UpdateCharacterStatisticsRequest) && PlayFabEvents._instance.OnUpdateCharacterStatisticsRequestEvent != null)
				{
					PlayFabEvents._instance.OnUpdateCharacterStatisticsRequestEvent((UpdateCharacterStatisticsRequest)e.Request);
					return;
				}
				if (type == typeof(UpdatePlayerStatisticsRequest) && PlayFabEvents._instance.OnUpdatePlayerStatisticsRequestEvent != null)
				{
					PlayFabEvents._instance.OnUpdatePlayerStatisticsRequestEvent((UpdatePlayerStatisticsRequest)e.Request);
					return;
				}
				if (type == typeof(UpdateSharedGroupDataRequest) && PlayFabEvents._instance.OnUpdateSharedGroupDataRequestEvent != null)
				{
					PlayFabEvents._instance.OnUpdateSharedGroupDataRequestEvent((UpdateSharedGroupDataRequest)e.Request);
					return;
				}
				if (type == typeof(UpdateUserDataRequest) && PlayFabEvents._instance.OnUpdateUserDataRequestEvent != null)
				{
					PlayFabEvents._instance.OnUpdateUserDataRequestEvent((UpdateUserDataRequest)e.Request);
					return;
				}
				if (type == typeof(UpdateUserDataRequest) && PlayFabEvents._instance.OnUpdateUserPublisherDataRequestEvent != null)
				{
					PlayFabEvents._instance.OnUpdateUserPublisherDataRequestEvent((UpdateUserDataRequest)e.Request);
					return;
				}
				if (type == typeof(UpdateUserTitleDisplayNameRequest) && PlayFabEvents._instance.OnUpdateUserTitleDisplayNameRequestEvent != null)
				{
					PlayFabEvents._instance.OnUpdateUserTitleDisplayNameRequestEvent((UpdateUserTitleDisplayNameRequest)e.Request);
					return;
				}
				if (type == typeof(ValidateAmazonReceiptRequest) && PlayFabEvents._instance.OnValidateAmazonIAPReceiptRequestEvent != null)
				{
					PlayFabEvents._instance.OnValidateAmazonIAPReceiptRequestEvent((ValidateAmazonReceiptRequest)e.Request);
					return;
				}
				if (type == typeof(ValidateGooglePlayPurchaseRequest) && PlayFabEvents._instance.OnValidateGooglePlayPurchaseRequestEvent != null)
				{
					PlayFabEvents._instance.OnValidateGooglePlayPurchaseRequestEvent((ValidateGooglePlayPurchaseRequest)e.Request);
					return;
				}
				if (type == typeof(ValidateIOSReceiptRequest) && PlayFabEvents._instance.OnValidateIOSReceiptRequestEvent != null)
				{
					PlayFabEvents._instance.OnValidateIOSReceiptRequestEvent((ValidateIOSReceiptRequest)e.Request);
					return;
				}
				if (type == typeof(ValidateWindowsReceiptRequest) && PlayFabEvents._instance.OnValidateWindowsStoreReceiptRequestEvent != null)
				{
					PlayFabEvents._instance.OnValidateWindowsStoreReceiptRequestEvent((ValidateWindowsReceiptRequest)e.Request);
					return;
				}
				if (type == typeof(WriteClientCharacterEventRequest) && PlayFabEvents._instance.OnWriteCharacterEventRequestEvent != null)
				{
					PlayFabEvents._instance.OnWriteCharacterEventRequestEvent((WriteClientCharacterEventRequest)e.Request);
					return;
				}
				if (type == typeof(WriteClientPlayerEventRequest) && PlayFabEvents._instance.OnWritePlayerEventRequestEvent != null)
				{
					PlayFabEvents._instance.OnWritePlayerEventRequestEvent((WriteClientPlayerEventRequest)e.Request);
					return;
				}
				if (type == typeof(WriteTitleEventRequest) && PlayFabEvents._instance.OnWriteTitleEventRequestEvent != null)
				{
					PlayFabEvents._instance.OnWriteTitleEventRequestEvent((WriteTitleEventRequest)e.Request);
					return;
				}
			}
			else
			{
				Type type2 = e.Result.GetType();
				if (type2 == typeof(LoginResult) && PlayFabEvents._instance.OnLoginResultEvent != null)
				{
					PlayFabEvents._instance.OnLoginResultEvent((LoginResult)e.Result);
					return;
				}
				if (type2 == typeof(AcceptTradeResponse) && PlayFabEvents._instance.OnAcceptTradeResultEvent != null)
				{
					PlayFabEvents._instance.OnAcceptTradeResultEvent((AcceptTradeResponse)e.Result);
					return;
				}
				if (type2 == typeof(AddFriendResult) && PlayFabEvents._instance.OnAddFriendResultEvent != null)
				{
					PlayFabEvents._instance.OnAddFriendResultEvent((AddFriendResult)e.Result);
					return;
				}
				if (type2 == typeof(AddGenericIDResult) && PlayFabEvents._instance.OnAddGenericIDResultEvent != null)
				{
					PlayFabEvents._instance.OnAddGenericIDResultEvent((AddGenericIDResult)e.Result);
					return;
				}
				if (type2 == typeof(AddOrUpdateContactEmailResult) && PlayFabEvents._instance.OnAddOrUpdateContactEmailResultEvent != null)
				{
					PlayFabEvents._instance.OnAddOrUpdateContactEmailResultEvent((AddOrUpdateContactEmailResult)e.Result);
					return;
				}
				if (type2 == typeof(AddSharedGroupMembersResult) && PlayFabEvents._instance.OnAddSharedGroupMembersResultEvent != null)
				{
					PlayFabEvents._instance.OnAddSharedGroupMembersResultEvent((AddSharedGroupMembersResult)e.Result);
					return;
				}
				if (type2 == typeof(AddUsernamePasswordResult) && PlayFabEvents._instance.OnAddUsernamePasswordResultEvent != null)
				{
					PlayFabEvents._instance.OnAddUsernamePasswordResultEvent((AddUsernamePasswordResult)e.Result);
					return;
				}
				if (type2 == typeof(ModifyUserVirtualCurrencyResult) && PlayFabEvents._instance.OnAddUserVirtualCurrencyResultEvent != null)
				{
					PlayFabEvents._instance.OnAddUserVirtualCurrencyResultEvent((ModifyUserVirtualCurrencyResult)e.Result);
					return;
				}
				if (type2 == typeof(AndroidDevicePushNotificationRegistrationResult) && PlayFabEvents._instance.OnAndroidDevicePushNotificationRegistrationResultEvent != null)
				{
					PlayFabEvents._instance.OnAndroidDevicePushNotificationRegistrationResultEvent((AndroidDevicePushNotificationRegistrationResult)e.Result);
					return;
				}
				if (type2 == typeof(AttributeInstallResult) && PlayFabEvents._instance.OnAttributeInstallResultEvent != null)
				{
					PlayFabEvents._instance.OnAttributeInstallResultEvent((AttributeInstallResult)e.Result);
					return;
				}
				if (type2 == typeof(CancelTradeResponse) && PlayFabEvents._instance.OnCancelTradeResultEvent != null)
				{
					PlayFabEvents._instance.OnCancelTradeResultEvent((CancelTradeResponse)e.Result);
					return;
				}
				if (type2 == typeof(ConfirmPurchaseResult) && PlayFabEvents._instance.OnConfirmPurchaseResultEvent != null)
				{
					PlayFabEvents._instance.OnConfirmPurchaseResultEvent((ConfirmPurchaseResult)e.Result);
					return;
				}
				if (type2 == typeof(ConsumeItemResult) && PlayFabEvents._instance.OnConsumeItemResultEvent != null)
				{
					PlayFabEvents._instance.OnConsumeItemResultEvent((ConsumeItemResult)e.Result);
					return;
				}
				if (type2 == typeof(CreateSharedGroupResult) && PlayFabEvents._instance.OnCreateSharedGroupResultEvent != null)
				{
					PlayFabEvents._instance.OnCreateSharedGroupResultEvent((CreateSharedGroupResult)e.Result);
					return;
				}
				if (type2 == typeof(ExecuteCloudScriptResult) && PlayFabEvents._instance.OnExecuteCloudScriptResultEvent != null)
				{
					PlayFabEvents._instance.OnExecuteCloudScriptResultEvent((ExecuteCloudScriptResult)e.Result);
					return;
				}
				if (type2 == typeof(GetAccountInfoResult) && PlayFabEvents._instance.OnGetAccountInfoResultEvent != null)
				{
					PlayFabEvents._instance.OnGetAccountInfoResultEvent((GetAccountInfoResult)e.Result);
					return;
				}
				if (type2 == typeof(ListUsersCharactersResult) && PlayFabEvents._instance.OnGetAllUsersCharactersResultEvent != null)
				{
					PlayFabEvents._instance.OnGetAllUsersCharactersResultEvent((ListUsersCharactersResult)e.Result);
					return;
				}
				if (type2 == typeof(GetCatalogItemsResult) && PlayFabEvents._instance.OnGetCatalogItemsResultEvent != null)
				{
					PlayFabEvents._instance.OnGetCatalogItemsResultEvent((GetCatalogItemsResult)e.Result);
					return;
				}
				if (type2 == typeof(GetCharacterDataResult) && PlayFabEvents._instance.OnGetCharacterDataResultEvent != null)
				{
					PlayFabEvents._instance.OnGetCharacterDataResultEvent((GetCharacterDataResult)e.Result);
					return;
				}
				if (type2 == typeof(GetCharacterInventoryResult) && PlayFabEvents._instance.OnGetCharacterInventoryResultEvent != null)
				{
					PlayFabEvents._instance.OnGetCharacterInventoryResultEvent((GetCharacterInventoryResult)e.Result);
					return;
				}
				if (type2 == typeof(GetCharacterLeaderboardResult) && PlayFabEvents._instance.OnGetCharacterLeaderboardResultEvent != null)
				{
					PlayFabEvents._instance.OnGetCharacterLeaderboardResultEvent((GetCharacterLeaderboardResult)e.Result);
					return;
				}
				if (type2 == typeof(GetCharacterDataResult) && PlayFabEvents._instance.OnGetCharacterReadOnlyDataResultEvent != null)
				{
					PlayFabEvents._instance.OnGetCharacterReadOnlyDataResultEvent((GetCharacterDataResult)e.Result);
					return;
				}
				if (type2 == typeof(GetCharacterStatisticsResult) && PlayFabEvents._instance.OnGetCharacterStatisticsResultEvent != null)
				{
					PlayFabEvents._instance.OnGetCharacterStatisticsResultEvent((GetCharacterStatisticsResult)e.Result);
					return;
				}
				if (type2 == typeof(GetContentDownloadUrlResult) && PlayFabEvents._instance.OnGetContentDownloadUrlResultEvent != null)
				{
					PlayFabEvents._instance.OnGetContentDownloadUrlResultEvent((GetContentDownloadUrlResult)e.Result);
					return;
				}
				if (type2 == typeof(CurrentGamesResult) && PlayFabEvents._instance.OnGetCurrentGamesResultEvent != null)
				{
					PlayFabEvents._instance.OnGetCurrentGamesResultEvent((CurrentGamesResult)e.Result);
					return;
				}
				if (type2 == typeof(GetLeaderboardResult) && PlayFabEvents._instance.OnGetFriendLeaderboardResultEvent != null)
				{
					PlayFabEvents._instance.OnGetFriendLeaderboardResultEvent((GetLeaderboardResult)e.Result);
					return;
				}
				if (type2 == typeof(GetFriendLeaderboardAroundPlayerResult) && PlayFabEvents._instance.OnGetFriendLeaderboardAroundPlayerResultEvent != null)
				{
					PlayFabEvents._instance.OnGetFriendLeaderboardAroundPlayerResultEvent((GetFriendLeaderboardAroundPlayerResult)e.Result);
					return;
				}
				if (type2 == typeof(GetFriendsListResult) && PlayFabEvents._instance.OnGetFriendsListResultEvent != null)
				{
					PlayFabEvents._instance.OnGetFriendsListResultEvent((GetFriendsListResult)e.Result);
					return;
				}
				if (type2 == typeof(GameServerRegionsResult) && PlayFabEvents._instance.OnGetGameServerRegionsResultEvent != null)
				{
					PlayFabEvents._instance.OnGetGameServerRegionsResultEvent((GameServerRegionsResult)e.Result);
					return;
				}
				if (type2 == typeof(GetLeaderboardResult) && PlayFabEvents._instance.OnGetLeaderboardResultEvent != null)
				{
					PlayFabEvents._instance.OnGetLeaderboardResultEvent((GetLeaderboardResult)e.Result);
					return;
				}
				if (type2 == typeof(GetLeaderboardAroundCharacterResult) && PlayFabEvents._instance.OnGetLeaderboardAroundCharacterResultEvent != null)
				{
					PlayFabEvents._instance.OnGetLeaderboardAroundCharacterResultEvent((GetLeaderboardAroundCharacterResult)e.Result);
					return;
				}
				if (type2 == typeof(GetLeaderboardAroundPlayerResult) && PlayFabEvents._instance.OnGetLeaderboardAroundPlayerResultEvent != null)
				{
					PlayFabEvents._instance.OnGetLeaderboardAroundPlayerResultEvent((GetLeaderboardAroundPlayerResult)e.Result);
					return;
				}
				if (type2 == typeof(GetLeaderboardForUsersCharactersResult) && PlayFabEvents._instance.OnGetLeaderboardForUserCharactersResultEvent != null)
				{
					PlayFabEvents._instance.OnGetLeaderboardForUserCharactersResultEvent((GetLeaderboardForUsersCharactersResult)e.Result);
					return;
				}
				if (type2 == typeof(GetPaymentTokenResult) && PlayFabEvents._instance.OnGetPaymentTokenResultEvent != null)
				{
					PlayFabEvents._instance.OnGetPaymentTokenResultEvent((GetPaymentTokenResult)e.Result);
					return;
				}
				if (type2 == typeof(GetPhotonAuthenticationTokenResult) && PlayFabEvents._instance.OnGetPhotonAuthenticationTokenResultEvent != null)
				{
					PlayFabEvents._instance.OnGetPhotonAuthenticationTokenResultEvent((GetPhotonAuthenticationTokenResult)e.Result);
					return;
				}
				if (type2 == typeof(GetPlayerCombinedInfoResult) && PlayFabEvents._instance.OnGetPlayerCombinedInfoResultEvent != null)
				{
					PlayFabEvents._instance.OnGetPlayerCombinedInfoResultEvent((GetPlayerCombinedInfoResult)e.Result);
					return;
				}
				if (type2 == typeof(GetPlayerProfileResult) && PlayFabEvents._instance.OnGetPlayerProfileResultEvent != null)
				{
					PlayFabEvents._instance.OnGetPlayerProfileResultEvent((GetPlayerProfileResult)e.Result);
					return;
				}
				if (type2 == typeof(GetPlayerSegmentsResult) && PlayFabEvents._instance.OnGetPlayerSegmentsResultEvent != null)
				{
					PlayFabEvents._instance.OnGetPlayerSegmentsResultEvent((GetPlayerSegmentsResult)e.Result);
					return;
				}
				if (type2 == typeof(GetPlayerStatisticsResult) && PlayFabEvents._instance.OnGetPlayerStatisticsResultEvent != null)
				{
					PlayFabEvents._instance.OnGetPlayerStatisticsResultEvent((GetPlayerStatisticsResult)e.Result);
					return;
				}
				if (type2 == typeof(GetPlayerStatisticVersionsResult) && PlayFabEvents._instance.OnGetPlayerStatisticVersionsResultEvent != null)
				{
					PlayFabEvents._instance.OnGetPlayerStatisticVersionsResultEvent((GetPlayerStatisticVersionsResult)e.Result);
					return;
				}
				if (type2 == typeof(GetPlayerTagsResult) && PlayFabEvents._instance.OnGetPlayerTagsResultEvent != null)
				{
					PlayFabEvents._instance.OnGetPlayerTagsResultEvent((GetPlayerTagsResult)e.Result);
					return;
				}
				if (type2 == typeof(GetPlayerTradesResponse) && PlayFabEvents._instance.OnGetPlayerTradesResultEvent != null)
				{
					PlayFabEvents._instance.OnGetPlayerTradesResultEvent((GetPlayerTradesResponse)e.Result);
					return;
				}
				if (type2 == typeof(GetPlayFabIDsFromFacebookIDsResult) && PlayFabEvents._instance.OnGetPlayFabIDsFromFacebookIDsResultEvent != null)
				{
					PlayFabEvents._instance.OnGetPlayFabIDsFromFacebookIDsResultEvent((GetPlayFabIDsFromFacebookIDsResult)e.Result);
					return;
				}
				if (type2 == typeof(GetPlayFabIDsFromGameCenterIDsResult) && PlayFabEvents._instance.OnGetPlayFabIDsFromGameCenterIDsResultEvent != null)
				{
					PlayFabEvents._instance.OnGetPlayFabIDsFromGameCenterIDsResultEvent((GetPlayFabIDsFromGameCenterIDsResult)e.Result);
					return;
				}
				if (type2 == typeof(GetPlayFabIDsFromGenericIDsResult) && PlayFabEvents._instance.OnGetPlayFabIDsFromGenericIDsResultEvent != null)
				{
					PlayFabEvents._instance.OnGetPlayFabIDsFromGenericIDsResultEvent((GetPlayFabIDsFromGenericIDsResult)e.Result);
					return;
				}
				if (type2 == typeof(GetPlayFabIDsFromGoogleIDsResult) && PlayFabEvents._instance.OnGetPlayFabIDsFromGoogleIDsResultEvent != null)
				{
					PlayFabEvents._instance.OnGetPlayFabIDsFromGoogleIDsResultEvent((GetPlayFabIDsFromGoogleIDsResult)e.Result);
					return;
				}
				if (type2 == typeof(GetPlayFabIDsFromKongregateIDsResult) && PlayFabEvents._instance.OnGetPlayFabIDsFromKongregateIDsResultEvent != null)
				{
					PlayFabEvents._instance.OnGetPlayFabIDsFromKongregateIDsResultEvent((GetPlayFabIDsFromKongregateIDsResult)e.Result);
					return;
				}
				if (type2 == typeof(GetPlayFabIDsFromSteamIDsResult) && PlayFabEvents._instance.OnGetPlayFabIDsFromSteamIDsResultEvent != null)
				{
					PlayFabEvents._instance.OnGetPlayFabIDsFromSteamIDsResultEvent((GetPlayFabIDsFromSteamIDsResult)e.Result);
					return;
				}
				if (type2 == typeof(GetPlayFabIDsFromTwitchIDsResult) && PlayFabEvents._instance.OnGetPlayFabIDsFromTwitchIDsResultEvent != null)
				{
					PlayFabEvents._instance.OnGetPlayFabIDsFromTwitchIDsResultEvent((GetPlayFabIDsFromTwitchIDsResult)e.Result);
					return;
				}
				if (type2 == typeof(GetPublisherDataResult) && PlayFabEvents._instance.OnGetPublisherDataResultEvent != null)
				{
					PlayFabEvents._instance.OnGetPublisherDataResultEvent((GetPublisherDataResult)e.Result);
					return;
				}
				if (type2 == typeof(GetPurchaseResult) && PlayFabEvents._instance.OnGetPurchaseResultEvent != null)
				{
					PlayFabEvents._instance.OnGetPurchaseResultEvent((GetPurchaseResult)e.Result);
					return;
				}
				if (type2 == typeof(GetSharedGroupDataResult) && PlayFabEvents._instance.OnGetSharedGroupDataResultEvent != null)
				{
					PlayFabEvents._instance.OnGetSharedGroupDataResultEvent((GetSharedGroupDataResult)e.Result);
					return;
				}
				if (type2 == typeof(GetStoreItemsResult) && PlayFabEvents._instance.OnGetStoreItemsResultEvent != null)
				{
					PlayFabEvents._instance.OnGetStoreItemsResultEvent((GetStoreItemsResult)e.Result);
					return;
				}
				if (type2 == typeof(GetTimeResult) && PlayFabEvents._instance.OnGetTimeResultEvent != null)
				{
					PlayFabEvents._instance.OnGetTimeResultEvent((GetTimeResult)e.Result);
					return;
				}
				if (type2 == typeof(GetTitleDataResult) && PlayFabEvents._instance.OnGetTitleDataResultEvent != null)
				{
					PlayFabEvents._instance.OnGetTitleDataResultEvent((GetTitleDataResult)e.Result);
					return;
				}
				if (type2 == typeof(GetTitleNewsResult) && PlayFabEvents._instance.OnGetTitleNewsResultEvent != null)
				{
					PlayFabEvents._instance.OnGetTitleNewsResultEvent((GetTitleNewsResult)e.Result);
					return;
				}
				if (type2 == typeof(GetTitlePublicKeyResult) && PlayFabEvents._instance.OnGetTitlePublicKeyResultEvent != null)
				{
					PlayFabEvents._instance.OnGetTitlePublicKeyResultEvent((GetTitlePublicKeyResult)e.Result);
					return;
				}
				if (type2 == typeof(GetTradeStatusResponse) && PlayFabEvents._instance.OnGetTradeStatusResultEvent != null)
				{
					PlayFabEvents._instance.OnGetTradeStatusResultEvent((GetTradeStatusResponse)e.Result);
					return;
				}
				if (type2 == typeof(GetUserDataResult) && PlayFabEvents._instance.OnGetUserDataResultEvent != null)
				{
					PlayFabEvents._instance.OnGetUserDataResultEvent((GetUserDataResult)e.Result);
					return;
				}
				if (type2 == typeof(GetUserInventoryResult) && PlayFabEvents._instance.OnGetUserInventoryResultEvent != null)
				{
					PlayFabEvents._instance.OnGetUserInventoryResultEvent((GetUserInventoryResult)e.Result);
					return;
				}
				if (type2 == typeof(GetUserDataResult) && PlayFabEvents._instance.OnGetUserPublisherDataResultEvent != null)
				{
					PlayFabEvents._instance.OnGetUserPublisherDataResultEvent((GetUserDataResult)e.Result);
					return;
				}
				if (type2 == typeof(GetUserDataResult) && PlayFabEvents._instance.OnGetUserPublisherReadOnlyDataResultEvent != null)
				{
					PlayFabEvents._instance.OnGetUserPublisherReadOnlyDataResultEvent((GetUserDataResult)e.Result);
					return;
				}
				if (type2 == typeof(GetUserDataResult) && PlayFabEvents._instance.OnGetUserReadOnlyDataResultEvent != null)
				{
					PlayFabEvents._instance.OnGetUserReadOnlyDataResultEvent((GetUserDataResult)e.Result);
					return;
				}
				if (type2 == typeof(GetWindowsHelloChallengeResponse) && PlayFabEvents._instance.OnGetWindowsHelloChallengeResultEvent != null)
				{
					PlayFabEvents._instance.OnGetWindowsHelloChallengeResultEvent((GetWindowsHelloChallengeResponse)e.Result);
					return;
				}
				if (type2 == typeof(GrantCharacterToUserResult) && PlayFabEvents._instance.OnGrantCharacterToUserResultEvent != null)
				{
					PlayFabEvents._instance.OnGrantCharacterToUserResultEvent((GrantCharacterToUserResult)e.Result);
					return;
				}
				if (type2 == typeof(LinkAndroidDeviceIDResult) && PlayFabEvents._instance.OnLinkAndroidDeviceIDResultEvent != null)
				{
					PlayFabEvents._instance.OnLinkAndroidDeviceIDResultEvent((LinkAndroidDeviceIDResult)e.Result);
					return;
				}
				if (type2 == typeof(LinkCustomIDResult) && PlayFabEvents._instance.OnLinkCustomIDResultEvent != null)
				{
					PlayFabEvents._instance.OnLinkCustomIDResultEvent((LinkCustomIDResult)e.Result);
					return;
				}
				if (type2 == typeof(LinkFacebookAccountResult) && PlayFabEvents._instance.OnLinkFacebookAccountResultEvent != null)
				{
					PlayFabEvents._instance.OnLinkFacebookAccountResultEvent((LinkFacebookAccountResult)e.Result);
					return;
				}
				if (type2 == typeof(LinkGameCenterAccountResult) && PlayFabEvents._instance.OnLinkGameCenterAccountResultEvent != null)
				{
					PlayFabEvents._instance.OnLinkGameCenterAccountResultEvent((LinkGameCenterAccountResult)e.Result);
					return;
				}
				if (type2 == typeof(LinkGoogleAccountResult) && PlayFabEvents._instance.OnLinkGoogleAccountResultEvent != null)
				{
					PlayFabEvents._instance.OnLinkGoogleAccountResultEvent((LinkGoogleAccountResult)e.Result);
					return;
				}
				if (type2 == typeof(LinkIOSDeviceIDResult) && PlayFabEvents._instance.OnLinkIOSDeviceIDResultEvent != null)
				{
					PlayFabEvents._instance.OnLinkIOSDeviceIDResultEvent((LinkIOSDeviceIDResult)e.Result);
					return;
				}
				if (type2 == typeof(LinkKongregateAccountResult) && PlayFabEvents._instance.OnLinkKongregateResultEvent != null)
				{
					PlayFabEvents._instance.OnLinkKongregateResultEvent((LinkKongregateAccountResult)e.Result);
					return;
				}
				if (type2 == typeof(LinkSteamAccountResult) && PlayFabEvents._instance.OnLinkSteamAccountResultEvent != null)
				{
					PlayFabEvents._instance.OnLinkSteamAccountResultEvent((LinkSteamAccountResult)e.Result);
					return;
				}
				if (type2 == typeof(LinkTwitchAccountResult) && PlayFabEvents._instance.OnLinkTwitchResultEvent != null)
				{
					PlayFabEvents._instance.OnLinkTwitchResultEvent((LinkTwitchAccountResult)e.Result);
					return;
				}
				if (type2 == typeof(LinkWindowsHelloAccountResponse) && PlayFabEvents._instance.OnLinkWindowsHelloResultEvent != null)
				{
					PlayFabEvents._instance.OnLinkWindowsHelloResultEvent((LinkWindowsHelloAccountResponse)e.Result);
					return;
				}
				if (type2 == typeof(MatchmakeResult) && PlayFabEvents._instance.OnMatchmakeResultEvent != null)
				{
					PlayFabEvents._instance.OnMatchmakeResultEvent((MatchmakeResult)e.Result);
					return;
				}
				if (type2 == typeof(OpenTradeResponse) && PlayFabEvents._instance.OnOpenTradeResultEvent != null)
				{
					PlayFabEvents._instance.OnOpenTradeResultEvent((OpenTradeResponse)e.Result);
					return;
				}
				if (type2 == typeof(PayForPurchaseResult) && PlayFabEvents._instance.OnPayForPurchaseResultEvent != null)
				{
					PlayFabEvents._instance.OnPayForPurchaseResultEvent((PayForPurchaseResult)e.Result);
					return;
				}
				if (type2 == typeof(PurchaseItemResult) && PlayFabEvents._instance.OnPurchaseItemResultEvent != null)
				{
					PlayFabEvents._instance.OnPurchaseItemResultEvent((PurchaseItemResult)e.Result);
					return;
				}
				if (type2 == typeof(RedeemCouponResult) && PlayFabEvents._instance.OnRedeemCouponResultEvent != null)
				{
					PlayFabEvents._instance.OnRedeemCouponResultEvent((RedeemCouponResult)e.Result);
					return;
				}
				if (type2 == typeof(RegisterForIOSPushNotificationResult) && PlayFabEvents._instance.OnRegisterForIOSPushNotificationResultEvent != null)
				{
					PlayFabEvents._instance.OnRegisterForIOSPushNotificationResultEvent((RegisterForIOSPushNotificationResult)e.Result);
					return;
				}
				if (type2 == typeof(RegisterPlayFabUserResult) && PlayFabEvents._instance.OnRegisterPlayFabUserResultEvent != null)
				{
					PlayFabEvents._instance.OnRegisterPlayFabUserResultEvent((RegisterPlayFabUserResult)e.Result);
					return;
				}
				if (type2 == typeof(RemoveContactEmailResult) && PlayFabEvents._instance.OnRemoveContactEmailResultEvent != null)
				{
					PlayFabEvents._instance.OnRemoveContactEmailResultEvent((RemoveContactEmailResult)e.Result);
					return;
				}
				if (type2 == typeof(RemoveFriendResult) && PlayFabEvents._instance.OnRemoveFriendResultEvent != null)
				{
					PlayFabEvents._instance.OnRemoveFriendResultEvent((RemoveFriendResult)e.Result);
					return;
				}
				if (type2 == typeof(RemoveGenericIDResult) && PlayFabEvents._instance.OnRemoveGenericIDResultEvent != null)
				{
					PlayFabEvents._instance.OnRemoveGenericIDResultEvent((RemoveGenericIDResult)e.Result);
					return;
				}
				if (type2 == typeof(RemoveSharedGroupMembersResult) && PlayFabEvents._instance.OnRemoveSharedGroupMembersResultEvent != null)
				{
					PlayFabEvents._instance.OnRemoveSharedGroupMembersResultEvent((RemoveSharedGroupMembersResult)e.Result);
					return;
				}
				if (type2 == typeof(EmptyResult) && PlayFabEvents._instance.OnReportDeviceInfoResultEvent != null)
				{
					PlayFabEvents._instance.OnReportDeviceInfoResultEvent((EmptyResult)e.Result);
					return;
				}
				if (type2 == typeof(ReportPlayerClientResult) && PlayFabEvents._instance.OnReportPlayerResultEvent != null)
				{
					PlayFabEvents._instance.OnReportPlayerResultEvent((ReportPlayerClientResult)e.Result);
					return;
				}
				if (type2 == typeof(RestoreIOSPurchasesResult) && PlayFabEvents._instance.OnRestoreIOSPurchasesResultEvent != null)
				{
					PlayFabEvents._instance.OnRestoreIOSPurchasesResultEvent((RestoreIOSPurchasesResult)e.Result);
					return;
				}
				if (type2 == typeof(SendAccountRecoveryEmailResult) && PlayFabEvents._instance.OnSendAccountRecoveryEmailResultEvent != null)
				{
					PlayFabEvents._instance.OnSendAccountRecoveryEmailResultEvent((SendAccountRecoveryEmailResult)e.Result);
					return;
				}
				if (type2 == typeof(SetFriendTagsResult) && PlayFabEvents._instance.OnSetFriendTagsResultEvent != null)
				{
					PlayFabEvents._instance.OnSetFriendTagsResultEvent((SetFriendTagsResult)e.Result);
					return;
				}
				if (type2 == typeof(SetPlayerSecretResult) && PlayFabEvents._instance.OnSetPlayerSecretResultEvent != null)
				{
					PlayFabEvents._instance.OnSetPlayerSecretResultEvent((SetPlayerSecretResult)e.Result);
					return;
				}
				if (type2 == typeof(StartGameResult) && PlayFabEvents._instance.OnStartGameResultEvent != null)
				{
					PlayFabEvents._instance.OnStartGameResultEvent((StartGameResult)e.Result);
					return;
				}
				if (type2 == typeof(StartPurchaseResult) && PlayFabEvents._instance.OnStartPurchaseResultEvent != null)
				{
					PlayFabEvents._instance.OnStartPurchaseResultEvent((StartPurchaseResult)e.Result);
					return;
				}
				if (type2 == typeof(ModifyUserVirtualCurrencyResult) && PlayFabEvents._instance.OnSubtractUserVirtualCurrencyResultEvent != null)
				{
					PlayFabEvents._instance.OnSubtractUserVirtualCurrencyResultEvent((ModifyUserVirtualCurrencyResult)e.Result);
					return;
				}
				if (type2 == typeof(UnlinkAndroidDeviceIDResult) && PlayFabEvents._instance.OnUnlinkAndroidDeviceIDResultEvent != null)
				{
					PlayFabEvents._instance.OnUnlinkAndroidDeviceIDResultEvent((UnlinkAndroidDeviceIDResult)e.Result);
					return;
				}
				if (type2 == typeof(UnlinkCustomIDResult) && PlayFabEvents._instance.OnUnlinkCustomIDResultEvent != null)
				{
					PlayFabEvents._instance.OnUnlinkCustomIDResultEvent((UnlinkCustomIDResult)e.Result);
					return;
				}
				if (type2 == typeof(UnlinkFacebookAccountResult) && PlayFabEvents._instance.OnUnlinkFacebookAccountResultEvent != null)
				{
					PlayFabEvents._instance.OnUnlinkFacebookAccountResultEvent((UnlinkFacebookAccountResult)e.Result);
					return;
				}
				if (type2 == typeof(UnlinkGameCenterAccountResult) && PlayFabEvents._instance.OnUnlinkGameCenterAccountResultEvent != null)
				{
					PlayFabEvents._instance.OnUnlinkGameCenterAccountResultEvent((UnlinkGameCenterAccountResult)e.Result);
					return;
				}
				if (type2 == typeof(UnlinkGoogleAccountResult) && PlayFabEvents._instance.OnUnlinkGoogleAccountResultEvent != null)
				{
					PlayFabEvents._instance.OnUnlinkGoogleAccountResultEvent((UnlinkGoogleAccountResult)e.Result);
					return;
				}
				if (type2 == typeof(UnlinkIOSDeviceIDResult) && PlayFabEvents._instance.OnUnlinkIOSDeviceIDResultEvent != null)
				{
					PlayFabEvents._instance.OnUnlinkIOSDeviceIDResultEvent((UnlinkIOSDeviceIDResult)e.Result);
					return;
				}
				if (type2 == typeof(UnlinkKongregateAccountResult) && PlayFabEvents._instance.OnUnlinkKongregateResultEvent != null)
				{
					PlayFabEvents._instance.OnUnlinkKongregateResultEvent((UnlinkKongregateAccountResult)e.Result);
					return;
				}
				if (type2 == typeof(UnlinkSteamAccountResult) && PlayFabEvents._instance.OnUnlinkSteamAccountResultEvent != null)
				{
					PlayFabEvents._instance.OnUnlinkSteamAccountResultEvent((UnlinkSteamAccountResult)e.Result);
					return;
				}
				if (type2 == typeof(UnlinkTwitchAccountResult) && PlayFabEvents._instance.OnUnlinkTwitchResultEvent != null)
				{
					PlayFabEvents._instance.OnUnlinkTwitchResultEvent((UnlinkTwitchAccountResult)e.Result);
					return;
				}
				if (type2 == typeof(UnlinkWindowsHelloAccountResponse) && PlayFabEvents._instance.OnUnlinkWindowsHelloResultEvent != null)
				{
					PlayFabEvents._instance.OnUnlinkWindowsHelloResultEvent((UnlinkWindowsHelloAccountResponse)e.Result);
					return;
				}
				if (type2 == typeof(UnlockContainerItemResult) && PlayFabEvents._instance.OnUnlockContainerInstanceResultEvent != null)
				{
					PlayFabEvents._instance.OnUnlockContainerInstanceResultEvent((UnlockContainerItemResult)e.Result);
					return;
				}
				if (type2 == typeof(UnlockContainerItemResult) && PlayFabEvents._instance.OnUnlockContainerItemResultEvent != null)
				{
					PlayFabEvents._instance.OnUnlockContainerItemResultEvent((UnlockContainerItemResult)e.Result);
					return;
				}
				if (type2 == typeof(EmptyResult) && PlayFabEvents._instance.OnUpdateAvatarUrlResultEvent != null)
				{
					PlayFabEvents._instance.OnUpdateAvatarUrlResultEvent((EmptyResult)e.Result);
					return;
				}
				if (type2 == typeof(UpdateCharacterDataResult) && PlayFabEvents._instance.OnUpdateCharacterDataResultEvent != null)
				{
					PlayFabEvents._instance.OnUpdateCharacterDataResultEvent((UpdateCharacterDataResult)e.Result);
					return;
				}
				if (type2 == typeof(UpdateCharacterStatisticsResult) && PlayFabEvents._instance.OnUpdateCharacterStatisticsResultEvent != null)
				{
					PlayFabEvents._instance.OnUpdateCharacterStatisticsResultEvent((UpdateCharacterStatisticsResult)e.Result);
					return;
				}
				if (type2 == typeof(UpdatePlayerStatisticsResult) && PlayFabEvents._instance.OnUpdatePlayerStatisticsResultEvent != null)
				{
					PlayFabEvents._instance.OnUpdatePlayerStatisticsResultEvent((UpdatePlayerStatisticsResult)e.Result);
					return;
				}
				if (type2 == typeof(UpdateSharedGroupDataResult) && PlayFabEvents._instance.OnUpdateSharedGroupDataResultEvent != null)
				{
					PlayFabEvents._instance.OnUpdateSharedGroupDataResultEvent((UpdateSharedGroupDataResult)e.Result);
					return;
				}
				if (type2 == typeof(UpdateUserDataResult) && PlayFabEvents._instance.OnUpdateUserDataResultEvent != null)
				{
					PlayFabEvents._instance.OnUpdateUserDataResultEvent((UpdateUserDataResult)e.Result);
					return;
				}
				if (type2 == typeof(UpdateUserDataResult) && PlayFabEvents._instance.OnUpdateUserPublisherDataResultEvent != null)
				{
					PlayFabEvents._instance.OnUpdateUserPublisherDataResultEvent((UpdateUserDataResult)e.Result);
					return;
				}
				if (type2 == typeof(UpdateUserTitleDisplayNameResult) && PlayFabEvents._instance.OnUpdateUserTitleDisplayNameResultEvent != null)
				{
					PlayFabEvents._instance.OnUpdateUserTitleDisplayNameResultEvent((UpdateUserTitleDisplayNameResult)e.Result);
					return;
				}
				if (type2 == typeof(ValidateAmazonReceiptResult) && PlayFabEvents._instance.OnValidateAmazonIAPReceiptResultEvent != null)
				{
					PlayFabEvents._instance.OnValidateAmazonIAPReceiptResultEvent((ValidateAmazonReceiptResult)e.Result);
					return;
				}
				if (type2 == typeof(ValidateGooglePlayPurchaseResult) && PlayFabEvents._instance.OnValidateGooglePlayPurchaseResultEvent != null)
				{
					PlayFabEvents._instance.OnValidateGooglePlayPurchaseResultEvent((ValidateGooglePlayPurchaseResult)e.Result);
					return;
				}
				if (type2 == typeof(ValidateIOSReceiptResult) && PlayFabEvents._instance.OnValidateIOSReceiptResultEvent != null)
				{
					PlayFabEvents._instance.OnValidateIOSReceiptResultEvent((ValidateIOSReceiptResult)e.Result);
					return;
				}
				if (type2 == typeof(ValidateWindowsReceiptResult) && PlayFabEvents._instance.OnValidateWindowsStoreReceiptResultEvent != null)
				{
					PlayFabEvents._instance.OnValidateWindowsStoreReceiptResultEvent((ValidateWindowsReceiptResult)e.Result);
					return;
				}
				if (type2 == typeof(WriteEventResponse) && PlayFabEvents._instance.OnWriteCharacterEventResultEvent != null)
				{
					PlayFabEvents._instance.OnWriteCharacterEventResultEvent((WriteEventResponse)e.Result);
					return;
				}
				if (type2 == typeof(WriteEventResponse) && PlayFabEvents._instance.OnWritePlayerEventResultEvent != null)
				{
					PlayFabEvents._instance.OnWritePlayerEventResultEvent((WriteEventResponse)e.Result);
					return;
				}
				if (type2 == typeof(WriteEventResponse) && PlayFabEvents._instance.OnWriteTitleEventResultEvent != null)
				{
					PlayFabEvents._instance.OnWriteTitleEventResultEvent((WriteEventResponse)e.Result);
					return;
				}
			}
		}

		private static PlayFabEvents _instance;

		public delegate void PlayFabErrorEvent(PlayFabRequestCommon request, PlayFabError error);

		public delegate void PlayFabResultEvent<in TResult>(TResult result) where TResult : PlayFabResultCommon;

		public delegate void PlayFabRequestEvent<in TRequest>(TRequest request) where TRequest : PlayFabRequestCommon;
	}
}
