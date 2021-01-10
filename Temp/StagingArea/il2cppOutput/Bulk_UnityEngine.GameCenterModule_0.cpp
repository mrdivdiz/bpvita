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

template <typename R>
struct InterfaceFuncInvoker0
{
	typedef R (*Func)(void*, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		return ((Func)invokeData.methodPtr)(obj, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3>
struct InterfaceActionInvoker3
{
	typedef void (*Action)(void*, T1, T2, T3, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1, T2 p2, T3 p3)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, invokeData.method);
	}
};
template <typename T1>
struct InterfaceActionInvoker1
{
	typedef void (*Action)(void*, T1, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
struct InterfaceActionInvoker0
{
	typedef void (*Action)(void*, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, invokeData.method);
	}
};
template <typename T1, typename T2>
struct InterfaceActionInvoker2
{
	typedef void (*Action)(void*, T1, T2, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1, T2 p2)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, p1, p2, invokeData.method);
	}
};

// UnityEngine.SocialPlatforms.ISocialPlatform
struct ISocialPlatform_t2920057433;
// UnityEngine.SocialPlatforms.ILocalUser
struct ILocalUser_t2242999785;
// System.String
struct String_t;
// System.Action`1<System.Boolean>
struct Action_1_t269755560;
// System.Action`1<UnityEngine.SocialPlatforms.IAchievementDescription[]>
struct Action_1_t1994432444;
// System.Action`1<UnityEngine.SocialPlatforms.IAchievement[]>
struct Action_1_t2064805934;
// UnityEngine.SocialPlatforms.ILeaderboard
struct ILeaderboard_t3934877283;
// UnityEngine.SocialPlatforms.Local
struct Local_t4068483442;
// UnityEngine.SocialPlatforms.Impl.Achievement
struct Achievement_t565359984;
// System.Object[]
struct ObjectU5BU5D_t2843939325;
// UnityEngine.SocialPlatforms.Impl.AchievementDescription
struct AchievementDescription_t3217594527;
// UnityEngine.Texture2D
struct Texture2D_t3840446185;
// UnityEngine.SocialPlatforms.Impl.Leaderboard
struct Leaderboard_t1065076763;
// UnityEngine.SocialPlatforms.Impl.Score
struct Score_t1968645328;
// UnityEngine.SocialPlatforms.IScore
struct IScore_t2559910621;
// UnityEngine.SocialPlatforms.IScore[]
struct IScoreU5BU5D_t527871248;
// UnityEngine.SocialPlatforms.Impl.LocalUser
struct LocalUser_t365094499;
// UnityEngine.SocialPlatforms.Impl.UserProfile
struct UserProfile_t3137328177;
// UnityEngine.SocialPlatforms.IUserProfile
struct IUserProfile_t360500636;
// System.Collections.Generic.List`1<UnityEngine.SocialPlatforms.Impl.UserProfile>
struct List_1_t314435623;
// System.Collections.Generic.List`1<System.Object>
struct List_1_t257213610;
// System.Collections.Generic.List`1<UnityEngine.SocialPlatforms.Impl.AchievementDescription>
struct List_1_t394701973;
// System.Collections.Generic.List`1<UnityEngine.SocialPlatforms.Impl.Achievement>
struct List_1_t2037434726;
// System.Collections.Generic.List`1<UnityEngine.SocialPlatforms.Impl.Leaderboard>
struct List_1_t2537151505;
// UnityEngine.SocialPlatforms.Impl.AchievementDescription[]
struct AchievementDescriptionU5BU5D_t1886727686;
// UnityEngine.SocialPlatforms.IAchievementDescription[]
struct IAchievementDescriptionU5BU5D_t1821964849;
// System.Action`1<System.Object>
struct Action_1_t3252573759;
// UnityEngine.SocialPlatforms.IAchievementDescription
struct IAchievementDescription_t2514275728;
// UnityEngine.SocialPlatforms.Impl.Achievement[]
struct AchievementU5BU5D_t1511134929;
// UnityEngine.SocialPlatforms.IAchievement[]
struct IAchievementU5BU5D_t1892338339;
// UnityEngine.SocialPlatforms.IAchievement
struct IAchievement_t1421108358;
// System.Collections.Generic.List`1<UnityEngine.SocialPlatforms.Impl.Score>
struct List_1_t3440720070;
// System.Collections.Generic.IEnumerable`1<UnityEngine.SocialPlatforms.Impl.Score>
struct IEnumerable_1_t948498217;
// System.Collections.Generic.IEnumerable`1<System.Object>
struct IEnumerable_1_t2059959053;
// UnityEngine.SocialPlatforms.Impl.Score[]
struct ScoreU5BU5D_t972561905;
// System.Comparison`1<UnityEngine.SocialPlatforms.Impl.Score>
struct Comparison_1_t1743576507;
// System.Comparison`1<System.Object>
struct Comparison_1_t2855037343;
// UnityEngine.SocialPlatforms.Impl.Leaderboard[]
struct LeaderboardU5BU5D_t31671578;
// UnityEngine.SocialPlatforms.Impl.UserProfile[]
struct UserProfileU5BU5D_t1895532524;
// System.Char[]
struct CharU5BU5D_t3528271667;
// System.Void
struct Void_t1185182177;
// System.Reflection.MethodInfo
struct MethodInfo_t;
// System.DelegateData
struct DelegateData_t1677132599;
// System.String[]
struct StringU5BU5D_t1281789340;
// System.Int32[]
struct Int32U5BU5D_t385246372;
// System.IAsyncResult
struct IAsyncResult_t767004451;
// System.AsyncCallback
struct AsyncCallback_t3962456242;
// UnityEngine.SocialPlatforms.IUserProfile[]
struct IUserProfileU5BU5D_t909679733;

extern RuntimeClass* ISocialPlatform_t2920057433_il2cpp_TypeInfo_var;
extern const uint32_t Social_get_localUser_m4215544813_MetadataUsageId;
extern const uint32_t Social_ReportProgress_m2978360853_MetadataUsageId;
extern const uint32_t Social_LoadAchievementDescriptions_m1775235550_MetadataUsageId;
extern const uint32_t Social_LoadAchievements_m899928901_MetadataUsageId;
extern const uint32_t Social_ReportScore_m356549569_MetadataUsageId;
extern const uint32_t Social_CreateLeaderboard_m1170049904_MetadataUsageId;
extern const uint32_t Social_ShowAchievementsUI_m450595073_MetadataUsageId;
extern const uint32_t Social_ShowLeaderboardUI_m369452130_MetadataUsageId;
extern RuntimeClass* ActivePlatform_t3103617690_il2cpp_TypeInfo_var;
extern const uint32_t ActivePlatform_get_Instance_m3727118555_MetadataUsageId;
extern RuntimeClass* Local_t4068483442_il2cpp_TypeInfo_var;
extern const uint32_t ActivePlatform_SelectSocialPlatform_m1059707725_MetadataUsageId;
extern RuntimeClass* ObjectU5BU5D_t2843939325_il2cpp_TypeInfo_var;
extern RuntimeClass* Double_t594665363_il2cpp_TypeInfo_var;
extern RuntimeClass* Boolean_t97287965_il2cpp_TypeInfo_var;
extern RuntimeClass* DateTime_t3738529785_il2cpp_TypeInfo_var;
extern RuntimeClass* String_t_il2cpp_TypeInfo_var;
extern String_t* _stringLiteral3786252490;
extern const uint32_t Achievement_ToString_m3521250266_MetadataUsageId;
extern RuntimeClass* Int32_t2950945753_il2cpp_TypeInfo_var;
extern const uint32_t AchievementDescription_ToString_m2063334390_MetadataUsageId;
extern RuntimeClass* Score_t1968645328_il2cpp_TypeInfo_var;
extern RuntimeClass* ScoreU5BU5D_t972561905_il2cpp_TypeInfo_var;
extern RuntimeClass* StringU5BU5D_t1281789340_il2cpp_TypeInfo_var;
extern String_t* _stringLiteral2065339255;
extern const uint32_t Leaderboard__ctor_m1030108446_MetadataUsageId;
extern RuntimeClass* UInt32_t2560061978_il2cpp_TypeInfo_var;
extern RuntimeClass* UserScope_t604006431_il2cpp_TypeInfo_var;
extern RuntimeClass* TimeScope_t539351503_il2cpp_TypeInfo_var;
extern String_t* _stringLiteral930699636;
extern String_t* _stringLiteral2979315402;
extern String_t* _stringLiteral1695920045;
extern String_t* _stringLiteral1702585322;
extern String_t* _stringLiteral3452614532;
extern String_t* _stringLiteral3449030883;
extern String_t* _stringLiteral1177415910;
extern String_t* _stringLiteral1358844784;
extern String_t* _stringLiteral1488170903;
extern String_t* _stringLiteral933325165;
extern const uint32_t Leaderboard_ToString_m1544604165_MetadataUsageId;
extern const uint32_t Leaderboard_LoadScores_m2671749416_MetadataUsageId;
extern RuntimeClass* UserProfileU5BU5D_t1895532524_il2cpp_TypeInfo_var;
extern const uint32_t LocalUser__ctor_m4260307073_MetadataUsageId;
extern const uint32_t LocalUser_Authenticate_m2136646640_MetadataUsageId;
extern String_t* _stringLiteral3452614544;
extern String_t* _stringLiteral757602046;
extern const uint32_t Score__ctor_m2390363112_MetadataUsageId;
extern RuntimeClass* Int64_t3736567304_il2cpp_TypeInfo_var;
extern String_t* _stringLiteral2608391305;
extern String_t* _stringLiteral1464936688;
extern String_t* _stringLiteral3818843126;
extern String_t* _stringLiteral2823322644;
extern String_t* _stringLiteral4281704856;
extern const uint32_t Score_ToString_m885507283_MetadataUsageId;
extern RuntimeClass* Texture2D_t3840446185_il2cpp_TypeInfo_var;
extern String_t* _stringLiteral3725686153;
extern const uint32_t UserProfile__ctor_m3353918255_MetadataUsageId;
extern RuntimeClass* UserState_t4177058321_il2cpp_TypeInfo_var;
extern const uint32_t UserProfile_ToString_m2232825484_MetadataUsageId;
extern RuntimeClass* List_1_t314435623_il2cpp_TypeInfo_var;
extern RuntimeClass* List_1_t394701973_il2cpp_TypeInfo_var;
extern RuntimeClass* List_1_t2037434726_il2cpp_TypeInfo_var;
extern RuntimeClass* List_1_t2537151505_il2cpp_TypeInfo_var;
extern const RuntimeMethod* List_1__ctor_m973695318_RuntimeMethod_var;
extern const RuntimeMethod* List_1__ctor_m3689826338_RuntimeMethod_var;
extern const RuntimeMethod* List_1__ctor_m1836006746_RuntimeMethod_var;
extern const RuntimeMethod* List_1__ctor_m1889483756_RuntimeMethod_var;
extern const uint32_t Local__ctor_m3461781796_MetadataUsageId;
extern RuntimeClass* LocalUser_t365094499_il2cpp_TypeInfo_var;
extern const uint32_t Local_get_localUser_m1583274769_MetadataUsageId;
extern const RuntimeMethod* Action_1_Invoke_m1933767679_RuntimeMethod_var;
extern String_t* _stringLiteral15947561;
extern String_t* _stringLiteral774297412;
extern const uint32_t Local_UnityEngine_SocialPlatforms_ISocialPlatform_Authenticate_m2207258125_MetadataUsageId;
extern RuntimeClass* Achievement_t565359984_il2cpp_TypeInfo_var;
extern RuntimeClass* Debug_t3317548046_il2cpp_TypeInfo_var;
extern const RuntimeMethod* List_1_GetEnumerator_m2680008813_RuntimeMethod_var;
extern const RuntimeMethod* Enumerator_get_Current_m2947874382_RuntimeMethod_var;
extern const RuntimeMethod* Enumerator_MoveNext_m2057277239_RuntimeMethod_var;
extern const RuntimeMethod* Enumerator_Dispose_m3795629826_RuntimeMethod_var;
extern const RuntimeMethod* List_1_GetEnumerator_m3287167671_RuntimeMethod_var;
extern const RuntimeMethod* Enumerator_get_Current_m578560357_RuntimeMethod_var;
extern const RuntimeMethod* List_1_Add_m4026348786_RuntimeMethod_var;
extern const RuntimeMethod* Enumerator_MoveNext_m1380577720_RuntimeMethod_var;
extern const RuntimeMethod* Enumerator_Dispose_m228566194_RuntimeMethod_var;
extern String_t* _stringLiteral2915405358;
extern const uint32_t Local_ReportProgress_m2862776241_MetadataUsageId;
extern const RuntimeMethod* List_1_ToArray_m3141863218_RuntimeMethod_var;
extern const RuntimeMethod* Action_1_Invoke_m1979208465_RuntimeMethod_var;
extern const uint32_t Local_LoadAchievementDescriptions_m3080409102_MetadataUsageId;
extern const RuntimeMethod* List_1_ToArray_m4122937214_RuntimeMethod_var;
extern const RuntimeMethod* Action_1_Invoke_m24007936_RuntimeMethod_var;
extern const uint32_t Local_LoadAchievements_m2951224182_MetadataUsageId;
extern RuntimeClass* List_1_t3440720070_il2cpp_TypeInfo_var;
extern RuntimeClass* IUserProfile_t360500636_il2cpp_TypeInfo_var;
extern const RuntimeMethod* List_1_GetEnumerator_m3274601223_RuntimeMethod_var;
extern const RuntimeMethod* Enumerator_get_Current_m1590304878_RuntimeMethod_var;
extern const RuntimeMethod* List_1__ctor_m176386895_RuntimeMethod_var;
extern const RuntimeMethod* List_1_Add_m1702244787_RuntimeMethod_var;
extern const RuntimeMethod* List_1_ToArray_m2845752048_RuntimeMethod_var;
extern const RuntimeMethod* Enumerator_MoveNext_m3184043996_RuntimeMethod_var;
extern const RuntimeMethod* Enumerator_Dispose_m1743516632_RuntimeMethod_var;
extern String_t* _stringLiteral3751832596;
extern String_t* _stringLiteral44010168;
extern const uint32_t Local_ReportScore_m128146884_MetadataUsageId;
extern RuntimeClass* Leaderboard_t1065076763_il2cpp_TypeInfo_var;
extern const uint32_t Local_UnityEngine_SocialPlatforms_ISocialPlatform_LoadScores_m1678696798_MetadataUsageId;
extern RuntimeClass* Comparison_1_t1743576507_il2cpp_TypeInfo_var;
extern const RuntimeMethod* Local_U3CSortScoresU3Em__0_m2862368374_RuntimeMethod_var;
extern const RuntimeMethod* Comparison_1__ctor_m2373250861_RuntimeMethod_var;
extern const RuntimeMethod* List_1_Sort_m1667366135_RuntimeMethod_var;
extern const RuntimeMethod* List_1_get_Item_m3843832117_RuntimeMethod_var;
extern const RuntimeMethod* List_1_get_Count_m1172671670_RuntimeMethod_var;
extern const uint32_t Local_SortScores_m3988362938_MetadataUsageId;
extern const uint32_t Local_SetLocalPlayerScore_m2220463184_MetadataUsageId;
extern String_t* _stringLiteral2433254339;
extern const uint32_t Local_ShowAchievementsUI_m4021375320_MetadataUsageId;
extern String_t* _stringLiteral3249695287;
extern const uint32_t Local_ShowLeaderboardUI_m151660348_MetadataUsageId;
extern const uint32_t Local_CreateLeaderboard_m1529960496_MetadataUsageId;
extern RuntimeClass* ILocalUser_t2242999785_il2cpp_TypeInfo_var;
extern String_t* _stringLiteral3019217460;
extern const uint32_t Local_VerifyUser_m2348500446_MetadataUsageId;
extern RuntimeClass* UserProfile_t3137328177_il2cpp_TypeInfo_var;
extern RuntimeClass* AchievementDescription_t3217594527_il2cpp_TypeInfo_var;
extern const RuntimeMethod* List_1_Add_m1578522892_RuntimeMethod_var;
extern const RuntimeMethod* List_1_Add_m1774517840_RuntimeMethod_var;
extern const RuntimeMethod* List_1__ctor_m1850989583_RuntimeMethod_var;
extern const RuntimeMethod* List_1_Add_m351770690_RuntimeMethod_var;
extern String_t* _stringLiteral2758590827;
extern String_t* _stringLiteral1972262697;
extern String_t* _stringLiteral2754897401;
extern String_t* _stringLiteral3928577833;
extern String_t* _stringLiteral808924690;
extern String_t* _stringLiteral1589925673;
extern String_t* _stringLiteral1343626406;
extern String_t* _stringLiteral3546240809;
extern String_t* _stringLiteral4166618085;
extern String_t* _stringLiteral1207588649;
extern String_t* _stringLiteral71334293;
extern String_t* _stringLiteral790607520;
extern String_t* _stringLiteral3353015368;
extern String_t* _stringLiteral1815849347;
extern String_t* _stringLiteral71334296;
extern String_t* _stringLiteral1410607624;
extern String_t* _stringLiteral1736209072;
extern String_t* _stringLiteral797346979;
extern String_t* _stringLiteral71334295;
extern String_t* _stringLiteral4060093497;
extern String_t* _stringLiteral3410331484;
extern String_t* _stringLiteral2859292443;
extern String_t* _stringLiteral2862084853;
extern String_t* _stringLiteral174720081;
extern String_t* _stringLiteral3889212743;
extern String_t* _stringLiteral2704654648;
extern String_t* _stringLiteral2937937919;
extern String_t* _stringLiteral3714347010;
extern const uint32_t Local_PopulateStaticData_m916798409_MetadataUsageId;
extern const uint32_t Local_CreateDummyTexture_m3769606019_MetadataUsageId;
extern const uint32_t Local__cctor_m4006956713_MetadataUsageId;

struct ObjectU5BU5D_t2843939325;
struct ScoreU5BU5D_t972561905;
struct IScoreU5BU5D_t527871248;
struct StringU5BU5D_t1281789340;
struct UserProfileU5BU5D_t1895532524;
struct IUserProfileU5BU5D_t909679733;
struct AchievementDescriptionU5BU5D_t1886727686;
struct IAchievementDescriptionU5BU5D_t1821964849;
struct AchievementU5BU5D_t1511134929;
struct IAchievementU5BU5D_t1892338339;


#ifndef U3CMODULEU3E_T692745540_H
#define U3CMODULEU3E_T692745540_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <Module>
struct  U3CModuleU3E_t692745540 
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // U3CMODULEU3E_T692745540_H
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
struct Il2CppArrayBounds;
#ifndef RUNTIMEARRAY_H
#define RUNTIMEARRAY_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Array

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // RUNTIMEARRAY_H
#ifndef ACHIEVEMENTDESCRIPTION_T3217594527_H
#define ACHIEVEMENTDESCRIPTION_T3217594527_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.SocialPlatforms.Impl.AchievementDescription
struct  AchievementDescription_t3217594527  : public RuntimeObject
{
public:
	// System.String UnityEngine.SocialPlatforms.Impl.AchievementDescription::m_Title
	String_t* ___m_Title_0;
	// UnityEngine.Texture2D UnityEngine.SocialPlatforms.Impl.AchievementDescription::m_Image
	Texture2D_t3840446185 * ___m_Image_1;
	// System.String UnityEngine.SocialPlatforms.Impl.AchievementDescription::m_AchievedDescription
	String_t* ___m_AchievedDescription_2;
	// System.String UnityEngine.SocialPlatforms.Impl.AchievementDescription::m_UnachievedDescription
	String_t* ___m_UnachievedDescription_3;
	// System.Boolean UnityEngine.SocialPlatforms.Impl.AchievementDescription::m_Hidden
	bool ___m_Hidden_4;
	// System.Int32 UnityEngine.SocialPlatforms.Impl.AchievementDescription::m_Points
	int32_t ___m_Points_5;
	// System.String UnityEngine.SocialPlatforms.Impl.AchievementDescription::<id>k__BackingField
	String_t* ___U3CidU3Ek__BackingField_6;

public:
	inline static int32_t get_offset_of_m_Title_0() { return static_cast<int32_t>(offsetof(AchievementDescription_t3217594527, ___m_Title_0)); }
	inline String_t* get_m_Title_0() const { return ___m_Title_0; }
	inline String_t** get_address_of_m_Title_0() { return &___m_Title_0; }
	inline void set_m_Title_0(String_t* value)
	{
		___m_Title_0 = value;
		Il2CppCodeGenWriteBarrier((&___m_Title_0), value);
	}

	inline static int32_t get_offset_of_m_Image_1() { return static_cast<int32_t>(offsetof(AchievementDescription_t3217594527, ___m_Image_1)); }
	inline Texture2D_t3840446185 * get_m_Image_1() const { return ___m_Image_1; }
	inline Texture2D_t3840446185 ** get_address_of_m_Image_1() { return &___m_Image_1; }
	inline void set_m_Image_1(Texture2D_t3840446185 * value)
	{
		___m_Image_1 = value;
		Il2CppCodeGenWriteBarrier((&___m_Image_1), value);
	}

	inline static int32_t get_offset_of_m_AchievedDescription_2() { return static_cast<int32_t>(offsetof(AchievementDescription_t3217594527, ___m_AchievedDescription_2)); }
	inline String_t* get_m_AchievedDescription_2() const { return ___m_AchievedDescription_2; }
	inline String_t** get_address_of_m_AchievedDescription_2() { return &___m_AchievedDescription_2; }
	inline void set_m_AchievedDescription_2(String_t* value)
	{
		___m_AchievedDescription_2 = value;
		Il2CppCodeGenWriteBarrier((&___m_AchievedDescription_2), value);
	}

	inline static int32_t get_offset_of_m_UnachievedDescription_3() { return static_cast<int32_t>(offsetof(AchievementDescription_t3217594527, ___m_UnachievedDescription_3)); }
	inline String_t* get_m_UnachievedDescription_3() const { return ___m_UnachievedDescription_3; }
	inline String_t** get_address_of_m_UnachievedDescription_3() { return &___m_UnachievedDescription_3; }
	inline void set_m_UnachievedDescription_3(String_t* value)
	{
		___m_UnachievedDescription_3 = value;
		Il2CppCodeGenWriteBarrier((&___m_UnachievedDescription_3), value);
	}

	inline static int32_t get_offset_of_m_Hidden_4() { return static_cast<int32_t>(offsetof(AchievementDescription_t3217594527, ___m_Hidden_4)); }
	inline bool get_m_Hidden_4() const { return ___m_Hidden_4; }
	inline bool* get_address_of_m_Hidden_4() { return &___m_Hidden_4; }
	inline void set_m_Hidden_4(bool value)
	{
		___m_Hidden_4 = value;
	}

	inline static int32_t get_offset_of_m_Points_5() { return static_cast<int32_t>(offsetof(AchievementDescription_t3217594527, ___m_Points_5)); }
	inline int32_t get_m_Points_5() const { return ___m_Points_5; }
	inline int32_t* get_address_of_m_Points_5() { return &___m_Points_5; }
	inline void set_m_Points_5(int32_t value)
	{
		___m_Points_5 = value;
	}

	inline static int32_t get_offset_of_U3CidU3Ek__BackingField_6() { return static_cast<int32_t>(offsetof(AchievementDescription_t3217594527, ___U3CidU3Ek__BackingField_6)); }
	inline String_t* get_U3CidU3Ek__BackingField_6() const { return ___U3CidU3Ek__BackingField_6; }
	inline String_t** get_address_of_U3CidU3Ek__BackingField_6() { return &___U3CidU3Ek__BackingField_6; }
	inline void set_U3CidU3Ek__BackingField_6(String_t* value)
	{
		___U3CidU3Ek__BackingField_6 = value;
		Il2CppCodeGenWriteBarrier((&___U3CidU3Ek__BackingField_6), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ACHIEVEMENTDESCRIPTION_T3217594527_H
#ifndef LOCAL_T4068483442_H
#define LOCAL_T4068483442_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.SocialPlatforms.Local
struct  Local_t4068483442  : public RuntimeObject
{
public:
	// System.Collections.Generic.List`1<UnityEngine.SocialPlatforms.Impl.UserProfile> UnityEngine.SocialPlatforms.Local::m_Friends
	List_1_t314435623 * ___m_Friends_1;
	// System.Collections.Generic.List`1<UnityEngine.SocialPlatforms.Impl.UserProfile> UnityEngine.SocialPlatforms.Local::m_Users
	List_1_t314435623 * ___m_Users_2;
	// System.Collections.Generic.List`1<UnityEngine.SocialPlatforms.Impl.AchievementDescription> UnityEngine.SocialPlatforms.Local::m_AchievementDescriptions
	List_1_t394701973 * ___m_AchievementDescriptions_3;
	// System.Collections.Generic.List`1<UnityEngine.SocialPlatforms.Impl.Achievement> UnityEngine.SocialPlatforms.Local::m_Achievements
	List_1_t2037434726 * ___m_Achievements_4;
	// System.Collections.Generic.List`1<UnityEngine.SocialPlatforms.Impl.Leaderboard> UnityEngine.SocialPlatforms.Local::m_Leaderboards
	List_1_t2537151505 * ___m_Leaderboards_5;
	// UnityEngine.Texture2D UnityEngine.SocialPlatforms.Local::m_DefaultTexture
	Texture2D_t3840446185 * ___m_DefaultTexture_6;

public:
	inline static int32_t get_offset_of_m_Friends_1() { return static_cast<int32_t>(offsetof(Local_t4068483442, ___m_Friends_1)); }
	inline List_1_t314435623 * get_m_Friends_1() const { return ___m_Friends_1; }
	inline List_1_t314435623 ** get_address_of_m_Friends_1() { return &___m_Friends_1; }
	inline void set_m_Friends_1(List_1_t314435623 * value)
	{
		___m_Friends_1 = value;
		Il2CppCodeGenWriteBarrier((&___m_Friends_1), value);
	}

	inline static int32_t get_offset_of_m_Users_2() { return static_cast<int32_t>(offsetof(Local_t4068483442, ___m_Users_2)); }
	inline List_1_t314435623 * get_m_Users_2() const { return ___m_Users_2; }
	inline List_1_t314435623 ** get_address_of_m_Users_2() { return &___m_Users_2; }
	inline void set_m_Users_2(List_1_t314435623 * value)
	{
		___m_Users_2 = value;
		Il2CppCodeGenWriteBarrier((&___m_Users_2), value);
	}

	inline static int32_t get_offset_of_m_AchievementDescriptions_3() { return static_cast<int32_t>(offsetof(Local_t4068483442, ___m_AchievementDescriptions_3)); }
	inline List_1_t394701973 * get_m_AchievementDescriptions_3() const { return ___m_AchievementDescriptions_3; }
	inline List_1_t394701973 ** get_address_of_m_AchievementDescriptions_3() { return &___m_AchievementDescriptions_3; }
	inline void set_m_AchievementDescriptions_3(List_1_t394701973 * value)
	{
		___m_AchievementDescriptions_3 = value;
		Il2CppCodeGenWriteBarrier((&___m_AchievementDescriptions_3), value);
	}

	inline static int32_t get_offset_of_m_Achievements_4() { return static_cast<int32_t>(offsetof(Local_t4068483442, ___m_Achievements_4)); }
	inline List_1_t2037434726 * get_m_Achievements_4() const { return ___m_Achievements_4; }
	inline List_1_t2037434726 ** get_address_of_m_Achievements_4() { return &___m_Achievements_4; }
	inline void set_m_Achievements_4(List_1_t2037434726 * value)
	{
		___m_Achievements_4 = value;
		Il2CppCodeGenWriteBarrier((&___m_Achievements_4), value);
	}

	inline static int32_t get_offset_of_m_Leaderboards_5() { return static_cast<int32_t>(offsetof(Local_t4068483442, ___m_Leaderboards_5)); }
	inline List_1_t2537151505 * get_m_Leaderboards_5() const { return ___m_Leaderboards_5; }
	inline List_1_t2537151505 ** get_address_of_m_Leaderboards_5() { return &___m_Leaderboards_5; }
	inline void set_m_Leaderboards_5(List_1_t2537151505 * value)
	{
		___m_Leaderboards_5 = value;
		Il2CppCodeGenWriteBarrier((&___m_Leaderboards_5), value);
	}

	inline static int32_t get_offset_of_m_DefaultTexture_6() { return static_cast<int32_t>(offsetof(Local_t4068483442, ___m_DefaultTexture_6)); }
	inline Texture2D_t3840446185 * get_m_DefaultTexture_6() const { return ___m_DefaultTexture_6; }
	inline Texture2D_t3840446185 ** get_address_of_m_DefaultTexture_6() { return &___m_DefaultTexture_6; }
	inline void set_m_DefaultTexture_6(Texture2D_t3840446185 * value)
	{
		___m_DefaultTexture_6 = value;
		Il2CppCodeGenWriteBarrier((&___m_DefaultTexture_6), value);
	}
};

struct Local_t4068483442_StaticFields
{
public:
	// UnityEngine.SocialPlatforms.Impl.LocalUser UnityEngine.SocialPlatforms.Local::m_LocalUser
	LocalUser_t365094499 * ___m_LocalUser_0;
	// System.Comparison`1<UnityEngine.SocialPlatforms.Impl.Score> UnityEngine.SocialPlatforms.Local::<>f__am$cache0
	Comparison_1_t1743576507 * ___U3CU3Ef__amU24cache0_7;

public:
	inline static int32_t get_offset_of_m_LocalUser_0() { return static_cast<int32_t>(offsetof(Local_t4068483442_StaticFields, ___m_LocalUser_0)); }
	inline LocalUser_t365094499 * get_m_LocalUser_0() const { return ___m_LocalUser_0; }
	inline LocalUser_t365094499 ** get_address_of_m_LocalUser_0() { return &___m_LocalUser_0; }
	inline void set_m_LocalUser_0(LocalUser_t365094499 * value)
	{
		___m_LocalUser_0 = value;
		Il2CppCodeGenWriteBarrier((&___m_LocalUser_0), value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__amU24cache0_7() { return static_cast<int32_t>(offsetof(Local_t4068483442_StaticFields, ___U3CU3Ef__amU24cache0_7)); }
	inline Comparison_1_t1743576507 * get_U3CU3Ef__amU24cache0_7() const { return ___U3CU3Ef__amU24cache0_7; }
	inline Comparison_1_t1743576507 ** get_address_of_U3CU3Ef__amU24cache0_7() { return &___U3CU3Ef__amU24cache0_7; }
	inline void set_U3CU3Ef__amU24cache0_7(Comparison_1_t1743576507 * value)
	{
		___U3CU3Ef__amU24cache0_7 = value;
		Il2CppCodeGenWriteBarrier((&___U3CU3Ef__amU24cache0_7), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LOCAL_T4068483442_H
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
#ifndef LIST_1_T3440720070_H
#define LIST_1_T3440720070_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.List`1<UnityEngine.SocialPlatforms.Impl.Score>
struct  List_1_t3440720070  : public RuntimeObject
{
public:
	// T[] System.Collections.Generic.List`1::_items
	ScoreU5BU5D_t972561905* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;

public:
	inline static int32_t get_offset_of__items_1() { return static_cast<int32_t>(offsetof(List_1_t3440720070, ____items_1)); }
	inline ScoreU5BU5D_t972561905* get__items_1() const { return ____items_1; }
	inline ScoreU5BU5D_t972561905** get_address_of__items_1() { return &____items_1; }
	inline void set__items_1(ScoreU5BU5D_t972561905* value)
	{
		____items_1 = value;
		Il2CppCodeGenWriteBarrier((&____items_1), value);
	}

	inline static int32_t get_offset_of__size_2() { return static_cast<int32_t>(offsetof(List_1_t3440720070, ____size_2)); }
	inline int32_t get__size_2() const { return ____size_2; }
	inline int32_t* get_address_of__size_2() { return &____size_2; }
	inline void set__size_2(int32_t value)
	{
		____size_2 = value;
	}

	inline static int32_t get_offset_of__version_3() { return static_cast<int32_t>(offsetof(List_1_t3440720070, ____version_3)); }
	inline int32_t get__version_3() const { return ____version_3; }
	inline int32_t* get_address_of__version_3() { return &____version_3; }
	inline void set__version_3(int32_t value)
	{
		____version_3 = value;
	}
};

struct List_1_t3440720070_StaticFields
{
public:
	// T[] System.Collections.Generic.List`1::EmptyArray
	ScoreU5BU5D_t972561905* ___EmptyArray_4;

public:
	inline static int32_t get_offset_of_EmptyArray_4() { return static_cast<int32_t>(offsetof(List_1_t3440720070_StaticFields, ___EmptyArray_4)); }
	inline ScoreU5BU5D_t972561905* get_EmptyArray_4() const { return ___EmptyArray_4; }
	inline ScoreU5BU5D_t972561905** get_address_of_EmptyArray_4() { return &___EmptyArray_4; }
	inline void set_EmptyArray_4(ScoreU5BU5D_t972561905* value)
	{
		___EmptyArray_4 = value;
		Il2CppCodeGenWriteBarrier((&___EmptyArray_4), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LIST_1_T3440720070_H
#ifndef LIST_1_T394701973_H
#define LIST_1_T394701973_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.List`1<UnityEngine.SocialPlatforms.Impl.AchievementDescription>
struct  List_1_t394701973  : public RuntimeObject
{
public:
	// T[] System.Collections.Generic.List`1::_items
	AchievementDescriptionU5BU5D_t1886727686* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;

public:
	inline static int32_t get_offset_of__items_1() { return static_cast<int32_t>(offsetof(List_1_t394701973, ____items_1)); }
	inline AchievementDescriptionU5BU5D_t1886727686* get__items_1() const { return ____items_1; }
	inline AchievementDescriptionU5BU5D_t1886727686** get_address_of__items_1() { return &____items_1; }
	inline void set__items_1(AchievementDescriptionU5BU5D_t1886727686* value)
	{
		____items_1 = value;
		Il2CppCodeGenWriteBarrier((&____items_1), value);
	}

	inline static int32_t get_offset_of__size_2() { return static_cast<int32_t>(offsetof(List_1_t394701973, ____size_2)); }
	inline int32_t get__size_2() const { return ____size_2; }
	inline int32_t* get_address_of__size_2() { return &____size_2; }
	inline void set__size_2(int32_t value)
	{
		____size_2 = value;
	}

	inline static int32_t get_offset_of__version_3() { return static_cast<int32_t>(offsetof(List_1_t394701973, ____version_3)); }
	inline int32_t get__version_3() const { return ____version_3; }
	inline int32_t* get_address_of__version_3() { return &____version_3; }
	inline void set__version_3(int32_t value)
	{
		____version_3 = value;
	}
};

struct List_1_t394701973_StaticFields
{
public:
	// T[] System.Collections.Generic.List`1::EmptyArray
	AchievementDescriptionU5BU5D_t1886727686* ___EmptyArray_4;

public:
	inline static int32_t get_offset_of_EmptyArray_4() { return static_cast<int32_t>(offsetof(List_1_t394701973_StaticFields, ___EmptyArray_4)); }
	inline AchievementDescriptionU5BU5D_t1886727686* get_EmptyArray_4() const { return ___EmptyArray_4; }
	inline AchievementDescriptionU5BU5D_t1886727686** get_address_of_EmptyArray_4() { return &___EmptyArray_4; }
	inline void set_EmptyArray_4(AchievementDescriptionU5BU5D_t1886727686* value)
	{
		___EmptyArray_4 = value;
		Il2CppCodeGenWriteBarrier((&___EmptyArray_4), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LIST_1_T394701973_H
#ifndef LIST_1_T2037434726_H
#define LIST_1_T2037434726_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.List`1<UnityEngine.SocialPlatforms.Impl.Achievement>
struct  List_1_t2037434726  : public RuntimeObject
{
public:
	// T[] System.Collections.Generic.List`1::_items
	AchievementU5BU5D_t1511134929* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;

public:
	inline static int32_t get_offset_of__items_1() { return static_cast<int32_t>(offsetof(List_1_t2037434726, ____items_1)); }
	inline AchievementU5BU5D_t1511134929* get__items_1() const { return ____items_1; }
	inline AchievementU5BU5D_t1511134929** get_address_of__items_1() { return &____items_1; }
	inline void set__items_1(AchievementU5BU5D_t1511134929* value)
	{
		____items_1 = value;
		Il2CppCodeGenWriteBarrier((&____items_1), value);
	}

	inline static int32_t get_offset_of__size_2() { return static_cast<int32_t>(offsetof(List_1_t2037434726, ____size_2)); }
	inline int32_t get__size_2() const { return ____size_2; }
	inline int32_t* get_address_of__size_2() { return &____size_2; }
	inline void set__size_2(int32_t value)
	{
		____size_2 = value;
	}

	inline static int32_t get_offset_of__version_3() { return static_cast<int32_t>(offsetof(List_1_t2037434726, ____version_3)); }
	inline int32_t get__version_3() const { return ____version_3; }
	inline int32_t* get_address_of__version_3() { return &____version_3; }
	inline void set__version_3(int32_t value)
	{
		____version_3 = value;
	}
};

struct List_1_t2037434726_StaticFields
{
public:
	// T[] System.Collections.Generic.List`1::EmptyArray
	AchievementU5BU5D_t1511134929* ___EmptyArray_4;

public:
	inline static int32_t get_offset_of_EmptyArray_4() { return static_cast<int32_t>(offsetof(List_1_t2037434726_StaticFields, ___EmptyArray_4)); }
	inline AchievementU5BU5D_t1511134929* get_EmptyArray_4() const { return ___EmptyArray_4; }
	inline AchievementU5BU5D_t1511134929** get_address_of_EmptyArray_4() { return &___EmptyArray_4; }
	inline void set_EmptyArray_4(AchievementU5BU5D_t1511134929* value)
	{
		___EmptyArray_4 = value;
		Il2CppCodeGenWriteBarrier((&___EmptyArray_4), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LIST_1_T2037434726_H
#ifndef LIST_1_T2537151505_H
#define LIST_1_T2537151505_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.List`1<UnityEngine.SocialPlatforms.Impl.Leaderboard>
struct  List_1_t2537151505  : public RuntimeObject
{
public:
	// T[] System.Collections.Generic.List`1::_items
	LeaderboardU5BU5D_t31671578* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;

public:
	inline static int32_t get_offset_of__items_1() { return static_cast<int32_t>(offsetof(List_1_t2537151505, ____items_1)); }
	inline LeaderboardU5BU5D_t31671578* get__items_1() const { return ____items_1; }
	inline LeaderboardU5BU5D_t31671578** get_address_of__items_1() { return &____items_1; }
	inline void set__items_1(LeaderboardU5BU5D_t31671578* value)
	{
		____items_1 = value;
		Il2CppCodeGenWriteBarrier((&____items_1), value);
	}

	inline static int32_t get_offset_of__size_2() { return static_cast<int32_t>(offsetof(List_1_t2537151505, ____size_2)); }
	inline int32_t get__size_2() const { return ____size_2; }
	inline int32_t* get_address_of__size_2() { return &____size_2; }
	inline void set__size_2(int32_t value)
	{
		____size_2 = value;
	}

	inline static int32_t get_offset_of__version_3() { return static_cast<int32_t>(offsetof(List_1_t2537151505, ____version_3)); }
	inline int32_t get__version_3() const { return ____version_3; }
	inline int32_t* get_address_of__version_3() { return &____version_3; }
	inline void set__version_3(int32_t value)
	{
		____version_3 = value;
	}
};

struct List_1_t2537151505_StaticFields
{
public:
	// T[] System.Collections.Generic.List`1::EmptyArray
	LeaderboardU5BU5D_t31671578* ___EmptyArray_4;

public:
	inline static int32_t get_offset_of_EmptyArray_4() { return static_cast<int32_t>(offsetof(List_1_t2537151505_StaticFields, ___EmptyArray_4)); }
	inline LeaderboardU5BU5D_t31671578* get_EmptyArray_4() const { return ___EmptyArray_4; }
	inline LeaderboardU5BU5D_t31671578** get_address_of_EmptyArray_4() { return &___EmptyArray_4; }
	inline void set_EmptyArray_4(LeaderboardU5BU5D_t31671578* value)
	{
		___EmptyArray_4 = value;
		Il2CppCodeGenWriteBarrier((&___EmptyArray_4), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LIST_1_T2537151505_H
#ifndef LIST_1_T314435623_H
#define LIST_1_T314435623_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.List`1<UnityEngine.SocialPlatforms.Impl.UserProfile>
struct  List_1_t314435623  : public RuntimeObject
{
public:
	// T[] System.Collections.Generic.List`1::_items
	UserProfileU5BU5D_t1895532524* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;

public:
	inline static int32_t get_offset_of__items_1() { return static_cast<int32_t>(offsetof(List_1_t314435623, ____items_1)); }
	inline UserProfileU5BU5D_t1895532524* get__items_1() const { return ____items_1; }
	inline UserProfileU5BU5D_t1895532524** get_address_of__items_1() { return &____items_1; }
	inline void set__items_1(UserProfileU5BU5D_t1895532524* value)
	{
		____items_1 = value;
		Il2CppCodeGenWriteBarrier((&____items_1), value);
	}

	inline static int32_t get_offset_of__size_2() { return static_cast<int32_t>(offsetof(List_1_t314435623, ____size_2)); }
	inline int32_t get__size_2() const { return ____size_2; }
	inline int32_t* get_address_of__size_2() { return &____size_2; }
	inline void set__size_2(int32_t value)
	{
		____size_2 = value;
	}

	inline static int32_t get_offset_of__version_3() { return static_cast<int32_t>(offsetof(List_1_t314435623, ____version_3)); }
	inline int32_t get__version_3() const { return ____version_3; }
	inline int32_t* get_address_of__version_3() { return &____version_3; }
	inline void set__version_3(int32_t value)
	{
		____version_3 = value;
	}
};

struct List_1_t314435623_StaticFields
{
public:
	// T[] System.Collections.Generic.List`1::EmptyArray
	UserProfileU5BU5D_t1895532524* ___EmptyArray_4;

public:
	inline static int32_t get_offset_of_EmptyArray_4() { return static_cast<int32_t>(offsetof(List_1_t314435623_StaticFields, ___EmptyArray_4)); }
	inline UserProfileU5BU5D_t1895532524* get_EmptyArray_4() const { return ___EmptyArray_4; }
	inline UserProfileU5BU5D_t1895532524** get_address_of_EmptyArray_4() { return &___EmptyArray_4; }
	inline void set_EmptyArray_4(UserProfileU5BU5D_t1895532524* value)
	{
		___EmptyArray_4 = value;
		Il2CppCodeGenWriteBarrier((&___EmptyArray_4), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LIST_1_T314435623_H
#ifndef SOCIAL_T3745463066_H
#define SOCIAL_T3745463066_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Social
struct  Social_t3745463066  : public RuntimeObject
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SOCIAL_T3745463066_H
#ifndef STRING_T_H
#define STRING_T_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.String
struct  String_t  : public RuntimeObject
{
public:
	// System.Int32 System.String::length
	int32_t ___length_0;
	// System.Char System.String::start_char
	Il2CppChar ___start_char_1;

public:
	inline static int32_t get_offset_of_length_0() { return static_cast<int32_t>(offsetof(String_t, ___length_0)); }
	inline int32_t get_length_0() const { return ___length_0; }
	inline int32_t* get_address_of_length_0() { return &___length_0; }
	inline void set_length_0(int32_t value)
	{
		___length_0 = value;
	}

	inline static int32_t get_offset_of_start_char_1() { return static_cast<int32_t>(offsetof(String_t, ___start_char_1)); }
	inline Il2CppChar get_start_char_1() const { return ___start_char_1; }
	inline Il2CppChar* get_address_of_start_char_1() { return &___start_char_1; }
	inline void set_start_char_1(Il2CppChar value)
	{
		___start_char_1 = value;
	}
};

struct String_t_StaticFields
{
public:
	// System.String System.String::Empty
	String_t* ___Empty_2;
	// System.Char[] System.String::WhiteChars
	CharU5BU5D_t3528271667* ___WhiteChars_3;

public:
	inline static int32_t get_offset_of_Empty_2() { return static_cast<int32_t>(offsetof(String_t_StaticFields, ___Empty_2)); }
	inline String_t* get_Empty_2() const { return ___Empty_2; }
	inline String_t** get_address_of_Empty_2() { return &___Empty_2; }
	inline void set_Empty_2(String_t* value)
	{
		___Empty_2 = value;
		Il2CppCodeGenWriteBarrier((&___Empty_2), value);
	}

	inline static int32_t get_offset_of_WhiteChars_3() { return static_cast<int32_t>(offsetof(String_t_StaticFields, ___WhiteChars_3)); }
	inline CharU5BU5D_t3528271667* get_WhiteChars_3() const { return ___WhiteChars_3; }
	inline CharU5BU5D_t3528271667** get_address_of_WhiteChars_3() { return &___WhiteChars_3; }
	inline void set_WhiteChars_3(CharU5BU5D_t3528271667* value)
	{
		___WhiteChars_3 = value;
		Il2CppCodeGenWriteBarrier((&___WhiteChars_3), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // STRING_T_H
#ifndef ACTIVEPLATFORM_T3103617690_H
#define ACTIVEPLATFORM_T3103617690_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.SocialPlatforms.ActivePlatform
struct  ActivePlatform_t3103617690  : public RuntimeObject
{
public:

public:
};

struct ActivePlatform_t3103617690_StaticFields
{
public:
	// UnityEngine.SocialPlatforms.ISocialPlatform UnityEngine.SocialPlatforms.ActivePlatform::_active
	RuntimeObject* ____active_0;

public:
	inline static int32_t get_offset_of__active_0() { return static_cast<int32_t>(offsetof(ActivePlatform_t3103617690_StaticFields, ____active_0)); }
	inline RuntimeObject* get__active_0() const { return ____active_0; }
	inline RuntimeObject** get_address_of__active_0() { return &____active_0; }
	inline void set__active_0(RuntimeObject* value)
	{
		____active_0 = value;
		Il2CppCodeGenWriteBarrier((&____active_0), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ACTIVEPLATFORM_T3103617690_H
#ifndef UINT32_T2560061978_H
#define UINT32_T2560061978_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.UInt32
struct  UInt32_t2560061978 
{
public:
	// System.UInt32 System.UInt32::m_value
	uint32_t ___m_value_2;

public:
	inline static int32_t get_offset_of_m_value_2() { return static_cast<int32_t>(offsetof(UInt32_t2560061978, ___m_value_2)); }
	inline uint32_t get_m_value_2() const { return ___m_value_2; }
	inline uint32_t* get_address_of_m_value_2() { return &___m_value_2; }
	inline void set_m_value_2(uint32_t value)
	{
		___m_value_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // UINT32_T2560061978_H
#ifndef ENUMERATOR_T2283945850_H
#define ENUMERATOR_T2283945850_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.List`1/Enumerator<UnityEngine.SocialPlatforms.Impl.AchievementDescription>
struct  Enumerator_t2283945850 
{
public:
	// System.Collections.Generic.List`1<T> System.Collections.Generic.List`1/Enumerator::l
	List_1_t394701973 * ___l_0;
	// System.Int32 System.Collections.Generic.List`1/Enumerator::next
	int32_t ___next_1;
	// System.Int32 System.Collections.Generic.List`1/Enumerator::ver
	int32_t ___ver_2;
	// T System.Collections.Generic.List`1/Enumerator::current
	AchievementDescription_t3217594527 * ___current_3;

public:
	inline static int32_t get_offset_of_l_0() { return static_cast<int32_t>(offsetof(Enumerator_t2283945850, ___l_0)); }
	inline List_1_t394701973 * get_l_0() const { return ___l_0; }
	inline List_1_t394701973 ** get_address_of_l_0() { return &___l_0; }
	inline void set_l_0(List_1_t394701973 * value)
	{
		___l_0 = value;
		Il2CppCodeGenWriteBarrier((&___l_0), value);
	}

	inline static int32_t get_offset_of_next_1() { return static_cast<int32_t>(offsetof(Enumerator_t2283945850, ___next_1)); }
	inline int32_t get_next_1() const { return ___next_1; }
	inline int32_t* get_address_of_next_1() { return &___next_1; }
	inline void set_next_1(int32_t value)
	{
		___next_1 = value;
	}

	inline static int32_t get_offset_of_ver_2() { return static_cast<int32_t>(offsetof(Enumerator_t2283945850, ___ver_2)); }
	inline int32_t get_ver_2() const { return ___ver_2; }
	inline int32_t* get_address_of_ver_2() { return &___ver_2; }
	inline void set_ver_2(int32_t value)
	{
		___ver_2 = value;
	}

	inline static int32_t get_offset_of_current_3() { return static_cast<int32_t>(offsetof(Enumerator_t2283945850, ___current_3)); }
	inline AchievementDescription_t3217594527 * get_current_3() const { return ___current_3; }
	inline AchievementDescription_t3217594527 ** get_address_of_current_3() { return &___current_3; }
	inline void set_current_3(AchievementDescription_t3217594527 * value)
	{
		___current_3 = value;
		Il2CppCodeGenWriteBarrier((&___current_3), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ENUMERATOR_T2283945850_H
#ifndef ENUMERATOR_T131428086_H
#define ENUMERATOR_T131428086_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.List`1/Enumerator<UnityEngine.SocialPlatforms.Impl.Leaderboard>
struct  Enumerator_t131428086 
{
public:
	// System.Collections.Generic.List`1<T> System.Collections.Generic.List`1/Enumerator::l
	List_1_t2537151505 * ___l_0;
	// System.Int32 System.Collections.Generic.List`1/Enumerator::next
	int32_t ___next_1;
	// System.Int32 System.Collections.Generic.List`1/Enumerator::ver
	int32_t ___ver_2;
	// T System.Collections.Generic.List`1/Enumerator::current
	Leaderboard_t1065076763 * ___current_3;

public:
	inline static int32_t get_offset_of_l_0() { return static_cast<int32_t>(offsetof(Enumerator_t131428086, ___l_0)); }
	inline List_1_t2537151505 * get_l_0() const { return ___l_0; }
	inline List_1_t2537151505 ** get_address_of_l_0() { return &___l_0; }
	inline void set_l_0(List_1_t2537151505 * value)
	{
		___l_0 = value;
		Il2CppCodeGenWriteBarrier((&___l_0), value);
	}

	inline static int32_t get_offset_of_next_1() { return static_cast<int32_t>(offsetof(Enumerator_t131428086, ___next_1)); }
	inline int32_t get_next_1() const { return ___next_1; }
	inline int32_t* get_address_of_next_1() { return &___next_1; }
	inline void set_next_1(int32_t value)
	{
		___next_1 = value;
	}

	inline static int32_t get_offset_of_ver_2() { return static_cast<int32_t>(offsetof(Enumerator_t131428086, ___ver_2)); }
	inline int32_t get_ver_2() const { return ___ver_2; }
	inline int32_t* get_address_of_ver_2() { return &___ver_2; }
	inline void set_ver_2(int32_t value)
	{
		___ver_2 = value;
	}

	inline static int32_t get_offset_of_current_3() { return static_cast<int32_t>(offsetof(Enumerator_t131428086, ___current_3)); }
	inline Leaderboard_t1065076763 * get_current_3() const { return ___current_3; }
	inline Leaderboard_t1065076763 ** get_address_of_current_3() { return &___current_3; }
	inline void set_current_3(Leaderboard_t1065076763 * value)
	{
		___current_3 = value;
		Il2CppCodeGenWriteBarrier((&___current_3), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ENUMERATOR_T131428086_H
#ifndef ENUMERATOR_T2146457487_H
#define ENUMERATOR_T2146457487_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.List`1/Enumerator<System.Object>
struct  Enumerator_t2146457487 
{
public:
	// System.Collections.Generic.List`1<T> System.Collections.Generic.List`1/Enumerator::l
	List_1_t257213610 * ___l_0;
	// System.Int32 System.Collections.Generic.List`1/Enumerator::next
	int32_t ___next_1;
	// System.Int32 System.Collections.Generic.List`1/Enumerator::ver
	int32_t ___ver_2;
	// T System.Collections.Generic.List`1/Enumerator::current
	RuntimeObject * ___current_3;

public:
	inline static int32_t get_offset_of_l_0() { return static_cast<int32_t>(offsetof(Enumerator_t2146457487, ___l_0)); }
	inline List_1_t257213610 * get_l_0() const { return ___l_0; }
	inline List_1_t257213610 ** get_address_of_l_0() { return &___l_0; }
	inline void set_l_0(List_1_t257213610 * value)
	{
		___l_0 = value;
		Il2CppCodeGenWriteBarrier((&___l_0), value);
	}

	inline static int32_t get_offset_of_next_1() { return static_cast<int32_t>(offsetof(Enumerator_t2146457487, ___next_1)); }
	inline int32_t get_next_1() const { return ___next_1; }
	inline int32_t* get_address_of_next_1() { return &___next_1; }
	inline void set_next_1(int32_t value)
	{
		___next_1 = value;
	}

	inline static int32_t get_offset_of_ver_2() { return static_cast<int32_t>(offsetof(Enumerator_t2146457487, ___ver_2)); }
	inline int32_t get_ver_2() const { return ___ver_2; }
	inline int32_t* get_address_of_ver_2() { return &___ver_2; }
	inline void set_ver_2(int32_t value)
	{
		___ver_2 = value;
	}

	inline static int32_t get_offset_of_current_3() { return static_cast<int32_t>(offsetof(Enumerator_t2146457487, ___current_3)); }
	inline RuntimeObject * get_current_3() const { return ___current_3; }
	inline RuntimeObject ** get_address_of_current_3() { return &___current_3; }
	inline void set_current_3(RuntimeObject * value)
	{
		___current_3 = value;
		Il2CppCodeGenWriteBarrier((&___current_3), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ENUMERATOR_T2146457487_H
#ifndef VOID_T1185182177_H
#define VOID_T1185182177_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Void
struct  Void_t1185182177 
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // VOID_T1185182177_H
#ifndef DOUBLE_T594665363_H
#define DOUBLE_T594665363_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Double
struct  Double_t594665363 
{
public:
	// System.Double System.Double::m_value
	double ___m_value_13;

public:
	inline static int32_t get_offset_of_m_value_13() { return static_cast<int32_t>(offsetof(Double_t594665363, ___m_value_13)); }
	inline double get_m_value_13() const { return ___m_value_13; }
	inline double* get_address_of_m_value_13() { return &___m_value_13; }
	inline void set_m_value_13(double value)
	{
		___m_value_13 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // DOUBLE_T594665363_H
#ifndef ENUMERATOR_T3926678603_H
#define ENUMERATOR_T3926678603_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.List`1/Enumerator<UnityEngine.SocialPlatforms.Impl.Achievement>
struct  Enumerator_t3926678603 
{
public:
	// System.Collections.Generic.List`1<T> System.Collections.Generic.List`1/Enumerator::l
	List_1_t2037434726 * ___l_0;
	// System.Int32 System.Collections.Generic.List`1/Enumerator::next
	int32_t ___next_1;
	// System.Int32 System.Collections.Generic.List`1/Enumerator::ver
	int32_t ___ver_2;
	// T System.Collections.Generic.List`1/Enumerator::current
	Achievement_t565359984 * ___current_3;

public:
	inline static int32_t get_offset_of_l_0() { return static_cast<int32_t>(offsetof(Enumerator_t3926678603, ___l_0)); }
	inline List_1_t2037434726 * get_l_0() const { return ___l_0; }
	inline List_1_t2037434726 ** get_address_of_l_0() { return &___l_0; }
	inline void set_l_0(List_1_t2037434726 * value)
	{
		___l_0 = value;
		Il2CppCodeGenWriteBarrier((&___l_0), value);
	}

	inline static int32_t get_offset_of_next_1() { return static_cast<int32_t>(offsetof(Enumerator_t3926678603, ___next_1)); }
	inline int32_t get_next_1() const { return ___next_1; }
	inline int32_t* get_address_of_next_1() { return &___next_1; }
	inline void set_next_1(int32_t value)
	{
		___next_1 = value;
	}

	inline static int32_t get_offset_of_ver_2() { return static_cast<int32_t>(offsetof(Enumerator_t3926678603, ___ver_2)); }
	inline int32_t get_ver_2() const { return ___ver_2; }
	inline int32_t* get_address_of_ver_2() { return &___ver_2; }
	inline void set_ver_2(int32_t value)
	{
		___ver_2 = value;
	}

	inline static int32_t get_offset_of_current_3() { return static_cast<int32_t>(offsetof(Enumerator_t3926678603, ___current_3)); }
	inline Achievement_t565359984 * get_current_3() const { return ___current_3; }
	inline Achievement_t565359984 ** get_address_of_current_3() { return &___current_3; }
	inline void set_current_3(Achievement_t565359984 * value)
	{
		___current_3 = value;
		Il2CppCodeGenWriteBarrier((&___current_3), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ENUMERATOR_T3926678603_H
#ifndef RANGE_T173988048_H
#define RANGE_T173988048_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.SocialPlatforms.Range
struct  Range_t173988048 
{
public:
	// System.Int32 UnityEngine.SocialPlatforms.Range::from
	int32_t ___from_0;
	// System.Int32 UnityEngine.SocialPlatforms.Range::count
	int32_t ___count_1;

public:
	inline static int32_t get_offset_of_from_0() { return static_cast<int32_t>(offsetof(Range_t173988048, ___from_0)); }
	inline int32_t get_from_0() const { return ___from_0; }
	inline int32_t* get_address_of_from_0() { return &___from_0; }
	inline void set_from_0(int32_t value)
	{
		___from_0 = value;
	}

	inline static int32_t get_offset_of_count_1() { return static_cast<int32_t>(offsetof(Range_t173988048, ___count_1)); }
	inline int32_t get_count_1() const { return ___count_1; }
	inline int32_t* get_address_of_count_1() { return &___count_1; }
	inline void set_count_1(int32_t value)
	{
		___count_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // RANGE_T173988048_H
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
#ifndef BOOLEAN_T97287965_H
#define BOOLEAN_T97287965_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Boolean
struct  Boolean_t97287965 
{
public:
	// System.Boolean System.Boolean::m_value
	bool ___m_value_2;

public:
	inline static int32_t get_offset_of_m_value_2() { return static_cast<int32_t>(offsetof(Boolean_t97287965, ___m_value_2)); }
	inline bool get_m_value_2() const { return ___m_value_2; }
	inline bool* get_address_of_m_value_2() { return &___m_value_2; }
	inline void set_m_value_2(bool value)
	{
		___m_value_2 = value;
	}
};

struct Boolean_t97287965_StaticFields
{
public:
	// System.String System.Boolean::FalseString
	String_t* ___FalseString_0;
	// System.String System.Boolean::TrueString
	String_t* ___TrueString_1;

public:
	inline static int32_t get_offset_of_FalseString_0() { return static_cast<int32_t>(offsetof(Boolean_t97287965_StaticFields, ___FalseString_0)); }
	inline String_t* get_FalseString_0() const { return ___FalseString_0; }
	inline String_t** get_address_of_FalseString_0() { return &___FalseString_0; }
	inline void set_FalseString_0(String_t* value)
	{
		___FalseString_0 = value;
		Il2CppCodeGenWriteBarrier((&___FalseString_0), value);
	}

	inline static int32_t get_offset_of_TrueString_1() { return static_cast<int32_t>(offsetof(Boolean_t97287965_StaticFields, ___TrueString_1)); }
	inline String_t* get_TrueString_1() const { return ___TrueString_1; }
	inline String_t** get_address_of_TrueString_1() { return &___TrueString_1; }
	inline void set_TrueString_1(String_t* value)
	{
		___TrueString_1 = value;
		Il2CppCodeGenWriteBarrier((&___TrueString_1), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // BOOLEAN_T97287965_H
#ifndef INT64_T3736567304_H
#define INT64_T3736567304_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Int64
struct  Int64_t3736567304 
{
public:
	// System.Int64 System.Int64::m_value
	int64_t ___m_value_2;

public:
	inline static int32_t get_offset_of_m_value_2() { return static_cast<int32_t>(offsetof(Int64_t3736567304, ___m_value_2)); }
	inline int64_t get_m_value_2() const { return ___m_value_2; }
	inline int64_t* get_address_of_m_value_2() { return &___m_value_2; }
	inline void set_m_value_2(int64_t value)
	{
		___m_value_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // INT64_T3736567304_H
#ifndef COLOR_T2555686324_H
#define COLOR_T2555686324_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Color
struct  Color_t2555686324 
{
public:
	// System.Single UnityEngine.Color::r
	float ___r_0;
	// System.Single UnityEngine.Color::g
	float ___g_1;
	// System.Single UnityEngine.Color::b
	float ___b_2;
	// System.Single UnityEngine.Color::a
	float ___a_3;

public:
	inline static int32_t get_offset_of_r_0() { return static_cast<int32_t>(offsetof(Color_t2555686324, ___r_0)); }
	inline float get_r_0() const { return ___r_0; }
	inline float* get_address_of_r_0() { return &___r_0; }
	inline void set_r_0(float value)
	{
		___r_0 = value;
	}

	inline static int32_t get_offset_of_g_1() { return static_cast<int32_t>(offsetof(Color_t2555686324, ___g_1)); }
	inline float get_g_1() const { return ___g_1; }
	inline float* get_address_of_g_1() { return &___g_1; }
	inline void set_g_1(float value)
	{
		___g_1 = value;
	}

	inline static int32_t get_offset_of_b_2() { return static_cast<int32_t>(offsetof(Color_t2555686324, ___b_2)); }
	inline float get_b_2() const { return ___b_2; }
	inline float* get_address_of_b_2() { return &___b_2; }
	inline void set_b_2(float value)
	{
		___b_2 = value;
	}

	inline static int32_t get_offset_of_a_3() { return static_cast<int32_t>(offsetof(Color_t2555686324, ___a_3)); }
	inline float get_a_3() const { return ___a_3; }
	inline float* get_address_of_a_3() { return &___a_3; }
	inline void set_a_3(float value)
	{
		___a_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // COLOR_T2555686324_H
#ifndef INTPTR_T_H
#define INTPTR_T_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.IntPtr
struct  IntPtr_t 
{
public:
	// System.Void* System.IntPtr::m_value
	void* ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(IntPtr_t, ___m_value_0)); }
	inline void* get_m_value_0() const { return ___m_value_0; }
	inline void** get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(void* value)
	{
		___m_value_0 = value;
	}
};

struct IntPtr_t_StaticFields
{
public:
	// System.IntPtr System.IntPtr::Zero
	intptr_t ___Zero_1;

public:
	inline static int32_t get_offset_of_Zero_1() { return static_cast<int32_t>(offsetof(IntPtr_t_StaticFields, ___Zero_1)); }
	inline intptr_t get_Zero_1() const { return ___Zero_1; }
	inline intptr_t* get_address_of_Zero_1() { return &___Zero_1; }
	inline void set_Zero_1(intptr_t value)
	{
		___Zero_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // INTPTR_T_H
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
#ifndef INT32_T2950945753_H
#define INT32_T2950945753_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Int32
struct  Int32_t2950945753 
{
public:
	// System.Int32 System.Int32::m_value
	int32_t ___m_value_2;

public:
	inline static int32_t get_offset_of_m_value_2() { return static_cast<int32_t>(offsetof(Int32_t2950945753, ___m_value_2)); }
	inline int32_t get_m_value_2() const { return ___m_value_2; }
	inline int32_t* get_address_of_m_value_2() { return &___m_value_2; }
	inline void set_m_value_2(int32_t value)
	{
		___m_value_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // INT32_T2950945753_H
#ifndef DELEGATE_T1188392813_H
#define DELEGATE_T1188392813_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Delegate
struct  Delegate_t1188392813  : public RuntimeObject
{
public:
	// System.IntPtr System.Delegate::method_ptr
	Il2CppMethodPointer ___method_ptr_0;
	// System.IntPtr System.Delegate::invoke_impl
	intptr_t ___invoke_impl_1;
	// System.Object System.Delegate::m_target
	RuntimeObject * ___m_target_2;
	// System.IntPtr System.Delegate::method
	intptr_t ___method_3;
	// System.IntPtr System.Delegate::delegate_trampoline
	intptr_t ___delegate_trampoline_4;
	// System.IntPtr System.Delegate::method_code
	intptr_t ___method_code_5;
	// System.Reflection.MethodInfo System.Delegate::method_info
	MethodInfo_t * ___method_info_6;
	// System.Reflection.MethodInfo System.Delegate::original_method_info
	MethodInfo_t * ___original_method_info_7;
	// System.DelegateData System.Delegate::data
	DelegateData_t1677132599 * ___data_8;

public:
	inline static int32_t get_offset_of_method_ptr_0() { return static_cast<int32_t>(offsetof(Delegate_t1188392813, ___method_ptr_0)); }
	inline Il2CppMethodPointer get_method_ptr_0() const { return ___method_ptr_0; }
	inline Il2CppMethodPointer* get_address_of_method_ptr_0() { return &___method_ptr_0; }
	inline void set_method_ptr_0(Il2CppMethodPointer value)
	{
		___method_ptr_0 = value;
	}

	inline static int32_t get_offset_of_invoke_impl_1() { return static_cast<int32_t>(offsetof(Delegate_t1188392813, ___invoke_impl_1)); }
	inline intptr_t get_invoke_impl_1() const { return ___invoke_impl_1; }
	inline intptr_t* get_address_of_invoke_impl_1() { return &___invoke_impl_1; }
	inline void set_invoke_impl_1(intptr_t value)
	{
		___invoke_impl_1 = value;
	}

	inline static int32_t get_offset_of_m_target_2() { return static_cast<int32_t>(offsetof(Delegate_t1188392813, ___m_target_2)); }
	inline RuntimeObject * get_m_target_2() const { return ___m_target_2; }
	inline RuntimeObject ** get_address_of_m_target_2() { return &___m_target_2; }
	inline void set_m_target_2(RuntimeObject * value)
	{
		___m_target_2 = value;
		Il2CppCodeGenWriteBarrier((&___m_target_2), value);
	}

	inline static int32_t get_offset_of_method_3() { return static_cast<int32_t>(offsetof(Delegate_t1188392813, ___method_3)); }
	inline intptr_t get_method_3() const { return ___method_3; }
	inline intptr_t* get_address_of_method_3() { return &___method_3; }
	inline void set_method_3(intptr_t value)
	{
		___method_3 = value;
	}

	inline static int32_t get_offset_of_delegate_trampoline_4() { return static_cast<int32_t>(offsetof(Delegate_t1188392813, ___delegate_trampoline_4)); }
	inline intptr_t get_delegate_trampoline_4() const { return ___delegate_trampoline_4; }
	inline intptr_t* get_address_of_delegate_trampoline_4() { return &___delegate_trampoline_4; }
	inline void set_delegate_trampoline_4(intptr_t value)
	{
		___delegate_trampoline_4 = value;
	}

	inline static int32_t get_offset_of_method_code_5() { return static_cast<int32_t>(offsetof(Delegate_t1188392813, ___method_code_5)); }
	inline intptr_t get_method_code_5() const { return ___method_code_5; }
	inline intptr_t* get_address_of_method_code_5() { return &___method_code_5; }
	inline void set_method_code_5(intptr_t value)
	{
		___method_code_5 = value;
	}

	inline static int32_t get_offset_of_method_info_6() { return static_cast<int32_t>(offsetof(Delegate_t1188392813, ___method_info_6)); }
	inline MethodInfo_t * get_method_info_6() const { return ___method_info_6; }
	inline MethodInfo_t ** get_address_of_method_info_6() { return &___method_info_6; }
	inline void set_method_info_6(MethodInfo_t * value)
	{
		___method_info_6 = value;
		Il2CppCodeGenWriteBarrier((&___method_info_6), value);
	}

	inline static int32_t get_offset_of_original_method_info_7() { return static_cast<int32_t>(offsetof(Delegate_t1188392813, ___original_method_info_7)); }
	inline MethodInfo_t * get_original_method_info_7() const { return ___original_method_info_7; }
	inline MethodInfo_t ** get_address_of_original_method_info_7() { return &___original_method_info_7; }
	inline void set_original_method_info_7(MethodInfo_t * value)
	{
		___original_method_info_7 = value;
		Il2CppCodeGenWriteBarrier((&___original_method_info_7), value);
	}

	inline static int32_t get_offset_of_data_8() { return static_cast<int32_t>(offsetof(Delegate_t1188392813, ___data_8)); }
	inline DelegateData_t1677132599 * get_data_8() const { return ___data_8; }
	inline DelegateData_t1677132599 ** get_address_of_data_8() { return &___data_8; }
	inline void set_data_8(DelegateData_t1677132599 * value)
	{
		___data_8 = value;
		Il2CppCodeGenWriteBarrier((&___data_8), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // DELEGATE_T1188392813_H
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
#ifndef OBJECT_T631007953_H
#define OBJECT_T631007953_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Object
struct  Object_t631007953  : public RuntimeObject
{
public:
	// System.IntPtr UnityEngine.Object::m_CachedPtr
	intptr_t ___m_CachedPtr_0;

public:
	inline static int32_t get_offset_of_m_CachedPtr_0() { return static_cast<int32_t>(offsetof(Object_t631007953, ___m_CachedPtr_0)); }
	inline intptr_t get_m_CachedPtr_0() const { return ___m_CachedPtr_0; }
	inline intptr_t* get_address_of_m_CachedPtr_0() { return &___m_CachedPtr_0; }
	inline void set_m_CachedPtr_0(intptr_t value)
	{
		___m_CachedPtr_0 = value;
	}
};

struct Object_t631007953_StaticFields
{
public:
	// System.Int32 UnityEngine.Object::OffsetOfInstanceIDInCPlusPlusObject
	int32_t ___OffsetOfInstanceIDInCPlusPlusObject_1;

public:
	inline static int32_t get_offset_of_OffsetOfInstanceIDInCPlusPlusObject_1() { return static_cast<int32_t>(offsetof(Object_t631007953_StaticFields, ___OffsetOfInstanceIDInCPlusPlusObject_1)); }
	inline int32_t get_OffsetOfInstanceIDInCPlusPlusObject_1() const { return ___OffsetOfInstanceIDInCPlusPlusObject_1; }
	inline int32_t* get_address_of_OffsetOfInstanceIDInCPlusPlusObject_1() { return &___OffsetOfInstanceIDInCPlusPlusObject_1; }
	inline void set_OffsetOfInstanceIDInCPlusPlusObject_1(int32_t value)
	{
		___OffsetOfInstanceIDInCPlusPlusObject_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of UnityEngine.Object
struct Object_t631007953_marshaled_pinvoke
{
	intptr_t ___m_CachedPtr_0;
};
// Native definition for COM marshalling of UnityEngine.Object
struct Object_t631007953_marshaled_com
{
	intptr_t ___m_CachedPtr_0;
};
#endif // OBJECT_T631007953_H
#ifndef TIMESCOPE_T539351503_H
#define TIMESCOPE_T539351503_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.SocialPlatforms.TimeScope
struct  TimeScope_t539351503 
{
public:
	// System.Int32 UnityEngine.SocialPlatforms.TimeScope::value__
	int32_t ___value___1;

public:
	inline static int32_t get_offset_of_value___1() { return static_cast<int32_t>(offsetof(TimeScope_t539351503, ___value___1)); }
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
#endif // TIMESCOPE_T539351503_H
#ifndef USERSCOPE_T604006431_H
#define USERSCOPE_T604006431_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.SocialPlatforms.UserScope
struct  UserScope_t604006431 
{
public:
	// System.Int32 UnityEngine.SocialPlatforms.UserScope::value__
	int32_t ___value___1;

public:
	inline static int32_t get_offset_of_value___1() { return static_cast<int32_t>(offsetof(UserScope_t604006431, ___value___1)); }
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
#endif // USERSCOPE_T604006431_H
#ifndef USERSTATE_T4177058321_H
#define USERSTATE_T4177058321_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.SocialPlatforms.UserState
struct  UserState_t4177058321 
{
public:
	// System.Int32 UnityEngine.SocialPlatforms.UserState::value__
	int32_t ___value___1;

public:
	inline static int32_t get_offset_of_value___1() { return static_cast<int32_t>(offsetof(UserState_t4177058321, ___value___1)); }
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
#endif // USERSTATE_T4177058321_H
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
#ifndef MULTICASTDELEGATE_T_H
#define MULTICASTDELEGATE_T_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.MulticastDelegate
struct  MulticastDelegate_t  : public Delegate_t1188392813
{
public:
	// System.MulticastDelegate System.MulticastDelegate::prev
	MulticastDelegate_t * ___prev_9;
	// System.MulticastDelegate System.MulticastDelegate::kpm_next
	MulticastDelegate_t * ___kpm_next_10;

public:
	inline static int32_t get_offset_of_prev_9() { return static_cast<int32_t>(offsetof(MulticastDelegate_t, ___prev_9)); }
	inline MulticastDelegate_t * get_prev_9() const { return ___prev_9; }
	inline MulticastDelegate_t ** get_address_of_prev_9() { return &___prev_9; }
	inline void set_prev_9(MulticastDelegate_t * value)
	{
		___prev_9 = value;
		Il2CppCodeGenWriteBarrier((&___prev_9), value);
	}

	inline static int32_t get_offset_of_kpm_next_10() { return static_cast<int32_t>(offsetof(MulticastDelegate_t, ___kpm_next_10)); }
	inline MulticastDelegate_t * get_kpm_next_10() const { return ___kpm_next_10; }
	inline MulticastDelegate_t ** get_address_of_kpm_next_10() { return &___kpm_next_10; }
	inline void set_kpm_next_10(MulticastDelegate_t * value)
	{
		___kpm_next_10 = value;
		Il2CppCodeGenWriteBarrier((&___kpm_next_10), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // MULTICASTDELEGATE_T_H
#ifndef LEADERBOARD_T1065076763_H
#define LEADERBOARD_T1065076763_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.SocialPlatforms.Impl.Leaderboard
struct  Leaderboard_t1065076763  : public RuntimeObject
{
public:
	// System.Boolean UnityEngine.SocialPlatforms.Impl.Leaderboard::m_Loading
	bool ___m_Loading_0;
	// UnityEngine.SocialPlatforms.IScore UnityEngine.SocialPlatforms.Impl.Leaderboard::m_LocalUserScore
	RuntimeObject* ___m_LocalUserScore_1;
	// System.UInt32 UnityEngine.SocialPlatforms.Impl.Leaderboard::m_MaxRange
	uint32_t ___m_MaxRange_2;
	// UnityEngine.SocialPlatforms.IScore[] UnityEngine.SocialPlatforms.Impl.Leaderboard::m_Scores
	IScoreU5BU5D_t527871248* ___m_Scores_3;
	// System.String UnityEngine.SocialPlatforms.Impl.Leaderboard::m_Title
	String_t* ___m_Title_4;
	// System.String[] UnityEngine.SocialPlatforms.Impl.Leaderboard::m_UserIDs
	StringU5BU5D_t1281789340* ___m_UserIDs_5;
	// System.String UnityEngine.SocialPlatforms.Impl.Leaderboard::<id>k__BackingField
	String_t* ___U3CidU3Ek__BackingField_6;
	// UnityEngine.SocialPlatforms.UserScope UnityEngine.SocialPlatforms.Impl.Leaderboard::<userScope>k__BackingField
	int32_t ___U3CuserScopeU3Ek__BackingField_7;
	// UnityEngine.SocialPlatforms.Range UnityEngine.SocialPlatforms.Impl.Leaderboard::<range>k__BackingField
	Range_t173988048  ___U3CrangeU3Ek__BackingField_8;
	// UnityEngine.SocialPlatforms.TimeScope UnityEngine.SocialPlatforms.Impl.Leaderboard::<timeScope>k__BackingField
	int32_t ___U3CtimeScopeU3Ek__BackingField_9;

public:
	inline static int32_t get_offset_of_m_Loading_0() { return static_cast<int32_t>(offsetof(Leaderboard_t1065076763, ___m_Loading_0)); }
	inline bool get_m_Loading_0() const { return ___m_Loading_0; }
	inline bool* get_address_of_m_Loading_0() { return &___m_Loading_0; }
	inline void set_m_Loading_0(bool value)
	{
		___m_Loading_0 = value;
	}

	inline static int32_t get_offset_of_m_LocalUserScore_1() { return static_cast<int32_t>(offsetof(Leaderboard_t1065076763, ___m_LocalUserScore_1)); }
	inline RuntimeObject* get_m_LocalUserScore_1() const { return ___m_LocalUserScore_1; }
	inline RuntimeObject** get_address_of_m_LocalUserScore_1() { return &___m_LocalUserScore_1; }
	inline void set_m_LocalUserScore_1(RuntimeObject* value)
	{
		___m_LocalUserScore_1 = value;
		Il2CppCodeGenWriteBarrier((&___m_LocalUserScore_1), value);
	}

	inline static int32_t get_offset_of_m_MaxRange_2() { return static_cast<int32_t>(offsetof(Leaderboard_t1065076763, ___m_MaxRange_2)); }
	inline uint32_t get_m_MaxRange_2() const { return ___m_MaxRange_2; }
	inline uint32_t* get_address_of_m_MaxRange_2() { return &___m_MaxRange_2; }
	inline void set_m_MaxRange_2(uint32_t value)
	{
		___m_MaxRange_2 = value;
	}

	inline static int32_t get_offset_of_m_Scores_3() { return static_cast<int32_t>(offsetof(Leaderboard_t1065076763, ___m_Scores_3)); }
	inline IScoreU5BU5D_t527871248* get_m_Scores_3() const { return ___m_Scores_3; }
	inline IScoreU5BU5D_t527871248** get_address_of_m_Scores_3() { return &___m_Scores_3; }
	inline void set_m_Scores_3(IScoreU5BU5D_t527871248* value)
	{
		___m_Scores_3 = value;
		Il2CppCodeGenWriteBarrier((&___m_Scores_3), value);
	}

	inline static int32_t get_offset_of_m_Title_4() { return static_cast<int32_t>(offsetof(Leaderboard_t1065076763, ___m_Title_4)); }
	inline String_t* get_m_Title_4() const { return ___m_Title_4; }
	inline String_t** get_address_of_m_Title_4() { return &___m_Title_4; }
	inline void set_m_Title_4(String_t* value)
	{
		___m_Title_4 = value;
		Il2CppCodeGenWriteBarrier((&___m_Title_4), value);
	}

	inline static int32_t get_offset_of_m_UserIDs_5() { return static_cast<int32_t>(offsetof(Leaderboard_t1065076763, ___m_UserIDs_5)); }
	inline StringU5BU5D_t1281789340* get_m_UserIDs_5() const { return ___m_UserIDs_5; }
	inline StringU5BU5D_t1281789340** get_address_of_m_UserIDs_5() { return &___m_UserIDs_5; }
	inline void set_m_UserIDs_5(StringU5BU5D_t1281789340* value)
	{
		___m_UserIDs_5 = value;
		Il2CppCodeGenWriteBarrier((&___m_UserIDs_5), value);
	}

	inline static int32_t get_offset_of_U3CidU3Ek__BackingField_6() { return static_cast<int32_t>(offsetof(Leaderboard_t1065076763, ___U3CidU3Ek__BackingField_6)); }
	inline String_t* get_U3CidU3Ek__BackingField_6() const { return ___U3CidU3Ek__BackingField_6; }
	inline String_t** get_address_of_U3CidU3Ek__BackingField_6() { return &___U3CidU3Ek__BackingField_6; }
	inline void set_U3CidU3Ek__BackingField_6(String_t* value)
	{
		___U3CidU3Ek__BackingField_6 = value;
		Il2CppCodeGenWriteBarrier((&___U3CidU3Ek__BackingField_6), value);
	}

	inline static int32_t get_offset_of_U3CuserScopeU3Ek__BackingField_7() { return static_cast<int32_t>(offsetof(Leaderboard_t1065076763, ___U3CuserScopeU3Ek__BackingField_7)); }
	inline int32_t get_U3CuserScopeU3Ek__BackingField_7() const { return ___U3CuserScopeU3Ek__BackingField_7; }
	inline int32_t* get_address_of_U3CuserScopeU3Ek__BackingField_7() { return &___U3CuserScopeU3Ek__BackingField_7; }
	inline void set_U3CuserScopeU3Ek__BackingField_7(int32_t value)
	{
		___U3CuserScopeU3Ek__BackingField_7 = value;
	}

	inline static int32_t get_offset_of_U3CrangeU3Ek__BackingField_8() { return static_cast<int32_t>(offsetof(Leaderboard_t1065076763, ___U3CrangeU3Ek__BackingField_8)); }
	inline Range_t173988048  get_U3CrangeU3Ek__BackingField_8() const { return ___U3CrangeU3Ek__BackingField_8; }
	inline Range_t173988048 * get_address_of_U3CrangeU3Ek__BackingField_8() { return &___U3CrangeU3Ek__BackingField_8; }
	inline void set_U3CrangeU3Ek__BackingField_8(Range_t173988048  value)
	{
		___U3CrangeU3Ek__BackingField_8 = value;
	}

	inline static int32_t get_offset_of_U3CtimeScopeU3Ek__BackingField_9() { return static_cast<int32_t>(offsetof(Leaderboard_t1065076763, ___U3CtimeScopeU3Ek__BackingField_9)); }
	inline int32_t get_U3CtimeScopeU3Ek__BackingField_9() const { return ___U3CtimeScopeU3Ek__BackingField_9; }
	inline int32_t* get_address_of_U3CtimeScopeU3Ek__BackingField_9() { return &___U3CtimeScopeU3Ek__BackingField_9; }
	inline void set_U3CtimeScopeU3Ek__BackingField_9(int32_t value)
	{
		___U3CtimeScopeU3Ek__BackingField_9 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LEADERBOARD_T1065076763_H
#ifndef TEXTURE_T3661962703_H
#define TEXTURE_T3661962703_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Texture
struct  Texture_t3661962703  : public Object_t631007953
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TEXTURE_T3661962703_H
#ifndef USERPROFILE_T3137328177_H
#define USERPROFILE_T3137328177_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.SocialPlatforms.Impl.UserProfile
struct  UserProfile_t3137328177  : public RuntimeObject
{
public:
	// System.String UnityEngine.SocialPlatforms.Impl.UserProfile::m_UserName
	String_t* ___m_UserName_0;
	// System.String UnityEngine.SocialPlatforms.Impl.UserProfile::m_ID
	String_t* ___m_ID_1;
	// System.Boolean UnityEngine.SocialPlatforms.Impl.UserProfile::m_IsFriend
	bool ___m_IsFriend_2;
	// UnityEngine.SocialPlatforms.UserState UnityEngine.SocialPlatforms.Impl.UserProfile::m_State
	int32_t ___m_State_3;
	// UnityEngine.Texture2D UnityEngine.SocialPlatforms.Impl.UserProfile::m_Image
	Texture2D_t3840446185 * ___m_Image_4;

public:
	inline static int32_t get_offset_of_m_UserName_0() { return static_cast<int32_t>(offsetof(UserProfile_t3137328177, ___m_UserName_0)); }
	inline String_t* get_m_UserName_0() const { return ___m_UserName_0; }
	inline String_t** get_address_of_m_UserName_0() { return &___m_UserName_0; }
	inline void set_m_UserName_0(String_t* value)
	{
		___m_UserName_0 = value;
		Il2CppCodeGenWriteBarrier((&___m_UserName_0), value);
	}

	inline static int32_t get_offset_of_m_ID_1() { return static_cast<int32_t>(offsetof(UserProfile_t3137328177, ___m_ID_1)); }
	inline String_t* get_m_ID_1() const { return ___m_ID_1; }
	inline String_t** get_address_of_m_ID_1() { return &___m_ID_1; }
	inline void set_m_ID_1(String_t* value)
	{
		___m_ID_1 = value;
		Il2CppCodeGenWriteBarrier((&___m_ID_1), value);
	}

	inline static int32_t get_offset_of_m_IsFriend_2() { return static_cast<int32_t>(offsetof(UserProfile_t3137328177, ___m_IsFriend_2)); }
	inline bool get_m_IsFriend_2() const { return ___m_IsFriend_2; }
	inline bool* get_address_of_m_IsFriend_2() { return &___m_IsFriend_2; }
	inline void set_m_IsFriend_2(bool value)
	{
		___m_IsFriend_2 = value;
	}

	inline static int32_t get_offset_of_m_State_3() { return static_cast<int32_t>(offsetof(UserProfile_t3137328177, ___m_State_3)); }
	inline int32_t get_m_State_3() const { return ___m_State_3; }
	inline int32_t* get_address_of_m_State_3() { return &___m_State_3; }
	inline void set_m_State_3(int32_t value)
	{
		___m_State_3 = value;
	}

	inline static int32_t get_offset_of_m_Image_4() { return static_cast<int32_t>(offsetof(UserProfile_t3137328177, ___m_Image_4)); }
	inline Texture2D_t3840446185 * get_m_Image_4() const { return ___m_Image_4; }
	inline Texture2D_t3840446185 ** get_address_of_m_Image_4() { return &___m_Image_4; }
	inline void set_m_Image_4(Texture2D_t3840446185 * value)
	{
		___m_Image_4 = value;
		Il2CppCodeGenWriteBarrier((&___m_Image_4), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // USERPROFILE_T3137328177_H
#ifndef SCORE_T1968645328_H
#define SCORE_T1968645328_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.SocialPlatforms.Impl.Score
struct  Score_t1968645328  : public RuntimeObject
{
public:
	// System.DateTime UnityEngine.SocialPlatforms.Impl.Score::m_Date
	DateTime_t3738529785  ___m_Date_0;
	// System.String UnityEngine.SocialPlatforms.Impl.Score::m_FormattedValue
	String_t* ___m_FormattedValue_1;
	// System.String UnityEngine.SocialPlatforms.Impl.Score::m_UserID
	String_t* ___m_UserID_2;
	// System.Int32 UnityEngine.SocialPlatforms.Impl.Score::m_Rank
	int32_t ___m_Rank_3;
	// System.String UnityEngine.SocialPlatforms.Impl.Score::<leaderboardID>k__BackingField
	String_t* ___U3CleaderboardIDU3Ek__BackingField_4;
	// System.Int64 UnityEngine.SocialPlatforms.Impl.Score::<value>k__BackingField
	int64_t ___U3CvalueU3Ek__BackingField_5;

public:
	inline static int32_t get_offset_of_m_Date_0() { return static_cast<int32_t>(offsetof(Score_t1968645328, ___m_Date_0)); }
	inline DateTime_t3738529785  get_m_Date_0() const { return ___m_Date_0; }
	inline DateTime_t3738529785 * get_address_of_m_Date_0() { return &___m_Date_0; }
	inline void set_m_Date_0(DateTime_t3738529785  value)
	{
		___m_Date_0 = value;
	}

	inline static int32_t get_offset_of_m_FormattedValue_1() { return static_cast<int32_t>(offsetof(Score_t1968645328, ___m_FormattedValue_1)); }
	inline String_t* get_m_FormattedValue_1() const { return ___m_FormattedValue_1; }
	inline String_t** get_address_of_m_FormattedValue_1() { return &___m_FormattedValue_1; }
	inline void set_m_FormattedValue_1(String_t* value)
	{
		___m_FormattedValue_1 = value;
		Il2CppCodeGenWriteBarrier((&___m_FormattedValue_1), value);
	}

	inline static int32_t get_offset_of_m_UserID_2() { return static_cast<int32_t>(offsetof(Score_t1968645328, ___m_UserID_2)); }
	inline String_t* get_m_UserID_2() const { return ___m_UserID_2; }
	inline String_t** get_address_of_m_UserID_2() { return &___m_UserID_2; }
	inline void set_m_UserID_2(String_t* value)
	{
		___m_UserID_2 = value;
		Il2CppCodeGenWriteBarrier((&___m_UserID_2), value);
	}

	inline static int32_t get_offset_of_m_Rank_3() { return static_cast<int32_t>(offsetof(Score_t1968645328, ___m_Rank_3)); }
	inline int32_t get_m_Rank_3() const { return ___m_Rank_3; }
	inline int32_t* get_address_of_m_Rank_3() { return &___m_Rank_3; }
	inline void set_m_Rank_3(int32_t value)
	{
		___m_Rank_3 = value;
	}

	inline static int32_t get_offset_of_U3CleaderboardIDU3Ek__BackingField_4() { return static_cast<int32_t>(offsetof(Score_t1968645328, ___U3CleaderboardIDU3Ek__BackingField_4)); }
	inline String_t* get_U3CleaderboardIDU3Ek__BackingField_4() const { return ___U3CleaderboardIDU3Ek__BackingField_4; }
	inline String_t** get_address_of_U3CleaderboardIDU3Ek__BackingField_4() { return &___U3CleaderboardIDU3Ek__BackingField_4; }
	inline void set_U3CleaderboardIDU3Ek__BackingField_4(String_t* value)
	{
		___U3CleaderboardIDU3Ek__BackingField_4 = value;
		Il2CppCodeGenWriteBarrier((&___U3CleaderboardIDU3Ek__BackingField_4), value);
	}

	inline static int32_t get_offset_of_U3CvalueU3Ek__BackingField_5() { return static_cast<int32_t>(offsetof(Score_t1968645328, ___U3CvalueU3Ek__BackingField_5)); }
	inline int64_t get_U3CvalueU3Ek__BackingField_5() const { return ___U3CvalueU3Ek__BackingField_5; }
	inline int64_t* get_address_of_U3CvalueU3Ek__BackingField_5() { return &___U3CvalueU3Ek__BackingField_5; }
	inline void set_U3CvalueU3Ek__BackingField_5(int64_t value)
	{
		___U3CvalueU3Ek__BackingField_5 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SCORE_T1968645328_H
#ifndef ACTION_1_T269755560_H
#define ACTION_1_T269755560_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Action`1<System.Boolean>
struct  Action_1_t269755560  : public MulticastDelegate_t
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ACTION_1_T269755560_H
#ifndef ACTION_1_T1994432444_H
#define ACTION_1_T1994432444_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Action`1<UnityEngine.SocialPlatforms.IAchievementDescription[]>
struct  Action_1_t1994432444  : public MulticastDelegate_t
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ACTION_1_T1994432444_H
#ifndef ACTION_1_T2064805934_H
#define ACTION_1_T2064805934_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Action`1<UnityEngine.SocialPlatforms.IAchievement[]>
struct  Action_1_t2064805934  : public MulticastDelegate_t
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ACTION_1_T2064805934_H
#ifndef COMPARISON_1_T1743576507_H
#define COMPARISON_1_T1743576507_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Comparison`1<UnityEngine.SocialPlatforms.Impl.Score>
struct  Comparison_1_t1743576507  : public MulticastDelegate_t
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // COMPARISON_1_T1743576507_H
#ifndef LOCALUSER_T365094499_H
#define LOCALUSER_T365094499_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.SocialPlatforms.Impl.LocalUser
struct  LocalUser_t365094499  : public UserProfile_t3137328177
{
public:
	// UnityEngine.SocialPlatforms.IUserProfile[] UnityEngine.SocialPlatforms.Impl.LocalUser::m_Friends
	IUserProfileU5BU5D_t909679733* ___m_Friends_5;
	// System.Boolean UnityEngine.SocialPlatforms.Impl.LocalUser::m_Authenticated
	bool ___m_Authenticated_6;
	// System.Boolean UnityEngine.SocialPlatforms.Impl.LocalUser::m_Underage
	bool ___m_Underage_7;

public:
	inline static int32_t get_offset_of_m_Friends_5() { return static_cast<int32_t>(offsetof(LocalUser_t365094499, ___m_Friends_5)); }
	inline IUserProfileU5BU5D_t909679733* get_m_Friends_5() const { return ___m_Friends_5; }
	inline IUserProfileU5BU5D_t909679733** get_address_of_m_Friends_5() { return &___m_Friends_5; }
	inline void set_m_Friends_5(IUserProfileU5BU5D_t909679733* value)
	{
		___m_Friends_5 = value;
		Il2CppCodeGenWriteBarrier((&___m_Friends_5), value);
	}

	inline static int32_t get_offset_of_m_Authenticated_6() { return static_cast<int32_t>(offsetof(LocalUser_t365094499, ___m_Authenticated_6)); }
	inline bool get_m_Authenticated_6() const { return ___m_Authenticated_6; }
	inline bool* get_address_of_m_Authenticated_6() { return &___m_Authenticated_6; }
	inline void set_m_Authenticated_6(bool value)
	{
		___m_Authenticated_6 = value;
	}

	inline static int32_t get_offset_of_m_Underage_7() { return static_cast<int32_t>(offsetof(LocalUser_t365094499, ___m_Underage_7)); }
	inline bool get_m_Underage_7() const { return ___m_Underage_7; }
	inline bool* get_address_of_m_Underage_7() { return &___m_Underage_7; }
	inline void set_m_Underage_7(bool value)
	{
		___m_Underage_7 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LOCALUSER_T365094499_H
#ifndef ACHIEVEMENT_T565359984_H
#define ACHIEVEMENT_T565359984_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.SocialPlatforms.Impl.Achievement
struct  Achievement_t565359984  : public RuntimeObject
{
public:
	// System.Boolean UnityEngine.SocialPlatforms.Impl.Achievement::m_Completed
	bool ___m_Completed_0;
	// System.Boolean UnityEngine.SocialPlatforms.Impl.Achievement::m_Hidden
	bool ___m_Hidden_1;
	// System.DateTime UnityEngine.SocialPlatforms.Impl.Achievement::m_LastReportedDate
	DateTime_t3738529785  ___m_LastReportedDate_2;
	// System.String UnityEngine.SocialPlatforms.Impl.Achievement::<id>k__BackingField
	String_t* ___U3CidU3Ek__BackingField_3;
	// System.Double UnityEngine.SocialPlatforms.Impl.Achievement::<percentCompleted>k__BackingField
	double ___U3CpercentCompletedU3Ek__BackingField_4;

public:
	inline static int32_t get_offset_of_m_Completed_0() { return static_cast<int32_t>(offsetof(Achievement_t565359984, ___m_Completed_0)); }
	inline bool get_m_Completed_0() const { return ___m_Completed_0; }
	inline bool* get_address_of_m_Completed_0() { return &___m_Completed_0; }
	inline void set_m_Completed_0(bool value)
	{
		___m_Completed_0 = value;
	}

	inline static int32_t get_offset_of_m_Hidden_1() { return static_cast<int32_t>(offsetof(Achievement_t565359984, ___m_Hidden_1)); }
	inline bool get_m_Hidden_1() const { return ___m_Hidden_1; }
	inline bool* get_address_of_m_Hidden_1() { return &___m_Hidden_1; }
	inline void set_m_Hidden_1(bool value)
	{
		___m_Hidden_1 = value;
	}

	inline static int32_t get_offset_of_m_LastReportedDate_2() { return static_cast<int32_t>(offsetof(Achievement_t565359984, ___m_LastReportedDate_2)); }
	inline DateTime_t3738529785  get_m_LastReportedDate_2() const { return ___m_LastReportedDate_2; }
	inline DateTime_t3738529785 * get_address_of_m_LastReportedDate_2() { return &___m_LastReportedDate_2; }
	inline void set_m_LastReportedDate_2(DateTime_t3738529785  value)
	{
		___m_LastReportedDate_2 = value;
	}

	inline static int32_t get_offset_of_U3CidU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(Achievement_t565359984, ___U3CidU3Ek__BackingField_3)); }
	inline String_t* get_U3CidU3Ek__BackingField_3() const { return ___U3CidU3Ek__BackingField_3; }
	inline String_t** get_address_of_U3CidU3Ek__BackingField_3() { return &___U3CidU3Ek__BackingField_3; }
	inline void set_U3CidU3Ek__BackingField_3(String_t* value)
	{
		___U3CidU3Ek__BackingField_3 = value;
		Il2CppCodeGenWriteBarrier((&___U3CidU3Ek__BackingField_3), value);
	}

	inline static int32_t get_offset_of_U3CpercentCompletedU3Ek__BackingField_4() { return static_cast<int32_t>(offsetof(Achievement_t565359984, ___U3CpercentCompletedU3Ek__BackingField_4)); }
	inline double get_U3CpercentCompletedU3Ek__BackingField_4() const { return ___U3CpercentCompletedU3Ek__BackingField_4; }
	inline double* get_address_of_U3CpercentCompletedU3Ek__BackingField_4() { return &___U3CpercentCompletedU3Ek__BackingField_4; }
	inline void set_U3CpercentCompletedU3Ek__BackingField_4(double value)
	{
		___U3CpercentCompletedU3Ek__BackingField_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ACHIEVEMENT_T565359984_H
#ifndef TEXTURE2D_T3840446185_H
#define TEXTURE2D_T3840446185_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Texture2D
struct  Texture2D_t3840446185  : public Texture_t3661962703
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TEXTURE2D_T3840446185_H
// System.Object[]
struct ObjectU5BU5D_t2843939325  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) RuntimeObject * m_Items[1];

public:
	inline RuntimeObject * GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline RuntimeObject ** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, RuntimeObject * value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
	inline RuntimeObject * GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline RuntimeObject ** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, RuntimeObject * value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
};
// UnityEngine.SocialPlatforms.Impl.Score[]
struct ScoreU5BU5D_t972561905  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) Score_t1968645328 * m_Items[1];

public:
	inline Score_t1968645328 * GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Score_t1968645328 ** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Score_t1968645328 * value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
	inline Score_t1968645328 * GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Score_t1968645328 ** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Score_t1968645328 * value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
};
// UnityEngine.SocialPlatforms.IScore[]
struct IScoreU5BU5D_t527871248  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) RuntimeObject* m_Items[1];

public:
	inline RuntimeObject* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline RuntimeObject** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, RuntimeObject* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
	inline RuntimeObject* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline RuntimeObject** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, RuntimeObject* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
};
// System.String[]
struct StringU5BU5D_t1281789340  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) String_t* m_Items[1];

public:
	inline String_t* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline String_t** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, String_t* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
	inline String_t* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline String_t** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, String_t* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
};
// UnityEngine.SocialPlatforms.Impl.UserProfile[]
struct UserProfileU5BU5D_t1895532524  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) UserProfile_t3137328177 * m_Items[1];

public:
	inline UserProfile_t3137328177 * GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline UserProfile_t3137328177 ** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, UserProfile_t3137328177 * value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
	inline UserProfile_t3137328177 * GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline UserProfile_t3137328177 ** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, UserProfile_t3137328177 * value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
};
// UnityEngine.SocialPlatforms.IUserProfile[]
struct IUserProfileU5BU5D_t909679733  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) RuntimeObject* m_Items[1];

public:
	inline RuntimeObject* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline RuntimeObject** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, RuntimeObject* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
	inline RuntimeObject* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline RuntimeObject** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, RuntimeObject* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
};
// UnityEngine.SocialPlatforms.Impl.AchievementDescription[]
struct AchievementDescriptionU5BU5D_t1886727686  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) AchievementDescription_t3217594527 * m_Items[1];

public:
	inline AchievementDescription_t3217594527 * GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline AchievementDescription_t3217594527 ** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, AchievementDescription_t3217594527 * value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
	inline AchievementDescription_t3217594527 * GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline AchievementDescription_t3217594527 ** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, AchievementDescription_t3217594527 * value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
};
// UnityEngine.SocialPlatforms.IAchievementDescription[]
struct IAchievementDescriptionU5BU5D_t1821964849  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) RuntimeObject* m_Items[1];

public:
	inline RuntimeObject* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline RuntimeObject** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, RuntimeObject* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
	inline RuntimeObject* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline RuntimeObject** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, RuntimeObject* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
};
// UnityEngine.SocialPlatforms.Impl.Achievement[]
struct AchievementU5BU5D_t1511134929  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) Achievement_t565359984 * m_Items[1];

public:
	inline Achievement_t565359984 * GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Achievement_t565359984 ** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Achievement_t565359984 * value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
	inline Achievement_t565359984 * GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Achievement_t565359984 ** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Achievement_t565359984 * value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
};
// UnityEngine.SocialPlatforms.IAchievement[]
struct IAchievementU5BU5D_t1892338339  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) RuntimeObject* m_Items[1];

public:
	inline RuntimeObject* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline RuntimeObject** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, RuntimeObject* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
	inline RuntimeObject* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline RuntimeObject** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, RuntimeObject* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
};


// System.Void System.Collections.Generic.List`1<System.Object>::.ctor()
extern "C"  void List_1__ctor_m2321703786_gshared (List_1_t257213610 * __this, const RuntimeMethod* method);
// System.Void System.Action`1<System.Boolean>::Invoke(!0)
extern "C"  void Action_1_Invoke_m1933767679_gshared (Action_1_t269755560 * __this, bool p0, const RuntimeMethod* method);
// System.Collections.Generic.List`1/Enumerator<!0> System.Collections.Generic.List`1<System.Object>::GetEnumerator()
extern "C"  Enumerator_t2146457487  List_1_GetEnumerator_m2930774921_gshared (List_1_t257213610 * __this, const RuntimeMethod* method);
// !0 System.Collections.Generic.List`1/Enumerator<System.Object>::get_Current()
extern "C"  RuntimeObject * Enumerator_get_Current_m470245444_gshared (Enumerator_t2146457487 * __this, const RuntimeMethod* method);
// System.Boolean System.Collections.Generic.List`1/Enumerator<System.Object>::MoveNext()
extern "C"  bool Enumerator_MoveNext_m2142368520_gshared (Enumerator_t2146457487 * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1/Enumerator<System.Object>::Dispose()
extern "C"  void Enumerator_Dispose_m3007748546_gshared (Enumerator_t2146457487 * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<System.Object>::Add(!0)
extern "C"  void List_1_Add_m3338814081_gshared (List_1_t257213610 * __this, RuntimeObject * p0, const RuntimeMethod* method);
// !0[] System.Collections.Generic.List`1<System.Object>::ToArray()
extern "C"  ObjectU5BU5D_t2843939325* List_1_ToArray_m4168020446_gshared (List_1_t257213610 * __this, const RuntimeMethod* method);
// System.Void System.Action`1<System.Object>::Invoke(!0)
extern "C"  void Action_1_Invoke_m2461023210_gshared (Action_1_t3252573759 * __this, RuntimeObject * p0, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<System.Object>::.ctor(System.Collections.Generic.IEnumerable`1<!0>)
extern "C"  void List_1__ctor_m1328752868_gshared (List_1_t257213610 * __this, RuntimeObject* p0, const RuntimeMethod* method);
// System.Void System.Comparison`1<System.Object>::.ctor(System.Object,System.IntPtr)
extern "C"  void Comparison_1__ctor_m793514796_gshared (Comparison_1_t2855037343 * __this, RuntimeObject * p0, intptr_t p1, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<System.Object>::Sort(System.Comparison`1<!0>)
extern "C"  void List_1_Sort_m2076177611_gshared (List_1_t257213610 * __this, Comparison_1_t2855037343 * p0, const RuntimeMethod* method);
// !0 System.Collections.Generic.List`1<System.Object>::get_Item(System.Int32)
extern "C"  RuntimeObject * List_1_get_Item_m2287542950_gshared (List_1_t257213610 * __this, int32_t p0, const RuntimeMethod* method);
// System.Int32 System.Collections.Generic.List`1<System.Object>::get_Count()
extern "C"  int32_t List_1_get_Count_m2934127733_gshared (List_1_t257213610 * __this, const RuntimeMethod* method);

// UnityEngine.SocialPlatforms.ISocialPlatform UnityEngine.SocialPlatforms.ActivePlatform::get_Instance()
extern "C"  RuntimeObject* ActivePlatform_get_Instance_m3727118555 (RuntimeObject * __this /* static, unused */, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// UnityEngine.SocialPlatforms.ISocialPlatform UnityEngine.Social::get_Active()
extern "C"  RuntimeObject* Social_get_Active_m1353875849 (RuntimeObject * __this /* static, unused */, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// UnityEngine.SocialPlatforms.ISocialPlatform UnityEngine.SocialPlatforms.ActivePlatform::SelectSocialPlatform()
extern "C"  RuntimeObject* ActivePlatform_SelectSocialPlatform_m1059707725 (RuntimeObject * __this /* static, unused */, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.SocialPlatforms.Local::.ctor()
extern "C"  void Local__ctor_m3461781796 (Local_t4068483442 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Object::.ctor()
extern "C"  void Object__ctor_m297566312 (RuntimeObject * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.SocialPlatforms.Impl.Achievement::set_id(System.String)
extern "C"  void Achievement_set_id_m2790336588 (Achievement_t565359984 * __this, String_t* ___value0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.SocialPlatforms.Impl.Achievement::set_percentCompleted(System.Double)
extern "C"  void Achievement_set_percentCompleted_m1653565997 (Achievement_t565359984 * __this, double ___value0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String UnityEngine.SocialPlatforms.Impl.Achievement::get_id()
extern "C"  String_t* Achievement_get_id_m89809597 (Achievement_t565359984 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Double UnityEngine.SocialPlatforms.Impl.Achievement::get_percentCompleted()
extern "C"  double Achievement_get_percentCompleted_m2110138160 (Achievement_t565359984 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean UnityEngine.SocialPlatforms.Impl.Achievement::get_completed()
extern "C"  bool Achievement_get_completed_m1377700980 (Achievement_t565359984 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean UnityEngine.SocialPlatforms.Impl.Achievement::get_hidden()
extern "C"  bool Achievement_get_hidden_m4063998500 (Achievement_t565359984 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.DateTime UnityEngine.SocialPlatforms.Impl.Achievement::get_lastReportedDate()
extern "C"  DateTime_t3738529785  Achievement_get_lastReportedDate_m2200074798 (Achievement_t565359984 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String System.String::Concat(System.Object[])
extern "C"  String_t* String_Concat_m2971454694 (RuntimeObject * __this /* static, unused */, ObjectU5BU5D_t2843939325* p0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.SocialPlatforms.Impl.AchievementDescription::set_id(System.String)
extern "C"  void AchievementDescription_set_id_m751528388 (AchievementDescription_t3217594527 * __this, String_t* ___value0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String UnityEngine.SocialPlatforms.Impl.AchievementDescription::get_id()
extern "C"  String_t* AchievementDescription_get_id_m985811184 (AchievementDescription_t3217594527 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String UnityEngine.SocialPlatforms.Impl.AchievementDescription::get_title()
extern "C"  String_t* AchievementDescription_get_title_m417729785 (AchievementDescription_t3217594527 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String UnityEngine.SocialPlatforms.Impl.AchievementDescription::get_achievedDescription()
extern "C"  String_t* AchievementDescription_get_achievedDescription_m387769685 (AchievementDescription_t3217594527 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String UnityEngine.SocialPlatforms.Impl.AchievementDescription::get_unachievedDescription()
extern "C"  String_t* AchievementDescription_get_unachievedDescription_m690845291 (AchievementDescription_t3217594527 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Int32 UnityEngine.SocialPlatforms.Impl.AchievementDescription::get_points()
extern "C"  int32_t AchievementDescription_get_points_m4273978152 (AchievementDescription_t3217594527 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean UnityEngine.SocialPlatforms.Impl.AchievementDescription::get_hidden()
extern "C"  bool AchievementDescription_get_hidden_m1497330198 (AchievementDescription_t3217594527 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.SocialPlatforms.Impl.Leaderboard::set_id(System.String)
extern "C"  void Leaderboard_set_id_m3990768853 (Leaderboard_t1065076763 * __this, String_t* ___value0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.SocialPlatforms.Range::.ctor(System.Int32,System.Int32)
extern "C"  void Range__ctor_m3975982763 (Range_t173988048 * __this, int32_t ___fromValue0, int32_t ___valueCount1, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.SocialPlatforms.Impl.Leaderboard::set_range(UnityEngine.SocialPlatforms.Range)
extern "C"  void Leaderboard_set_range_m1868499957 (Leaderboard_t1065076763 * __this, Range_t173988048  ___value0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.SocialPlatforms.Impl.Leaderboard::set_userScope(UnityEngine.SocialPlatforms.UserScope)
extern "C"  void Leaderboard_set_userScope_m4131851828 (Leaderboard_t1065076763 * __this, int32_t ___value0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.SocialPlatforms.Impl.Leaderboard::set_timeScope(UnityEngine.SocialPlatforms.TimeScope)
extern "C"  void Leaderboard_set_timeScope_m3468042286 (Leaderboard_t1065076763 * __this, int32_t ___value0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.SocialPlatforms.Impl.Score::.ctor(System.String,System.Int64)
extern "C"  void Score__ctor_m2390363112 (Score_t1968645328 * __this, String_t* ___leaderboardID0, int64_t ___value1, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String UnityEngine.SocialPlatforms.Impl.Leaderboard::get_id()
extern "C"  String_t* Leaderboard_get_id_m4258535896 (Leaderboard_t1065076763 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// UnityEngine.SocialPlatforms.Range UnityEngine.SocialPlatforms.Impl.Leaderboard::get_range()
extern "C"  Range_t173988048  Leaderboard_get_range_m167968592 (Leaderboard_t1065076763 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// UnityEngine.SocialPlatforms.UserScope UnityEngine.SocialPlatforms.Impl.Leaderboard::get_userScope()
extern "C"  int32_t Leaderboard_get_userScope_m4090697307 (Leaderboard_t1065076763 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// UnityEngine.SocialPlatforms.TimeScope UnityEngine.SocialPlatforms.Impl.Leaderboard::get_timeScope()
extern "C"  int32_t Leaderboard_get_timeScope_m4226979676 (Leaderboard_t1065076763 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.SocialPlatforms.Impl.UserProfile::.ctor()
extern "C"  void UserProfile__ctor_m3353918255 (UserProfile_t3137328177 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.DateTime System.DateTime::get_Now()
extern "C"  DateTime_t3738529785  DateTime_get_Now_m1277138875 (RuntimeObject * __this /* static, unused */, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.SocialPlatforms.Impl.Score::.ctor(System.String,System.Int64,System.String,System.DateTime,System.String,System.Int32)
extern "C"  void Score__ctor_m1554947855 (Score_t1968645328 * __this, String_t* ___leaderboardID0, int64_t ___value1, String_t* ___userID2, DateTime_t3738529785  ___date3, String_t* ___formattedValue4, int32_t ___rank5, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.SocialPlatforms.Impl.Score::set_leaderboardID(System.String)
extern "C"  void Score_set_leaderboardID_m268558918 (Score_t1968645328 * __this, String_t* ___value0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.SocialPlatforms.Impl.Score::set_value(System.Int64)
extern "C"  void Score_set_value_m935893699 (Score_t1968645328 * __this, int64_t ___value0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Int64 UnityEngine.SocialPlatforms.Impl.Score::get_value()
extern "C"  int64_t Score_get_value_m3180422307 (Score_t1968645328 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String UnityEngine.SocialPlatforms.Impl.Score::get_leaderboardID()
extern "C"  String_t* Score_get_leaderboardID_m3645107971 (Score_t1968645328 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.Texture2D::.ctor(System.Int32,System.Int32)
extern "C"  void Texture2D__ctor_m373113269 (Texture2D_t3840446185 * __this, int32_t p0, int32_t p1, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String UnityEngine.SocialPlatforms.Impl.UserProfile::get_id()
extern "C"  String_t* UserProfile_get_id_m3178143816 (UserProfile_t3137328177 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String UnityEngine.SocialPlatforms.Impl.UserProfile::get_userName()
extern "C"  String_t* UserProfile_get_userName_m3063744753 (UserProfile_t3137328177 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean UnityEngine.SocialPlatforms.Impl.UserProfile::get_isFriend()
extern "C"  bool UserProfile_get_isFriend_m3838691482 (UserProfile_t3137328177 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// UnityEngine.SocialPlatforms.UserState UnityEngine.SocialPlatforms.Impl.UserProfile::get_state()
extern "C"  int32_t UserProfile_get_state_m3340793320 (UserProfile_t3137328177 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Collections.Generic.List`1<UnityEngine.SocialPlatforms.Impl.UserProfile>::.ctor()
#define List_1__ctor_m973695318(__this, method) ((  void (*) (List_1_t314435623 *, const RuntimeMethod*))List_1__ctor_m2321703786_gshared)(__this, method)
// System.Void System.Collections.Generic.List`1<UnityEngine.SocialPlatforms.Impl.AchievementDescription>::.ctor()
#define List_1__ctor_m3689826338(__this, method) ((  void (*) (List_1_t394701973 *, const RuntimeMethod*))List_1__ctor_m2321703786_gshared)(__this, method)
// System.Void System.Collections.Generic.List`1<UnityEngine.SocialPlatforms.Impl.Achievement>::.ctor()
#define List_1__ctor_m1836006746(__this, method) ((  void (*) (List_1_t2037434726 *, const RuntimeMethod*))List_1__ctor_m2321703786_gshared)(__this, method)
// System.Void System.Collections.Generic.List`1<UnityEngine.SocialPlatforms.Impl.Leaderboard>::.ctor()
#define List_1__ctor_m1889483756(__this, method) ((  void (*) (List_1_t2537151505 *, const RuntimeMethod*))List_1__ctor_m2321703786_gshared)(__this, method)
// System.Void UnityEngine.SocialPlatforms.Impl.LocalUser::.ctor()
extern "C"  void LocalUser__ctor_m4260307073 (LocalUser_t365094499 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// UnityEngine.Texture2D UnityEngine.SocialPlatforms.Local::CreateDummyTexture(System.Int32,System.Int32)
extern "C"  Texture2D_t3840446185 * Local_CreateDummyTexture_m3769606019 (Local_t4068483442 * __this, int32_t ___width0, int32_t ___height1, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.SocialPlatforms.Local::PopulateStaticData()
extern "C"  void Local_PopulateStaticData_m916798409 (Local_t4068483442 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.SocialPlatforms.Impl.LocalUser::SetAuthenticated(System.Boolean)
extern "C"  void LocalUser_SetAuthenticated_m3352566618 (LocalUser_t365094499 * __this, bool ___value0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.SocialPlatforms.Impl.LocalUser::SetUnderage(System.Boolean)
extern "C"  void LocalUser_SetUnderage_m1848352351 (LocalUser_t365094499 * __this, bool ___value0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.SocialPlatforms.Impl.UserProfile::SetUserID(System.String)
extern "C"  void UserProfile_SetUserID_m1137218839 (UserProfile_t3137328177 * __this, String_t* ___id0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.SocialPlatforms.Impl.UserProfile::SetUserName(System.String)
extern "C"  void UserProfile_SetUserName_m1732526939 (UserProfile_t3137328177 * __this, String_t* ___name0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.SocialPlatforms.Impl.UserProfile::SetImage(UnityEngine.Texture2D)
extern "C"  void UserProfile_SetImage_m418239758 (UserProfile_t3137328177 * __this, Texture2D_t3840446185 * ___image0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Action`1<System.Boolean>::Invoke(!0)
#define Action_1_Invoke_m1933767679(__this, p0, method) ((  void (*) (Action_1_t269755560 *, bool, const RuntimeMethod*))Action_1_Invoke_m1933767679_gshared)(__this, p0, method)
// System.Boolean UnityEngine.SocialPlatforms.Local::VerifyUser()
extern "C"  bool Local_VerifyUser_m2348500446 (Local_t4068483442 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Collections.Generic.List`1/Enumerator<!0> System.Collections.Generic.List`1<UnityEngine.SocialPlatforms.Impl.Achievement>::GetEnumerator()
#define List_1_GetEnumerator_m2680008813(__this, method) ((  Enumerator_t3926678603  (*) (List_1_t2037434726 *, const RuntimeMethod*))List_1_GetEnumerator_m2930774921_gshared)(__this, method)
// !0 System.Collections.Generic.List`1/Enumerator<UnityEngine.SocialPlatforms.Impl.Achievement>::get_Current()
#define Enumerator_get_Current_m2947874382(__this, method) ((  Achievement_t565359984 * (*) (Enumerator_t3926678603 *, const RuntimeMethod*))Enumerator_get_Current_m470245444_gshared)(__this, method)
// System.Boolean System.String::op_Equality(System.String,System.String)
extern "C"  bool String_op_Equality_m920492651 (RuntimeObject * __this /* static, unused */, String_t* p0, String_t* p1, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.SocialPlatforms.Impl.Achievement::SetCompleted(System.Boolean)
extern "C"  void Achievement_SetCompleted_m2745299806 (Achievement_t565359984 * __this, bool ___value0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.SocialPlatforms.Impl.Achievement::SetHidden(System.Boolean)
extern "C"  void Achievement_SetHidden_m3652603746 (Achievement_t565359984 * __this, bool ___value0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.SocialPlatforms.Impl.Achievement::SetLastReportedDate(System.DateTime)
extern "C"  void Achievement_SetLastReportedDate_m563615391 (Achievement_t565359984 * __this, DateTime_t3738529785  ___date0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean System.Collections.Generic.List`1/Enumerator<UnityEngine.SocialPlatforms.Impl.Achievement>::MoveNext()
#define Enumerator_MoveNext_m2057277239(__this, method) ((  bool (*) (Enumerator_t3926678603 *, const RuntimeMethod*))Enumerator_MoveNext_m2142368520_gshared)(__this, method)
// System.Void System.Collections.Generic.List`1/Enumerator<UnityEngine.SocialPlatforms.Impl.Achievement>::Dispose()
#define Enumerator_Dispose_m3795629826(__this, method) ((  void (*) (Enumerator_t3926678603 *, const RuntimeMethod*))Enumerator_Dispose_m3007748546_gshared)(__this, method)
// System.Collections.Generic.List`1/Enumerator<!0> System.Collections.Generic.List`1<UnityEngine.SocialPlatforms.Impl.AchievementDescription>::GetEnumerator()
#define List_1_GetEnumerator_m3287167671(__this, method) ((  Enumerator_t2283945850  (*) (List_1_t394701973 *, const RuntimeMethod*))List_1_GetEnumerator_m2930774921_gshared)(__this, method)
// !0 System.Collections.Generic.List`1/Enumerator<UnityEngine.SocialPlatforms.Impl.AchievementDescription>::get_Current()
#define Enumerator_get_Current_m578560357(__this, method) ((  AchievementDescription_t3217594527 * (*) (Enumerator_t2283945850 *, const RuntimeMethod*))Enumerator_get_Current_m470245444_gshared)(__this, method)
// System.Void UnityEngine.SocialPlatforms.Impl.Achievement::.ctor(System.String,System.Double,System.Boolean,System.Boolean,System.DateTime)
extern "C"  void Achievement__ctor_m2166901798 (Achievement_t565359984 * __this, String_t* ___id0, double ___percentCompleted1, bool ___completed2, bool ___hidden3, DateTime_t3738529785  ___lastReportedDate4, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Collections.Generic.List`1<UnityEngine.SocialPlatforms.Impl.Achievement>::Add(!0)
#define List_1_Add_m4026348786(__this, p0, method) ((  void (*) (List_1_t2037434726 *, Achievement_t565359984 *, const RuntimeMethod*))List_1_Add_m3338814081_gshared)(__this, p0, method)
// System.Boolean System.Collections.Generic.List`1/Enumerator<UnityEngine.SocialPlatforms.Impl.AchievementDescription>::MoveNext()
#define Enumerator_MoveNext_m1380577720(__this, method) ((  bool (*) (Enumerator_t2283945850 *, const RuntimeMethod*))Enumerator_MoveNext_m2142368520_gshared)(__this, method)
// System.Void System.Collections.Generic.List`1/Enumerator<UnityEngine.SocialPlatforms.Impl.AchievementDescription>::Dispose()
#define Enumerator_Dispose_m228566194(__this, method) ((  void (*) (Enumerator_t2283945850 *, const RuntimeMethod*))Enumerator_Dispose_m3007748546_gshared)(__this, method)
// System.Void UnityEngine.Debug::LogError(System.Object)
extern "C"  void Debug_LogError_m2850623458 (RuntimeObject * __this /* static, unused */, RuntimeObject * p0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// !0[] System.Collections.Generic.List`1<UnityEngine.SocialPlatforms.Impl.AchievementDescription>::ToArray()
#define List_1_ToArray_m3141863218(__this, method) ((  AchievementDescriptionU5BU5D_t1886727686* (*) (List_1_t394701973 *, const RuntimeMethod*))List_1_ToArray_m4168020446_gshared)(__this, method)
// System.Void System.Action`1<UnityEngine.SocialPlatforms.IAchievementDescription[]>::Invoke(!0)
#define Action_1_Invoke_m1979208465(__this, p0, method) ((  void (*) (Action_1_t1994432444 *, IAchievementDescriptionU5BU5D_t1821964849*, const RuntimeMethod*))Action_1_Invoke_m2461023210_gshared)(__this, p0, method)
// !0[] System.Collections.Generic.List`1<UnityEngine.SocialPlatforms.Impl.Achievement>::ToArray()
#define List_1_ToArray_m4122937214(__this, method) ((  AchievementU5BU5D_t1511134929* (*) (List_1_t2037434726 *, const RuntimeMethod*))List_1_ToArray_m4168020446_gshared)(__this, method)
// System.Void System.Action`1<UnityEngine.SocialPlatforms.IAchievement[]>::Invoke(!0)
#define Action_1_Invoke_m24007936(__this, p0, method) ((  void (*) (Action_1_t2064805934 *, IAchievementU5BU5D_t1892338339*, const RuntimeMethod*))Action_1_Invoke_m2461023210_gshared)(__this, p0, method)
// System.Collections.Generic.List`1/Enumerator<!0> System.Collections.Generic.List`1<UnityEngine.SocialPlatforms.Impl.Leaderboard>::GetEnumerator()
#define List_1_GetEnumerator_m3274601223(__this, method) ((  Enumerator_t131428086  (*) (List_1_t2537151505 *, const RuntimeMethod*))List_1_GetEnumerator_m2930774921_gshared)(__this, method)
// !0 System.Collections.Generic.List`1/Enumerator<UnityEngine.SocialPlatforms.Impl.Leaderboard>::get_Current()
#define Enumerator_get_Current_m1590304878(__this, method) ((  Leaderboard_t1065076763 * (*) (Enumerator_t131428086 *, const RuntimeMethod*))Enumerator_get_Current_m470245444_gshared)(__this, method)
// UnityEngine.SocialPlatforms.IScore[] UnityEngine.SocialPlatforms.Impl.Leaderboard::get_scores()
extern "C"  IScoreU5BU5D_t527871248* Leaderboard_get_scores_m1529761529 (Leaderboard_t1065076763 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Collections.Generic.List`1<UnityEngine.SocialPlatforms.Impl.Score>::.ctor(System.Collections.Generic.IEnumerable`1<!0>)
#define List_1__ctor_m176386895(__this, p0, method) ((  void (*) (List_1_t3440720070 *, RuntimeObject*, const RuntimeMethod*))List_1__ctor_m1328752868_gshared)(__this, p0, method)
// UnityEngine.SocialPlatforms.ILocalUser UnityEngine.SocialPlatforms.Local::get_localUser()
extern "C"  RuntimeObject* Local_get_localUser_m1583274769 (Local_t4068483442 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String System.String::Concat(System.Object,System.Object)
extern "C"  String_t* String_Concat_m904156431 (RuntimeObject * __this /* static, unused */, RuntimeObject * p0, RuntimeObject * p1, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Collections.Generic.List`1<UnityEngine.SocialPlatforms.Impl.Score>::Add(!0)
#define List_1_Add_m1702244787(__this, p0, method) ((  void (*) (List_1_t3440720070 *, Score_t1968645328 *, const RuntimeMethod*))List_1_Add_m3338814081_gshared)(__this, p0, method)
// !0[] System.Collections.Generic.List`1<UnityEngine.SocialPlatforms.Impl.Score>::ToArray()
#define List_1_ToArray_m2845752048(__this, method) ((  ScoreU5BU5D_t972561905* (*) (List_1_t3440720070 *, const RuntimeMethod*))List_1_ToArray_m4168020446_gshared)(__this, method)
// System.Void UnityEngine.SocialPlatforms.Impl.Leaderboard::SetScores(UnityEngine.SocialPlatforms.IScore[])
extern "C"  void Leaderboard_SetScores_m2163784072 (Leaderboard_t1065076763 * __this, IScoreU5BU5D_t527871248* ___scores0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean System.Collections.Generic.List`1/Enumerator<UnityEngine.SocialPlatforms.Impl.Leaderboard>::MoveNext()
#define Enumerator_MoveNext_m3184043996(__this, method) ((  bool (*) (Enumerator_t131428086 *, const RuntimeMethod*))Enumerator_MoveNext_m2142368520_gshared)(__this, method)
// System.Void System.Collections.Generic.List`1/Enumerator<UnityEngine.SocialPlatforms.Impl.Leaderboard>::Dispose()
#define Enumerator_Dispose_m1743516632(__this, method) ((  void (*) (Enumerator_t131428086 *, const RuntimeMethod*))Enumerator_Dispose_m3007748546_gshared)(__this, method)
// System.String UnityEngine.SocialPlatforms.Impl.Leaderboard::get_title()
extern "C"  String_t* Leaderboard_get_title_m3614214113 (Leaderboard_t1065076763 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.SocialPlatforms.Impl.Leaderboard::SetTitle(System.String)
extern "C"  void Leaderboard_SetTitle_m459905577 (Leaderboard_t1065076763 * __this, String_t* ___title0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.SocialPlatforms.Impl.Leaderboard::SetMaxRange(System.UInt32)
extern "C"  void Leaderboard_SetMaxRange_m629679481 (Leaderboard_t1065076763 * __this, uint32_t ___maxRange0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.SocialPlatforms.Local::SortScores(UnityEngine.SocialPlatforms.Impl.Leaderboard)
extern "C"  void Local_SortScores_m3988362938 (Local_t4068483442 * __this, Leaderboard_t1065076763 * ___board0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.SocialPlatforms.Local::SetLocalPlayerScore(UnityEngine.SocialPlatforms.Impl.Leaderboard)
extern "C"  void Local_SetLocalPlayerScore_m2220463184 (Local_t4068483442 * __this, Leaderboard_t1065076763 * ___board0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Comparison`1<UnityEngine.SocialPlatforms.Impl.Score>::.ctor(System.Object,System.IntPtr)
#define Comparison_1__ctor_m2373250861(__this, p0, p1, method) ((  void (*) (Comparison_1_t1743576507 *, RuntimeObject *, intptr_t, const RuntimeMethod*))Comparison_1__ctor_m793514796_gshared)(__this, p0, p1, method)
// System.Void System.Collections.Generic.List`1<UnityEngine.SocialPlatforms.Impl.Score>::Sort(System.Comparison`1<!0>)
#define List_1_Sort_m1667366135(__this, p0, method) ((  void (*) (List_1_t3440720070 *, Comparison_1_t1743576507 *, const RuntimeMethod*))List_1_Sort_m2076177611_gshared)(__this, p0, method)
// !0 System.Collections.Generic.List`1<UnityEngine.SocialPlatforms.Impl.Score>::get_Item(System.Int32)
#define List_1_get_Item_m3843832117(__this, p0, method) ((  Score_t1968645328 * (*) (List_1_t3440720070 *, int32_t, const RuntimeMethod*))List_1_get_Item_m2287542950_gshared)(__this, p0, method)
// System.Void UnityEngine.SocialPlatforms.Impl.Score::SetRank(System.Int32)
extern "C"  void Score_SetRank_m588673792 (Score_t1968645328 * __this, int32_t ___rank0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Int32 System.Collections.Generic.List`1<UnityEngine.SocialPlatforms.Impl.Score>::get_Count()
#define List_1_get_Count_m1172671670(__this, method) ((  int32_t (*) (List_1_t3440720070 *, const RuntimeMethod*))List_1_get_Count_m2934127733_gshared)(__this, method)
// System.String UnityEngine.SocialPlatforms.Impl.Score::get_userID()
extern "C"  String_t* Score_get_userID_m602877400 (Score_t1968645328 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.SocialPlatforms.Impl.Leaderboard::SetLocalUserScore(UnityEngine.SocialPlatforms.IScore)
extern "C"  void Leaderboard_SetLocalUserScore_m3569886016 (Leaderboard_t1065076763 * __this, RuntimeObject* ___score0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.Debug::Log(System.Object)
extern "C"  void Debug_Log_m4051431634 (RuntimeObject * __this /* static, unused */, RuntimeObject * p0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.SocialPlatforms.Impl.Leaderboard::.ctor()
extern "C"  void Leaderboard__ctor_m1030108446 (Leaderboard_t1065076763 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.SocialPlatforms.Impl.UserProfile::.ctor(System.String,System.String,System.Boolean,UnityEngine.SocialPlatforms.UserState,UnityEngine.Texture2D)
extern "C"  void UserProfile__ctor_m2409346676 (UserProfile_t3137328177 * __this, String_t* ___name0, String_t* ___id1, bool ___friend2, int32_t ___state3, Texture2D_t3840446185 * ___image4, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Collections.Generic.List`1<UnityEngine.SocialPlatforms.Impl.UserProfile>::Add(!0)
#define List_1_Add_m1578522892(__this, p0, method) ((  void (*) (List_1_t314435623 *, UserProfile_t3137328177 *, const RuntimeMethod*))List_1_Add_m3338814081_gshared)(__this, p0, method)
// System.Void UnityEngine.SocialPlatforms.Impl.AchievementDescription::.ctor(System.String,System.String,UnityEngine.Texture2D,System.String,System.String,System.Boolean,System.Int32)
extern "C"  void AchievementDescription__ctor_m2104645942 (AchievementDescription_t3217594527 * __this, String_t* ___id0, String_t* ___title1, Texture2D_t3840446185 * ___image2, String_t* ___achievedDescription3, String_t* ___unachievedDescription4, bool ___hidden5, int32_t ___points6, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Collections.Generic.List`1<UnityEngine.SocialPlatforms.Impl.AchievementDescription>::Add(!0)
#define List_1_Add_m1774517840(__this, p0, method) ((  void (*) (List_1_t394701973 *, AchievementDescription_t3217594527 *, const RuntimeMethod*))List_1_Add_m3338814081_gshared)(__this, p0, method)
// System.Void System.Collections.Generic.List`1<UnityEngine.SocialPlatforms.Impl.Score>::.ctor()
#define List_1__ctor_m1850989583(__this, method) ((  void (*) (List_1_t3440720070 *, const RuntimeMethod*))List_1__ctor_m2321703786_gshared)(__this, method)
// System.DateTime System.DateTime::AddDays(System.Double)
extern "C"  DateTime_t3738529785  DateTime_AddDays_m2583849741 (DateTime_t3738529785 * __this, double p0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Collections.Generic.List`1<UnityEngine.SocialPlatforms.Impl.Leaderboard>::Add(!0)
#define List_1_Add_m351770690(__this, p0, method) ((  void (*) (List_1_t2537151505 *, Leaderboard_t1065076763 *, const RuntimeMethod*))List_1_Add_m3338814081_gshared)(__this, p0, method)
// UnityEngine.Color UnityEngine.Color::get_white()
extern "C"  Color_t2555686324  Color_get_white_m332174077 (RuntimeObject * __this /* static, unused */, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// UnityEngine.Color UnityEngine.Color::get_gray()
extern "C"  Color_t2555686324  Color_get_gray_m1471337008 (RuntimeObject * __this /* static, unused */, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.Texture2D::SetPixel(System.Int32,System.Int32,UnityEngine.Color)
extern "C"  void Texture2D_SetPixel_m2984741184 (Texture2D_t3840446185 * __this, int32_t p0, int32_t p1, Color_t2555686324  p2, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.Texture2D::Apply()
extern "C"  void Texture2D_Apply_m2271746283 (Texture2D_t3840446185 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Int32 System.Int64::CompareTo(System.Int64)
extern "C"  int32_t Int64_CompareTo_m3345789408 (int64_t* __this, int64_t p0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// UnityEngine.SocialPlatforms.ISocialPlatform UnityEngine.Social::get_Active()
extern "C"  RuntimeObject* Social_get_Active_m1353875849 (RuntimeObject * __this /* static, unused */, const RuntimeMethod* method)
{
	RuntimeObject* V_0 = NULL;
	{
		RuntimeObject* L_0 = ActivePlatform_get_Instance_m3727118555(NULL /*static, unused*/, /*hidden argument*/NULL);
		V_0 = L_0;
		goto IL_000c;
	}

IL_000c:
	{
		RuntimeObject* L_1 = V_0;
		return L_1;
	}
}
// UnityEngine.SocialPlatforms.ILocalUser UnityEngine.Social::get_localUser()
extern "C"  RuntimeObject* Social_get_localUser_m4215544813 (RuntimeObject * __this /* static, unused */, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Social_get_localUser_m4215544813_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	RuntimeObject* V_0 = NULL;
	{
		RuntimeObject* L_0 = Social_get_Active_m1353875849(NULL /*static, unused*/, /*hidden argument*/NULL);
		RuntimeObject* L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* UnityEngine.SocialPlatforms.ILocalUser UnityEngine.SocialPlatforms.ISocialPlatform::get_localUser() */, ISocialPlatform_t2920057433_il2cpp_TypeInfo_var, L_0);
		V_0 = L_1;
		goto IL_0011;
	}

IL_0011:
	{
		RuntimeObject* L_2 = V_0;
		return L_2;
	}
}
// System.Void UnityEngine.Social::ReportProgress(System.String,System.Double,System.Action`1<System.Boolean>)
extern "C"  void Social_ReportProgress_m2978360853 (RuntimeObject * __this /* static, unused */, String_t* ___achievementID0, double ___progress1, Action_1_t269755560 * ___callback2, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Social_ReportProgress_m2978360853_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = Social_get_Active_m1353875849(NULL /*static, unused*/, /*hidden argument*/NULL);
		String_t* L_1 = ___achievementID0;
		double L_2 = ___progress1;
		Action_1_t269755560 * L_3 = ___callback2;
		InterfaceActionInvoker3< String_t*, double, Action_1_t269755560 * >::Invoke(1 /* System.Void UnityEngine.SocialPlatforms.ISocialPlatform::ReportProgress(System.String,System.Double,System.Action`1<System.Boolean>) */, ISocialPlatform_t2920057433_il2cpp_TypeInfo_var, L_0, L_1, L_2, L_3);
		return;
	}
}
// System.Void UnityEngine.Social::LoadAchievementDescriptions(System.Action`1<UnityEngine.SocialPlatforms.IAchievementDescription[]>)
extern "C"  void Social_LoadAchievementDescriptions_m1775235550 (RuntimeObject * __this /* static, unused */, Action_1_t1994432444 * ___callback0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Social_LoadAchievementDescriptions_m1775235550_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = Social_get_Active_m1353875849(NULL /*static, unused*/, /*hidden argument*/NULL);
		Action_1_t1994432444 * L_1 = ___callback0;
		InterfaceActionInvoker1< Action_1_t1994432444 * >::Invoke(2 /* System.Void UnityEngine.SocialPlatforms.ISocialPlatform::LoadAchievementDescriptions(System.Action`1<UnityEngine.SocialPlatforms.IAchievementDescription[]>) */, ISocialPlatform_t2920057433_il2cpp_TypeInfo_var, L_0, L_1);
		return;
	}
}
// System.Void UnityEngine.Social::LoadAchievements(System.Action`1<UnityEngine.SocialPlatforms.IAchievement[]>)
extern "C"  void Social_LoadAchievements_m899928901 (RuntimeObject * __this /* static, unused */, Action_1_t2064805934 * ___callback0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Social_LoadAchievements_m899928901_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = Social_get_Active_m1353875849(NULL /*static, unused*/, /*hidden argument*/NULL);
		Action_1_t2064805934 * L_1 = ___callback0;
		InterfaceActionInvoker1< Action_1_t2064805934 * >::Invoke(3 /* System.Void UnityEngine.SocialPlatforms.ISocialPlatform::LoadAchievements(System.Action`1<UnityEngine.SocialPlatforms.IAchievement[]>) */, ISocialPlatform_t2920057433_il2cpp_TypeInfo_var, L_0, L_1);
		return;
	}
}
// System.Void UnityEngine.Social::ReportScore(System.Int64,System.String,System.Action`1<System.Boolean>)
extern "C"  void Social_ReportScore_m356549569 (RuntimeObject * __this /* static, unused */, int64_t ___score0, String_t* ___board1, Action_1_t269755560 * ___callback2, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Social_ReportScore_m356549569_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = Social_get_Active_m1353875849(NULL /*static, unused*/, /*hidden argument*/NULL);
		int64_t L_1 = ___score0;
		String_t* L_2 = ___board1;
		Action_1_t269755560 * L_3 = ___callback2;
		InterfaceActionInvoker3< int64_t, String_t*, Action_1_t269755560 * >::Invoke(4 /* System.Void UnityEngine.SocialPlatforms.ISocialPlatform::ReportScore(System.Int64,System.String,System.Action`1<System.Boolean>) */, ISocialPlatform_t2920057433_il2cpp_TypeInfo_var, L_0, L_1, L_2, L_3);
		return;
	}
}
// UnityEngine.SocialPlatforms.ILeaderboard UnityEngine.Social::CreateLeaderboard()
extern "C"  RuntimeObject* Social_CreateLeaderboard_m1170049904 (RuntimeObject * __this /* static, unused */, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Social_CreateLeaderboard_m1170049904_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	RuntimeObject* V_0 = NULL;
	{
		RuntimeObject* L_0 = Social_get_Active_m1353875849(NULL /*static, unused*/, /*hidden argument*/NULL);
		RuntimeObject* L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(5 /* UnityEngine.SocialPlatforms.ILeaderboard UnityEngine.SocialPlatforms.ISocialPlatform::CreateLeaderboard() */, ISocialPlatform_t2920057433_il2cpp_TypeInfo_var, L_0);
		V_0 = L_1;
		goto IL_0011;
	}

IL_0011:
	{
		RuntimeObject* L_2 = V_0;
		return L_2;
	}
}
// System.Void UnityEngine.Social::ShowAchievementsUI()
extern "C"  void Social_ShowAchievementsUI_m450595073 (RuntimeObject * __this /* static, unused */, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Social_ShowAchievementsUI_m450595073_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = Social_get_Active_m1353875849(NULL /*static, unused*/, /*hidden argument*/NULL);
		InterfaceActionInvoker0::Invoke(6 /* System.Void UnityEngine.SocialPlatforms.ISocialPlatform::ShowAchievementsUI() */, ISocialPlatform_t2920057433_il2cpp_TypeInfo_var, L_0);
		return;
	}
}
// System.Void UnityEngine.Social::ShowLeaderboardUI()
extern "C"  void Social_ShowLeaderboardUI_m369452130 (RuntimeObject * __this /* static, unused */, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Social_ShowLeaderboardUI_m369452130_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = Social_get_Active_m1353875849(NULL /*static, unused*/, /*hidden argument*/NULL);
		InterfaceActionInvoker0::Invoke(7 /* System.Void UnityEngine.SocialPlatforms.ISocialPlatform::ShowLeaderboardUI() */, ISocialPlatform_t2920057433_il2cpp_TypeInfo_var, L_0);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// UnityEngine.SocialPlatforms.ISocialPlatform UnityEngine.SocialPlatforms.ActivePlatform::get_Instance()
extern "C"  RuntimeObject* ActivePlatform_get_Instance_m3727118555 (RuntimeObject * __this /* static, unused */, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (ActivePlatform_get_Instance_m3727118555_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	RuntimeObject* V_0 = NULL;
	{
		RuntimeObject* L_0 = ((ActivePlatform_t3103617690_StaticFields*)il2cpp_codegen_static_fields_for(ActivePlatform_t3103617690_il2cpp_TypeInfo_var))->get__active_0();
		if (L_0)
		{
			goto IL_0015;
		}
	}
	{
		RuntimeObject* L_1 = ActivePlatform_SelectSocialPlatform_m1059707725(NULL /*static, unused*/, /*hidden argument*/NULL);
		((ActivePlatform_t3103617690_StaticFields*)il2cpp_codegen_static_fields_for(ActivePlatform_t3103617690_il2cpp_TypeInfo_var))->set__active_0(L_1);
	}

IL_0015:
	{
		RuntimeObject* L_2 = ((ActivePlatform_t3103617690_StaticFields*)il2cpp_codegen_static_fields_for(ActivePlatform_t3103617690_il2cpp_TypeInfo_var))->get__active_0();
		V_0 = L_2;
		goto IL_0020;
	}

IL_0020:
	{
		RuntimeObject* L_3 = V_0;
		return L_3;
	}
}
// UnityEngine.SocialPlatforms.ISocialPlatform UnityEngine.SocialPlatforms.ActivePlatform::SelectSocialPlatform()
extern "C"  RuntimeObject* ActivePlatform_SelectSocialPlatform_m1059707725 (RuntimeObject * __this /* static, unused */, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (ActivePlatform_SelectSocialPlatform_m1059707725_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	RuntimeObject* V_0 = NULL;
	{
		Local_t4068483442 * L_0 = (Local_t4068483442 *)il2cpp_codegen_object_new(Local_t4068483442_il2cpp_TypeInfo_var);
		Local__ctor_m3461781796(L_0, /*hidden argument*/NULL);
		V_0 = L_0;
		goto IL_000c;
	}

IL_000c:
	{
		RuntimeObject* L_1 = V_0;
		return L_1;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void UnityEngine.SocialPlatforms.Impl.Achievement::.ctor(System.String,System.Double,System.Boolean,System.Boolean,System.DateTime)
extern "C"  void Achievement__ctor_m2166901798 (Achievement_t565359984 * __this, String_t* ___id0, double ___percentCompleted1, bool ___completed2, bool ___hidden3, DateTime_t3738529785  ___lastReportedDate4, const RuntimeMethod* method)
{
	{
		Object__ctor_m297566312(__this, /*hidden argument*/NULL);
		String_t* L_0 = ___id0;
		Achievement_set_id_m2790336588(__this, L_0, /*hidden argument*/NULL);
		double L_1 = ___percentCompleted1;
		Achievement_set_percentCompleted_m1653565997(__this, L_1, /*hidden argument*/NULL);
		bool L_2 = ___completed2;
		__this->set_m_Completed_0(L_2);
		bool L_3 = ___hidden3;
		__this->set_m_Hidden_1(L_3);
		DateTime_t3738529785  L_4 = ___lastReportedDate4;
		__this->set_m_LastReportedDate_2(L_4);
		return;
	}
}
// System.String UnityEngine.SocialPlatforms.Impl.Achievement::ToString()
extern "C"  String_t* Achievement_ToString_m3521250266 (Achievement_t565359984 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Achievement_ToString_m3521250266_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	String_t* V_0 = NULL;
	{
		ObjectU5BU5D_t2843939325* L_0 = ((ObjectU5BU5D_t2843939325*)SZArrayNew(ObjectU5BU5D_t2843939325_il2cpp_TypeInfo_var, (uint32_t)((int32_t)9)));
		String_t* L_1 = Achievement_get_id_m89809597(__this, /*hidden argument*/NULL);
		ArrayElementTypeCheck (L_0, L_1);
		(L_0)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(0), (RuntimeObject *)L_1);
		ObjectU5BU5D_t2843939325* L_2 = L_0;
		ArrayElementTypeCheck (L_2, _stringLiteral3786252490);
		(L_2)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(1), (RuntimeObject *)_stringLiteral3786252490);
		ObjectU5BU5D_t2843939325* L_3 = L_2;
		double L_4 = Achievement_get_percentCompleted_m2110138160(__this, /*hidden argument*/NULL);
		double L_5 = L_4;
		RuntimeObject * L_6 = Box(Double_t594665363_il2cpp_TypeInfo_var, &L_5);
		ArrayElementTypeCheck (L_3, L_6);
		(L_3)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(2), (RuntimeObject *)L_6);
		ObjectU5BU5D_t2843939325* L_7 = L_3;
		ArrayElementTypeCheck (L_7, _stringLiteral3786252490);
		(L_7)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(3), (RuntimeObject *)_stringLiteral3786252490);
		ObjectU5BU5D_t2843939325* L_8 = L_7;
		bool L_9 = Achievement_get_completed_m1377700980(__this, /*hidden argument*/NULL);
		bool L_10 = L_9;
		RuntimeObject * L_11 = Box(Boolean_t97287965_il2cpp_TypeInfo_var, &L_10);
		ArrayElementTypeCheck (L_8, L_11);
		(L_8)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(4), (RuntimeObject *)L_11);
		ObjectU5BU5D_t2843939325* L_12 = L_8;
		ArrayElementTypeCheck (L_12, _stringLiteral3786252490);
		(L_12)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(5), (RuntimeObject *)_stringLiteral3786252490);
		ObjectU5BU5D_t2843939325* L_13 = L_12;
		bool L_14 = Achievement_get_hidden_m4063998500(__this, /*hidden argument*/NULL);
		bool L_15 = L_14;
		RuntimeObject * L_16 = Box(Boolean_t97287965_il2cpp_TypeInfo_var, &L_15);
		ArrayElementTypeCheck (L_13, L_16);
		(L_13)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(6), (RuntimeObject *)L_16);
		ObjectU5BU5D_t2843939325* L_17 = L_13;
		ArrayElementTypeCheck (L_17, _stringLiteral3786252490);
		(L_17)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(7), (RuntimeObject *)_stringLiteral3786252490);
		ObjectU5BU5D_t2843939325* L_18 = L_17;
		DateTime_t3738529785  L_19 = Achievement_get_lastReportedDate_m2200074798(__this, /*hidden argument*/NULL);
		DateTime_t3738529785  L_20 = L_19;
		RuntimeObject * L_21 = Box(DateTime_t3738529785_il2cpp_TypeInfo_var, &L_20);
		ArrayElementTypeCheck (L_18, L_21);
		(L_18)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(8), (RuntimeObject *)L_21);
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_22 = String_Concat_m2971454694(NULL /*static, unused*/, L_18, /*hidden argument*/NULL);
		V_0 = L_22;
		goto IL_0074;
	}

IL_0074:
	{
		String_t* L_23 = V_0;
		return L_23;
	}
}
// System.Void UnityEngine.SocialPlatforms.Impl.Achievement::SetCompleted(System.Boolean)
extern "C"  void Achievement_SetCompleted_m2745299806 (Achievement_t565359984 * __this, bool ___value0, const RuntimeMethod* method)
{
	{
		bool L_0 = ___value0;
		__this->set_m_Completed_0(L_0);
		return;
	}
}
// System.Void UnityEngine.SocialPlatforms.Impl.Achievement::SetHidden(System.Boolean)
extern "C"  void Achievement_SetHidden_m3652603746 (Achievement_t565359984 * __this, bool ___value0, const RuntimeMethod* method)
{
	{
		bool L_0 = ___value0;
		__this->set_m_Hidden_1(L_0);
		return;
	}
}
// System.Void UnityEngine.SocialPlatforms.Impl.Achievement::SetLastReportedDate(System.DateTime)
extern "C"  void Achievement_SetLastReportedDate_m563615391 (Achievement_t565359984 * __this, DateTime_t3738529785  ___date0, const RuntimeMethod* method)
{
	{
		DateTime_t3738529785  L_0 = ___date0;
		__this->set_m_LastReportedDate_2(L_0);
		return;
	}
}
// System.String UnityEngine.SocialPlatforms.Impl.Achievement::get_id()
extern "C"  String_t* Achievement_get_id_m89809597 (Achievement_t565359984 * __this, const RuntimeMethod* method)
{
	String_t* V_0 = NULL;
	{
		String_t* L_0 = __this->get_U3CidU3Ek__BackingField_3();
		V_0 = L_0;
		goto IL_000c;
	}

IL_000c:
	{
		String_t* L_1 = V_0;
		return L_1;
	}
}
// System.Void UnityEngine.SocialPlatforms.Impl.Achievement::set_id(System.String)
extern "C"  void Achievement_set_id_m2790336588 (Achievement_t565359984 * __this, String_t* ___value0, const RuntimeMethod* method)
{
	{
		String_t* L_0 = ___value0;
		__this->set_U3CidU3Ek__BackingField_3(L_0);
		return;
	}
}
// System.Double UnityEngine.SocialPlatforms.Impl.Achievement::get_percentCompleted()
extern "C"  double Achievement_get_percentCompleted_m2110138160 (Achievement_t565359984 * __this, const RuntimeMethod* method)
{
	double V_0 = 0.0;
	{
		double L_0 = __this->get_U3CpercentCompletedU3Ek__BackingField_4();
		V_0 = L_0;
		goto IL_000c;
	}

IL_000c:
	{
		double L_1 = V_0;
		return L_1;
	}
}
// System.Void UnityEngine.SocialPlatforms.Impl.Achievement::set_percentCompleted(System.Double)
extern "C"  void Achievement_set_percentCompleted_m1653565997 (Achievement_t565359984 * __this, double ___value0, const RuntimeMethod* method)
{
	{
		double L_0 = ___value0;
		__this->set_U3CpercentCompletedU3Ek__BackingField_4(L_0);
		return;
	}
}
// System.Boolean UnityEngine.SocialPlatforms.Impl.Achievement::get_completed()
extern "C"  bool Achievement_get_completed_m1377700980 (Achievement_t565359984 * __this, const RuntimeMethod* method)
{
	bool V_0 = false;
	{
		bool L_0 = __this->get_m_Completed_0();
		V_0 = L_0;
		goto IL_000d;
	}

IL_000d:
	{
		bool L_1 = V_0;
		return L_1;
	}
}
// System.Boolean UnityEngine.SocialPlatforms.Impl.Achievement::get_hidden()
extern "C"  bool Achievement_get_hidden_m4063998500 (Achievement_t565359984 * __this, const RuntimeMethod* method)
{
	bool V_0 = false;
	{
		bool L_0 = __this->get_m_Hidden_1();
		V_0 = L_0;
		goto IL_000d;
	}

IL_000d:
	{
		bool L_1 = V_0;
		return L_1;
	}
}
// System.DateTime UnityEngine.SocialPlatforms.Impl.Achievement::get_lastReportedDate()
extern "C"  DateTime_t3738529785  Achievement_get_lastReportedDate_m2200074798 (Achievement_t565359984 * __this, const RuntimeMethod* method)
{
	DateTime_t3738529785  V_0;
	memset(&V_0, 0, sizeof(V_0));
	{
		DateTime_t3738529785  L_0 = __this->get_m_LastReportedDate_2();
		V_0 = L_0;
		goto IL_000d;
	}

IL_000d:
	{
		DateTime_t3738529785  L_1 = V_0;
		return L_1;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void UnityEngine.SocialPlatforms.Impl.AchievementDescription::.ctor(System.String,System.String,UnityEngine.Texture2D,System.String,System.String,System.Boolean,System.Int32)
extern "C"  void AchievementDescription__ctor_m2104645942 (AchievementDescription_t3217594527 * __this, String_t* ___id0, String_t* ___title1, Texture2D_t3840446185 * ___image2, String_t* ___achievedDescription3, String_t* ___unachievedDescription4, bool ___hidden5, int32_t ___points6, const RuntimeMethod* method)
{
	{
		Object__ctor_m297566312(__this, /*hidden argument*/NULL);
		String_t* L_0 = ___id0;
		AchievementDescription_set_id_m751528388(__this, L_0, /*hidden argument*/NULL);
		String_t* L_1 = ___title1;
		__this->set_m_Title_0(L_1);
		Texture2D_t3840446185 * L_2 = ___image2;
		__this->set_m_Image_1(L_2);
		String_t* L_3 = ___achievedDescription3;
		__this->set_m_AchievedDescription_2(L_3);
		String_t* L_4 = ___unachievedDescription4;
		__this->set_m_UnachievedDescription_3(L_4);
		bool L_5 = ___hidden5;
		__this->set_m_Hidden_4(L_5);
		int32_t L_6 = ___points6;
		__this->set_m_Points_5(L_6);
		return;
	}
}
// System.String UnityEngine.SocialPlatforms.Impl.AchievementDescription::ToString()
extern "C"  String_t* AchievementDescription_ToString_m2063334390 (AchievementDescription_t3217594527 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (AchievementDescription_ToString_m2063334390_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	String_t* V_0 = NULL;
	{
		ObjectU5BU5D_t2843939325* L_0 = ((ObjectU5BU5D_t2843939325*)SZArrayNew(ObjectU5BU5D_t2843939325_il2cpp_TypeInfo_var, (uint32_t)((int32_t)11)));
		String_t* L_1 = AchievementDescription_get_id_m985811184(__this, /*hidden argument*/NULL);
		ArrayElementTypeCheck (L_0, L_1);
		(L_0)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(0), (RuntimeObject *)L_1);
		ObjectU5BU5D_t2843939325* L_2 = L_0;
		ArrayElementTypeCheck (L_2, _stringLiteral3786252490);
		(L_2)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(1), (RuntimeObject *)_stringLiteral3786252490);
		ObjectU5BU5D_t2843939325* L_3 = L_2;
		String_t* L_4 = AchievementDescription_get_title_m417729785(__this, /*hidden argument*/NULL);
		ArrayElementTypeCheck (L_3, L_4);
		(L_3)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(2), (RuntimeObject *)L_4);
		ObjectU5BU5D_t2843939325* L_5 = L_3;
		ArrayElementTypeCheck (L_5, _stringLiteral3786252490);
		(L_5)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(3), (RuntimeObject *)_stringLiteral3786252490);
		ObjectU5BU5D_t2843939325* L_6 = L_5;
		String_t* L_7 = AchievementDescription_get_achievedDescription_m387769685(__this, /*hidden argument*/NULL);
		ArrayElementTypeCheck (L_6, L_7);
		(L_6)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(4), (RuntimeObject *)L_7);
		ObjectU5BU5D_t2843939325* L_8 = L_6;
		ArrayElementTypeCheck (L_8, _stringLiteral3786252490);
		(L_8)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(5), (RuntimeObject *)_stringLiteral3786252490);
		ObjectU5BU5D_t2843939325* L_9 = L_8;
		String_t* L_10 = AchievementDescription_get_unachievedDescription_m690845291(__this, /*hidden argument*/NULL);
		ArrayElementTypeCheck (L_9, L_10);
		(L_9)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(6), (RuntimeObject *)L_10);
		ObjectU5BU5D_t2843939325* L_11 = L_9;
		ArrayElementTypeCheck (L_11, _stringLiteral3786252490);
		(L_11)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(7), (RuntimeObject *)_stringLiteral3786252490);
		ObjectU5BU5D_t2843939325* L_12 = L_11;
		int32_t L_13 = AchievementDescription_get_points_m4273978152(__this, /*hidden argument*/NULL);
		int32_t L_14 = L_13;
		RuntimeObject * L_15 = Box(Int32_t2950945753_il2cpp_TypeInfo_var, &L_14);
		ArrayElementTypeCheck (L_12, L_15);
		(L_12)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(8), (RuntimeObject *)L_15);
		ObjectU5BU5D_t2843939325* L_16 = L_12;
		ArrayElementTypeCheck (L_16, _stringLiteral3786252490);
		(L_16)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(((int32_t)9)), (RuntimeObject *)_stringLiteral3786252490);
		ObjectU5BU5D_t2843939325* L_17 = L_16;
		bool L_18 = AchievementDescription_get_hidden_m1497330198(__this, /*hidden argument*/NULL);
		bool L_19 = L_18;
		RuntimeObject * L_20 = Box(Boolean_t97287965_il2cpp_TypeInfo_var, &L_19);
		ArrayElementTypeCheck (L_17, L_20);
		(L_17)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(((int32_t)10)), (RuntimeObject *)L_20);
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_21 = String_Concat_m2971454694(NULL /*static, unused*/, L_17, /*hidden argument*/NULL);
		V_0 = L_21;
		goto IL_007d;
	}

IL_007d:
	{
		String_t* L_22 = V_0;
		return L_22;
	}
}
// System.String UnityEngine.SocialPlatforms.Impl.AchievementDescription::get_id()
extern "C"  String_t* AchievementDescription_get_id_m985811184 (AchievementDescription_t3217594527 * __this, const RuntimeMethod* method)
{
	String_t* V_0 = NULL;
	{
		String_t* L_0 = __this->get_U3CidU3Ek__BackingField_6();
		V_0 = L_0;
		goto IL_000c;
	}

IL_000c:
	{
		String_t* L_1 = V_0;
		return L_1;
	}
}
// System.Void UnityEngine.SocialPlatforms.Impl.AchievementDescription::set_id(System.String)
extern "C"  void AchievementDescription_set_id_m751528388 (AchievementDescription_t3217594527 * __this, String_t* ___value0, const RuntimeMethod* method)
{
	{
		String_t* L_0 = ___value0;
		__this->set_U3CidU3Ek__BackingField_6(L_0);
		return;
	}
}
// System.String UnityEngine.SocialPlatforms.Impl.AchievementDescription::get_title()
extern "C"  String_t* AchievementDescription_get_title_m417729785 (AchievementDescription_t3217594527 * __this, const RuntimeMethod* method)
{
	String_t* V_0 = NULL;
	{
		String_t* L_0 = __this->get_m_Title_0();
		V_0 = L_0;
		goto IL_000d;
	}

IL_000d:
	{
		String_t* L_1 = V_0;
		return L_1;
	}
}
// System.String UnityEngine.SocialPlatforms.Impl.AchievementDescription::get_achievedDescription()
extern "C"  String_t* AchievementDescription_get_achievedDescription_m387769685 (AchievementDescription_t3217594527 * __this, const RuntimeMethod* method)
{
	String_t* V_0 = NULL;
	{
		String_t* L_0 = __this->get_m_AchievedDescription_2();
		V_0 = L_0;
		goto IL_000d;
	}

IL_000d:
	{
		String_t* L_1 = V_0;
		return L_1;
	}
}
// System.String UnityEngine.SocialPlatforms.Impl.AchievementDescription::get_unachievedDescription()
extern "C"  String_t* AchievementDescription_get_unachievedDescription_m690845291 (AchievementDescription_t3217594527 * __this, const RuntimeMethod* method)
{
	String_t* V_0 = NULL;
	{
		String_t* L_0 = __this->get_m_UnachievedDescription_3();
		V_0 = L_0;
		goto IL_000d;
	}

IL_000d:
	{
		String_t* L_1 = V_0;
		return L_1;
	}
}
// System.Boolean UnityEngine.SocialPlatforms.Impl.AchievementDescription::get_hidden()
extern "C"  bool AchievementDescription_get_hidden_m1497330198 (AchievementDescription_t3217594527 * __this, const RuntimeMethod* method)
{
	bool V_0 = false;
	{
		bool L_0 = __this->get_m_Hidden_4();
		V_0 = L_0;
		goto IL_000d;
	}

IL_000d:
	{
		bool L_1 = V_0;
		return L_1;
	}
}
// System.Int32 UnityEngine.SocialPlatforms.Impl.AchievementDescription::get_points()
extern "C"  int32_t AchievementDescription_get_points_m4273978152 (AchievementDescription_t3217594527 * __this, const RuntimeMethod* method)
{
	int32_t V_0 = 0;
	{
		int32_t L_0 = __this->get_m_Points_5();
		V_0 = L_0;
		goto IL_000d;
	}

IL_000d:
	{
		int32_t L_1 = V_0;
		return L_1;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void UnityEngine.SocialPlatforms.Impl.Leaderboard::.ctor()
extern "C"  void Leaderboard__ctor_m1030108446 (Leaderboard_t1065076763 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Leaderboard__ctor_m1030108446_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		Object__ctor_m297566312(__this, /*hidden argument*/NULL);
		Leaderboard_set_id_m3990768853(__this, _stringLiteral2065339255, /*hidden argument*/NULL);
		Range_t173988048  L_0;
		memset(&L_0, 0, sizeof(L_0));
		Range__ctor_m3975982763((&L_0), 1, ((int32_t)10), /*hidden argument*/NULL);
		Leaderboard_set_range_m1868499957(__this, L_0, /*hidden argument*/NULL);
		Leaderboard_set_userScope_m4131851828(__this, 0, /*hidden argument*/NULL);
		Leaderboard_set_timeScope_m3468042286(__this, 2, /*hidden argument*/NULL);
		__this->set_m_Loading_0((bool)0);
		Score_t1968645328 * L_1 = (Score_t1968645328 *)il2cpp_codegen_object_new(Score_t1968645328_il2cpp_TypeInfo_var);
		Score__ctor_m2390363112(L_1, _stringLiteral2065339255, (((int64_t)((int64_t)0))), /*hidden argument*/NULL);
		__this->set_m_LocalUserScore_1(L_1);
		__this->set_m_MaxRange_2(0);
		__this->set_m_Scores_3((IScoreU5BU5D_t527871248*)((ScoreU5BU5D_t972561905*)SZArrayNew(ScoreU5BU5D_t972561905_il2cpp_TypeInfo_var, (uint32_t)0)));
		__this->set_m_Title_4(_stringLiteral2065339255);
		__this->set_m_UserIDs_5(((StringU5BU5D_t1281789340*)SZArrayNew(StringU5BU5D_t1281789340_il2cpp_TypeInfo_var, (uint32_t)0)));
		return;
	}
}
// System.String UnityEngine.SocialPlatforms.Impl.Leaderboard::ToString()
extern "C"  String_t* Leaderboard_ToString_m1544604165 (Leaderboard_t1065076763 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Leaderboard_ToString_m1544604165_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	Range_t173988048  V_0;
	memset(&V_0, 0, sizeof(V_0));
	Range_t173988048  V_1;
	memset(&V_1, 0, sizeof(V_1));
	String_t* V_2 = NULL;
	{
		ObjectU5BU5D_t2843939325* L_0 = ((ObjectU5BU5D_t2843939325*)SZArrayNew(ObjectU5BU5D_t2843939325_il2cpp_TypeInfo_var, (uint32_t)((int32_t)20)));
		ArrayElementTypeCheck (L_0, _stringLiteral930699636);
		(L_0)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(0), (RuntimeObject *)_stringLiteral930699636);
		ObjectU5BU5D_t2843939325* L_1 = L_0;
		String_t* L_2 = Leaderboard_get_id_m4258535896(__this, /*hidden argument*/NULL);
		ArrayElementTypeCheck (L_1, L_2);
		(L_1)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(1), (RuntimeObject *)L_2);
		ObjectU5BU5D_t2843939325* L_3 = L_1;
		ArrayElementTypeCheck (L_3, _stringLiteral2979315402);
		(L_3)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(2), (RuntimeObject *)_stringLiteral2979315402);
		ObjectU5BU5D_t2843939325* L_4 = L_3;
		String_t* L_5 = __this->get_m_Title_4();
		ArrayElementTypeCheck (L_4, L_5);
		(L_4)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(3), (RuntimeObject *)L_5);
		ObjectU5BU5D_t2843939325* L_6 = L_4;
		ArrayElementTypeCheck (L_6, _stringLiteral1695920045);
		(L_6)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(4), (RuntimeObject *)_stringLiteral1695920045);
		ObjectU5BU5D_t2843939325* L_7 = L_6;
		bool L_8 = __this->get_m_Loading_0();
		bool L_9 = L_8;
		RuntimeObject * L_10 = Box(Boolean_t97287965_il2cpp_TypeInfo_var, &L_9);
		ArrayElementTypeCheck (L_7, L_10);
		(L_7)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(5), (RuntimeObject *)L_10);
		ObjectU5BU5D_t2843939325* L_11 = L_7;
		ArrayElementTypeCheck (L_11, _stringLiteral1702585322);
		(L_11)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(6), (RuntimeObject *)_stringLiteral1702585322);
		ObjectU5BU5D_t2843939325* L_12 = L_11;
		Range_t173988048  L_13 = Leaderboard_get_range_m167968592(__this, /*hidden argument*/NULL);
		V_0 = L_13;
		int32_t L_14 = (&V_0)->get_from_0();
		int32_t L_15 = L_14;
		RuntimeObject * L_16 = Box(Int32_t2950945753_il2cpp_TypeInfo_var, &L_15);
		ArrayElementTypeCheck (L_12, L_16);
		(L_12)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(7), (RuntimeObject *)L_16);
		ObjectU5BU5D_t2843939325* L_17 = L_12;
		ArrayElementTypeCheck (L_17, _stringLiteral3452614532);
		(L_17)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(8), (RuntimeObject *)_stringLiteral3452614532);
		ObjectU5BU5D_t2843939325* L_18 = L_17;
		Range_t173988048  L_19 = Leaderboard_get_range_m167968592(__this, /*hidden argument*/NULL);
		V_1 = L_19;
		int32_t L_20 = (&V_1)->get_count_1();
		int32_t L_21 = L_20;
		RuntimeObject * L_22 = Box(Int32_t2950945753_il2cpp_TypeInfo_var, &L_21);
		ArrayElementTypeCheck (L_18, L_22);
		(L_18)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(((int32_t)9)), (RuntimeObject *)L_22);
		ObjectU5BU5D_t2843939325* L_23 = L_18;
		ArrayElementTypeCheck (L_23, _stringLiteral3449030883);
		(L_23)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(((int32_t)10)), (RuntimeObject *)_stringLiteral3449030883);
		ObjectU5BU5D_t2843939325* L_24 = L_23;
		uint32_t L_25 = __this->get_m_MaxRange_2();
		uint32_t L_26 = L_25;
		RuntimeObject * L_27 = Box(UInt32_t2560061978_il2cpp_TypeInfo_var, &L_26);
		ArrayElementTypeCheck (L_24, L_27);
		(L_24)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(((int32_t)11)), (RuntimeObject *)L_27);
		ObjectU5BU5D_t2843939325* L_28 = L_24;
		ArrayElementTypeCheck (L_28, _stringLiteral1177415910);
		(L_28)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(((int32_t)12)), (RuntimeObject *)_stringLiteral1177415910);
		ObjectU5BU5D_t2843939325* L_29 = L_28;
		IScoreU5BU5D_t527871248* L_30 = __this->get_m_Scores_3();
		int32_t L_31 = (((int32_t)((int32_t)(((RuntimeArray *)L_30)->max_length))));
		RuntimeObject * L_32 = Box(Int32_t2950945753_il2cpp_TypeInfo_var, &L_31);
		ArrayElementTypeCheck (L_29, L_32);
		(L_29)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(((int32_t)13)), (RuntimeObject *)L_32);
		ObjectU5BU5D_t2843939325* L_33 = L_29;
		ArrayElementTypeCheck (L_33, _stringLiteral1358844784);
		(L_33)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(((int32_t)14)), (RuntimeObject *)_stringLiteral1358844784);
		ObjectU5BU5D_t2843939325* L_34 = L_33;
		int32_t L_35 = Leaderboard_get_userScope_m4090697307(__this, /*hidden argument*/NULL);
		int32_t L_36 = L_35;
		RuntimeObject * L_37 = Box(UserScope_t604006431_il2cpp_TypeInfo_var, &L_36);
		ArrayElementTypeCheck (L_34, L_37);
		(L_34)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(((int32_t)15)), (RuntimeObject *)L_37);
		ObjectU5BU5D_t2843939325* L_38 = L_34;
		ArrayElementTypeCheck (L_38, _stringLiteral1488170903);
		(L_38)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(((int32_t)16)), (RuntimeObject *)_stringLiteral1488170903);
		ObjectU5BU5D_t2843939325* L_39 = L_38;
		int32_t L_40 = Leaderboard_get_timeScope_m4226979676(__this, /*hidden argument*/NULL);
		int32_t L_41 = L_40;
		RuntimeObject * L_42 = Box(TimeScope_t539351503_il2cpp_TypeInfo_var, &L_41);
		ArrayElementTypeCheck (L_39, L_42);
		(L_39)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(((int32_t)17)), (RuntimeObject *)L_42);
		ObjectU5BU5D_t2843939325* L_43 = L_39;
		ArrayElementTypeCheck (L_43, _stringLiteral933325165);
		(L_43)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(((int32_t)18)), (RuntimeObject *)_stringLiteral933325165);
		ObjectU5BU5D_t2843939325* L_44 = L_43;
		StringU5BU5D_t1281789340* L_45 = __this->get_m_UserIDs_5();
		int32_t L_46 = (((int32_t)((int32_t)(((RuntimeArray *)L_45)->max_length))));
		RuntimeObject * L_47 = Box(Int32_t2950945753_il2cpp_TypeInfo_var, &L_46);
		ArrayElementTypeCheck (L_44, L_47);
		(L_44)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(((int32_t)19)), (RuntimeObject *)L_47);
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_48 = String_Concat_m2971454694(NULL /*static, unused*/, L_44, /*hidden argument*/NULL);
		V_2 = L_48;
		goto IL_0104;
	}

IL_0104:
	{
		String_t* L_49 = V_2;
		return L_49;
	}
}
// System.Void UnityEngine.SocialPlatforms.Impl.Leaderboard::LoadScores(System.Action`1<System.Boolean>)
extern "C"  void Leaderboard_LoadScores_m2671749416 (Leaderboard_t1065076763 * __this, Action_1_t269755560 * ___callback0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Leaderboard_LoadScores_m2671749416_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = ActivePlatform_get_Instance_m3727118555(NULL /*static, unused*/, /*hidden argument*/NULL);
		Action_1_t269755560 * L_1 = ___callback0;
		InterfaceActionInvoker2< RuntimeObject*, Action_1_t269755560 * >::Invoke(9 /* System.Void UnityEngine.SocialPlatforms.ISocialPlatform::LoadScores(UnityEngine.SocialPlatforms.ILeaderboard,System.Action`1<System.Boolean>) */, ISocialPlatform_t2920057433_il2cpp_TypeInfo_var, L_0, __this, L_1);
		return;
	}
}
// System.Void UnityEngine.SocialPlatforms.Impl.Leaderboard::SetLocalUserScore(UnityEngine.SocialPlatforms.IScore)
extern "C"  void Leaderboard_SetLocalUserScore_m3569886016 (Leaderboard_t1065076763 * __this, RuntimeObject* ___score0, const RuntimeMethod* method)
{
	{
		RuntimeObject* L_0 = ___score0;
		__this->set_m_LocalUserScore_1(L_0);
		return;
	}
}
// System.Void UnityEngine.SocialPlatforms.Impl.Leaderboard::SetMaxRange(System.UInt32)
extern "C"  void Leaderboard_SetMaxRange_m629679481 (Leaderboard_t1065076763 * __this, uint32_t ___maxRange0, const RuntimeMethod* method)
{
	{
		uint32_t L_0 = ___maxRange0;
		__this->set_m_MaxRange_2(L_0);
		return;
	}
}
// System.Void UnityEngine.SocialPlatforms.Impl.Leaderboard::SetScores(UnityEngine.SocialPlatforms.IScore[])
extern "C"  void Leaderboard_SetScores_m2163784072 (Leaderboard_t1065076763 * __this, IScoreU5BU5D_t527871248* ___scores0, const RuntimeMethod* method)
{
	{
		IScoreU5BU5D_t527871248* L_0 = ___scores0;
		__this->set_m_Scores_3(L_0);
		return;
	}
}
// System.Void UnityEngine.SocialPlatforms.Impl.Leaderboard::SetTitle(System.String)
extern "C"  void Leaderboard_SetTitle_m459905577 (Leaderboard_t1065076763 * __this, String_t* ___title0, const RuntimeMethod* method)
{
	{
		String_t* L_0 = ___title0;
		__this->set_m_Title_4(L_0);
		return;
	}
}
// System.String UnityEngine.SocialPlatforms.Impl.Leaderboard::get_id()
extern "C"  String_t* Leaderboard_get_id_m4258535896 (Leaderboard_t1065076763 * __this, const RuntimeMethod* method)
{
	String_t* V_0 = NULL;
	{
		String_t* L_0 = __this->get_U3CidU3Ek__BackingField_6();
		V_0 = L_0;
		goto IL_000c;
	}

IL_000c:
	{
		String_t* L_1 = V_0;
		return L_1;
	}
}
// System.Void UnityEngine.SocialPlatforms.Impl.Leaderboard::set_id(System.String)
extern "C"  void Leaderboard_set_id_m3990768853 (Leaderboard_t1065076763 * __this, String_t* ___value0, const RuntimeMethod* method)
{
	{
		String_t* L_0 = ___value0;
		__this->set_U3CidU3Ek__BackingField_6(L_0);
		return;
	}
}
// UnityEngine.SocialPlatforms.UserScope UnityEngine.SocialPlatforms.Impl.Leaderboard::get_userScope()
extern "C"  int32_t Leaderboard_get_userScope_m4090697307 (Leaderboard_t1065076763 * __this, const RuntimeMethod* method)
{
	int32_t V_0 = 0;
	{
		int32_t L_0 = __this->get_U3CuserScopeU3Ek__BackingField_7();
		V_0 = L_0;
		goto IL_000c;
	}

IL_000c:
	{
		int32_t L_1 = V_0;
		return L_1;
	}
}
// System.Void UnityEngine.SocialPlatforms.Impl.Leaderboard::set_userScope(UnityEngine.SocialPlatforms.UserScope)
extern "C"  void Leaderboard_set_userScope_m4131851828 (Leaderboard_t1065076763 * __this, int32_t ___value0, const RuntimeMethod* method)
{
	{
		int32_t L_0 = ___value0;
		__this->set_U3CuserScopeU3Ek__BackingField_7(L_0);
		return;
	}
}
// UnityEngine.SocialPlatforms.Range UnityEngine.SocialPlatforms.Impl.Leaderboard::get_range()
extern "C"  Range_t173988048  Leaderboard_get_range_m167968592 (Leaderboard_t1065076763 * __this, const RuntimeMethod* method)
{
	Range_t173988048  V_0;
	memset(&V_0, 0, sizeof(V_0));
	{
		Range_t173988048  L_0 = __this->get_U3CrangeU3Ek__BackingField_8();
		V_0 = L_0;
		goto IL_000c;
	}

IL_000c:
	{
		Range_t173988048  L_1 = V_0;
		return L_1;
	}
}
// System.Void UnityEngine.SocialPlatforms.Impl.Leaderboard::set_range(UnityEngine.SocialPlatforms.Range)
extern "C"  void Leaderboard_set_range_m1868499957 (Leaderboard_t1065076763 * __this, Range_t173988048  ___value0, const RuntimeMethod* method)
{
	{
		Range_t173988048  L_0 = ___value0;
		__this->set_U3CrangeU3Ek__BackingField_8(L_0);
		return;
	}
}
// UnityEngine.SocialPlatforms.TimeScope UnityEngine.SocialPlatforms.Impl.Leaderboard::get_timeScope()
extern "C"  int32_t Leaderboard_get_timeScope_m4226979676 (Leaderboard_t1065076763 * __this, const RuntimeMethod* method)
{
	int32_t V_0 = 0;
	{
		int32_t L_0 = __this->get_U3CtimeScopeU3Ek__BackingField_9();
		V_0 = L_0;
		goto IL_000c;
	}

IL_000c:
	{
		int32_t L_1 = V_0;
		return L_1;
	}
}
// System.Void UnityEngine.SocialPlatforms.Impl.Leaderboard::set_timeScope(UnityEngine.SocialPlatforms.TimeScope)
extern "C"  void Leaderboard_set_timeScope_m3468042286 (Leaderboard_t1065076763 * __this, int32_t ___value0, const RuntimeMethod* method)
{
	{
		int32_t L_0 = ___value0;
		__this->set_U3CtimeScopeU3Ek__BackingField_9(L_0);
		return;
	}
}
// UnityEngine.SocialPlatforms.IScore UnityEngine.SocialPlatforms.Impl.Leaderboard::get_localUserScore()
extern "C"  RuntimeObject* Leaderboard_get_localUserScore_m4251180644 (Leaderboard_t1065076763 * __this, const RuntimeMethod* method)
{
	RuntimeObject* V_0 = NULL;
	{
		RuntimeObject* L_0 = __this->get_m_LocalUserScore_1();
		V_0 = L_0;
		goto IL_000d;
	}

IL_000d:
	{
		RuntimeObject* L_1 = V_0;
		return L_1;
	}
}
// UnityEngine.SocialPlatforms.IScore[] UnityEngine.SocialPlatforms.Impl.Leaderboard::get_scores()
extern "C"  IScoreU5BU5D_t527871248* Leaderboard_get_scores_m1529761529 (Leaderboard_t1065076763 * __this, const RuntimeMethod* method)
{
	IScoreU5BU5D_t527871248* V_0 = NULL;
	{
		IScoreU5BU5D_t527871248* L_0 = __this->get_m_Scores_3();
		V_0 = L_0;
		goto IL_000d;
	}

IL_000d:
	{
		IScoreU5BU5D_t527871248* L_1 = V_0;
		return L_1;
	}
}
// System.String UnityEngine.SocialPlatforms.Impl.Leaderboard::get_title()
extern "C"  String_t* Leaderboard_get_title_m3614214113 (Leaderboard_t1065076763 * __this, const RuntimeMethod* method)
{
	String_t* V_0 = NULL;
	{
		String_t* L_0 = __this->get_m_Title_4();
		V_0 = L_0;
		goto IL_000d;
	}

IL_000d:
	{
		String_t* L_1 = V_0;
		return L_1;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void UnityEngine.SocialPlatforms.Impl.LocalUser::.ctor()
extern "C"  void LocalUser__ctor_m4260307073 (LocalUser_t365094499 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (LocalUser__ctor_m4260307073_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		UserProfile__ctor_m3353918255(__this, /*hidden argument*/NULL);
		__this->set_m_Friends_5((IUserProfileU5BU5D_t909679733*)((UserProfileU5BU5D_t1895532524*)SZArrayNew(UserProfileU5BU5D_t1895532524_il2cpp_TypeInfo_var, (uint32_t)0)));
		__this->set_m_Authenticated_6((bool)0);
		__this->set_m_Underage_7((bool)0);
		return;
	}
}
// System.Void UnityEngine.SocialPlatforms.Impl.LocalUser::Authenticate(System.Action`1<System.Boolean>)
extern "C"  void LocalUser_Authenticate_m2136646640 (LocalUser_t365094499 * __this, Action_1_t269755560 * ___callback0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (LocalUser_Authenticate_m2136646640_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = ActivePlatform_get_Instance_m3727118555(NULL /*static, unused*/, /*hidden argument*/NULL);
		Action_1_t269755560 * L_1 = ___callback0;
		InterfaceActionInvoker2< RuntimeObject*, Action_1_t269755560 * >::Invoke(8 /* System.Void UnityEngine.SocialPlatforms.ISocialPlatform::Authenticate(UnityEngine.SocialPlatforms.ILocalUser,System.Action`1<System.Boolean>) */, ISocialPlatform_t2920057433_il2cpp_TypeInfo_var, L_0, __this, L_1);
		return;
	}
}
// System.Void UnityEngine.SocialPlatforms.Impl.LocalUser::SetAuthenticated(System.Boolean)
extern "C"  void LocalUser_SetAuthenticated_m3352566618 (LocalUser_t365094499 * __this, bool ___value0, const RuntimeMethod* method)
{
	{
		bool L_0 = ___value0;
		__this->set_m_Authenticated_6(L_0);
		return;
	}
}
// System.Void UnityEngine.SocialPlatforms.Impl.LocalUser::SetUnderage(System.Boolean)
extern "C"  void LocalUser_SetUnderage_m1848352351 (LocalUser_t365094499 * __this, bool ___value0, const RuntimeMethod* method)
{
	{
		bool L_0 = ___value0;
		__this->set_m_Underage_7(L_0);
		return;
	}
}
// System.Boolean UnityEngine.SocialPlatforms.Impl.LocalUser::get_authenticated()
extern "C"  bool LocalUser_get_authenticated_m385074490 (LocalUser_t365094499 * __this, const RuntimeMethod* method)
{
	bool V_0 = false;
	{
		bool L_0 = __this->get_m_Authenticated_6();
		V_0 = L_0;
		goto IL_000d;
	}

IL_000d:
	{
		bool L_1 = V_0;
		return L_1;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void UnityEngine.SocialPlatforms.Impl.Score::.ctor(System.String,System.Int64)
extern "C"  void Score__ctor_m2390363112 (Score_t1968645328 * __this, String_t* ___leaderboardID0, int64_t ___value1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Score__ctor_m2390363112_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		String_t* L_0 = ___leaderboardID0;
		int64_t L_1 = ___value1;
		IL2CPP_RUNTIME_CLASS_INIT(DateTime_t3738529785_il2cpp_TypeInfo_var);
		DateTime_t3738529785  L_2 = DateTime_get_Now_m1277138875(NULL /*static, unused*/, /*hidden argument*/NULL);
		Score__ctor_m1554947855(__this, L_0, L_1, _stringLiteral3452614544, L_2, _stringLiteral757602046, (-1), /*hidden argument*/NULL);
		return;
	}
}
// System.Void UnityEngine.SocialPlatforms.Impl.Score::.ctor(System.String,System.Int64,System.String,System.DateTime,System.String,System.Int32)
extern "C"  void Score__ctor_m1554947855 (Score_t1968645328 * __this, String_t* ___leaderboardID0, int64_t ___value1, String_t* ___userID2, DateTime_t3738529785  ___date3, String_t* ___formattedValue4, int32_t ___rank5, const RuntimeMethod* method)
{
	{
		Object__ctor_m297566312(__this, /*hidden argument*/NULL);
		String_t* L_0 = ___leaderboardID0;
		Score_set_leaderboardID_m268558918(__this, L_0, /*hidden argument*/NULL);
		int64_t L_1 = ___value1;
		Score_set_value_m935893699(__this, L_1, /*hidden argument*/NULL);
		String_t* L_2 = ___userID2;
		__this->set_m_UserID_2(L_2);
		DateTime_t3738529785  L_3 = ___date3;
		__this->set_m_Date_0(L_3);
		String_t* L_4 = ___formattedValue4;
		__this->set_m_FormattedValue_1(L_4);
		int32_t L_5 = ___rank5;
		__this->set_m_Rank_3(L_5);
		return;
	}
}
// System.String UnityEngine.SocialPlatforms.Impl.Score::ToString()
extern "C"  String_t* Score_ToString_m885507283 (Score_t1968645328 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Score_ToString_m885507283_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	String_t* V_0 = NULL;
	{
		ObjectU5BU5D_t2843939325* L_0 = ((ObjectU5BU5D_t2843939325*)SZArrayNew(ObjectU5BU5D_t2843939325_il2cpp_TypeInfo_var, (uint32_t)((int32_t)10)));
		ArrayElementTypeCheck (L_0, _stringLiteral2608391305);
		(L_0)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(0), (RuntimeObject *)_stringLiteral2608391305);
		ObjectU5BU5D_t2843939325* L_1 = L_0;
		int32_t L_2 = __this->get_m_Rank_3();
		int32_t L_3 = L_2;
		RuntimeObject * L_4 = Box(Int32_t2950945753_il2cpp_TypeInfo_var, &L_3);
		ArrayElementTypeCheck (L_1, L_4);
		(L_1)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(1), (RuntimeObject *)L_4);
		ObjectU5BU5D_t2843939325* L_5 = L_1;
		ArrayElementTypeCheck (L_5, _stringLiteral1464936688);
		(L_5)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(2), (RuntimeObject *)_stringLiteral1464936688);
		ObjectU5BU5D_t2843939325* L_6 = L_5;
		int64_t L_7 = Score_get_value_m3180422307(__this, /*hidden argument*/NULL);
		int64_t L_8 = L_7;
		RuntimeObject * L_9 = Box(Int64_t3736567304_il2cpp_TypeInfo_var, &L_8);
		ArrayElementTypeCheck (L_6, L_9);
		(L_6)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(3), (RuntimeObject *)L_9);
		ObjectU5BU5D_t2843939325* L_10 = L_6;
		ArrayElementTypeCheck (L_10, _stringLiteral3818843126);
		(L_10)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(4), (RuntimeObject *)_stringLiteral3818843126);
		ObjectU5BU5D_t2843939325* L_11 = L_10;
		String_t* L_12 = Score_get_leaderboardID_m3645107971(__this, /*hidden argument*/NULL);
		ArrayElementTypeCheck (L_11, L_12);
		(L_11)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(5), (RuntimeObject *)L_12);
		ObjectU5BU5D_t2843939325* L_13 = L_11;
		ArrayElementTypeCheck (L_13, _stringLiteral2823322644);
		(L_13)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(6), (RuntimeObject *)_stringLiteral2823322644);
		ObjectU5BU5D_t2843939325* L_14 = L_13;
		String_t* L_15 = __this->get_m_UserID_2();
		ArrayElementTypeCheck (L_14, L_15);
		(L_14)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(7), (RuntimeObject *)L_15);
		ObjectU5BU5D_t2843939325* L_16 = L_14;
		ArrayElementTypeCheck (L_16, _stringLiteral4281704856);
		(L_16)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(8), (RuntimeObject *)_stringLiteral4281704856);
		ObjectU5BU5D_t2843939325* L_17 = L_16;
		DateTime_t3738529785  L_18 = __this->get_m_Date_0();
		DateTime_t3738529785  L_19 = L_18;
		RuntimeObject * L_20 = Box(DateTime_t3738529785_il2cpp_TypeInfo_var, &L_19);
		ArrayElementTypeCheck (L_17, L_20);
		(L_17)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(((int32_t)9)), (RuntimeObject *)L_20);
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_21 = String_Concat_m2971454694(NULL /*static, unused*/, L_17, /*hidden argument*/NULL);
		V_0 = L_21;
		goto IL_0078;
	}

IL_0078:
	{
		String_t* L_22 = V_0;
		return L_22;
	}
}
// System.Void UnityEngine.SocialPlatforms.Impl.Score::SetRank(System.Int32)
extern "C"  void Score_SetRank_m588673792 (Score_t1968645328 * __this, int32_t ___rank0, const RuntimeMethod* method)
{
	{
		int32_t L_0 = ___rank0;
		__this->set_m_Rank_3(L_0);
		return;
	}
}
// System.String UnityEngine.SocialPlatforms.Impl.Score::get_leaderboardID()
extern "C"  String_t* Score_get_leaderboardID_m3645107971 (Score_t1968645328 * __this, const RuntimeMethod* method)
{
	String_t* V_0 = NULL;
	{
		String_t* L_0 = __this->get_U3CleaderboardIDU3Ek__BackingField_4();
		V_0 = L_0;
		goto IL_000c;
	}

IL_000c:
	{
		String_t* L_1 = V_0;
		return L_1;
	}
}
// System.Void UnityEngine.SocialPlatforms.Impl.Score::set_leaderboardID(System.String)
extern "C"  void Score_set_leaderboardID_m268558918 (Score_t1968645328 * __this, String_t* ___value0, const RuntimeMethod* method)
{
	{
		String_t* L_0 = ___value0;
		__this->set_U3CleaderboardIDU3Ek__BackingField_4(L_0);
		return;
	}
}
// System.Int64 UnityEngine.SocialPlatforms.Impl.Score::get_value()
extern "C"  int64_t Score_get_value_m3180422307 (Score_t1968645328 * __this, const RuntimeMethod* method)
{
	int64_t V_0 = 0;
	{
		int64_t L_0 = __this->get_U3CvalueU3Ek__BackingField_5();
		V_0 = L_0;
		goto IL_000c;
	}

IL_000c:
	{
		int64_t L_1 = V_0;
		return L_1;
	}
}
// System.Void UnityEngine.SocialPlatforms.Impl.Score::set_value(System.Int64)
extern "C"  void Score_set_value_m935893699 (Score_t1968645328 * __this, int64_t ___value0, const RuntimeMethod* method)
{
	{
		int64_t L_0 = ___value0;
		__this->set_U3CvalueU3Ek__BackingField_5(L_0);
		return;
	}
}
// System.String UnityEngine.SocialPlatforms.Impl.Score::get_formattedValue()
extern "C"  String_t* Score_get_formattedValue_m2991835363 (Score_t1968645328 * __this, const RuntimeMethod* method)
{
	String_t* V_0 = NULL;
	{
		String_t* L_0 = __this->get_m_FormattedValue_1();
		V_0 = L_0;
		goto IL_000d;
	}

IL_000d:
	{
		String_t* L_1 = V_0;
		return L_1;
	}
}
// System.String UnityEngine.SocialPlatforms.Impl.Score::get_userID()
extern "C"  String_t* Score_get_userID_m602877400 (Score_t1968645328 * __this, const RuntimeMethod* method)
{
	String_t* V_0 = NULL;
	{
		String_t* L_0 = __this->get_m_UserID_2();
		V_0 = L_0;
		goto IL_000d;
	}

IL_000d:
	{
		String_t* L_1 = V_0;
		return L_1;
	}
}
// System.Int32 UnityEngine.SocialPlatforms.Impl.Score::get_rank()
extern "C"  int32_t Score_get_rank_m2257575811 (Score_t1968645328 * __this, const RuntimeMethod* method)
{
	int32_t V_0 = 0;
	{
		int32_t L_0 = __this->get_m_Rank_3();
		V_0 = L_0;
		goto IL_000d;
	}

IL_000d:
	{
		int32_t L_1 = V_0;
		return L_1;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void UnityEngine.SocialPlatforms.Impl.UserProfile::.ctor()
extern "C"  void UserProfile__ctor_m3353918255 (UserProfile_t3137328177 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (UserProfile__ctor_m3353918255_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		Object__ctor_m297566312(__this, /*hidden argument*/NULL);
		__this->set_m_UserName_0(_stringLiteral3725686153);
		__this->set_m_ID_1(_stringLiteral3452614544);
		__this->set_m_IsFriend_2((bool)0);
		__this->set_m_State_3(3);
		Texture2D_t3840446185 * L_0 = (Texture2D_t3840446185 *)il2cpp_codegen_object_new(Texture2D_t3840446185_il2cpp_TypeInfo_var);
		Texture2D__ctor_m373113269(L_0, ((int32_t)32), ((int32_t)32), /*hidden argument*/NULL);
		__this->set_m_Image_4(L_0);
		return;
	}
}
// System.Void UnityEngine.SocialPlatforms.Impl.UserProfile::.ctor(System.String,System.String,System.Boolean,UnityEngine.SocialPlatforms.UserState,UnityEngine.Texture2D)
extern "C"  void UserProfile__ctor_m2409346676 (UserProfile_t3137328177 * __this, String_t* ___name0, String_t* ___id1, bool ___friend2, int32_t ___state3, Texture2D_t3840446185 * ___image4, const RuntimeMethod* method)
{
	{
		Object__ctor_m297566312(__this, /*hidden argument*/NULL);
		String_t* L_0 = ___name0;
		__this->set_m_UserName_0(L_0);
		String_t* L_1 = ___id1;
		__this->set_m_ID_1(L_1);
		bool L_2 = ___friend2;
		__this->set_m_IsFriend_2(L_2);
		int32_t L_3 = ___state3;
		__this->set_m_State_3(L_3);
		Texture2D_t3840446185 * L_4 = ___image4;
		__this->set_m_Image_4(L_4);
		return;
	}
}
// System.String UnityEngine.SocialPlatforms.Impl.UserProfile::ToString()
extern "C"  String_t* UserProfile_ToString_m2232825484 (UserProfile_t3137328177 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (UserProfile_ToString_m2232825484_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	String_t* V_0 = NULL;
	{
		ObjectU5BU5D_t2843939325* L_0 = ((ObjectU5BU5D_t2843939325*)SZArrayNew(ObjectU5BU5D_t2843939325_il2cpp_TypeInfo_var, (uint32_t)7));
		String_t* L_1 = UserProfile_get_id_m3178143816(__this, /*hidden argument*/NULL);
		ArrayElementTypeCheck (L_0, L_1);
		(L_0)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(0), (RuntimeObject *)L_1);
		ObjectU5BU5D_t2843939325* L_2 = L_0;
		ArrayElementTypeCheck (L_2, _stringLiteral3786252490);
		(L_2)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(1), (RuntimeObject *)_stringLiteral3786252490);
		ObjectU5BU5D_t2843939325* L_3 = L_2;
		String_t* L_4 = UserProfile_get_userName_m3063744753(__this, /*hidden argument*/NULL);
		ArrayElementTypeCheck (L_3, L_4);
		(L_3)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(2), (RuntimeObject *)L_4);
		ObjectU5BU5D_t2843939325* L_5 = L_3;
		ArrayElementTypeCheck (L_5, _stringLiteral3786252490);
		(L_5)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(3), (RuntimeObject *)_stringLiteral3786252490);
		ObjectU5BU5D_t2843939325* L_6 = L_5;
		bool L_7 = UserProfile_get_isFriend_m3838691482(__this, /*hidden argument*/NULL);
		bool L_8 = L_7;
		RuntimeObject * L_9 = Box(Boolean_t97287965_il2cpp_TypeInfo_var, &L_8);
		ArrayElementTypeCheck (L_6, L_9);
		(L_6)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(4), (RuntimeObject *)L_9);
		ObjectU5BU5D_t2843939325* L_10 = L_6;
		ArrayElementTypeCheck (L_10, _stringLiteral3786252490);
		(L_10)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(5), (RuntimeObject *)_stringLiteral3786252490);
		ObjectU5BU5D_t2843939325* L_11 = L_10;
		int32_t L_12 = UserProfile_get_state_m3340793320(__this, /*hidden argument*/NULL);
		int32_t L_13 = L_12;
		RuntimeObject * L_14 = Box(UserState_t4177058321_il2cpp_TypeInfo_var, &L_13);
		ArrayElementTypeCheck (L_11, L_14);
		(L_11)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(6), (RuntimeObject *)L_14);
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_15 = String_Concat_m2971454694(NULL /*static, unused*/, L_11, /*hidden argument*/NULL);
		V_0 = L_15;
		goto IL_0058;
	}

IL_0058:
	{
		String_t* L_16 = V_0;
		return L_16;
	}
}
// System.Void UnityEngine.SocialPlatforms.Impl.UserProfile::SetUserName(System.String)
extern "C"  void UserProfile_SetUserName_m1732526939 (UserProfile_t3137328177 * __this, String_t* ___name0, const RuntimeMethod* method)
{
	{
		String_t* L_0 = ___name0;
		__this->set_m_UserName_0(L_0);
		return;
	}
}
// System.Void UnityEngine.SocialPlatforms.Impl.UserProfile::SetUserID(System.String)
extern "C"  void UserProfile_SetUserID_m1137218839 (UserProfile_t3137328177 * __this, String_t* ___id0, const RuntimeMethod* method)
{
	{
		String_t* L_0 = ___id0;
		__this->set_m_ID_1(L_0);
		return;
	}
}
// System.Void UnityEngine.SocialPlatforms.Impl.UserProfile::SetImage(UnityEngine.Texture2D)
extern "C"  void UserProfile_SetImage_m418239758 (UserProfile_t3137328177 * __this, Texture2D_t3840446185 * ___image0, const RuntimeMethod* method)
{
	{
		Texture2D_t3840446185 * L_0 = ___image0;
		__this->set_m_Image_4(L_0);
		return;
	}
}
// System.String UnityEngine.SocialPlatforms.Impl.UserProfile::get_userName()
extern "C"  String_t* UserProfile_get_userName_m3063744753 (UserProfile_t3137328177 * __this, const RuntimeMethod* method)
{
	String_t* V_0 = NULL;
	{
		String_t* L_0 = __this->get_m_UserName_0();
		V_0 = L_0;
		goto IL_000d;
	}

IL_000d:
	{
		String_t* L_1 = V_0;
		return L_1;
	}
}
// System.String UnityEngine.SocialPlatforms.Impl.UserProfile::get_id()
extern "C"  String_t* UserProfile_get_id_m3178143816 (UserProfile_t3137328177 * __this, const RuntimeMethod* method)
{
	String_t* V_0 = NULL;
	{
		String_t* L_0 = __this->get_m_ID_1();
		V_0 = L_0;
		goto IL_000d;
	}

IL_000d:
	{
		String_t* L_1 = V_0;
		return L_1;
	}
}
// System.Boolean UnityEngine.SocialPlatforms.Impl.UserProfile::get_isFriend()
extern "C"  bool UserProfile_get_isFriend_m3838691482 (UserProfile_t3137328177 * __this, const RuntimeMethod* method)
{
	bool V_0 = false;
	{
		bool L_0 = __this->get_m_IsFriend_2();
		V_0 = L_0;
		goto IL_000d;
	}

IL_000d:
	{
		bool L_1 = V_0;
		return L_1;
	}
}
// UnityEngine.SocialPlatforms.UserState UnityEngine.SocialPlatforms.Impl.UserProfile::get_state()
extern "C"  int32_t UserProfile_get_state_m3340793320 (UserProfile_t3137328177 * __this, const RuntimeMethod* method)
{
	int32_t V_0 = 0;
	{
		int32_t L_0 = __this->get_m_State_3();
		V_0 = L_0;
		goto IL_000d;
	}

IL_000d:
	{
		int32_t L_1 = V_0;
		return L_1;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void UnityEngine.SocialPlatforms.Local::.ctor()
extern "C"  void Local__ctor_m3461781796 (Local_t4068483442 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Local__ctor_m3461781796_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		List_1_t314435623 * L_0 = (List_1_t314435623 *)il2cpp_codegen_object_new(List_1_t314435623_il2cpp_TypeInfo_var);
		List_1__ctor_m973695318(L_0, /*hidden argument*/List_1__ctor_m973695318_RuntimeMethod_var);
		__this->set_m_Friends_1(L_0);
		List_1_t314435623 * L_1 = (List_1_t314435623 *)il2cpp_codegen_object_new(List_1_t314435623_il2cpp_TypeInfo_var);
		List_1__ctor_m973695318(L_1, /*hidden argument*/List_1__ctor_m973695318_RuntimeMethod_var);
		__this->set_m_Users_2(L_1);
		List_1_t394701973 * L_2 = (List_1_t394701973 *)il2cpp_codegen_object_new(List_1_t394701973_il2cpp_TypeInfo_var);
		List_1__ctor_m3689826338(L_2, /*hidden argument*/List_1__ctor_m3689826338_RuntimeMethod_var);
		__this->set_m_AchievementDescriptions_3(L_2);
		List_1_t2037434726 * L_3 = (List_1_t2037434726 *)il2cpp_codegen_object_new(List_1_t2037434726_il2cpp_TypeInfo_var);
		List_1__ctor_m1836006746(L_3, /*hidden argument*/List_1__ctor_m1836006746_RuntimeMethod_var);
		__this->set_m_Achievements_4(L_3);
		List_1_t2537151505 * L_4 = (List_1_t2537151505 *)il2cpp_codegen_object_new(List_1_t2537151505_il2cpp_TypeInfo_var);
		List_1__ctor_m1889483756(L_4, /*hidden argument*/List_1__ctor_m1889483756_RuntimeMethod_var);
		__this->set_m_Leaderboards_5(L_4);
		Object__ctor_m297566312(__this, /*hidden argument*/NULL);
		return;
	}
}
// UnityEngine.SocialPlatforms.ILocalUser UnityEngine.SocialPlatforms.Local::get_localUser()
extern "C"  RuntimeObject* Local_get_localUser_m1583274769 (Local_t4068483442 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Local_get_localUser_m1583274769_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	RuntimeObject* V_0 = NULL;
	{
		IL2CPP_RUNTIME_CLASS_INIT(Local_t4068483442_il2cpp_TypeInfo_var);
		LocalUser_t365094499 * L_0 = ((Local_t4068483442_StaticFields*)il2cpp_codegen_static_fields_for(Local_t4068483442_il2cpp_TypeInfo_var))->get_m_LocalUser_0();
		if (L_0)
		{
			goto IL_0015;
		}
	}
	{
		LocalUser_t365094499 * L_1 = (LocalUser_t365094499 *)il2cpp_codegen_object_new(LocalUser_t365094499_il2cpp_TypeInfo_var);
		LocalUser__ctor_m4260307073(L_1, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Local_t4068483442_il2cpp_TypeInfo_var);
		((Local_t4068483442_StaticFields*)il2cpp_codegen_static_fields_for(Local_t4068483442_il2cpp_TypeInfo_var))->set_m_LocalUser_0(L_1);
	}

IL_0015:
	{
		IL2CPP_RUNTIME_CLASS_INIT(Local_t4068483442_il2cpp_TypeInfo_var);
		LocalUser_t365094499 * L_2 = ((Local_t4068483442_StaticFields*)il2cpp_codegen_static_fields_for(Local_t4068483442_il2cpp_TypeInfo_var))->get_m_LocalUser_0();
		V_0 = L_2;
		goto IL_0020;
	}

IL_0020:
	{
		RuntimeObject* L_3 = V_0;
		return L_3;
	}
}
// System.Void UnityEngine.SocialPlatforms.Local::UnityEngine.SocialPlatforms.ISocialPlatform.Authenticate(UnityEngine.SocialPlatforms.ILocalUser,System.Action`1<System.Boolean>)
extern "C"  void Local_UnityEngine_SocialPlatforms_ISocialPlatform_Authenticate_m2207258125 (Local_t4068483442 * __this, RuntimeObject* ___user0, Action_1_t269755560 * ___callback1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Local_UnityEngine_SocialPlatforms_ISocialPlatform_Authenticate_m2207258125_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	LocalUser_t365094499 * V_0 = NULL;
	{
		RuntimeObject* L_0 = ___user0;
		V_0 = ((LocalUser_t365094499 *)CastclassClass((RuntimeObject*)L_0, LocalUser_t365094499_il2cpp_TypeInfo_var));
		Texture2D_t3840446185 * L_1 = Local_CreateDummyTexture_m3769606019(__this, ((int32_t)32), ((int32_t)32), /*hidden argument*/NULL);
		__this->set_m_DefaultTexture_6(L_1);
		Local_PopulateStaticData_m916798409(__this, /*hidden argument*/NULL);
		LocalUser_t365094499 * L_2 = V_0;
		LocalUser_SetAuthenticated_m3352566618(L_2, (bool)1, /*hidden argument*/NULL);
		LocalUser_t365094499 * L_3 = V_0;
		LocalUser_SetUnderage_m1848352351(L_3, (bool)0, /*hidden argument*/NULL);
		LocalUser_t365094499 * L_4 = V_0;
		UserProfile_SetUserID_m1137218839(L_4, _stringLiteral15947561, /*hidden argument*/NULL);
		LocalUser_t365094499 * L_5 = V_0;
		UserProfile_SetUserName_m1732526939(L_5, _stringLiteral774297412, /*hidden argument*/NULL);
		LocalUser_t365094499 * L_6 = V_0;
		Texture2D_t3840446185 * L_7 = __this->get_m_DefaultTexture_6();
		UserProfile_SetImage_m418239758(L_6, L_7, /*hidden argument*/NULL);
		Action_1_t269755560 * L_8 = ___callback1;
		if (!L_8)
		{
			goto IL_005b;
		}
	}
	{
		Action_1_t269755560 * L_9 = ___callback1;
		Action_1_Invoke_m1933767679(L_9, (bool)1, /*hidden argument*/Action_1_Invoke_m1933767679_RuntimeMethod_var);
	}

IL_005b:
	{
		return;
	}
}
// System.Void UnityEngine.SocialPlatforms.Local::ReportProgress(System.String,System.Double,System.Action`1<System.Boolean>)
extern "C"  void Local_ReportProgress_m2862776241 (Local_t4068483442 * __this, String_t* ___id0, double ___progress1, Action_1_t269755560 * ___callback2, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Local_ReportProgress_m2862776241_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	Achievement_t565359984 * V_0 = NULL;
	Enumerator_t3926678603  V_1;
	memset(&V_1, 0, sizeof(V_1));
	AchievementDescription_t3217594527 * V_2 = NULL;
	Enumerator_t2283945850  V_3;
	memset(&V_3, 0, sizeof(V_3));
	bool V_4 = false;
	Achievement_t565359984 * V_5 = NULL;
	Exception_t * __last_unhandled_exception = 0;
	NO_UNUSED_WARNING (__last_unhandled_exception);
	Exception_t * __exception_local = 0;
	NO_UNUSED_WARNING (__exception_local);
	int32_t __leave_target = 0;
	NO_UNUSED_WARNING (__leave_target);
	int32_t G_B21_0 = 0;
	{
		bool L_0 = Local_VerifyUser_m2348500446(__this, /*hidden argument*/NULL);
		if (L_0)
		{
			goto IL_0011;
		}
	}
	{
		goto IL_0157;
	}

IL_0011:
	{
		List_1_t2037434726 * L_1 = __this->get_m_Achievements_4();
		Enumerator_t3926678603  L_2 = List_1_GetEnumerator_m2680008813(L_1, /*hidden argument*/List_1_GetEnumerator_m2680008813_RuntimeMethod_var);
		V_1 = L_2;
	}

IL_001e:
	try
	{ // begin try (depth: 1)
		{
			goto IL_008c;
		}

IL_0023:
		{
			Achievement_t565359984 * L_3 = Enumerator_get_Current_m2947874382((&V_1), /*hidden argument*/Enumerator_get_Current_m2947874382_RuntimeMethod_var);
			V_0 = L_3;
			Achievement_t565359984 * L_4 = V_0;
			String_t* L_5 = Achievement_get_id_m89809597(L_4, /*hidden argument*/NULL);
			String_t* L_6 = ___id0;
			IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
			bool L_7 = String_op_Equality_m920492651(NULL /*static, unused*/, L_5, L_6, /*hidden argument*/NULL);
			if (!L_7)
			{
				goto IL_008b;
			}
		}

IL_003d:
		{
			Achievement_t565359984 * L_8 = V_0;
			double L_9 = Achievement_get_percentCompleted_m2110138160(L_8, /*hidden argument*/NULL);
			double L_10 = ___progress1;
			if ((!(((double)L_9) <= ((double)L_10))))
			{
				goto IL_008b;
			}
		}

IL_0049:
		{
			double L_11 = ___progress1;
			if ((!(((double)L_11) >= ((double)(100.0)))))
			{
				goto IL_0060;
			}
		}

IL_0059:
		{
			Achievement_t565359984 * L_12 = V_0;
			Achievement_SetCompleted_m2745299806(L_12, (bool)1, /*hidden argument*/NULL);
		}

IL_0060:
		{
			Achievement_t565359984 * L_13 = V_0;
			Achievement_SetHidden_m3652603746(L_13, (bool)0, /*hidden argument*/NULL);
			Achievement_t565359984 * L_14 = V_0;
			IL2CPP_RUNTIME_CLASS_INIT(DateTime_t3738529785_il2cpp_TypeInfo_var);
			DateTime_t3738529785  L_15 = DateTime_get_Now_m1277138875(NULL /*static, unused*/, /*hidden argument*/NULL);
			Achievement_SetLastReportedDate_m563615391(L_14, L_15, /*hidden argument*/NULL);
			Achievement_t565359984 * L_16 = V_0;
			double L_17 = ___progress1;
			Achievement_set_percentCompleted_m1653565997(L_16, L_17, /*hidden argument*/NULL);
			Action_1_t269755560 * L_18 = ___callback2;
			if (!L_18)
			{
				goto IL_0086;
			}
		}

IL_007f:
		{
			Action_1_t269755560 * L_19 = ___callback2;
			Action_1_Invoke_m1933767679(L_19, (bool)1, /*hidden argument*/Action_1_Invoke_m1933767679_RuntimeMethod_var);
		}

IL_0086:
		{
			IL2CPP_LEAVE(0x157, FINALLY_009d);
		}

IL_008b:
		{
		}

IL_008c:
		{
			bool L_20 = Enumerator_MoveNext_m2057277239((&V_1), /*hidden argument*/Enumerator_MoveNext_m2057277239_RuntimeMethod_var);
			if (L_20)
			{
				goto IL_0023;
			}
		}

IL_0098:
		{
			IL2CPP_LEAVE(0xAB, FINALLY_009d);
		}
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_009d;
	}

FINALLY_009d:
	{ // begin finally (depth: 1)
		Enumerator_Dispose_m3795629826((&V_1), /*hidden argument*/Enumerator_Dispose_m3795629826_RuntimeMethod_var);
		IL2CPP_END_FINALLY(157)
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(157)
	{
		IL2CPP_JUMP_TBL(0x157, IL_0157)
		IL2CPP_JUMP_TBL(0xAB, IL_00ab)
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
	}

IL_00ab:
	{
		List_1_t394701973 * L_21 = __this->get_m_AchievementDescriptions_3();
		Enumerator_t2283945850  L_22 = List_1_GetEnumerator_m3287167671(L_21, /*hidden argument*/List_1_GetEnumerator_m3287167671_RuntimeMethod_var);
		V_3 = L_22;
	}

IL_00b8:
	try
	{ // begin try (depth: 1)
		{
			goto IL_0121;
		}

IL_00bd:
		{
			AchievementDescription_t3217594527 * L_23 = Enumerator_get_Current_m578560357((&V_3), /*hidden argument*/Enumerator_get_Current_m578560357_RuntimeMethod_var);
			V_2 = L_23;
			AchievementDescription_t3217594527 * L_24 = V_2;
			String_t* L_25 = AchievementDescription_get_id_m985811184(L_24, /*hidden argument*/NULL);
			String_t* L_26 = ___id0;
			IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
			bool L_27 = String_op_Equality_m920492651(NULL /*static, unused*/, L_25, L_26, /*hidden argument*/NULL);
			if (!L_27)
			{
				goto IL_0120;
			}
		}

IL_00d7:
		{
			double L_28 = ___progress1;
			if ((!(((double)L_28) >= ((double)(100.0)))))
			{
				goto IL_00ed;
			}
		}

IL_00e7:
		{
			G_B21_0 = 1;
			goto IL_00ee;
		}

IL_00ed:
		{
			G_B21_0 = 0;
		}

IL_00ee:
		{
			V_4 = (bool)G_B21_0;
			String_t* L_29 = ___id0;
			double L_30 = ___progress1;
			bool L_31 = V_4;
			IL2CPP_RUNTIME_CLASS_INIT(DateTime_t3738529785_il2cpp_TypeInfo_var);
			DateTime_t3738529785  L_32 = DateTime_get_Now_m1277138875(NULL /*static, unused*/, /*hidden argument*/NULL);
			Achievement_t565359984 * L_33 = (Achievement_t565359984 *)il2cpp_codegen_object_new(Achievement_t565359984_il2cpp_TypeInfo_var);
			Achievement__ctor_m2166901798(L_33, L_29, L_30, L_31, (bool)0, L_32, /*hidden argument*/NULL);
			V_5 = L_33;
			List_1_t2037434726 * L_34 = __this->get_m_Achievements_4();
			Achievement_t565359984 * L_35 = V_5;
			List_1_Add_m4026348786(L_34, L_35, /*hidden argument*/List_1_Add_m4026348786_RuntimeMethod_var);
			Action_1_t269755560 * L_36 = ___callback2;
			if (!L_36)
			{
				goto IL_011b;
			}
		}

IL_0114:
		{
			Action_1_t269755560 * L_37 = ___callback2;
			Action_1_Invoke_m1933767679(L_37, (bool)1, /*hidden argument*/Action_1_Invoke_m1933767679_RuntimeMethod_var);
		}

IL_011b:
		{
			IL2CPP_LEAVE(0x157, FINALLY_0132);
		}

IL_0120:
		{
		}

IL_0121:
		{
			bool L_38 = Enumerator_MoveNext_m1380577720((&V_3), /*hidden argument*/Enumerator_MoveNext_m1380577720_RuntimeMethod_var);
			if (L_38)
			{
				goto IL_00bd;
			}
		}

IL_012d:
		{
			IL2CPP_LEAVE(0x140, FINALLY_0132);
		}
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_0132;
	}

FINALLY_0132:
	{ // begin finally (depth: 1)
		Enumerator_Dispose_m228566194((&V_3), /*hidden argument*/Enumerator_Dispose_m228566194_RuntimeMethod_var);
		IL2CPP_END_FINALLY(306)
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(306)
	{
		IL2CPP_JUMP_TBL(0x157, IL_0157)
		IL2CPP_JUMP_TBL(0x140, IL_0140)
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
	}

IL_0140:
	{
		IL2CPP_RUNTIME_CLASS_INIT(Debug_t3317548046_il2cpp_TypeInfo_var);
		Debug_LogError_m2850623458(NULL /*static, unused*/, _stringLiteral2915405358, /*hidden argument*/NULL);
		Action_1_t269755560 * L_39 = ___callback2;
		if (!L_39)
		{
			goto IL_0157;
		}
	}
	{
		Action_1_t269755560 * L_40 = ___callback2;
		Action_1_Invoke_m1933767679(L_40, (bool)0, /*hidden argument*/Action_1_Invoke_m1933767679_RuntimeMethod_var);
	}

IL_0157:
	{
		return;
	}
}
// System.Void UnityEngine.SocialPlatforms.Local::LoadAchievementDescriptions(System.Action`1<UnityEngine.SocialPlatforms.IAchievementDescription[]>)
extern "C"  void Local_LoadAchievementDescriptions_m3080409102 (Local_t4068483442 * __this, Action_1_t1994432444 * ___callback0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Local_LoadAchievementDescriptions_m3080409102_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		bool L_0 = Local_VerifyUser_m2348500446(__this, /*hidden argument*/NULL);
		if (L_0)
		{
			goto IL_0011;
		}
	}
	{
		goto IL_0028;
	}

IL_0011:
	{
		Action_1_t1994432444 * L_1 = ___callback0;
		if (!L_1)
		{
			goto IL_0028;
		}
	}
	{
		Action_1_t1994432444 * L_2 = ___callback0;
		List_1_t394701973 * L_3 = __this->get_m_AchievementDescriptions_3();
		AchievementDescriptionU5BU5D_t1886727686* L_4 = List_1_ToArray_m3141863218(L_3, /*hidden argument*/List_1_ToArray_m3141863218_RuntimeMethod_var);
		Action_1_Invoke_m1979208465(L_2, (IAchievementDescriptionU5BU5D_t1821964849*)(IAchievementDescriptionU5BU5D_t1821964849*)L_4, /*hidden argument*/Action_1_Invoke_m1979208465_RuntimeMethod_var);
	}

IL_0028:
	{
		return;
	}
}
// System.Void UnityEngine.SocialPlatforms.Local::LoadAchievements(System.Action`1<UnityEngine.SocialPlatforms.IAchievement[]>)
extern "C"  void Local_LoadAchievements_m2951224182 (Local_t4068483442 * __this, Action_1_t2064805934 * ___callback0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Local_LoadAchievements_m2951224182_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		bool L_0 = Local_VerifyUser_m2348500446(__this, /*hidden argument*/NULL);
		if (L_0)
		{
			goto IL_0011;
		}
	}
	{
		goto IL_0028;
	}

IL_0011:
	{
		Action_1_t2064805934 * L_1 = ___callback0;
		if (!L_1)
		{
			goto IL_0028;
		}
	}
	{
		Action_1_t2064805934 * L_2 = ___callback0;
		List_1_t2037434726 * L_3 = __this->get_m_Achievements_4();
		AchievementU5BU5D_t1511134929* L_4 = List_1_ToArray_m4122937214(L_3, /*hidden argument*/List_1_ToArray_m4122937214_RuntimeMethod_var);
		Action_1_Invoke_m24007936(L_2, (IAchievementU5BU5D_t1892338339*)(IAchievementU5BU5D_t1892338339*)L_4, /*hidden argument*/Action_1_Invoke_m24007936_RuntimeMethod_var);
	}

IL_0028:
	{
		return;
	}
}
// System.Void UnityEngine.SocialPlatforms.Local::ReportScore(System.Int64,System.String,System.Action`1<System.Boolean>)
extern "C"  void Local_ReportScore_m128146884 (Local_t4068483442 * __this, int64_t ___score0, String_t* ___board1, Action_1_t269755560 * ___callback2, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Local_ReportScore_m128146884_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	Leaderboard_t1065076763 * V_0 = NULL;
	Enumerator_t131428086  V_1;
	memset(&V_1, 0, sizeof(V_1));
	List_1_t3440720070 * V_2 = NULL;
	Exception_t * __last_unhandled_exception = 0;
	NO_UNUSED_WARNING (__last_unhandled_exception);
	Exception_t * __exception_local = 0;
	NO_UNUSED_WARNING (__exception_local);
	int32_t __leave_target = 0;
	NO_UNUSED_WARNING (__leave_target);
	{
		bool L_0 = Local_VerifyUser_m2348500446(__this, /*hidden argument*/NULL);
		if (L_0)
		{
			goto IL_0011;
		}
	}
	{
		goto IL_00d2;
	}

IL_0011:
	{
		List_1_t2537151505 * L_1 = __this->get_m_Leaderboards_5();
		Enumerator_t131428086  L_2 = List_1_GetEnumerator_m3274601223(L_1, /*hidden argument*/List_1_GetEnumerator_m3274601223_RuntimeMethod_var);
		V_1 = L_2;
	}

IL_001e:
	try
	{ // begin try (depth: 1)
		{
			goto IL_009c;
		}

IL_0023:
		{
			Leaderboard_t1065076763 * L_3 = Enumerator_get_Current_m1590304878((&V_1), /*hidden argument*/Enumerator_get_Current_m1590304878_RuntimeMethod_var);
			V_0 = L_3;
			Leaderboard_t1065076763 * L_4 = V_0;
			String_t* L_5 = Leaderboard_get_id_m4258535896(L_4, /*hidden argument*/NULL);
			String_t* L_6 = ___board1;
			IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
			bool L_7 = String_op_Equality_m920492651(NULL /*static, unused*/, L_5, L_6, /*hidden argument*/NULL);
			if (!L_7)
			{
				goto IL_009b;
			}
		}

IL_003d:
		{
			Leaderboard_t1065076763 * L_8 = V_0;
			IScoreU5BU5D_t527871248* L_9 = Leaderboard_get_scores_m1529761529(L_8, /*hidden argument*/NULL);
			List_1_t3440720070 * L_10 = (List_1_t3440720070 *)il2cpp_codegen_object_new(List_1_t3440720070_il2cpp_TypeInfo_var);
			List_1__ctor_m176386895(L_10, (RuntimeObject*)(RuntimeObject*)((ScoreU5BU5D_t972561905*)Castclass((RuntimeObject*)L_9, ScoreU5BU5D_t972561905_il2cpp_TypeInfo_var)), /*hidden argument*/List_1__ctor_m176386895_RuntimeMethod_var);
			V_2 = L_10;
			List_1_t3440720070 * L_11 = V_2;
			String_t* L_12 = ___board1;
			int64_t L_13 = ___score0;
			RuntimeObject* L_14 = Local_get_localUser_m1583274769(__this, /*hidden argument*/NULL);
			String_t* L_15 = InterfaceFuncInvoker0< String_t* >::Invoke(0 /* System.String UnityEngine.SocialPlatforms.IUserProfile::get_id() */, IUserProfile_t360500636_il2cpp_TypeInfo_var, L_14);
			IL2CPP_RUNTIME_CLASS_INIT(DateTime_t3738529785_il2cpp_TypeInfo_var);
			DateTime_t3738529785  L_16 = DateTime_get_Now_m1277138875(NULL /*static, unused*/, /*hidden argument*/NULL);
			int64_t L_17 = ___score0;
			int64_t L_18 = L_17;
			RuntimeObject * L_19 = Box(Int64_t3736567304_il2cpp_TypeInfo_var, &L_18);
			IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
			String_t* L_20 = String_Concat_m904156431(NULL /*static, unused*/, L_19, _stringLiteral3751832596, /*hidden argument*/NULL);
			Score_t1968645328 * L_21 = (Score_t1968645328 *)il2cpp_codegen_object_new(Score_t1968645328_il2cpp_TypeInfo_var);
			Score__ctor_m1554947855(L_21, L_12, L_13, L_15, L_16, L_20, 0, /*hidden argument*/NULL);
			List_1_Add_m1702244787(L_11, L_21, /*hidden argument*/List_1_Add_m1702244787_RuntimeMethod_var);
			Leaderboard_t1065076763 * L_22 = V_0;
			List_1_t3440720070 * L_23 = V_2;
			ScoreU5BU5D_t972561905* L_24 = List_1_ToArray_m2845752048(L_23, /*hidden argument*/List_1_ToArray_m2845752048_RuntimeMethod_var);
			Leaderboard_SetScores_m2163784072(L_22, (IScoreU5BU5D_t527871248*)(IScoreU5BU5D_t527871248*)L_24, /*hidden argument*/NULL);
			Action_1_t269755560 * L_25 = ___callback2;
			if (!L_25)
			{
				goto IL_0096;
			}
		}

IL_008f:
		{
			Action_1_t269755560 * L_26 = ___callback2;
			Action_1_Invoke_m1933767679(L_26, (bool)1, /*hidden argument*/Action_1_Invoke_m1933767679_RuntimeMethod_var);
		}

IL_0096:
		{
			IL2CPP_LEAVE(0xD2, FINALLY_00ad);
		}

IL_009b:
		{
		}

IL_009c:
		{
			bool L_27 = Enumerator_MoveNext_m3184043996((&V_1), /*hidden argument*/Enumerator_MoveNext_m3184043996_RuntimeMethod_var);
			if (L_27)
			{
				goto IL_0023;
			}
		}

IL_00a8:
		{
			IL2CPP_LEAVE(0xBB, FINALLY_00ad);
		}
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_00ad;
	}

FINALLY_00ad:
	{ // begin finally (depth: 1)
		Enumerator_Dispose_m1743516632((&V_1), /*hidden argument*/Enumerator_Dispose_m1743516632_RuntimeMethod_var);
		IL2CPP_END_FINALLY(173)
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(173)
	{
		IL2CPP_JUMP_TBL(0xD2, IL_00d2)
		IL2CPP_JUMP_TBL(0xBB, IL_00bb)
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
	}

IL_00bb:
	{
		IL2CPP_RUNTIME_CLASS_INIT(Debug_t3317548046_il2cpp_TypeInfo_var);
		Debug_LogError_m2850623458(NULL /*static, unused*/, _stringLiteral44010168, /*hidden argument*/NULL);
		Action_1_t269755560 * L_28 = ___callback2;
		if (!L_28)
		{
			goto IL_00d2;
		}
	}
	{
		Action_1_t269755560 * L_29 = ___callback2;
		Action_1_Invoke_m1933767679(L_29, (bool)0, /*hidden argument*/Action_1_Invoke_m1933767679_RuntimeMethod_var);
	}

IL_00d2:
	{
		return;
	}
}
// System.Void UnityEngine.SocialPlatforms.Local::UnityEngine.SocialPlatforms.ISocialPlatform.LoadScores(UnityEngine.SocialPlatforms.ILeaderboard,System.Action`1<System.Boolean>)
extern "C"  void Local_UnityEngine_SocialPlatforms_ISocialPlatform_LoadScores_m1678696798 (Local_t4068483442 * __this, RuntimeObject* ___board0, Action_1_t269755560 * ___callback1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Local_UnityEngine_SocialPlatforms_ISocialPlatform_LoadScores_m1678696798_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	Leaderboard_t1065076763 * V_0 = NULL;
	Leaderboard_t1065076763 * V_1 = NULL;
	Enumerator_t131428086  V_2;
	memset(&V_2, 0, sizeof(V_2));
	Exception_t * __last_unhandled_exception = 0;
	NO_UNUSED_WARNING (__last_unhandled_exception);
	Exception_t * __exception_local = 0;
	NO_UNUSED_WARNING (__exception_local);
	int32_t __leave_target = 0;
	NO_UNUSED_WARNING (__leave_target);
	{
		bool L_0 = Local_VerifyUser_m2348500446(__this, /*hidden argument*/NULL);
		if (L_0)
		{
			goto IL_0011;
		}
	}
	{
		goto IL_00ac;
	}

IL_0011:
	{
		RuntimeObject* L_1 = ___board0;
		V_0 = ((Leaderboard_t1065076763 *)CastclassClass((RuntimeObject*)L_1, Leaderboard_t1065076763_il2cpp_TypeInfo_var));
		List_1_t2537151505 * L_2 = __this->get_m_Leaderboards_5();
		Enumerator_t131428086  L_3 = List_1_GetEnumerator_m3274601223(L_2, /*hidden argument*/List_1_GetEnumerator_m3274601223_RuntimeMethod_var);
		V_2 = L_3;
	}

IL_0025:
	try
	{ // begin try (depth: 1)
		{
			goto IL_0072;
		}

IL_002a:
		{
			Leaderboard_t1065076763 * L_4 = Enumerator_get_Current_m1590304878((&V_2), /*hidden argument*/Enumerator_get_Current_m1590304878_RuntimeMethod_var);
			V_1 = L_4;
			Leaderboard_t1065076763 * L_5 = V_1;
			String_t* L_6 = Leaderboard_get_id_m4258535896(L_5, /*hidden argument*/NULL);
			Leaderboard_t1065076763 * L_7 = V_0;
			String_t* L_8 = Leaderboard_get_id_m4258535896(L_7, /*hidden argument*/NULL);
			IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
			bool L_9 = String_op_Equality_m920492651(NULL /*static, unused*/, L_6, L_8, /*hidden argument*/NULL);
			if (!L_9)
			{
				goto IL_0071;
			}
		}

IL_0049:
		{
			Leaderboard_t1065076763 * L_10 = V_0;
			Leaderboard_t1065076763 * L_11 = V_1;
			String_t* L_12 = Leaderboard_get_title_m3614214113(L_11, /*hidden argument*/NULL);
			Leaderboard_SetTitle_m459905577(L_10, L_12, /*hidden argument*/NULL);
			Leaderboard_t1065076763 * L_13 = V_0;
			Leaderboard_t1065076763 * L_14 = V_1;
			IScoreU5BU5D_t527871248* L_15 = Leaderboard_get_scores_m1529761529(L_14, /*hidden argument*/NULL);
			Leaderboard_SetScores_m2163784072(L_13, L_15, /*hidden argument*/NULL);
			Leaderboard_t1065076763 * L_16 = V_0;
			Leaderboard_t1065076763 * L_17 = V_1;
			IScoreU5BU5D_t527871248* L_18 = Leaderboard_get_scores_m1529761529(L_17, /*hidden argument*/NULL);
			Leaderboard_SetMaxRange_m629679481(L_16, (((int32_t)((int32_t)(((RuntimeArray *)L_18)->max_length)))), /*hidden argument*/NULL);
		}

IL_0071:
		{
		}

IL_0072:
		{
			bool L_19 = Enumerator_MoveNext_m3184043996((&V_2), /*hidden argument*/Enumerator_MoveNext_m3184043996_RuntimeMethod_var);
			if (L_19)
			{
				goto IL_002a;
			}
		}

IL_007e:
		{
			IL2CPP_LEAVE(0x91, FINALLY_0083);
		}
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_0083;
	}

FINALLY_0083:
	{ // begin finally (depth: 1)
		Enumerator_Dispose_m1743516632((&V_2), /*hidden argument*/Enumerator_Dispose_m1743516632_RuntimeMethod_var);
		IL2CPP_END_FINALLY(131)
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(131)
	{
		IL2CPP_JUMP_TBL(0x91, IL_0091)
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
	}

IL_0091:
	{
		Leaderboard_t1065076763 * L_20 = V_0;
		Local_SortScores_m3988362938(__this, L_20, /*hidden argument*/NULL);
		Leaderboard_t1065076763 * L_21 = V_0;
		Local_SetLocalPlayerScore_m2220463184(__this, L_21, /*hidden argument*/NULL);
		Action_1_t269755560 * L_22 = ___callback1;
		if (!L_22)
		{
			goto IL_00ac;
		}
	}
	{
		Action_1_t269755560 * L_23 = ___callback1;
		Action_1_Invoke_m1933767679(L_23, (bool)1, /*hidden argument*/Action_1_Invoke_m1933767679_RuntimeMethod_var);
	}

IL_00ac:
	{
		return;
	}
}
// System.Void UnityEngine.SocialPlatforms.Local::SortScores(UnityEngine.SocialPlatforms.Impl.Leaderboard)
extern "C"  void Local_SortScores_m3988362938 (Local_t4068483442 * __this, Leaderboard_t1065076763 * ___board0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Local_SortScores_m3988362938_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	List_1_t3440720070 * V_0 = NULL;
	int32_t V_1 = 0;
	List_1_t3440720070 * G_B2_0 = NULL;
	List_1_t3440720070 * G_B1_0 = NULL;
	{
		Leaderboard_t1065076763 * L_0 = ___board0;
		IScoreU5BU5D_t527871248* L_1 = Leaderboard_get_scores_m1529761529(L_0, /*hidden argument*/NULL);
		List_1_t3440720070 * L_2 = (List_1_t3440720070 *)il2cpp_codegen_object_new(List_1_t3440720070_il2cpp_TypeInfo_var);
		List_1__ctor_m176386895(L_2, (RuntimeObject*)(RuntimeObject*)((ScoreU5BU5D_t972561905*)Castclass((RuntimeObject*)L_1, ScoreU5BU5D_t972561905_il2cpp_TypeInfo_var)), /*hidden argument*/List_1__ctor_m176386895_RuntimeMethod_var);
		V_0 = L_2;
		List_1_t3440720070 * L_3 = V_0;
		IL2CPP_RUNTIME_CLASS_INIT(Local_t4068483442_il2cpp_TypeInfo_var);
		Comparison_1_t1743576507 * L_4 = ((Local_t4068483442_StaticFields*)il2cpp_codegen_static_fields_for(Local_t4068483442_il2cpp_TypeInfo_var))->get_U3CU3Ef__amU24cache0_7();
		G_B1_0 = L_3;
		if (L_4)
		{
			G_B2_0 = L_3;
			goto IL_002b;
		}
	}
	{
		intptr_t L_5 = (intptr_t)Local_U3CSortScoresU3Em__0_m2862368374_RuntimeMethod_var;
		Comparison_1_t1743576507 * L_6 = (Comparison_1_t1743576507 *)il2cpp_codegen_object_new(Comparison_1_t1743576507_il2cpp_TypeInfo_var);
		Comparison_1__ctor_m2373250861(L_6, NULL, L_5, /*hidden argument*/Comparison_1__ctor_m2373250861_RuntimeMethod_var);
		IL2CPP_RUNTIME_CLASS_INIT(Local_t4068483442_il2cpp_TypeInfo_var);
		((Local_t4068483442_StaticFields*)il2cpp_codegen_static_fields_for(Local_t4068483442_il2cpp_TypeInfo_var))->set_U3CU3Ef__amU24cache0_7(L_6);
		G_B2_0 = G_B1_0;
	}

IL_002b:
	{
		IL2CPP_RUNTIME_CLASS_INIT(Local_t4068483442_il2cpp_TypeInfo_var);
		Comparison_1_t1743576507 * L_7 = ((Local_t4068483442_StaticFields*)il2cpp_codegen_static_fields_for(Local_t4068483442_il2cpp_TypeInfo_var))->get_U3CU3Ef__amU24cache0_7();
		List_1_Sort_m1667366135(G_B2_0, L_7, /*hidden argument*/List_1_Sort_m1667366135_RuntimeMethod_var);
		V_1 = 0;
		goto IL_004f;
	}

IL_003c:
	{
		List_1_t3440720070 * L_8 = V_0;
		int32_t L_9 = V_1;
		Score_t1968645328 * L_10 = List_1_get_Item_m3843832117(L_8, L_9, /*hidden argument*/List_1_get_Item_m3843832117_RuntimeMethod_var);
		int32_t L_11 = V_1;
		Score_SetRank_m588673792(L_10, ((int32_t)il2cpp_codegen_add((int32_t)L_11, (int32_t)1)), /*hidden argument*/NULL);
		int32_t L_12 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add((int32_t)L_12, (int32_t)1));
	}

IL_004f:
	{
		int32_t L_13 = V_1;
		List_1_t3440720070 * L_14 = V_0;
		int32_t L_15 = List_1_get_Count_m1172671670(L_14, /*hidden argument*/List_1_get_Count_m1172671670_RuntimeMethod_var);
		if ((((int32_t)L_13) < ((int32_t)L_15)))
		{
			goto IL_003c;
		}
	}
	{
		return;
	}
}
// System.Void UnityEngine.SocialPlatforms.Local::SetLocalPlayerScore(UnityEngine.SocialPlatforms.Impl.Leaderboard)
extern "C"  void Local_SetLocalPlayerScore_m2220463184 (Local_t4068483442 * __this, Leaderboard_t1065076763 * ___board0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Local_SetLocalPlayerScore_m2220463184_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	Score_t1968645328 * V_0 = NULL;
	IScoreU5BU5D_t527871248* V_1 = NULL;
	int32_t V_2 = 0;
	{
		Leaderboard_t1065076763 * L_0 = ___board0;
		IScoreU5BU5D_t527871248* L_1 = Leaderboard_get_scores_m1529761529(L_0, /*hidden argument*/NULL);
		V_1 = L_1;
		V_2 = 0;
		goto IL_0047;
	}

IL_0010:
	{
		IScoreU5BU5D_t527871248* L_2 = V_1;
		int32_t L_3 = V_2;
		int32_t L_4 = L_3;
		RuntimeObject* L_5 = (L_2)->GetAtUnchecked(static_cast<il2cpp_array_size_t>(L_4));
		V_0 = ((Score_t1968645328 *)CastclassClass((RuntimeObject*)L_5, Score_t1968645328_il2cpp_TypeInfo_var));
		Score_t1968645328 * L_6 = V_0;
		String_t* L_7 = Score_get_userID_m602877400(L_6, /*hidden argument*/NULL);
		RuntimeObject* L_8 = Local_get_localUser_m1583274769(__this, /*hidden argument*/NULL);
		String_t* L_9 = InterfaceFuncInvoker0< String_t* >::Invoke(0 /* System.String UnityEngine.SocialPlatforms.IUserProfile::get_id() */, IUserProfile_t360500636_il2cpp_TypeInfo_var, L_8);
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_10 = String_op_Equality_m920492651(NULL /*static, unused*/, L_7, L_9, /*hidden argument*/NULL);
		if (!L_10)
		{
			goto IL_0042;
		}
	}
	{
		Leaderboard_t1065076763 * L_11 = ___board0;
		Score_t1968645328 * L_12 = V_0;
		Leaderboard_SetLocalUserScore_m3569886016(L_11, L_12, /*hidden argument*/NULL);
		goto IL_0050;
	}

IL_0042:
	{
		int32_t L_13 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add((int32_t)L_13, (int32_t)1));
	}

IL_0047:
	{
		int32_t L_14 = V_2;
		IScoreU5BU5D_t527871248* L_15 = V_1;
		if ((((int32_t)L_14) < ((int32_t)(((int32_t)((int32_t)(((RuntimeArray *)L_15)->max_length)))))))
		{
			goto IL_0010;
		}
	}

IL_0050:
	{
		return;
	}
}
// System.Void UnityEngine.SocialPlatforms.Local::ShowAchievementsUI()
extern "C"  void Local_ShowAchievementsUI_m4021375320 (Local_t4068483442 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Local_ShowAchievementsUI_m4021375320_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(Debug_t3317548046_il2cpp_TypeInfo_var);
		Debug_Log_m4051431634(NULL /*static, unused*/, _stringLiteral2433254339, /*hidden argument*/NULL);
		return;
	}
}
// System.Void UnityEngine.SocialPlatforms.Local::ShowLeaderboardUI()
extern "C"  void Local_ShowLeaderboardUI_m151660348 (Local_t4068483442 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Local_ShowLeaderboardUI_m151660348_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(Debug_t3317548046_il2cpp_TypeInfo_var);
		Debug_Log_m4051431634(NULL /*static, unused*/, _stringLiteral3249695287, /*hidden argument*/NULL);
		return;
	}
}
// UnityEngine.SocialPlatforms.ILeaderboard UnityEngine.SocialPlatforms.Local::CreateLeaderboard()
extern "C"  RuntimeObject* Local_CreateLeaderboard_m1529960496 (Local_t4068483442 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Local_CreateLeaderboard_m1529960496_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	Leaderboard_t1065076763 * V_0 = NULL;
	RuntimeObject* V_1 = NULL;
	{
		Leaderboard_t1065076763 * L_0 = (Leaderboard_t1065076763 *)il2cpp_codegen_object_new(Leaderboard_t1065076763_il2cpp_TypeInfo_var);
		Leaderboard__ctor_m1030108446(L_0, /*hidden argument*/NULL);
		V_0 = L_0;
		Leaderboard_t1065076763 * L_1 = V_0;
		V_1 = L_1;
		goto IL_000e;
	}

IL_000e:
	{
		RuntimeObject* L_2 = V_1;
		return L_2;
	}
}
// System.Boolean UnityEngine.SocialPlatforms.Local::VerifyUser()
extern "C"  bool Local_VerifyUser_m2348500446 (Local_t4068483442 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Local_VerifyUser_m2348500446_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	{
		RuntimeObject* L_0 = Local_get_localUser_m1583274769(__this, /*hidden argument*/NULL);
		bool L_1 = InterfaceFuncInvoker0< bool >::Invoke(1 /* System.Boolean UnityEngine.SocialPlatforms.ILocalUser::get_authenticated() */, ILocalUser_t2242999785_il2cpp_TypeInfo_var, L_0);
		if (L_1)
		{
			goto IL_0023;
		}
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(Debug_t3317548046_il2cpp_TypeInfo_var);
		Debug_LogError_m2850623458(NULL /*static, unused*/, _stringLiteral3019217460, /*hidden argument*/NULL);
		V_0 = (bool)0;
		goto IL_002a;
	}

IL_0023:
	{
		V_0 = (bool)1;
		goto IL_002a;
	}

IL_002a:
	{
		bool L_2 = V_0;
		return L_2;
	}
}
// System.Void UnityEngine.SocialPlatforms.Local::PopulateStaticData()
extern "C"  void Local_PopulateStaticData_m916798409 (Local_t4068483442 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Local_PopulateStaticData_m916798409_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	Leaderboard_t1065076763 * V_0 = NULL;
	List_1_t3440720070 * V_1 = NULL;
	DateTime_t3738529785  V_2;
	memset(&V_2, 0, sizeof(V_2));
	DateTime_t3738529785  V_3;
	memset(&V_3, 0, sizeof(V_3));
	DateTime_t3738529785  V_4;
	memset(&V_4, 0, sizeof(V_4));
	DateTime_t3738529785  V_5;
	memset(&V_5, 0, sizeof(V_5));
	{
		List_1_t314435623 * L_0 = __this->get_m_Friends_1();
		Texture2D_t3840446185 * L_1 = __this->get_m_DefaultTexture_6();
		UserProfile_t3137328177 * L_2 = (UserProfile_t3137328177 *)il2cpp_codegen_object_new(UserProfile_t3137328177_il2cpp_TypeInfo_var);
		UserProfile__ctor_m2409346676(L_2, _stringLiteral2758590827, _stringLiteral1972262697, (bool)1, 0, L_1, /*hidden argument*/NULL);
		List_1_Add_m1578522892(L_0, L_2, /*hidden argument*/List_1_Add_m1578522892_RuntimeMethod_var);
		List_1_t314435623 * L_3 = __this->get_m_Friends_1();
		Texture2D_t3840446185 * L_4 = __this->get_m_DefaultTexture_6();
		UserProfile_t3137328177 * L_5 = (UserProfile_t3137328177 *)il2cpp_codegen_object_new(UserProfile_t3137328177_il2cpp_TypeInfo_var);
		UserProfile__ctor_m2409346676(L_5, _stringLiteral2754897401, _stringLiteral3928577833, (bool)1, 0, L_4, /*hidden argument*/NULL);
		List_1_Add_m1578522892(L_3, L_5, /*hidden argument*/List_1_Add_m1578522892_RuntimeMethod_var);
		List_1_t314435623 * L_6 = __this->get_m_Friends_1();
		Texture2D_t3840446185 * L_7 = __this->get_m_DefaultTexture_6();
		UserProfile_t3137328177 * L_8 = (UserProfile_t3137328177 *)il2cpp_codegen_object_new(UserProfile_t3137328177_il2cpp_TypeInfo_var);
		UserProfile__ctor_m2409346676(L_8, _stringLiteral808924690, _stringLiteral1589925673, (bool)1, 0, L_7, /*hidden argument*/NULL);
		List_1_Add_m1578522892(L_6, L_8, /*hidden argument*/List_1_Add_m1578522892_RuntimeMethod_var);
		List_1_t314435623 * L_9 = __this->get_m_Users_2();
		Texture2D_t3840446185 * L_10 = __this->get_m_DefaultTexture_6();
		UserProfile_t3137328177 * L_11 = (UserProfile_t3137328177 *)il2cpp_codegen_object_new(UserProfile_t3137328177_il2cpp_TypeInfo_var);
		UserProfile__ctor_m2409346676(L_11, _stringLiteral1343626406, _stringLiteral3546240809, (bool)0, 3, L_10, /*hidden argument*/NULL);
		List_1_Add_m1578522892(L_9, L_11, /*hidden argument*/List_1_Add_m1578522892_RuntimeMethod_var);
		List_1_t314435623 * L_12 = __this->get_m_Users_2();
		Texture2D_t3840446185 * L_13 = __this->get_m_DefaultTexture_6();
		UserProfile_t3137328177 * L_14 = (UserProfile_t3137328177 *)il2cpp_codegen_object_new(UserProfile_t3137328177_il2cpp_TypeInfo_var);
		UserProfile__ctor_m2409346676(L_14, _stringLiteral4166618085, _stringLiteral1207588649, (bool)0, 3, L_13, /*hidden argument*/NULL);
		List_1_Add_m1578522892(L_12, L_14, /*hidden argument*/List_1_Add_m1578522892_RuntimeMethod_var);
		List_1_t394701973 * L_15 = __this->get_m_AchievementDescriptions_3();
		Texture2D_t3840446185 * L_16 = __this->get_m_DefaultTexture_6();
		AchievementDescription_t3217594527 * L_17 = (AchievementDescription_t3217594527 *)il2cpp_codegen_object_new(AchievementDescription_t3217594527_il2cpp_TypeInfo_var);
		AchievementDescription__ctor_m2104645942(L_17, _stringLiteral71334293, _stringLiteral790607520, L_16, _stringLiteral3353015368, _stringLiteral1815849347, (bool)0, ((int32_t)10), /*hidden argument*/NULL);
		List_1_Add_m1774517840(L_15, L_17, /*hidden argument*/List_1_Add_m1774517840_RuntimeMethod_var);
		List_1_t394701973 * L_18 = __this->get_m_AchievementDescriptions_3();
		Texture2D_t3840446185 * L_19 = __this->get_m_DefaultTexture_6();
		AchievementDescription_t3217594527 * L_20 = (AchievementDescription_t3217594527 *)il2cpp_codegen_object_new(AchievementDescription_t3217594527_il2cpp_TypeInfo_var);
		AchievementDescription__ctor_m2104645942(L_20, _stringLiteral71334296, _stringLiteral1410607624, L_19, _stringLiteral1736209072, _stringLiteral797346979, (bool)0, ((int32_t)20), /*hidden argument*/NULL);
		List_1_Add_m1774517840(L_18, L_20, /*hidden argument*/List_1_Add_m1774517840_RuntimeMethod_var);
		List_1_t394701973 * L_21 = __this->get_m_AchievementDescriptions_3();
		Texture2D_t3840446185 * L_22 = __this->get_m_DefaultTexture_6();
		AchievementDescription_t3217594527 * L_23 = (AchievementDescription_t3217594527 *)il2cpp_codegen_object_new(AchievementDescription_t3217594527_il2cpp_TypeInfo_var);
		AchievementDescription__ctor_m2104645942(L_23, _stringLiteral71334295, _stringLiteral4060093497, L_22, _stringLiteral3410331484, _stringLiteral2859292443, (bool)0, ((int32_t)15), /*hidden argument*/NULL);
		List_1_Add_m1774517840(L_21, L_23, /*hidden argument*/List_1_Add_m1774517840_RuntimeMethod_var);
		Leaderboard_t1065076763 * L_24 = (Leaderboard_t1065076763 *)il2cpp_codegen_object_new(Leaderboard_t1065076763_il2cpp_TypeInfo_var);
		Leaderboard__ctor_m1030108446(L_24, /*hidden argument*/NULL);
		V_0 = L_24;
		Leaderboard_t1065076763 * L_25 = V_0;
		Leaderboard_SetTitle_m459905577(L_25, _stringLiteral2862084853, /*hidden argument*/NULL);
		Leaderboard_t1065076763 * L_26 = V_0;
		Leaderboard_set_id_m3990768853(L_26, _stringLiteral174720081, /*hidden argument*/NULL);
		List_1_t3440720070 * L_27 = (List_1_t3440720070 *)il2cpp_codegen_object_new(List_1_t3440720070_il2cpp_TypeInfo_var);
		List_1__ctor_m1850989583(L_27, /*hidden argument*/List_1__ctor_m1850989583_RuntimeMethod_var);
		V_1 = L_27;
		List_1_t3440720070 * L_28 = V_1;
		IL2CPP_RUNTIME_CLASS_INIT(DateTime_t3738529785_il2cpp_TypeInfo_var);
		DateTime_t3738529785  L_29 = DateTime_get_Now_m1277138875(NULL /*static, unused*/, /*hidden argument*/NULL);
		V_2 = L_29;
		DateTime_t3738529785  L_30 = DateTime_AddDays_m2583849741((&V_2), (-1.0), /*hidden argument*/NULL);
		Score_t1968645328 * L_31 = (Score_t1968645328 *)il2cpp_codegen_object_new(Score_t1968645328_il2cpp_TypeInfo_var);
		Score__ctor_m1554947855(L_31, _stringLiteral174720081, (((int64_t)((int64_t)((int32_t)300)))), _stringLiteral1972262697, L_30, _stringLiteral3889212743, 1, /*hidden argument*/NULL);
		List_1_Add_m1702244787(L_28, L_31, /*hidden argument*/List_1_Add_m1702244787_RuntimeMethod_var);
		List_1_t3440720070 * L_32 = V_1;
		DateTime_t3738529785  L_33 = DateTime_get_Now_m1277138875(NULL /*static, unused*/, /*hidden argument*/NULL);
		V_3 = L_33;
		DateTime_t3738529785  L_34 = DateTime_AddDays_m2583849741((&V_3), (-1.0), /*hidden argument*/NULL);
		Score_t1968645328 * L_35 = (Score_t1968645328 *)il2cpp_codegen_object_new(Score_t1968645328_il2cpp_TypeInfo_var);
		Score__ctor_m1554947855(L_35, _stringLiteral174720081, (((int64_t)((int64_t)((int32_t)255)))), _stringLiteral3928577833, L_34, _stringLiteral2704654648, 2, /*hidden argument*/NULL);
		List_1_Add_m1702244787(L_32, L_35, /*hidden argument*/List_1_Add_m1702244787_RuntimeMethod_var);
		List_1_t3440720070 * L_36 = V_1;
		DateTime_t3738529785  L_37 = DateTime_get_Now_m1277138875(NULL /*static, unused*/, /*hidden argument*/NULL);
		V_4 = L_37;
		DateTime_t3738529785  L_38 = DateTime_AddDays_m2583849741((&V_4), (-1.0), /*hidden argument*/NULL);
		Score_t1968645328 * L_39 = (Score_t1968645328 *)il2cpp_codegen_object_new(Score_t1968645328_il2cpp_TypeInfo_var);
		Score__ctor_m1554947855(L_39, _stringLiteral174720081, (((int64_t)((int64_t)((int32_t)55)))), _stringLiteral1589925673, L_38, _stringLiteral2937937919, 3, /*hidden argument*/NULL);
		List_1_Add_m1702244787(L_36, L_39, /*hidden argument*/List_1_Add_m1702244787_RuntimeMethod_var);
		List_1_t3440720070 * L_40 = V_1;
		DateTime_t3738529785  L_41 = DateTime_get_Now_m1277138875(NULL /*static, unused*/, /*hidden argument*/NULL);
		V_5 = L_41;
		DateTime_t3738529785  L_42 = DateTime_AddDays_m2583849741((&V_5), (-1.0), /*hidden argument*/NULL);
		Score_t1968645328 * L_43 = (Score_t1968645328 *)il2cpp_codegen_object_new(Score_t1968645328_il2cpp_TypeInfo_var);
		Score__ctor_m1554947855(L_43, _stringLiteral174720081, (((int64_t)((int64_t)((int32_t)10)))), _stringLiteral3546240809, L_42, _stringLiteral3714347010, 4, /*hidden argument*/NULL);
		List_1_Add_m1702244787(L_40, L_43, /*hidden argument*/List_1_Add_m1702244787_RuntimeMethod_var);
		Leaderboard_t1065076763 * L_44 = V_0;
		List_1_t3440720070 * L_45 = V_1;
		ScoreU5BU5D_t972561905* L_46 = List_1_ToArray_m2845752048(L_45, /*hidden argument*/List_1_ToArray_m2845752048_RuntimeMethod_var);
		Leaderboard_SetScores_m2163784072(L_44, (IScoreU5BU5D_t527871248*)(IScoreU5BU5D_t527871248*)L_46, /*hidden argument*/NULL);
		List_1_t2537151505 * L_47 = __this->get_m_Leaderboards_5();
		Leaderboard_t1065076763 * L_48 = V_0;
		List_1_Add_m351770690(L_47, L_48, /*hidden argument*/List_1_Add_m351770690_RuntimeMethod_var);
		return;
	}
}
// UnityEngine.Texture2D UnityEngine.SocialPlatforms.Local::CreateDummyTexture(System.Int32,System.Int32)
extern "C"  Texture2D_t3840446185 * Local_CreateDummyTexture_m3769606019 (Local_t4068483442 * __this, int32_t ___width0, int32_t ___height1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Local_CreateDummyTexture_m3769606019_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	Texture2D_t3840446185 * V_0 = NULL;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	Color_t2555686324  V_3;
	memset(&V_3, 0, sizeof(V_3));
	Texture2D_t3840446185 * V_4 = NULL;
	Color_t2555686324  G_B5_0;
	memset(&G_B5_0, 0, sizeof(G_B5_0));
	{
		int32_t L_0 = ___width0;
		int32_t L_1 = ___height1;
		Texture2D_t3840446185 * L_2 = (Texture2D_t3840446185 *)il2cpp_codegen_object_new(Texture2D_t3840446185_il2cpp_TypeInfo_var);
		Texture2D__ctor_m373113269(L_2, L_0, L_1, /*hidden argument*/NULL);
		V_0 = L_2;
		V_1 = 0;
		goto IL_004c;
	}

IL_0010:
	{
		V_2 = 0;
		goto IL_0040;
	}

IL_0018:
	{
		int32_t L_3 = V_2;
		int32_t L_4 = V_1;
		if ((((int32_t)((int32_t)((int32_t)L_3&(int32_t)L_4))) <= ((int32_t)0)))
		{
			goto IL_002c;
		}
	}
	{
		Color_t2555686324  L_5 = Color_get_white_m332174077(NULL /*static, unused*/, /*hidden argument*/NULL);
		G_B5_0 = L_5;
		goto IL_0031;
	}

IL_002c:
	{
		Color_t2555686324  L_6 = Color_get_gray_m1471337008(NULL /*static, unused*/, /*hidden argument*/NULL);
		G_B5_0 = L_6;
	}

IL_0031:
	{
		V_3 = G_B5_0;
		Texture2D_t3840446185 * L_7 = V_0;
		int32_t L_8 = V_2;
		int32_t L_9 = V_1;
		Color_t2555686324  L_10 = V_3;
		Texture2D_SetPixel_m2984741184(L_7, L_8, L_9, L_10, /*hidden argument*/NULL);
		int32_t L_11 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add((int32_t)L_11, (int32_t)1));
	}

IL_0040:
	{
		int32_t L_12 = V_2;
		int32_t L_13 = ___width0;
		if ((((int32_t)L_12) < ((int32_t)L_13)))
		{
			goto IL_0018;
		}
	}
	{
		int32_t L_14 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add((int32_t)L_14, (int32_t)1));
	}

IL_004c:
	{
		int32_t L_15 = V_1;
		int32_t L_16 = ___height1;
		if ((((int32_t)L_15) < ((int32_t)L_16)))
		{
			goto IL_0010;
		}
	}
	{
		Texture2D_t3840446185 * L_17 = V_0;
		Texture2D_Apply_m2271746283(L_17, /*hidden argument*/NULL);
		Texture2D_t3840446185 * L_18 = V_0;
		V_4 = L_18;
		goto IL_0061;
	}

IL_0061:
	{
		Texture2D_t3840446185 * L_19 = V_4;
		return L_19;
	}
}
// System.Void UnityEngine.SocialPlatforms.Local::.cctor()
extern "C"  void Local__cctor_m4006956713 (RuntimeObject * __this /* static, unused */, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Local__cctor_m4006956713_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		((Local_t4068483442_StaticFields*)il2cpp_codegen_static_fields_for(Local_t4068483442_il2cpp_TypeInfo_var))->set_m_LocalUser_0((LocalUser_t365094499 *)NULL);
		return;
	}
}
// System.Int32 UnityEngine.SocialPlatforms.Local::<SortScores>m__0(UnityEngine.SocialPlatforms.Impl.Score,UnityEngine.SocialPlatforms.Impl.Score)
extern "C"  int32_t Local_U3CSortScoresU3Em__0_m2862368374 (RuntimeObject * __this /* static, unused */, Score_t1968645328 * ___s10, Score_t1968645328 * ___s21, const RuntimeMethod* method)
{
	int64_t V_0 = 0;
	int32_t V_1 = 0;
	{
		Score_t1968645328 * L_0 = ___s21;
		int64_t L_1 = Score_get_value_m3180422307(L_0, /*hidden argument*/NULL);
		V_0 = L_1;
		Score_t1968645328 * L_2 = ___s10;
		int64_t L_3 = Score_get_value_m3180422307(L_2, /*hidden argument*/NULL);
		int32_t L_4 = Int64_CompareTo_m3345789408((&V_0), L_3, /*hidden argument*/NULL);
		V_1 = L_4;
		goto IL_001b;
	}

IL_001b:
	{
		int32_t L_5 = V_1;
		return L_5;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void UnityEngine.SocialPlatforms.Range::.ctor(System.Int32,System.Int32)
extern "C"  void Range__ctor_m3975982763 (Range_t173988048 * __this, int32_t ___fromValue0, int32_t ___valueCount1, const RuntimeMethod* method)
{
	{
		int32_t L_0 = ___fromValue0;
		__this->set_from_0(L_0);
		int32_t L_1 = ___valueCount1;
		__this->set_count_1(L_1);
		return;
	}
}
extern "C"  void Range__ctor_m3975982763_AdjustorThunk (RuntimeObject * __this, int32_t ___fromValue0, int32_t ___valueCount1, const RuntimeMethod* method)
{
	Range_t173988048 * _thisAdjusted = reinterpret_cast<Range_t173988048 *>(__this + 1);
	Range__ctor_m3975982763(_thisAdjusted, ___fromValue0, ___valueCount1, method);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
