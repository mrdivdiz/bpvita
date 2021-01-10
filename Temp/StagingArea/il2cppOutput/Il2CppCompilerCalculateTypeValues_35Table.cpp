#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <cstring>
#include <string.h>
#include <stdio.h>
#include <cmath>
#include <limits>
#include <assert.h>
#include <stdint.h>

#include "il2cpp-class-internals.h"
#include "codegen/il2cpp-codegen.h"
#include "il2cpp-object-internals.h"


// System.String
struct String_t;
// PlayFab.ClientModels.PlayerProfileModel
struct PlayerProfileModel_t250934598;
// PlayFab.SharedModels.PlayFabRequestCommon
struct PlayFabRequestCommon_t229319069;
// System.Collections.Generic.List`1<System.String>
struct List_1_t3319525431;
// PlayFab.ClientModels.UserSettings
struct UserSettings_t3054366223;
// PlayFab.ClientModels.GenericServiceId
struct GenericServiceId_t3400130533;
// System.Collections.Generic.List`1<PlayFab.ClientModels.ItemInstance>
struct List_1_t898730215;
// PlayFab.ClientModels.TradeInfo
struct TradeInfo_t4070927481;
// System.Char[]
struct CharU5BU5D_t3528271667;
// System.Collections.Generic.List`1<PlayFab.ClientModels.CharacterResult>
struct List_1_t870886602;
// System.Collections.Generic.List`1<PlayFab.ClientModels.CartItem>
struct List_1_t2141460274;
// System.Collections.Generic.List`1<PlayFab.ClientModels.PaymentOption>
struct List_1_t2421373131;
// System.Collections.Generic.Dictionary`2<System.String,System.Int32>
struct Dictionary_2_t2736202052;
// System.Collections.Generic.List`1<PlayFab.ClientModels.ItemPurchaseRequest>
struct List_1_t3805761739;
// PlayFab.ClientModels.GetPlayerCombinedInfoRequestParams
struct GetPlayerCombinedInfoRequestParams_t121265087;
// System.String[]
struct StringU5BU5D_t1281789340;
// System.Int32[]
struct Int32U5BU5D_t385246372;
// PlayFab.ClientModels.CollectionFilter
struct CollectionFilter_t2867730642;
// System.Collections.Generic.Dictionary`2<System.String,System.String>
struct Dictionary_2_t1632706988;
// System.Collections.Generic.List`1<PlayFab.ClientModels.AdCampaignAttributionModel>
struct List_1_t406833115;
// System.Collections.Generic.List`1<PlayFab.ClientModels.ContactEmailInfoModel>
struct List_1_t1117944676;
// System.Collections.Generic.List`1<PlayFab.ClientModels.LinkedPlatformAccountModel>
struct List_1_t4191507331;
// System.Collections.Generic.List`1<PlayFab.ClientModels.LocationModel>
struct List_1_t990609382;
// System.Collections.Generic.List`1<PlayFab.ClientModels.MembershipModel>
struct List_1_t2844474068;
// System.Collections.Generic.List`1<PlayFab.ClientModels.PushNotificationRegistrationModel>
struct List_1_t2875462914;
// System.Collections.Generic.List`1<PlayFab.ClientModels.StatisticModel>
struct List_1_t2070485369;
// System.Collections.Generic.List`1<PlayFab.ClientModels.TagModel>
struct List_1_t4252289162;
// System.Collections.Generic.List`1<PlayFab.ClientModels.ValueToDateModel>
struct List_1_t1071715830;
// PlayFab.ClientModels.EntityTokenResponse
struct EntityTokenResponse_t1814794135;
// PlayFab.ClientModels.GetPlayerCombinedInfoResultPayload
struct GetPlayerCombinedInfoResultPayload_t2789378405;
// System.Collections.Generic.List`1<PlayFab.ClientModels.SubscriptionModel>
struct List_1_t2010074131;




#ifndef RUNTIMEOBJECT_H
#define RUNTIMEOBJECT_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Object

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // RUNTIMEOBJECT_H
#ifndef PAYMENTOPTION_T949298389_H
#define PAYMENTOPTION_T949298389_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.PaymentOption
struct  PaymentOption_t949298389  : public RuntimeObject
{
public:
	// System.String PlayFab.ClientModels.PaymentOption::Currency
	String_t* ___Currency_0;
	// System.UInt32 PlayFab.ClientModels.PaymentOption::Price
	uint32_t ___Price_1;
	// System.String PlayFab.ClientModels.PaymentOption::ProviderName
	String_t* ___ProviderName_2;
	// System.UInt32 PlayFab.ClientModels.PaymentOption::StoreCredit
	uint32_t ___StoreCredit_3;

public:
	inline static int32_t get_offset_of_Currency_0() { return static_cast<int32_t>(offsetof(PaymentOption_t949298389, ___Currency_0)); }
	inline String_t* get_Currency_0() const { return ___Currency_0; }
	inline String_t** get_address_of_Currency_0() { return &___Currency_0; }
	inline void set_Currency_0(String_t* value)
	{
		___Currency_0 = value;
		Il2CppCodeGenWriteBarrier((&___Currency_0), value);
	}

	inline static int32_t get_offset_of_Price_1() { return static_cast<int32_t>(offsetof(PaymentOption_t949298389, ___Price_1)); }
	inline uint32_t get_Price_1() const { return ___Price_1; }
	inline uint32_t* get_address_of_Price_1() { return &___Price_1; }
	inline void set_Price_1(uint32_t value)
	{
		___Price_1 = value;
	}

	inline static int32_t get_offset_of_ProviderName_2() { return static_cast<int32_t>(offsetof(PaymentOption_t949298389, ___ProviderName_2)); }
	inline String_t* get_ProviderName_2() const { return ___ProviderName_2; }
	inline String_t** get_address_of_ProviderName_2() { return &___ProviderName_2; }
	inline void set_ProviderName_2(String_t* value)
	{
		___ProviderName_2 = value;
		Il2CppCodeGenWriteBarrier((&___ProviderName_2), value);
	}

	inline static int32_t get_offset_of_StoreCredit_3() { return static_cast<int32_t>(offsetof(PaymentOption_t949298389, ___StoreCredit_3)); }
	inline uint32_t get_StoreCredit_3() const { return ___StoreCredit_3; }
	inline uint32_t* get_address_of_StoreCredit_3() { return &___StoreCredit_3; }
	inline void set_StoreCredit_3(uint32_t value)
	{
		___StoreCredit_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // PAYMENTOPTION_T949298389_H
#ifndef NAMEIDENTIFIER_T1683639553_H
#define NAMEIDENTIFIER_T1683639553_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.NameIdentifier
struct  NameIdentifier_t1683639553  : public RuntimeObject
{
public:
	// System.String PlayFab.ClientModels.NameIdentifier::Id
	String_t* ___Id_0;
	// System.String PlayFab.ClientModels.NameIdentifier::Name
	String_t* ___Name_1;

public:
	inline static int32_t get_offset_of_Id_0() { return static_cast<int32_t>(offsetof(NameIdentifier_t1683639553, ___Id_0)); }
	inline String_t* get_Id_0() const { return ___Id_0; }
	inline String_t** get_address_of_Id_0() { return &___Id_0; }
	inline void set_Id_0(String_t* value)
	{
		___Id_0 = value;
		Il2CppCodeGenWriteBarrier((&___Id_0), value);
	}

	inline static int32_t get_offset_of_Name_1() { return static_cast<int32_t>(offsetof(NameIdentifier_t1683639553, ___Name_1)); }
	inline String_t* get_Name_1() const { return ___Name_1; }
	inline String_t** get_address_of_Name_1() { return &___Name_1; }
	inline void set_Name_1(String_t* value)
	{
		___Name_1 = value;
		Il2CppCodeGenWriteBarrier((&___Name_1), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // NAMEIDENTIFIER_T1683639553_H
#ifndef VALUETYPE_T3640485471_H
#define VALUETYPE_T3640485471_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.ValueType
struct  ValueType_t3640485471  : public RuntimeObject
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of System.ValueType
struct ValueType_t3640485471_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.ValueType
struct ValueType_t3640485471_marshaled_com
{
};
#endif // VALUETYPE_T3640485471_H
#ifndef PLAYERPROFILEVIEWCONSTRAINTS_T97717017_H
#define PLAYERPROFILEVIEWCONSTRAINTS_T97717017_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.PlayerProfileViewConstraints
struct  PlayerProfileViewConstraints_t97717017  : public RuntimeObject
{
public:
	// System.Boolean PlayFab.ClientModels.PlayerProfileViewConstraints::ShowAvatarUrl
	bool ___ShowAvatarUrl_0;
	// System.Boolean PlayFab.ClientModels.PlayerProfileViewConstraints::ShowBannedUntil
	bool ___ShowBannedUntil_1;
	// System.Boolean PlayFab.ClientModels.PlayerProfileViewConstraints::ShowCampaignAttributions
	bool ___ShowCampaignAttributions_2;
	// System.Boolean PlayFab.ClientModels.PlayerProfileViewConstraints::ShowContactEmailAddresses
	bool ___ShowContactEmailAddresses_3;
	// System.Boolean PlayFab.ClientModels.PlayerProfileViewConstraints::ShowCreated
	bool ___ShowCreated_4;
	// System.Boolean PlayFab.ClientModels.PlayerProfileViewConstraints::ShowDisplayName
	bool ___ShowDisplayName_5;
	// System.Boolean PlayFab.ClientModels.PlayerProfileViewConstraints::ShowLastLogin
	bool ___ShowLastLogin_6;
	// System.Boolean PlayFab.ClientModels.PlayerProfileViewConstraints::ShowLinkedAccounts
	bool ___ShowLinkedAccounts_7;
	// System.Boolean PlayFab.ClientModels.PlayerProfileViewConstraints::ShowLocations
	bool ___ShowLocations_8;
	// System.Boolean PlayFab.ClientModels.PlayerProfileViewConstraints::ShowMemberships
	bool ___ShowMemberships_9;
	// System.Boolean PlayFab.ClientModels.PlayerProfileViewConstraints::ShowOrigination
	bool ___ShowOrigination_10;
	// System.Boolean PlayFab.ClientModels.PlayerProfileViewConstraints::ShowPushNotificationRegistrations
	bool ___ShowPushNotificationRegistrations_11;
	// System.Boolean PlayFab.ClientModels.PlayerProfileViewConstraints::ShowStatistics
	bool ___ShowStatistics_12;
	// System.Boolean PlayFab.ClientModels.PlayerProfileViewConstraints::ShowTags
	bool ___ShowTags_13;
	// System.Boolean PlayFab.ClientModels.PlayerProfileViewConstraints::ShowTotalValueToDateInUsd
	bool ___ShowTotalValueToDateInUsd_14;
	// System.Boolean PlayFab.ClientModels.PlayerProfileViewConstraints::ShowValuesToDate
	bool ___ShowValuesToDate_15;

public:
	inline static int32_t get_offset_of_ShowAvatarUrl_0() { return static_cast<int32_t>(offsetof(PlayerProfileViewConstraints_t97717017, ___ShowAvatarUrl_0)); }
	inline bool get_ShowAvatarUrl_0() const { return ___ShowAvatarUrl_0; }
	inline bool* get_address_of_ShowAvatarUrl_0() { return &___ShowAvatarUrl_0; }
	inline void set_ShowAvatarUrl_0(bool value)
	{
		___ShowAvatarUrl_0 = value;
	}

	inline static int32_t get_offset_of_ShowBannedUntil_1() { return static_cast<int32_t>(offsetof(PlayerProfileViewConstraints_t97717017, ___ShowBannedUntil_1)); }
	inline bool get_ShowBannedUntil_1() const { return ___ShowBannedUntil_1; }
	inline bool* get_address_of_ShowBannedUntil_1() { return &___ShowBannedUntil_1; }
	inline void set_ShowBannedUntil_1(bool value)
	{
		___ShowBannedUntil_1 = value;
	}

	inline static int32_t get_offset_of_ShowCampaignAttributions_2() { return static_cast<int32_t>(offsetof(PlayerProfileViewConstraints_t97717017, ___ShowCampaignAttributions_2)); }
	inline bool get_ShowCampaignAttributions_2() const { return ___ShowCampaignAttributions_2; }
	inline bool* get_address_of_ShowCampaignAttributions_2() { return &___ShowCampaignAttributions_2; }
	inline void set_ShowCampaignAttributions_2(bool value)
	{
		___ShowCampaignAttributions_2 = value;
	}

	inline static int32_t get_offset_of_ShowContactEmailAddresses_3() { return static_cast<int32_t>(offsetof(PlayerProfileViewConstraints_t97717017, ___ShowContactEmailAddresses_3)); }
	inline bool get_ShowContactEmailAddresses_3() const { return ___ShowContactEmailAddresses_3; }
	inline bool* get_address_of_ShowContactEmailAddresses_3() { return &___ShowContactEmailAddresses_3; }
	inline void set_ShowContactEmailAddresses_3(bool value)
	{
		___ShowContactEmailAddresses_3 = value;
	}

	inline static int32_t get_offset_of_ShowCreated_4() { return static_cast<int32_t>(offsetof(PlayerProfileViewConstraints_t97717017, ___ShowCreated_4)); }
	inline bool get_ShowCreated_4() const { return ___ShowCreated_4; }
	inline bool* get_address_of_ShowCreated_4() { return &___ShowCreated_4; }
	inline void set_ShowCreated_4(bool value)
	{
		___ShowCreated_4 = value;
	}

	inline static int32_t get_offset_of_ShowDisplayName_5() { return static_cast<int32_t>(offsetof(PlayerProfileViewConstraints_t97717017, ___ShowDisplayName_5)); }
	inline bool get_ShowDisplayName_5() const { return ___ShowDisplayName_5; }
	inline bool* get_address_of_ShowDisplayName_5() { return &___ShowDisplayName_5; }
	inline void set_ShowDisplayName_5(bool value)
	{
		___ShowDisplayName_5 = value;
	}

	inline static int32_t get_offset_of_ShowLastLogin_6() { return static_cast<int32_t>(offsetof(PlayerProfileViewConstraints_t97717017, ___ShowLastLogin_6)); }
	inline bool get_ShowLastLogin_6() const { return ___ShowLastLogin_6; }
	inline bool* get_address_of_ShowLastLogin_6() { return &___ShowLastLogin_6; }
	inline void set_ShowLastLogin_6(bool value)
	{
		___ShowLastLogin_6 = value;
	}

	inline static int32_t get_offset_of_ShowLinkedAccounts_7() { return static_cast<int32_t>(offsetof(PlayerProfileViewConstraints_t97717017, ___ShowLinkedAccounts_7)); }
	inline bool get_ShowLinkedAccounts_7() const { return ___ShowLinkedAccounts_7; }
	inline bool* get_address_of_ShowLinkedAccounts_7() { return &___ShowLinkedAccounts_7; }
	inline void set_ShowLinkedAccounts_7(bool value)
	{
		___ShowLinkedAccounts_7 = value;
	}

	inline static int32_t get_offset_of_ShowLocations_8() { return static_cast<int32_t>(offsetof(PlayerProfileViewConstraints_t97717017, ___ShowLocations_8)); }
	inline bool get_ShowLocations_8() const { return ___ShowLocations_8; }
	inline bool* get_address_of_ShowLocations_8() { return &___ShowLocations_8; }
	inline void set_ShowLocations_8(bool value)
	{
		___ShowLocations_8 = value;
	}

	inline static int32_t get_offset_of_ShowMemberships_9() { return static_cast<int32_t>(offsetof(PlayerProfileViewConstraints_t97717017, ___ShowMemberships_9)); }
	inline bool get_ShowMemberships_9() const { return ___ShowMemberships_9; }
	inline bool* get_address_of_ShowMemberships_9() { return &___ShowMemberships_9; }
	inline void set_ShowMemberships_9(bool value)
	{
		___ShowMemberships_9 = value;
	}

	inline static int32_t get_offset_of_ShowOrigination_10() { return static_cast<int32_t>(offsetof(PlayerProfileViewConstraints_t97717017, ___ShowOrigination_10)); }
	inline bool get_ShowOrigination_10() const { return ___ShowOrigination_10; }
	inline bool* get_address_of_ShowOrigination_10() { return &___ShowOrigination_10; }
	inline void set_ShowOrigination_10(bool value)
	{
		___ShowOrigination_10 = value;
	}

	inline static int32_t get_offset_of_ShowPushNotificationRegistrations_11() { return static_cast<int32_t>(offsetof(PlayerProfileViewConstraints_t97717017, ___ShowPushNotificationRegistrations_11)); }
	inline bool get_ShowPushNotificationRegistrations_11() const { return ___ShowPushNotificationRegistrations_11; }
	inline bool* get_address_of_ShowPushNotificationRegistrations_11() { return &___ShowPushNotificationRegistrations_11; }
	inline void set_ShowPushNotificationRegistrations_11(bool value)
	{
		___ShowPushNotificationRegistrations_11 = value;
	}

	inline static int32_t get_offset_of_ShowStatistics_12() { return static_cast<int32_t>(offsetof(PlayerProfileViewConstraints_t97717017, ___ShowStatistics_12)); }
	inline bool get_ShowStatistics_12() const { return ___ShowStatistics_12; }
	inline bool* get_address_of_ShowStatistics_12() { return &___ShowStatistics_12; }
	inline void set_ShowStatistics_12(bool value)
	{
		___ShowStatistics_12 = value;
	}

	inline static int32_t get_offset_of_ShowTags_13() { return static_cast<int32_t>(offsetof(PlayerProfileViewConstraints_t97717017, ___ShowTags_13)); }
	inline bool get_ShowTags_13() const { return ___ShowTags_13; }
	inline bool* get_address_of_ShowTags_13() { return &___ShowTags_13; }
	inline void set_ShowTags_13(bool value)
	{
		___ShowTags_13 = value;
	}

	inline static int32_t get_offset_of_ShowTotalValueToDateInUsd_14() { return static_cast<int32_t>(offsetof(PlayerProfileViewConstraints_t97717017, ___ShowTotalValueToDateInUsd_14)); }
	inline bool get_ShowTotalValueToDateInUsd_14() const { return ___ShowTotalValueToDateInUsd_14; }
	inline bool* get_address_of_ShowTotalValueToDateInUsd_14() { return &___ShowTotalValueToDateInUsd_14; }
	inline void set_ShowTotalValueToDateInUsd_14(bool value)
	{
		___ShowTotalValueToDateInUsd_14 = value;
	}

	inline static int32_t get_offset_of_ShowValuesToDate_15() { return static_cast<int32_t>(offsetof(PlayerProfileViewConstraints_t97717017, ___ShowValuesToDate_15)); }
	inline bool get_ShowValuesToDate_15() const { return ___ShowValuesToDate_15; }
	inline bool* get_address_of_ShowValuesToDate_15() { return &___ShowValuesToDate_15; }
	inline void set_ShowValuesToDate_15(bool value)
	{
		___ShowValuesToDate_15 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // PLAYERPROFILEVIEWCONSTRAINTS_T97717017_H
#ifndef PLAYERLEADERBOARDENTRY_T1881677957_H
#define PLAYERLEADERBOARDENTRY_T1881677957_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.PlayerLeaderboardEntry
struct  PlayerLeaderboardEntry_t1881677957  : public RuntimeObject
{
public:
	// System.String PlayFab.ClientModels.PlayerLeaderboardEntry::DisplayName
	String_t* ___DisplayName_0;
	// System.String PlayFab.ClientModels.PlayerLeaderboardEntry::PlayFabId
	String_t* ___PlayFabId_1;
	// System.Int32 PlayFab.ClientModels.PlayerLeaderboardEntry::Position
	int32_t ___Position_2;
	// PlayFab.ClientModels.PlayerProfileModel PlayFab.ClientModels.PlayerLeaderboardEntry::Profile
	PlayerProfileModel_t250934598 * ___Profile_3;
	// System.Int32 PlayFab.ClientModels.PlayerLeaderboardEntry::StatValue
	int32_t ___StatValue_4;

public:
	inline static int32_t get_offset_of_DisplayName_0() { return static_cast<int32_t>(offsetof(PlayerLeaderboardEntry_t1881677957, ___DisplayName_0)); }
	inline String_t* get_DisplayName_0() const { return ___DisplayName_0; }
	inline String_t** get_address_of_DisplayName_0() { return &___DisplayName_0; }
	inline void set_DisplayName_0(String_t* value)
	{
		___DisplayName_0 = value;
		Il2CppCodeGenWriteBarrier((&___DisplayName_0), value);
	}

	inline static int32_t get_offset_of_PlayFabId_1() { return static_cast<int32_t>(offsetof(PlayerLeaderboardEntry_t1881677957, ___PlayFabId_1)); }
	inline String_t* get_PlayFabId_1() const { return ___PlayFabId_1; }
	inline String_t** get_address_of_PlayFabId_1() { return &___PlayFabId_1; }
	inline void set_PlayFabId_1(String_t* value)
	{
		___PlayFabId_1 = value;
		Il2CppCodeGenWriteBarrier((&___PlayFabId_1), value);
	}

	inline static int32_t get_offset_of_Position_2() { return static_cast<int32_t>(offsetof(PlayerLeaderboardEntry_t1881677957, ___Position_2)); }
	inline int32_t get_Position_2() const { return ___Position_2; }
	inline int32_t* get_address_of_Position_2() { return &___Position_2; }
	inline void set_Position_2(int32_t value)
	{
		___Position_2 = value;
	}

	inline static int32_t get_offset_of_Profile_3() { return static_cast<int32_t>(offsetof(PlayerLeaderboardEntry_t1881677957, ___Profile_3)); }
	inline PlayerProfileModel_t250934598 * get_Profile_3() const { return ___Profile_3; }
	inline PlayerProfileModel_t250934598 ** get_address_of_Profile_3() { return &___Profile_3; }
	inline void set_Profile_3(PlayerProfileModel_t250934598 * value)
	{
		___Profile_3 = value;
		Il2CppCodeGenWriteBarrier((&___Profile_3), value);
	}

	inline static int32_t get_offset_of_StatValue_4() { return static_cast<int32_t>(offsetof(PlayerLeaderboardEntry_t1881677957, ___StatValue_4)); }
	inline int32_t get_StatValue_4() const { return ___StatValue_4; }
	inline int32_t* get_address_of_StatValue_4() { return &___StatValue_4; }
	inline void set_StatValue_4(int32_t value)
	{
		___StatValue_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // PLAYERLEADERBOARDENTRY_T1881677957_H
#ifndef PLAYFABRESULTCOMMON_T3469603827_H
#define PLAYFABRESULTCOMMON_T3469603827_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.SharedModels.PlayFabResultCommon
struct  PlayFabResultCommon_t3469603827  : public RuntimeObject
{
public:
	// PlayFab.SharedModels.PlayFabRequestCommon PlayFab.SharedModels.PlayFabResultCommon::Request
	PlayFabRequestCommon_t229319069 * ___Request_0;
	// System.Object PlayFab.SharedModels.PlayFabResultCommon::CustomData
	RuntimeObject * ___CustomData_1;

public:
	inline static int32_t get_offset_of_Request_0() { return static_cast<int32_t>(offsetof(PlayFabResultCommon_t3469603827, ___Request_0)); }
	inline PlayFabRequestCommon_t229319069 * get_Request_0() const { return ___Request_0; }
	inline PlayFabRequestCommon_t229319069 ** get_address_of_Request_0() { return &___Request_0; }
	inline void set_Request_0(PlayFabRequestCommon_t229319069 * value)
	{
		___Request_0 = value;
		Il2CppCodeGenWriteBarrier((&___Request_0), value);
	}

	inline static int32_t get_offset_of_CustomData_1() { return static_cast<int32_t>(offsetof(PlayFabResultCommon_t3469603827, ___CustomData_1)); }
	inline RuntimeObject * get_CustomData_1() const { return ___CustomData_1; }
	inline RuntimeObject ** get_address_of_CustomData_1() { return &___CustomData_1; }
	inline void set_CustomData_1(RuntimeObject * value)
	{
		___CustomData_1 = value;
		Il2CppCodeGenWriteBarrier((&___CustomData_1), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // PLAYFABRESULTCOMMON_T3469603827_H
#ifndef SCRIPTEXECUTIONERROR_T3998229139_H
#define SCRIPTEXECUTIONERROR_T3998229139_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.ScriptExecutionError
struct  ScriptExecutionError_t3998229139  : public RuntimeObject
{
public:
	// System.String PlayFab.ClientModels.ScriptExecutionError::Error
	String_t* ___Error_0;
	// System.String PlayFab.ClientModels.ScriptExecutionError::Message
	String_t* ___Message_1;
	// System.String PlayFab.ClientModels.ScriptExecutionError::StackTrace
	String_t* ___StackTrace_2;

public:
	inline static int32_t get_offset_of_Error_0() { return static_cast<int32_t>(offsetof(ScriptExecutionError_t3998229139, ___Error_0)); }
	inline String_t* get_Error_0() const { return ___Error_0; }
	inline String_t** get_address_of_Error_0() { return &___Error_0; }
	inline void set_Error_0(String_t* value)
	{
		___Error_0 = value;
		Il2CppCodeGenWriteBarrier((&___Error_0), value);
	}

	inline static int32_t get_offset_of_Message_1() { return static_cast<int32_t>(offsetof(ScriptExecutionError_t3998229139, ___Message_1)); }
	inline String_t* get_Message_1() const { return ___Message_1; }
	inline String_t** get_address_of_Message_1() { return &___Message_1; }
	inline void set_Message_1(String_t* value)
	{
		___Message_1 = value;
		Il2CppCodeGenWriteBarrier((&___Message_1), value);
	}

	inline static int32_t get_offset_of_StackTrace_2() { return static_cast<int32_t>(offsetof(ScriptExecutionError_t3998229139, ___StackTrace_2)); }
	inline String_t* get_StackTrace_2() const { return ___StackTrace_2; }
	inline String_t** get_address_of_StackTrace_2() { return &___StackTrace_2; }
	inline void set_StackTrace_2(String_t* value)
	{
		___StackTrace_2 = value;
		Il2CppCodeGenWriteBarrier((&___StackTrace_2), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SCRIPTEXECUTIONERROR_T3998229139_H
#ifndef LOGSTATEMENT_T3612334110_H
#define LOGSTATEMENT_T3612334110_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.LogStatement
struct  LogStatement_t3612334110  : public RuntimeObject
{
public:
	// System.Object PlayFab.ClientModels.LogStatement::Data
	RuntimeObject * ___Data_0;
	// System.String PlayFab.ClientModels.LogStatement::Level
	String_t* ___Level_1;
	// System.String PlayFab.ClientModels.LogStatement::Message
	String_t* ___Message_2;

public:
	inline static int32_t get_offset_of_Data_0() { return static_cast<int32_t>(offsetof(LogStatement_t3612334110, ___Data_0)); }
	inline RuntimeObject * get_Data_0() const { return ___Data_0; }
	inline RuntimeObject ** get_address_of_Data_0() { return &___Data_0; }
	inline void set_Data_0(RuntimeObject * value)
	{
		___Data_0 = value;
		Il2CppCodeGenWriteBarrier((&___Data_0), value);
	}

	inline static int32_t get_offset_of_Level_1() { return static_cast<int32_t>(offsetof(LogStatement_t3612334110, ___Level_1)); }
	inline String_t* get_Level_1() const { return ___Level_1; }
	inline String_t** get_address_of_Level_1() { return &___Level_1; }
	inline void set_Level_1(String_t* value)
	{
		___Level_1 = value;
		Il2CppCodeGenWriteBarrier((&___Level_1), value);
	}

	inline static int32_t get_offset_of_Message_2() { return static_cast<int32_t>(offsetof(LogStatement_t3612334110, ___Message_2)); }
	inline String_t* get_Message_2() const { return ___Message_2; }
	inline String_t** get_address_of_Message_2() { return &___Message_2; }
	inline void set_Message_2(String_t* value)
	{
		___Message_2 = value;
		Il2CppCodeGenWriteBarrier((&___Message_2), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LOGSTATEMENT_T3612334110_H
#ifndef STATISTICMODEL_T598410627_H
#define STATISTICMODEL_T598410627_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.StatisticModel
struct  StatisticModel_t598410627  : public RuntimeObject
{
public:
	// System.String PlayFab.ClientModels.StatisticModel::Name
	String_t* ___Name_0;
	// System.Int32 PlayFab.ClientModels.StatisticModel::Value
	int32_t ___Value_1;
	// System.Int32 PlayFab.ClientModels.StatisticModel::Version
	int32_t ___Version_2;

public:
	inline static int32_t get_offset_of_Name_0() { return static_cast<int32_t>(offsetof(StatisticModel_t598410627, ___Name_0)); }
	inline String_t* get_Name_0() const { return ___Name_0; }
	inline String_t** get_address_of_Name_0() { return &___Name_0; }
	inline void set_Name_0(String_t* value)
	{
		___Name_0 = value;
		Il2CppCodeGenWriteBarrier((&___Name_0), value);
	}

	inline static int32_t get_offset_of_Value_1() { return static_cast<int32_t>(offsetof(StatisticModel_t598410627, ___Value_1)); }
	inline int32_t get_Value_1() const { return ___Value_1; }
	inline int32_t* get_address_of_Value_1() { return &___Value_1; }
	inline void set_Value_1(int32_t value)
	{
		___Value_1 = value;
	}

	inline static int32_t get_offset_of_Version_2() { return static_cast<int32_t>(offsetof(StatisticModel_t598410627, ___Version_2)); }
	inline int32_t get_Version_2() const { return ___Version_2; }
	inline int32_t* get_address_of_Version_2() { return &___Version_2; }
	inline void set_Version_2(int32_t value)
	{
		___Version_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // STATISTICMODEL_T598410627_H
#ifndef PLAYFABREQUESTCOMMON_T229319069_H
#define PLAYFABREQUESTCOMMON_T229319069_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.SharedModels.PlayFabRequestCommon
struct  PlayFabRequestCommon_t229319069  : public RuntimeObject
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // PLAYFABREQUESTCOMMON_T229319069_H
#ifndef STATISTICNAMEVERSION_T4077247347_H
#define STATISTICNAMEVERSION_T4077247347_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.StatisticNameVersion
struct  StatisticNameVersion_t4077247347  : public RuntimeObject
{
public:
	// System.String PlayFab.ClientModels.StatisticNameVersion::StatisticName
	String_t* ___StatisticName_0;
	// System.UInt32 PlayFab.ClientModels.StatisticNameVersion::Version
	uint32_t ___Version_1;

public:
	inline static int32_t get_offset_of_StatisticName_0() { return static_cast<int32_t>(offsetof(StatisticNameVersion_t4077247347, ___StatisticName_0)); }
	inline String_t* get_StatisticName_0() const { return ___StatisticName_0; }
	inline String_t** get_address_of_StatisticName_0() { return &___StatisticName_0; }
	inline void set_StatisticName_0(String_t* value)
	{
		___StatisticName_0 = value;
		Il2CppCodeGenWriteBarrier((&___StatisticName_0), value);
	}

	inline static int32_t get_offset_of_Version_1() { return static_cast<int32_t>(offsetof(StatisticNameVersion_t4077247347, ___Version_1)); }
	inline uint32_t get_Version_1() const { return ___Version_1; }
	inline uint32_t* get_address_of_Version_1() { return &___Version_1; }
	inline void set_Version_1(uint32_t value)
	{
		___Version_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // STATISTICNAMEVERSION_T4077247347_H
#ifndef GOOGLEPLAYFABIDPAIR_T4035589282_H
#define GOOGLEPLAYFABIDPAIR_T4035589282_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.GooglePlayFabIdPair
struct  GooglePlayFabIdPair_t4035589282  : public RuntimeObject
{
public:
	// System.String PlayFab.ClientModels.GooglePlayFabIdPair::GoogleId
	String_t* ___GoogleId_0;
	// System.String PlayFab.ClientModels.GooglePlayFabIdPair::PlayFabId
	String_t* ___PlayFabId_1;

public:
	inline static int32_t get_offset_of_GoogleId_0() { return static_cast<int32_t>(offsetof(GooglePlayFabIdPair_t4035589282, ___GoogleId_0)); }
	inline String_t* get_GoogleId_0() const { return ___GoogleId_0; }
	inline String_t** get_address_of_GoogleId_0() { return &___GoogleId_0; }
	inline void set_GoogleId_0(String_t* value)
	{
		___GoogleId_0 = value;
		Il2CppCodeGenWriteBarrier((&___GoogleId_0), value);
	}

	inline static int32_t get_offset_of_PlayFabId_1() { return static_cast<int32_t>(offsetof(GooglePlayFabIdPair_t4035589282, ___PlayFabId_1)); }
	inline String_t* get_PlayFabId_1() const { return ___PlayFabId_1; }
	inline String_t** get_address_of_PlayFabId_1() { return &___PlayFabId_1; }
	inline void set_PlayFabId_1(String_t* value)
	{
		___PlayFabId_1 = value;
		Il2CppCodeGenWriteBarrier((&___PlayFabId_1), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // GOOGLEPLAYFABIDPAIR_T4035589282_H
#ifndef KONGREGATEPLAYFABIDPAIR_T3490969040_H
#define KONGREGATEPLAYFABIDPAIR_T3490969040_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.KongregatePlayFabIdPair
struct  KongregatePlayFabIdPair_t3490969040  : public RuntimeObject
{
public:
	// System.String PlayFab.ClientModels.KongregatePlayFabIdPair::KongregateId
	String_t* ___KongregateId_0;
	// System.String PlayFab.ClientModels.KongregatePlayFabIdPair::PlayFabId
	String_t* ___PlayFabId_1;

public:
	inline static int32_t get_offset_of_KongregateId_0() { return static_cast<int32_t>(offsetof(KongregatePlayFabIdPair_t3490969040, ___KongregateId_0)); }
	inline String_t* get_KongregateId_0() const { return ___KongregateId_0; }
	inline String_t** get_address_of_KongregateId_0() { return &___KongregateId_0; }
	inline void set_KongregateId_0(String_t* value)
	{
		___KongregateId_0 = value;
		Il2CppCodeGenWriteBarrier((&___KongregateId_0), value);
	}

	inline static int32_t get_offset_of_PlayFabId_1() { return static_cast<int32_t>(offsetof(KongregatePlayFabIdPair_t3490969040, ___PlayFabId_1)); }
	inline String_t* get_PlayFabId_1() const { return ___PlayFabId_1; }
	inline String_t** get_address_of_PlayFabId_1() { return &___PlayFabId_1; }
	inline void set_PlayFabId_1(String_t* value)
	{
		___PlayFabId_1 = value;
		Il2CppCodeGenWriteBarrier((&___PlayFabId_1), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // KONGREGATEPLAYFABIDPAIR_T3490969040_H
#ifndef REMOVECONTACTEMAILRESULT_T1684933791_H
#define REMOVECONTACTEMAILRESULT_T1684933791_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.RemoveContactEmailResult
struct  RemoveContactEmailResult_t1684933791  : public PlayFabResultCommon_t3469603827
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // REMOVECONTACTEMAILRESULT_T1684933791_H
#ifndef REMOVEFRIENDREQUEST_T4181183992_H
#define REMOVEFRIENDREQUEST_T4181183992_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.RemoveFriendRequest
struct  RemoveFriendRequest_t4181183992  : public PlayFabRequestCommon_t229319069
{
public:
	// System.String PlayFab.ClientModels.RemoveFriendRequest::FriendPlayFabId
	String_t* ___FriendPlayFabId_0;

public:
	inline static int32_t get_offset_of_FriendPlayFabId_0() { return static_cast<int32_t>(offsetof(RemoveFriendRequest_t4181183992, ___FriendPlayFabId_0)); }
	inline String_t* get_FriendPlayFabId_0() const { return ___FriendPlayFabId_0; }
	inline String_t** get_address_of_FriendPlayFabId_0() { return &___FriendPlayFabId_0; }
	inline void set_FriendPlayFabId_0(String_t* value)
	{
		___FriendPlayFabId_0 = value;
		Il2CppCodeGenWriteBarrier((&___FriendPlayFabId_0), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // REMOVEFRIENDREQUEST_T4181183992_H
#ifndef REPORTPLAYERCLIENTRESULT_T3799493971_H
#define REPORTPLAYERCLIENTRESULT_T3799493971_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.ReportPlayerClientResult
struct  ReportPlayerClientResult_t3799493971  : public PlayFabResultCommon_t3469603827
{
public:
	// System.Int32 PlayFab.ClientModels.ReportPlayerClientResult::SubmissionsRemaining
	int32_t ___SubmissionsRemaining_2;

public:
	inline static int32_t get_offset_of_SubmissionsRemaining_2() { return static_cast<int32_t>(offsetof(ReportPlayerClientResult_t3799493971, ___SubmissionsRemaining_2)); }
	inline int32_t get_SubmissionsRemaining_2() const { return ___SubmissionsRemaining_2; }
	inline int32_t* get_address_of_SubmissionsRemaining_2() { return &___SubmissionsRemaining_2; }
	inline void set_SubmissionsRemaining_2(int32_t value)
	{
		___SubmissionsRemaining_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // REPORTPLAYERCLIENTRESULT_T3799493971_H
#ifndef RESTOREIOSPURCHASESREQUEST_T2021516304_H
#define RESTOREIOSPURCHASESREQUEST_T2021516304_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.RestoreIOSPurchasesRequest
struct  RestoreIOSPurchasesRequest_t2021516304  : public PlayFabRequestCommon_t229319069
{
public:
	// System.String PlayFab.ClientModels.RestoreIOSPurchasesRequest::ReceiptData
	String_t* ___ReceiptData_0;

public:
	inline static int32_t get_offset_of_ReceiptData_0() { return static_cast<int32_t>(offsetof(RestoreIOSPurchasesRequest_t2021516304, ___ReceiptData_0)); }
	inline String_t* get_ReceiptData_0() const { return ___ReceiptData_0; }
	inline String_t** get_address_of_ReceiptData_0() { return &___ReceiptData_0; }
	inline void set_ReceiptData_0(String_t* value)
	{
		___ReceiptData_0 = value;
		Il2CppCodeGenWriteBarrier((&___ReceiptData_0), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // RESTOREIOSPURCHASESREQUEST_T2021516304_H
#ifndef RESTOREIOSPURCHASESRESULT_T2500978621_H
#define RESTOREIOSPURCHASESRESULT_T2500978621_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.RestoreIOSPurchasesResult
struct  RestoreIOSPurchasesResult_t2500978621  : public PlayFabResultCommon_t3469603827
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // RESTOREIOSPURCHASESRESULT_T2500978621_H
#ifndef REGISTERFORIOSPUSHNOTIFICATIONRESULT_T2256269114_H
#define REGISTERFORIOSPUSHNOTIFICATIONRESULT_T2256269114_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.RegisterForIOSPushNotificationResult
struct  RegisterForIOSPushNotificationResult_t2256269114  : public PlayFabResultCommon_t3469603827
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // REGISTERFORIOSPUSHNOTIFICATIONRESULT_T2256269114_H
#ifndef SENDACCOUNTRECOVERYEMAILRESULT_T550548115_H
#define SENDACCOUNTRECOVERYEMAILRESULT_T550548115_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.SendAccountRecoveryEmailResult
struct  SendAccountRecoveryEmailResult_t550548115  : public PlayFabResultCommon_t3469603827
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SENDACCOUNTRECOVERYEMAILRESULT_T550548115_H
#ifndef SETFRIENDTAGSREQUEST_T2241574297_H
#define SETFRIENDTAGSREQUEST_T2241574297_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.SetFriendTagsRequest
struct  SetFriendTagsRequest_t2241574297  : public PlayFabRequestCommon_t229319069
{
public:
	// System.String PlayFab.ClientModels.SetFriendTagsRequest::FriendPlayFabId
	String_t* ___FriendPlayFabId_0;
	// System.Collections.Generic.List`1<System.String> PlayFab.ClientModels.SetFriendTagsRequest::Tags
	List_1_t3319525431 * ___Tags_1;

public:
	inline static int32_t get_offset_of_FriendPlayFabId_0() { return static_cast<int32_t>(offsetof(SetFriendTagsRequest_t2241574297, ___FriendPlayFabId_0)); }
	inline String_t* get_FriendPlayFabId_0() const { return ___FriendPlayFabId_0; }
	inline String_t** get_address_of_FriendPlayFabId_0() { return &___FriendPlayFabId_0; }
	inline void set_FriendPlayFabId_0(String_t* value)
	{
		___FriendPlayFabId_0 = value;
		Il2CppCodeGenWriteBarrier((&___FriendPlayFabId_0), value);
	}

	inline static int32_t get_offset_of_Tags_1() { return static_cast<int32_t>(offsetof(SetFriendTagsRequest_t2241574297, ___Tags_1)); }
	inline List_1_t3319525431 * get_Tags_1() const { return ___Tags_1; }
	inline List_1_t3319525431 ** get_address_of_Tags_1() { return &___Tags_1; }
	inline void set_Tags_1(List_1_t3319525431 * value)
	{
		___Tags_1 = value;
		Il2CppCodeGenWriteBarrier((&___Tags_1), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SETFRIENDTAGSREQUEST_T2241574297_H
#ifndef SETFRIENDTAGSRESULT_T4002085899_H
#define SETFRIENDTAGSRESULT_T4002085899_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.SetFriendTagsResult
struct  SetFriendTagsResult_t4002085899  : public PlayFabResultCommon_t3469603827
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SETFRIENDTAGSRESULT_T4002085899_H
#ifndef REMOVECONTACTEMAILREQUEST_T1252854948_H
#define REMOVECONTACTEMAILREQUEST_T1252854948_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.RemoveContactEmailRequest
struct  RemoveContactEmailRequest_t1252854948  : public PlayFabRequestCommon_t229319069
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // REMOVECONTACTEMAILREQUEST_T1252854948_H
#ifndef REGISTERPLAYFABUSERRESULT_T802479880_H
#define REGISTERPLAYFABUSERRESULT_T802479880_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.RegisterPlayFabUserResult
struct  RegisterPlayFabUserResult_t802479880  : public PlayFabResultCommon_t3469603827
{
public:
	// System.String PlayFab.ClientModels.RegisterPlayFabUserResult::PlayFabId
	String_t* ___PlayFabId_2;
	// System.String PlayFab.ClientModels.RegisterPlayFabUserResult::SessionTicket
	String_t* ___SessionTicket_3;
	// PlayFab.ClientModels.UserSettings PlayFab.ClientModels.RegisterPlayFabUserResult::SettingsForUser
	UserSettings_t3054366223 * ___SettingsForUser_4;
	// System.String PlayFab.ClientModels.RegisterPlayFabUserResult::Username
	String_t* ___Username_5;

public:
	inline static int32_t get_offset_of_PlayFabId_2() { return static_cast<int32_t>(offsetof(RegisterPlayFabUserResult_t802479880, ___PlayFabId_2)); }
	inline String_t* get_PlayFabId_2() const { return ___PlayFabId_2; }
	inline String_t** get_address_of_PlayFabId_2() { return &___PlayFabId_2; }
	inline void set_PlayFabId_2(String_t* value)
	{
		___PlayFabId_2 = value;
		Il2CppCodeGenWriteBarrier((&___PlayFabId_2), value);
	}

	inline static int32_t get_offset_of_SessionTicket_3() { return static_cast<int32_t>(offsetof(RegisterPlayFabUserResult_t802479880, ___SessionTicket_3)); }
	inline String_t* get_SessionTicket_3() const { return ___SessionTicket_3; }
	inline String_t** get_address_of_SessionTicket_3() { return &___SessionTicket_3; }
	inline void set_SessionTicket_3(String_t* value)
	{
		___SessionTicket_3 = value;
		Il2CppCodeGenWriteBarrier((&___SessionTicket_3), value);
	}

	inline static int32_t get_offset_of_SettingsForUser_4() { return static_cast<int32_t>(offsetof(RegisterPlayFabUserResult_t802479880, ___SettingsForUser_4)); }
	inline UserSettings_t3054366223 * get_SettingsForUser_4() const { return ___SettingsForUser_4; }
	inline UserSettings_t3054366223 ** get_address_of_SettingsForUser_4() { return &___SettingsForUser_4; }
	inline void set_SettingsForUser_4(UserSettings_t3054366223 * value)
	{
		___SettingsForUser_4 = value;
		Il2CppCodeGenWriteBarrier((&___SettingsForUser_4), value);
	}

	inline static int32_t get_offset_of_Username_5() { return static_cast<int32_t>(offsetof(RegisterPlayFabUserResult_t802479880, ___Username_5)); }
	inline String_t* get_Username_5() const { return ___Username_5; }
	inline String_t** get_address_of_Username_5() { return &___Username_5; }
	inline void set_Username_5(String_t* value)
	{
		___Username_5 = value;
		Il2CppCodeGenWriteBarrier((&___Username_5), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // REGISTERPLAYFABUSERRESULT_T802479880_H
#ifndef SENDACCOUNTRECOVERYEMAILREQUEST_T3630781634_H
#define SENDACCOUNTRECOVERYEMAILREQUEST_T3630781634_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.SendAccountRecoveryEmailRequest
struct  SendAccountRecoveryEmailRequest_t3630781634  : public PlayFabRequestCommon_t229319069
{
public:
	// System.String PlayFab.ClientModels.SendAccountRecoveryEmailRequest::Email
	String_t* ___Email_0;
	// System.String PlayFab.ClientModels.SendAccountRecoveryEmailRequest::EmailTemplateId
	String_t* ___EmailTemplateId_1;
	// System.String PlayFab.ClientModels.SendAccountRecoveryEmailRequest::TitleId
	String_t* ___TitleId_2;

public:
	inline static int32_t get_offset_of_Email_0() { return static_cast<int32_t>(offsetof(SendAccountRecoveryEmailRequest_t3630781634, ___Email_0)); }
	inline String_t* get_Email_0() const { return ___Email_0; }
	inline String_t** get_address_of_Email_0() { return &___Email_0; }
	inline void set_Email_0(String_t* value)
	{
		___Email_0 = value;
		Il2CppCodeGenWriteBarrier((&___Email_0), value);
	}

	inline static int32_t get_offset_of_EmailTemplateId_1() { return static_cast<int32_t>(offsetof(SendAccountRecoveryEmailRequest_t3630781634, ___EmailTemplateId_1)); }
	inline String_t* get_EmailTemplateId_1() const { return ___EmailTemplateId_1; }
	inline String_t** get_address_of_EmailTemplateId_1() { return &___EmailTemplateId_1; }
	inline void set_EmailTemplateId_1(String_t* value)
	{
		___EmailTemplateId_1 = value;
		Il2CppCodeGenWriteBarrier((&___EmailTemplateId_1), value);
	}

	inline static int32_t get_offset_of_TitleId_2() { return static_cast<int32_t>(offsetof(SendAccountRecoveryEmailRequest_t3630781634, ___TitleId_2)); }
	inline String_t* get_TitleId_2() const { return ___TitleId_2; }
	inline String_t** get_address_of_TitleId_2() { return &___TitleId_2; }
	inline void set_TitleId_2(String_t* value)
	{
		___TitleId_2 = value;
		Il2CppCodeGenWriteBarrier((&___TitleId_2), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SENDACCOUNTRECOVERYEMAILREQUEST_T3630781634_H
#ifndef REMOVEGENERICIDREQUEST_T1674395511_H
#define REMOVEGENERICIDREQUEST_T1674395511_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.RemoveGenericIDRequest
struct  RemoveGenericIDRequest_t1674395511  : public PlayFabRequestCommon_t229319069
{
public:
	// PlayFab.ClientModels.GenericServiceId PlayFab.ClientModels.RemoveGenericIDRequest::GenericId
	GenericServiceId_t3400130533 * ___GenericId_0;

public:
	inline static int32_t get_offset_of_GenericId_0() { return static_cast<int32_t>(offsetof(RemoveGenericIDRequest_t1674395511, ___GenericId_0)); }
	inline GenericServiceId_t3400130533 * get_GenericId_0() const { return ___GenericId_0; }
	inline GenericServiceId_t3400130533 ** get_address_of_GenericId_0() { return &___GenericId_0; }
	inline void set_GenericId_0(GenericServiceId_t3400130533 * value)
	{
		___GenericId_0 = value;
		Il2CppCodeGenWriteBarrier((&___GenericId_0), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // REMOVEGENERICIDREQUEST_T1674395511_H
#ifndef REMOVESHAREDGROUPMEMBERSRESULT_T1660437242_H
#define REMOVESHAREDGROUPMEMBERSRESULT_T1660437242_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.RemoveSharedGroupMembersResult
struct  RemoveSharedGroupMembersResult_t1660437242  : public PlayFabResultCommon_t3469603827
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // REMOVESHAREDGROUPMEMBERSRESULT_T1660437242_H
#ifndef REDEEMCOUPONREQUEST_T236242173_H
#define REDEEMCOUPONREQUEST_T236242173_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.RedeemCouponRequest
struct  RedeemCouponRequest_t236242173  : public PlayFabRequestCommon_t229319069
{
public:
	// System.String PlayFab.ClientModels.RedeemCouponRequest::CatalogVersion
	String_t* ___CatalogVersion_0;
	// System.String PlayFab.ClientModels.RedeemCouponRequest::CharacterId
	String_t* ___CharacterId_1;
	// System.String PlayFab.ClientModels.RedeemCouponRequest::CouponCode
	String_t* ___CouponCode_2;

public:
	inline static int32_t get_offset_of_CatalogVersion_0() { return static_cast<int32_t>(offsetof(RedeemCouponRequest_t236242173, ___CatalogVersion_0)); }
	inline String_t* get_CatalogVersion_0() const { return ___CatalogVersion_0; }
	inline String_t** get_address_of_CatalogVersion_0() { return &___CatalogVersion_0; }
	inline void set_CatalogVersion_0(String_t* value)
	{
		___CatalogVersion_0 = value;
		Il2CppCodeGenWriteBarrier((&___CatalogVersion_0), value);
	}

	inline static int32_t get_offset_of_CharacterId_1() { return static_cast<int32_t>(offsetof(RedeemCouponRequest_t236242173, ___CharacterId_1)); }
	inline String_t* get_CharacterId_1() const { return ___CharacterId_1; }
	inline String_t** get_address_of_CharacterId_1() { return &___CharacterId_1; }
	inline void set_CharacterId_1(String_t* value)
	{
		___CharacterId_1 = value;
		Il2CppCodeGenWriteBarrier((&___CharacterId_1), value);
	}

	inline static int32_t get_offset_of_CouponCode_2() { return static_cast<int32_t>(offsetof(RedeemCouponRequest_t236242173, ___CouponCode_2)); }
	inline String_t* get_CouponCode_2() const { return ___CouponCode_2; }
	inline String_t** get_address_of_CouponCode_2() { return &___CouponCode_2; }
	inline void set_CouponCode_2(String_t* value)
	{
		___CouponCode_2 = value;
		Il2CppCodeGenWriteBarrier((&___CouponCode_2), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // REDEEMCOUPONREQUEST_T236242173_H
#ifndef REMOVEGENERICIDRESULT_T3234682150_H
#define REMOVEGENERICIDRESULT_T3234682150_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.RemoveGenericIDResult
struct  RemoveGenericIDResult_t3234682150  : public PlayFabResultCommon_t3469603827
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // REMOVEGENERICIDRESULT_T3234682150_H
#ifndef PURCHASEITEMRESULT_T1722243179_H
#define PURCHASEITEMRESULT_T1722243179_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.PurchaseItemResult
struct  PurchaseItemResult_t1722243179  : public PlayFabResultCommon_t3469603827
{
public:
	// System.Collections.Generic.List`1<PlayFab.ClientModels.ItemInstance> PlayFab.ClientModels.PurchaseItemResult::Items
	List_1_t898730215 * ___Items_2;

public:
	inline static int32_t get_offset_of_Items_2() { return static_cast<int32_t>(offsetof(PurchaseItemResult_t1722243179, ___Items_2)); }
	inline List_1_t898730215 * get_Items_2() const { return ___Items_2; }
	inline List_1_t898730215 ** get_address_of_Items_2() { return &___Items_2; }
	inline void set_Items_2(List_1_t898730215 * value)
	{
		___Items_2 = value;
		Il2CppCodeGenWriteBarrier((&___Items_2), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // PURCHASEITEMRESULT_T1722243179_H
#ifndef PURCHASEITEMREQUEST_T446597288_H
#define PURCHASEITEMREQUEST_T446597288_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.PurchaseItemRequest
struct  PurchaseItemRequest_t446597288  : public PlayFabRequestCommon_t229319069
{
public:
	// System.String PlayFab.ClientModels.PurchaseItemRequest::CatalogVersion
	String_t* ___CatalogVersion_0;
	// System.String PlayFab.ClientModels.PurchaseItemRequest::CharacterId
	String_t* ___CharacterId_1;
	// System.String PlayFab.ClientModels.PurchaseItemRequest::ItemId
	String_t* ___ItemId_2;
	// System.Int32 PlayFab.ClientModels.PurchaseItemRequest::Price
	int32_t ___Price_3;
	// System.String PlayFab.ClientModels.PurchaseItemRequest::StoreId
	String_t* ___StoreId_4;
	// System.String PlayFab.ClientModels.PurchaseItemRequest::VirtualCurrency
	String_t* ___VirtualCurrency_5;

public:
	inline static int32_t get_offset_of_CatalogVersion_0() { return static_cast<int32_t>(offsetof(PurchaseItemRequest_t446597288, ___CatalogVersion_0)); }
	inline String_t* get_CatalogVersion_0() const { return ___CatalogVersion_0; }
	inline String_t** get_address_of_CatalogVersion_0() { return &___CatalogVersion_0; }
	inline void set_CatalogVersion_0(String_t* value)
	{
		___CatalogVersion_0 = value;
		Il2CppCodeGenWriteBarrier((&___CatalogVersion_0), value);
	}

	inline static int32_t get_offset_of_CharacterId_1() { return static_cast<int32_t>(offsetof(PurchaseItemRequest_t446597288, ___CharacterId_1)); }
	inline String_t* get_CharacterId_1() const { return ___CharacterId_1; }
	inline String_t** get_address_of_CharacterId_1() { return &___CharacterId_1; }
	inline void set_CharacterId_1(String_t* value)
	{
		___CharacterId_1 = value;
		Il2CppCodeGenWriteBarrier((&___CharacterId_1), value);
	}

	inline static int32_t get_offset_of_ItemId_2() { return static_cast<int32_t>(offsetof(PurchaseItemRequest_t446597288, ___ItemId_2)); }
	inline String_t* get_ItemId_2() const { return ___ItemId_2; }
	inline String_t** get_address_of_ItemId_2() { return &___ItemId_2; }
	inline void set_ItemId_2(String_t* value)
	{
		___ItemId_2 = value;
		Il2CppCodeGenWriteBarrier((&___ItemId_2), value);
	}

	inline static int32_t get_offset_of_Price_3() { return static_cast<int32_t>(offsetof(PurchaseItemRequest_t446597288, ___Price_3)); }
	inline int32_t get_Price_3() const { return ___Price_3; }
	inline int32_t* get_address_of_Price_3() { return &___Price_3; }
	inline void set_Price_3(int32_t value)
	{
		___Price_3 = value;
	}

	inline static int32_t get_offset_of_StoreId_4() { return static_cast<int32_t>(offsetof(PurchaseItemRequest_t446597288, ___StoreId_4)); }
	inline String_t* get_StoreId_4() const { return ___StoreId_4; }
	inline String_t** get_address_of_StoreId_4() { return &___StoreId_4; }
	inline void set_StoreId_4(String_t* value)
	{
		___StoreId_4 = value;
		Il2CppCodeGenWriteBarrier((&___StoreId_4), value);
	}

	inline static int32_t get_offset_of_VirtualCurrency_5() { return static_cast<int32_t>(offsetof(PurchaseItemRequest_t446597288, ___VirtualCurrency_5)); }
	inline String_t* get_VirtualCurrency_5() const { return ___VirtualCurrency_5; }
	inline String_t** get_address_of_VirtualCurrency_5() { return &___VirtualCurrency_5; }
	inline void set_VirtualCurrency_5(String_t* value)
	{
		___VirtualCurrency_5 = value;
		Il2CppCodeGenWriteBarrier((&___VirtualCurrency_5), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // PURCHASEITEMREQUEST_T446597288_H
#ifndef REMOVESHAREDGROUPMEMBERSREQUEST_T3650533269_H
#define REMOVESHAREDGROUPMEMBERSREQUEST_T3650533269_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.RemoveSharedGroupMembersRequest
struct  RemoveSharedGroupMembersRequest_t3650533269  : public PlayFabRequestCommon_t229319069
{
public:
	// System.Collections.Generic.List`1<System.String> PlayFab.ClientModels.RemoveSharedGroupMembersRequest::PlayFabIds
	List_1_t3319525431 * ___PlayFabIds_0;
	// System.String PlayFab.ClientModels.RemoveSharedGroupMembersRequest::SharedGroupId
	String_t* ___SharedGroupId_1;

public:
	inline static int32_t get_offset_of_PlayFabIds_0() { return static_cast<int32_t>(offsetof(RemoveSharedGroupMembersRequest_t3650533269, ___PlayFabIds_0)); }
	inline List_1_t3319525431 * get_PlayFabIds_0() const { return ___PlayFabIds_0; }
	inline List_1_t3319525431 ** get_address_of_PlayFabIds_0() { return &___PlayFabIds_0; }
	inline void set_PlayFabIds_0(List_1_t3319525431 * value)
	{
		___PlayFabIds_0 = value;
		Il2CppCodeGenWriteBarrier((&___PlayFabIds_0), value);
	}

	inline static int32_t get_offset_of_SharedGroupId_1() { return static_cast<int32_t>(offsetof(RemoveSharedGroupMembersRequest_t3650533269, ___SharedGroupId_1)); }
	inline String_t* get_SharedGroupId_1() const { return ___SharedGroupId_1; }
	inline String_t** get_address_of_SharedGroupId_1() { return &___SharedGroupId_1; }
	inline void set_SharedGroupId_1(String_t* value)
	{
		___SharedGroupId_1 = value;
		Il2CppCodeGenWriteBarrier((&___SharedGroupId_1), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // REMOVESHAREDGROUPMEMBERSREQUEST_T3650533269_H
#ifndef OPENTRADEREQUEST_T11547462_H
#define OPENTRADEREQUEST_T11547462_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.OpenTradeRequest
struct  OpenTradeRequest_t11547462  : public PlayFabRequestCommon_t229319069
{
public:
	// System.Collections.Generic.List`1<System.String> PlayFab.ClientModels.OpenTradeRequest::AllowedPlayerIds
	List_1_t3319525431 * ___AllowedPlayerIds_0;
	// System.Collections.Generic.List`1<System.String> PlayFab.ClientModels.OpenTradeRequest::OfferedInventoryInstanceIds
	List_1_t3319525431 * ___OfferedInventoryInstanceIds_1;
	// System.Collections.Generic.List`1<System.String> PlayFab.ClientModels.OpenTradeRequest::RequestedCatalogItemIds
	List_1_t3319525431 * ___RequestedCatalogItemIds_2;

public:
	inline static int32_t get_offset_of_AllowedPlayerIds_0() { return static_cast<int32_t>(offsetof(OpenTradeRequest_t11547462, ___AllowedPlayerIds_0)); }
	inline List_1_t3319525431 * get_AllowedPlayerIds_0() const { return ___AllowedPlayerIds_0; }
	inline List_1_t3319525431 ** get_address_of_AllowedPlayerIds_0() { return &___AllowedPlayerIds_0; }
	inline void set_AllowedPlayerIds_0(List_1_t3319525431 * value)
	{
		___AllowedPlayerIds_0 = value;
		Il2CppCodeGenWriteBarrier((&___AllowedPlayerIds_0), value);
	}

	inline static int32_t get_offset_of_OfferedInventoryInstanceIds_1() { return static_cast<int32_t>(offsetof(OpenTradeRequest_t11547462, ___OfferedInventoryInstanceIds_1)); }
	inline List_1_t3319525431 * get_OfferedInventoryInstanceIds_1() const { return ___OfferedInventoryInstanceIds_1; }
	inline List_1_t3319525431 ** get_address_of_OfferedInventoryInstanceIds_1() { return &___OfferedInventoryInstanceIds_1; }
	inline void set_OfferedInventoryInstanceIds_1(List_1_t3319525431 * value)
	{
		___OfferedInventoryInstanceIds_1 = value;
		Il2CppCodeGenWriteBarrier((&___OfferedInventoryInstanceIds_1), value);
	}

	inline static int32_t get_offset_of_RequestedCatalogItemIds_2() { return static_cast<int32_t>(offsetof(OpenTradeRequest_t11547462, ___RequestedCatalogItemIds_2)); }
	inline List_1_t3319525431 * get_RequestedCatalogItemIds_2() const { return ___RequestedCatalogItemIds_2; }
	inline List_1_t3319525431 ** get_address_of_RequestedCatalogItemIds_2() { return &___RequestedCatalogItemIds_2; }
	inline void set_RequestedCatalogItemIds_2(List_1_t3319525431 * value)
	{
		___RequestedCatalogItemIds_2 = value;
		Il2CppCodeGenWriteBarrier((&___RequestedCatalogItemIds_2), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // OPENTRADEREQUEST_T11547462_H
#ifndef REMOVEFRIENDRESULT_T1519141523_H
#define REMOVEFRIENDRESULT_T1519141523_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.RemoveFriendResult
struct  RemoveFriendResult_t1519141523  : public PlayFabResultCommon_t3469603827
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // REMOVEFRIENDRESULT_T1519141523_H
#ifndef MODIFYUSERVIRTUALCURRENCYRESULT_T2341190276_H
#define MODIFYUSERVIRTUALCURRENCYRESULT_T2341190276_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.ModifyUserVirtualCurrencyResult
struct  ModifyUserVirtualCurrencyResult_t2341190276  : public PlayFabResultCommon_t3469603827
{
public:
	// System.Int32 PlayFab.ClientModels.ModifyUserVirtualCurrencyResult::Balance
	int32_t ___Balance_2;
	// System.Int32 PlayFab.ClientModels.ModifyUserVirtualCurrencyResult::BalanceChange
	int32_t ___BalanceChange_3;
	// System.String PlayFab.ClientModels.ModifyUserVirtualCurrencyResult::PlayFabId
	String_t* ___PlayFabId_4;
	// System.String PlayFab.ClientModels.ModifyUserVirtualCurrencyResult::VirtualCurrency
	String_t* ___VirtualCurrency_5;

public:
	inline static int32_t get_offset_of_Balance_2() { return static_cast<int32_t>(offsetof(ModifyUserVirtualCurrencyResult_t2341190276, ___Balance_2)); }
	inline int32_t get_Balance_2() const { return ___Balance_2; }
	inline int32_t* get_address_of_Balance_2() { return &___Balance_2; }
	inline void set_Balance_2(int32_t value)
	{
		___Balance_2 = value;
	}

	inline static int32_t get_offset_of_BalanceChange_3() { return static_cast<int32_t>(offsetof(ModifyUserVirtualCurrencyResult_t2341190276, ___BalanceChange_3)); }
	inline int32_t get_BalanceChange_3() const { return ___BalanceChange_3; }
	inline int32_t* get_address_of_BalanceChange_3() { return &___BalanceChange_3; }
	inline void set_BalanceChange_3(int32_t value)
	{
		___BalanceChange_3 = value;
	}

	inline static int32_t get_offset_of_PlayFabId_4() { return static_cast<int32_t>(offsetof(ModifyUserVirtualCurrencyResult_t2341190276, ___PlayFabId_4)); }
	inline String_t* get_PlayFabId_4() const { return ___PlayFabId_4; }
	inline String_t** get_address_of_PlayFabId_4() { return &___PlayFabId_4; }
	inline void set_PlayFabId_4(String_t* value)
	{
		___PlayFabId_4 = value;
		Il2CppCodeGenWriteBarrier((&___PlayFabId_4), value);
	}

	inline static int32_t get_offset_of_VirtualCurrency_5() { return static_cast<int32_t>(offsetof(ModifyUserVirtualCurrencyResult_t2341190276, ___VirtualCurrency_5)); }
	inline String_t* get_VirtualCurrency_5() const { return ___VirtualCurrency_5; }
	inline String_t** get_address_of_VirtualCurrency_5() { return &___VirtualCurrency_5; }
	inline void set_VirtualCurrency_5(String_t* value)
	{
		___VirtualCurrency_5 = value;
		Il2CppCodeGenWriteBarrier((&___VirtualCurrency_5), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // MODIFYUSERVIRTUALCURRENCYRESULT_T2341190276_H
#ifndef OPENTRADERESPONSE_T2601250367_H
#define OPENTRADERESPONSE_T2601250367_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.OpenTradeResponse
struct  OpenTradeResponse_t2601250367  : public PlayFabResultCommon_t3469603827
{
public:
	// PlayFab.ClientModels.TradeInfo PlayFab.ClientModels.OpenTradeResponse::Trade
	TradeInfo_t4070927481 * ___Trade_2;

public:
	inline static int32_t get_offset_of_Trade_2() { return static_cast<int32_t>(offsetof(OpenTradeResponse_t2601250367, ___Trade_2)); }
	inline TradeInfo_t4070927481 * get_Trade_2() const { return ___Trade_2; }
	inline TradeInfo_t4070927481 ** get_address_of_Trade_2() { return &___Trade_2; }
	inline void set_Trade_2(TradeInfo_t4070927481 * value)
	{
		___Trade_2 = value;
		Il2CppCodeGenWriteBarrier((&___Trade_2), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // OPENTRADERESPONSE_T2601250367_H
#ifndef REDEEMCOUPONRESULT_T4207086596_H
#define REDEEMCOUPONRESULT_T4207086596_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.RedeemCouponResult
struct  RedeemCouponResult_t4207086596  : public PlayFabResultCommon_t3469603827
{
public:
	// System.Collections.Generic.List`1<PlayFab.ClientModels.ItemInstance> PlayFab.ClientModels.RedeemCouponResult::GrantedItems
	List_1_t898730215 * ___GrantedItems_2;

public:
	inline static int32_t get_offset_of_GrantedItems_2() { return static_cast<int32_t>(offsetof(RedeemCouponResult_t4207086596, ___GrantedItems_2)); }
	inline List_1_t898730215 * get_GrantedItems_2() const { return ___GrantedItems_2; }
	inline List_1_t898730215 ** get_address_of_GrantedItems_2() { return &___GrantedItems_2; }
	inline void set_GrantedItems_2(List_1_t898730215 * value)
	{
		___GrantedItems_2 = value;
		Il2CppCodeGenWriteBarrier((&___GrantedItems_2), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // REDEEMCOUPONRESULT_T4207086596_H
#ifndef REPORTPLAYERCLIENTREQUEST_T2988748114_H
#define REPORTPLAYERCLIENTREQUEST_T2988748114_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.ReportPlayerClientRequest
struct  ReportPlayerClientRequest_t2988748114  : public PlayFabRequestCommon_t229319069
{
public:
	// System.String PlayFab.ClientModels.ReportPlayerClientRequest::Comment
	String_t* ___Comment_0;
	// System.String PlayFab.ClientModels.ReportPlayerClientRequest::ReporteeId
	String_t* ___ReporteeId_1;

public:
	inline static int32_t get_offset_of_Comment_0() { return static_cast<int32_t>(offsetof(ReportPlayerClientRequest_t2988748114, ___Comment_0)); }
	inline String_t* get_Comment_0() const { return ___Comment_0; }
	inline String_t** get_address_of_Comment_0() { return &___Comment_0; }
	inline void set_Comment_0(String_t* value)
	{
		___Comment_0 = value;
		Il2CppCodeGenWriteBarrier((&___Comment_0), value);
	}

	inline static int32_t get_offset_of_ReporteeId_1() { return static_cast<int32_t>(offsetof(ReportPlayerClientRequest_t2988748114, ___ReporteeId_1)); }
	inline String_t* get_ReporteeId_1() const { return ___ReporteeId_1; }
	inline String_t** get_address_of_ReporteeId_1() { return &___ReporteeId_1; }
	inline void set_ReporteeId_1(String_t* value)
	{
		___ReporteeId_1 = value;
		Il2CppCodeGenWriteBarrier((&___ReporteeId_1), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // REPORTPLAYERCLIENTREQUEST_T2988748114_H
#ifndef PAYFORPURCHASEREQUEST_T2615822629_H
#define PAYFORPURCHASEREQUEST_T2615822629_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.PayForPurchaseRequest
struct  PayForPurchaseRequest_t2615822629  : public PlayFabRequestCommon_t229319069
{
public:
	// System.String PlayFab.ClientModels.PayForPurchaseRequest::Currency
	String_t* ___Currency_0;
	// System.String PlayFab.ClientModels.PayForPurchaseRequest::OrderId
	String_t* ___OrderId_1;
	// System.String PlayFab.ClientModels.PayForPurchaseRequest::ProviderName
	String_t* ___ProviderName_2;
	// System.String PlayFab.ClientModels.PayForPurchaseRequest::ProviderTransactionId
	String_t* ___ProviderTransactionId_3;

public:
	inline static int32_t get_offset_of_Currency_0() { return static_cast<int32_t>(offsetof(PayForPurchaseRequest_t2615822629, ___Currency_0)); }
	inline String_t* get_Currency_0() const { return ___Currency_0; }
	inline String_t** get_address_of_Currency_0() { return &___Currency_0; }
	inline void set_Currency_0(String_t* value)
	{
		___Currency_0 = value;
		Il2CppCodeGenWriteBarrier((&___Currency_0), value);
	}

	inline static int32_t get_offset_of_OrderId_1() { return static_cast<int32_t>(offsetof(PayForPurchaseRequest_t2615822629, ___OrderId_1)); }
	inline String_t* get_OrderId_1() const { return ___OrderId_1; }
	inline String_t** get_address_of_OrderId_1() { return &___OrderId_1; }
	inline void set_OrderId_1(String_t* value)
	{
		___OrderId_1 = value;
		Il2CppCodeGenWriteBarrier((&___OrderId_1), value);
	}

	inline static int32_t get_offset_of_ProviderName_2() { return static_cast<int32_t>(offsetof(PayForPurchaseRequest_t2615822629, ___ProviderName_2)); }
	inline String_t* get_ProviderName_2() const { return ___ProviderName_2; }
	inline String_t** get_address_of_ProviderName_2() { return &___ProviderName_2; }
	inline void set_ProviderName_2(String_t* value)
	{
		___ProviderName_2 = value;
		Il2CppCodeGenWriteBarrier((&___ProviderName_2), value);
	}

	inline static int32_t get_offset_of_ProviderTransactionId_3() { return static_cast<int32_t>(offsetof(PayForPurchaseRequest_t2615822629, ___ProviderTransactionId_3)); }
	inline String_t* get_ProviderTransactionId_3() const { return ___ProviderTransactionId_3; }
	inline String_t** get_address_of_ProviderTransactionId_3() { return &___ProviderTransactionId_3; }
	inline void set_ProviderTransactionId_3(String_t* value)
	{
		___ProviderTransactionId_3 = value;
		Il2CppCodeGenWriteBarrier((&___ProviderTransactionId_3), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // PAYFORPURCHASEREQUEST_T2615822629_H
#ifndef NULLABLE_1_T4282624060_H
#define NULLABLE_1_T4282624060_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Nullable`1<System.UInt32>
struct  Nullable_1_t4282624060 
{
public:
	// T System.Nullable`1::value
	uint32_t ___value_0;
	// System.Boolean System.Nullable`1::has_value
	bool ___has_value_1;

public:
	inline static int32_t get_offset_of_value_0() { return static_cast<int32_t>(offsetof(Nullable_1_t4282624060, ___value_0)); }
	inline uint32_t get_value_0() const { return ___value_0; }
	inline uint32_t* get_address_of_value_0() { return &___value_0; }
	inline void set_value_0(uint32_t value)
	{
		___value_0 = value;
	}

	inline static int32_t get_offset_of_has_value_1() { return static_cast<int32_t>(offsetof(Nullable_1_t4282624060, ___has_value_1)); }
	inline bool get_has_value_1() const { return ___has_value_1; }
	inline bool* get_address_of_has_value_1() { return &___has_value_1; }
	inline void set_has_value_1(bool value)
	{
		___has_value_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // NULLABLE_1_T4282624060_H
#ifndef LINKGOOGLEACCOUNTRESULT_T1807689001_H
#define LINKGOOGLEACCOUNTRESULT_T1807689001_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.LinkGoogleAccountResult
struct  LinkGoogleAccountResult_t1807689001  : public PlayFabResultCommon_t3469603827
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LINKGOOGLEACCOUNTRESULT_T1807689001_H
#ifndef LINKGAMECENTERACCOUNTRESULT_T1522738593_H
#define LINKGAMECENTERACCOUNTRESULT_T1522738593_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.LinkGameCenterAccountResult
struct  LinkGameCenterAccountResult_t1522738593  : public PlayFabResultCommon_t3469603827
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LINKGAMECENTERACCOUNTRESULT_T1522738593_H
#ifndef LINKKONGREGATEACCOUNTRESULT_T2275718960_H
#define LINKKONGREGATEACCOUNTRESULT_T2275718960_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.LinkKongregateAccountResult
struct  LinkKongregateAccountResult_t2275718960  : public PlayFabResultCommon_t3469603827
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LINKKONGREGATEACCOUNTRESULT_T2275718960_H
#ifndef ENUM_T4135868527_H
#define ENUM_T4135868527_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Enum
struct  Enum_t4135868527  : public ValueType_t3640485471
{
public:

public:
};

struct Enum_t4135868527_StaticFields
{
public:
	// System.Char[] System.Enum::split_char
	CharU5BU5D_t3528271667* ___split_char_0;

public:
	inline static int32_t get_offset_of_split_char_0() { return static_cast<int32_t>(offsetof(Enum_t4135868527_StaticFields, ___split_char_0)); }
	inline CharU5BU5D_t3528271667* get_split_char_0() const { return ___split_char_0; }
	inline CharU5BU5D_t3528271667** get_address_of_split_char_0() { return &___split_char_0; }
	inline void set_split_char_0(CharU5BU5D_t3528271667* value)
	{
		___split_char_0 = value;
		Il2CppCodeGenWriteBarrier((&___split_char_0), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of System.Enum
struct Enum_t4135868527_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.Enum
struct Enum_t4135868527_marshaled_com
{
};
#endif // ENUM_T4135868527_H
#ifndef LINKIOSDEVICEIDRESULT_T3891870534_H
#define LINKIOSDEVICEIDRESULT_T3891870534_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.LinkIOSDeviceIDResult
struct  LinkIOSDeviceIDResult_t3891870534  : public PlayFabResultCommon_t3469603827
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LINKIOSDEVICEIDRESULT_T3891870534_H
#ifndef LINKFACEBOOKACCOUNTRESULT_T3882480540_H
#define LINKFACEBOOKACCOUNTRESULT_T3882480540_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.LinkFacebookAccountResult
struct  LinkFacebookAccountResult_t3882480540  : public PlayFabResultCommon_t3469603827
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LINKFACEBOOKACCOUNTRESULT_T3882480540_H
#ifndef ITEMPURCHASEREQUEST_T2333686997_H
#define ITEMPURCHASEREQUEST_T2333686997_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.ItemPurchaseRequest
struct  ItemPurchaseRequest_t2333686997  : public PlayFabRequestCommon_t229319069
{
public:
	// System.String PlayFab.ClientModels.ItemPurchaseRequest::Annotation
	String_t* ___Annotation_0;
	// System.String PlayFab.ClientModels.ItemPurchaseRequest::ItemId
	String_t* ___ItemId_1;
	// System.UInt32 PlayFab.ClientModels.ItemPurchaseRequest::Quantity
	uint32_t ___Quantity_2;
	// System.Collections.Generic.List`1<System.String> PlayFab.ClientModels.ItemPurchaseRequest::UpgradeFromItems
	List_1_t3319525431 * ___UpgradeFromItems_3;

public:
	inline static int32_t get_offset_of_Annotation_0() { return static_cast<int32_t>(offsetof(ItemPurchaseRequest_t2333686997, ___Annotation_0)); }
	inline String_t* get_Annotation_0() const { return ___Annotation_0; }
	inline String_t** get_address_of_Annotation_0() { return &___Annotation_0; }
	inline void set_Annotation_0(String_t* value)
	{
		___Annotation_0 = value;
		Il2CppCodeGenWriteBarrier((&___Annotation_0), value);
	}

	inline static int32_t get_offset_of_ItemId_1() { return static_cast<int32_t>(offsetof(ItemPurchaseRequest_t2333686997, ___ItemId_1)); }
	inline String_t* get_ItemId_1() const { return ___ItemId_1; }
	inline String_t** get_address_of_ItemId_1() { return &___ItemId_1; }
	inline void set_ItemId_1(String_t* value)
	{
		___ItemId_1 = value;
		Il2CppCodeGenWriteBarrier((&___ItemId_1), value);
	}

	inline static int32_t get_offset_of_Quantity_2() { return static_cast<int32_t>(offsetof(ItemPurchaseRequest_t2333686997, ___Quantity_2)); }
	inline uint32_t get_Quantity_2() const { return ___Quantity_2; }
	inline uint32_t* get_address_of_Quantity_2() { return &___Quantity_2; }
	inline void set_Quantity_2(uint32_t value)
	{
		___Quantity_2 = value;
	}

	inline static int32_t get_offset_of_UpgradeFromItems_3() { return static_cast<int32_t>(offsetof(ItemPurchaseRequest_t2333686997, ___UpgradeFromItems_3)); }
	inline List_1_t3319525431 * get_UpgradeFromItems_3() const { return ___UpgradeFromItems_3; }
	inline List_1_t3319525431 ** get_address_of_UpgradeFromItems_3() { return &___UpgradeFromItems_3; }
	inline void set_UpgradeFromItems_3(List_1_t3319525431 * value)
	{
		___UpgradeFromItems_3 = value;
		Il2CppCodeGenWriteBarrier((&___UpgradeFromItems_3), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ITEMPURCHASEREQUEST_T2333686997_H
#ifndef GRANTCHARACTERTOUSERRESULT_T2109757427_H
#define GRANTCHARACTERTOUSERRESULT_T2109757427_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.GrantCharacterToUserResult
struct  GrantCharacterToUserResult_t2109757427  : public PlayFabResultCommon_t3469603827
{
public:
	// System.String PlayFab.ClientModels.GrantCharacterToUserResult::CharacterId
	String_t* ___CharacterId_2;
	// System.String PlayFab.ClientModels.GrantCharacterToUserResult::CharacterType
	String_t* ___CharacterType_3;
	// System.Boolean PlayFab.ClientModels.GrantCharacterToUserResult::Result
	bool ___Result_4;

public:
	inline static int32_t get_offset_of_CharacterId_2() { return static_cast<int32_t>(offsetof(GrantCharacterToUserResult_t2109757427, ___CharacterId_2)); }
	inline String_t* get_CharacterId_2() const { return ___CharacterId_2; }
	inline String_t** get_address_of_CharacterId_2() { return &___CharacterId_2; }
	inline void set_CharacterId_2(String_t* value)
	{
		___CharacterId_2 = value;
		Il2CppCodeGenWriteBarrier((&___CharacterId_2), value);
	}

	inline static int32_t get_offset_of_CharacterType_3() { return static_cast<int32_t>(offsetof(GrantCharacterToUserResult_t2109757427, ___CharacterType_3)); }
	inline String_t* get_CharacterType_3() const { return ___CharacterType_3; }
	inline String_t** get_address_of_CharacterType_3() { return &___CharacterType_3; }
	inline void set_CharacterType_3(String_t* value)
	{
		___CharacterType_3 = value;
		Il2CppCodeGenWriteBarrier((&___CharacterType_3), value);
	}

	inline static int32_t get_offset_of_Result_4() { return static_cast<int32_t>(offsetof(GrantCharacterToUserResult_t2109757427, ___Result_4)); }
	inline bool get_Result_4() const { return ___Result_4; }
	inline bool* get_address_of_Result_4() { return &___Result_4; }
	inline void set_Result_4(bool value)
	{
		___Result_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // GRANTCHARACTERTOUSERRESULT_T2109757427_H
#ifndef GRANTCHARACTERTOUSERREQUEST_T2936922968_H
#define GRANTCHARACTERTOUSERREQUEST_T2936922968_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.GrantCharacterToUserRequest
struct  GrantCharacterToUserRequest_t2936922968  : public PlayFabRequestCommon_t229319069
{
public:
	// System.String PlayFab.ClientModels.GrantCharacterToUserRequest::CatalogVersion
	String_t* ___CatalogVersion_0;
	// System.String PlayFab.ClientModels.GrantCharacterToUserRequest::CharacterName
	String_t* ___CharacterName_1;
	// System.String PlayFab.ClientModels.GrantCharacterToUserRequest::ItemId
	String_t* ___ItemId_2;

public:
	inline static int32_t get_offset_of_CatalogVersion_0() { return static_cast<int32_t>(offsetof(GrantCharacterToUserRequest_t2936922968, ___CatalogVersion_0)); }
	inline String_t* get_CatalogVersion_0() const { return ___CatalogVersion_0; }
	inline String_t** get_address_of_CatalogVersion_0() { return &___CatalogVersion_0; }
	inline void set_CatalogVersion_0(String_t* value)
	{
		___CatalogVersion_0 = value;
		Il2CppCodeGenWriteBarrier((&___CatalogVersion_0), value);
	}

	inline static int32_t get_offset_of_CharacterName_1() { return static_cast<int32_t>(offsetof(GrantCharacterToUserRequest_t2936922968, ___CharacterName_1)); }
	inline String_t* get_CharacterName_1() const { return ___CharacterName_1; }
	inline String_t** get_address_of_CharacterName_1() { return &___CharacterName_1; }
	inline void set_CharacterName_1(String_t* value)
	{
		___CharacterName_1 = value;
		Il2CppCodeGenWriteBarrier((&___CharacterName_1), value);
	}

	inline static int32_t get_offset_of_ItemId_2() { return static_cast<int32_t>(offsetof(GrantCharacterToUserRequest_t2936922968, ___ItemId_2)); }
	inline String_t* get_ItemId_2() const { return ___ItemId_2; }
	inline String_t** get_address_of_ItemId_2() { return &___ItemId_2; }
	inline void set_ItemId_2(String_t* value)
	{
		___ItemId_2 = value;
		Il2CppCodeGenWriteBarrier((&___ItemId_2), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // GRANTCHARACTERTOUSERREQUEST_T2936922968_H
#ifndef TIMESPAN_T881159249_H
#define TIMESPAN_T881159249_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.TimeSpan
struct  TimeSpan_t881159249 
{
public:
	// System.Int64 System.TimeSpan::_ticks
	int64_t ____ticks_8;

public:
	inline static int32_t get_offset_of__ticks_8() { return static_cast<int32_t>(offsetof(TimeSpan_t881159249, ____ticks_8)); }
	inline int64_t get__ticks_8() const { return ____ticks_8; }
	inline int64_t* get_address_of__ticks_8() { return &____ticks_8; }
	inline void set__ticks_8(int64_t value)
	{
		____ticks_8 = value;
	}
};

struct TimeSpan_t881159249_StaticFields
{
public:
	// System.TimeSpan System.TimeSpan::MaxValue
	TimeSpan_t881159249  ___MaxValue_5;
	// System.TimeSpan System.TimeSpan::MinValue
	TimeSpan_t881159249  ___MinValue_6;
	// System.TimeSpan System.TimeSpan::Zero
	TimeSpan_t881159249  ___Zero_7;

public:
	inline static int32_t get_offset_of_MaxValue_5() { return static_cast<int32_t>(offsetof(TimeSpan_t881159249_StaticFields, ___MaxValue_5)); }
	inline TimeSpan_t881159249  get_MaxValue_5() const { return ___MaxValue_5; }
	inline TimeSpan_t881159249 * get_address_of_MaxValue_5() { return &___MaxValue_5; }
	inline void set_MaxValue_5(TimeSpan_t881159249  value)
	{
		___MaxValue_5 = value;
	}

	inline static int32_t get_offset_of_MinValue_6() { return static_cast<int32_t>(offsetof(TimeSpan_t881159249_StaticFields, ___MinValue_6)); }
	inline TimeSpan_t881159249  get_MinValue_6() const { return ___MinValue_6; }
	inline TimeSpan_t881159249 * get_address_of_MinValue_6() { return &___MinValue_6; }
	inline void set_MinValue_6(TimeSpan_t881159249  value)
	{
		___MinValue_6 = value;
	}

	inline static int32_t get_offset_of_Zero_7() { return static_cast<int32_t>(offsetof(TimeSpan_t881159249_StaticFields, ___Zero_7)); }
	inline TimeSpan_t881159249  get_Zero_7() const { return ___Zero_7; }
	inline TimeSpan_t881159249 * get_address_of_Zero_7() { return &___Zero_7; }
	inline void set_Zero_7(TimeSpan_t881159249  value)
	{
		___Zero_7 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TIMESPAN_T881159249_H
#ifndef LINKCUSTOMIDRESULT_T139981749_H
#define LINKCUSTOMIDRESULT_T139981749_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.LinkCustomIDResult
struct  LinkCustomIDResult_t139981749  : public PlayFabResultCommon_t3469603827
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LINKCUSTOMIDRESULT_T139981749_H
#ifndef LINKANDROIDDEVICEIDRESULT_T552766912_H
#define LINKANDROIDDEVICEIDRESULT_T552766912_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.LinkAndroidDeviceIDResult
struct  LinkAndroidDeviceIDResult_t552766912  : public PlayFabResultCommon_t3469603827
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LINKANDROIDDEVICEIDRESULT_T552766912_H
#ifndef NULLABLE_1_T2317227445_H
#define NULLABLE_1_T2317227445_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Nullable`1<System.Double>
struct  Nullable_1_t2317227445 
{
public:
	// T System.Nullable`1::value
	double ___value_0;
	// System.Boolean System.Nullable`1::has_value
	bool ___has_value_1;

public:
	inline static int32_t get_offset_of_value_0() { return static_cast<int32_t>(offsetof(Nullable_1_t2317227445, ___value_0)); }
	inline double get_value_0() const { return ___value_0; }
	inline double* get_address_of_value_0() { return &___value_0; }
	inline void set_value_0(double value)
	{
		___value_0 = value;
	}

	inline static int32_t get_offset_of_has_value_1() { return static_cast<int32_t>(offsetof(Nullable_1_t2317227445, ___has_value_1)); }
	inline bool get_has_value_1() const { return ___has_value_1; }
	inline bool* get_address_of_has_value_1() { return &___has_value_1; }
	inline void set_has_value_1(bool value)
	{
		___has_value_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // NULLABLE_1_T2317227445_H
#ifndef SETPLAYERSECRETREQUEST_T226361414_H
#define SETPLAYERSECRETREQUEST_T226361414_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.SetPlayerSecretRequest
struct  SetPlayerSecretRequest_t226361414  : public PlayFabRequestCommon_t229319069
{
public:
	// System.String PlayFab.ClientModels.SetPlayerSecretRequest::EncryptedRequest
	String_t* ___EncryptedRequest_0;
	// System.String PlayFab.ClientModels.SetPlayerSecretRequest::PlayerSecret
	String_t* ___PlayerSecret_1;

public:
	inline static int32_t get_offset_of_EncryptedRequest_0() { return static_cast<int32_t>(offsetof(SetPlayerSecretRequest_t226361414, ___EncryptedRequest_0)); }
	inline String_t* get_EncryptedRequest_0() const { return ___EncryptedRequest_0; }
	inline String_t** get_address_of_EncryptedRequest_0() { return &___EncryptedRequest_0; }
	inline void set_EncryptedRequest_0(String_t* value)
	{
		___EncryptedRequest_0 = value;
		Il2CppCodeGenWriteBarrier((&___EncryptedRequest_0), value);
	}

	inline static int32_t get_offset_of_PlayerSecret_1() { return static_cast<int32_t>(offsetof(SetPlayerSecretRequest_t226361414, ___PlayerSecret_1)); }
	inline String_t* get_PlayerSecret_1() const { return ___PlayerSecret_1; }
	inline String_t** get_address_of_PlayerSecret_1() { return &___PlayerSecret_1; }
	inline void set_PlayerSecret_1(String_t* value)
	{
		___PlayerSecret_1 = value;
		Il2CppCodeGenWriteBarrier((&___PlayerSecret_1), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SETPLAYERSECRETREQUEST_T226361414_H
#ifndef LISTUSERSCHARACTERSRESULT_T1440701948_H
#define LISTUSERSCHARACTERSRESULT_T1440701948_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.ListUsersCharactersResult
struct  ListUsersCharactersResult_t1440701948  : public PlayFabResultCommon_t3469603827
{
public:
	// System.Collections.Generic.List`1<PlayFab.ClientModels.CharacterResult> PlayFab.ClientModels.ListUsersCharactersResult::Characters
	List_1_t870886602 * ___Characters_2;

public:
	inline static int32_t get_offset_of_Characters_2() { return static_cast<int32_t>(offsetof(ListUsersCharactersResult_t1440701948, ___Characters_2)); }
	inline List_1_t870886602 * get_Characters_2() const { return ___Characters_2; }
	inline List_1_t870886602 ** get_address_of_Characters_2() { return &___Characters_2; }
	inline void set_Characters_2(List_1_t870886602 * value)
	{
		___Characters_2 = value;
		Il2CppCodeGenWriteBarrier((&___Characters_2), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LISTUSERSCHARACTERSRESULT_T1440701948_H
#ifndef STARTPURCHASERESULT_T322616865_H
#define STARTPURCHASERESULT_T322616865_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.StartPurchaseResult
struct  StartPurchaseResult_t322616865  : public PlayFabResultCommon_t3469603827
{
public:
	// System.Collections.Generic.List`1<PlayFab.ClientModels.CartItem> PlayFab.ClientModels.StartPurchaseResult::Contents
	List_1_t2141460274 * ___Contents_2;
	// System.String PlayFab.ClientModels.StartPurchaseResult::OrderId
	String_t* ___OrderId_3;
	// System.Collections.Generic.List`1<PlayFab.ClientModels.PaymentOption> PlayFab.ClientModels.StartPurchaseResult::PaymentOptions
	List_1_t2421373131 * ___PaymentOptions_4;
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> PlayFab.ClientModels.StartPurchaseResult::VirtualCurrencyBalances
	Dictionary_2_t2736202052 * ___VirtualCurrencyBalances_5;

public:
	inline static int32_t get_offset_of_Contents_2() { return static_cast<int32_t>(offsetof(StartPurchaseResult_t322616865, ___Contents_2)); }
	inline List_1_t2141460274 * get_Contents_2() const { return ___Contents_2; }
	inline List_1_t2141460274 ** get_address_of_Contents_2() { return &___Contents_2; }
	inline void set_Contents_2(List_1_t2141460274 * value)
	{
		___Contents_2 = value;
		Il2CppCodeGenWriteBarrier((&___Contents_2), value);
	}

	inline static int32_t get_offset_of_OrderId_3() { return static_cast<int32_t>(offsetof(StartPurchaseResult_t322616865, ___OrderId_3)); }
	inline String_t* get_OrderId_3() const { return ___OrderId_3; }
	inline String_t** get_address_of_OrderId_3() { return &___OrderId_3; }
	inline void set_OrderId_3(String_t* value)
	{
		___OrderId_3 = value;
		Il2CppCodeGenWriteBarrier((&___OrderId_3), value);
	}

	inline static int32_t get_offset_of_PaymentOptions_4() { return static_cast<int32_t>(offsetof(StartPurchaseResult_t322616865, ___PaymentOptions_4)); }
	inline List_1_t2421373131 * get_PaymentOptions_4() const { return ___PaymentOptions_4; }
	inline List_1_t2421373131 ** get_address_of_PaymentOptions_4() { return &___PaymentOptions_4; }
	inline void set_PaymentOptions_4(List_1_t2421373131 * value)
	{
		___PaymentOptions_4 = value;
		Il2CppCodeGenWriteBarrier((&___PaymentOptions_4), value);
	}

	inline static int32_t get_offset_of_VirtualCurrencyBalances_5() { return static_cast<int32_t>(offsetof(StartPurchaseResult_t322616865, ___VirtualCurrencyBalances_5)); }
	inline Dictionary_2_t2736202052 * get_VirtualCurrencyBalances_5() const { return ___VirtualCurrencyBalances_5; }
	inline Dictionary_2_t2736202052 ** get_address_of_VirtualCurrencyBalances_5() { return &___VirtualCurrencyBalances_5; }
	inline void set_VirtualCurrencyBalances_5(Dictionary_2_t2736202052 * value)
	{
		___VirtualCurrencyBalances_5 = value;
		Il2CppCodeGenWriteBarrier((&___VirtualCurrencyBalances_5), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // STARTPURCHASERESULT_T322616865_H
#ifndef SETPLAYERSECRETRESULT_T1859896565_H
#define SETPLAYERSECRETRESULT_T1859896565_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.SetPlayerSecretResult
struct  SetPlayerSecretResult_t1859896565  : public PlayFabResultCommon_t3469603827
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SETPLAYERSECRETRESULT_T1859896565_H
#ifndef STARTPURCHASEREQUEST_T1560898140_H
#define STARTPURCHASEREQUEST_T1560898140_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.StartPurchaseRequest
struct  StartPurchaseRequest_t1560898140  : public PlayFabRequestCommon_t229319069
{
public:
	// System.String PlayFab.ClientModels.StartPurchaseRequest::CatalogVersion
	String_t* ___CatalogVersion_0;
	// System.Collections.Generic.List`1<PlayFab.ClientModels.ItemPurchaseRequest> PlayFab.ClientModels.StartPurchaseRequest::Items
	List_1_t3805761739 * ___Items_1;
	// System.String PlayFab.ClientModels.StartPurchaseRequest::StoreId
	String_t* ___StoreId_2;

public:
	inline static int32_t get_offset_of_CatalogVersion_0() { return static_cast<int32_t>(offsetof(StartPurchaseRequest_t1560898140, ___CatalogVersion_0)); }
	inline String_t* get_CatalogVersion_0() const { return ___CatalogVersion_0; }
	inline String_t** get_address_of_CatalogVersion_0() { return &___CatalogVersion_0; }
	inline void set_CatalogVersion_0(String_t* value)
	{
		___CatalogVersion_0 = value;
		Il2CppCodeGenWriteBarrier((&___CatalogVersion_0), value);
	}

	inline static int32_t get_offset_of_Items_1() { return static_cast<int32_t>(offsetof(StartPurchaseRequest_t1560898140, ___Items_1)); }
	inline List_1_t3805761739 * get_Items_1() const { return ___Items_1; }
	inline List_1_t3805761739 ** get_address_of_Items_1() { return &___Items_1; }
	inline void set_Items_1(List_1_t3805761739 * value)
	{
		___Items_1 = value;
		Il2CppCodeGenWriteBarrier((&___Items_1), value);
	}

	inline static int32_t get_offset_of_StoreId_2() { return static_cast<int32_t>(offsetof(StartPurchaseRequest_t1560898140, ___StoreId_2)); }
	inline String_t* get_StoreId_2() const { return ___StoreId_2; }
	inline String_t** get_address_of_StoreId_2() { return &___StoreId_2; }
	inline void set_StoreId_2(String_t* value)
	{
		___StoreId_2 = value;
		Il2CppCodeGenWriteBarrier((&___StoreId_2), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // STARTPURCHASEREQUEST_T1560898140_H
#ifndef LISTUSERSCHARACTERSREQUEST_T1477129616_H
#define LISTUSERSCHARACTERSREQUEST_T1477129616_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.ListUsersCharactersRequest
struct  ListUsersCharactersRequest_t1477129616  : public PlayFabRequestCommon_t229319069
{
public:
	// System.String PlayFab.ClientModels.ListUsersCharactersRequest::PlayFabId
	String_t* ___PlayFabId_0;

public:
	inline static int32_t get_offset_of_PlayFabId_0() { return static_cast<int32_t>(offsetof(ListUsersCharactersRequest_t1477129616, ___PlayFabId_0)); }
	inline String_t* get_PlayFabId_0() const { return ___PlayFabId_0; }
	inline String_t** get_address_of_PlayFabId_0() { return &___PlayFabId_0; }
	inline void set_PlayFabId_0(String_t* value)
	{
		___PlayFabId_0 = value;
		Il2CppCodeGenWriteBarrier((&___PlayFabId_0), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LISTUSERSCHARACTERSREQUEST_T1477129616_H
#ifndef NULLABLE_1_T1819850047_H
#define NULLABLE_1_T1819850047_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Nullable`1<System.Boolean>
struct  Nullable_1_t1819850047 
{
public:
	// T System.Nullable`1::value
	bool ___value_0;
	// System.Boolean System.Nullable`1::has_value
	bool ___has_value_1;

public:
	inline static int32_t get_offset_of_value_0() { return static_cast<int32_t>(offsetof(Nullable_1_t1819850047, ___value_0)); }
	inline bool get_value_0() const { return ___value_0; }
	inline bool* get_address_of_value_0() { return &___value_0; }
	inline void set_value_0(bool value)
	{
		___value_0 = value;
	}

	inline static int32_t get_offset_of_has_value_1() { return static_cast<int32_t>(offsetof(Nullable_1_t1819850047, ___has_value_1)); }
	inline bool get_has_value_1() const { return ___has_value_1; }
	inline bool* get_address_of_has_value_1() { return &___has_value_1; }
	inline void set_has_value_1(bool value)
	{
		___has_value_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // NULLABLE_1_T1819850047_H
#ifndef LINKSTEAMACCOUNTRESULT_T2110373135_H
#define LINKSTEAMACCOUNTRESULT_T2110373135_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.LinkSteamAccountResult
struct  LinkSteamAccountResult_t2110373135  : public PlayFabResultCommon_t3469603827
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LINKSTEAMACCOUNTRESULT_T2110373135_H
#ifndef NULLABLE_1_T378540539_H
#define NULLABLE_1_T378540539_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Nullable`1<System.Int32>
struct  Nullable_1_t378540539 
{
public:
	// T System.Nullable`1::value
	int32_t ___value_0;
	// System.Boolean System.Nullable`1::has_value
	bool ___has_value_1;

public:
	inline static int32_t get_offset_of_value_0() { return static_cast<int32_t>(offsetof(Nullable_1_t378540539, ___value_0)); }
	inline int32_t get_value_0() const { return ___value_0; }
	inline int32_t* get_address_of_value_0() { return &___value_0; }
	inline void set_value_0(int32_t value)
	{
		___value_0 = value;
	}

	inline static int32_t get_offset_of_has_value_1() { return static_cast<int32_t>(offsetof(Nullable_1_t378540539, ___has_value_1)); }
	inline bool get_has_value_1() const { return ___has_value_1; }
	inline bool* get_address_of_has_value_1() { return &___has_value_1; }
	inline void set_has_value_1(bool value)
	{
		___has_value_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // NULLABLE_1_T378540539_H
#ifndef LINKTWITCHACCOUNTRESULT_T4274966282_H
#define LINKTWITCHACCOUNTRESULT_T4274966282_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.LinkTwitchAccountResult
struct  LinkTwitchAccountResult_t4274966282  : public PlayFabResultCommon_t3469603827
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LINKTWITCHACCOUNTRESULT_T4274966282_H
#ifndef LINKWINDOWSHELLOACCOUNTRESPONSE_T3319284420_H
#define LINKWINDOWSHELLOACCOUNTRESPONSE_T3319284420_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.LinkWindowsHelloAccountResponse
struct  LinkWindowsHelloAccountResponse_t3319284420  : public PlayFabResultCommon_t3469603827
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LINKWINDOWSHELLOACCOUNTRESPONSE_T3319284420_H
#ifndef SOURCETYPE_T2721852859_H
#define SOURCETYPE_T2721852859_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.SourceType
struct  SourceType_t2721852859 
{
public:
	// System.Int32 PlayFab.ClientModels.SourceType::value__
	int32_t ___value___1;

public:
	inline static int32_t get_offset_of_value___1() { return static_cast<int32_t>(offsetof(SourceType_t2721852859, ___value___1)); }
	inline int32_t get_value___1() const { return ___value___1; }
	inline int32_t* get_address_of_value___1() { return &___value___1; }
	inline void set_value___1(int32_t value)
	{
		___value___1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SOURCETYPE_T2721852859_H
#ifndef USERDATAPERMISSION_T2025516611_H
#define USERDATAPERMISSION_T2025516611_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.UserDataPermission
struct  UserDataPermission_t2025516611 
{
public:
	// System.Int32 PlayFab.ClientModels.UserDataPermission::value__
	int32_t ___value___1;

public:
	inline static int32_t get_offset_of_value___1() { return static_cast<int32_t>(offsetof(UserDataPermission_t2025516611, ___value___1)); }
	inline int32_t get_value___1() const { return ___value___1; }
	inline int32_t* get_address_of_value___1() { return &___value___1; }
	inline void set_value___1(int32_t value)
	{
		___value___1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // USERDATAPERMISSION_T2025516611_H
#ifndef COUNTRYCODE_T1744650337_H
#define COUNTRYCODE_T1744650337_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.CountryCode
struct  CountryCode_t1744650337 
{
public:
	// System.Int32 PlayFab.ClientModels.CountryCode::value__
	int32_t ___value___1;

public:
	inline static int32_t get_offset_of_value___1() { return static_cast<int32_t>(offsetof(CountryCode_t1744650337, ___value___1)); }
	inline int32_t get_value___1() const { return ___value___1; }
	inline int32_t* get_address_of_value___1() { return &___value___1; }
	inline void set_value___1(int32_t value)
	{
		___value___1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // COUNTRYCODE_T1744650337_H
#ifndef DATETIMEKIND_T3468814247_H
#define DATETIMEKIND_T3468814247_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.DateTimeKind
struct  DateTimeKind_t3468814247 
{
public:
	// System.Int32 System.DateTimeKind::value__
	int32_t ___value___1;

public:
	inline static int32_t get_offset_of_value___1() { return static_cast<int32_t>(offsetof(DateTimeKind_t3468814247, ___value___1)); }
	inline int32_t get_value___1() const { return ___value___1; }
	inline int32_t* get_address_of_value___1() { return &___value___1; }
	inline void set_value___1(int32_t value)
	{
		___value___1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // DATETIMEKIND_T3468814247_H
#ifndef CONTINENTCODE_T2955100920_H
#define CONTINENTCODE_T2955100920_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.ContinentCode
struct  ContinentCode_t2955100920 
{
public:
	// System.Int32 PlayFab.ClientModels.ContinentCode::value__
	int32_t ___value___1;

public:
	inline static int32_t get_offset_of_value___1() { return static_cast<int32_t>(offsetof(ContinentCode_t2955100920, ___value___1)); }
	inline int32_t get_value___1() const { return ___value___1; }
	inline int32_t* get_address_of_value___1() { return &___value___1; }
	inline void set_value___1(int32_t value)
	{
		___value___1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // CONTINENTCODE_T2955100920_H
#ifndef TRANSACTIONSTATUS_T2822543195_H
#define TRANSACTIONSTATUS_T2822543195_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.TransactionStatus
struct  TransactionStatus_t2822543195 
{
public:
	// System.Int32 PlayFab.ClientModels.TransactionStatus::value__
	int32_t ___value___1;

public:
	inline static int32_t get_offset_of_value___1() { return static_cast<int32_t>(offsetof(TransactionStatus_t2822543195, ___value___1)); }
	inline int32_t get_value___1() const { return ___value___1; }
	inline int32_t* get_address_of_value___1() { return &___value___1; }
	inline void set_value___1(int32_t value)
	{
		___value___1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TRANSACTIONSTATUS_T2822543195_H
#ifndef STARTGAMERESULT_T3332222724_H
#define STARTGAMERESULT_T3332222724_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.StartGameResult
struct  StartGameResult_t3332222724  : public PlayFabResultCommon_t3469603827
{
public:
	// System.String PlayFab.ClientModels.StartGameResult::Expires
	String_t* ___Expires_2;
	// System.String PlayFab.ClientModels.StartGameResult::LobbyID
	String_t* ___LobbyID_3;
	// System.String PlayFab.ClientModels.StartGameResult::Password
	String_t* ___Password_4;
	// System.String PlayFab.ClientModels.StartGameResult::ServerHostname
	String_t* ___ServerHostname_5;
	// System.String PlayFab.ClientModels.StartGameResult::ServerIPV6Address
	String_t* ___ServerIPV6Address_6;
	// System.Nullable`1<System.Int32> PlayFab.ClientModels.StartGameResult::ServerPort
	Nullable_1_t378540539  ___ServerPort_7;
	// System.String PlayFab.ClientModels.StartGameResult::Ticket
	String_t* ___Ticket_8;

public:
	inline static int32_t get_offset_of_Expires_2() { return static_cast<int32_t>(offsetof(StartGameResult_t3332222724, ___Expires_2)); }
	inline String_t* get_Expires_2() const { return ___Expires_2; }
	inline String_t** get_address_of_Expires_2() { return &___Expires_2; }
	inline void set_Expires_2(String_t* value)
	{
		___Expires_2 = value;
		Il2CppCodeGenWriteBarrier((&___Expires_2), value);
	}

	inline static int32_t get_offset_of_LobbyID_3() { return static_cast<int32_t>(offsetof(StartGameResult_t3332222724, ___LobbyID_3)); }
	inline String_t* get_LobbyID_3() const { return ___LobbyID_3; }
	inline String_t** get_address_of_LobbyID_3() { return &___LobbyID_3; }
	inline void set_LobbyID_3(String_t* value)
	{
		___LobbyID_3 = value;
		Il2CppCodeGenWriteBarrier((&___LobbyID_3), value);
	}

	inline static int32_t get_offset_of_Password_4() { return static_cast<int32_t>(offsetof(StartGameResult_t3332222724, ___Password_4)); }
	inline String_t* get_Password_4() const { return ___Password_4; }
	inline String_t** get_address_of_Password_4() { return &___Password_4; }
	inline void set_Password_4(String_t* value)
	{
		___Password_4 = value;
		Il2CppCodeGenWriteBarrier((&___Password_4), value);
	}

	inline static int32_t get_offset_of_ServerHostname_5() { return static_cast<int32_t>(offsetof(StartGameResult_t3332222724, ___ServerHostname_5)); }
	inline String_t* get_ServerHostname_5() const { return ___ServerHostname_5; }
	inline String_t** get_address_of_ServerHostname_5() { return &___ServerHostname_5; }
	inline void set_ServerHostname_5(String_t* value)
	{
		___ServerHostname_5 = value;
		Il2CppCodeGenWriteBarrier((&___ServerHostname_5), value);
	}

	inline static int32_t get_offset_of_ServerIPV6Address_6() { return static_cast<int32_t>(offsetof(StartGameResult_t3332222724, ___ServerIPV6Address_6)); }
	inline String_t* get_ServerIPV6Address_6() const { return ___ServerIPV6Address_6; }
	inline String_t** get_address_of_ServerIPV6Address_6() { return &___ServerIPV6Address_6; }
	inline void set_ServerIPV6Address_6(String_t* value)
	{
		___ServerIPV6Address_6 = value;
		Il2CppCodeGenWriteBarrier((&___ServerIPV6Address_6), value);
	}

	inline static int32_t get_offset_of_ServerPort_7() { return static_cast<int32_t>(offsetof(StartGameResult_t3332222724, ___ServerPort_7)); }
	inline Nullable_1_t378540539  get_ServerPort_7() const { return ___ServerPort_7; }
	inline Nullable_1_t378540539 * get_address_of_ServerPort_7() { return &___ServerPort_7; }
	inline void set_ServerPort_7(Nullable_1_t378540539  value)
	{
		___ServerPort_7 = value;
	}

	inline static int32_t get_offset_of_Ticket_8() { return static_cast<int32_t>(offsetof(StartGameResult_t3332222724, ___Ticket_8)); }
	inline String_t* get_Ticket_8() const { return ___Ticket_8; }
	inline String_t** get_address_of_Ticket_8() { return &___Ticket_8; }
	inline void set_Ticket_8(String_t* value)
	{
		___Ticket_8 = value;
		Il2CppCodeGenWriteBarrier((&___Ticket_8), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // STARTGAMERESULT_T3332222724_H
#ifndef REGISTERWITHWINDOWSHELLOREQUEST_T1629448663_H
#define REGISTERWITHWINDOWSHELLOREQUEST_T1629448663_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.RegisterWithWindowsHelloRequest
struct  RegisterWithWindowsHelloRequest_t1629448663  : public PlayFabRequestCommon_t229319069
{
public:
	// System.String PlayFab.ClientModels.RegisterWithWindowsHelloRequest::DeviceName
	String_t* ___DeviceName_0;
	// System.String PlayFab.ClientModels.RegisterWithWindowsHelloRequest::EncryptedRequest
	String_t* ___EncryptedRequest_1;
	// PlayFab.ClientModels.GetPlayerCombinedInfoRequestParams PlayFab.ClientModels.RegisterWithWindowsHelloRequest::InfoRequestParameters
	GetPlayerCombinedInfoRequestParams_t121265087 * ___InfoRequestParameters_2;
	// System.Nullable`1<System.Boolean> PlayFab.ClientModels.RegisterWithWindowsHelloRequest::LoginTitlePlayerAccountEntity
	Nullable_1_t1819850047  ___LoginTitlePlayerAccountEntity_3;
	// System.String PlayFab.ClientModels.RegisterWithWindowsHelloRequest::PlayerSecret
	String_t* ___PlayerSecret_4;
	// System.String PlayFab.ClientModels.RegisterWithWindowsHelloRequest::PublicKey
	String_t* ___PublicKey_5;
	// System.String PlayFab.ClientModels.RegisterWithWindowsHelloRequest::TitleId
	String_t* ___TitleId_6;
	// System.String PlayFab.ClientModels.RegisterWithWindowsHelloRequest::UserName
	String_t* ___UserName_7;

public:
	inline static int32_t get_offset_of_DeviceName_0() { return static_cast<int32_t>(offsetof(RegisterWithWindowsHelloRequest_t1629448663, ___DeviceName_0)); }
	inline String_t* get_DeviceName_0() const { return ___DeviceName_0; }
	inline String_t** get_address_of_DeviceName_0() { return &___DeviceName_0; }
	inline void set_DeviceName_0(String_t* value)
	{
		___DeviceName_0 = value;
		Il2CppCodeGenWriteBarrier((&___DeviceName_0), value);
	}

	inline static int32_t get_offset_of_EncryptedRequest_1() { return static_cast<int32_t>(offsetof(RegisterWithWindowsHelloRequest_t1629448663, ___EncryptedRequest_1)); }
	inline String_t* get_EncryptedRequest_1() const { return ___EncryptedRequest_1; }
	inline String_t** get_address_of_EncryptedRequest_1() { return &___EncryptedRequest_1; }
	inline void set_EncryptedRequest_1(String_t* value)
	{
		___EncryptedRequest_1 = value;
		Il2CppCodeGenWriteBarrier((&___EncryptedRequest_1), value);
	}

	inline static int32_t get_offset_of_InfoRequestParameters_2() { return static_cast<int32_t>(offsetof(RegisterWithWindowsHelloRequest_t1629448663, ___InfoRequestParameters_2)); }
	inline GetPlayerCombinedInfoRequestParams_t121265087 * get_InfoRequestParameters_2() const { return ___InfoRequestParameters_2; }
	inline GetPlayerCombinedInfoRequestParams_t121265087 ** get_address_of_InfoRequestParameters_2() { return &___InfoRequestParameters_2; }
	inline void set_InfoRequestParameters_2(GetPlayerCombinedInfoRequestParams_t121265087 * value)
	{
		___InfoRequestParameters_2 = value;
		Il2CppCodeGenWriteBarrier((&___InfoRequestParameters_2), value);
	}

	inline static int32_t get_offset_of_LoginTitlePlayerAccountEntity_3() { return static_cast<int32_t>(offsetof(RegisterWithWindowsHelloRequest_t1629448663, ___LoginTitlePlayerAccountEntity_3)); }
	inline Nullable_1_t1819850047  get_LoginTitlePlayerAccountEntity_3() const { return ___LoginTitlePlayerAccountEntity_3; }
	inline Nullable_1_t1819850047 * get_address_of_LoginTitlePlayerAccountEntity_3() { return &___LoginTitlePlayerAccountEntity_3; }
	inline void set_LoginTitlePlayerAccountEntity_3(Nullable_1_t1819850047  value)
	{
		___LoginTitlePlayerAccountEntity_3 = value;
	}

	inline static int32_t get_offset_of_PlayerSecret_4() { return static_cast<int32_t>(offsetof(RegisterWithWindowsHelloRequest_t1629448663, ___PlayerSecret_4)); }
	inline String_t* get_PlayerSecret_4() const { return ___PlayerSecret_4; }
	inline String_t** get_address_of_PlayerSecret_4() { return &___PlayerSecret_4; }
	inline void set_PlayerSecret_4(String_t* value)
	{
		___PlayerSecret_4 = value;
		Il2CppCodeGenWriteBarrier((&___PlayerSecret_4), value);
	}

	inline static int32_t get_offset_of_PublicKey_5() { return static_cast<int32_t>(offsetof(RegisterWithWindowsHelloRequest_t1629448663, ___PublicKey_5)); }
	inline String_t* get_PublicKey_5() const { return ___PublicKey_5; }
	inline String_t** get_address_of_PublicKey_5() { return &___PublicKey_5; }
	inline void set_PublicKey_5(String_t* value)
	{
		___PublicKey_5 = value;
		Il2CppCodeGenWriteBarrier((&___PublicKey_5), value);
	}

	inline static int32_t get_offset_of_TitleId_6() { return static_cast<int32_t>(offsetof(RegisterWithWindowsHelloRequest_t1629448663, ___TitleId_6)); }
	inline String_t* get_TitleId_6() const { return ___TitleId_6; }
	inline String_t** get_address_of_TitleId_6() { return &___TitleId_6; }
	inline void set_TitleId_6(String_t* value)
	{
		___TitleId_6 = value;
		Il2CppCodeGenWriteBarrier((&___TitleId_6), value);
	}

	inline static int32_t get_offset_of_UserName_7() { return static_cast<int32_t>(offsetof(RegisterWithWindowsHelloRequest_t1629448663, ___UserName_7)); }
	inline String_t* get_UserName_7() const { return ___UserName_7; }
	inline String_t** get_address_of_UserName_7() { return &___UserName_7; }
	inline void set_UserName_7(String_t* value)
	{
		___UserName_7 = value;
		Il2CppCodeGenWriteBarrier((&___UserName_7), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // REGISTERWITHWINDOWSHELLOREQUEST_T1629448663_H
#ifndef LOGINWITHANDROIDDEVICEIDREQUEST_T1269656532_H
#define LOGINWITHANDROIDDEVICEIDREQUEST_T1269656532_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.LoginWithAndroidDeviceIDRequest
struct  LoginWithAndroidDeviceIDRequest_t1269656532  : public PlayFabRequestCommon_t229319069
{
public:
	// System.String PlayFab.ClientModels.LoginWithAndroidDeviceIDRequest::AndroidDevice
	String_t* ___AndroidDevice_0;
	// System.String PlayFab.ClientModels.LoginWithAndroidDeviceIDRequest::AndroidDeviceId
	String_t* ___AndroidDeviceId_1;
	// System.Nullable`1<System.Boolean> PlayFab.ClientModels.LoginWithAndroidDeviceIDRequest::CreateAccount
	Nullable_1_t1819850047  ___CreateAccount_2;
	// System.String PlayFab.ClientModels.LoginWithAndroidDeviceIDRequest::EncryptedRequest
	String_t* ___EncryptedRequest_3;
	// PlayFab.ClientModels.GetPlayerCombinedInfoRequestParams PlayFab.ClientModels.LoginWithAndroidDeviceIDRequest::InfoRequestParameters
	GetPlayerCombinedInfoRequestParams_t121265087 * ___InfoRequestParameters_4;
	// System.Nullable`1<System.Boolean> PlayFab.ClientModels.LoginWithAndroidDeviceIDRequest::LoginTitlePlayerAccountEntity
	Nullable_1_t1819850047  ___LoginTitlePlayerAccountEntity_5;
	// System.String PlayFab.ClientModels.LoginWithAndroidDeviceIDRequest::OS
	String_t* ___OS_6;
	// System.String PlayFab.ClientModels.LoginWithAndroidDeviceIDRequest::PlayerSecret
	String_t* ___PlayerSecret_7;
	// System.String PlayFab.ClientModels.LoginWithAndroidDeviceIDRequest::TitleId
	String_t* ___TitleId_8;

public:
	inline static int32_t get_offset_of_AndroidDevice_0() { return static_cast<int32_t>(offsetof(LoginWithAndroidDeviceIDRequest_t1269656532, ___AndroidDevice_0)); }
	inline String_t* get_AndroidDevice_0() const { return ___AndroidDevice_0; }
	inline String_t** get_address_of_AndroidDevice_0() { return &___AndroidDevice_0; }
	inline void set_AndroidDevice_0(String_t* value)
	{
		___AndroidDevice_0 = value;
		Il2CppCodeGenWriteBarrier((&___AndroidDevice_0), value);
	}

	inline static int32_t get_offset_of_AndroidDeviceId_1() { return static_cast<int32_t>(offsetof(LoginWithAndroidDeviceIDRequest_t1269656532, ___AndroidDeviceId_1)); }
	inline String_t* get_AndroidDeviceId_1() const { return ___AndroidDeviceId_1; }
	inline String_t** get_address_of_AndroidDeviceId_1() { return &___AndroidDeviceId_1; }
	inline void set_AndroidDeviceId_1(String_t* value)
	{
		___AndroidDeviceId_1 = value;
		Il2CppCodeGenWriteBarrier((&___AndroidDeviceId_1), value);
	}

	inline static int32_t get_offset_of_CreateAccount_2() { return static_cast<int32_t>(offsetof(LoginWithAndroidDeviceIDRequest_t1269656532, ___CreateAccount_2)); }
	inline Nullable_1_t1819850047  get_CreateAccount_2() const { return ___CreateAccount_2; }
	inline Nullable_1_t1819850047 * get_address_of_CreateAccount_2() { return &___CreateAccount_2; }
	inline void set_CreateAccount_2(Nullable_1_t1819850047  value)
	{
		___CreateAccount_2 = value;
	}

	inline static int32_t get_offset_of_EncryptedRequest_3() { return static_cast<int32_t>(offsetof(LoginWithAndroidDeviceIDRequest_t1269656532, ___EncryptedRequest_3)); }
	inline String_t* get_EncryptedRequest_3() const { return ___EncryptedRequest_3; }
	inline String_t** get_address_of_EncryptedRequest_3() { return &___EncryptedRequest_3; }
	inline void set_EncryptedRequest_3(String_t* value)
	{
		___EncryptedRequest_3 = value;
		Il2CppCodeGenWriteBarrier((&___EncryptedRequest_3), value);
	}

	inline static int32_t get_offset_of_InfoRequestParameters_4() { return static_cast<int32_t>(offsetof(LoginWithAndroidDeviceIDRequest_t1269656532, ___InfoRequestParameters_4)); }
	inline GetPlayerCombinedInfoRequestParams_t121265087 * get_InfoRequestParameters_4() const { return ___InfoRequestParameters_4; }
	inline GetPlayerCombinedInfoRequestParams_t121265087 ** get_address_of_InfoRequestParameters_4() { return &___InfoRequestParameters_4; }
	inline void set_InfoRequestParameters_4(GetPlayerCombinedInfoRequestParams_t121265087 * value)
	{
		___InfoRequestParameters_4 = value;
		Il2CppCodeGenWriteBarrier((&___InfoRequestParameters_4), value);
	}

	inline static int32_t get_offset_of_LoginTitlePlayerAccountEntity_5() { return static_cast<int32_t>(offsetof(LoginWithAndroidDeviceIDRequest_t1269656532, ___LoginTitlePlayerAccountEntity_5)); }
	inline Nullable_1_t1819850047  get_LoginTitlePlayerAccountEntity_5() const { return ___LoginTitlePlayerAccountEntity_5; }
	inline Nullable_1_t1819850047 * get_address_of_LoginTitlePlayerAccountEntity_5() { return &___LoginTitlePlayerAccountEntity_5; }
	inline void set_LoginTitlePlayerAccountEntity_5(Nullable_1_t1819850047  value)
	{
		___LoginTitlePlayerAccountEntity_5 = value;
	}

	inline static int32_t get_offset_of_OS_6() { return static_cast<int32_t>(offsetof(LoginWithAndroidDeviceIDRequest_t1269656532, ___OS_6)); }
	inline String_t* get_OS_6() const { return ___OS_6; }
	inline String_t** get_address_of_OS_6() { return &___OS_6; }
	inline void set_OS_6(String_t* value)
	{
		___OS_6 = value;
		Il2CppCodeGenWriteBarrier((&___OS_6), value);
	}

	inline static int32_t get_offset_of_PlayerSecret_7() { return static_cast<int32_t>(offsetof(LoginWithAndroidDeviceIDRequest_t1269656532, ___PlayerSecret_7)); }
	inline String_t* get_PlayerSecret_7() const { return ___PlayerSecret_7; }
	inline String_t** get_address_of_PlayerSecret_7() { return &___PlayerSecret_7; }
	inline void set_PlayerSecret_7(String_t* value)
	{
		___PlayerSecret_7 = value;
		Il2CppCodeGenWriteBarrier((&___PlayerSecret_7), value);
	}

	inline static int32_t get_offset_of_TitleId_8() { return static_cast<int32_t>(offsetof(LoginWithAndroidDeviceIDRequest_t1269656532, ___TitleId_8)); }
	inline String_t* get_TitleId_8() const { return ___TitleId_8; }
	inline String_t** get_address_of_TitleId_8() { return &___TitleId_8; }
	inline void set_TitleId_8(String_t* value)
	{
		___TitleId_8 = value;
		Il2CppCodeGenWriteBarrier((&___TitleId_8), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LOGINWITHANDROIDDEVICEIDREQUEST_T1269656532_H
#ifndef LOGINWITHCUSTOMIDREQUEST_T176841994_H
#define LOGINWITHCUSTOMIDREQUEST_T176841994_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.LoginWithCustomIDRequest
struct  LoginWithCustomIDRequest_t176841994  : public PlayFabRequestCommon_t229319069
{
public:
	// System.Nullable`1<System.Boolean> PlayFab.ClientModels.LoginWithCustomIDRequest::CreateAccount
	Nullable_1_t1819850047  ___CreateAccount_0;
	// System.String PlayFab.ClientModels.LoginWithCustomIDRequest::CustomId
	String_t* ___CustomId_1;
	// System.String PlayFab.ClientModels.LoginWithCustomIDRequest::EncryptedRequest
	String_t* ___EncryptedRequest_2;
	// PlayFab.ClientModels.GetPlayerCombinedInfoRequestParams PlayFab.ClientModels.LoginWithCustomIDRequest::InfoRequestParameters
	GetPlayerCombinedInfoRequestParams_t121265087 * ___InfoRequestParameters_3;
	// System.Nullable`1<System.Boolean> PlayFab.ClientModels.LoginWithCustomIDRequest::LoginTitlePlayerAccountEntity
	Nullable_1_t1819850047  ___LoginTitlePlayerAccountEntity_4;
	// System.String PlayFab.ClientModels.LoginWithCustomIDRequest::PlayerSecret
	String_t* ___PlayerSecret_5;
	// System.String PlayFab.ClientModels.LoginWithCustomIDRequest::TitleId
	String_t* ___TitleId_6;

public:
	inline static int32_t get_offset_of_CreateAccount_0() { return static_cast<int32_t>(offsetof(LoginWithCustomIDRequest_t176841994, ___CreateAccount_0)); }
	inline Nullable_1_t1819850047  get_CreateAccount_0() const { return ___CreateAccount_0; }
	inline Nullable_1_t1819850047 * get_address_of_CreateAccount_0() { return &___CreateAccount_0; }
	inline void set_CreateAccount_0(Nullable_1_t1819850047  value)
	{
		___CreateAccount_0 = value;
	}

	inline static int32_t get_offset_of_CustomId_1() { return static_cast<int32_t>(offsetof(LoginWithCustomIDRequest_t176841994, ___CustomId_1)); }
	inline String_t* get_CustomId_1() const { return ___CustomId_1; }
	inline String_t** get_address_of_CustomId_1() { return &___CustomId_1; }
	inline void set_CustomId_1(String_t* value)
	{
		___CustomId_1 = value;
		Il2CppCodeGenWriteBarrier((&___CustomId_1), value);
	}

	inline static int32_t get_offset_of_EncryptedRequest_2() { return static_cast<int32_t>(offsetof(LoginWithCustomIDRequest_t176841994, ___EncryptedRequest_2)); }
	inline String_t* get_EncryptedRequest_2() const { return ___EncryptedRequest_2; }
	inline String_t** get_address_of_EncryptedRequest_2() { return &___EncryptedRequest_2; }
	inline void set_EncryptedRequest_2(String_t* value)
	{
		___EncryptedRequest_2 = value;
		Il2CppCodeGenWriteBarrier((&___EncryptedRequest_2), value);
	}

	inline static int32_t get_offset_of_InfoRequestParameters_3() { return static_cast<int32_t>(offsetof(LoginWithCustomIDRequest_t176841994, ___InfoRequestParameters_3)); }
	inline GetPlayerCombinedInfoRequestParams_t121265087 * get_InfoRequestParameters_3() const { return ___InfoRequestParameters_3; }
	inline GetPlayerCombinedInfoRequestParams_t121265087 ** get_address_of_InfoRequestParameters_3() { return &___InfoRequestParameters_3; }
	inline void set_InfoRequestParameters_3(GetPlayerCombinedInfoRequestParams_t121265087 * value)
	{
		___InfoRequestParameters_3 = value;
		Il2CppCodeGenWriteBarrier((&___InfoRequestParameters_3), value);
	}

	inline static int32_t get_offset_of_LoginTitlePlayerAccountEntity_4() { return static_cast<int32_t>(offsetof(LoginWithCustomIDRequest_t176841994, ___LoginTitlePlayerAccountEntity_4)); }
	inline Nullable_1_t1819850047  get_LoginTitlePlayerAccountEntity_4() const { return ___LoginTitlePlayerAccountEntity_4; }
	inline Nullable_1_t1819850047 * get_address_of_LoginTitlePlayerAccountEntity_4() { return &___LoginTitlePlayerAccountEntity_4; }
	inline void set_LoginTitlePlayerAccountEntity_4(Nullable_1_t1819850047  value)
	{
		___LoginTitlePlayerAccountEntity_4 = value;
	}

	inline static int32_t get_offset_of_PlayerSecret_5() { return static_cast<int32_t>(offsetof(LoginWithCustomIDRequest_t176841994, ___PlayerSecret_5)); }
	inline String_t* get_PlayerSecret_5() const { return ___PlayerSecret_5; }
	inline String_t** get_address_of_PlayerSecret_5() { return &___PlayerSecret_5; }
	inline void set_PlayerSecret_5(String_t* value)
	{
		___PlayerSecret_5 = value;
		Il2CppCodeGenWriteBarrier((&___PlayerSecret_5), value);
	}

	inline static int32_t get_offset_of_TitleId_6() { return static_cast<int32_t>(offsetof(LoginWithCustomIDRequest_t176841994, ___TitleId_6)); }
	inline String_t* get_TitleId_6() const { return ___TitleId_6; }
	inline String_t** get_address_of_TitleId_6() { return &___TitleId_6; }
	inline void set_TitleId_6(String_t* value)
	{
		___TitleId_6 = value;
		Il2CppCodeGenWriteBarrier((&___TitleId_6), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LOGINWITHCUSTOMIDREQUEST_T176841994_H
#ifndef LINKWINDOWSHELLOACCOUNTREQUEST_T2757452561_H
#define LINKWINDOWSHELLOACCOUNTREQUEST_T2757452561_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.LinkWindowsHelloAccountRequest
struct  LinkWindowsHelloAccountRequest_t2757452561  : public PlayFabRequestCommon_t229319069
{
public:
	// System.String PlayFab.ClientModels.LinkWindowsHelloAccountRequest::DeviceName
	String_t* ___DeviceName_0;
	// System.Nullable`1<System.Boolean> PlayFab.ClientModels.LinkWindowsHelloAccountRequest::ForceLink
	Nullable_1_t1819850047  ___ForceLink_1;
	// System.String PlayFab.ClientModels.LinkWindowsHelloAccountRequest::PublicKey
	String_t* ___PublicKey_2;
	// System.String PlayFab.ClientModels.LinkWindowsHelloAccountRequest::UserName
	String_t* ___UserName_3;

public:
	inline static int32_t get_offset_of_DeviceName_0() { return static_cast<int32_t>(offsetof(LinkWindowsHelloAccountRequest_t2757452561, ___DeviceName_0)); }
	inline String_t* get_DeviceName_0() const { return ___DeviceName_0; }
	inline String_t** get_address_of_DeviceName_0() { return &___DeviceName_0; }
	inline void set_DeviceName_0(String_t* value)
	{
		___DeviceName_0 = value;
		Il2CppCodeGenWriteBarrier((&___DeviceName_0), value);
	}

	inline static int32_t get_offset_of_ForceLink_1() { return static_cast<int32_t>(offsetof(LinkWindowsHelloAccountRequest_t2757452561, ___ForceLink_1)); }
	inline Nullable_1_t1819850047  get_ForceLink_1() const { return ___ForceLink_1; }
	inline Nullable_1_t1819850047 * get_address_of_ForceLink_1() { return &___ForceLink_1; }
	inline void set_ForceLink_1(Nullable_1_t1819850047  value)
	{
		___ForceLink_1 = value;
	}

	inline static int32_t get_offset_of_PublicKey_2() { return static_cast<int32_t>(offsetof(LinkWindowsHelloAccountRequest_t2757452561, ___PublicKey_2)); }
	inline String_t* get_PublicKey_2() const { return ___PublicKey_2; }
	inline String_t** get_address_of_PublicKey_2() { return &___PublicKey_2; }
	inline void set_PublicKey_2(String_t* value)
	{
		___PublicKey_2 = value;
		Il2CppCodeGenWriteBarrier((&___PublicKey_2), value);
	}

	inline static int32_t get_offset_of_UserName_3() { return static_cast<int32_t>(offsetof(LinkWindowsHelloAccountRequest_t2757452561, ___UserName_3)); }
	inline String_t* get_UserName_3() const { return ___UserName_3; }
	inline String_t** get_address_of_UserName_3() { return &___UserName_3; }
	inline void set_UserName_3(String_t* value)
	{
		___UserName_3 = value;
		Il2CppCodeGenWriteBarrier((&___UserName_3), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LINKWINDOWSHELLOACCOUNTREQUEST_T2757452561_H
#ifndef LOGINIDENTITYPROVIDER_T1880618185_H
#define LOGINIDENTITYPROVIDER_T1880618185_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.LoginIdentityProvider
struct  LoginIdentityProvider_t1880618185 
{
public:
	// System.Int32 PlayFab.ClientModels.LoginIdentityProvider::value__
	int32_t ___value___1;

public:
	inline static int32_t get_offset_of_value___1() { return static_cast<int32_t>(offsetof(LoginIdentityProvider_t1880618185, ___value___1)); }
	inline int32_t get_value___1() const { return ___value___1; }
	inline int32_t* get_address_of_value___1() { return &___value___1; }
	inline void set_value___1(int32_t value)
	{
		___value___1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LOGINIDENTITYPROVIDER_T1880618185_H
#ifndef LOGINWITHEMAILADDRESSREQUEST_T3424541161_H
#define LOGINWITHEMAILADDRESSREQUEST_T3424541161_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.LoginWithEmailAddressRequest
struct  LoginWithEmailAddressRequest_t3424541161  : public PlayFabRequestCommon_t229319069
{
public:
	// System.String PlayFab.ClientModels.LoginWithEmailAddressRequest::Email
	String_t* ___Email_0;
	// PlayFab.ClientModels.GetPlayerCombinedInfoRequestParams PlayFab.ClientModels.LoginWithEmailAddressRequest::InfoRequestParameters
	GetPlayerCombinedInfoRequestParams_t121265087 * ___InfoRequestParameters_1;
	// System.Nullable`1<System.Boolean> PlayFab.ClientModels.LoginWithEmailAddressRequest::LoginTitlePlayerAccountEntity
	Nullable_1_t1819850047  ___LoginTitlePlayerAccountEntity_2;
	// System.String PlayFab.ClientModels.LoginWithEmailAddressRequest::Password
	String_t* ___Password_3;
	// System.String PlayFab.ClientModels.LoginWithEmailAddressRequest::TitleId
	String_t* ___TitleId_4;

public:
	inline static int32_t get_offset_of_Email_0() { return static_cast<int32_t>(offsetof(LoginWithEmailAddressRequest_t3424541161, ___Email_0)); }
	inline String_t* get_Email_0() const { return ___Email_0; }
	inline String_t** get_address_of_Email_0() { return &___Email_0; }
	inline void set_Email_0(String_t* value)
	{
		___Email_0 = value;
		Il2CppCodeGenWriteBarrier((&___Email_0), value);
	}

	inline static int32_t get_offset_of_InfoRequestParameters_1() { return static_cast<int32_t>(offsetof(LoginWithEmailAddressRequest_t3424541161, ___InfoRequestParameters_1)); }
	inline GetPlayerCombinedInfoRequestParams_t121265087 * get_InfoRequestParameters_1() const { return ___InfoRequestParameters_1; }
	inline GetPlayerCombinedInfoRequestParams_t121265087 ** get_address_of_InfoRequestParameters_1() { return &___InfoRequestParameters_1; }
	inline void set_InfoRequestParameters_1(GetPlayerCombinedInfoRequestParams_t121265087 * value)
	{
		___InfoRequestParameters_1 = value;
		Il2CppCodeGenWriteBarrier((&___InfoRequestParameters_1), value);
	}

	inline static int32_t get_offset_of_LoginTitlePlayerAccountEntity_2() { return static_cast<int32_t>(offsetof(LoginWithEmailAddressRequest_t3424541161, ___LoginTitlePlayerAccountEntity_2)); }
	inline Nullable_1_t1819850047  get_LoginTitlePlayerAccountEntity_2() const { return ___LoginTitlePlayerAccountEntity_2; }
	inline Nullable_1_t1819850047 * get_address_of_LoginTitlePlayerAccountEntity_2() { return &___LoginTitlePlayerAccountEntity_2; }
	inline void set_LoginTitlePlayerAccountEntity_2(Nullable_1_t1819850047  value)
	{
		___LoginTitlePlayerAccountEntity_2 = value;
	}

	inline static int32_t get_offset_of_Password_3() { return static_cast<int32_t>(offsetof(LoginWithEmailAddressRequest_t3424541161, ___Password_3)); }
	inline String_t* get_Password_3() const { return ___Password_3; }
	inline String_t** get_address_of_Password_3() { return &___Password_3; }
	inline void set_Password_3(String_t* value)
	{
		___Password_3 = value;
		Il2CppCodeGenWriteBarrier((&___Password_3), value);
	}

	inline static int32_t get_offset_of_TitleId_4() { return static_cast<int32_t>(offsetof(LoginWithEmailAddressRequest_t3424541161, ___TitleId_4)); }
	inline String_t* get_TitleId_4() const { return ___TitleId_4; }
	inline String_t** get_address_of_TitleId_4() { return &___TitleId_4; }
	inline void set_TitleId_4(String_t* value)
	{
		___TitleId_4 = value;
		Il2CppCodeGenWriteBarrier((&___TitleId_4), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LOGINWITHEMAILADDRESSREQUEST_T3424541161_H
#ifndef LOGINWITHGOOGLEACCOUNTREQUEST_T513675687_H
#define LOGINWITHGOOGLEACCOUNTREQUEST_T513675687_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.LoginWithGoogleAccountRequest
struct  LoginWithGoogleAccountRequest_t513675687  : public PlayFabRequestCommon_t229319069
{
public:
	// System.Nullable`1<System.Boolean> PlayFab.ClientModels.LoginWithGoogleAccountRequest::CreateAccount
	Nullable_1_t1819850047  ___CreateAccount_0;
	// System.String PlayFab.ClientModels.LoginWithGoogleAccountRequest::EncryptedRequest
	String_t* ___EncryptedRequest_1;
	// PlayFab.ClientModels.GetPlayerCombinedInfoRequestParams PlayFab.ClientModels.LoginWithGoogleAccountRequest::InfoRequestParameters
	GetPlayerCombinedInfoRequestParams_t121265087 * ___InfoRequestParameters_2;
	// System.Nullable`1<System.Boolean> PlayFab.ClientModels.LoginWithGoogleAccountRequest::LoginTitlePlayerAccountEntity
	Nullable_1_t1819850047  ___LoginTitlePlayerAccountEntity_3;
	// System.String PlayFab.ClientModels.LoginWithGoogleAccountRequest::PlayerSecret
	String_t* ___PlayerSecret_4;
	// System.String PlayFab.ClientModels.LoginWithGoogleAccountRequest::ServerAuthCode
	String_t* ___ServerAuthCode_5;
	// System.String PlayFab.ClientModels.LoginWithGoogleAccountRequest::TitleId
	String_t* ___TitleId_6;

public:
	inline static int32_t get_offset_of_CreateAccount_0() { return static_cast<int32_t>(offsetof(LoginWithGoogleAccountRequest_t513675687, ___CreateAccount_0)); }
	inline Nullable_1_t1819850047  get_CreateAccount_0() const { return ___CreateAccount_0; }
	inline Nullable_1_t1819850047 * get_address_of_CreateAccount_0() { return &___CreateAccount_0; }
	inline void set_CreateAccount_0(Nullable_1_t1819850047  value)
	{
		___CreateAccount_0 = value;
	}

	inline static int32_t get_offset_of_EncryptedRequest_1() { return static_cast<int32_t>(offsetof(LoginWithGoogleAccountRequest_t513675687, ___EncryptedRequest_1)); }
	inline String_t* get_EncryptedRequest_1() const { return ___EncryptedRequest_1; }
	inline String_t** get_address_of_EncryptedRequest_1() { return &___EncryptedRequest_1; }
	inline void set_EncryptedRequest_1(String_t* value)
	{
		___EncryptedRequest_1 = value;
		Il2CppCodeGenWriteBarrier((&___EncryptedRequest_1), value);
	}

	inline static int32_t get_offset_of_InfoRequestParameters_2() { return static_cast<int32_t>(offsetof(LoginWithGoogleAccountRequest_t513675687, ___InfoRequestParameters_2)); }
	inline GetPlayerCombinedInfoRequestParams_t121265087 * get_InfoRequestParameters_2() const { return ___InfoRequestParameters_2; }
	inline GetPlayerCombinedInfoRequestParams_t121265087 ** get_address_of_InfoRequestParameters_2() { return &___InfoRequestParameters_2; }
	inline void set_InfoRequestParameters_2(GetPlayerCombinedInfoRequestParams_t121265087 * value)
	{
		___InfoRequestParameters_2 = value;
		Il2CppCodeGenWriteBarrier((&___InfoRequestParameters_2), value);
	}

	inline static int32_t get_offset_of_LoginTitlePlayerAccountEntity_3() { return static_cast<int32_t>(offsetof(LoginWithGoogleAccountRequest_t513675687, ___LoginTitlePlayerAccountEntity_3)); }
	inline Nullable_1_t1819850047  get_LoginTitlePlayerAccountEntity_3() const { return ___LoginTitlePlayerAccountEntity_3; }
	inline Nullable_1_t1819850047 * get_address_of_LoginTitlePlayerAccountEntity_3() { return &___LoginTitlePlayerAccountEntity_3; }
	inline void set_LoginTitlePlayerAccountEntity_3(Nullable_1_t1819850047  value)
	{
		___LoginTitlePlayerAccountEntity_3 = value;
	}

	inline static int32_t get_offset_of_PlayerSecret_4() { return static_cast<int32_t>(offsetof(LoginWithGoogleAccountRequest_t513675687, ___PlayerSecret_4)); }
	inline String_t* get_PlayerSecret_4() const { return ___PlayerSecret_4; }
	inline String_t** get_address_of_PlayerSecret_4() { return &___PlayerSecret_4; }
	inline void set_PlayerSecret_4(String_t* value)
	{
		___PlayerSecret_4 = value;
		Il2CppCodeGenWriteBarrier((&___PlayerSecret_4), value);
	}

	inline static int32_t get_offset_of_ServerAuthCode_5() { return static_cast<int32_t>(offsetof(LoginWithGoogleAccountRequest_t513675687, ___ServerAuthCode_5)); }
	inline String_t* get_ServerAuthCode_5() const { return ___ServerAuthCode_5; }
	inline String_t** get_address_of_ServerAuthCode_5() { return &___ServerAuthCode_5; }
	inline void set_ServerAuthCode_5(String_t* value)
	{
		___ServerAuthCode_5 = value;
		Il2CppCodeGenWriteBarrier((&___ServerAuthCode_5), value);
	}

	inline static int32_t get_offset_of_TitleId_6() { return static_cast<int32_t>(offsetof(LoginWithGoogleAccountRequest_t513675687, ___TitleId_6)); }
	inline String_t* get_TitleId_6() const { return ___TitleId_6; }
	inline String_t** get_address_of_TitleId_6() { return &___TitleId_6; }
	inline void set_TitleId_6(String_t* value)
	{
		___TitleId_6 = value;
		Il2CppCodeGenWriteBarrier((&___TitleId_6), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LOGINWITHGOOGLEACCOUNTREQUEST_T513675687_H
#ifndef LOGINWITHIOSDEVICEIDREQUEST_T1104678395_H
#define LOGINWITHIOSDEVICEIDREQUEST_T1104678395_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.LoginWithIOSDeviceIDRequest
struct  LoginWithIOSDeviceIDRequest_t1104678395  : public PlayFabRequestCommon_t229319069
{
public:
	// System.Nullable`1<System.Boolean> PlayFab.ClientModels.LoginWithIOSDeviceIDRequest::CreateAccount
	Nullable_1_t1819850047  ___CreateAccount_0;
	// System.String PlayFab.ClientModels.LoginWithIOSDeviceIDRequest::DeviceId
	String_t* ___DeviceId_1;
	// System.String PlayFab.ClientModels.LoginWithIOSDeviceIDRequest::DeviceModel
	String_t* ___DeviceModel_2;
	// System.String PlayFab.ClientModels.LoginWithIOSDeviceIDRequest::EncryptedRequest
	String_t* ___EncryptedRequest_3;
	// PlayFab.ClientModels.GetPlayerCombinedInfoRequestParams PlayFab.ClientModels.LoginWithIOSDeviceIDRequest::InfoRequestParameters
	GetPlayerCombinedInfoRequestParams_t121265087 * ___InfoRequestParameters_4;
	// System.Nullable`1<System.Boolean> PlayFab.ClientModels.LoginWithIOSDeviceIDRequest::LoginTitlePlayerAccountEntity
	Nullable_1_t1819850047  ___LoginTitlePlayerAccountEntity_5;
	// System.String PlayFab.ClientModels.LoginWithIOSDeviceIDRequest::OS
	String_t* ___OS_6;
	// System.String PlayFab.ClientModels.LoginWithIOSDeviceIDRequest::PlayerSecret
	String_t* ___PlayerSecret_7;
	// System.String PlayFab.ClientModels.LoginWithIOSDeviceIDRequest::TitleId
	String_t* ___TitleId_8;

public:
	inline static int32_t get_offset_of_CreateAccount_0() { return static_cast<int32_t>(offsetof(LoginWithIOSDeviceIDRequest_t1104678395, ___CreateAccount_0)); }
	inline Nullable_1_t1819850047  get_CreateAccount_0() const { return ___CreateAccount_0; }
	inline Nullable_1_t1819850047 * get_address_of_CreateAccount_0() { return &___CreateAccount_0; }
	inline void set_CreateAccount_0(Nullable_1_t1819850047  value)
	{
		___CreateAccount_0 = value;
	}

	inline static int32_t get_offset_of_DeviceId_1() { return static_cast<int32_t>(offsetof(LoginWithIOSDeviceIDRequest_t1104678395, ___DeviceId_1)); }
	inline String_t* get_DeviceId_1() const { return ___DeviceId_1; }
	inline String_t** get_address_of_DeviceId_1() { return &___DeviceId_1; }
	inline void set_DeviceId_1(String_t* value)
	{
		___DeviceId_1 = value;
		Il2CppCodeGenWriteBarrier((&___DeviceId_1), value);
	}

	inline static int32_t get_offset_of_DeviceModel_2() { return static_cast<int32_t>(offsetof(LoginWithIOSDeviceIDRequest_t1104678395, ___DeviceModel_2)); }
	inline String_t* get_DeviceModel_2() const { return ___DeviceModel_2; }
	inline String_t** get_address_of_DeviceModel_2() { return &___DeviceModel_2; }
	inline void set_DeviceModel_2(String_t* value)
	{
		___DeviceModel_2 = value;
		Il2CppCodeGenWriteBarrier((&___DeviceModel_2), value);
	}

	inline static int32_t get_offset_of_EncryptedRequest_3() { return static_cast<int32_t>(offsetof(LoginWithIOSDeviceIDRequest_t1104678395, ___EncryptedRequest_3)); }
	inline String_t* get_EncryptedRequest_3() const { return ___EncryptedRequest_3; }
	inline String_t** get_address_of_EncryptedRequest_3() { return &___EncryptedRequest_3; }
	inline void set_EncryptedRequest_3(String_t* value)
	{
		___EncryptedRequest_3 = value;
		Il2CppCodeGenWriteBarrier((&___EncryptedRequest_3), value);
	}

	inline static int32_t get_offset_of_InfoRequestParameters_4() { return static_cast<int32_t>(offsetof(LoginWithIOSDeviceIDRequest_t1104678395, ___InfoRequestParameters_4)); }
	inline GetPlayerCombinedInfoRequestParams_t121265087 * get_InfoRequestParameters_4() const { return ___InfoRequestParameters_4; }
	inline GetPlayerCombinedInfoRequestParams_t121265087 ** get_address_of_InfoRequestParameters_4() { return &___InfoRequestParameters_4; }
	inline void set_InfoRequestParameters_4(GetPlayerCombinedInfoRequestParams_t121265087 * value)
	{
		___InfoRequestParameters_4 = value;
		Il2CppCodeGenWriteBarrier((&___InfoRequestParameters_4), value);
	}

	inline static int32_t get_offset_of_LoginTitlePlayerAccountEntity_5() { return static_cast<int32_t>(offsetof(LoginWithIOSDeviceIDRequest_t1104678395, ___LoginTitlePlayerAccountEntity_5)); }
	inline Nullable_1_t1819850047  get_LoginTitlePlayerAccountEntity_5() const { return ___LoginTitlePlayerAccountEntity_5; }
	inline Nullable_1_t1819850047 * get_address_of_LoginTitlePlayerAccountEntity_5() { return &___LoginTitlePlayerAccountEntity_5; }
	inline void set_LoginTitlePlayerAccountEntity_5(Nullable_1_t1819850047  value)
	{
		___LoginTitlePlayerAccountEntity_5 = value;
	}

	inline static int32_t get_offset_of_OS_6() { return static_cast<int32_t>(offsetof(LoginWithIOSDeviceIDRequest_t1104678395, ___OS_6)); }
	inline String_t* get_OS_6() const { return ___OS_6; }
	inline String_t** get_address_of_OS_6() { return &___OS_6; }
	inline void set_OS_6(String_t* value)
	{
		___OS_6 = value;
		Il2CppCodeGenWriteBarrier((&___OS_6), value);
	}

	inline static int32_t get_offset_of_PlayerSecret_7() { return static_cast<int32_t>(offsetof(LoginWithIOSDeviceIDRequest_t1104678395, ___PlayerSecret_7)); }
	inline String_t* get_PlayerSecret_7() const { return ___PlayerSecret_7; }
	inline String_t** get_address_of_PlayerSecret_7() { return &___PlayerSecret_7; }
	inline void set_PlayerSecret_7(String_t* value)
	{
		___PlayerSecret_7 = value;
		Il2CppCodeGenWriteBarrier((&___PlayerSecret_7), value);
	}

	inline static int32_t get_offset_of_TitleId_8() { return static_cast<int32_t>(offsetof(LoginWithIOSDeviceIDRequest_t1104678395, ___TitleId_8)); }
	inline String_t* get_TitleId_8() const { return ___TitleId_8; }
	inline String_t** get_address_of_TitleId_8() { return &___TitleId_8; }
	inline void set_TitleId_8(String_t* value)
	{
		___TitleId_8 = value;
		Il2CppCodeGenWriteBarrier((&___TitleId_8), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LOGINWITHIOSDEVICEIDREQUEST_T1104678395_H
#ifndef LOGINWITHFACEBOOKREQUEST_T553021538_H
#define LOGINWITHFACEBOOKREQUEST_T553021538_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.LoginWithFacebookRequest
struct  LoginWithFacebookRequest_t553021538  : public PlayFabRequestCommon_t229319069
{
public:
	// System.String PlayFab.ClientModels.LoginWithFacebookRequest::AccessToken
	String_t* ___AccessToken_0;
	// System.Nullable`1<System.Boolean> PlayFab.ClientModels.LoginWithFacebookRequest::CreateAccount
	Nullable_1_t1819850047  ___CreateAccount_1;
	// System.String PlayFab.ClientModels.LoginWithFacebookRequest::EncryptedRequest
	String_t* ___EncryptedRequest_2;
	// PlayFab.ClientModels.GetPlayerCombinedInfoRequestParams PlayFab.ClientModels.LoginWithFacebookRequest::InfoRequestParameters
	GetPlayerCombinedInfoRequestParams_t121265087 * ___InfoRequestParameters_3;
	// System.Nullable`1<System.Boolean> PlayFab.ClientModels.LoginWithFacebookRequest::LoginTitlePlayerAccountEntity
	Nullable_1_t1819850047  ___LoginTitlePlayerAccountEntity_4;
	// System.String PlayFab.ClientModels.LoginWithFacebookRequest::PlayerSecret
	String_t* ___PlayerSecret_5;
	// System.String PlayFab.ClientModels.LoginWithFacebookRequest::TitleId
	String_t* ___TitleId_6;

public:
	inline static int32_t get_offset_of_AccessToken_0() { return static_cast<int32_t>(offsetof(LoginWithFacebookRequest_t553021538, ___AccessToken_0)); }
	inline String_t* get_AccessToken_0() const { return ___AccessToken_0; }
	inline String_t** get_address_of_AccessToken_0() { return &___AccessToken_0; }
	inline void set_AccessToken_0(String_t* value)
	{
		___AccessToken_0 = value;
		Il2CppCodeGenWriteBarrier((&___AccessToken_0), value);
	}

	inline static int32_t get_offset_of_CreateAccount_1() { return static_cast<int32_t>(offsetof(LoginWithFacebookRequest_t553021538, ___CreateAccount_1)); }
	inline Nullable_1_t1819850047  get_CreateAccount_1() const { return ___CreateAccount_1; }
	inline Nullable_1_t1819850047 * get_address_of_CreateAccount_1() { return &___CreateAccount_1; }
	inline void set_CreateAccount_1(Nullable_1_t1819850047  value)
	{
		___CreateAccount_1 = value;
	}

	inline static int32_t get_offset_of_EncryptedRequest_2() { return static_cast<int32_t>(offsetof(LoginWithFacebookRequest_t553021538, ___EncryptedRequest_2)); }
	inline String_t* get_EncryptedRequest_2() const { return ___EncryptedRequest_2; }
	inline String_t** get_address_of_EncryptedRequest_2() { return &___EncryptedRequest_2; }
	inline void set_EncryptedRequest_2(String_t* value)
	{
		___EncryptedRequest_2 = value;
		Il2CppCodeGenWriteBarrier((&___EncryptedRequest_2), value);
	}

	inline static int32_t get_offset_of_InfoRequestParameters_3() { return static_cast<int32_t>(offsetof(LoginWithFacebookRequest_t553021538, ___InfoRequestParameters_3)); }
	inline GetPlayerCombinedInfoRequestParams_t121265087 * get_InfoRequestParameters_3() const { return ___InfoRequestParameters_3; }
	inline GetPlayerCombinedInfoRequestParams_t121265087 ** get_address_of_InfoRequestParameters_3() { return &___InfoRequestParameters_3; }
	inline void set_InfoRequestParameters_3(GetPlayerCombinedInfoRequestParams_t121265087 * value)
	{
		___InfoRequestParameters_3 = value;
		Il2CppCodeGenWriteBarrier((&___InfoRequestParameters_3), value);
	}

	inline static int32_t get_offset_of_LoginTitlePlayerAccountEntity_4() { return static_cast<int32_t>(offsetof(LoginWithFacebookRequest_t553021538, ___LoginTitlePlayerAccountEntity_4)); }
	inline Nullable_1_t1819850047  get_LoginTitlePlayerAccountEntity_4() const { return ___LoginTitlePlayerAccountEntity_4; }
	inline Nullable_1_t1819850047 * get_address_of_LoginTitlePlayerAccountEntity_4() { return &___LoginTitlePlayerAccountEntity_4; }
	inline void set_LoginTitlePlayerAccountEntity_4(Nullable_1_t1819850047  value)
	{
		___LoginTitlePlayerAccountEntity_4 = value;
	}

	inline static int32_t get_offset_of_PlayerSecret_5() { return static_cast<int32_t>(offsetof(LoginWithFacebookRequest_t553021538, ___PlayerSecret_5)); }
	inline String_t* get_PlayerSecret_5() const { return ___PlayerSecret_5; }
	inline String_t** get_address_of_PlayerSecret_5() { return &___PlayerSecret_5; }
	inline void set_PlayerSecret_5(String_t* value)
	{
		___PlayerSecret_5 = value;
		Il2CppCodeGenWriteBarrier((&___PlayerSecret_5), value);
	}

	inline static int32_t get_offset_of_TitleId_6() { return static_cast<int32_t>(offsetof(LoginWithFacebookRequest_t553021538, ___TitleId_6)); }
	inline String_t* get_TitleId_6() const { return ___TitleId_6; }
	inline String_t** get_address_of_TitleId_6() { return &___TitleId_6; }
	inline void set_TitleId_6(String_t* value)
	{
		___TitleId_6 = value;
		Il2CppCodeGenWriteBarrier((&___TitleId_6), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LOGINWITHFACEBOOKREQUEST_T553021538_H
#ifndef LOGINWITHGAMECENTERREQUEST_T195971591_H
#define LOGINWITHGAMECENTERREQUEST_T195971591_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.LoginWithGameCenterRequest
struct  LoginWithGameCenterRequest_t195971591  : public PlayFabRequestCommon_t229319069
{
public:
	// System.Nullable`1<System.Boolean> PlayFab.ClientModels.LoginWithGameCenterRequest::CreateAccount
	Nullable_1_t1819850047  ___CreateAccount_0;
	// System.String PlayFab.ClientModels.LoginWithGameCenterRequest::EncryptedRequest
	String_t* ___EncryptedRequest_1;
	// PlayFab.ClientModels.GetPlayerCombinedInfoRequestParams PlayFab.ClientModels.LoginWithGameCenterRequest::InfoRequestParameters
	GetPlayerCombinedInfoRequestParams_t121265087 * ___InfoRequestParameters_2;
	// System.Nullable`1<System.Boolean> PlayFab.ClientModels.LoginWithGameCenterRequest::LoginTitlePlayerAccountEntity
	Nullable_1_t1819850047  ___LoginTitlePlayerAccountEntity_3;
	// System.String PlayFab.ClientModels.LoginWithGameCenterRequest::PlayerId
	String_t* ___PlayerId_4;
	// System.String PlayFab.ClientModels.LoginWithGameCenterRequest::PlayerSecret
	String_t* ___PlayerSecret_5;
	// System.String PlayFab.ClientModels.LoginWithGameCenterRequest::TitleId
	String_t* ___TitleId_6;

public:
	inline static int32_t get_offset_of_CreateAccount_0() { return static_cast<int32_t>(offsetof(LoginWithGameCenterRequest_t195971591, ___CreateAccount_0)); }
	inline Nullable_1_t1819850047  get_CreateAccount_0() const { return ___CreateAccount_0; }
	inline Nullable_1_t1819850047 * get_address_of_CreateAccount_0() { return &___CreateAccount_0; }
	inline void set_CreateAccount_0(Nullable_1_t1819850047  value)
	{
		___CreateAccount_0 = value;
	}

	inline static int32_t get_offset_of_EncryptedRequest_1() { return static_cast<int32_t>(offsetof(LoginWithGameCenterRequest_t195971591, ___EncryptedRequest_1)); }
	inline String_t* get_EncryptedRequest_1() const { return ___EncryptedRequest_1; }
	inline String_t** get_address_of_EncryptedRequest_1() { return &___EncryptedRequest_1; }
	inline void set_EncryptedRequest_1(String_t* value)
	{
		___EncryptedRequest_1 = value;
		Il2CppCodeGenWriteBarrier((&___EncryptedRequest_1), value);
	}

	inline static int32_t get_offset_of_InfoRequestParameters_2() { return static_cast<int32_t>(offsetof(LoginWithGameCenterRequest_t195971591, ___InfoRequestParameters_2)); }
	inline GetPlayerCombinedInfoRequestParams_t121265087 * get_InfoRequestParameters_2() const { return ___InfoRequestParameters_2; }
	inline GetPlayerCombinedInfoRequestParams_t121265087 ** get_address_of_InfoRequestParameters_2() { return &___InfoRequestParameters_2; }
	inline void set_InfoRequestParameters_2(GetPlayerCombinedInfoRequestParams_t121265087 * value)
	{
		___InfoRequestParameters_2 = value;
		Il2CppCodeGenWriteBarrier((&___InfoRequestParameters_2), value);
	}

	inline static int32_t get_offset_of_LoginTitlePlayerAccountEntity_3() { return static_cast<int32_t>(offsetof(LoginWithGameCenterRequest_t195971591, ___LoginTitlePlayerAccountEntity_3)); }
	inline Nullable_1_t1819850047  get_LoginTitlePlayerAccountEntity_3() const { return ___LoginTitlePlayerAccountEntity_3; }
	inline Nullable_1_t1819850047 * get_address_of_LoginTitlePlayerAccountEntity_3() { return &___LoginTitlePlayerAccountEntity_3; }
	inline void set_LoginTitlePlayerAccountEntity_3(Nullable_1_t1819850047  value)
	{
		___LoginTitlePlayerAccountEntity_3 = value;
	}

	inline static int32_t get_offset_of_PlayerId_4() { return static_cast<int32_t>(offsetof(LoginWithGameCenterRequest_t195971591, ___PlayerId_4)); }
	inline String_t* get_PlayerId_4() const { return ___PlayerId_4; }
	inline String_t** get_address_of_PlayerId_4() { return &___PlayerId_4; }
	inline void set_PlayerId_4(String_t* value)
	{
		___PlayerId_4 = value;
		Il2CppCodeGenWriteBarrier((&___PlayerId_4), value);
	}

	inline static int32_t get_offset_of_PlayerSecret_5() { return static_cast<int32_t>(offsetof(LoginWithGameCenterRequest_t195971591, ___PlayerSecret_5)); }
	inline String_t* get_PlayerSecret_5() const { return ___PlayerSecret_5; }
	inline String_t** get_address_of_PlayerSecret_5() { return &___PlayerSecret_5; }
	inline void set_PlayerSecret_5(String_t* value)
	{
		___PlayerSecret_5 = value;
		Il2CppCodeGenWriteBarrier((&___PlayerSecret_5), value);
	}

	inline static int32_t get_offset_of_TitleId_6() { return static_cast<int32_t>(offsetof(LoginWithGameCenterRequest_t195971591, ___TitleId_6)); }
	inline String_t* get_TitleId_6() const { return ___TitleId_6; }
	inline String_t** get_address_of_TitleId_6() { return &___TitleId_6; }
	inline void set_TitleId_6(String_t* value)
	{
		___TitleId_6 = value;
		Il2CppCodeGenWriteBarrier((&___TitleId_6), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LOGINWITHGAMECENTERREQUEST_T195971591_H
#ifndef LINKFACEBOOKACCOUNTREQUEST_T206724149_H
#define LINKFACEBOOKACCOUNTREQUEST_T206724149_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.LinkFacebookAccountRequest
struct  LinkFacebookAccountRequest_t206724149  : public PlayFabRequestCommon_t229319069
{
public:
	// System.String PlayFab.ClientModels.LinkFacebookAccountRequest::AccessToken
	String_t* ___AccessToken_0;
	// System.Nullable`1<System.Boolean> PlayFab.ClientModels.LinkFacebookAccountRequest::ForceLink
	Nullable_1_t1819850047  ___ForceLink_1;

public:
	inline static int32_t get_offset_of_AccessToken_0() { return static_cast<int32_t>(offsetof(LinkFacebookAccountRequest_t206724149, ___AccessToken_0)); }
	inline String_t* get_AccessToken_0() const { return ___AccessToken_0; }
	inline String_t** get_address_of_AccessToken_0() { return &___AccessToken_0; }
	inline void set_AccessToken_0(String_t* value)
	{
		___AccessToken_0 = value;
		Il2CppCodeGenWriteBarrier((&___AccessToken_0), value);
	}

	inline static int32_t get_offset_of_ForceLink_1() { return static_cast<int32_t>(offsetof(LinkFacebookAccountRequest_t206724149, ___ForceLink_1)); }
	inline Nullable_1_t1819850047  get_ForceLink_1() const { return ___ForceLink_1; }
	inline Nullable_1_t1819850047 * get_address_of_ForceLink_1() { return &___ForceLink_1; }
	inline void set_ForceLink_1(Nullable_1_t1819850047  value)
	{
		___ForceLink_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LINKFACEBOOKACCOUNTREQUEST_T206724149_H
#ifndef LINKGAMECENTERACCOUNTREQUEST_T2735439760_H
#define LINKGAMECENTERACCOUNTREQUEST_T2735439760_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.LinkGameCenterAccountRequest
struct  LinkGameCenterAccountRequest_t2735439760  : public PlayFabRequestCommon_t229319069
{
public:
	// System.Nullable`1<System.Boolean> PlayFab.ClientModels.LinkGameCenterAccountRequest::ForceLink
	Nullable_1_t1819850047  ___ForceLink_0;
	// System.String PlayFab.ClientModels.LinkGameCenterAccountRequest::GameCenterId
	String_t* ___GameCenterId_1;

public:
	inline static int32_t get_offset_of_ForceLink_0() { return static_cast<int32_t>(offsetof(LinkGameCenterAccountRequest_t2735439760, ___ForceLink_0)); }
	inline Nullable_1_t1819850047  get_ForceLink_0() const { return ___ForceLink_0; }
	inline Nullable_1_t1819850047 * get_address_of_ForceLink_0() { return &___ForceLink_0; }
	inline void set_ForceLink_0(Nullable_1_t1819850047  value)
	{
		___ForceLink_0 = value;
	}

	inline static int32_t get_offset_of_GameCenterId_1() { return static_cast<int32_t>(offsetof(LinkGameCenterAccountRequest_t2735439760, ___GameCenterId_1)); }
	inline String_t* get_GameCenterId_1() const { return ___GameCenterId_1; }
	inline String_t** get_address_of_GameCenterId_1() { return &___GameCenterId_1; }
	inline void set_GameCenterId_1(String_t* value)
	{
		___GameCenterId_1 = value;
		Il2CppCodeGenWriteBarrier((&___GameCenterId_1), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LINKGAMECENTERACCOUNTREQUEST_T2735439760_H
#ifndef LINKANDROIDDEVICEIDREQUEST_T254733486_H
#define LINKANDROIDDEVICEIDREQUEST_T254733486_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.LinkAndroidDeviceIDRequest
struct  LinkAndroidDeviceIDRequest_t254733486  : public PlayFabRequestCommon_t229319069
{
public:
	// System.String PlayFab.ClientModels.LinkAndroidDeviceIDRequest::AndroidDevice
	String_t* ___AndroidDevice_0;
	// System.String PlayFab.ClientModels.LinkAndroidDeviceIDRequest::AndroidDeviceId
	String_t* ___AndroidDeviceId_1;
	// System.Nullable`1<System.Boolean> PlayFab.ClientModels.LinkAndroidDeviceIDRequest::ForceLink
	Nullable_1_t1819850047  ___ForceLink_2;
	// System.String PlayFab.ClientModels.LinkAndroidDeviceIDRequest::OS
	String_t* ___OS_3;

public:
	inline static int32_t get_offset_of_AndroidDevice_0() { return static_cast<int32_t>(offsetof(LinkAndroidDeviceIDRequest_t254733486, ___AndroidDevice_0)); }
	inline String_t* get_AndroidDevice_0() const { return ___AndroidDevice_0; }
	inline String_t** get_address_of_AndroidDevice_0() { return &___AndroidDevice_0; }
	inline void set_AndroidDevice_0(String_t* value)
	{
		___AndroidDevice_0 = value;
		Il2CppCodeGenWriteBarrier((&___AndroidDevice_0), value);
	}

	inline static int32_t get_offset_of_AndroidDeviceId_1() { return static_cast<int32_t>(offsetof(LinkAndroidDeviceIDRequest_t254733486, ___AndroidDeviceId_1)); }
	inline String_t* get_AndroidDeviceId_1() const { return ___AndroidDeviceId_1; }
	inline String_t** get_address_of_AndroidDeviceId_1() { return &___AndroidDeviceId_1; }
	inline void set_AndroidDeviceId_1(String_t* value)
	{
		___AndroidDeviceId_1 = value;
		Il2CppCodeGenWriteBarrier((&___AndroidDeviceId_1), value);
	}

	inline static int32_t get_offset_of_ForceLink_2() { return static_cast<int32_t>(offsetof(LinkAndroidDeviceIDRequest_t254733486, ___ForceLink_2)); }
	inline Nullable_1_t1819850047  get_ForceLink_2() const { return ___ForceLink_2; }
	inline Nullable_1_t1819850047 * get_address_of_ForceLink_2() { return &___ForceLink_2; }
	inline void set_ForceLink_2(Nullable_1_t1819850047  value)
	{
		___ForceLink_2 = value;
	}

	inline static int32_t get_offset_of_OS_3() { return static_cast<int32_t>(offsetof(LinkAndroidDeviceIDRequest_t254733486, ___OS_3)); }
	inline String_t* get_OS_3() const { return ___OS_3; }
	inline String_t** get_address_of_OS_3() { return &___OS_3; }
	inline void set_OS_3(String_t* value)
	{
		___OS_3 = value;
		Il2CppCodeGenWriteBarrier((&___OS_3), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LINKANDROIDDEVICEIDREQUEST_T254733486_H
#ifndef LINKCUSTOMIDREQUEST_T2139586330_H
#define LINKCUSTOMIDREQUEST_T2139586330_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.LinkCustomIDRequest
struct  LinkCustomIDRequest_t2139586330  : public PlayFabRequestCommon_t229319069
{
public:
	// System.String PlayFab.ClientModels.LinkCustomIDRequest::CustomId
	String_t* ___CustomId_0;
	// System.Nullable`1<System.Boolean> PlayFab.ClientModels.LinkCustomIDRequest::ForceLink
	Nullable_1_t1819850047  ___ForceLink_1;

public:
	inline static int32_t get_offset_of_CustomId_0() { return static_cast<int32_t>(offsetof(LinkCustomIDRequest_t2139586330, ___CustomId_0)); }
	inline String_t* get_CustomId_0() const { return ___CustomId_0; }
	inline String_t** get_address_of_CustomId_0() { return &___CustomId_0; }
	inline void set_CustomId_0(String_t* value)
	{
		___CustomId_0 = value;
		Il2CppCodeGenWriteBarrier((&___CustomId_0), value);
	}

	inline static int32_t get_offset_of_ForceLink_1() { return static_cast<int32_t>(offsetof(LinkCustomIDRequest_t2139586330, ___ForceLink_1)); }
	inline Nullable_1_t1819850047  get_ForceLink_1() const { return ___ForceLink_1; }
	inline Nullable_1_t1819850047 * get_address_of_ForceLink_1() { return &___ForceLink_1; }
	inline void set_ForceLink_1(Nullable_1_t1819850047  value)
	{
		___ForceLink_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LINKCUSTOMIDREQUEST_T2139586330_H
#ifndef LINKGOOGLEACCOUNTREQUEST_T1583516147_H
#define LINKGOOGLEACCOUNTREQUEST_T1583516147_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.LinkGoogleAccountRequest
struct  LinkGoogleAccountRequest_t1583516147  : public PlayFabRequestCommon_t229319069
{
public:
	// System.Nullable`1<System.Boolean> PlayFab.ClientModels.LinkGoogleAccountRequest::ForceLink
	Nullable_1_t1819850047  ___ForceLink_0;
	// System.String PlayFab.ClientModels.LinkGoogleAccountRequest::ServerAuthCode
	String_t* ___ServerAuthCode_1;

public:
	inline static int32_t get_offset_of_ForceLink_0() { return static_cast<int32_t>(offsetof(LinkGoogleAccountRequest_t1583516147, ___ForceLink_0)); }
	inline Nullable_1_t1819850047  get_ForceLink_0() const { return ___ForceLink_0; }
	inline Nullable_1_t1819850047 * get_address_of_ForceLink_0() { return &___ForceLink_0; }
	inline void set_ForceLink_0(Nullable_1_t1819850047  value)
	{
		___ForceLink_0 = value;
	}

	inline static int32_t get_offset_of_ServerAuthCode_1() { return static_cast<int32_t>(offsetof(LinkGoogleAccountRequest_t1583516147, ___ServerAuthCode_1)); }
	inline String_t* get_ServerAuthCode_1() const { return ___ServerAuthCode_1; }
	inline String_t** get_address_of_ServerAuthCode_1() { return &___ServerAuthCode_1; }
	inline void set_ServerAuthCode_1(String_t* value)
	{
		___ServerAuthCode_1 = value;
		Il2CppCodeGenWriteBarrier((&___ServerAuthCode_1), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LINKGOOGLEACCOUNTREQUEST_T1583516147_H
#ifndef LINKSTEAMACCOUNTREQUEST_T3315598358_H
#define LINKSTEAMACCOUNTREQUEST_T3315598358_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.LinkSteamAccountRequest
struct  LinkSteamAccountRequest_t3315598358  : public PlayFabRequestCommon_t229319069
{
public:
	// System.Nullable`1<System.Boolean> PlayFab.ClientModels.LinkSteamAccountRequest::ForceLink
	Nullable_1_t1819850047  ___ForceLink_0;
	// System.String PlayFab.ClientModels.LinkSteamAccountRequest::SteamTicket
	String_t* ___SteamTicket_1;

public:
	inline static int32_t get_offset_of_ForceLink_0() { return static_cast<int32_t>(offsetof(LinkSteamAccountRequest_t3315598358, ___ForceLink_0)); }
	inline Nullable_1_t1819850047  get_ForceLink_0() const { return ___ForceLink_0; }
	inline Nullable_1_t1819850047 * get_address_of_ForceLink_0() { return &___ForceLink_0; }
	inline void set_ForceLink_0(Nullable_1_t1819850047  value)
	{
		___ForceLink_0 = value;
	}

	inline static int32_t get_offset_of_SteamTicket_1() { return static_cast<int32_t>(offsetof(LinkSteamAccountRequest_t3315598358, ___SteamTicket_1)); }
	inline String_t* get_SteamTicket_1() const { return ___SteamTicket_1; }
	inline String_t** get_address_of_SteamTicket_1() { return &___SteamTicket_1; }
	inline void set_SteamTicket_1(String_t* value)
	{
		___SteamTicket_1 = value;
		Il2CppCodeGenWriteBarrier((&___SteamTicket_1), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LINKSTEAMACCOUNTREQUEST_T3315598358_H
#ifndef LINKTWITCHACCOUNTREQUEST_T1241952066_H
#define LINKTWITCHACCOUNTREQUEST_T1241952066_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.LinkTwitchAccountRequest
struct  LinkTwitchAccountRequest_t1241952066  : public PlayFabRequestCommon_t229319069
{
public:
	// System.String PlayFab.ClientModels.LinkTwitchAccountRequest::AccessToken
	String_t* ___AccessToken_0;
	// System.Nullable`1<System.Boolean> PlayFab.ClientModels.LinkTwitchAccountRequest::ForceLink
	Nullable_1_t1819850047  ___ForceLink_1;

public:
	inline static int32_t get_offset_of_AccessToken_0() { return static_cast<int32_t>(offsetof(LinkTwitchAccountRequest_t1241952066, ___AccessToken_0)); }
	inline String_t* get_AccessToken_0() const { return ___AccessToken_0; }
	inline String_t** get_address_of_AccessToken_0() { return &___AccessToken_0; }
	inline void set_AccessToken_0(String_t* value)
	{
		___AccessToken_0 = value;
		Il2CppCodeGenWriteBarrier((&___AccessToken_0), value);
	}

	inline static int32_t get_offset_of_ForceLink_1() { return static_cast<int32_t>(offsetof(LinkTwitchAccountRequest_t1241952066, ___ForceLink_1)); }
	inline Nullable_1_t1819850047  get_ForceLink_1() const { return ___ForceLink_1; }
	inline Nullable_1_t1819850047 * get_address_of_ForceLink_1() { return &___ForceLink_1; }
	inline void set_ForceLink_1(Nullable_1_t1819850047  value)
	{
		___ForceLink_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LINKTWITCHACCOUNTREQUEST_T1241952066_H
#ifndef LINKIOSDEVICEIDREQUEST_T732156087_H
#define LINKIOSDEVICEIDREQUEST_T732156087_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.LinkIOSDeviceIDRequest
struct  LinkIOSDeviceIDRequest_t732156087  : public PlayFabRequestCommon_t229319069
{
public:
	// System.String PlayFab.ClientModels.LinkIOSDeviceIDRequest::DeviceId
	String_t* ___DeviceId_0;
	// System.String PlayFab.ClientModels.LinkIOSDeviceIDRequest::DeviceModel
	String_t* ___DeviceModel_1;
	// System.Nullable`1<System.Boolean> PlayFab.ClientModels.LinkIOSDeviceIDRequest::ForceLink
	Nullable_1_t1819850047  ___ForceLink_2;
	// System.String PlayFab.ClientModels.LinkIOSDeviceIDRequest::OS
	String_t* ___OS_3;

public:
	inline static int32_t get_offset_of_DeviceId_0() { return static_cast<int32_t>(offsetof(LinkIOSDeviceIDRequest_t732156087, ___DeviceId_0)); }
	inline String_t* get_DeviceId_0() const { return ___DeviceId_0; }
	inline String_t** get_address_of_DeviceId_0() { return &___DeviceId_0; }
	inline void set_DeviceId_0(String_t* value)
	{
		___DeviceId_0 = value;
		Il2CppCodeGenWriteBarrier((&___DeviceId_0), value);
	}

	inline static int32_t get_offset_of_DeviceModel_1() { return static_cast<int32_t>(offsetof(LinkIOSDeviceIDRequest_t732156087, ___DeviceModel_1)); }
	inline String_t* get_DeviceModel_1() const { return ___DeviceModel_1; }
	inline String_t** get_address_of_DeviceModel_1() { return &___DeviceModel_1; }
	inline void set_DeviceModel_1(String_t* value)
	{
		___DeviceModel_1 = value;
		Il2CppCodeGenWriteBarrier((&___DeviceModel_1), value);
	}

	inline static int32_t get_offset_of_ForceLink_2() { return static_cast<int32_t>(offsetof(LinkIOSDeviceIDRequest_t732156087, ___ForceLink_2)); }
	inline Nullable_1_t1819850047  get_ForceLink_2() const { return ___ForceLink_2; }
	inline Nullable_1_t1819850047 * get_address_of_ForceLink_2() { return &___ForceLink_2; }
	inline void set_ForceLink_2(Nullable_1_t1819850047  value)
	{
		___ForceLink_2 = value;
	}

	inline static int32_t get_offset_of_OS_3() { return static_cast<int32_t>(offsetof(LinkIOSDeviceIDRequest_t732156087, ___OS_3)); }
	inline String_t* get_OS_3() const { return ___OS_3; }
	inline String_t** get_address_of_OS_3() { return &___OS_3; }
	inline void set_OS_3(String_t* value)
	{
		___OS_3 = value;
		Il2CppCodeGenWriteBarrier((&___OS_3), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LINKIOSDEVICEIDREQUEST_T732156087_H
#ifndef LINKKONGREGATEACCOUNTREQUEST_T2767208911_H
#define LINKKONGREGATEACCOUNTREQUEST_T2767208911_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.LinkKongregateAccountRequest
struct  LinkKongregateAccountRequest_t2767208911  : public PlayFabRequestCommon_t229319069
{
public:
	// System.String PlayFab.ClientModels.LinkKongregateAccountRequest::AuthTicket
	String_t* ___AuthTicket_0;
	// System.Nullable`1<System.Boolean> PlayFab.ClientModels.LinkKongregateAccountRequest::ForceLink
	Nullable_1_t1819850047  ___ForceLink_1;
	// System.String PlayFab.ClientModels.LinkKongregateAccountRequest::KongregateId
	String_t* ___KongregateId_2;

public:
	inline static int32_t get_offset_of_AuthTicket_0() { return static_cast<int32_t>(offsetof(LinkKongregateAccountRequest_t2767208911, ___AuthTicket_0)); }
	inline String_t* get_AuthTicket_0() const { return ___AuthTicket_0; }
	inline String_t** get_address_of_AuthTicket_0() { return &___AuthTicket_0; }
	inline void set_AuthTicket_0(String_t* value)
	{
		___AuthTicket_0 = value;
		Il2CppCodeGenWriteBarrier((&___AuthTicket_0), value);
	}

	inline static int32_t get_offset_of_ForceLink_1() { return static_cast<int32_t>(offsetof(LinkKongregateAccountRequest_t2767208911, ___ForceLink_1)); }
	inline Nullable_1_t1819850047  get_ForceLink_1() const { return ___ForceLink_1; }
	inline Nullable_1_t1819850047 * get_address_of_ForceLink_1() { return &___ForceLink_1; }
	inline void set_ForceLink_1(Nullable_1_t1819850047  value)
	{
		___ForceLink_1 = value;
	}

	inline static int32_t get_offset_of_KongregateId_2() { return static_cast<int32_t>(offsetof(LinkKongregateAccountRequest_t2767208911, ___KongregateId_2)); }
	inline String_t* get_KongregateId_2() const { return ___KongregateId_2; }
	inline String_t** get_address_of_KongregateId_2() { return &___KongregateId_2; }
	inline void set_KongregateId_2(String_t* value)
	{
		___KongregateId_2 = value;
		Il2CppCodeGenWriteBarrier((&___KongregateId_2), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LINKKONGREGATEACCOUNTREQUEST_T2767208911_H
#ifndef LOGINWITHWINDOWSHELLOREQUEST_T725081759_H
#define LOGINWITHWINDOWSHELLOREQUEST_T725081759_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.LoginWithWindowsHelloRequest
struct  LoginWithWindowsHelloRequest_t725081759  : public PlayFabRequestCommon_t229319069
{
public:
	// System.String PlayFab.ClientModels.LoginWithWindowsHelloRequest::ChallengeSignature
	String_t* ___ChallengeSignature_0;
	// PlayFab.ClientModels.GetPlayerCombinedInfoRequestParams PlayFab.ClientModels.LoginWithWindowsHelloRequest::InfoRequestParameters
	GetPlayerCombinedInfoRequestParams_t121265087 * ___InfoRequestParameters_1;
	// System.Nullable`1<System.Boolean> PlayFab.ClientModels.LoginWithWindowsHelloRequest::LoginTitlePlayerAccountEntity
	Nullable_1_t1819850047  ___LoginTitlePlayerAccountEntity_2;
	// System.String PlayFab.ClientModels.LoginWithWindowsHelloRequest::PublicKeyHint
	String_t* ___PublicKeyHint_3;
	// System.String PlayFab.ClientModels.LoginWithWindowsHelloRequest::TitleId
	String_t* ___TitleId_4;

public:
	inline static int32_t get_offset_of_ChallengeSignature_0() { return static_cast<int32_t>(offsetof(LoginWithWindowsHelloRequest_t725081759, ___ChallengeSignature_0)); }
	inline String_t* get_ChallengeSignature_0() const { return ___ChallengeSignature_0; }
	inline String_t** get_address_of_ChallengeSignature_0() { return &___ChallengeSignature_0; }
	inline void set_ChallengeSignature_0(String_t* value)
	{
		___ChallengeSignature_0 = value;
		Il2CppCodeGenWriteBarrier((&___ChallengeSignature_0), value);
	}

	inline static int32_t get_offset_of_InfoRequestParameters_1() { return static_cast<int32_t>(offsetof(LoginWithWindowsHelloRequest_t725081759, ___InfoRequestParameters_1)); }
	inline GetPlayerCombinedInfoRequestParams_t121265087 * get_InfoRequestParameters_1() const { return ___InfoRequestParameters_1; }
	inline GetPlayerCombinedInfoRequestParams_t121265087 ** get_address_of_InfoRequestParameters_1() { return &___InfoRequestParameters_1; }
	inline void set_InfoRequestParameters_1(GetPlayerCombinedInfoRequestParams_t121265087 * value)
	{
		___InfoRequestParameters_1 = value;
		Il2CppCodeGenWriteBarrier((&___InfoRequestParameters_1), value);
	}

	inline static int32_t get_offset_of_LoginTitlePlayerAccountEntity_2() { return static_cast<int32_t>(offsetof(LoginWithWindowsHelloRequest_t725081759, ___LoginTitlePlayerAccountEntity_2)); }
	inline Nullable_1_t1819850047  get_LoginTitlePlayerAccountEntity_2() const { return ___LoginTitlePlayerAccountEntity_2; }
	inline Nullable_1_t1819850047 * get_address_of_LoginTitlePlayerAccountEntity_2() { return &___LoginTitlePlayerAccountEntity_2; }
	inline void set_LoginTitlePlayerAccountEntity_2(Nullable_1_t1819850047  value)
	{
		___LoginTitlePlayerAccountEntity_2 = value;
	}

	inline static int32_t get_offset_of_PublicKeyHint_3() { return static_cast<int32_t>(offsetof(LoginWithWindowsHelloRequest_t725081759, ___PublicKeyHint_3)); }
	inline String_t* get_PublicKeyHint_3() const { return ___PublicKeyHint_3; }
	inline String_t** get_address_of_PublicKeyHint_3() { return &___PublicKeyHint_3; }
	inline void set_PublicKeyHint_3(String_t* value)
	{
		___PublicKeyHint_3 = value;
		Il2CppCodeGenWriteBarrier((&___PublicKeyHint_3), value);
	}

	inline static int32_t get_offset_of_TitleId_4() { return static_cast<int32_t>(offsetof(LoginWithWindowsHelloRequest_t725081759, ___TitleId_4)); }
	inline String_t* get_TitleId_4() const { return ___TitleId_4; }
	inline String_t** get_address_of_TitleId_4() { return &___TitleId_4; }
	inline void set_TitleId_4(String_t* value)
	{
		___TitleId_4 = value;
		Il2CppCodeGenWriteBarrier((&___TitleId_4), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LOGINWITHWINDOWSHELLOREQUEST_T725081759_H
#ifndef LOGINWITHTWITCHREQUEST_T1822909188_H
#define LOGINWITHTWITCHREQUEST_T1822909188_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.LoginWithTwitchRequest
struct  LoginWithTwitchRequest_t1822909188  : public PlayFabRequestCommon_t229319069
{
public:
	// System.String PlayFab.ClientModels.LoginWithTwitchRequest::AccessToken
	String_t* ___AccessToken_0;
	// System.Nullable`1<System.Boolean> PlayFab.ClientModels.LoginWithTwitchRequest::CreateAccount
	Nullable_1_t1819850047  ___CreateAccount_1;
	// System.String PlayFab.ClientModels.LoginWithTwitchRequest::EncryptedRequest
	String_t* ___EncryptedRequest_2;
	// PlayFab.ClientModels.GetPlayerCombinedInfoRequestParams PlayFab.ClientModels.LoginWithTwitchRequest::InfoRequestParameters
	GetPlayerCombinedInfoRequestParams_t121265087 * ___InfoRequestParameters_3;
	// System.Nullable`1<System.Boolean> PlayFab.ClientModels.LoginWithTwitchRequest::LoginTitlePlayerAccountEntity
	Nullable_1_t1819850047  ___LoginTitlePlayerAccountEntity_4;
	// System.String PlayFab.ClientModels.LoginWithTwitchRequest::PlayerSecret
	String_t* ___PlayerSecret_5;
	// System.String PlayFab.ClientModels.LoginWithTwitchRequest::TitleId
	String_t* ___TitleId_6;

public:
	inline static int32_t get_offset_of_AccessToken_0() { return static_cast<int32_t>(offsetof(LoginWithTwitchRequest_t1822909188, ___AccessToken_0)); }
	inline String_t* get_AccessToken_0() const { return ___AccessToken_0; }
	inline String_t** get_address_of_AccessToken_0() { return &___AccessToken_0; }
	inline void set_AccessToken_0(String_t* value)
	{
		___AccessToken_0 = value;
		Il2CppCodeGenWriteBarrier((&___AccessToken_0), value);
	}

	inline static int32_t get_offset_of_CreateAccount_1() { return static_cast<int32_t>(offsetof(LoginWithTwitchRequest_t1822909188, ___CreateAccount_1)); }
	inline Nullable_1_t1819850047  get_CreateAccount_1() const { return ___CreateAccount_1; }
	inline Nullable_1_t1819850047 * get_address_of_CreateAccount_1() { return &___CreateAccount_1; }
	inline void set_CreateAccount_1(Nullable_1_t1819850047  value)
	{
		___CreateAccount_1 = value;
	}

	inline static int32_t get_offset_of_EncryptedRequest_2() { return static_cast<int32_t>(offsetof(LoginWithTwitchRequest_t1822909188, ___EncryptedRequest_2)); }
	inline String_t* get_EncryptedRequest_2() const { return ___EncryptedRequest_2; }
	inline String_t** get_address_of_EncryptedRequest_2() { return &___EncryptedRequest_2; }
	inline void set_EncryptedRequest_2(String_t* value)
	{
		___EncryptedRequest_2 = value;
		Il2CppCodeGenWriteBarrier((&___EncryptedRequest_2), value);
	}

	inline static int32_t get_offset_of_InfoRequestParameters_3() { return static_cast<int32_t>(offsetof(LoginWithTwitchRequest_t1822909188, ___InfoRequestParameters_3)); }
	inline GetPlayerCombinedInfoRequestParams_t121265087 * get_InfoRequestParameters_3() const { return ___InfoRequestParameters_3; }
	inline GetPlayerCombinedInfoRequestParams_t121265087 ** get_address_of_InfoRequestParameters_3() { return &___InfoRequestParameters_3; }
	inline void set_InfoRequestParameters_3(GetPlayerCombinedInfoRequestParams_t121265087 * value)
	{
		___InfoRequestParameters_3 = value;
		Il2CppCodeGenWriteBarrier((&___InfoRequestParameters_3), value);
	}

	inline static int32_t get_offset_of_LoginTitlePlayerAccountEntity_4() { return static_cast<int32_t>(offsetof(LoginWithTwitchRequest_t1822909188, ___LoginTitlePlayerAccountEntity_4)); }
	inline Nullable_1_t1819850047  get_LoginTitlePlayerAccountEntity_4() const { return ___LoginTitlePlayerAccountEntity_4; }
	inline Nullable_1_t1819850047 * get_address_of_LoginTitlePlayerAccountEntity_4() { return &___LoginTitlePlayerAccountEntity_4; }
	inline void set_LoginTitlePlayerAccountEntity_4(Nullable_1_t1819850047  value)
	{
		___LoginTitlePlayerAccountEntity_4 = value;
	}

	inline static int32_t get_offset_of_PlayerSecret_5() { return static_cast<int32_t>(offsetof(LoginWithTwitchRequest_t1822909188, ___PlayerSecret_5)); }
	inline String_t* get_PlayerSecret_5() const { return ___PlayerSecret_5; }
	inline String_t** get_address_of_PlayerSecret_5() { return &___PlayerSecret_5; }
	inline void set_PlayerSecret_5(String_t* value)
	{
		___PlayerSecret_5 = value;
		Il2CppCodeGenWriteBarrier((&___PlayerSecret_5), value);
	}

	inline static int32_t get_offset_of_TitleId_6() { return static_cast<int32_t>(offsetof(LoginWithTwitchRequest_t1822909188, ___TitleId_6)); }
	inline String_t* get_TitleId_6() const { return ___TitleId_6; }
	inline String_t** get_address_of_TitleId_6() { return &___TitleId_6; }
	inline void set_TitleId_6(String_t* value)
	{
		___TitleId_6 = value;
		Il2CppCodeGenWriteBarrier((&___TitleId_6), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LOGINWITHTWITCHREQUEST_T1822909188_H
#ifndef REGION_T4198023226_H
#define REGION_T4198023226_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.Region
struct  Region_t4198023226 
{
public:
	// System.Int32 PlayFab.ClientModels.Region::value__
	int32_t ___value___1;

public:
	inline static int32_t get_offset_of_value___1() { return static_cast<int32_t>(offsetof(Region_t4198023226, ___value___1)); }
	inline int32_t get_value___1() const { return ___value___1; }
	inline int32_t* get_address_of_value___1() { return &___value___1; }
	inline void set_value___1(int32_t value)
	{
		___value___1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // REGION_T4198023226_H
#ifndef PUSHNOTIFICATIONPLATFORM_T675897761_H
#define PUSHNOTIFICATIONPLATFORM_T675897761_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.PushNotificationPlatform
struct  PushNotificationPlatform_t675897761 
{
public:
	// System.Int32 PlayFab.ClientModels.PushNotificationPlatform::value__
	int32_t ___value___1;

public:
	inline static int32_t get_offset_of_value___1() { return static_cast<int32_t>(offsetof(PushNotificationPlatform_t675897761, ___value___1)); }
	inline int32_t get_value___1() const { return ___value___1; }
	inline int32_t* get_address_of_value___1() { return &___value___1; }
	inline void set_value___1(int32_t value)
	{
		___value___1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // PUSHNOTIFICATIONPLATFORM_T675897761_H
#ifndef MATCHMAKESTATUS_T1217147204_H
#define MATCHMAKESTATUS_T1217147204_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.MatchmakeStatus
struct  MatchmakeStatus_t1217147204 
{
public:
	// System.Int32 PlayFab.ClientModels.MatchmakeStatus::value__
	int32_t ___value___1;

public:
	inline static int32_t get_offset_of_value___1() { return static_cast<int32_t>(offsetof(MatchmakeStatus_t1217147204, ___value___1)); }
	inline int32_t get_value___1() const { return ___value___1; }
	inline int32_t* get_address_of_value___1() { return &___value___1; }
	inline void set_value___1(int32_t value)
	{
		___value___1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // MATCHMAKESTATUS_T1217147204_H
#ifndef LOGINWITHKONGREGATEREQUEST_T2996684931_H
#define LOGINWITHKONGREGATEREQUEST_T2996684931_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.LoginWithKongregateRequest
struct  LoginWithKongregateRequest_t2996684931  : public PlayFabRequestCommon_t229319069
{
public:
	// System.String PlayFab.ClientModels.LoginWithKongregateRequest::AuthTicket
	String_t* ___AuthTicket_0;
	// System.Nullable`1<System.Boolean> PlayFab.ClientModels.LoginWithKongregateRequest::CreateAccount
	Nullable_1_t1819850047  ___CreateAccount_1;
	// System.String PlayFab.ClientModels.LoginWithKongregateRequest::EncryptedRequest
	String_t* ___EncryptedRequest_2;
	// PlayFab.ClientModels.GetPlayerCombinedInfoRequestParams PlayFab.ClientModels.LoginWithKongregateRequest::InfoRequestParameters
	GetPlayerCombinedInfoRequestParams_t121265087 * ___InfoRequestParameters_3;
	// System.String PlayFab.ClientModels.LoginWithKongregateRequest::KongregateId
	String_t* ___KongregateId_4;
	// System.Nullable`1<System.Boolean> PlayFab.ClientModels.LoginWithKongregateRequest::LoginTitlePlayerAccountEntity
	Nullable_1_t1819850047  ___LoginTitlePlayerAccountEntity_5;
	// System.String PlayFab.ClientModels.LoginWithKongregateRequest::PlayerSecret
	String_t* ___PlayerSecret_6;
	// System.String PlayFab.ClientModels.LoginWithKongregateRequest::TitleId
	String_t* ___TitleId_7;

public:
	inline static int32_t get_offset_of_AuthTicket_0() { return static_cast<int32_t>(offsetof(LoginWithKongregateRequest_t2996684931, ___AuthTicket_0)); }
	inline String_t* get_AuthTicket_0() const { return ___AuthTicket_0; }
	inline String_t** get_address_of_AuthTicket_0() { return &___AuthTicket_0; }
	inline void set_AuthTicket_0(String_t* value)
	{
		___AuthTicket_0 = value;
		Il2CppCodeGenWriteBarrier((&___AuthTicket_0), value);
	}

	inline static int32_t get_offset_of_CreateAccount_1() { return static_cast<int32_t>(offsetof(LoginWithKongregateRequest_t2996684931, ___CreateAccount_1)); }
	inline Nullable_1_t1819850047  get_CreateAccount_1() const { return ___CreateAccount_1; }
	inline Nullable_1_t1819850047 * get_address_of_CreateAccount_1() { return &___CreateAccount_1; }
	inline void set_CreateAccount_1(Nullable_1_t1819850047  value)
	{
		___CreateAccount_1 = value;
	}

	inline static int32_t get_offset_of_EncryptedRequest_2() { return static_cast<int32_t>(offsetof(LoginWithKongregateRequest_t2996684931, ___EncryptedRequest_2)); }
	inline String_t* get_EncryptedRequest_2() const { return ___EncryptedRequest_2; }
	inline String_t** get_address_of_EncryptedRequest_2() { return &___EncryptedRequest_2; }
	inline void set_EncryptedRequest_2(String_t* value)
	{
		___EncryptedRequest_2 = value;
		Il2CppCodeGenWriteBarrier((&___EncryptedRequest_2), value);
	}

	inline static int32_t get_offset_of_InfoRequestParameters_3() { return static_cast<int32_t>(offsetof(LoginWithKongregateRequest_t2996684931, ___InfoRequestParameters_3)); }
	inline GetPlayerCombinedInfoRequestParams_t121265087 * get_InfoRequestParameters_3() const { return ___InfoRequestParameters_3; }
	inline GetPlayerCombinedInfoRequestParams_t121265087 ** get_address_of_InfoRequestParameters_3() { return &___InfoRequestParameters_3; }
	inline void set_InfoRequestParameters_3(GetPlayerCombinedInfoRequestParams_t121265087 * value)
	{
		___InfoRequestParameters_3 = value;
		Il2CppCodeGenWriteBarrier((&___InfoRequestParameters_3), value);
	}

	inline static int32_t get_offset_of_KongregateId_4() { return static_cast<int32_t>(offsetof(LoginWithKongregateRequest_t2996684931, ___KongregateId_4)); }
	inline String_t* get_KongregateId_4() const { return ___KongregateId_4; }
	inline String_t** get_address_of_KongregateId_4() { return &___KongregateId_4; }
	inline void set_KongregateId_4(String_t* value)
	{
		___KongregateId_4 = value;
		Il2CppCodeGenWriteBarrier((&___KongregateId_4), value);
	}

	inline static int32_t get_offset_of_LoginTitlePlayerAccountEntity_5() { return static_cast<int32_t>(offsetof(LoginWithKongregateRequest_t2996684931, ___LoginTitlePlayerAccountEntity_5)); }
	inline Nullable_1_t1819850047  get_LoginTitlePlayerAccountEntity_5() const { return ___LoginTitlePlayerAccountEntity_5; }
	inline Nullable_1_t1819850047 * get_address_of_LoginTitlePlayerAccountEntity_5() { return &___LoginTitlePlayerAccountEntity_5; }
	inline void set_LoginTitlePlayerAccountEntity_5(Nullable_1_t1819850047  value)
	{
		___LoginTitlePlayerAccountEntity_5 = value;
	}

	inline static int32_t get_offset_of_PlayerSecret_6() { return static_cast<int32_t>(offsetof(LoginWithKongregateRequest_t2996684931, ___PlayerSecret_6)); }
	inline String_t* get_PlayerSecret_6() const { return ___PlayerSecret_6; }
	inline String_t** get_address_of_PlayerSecret_6() { return &___PlayerSecret_6; }
	inline void set_PlayerSecret_6(String_t* value)
	{
		___PlayerSecret_6 = value;
		Il2CppCodeGenWriteBarrier((&___PlayerSecret_6), value);
	}

	inline static int32_t get_offset_of_TitleId_7() { return static_cast<int32_t>(offsetof(LoginWithKongregateRequest_t2996684931, ___TitleId_7)); }
	inline String_t* get_TitleId_7() const { return ___TitleId_7; }
	inline String_t** get_address_of_TitleId_7() { return &___TitleId_7; }
	inline void set_TitleId_7(String_t* value)
	{
		___TitleId_7 = value;
		Il2CppCodeGenWriteBarrier((&___TitleId_7), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LOGINWITHKONGREGATEREQUEST_T2996684931_H
#ifndef REGISTERPLAYFABUSERREQUEST_T413887218_H
#define REGISTERPLAYFABUSERREQUEST_T413887218_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.RegisterPlayFabUserRequest
struct  RegisterPlayFabUserRequest_t413887218  : public PlayFabRequestCommon_t229319069
{
public:
	// System.String PlayFab.ClientModels.RegisterPlayFabUserRequest::DisplayName
	String_t* ___DisplayName_0;
	// System.String PlayFab.ClientModels.RegisterPlayFabUserRequest::Email
	String_t* ___Email_1;
	// System.String PlayFab.ClientModels.RegisterPlayFabUserRequest::EncryptedRequest
	String_t* ___EncryptedRequest_2;
	// PlayFab.ClientModels.GetPlayerCombinedInfoRequestParams PlayFab.ClientModels.RegisterPlayFabUserRequest::InfoRequestParameters
	GetPlayerCombinedInfoRequestParams_t121265087 * ___InfoRequestParameters_3;
	// System.Nullable`1<System.Boolean> PlayFab.ClientModels.RegisterPlayFabUserRequest::LoginTitlePlayerAccountEntity
	Nullable_1_t1819850047  ___LoginTitlePlayerAccountEntity_4;
	// System.String PlayFab.ClientModels.RegisterPlayFabUserRequest::Password
	String_t* ___Password_5;
	// System.String PlayFab.ClientModels.RegisterPlayFabUserRequest::PlayerSecret
	String_t* ___PlayerSecret_6;
	// System.Nullable`1<System.Boolean> PlayFab.ClientModels.RegisterPlayFabUserRequest::RequireBothUsernameAndEmail
	Nullable_1_t1819850047  ___RequireBothUsernameAndEmail_7;
	// System.String PlayFab.ClientModels.RegisterPlayFabUserRequest::TitleId
	String_t* ___TitleId_8;
	// System.String PlayFab.ClientModels.RegisterPlayFabUserRequest::Username
	String_t* ___Username_9;

public:
	inline static int32_t get_offset_of_DisplayName_0() { return static_cast<int32_t>(offsetof(RegisterPlayFabUserRequest_t413887218, ___DisplayName_0)); }
	inline String_t* get_DisplayName_0() const { return ___DisplayName_0; }
	inline String_t** get_address_of_DisplayName_0() { return &___DisplayName_0; }
	inline void set_DisplayName_0(String_t* value)
	{
		___DisplayName_0 = value;
		Il2CppCodeGenWriteBarrier((&___DisplayName_0), value);
	}

	inline static int32_t get_offset_of_Email_1() { return static_cast<int32_t>(offsetof(RegisterPlayFabUserRequest_t413887218, ___Email_1)); }
	inline String_t* get_Email_1() const { return ___Email_1; }
	inline String_t** get_address_of_Email_1() { return &___Email_1; }
	inline void set_Email_1(String_t* value)
	{
		___Email_1 = value;
		Il2CppCodeGenWriteBarrier((&___Email_1), value);
	}

	inline static int32_t get_offset_of_EncryptedRequest_2() { return static_cast<int32_t>(offsetof(RegisterPlayFabUserRequest_t413887218, ___EncryptedRequest_2)); }
	inline String_t* get_EncryptedRequest_2() const { return ___EncryptedRequest_2; }
	inline String_t** get_address_of_EncryptedRequest_2() { return &___EncryptedRequest_2; }
	inline void set_EncryptedRequest_2(String_t* value)
	{
		___EncryptedRequest_2 = value;
		Il2CppCodeGenWriteBarrier((&___EncryptedRequest_2), value);
	}

	inline static int32_t get_offset_of_InfoRequestParameters_3() { return static_cast<int32_t>(offsetof(RegisterPlayFabUserRequest_t413887218, ___InfoRequestParameters_3)); }
	inline GetPlayerCombinedInfoRequestParams_t121265087 * get_InfoRequestParameters_3() const { return ___InfoRequestParameters_3; }
	inline GetPlayerCombinedInfoRequestParams_t121265087 ** get_address_of_InfoRequestParameters_3() { return &___InfoRequestParameters_3; }
	inline void set_InfoRequestParameters_3(GetPlayerCombinedInfoRequestParams_t121265087 * value)
	{
		___InfoRequestParameters_3 = value;
		Il2CppCodeGenWriteBarrier((&___InfoRequestParameters_3), value);
	}

	inline static int32_t get_offset_of_LoginTitlePlayerAccountEntity_4() { return static_cast<int32_t>(offsetof(RegisterPlayFabUserRequest_t413887218, ___LoginTitlePlayerAccountEntity_4)); }
	inline Nullable_1_t1819850047  get_LoginTitlePlayerAccountEntity_4() const { return ___LoginTitlePlayerAccountEntity_4; }
	inline Nullable_1_t1819850047 * get_address_of_LoginTitlePlayerAccountEntity_4() { return &___LoginTitlePlayerAccountEntity_4; }
	inline void set_LoginTitlePlayerAccountEntity_4(Nullable_1_t1819850047  value)
	{
		___LoginTitlePlayerAccountEntity_4 = value;
	}

	inline static int32_t get_offset_of_Password_5() { return static_cast<int32_t>(offsetof(RegisterPlayFabUserRequest_t413887218, ___Password_5)); }
	inline String_t* get_Password_5() const { return ___Password_5; }
	inline String_t** get_address_of_Password_5() { return &___Password_5; }
	inline void set_Password_5(String_t* value)
	{
		___Password_5 = value;
		Il2CppCodeGenWriteBarrier((&___Password_5), value);
	}

	inline static int32_t get_offset_of_PlayerSecret_6() { return static_cast<int32_t>(offsetof(RegisterPlayFabUserRequest_t413887218, ___PlayerSecret_6)); }
	inline String_t* get_PlayerSecret_6() const { return ___PlayerSecret_6; }
	inline String_t** get_address_of_PlayerSecret_6() { return &___PlayerSecret_6; }
	inline void set_PlayerSecret_6(String_t* value)
	{
		___PlayerSecret_6 = value;
		Il2CppCodeGenWriteBarrier((&___PlayerSecret_6), value);
	}

	inline static int32_t get_offset_of_RequireBothUsernameAndEmail_7() { return static_cast<int32_t>(offsetof(RegisterPlayFabUserRequest_t413887218, ___RequireBothUsernameAndEmail_7)); }
	inline Nullable_1_t1819850047  get_RequireBothUsernameAndEmail_7() const { return ___RequireBothUsernameAndEmail_7; }
	inline Nullable_1_t1819850047 * get_address_of_RequireBothUsernameAndEmail_7() { return &___RequireBothUsernameAndEmail_7; }
	inline void set_RequireBothUsernameAndEmail_7(Nullable_1_t1819850047  value)
	{
		___RequireBothUsernameAndEmail_7 = value;
	}

	inline static int32_t get_offset_of_TitleId_8() { return static_cast<int32_t>(offsetof(RegisterPlayFabUserRequest_t413887218, ___TitleId_8)); }
	inline String_t* get_TitleId_8() const { return ___TitleId_8; }
	inline String_t** get_address_of_TitleId_8() { return &___TitleId_8; }
	inline void set_TitleId_8(String_t* value)
	{
		___TitleId_8 = value;
		Il2CppCodeGenWriteBarrier((&___TitleId_8), value);
	}

	inline static int32_t get_offset_of_Username_9() { return static_cast<int32_t>(offsetof(RegisterPlayFabUserRequest_t413887218, ___Username_9)); }
	inline String_t* get_Username_9() const { return ___Username_9; }
	inline String_t** get_address_of_Username_9() { return &___Username_9; }
	inline void set_Username_9(String_t* value)
	{
		___Username_9 = value;
		Il2CppCodeGenWriteBarrier((&___Username_9), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // REGISTERPLAYFABUSERREQUEST_T413887218_H
#ifndef LOGINWITHPLAYFABREQUEST_T29234253_H
#define LOGINWITHPLAYFABREQUEST_T29234253_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.LoginWithPlayFabRequest
struct  LoginWithPlayFabRequest_t29234253  : public PlayFabRequestCommon_t229319069
{
public:
	// PlayFab.ClientModels.GetPlayerCombinedInfoRequestParams PlayFab.ClientModels.LoginWithPlayFabRequest::InfoRequestParameters
	GetPlayerCombinedInfoRequestParams_t121265087 * ___InfoRequestParameters_0;
	// System.Nullable`1<System.Boolean> PlayFab.ClientModels.LoginWithPlayFabRequest::LoginTitlePlayerAccountEntity
	Nullable_1_t1819850047  ___LoginTitlePlayerAccountEntity_1;
	// System.String PlayFab.ClientModels.LoginWithPlayFabRequest::Password
	String_t* ___Password_2;
	// System.String PlayFab.ClientModels.LoginWithPlayFabRequest::TitleId
	String_t* ___TitleId_3;
	// System.String PlayFab.ClientModels.LoginWithPlayFabRequest::Username
	String_t* ___Username_4;

public:
	inline static int32_t get_offset_of_InfoRequestParameters_0() { return static_cast<int32_t>(offsetof(LoginWithPlayFabRequest_t29234253, ___InfoRequestParameters_0)); }
	inline GetPlayerCombinedInfoRequestParams_t121265087 * get_InfoRequestParameters_0() const { return ___InfoRequestParameters_0; }
	inline GetPlayerCombinedInfoRequestParams_t121265087 ** get_address_of_InfoRequestParameters_0() { return &___InfoRequestParameters_0; }
	inline void set_InfoRequestParameters_0(GetPlayerCombinedInfoRequestParams_t121265087 * value)
	{
		___InfoRequestParameters_0 = value;
		Il2CppCodeGenWriteBarrier((&___InfoRequestParameters_0), value);
	}

	inline static int32_t get_offset_of_LoginTitlePlayerAccountEntity_1() { return static_cast<int32_t>(offsetof(LoginWithPlayFabRequest_t29234253, ___LoginTitlePlayerAccountEntity_1)); }
	inline Nullable_1_t1819850047  get_LoginTitlePlayerAccountEntity_1() const { return ___LoginTitlePlayerAccountEntity_1; }
	inline Nullable_1_t1819850047 * get_address_of_LoginTitlePlayerAccountEntity_1() { return &___LoginTitlePlayerAccountEntity_1; }
	inline void set_LoginTitlePlayerAccountEntity_1(Nullable_1_t1819850047  value)
	{
		___LoginTitlePlayerAccountEntity_1 = value;
	}

	inline static int32_t get_offset_of_Password_2() { return static_cast<int32_t>(offsetof(LoginWithPlayFabRequest_t29234253, ___Password_2)); }
	inline String_t* get_Password_2() const { return ___Password_2; }
	inline String_t** get_address_of_Password_2() { return &___Password_2; }
	inline void set_Password_2(String_t* value)
	{
		___Password_2 = value;
		Il2CppCodeGenWriteBarrier((&___Password_2), value);
	}

	inline static int32_t get_offset_of_TitleId_3() { return static_cast<int32_t>(offsetof(LoginWithPlayFabRequest_t29234253, ___TitleId_3)); }
	inline String_t* get_TitleId_3() const { return ___TitleId_3; }
	inline String_t** get_address_of_TitleId_3() { return &___TitleId_3; }
	inline void set_TitleId_3(String_t* value)
	{
		___TitleId_3 = value;
		Il2CppCodeGenWriteBarrier((&___TitleId_3), value);
	}

	inline static int32_t get_offset_of_Username_4() { return static_cast<int32_t>(offsetof(LoginWithPlayFabRequest_t29234253, ___Username_4)); }
	inline String_t* get_Username_4() const { return ___Username_4; }
	inline String_t** get_address_of_Username_4() { return &___Username_4; }
	inline void set_Username_4(String_t* value)
	{
		___Username_4 = value;
		Il2CppCodeGenWriteBarrier((&___Username_4), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LOGINWITHPLAYFABREQUEST_T29234253_H
#ifndef LOGINWITHSTEAMREQUEST_T1168349975_H
#define LOGINWITHSTEAMREQUEST_T1168349975_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.LoginWithSteamRequest
struct  LoginWithSteamRequest_t1168349975  : public PlayFabRequestCommon_t229319069
{
public:
	// System.Nullable`1<System.Boolean> PlayFab.ClientModels.LoginWithSteamRequest::CreateAccount
	Nullable_1_t1819850047  ___CreateAccount_0;
	// System.String PlayFab.ClientModels.LoginWithSteamRequest::EncryptedRequest
	String_t* ___EncryptedRequest_1;
	// PlayFab.ClientModels.GetPlayerCombinedInfoRequestParams PlayFab.ClientModels.LoginWithSteamRequest::InfoRequestParameters
	GetPlayerCombinedInfoRequestParams_t121265087 * ___InfoRequestParameters_2;
	// System.Nullable`1<System.Boolean> PlayFab.ClientModels.LoginWithSteamRequest::LoginTitlePlayerAccountEntity
	Nullable_1_t1819850047  ___LoginTitlePlayerAccountEntity_3;
	// System.String PlayFab.ClientModels.LoginWithSteamRequest::PlayerSecret
	String_t* ___PlayerSecret_4;
	// System.String PlayFab.ClientModels.LoginWithSteamRequest::SteamTicket
	String_t* ___SteamTicket_5;
	// System.String PlayFab.ClientModels.LoginWithSteamRequest::TitleId
	String_t* ___TitleId_6;

public:
	inline static int32_t get_offset_of_CreateAccount_0() { return static_cast<int32_t>(offsetof(LoginWithSteamRequest_t1168349975, ___CreateAccount_0)); }
	inline Nullable_1_t1819850047  get_CreateAccount_0() const { return ___CreateAccount_0; }
	inline Nullable_1_t1819850047 * get_address_of_CreateAccount_0() { return &___CreateAccount_0; }
	inline void set_CreateAccount_0(Nullable_1_t1819850047  value)
	{
		___CreateAccount_0 = value;
	}

	inline static int32_t get_offset_of_EncryptedRequest_1() { return static_cast<int32_t>(offsetof(LoginWithSteamRequest_t1168349975, ___EncryptedRequest_1)); }
	inline String_t* get_EncryptedRequest_1() const { return ___EncryptedRequest_1; }
	inline String_t** get_address_of_EncryptedRequest_1() { return &___EncryptedRequest_1; }
	inline void set_EncryptedRequest_1(String_t* value)
	{
		___EncryptedRequest_1 = value;
		Il2CppCodeGenWriteBarrier((&___EncryptedRequest_1), value);
	}

	inline static int32_t get_offset_of_InfoRequestParameters_2() { return static_cast<int32_t>(offsetof(LoginWithSteamRequest_t1168349975, ___InfoRequestParameters_2)); }
	inline GetPlayerCombinedInfoRequestParams_t121265087 * get_InfoRequestParameters_2() const { return ___InfoRequestParameters_2; }
	inline GetPlayerCombinedInfoRequestParams_t121265087 ** get_address_of_InfoRequestParameters_2() { return &___InfoRequestParameters_2; }
	inline void set_InfoRequestParameters_2(GetPlayerCombinedInfoRequestParams_t121265087 * value)
	{
		___InfoRequestParameters_2 = value;
		Il2CppCodeGenWriteBarrier((&___InfoRequestParameters_2), value);
	}

	inline static int32_t get_offset_of_LoginTitlePlayerAccountEntity_3() { return static_cast<int32_t>(offsetof(LoginWithSteamRequest_t1168349975, ___LoginTitlePlayerAccountEntity_3)); }
	inline Nullable_1_t1819850047  get_LoginTitlePlayerAccountEntity_3() const { return ___LoginTitlePlayerAccountEntity_3; }
	inline Nullable_1_t1819850047 * get_address_of_LoginTitlePlayerAccountEntity_3() { return &___LoginTitlePlayerAccountEntity_3; }
	inline void set_LoginTitlePlayerAccountEntity_3(Nullable_1_t1819850047  value)
	{
		___LoginTitlePlayerAccountEntity_3 = value;
	}

	inline static int32_t get_offset_of_PlayerSecret_4() { return static_cast<int32_t>(offsetof(LoginWithSteamRequest_t1168349975, ___PlayerSecret_4)); }
	inline String_t* get_PlayerSecret_4() const { return ___PlayerSecret_4; }
	inline String_t** get_address_of_PlayerSecret_4() { return &___PlayerSecret_4; }
	inline void set_PlayerSecret_4(String_t* value)
	{
		___PlayerSecret_4 = value;
		Il2CppCodeGenWriteBarrier((&___PlayerSecret_4), value);
	}

	inline static int32_t get_offset_of_SteamTicket_5() { return static_cast<int32_t>(offsetof(LoginWithSteamRequest_t1168349975, ___SteamTicket_5)); }
	inline String_t* get_SteamTicket_5() const { return ___SteamTicket_5; }
	inline String_t** get_address_of_SteamTicket_5() { return &___SteamTicket_5; }
	inline void set_SteamTicket_5(String_t* value)
	{
		___SteamTicket_5 = value;
		Il2CppCodeGenWriteBarrier((&___SteamTicket_5), value);
	}

	inline static int32_t get_offset_of_TitleId_6() { return static_cast<int32_t>(offsetof(LoginWithSteamRequest_t1168349975, ___TitleId_6)); }
	inline String_t* get_TitleId_6() const { return ___TitleId_6; }
	inline String_t** get_address_of_TitleId_6() { return &___TitleId_6; }
	inline void set_TitleId_6(String_t* value)
	{
		___TitleId_6 = value;
		Il2CppCodeGenWriteBarrier((&___TitleId_6), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LOGINWITHSTEAMREQUEST_T1168349975_H
#ifndef REGISTERFORIOSPUSHNOTIFICATIONREQUEST_T3055742779_H
#define REGISTERFORIOSPUSHNOTIFICATIONREQUEST_T3055742779_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.RegisterForIOSPushNotificationRequest
struct  RegisterForIOSPushNotificationRequest_t3055742779  : public PlayFabRequestCommon_t229319069
{
public:
	// System.String PlayFab.ClientModels.RegisterForIOSPushNotificationRequest::ConfirmationMessage
	String_t* ___ConfirmationMessage_0;
	// System.String PlayFab.ClientModels.RegisterForIOSPushNotificationRequest::DeviceToken
	String_t* ___DeviceToken_1;
	// System.Nullable`1<System.Boolean> PlayFab.ClientModels.RegisterForIOSPushNotificationRequest::SendPushNotificationConfirmation
	Nullable_1_t1819850047  ___SendPushNotificationConfirmation_2;

public:
	inline static int32_t get_offset_of_ConfirmationMessage_0() { return static_cast<int32_t>(offsetof(RegisterForIOSPushNotificationRequest_t3055742779, ___ConfirmationMessage_0)); }
	inline String_t* get_ConfirmationMessage_0() const { return ___ConfirmationMessage_0; }
	inline String_t** get_address_of_ConfirmationMessage_0() { return &___ConfirmationMessage_0; }
	inline void set_ConfirmationMessage_0(String_t* value)
	{
		___ConfirmationMessage_0 = value;
		Il2CppCodeGenWriteBarrier((&___ConfirmationMessage_0), value);
	}

	inline static int32_t get_offset_of_DeviceToken_1() { return static_cast<int32_t>(offsetof(RegisterForIOSPushNotificationRequest_t3055742779, ___DeviceToken_1)); }
	inline String_t* get_DeviceToken_1() const { return ___DeviceToken_1; }
	inline String_t** get_address_of_DeviceToken_1() { return &___DeviceToken_1; }
	inline void set_DeviceToken_1(String_t* value)
	{
		___DeviceToken_1 = value;
		Il2CppCodeGenWriteBarrier((&___DeviceToken_1), value);
	}

	inline static int32_t get_offset_of_SendPushNotificationConfirmation_2() { return static_cast<int32_t>(offsetof(RegisterForIOSPushNotificationRequest_t3055742779, ___SendPushNotificationConfirmation_2)); }
	inline Nullable_1_t1819850047  get_SendPushNotificationConfirmation_2() const { return ___SendPushNotificationConfirmation_2; }
	inline Nullable_1_t1819850047 * get_address_of_SendPushNotificationConfirmation_2() { return &___SendPushNotificationConfirmation_2; }
	inline void set_SendPushNotificationConfirmation_2(Nullable_1_t1819850047  value)
	{
		___SendPushNotificationConfirmation_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // REGISTERFORIOSPUSHNOTIFICATIONREQUEST_T3055742779_H
#ifndef NULLABLE_1_T2939709286_H
#define NULLABLE_1_T2939709286_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Nullable`1<PlayFab.ClientModels.MatchmakeStatus>
struct  Nullable_1_t2939709286 
{
public:
	// T System.Nullable`1::value
	int32_t ___value_0;
	// System.Boolean System.Nullable`1::has_value
	bool ___has_value_1;

public:
	inline static int32_t get_offset_of_value_0() { return static_cast<int32_t>(offsetof(Nullable_1_t2939709286, ___value_0)); }
	inline int32_t get_value_0() const { return ___value_0; }
	inline int32_t* get_address_of_value_0() { return &___value_0; }
	inline void set_value_0(int32_t value)
	{
		___value_0 = value;
	}

	inline static int32_t get_offset_of_has_value_1() { return static_cast<int32_t>(offsetof(Nullable_1_t2939709286, ___has_value_1)); }
	inline bool get_has_value_1() const { return ___has_value_1; }
	inline bool* get_address_of_has_value_1() { return &___has_value_1; }
	inline void set_has_value_1(bool value)
	{
		___has_value_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // NULLABLE_1_T2939709286_H
#ifndef NULLABLE_1_T3467212419_H
#define NULLABLE_1_T3467212419_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Nullable`1<PlayFab.ClientModels.CountryCode>
struct  Nullable_1_t3467212419 
{
public:
	// T System.Nullable`1::value
	int32_t ___value_0;
	// System.Boolean System.Nullable`1::has_value
	bool ___has_value_1;

public:
	inline static int32_t get_offset_of_value_0() { return static_cast<int32_t>(offsetof(Nullable_1_t3467212419, ___value_0)); }
	inline int32_t get_value_0() const { return ___value_0; }
	inline int32_t* get_address_of_value_0() { return &___value_0; }
	inline void set_value_0(int32_t value)
	{
		___value_0 = value;
	}

	inline static int32_t get_offset_of_has_value_1() { return static_cast<int32_t>(offsetof(Nullable_1_t3467212419, ___has_value_1)); }
	inline bool get_has_value_1() const { return ___has_value_1; }
	inline bool* get_address_of_has_value_1() { return &___has_value_1; }
	inline void set_has_value_1(bool value)
	{
		___has_value_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // NULLABLE_1_T3467212419_H
#ifndef NULLABLE_1_T1625618012_H
#define NULLABLE_1_T1625618012_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Nullable`1<PlayFab.ClientModels.Region>
struct  Nullable_1_t1625618012 
{
public:
	// T System.Nullable`1::value
	int32_t ___value_0;
	// System.Boolean System.Nullable`1::has_value
	bool ___has_value_1;

public:
	inline static int32_t get_offset_of_value_0() { return static_cast<int32_t>(offsetof(Nullable_1_t1625618012, ___value_0)); }
	inline int32_t get_value_0() const { return ___value_0; }
	inline int32_t* get_address_of_value_0() { return &___value_0; }
	inline void set_value_0(int32_t value)
	{
		___value_0 = value;
	}

	inline static int32_t get_offset_of_has_value_1() { return static_cast<int32_t>(offsetof(Nullable_1_t1625618012, ___has_value_1)); }
	inline bool get_has_value_1() const { return ___has_value_1; }
	inline bool* get_address_of_has_value_1() { return &___has_value_1; }
	inline void set_has_value_1(bool value)
	{
		___has_value_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // NULLABLE_1_T1625618012_H
#ifndef DATETIME_T3738529785_H
#define DATETIME_T3738529785_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.DateTime
struct  DateTime_t3738529785 
{
public:
	// System.TimeSpan System.DateTime::ticks
	TimeSpan_t881159249  ___ticks_10;
	// System.DateTimeKind System.DateTime::kind
	int32_t ___kind_11;

public:
	inline static int32_t get_offset_of_ticks_10() { return static_cast<int32_t>(offsetof(DateTime_t3738529785, ___ticks_10)); }
	inline TimeSpan_t881159249  get_ticks_10() const { return ___ticks_10; }
	inline TimeSpan_t881159249 * get_address_of_ticks_10() { return &___ticks_10; }
	inline void set_ticks_10(TimeSpan_t881159249  value)
	{
		___ticks_10 = value;
	}

	inline static int32_t get_offset_of_kind_11() { return static_cast<int32_t>(offsetof(DateTime_t3738529785, ___kind_11)); }
	inline int32_t get_kind_11() const { return ___kind_11; }
	inline int32_t* get_address_of_kind_11() { return &___kind_11; }
	inline void set_kind_11(int32_t value)
	{
		___kind_11 = value;
	}
};

struct DateTime_t3738529785_StaticFields
{
public:
	// System.DateTime System.DateTime::MaxValue
	DateTime_t3738529785  ___MaxValue_12;
	// System.DateTime System.DateTime::MinValue
	DateTime_t3738529785  ___MinValue_13;
	// System.String[] System.DateTime::ParseTimeFormats
	StringU5BU5D_t1281789340* ___ParseTimeFormats_14;
	// System.String[] System.DateTime::ParseYearDayMonthFormats
	StringU5BU5D_t1281789340* ___ParseYearDayMonthFormats_15;
	// System.String[] System.DateTime::ParseYearMonthDayFormats
	StringU5BU5D_t1281789340* ___ParseYearMonthDayFormats_16;
	// System.String[] System.DateTime::ParseDayMonthYearFormats
	StringU5BU5D_t1281789340* ___ParseDayMonthYearFormats_17;
	// System.String[] System.DateTime::ParseMonthDayYearFormats
	StringU5BU5D_t1281789340* ___ParseMonthDayYearFormats_18;
	// System.String[] System.DateTime::MonthDayShortFormats
	StringU5BU5D_t1281789340* ___MonthDayShortFormats_19;
	// System.String[] System.DateTime::DayMonthShortFormats
	StringU5BU5D_t1281789340* ___DayMonthShortFormats_20;
	// System.Int32[] System.DateTime::daysmonth
	Int32U5BU5D_t385246372* ___daysmonth_21;
	// System.Int32[] System.DateTime::daysmonthleap
	Int32U5BU5D_t385246372* ___daysmonthleap_22;
	// System.Object System.DateTime::to_local_time_span_object
	RuntimeObject * ___to_local_time_span_object_23;
	// System.Int64 System.DateTime::last_now
	int64_t ___last_now_24;

public:
	inline static int32_t get_offset_of_MaxValue_12() { return static_cast<int32_t>(offsetof(DateTime_t3738529785_StaticFields, ___MaxValue_12)); }
	inline DateTime_t3738529785  get_MaxValue_12() const { return ___MaxValue_12; }
	inline DateTime_t3738529785 * get_address_of_MaxValue_12() { return &___MaxValue_12; }
	inline void set_MaxValue_12(DateTime_t3738529785  value)
	{
		___MaxValue_12 = value;
	}

	inline static int32_t get_offset_of_MinValue_13() { return static_cast<int32_t>(offsetof(DateTime_t3738529785_StaticFields, ___MinValue_13)); }
	inline DateTime_t3738529785  get_MinValue_13() const { return ___MinValue_13; }
	inline DateTime_t3738529785 * get_address_of_MinValue_13() { return &___MinValue_13; }
	inline void set_MinValue_13(DateTime_t3738529785  value)
	{
		___MinValue_13 = value;
	}

	inline static int32_t get_offset_of_ParseTimeFormats_14() { return static_cast<int32_t>(offsetof(DateTime_t3738529785_StaticFields, ___ParseTimeFormats_14)); }
	inline StringU5BU5D_t1281789340* get_ParseTimeFormats_14() const { return ___ParseTimeFormats_14; }
	inline StringU5BU5D_t1281789340** get_address_of_ParseTimeFormats_14() { return &___ParseTimeFormats_14; }
	inline void set_ParseTimeFormats_14(StringU5BU5D_t1281789340* value)
	{
		___ParseTimeFormats_14 = value;
		Il2CppCodeGenWriteBarrier((&___ParseTimeFormats_14), value);
	}

	inline static int32_t get_offset_of_ParseYearDayMonthFormats_15() { return static_cast<int32_t>(offsetof(DateTime_t3738529785_StaticFields, ___ParseYearDayMonthFormats_15)); }
	inline StringU5BU5D_t1281789340* get_ParseYearDayMonthFormats_15() const { return ___ParseYearDayMonthFormats_15; }
	inline StringU5BU5D_t1281789340** get_address_of_ParseYearDayMonthFormats_15() { return &___ParseYearDayMonthFormats_15; }
	inline void set_ParseYearDayMonthFormats_15(StringU5BU5D_t1281789340* value)
	{
		___ParseYearDayMonthFormats_15 = value;
		Il2CppCodeGenWriteBarrier((&___ParseYearDayMonthFormats_15), value);
	}

	inline static int32_t get_offset_of_ParseYearMonthDayFormats_16() { return static_cast<int32_t>(offsetof(DateTime_t3738529785_StaticFields, ___ParseYearMonthDayFormats_16)); }
	inline StringU5BU5D_t1281789340* get_ParseYearMonthDayFormats_16() const { return ___ParseYearMonthDayFormats_16; }
	inline StringU5BU5D_t1281789340** get_address_of_ParseYearMonthDayFormats_16() { return &___ParseYearMonthDayFormats_16; }
	inline void set_ParseYearMonthDayFormats_16(StringU5BU5D_t1281789340* value)
	{
		___ParseYearMonthDayFormats_16 = value;
		Il2CppCodeGenWriteBarrier((&___ParseYearMonthDayFormats_16), value);
	}

	inline static int32_t get_offset_of_ParseDayMonthYearFormats_17() { return static_cast<int32_t>(offsetof(DateTime_t3738529785_StaticFields, ___ParseDayMonthYearFormats_17)); }
	inline StringU5BU5D_t1281789340* get_ParseDayMonthYearFormats_17() const { return ___ParseDayMonthYearFormats_17; }
	inline StringU5BU5D_t1281789340** get_address_of_ParseDayMonthYearFormats_17() { return &___ParseDayMonthYearFormats_17; }
	inline void set_ParseDayMonthYearFormats_17(StringU5BU5D_t1281789340* value)
	{
		___ParseDayMonthYearFormats_17 = value;
		Il2CppCodeGenWriteBarrier((&___ParseDayMonthYearFormats_17), value);
	}

	inline static int32_t get_offset_of_ParseMonthDayYearFormats_18() { return static_cast<int32_t>(offsetof(DateTime_t3738529785_StaticFields, ___ParseMonthDayYearFormats_18)); }
	inline StringU5BU5D_t1281789340* get_ParseMonthDayYearFormats_18() const { return ___ParseMonthDayYearFormats_18; }
	inline StringU5BU5D_t1281789340** get_address_of_ParseMonthDayYearFormats_18() { return &___ParseMonthDayYearFormats_18; }
	inline void set_ParseMonthDayYearFormats_18(StringU5BU5D_t1281789340* value)
	{
		___ParseMonthDayYearFormats_18 = value;
		Il2CppCodeGenWriteBarrier((&___ParseMonthDayYearFormats_18), value);
	}

	inline static int32_t get_offset_of_MonthDayShortFormats_19() { return static_cast<int32_t>(offsetof(DateTime_t3738529785_StaticFields, ___MonthDayShortFormats_19)); }
	inline StringU5BU5D_t1281789340* get_MonthDayShortFormats_19() const { return ___MonthDayShortFormats_19; }
	inline StringU5BU5D_t1281789340** get_address_of_MonthDayShortFormats_19() { return &___MonthDayShortFormats_19; }
	inline void set_MonthDayShortFormats_19(StringU5BU5D_t1281789340* value)
	{
		___MonthDayShortFormats_19 = value;
		Il2CppCodeGenWriteBarrier((&___MonthDayShortFormats_19), value);
	}

	inline static int32_t get_offset_of_DayMonthShortFormats_20() { return static_cast<int32_t>(offsetof(DateTime_t3738529785_StaticFields, ___DayMonthShortFormats_20)); }
	inline StringU5BU5D_t1281789340* get_DayMonthShortFormats_20() const { return ___DayMonthShortFormats_20; }
	inline StringU5BU5D_t1281789340** get_address_of_DayMonthShortFormats_20() { return &___DayMonthShortFormats_20; }
	inline void set_DayMonthShortFormats_20(StringU5BU5D_t1281789340* value)
	{
		___DayMonthShortFormats_20 = value;
		Il2CppCodeGenWriteBarrier((&___DayMonthShortFormats_20), value);
	}

	inline static int32_t get_offset_of_daysmonth_21() { return static_cast<int32_t>(offsetof(DateTime_t3738529785_StaticFields, ___daysmonth_21)); }
	inline Int32U5BU5D_t385246372* get_daysmonth_21() const { return ___daysmonth_21; }
	inline Int32U5BU5D_t385246372** get_address_of_daysmonth_21() { return &___daysmonth_21; }
	inline void set_daysmonth_21(Int32U5BU5D_t385246372* value)
	{
		___daysmonth_21 = value;
		Il2CppCodeGenWriteBarrier((&___daysmonth_21), value);
	}

	inline static int32_t get_offset_of_daysmonthleap_22() { return static_cast<int32_t>(offsetof(DateTime_t3738529785_StaticFields, ___daysmonthleap_22)); }
	inline Int32U5BU5D_t385246372* get_daysmonthleap_22() const { return ___daysmonthleap_22; }
	inline Int32U5BU5D_t385246372** get_address_of_daysmonthleap_22() { return &___daysmonthleap_22; }
	inline void set_daysmonthleap_22(Int32U5BU5D_t385246372* value)
	{
		___daysmonthleap_22 = value;
		Il2CppCodeGenWriteBarrier((&___daysmonthleap_22), value);
	}

	inline static int32_t get_offset_of_to_local_time_span_object_23() { return static_cast<int32_t>(offsetof(DateTime_t3738529785_StaticFields, ___to_local_time_span_object_23)); }
	inline RuntimeObject * get_to_local_time_span_object_23() const { return ___to_local_time_span_object_23; }
	inline RuntimeObject ** get_address_of_to_local_time_span_object_23() { return &___to_local_time_span_object_23; }
	inline void set_to_local_time_span_object_23(RuntimeObject * value)
	{
		___to_local_time_span_object_23 = value;
		Il2CppCodeGenWriteBarrier((&___to_local_time_span_object_23), value);
	}

	inline static int32_t get_offset_of_last_now_24() { return static_cast<int32_t>(offsetof(DateTime_t3738529785_StaticFields, ___last_now_24)); }
	inline int64_t get_last_now_24() const { return ___last_now_24; }
	inline int64_t* get_address_of_last_now_24() { return &___last_now_24; }
	inline void set_last_now_24(int64_t value)
	{
		___last_now_24 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // DATETIME_T3738529785_H
#ifndef NULLABLE_1_T3748078693_H
#define NULLABLE_1_T3748078693_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Nullable`1<PlayFab.ClientModels.UserDataPermission>
struct  Nullable_1_t3748078693 
{
public:
	// T System.Nullable`1::value
	int32_t ___value_0;
	// System.Boolean System.Nullable`1::has_value
	bool ___has_value_1;

public:
	inline static int32_t get_offset_of_value_0() { return static_cast<int32_t>(offsetof(Nullable_1_t3748078693, ___value_0)); }
	inline int32_t get_value_0() const { return ___value_0; }
	inline int32_t* get_address_of_value_0() { return &___value_0; }
	inline void set_value_0(int32_t value)
	{
		___value_0 = value;
	}

	inline static int32_t get_offset_of_has_value_1() { return static_cast<int32_t>(offsetof(Nullable_1_t3748078693, ___has_value_1)); }
	inline bool get_has_value_1() const { return ___has_value_1; }
	inline bool* get_address_of_has_value_1() { return &___has_value_1; }
	inline void set_has_value_1(bool value)
	{
		___has_value_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // NULLABLE_1_T3748078693_H
#ifndef NULLABLE_1_T2398459843_H
#define NULLABLE_1_T2398459843_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Nullable`1<PlayFab.ClientModels.PushNotificationPlatform>
struct  Nullable_1_t2398459843 
{
public:
	// T System.Nullable`1::value
	int32_t ___value_0;
	// System.Boolean System.Nullable`1::has_value
	bool ___has_value_1;

public:
	inline static int32_t get_offset_of_value_0() { return static_cast<int32_t>(offsetof(Nullable_1_t2398459843, ___value_0)); }
	inline int32_t get_value_0() const { return ___value_0; }
	inline int32_t* get_address_of_value_0() { return &___value_0; }
	inline void set_value_0(int32_t value)
	{
		___value_0 = value;
	}

	inline static int32_t get_offset_of_has_value_1() { return static_cast<int32_t>(offsetof(Nullable_1_t2398459843, ___has_value_1)); }
	inline bool get_has_value_1() const { return ___has_value_1; }
	inline bool* get_address_of_has_value_1() { return &___has_value_1; }
	inline void set_has_value_1(bool value)
	{
		___has_value_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // NULLABLE_1_T2398459843_H
#ifndef NULLABLE_1_T250137981_H
#define NULLABLE_1_T250137981_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Nullable`1<PlayFab.ClientModels.TransactionStatus>
struct  Nullable_1_t250137981 
{
public:
	// T System.Nullable`1::value
	int32_t ___value_0;
	// System.Boolean System.Nullable`1::has_value
	bool ___has_value_1;

public:
	inline static int32_t get_offset_of_value_0() { return static_cast<int32_t>(offsetof(Nullable_1_t250137981, ___value_0)); }
	inline int32_t get_value_0() const { return ___value_0; }
	inline int32_t* get_address_of_value_0() { return &___value_0; }
	inline void set_value_0(int32_t value)
	{
		___value_0 = value;
	}

	inline static int32_t get_offset_of_has_value_1() { return static_cast<int32_t>(offsetof(Nullable_1_t250137981, ___has_value_1)); }
	inline bool get_has_value_1() const { return ___has_value_1; }
	inline bool* get_address_of_has_value_1() { return &___has_value_1; }
	inline void set_has_value_1(bool value)
	{
		___has_value_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // NULLABLE_1_T250137981_H
#ifndef NULLABLE_1_T3603180267_H
#define NULLABLE_1_T3603180267_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Nullable`1<PlayFab.ClientModels.LoginIdentityProvider>
struct  Nullable_1_t3603180267 
{
public:
	// T System.Nullable`1::value
	int32_t ___value_0;
	// System.Boolean System.Nullable`1::has_value
	bool ___has_value_1;

public:
	inline static int32_t get_offset_of_value_0() { return static_cast<int32_t>(offsetof(Nullable_1_t3603180267, ___value_0)); }
	inline int32_t get_value_0() const { return ___value_0; }
	inline int32_t* get_address_of_value_0() { return &___value_0; }
	inline void set_value_0(int32_t value)
	{
		___value_0 = value;
	}

	inline static int32_t get_offset_of_has_value_1() { return static_cast<int32_t>(offsetof(Nullable_1_t3603180267, ___has_value_1)); }
	inline bool get_has_value_1() const { return ___has_value_1; }
	inline bool* get_address_of_has_value_1() { return &___has_value_1; }
	inline void set_has_value_1(bool value)
	{
		___has_value_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // NULLABLE_1_T3603180267_H
#ifndef STARTGAMEREQUEST_T3072561728_H
#define STARTGAMEREQUEST_T3072561728_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.StartGameRequest
struct  StartGameRequest_t3072561728  : public PlayFabRequestCommon_t229319069
{
public:
	// System.String PlayFab.ClientModels.StartGameRequest::BuildVersion
	String_t* ___BuildVersion_0;
	// System.String PlayFab.ClientModels.StartGameRequest::CharacterId
	String_t* ___CharacterId_1;
	// System.String PlayFab.ClientModels.StartGameRequest::CustomCommandLineData
	String_t* ___CustomCommandLineData_2;
	// System.String PlayFab.ClientModels.StartGameRequest::GameMode
	String_t* ___GameMode_3;
	// PlayFab.ClientModels.Region PlayFab.ClientModels.StartGameRequest::Region
	int32_t ___Region_4;
	// System.String PlayFab.ClientModels.StartGameRequest::StatisticName
	String_t* ___StatisticName_5;

public:
	inline static int32_t get_offset_of_BuildVersion_0() { return static_cast<int32_t>(offsetof(StartGameRequest_t3072561728, ___BuildVersion_0)); }
	inline String_t* get_BuildVersion_0() const { return ___BuildVersion_0; }
	inline String_t** get_address_of_BuildVersion_0() { return &___BuildVersion_0; }
	inline void set_BuildVersion_0(String_t* value)
	{
		___BuildVersion_0 = value;
		Il2CppCodeGenWriteBarrier((&___BuildVersion_0), value);
	}

	inline static int32_t get_offset_of_CharacterId_1() { return static_cast<int32_t>(offsetof(StartGameRequest_t3072561728, ___CharacterId_1)); }
	inline String_t* get_CharacterId_1() const { return ___CharacterId_1; }
	inline String_t** get_address_of_CharacterId_1() { return &___CharacterId_1; }
	inline void set_CharacterId_1(String_t* value)
	{
		___CharacterId_1 = value;
		Il2CppCodeGenWriteBarrier((&___CharacterId_1), value);
	}

	inline static int32_t get_offset_of_CustomCommandLineData_2() { return static_cast<int32_t>(offsetof(StartGameRequest_t3072561728, ___CustomCommandLineData_2)); }
	inline String_t* get_CustomCommandLineData_2() const { return ___CustomCommandLineData_2; }
	inline String_t** get_address_of_CustomCommandLineData_2() { return &___CustomCommandLineData_2; }
	inline void set_CustomCommandLineData_2(String_t* value)
	{
		___CustomCommandLineData_2 = value;
		Il2CppCodeGenWriteBarrier((&___CustomCommandLineData_2), value);
	}

	inline static int32_t get_offset_of_GameMode_3() { return static_cast<int32_t>(offsetof(StartGameRequest_t3072561728, ___GameMode_3)); }
	inline String_t* get_GameMode_3() const { return ___GameMode_3; }
	inline String_t** get_address_of_GameMode_3() { return &___GameMode_3; }
	inline void set_GameMode_3(String_t* value)
	{
		___GameMode_3 = value;
		Il2CppCodeGenWriteBarrier((&___GameMode_3), value);
	}

	inline static int32_t get_offset_of_Region_4() { return static_cast<int32_t>(offsetof(StartGameRequest_t3072561728, ___Region_4)); }
	inline int32_t get_Region_4() const { return ___Region_4; }
	inline int32_t* get_address_of_Region_4() { return &___Region_4; }
	inline void set_Region_4(int32_t value)
	{
		___Region_4 = value;
	}

	inline static int32_t get_offset_of_StatisticName_5() { return static_cast<int32_t>(offsetof(StartGameRequest_t3072561728, ___StatisticName_5)); }
	inline String_t* get_StatisticName_5() const { return ___StatisticName_5; }
	inline String_t** get_address_of_StatisticName_5() { return &___StatisticName_5; }
	inline void set_StatisticName_5(String_t* value)
	{
		___StatisticName_5 = value;
		Il2CppCodeGenWriteBarrier((&___StatisticName_5), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // STARTGAMEREQUEST_T3072561728_H
#ifndef NULLABLE_1_T382695706_H
#define NULLABLE_1_T382695706_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Nullable`1<PlayFab.ClientModels.ContinentCode>
struct  Nullable_1_t382695706 
{
public:
	// T System.Nullable`1::value
	int32_t ___value_0;
	// System.Boolean System.Nullable`1::has_value
	bool ___has_value_1;

public:
	inline static int32_t get_offset_of_value_0() { return static_cast<int32_t>(offsetof(Nullable_1_t382695706, ___value_0)); }
	inline int32_t get_value_0() const { return ___value_0; }
	inline int32_t* get_address_of_value_0() { return &___value_0; }
	inline void set_value_0(int32_t value)
	{
		___value_0 = value;
	}

	inline static int32_t get_offset_of_has_value_1() { return static_cast<int32_t>(offsetof(Nullable_1_t382695706, ___has_value_1)); }
	inline bool get_has_value_1() const { return ___has_value_1; }
	inline bool* get_address_of_has_value_1() { return &___has_value_1; }
	inline void set_has_value_1(bool value)
	{
		___has_value_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // NULLABLE_1_T382695706_H
#ifndef LINKEDPLATFORMACCOUNTMODEL_T2719432589_H
#define LINKEDPLATFORMACCOUNTMODEL_T2719432589_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.LinkedPlatformAccountModel
struct  LinkedPlatformAccountModel_t2719432589  : public RuntimeObject
{
public:
	// System.String PlayFab.ClientModels.LinkedPlatformAccountModel::Email
	String_t* ___Email_0;
	// System.Nullable`1<PlayFab.ClientModels.LoginIdentityProvider> PlayFab.ClientModels.LinkedPlatformAccountModel::Platform
	Nullable_1_t3603180267  ___Platform_1;
	// System.String PlayFab.ClientModels.LinkedPlatformAccountModel::PlatformUserId
	String_t* ___PlatformUserId_2;
	// System.String PlayFab.ClientModels.LinkedPlatformAccountModel::Username
	String_t* ___Username_3;

public:
	inline static int32_t get_offset_of_Email_0() { return static_cast<int32_t>(offsetof(LinkedPlatformAccountModel_t2719432589, ___Email_0)); }
	inline String_t* get_Email_0() const { return ___Email_0; }
	inline String_t** get_address_of_Email_0() { return &___Email_0; }
	inline void set_Email_0(String_t* value)
	{
		___Email_0 = value;
		Il2CppCodeGenWriteBarrier((&___Email_0), value);
	}

	inline static int32_t get_offset_of_Platform_1() { return static_cast<int32_t>(offsetof(LinkedPlatformAccountModel_t2719432589, ___Platform_1)); }
	inline Nullable_1_t3603180267  get_Platform_1() const { return ___Platform_1; }
	inline Nullable_1_t3603180267 * get_address_of_Platform_1() { return &___Platform_1; }
	inline void set_Platform_1(Nullable_1_t3603180267  value)
	{
		___Platform_1 = value;
	}

	inline static int32_t get_offset_of_PlatformUserId_2() { return static_cast<int32_t>(offsetof(LinkedPlatformAccountModel_t2719432589, ___PlatformUserId_2)); }
	inline String_t* get_PlatformUserId_2() const { return ___PlatformUserId_2; }
	inline String_t** get_address_of_PlatformUserId_2() { return &___PlatformUserId_2; }
	inline void set_PlatformUserId_2(String_t* value)
	{
		___PlatformUserId_2 = value;
		Il2CppCodeGenWriteBarrier((&___PlatformUserId_2), value);
	}

	inline static int32_t get_offset_of_Username_3() { return static_cast<int32_t>(offsetof(LinkedPlatformAccountModel_t2719432589, ___Username_3)); }
	inline String_t* get_Username_3() const { return ___Username_3; }
	inline String_t** get_address_of_Username_3() { return &___Username_3; }
	inline void set_Username_3(String_t* value)
	{
		___Username_3 = value;
		Il2CppCodeGenWriteBarrier((&___Username_3), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LINKEDPLATFORMACCOUNTMODEL_T2719432589_H
#ifndef MATCHMAKERESULT_T2030730580_H
#define MATCHMAKERESULT_T2030730580_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.MatchmakeResult
struct  MatchmakeResult_t2030730580  : public PlayFabResultCommon_t3469603827
{
public:
	// System.String PlayFab.ClientModels.MatchmakeResult::Expires
	String_t* ___Expires_2;
	// System.String PlayFab.ClientModels.MatchmakeResult::LobbyID
	String_t* ___LobbyID_3;
	// System.Nullable`1<System.Int32> PlayFab.ClientModels.MatchmakeResult::PollWaitTimeMS
	Nullable_1_t378540539  ___PollWaitTimeMS_4;
	// System.String PlayFab.ClientModels.MatchmakeResult::ServerHostname
	String_t* ___ServerHostname_5;
	// System.String PlayFab.ClientModels.MatchmakeResult::ServerIPV6Address
	String_t* ___ServerIPV6Address_6;
	// System.Nullable`1<System.Int32> PlayFab.ClientModels.MatchmakeResult::ServerPort
	Nullable_1_t378540539  ___ServerPort_7;
	// System.Nullable`1<PlayFab.ClientModels.MatchmakeStatus> PlayFab.ClientModels.MatchmakeResult::Status
	Nullable_1_t2939709286  ___Status_8;
	// System.String PlayFab.ClientModels.MatchmakeResult::Ticket
	String_t* ___Ticket_9;

public:
	inline static int32_t get_offset_of_Expires_2() { return static_cast<int32_t>(offsetof(MatchmakeResult_t2030730580, ___Expires_2)); }
	inline String_t* get_Expires_2() const { return ___Expires_2; }
	inline String_t** get_address_of_Expires_2() { return &___Expires_2; }
	inline void set_Expires_2(String_t* value)
	{
		___Expires_2 = value;
		Il2CppCodeGenWriteBarrier((&___Expires_2), value);
	}

	inline static int32_t get_offset_of_LobbyID_3() { return static_cast<int32_t>(offsetof(MatchmakeResult_t2030730580, ___LobbyID_3)); }
	inline String_t* get_LobbyID_3() const { return ___LobbyID_3; }
	inline String_t** get_address_of_LobbyID_3() { return &___LobbyID_3; }
	inline void set_LobbyID_3(String_t* value)
	{
		___LobbyID_3 = value;
		Il2CppCodeGenWriteBarrier((&___LobbyID_3), value);
	}

	inline static int32_t get_offset_of_PollWaitTimeMS_4() { return static_cast<int32_t>(offsetof(MatchmakeResult_t2030730580, ___PollWaitTimeMS_4)); }
	inline Nullable_1_t378540539  get_PollWaitTimeMS_4() const { return ___PollWaitTimeMS_4; }
	inline Nullable_1_t378540539 * get_address_of_PollWaitTimeMS_4() { return &___PollWaitTimeMS_4; }
	inline void set_PollWaitTimeMS_4(Nullable_1_t378540539  value)
	{
		___PollWaitTimeMS_4 = value;
	}

	inline static int32_t get_offset_of_ServerHostname_5() { return static_cast<int32_t>(offsetof(MatchmakeResult_t2030730580, ___ServerHostname_5)); }
	inline String_t* get_ServerHostname_5() const { return ___ServerHostname_5; }
	inline String_t** get_address_of_ServerHostname_5() { return &___ServerHostname_5; }
	inline void set_ServerHostname_5(String_t* value)
	{
		___ServerHostname_5 = value;
		Il2CppCodeGenWriteBarrier((&___ServerHostname_5), value);
	}

	inline static int32_t get_offset_of_ServerIPV6Address_6() { return static_cast<int32_t>(offsetof(MatchmakeResult_t2030730580, ___ServerIPV6Address_6)); }
	inline String_t* get_ServerIPV6Address_6() const { return ___ServerIPV6Address_6; }
	inline String_t** get_address_of_ServerIPV6Address_6() { return &___ServerIPV6Address_6; }
	inline void set_ServerIPV6Address_6(String_t* value)
	{
		___ServerIPV6Address_6 = value;
		Il2CppCodeGenWriteBarrier((&___ServerIPV6Address_6), value);
	}

	inline static int32_t get_offset_of_ServerPort_7() { return static_cast<int32_t>(offsetof(MatchmakeResult_t2030730580, ___ServerPort_7)); }
	inline Nullable_1_t378540539  get_ServerPort_7() const { return ___ServerPort_7; }
	inline Nullable_1_t378540539 * get_address_of_ServerPort_7() { return &___ServerPort_7; }
	inline void set_ServerPort_7(Nullable_1_t378540539  value)
	{
		___ServerPort_7 = value;
	}

	inline static int32_t get_offset_of_Status_8() { return static_cast<int32_t>(offsetof(MatchmakeResult_t2030730580, ___Status_8)); }
	inline Nullable_1_t2939709286  get_Status_8() const { return ___Status_8; }
	inline Nullable_1_t2939709286 * get_address_of_Status_8() { return &___Status_8; }
	inline void set_Status_8(Nullable_1_t2939709286  value)
	{
		___Status_8 = value;
	}

	inline static int32_t get_offset_of_Ticket_9() { return static_cast<int32_t>(offsetof(MatchmakeResult_t2030730580, ___Ticket_9)); }
	inline String_t* get_Ticket_9() const { return ___Ticket_9; }
	inline String_t** get_address_of_Ticket_9() { return &___Ticket_9; }
	inline void set_Ticket_9(String_t* value)
	{
		___Ticket_9 = value;
		Il2CppCodeGenWriteBarrier((&___Ticket_9), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // MATCHMAKERESULT_T2030730580_H
#ifndef MATCHMAKEREQUEST_T1739851507_H
#define MATCHMAKEREQUEST_T1739851507_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.MatchmakeRequest
struct  MatchmakeRequest_t1739851507  : public PlayFabRequestCommon_t229319069
{
public:
	// System.String PlayFab.ClientModels.MatchmakeRequest::BuildVersion
	String_t* ___BuildVersion_0;
	// System.String PlayFab.ClientModels.MatchmakeRequest::CharacterId
	String_t* ___CharacterId_1;
	// System.String PlayFab.ClientModels.MatchmakeRequest::GameMode
	String_t* ___GameMode_2;
	// System.String PlayFab.ClientModels.MatchmakeRequest::LobbyId
	String_t* ___LobbyId_3;
	// System.Nullable`1<PlayFab.ClientModels.Region> PlayFab.ClientModels.MatchmakeRequest::Region
	Nullable_1_t1625618012  ___Region_4;
	// System.Nullable`1<System.Boolean> PlayFab.ClientModels.MatchmakeRequest::StartNewIfNoneFound
	Nullable_1_t1819850047  ___StartNewIfNoneFound_5;
	// System.String PlayFab.ClientModels.MatchmakeRequest::StatisticName
	String_t* ___StatisticName_6;
	// PlayFab.ClientModels.CollectionFilter PlayFab.ClientModels.MatchmakeRequest::TagFilter
	CollectionFilter_t2867730642 * ___TagFilter_7;

public:
	inline static int32_t get_offset_of_BuildVersion_0() { return static_cast<int32_t>(offsetof(MatchmakeRequest_t1739851507, ___BuildVersion_0)); }
	inline String_t* get_BuildVersion_0() const { return ___BuildVersion_0; }
	inline String_t** get_address_of_BuildVersion_0() { return &___BuildVersion_0; }
	inline void set_BuildVersion_0(String_t* value)
	{
		___BuildVersion_0 = value;
		Il2CppCodeGenWriteBarrier((&___BuildVersion_0), value);
	}

	inline static int32_t get_offset_of_CharacterId_1() { return static_cast<int32_t>(offsetof(MatchmakeRequest_t1739851507, ___CharacterId_1)); }
	inline String_t* get_CharacterId_1() const { return ___CharacterId_1; }
	inline String_t** get_address_of_CharacterId_1() { return &___CharacterId_1; }
	inline void set_CharacterId_1(String_t* value)
	{
		___CharacterId_1 = value;
		Il2CppCodeGenWriteBarrier((&___CharacterId_1), value);
	}

	inline static int32_t get_offset_of_GameMode_2() { return static_cast<int32_t>(offsetof(MatchmakeRequest_t1739851507, ___GameMode_2)); }
	inline String_t* get_GameMode_2() const { return ___GameMode_2; }
	inline String_t** get_address_of_GameMode_2() { return &___GameMode_2; }
	inline void set_GameMode_2(String_t* value)
	{
		___GameMode_2 = value;
		Il2CppCodeGenWriteBarrier((&___GameMode_2), value);
	}

	inline static int32_t get_offset_of_LobbyId_3() { return static_cast<int32_t>(offsetof(MatchmakeRequest_t1739851507, ___LobbyId_3)); }
	inline String_t* get_LobbyId_3() const { return ___LobbyId_3; }
	inline String_t** get_address_of_LobbyId_3() { return &___LobbyId_3; }
	inline void set_LobbyId_3(String_t* value)
	{
		___LobbyId_3 = value;
		Il2CppCodeGenWriteBarrier((&___LobbyId_3), value);
	}

	inline static int32_t get_offset_of_Region_4() { return static_cast<int32_t>(offsetof(MatchmakeRequest_t1739851507, ___Region_4)); }
	inline Nullable_1_t1625618012  get_Region_4() const { return ___Region_4; }
	inline Nullable_1_t1625618012 * get_address_of_Region_4() { return &___Region_4; }
	inline void set_Region_4(Nullable_1_t1625618012  value)
	{
		___Region_4 = value;
	}

	inline static int32_t get_offset_of_StartNewIfNoneFound_5() { return static_cast<int32_t>(offsetof(MatchmakeRequest_t1739851507, ___StartNewIfNoneFound_5)); }
	inline Nullable_1_t1819850047  get_StartNewIfNoneFound_5() const { return ___StartNewIfNoneFound_5; }
	inline Nullable_1_t1819850047 * get_address_of_StartNewIfNoneFound_5() { return &___StartNewIfNoneFound_5; }
	inline void set_StartNewIfNoneFound_5(Nullable_1_t1819850047  value)
	{
		___StartNewIfNoneFound_5 = value;
	}

	inline static int32_t get_offset_of_StatisticName_6() { return static_cast<int32_t>(offsetof(MatchmakeRequest_t1739851507, ___StatisticName_6)); }
	inline String_t* get_StatisticName_6() const { return ___StatisticName_6; }
	inline String_t** get_address_of_StatisticName_6() { return &___StatisticName_6; }
	inline void set_StatisticName_6(String_t* value)
	{
		___StatisticName_6 = value;
		Il2CppCodeGenWriteBarrier((&___StatisticName_6), value);
	}

	inline static int32_t get_offset_of_TagFilter_7() { return static_cast<int32_t>(offsetof(MatchmakeRequest_t1739851507, ___TagFilter_7)); }
	inline CollectionFilter_t2867730642 * get_TagFilter_7() const { return ___TagFilter_7; }
	inline CollectionFilter_t2867730642 ** get_address_of_TagFilter_7() { return &___TagFilter_7; }
	inline void set_TagFilter_7(CollectionFilter_t2867730642 * value)
	{
		___TagFilter_7 = value;
		Il2CppCodeGenWriteBarrier((&___TagFilter_7), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // MATCHMAKEREQUEST_T1739851507_H
#ifndef REGIONINFO_T1716013666_H
#define REGIONINFO_T1716013666_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.RegionInfo
struct  RegionInfo_t1716013666  : public RuntimeObject
{
public:
	// System.Boolean PlayFab.ClientModels.RegionInfo::Available
	bool ___Available_0;
	// System.String PlayFab.ClientModels.RegionInfo::Name
	String_t* ___Name_1;
	// System.String PlayFab.ClientModels.RegionInfo::PingUrl
	String_t* ___PingUrl_2;
	// System.Nullable`1<PlayFab.ClientModels.Region> PlayFab.ClientModels.RegionInfo::Region
	Nullable_1_t1625618012  ___Region_3;

public:
	inline static int32_t get_offset_of_Available_0() { return static_cast<int32_t>(offsetof(RegionInfo_t1716013666, ___Available_0)); }
	inline bool get_Available_0() const { return ___Available_0; }
	inline bool* get_address_of_Available_0() { return &___Available_0; }
	inline void set_Available_0(bool value)
	{
		___Available_0 = value;
	}

	inline static int32_t get_offset_of_Name_1() { return static_cast<int32_t>(offsetof(RegionInfo_t1716013666, ___Name_1)); }
	inline String_t* get_Name_1() const { return ___Name_1; }
	inline String_t** get_address_of_Name_1() { return &___Name_1; }
	inline void set_Name_1(String_t* value)
	{
		___Name_1 = value;
		Il2CppCodeGenWriteBarrier((&___Name_1), value);
	}

	inline static int32_t get_offset_of_PingUrl_2() { return static_cast<int32_t>(offsetof(RegionInfo_t1716013666, ___PingUrl_2)); }
	inline String_t* get_PingUrl_2() const { return ___PingUrl_2; }
	inline String_t** get_address_of_PingUrl_2() { return &___PingUrl_2; }
	inline void set_PingUrl_2(String_t* value)
	{
		___PingUrl_2 = value;
		Il2CppCodeGenWriteBarrier((&___PingUrl_2), value);
	}

	inline static int32_t get_offset_of_Region_3() { return static_cast<int32_t>(offsetof(RegionInfo_t1716013666, ___Region_3)); }
	inline Nullable_1_t1625618012  get_Region_3() const { return ___Region_3; }
	inline Nullable_1_t1625618012 * get_address_of_Region_3() { return &___Region_3; }
	inline void set_Region_3(Nullable_1_t1625618012  value)
	{
		___Region_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // REGIONINFO_T1716013666_H
#ifndef PUSHNOTIFICATIONREGISTRATIONMODEL_T1403388172_H
#define PUSHNOTIFICATIONREGISTRATIONMODEL_T1403388172_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.PushNotificationRegistrationModel
struct  PushNotificationRegistrationModel_t1403388172  : public RuntimeObject
{
public:
	// System.String PlayFab.ClientModels.PushNotificationRegistrationModel::NotificationEndpointARN
	String_t* ___NotificationEndpointARN_0;
	// System.Nullable`1<PlayFab.ClientModels.PushNotificationPlatform> PlayFab.ClientModels.PushNotificationRegistrationModel::Platform
	Nullable_1_t2398459843  ___Platform_1;

public:
	inline static int32_t get_offset_of_NotificationEndpointARN_0() { return static_cast<int32_t>(offsetof(PushNotificationRegistrationModel_t1403388172, ___NotificationEndpointARN_0)); }
	inline String_t* get_NotificationEndpointARN_0() const { return ___NotificationEndpointARN_0; }
	inline String_t** get_address_of_NotificationEndpointARN_0() { return &___NotificationEndpointARN_0; }
	inline void set_NotificationEndpointARN_0(String_t* value)
	{
		___NotificationEndpointARN_0 = value;
		Il2CppCodeGenWriteBarrier((&___NotificationEndpointARN_0), value);
	}

	inline static int32_t get_offset_of_Platform_1() { return static_cast<int32_t>(offsetof(PushNotificationRegistrationModel_t1403388172, ___Platform_1)); }
	inline Nullable_1_t2398459843  get_Platform_1() const { return ___Platform_1; }
	inline Nullable_1_t2398459843 * get_address_of_Platform_1() { return &___Platform_1; }
	inline void set_Platform_1(Nullable_1_t2398459843  value)
	{
		___Platform_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // PUSHNOTIFICATIONREGISTRATIONMODEL_T1403388172_H
#ifndef PAYFORPURCHASERESULT_T2186103076_H
#define PAYFORPURCHASERESULT_T2186103076_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.PayForPurchaseResult
struct  PayForPurchaseResult_t2186103076  : public PlayFabResultCommon_t3469603827
{
public:
	// System.UInt32 PlayFab.ClientModels.PayForPurchaseResult::CreditApplied
	uint32_t ___CreditApplied_2;
	// System.String PlayFab.ClientModels.PayForPurchaseResult::OrderId
	String_t* ___OrderId_3;
	// System.String PlayFab.ClientModels.PayForPurchaseResult::ProviderData
	String_t* ___ProviderData_4;
	// System.String PlayFab.ClientModels.PayForPurchaseResult::ProviderToken
	String_t* ___ProviderToken_5;
	// System.String PlayFab.ClientModels.PayForPurchaseResult::PurchaseConfirmationPageURL
	String_t* ___PurchaseConfirmationPageURL_6;
	// System.String PlayFab.ClientModels.PayForPurchaseResult::PurchaseCurrency
	String_t* ___PurchaseCurrency_7;
	// System.UInt32 PlayFab.ClientModels.PayForPurchaseResult::PurchasePrice
	uint32_t ___PurchasePrice_8;
	// System.Nullable`1<PlayFab.ClientModels.TransactionStatus> PlayFab.ClientModels.PayForPurchaseResult::Status
	Nullable_1_t250137981  ___Status_9;
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> PlayFab.ClientModels.PayForPurchaseResult::VCAmount
	Dictionary_2_t2736202052 * ___VCAmount_10;
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> PlayFab.ClientModels.PayForPurchaseResult::VirtualCurrency
	Dictionary_2_t2736202052 * ___VirtualCurrency_11;

public:
	inline static int32_t get_offset_of_CreditApplied_2() { return static_cast<int32_t>(offsetof(PayForPurchaseResult_t2186103076, ___CreditApplied_2)); }
	inline uint32_t get_CreditApplied_2() const { return ___CreditApplied_2; }
	inline uint32_t* get_address_of_CreditApplied_2() { return &___CreditApplied_2; }
	inline void set_CreditApplied_2(uint32_t value)
	{
		___CreditApplied_2 = value;
	}

	inline static int32_t get_offset_of_OrderId_3() { return static_cast<int32_t>(offsetof(PayForPurchaseResult_t2186103076, ___OrderId_3)); }
	inline String_t* get_OrderId_3() const { return ___OrderId_3; }
	inline String_t** get_address_of_OrderId_3() { return &___OrderId_3; }
	inline void set_OrderId_3(String_t* value)
	{
		___OrderId_3 = value;
		Il2CppCodeGenWriteBarrier((&___OrderId_3), value);
	}

	inline static int32_t get_offset_of_ProviderData_4() { return static_cast<int32_t>(offsetof(PayForPurchaseResult_t2186103076, ___ProviderData_4)); }
	inline String_t* get_ProviderData_4() const { return ___ProviderData_4; }
	inline String_t** get_address_of_ProviderData_4() { return &___ProviderData_4; }
	inline void set_ProviderData_4(String_t* value)
	{
		___ProviderData_4 = value;
		Il2CppCodeGenWriteBarrier((&___ProviderData_4), value);
	}

	inline static int32_t get_offset_of_ProviderToken_5() { return static_cast<int32_t>(offsetof(PayForPurchaseResult_t2186103076, ___ProviderToken_5)); }
	inline String_t* get_ProviderToken_5() const { return ___ProviderToken_5; }
	inline String_t** get_address_of_ProviderToken_5() { return &___ProviderToken_5; }
	inline void set_ProviderToken_5(String_t* value)
	{
		___ProviderToken_5 = value;
		Il2CppCodeGenWriteBarrier((&___ProviderToken_5), value);
	}

	inline static int32_t get_offset_of_PurchaseConfirmationPageURL_6() { return static_cast<int32_t>(offsetof(PayForPurchaseResult_t2186103076, ___PurchaseConfirmationPageURL_6)); }
	inline String_t* get_PurchaseConfirmationPageURL_6() const { return ___PurchaseConfirmationPageURL_6; }
	inline String_t** get_address_of_PurchaseConfirmationPageURL_6() { return &___PurchaseConfirmationPageURL_6; }
	inline void set_PurchaseConfirmationPageURL_6(String_t* value)
	{
		___PurchaseConfirmationPageURL_6 = value;
		Il2CppCodeGenWriteBarrier((&___PurchaseConfirmationPageURL_6), value);
	}

	inline static int32_t get_offset_of_PurchaseCurrency_7() { return static_cast<int32_t>(offsetof(PayForPurchaseResult_t2186103076, ___PurchaseCurrency_7)); }
	inline String_t* get_PurchaseCurrency_7() const { return ___PurchaseCurrency_7; }
	inline String_t** get_address_of_PurchaseCurrency_7() { return &___PurchaseCurrency_7; }
	inline void set_PurchaseCurrency_7(String_t* value)
	{
		___PurchaseCurrency_7 = value;
		Il2CppCodeGenWriteBarrier((&___PurchaseCurrency_7), value);
	}

	inline static int32_t get_offset_of_PurchasePrice_8() { return static_cast<int32_t>(offsetof(PayForPurchaseResult_t2186103076, ___PurchasePrice_8)); }
	inline uint32_t get_PurchasePrice_8() const { return ___PurchasePrice_8; }
	inline uint32_t* get_address_of_PurchasePrice_8() { return &___PurchasePrice_8; }
	inline void set_PurchasePrice_8(uint32_t value)
	{
		___PurchasePrice_8 = value;
	}

	inline static int32_t get_offset_of_Status_9() { return static_cast<int32_t>(offsetof(PayForPurchaseResult_t2186103076, ___Status_9)); }
	inline Nullable_1_t250137981  get_Status_9() const { return ___Status_9; }
	inline Nullable_1_t250137981 * get_address_of_Status_9() { return &___Status_9; }
	inline void set_Status_9(Nullable_1_t250137981  value)
	{
		___Status_9 = value;
	}

	inline static int32_t get_offset_of_VCAmount_10() { return static_cast<int32_t>(offsetof(PayForPurchaseResult_t2186103076, ___VCAmount_10)); }
	inline Dictionary_2_t2736202052 * get_VCAmount_10() const { return ___VCAmount_10; }
	inline Dictionary_2_t2736202052 ** get_address_of_VCAmount_10() { return &___VCAmount_10; }
	inline void set_VCAmount_10(Dictionary_2_t2736202052 * value)
	{
		___VCAmount_10 = value;
		Il2CppCodeGenWriteBarrier((&___VCAmount_10), value);
	}

	inline static int32_t get_offset_of_VirtualCurrency_11() { return static_cast<int32_t>(offsetof(PayForPurchaseResult_t2186103076, ___VirtualCurrency_11)); }
	inline Dictionary_2_t2736202052 * get_VirtualCurrency_11() const { return ___VirtualCurrency_11; }
	inline Dictionary_2_t2736202052 ** get_address_of_VirtualCurrency_11() { return &___VirtualCurrency_11; }
	inline void set_VirtualCurrency_11(Dictionary_2_t2736202052 * value)
	{
		___VirtualCurrency_11 = value;
		Il2CppCodeGenWriteBarrier((&___VirtualCurrency_11), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // PAYFORPURCHASERESULT_T2186103076_H
#ifndef SHAREDGROUPDATARECORD_T1581922388_H
#define SHAREDGROUPDATARECORD_T1581922388_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.SharedGroupDataRecord
struct  SharedGroupDataRecord_t1581922388  : public RuntimeObject
{
public:
	// System.DateTime PlayFab.ClientModels.SharedGroupDataRecord::LastUpdated
	DateTime_t3738529785  ___LastUpdated_0;
	// System.String PlayFab.ClientModels.SharedGroupDataRecord::LastUpdatedBy
	String_t* ___LastUpdatedBy_1;
	// System.Nullable`1<PlayFab.ClientModels.UserDataPermission> PlayFab.ClientModels.SharedGroupDataRecord::Permission
	Nullable_1_t3748078693  ___Permission_2;
	// System.String PlayFab.ClientModels.SharedGroupDataRecord::Value
	String_t* ___Value_3;

public:
	inline static int32_t get_offset_of_LastUpdated_0() { return static_cast<int32_t>(offsetof(SharedGroupDataRecord_t1581922388, ___LastUpdated_0)); }
	inline DateTime_t3738529785  get_LastUpdated_0() const { return ___LastUpdated_0; }
	inline DateTime_t3738529785 * get_address_of_LastUpdated_0() { return &___LastUpdated_0; }
	inline void set_LastUpdated_0(DateTime_t3738529785  value)
	{
		___LastUpdated_0 = value;
	}

	inline static int32_t get_offset_of_LastUpdatedBy_1() { return static_cast<int32_t>(offsetof(SharedGroupDataRecord_t1581922388, ___LastUpdatedBy_1)); }
	inline String_t* get_LastUpdatedBy_1() const { return ___LastUpdatedBy_1; }
	inline String_t** get_address_of_LastUpdatedBy_1() { return &___LastUpdatedBy_1; }
	inline void set_LastUpdatedBy_1(String_t* value)
	{
		___LastUpdatedBy_1 = value;
		Il2CppCodeGenWriteBarrier((&___LastUpdatedBy_1), value);
	}

	inline static int32_t get_offset_of_Permission_2() { return static_cast<int32_t>(offsetof(SharedGroupDataRecord_t1581922388, ___Permission_2)); }
	inline Nullable_1_t3748078693  get_Permission_2() const { return ___Permission_2; }
	inline Nullable_1_t3748078693 * get_address_of_Permission_2() { return &___Permission_2; }
	inline void set_Permission_2(Nullable_1_t3748078693  value)
	{
		___Permission_2 = value;
	}

	inline static int32_t get_offset_of_Value_3() { return static_cast<int32_t>(offsetof(SharedGroupDataRecord_t1581922388, ___Value_3)); }
	inline String_t* get_Value_3() const { return ___Value_3; }
	inline String_t** get_address_of_Value_3() { return &___Value_3; }
	inline void set_Value_3(String_t* value)
	{
		___Value_3 = value;
		Il2CppCodeGenWriteBarrier((&___Value_3), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SHAREDGROUPDATARECORD_T1581922388_H
#ifndef LOCATIONMODEL_T3813501936_H
#define LOCATIONMODEL_T3813501936_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.LocationModel
struct  LocationModel_t3813501936  : public RuntimeObject
{
public:
	// System.String PlayFab.ClientModels.LocationModel::City
	String_t* ___City_0;
	// System.Nullable`1<PlayFab.ClientModels.ContinentCode> PlayFab.ClientModels.LocationModel::ContinentCode
	Nullable_1_t382695706  ___ContinentCode_1;
	// System.Nullable`1<PlayFab.ClientModels.CountryCode> PlayFab.ClientModels.LocationModel::CountryCode
	Nullable_1_t3467212419  ___CountryCode_2;
	// System.Nullable`1<System.Double> PlayFab.ClientModels.LocationModel::Latitude
	Nullable_1_t2317227445  ___Latitude_3;
	// System.Nullable`1<System.Double> PlayFab.ClientModels.LocationModel::Longitude
	Nullable_1_t2317227445  ___Longitude_4;

public:
	inline static int32_t get_offset_of_City_0() { return static_cast<int32_t>(offsetof(LocationModel_t3813501936, ___City_0)); }
	inline String_t* get_City_0() const { return ___City_0; }
	inline String_t** get_address_of_City_0() { return &___City_0; }
	inline void set_City_0(String_t* value)
	{
		___City_0 = value;
		Il2CppCodeGenWriteBarrier((&___City_0), value);
	}

	inline static int32_t get_offset_of_ContinentCode_1() { return static_cast<int32_t>(offsetof(LocationModel_t3813501936, ___ContinentCode_1)); }
	inline Nullable_1_t382695706  get_ContinentCode_1() const { return ___ContinentCode_1; }
	inline Nullable_1_t382695706 * get_address_of_ContinentCode_1() { return &___ContinentCode_1; }
	inline void set_ContinentCode_1(Nullable_1_t382695706  value)
	{
		___ContinentCode_1 = value;
	}

	inline static int32_t get_offset_of_CountryCode_2() { return static_cast<int32_t>(offsetof(LocationModel_t3813501936, ___CountryCode_2)); }
	inline Nullable_1_t3467212419  get_CountryCode_2() const { return ___CountryCode_2; }
	inline Nullable_1_t3467212419 * get_address_of_CountryCode_2() { return &___CountryCode_2; }
	inline void set_CountryCode_2(Nullable_1_t3467212419  value)
	{
		___CountryCode_2 = value;
	}

	inline static int32_t get_offset_of_Latitude_3() { return static_cast<int32_t>(offsetof(LocationModel_t3813501936, ___Latitude_3)); }
	inline Nullable_1_t2317227445  get_Latitude_3() const { return ___Latitude_3; }
	inline Nullable_1_t2317227445 * get_address_of_Latitude_3() { return &___Latitude_3; }
	inline void set_Latitude_3(Nullable_1_t2317227445  value)
	{
		___Latitude_3 = value;
	}

	inline static int32_t get_offset_of_Longitude_4() { return static_cast<int32_t>(offsetof(LocationModel_t3813501936, ___Longitude_4)); }
	inline Nullable_1_t2317227445  get_Longitude_4() const { return ___Longitude_4; }
	inline Nullable_1_t2317227445 * get_address_of_Longitude_4() { return &___Longitude_4; }
	inline void set_Longitude_4(Nullable_1_t2317227445  value)
	{
		___Longitude_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LOCATIONMODEL_T3813501936_H
#ifndef NULLABLE_1_T1166124571_H
#define NULLABLE_1_T1166124571_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Nullable`1<System.DateTime>
struct  Nullable_1_t1166124571 
{
public:
	// T System.Nullable`1::value
	DateTime_t3738529785  ___value_0;
	// System.Boolean System.Nullable`1::has_value
	bool ___has_value_1;

public:
	inline static int32_t get_offset_of_value_0() { return static_cast<int32_t>(offsetof(Nullable_1_t1166124571, ___value_0)); }
	inline DateTime_t3738529785  get_value_0() const { return ___value_0; }
	inline DateTime_t3738529785 * get_address_of_value_0() { return &___value_0; }
	inline void set_value_0(DateTime_t3738529785  value)
	{
		___value_0 = value;
	}

	inline static int32_t get_offset_of_has_value_1() { return static_cast<int32_t>(offsetof(Nullable_1_t1166124571, ___has_value_1)); }
	inline bool get_has_value_1() const { return ___has_value_1; }
	inline bool* get_address_of_has_value_1() { return &___has_value_1; }
	inline void set_has_value_1(bool value)
	{
		___has_value_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // NULLABLE_1_T1166124571_H
#ifndef ITEMINSTANCE_T3721622769_H
#define ITEMINSTANCE_T3721622769_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.ItemInstance
struct  ItemInstance_t3721622769  : public RuntimeObject
{
public:
	// System.String PlayFab.ClientModels.ItemInstance::Annotation
	String_t* ___Annotation_0;
	// System.Collections.Generic.List`1<System.String> PlayFab.ClientModels.ItemInstance::BundleContents
	List_1_t3319525431 * ___BundleContents_1;
	// System.String PlayFab.ClientModels.ItemInstance::BundleParent
	String_t* ___BundleParent_2;
	// System.String PlayFab.ClientModels.ItemInstance::CatalogVersion
	String_t* ___CatalogVersion_3;
	// System.Collections.Generic.Dictionary`2<System.String,System.String> PlayFab.ClientModels.ItemInstance::CustomData
	Dictionary_2_t1632706988 * ___CustomData_4;
	// System.String PlayFab.ClientModels.ItemInstance::DisplayName
	String_t* ___DisplayName_5;
	// System.Nullable`1<System.DateTime> PlayFab.ClientModels.ItemInstance::Expiration
	Nullable_1_t1166124571  ___Expiration_6;
	// System.String PlayFab.ClientModels.ItemInstance::ItemClass
	String_t* ___ItemClass_7;
	// System.String PlayFab.ClientModels.ItemInstance::ItemId
	String_t* ___ItemId_8;
	// System.String PlayFab.ClientModels.ItemInstance::ItemInstanceId
	String_t* ___ItemInstanceId_9;
	// System.Nullable`1<System.DateTime> PlayFab.ClientModels.ItemInstance::PurchaseDate
	Nullable_1_t1166124571  ___PurchaseDate_10;
	// System.Nullable`1<System.Int32> PlayFab.ClientModels.ItemInstance::RemainingUses
	Nullable_1_t378540539  ___RemainingUses_11;
	// System.String PlayFab.ClientModels.ItemInstance::UnitCurrency
	String_t* ___UnitCurrency_12;
	// System.UInt32 PlayFab.ClientModels.ItemInstance::UnitPrice
	uint32_t ___UnitPrice_13;
	// System.Nullable`1<System.Int32> PlayFab.ClientModels.ItemInstance::UsesIncrementedBy
	Nullable_1_t378540539  ___UsesIncrementedBy_14;

public:
	inline static int32_t get_offset_of_Annotation_0() { return static_cast<int32_t>(offsetof(ItemInstance_t3721622769, ___Annotation_0)); }
	inline String_t* get_Annotation_0() const { return ___Annotation_0; }
	inline String_t** get_address_of_Annotation_0() { return &___Annotation_0; }
	inline void set_Annotation_0(String_t* value)
	{
		___Annotation_0 = value;
		Il2CppCodeGenWriteBarrier((&___Annotation_0), value);
	}

	inline static int32_t get_offset_of_BundleContents_1() { return static_cast<int32_t>(offsetof(ItemInstance_t3721622769, ___BundleContents_1)); }
	inline List_1_t3319525431 * get_BundleContents_1() const { return ___BundleContents_1; }
	inline List_1_t3319525431 ** get_address_of_BundleContents_1() { return &___BundleContents_1; }
	inline void set_BundleContents_1(List_1_t3319525431 * value)
	{
		___BundleContents_1 = value;
		Il2CppCodeGenWriteBarrier((&___BundleContents_1), value);
	}

	inline static int32_t get_offset_of_BundleParent_2() { return static_cast<int32_t>(offsetof(ItemInstance_t3721622769, ___BundleParent_2)); }
	inline String_t* get_BundleParent_2() const { return ___BundleParent_2; }
	inline String_t** get_address_of_BundleParent_2() { return &___BundleParent_2; }
	inline void set_BundleParent_2(String_t* value)
	{
		___BundleParent_2 = value;
		Il2CppCodeGenWriteBarrier((&___BundleParent_2), value);
	}

	inline static int32_t get_offset_of_CatalogVersion_3() { return static_cast<int32_t>(offsetof(ItemInstance_t3721622769, ___CatalogVersion_3)); }
	inline String_t* get_CatalogVersion_3() const { return ___CatalogVersion_3; }
	inline String_t** get_address_of_CatalogVersion_3() { return &___CatalogVersion_3; }
	inline void set_CatalogVersion_3(String_t* value)
	{
		___CatalogVersion_3 = value;
		Il2CppCodeGenWriteBarrier((&___CatalogVersion_3), value);
	}

	inline static int32_t get_offset_of_CustomData_4() { return static_cast<int32_t>(offsetof(ItemInstance_t3721622769, ___CustomData_4)); }
	inline Dictionary_2_t1632706988 * get_CustomData_4() const { return ___CustomData_4; }
	inline Dictionary_2_t1632706988 ** get_address_of_CustomData_4() { return &___CustomData_4; }
	inline void set_CustomData_4(Dictionary_2_t1632706988 * value)
	{
		___CustomData_4 = value;
		Il2CppCodeGenWriteBarrier((&___CustomData_4), value);
	}

	inline static int32_t get_offset_of_DisplayName_5() { return static_cast<int32_t>(offsetof(ItemInstance_t3721622769, ___DisplayName_5)); }
	inline String_t* get_DisplayName_5() const { return ___DisplayName_5; }
	inline String_t** get_address_of_DisplayName_5() { return &___DisplayName_5; }
	inline void set_DisplayName_5(String_t* value)
	{
		___DisplayName_5 = value;
		Il2CppCodeGenWriteBarrier((&___DisplayName_5), value);
	}

	inline static int32_t get_offset_of_Expiration_6() { return static_cast<int32_t>(offsetof(ItemInstance_t3721622769, ___Expiration_6)); }
	inline Nullable_1_t1166124571  get_Expiration_6() const { return ___Expiration_6; }
	inline Nullable_1_t1166124571 * get_address_of_Expiration_6() { return &___Expiration_6; }
	inline void set_Expiration_6(Nullable_1_t1166124571  value)
	{
		___Expiration_6 = value;
	}

	inline static int32_t get_offset_of_ItemClass_7() { return static_cast<int32_t>(offsetof(ItemInstance_t3721622769, ___ItemClass_7)); }
	inline String_t* get_ItemClass_7() const { return ___ItemClass_7; }
	inline String_t** get_address_of_ItemClass_7() { return &___ItemClass_7; }
	inline void set_ItemClass_7(String_t* value)
	{
		___ItemClass_7 = value;
		Il2CppCodeGenWriteBarrier((&___ItemClass_7), value);
	}

	inline static int32_t get_offset_of_ItemId_8() { return static_cast<int32_t>(offsetof(ItemInstance_t3721622769, ___ItemId_8)); }
	inline String_t* get_ItemId_8() const { return ___ItemId_8; }
	inline String_t** get_address_of_ItemId_8() { return &___ItemId_8; }
	inline void set_ItemId_8(String_t* value)
	{
		___ItemId_8 = value;
		Il2CppCodeGenWriteBarrier((&___ItemId_8), value);
	}

	inline static int32_t get_offset_of_ItemInstanceId_9() { return static_cast<int32_t>(offsetof(ItemInstance_t3721622769, ___ItemInstanceId_9)); }
	inline String_t* get_ItemInstanceId_9() const { return ___ItemInstanceId_9; }
	inline String_t** get_address_of_ItemInstanceId_9() { return &___ItemInstanceId_9; }
	inline void set_ItemInstanceId_9(String_t* value)
	{
		___ItemInstanceId_9 = value;
		Il2CppCodeGenWriteBarrier((&___ItemInstanceId_9), value);
	}

	inline static int32_t get_offset_of_PurchaseDate_10() { return static_cast<int32_t>(offsetof(ItemInstance_t3721622769, ___PurchaseDate_10)); }
	inline Nullable_1_t1166124571  get_PurchaseDate_10() const { return ___PurchaseDate_10; }
	inline Nullable_1_t1166124571 * get_address_of_PurchaseDate_10() { return &___PurchaseDate_10; }
	inline void set_PurchaseDate_10(Nullable_1_t1166124571  value)
	{
		___PurchaseDate_10 = value;
	}

	inline static int32_t get_offset_of_RemainingUses_11() { return static_cast<int32_t>(offsetof(ItemInstance_t3721622769, ___RemainingUses_11)); }
	inline Nullable_1_t378540539  get_RemainingUses_11() const { return ___RemainingUses_11; }
	inline Nullable_1_t378540539 * get_address_of_RemainingUses_11() { return &___RemainingUses_11; }
	inline void set_RemainingUses_11(Nullable_1_t378540539  value)
	{
		___RemainingUses_11 = value;
	}

	inline static int32_t get_offset_of_UnitCurrency_12() { return static_cast<int32_t>(offsetof(ItemInstance_t3721622769, ___UnitCurrency_12)); }
	inline String_t* get_UnitCurrency_12() const { return ___UnitCurrency_12; }
	inline String_t** get_address_of_UnitCurrency_12() { return &___UnitCurrency_12; }
	inline void set_UnitCurrency_12(String_t* value)
	{
		___UnitCurrency_12 = value;
		Il2CppCodeGenWriteBarrier((&___UnitCurrency_12), value);
	}

	inline static int32_t get_offset_of_UnitPrice_13() { return static_cast<int32_t>(offsetof(ItemInstance_t3721622769, ___UnitPrice_13)); }
	inline uint32_t get_UnitPrice_13() const { return ___UnitPrice_13; }
	inline uint32_t* get_address_of_UnitPrice_13() { return &___UnitPrice_13; }
	inline void set_UnitPrice_13(uint32_t value)
	{
		___UnitPrice_13 = value;
	}

	inline static int32_t get_offset_of_UsesIncrementedBy_14() { return static_cast<int32_t>(offsetof(ItemInstance_t3721622769, ___UsesIncrementedBy_14)); }
	inline Nullable_1_t378540539  get_UsesIncrementedBy_14() const { return ___UsesIncrementedBy_14; }
	inline Nullable_1_t378540539 * get_address_of_UsesIncrementedBy_14() { return &___UsesIncrementedBy_14; }
	inline void set_UsesIncrementedBy_14(Nullable_1_t378540539  value)
	{
		___UsesIncrementedBy_14 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ITEMINSTANCE_T3721622769_H
#ifndef PLAYERSTATISTICVERSION_T2730724419_H
#define PLAYERSTATISTICVERSION_T2730724419_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.PlayerStatisticVersion
struct  PlayerStatisticVersion_t2730724419  : public RuntimeObject
{
public:
	// System.DateTime PlayFab.ClientModels.PlayerStatisticVersion::ActivationTime
	DateTime_t3738529785  ___ActivationTime_0;
	// System.Nullable`1<System.DateTime> PlayFab.ClientModels.PlayerStatisticVersion::DeactivationTime
	Nullable_1_t1166124571  ___DeactivationTime_1;
	// System.Nullable`1<System.DateTime> PlayFab.ClientModels.PlayerStatisticVersion::ScheduledActivationTime
	Nullable_1_t1166124571  ___ScheduledActivationTime_2;
	// System.Nullable`1<System.DateTime> PlayFab.ClientModels.PlayerStatisticVersion::ScheduledDeactivationTime
	Nullable_1_t1166124571  ___ScheduledDeactivationTime_3;
	// System.String PlayFab.ClientModels.PlayerStatisticVersion::StatisticName
	String_t* ___StatisticName_4;
	// System.UInt32 PlayFab.ClientModels.PlayerStatisticVersion::Version
	uint32_t ___Version_5;

public:
	inline static int32_t get_offset_of_ActivationTime_0() { return static_cast<int32_t>(offsetof(PlayerStatisticVersion_t2730724419, ___ActivationTime_0)); }
	inline DateTime_t3738529785  get_ActivationTime_0() const { return ___ActivationTime_0; }
	inline DateTime_t3738529785 * get_address_of_ActivationTime_0() { return &___ActivationTime_0; }
	inline void set_ActivationTime_0(DateTime_t3738529785  value)
	{
		___ActivationTime_0 = value;
	}

	inline static int32_t get_offset_of_DeactivationTime_1() { return static_cast<int32_t>(offsetof(PlayerStatisticVersion_t2730724419, ___DeactivationTime_1)); }
	inline Nullable_1_t1166124571  get_DeactivationTime_1() const { return ___DeactivationTime_1; }
	inline Nullable_1_t1166124571 * get_address_of_DeactivationTime_1() { return &___DeactivationTime_1; }
	inline void set_DeactivationTime_1(Nullable_1_t1166124571  value)
	{
		___DeactivationTime_1 = value;
	}

	inline static int32_t get_offset_of_ScheduledActivationTime_2() { return static_cast<int32_t>(offsetof(PlayerStatisticVersion_t2730724419, ___ScheduledActivationTime_2)); }
	inline Nullable_1_t1166124571  get_ScheduledActivationTime_2() const { return ___ScheduledActivationTime_2; }
	inline Nullable_1_t1166124571 * get_address_of_ScheduledActivationTime_2() { return &___ScheduledActivationTime_2; }
	inline void set_ScheduledActivationTime_2(Nullable_1_t1166124571  value)
	{
		___ScheduledActivationTime_2 = value;
	}

	inline static int32_t get_offset_of_ScheduledDeactivationTime_3() { return static_cast<int32_t>(offsetof(PlayerStatisticVersion_t2730724419, ___ScheduledDeactivationTime_3)); }
	inline Nullable_1_t1166124571  get_ScheduledDeactivationTime_3() const { return ___ScheduledDeactivationTime_3; }
	inline Nullable_1_t1166124571 * get_address_of_ScheduledDeactivationTime_3() { return &___ScheduledDeactivationTime_3; }
	inline void set_ScheduledDeactivationTime_3(Nullable_1_t1166124571  value)
	{
		___ScheduledDeactivationTime_3 = value;
	}

	inline static int32_t get_offset_of_StatisticName_4() { return static_cast<int32_t>(offsetof(PlayerStatisticVersion_t2730724419, ___StatisticName_4)); }
	inline String_t* get_StatisticName_4() const { return ___StatisticName_4; }
	inline String_t** get_address_of_StatisticName_4() { return &___StatisticName_4; }
	inline void set_StatisticName_4(String_t* value)
	{
		___StatisticName_4 = value;
		Il2CppCodeGenWriteBarrier((&___StatisticName_4), value);
	}

	inline static int32_t get_offset_of_Version_5() { return static_cast<int32_t>(offsetof(PlayerStatisticVersion_t2730724419, ___Version_5)); }
	inline uint32_t get_Version_5() const { return ___Version_5; }
	inline uint32_t* get_address_of_Version_5() { return &___Version_5; }
	inline void set_Version_5(uint32_t value)
	{
		___Version_5 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // PLAYERSTATISTICVERSION_T2730724419_H
#ifndef PLAYERPROFILEMODEL_T250934598_H
#define PLAYERPROFILEMODEL_T250934598_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.PlayerProfileModel
struct  PlayerProfileModel_t250934598  : public RuntimeObject
{
public:
	// System.Collections.Generic.List`1<PlayFab.ClientModels.AdCampaignAttributionModel> PlayFab.ClientModels.PlayerProfileModel::AdCampaignAttributions
	List_1_t406833115 * ___AdCampaignAttributions_0;
	// System.String PlayFab.ClientModels.PlayerProfileModel::AvatarUrl
	String_t* ___AvatarUrl_1;
	// System.Nullable`1<System.DateTime> PlayFab.ClientModels.PlayerProfileModel::BannedUntil
	Nullable_1_t1166124571  ___BannedUntil_2;
	// System.Collections.Generic.List`1<PlayFab.ClientModels.ContactEmailInfoModel> PlayFab.ClientModels.PlayerProfileModel::ContactEmailAddresses
	List_1_t1117944676 * ___ContactEmailAddresses_3;
	// System.Nullable`1<System.DateTime> PlayFab.ClientModels.PlayerProfileModel::Created
	Nullable_1_t1166124571  ___Created_4;
	// System.String PlayFab.ClientModels.PlayerProfileModel::DisplayName
	String_t* ___DisplayName_5;
	// System.Nullable`1<System.DateTime> PlayFab.ClientModels.PlayerProfileModel::LastLogin
	Nullable_1_t1166124571  ___LastLogin_6;
	// System.Collections.Generic.List`1<PlayFab.ClientModels.LinkedPlatformAccountModel> PlayFab.ClientModels.PlayerProfileModel::LinkedAccounts
	List_1_t4191507331 * ___LinkedAccounts_7;
	// System.Collections.Generic.List`1<PlayFab.ClientModels.LocationModel> PlayFab.ClientModels.PlayerProfileModel::Locations
	List_1_t990609382 * ___Locations_8;
	// System.Collections.Generic.List`1<PlayFab.ClientModels.MembershipModel> PlayFab.ClientModels.PlayerProfileModel::Memberships
	List_1_t2844474068 * ___Memberships_9;
	// System.Nullable`1<PlayFab.ClientModels.LoginIdentityProvider> PlayFab.ClientModels.PlayerProfileModel::Origination
	Nullable_1_t3603180267  ___Origination_10;
	// System.String PlayFab.ClientModels.PlayerProfileModel::PlayerId
	String_t* ___PlayerId_11;
	// System.String PlayFab.ClientModels.PlayerProfileModel::PublisherId
	String_t* ___PublisherId_12;
	// System.Collections.Generic.List`1<PlayFab.ClientModels.PushNotificationRegistrationModel> PlayFab.ClientModels.PlayerProfileModel::PushNotificationRegistrations
	List_1_t2875462914 * ___PushNotificationRegistrations_13;
	// System.Collections.Generic.List`1<PlayFab.ClientModels.StatisticModel> PlayFab.ClientModels.PlayerProfileModel::Statistics
	List_1_t2070485369 * ___Statistics_14;
	// System.Collections.Generic.List`1<PlayFab.ClientModels.TagModel> PlayFab.ClientModels.PlayerProfileModel::Tags
	List_1_t4252289162 * ___Tags_15;
	// System.String PlayFab.ClientModels.PlayerProfileModel::TitleId
	String_t* ___TitleId_16;
	// System.Nullable`1<System.UInt32> PlayFab.ClientModels.PlayerProfileModel::TotalValueToDateInUSD
	Nullable_1_t4282624060  ___TotalValueToDateInUSD_17;
	// System.Collections.Generic.List`1<PlayFab.ClientModels.ValueToDateModel> PlayFab.ClientModels.PlayerProfileModel::ValuesToDate
	List_1_t1071715830 * ___ValuesToDate_18;

public:
	inline static int32_t get_offset_of_AdCampaignAttributions_0() { return static_cast<int32_t>(offsetof(PlayerProfileModel_t250934598, ___AdCampaignAttributions_0)); }
	inline List_1_t406833115 * get_AdCampaignAttributions_0() const { return ___AdCampaignAttributions_0; }
	inline List_1_t406833115 ** get_address_of_AdCampaignAttributions_0() { return &___AdCampaignAttributions_0; }
	inline void set_AdCampaignAttributions_0(List_1_t406833115 * value)
	{
		___AdCampaignAttributions_0 = value;
		Il2CppCodeGenWriteBarrier((&___AdCampaignAttributions_0), value);
	}

	inline static int32_t get_offset_of_AvatarUrl_1() { return static_cast<int32_t>(offsetof(PlayerProfileModel_t250934598, ___AvatarUrl_1)); }
	inline String_t* get_AvatarUrl_1() const { return ___AvatarUrl_1; }
	inline String_t** get_address_of_AvatarUrl_1() { return &___AvatarUrl_1; }
	inline void set_AvatarUrl_1(String_t* value)
	{
		___AvatarUrl_1 = value;
		Il2CppCodeGenWriteBarrier((&___AvatarUrl_1), value);
	}

	inline static int32_t get_offset_of_BannedUntil_2() { return static_cast<int32_t>(offsetof(PlayerProfileModel_t250934598, ___BannedUntil_2)); }
	inline Nullable_1_t1166124571  get_BannedUntil_2() const { return ___BannedUntil_2; }
	inline Nullable_1_t1166124571 * get_address_of_BannedUntil_2() { return &___BannedUntil_2; }
	inline void set_BannedUntil_2(Nullable_1_t1166124571  value)
	{
		___BannedUntil_2 = value;
	}

	inline static int32_t get_offset_of_ContactEmailAddresses_3() { return static_cast<int32_t>(offsetof(PlayerProfileModel_t250934598, ___ContactEmailAddresses_3)); }
	inline List_1_t1117944676 * get_ContactEmailAddresses_3() const { return ___ContactEmailAddresses_3; }
	inline List_1_t1117944676 ** get_address_of_ContactEmailAddresses_3() { return &___ContactEmailAddresses_3; }
	inline void set_ContactEmailAddresses_3(List_1_t1117944676 * value)
	{
		___ContactEmailAddresses_3 = value;
		Il2CppCodeGenWriteBarrier((&___ContactEmailAddresses_3), value);
	}

	inline static int32_t get_offset_of_Created_4() { return static_cast<int32_t>(offsetof(PlayerProfileModel_t250934598, ___Created_4)); }
	inline Nullable_1_t1166124571  get_Created_4() const { return ___Created_4; }
	inline Nullable_1_t1166124571 * get_address_of_Created_4() { return &___Created_4; }
	inline void set_Created_4(Nullable_1_t1166124571  value)
	{
		___Created_4 = value;
	}

	inline static int32_t get_offset_of_DisplayName_5() { return static_cast<int32_t>(offsetof(PlayerProfileModel_t250934598, ___DisplayName_5)); }
	inline String_t* get_DisplayName_5() const { return ___DisplayName_5; }
	inline String_t** get_address_of_DisplayName_5() { return &___DisplayName_5; }
	inline void set_DisplayName_5(String_t* value)
	{
		___DisplayName_5 = value;
		Il2CppCodeGenWriteBarrier((&___DisplayName_5), value);
	}

	inline static int32_t get_offset_of_LastLogin_6() { return static_cast<int32_t>(offsetof(PlayerProfileModel_t250934598, ___LastLogin_6)); }
	inline Nullable_1_t1166124571  get_LastLogin_6() const { return ___LastLogin_6; }
	inline Nullable_1_t1166124571 * get_address_of_LastLogin_6() { return &___LastLogin_6; }
	inline void set_LastLogin_6(Nullable_1_t1166124571  value)
	{
		___LastLogin_6 = value;
	}

	inline static int32_t get_offset_of_LinkedAccounts_7() { return static_cast<int32_t>(offsetof(PlayerProfileModel_t250934598, ___LinkedAccounts_7)); }
	inline List_1_t4191507331 * get_LinkedAccounts_7() const { return ___LinkedAccounts_7; }
	inline List_1_t4191507331 ** get_address_of_LinkedAccounts_7() { return &___LinkedAccounts_7; }
	inline void set_LinkedAccounts_7(List_1_t4191507331 * value)
	{
		___LinkedAccounts_7 = value;
		Il2CppCodeGenWriteBarrier((&___LinkedAccounts_7), value);
	}

	inline static int32_t get_offset_of_Locations_8() { return static_cast<int32_t>(offsetof(PlayerProfileModel_t250934598, ___Locations_8)); }
	inline List_1_t990609382 * get_Locations_8() const { return ___Locations_8; }
	inline List_1_t990609382 ** get_address_of_Locations_8() { return &___Locations_8; }
	inline void set_Locations_8(List_1_t990609382 * value)
	{
		___Locations_8 = value;
		Il2CppCodeGenWriteBarrier((&___Locations_8), value);
	}

	inline static int32_t get_offset_of_Memberships_9() { return static_cast<int32_t>(offsetof(PlayerProfileModel_t250934598, ___Memberships_9)); }
	inline List_1_t2844474068 * get_Memberships_9() const { return ___Memberships_9; }
	inline List_1_t2844474068 ** get_address_of_Memberships_9() { return &___Memberships_9; }
	inline void set_Memberships_9(List_1_t2844474068 * value)
	{
		___Memberships_9 = value;
		Il2CppCodeGenWriteBarrier((&___Memberships_9), value);
	}

	inline static int32_t get_offset_of_Origination_10() { return static_cast<int32_t>(offsetof(PlayerProfileModel_t250934598, ___Origination_10)); }
	inline Nullable_1_t3603180267  get_Origination_10() const { return ___Origination_10; }
	inline Nullable_1_t3603180267 * get_address_of_Origination_10() { return &___Origination_10; }
	inline void set_Origination_10(Nullable_1_t3603180267  value)
	{
		___Origination_10 = value;
	}

	inline static int32_t get_offset_of_PlayerId_11() { return static_cast<int32_t>(offsetof(PlayerProfileModel_t250934598, ___PlayerId_11)); }
	inline String_t* get_PlayerId_11() const { return ___PlayerId_11; }
	inline String_t** get_address_of_PlayerId_11() { return &___PlayerId_11; }
	inline void set_PlayerId_11(String_t* value)
	{
		___PlayerId_11 = value;
		Il2CppCodeGenWriteBarrier((&___PlayerId_11), value);
	}

	inline static int32_t get_offset_of_PublisherId_12() { return static_cast<int32_t>(offsetof(PlayerProfileModel_t250934598, ___PublisherId_12)); }
	inline String_t* get_PublisherId_12() const { return ___PublisherId_12; }
	inline String_t** get_address_of_PublisherId_12() { return &___PublisherId_12; }
	inline void set_PublisherId_12(String_t* value)
	{
		___PublisherId_12 = value;
		Il2CppCodeGenWriteBarrier((&___PublisherId_12), value);
	}

	inline static int32_t get_offset_of_PushNotificationRegistrations_13() { return static_cast<int32_t>(offsetof(PlayerProfileModel_t250934598, ___PushNotificationRegistrations_13)); }
	inline List_1_t2875462914 * get_PushNotificationRegistrations_13() const { return ___PushNotificationRegistrations_13; }
	inline List_1_t2875462914 ** get_address_of_PushNotificationRegistrations_13() { return &___PushNotificationRegistrations_13; }
	inline void set_PushNotificationRegistrations_13(List_1_t2875462914 * value)
	{
		___PushNotificationRegistrations_13 = value;
		Il2CppCodeGenWriteBarrier((&___PushNotificationRegistrations_13), value);
	}

	inline static int32_t get_offset_of_Statistics_14() { return static_cast<int32_t>(offsetof(PlayerProfileModel_t250934598, ___Statistics_14)); }
	inline List_1_t2070485369 * get_Statistics_14() const { return ___Statistics_14; }
	inline List_1_t2070485369 ** get_address_of_Statistics_14() { return &___Statistics_14; }
	inline void set_Statistics_14(List_1_t2070485369 * value)
	{
		___Statistics_14 = value;
		Il2CppCodeGenWriteBarrier((&___Statistics_14), value);
	}

	inline static int32_t get_offset_of_Tags_15() { return static_cast<int32_t>(offsetof(PlayerProfileModel_t250934598, ___Tags_15)); }
	inline List_1_t4252289162 * get_Tags_15() const { return ___Tags_15; }
	inline List_1_t4252289162 ** get_address_of_Tags_15() { return &___Tags_15; }
	inline void set_Tags_15(List_1_t4252289162 * value)
	{
		___Tags_15 = value;
		Il2CppCodeGenWriteBarrier((&___Tags_15), value);
	}

	inline static int32_t get_offset_of_TitleId_16() { return static_cast<int32_t>(offsetof(PlayerProfileModel_t250934598, ___TitleId_16)); }
	inline String_t* get_TitleId_16() const { return ___TitleId_16; }
	inline String_t** get_address_of_TitleId_16() { return &___TitleId_16; }
	inline void set_TitleId_16(String_t* value)
	{
		___TitleId_16 = value;
		Il2CppCodeGenWriteBarrier((&___TitleId_16), value);
	}

	inline static int32_t get_offset_of_TotalValueToDateInUSD_17() { return static_cast<int32_t>(offsetof(PlayerProfileModel_t250934598, ___TotalValueToDateInUSD_17)); }
	inline Nullable_1_t4282624060  get_TotalValueToDateInUSD_17() const { return ___TotalValueToDateInUSD_17; }
	inline Nullable_1_t4282624060 * get_address_of_TotalValueToDateInUSD_17() { return &___TotalValueToDateInUSD_17; }
	inline void set_TotalValueToDateInUSD_17(Nullable_1_t4282624060  value)
	{
		___TotalValueToDateInUSD_17 = value;
	}

	inline static int32_t get_offset_of_ValuesToDate_18() { return static_cast<int32_t>(offsetof(PlayerProfileModel_t250934598, ___ValuesToDate_18)); }
	inline List_1_t1071715830 * get_ValuesToDate_18() const { return ___ValuesToDate_18; }
	inline List_1_t1071715830 ** get_address_of_ValuesToDate_18() { return &___ValuesToDate_18; }
	inline void set_ValuesToDate_18(List_1_t1071715830 * value)
	{
		___ValuesToDate_18 = value;
		Il2CppCodeGenWriteBarrier((&___ValuesToDate_18), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // PLAYERPROFILEMODEL_T250934598_H
#ifndef LOGINRESULT_T1741360290_H
#define LOGINRESULT_T1741360290_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.LoginResult
struct  LoginResult_t1741360290  : public PlayFabResultCommon_t3469603827
{
public:
	// PlayFab.ClientModels.EntityTokenResponse PlayFab.ClientModels.LoginResult::EntityToken
	EntityTokenResponse_t1814794135 * ___EntityToken_2;
	// PlayFab.ClientModels.GetPlayerCombinedInfoResultPayload PlayFab.ClientModels.LoginResult::InfoResultPayload
	GetPlayerCombinedInfoResultPayload_t2789378405 * ___InfoResultPayload_3;
	// System.Nullable`1<System.DateTime> PlayFab.ClientModels.LoginResult::LastLoginTime
	Nullable_1_t1166124571  ___LastLoginTime_4;
	// System.Boolean PlayFab.ClientModels.LoginResult::NewlyCreated
	bool ___NewlyCreated_5;
	// System.String PlayFab.ClientModels.LoginResult::PlayFabId
	String_t* ___PlayFabId_6;
	// System.String PlayFab.ClientModels.LoginResult::SessionTicket
	String_t* ___SessionTicket_7;
	// PlayFab.ClientModels.UserSettings PlayFab.ClientModels.LoginResult::SettingsForUser
	UserSettings_t3054366223 * ___SettingsForUser_8;

public:
	inline static int32_t get_offset_of_EntityToken_2() { return static_cast<int32_t>(offsetof(LoginResult_t1741360290, ___EntityToken_2)); }
	inline EntityTokenResponse_t1814794135 * get_EntityToken_2() const { return ___EntityToken_2; }
	inline EntityTokenResponse_t1814794135 ** get_address_of_EntityToken_2() { return &___EntityToken_2; }
	inline void set_EntityToken_2(EntityTokenResponse_t1814794135 * value)
	{
		___EntityToken_2 = value;
		Il2CppCodeGenWriteBarrier((&___EntityToken_2), value);
	}

	inline static int32_t get_offset_of_InfoResultPayload_3() { return static_cast<int32_t>(offsetof(LoginResult_t1741360290, ___InfoResultPayload_3)); }
	inline GetPlayerCombinedInfoResultPayload_t2789378405 * get_InfoResultPayload_3() const { return ___InfoResultPayload_3; }
	inline GetPlayerCombinedInfoResultPayload_t2789378405 ** get_address_of_InfoResultPayload_3() { return &___InfoResultPayload_3; }
	inline void set_InfoResultPayload_3(GetPlayerCombinedInfoResultPayload_t2789378405 * value)
	{
		___InfoResultPayload_3 = value;
		Il2CppCodeGenWriteBarrier((&___InfoResultPayload_3), value);
	}

	inline static int32_t get_offset_of_LastLoginTime_4() { return static_cast<int32_t>(offsetof(LoginResult_t1741360290, ___LastLoginTime_4)); }
	inline Nullable_1_t1166124571  get_LastLoginTime_4() const { return ___LastLoginTime_4; }
	inline Nullable_1_t1166124571 * get_address_of_LastLoginTime_4() { return &___LastLoginTime_4; }
	inline void set_LastLoginTime_4(Nullable_1_t1166124571  value)
	{
		___LastLoginTime_4 = value;
	}

	inline static int32_t get_offset_of_NewlyCreated_5() { return static_cast<int32_t>(offsetof(LoginResult_t1741360290, ___NewlyCreated_5)); }
	inline bool get_NewlyCreated_5() const { return ___NewlyCreated_5; }
	inline bool* get_address_of_NewlyCreated_5() { return &___NewlyCreated_5; }
	inline void set_NewlyCreated_5(bool value)
	{
		___NewlyCreated_5 = value;
	}

	inline static int32_t get_offset_of_PlayFabId_6() { return static_cast<int32_t>(offsetof(LoginResult_t1741360290, ___PlayFabId_6)); }
	inline String_t* get_PlayFabId_6() const { return ___PlayFabId_6; }
	inline String_t** get_address_of_PlayFabId_6() { return &___PlayFabId_6; }
	inline void set_PlayFabId_6(String_t* value)
	{
		___PlayFabId_6 = value;
		Il2CppCodeGenWriteBarrier((&___PlayFabId_6), value);
	}

	inline static int32_t get_offset_of_SessionTicket_7() { return static_cast<int32_t>(offsetof(LoginResult_t1741360290, ___SessionTicket_7)); }
	inline String_t* get_SessionTicket_7() const { return ___SessionTicket_7; }
	inline String_t** get_address_of_SessionTicket_7() { return &___SessionTicket_7; }
	inline void set_SessionTicket_7(String_t* value)
	{
		___SessionTicket_7 = value;
		Il2CppCodeGenWriteBarrier((&___SessionTicket_7), value);
	}

	inline static int32_t get_offset_of_SettingsForUser_8() { return static_cast<int32_t>(offsetof(LoginResult_t1741360290, ___SettingsForUser_8)); }
	inline UserSettings_t3054366223 * get_SettingsForUser_8() const { return ___SettingsForUser_8; }
	inline UserSettings_t3054366223 ** get_address_of_SettingsForUser_8() { return &___SettingsForUser_8; }
	inline void set_SettingsForUser_8(UserSettings_t3054366223 * value)
	{
		___SettingsForUser_8 = value;
		Il2CppCodeGenWriteBarrier((&___SettingsForUser_8), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LOGINRESULT_T1741360290_H
#ifndef MEMBERSHIPMODEL_T1372399326_H
#define MEMBERSHIPMODEL_T1372399326_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayFab.ClientModels.MembershipModel
struct  MembershipModel_t1372399326  : public RuntimeObject
{
public:
	// System.Boolean PlayFab.ClientModels.MembershipModel::IsActive
	bool ___IsActive_0;
	// System.DateTime PlayFab.ClientModels.MembershipModel::MembershipExpiration
	DateTime_t3738529785  ___MembershipExpiration_1;
	// System.String PlayFab.ClientModels.MembershipModel::MembershipId
	String_t* ___MembershipId_2;
	// System.Nullable`1<System.DateTime> PlayFab.ClientModels.MembershipModel::OverrideExpiration
	Nullable_1_t1166124571  ___OverrideExpiration_3;
	// System.Collections.Generic.List`1<PlayFab.ClientModels.SubscriptionModel> PlayFab.ClientModels.MembershipModel::Subscriptions
	List_1_t2010074131 * ___Subscriptions_4;

public:
	inline static int32_t get_offset_of_IsActive_0() { return static_cast<int32_t>(offsetof(MembershipModel_t1372399326, ___IsActive_0)); }
	inline bool get_IsActive_0() const { return ___IsActive_0; }
	inline bool* get_address_of_IsActive_0() { return &___IsActive_0; }
	inline void set_IsActive_0(bool value)
	{
		___IsActive_0 = value;
	}

	inline static int32_t get_offset_of_MembershipExpiration_1() { return static_cast<int32_t>(offsetof(MembershipModel_t1372399326, ___MembershipExpiration_1)); }
	inline DateTime_t3738529785  get_MembershipExpiration_1() const { return ___MembershipExpiration_1; }
	inline DateTime_t3738529785 * get_address_of_MembershipExpiration_1() { return &___MembershipExpiration_1; }
	inline void set_MembershipExpiration_1(DateTime_t3738529785  value)
	{
		___MembershipExpiration_1 = value;
	}

	inline static int32_t get_offset_of_MembershipId_2() { return static_cast<int32_t>(offsetof(MembershipModel_t1372399326, ___MembershipId_2)); }
	inline String_t* get_MembershipId_2() const { return ___MembershipId_2; }
	inline String_t** get_address_of_MembershipId_2() { return &___MembershipId_2; }
	inline void set_MembershipId_2(String_t* value)
	{
		___MembershipId_2 = value;
		Il2CppCodeGenWriteBarrier((&___MembershipId_2), value);
	}

	inline static int32_t get_offset_of_OverrideExpiration_3() { return static_cast<int32_t>(offsetof(MembershipModel_t1372399326, ___OverrideExpiration_3)); }
	inline Nullable_1_t1166124571  get_OverrideExpiration_3() const { return ___OverrideExpiration_3; }
	inline Nullable_1_t1166124571 * get_address_of_OverrideExpiration_3() { return &___OverrideExpiration_3; }
	inline void set_OverrideExpiration_3(Nullable_1_t1166124571  value)
	{
		___OverrideExpiration_3 = value;
	}

	inline static int32_t get_offset_of_Subscriptions_4() { return static_cast<int32_t>(offsetof(MembershipModel_t1372399326, ___Subscriptions_4)); }
	inline List_1_t2010074131 * get_Subscriptions_4() const { return ___Subscriptions_4; }
	inline List_1_t2010074131 ** get_address_of_Subscriptions_4() { return &___Subscriptions_4; }
	inline void set_Subscriptions_4(List_1_t2010074131 * value)
	{
		___Subscriptions_4 = value;
		Il2CppCodeGenWriteBarrier((&___Subscriptions_4), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // MEMBERSHIPMODEL_T1372399326_H





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3500 = { sizeof (GooglePlayFabIdPair_t4035589282), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3500[2] = 
{
	GooglePlayFabIdPair_t4035589282::get_offset_of_GoogleId_0(),
	GooglePlayFabIdPair_t4035589282::get_offset_of_PlayFabId_1(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3501 = { sizeof (GrantCharacterToUserRequest_t2936922968), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3501[3] = 
{
	GrantCharacterToUserRequest_t2936922968::get_offset_of_CatalogVersion_0(),
	GrantCharacterToUserRequest_t2936922968::get_offset_of_CharacterName_1(),
	GrantCharacterToUserRequest_t2936922968::get_offset_of_ItemId_2(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3502 = { sizeof (GrantCharacterToUserResult_t2109757427), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3502[3] = 
{
	GrantCharacterToUserResult_t2109757427::get_offset_of_CharacterId_2(),
	GrantCharacterToUserResult_t2109757427::get_offset_of_CharacterType_3(),
	GrantCharacterToUserResult_t2109757427::get_offset_of_Result_4(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3503 = { sizeof (ItemInstance_t3721622769), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3503[15] = 
{
	ItemInstance_t3721622769::get_offset_of_Annotation_0(),
	ItemInstance_t3721622769::get_offset_of_BundleContents_1(),
	ItemInstance_t3721622769::get_offset_of_BundleParent_2(),
	ItemInstance_t3721622769::get_offset_of_CatalogVersion_3(),
	ItemInstance_t3721622769::get_offset_of_CustomData_4(),
	ItemInstance_t3721622769::get_offset_of_DisplayName_5(),
	ItemInstance_t3721622769::get_offset_of_Expiration_6(),
	ItemInstance_t3721622769::get_offset_of_ItemClass_7(),
	ItemInstance_t3721622769::get_offset_of_ItemId_8(),
	ItemInstance_t3721622769::get_offset_of_ItemInstanceId_9(),
	ItemInstance_t3721622769::get_offset_of_PurchaseDate_10(),
	ItemInstance_t3721622769::get_offset_of_RemainingUses_11(),
	ItemInstance_t3721622769::get_offset_of_UnitCurrency_12(),
	ItemInstance_t3721622769::get_offset_of_UnitPrice_13(),
	ItemInstance_t3721622769::get_offset_of_UsesIncrementedBy_14(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3504 = { sizeof (ItemPurchaseRequest_t2333686997), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3504[4] = 
{
	ItemPurchaseRequest_t2333686997::get_offset_of_Annotation_0(),
	ItemPurchaseRequest_t2333686997::get_offset_of_ItemId_1(),
	ItemPurchaseRequest_t2333686997::get_offset_of_Quantity_2(),
	ItemPurchaseRequest_t2333686997::get_offset_of_UpgradeFromItems_3(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3505 = { sizeof (KongregatePlayFabIdPair_t3490969040), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3505[2] = 
{
	KongregatePlayFabIdPair_t3490969040::get_offset_of_KongregateId_0(),
	KongregatePlayFabIdPair_t3490969040::get_offset_of_PlayFabId_1(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3506 = { sizeof (LinkAndroidDeviceIDRequest_t254733486), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3506[4] = 
{
	LinkAndroidDeviceIDRequest_t254733486::get_offset_of_AndroidDevice_0(),
	LinkAndroidDeviceIDRequest_t254733486::get_offset_of_AndroidDeviceId_1(),
	LinkAndroidDeviceIDRequest_t254733486::get_offset_of_ForceLink_2(),
	LinkAndroidDeviceIDRequest_t254733486::get_offset_of_OS_3(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3507 = { sizeof (LinkAndroidDeviceIDResult_t552766912), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3508 = { sizeof (LinkCustomIDRequest_t2139586330), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3508[2] = 
{
	LinkCustomIDRequest_t2139586330::get_offset_of_CustomId_0(),
	LinkCustomIDRequest_t2139586330::get_offset_of_ForceLink_1(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3509 = { sizeof (LinkCustomIDResult_t139981749), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3510 = { sizeof (LinkedPlatformAccountModel_t2719432589), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3510[4] = 
{
	LinkedPlatformAccountModel_t2719432589::get_offset_of_Email_0(),
	LinkedPlatformAccountModel_t2719432589::get_offset_of_Platform_1(),
	LinkedPlatformAccountModel_t2719432589::get_offset_of_PlatformUserId_2(),
	LinkedPlatformAccountModel_t2719432589::get_offset_of_Username_3(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3511 = { sizeof (LinkFacebookAccountRequest_t206724149), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3511[2] = 
{
	LinkFacebookAccountRequest_t206724149::get_offset_of_AccessToken_0(),
	LinkFacebookAccountRequest_t206724149::get_offset_of_ForceLink_1(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3512 = { sizeof (LinkFacebookAccountResult_t3882480540), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3513 = { sizeof (LinkGameCenterAccountRequest_t2735439760), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3513[2] = 
{
	LinkGameCenterAccountRequest_t2735439760::get_offset_of_ForceLink_0(),
	LinkGameCenterAccountRequest_t2735439760::get_offset_of_GameCenterId_1(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3514 = { sizeof (LinkGameCenterAccountResult_t1522738593), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3515 = { sizeof (LinkGoogleAccountRequest_t1583516147), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3515[2] = 
{
	LinkGoogleAccountRequest_t1583516147::get_offset_of_ForceLink_0(),
	LinkGoogleAccountRequest_t1583516147::get_offset_of_ServerAuthCode_1(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3516 = { sizeof (LinkGoogleAccountResult_t1807689001), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3517 = { sizeof (LinkIOSDeviceIDRequest_t732156087), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3517[4] = 
{
	LinkIOSDeviceIDRequest_t732156087::get_offset_of_DeviceId_0(),
	LinkIOSDeviceIDRequest_t732156087::get_offset_of_DeviceModel_1(),
	LinkIOSDeviceIDRequest_t732156087::get_offset_of_ForceLink_2(),
	LinkIOSDeviceIDRequest_t732156087::get_offset_of_OS_3(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3518 = { sizeof (LinkIOSDeviceIDResult_t3891870534), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3519 = { sizeof (LinkKongregateAccountRequest_t2767208911), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3519[3] = 
{
	LinkKongregateAccountRequest_t2767208911::get_offset_of_AuthTicket_0(),
	LinkKongregateAccountRequest_t2767208911::get_offset_of_ForceLink_1(),
	LinkKongregateAccountRequest_t2767208911::get_offset_of_KongregateId_2(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3520 = { sizeof (LinkKongregateAccountResult_t2275718960), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3521 = { sizeof (LinkSteamAccountRequest_t3315598358), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3521[2] = 
{
	LinkSteamAccountRequest_t3315598358::get_offset_of_ForceLink_0(),
	LinkSteamAccountRequest_t3315598358::get_offset_of_SteamTicket_1(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3522 = { sizeof (LinkSteamAccountResult_t2110373135), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3523 = { sizeof (LinkTwitchAccountRequest_t1241952066), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3523[2] = 
{
	LinkTwitchAccountRequest_t1241952066::get_offset_of_AccessToken_0(),
	LinkTwitchAccountRequest_t1241952066::get_offset_of_ForceLink_1(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3524 = { sizeof (LinkTwitchAccountResult_t4274966282), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3525 = { sizeof (LinkWindowsHelloAccountRequest_t2757452561), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3525[4] = 
{
	LinkWindowsHelloAccountRequest_t2757452561::get_offset_of_DeviceName_0(),
	LinkWindowsHelloAccountRequest_t2757452561::get_offset_of_ForceLink_1(),
	LinkWindowsHelloAccountRequest_t2757452561::get_offset_of_PublicKey_2(),
	LinkWindowsHelloAccountRequest_t2757452561::get_offset_of_UserName_3(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3526 = { sizeof (LinkWindowsHelloAccountResponse_t3319284420), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3527 = { sizeof (ListUsersCharactersRequest_t1477129616), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3527[1] = 
{
	ListUsersCharactersRequest_t1477129616::get_offset_of_PlayFabId_0(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3528 = { sizeof (ListUsersCharactersResult_t1440701948), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3528[1] = 
{
	ListUsersCharactersResult_t1440701948::get_offset_of_Characters_2(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3529 = { sizeof (LocationModel_t3813501936), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3529[5] = 
{
	LocationModel_t3813501936::get_offset_of_City_0(),
	LocationModel_t3813501936::get_offset_of_ContinentCode_1(),
	LocationModel_t3813501936::get_offset_of_CountryCode_2(),
	LocationModel_t3813501936::get_offset_of_Latitude_3(),
	LocationModel_t3813501936::get_offset_of_Longitude_4(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3530 = { sizeof (LoginIdentityProvider_t1880618185)+ sizeof (RuntimeObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable3530[15] = 
{
	LoginIdentityProvider_t1880618185::get_offset_of_value___1() + static_cast<int32_t>(sizeof(RuntimeObject)),
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3531 = { sizeof (LoginResult_t1741360290), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3531[7] = 
{
	LoginResult_t1741360290::get_offset_of_EntityToken_2(),
	LoginResult_t1741360290::get_offset_of_InfoResultPayload_3(),
	LoginResult_t1741360290::get_offset_of_LastLoginTime_4(),
	LoginResult_t1741360290::get_offset_of_NewlyCreated_5(),
	LoginResult_t1741360290::get_offset_of_PlayFabId_6(),
	LoginResult_t1741360290::get_offset_of_SessionTicket_7(),
	LoginResult_t1741360290::get_offset_of_SettingsForUser_8(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3532 = { sizeof (LoginWithAndroidDeviceIDRequest_t1269656532), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3532[9] = 
{
	LoginWithAndroidDeviceIDRequest_t1269656532::get_offset_of_AndroidDevice_0(),
	LoginWithAndroidDeviceIDRequest_t1269656532::get_offset_of_AndroidDeviceId_1(),
	LoginWithAndroidDeviceIDRequest_t1269656532::get_offset_of_CreateAccount_2(),
	LoginWithAndroidDeviceIDRequest_t1269656532::get_offset_of_EncryptedRequest_3(),
	LoginWithAndroidDeviceIDRequest_t1269656532::get_offset_of_InfoRequestParameters_4(),
	LoginWithAndroidDeviceIDRequest_t1269656532::get_offset_of_LoginTitlePlayerAccountEntity_5(),
	LoginWithAndroidDeviceIDRequest_t1269656532::get_offset_of_OS_6(),
	LoginWithAndroidDeviceIDRequest_t1269656532::get_offset_of_PlayerSecret_7(),
	LoginWithAndroidDeviceIDRequest_t1269656532::get_offset_of_TitleId_8(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3533 = { sizeof (LoginWithCustomIDRequest_t176841994), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3533[7] = 
{
	LoginWithCustomIDRequest_t176841994::get_offset_of_CreateAccount_0(),
	LoginWithCustomIDRequest_t176841994::get_offset_of_CustomId_1(),
	LoginWithCustomIDRequest_t176841994::get_offset_of_EncryptedRequest_2(),
	LoginWithCustomIDRequest_t176841994::get_offset_of_InfoRequestParameters_3(),
	LoginWithCustomIDRequest_t176841994::get_offset_of_LoginTitlePlayerAccountEntity_4(),
	LoginWithCustomIDRequest_t176841994::get_offset_of_PlayerSecret_5(),
	LoginWithCustomIDRequest_t176841994::get_offset_of_TitleId_6(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3534 = { sizeof (LoginWithEmailAddressRequest_t3424541161), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3534[5] = 
{
	LoginWithEmailAddressRequest_t3424541161::get_offset_of_Email_0(),
	LoginWithEmailAddressRequest_t3424541161::get_offset_of_InfoRequestParameters_1(),
	LoginWithEmailAddressRequest_t3424541161::get_offset_of_LoginTitlePlayerAccountEntity_2(),
	LoginWithEmailAddressRequest_t3424541161::get_offset_of_Password_3(),
	LoginWithEmailAddressRequest_t3424541161::get_offset_of_TitleId_4(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3535 = { sizeof (LoginWithFacebookRequest_t553021538), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3535[7] = 
{
	LoginWithFacebookRequest_t553021538::get_offset_of_AccessToken_0(),
	LoginWithFacebookRequest_t553021538::get_offset_of_CreateAccount_1(),
	LoginWithFacebookRequest_t553021538::get_offset_of_EncryptedRequest_2(),
	LoginWithFacebookRequest_t553021538::get_offset_of_InfoRequestParameters_3(),
	LoginWithFacebookRequest_t553021538::get_offset_of_LoginTitlePlayerAccountEntity_4(),
	LoginWithFacebookRequest_t553021538::get_offset_of_PlayerSecret_5(),
	LoginWithFacebookRequest_t553021538::get_offset_of_TitleId_6(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3536 = { sizeof (LoginWithGameCenterRequest_t195971591), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3536[7] = 
{
	LoginWithGameCenterRequest_t195971591::get_offset_of_CreateAccount_0(),
	LoginWithGameCenterRequest_t195971591::get_offset_of_EncryptedRequest_1(),
	LoginWithGameCenterRequest_t195971591::get_offset_of_InfoRequestParameters_2(),
	LoginWithGameCenterRequest_t195971591::get_offset_of_LoginTitlePlayerAccountEntity_3(),
	LoginWithGameCenterRequest_t195971591::get_offset_of_PlayerId_4(),
	LoginWithGameCenterRequest_t195971591::get_offset_of_PlayerSecret_5(),
	LoginWithGameCenterRequest_t195971591::get_offset_of_TitleId_6(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3537 = { sizeof (LoginWithGoogleAccountRequest_t513675687), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3537[7] = 
{
	LoginWithGoogleAccountRequest_t513675687::get_offset_of_CreateAccount_0(),
	LoginWithGoogleAccountRequest_t513675687::get_offset_of_EncryptedRequest_1(),
	LoginWithGoogleAccountRequest_t513675687::get_offset_of_InfoRequestParameters_2(),
	LoginWithGoogleAccountRequest_t513675687::get_offset_of_LoginTitlePlayerAccountEntity_3(),
	LoginWithGoogleAccountRequest_t513675687::get_offset_of_PlayerSecret_4(),
	LoginWithGoogleAccountRequest_t513675687::get_offset_of_ServerAuthCode_5(),
	LoginWithGoogleAccountRequest_t513675687::get_offset_of_TitleId_6(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3538 = { sizeof (LoginWithIOSDeviceIDRequest_t1104678395), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3538[9] = 
{
	LoginWithIOSDeviceIDRequest_t1104678395::get_offset_of_CreateAccount_0(),
	LoginWithIOSDeviceIDRequest_t1104678395::get_offset_of_DeviceId_1(),
	LoginWithIOSDeviceIDRequest_t1104678395::get_offset_of_DeviceModel_2(),
	LoginWithIOSDeviceIDRequest_t1104678395::get_offset_of_EncryptedRequest_3(),
	LoginWithIOSDeviceIDRequest_t1104678395::get_offset_of_InfoRequestParameters_4(),
	LoginWithIOSDeviceIDRequest_t1104678395::get_offset_of_LoginTitlePlayerAccountEntity_5(),
	LoginWithIOSDeviceIDRequest_t1104678395::get_offset_of_OS_6(),
	LoginWithIOSDeviceIDRequest_t1104678395::get_offset_of_PlayerSecret_7(),
	LoginWithIOSDeviceIDRequest_t1104678395::get_offset_of_TitleId_8(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3539 = { sizeof (LoginWithKongregateRequest_t2996684931), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3539[8] = 
{
	LoginWithKongregateRequest_t2996684931::get_offset_of_AuthTicket_0(),
	LoginWithKongregateRequest_t2996684931::get_offset_of_CreateAccount_1(),
	LoginWithKongregateRequest_t2996684931::get_offset_of_EncryptedRequest_2(),
	LoginWithKongregateRequest_t2996684931::get_offset_of_InfoRequestParameters_3(),
	LoginWithKongregateRequest_t2996684931::get_offset_of_KongregateId_4(),
	LoginWithKongregateRequest_t2996684931::get_offset_of_LoginTitlePlayerAccountEntity_5(),
	LoginWithKongregateRequest_t2996684931::get_offset_of_PlayerSecret_6(),
	LoginWithKongregateRequest_t2996684931::get_offset_of_TitleId_7(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3540 = { sizeof (LoginWithPlayFabRequest_t29234253), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3540[5] = 
{
	LoginWithPlayFabRequest_t29234253::get_offset_of_InfoRequestParameters_0(),
	LoginWithPlayFabRequest_t29234253::get_offset_of_LoginTitlePlayerAccountEntity_1(),
	LoginWithPlayFabRequest_t29234253::get_offset_of_Password_2(),
	LoginWithPlayFabRequest_t29234253::get_offset_of_TitleId_3(),
	LoginWithPlayFabRequest_t29234253::get_offset_of_Username_4(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3541 = { sizeof (LoginWithSteamRequest_t1168349975), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3541[7] = 
{
	LoginWithSteamRequest_t1168349975::get_offset_of_CreateAccount_0(),
	LoginWithSteamRequest_t1168349975::get_offset_of_EncryptedRequest_1(),
	LoginWithSteamRequest_t1168349975::get_offset_of_InfoRequestParameters_2(),
	LoginWithSteamRequest_t1168349975::get_offset_of_LoginTitlePlayerAccountEntity_3(),
	LoginWithSteamRequest_t1168349975::get_offset_of_PlayerSecret_4(),
	LoginWithSteamRequest_t1168349975::get_offset_of_SteamTicket_5(),
	LoginWithSteamRequest_t1168349975::get_offset_of_TitleId_6(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3542 = { sizeof (LoginWithTwitchRequest_t1822909188), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3542[7] = 
{
	LoginWithTwitchRequest_t1822909188::get_offset_of_AccessToken_0(),
	LoginWithTwitchRequest_t1822909188::get_offset_of_CreateAccount_1(),
	LoginWithTwitchRequest_t1822909188::get_offset_of_EncryptedRequest_2(),
	LoginWithTwitchRequest_t1822909188::get_offset_of_InfoRequestParameters_3(),
	LoginWithTwitchRequest_t1822909188::get_offset_of_LoginTitlePlayerAccountEntity_4(),
	LoginWithTwitchRequest_t1822909188::get_offset_of_PlayerSecret_5(),
	LoginWithTwitchRequest_t1822909188::get_offset_of_TitleId_6(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3543 = { sizeof (LoginWithWindowsHelloRequest_t725081759), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3543[5] = 
{
	LoginWithWindowsHelloRequest_t725081759::get_offset_of_ChallengeSignature_0(),
	LoginWithWindowsHelloRequest_t725081759::get_offset_of_InfoRequestParameters_1(),
	LoginWithWindowsHelloRequest_t725081759::get_offset_of_LoginTitlePlayerAccountEntity_2(),
	LoginWithWindowsHelloRequest_t725081759::get_offset_of_PublicKeyHint_3(),
	LoginWithWindowsHelloRequest_t725081759::get_offset_of_TitleId_4(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3544 = { sizeof (LogStatement_t3612334110), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3544[3] = 
{
	LogStatement_t3612334110::get_offset_of_Data_0(),
	LogStatement_t3612334110::get_offset_of_Level_1(),
	LogStatement_t3612334110::get_offset_of_Message_2(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3545 = { sizeof (MatchmakeRequest_t1739851507), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3545[8] = 
{
	MatchmakeRequest_t1739851507::get_offset_of_BuildVersion_0(),
	MatchmakeRequest_t1739851507::get_offset_of_CharacterId_1(),
	MatchmakeRequest_t1739851507::get_offset_of_GameMode_2(),
	MatchmakeRequest_t1739851507::get_offset_of_LobbyId_3(),
	MatchmakeRequest_t1739851507::get_offset_of_Region_4(),
	MatchmakeRequest_t1739851507::get_offset_of_StartNewIfNoneFound_5(),
	MatchmakeRequest_t1739851507::get_offset_of_StatisticName_6(),
	MatchmakeRequest_t1739851507::get_offset_of_TagFilter_7(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3546 = { sizeof (MatchmakeResult_t2030730580), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3546[8] = 
{
	MatchmakeResult_t2030730580::get_offset_of_Expires_2(),
	MatchmakeResult_t2030730580::get_offset_of_LobbyID_3(),
	MatchmakeResult_t2030730580::get_offset_of_PollWaitTimeMS_4(),
	MatchmakeResult_t2030730580::get_offset_of_ServerHostname_5(),
	MatchmakeResult_t2030730580::get_offset_of_ServerIPV6Address_6(),
	MatchmakeResult_t2030730580::get_offset_of_ServerPort_7(),
	MatchmakeResult_t2030730580::get_offset_of_Status_8(),
	MatchmakeResult_t2030730580::get_offset_of_Ticket_9(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3547 = { sizeof (MatchmakeStatus_t1217147204)+ sizeof (RuntimeObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable3547[6] = 
{
	MatchmakeStatus_t1217147204::get_offset_of_value___1() + static_cast<int32_t>(sizeof(RuntimeObject)),
	0,
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3548 = { sizeof (MembershipModel_t1372399326), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3548[5] = 
{
	MembershipModel_t1372399326::get_offset_of_IsActive_0(),
	MembershipModel_t1372399326::get_offset_of_MembershipExpiration_1(),
	MembershipModel_t1372399326::get_offset_of_MembershipId_2(),
	MembershipModel_t1372399326::get_offset_of_OverrideExpiration_3(),
	MembershipModel_t1372399326::get_offset_of_Subscriptions_4(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3549 = { sizeof (ModifyUserVirtualCurrencyResult_t2341190276), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3549[4] = 
{
	ModifyUserVirtualCurrencyResult_t2341190276::get_offset_of_Balance_2(),
	ModifyUserVirtualCurrencyResult_t2341190276::get_offset_of_BalanceChange_3(),
	ModifyUserVirtualCurrencyResult_t2341190276::get_offset_of_PlayFabId_4(),
	ModifyUserVirtualCurrencyResult_t2341190276::get_offset_of_VirtualCurrency_5(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3550 = { sizeof (NameIdentifier_t1683639553), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3550[2] = 
{
	NameIdentifier_t1683639553::get_offset_of_Id_0(),
	NameIdentifier_t1683639553::get_offset_of_Name_1(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3551 = { sizeof (OpenTradeRequest_t11547462), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3551[3] = 
{
	OpenTradeRequest_t11547462::get_offset_of_AllowedPlayerIds_0(),
	OpenTradeRequest_t11547462::get_offset_of_OfferedInventoryInstanceIds_1(),
	OpenTradeRequest_t11547462::get_offset_of_RequestedCatalogItemIds_2(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3552 = { sizeof (OpenTradeResponse_t2601250367), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3552[1] = 
{
	OpenTradeResponse_t2601250367::get_offset_of_Trade_2(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3553 = { sizeof (PayForPurchaseRequest_t2615822629), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3553[4] = 
{
	PayForPurchaseRequest_t2615822629::get_offset_of_Currency_0(),
	PayForPurchaseRequest_t2615822629::get_offset_of_OrderId_1(),
	PayForPurchaseRequest_t2615822629::get_offset_of_ProviderName_2(),
	PayForPurchaseRequest_t2615822629::get_offset_of_ProviderTransactionId_3(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3554 = { sizeof (PayForPurchaseResult_t2186103076), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3554[10] = 
{
	PayForPurchaseResult_t2186103076::get_offset_of_CreditApplied_2(),
	PayForPurchaseResult_t2186103076::get_offset_of_OrderId_3(),
	PayForPurchaseResult_t2186103076::get_offset_of_ProviderData_4(),
	PayForPurchaseResult_t2186103076::get_offset_of_ProviderToken_5(),
	PayForPurchaseResult_t2186103076::get_offset_of_PurchaseConfirmationPageURL_6(),
	PayForPurchaseResult_t2186103076::get_offset_of_PurchaseCurrency_7(),
	PayForPurchaseResult_t2186103076::get_offset_of_PurchasePrice_8(),
	PayForPurchaseResult_t2186103076::get_offset_of_Status_9(),
	PayForPurchaseResult_t2186103076::get_offset_of_VCAmount_10(),
	PayForPurchaseResult_t2186103076::get_offset_of_VirtualCurrency_11(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3555 = { sizeof (PaymentOption_t949298389), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3555[4] = 
{
	PaymentOption_t949298389::get_offset_of_Currency_0(),
	PaymentOption_t949298389::get_offset_of_Price_1(),
	PaymentOption_t949298389::get_offset_of_ProviderName_2(),
	PaymentOption_t949298389::get_offset_of_StoreCredit_3(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3556 = { sizeof (PlayerLeaderboardEntry_t1881677957), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3556[5] = 
{
	PlayerLeaderboardEntry_t1881677957::get_offset_of_DisplayName_0(),
	PlayerLeaderboardEntry_t1881677957::get_offset_of_PlayFabId_1(),
	PlayerLeaderboardEntry_t1881677957::get_offset_of_Position_2(),
	PlayerLeaderboardEntry_t1881677957::get_offset_of_Profile_3(),
	PlayerLeaderboardEntry_t1881677957::get_offset_of_StatValue_4(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3557 = { sizeof (PlayerProfileModel_t250934598), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3557[19] = 
{
	PlayerProfileModel_t250934598::get_offset_of_AdCampaignAttributions_0(),
	PlayerProfileModel_t250934598::get_offset_of_AvatarUrl_1(),
	PlayerProfileModel_t250934598::get_offset_of_BannedUntil_2(),
	PlayerProfileModel_t250934598::get_offset_of_ContactEmailAddresses_3(),
	PlayerProfileModel_t250934598::get_offset_of_Created_4(),
	PlayerProfileModel_t250934598::get_offset_of_DisplayName_5(),
	PlayerProfileModel_t250934598::get_offset_of_LastLogin_6(),
	PlayerProfileModel_t250934598::get_offset_of_LinkedAccounts_7(),
	PlayerProfileModel_t250934598::get_offset_of_Locations_8(),
	PlayerProfileModel_t250934598::get_offset_of_Memberships_9(),
	PlayerProfileModel_t250934598::get_offset_of_Origination_10(),
	PlayerProfileModel_t250934598::get_offset_of_PlayerId_11(),
	PlayerProfileModel_t250934598::get_offset_of_PublisherId_12(),
	PlayerProfileModel_t250934598::get_offset_of_PushNotificationRegistrations_13(),
	PlayerProfileModel_t250934598::get_offset_of_Statistics_14(),
	PlayerProfileModel_t250934598::get_offset_of_Tags_15(),
	PlayerProfileModel_t250934598::get_offset_of_TitleId_16(),
	PlayerProfileModel_t250934598::get_offset_of_TotalValueToDateInUSD_17(),
	PlayerProfileModel_t250934598::get_offset_of_ValuesToDate_18(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3558 = { sizeof (PlayerProfileViewConstraints_t97717017), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3558[16] = 
{
	PlayerProfileViewConstraints_t97717017::get_offset_of_ShowAvatarUrl_0(),
	PlayerProfileViewConstraints_t97717017::get_offset_of_ShowBannedUntil_1(),
	PlayerProfileViewConstraints_t97717017::get_offset_of_ShowCampaignAttributions_2(),
	PlayerProfileViewConstraints_t97717017::get_offset_of_ShowContactEmailAddresses_3(),
	PlayerProfileViewConstraints_t97717017::get_offset_of_ShowCreated_4(),
	PlayerProfileViewConstraints_t97717017::get_offset_of_ShowDisplayName_5(),
	PlayerProfileViewConstraints_t97717017::get_offset_of_ShowLastLogin_6(),
	PlayerProfileViewConstraints_t97717017::get_offset_of_ShowLinkedAccounts_7(),
	PlayerProfileViewConstraints_t97717017::get_offset_of_ShowLocations_8(),
	PlayerProfileViewConstraints_t97717017::get_offset_of_ShowMemberships_9(),
	PlayerProfileViewConstraints_t97717017::get_offset_of_ShowOrigination_10(),
	PlayerProfileViewConstraints_t97717017::get_offset_of_ShowPushNotificationRegistrations_11(),
	PlayerProfileViewConstraints_t97717017::get_offset_of_ShowStatistics_12(),
	PlayerProfileViewConstraints_t97717017::get_offset_of_ShowTags_13(),
	PlayerProfileViewConstraints_t97717017::get_offset_of_ShowTotalValueToDateInUsd_14(),
	PlayerProfileViewConstraints_t97717017::get_offset_of_ShowValuesToDate_15(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3559 = { sizeof (PlayerStatisticVersion_t2730724419), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3559[6] = 
{
	PlayerStatisticVersion_t2730724419::get_offset_of_ActivationTime_0(),
	PlayerStatisticVersion_t2730724419::get_offset_of_DeactivationTime_1(),
	PlayerStatisticVersion_t2730724419::get_offset_of_ScheduledActivationTime_2(),
	PlayerStatisticVersion_t2730724419::get_offset_of_ScheduledDeactivationTime_3(),
	PlayerStatisticVersion_t2730724419::get_offset_of_StatisticName_4(),
	PlayerStatisticVersion_t2730724419::get_offset_of_Version_5(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3560 = { sizeof (PurchaseItemRequest_t446597288), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3560[6] = 
{
	PurchaseItemRequest_t446597288::get_offset_of_CatalogVersion_0(),
	PurchaseItemRequest_t446597288::get_offset_of_CharacterId_1(),
	PurchaseItemRequest_t446597288::get_offset_of_ItemId_2(),
	PurchaseItemRequest_t446597288::get_offset_of_Price_3(),
	PurchaseItemRequest_t446597288::get_offset_of_StoreId_4(),
	PurchaseItemRequest_t446597288::get_offset_of_VirtualCurrency_5(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3561 = { sizeof (PurchaseItemResult_t1722243179), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3561[1] = 
{
	PurchaseItemResult_t1722243179::get_offset_of_Items_2(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3562 = { sizeof (PushNotificationPlatform_t675897761)+ sizeof (RuntimeObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable3562[3] = 
{
	PushNotificationPlatform_t675897761::get_offset_of_value___1() + static_cast<int32_t>(sizeof(RuntimeObject)),
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3563 = { sizeof (PushNotificationRegistrationModel_t1403388172), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3563[2] = 
{
	PushNotificationRegistrationModel_t1403388172::get_offset_of_NotificationEndpointARN_0(),
	PushNotificationRegistrationModel_t1403388172::get_offset_of_Platform_1(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3564 = { sizeof (RedeemCouponRequest_t236242173), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3564[3] = 
{
	RedeemCouponRequest_t236242173::get_offset_of_CatalogVersion_0(),
	RedeemCouponRequest_t236242173::get_offset_of_CharacterId_1(),
	RedeemCouponRequest_t236242173::get_offset_of_CouponCode_2(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3565 = { sizeof (RedeemCouponResult_t4207086596), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3565[1] = 
{
	RedeemCouponResult_t4207086596::get_offset_of_GrantedItems_2(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3566 = { sizeof (Region_t4198023226)+ sizeof (RuntimeObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable3566[8] = 
{
	Region_t4198023226::get_offset_of_value___1() + static_cast<int32_t>(sizeof(RuntimeObject)),
	0,
	0,
	0,
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3567 = { sizeof (RegionInfo_t1716013666), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3567[4] = 
{
	RegionInfo_t1716013666::get_offset_of_Available_0(),
	RegionInfo_t1716013666::get_offset_of_Name_1(),
	RegionInfo_t1716013666::get_offset_of_PingUrl_2(),
	RegionInfo_t1716013666::get_offset_of_Region_3(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3568 = { sizeof (RegisterForIOSPushNotificationRequest_t3055742779), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3568[3] = 
{
	RegisterForIOSPushNotificationRequest_t3055742779::get_offset_of_ConfirmationMessage_0(),
	RegisterForIOSPushNotificationRequest_t3055742779::get_offset_of_DeviceToken_1(),
	RegisterForIOSPushNotificationRequest_t3055742779::get_offset_of_SendPushNotificationConfirmation_2(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3569 = { sizeof (RegisterForIOSPushNotificationResult_t2256269114), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3570 = { sizeof (RegisterPlayFabUserRequest_t413887218), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3570[10] = 
{
	RegisterPlayFabUserRequest_t413887218::get_offset_of_DisplayName_0(),
	RegisterPlayFabUserRequest_t413887218::get_offset_of_Email_1(),
	RegisterPlayFabUserRequest_t413887218::get_offset_of_EncryptedRequest_2(),
	RegisterPlayFabUserRequest_t413887218::get_offset_of_InfoRequestParameters_3(),
	RegisterPlayFabUserRequest_t413887218::get_offset_of_LoginTitlePlayerAccountEntity_4(),
	RegisterPlayFabUserRequest_t413887218::get_offset_of_Password_5(),
	RegisterPlayFabUserRequest_t413887218::get_offset_of_PlayerSecret_6(),
	RegisterPlayFabUserRequest_t413887218::get_offset_of_RequireBothUsernameAndEmail_7(),
	RegisterPlayFabUserRequest_t413887218::get_offset_of_TitleId_8(),
	RegisterPlayFabUserRequest_t413887218::get_offset_of_Username_9(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3571 = { sizeof (RegisterPlayFabUserResult_t802479880), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3571[4] = 
{
	RegisterPlayFabUserResult_t802479880::get_offset_of_PlayFabId_2(),
	RegisterPlayFabUserResult_t802479880::get_offset_of_SessionTicket_3(),
	RegisterPlayFabUserResult_t802479880::get_offset_of_SettingsForUser_4(),
	RegisterPlayFabUserResult_t802479880::get_offset_of_Username_5(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3572 = { sizeof (RegisterWithWindowsHelloRequest_t1629448663), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3572[8] = 
{
	RegisterWithWindowsHelloRequest_t1629448663::get_offset_of_DeviceName_0(),
	RegisterWithWindowsHelloRequest_t1629448663::get_offset_of_EncryptedRequest_1(),
	RegisterWithWindowsHelloRequest_t1629448663::get_offset_of_InfoRequestParameters_2(),
	RegisterWithWindowsHelloRequest_t1629448663::get_offset_of_LoginTitlePlayerAccountEntity_3(),
	RegisterWithWindowsHelloRequest_t1629448663::get_offset_of_PlayerSecret_4(),
	RegisterWithWindowsHelloRequest_t1629448663::get_offset_of_PublicKey_5(),
	RegisterWithWindowsHelloRequest_t1629448663::get_offset_of_TitleId_6(),
	RegisterWithWindowsHelloRequest_t1629448663::get_offset_of_UserName_7(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3573 = { sizeof (RemoveContactEmailRequest_t1252854948), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3574 = { sizeof (RemoveContactEmailResult_t1684933791), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3575 = { sizeof (RemoveFriendRequest_t4181183992), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3575[1] = 
{
	RemoveFriendRequest_t4181183992::get_offset_of_FriendPlayFabId_0(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3576 = { sizeof (RemoveFriendResult_t1519141523), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3577 = { sizeof (RemoveGenericIDRequest_t1674395511), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3577[1] = 
{
	RemoveGenericIDRequest_t1674395511::get_offset_of_GenericId_0(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3578 = { sizeof (RemoveGenericIDResult_t3234682150), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3579 = { sizeof (RemoveSharedGroupMembersRequest_t3650533269), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3579[2] = 
{
	RemoveSharedGroupMembersRequest_t3650533269::get_offset_of_PlayFabIds_0(),
	RemoveSharedGroupMembersRequest_t3650533269::get_offset_of_SharedGroupId_1(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3580 = { sizeof (RemoveSharedGroupMembersResult_t1660437242), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3581 = { sizeof (ReportPlayerClientRequest_t2988748114), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3581[2] = 
{
	ReportPlayerClientRequest_t2988748114::get_offset_of_Comment_0(),
	ReportPlayerClientRequest_t2988748114::get_offset_of_ReporteeId_1(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3582 = { sizeof (ReportPlayerClientResult_t3799493971), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3582[1] = 
{
	ReportPlayerClientResult_t3799493971::get_offset_of_SubmissionsRemaining_2(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3583 = { sizeof (RestoreIOSPurchasesRequest_t2021516304), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3583[1] = 
{
	RestoreIOSPurchasesRequest_t2021516304::get_offset_of_ReceiptData_0(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3584 = { sizeof (RestoreIOSPurchasesResult_t2500978621), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3585 = { sizeof (ScriptExecutionError_t3998229139), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3585[3] = 
{
	ScriptExecutionError_t3998229139::get_offset_of_Error_0(),
	ScriptExecutionError_t3998229139::get_offset_of_Message_1(),
	ScriptExecutionError_t3998229139::get_offset_of_StackTrace_2(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3586 = { sizeof (SendAccountRecoveryEmailRequest_t3630781634), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3586[3] = 
{
	SendAccountRecoveryEmailRequest_t3630781634::get_offset_of_Email_0(),
	SendAccountRecoveryEmailRequest_t3630781634::get_offset_of_EmailTemplateId_1(),
	SendAccountRecoveryEmailRequest_t3630781634::get_offset_of_TitleId_2(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3587 = { sizeof (SendAccountRecoveryEmailResult_t550548115), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3588 = { sizeof (SetFriendTagsRequest_t2241574297), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3588[2] = 
{
	SetFriendTagsRequest_t2241574297::get_offset_of_FriendPlayFabId_0(),
	SetFriendTagsRequest_t2241574297::get_offset_of_Tags_1(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3589 = { sizeof (SetFriendTagsResult_t4002085899), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3590 = { sizeof (SetPlayerSecretRequest_t226361414), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3590[2] = 
{
	SetPlayerSecretRequest_t226361414::get_offset_of_EncryptedRequest_0(),
	SetPlayerSecretRequest_t226361414::get_offset_of_PlayerSecret_1(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3591 = { sizeof (SetPlayerSecretResult_t1859896565), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3592 = { sizeof (SharedGroupDataRecord_t1581922388), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3592[4] = 
{
	SharedGroupDataRecord_t1581922388::get_offset_of_LastUpdated_0(),
	SharedGroupDataRecord_t1581922388::get_offset_of_LastUpdatedBy_1(),
	SharedGroupDataRecord_t1581922388::get_offset_of_Permission_2(),
	SharedGroupDataRecord_t1581922388::get_offset_of_Value_3(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3593 = { sizeof (SourceType_t2721852859)+ sizeof (RuntimeObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable3593[6] = 
{
	SourceType_t2721852859::get_offset_of_value___1() + static_cast<int32_t>(sizeof(RuntimeObject)),
	0,
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3594 = { sizeof (StartGameRequest_t3072561728), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3594[6] = 
{
	StartGameRequest_t3072561728::get_offset_of_BuildVersion_0(),
	StartGameRequest_t3072561728::get_offset_of_CharacterId_1(),
	StartGameRequest_t3072561728::get_offset_of_CustomCommandLineData_2(),
	StartGameRequest_t3072561728::get_offset_of_GameMode_3(),
	StartGameRequest_t3072561728::get_offset_of_Region_4(),
	StartGameRequest_t3072561728::get_offset_of_StatisticName_5(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3595 = { sizeof (StartGameResult_t3332222724), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3595[7] = 
{
	StartGameResult_t3332222724::get_offset_of_Expires_2(),
	StartGameResult_t3332222724::get_offset_of_LobbyID_3(),
	StartGameResult_t3332222724::get_offset_of_Password_4(),
	StartGameResult_t3332222724::get_offset_of_ServerHostname_5(),
	StartGameResult_t3332222724::get_offset_of_ServerIPV6Address_6(),
	StartGameResult_t3332222724::get_offset_of_ServerPort_7(),
	StartGameResult_t3332222724::get_offset_of_Ticket_8(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3596 = { sizeof (StartPurchaseRequest_t1560898140), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3596[3] = 
{
	StartPurchaseRequest_t1560898140::get_offset_of_CatalogVersion_0(),
	StartPurchaseRequest_t1560898140::get_offset_of_Items_1(),
	StartPurchaseRequest_t1560898140::get_offset_of_StoreId_2(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3597 = { sizeof (StartPurchaseResult_t322616865), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3597[4] = 
{
	StartPurchaseResult_t322616865::get_offset_of_Contents_2(),
	StartPurchaseResult_t322616865::get_offset_of_OrderId_3(),
	StartPurchaseResult_t322616865::get_offset_of_PaymentOptions_4(),
	StartPurchaseResult_t322616865::get_offset_of_VirtualCurrencyBalances_5(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3598 = { sizeof (StatisticModel_t598410627), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3598[3] = 
{
	StatisticModel_t598410627::get_offset_of_Name_0(),
	StatisticModel_t598410627::get_offset_of_Value_1(),
	StatisticModel_t598410627::get_offset_of_Version_2(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize3599 = { sizeof (StatisticNameVersion_t4077247347), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable3599[2] = 
{
	StatisticNameVersion_t4077247347::get_offset_of_StatisticName_0(),
	StatisticNameVersion_t4077247347::get_offset_of_Version_1(),
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif
