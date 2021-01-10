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

template <typename T1, typename T2>
struct VirtActionInvoker2
{
	typedef void (*Action)(void*, T1, T2, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		((Action)invokeData.methodPtr)(obj, p1, p2, invokeData.method);
	}
};
template <typename R, typename T1>
struct VirtFuncInvoker1
{
	typedef R (*Func)(void*, T1, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename R>
struct VirtFuncInvoker0
{
	typedef R (*Func)(void*, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, invokeData.method);
	}
};
template <typename T1>
struct VirtActionInvoker1
{
	typedef void (*Action)(void*, T1, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		((Action)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename R, typename T1, typename T2, typename T3>
struct VirtFuncInvoker3
{
	typedef R (*Func)(void*, T1, T2, T3, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2, T3 p3)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, p1, p2, p3, invokeData.method);
	}
};
template <typename R, typename T1, typename T2>
struct VirtFuncInvoker2
{
	typedef R (*Func)(void*, T1, T2, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, p1, p2, invokeData.method);
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
struct InterfaceActionInvoker0
{
	typedef void (*Action)(void*, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3, typename T4>
struct InterfaceActionInvoker4
{
	typedef void (*Action)(void*, T1, T2, T3, T4, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, p4, invokeData.method);
	}
};

// System.Text.RegularExpressions.Syntax.PositionAssertion
struct PositionAssertion_t3339288061;
// System.Text.RegularExpressions.Syntax.Expression
struct Expression_t2722445759;
// System.Text.RegularExpressions.ICompiler
struct ICompiler_t118549125;
// System.Text.RegularExpressions.Syntax.AnchorInfo
struct AnchorInfo_t3387011151;
// System.Text.RegularExpressions.Syntax.Reference
struct Reference_t1799410108;
// System.Text.RegularExpressions.Syntax.CapturingGroup
struct CapturingGroup_t751358689;
// System.Text.RegularExpressions.Syntax.RegularExpression
struct RegularExpression_t3834220169;
// System.Text.RegularExpressions.Syntax.Group
struct Group_t1458537008;
// System.String
struct String_t;
// System.Text.RegularExpressions.Syntax.Repetition
struct Repetition_t2393242404;
// System.Text.RegularExpressions.Syntax.CompositeExpression
struct CompositeExpression_t1252229802;
// System.Text.RegularExpressions.Syntax.ExpressionCollection
struct ExpressionCollection_t1810289389;
// System.Text.StringBuilder
struct StringBuilder_t;
// System.Uri
struct Uri_t100236324;
// System.Runtime.Serialization.SerializationInfo
struct SerializationInfo_t950877179;
// System.UriFormatException
struct UriFormatException_t953270471;
// System.Object[]
struct ObjectU5BU5D_t2843939325;
// System.ArgumentException
struct ArgumentException_t132251570;
// System.ArgumentNullException
struct ArgumentNullException_t1615371798;
// System.ArgumentOutOfRangeException
struct ArgumentOutOfRangeException_t777629997;
// System.Char[]
struct CharU5BU5D_t3528271667;
// System.Collections.Generic.Dictionary`2<System.String,System.Int32>
struct Dictionary_2_t2736202052;
// System.Collections.Generic.Dictionary`2<System.Object,System.Int32>
struct Dictionary_2_t3384741;
// System.Net.IPAddress
struct IPAddress_t241777590;
// System.Net.IPv6Address
struct IPv6Address_t2709566769;
// System.String[]
struct StringU5BU5D_t1281789340;
// System.Globalization.CultureInfo
struct CultureInfo_t4157843068;
// System.Text.Encoding
struct Encoding_t1523322056;
// System.IFormatProvider
struct IFormatProvider_t2518567562;
// System.UriParser
struct UriParser_t3890150400;
// System.Collections.ArrayList
struct ArrayList_t2718874744;
// System.DefaultUriParser
struct DefaultUriParser_t95882050;
// System.IO.MemoryStream
struct MemoryStream_t94973147;
// System.InvalidOperationException
struct InvalidOperationException_t56020091;
// System.FormatException
struct FormatException_t154580423;
// System.Text.RegularExpressions.Regex
struct Regex_t3657309853;
// System.Collections.Hashtable
struct Hashtable_t1853889766;
// System.UriTypeConverter
struct UriTypeConverter_t3695916615;
// System.Type
struct Type_t;
// System.ComponentModel.ITypeDescriptorContext
struct ITypeDescriptorContext_t2998566513;
// System.NotSupportedException
struct NotSupportedException_t1314879016;
// System.ComponentModel.TypeConverter
struct TypeConverter_t2249118273;
// System.Text.DecoderFallback
struct DecoderFallback_t3123823036;
// System.Text.EncoderFallback
struct EncoderFallback_t1188251036;
// System.Reflection.Assembly
struct Assembly_t;
// System.Globalization.NumberFormatInfo
struct NumberFormatInfo_t435877138;
// System.Globalization.DateTimeFormatInfo
struct DateTimeFormatInfo_t2405853701;
// System.Globalization.TextInfo
struct TextInfo_t3810425522;
// System.Globalization.CompareInfo
struct CompareInfo_t1092934962;
// System.Globalization.Calendar[]
struct CalendarU5BU5D_t3985046076;
// System.Globalization.Calendar
struct Calendar_t1661121569;
// System.Byte[]
struct ByteU5BU5D_t4116647657;
// System.Int32
struct Int32_t2950945753;
// System.Void
struct Void_t1185182177;
// System.UInt16[]
struct UInt16U5BU5D_t3326319531;
// System.Uri/UriScheme[]
struct UriSchemeU5BU5D_t2082808316;
// System.Runtime.Serialization.IFormatterConverter
struct IFormatterConverter_t2171992254;
// System.Int32[]
struct Int32U5BU5D_t385246372;
// System.Collections.Generic.Link[]
struct LinkU5BU5D_t964245573;
// System.Collections.Generic.IEqualityComparer`1<System.String>
struct IEqualityComparer_1_t3954782707;
// System.Collections.Generic.Dictionary`2/Transform`1<System.String,System.Int32,System.Collections.DictionaryEntry>
struct Transform_1_t3530625384;
// System.IntPtr[]
struct IntPtrU5BU5D_t4013366056;
// System.Collections.IDictionary
struct IDictionary_t1363984059;
// System.Collections.Hashtable/Slot[]
struct SlotU5BU5D_t2994659099;
// System.Collections.Hashtable/HashKeys
struct HashKeys_t1568156503;
// System.Collections.Hashtable/HashValues
struct HashValues_t618387445;
// System.Collections.IHashCodeProvider
struct IHashCodeProvider_t267601189;
// System.Collections.IComparer
struct IComparer_t1540313114;
// System.Collections.IEqualityComparer
struct IEqualityComparer_t1493878338;
// System.Byte
struct Byte_t1134296376;
// System.Double
struct Double_t594665363;
// System.UInt16
struct UInt16_t2177724958;
// System.Type[]
struct TypeU5BU5D_t3940880105;
// System.Reflection.MemberFilter
struct MemberFilter_t426314064;
// System.Text.RegularExpressions.FactoryCache
struct FactoryCache_t2327118887;
// System.Text.RegularExpressions.IMachineFactory
struct IMachineFactory_t1209798546;
// System.Collections.Generic.Dictionary`2<System.Int32,System.Int32>
struct Dictionary_2_t1839659084;

extern RuntimeClass* ICompiler_t118549125_il2cpp_TypeInfo_var;
extern const uint32_t PositionAssertion_Compile_m2500980346_MetadataUsageId;
extern RuntimeClass* AnchorInfo_t3387011151_il2cpp_TypeInfo_var;
extern const uint32_t PositionAssertion_GetAnchorInfo_m32057718_MetadataUsageId;
extern const uint32_t Reference_Compile_m4195878675_MetadataUsageId;
extern const uint32_t RegularExpression_Compile_m2385682508_MetadataUsageId;
extern const uint32_t Repetition_Compile_m988726715_MetadataUsageId;
extern RuntimeClass* StringBuilder_t_il2cpp_TypeInfo_var;
extern const uint32_t Repetition_GetAnchorInfo_m2615648496_MetadataUsageId;
extern String_t* _stringLiteral1705674066;
extern const uint32_t Uri__ctor_m3848281005_MetadataUsageId;
extern RuntimeClass* String_t_il2cpp_TypeInfo_var;
extern RuntimeClass* UriFormatException_t953270471_il2cpp_TypeInfo_var;
extern RuntimeClass* ObjectU5BU5D_t2843939325_il2cpp_TypeInfo_var;
extern RuntimeClass* UriKind_t3816567336_il2cpp_TypeInfo_var;
extern RuntimeClass* ArgumentException_t132251570_il2cpp_TypeInfo_var;
extern const RuntimeMethod* Uri__ctor_m3040793867_RuntimeMethod_var;
extern String_t* _stringLiteral1267661654;
extern String_t* _stringLiteral3167450820;
extern String_t* _stringLiteral2894849996;
extern const uint32_t Uri__ctor_m3040793867_MetadataUsageId;
extern const RuntimeMethod* Uri__ctor_m1916875437_RuntimeMethod_var;
extern const uint32_t Uri__ctor_m1916875437_MetadataUsageId;
extern RuntimeClass* Uri_t100236324_il2cpp_TypeInfo_var;
extern const uint32_t Uri__ctor_m253204164_MetadataUsageId;
extern const RuntimeMethod* Uri__ctor_m3577021606_RuntimeMethod_var;
extern String_t* _stringLiteral1833178994;
extern const uint32_t Uri__ctor_m3577021606_MetadataUsageId;
extern const uint32_t Uri__ctor_m4293005803_MetadataUsageId;
extern RuntimeClass* UriSchemeU5BU5D_t2082808316_il2cpp_TypeInfo_var;
extern String_t* _stringLiteral598647136;
extern String_t* _stringLiteral1057238085;
extern String_t* _stringLiteral1629333464;
extern String_t* _stringLiteral228733076;
extern String_t* _stringLiteral2386815142;
extern String_t* _stringLiteral3140485902;
extern String_t* _stringLiteral1973861653;
extern String_t* _stringLiteral416809914;
extern String_t* _stringLiteral15098073;
extern String_t* _stringLiteral3139830536;
extern String_t* _stringLiteral3041793228;
extern String_t* _stringLiteral1761547464;
extern String_t* _stringLiteral3452614550;
extern const uint32_t Uri__cctor_m38080231_MetadataUsageId;
extern RuntimeClass* ArgumentNullException_t1615371798_il2cpp_TypeInfo_var;
extern RuntimeClass* ArgumentOutOfRangeException_t777629997_il2cpp_TypeInfo_var;
extern RuntimeClass* CharU5BU5D_t3528271667_il2cpp_TypeInfo_var;
extern RuntimeClass* Char_t3634460470_il2cpp_TypeInfo_var;
extern const RuntimeMethod* Uri_Merge_m76373955_RuntimeMethod_var;
extern String_t* _stringLiteral4058229981;
extern String_t* _stringLiteral3452614525;
extern String_t* _stringLiteral3450582914;
extern String_t* _stringLiteral3139614613;
extern String_t* _stringLiteral3450648450;
extern String_t* _stringLiteral2623387541;
extern const uint32_t Uri_Merge_m76373955_MetadataUsageId;
extern RuntimeClass* Dictionary_2_t2736202052_il2cpp_TypeInfo_var;
extern const RuntimeMethod* Dictionary_2__ctor_m2392909825_RuntimeMethod_var;
extern const RuntimeMethod* Dictionary_2_Add_m282647386_RuntimeMethod_var;
extern const RuntimeMethod* Dictionary_2_TryGetValue_m1013208020_RuntimeMethod_var;
extern String_t* _stringLiteral3452614529;
extern const uint32_t Uri_get_AbsolutePath_m590948575_MetadataUsageId;
extern const uint32_t Uri_get_AbsoluteUri_m2582056986_MetadataUsageId;
extern RuntimeClass* Int32_t2950945753_il2cpp_TypeInfo_var;
extern const uint32_t Uri_get_Authority_m3816772302_MetadataUsageId;
extern const uint32_t Uri_get_HostNameType_m1143766868_MetadataUsageId;
extern const uint32_t Uri_get_IsDefaultPort_m3984463462_MetadataUsageId;
extern const uint32_t Uri_get_IsFile_m2450018824_MetadataUsageId;
extern RuntimeClass* IPAddress_t241777590_il2cpp_TypeInfo_var;
extern RuntimeClass* IPv6Address_t2709566769_il2cpp_TypeInfo_var;
extern String_t* _stringLiteral405613428;
extern String_t* _stringLiteral1305937687;
extern const uint32_t Uri_get_IsLoopback_m2492530169_MetadataUsageId;
extern RuntimeClass* Path_t1605229823_il2cpp_TypeInfo_var;
extern String_t* _stringLiteral3458119668;
extern const uint32_t Uri_get_LocalPath_m2837234216_MetadataUsageId;
extern const uint32_t Uri_get_PathAndQuery_m2396197970_MetadataUsageId;
extern const uint32_t Uri_CheckHostName_m2213216182_MetadataUsageId;
extern const uint32_t Uri_IsIPv4Address_m3535481943_MetadataUsageId;
extern const uint32_t Uri_IsDomainAddress_m2867513594_MetadataUsageId;
extern const uint32_t Uri_CheckSchemeName_m108657675_MetadataUsageId;
extern const uint32_t Uri_Equals_m3263316701_MetadataUsageId;
extern RuntimeClass* CultureInfo_t4157843068_il2cpp_TypeInfo_var;
extern const uint32_t Uri_InternalEquals_m2029068366_MetadataUsageId;
extern const uint32_t Uri_GetHashCode_m321999866_MetadataUsageId;
extern const uint32_t Uri_GetLeftPart_m3979111399_MetadataUsageId;
extern const RuntimeMethod* Uri_FromHex_m2610708947_RuntimeMethod_var;
extern String_t* _stringLiteral2699191085;
extern const uint32_t Uri_FromHex_m2610708947_MetadataUsageId;
extern const RuntimeMethod* Uri_HexEscape_m1589417657_RuntimeMethod_var;
extern String_t* _stringLiteral1776941794;
extern String_t* _stringLiteral3452614523;
extern const uint32_t Uri_HexEscape_m1589417657_MetadataUsageId;
extern const uint32_t Uri_IsHexEncoding_m3290929897_MetadataUsageId;
extern const uint32_t Uri_AppendQueryAndFragment_m3170766010_MetadataUsageId;
extern const uint32_t Uri_ToString_m3742105950_MetadataUsageId;
extern const uint32_t Uri_EscapeString_m2061933484_MetadataUsageId;
extern RuntimeClass* Encoding_t1523322056_il2cpp_TypeInfo_var;
extern String_t* _stringLiteral1759775709;
extern String_t* _stringLiteral259003225;
extern const uint32_t Uri_EscapeString_m3864445955_MetadataUsageId;
extern const uint32_t Uri_ParseUri_m2150795567_MetadataUsageId;
extern const uint32_t Uri_Unescape_m3373094076_MetadataUsageId;
extern String_t* _stringLiteral2671228134;
extern String_t* _stringLiteral3834027548;
extern String_t* _stringLiteral3000541767;
extern const uint32_t Uri_Unescape_m910903869_MetadataUsageId;
extern String_t* _stringLiteral3452614644;
extern const uint32_t Uri_ParseAsWindowsUNC_m2348878458_MetadataUsageId;
extern String_t* _stringLiteral796679200;
extern const uint32_t Uri_ParseAsWindowsAbsoluteFilePath_m708354183_MetadataUsageId;
extern const uint32_t Uri_ParseAsUnixAbsoluteFilePath_m1476768041_MetadataUsageId;
extern const RuntimeMethod* Uri_Parse_m736300106_RuntimeMethod_var;
extern String_t* _stringLiteral3582941166;
extern const uint32_t Uri_Parse_m736300106_MetadataUsageId;
extern RuntimeClass* DefaultUriParser_t95882050_il2cpp_TypeInfo_var;
extern String_t* _stringLiteral3313991234;
extern String_t* _stringLiteral1563818855;
extern String_t* _stringLiteral3874466473;
extern String_t* _stringLiteral94042051;
extern String_t* _stringLiteral1541500764;
extern String_t* _stringLiteral2669708615;
extern String_t* _stringLiteral3450582913;
extern String_t* _stringLiteral4171376173;
extern String_t* _stringLiteral3452614645;
extern String_t* _stringLiteral3452614643;
extern String_t* _stringLiteral833983382;
extern String_t* _stringLiteral3452614535;
extern const uint32_t Uri_ParseNoExceptions_m4274141693_MetadataUsageId;
extern const uint32_t Uri_CompactEscaped_m2984961597_MetadataUsageId;
extern RuntimeClass* ArrayList_t2718874744_il2cpp_TypeInfo_var;
extern RuntimeClass* IEnumerator_t1853284238_il2cpp_TypeInfo_var;
extern RuntimeClass* IDisposable_t3640265483_il2cpp_TypeInfo_var;
extern String_t* _stringLiteral3452614530;
extern const uint32_t Uri_Reduce_m3122437040_MetadataUsageId;
extern RuntimeClass* ByteU5BU5D_t4116647657_il2cpp_TypeInfo_var;
extern const RuntimeMethod* Uri_HexUnescapeMultiByte_m332853996_RuntimeMethod_var;
extern String_t* _stringLiteral2326546891;
extern String_t* _stringLiteral797640427;
extern const uint32_t Uri_HexUnescapeMultiByte_m332853996_MetadataUsageId;
extern const uint32_t Uri_GetSchemeDelimiter_m2374610473_MetadataUsageId;
extern RuntimeClass* UriParser_t3890150400_il2cpp_TypeInfo_var;
extern const uint32_t Uri_GetDefaultPort_m2547653357_MetadataUsageId;
extern const uint32_t Uri_GetOpaqueWiseSchemeDelimiter_m1909471550_MetadataUsageId;
extern const uint32_t Uri_IsPredefinedScheme_m1188665625_MetadataUsageId;
extern String_t* _stringLiteral3452614534;
extern const uint32_t Uri_get_Parser_m3737125102_MetadataUsageId;
extern const uint32_t Uri_IsWellFormedOriginalString_m1655593438_MetadataUsageId;
extern const uint32_t Uri_IsWellFormedUriString_m3476662626_MetadataUsageId;
extern const uint32_t Uri_TryCreate_m385949523_MetadataUsageId;
extern RuntimeClass* MemoryStream_t94973147_il2cpp_TypeInfo_var;
extern const RuntimeMethod* Uri_UnescapeDataString_m3282767665_RuntimeMethod_var;
extern String_t* _stringLiteral682703636;
extern const uint32_t Uri_UnescapeDataString_m3282767665_MetadataUsageId;
extern const uint32_t Uri_GetChar_m2610276660_MetadataUsageId;
extern RuntimeClass* InvalidOperationException_t56020091_il2cpp_TypeInfo_var;
extern const RuntimeMethod* Uri_EnsureAbsoluteUri_m2231483494_RuntimeMethod_var;
extern String_t* _stringLiteral2193443264;
extern const uint32_t Uri_EnsureAbsoluteUri_m2231483494_MetadataUsageId;
extern const uint32_t Uri_op_Inequality_m839253362_MetadataUsageId;
extern String_t* _stringLiteral2864059369;
extern const uint32_t UriFormatException__ctor_m1115096473_MetadataUsageId;
extern RuntimeClass* RuntimeObject_il2cpp_TypeInfo_var;
extern RuntimeClass* Regex_t3657309853_il2cpp_TypeInfo_var;
extern String_t* _stringLiteral528199797;
extern String_t* _stringLiteral3698381084;
extern const uint32_t UriParser__cctor_m3655686731_MetadataUsageId;
extern String_t* _stringLiteral2140524769;
extern const uint32_t UriParser_InitializeAndValidate_m2008117311_MetadataUsageId;
extern RuntimeClass* Hashtable_t1853889766_il2cpp_TypeInfo_var;
extern String_t* _stringLiteral4255182569;
extern const uint32_t UriParser_CreateDefaults_m404296154_MetadataUsageId;
extern RuntimeClass* GenericUriParser_t1141496137_il2cpp_TypeInfo_var;
extern const uint32_t UriParser_InternalRegister_m3643767086_MetadataUsageId;
extern const uint32_t UriParser_GetParser_m544052729_MetadataUsageId;
extern const RuntimeType* String_t_0_0_0_var;
extern const RuntimeType* Uri_t100236324_0_0_0_var;
extern RuntimeClass* Type_t_il2cpp_TypeInfo_var;
extern const uint32_t UriTypeConverter_CanConvert_m4004296934_MetadataUsageId;
extern const RuntimeMethod* UriTypeConverter_CanConvertFrom_m3865653726_RuntimeMethod_var;
extern String_t* _stringLiteral652524914;
extern const uint32_t UriTypeConverter_CanConvertFrom_m3865653726_MetadataUsageId;
extern RuntimeClass* NotSupportedException_t1314879016_il2cpp_TypeInfo_var;
extern const RuntimeMethod* UriTypeConverter_ConvertFrom_m3320288643_RuntimeMethod_var;
extern String_t* _stringLiteral3493618073;
extern String_t* _stringLiteral2299570518;
extern const uint32_t UriTypeConverter_ConvertFrom_m3320288643_MetadataUsageId;
extern const RuntimeMethod* UriTypeConverter_ConvertTo_m3611054432_RuntimeMethod_var;
extern String_t* _stringLiteral1835507732;
extern const uint32_t UriTypeConverter_ConvertTo_m3611054432_MetadataUsageId;

struct ObjectU5BU5D_t2843939325;
struct UriSchemeU5BU5D_t2082808316;
struct CharU5BU5D_t3528271667;
struct StringU5BU5D_t1281789340;
struct ByteU5BU5D_t4116647657;


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
#ifndef PATH_T1605229823_H
#define PATH_T1605229823_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.IO.Path
struct  Path_t1605229823  : public RuntimeObject
{
public:

public:
};

struct Path_t1605229823_StaticFields
{
public:
	// System.Char[] System.IO.Path::InvalidPathChars
	CharU5BU5D_t3528271667* ___InvalidPathChars_0;
	// System.Char System.IO.Path::AltDirectorySeparatorChar
	Il2CppChar ___AltDirectorySeparatorChar_1;
	// System.Char System.IO.Path::DirectorySeparatorChar
	Il2CppChar ___DirectorySeparatorChar_2;
	// System.Char System.IO.Path::PathSeparator
	Il2CppChar ___PathSeparator_3;
	// System.String System.IO.Path::DirectorySeparatorStr
	String_t* ___DirectorySeparatorStr_4;
	// System.Char System.IO.Path::VolumeSeparatorChar
	Il2CppChar ___VolumeSeparatorChar_5;
	// System.Char[] System.IO.Path::PathSeparatorChars
	CharU5BU5D_t3528271667* ___PathSeparatorChars_6;
	// System.Boolean System.IO.Path::dirEqualsVolume
	bool ___dirEqualsVolume_7;

public:
	inline static int32_t get_offset_of_InvalidPathChars_0() { return static_cast<int32_t>(offsetof(Path_t1605229823_StaticFields, ___InvalidPathChars_0)); }
	inline CharU5BU5D_t3528271667* get_InvalidPathChars_0() const { return ___InvalidPathChars_0; }
	inline CharU5BU5D_t3528271667** get_address_of_InvalidPathChars_0() { return &___InvalidPathChars_0; }
	inline void set_InvalidPathChars_0(CharU5BU5D_t3528271667* value)
	{
		___InvalidPathChars_0 = value;
		Il2CppCodeGenWriteBarrier((&___InvalidPathChars_0), value);
	}

	inline static int32_t get_offset_of_AltDirectorySeparatorChar_1() { return static_cast<int32_t>(offsetof(Path_t1605229823_StaticFields, ___AltDirectorySeparatorChar_1)); }
	inline Il2CppChar get_AltDirectorySeparatorChar_1() const { return ___AltDirectorySeparatorChar_1; }
	inline Il2CppChar* get_address_of_AltDirectorySeparatorChar_1() { return &___AltDirectorySeparatorChar_1; }
	inline void set_AltDirectorySeparatorChar_1(Il2CppChar value)
	{
		___AltDirectorySeparatorChar_1 = value;
	}

	inline static int32_t get_offset_of_DirectorySeparatorChar_2() { return static_cast<int32_t>(offsetof(Path_t1605229823_StaticFields, ___DirectorySeparatorChar_2)); }
	inline Il2CppChar get_DirectorySeparatorChar_2() const { return ___DirectorySeparatorChar_2; }
	inline Il2CppChar* get_address_of_DirectorySeparatorChar_2() { return &___DirectorySeparatorChar_2; }
	inline void set_DirectorySeparatorChar_2(Il2CppChar value)
	{
		___DirectorySeparatorChar_2 = value;
	}

	inline static int32_t get_offset_of_PathSeparator_3() { return static_cast<int32_t>(offsetof(Path_t1605229823_StaticFields, ___PathSeparator_3)); }
	inline Il2CppChar get_PathSeparator_3() const { return ___PathSeparator_3; }
	inline Il2CppChar* get_address_of_PathSeparator_3() { return &___PathSeparator_3; }
	inline void set_PathSeparator_3(Il2CppChar value)
	{
		___PathSeparator_3 = value;
	}

	inline static int32_t get_offset_of_DirectorySeparatorStr_4() { return static_cast<int32_t>(offsetof(Path_t1605229823_StaticFields, ___DirectorySeparatorStr_4)); }
	inline String_t* get_DirectorySeparatorStr_4() const { return ___DirectorySeparatorStr_4; }
	inline String_t** get_address_of_DirectorySeparatorStr_4() { return &___DirectorySeparatorStr_4; }
	inline void set_DirectorySeparatorStr_4(String_t* value)
	{
		___DirectorySeparatorStr_4 = value;
		Il2CppCodeGenWriteBarrier((&___DirectorySeparatorStr_4), value);
	}

	inline static int32_t get_offset_of_VolumeSeparatorChar_5() { return static_cast<int32_t>(offsetof(Path_t1605229823_StaticFields, ___VolumeSeparatorChar_5)); }
	inline Il2CppChar get_VolumeSeparatorChar_5() const { return ___VolumeSeparatorChar_5; }
	inline Il2CppChar* get_address_of_VolumeSeparatorChar_5() { return &___VolumeSeparatorChar_5; }
	inline void set_VolumeSeparatorChar_5(Il2CppChar value)
	{
		___VolumeSeparatorChar_5 = value;
	}

	inline static int32_t get_offset_of_PathSeparatorChars_6() { return static_cast<int32_t>(offsetof(Path_t1605229823_StaticFields, ___PathSeparatorChars_6)); }
	inline CharU5BU5D_t3528271667* get_PathSeparatorChars_6() const { return ___PathSeparatorChars_6; }
	inline CharU5BU5D_t3528271667** get_address_of_PathSeparatorChars_6() { return &___PathSeparatorChars_6; }
	inline void set_PathSeparatorChars_6(CharU5BU5D_t3528271667* value)
	{
		___PathSeparatorChars_6 = value;
		Il2CppCodeGenWriteBarrier((&___PathSeparatorChars_6), value);
	}

	inline static int32_t get_offset_of_dirEqualsVolume_7() { return static_cast<int32_t>(offsetof(Path_t1605229823_StaticFields, ___dirEqualsVolume_7)); }
	inline bool get_dirEqualsVolume_7() const { return ___dirEqualsVolume_7; }
	inline bool* get_address_of_dirEqualsVolume_7() { return &___dirEqualsVolume_7; }
	inline void set_dirEqualsVolume_7(bool value)
	{
		___dirEqualsVolume_7 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // PATH_T1605229823_H
#ifndef ENCODING_T1523322056_H
#define ENCODING_T1523322056_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Text.Encoding
struct  Encoding_t1523322056  : public RuntimeObject
{
public:
	// System.Int32 System.Text.Encoding::codePage
	int32_t ___codePage_0;
	// System.Int32 System.Text.Encoding::windows_code_page
	int32_t ___windows_code_page_1;
	// System.Boolean System.Text.Encoding::is_readonly
	bool ___is_readonly_2;
	// System.Text.DecoderFallback System.Text.Encoding::decoder_fallback
	DecoderFallback_t3123823036 * ___decoder_fallback_3;
	// System.Text.EncoderFallback System.Text.Encoding::encoder_fallback
	EncoderFallback_t1188251036 * ___encoder_fallback_4;
	// System.String System.Text.Encoding::body_name
	String_t* ___body_name_8;
	// System.String System.Text.Encoding::encoding_name
	String_t* ___encoding_name_9;
	// System.String System.Text.Encoding::header_name
	String_t* ___header_name_10;
	// System.Boolean System.Text.Encoding::is_mail_news_display
	bool ___is_mail_news_display_11;
	// System.Boolean System.Text.Encoding::is_mail_news_save
	bool ___is_mail_news_save_12;
	// System.Boolean System.Text.Encoding::is_browser_save
	bool ___is_browser_save_13;
	// System.Boolean System.Text.Encoding::is_browser_display
	bool ___is_browser_display_14;
	// System.String System.Text.Encoding::web_name
	String_t* ___web_name_15;

public:
	inline static int32_t get_offset_of_codePage_0() { return static_cast<int32_t>(offsetof(Encoding_t1523322056, ___codePage_0)); }
	inline int32_t get_codePage_0() const { return ___codePage_0; }
	inline int32_t* get_address_of_codePage_0() { return &___codePage_0; }
	inline void set_codePage_0(int32_t value)
	{
		___codePage_0 = value;
	}

	inline static int32_t get_offset_of_windows_code_page_1() { return static_cast<int32_t>(offsetof(Encoding_t1523322056, ___windows_code_page_1)); }
	inline int32_t get_windows_code_page_1() const { return ___windows_code_page_1; }
	inline int32_t* get_address_of_windows_code_page_1() { return &___windows_code_page_1; }
	inline void set_windows_code_page_1(int32_t value)
	{
		___windows_code_page_1 = value;
	}

	inline static int32_t get_offset_of_is_readonly_2() { return static_cast<int32_t>(offsetof(Encoding_t1523322056, ___is_readonly_2)); }
	inline bool get_is_readonly_2() const { return ___is_readonly_2; }
	inline bool* get_address_of_is_readonly_2() { return &___is_readonly_2; }
	inline void set_is_readonly_2(bool value)
	{
		___is_readonly_2 = value;
	}

	inline static int32_t get_offset_of_decoder_fallback_3() { return static_cast<int32_t>(offsetof(Encoding_t1523322056, ___decoder_fallback_3)); }
	inline DecoderFallback_t3123823036 * get_decoder_fallback_3() const { return ___decoder_fallback_3; }
	inline DecoderFallback_t3123823036 ** get_address_of_decoder_fallback_3() { return &___decoder_fallback_3; }
	inline void set_decoder_fallback_3(DecoderFallback_t3123823036 * value)
	{
		___decoder_fallback_3 = value;
		Il2CppCodeGenWriteBarrier((&___decoder_fallback_3), value);
	}

	inline static int32_t get_offset_of_encoder_fallback_4() { return static_cast<int32_t>(offsetof(Encoding_t1523322056, ___encoder_fallback_4)); }
	inline EncoderFallback_t1188251036 * get_encoder_fallback_4() const { return ___encoder_fallback_4; }
	inline EncoderFallback_t1188251036 ** get_address_of_encoder_fallback_4() { return &___encoder_fallback_4; }
	inline void set_encoder_fallback_4(EncoderFallback_t1188251036 * value)
	{
		___encoder_fallback_4 = value;
		Il2CppCodeGenWriteBarrier((&___encoder_fallback_4), value);
	}

	inline static int32_t get_offset_of_body_name_8() { return static_cast<int32_t>(offsetof(Encoding_t1523322056, ___body_name_8)); }
	inline String_t* get_body_name_8() const { return ___body_name_8; }
	inline String_t** get_address_of_body_name_8() { return &___body_name_8; }
	inline void set_body_name_8(String_t* value)
	{
		___body_name_8 = value;
		Il2CppCodeGenWriteBarrier((&___body_name_8), value);
	}

	inline static int32_t get_offset_of_encoding_name_9() { return static_cast<int32_t>(offsetof(Encoding_t1523322056, ___encoding_name_9)); }
	inline String_t* get_encoding_name_9() const { return ___encoding_name_9; }
	inline String_t** get_address_of_encoding_name_9() { return &___encoding_name_9; }
	inline void set_encoding_name_9(String_t* value)
	{
		___encoding_name_9 = value;
		Il2CppCodeGenWriteBarrier((&___encoding_name_9), value);
	}

	inline static int32_t get_offset_of_header_name_10() { return static_cast<int32_t>(offsetof(Encoding_t1523322056, ___header_name_10)); }
	inline String_t* get_header_name_10() const { return ___header_name_10; }
	inline String_t** get_address_of_header_name_10() { return &___header_name_10; }
	inline void set_header_name_10(String_t* value)
	{
		___header_name_10 = value;
		Il2CppCodeGenWriteBarrier((&___header_name_10), value);
	}

	inline static int32_t get_offset_of_is_mail_news_display_11() { return static_cast<int32_t>(offsetof(Encoding_t1523322056, ___is_mail_news_display_11)); }
	inline bool get_is_mail_news_display_11() const { return ___is_mail_news_display_11; }
	inline bool* get_address_of_is_mail_news_display_11() { return &___is_mail_news_display_11; }
	inline void set_is_mail_news_display_11(bool value)
	{
		___is_mail_news_display_11 = value;
	}

	inline static int32_t get_offset_of_is_mail_news_save_12() { return static_cast<int32_t>(offsetof(Encoding_t1523322056, ___is_mail_news_save_12)); }
	inline bool get_is_mail_news_save_12() const { return ___is_mail_news_save_12; }
	inline bool* get_address_of_is_mail_news_save_12() { return &___is_mail_news_save_12; }
	inline void set_is_mail_news_save_12(bool value)
	{
		___is_mail_news_save_12 = value;
	}

	inline static int32_t get_offset_of_is_browser_save_13() { return static_cast<int32_t>(offsetof(Encoding_t1523322056, ___is_browser_save_13)); }
	inline bool get_is_browser_save_13() const { return ___is_browser_save_13; }
	inline bool* get_address_of_is_browser_save_13() { return &___is_browser_save_13; }
	inline void set_is_browser_save_13(bool value)
	{
		___is_browser_save_13 = value;
	}

	inline static int32_t get_offset_of_is_browser_display_14() { return static_cast<int32_t>(offsetof(Encoding_t1523322056, ___is_browser_display_14)); }
	inline bool get_is_browser_display_14() const { return ___is_browser_display_14; }
	inline bool* get_address_of_is_browser_display_14() { return &___is_browser_display_14; }
	inline void set_is_browser_display_14(bool value)
	{
		___is_browser_display_14 = value;
	}

	inline static int32_t get_offset_of_web_name_15() { return static_cast<int32_t>(offsetof(Encoding_t1523322056, ___web_name_15)); }
	inline String_t* get_web_name_15() const { return ___web_name_15; }
	inline String_t** get_address_of_web_name_15() { return &___web_name_15; }
	inline void set_web_name_15(String_t* value)
	{
		___web_name_15 = value;
		Il2CppCodeGenWriteBarrier((&___web_name_15), value);
	}
};

struct Encoding_t1523322056_StaticFields
{
public:
	// System.Reflection.Assembly System.Text.Encoding::i18nAssembly
	Assembly_t * ___i18nAssembly_5;
	// System.Boolean System.Text.Encoding::i18nDisabled
	bool ___i18nDisabled_6;
	// System.Object[] System.Text.Encoding::encodings
	ObjectU5BU5D_t2843939325* ___encodings_7;
	// System.Text.Encoding modreq(System.Runtime.CompilerServices.IsVolatile) System.Text.Encoding::asciiEncoding
	Encoding_t1523322056 * ___asciiEncoding_16;
	// System.Text.Encoding modreq(System.Runtime.CompilerServices.IsVolatile) System.Text.Encoding::bigEndianEncoding
	Encoding_t1523322056 * ___bigEndianEncoding_17;
	// System.Text.Encoding modreq(System.Runtime.CompilerServices.IsVolatile) System.Text.Encoding::defaultEncoding
	Encoding_t1523322056 * ___defaultEncoding_18;
	// System.Text.Encoding modreq(System.Runtime.CompilerServices.IsVolatile) System.Text.Encoding::utf7Encoding
	Encoding_t1523322056 * ___utf7Encoding_19;
	// System.Text.Encoding modreq(System.Runtime.CompilerServices.IsVolatile) System.Text.Encoding::utf8EncodingWithMarkers
	Encoding_t1523322056 * ___utf8EncodingWithMarkers_20;
	// System.Text.Encoding modreq(System.Runtime.CompilerServices.IsVolatile) System.Text.Encoding::utf8EncodingWithoutMarkers
	Encoding_t1523322056 * ___utf8EncodingWithoutMarkers_21;
	// System.Text.Encoding modreq(System.Runtime.CompilerServices.IsVolatile) System.Text.Encoding::unicodeEncoding
	Encoding_t1523322056 * ___unicodeEncoding_22;
	// System.Text.Encoding modreq(System.Runtime.CompilerServices.IsVolatile) System.Text.Encoding::isoLatin1Encoding
	Encoding_t1523322056 * ___isoLatin1Encoding_23;
	// System.Text.Encoding modreq(System.Runtime.CompilerServices.IsVolatile) System.Text.Encoding::utf8EncodingUnsafe
	Encoding_t1523322056 * ___utf8EncodingUnsafe_24;
	// System.Text.Encoding modreq(System.Runtime.CompilerServices.IsVolatile) System.Text.Encoding::utf32Encoding
	Encoding_t1523322056 * ___utf32Encoding_25;
	// System.Text.Encoding modreq(System.Runtime.CompilerServices.IsVolatile) System.Text.Encoding::bigEndianUTF32Encoding
	Encoding_t1523322056 * ___bigEndianUTF32Encoding_26;
	// System.Object System.Text.Encoding::lockobj
	RuntimeObject * ___lockobj_27;

public:
	inline static int32_t get_offset_of_i18nAssembly_5() { return static_cast<int32_t>(offsetof(Encoding_t1523322056_StaticFields, ___i18nAssembly_5)); }
	inline Assembly_t * get_i18nAssembly_5() const { return ___i18nAssembly_5; }
	inline Assembly_t ** get_address_of_i18nAssembly_5() { return &___i18nAssembly_5; }
	inline void set_i18nAssembly_5(Assembly_t * value)
	{
		___i18nAssembly_5 = value;
		Il2CppCodeGenWriteBarrier((&___i18nAssembly_5), value);
	}

	inline static int32_t get_offset_of_i18nDisabled_6() { return static_cast<int32_t>(offsetof(Encoding_t1523322056_StaticFields, ___i18nDisabled_6)); }
	inline bool get_i18nDisabled_6() const { return ___i18nDisabled_6; }
	inline bool* get_address_of_i18nDisabled_6() { return &___i18nDisabled_6; }
	inline void set_i18nDisabled_6(bool value)
	{
		___i18nDisabled_6 = value;
	}

	inline static int32_t get_offset_of_encodings_7() { return static_cast<int32_t>(offsetof(Encoding_t1523322056_StaticFields, ___encodings_7)); }
	inline ObjectU5BU5D_t2843939325* get_encodings_7() const { return ___encodings_7; }
	inline ObjectU5BU5D_t2843939325** get_address_of_encodings_7() { return &___encodings_7; }
	inline void set_encodings_7(ObjectU5BU5D_t2843939325* value)
	{
		___encodings_7 = value;
		Il2CppCodeGenWriteBarrier((&___encodings_7), value);
	}

	inline static int32_t get_offset_of_asciiEncoding_16() { return static_cast<int32_t>(offsetof(Encoding_t1523322056_StaticFields, ___asciiEncoding_16)); }
	inline Encoding_t1523322056 * get_asciiEncoding_16() const { return ___asciiEncoding_16; }
	inline Encoding_t1523322056 ** get_address_of_asciiEncoding_16() { return &___asciiEncoding_16; }
	inline void set_asciiEncoding_16(Encoding_t1523322056 * value)
	{
		___asciiEncoding_16 = value;
		Il2CppCodeGenWriteBarrier((&___asciiEncoding_16), value);
	}

	inline static int32_t get_offset_of_bigEndianEncoding_17() { return static_cast<int32_t>(offsetof(Encoding_t1523322056_StaticFields, ___bigEndianEncoding_17)); }
	inline Encoding_t1523322056 * get_bigEndianEncoding_17() const { return ___bigEndianEncoding_17; }
	inline Encoding_t1523322056 ** get_address_of_bigEndianEncoding_17() { return &___bigEndianEncoding_17; }
	inline void set_bigEndianEncoding_17(Encoding_t1523322056 * value)
	{
		___bigEndianEncoding_17 = value;
		Il2CppCodeGenWriteBarrier((&___bigEndianEncoding_17), value);
	}

	inline static int32_t get_offset_of_defaultEncoding_18() { return static_cast<int32_t>(offsetof(Encoding_t1523322056_StaticFields, ___defaultEncoding_18)); }
	inline Encoding_t1523322056 * get_defaultEncoding_18() const { return ___defaultEncoding_18; }
	inline Encoding_t1523322056 ** get_address_of_defaultEncoding_18() { return &___defaultEncoding_18; }
	inline void set_defaultEncoding_18(Encoding_t1523322056 * value)
	{
		___defaultEncoding_18 = value;
		Il2CppCodeGenWriteBarrier((&___defaultEncoding_18), value);
	}

	inline static int32_t get_offset_of_utf7Encoding_19() { return static_cast<int32_t>(offsetof(Encoding_t1523322056_StaticFields, ___utf7Encoding_19)); }
	inline Encoding_t1523322056 * get_utf7Encoding_19() const { return ___utf7Encoding_19; }
	inline Encoding_t1523322056 ** get_address_of_utf7Encoding_19() { return &___utf7Encoding_19; }
	inline void set_utf7Encoding_19(Encoding_t1523322056 * value)
	{
		___utf7Encoding_19 = value;
		Il2CppCodeGenWriteBarrier((&___utf7Encoding_19), value);
	}

	inline static int32_t get_offset_of_utf8EncodingWithMarkers_20() { return static_cast<int32_t>(offsetof(Encoding_t1523322056_StaticFields, ___utf8EncodingWithMarkers_20)); }
	inline Encoding_t1523322056 * get_utf8EncodingWithMarkers_20() const { return ___utf8EncodingWithMarkers_20; }
	inline Encoding_t1523322056 ** get_address_of_utf8EncodingWithMarkers_20() { return &___utf8EncodingWithMarkers_20; }
	inline void set_utf8EncodingWithMarkers_20(Encoding_t1523322056 * value)
	{
		___utf8EncodingWithMarkers_20 = value;
		Il2CppCodeGenWriteBarrier((&___utf8EncodingWithMarkers_20), value);
	}

	inline static int32_t get_offset_of_utf8EncodingWithoutMarkers_21() { return static_cast<int32_t>(offsetof(Encoding_t1523322056_StaticFields, ___utf8EncodingWithoutMarkers_21)); }
	inline Encoding_t1523322056 * get_utf8EncodingWithoutMarkers_21() const { return ___utf8EncodingWithoutMarkers_21; }
	inline Encoding_t1523322056 ** get_address_of_utf8EncodingWithoutMarkers_21() { return &___utf8EncodingWithoutMarkers_21; }
	inline void set_utf8EncodingWithoutMarkers_21(Encoding_t1523322056 * value)
	{
		___utf8EncodingWithoutMarkers_21 = value;
		Il2CppCodeGenWriteBarrier((&___utf8EncodingWithoutMarkers_21), value);
	}

	inline static int32_t get_offset_of_unicodeEncoding_22() { return static_cast<int32_t>(offsetof(Encoding_t1523322056_StaticFields, ___unicodeEncoding_22)); }
	inline Encoding_t1523322056 * get_unicodeEncoding_22() const { return ___unicodeEncoding_22; }
	inline Encoding_t1523322056 ** get_address_of_unicodeEncoding_22() { return &___unicodeEncoding_22; }
	inline void set_unicodeEncoding_22(Encoding_t1523322056 * value)
	{
		___unicodeEncoding_22 = value;
		Il2CppCodeGenWriteBarrier((&___unicodeEncoding_22), value);
	}

	inline static int32_t get_offset_of_isoLatin1Encoding_23() { return static_cast<int32_t>(offsetof(Encoding_t1523322056_StaticFields, ___isoLatin1Encoding_23)); }
	inline Encoding_t1523322056 * get_isoLatin1Encoding_23() const { return ___isoLatin1Encoding_23; }
	inline Encoding_t1523322056 ** get_address_of_isoLatin1Encoding_23() { return &___isoLatin1Encoding_23; }
	inline void set_isoLatin1Encoding_23(Encoding_t1523322056 * value)
	{
		___isoLatin1Encoding_23 = value;
		Il2CppCodeGenWriteBarrier((&___isoLatin1Encoding_23), value);
	}

	inline static int32_t get_offset_of_utf8EncodingUnsafe_24() { return static_cast<int32_t>(offsetof(Encoding_t1523322056_StaticFields, ___utf8EncodingUnsafe_24)); }
	inline Encoding_t1523322056 * get_utf8EncodingUnsafe_24() const { return ___utf8EncodingUnsafe_24; }
	inline Encoding_t1523322056 ** get_address_of_utf8EncodingUnsafe_24() { return &___utf8EncodingUnsafe_24; }
	inline void set_utf8EncodingUnsafe_24(Encoding_t1523322056 * value)
	{
		___utf8EncodingUnsafe_24 = value;
		Il2CppCodeGenWriteBarrier((&___utf8EncodingUnsafe_24), value);
	}

	inline static int32_t get_offset_of_utf32Encoding_25() { return static_cast<int32_t>(offsetof(Encoding_t1523322056_StaticFields, ___utf32Encoding_25)); }
	inline Encoding_t1523322056 * get_utf32Encoding_25() const { return ___utf32Encoding_25; }
	inline Encoding_t1523322056 ** get_address_of_utf32Encoding_25() { return &___utf32Encoding_25; }
	inline void set_utf32Encoding_25(Encoding_t1523322056 * value)
	{
		___utf32Encoding_25 = value;
		Il2CppCodeGenWriteBarrier((&___utf32Encoding_25), value);
	}

	inline static int32_t get_offset_of_bigEndianUTF32Encoding_26() { return static_cast<int32_t>(offsetof(Encoding_t1523322056_StaticFields, ___bigEndianUTF32Encoding_26)); }
	inline Encoding_t1523322056 * get_bigEndianUTF32Encoding_26() const { return ___bigEndianUTF32Encoding_26; }
	inline Encoding_t1523322056 ** get_address_of_bigEndianUTF32Encoding_26() { return &___bigEndianUTF32Encoding_26; }
	inline void set_bigEndianUTF32Encoding_26(Encoding_t1523322056 * value)
	{
		___bigEndianUTF32Encoding_26 = value;
		Il2CppCodeGenWriteBarrier((&___bigEndianUTF32Encoding_26), value);
	}

	inline static int32_t get_offset_of_lockobj_27() { return static_cast<int32_t>(offsetof(Encoding_t1523322056_StaticFields, ___lockobj_27)); }
	inline RuntimeObject * get_lockobj_27() const { return ___lockobj_27; }
	inline RuntimeObject ** get_address_of_lockobj_27() { return &___lockobj_27; }
	inline void set_lockobj_27(RuntimeObject * value)
	{
		___lockobj_27 = value;
		Il2CppCodeGenWriteBarrier((&___lockobj_27), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ENCODING_T1523322056_H
#ifndef CULTUREINFO_T4157843068_H
#define CULTUREINFO_T4157843068_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Globalization.CultureInfo
struct  CultureInfo_t4157843068  : public RuntimeObject
{
public:
	// System.Boolean System.Globalization.CultureInfo::m_isReadOnly
	bool ___m_isReadOnly_7;
	// System.Int32 System.Globalization.CultureInfo::cultureID
	int32_t ___cultureID_8;
	// System.Int32 System.Globalization.CultureInfo::parent_lcid
	int32_t ___parent_lcid_9;
	// System.Int32 System.Globalization.CultureInfo::specific_lcid
	int32_t ___specific_lcid_10;
	// System.Int32 System.Globalization.CultureInfo::datetime_index
	int32_t ___datetime_index_11;
	// System.Int32 System.Globalization.CultureInfo::number_index
	int32_t ___number_index_12;
	// System.Boolean System.Globalization.CultureInfo::m_useUserOverride
	bool ___m_useUserOverride_13;
	// System.Globalization.NumberFormatInfo modreq(System.Runtime.CompilerServices.IsVolatile) System.Globalization.CultureInfo::numInfo
	NumberFormatInfo_t435877138 * ___numInfo_14;
	// System.Globalization.DateTimeFormatInfo modreq(System.Runtime.CompilerServices.IsVolatile) System.Globalization.CultureInfo::dateTimeInfo
	DateTimeFormatInfo_t2405853701 * ___dateTimeInfo_15;
	// System.Globalization.TextInfo modreq(System.Runtime.CompilerServices.IsVolatile) System.Globalization.CultureInfo::textInfo
	TextInfo_t3810425522 * ___textInfo_16;
	// System.String System.Globalization.CultureInfo::m_name
	String_t* ___m_name_17;
	// System.String System.Globalization.CultureInfo::displayname
	String_t* ___displayname_18;
	// System.String System.Globalization.CultureInfo::englishname
	String_t* ___englishname_19;
	// System.String System.Globalization.CultureInfo::nativename
	String_t* ___nativename_20;
	// System.String System.Globalization.CultureInfo::iso3lang
	String_t* ___iso3lang_21;
	// System.String System.Globalization.CultureInfo::iso2lang
	String_t* ___iso2lang_22;
	// System.String System.Globalization.CultureInfo::icu_name
	String_t* ___icu_name_23;
	// System.String System.Globalization.CultureInfo::win3lang
	String_t* ___win3lang_24;
	// System.String System.Globalization.CultureInfo::territory
	String_t* ___territory_25;
	// System.Globalization.CompareInfo modreq(System.Runtime.CompilerServices.IsVolatile) System.Globalization.CultureInfo::compareInfo
	CompareInfo_t1092934962 * ___compareInfo_26;
	// System.Int32* System.Globalization.CultureInfo::calendar_data
	int32_t* ___calendar_data_27;
	// System.Void* System.Globalization.CultureInfo::textinfo_data
	void* ___textinfo_data_28;
	// System.Globalization.Calendar[] System.Globalization.CultureInfo::optional_calendars
	CalendarU5BU5D_t3985046076* ___optional_calendars_29;
	// System.Globalization.CultureInfo System.Globalization.CultureInfo::parent_culture
	CultureInfo_t4157843068 * ___parent_culture_30;
	// System.Int32 System.Globalization.CultureInfo::m_dataItem
	int32_t ___m_dataItem_31;
	// System.Globalization.Calendar System.Globalization.CultureInfo::calendar
	Calendar_t1661121569 * ___calendar_32;
	// System.Boolean System.Globalization.CultureInfo::constructed
	bool ___constructed_33;
	// System.Byte[] System.Globalization.CultureInfo::cached_serialized_form
	ByteU5BU5D_t4116647657* ___cached_serialized_form_34;

public:
	inline static int32_t get_offset_of_m_isReadOnly_7() { return static_cast<int32_t>(offsetof(CultureInfo_t4157843068, ___m_isReadOnly_7)); }
	inline bool get_m_isReadOnly_7() const { return ___m_isReadOnly_7; }
	inline bool* get_address_of_m_isReadOnly_7() { return &___m_isReadOnly_7; }
	inline void set_m_isReadOnly_7(bool value)
	{
		___m_isReadOnly_7 = value;
	}

	inline static int32_t get_offset_of_cultureID_8() { return static_cast<int32_t>(offsetof(CultureInfo_t4157843068, ___cultureID_8)); }
	inline int32_t get_cultureID_8() const { return ___cultureID_8; }
	inline int32_t* get_address_of_cultureID_8() { return &___cultureID_8; }
	inline void set_cultureID_8(int32_t value)
	{
		___cultureID_8 = value;
	}

	inline static int32_t get_offset_of_parent_lcid_9() { return static_cast<int32_t>(offsetof(CultureInfo_t4157843068, ___parent_lcid_9)); }
	inline int32_t get_parent_lcid_9() const { return ___parent_lcid_9; }
	inline int32_t* get_address_of_parent_lcid_9() { return &___parent_lcid_9; }
	inline void set_parent_lcid_9(int32_t value)
	{
		___parent_lcid_9 = value;
	}

	inline static int32_t get_offset_of_specific_lcid_10() { return static_cast<int32_t>(offsetof(CultureInfo_t4157843068, ___specific_lcid_10)); }
	inline int32_t get_specific_lcid_10() const { return ___specific_lcid_10; }
	inline int32_t* get_address_of_specific_lcid_10() { return &___specific_lcid_10; }
	inline void set_specific_lcid_10(int32_t value)
	{
		___specific_lcid_10 = value;
	}

	inline static int32_t get_offset_of_datetime_index_11() { return static_cast<int32_t>(offsetof(CultureInfo_t4157843068, ___datetime_index_11)); }
	inline int32_t get_datetime_index_11() const { return ___datetime_index_11; }
	inline int32_t* get_address_of_datetime_index_11() { return &___datetime_index_11; }
	inline void set_datetime_index_11(int32_t value)
	{
		___datetime_index_11 = value;
	}

	inline static int32_t get_offset_of_number_index_12() { return static_cast<int32_t>(offsetof(CultureInfo_t4157843068, ___number_index_12)); }
	inline int32_t get_number_index_12() const { return ___number_index_12; }
	inline int32_t* get_address_of_number_index_12() { return &___number_index_12; }
	inline void set_number_index_12(int32_t value)
	{
		___number_index_12 = value;
	}

	inline static int32_t get_offset_of_m_useUserOverride_13() { return static_cast<int32_t>(offsetof(CultureInfo_t4157843068, ___m_useUserOverride_13)); }
	inline bool get_m_useUserOverride_13() const { return ___m_useUserOverride_13; }
	inline bool* get_address_of_m_useUserOverride_13() { return &___m_useUserOverride_13; }
	inline void set_m_useUserOverride_13(bool value)
	{
		___m_useUserOverride_13 = value;
	}

	inline static int32_t get_offset_of_numInfo_14() { return static_cast<int32_t>(offsetof(CultureInfo_t4157843068, ___numInfo_14)); }
	inline NumberFormatInfo_t435877138 * get_numInfo_14() const { return ___numInfo_14; }
	inline NumberFormatInfo_t435877138 ** get_address_of_numInfo_14() { return &___numInfo_14; }
	inline void set_numInfo_14(NumberFormatInfo_t435877138 * value)
	{
		___numInfo_14 = value;
		Il2CppCodeGenWriteBarrier((&___numInfo_14), value);
	}

	inline static int32_t get_offset_of_dateTimeInfo_15() { return static_cast<int32_t>(offsetof(CultureInfo_t4157843068, ___dateTimeInfo_15)); }
	inline DateTimeFormatInfo_t2405853701 * get_dateTimeInfo_15() const { return ___dateTimeInfo_15; }
	inline DateTimeFormatInfo_t2405853701 ** get_address_of_dateTimeInfo_15() { return &___dateTimeInfo_15; }
	inline void set_dateTimeInfo_15(DateTimeFormatInfo_t2405853701 * value)
	{
		___dateTimeInfo_15 = value;
		Il2CppCodeGenWriteBarrier((&___dateTimeInfo_15), value);
	}

	inline static int32_t get_offset_of_textInfo_16() { return static_cast<int32_t>(offsetof(CultureInfo_t4157843068, ___textInfo_16)); }
	inline TextInfo_t3810425522 * get_textInfo_16() const { return ___textInfo_16; }
	inline TextInfo_t3810425522 ** get_address_of_textInfo_16() { return &___textInfo_16; }
	inline void set_textInfo_16(TextInfo_t3810425522 * value)
	{
		___textInfo_16 = value;
		Il2CppCodeGenWriteBarrier((&___textInfo_16), value);
	}

	inline static int32_t get_offset_of_m_name_17() { return static_cast<int32_t>(offsetof(CultureInfo_t4157843068, ___m_name_17)); }
	inline String_t* get_m_name_17() const { return ___m_name_17; }
	inline String_t** get_address_of_m_name_17() { return &___m_name_17; }
	inline void set_m_name_17(String_t* value)
	{
		___m_name_17 = value;
		Il2CppCodeGenWriteBarrier((&___m_name_17), value);
	}

	inline static int32_t get_offset_of_displayname_18() { return static_cast<int32_t>(offsetof(CultureInfo_t4157843068, ___displayname_18)); }
	inline String_t* get_displayname_18() const { return ___displayname_18; }
	inline String_t** get_address_of_displayname_18() { return &___displayname_18; }
	inline void set_displayname_18(String_t* value)
	{
		___displayname_18 = value;
		Il2CppCodeGenWriteBarrier((&___displayname_18), value);
	}

	inline static int32_t get_offset_of_englishname_19() { return static_cast<int32_t>(offsetof(CultureInfo_t4157843068, ___englishname_19)); }
	inline String_t* get_englishname_19() const { return ___englishname_19; }
	inline String_t** get_address_of_englishname_19() { return &___englishname_19; }
	inline void set_englishname_19(String_t* value)
	{
		___englishname_19 = value;
		Il2CppCodeGenWriteBarrier((&___englishname_19), value);
	}

	inline static int32_t get_offset_of_nativename_20() { return static_cast<int32_t>(offsetof(CultureInfo_t4157843068, ___nativename_20)); }
	inline String_t* get_nativename_20() const { return ___nativename_20; }
	inline String_t** get_address_of_nativename_20() { return &___nativename_20; }
	inline void set_nativename_20(String_t* value)
	{
		___nativename_20 = value;
		Il2CppCodeGenWriteBarrier((&___nativename_20), value);
	}

	inline static int32_t get_offset_of_iso3lang_21() { return static_cast<int32_t>(offsetof(CultureInfo_t4157843068, ___iso3lang_21)); }
	inline String_t* get_iso3lang_21() const { return ___iso3lang_21; }
	inline String_t** get_address_of_iso3lang_21() { return &___iso3lang_21; }
	inline void set_iso3lang_21(String_t* value)
	{
		___iso3lang_21 = value;
		Il2CppCodeGenWriteBarrier((&___iso3lang_21), value);
	}

	inline static int32_t get_offset_of_iso2lang_22() { return static_cast<int32_t>(offsetof(CultureInfo_t4157843068, ___iso2lang_22)); }
	inline String_t* get_iso2lang_22() const { return ___iso2lang_22; }
	inline String_t** get_address_of_iso2lang_22() { return &___iso2lang_22; }
	inline void set_iso2lang_22(String_t* value)
	{
		___iso2lang_22 = value;
		Il2CppCodeGenWriteBarrier((&___iso2lang_22), value);
	}

	inline static int32_t get_offset_of_icu_name_23() { return static_cast<int32_t>(offsetof(CultureInfo_t4157843068, ___icu_name_23)); }
	inline String_t* get_icu_name_23() const { return ___icu_name_23; }
	inline String_t** get_address_of_icu_name_23() { return &___icu_name_23; }
	inline void set_icu_name_23(String_t* value)
	{
		___icu_name_23 = value;
		Il2CppCodeGenWriteBarrier((&___icu_name_23), value);
	}

	inline static int32_t get_offset_of_win3lang_24() { return static_cast<int32_t>(offsetof(CultureInfo_t4157843068, ___win3lang_24)); }
	inline String_t* get_win3lang_24() const { return ___win3lang_24; }
	inline String_t** get_address_of_win3lang_24() { return &___win3lang_24; }
	inline void set_win3lang_24(String_t* value)
	{
		___win3lang_24 = value;
		Il2CppCodeGenWriteBarrier((&___win3lang_24), value);
	}

	inline static int32_t get_offset_of_territory_25() { return static_cast<int32_t>(offsetof(CultureInfo_t4157843068, ___territory_25)); }
	inline String_t* get_territory_25() const { return ___territory_25; }
	inline String_t** get_address_of_territory_25() { return &___territory_25; }
	inline void set_territory_25(String_t* value)
	{
		___territory_25 = value;
		Il2CppCodeGenWriteBarrier((&___territory_25), value);
	}

	inline static int32_t get_offset_of_compareInfo_26() { return static_cast<int32_t>(offsetof(CultureInfo_t4157843068, ___compareInfo_26)); }
	inline CompareInfo_t1092934962 * get_compareInfo_26() const { return ___compareInfo_26; }
	inline CompareInfo_t1092934962 ** get_address_of_compareInfo_26() { return &___compareInfo_26; }
	inline void set_compareInfo_26(CompareInfo_t1092934962 * value)
	{
		___compareInfo_26 = value;
		Il2CppCodeGenWriteBarrier((&___compareInfo_26), value);
	}

	inline static int32_t get_offset_of_calendar_data_27() { return static_cast<int32_t>(offsetof(CultureInfo_t4157843068, ___calendar_data_27)); }
	inline int32_t* get_calendar_data_27() const { return ___calendar_data_27; }
	inline int32_t** get_address_of_calendar_data_27() { return &___calendar_data_27; }
	inline void set_calendar_data_27(int32_t* value)
	{
		___calendar_data_27 = value;
	}

	inline static int32_t get_offset_of_textinfo_data_28() { return static_cast<int32_t>(offsetof(CultureInfo_t4157843068, ___textinfo_data_28)); }
	inline void* get_textinfo_data_28() const { return ___textinfo_data_28; }
	inline void** get_address_of_textinfo_data_28() { return &___textinfo_data_28; }
	inline void set_textinfo_data_28(void* value)
	{
		___textinfo_data_28 = value;
	}

	inline static int32_t get_offset_of_optional_calendars_29() { return static_cast<int32_t>(offsetof(CultureInfo_t4157843068, ___optional_calendars_29)); }
	inline CalendarU5BU5D_t3985046076* get_optional_calendars_29() const { return ___optional_calendars_29; }
	inline CalendarU5BU5D_t3985046076** get_address_of_optional_calendars_29() { return &___optional_calendars_29; }
	inline void set_optional_calendars_29(CalendarU5BU5D_t3985046076* value)
	{
		___optional_calendars_29 = value;
		Il2CppCodeGenWriteBarrier((&___optional_calendars_29), value);
	}

	inline static int32_t get_offset_of_parent_culture_30() { return static_cast<int32_t>(offsetof(CultureInfo_t4157843068, ___parent_culture_30)); }
	inline CultureInfo_t4157843068 * get_parent_culture_30() const { return ___parent_culture_30; }
	inline CultureInfo_t4157843068 ** get_address_of_parent_culture_30() { return &___parent_culture_30; }
	inline void set_parent_culture_30(CultureInfo_t4157843068 * value)
	{
		___parent_culture_30 = value;
		Il2CppCodeGenWriteBarrier((&___parent_culture_30), value);
	}

	inline static int32_t get_offset_of_m_dataItem_31() { return static_cast<int32_t>(offsetof(CultureInfo_t4157843068, ___m_dataItem_31)); }
	inline int32_t get_m_dataItem_31() const { return ___m_dataItem_31; }
	inline int32_t* get_address_of_m_dataItem_31() { return &___m_dataItem_31; }
	inline void set_m_dataItem_31(int32_t value)
	{
		___m_dataItem_31 = value;
	}

	inline static int32_t get_offset_of_calendar_32() { return static_cast<int32_t>(offsetof(CultureInfo_t4157843068, ___calendar_32)); }
	inline Calendar_t1661121569 * get_calendar_32() const { return ___calendar_32; }
	inline Calendar_t1661121569 ** get_address_of_calendar_32() { return &___calendar_32; }
	inline void set_calendar_32(Calendar_t1661121569 * value)
	{
		___calendar_32 = value;
		Il2CppCodeGenWriteBarrier((&___calendar_32), value);
	}

	inline static int32_t get_offset_of_constructed_33() { return static_cast<int32_t>(offsetof(CultureInfo_t4157843068, ___constructed_33)); }
	inline bool get_constructed_33() const { return ___constructed_33; }
	inline bool* get_address_of_constructed_33() { return &___constructed_33; }
	inline void set_constructed_33(bool value)
	{
		___constructed_33 = value;
	}

	inline static int32_t get_offset_of_cached_serialized_form_34() { return static_cast<int32_t>(offsetof(CultureInfo_t4157843068, ___cached_serialized_form_34)); }
	inline ByteU5BU5D_t4116647657* get_cached_serialized_form_34() const { return ___cached_serialized_form_34; }
	inline ByteU5BU5D_t4116647657** get_address_of_cached_serialized_form_34() { return &___cached_serialized_form_34; }
	inline void set_cached_serialized_form_34(ByteU5BU5D_t4116647657* value)
	{
		___cached_serialized_form_34 = value;
		Il2CppCodeGenWriteBarrier((&___cached_serialized_form_34), value);
	}
};

struct CultureInfo_t4157843068_StaticFields
{
public:
	// System.Globalization.CultureInfo modreq(System.Runtime.CompilerServices.IsVolatile) System.Globalization.CultureInfo::invariant_culture_info
	CultureInfo_t4157843068 * ___invariant_culture_info_4;
	// System.Object System.Globalization.CultureInfo::shared_table_lock
	RuntimeObject * ___shared_table_lock_5;
	// System.Int32 System.Globalization.CultureInfo::BootstrapCultureID
	int32_t ___BootstrapCultureID_6;
	// System.String System.Globalization.CultureInfo::MSG_READONLY
	String_t* ___MSG_READONLY_35;
	// System.Collections.Hashtable System.Globalization.CultureInfo::shared_by_number
	Hashtable_t1853889766 * ___shared_by_number_36;
	// System.Collections.Hashtable System.Globalization.CultureInfo::shared_by_name
	Hashtable_t1853889766 * ___shared_by_name_37;
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> System.Globalization.CultureInfo::<>f__switch$map19
	Dictionary_2_t2736202052 * ___U3CU3Ef__switchU24map19_38;
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> System.Globalization.CultureInfo::<>f__switch$map1A
	Dictionary_2_t2736202052 * ___U3CU3Ef__switchU24map1A_39;

public:
	inline static int32_t get_offset_of_invariant_culture_info_4() { return static_cast<int32_t>(offsetof(CultureInfo_t4157843068_StaticFields, ___invariant_culture_info_4)); }
	inline CultureInfo_t4157843068 * get_invariant_culture_info_4() const { return ___invariant_culture_info_4; }
	inline CultureInfo_t4157843068 ** get_address_of_invariant_culture_info_4() { return &___invariant_culture_info_4; }
	inline void set_invariant_culture_info_4(CultureInfo_t4157843068 * value)
	{
		___invariant_culture_info_4 = value;
		Il2CppCodeGenWriteBarrier((&___invariant_culture_info_4), value);
	}

	inline static int32_t get_offset_of_shared_table_lock_5() { return static_cast<int32_t>(offsetof(CultureInfo_t4157843068_StaticFields, ___shared_table_lock_5)); }
	inline RuntimeObject * get_shared_table_lock_5() const { return ___shared_table_lock_5; }
	inline RuntimeObject ** get_address_of_shared_table_lock_5() { return &___shared_table_lock_5; }
	inline void set_shared_table_lock_5(RuntimeObject * value)
	{
		___shared_table_lock_5 = value;
		Il2CppCodeGenWriteBarrier((&___shared_table_lock_5), value);
	}

	inline static int32_t get_offset_of_BootstrapCultureID_6() { return static_cast<int32_t>(offsetof(CultureInfo_t4157843068_StaticFields, ___BootstrapCultureID_6)); }
	inline int32_t get_BootstrapCultureID_6() const { return ___BootstrapCultureID_6; }
	inline int32_t* get_address_of_BootstrapCultureID_6() { return &___BootstrapCultureID_6; }
	inline void set_BootstrapCultureID_6(int32_t value)
	{
		___BootstrapCultureID_6 = value;
	}

	inline static int32_t get_offset_of_MSG_READONLY_35() { return static_cast<int32_t>(offsetof(CultureInfo_t4157843068_StaticFields, ___MSG_READONLY_35)); }
	inline String_t* get_MSG_READONLY_35() const { return ___MSG_READONLY_35; }
	inline String_t** get_address_of_MSG_READONLY_35() { return &___MSG_READONLY_35; }
	inline void set_MSG_READONLY_35(String_t* value)
	{
		___MSG_READONLY_35 = value;
		Il2CppCodeGenWriteBarrier((&___MSG_READONLY_35), value);
	}

	inline static int32_t get_offset_of_shared_by_number_36() { return static_cast<int32_t>(offsetof(CultureInfo_t4157843068_StaticFields, ___shared_by_number_36)); }
	inline Hashtable_t1853889766 * get_shared_by_number_36() const { return ___shared_by_number_36; }
	inline Hashtable_t1853889766 ** get_address_of_shared_by_number_36() { return &___shared_by_number_36; }
	inline void set_shared_by_number_36(Hashtable_t1853889766 * value)
	{
		___shared_by_number_36 = value;
		Il2CppCodeGenWriteBarrier((&___shared_by_number_36), value);
	}

	inline static int32_t get_offset_of_shared_by_name_37() { return static_cast<int32_t>(offsetof(CultureInfo_t4157843068_StaticFields, ___shared_by_name_37)); }
	inline Hashtable_t1853889766 * get_shared_by_name_37() const { return ___shared_by_name_37; }
	inline Hashtable_t1853889766 ** get_address_of_shared_by_name_37() { return &___shared_by_name_37; }
	inline void set_shared_by_name_37(Hashtable_t1853889766 * value)
	{
		___shared_by_name_37 = value;
		Il2CppCodeGenWriteBarrier((&___shared_by_name_37), value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__switchU24map19_38() { return static_cast<int32_t>(offsetof(CultureInfo_t4157843068_StaticFields, ___U3CU3Ef__switchU24map19_38)); }
	inline Dictionary_2_t2736202052 * get_U3CU3Ef__switchU24map19_38() const { return ___U3CU3Ef__switchU24map19_38; }
	inline Dictionary_2_t2736202052 ** get_address_of_U3CU3Ef__switchU24map19_38() { return &___U3CU3Ef__switchU24map19_38; }
	inline void set_U3CU3Ef__switchU24map19_38(Dictionary_2_t2736202052 * value)
	{
		___U3CU3Ef__switchU24map19_38 = value;
		Il2CppCodeGenWriteBarrier((&___U3CU3Ef__switchU24map19_38), value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__switchU24map1A_39() { return static_cast<int32_t>(offsetof(CultureInfo_t4157843068_StaticFields, ___U3CU3Ef__switchU24map1A_39)); }
	inline Dictionary_2_t2736202052 * get_U3CU3Ef__switchU24map1A_39() const { return ___U3CU3Ef__switchU24map1A_39; }
	inline Dictionary_2_t2736202052 ** get_address_of_U3CU3Ef__switchU24map1A_39() { return &___U3CU3Ef__switchU24map1A_39; }
	inline void set_U3CU3Ef__switchU24map1A_39(Dictionary_2_t2736202052 * value)
	{
		___U3CU3Ef__switchU24map1A_39 = value;
		Il2CppCodeGenWriteBarrier((&___U3CU3Ef__switchU24map1A_39), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // CULTUREINFO_T4157843068_H
#ifndef IPV6ADDRESS_T2709566769_H
#define IPV6ADDRESS_T2709566769_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Net.IPv6Address
struct  IPv6Address_t2709566769  : public RuntimeObject
{
public:
	// System.UInt16[] System.Net.IPv6Address::address
	UInt16U5BU5D_t3326319531* ___address_0;
	// System.Int32 System.Net.IPv6Address::prefixLength
	int32_t ___prefixLength_1;
	// System.Int64 System.Net.IPv6Address::scopeId
	int64_t ___scopeId_2;

public:
	inline static int32_t get_offset_of_address_0() { return static_cast<int32_t>(offsetof(IPv6Address_t2709566769, ___address_0)); }
	inline UInt16U5BU5D_t3326319531* get_address_0() const { return ___address_0; }
	inline UInt16U5BU5D_t3326319531** get_address_of_address_0() { return &___address_0; }
	inline void set_address_0(UInt16U5BU5D_t3326319531* value)
	{
		___address_0 = value;
		Il2CppCodeGenWriteBarrier((&___address_0), value);
	}

	inline static int32_t get_offset_of_prefixLength_1() { return static_cast<int32_t>(offsetof(IPv6Address_t2709566769, ___prefixLength_1)); }
	inline int32_t get_prefixLength_1() const { return ___prefixLength_1; }
	inline int32_t* get_address_of_prefixLength_1() { return &___prefixLength_1; }
	inline void set_prefixLength_1(int32_t value)
	{
		___prefixLength_1 = value;
	}

	inline static int32_t get_offset_of_scopeId_2() { return static_cast<int32_t>(offsetof(IPv6Address_t2709566769, ___scopeId_2)); }
	inline int64_t get_scopeId_2() const { return ___scopeId_2; }
	inline int64_t* get_address_of_scopeId_2() { return &___scopeId_2; }
	inline void set_scopeId_2(int64_t value)
	{
		___scopeId_2 = value;
	}
};

struct IPv6Address_t2709566769_StaticFields
{
public:
	// System.Net.IPv6Address System.Net.IPv6Address::Loopback
	IPv6Address_t2709566769 * ___Loopback_3;
	// System.Net.IPv6Address System.Net.IPv6Address::Unspecified
	IPv6Address_t2709566769 * ___Unspecified_4;

public:
	inline static int32_t get_offset_of_Loopback_3() { return static_cast<int32_t>(offsetof(IPv6Address_t2709566769_StaticFields, ___Loopback_3)); }
	inline IPv6Address_t2709566769 * get_Loopback_3() const { return ___Loopback_3; }
	inline IPv6Address_t2709566769 ** get_address_of_Loopback_3() { return &___Loopback_3; }
	inline void set_Loopback_3(IPv6Address_t2709566769 * value)
	{
		___Loopback_3 = value;
		Il2CppCodeGenWriteBarrier((&___Loopback_3), value);
	}

	inline static int32_t get_offset_of_Unspecified_4() { return static_cast<int32_t>(offsetof(IPv6Address_t2709566769_StaticFields, ___Unspecified_4)); }
	inline IPv6Address_t2709566769 * get_Unspecified_4() const { return ___Unspecified_4; }
	inline IPv6Address_t2709566769 ** get_address_of_Unspecified_4() { return &___Unspecified_4; }
	inline void set_Unspecified_4(IPv6Address_t2709566769 * value)
	{
		___Unspecified_4 = value;
		Il2CppCodeGenWriteBarrier((&___Unspecified_4), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // IPV6ADDRESS_T2709566769_H
#ifndef URI_T100236324_H
#define URI_T100236324_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Uri
struct  Uri_t100236324  : public RuntimeObject
{
public:
	// System.Boolean System.Uri::isUnixFilePath
	bool ___isUnixFilePath_1;
	// System.String System.Uri::source
	String_t* ___source_2;
	// System.String System.Uri::scheme
	String_t* ___scheme_3;
	// System.String System.Uri::host
	String_t* ___host_4;
	// System.Int32 System.Uri::port
	int32_t ___port_5;
	// System.String System.Uri::path
	String_t* ___path_6;
	// System.String System.Uri::query
	String_t* ___query_7;
	// System.String System.Uri::fragment
	String_t* ___fragment_8;
	// System.String System.Uri::userinfo
	String_t* ___userinfo_9;
	// System.Boolean System.Uri::isUnc
	bool ___isUnc_10;
	// System.Boolean System.Uri::isOpaquePart
	bool ___isOpaquePart_11;
	// System.Boolean System.Uri::isAbsoluteUri
	bool ___isAbsoluteUri_12;
	// System.String[] System.Uri::segments
	StringU5BU5D_t1281789340* ___segments_13;
	// System.Boolean System.Uri::userEscaped
	bool ___userEscaped_14;
	// System.String System.Uri::cachedAbsoluteUri
	String_t* ___cachedAbsoluteUri_15;
	// System.String System.Uri::cachedToString
	String_t* ___cachedToString_16;
	// System.String System.Uri::cachedLocalPath
	String_t* ___cachedLocalPath_17;
	// System.Int32 System.Uri::cachedHashCode
	int32_t ___cachedHashCode_18;
	// System.UriParser System.Uri::parser
	UriParser_t3890150400 * ___parser_32;

public:
	inline static int32_t get_offset_of_isUnixFilePath_1() { return static_cast<int32_t>(offsetof(Uri_t100236324, ___isUnixFilePath_1)); }
	inline bool get_isUnixFilePath_1() const { return ___isUnixFilePath_1; }
	inline bool* get_address_of_isUnixFilePath_1() { return &___isUnixFilePath_1; }
	inline void set_isUnixFilePath_1(bool value)
	{
		___isUnixFilePath_1 = value;
	}

	inline static int32_t get_offset_of_source_2() { return static_cast<int32_t>(offsetof(Uri_t100236324, ___source_2)); }
	inline String_t* get_source_2() const { return ___source_2; }
	inline String_t** get_address_of_source_2() { return &___source_2; }
	inline void set_source_2(String_t* value)
	{
		___source_2 = value;
		Il2CppCodeGenWriteBarrier((&___source_2), value);
	}

	inline static int32_t get_offset_of_scheme_3() { return static_cast<int32_t>(offsetof(Uri_t100236324, ___scheme_3)); }
	inline String_t* get_scheme_3() const { return ___scheme_3; }
	inline String_t** get_address_of_scheme_3() { return &___scheme_3; }
	inline void set_scheme_3(String_t* value)
	{
		___scheme_3 = value;
		Il2CppCodeGenWriteBarrier((&___scheme_3), value);
	}

	inline static int32_t get_offset_of_host_4() { return static_cast<int32_t>(offsetof(Uri_t100236324, ___host_4)); }
	inline String_t* get_host_4() const { return ___host_4; }
	inline String_t** get_address_of_host_4() { return &___host_4; }
	inline void set_host_4(String_t* value)
	{
		___host_4 = value;
		Il2CppCodeGenWriteBarrier((&___host_4), value);
	}

	inline static int32_t get_offset_of_port_5() { return static_cast<int32_t>(offsetof(Uri_t100236324, ___port_5)); }
	inline int32_t get_port_5() const { return ___port_5; }
	inline int32_t* get_address_of_port_5() { return &___port_5; }
	inline void set_port_5(int32_t value)
	{
		___port_5 = value;
	}

	inline static int32_t get_offset_of_path_6() { return static_cast<int32_t>(offsetof(Uri_t100236324, ___path_6)); }
	inline String_t* get_path_6() const { return ___path_6; }
	inline String_t** get_address_of_path_6() { return &___path_6; }
	inline void set_path_6(String_t* value)
	{
		___path_6 = value;
		Il2CppCodeGenWriteBarrier((&___path_6), value);
	}

	inline static int32_t get_offset_of_query_7() { return static_cast<int32_t>(offsetof(Uri_t100236324, ___query_7)); }
	inline String_t* get_query_7() const { return ___query_7; }
	inline String_t** get_address_of_query_7() { return &___query_7; }
	inline void set_query_7(String_t* value)
	{
		___query_7 = value;
		Il2CppCodeGenWriteBarrier((&___query_7), value);
	}

	inline static int32_t get_offset_of_fragment_8() { return static_cast<int32_t>(offsetof(Uri_t100236324, ___fragment_8)); }
	inline String_t* get_fragment_8() const { return ___fragment_8; }
	inline String_t** get_address_of_fragment_8() { return &___fragment_8; }
	inline void set_fragment_8(String_t* value)
	{
		___fragment_8 = value;
		Il2CppCodeGenWriteBarrier((&___fragment_8), value);
	}

	inline static int32_t get_offset_of_userinfo_9() { return static_cast<int32_t>(offsetof(Uri_t100236324, ___userinfo_9)); }
	inline String_t* get_userinfo_9() const { return ___userinfo_9; }
	inline String_t** get_address_of_userinfo_9() { return &___userinfo_9; }
	inline void set_userinfo_9(String_t* value)
	{
		___userinfo_9 = value;
		Il2CppCodeGenWriteBarrier((&___userinfo_9), value);
	}

	inline static int32_t get_offset_of_isUnc_10() { return static_cast<int32_t>(offsetof(Uri_t100236324, ___isUnc_10)); }
	inline bool get_isUnc_10() const { return ___isUnc_10; }
	inline bool* get_address_of_isUnc_10() { return &___isUnc_10; }
	inline void set_isUnc_10(bool value)
	{
		___isUnc_10 = value;
	}

	inline static int32_t get_offset_of_isOpaquePart_11() { return static_cast<int32_t>(offsetof(Uri_t100236324, ___isOpaquePart_11)); }
	inline bool get_isOpaquePart_11() const { return ___isOpaquePart_11; }
	inline bool* get_address_of_isOpaquePart_11() { return &___isOpaquePart_11; }
	inline void set_isOpaquePart_11(bool value)
	{
		___isOpaquePart_11 = value;
	}

	inline static int32_t get_offset_of_isAbsoluteUri_12() { return static_cast<int32_t>(offsetof(Uri_t100236324, ___isAbsoluteUri_12)); }
	inline bool get_isAbsoluteUri_12() const { return ___isAbsoluteUri_12; }
	inline bool* get_address_of_isAbsoluteUri_12() { return &___isAbsoluteUri_12; }
	inline void set_isAbsoluteUri_12(bool value)
	{
		___isAbsoluteUri_12 = value;
	}

	inline static int32_t get_offset_of_segments_13() { return static_cast<int32_t>(offsetof(Uri_t100236324, ___segments_13)); }
	inline StringU5BU5D_t1281789340* get_segments_13() const { return ___segments_13; }
	inline StringU5BU5D_t1281789340** get_address_of_segments_13() { return &___segments_13; }
	inline void set_segments_13(StringU5BU5D_t1281789340* value)
	{
		___segments_13 = value;
		Il2CppCodeGenWriteBarrier((&___segments_13), value);
	}

	inline static int32_t get_offset_of_userEscaped_14() { return static_cast<int32_t>(offsetof(Uri_t100236324, ___userEscaped_14)); }
	inline bool get_userEscaped_14() const { return ___userEscaped_14; }
	inline bool* get_address_of_userEscaped_14() { return &___userEscaped_14; }
	inline void set_userEscaped_14(bool value)
	{
		___userEscaped_14 = value;
	}

	inline static int32_t get_offset_of_cachedAbsoluteUri_15() { return static_cast<int32_t>(offsetof(Uri_t100236324, ___cachedAbsoluteUri_15)); }
	inline String_t* get_cachedAbsoluteUri_15() const { return ___cachedAbsoluteUri_15; }
	inline String_t** get_address_of_cachedAbsoluteUri_15() { return &___cachedAbsoluteUri_15; }
	inline void set_cachedAbsoluteUri_15(String_t* value)
	{
		___cachedAbsoluteUri_15 = value;
		Il2CppCodeGenWriteBarrier((&___cachedAbsoluteUri_15), value);
	}

	inline static int32_t get_offset_of_cachedToString_16() { return static_cast<int32_t>(offsetof(Uri_t100236324, ___cachedToString_16)); }
	inline String_t* get_cachedToString_16() const { return ___cachedToString_16; }
	inline String_t** get_address_of_cachedToString_16() { return &___cachedToString_16; }
	inline void set_cachedToString_16(String_t* value)
	{
		___cachedToString_16 = value;
		Il2CppCodeGenWriteBarrier((&___cachedToString_16), value);
	}

	inline static int32_t get_offset_of_cachedLocalPath_17() { return static_cast<int32_t>(offsetof(Uri_t100236324, ___cachedLocalPath_17)); }
	inline String_t* get_cachedLocalPath_17() const { return ___cachedLocalPath_17; }
	inline String_t** get_address_of_cachedLocalPath_17() { return &___cachedLocalPath_17; }
	inline void set_cachedLocalPath_17(String_t* value)
	{
		___cachedLocalPath_17 = value;
		Il2CppCodeGenWriteBarrier((&___cachedLocalPath_17), value);
	}

	inline static int32_t get_offset_of_cachedHashCode_18() { return static_cast<int32_t>(offsetof(Uri_t100236324, ___cachedHashCode_18)); }
	inline int32_t get_cachedHashCode_18() const { return ___cachedHashCode_18; }
	inline int32_t* get_address_of_cachedHashCode_18() { return &___cachedHashCode_18; }
	inline void set_cachedHashCode_18(int32_t value)
	{
		___cachedHashCode_18 = value;
	}

	inline static int32_t get_offset_of_parser_32() { return static_cast<int32_t>(offsetof(Uri_t100236324, ___parser_32)); }
	inline UriParser_t3890150400 * get_parser_32() const { return ___parser_32; }
	inline UriParser_t3890150400 ** get_address_of_parser_32() { return &___parser_32; }
	inline void set_parser_32(UriParser_t3890150400 * value)
	{
		___parser_32 = value;
		Il2CppCodeGenWriteBarrier((&___parser_32), value);
	}
};

struct Uri_t100236324_StaticFields
{
public:
	// System.String System.Uri::hexUpperChars
	String_t* ___hexUpperChars_19;
	// System.String System.Uri::SchemeDelimiter
	String_t* ___SchemeDelimiter_20;
	// System.String System.Uri::UriSchemeFile
	String_t* ___UriSchemeFile_21;
	// System.String System.Uri::UriSchemeFtp
	String_t* ___UriSchemeFtp_22;
	// System.String System.Uri::UriSchemeGopher
	String_t* ___UriSchemeGopher_23;
	// System.String System.Uri::UriSchemeHttp
	String_t* ___UriSchemeHttp_24;
	// System.String System.Uri::UriSchemeHttps
	String_t* ___UriSchemeHttps_25;
	// System.String System.Uri::UriSchemeMailto
	String_t* ___UriSchemeMailto_26;
	// System.String System.Uri::UriSchemeNews
	String_t* ___UriSchemeNews_27;
	// System.String System.Uri::UriSchemeNntp
	String_t* ___UriSchemeNntp_28;
	// System.String System.Uri::UriSchemeNetPipe
	String_t* ___UriSchemeNetPipe_29;
	// System.String System.Uri::UriSchemeNetTcp
	String_t* ___UriSchemeNetTcp_30;
	// System.Uri/UriScheme[] System.Uri::schemes
	UriSchemeU5BU5D_t2082808316* ___schemes_31;
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> System.Uri::<>f__switch$map12
	Dictionary_2_t2736202052 * ___U3CU3Ef__switchU24map12_33;
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> System.Uri::<>f__switch$map13
	Dictionary_2_t2736202052 * ___U3CU3Ef__switchU24map13_34;
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> System.Uri::<>f__switch$map14
	Dictionary_2_t2736202052 * ___U3CU3Ef__switchU24map14_35;
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> System.Uri::<>f__switch$map15
	Dictionary_2_t2736202052 * ___U3CU3Ef__switchU24map15_36;
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> System.Uri::<>f__switch$map16
	Dictionary_2_t2736202052 * ___U3CU3Ef__switchU24map16_37;

public:
	inline static int32_t get_offset_of_hexUpperChars_19() { return static_cast<int32_t>(offsetof(Uri_t100236324_StaticFields, ___hexUpperChars_19)); }
	inline String_t* get_hexUpperChars_19() const { return ___hexUpperChars_19; }
	inline String_t** get_address_of_hexUpperChars_19() { return &___hexUpperChars_19; }
	inline void set_hexUpperChars_19(String_t* value)
	{
		___hexUpperChars_19 = value;
		Il2CppCodeGenWriteBarrier((&___hexUpperChars_19), value);
	}

	inline static int32_t get_offset_of_SchemeDelimiter_20() { return static_cast<int32_t>(offsetof(Uri_t100236324_StaticFields, ___SchemeDelimiter_20)); }
	inline String_t* get_SchemeDelimiter_20() const { return ___SchemeDelimiter_20; }
	inline String_t** get_address_of_SchemeDelimiter_20() { return &___SchemeDelimiter_20; }
	inline void set_SchemeDelimiter_20(String_t* value)
	{
		___SchemeDelimiter_20 = value;
		Il2CppCodeGenWriteBarrier((&___SchemeDelimiter_20), value);
	}

	inline static int32_t get_offset_of_UriSchemeFile_21() { return static_cast<int32_t>(offsetof(Uri_t100236324_StaticFields, ___UriSchemeFile_21)); }
	inline String_t* get_UriSchemeFile_21() const { return ___UriSchemeFile_21; }
	inline String_t** get_address_of_UriSchemeFile_21() { return &___UriSchemeFile_21; }
	inline void set_UriSchemeFile_21(String_t* value)
	{
		___UriSchemeFile_21 = value;
		Il2CppCodeGenWriteBarrier((&___UriSchemeFile_21), value);
	}

	inline static int32_t get_offset_of_UriSchemeFtp_22() { return static_cast<int32_t>(offsetof(Uri_t100236324_StaticFields, ___UriSchemeFtp_22)); }
	inline String_t* get_UriSchemeFtp_22() const { return ___UriSchemeFtp_22; }
	inline String_t** get_address_of_UriSchemeFtp_22() { return &___UriSchemeFtp_22; }
	inline void set_UriSchemeFtp_22(String_t* value)
	{
		___UriSchemeFtp_22 = value;
		Il2CppCodeGenWriteBarrier((&___UriSchemeFtp_22), value);
	}

	inline static int32_t get_offset_of_UriSchemeGopher_23() { return static_cast<int32_t>(offsetof(Uri_t100236324_StaticFields, ___UriSchemeGopher_23)); }
	inline String_t* get_UriSchemeGopher_23() const { return ___UriSchemeGopher_23; }
	inline String_t** get_address_of_UriSchemeGopher_23() { return &___UriSchemeGopher_23; }
	inline void set_UriSchemeGopher_23(String_t* value)
	{
		___UriSchemeGopher_23 = value;
		Il2CppCodeGenWriteBarrier((&___UriSchemeGopher_23), value);
	}

	inline static int32_t get_offset_of_UriSchemeHttp_24() { return static_cast<int32_t>(offsetof(Uri_t100236324_StaticFields, ___UriSchemeHttp_24)); }
	inline String_t* get_UriSchemeHttp_24() const { return ___UriSchemeHttp_24; }
	inline String_t** get_address_of_UriSchemeHttp_24() { return &___UriSchemeHttp_24; }
	inline void set_UriSchemeHttp_24(String_t* value)
	{
		___UriSchemeHttp_24 = value;
		Il2CppCodeGenWriteBarrier((&___UriSchemeHttp_24), value);
	}

	inline static int32_t get_offset_of_UriSchemeHttps_25() { return static_cast<int32_t>(offsetof(Uri_t100236324_StaticFields, ___UriSchemeHttps_25)); }
	inline String_t* get_UriSchemeHttps_25() const { return ___UriSchemeHttps_25; }
	inline String_t** get_address_of_UriSchemeHttps_25() { return &___UriSchemeHttps_25; }
	inline void set_UriSchemeHttps_25(String_t* value)
	{
		___UriSchemeHttps_25 = value;
		Il2CppCodeGenWriteBarrier((&___UriSchemeHttps_25), value);
	}

	inline static int32_t get_offset_of_UriSchemeMailto_26() { return static_cast<int32_t>(offsetof(Uri_t100236324_StaticFields, ___UriSchemeMailto_26)); }
	inline String_t* get_UriSchemeMailto_26() const { return ___UriSchemeMailto_26; }
	inline String_t** get_address_of_UriSchemeMailto_26() { return &___UriSchemeMailto_26; }
	inline void set_UriSchemeMailto_26(String_t* value)
	{
		___UriSchemeMailto_26 = value;
		Il2CppCodeGenWriteBarrier((&___UriSchemeMailto_26), value);
	}

	inline static int32_t get_offset_of_UriSchemeNews_27() { return static_cast<int32_t>(offsetof(Uri_t100236324_StaticFields, ___UriSchemeNews_27)); }
	inline String_t* get_UriSchemeNews_27() const { return ___UriSchemeNews_27; }
	inline String_t** get_address_of_UriSchemeNews_27() { return &___UriSchemeNews_27; }
	inline void set_UriSchemeNews_27(String_t* value)
	{
		___UriSchemeNews_27 = value;
		Il2CppCodeGenWriteBarrier((&___UriSchemeNews_27), value);
	}

	inline static int32_t get_offset_of_UriSchemeNntp_28() { return static_cast<int32_t>(offsetof(Uri_t100236324_StaticFields, ___UriSchemeNntp_28)); }
	inline String_t* get_UriSchemeNntp_28() const { return ___UriSchemeNntp_28; }
	inline String_t** get_address_of_UriSchemeNntp_28() { return &___UriSchemeNntp_28; }
	inline void set_UriSchemeNntp_28(String_t* value)
	{
		___UriSchemeNntp_28 = value;
		Il2CppCodeGenWriteBarrier((&___UriSchemeNntp_28), value);
	}

	inline static int32_t get_offset_of_UriSchemeNetPipe_29() { return static_cast<int32_t>(offsetof(Uri_t100236324_StaticFields, ___UriSchemeNetPipe_29)); }
	inline String_t* get_UriSchemeNetPipe_29() const { return ___UriSchemeNetPipe_29; }
	inline String_t** get_address_of_UriSchemeNetPipe_29() { return &___UriSchemeNetPipe_29; }
	inline void set_UriSchemeNetPipe_29(String_t* value)
	{
		___UriSchemeNetPipe_29 = value;
		Il2CppCodeGenWriteBarrier((&___UriSchemeNetPipe_29), value);
	}

	inline static int32_t get_offset_of_UriSchemeNetTcp_30() { return static_cast<int32_t>(offsetof(Uri_t100236324_StaticFields, ___UriSchemeNetTcp_30)); }
	inline String_t* get_UriSchemeNetTcp_30() const { return ___UriSchemeNetTcp_30; }
	inline String_t** get_address_of_UriSchemeNetTcp_30() { return &___UriSchemeNetTcp_30; }
	inline void set_UriSchemeNetTcp_30(String_t* value)
	{
		___UriSchemeNetTcp_30 = value;
		Il2CppCodeGenWriteBarrier((&___UriSchemeNetTcp_30), value);
	}

	inline static int32_t get_offset_of_schemes_31() { return static_cast<int32_t>(offsetof(Uri_t100236324_StaticFields, ___schemes_31)); }
	inline UriSchemeU5BU5D_t2082808316* get_schemes_31() const { return ___schemes_31; }
	inline UriSchemeU5BU5D_t2082808316** get_address_of_schemes_31() { return &___schemes_31; }
	inline void set_schemes_31(UriSchemeU5BU5D_t2082808316* value)
	{
		___schemes_31 = value;
		Il2CppCodeGenWriteBarrier((&___schemes_31), value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__switchU24map12_33() { return static_cast<int32_t>(offsetof(Uri_t100236324_StaticFields, ___U3CU3Ef__switchU24map12_33)); }
	inline Dictionary_2_t2736202052 * get_U3CU3Ef__switchU24map12_33() const { return ___U3CU3Ef__switchU24map12_33; }
	inline Dictionary_2_t2736202052 ** get_address_of_U3CU3Ef__switchU24map12_33() { return &___U3CU3Ef__switchU24map12_33; }
	inline void set_U3CU3Ef__switchU24map12_33(Dictionary_2_t2736202052 * value)
	{
		___U3CU3Ef__switchU24map12_33 = value;
		Il2CppCodeGenWriteBarrier((&___U3CU3Ef__switchU24map12_33), value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__switchU24map13_34() { return static_cast<int32_t>(offsetof(Uri_t100236324_StaticFields, ___U3CU3Ef__switchU24map13_34)); }
	inline Dictionary_2_t2736202052 * get_U3CU3Ef__switchU24map13_34() const { return ___U3CU3Ef__switchU24map13_34; }
	inline Dictionary_2_t2736202052 ** get_address_of_U3CU3Ef__switchU24map13_34() { return &___U3CU3Ef__switchU24map13_34; }
	inline void set_U3CU3Ef__switchU24map13_34(Dictionary_2_t2736202052 * value)
	{
		___U3CU3Ef__switchU24map13_34 = value;
		Il2CppCodeGenWriteBarrier((&___U3CU3Ef__switchU24map13_34), value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__switchU24map14_35() { return static_cast<int32_t>(offsetof(Uri_t100236324_StaticFields, ___U3CU3Ef__switchU24map14_35)); }
	inline Dictionary_2_t2736202052 * get_U3CU3Ef__switchU24map14_35() const { return ___U3CU3Ef__switchU24map14_35; }
	inline Dictionary_2_t2736202052 ** get_address_of_U3CU3Ef__switchU24map14_35() { return &___U3CU3Ef__switchU24map14_35; }
	inline void set_U3CU3Ef__switchU24map14_35(Dictionary_2_t2736202052 * value)
	{
		___U3CU3Ef__switchU24map14_35 = value;
		Il2CppCodeGenWriteBarrier((&___U3CU3Ef__switchU24map14_35), value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__switchU24map15_36() { return static_cast<int32_t>(offsetof(Uri_t100236324_StaticFields, ___U3CU3Ef__switchU24map15_36)); }
	inline Dictionary_2_t2736202052 * get_U3CU3Ef__switchU24map15_36() const { return ___U3CU3Ef__switchU24map15_36; }
	inline Dictionary_2_t2736202052 ** get_address_of_U3CU3Ef__switchU24map15_36() { return &___U3CU3Ef__switchU24map15_36; }
	inline void set_U3CU3Ef__switchU24map15_36(Dictionary_2_t2736202052 * value)
	{
		___U3CU3Ef__switchU24map15_36 = value;
		Il2CppCodeGenWriteBarrier((&___U3CU3Ef__switchU24map15_36), value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__switchU24map16_37() { return static_cast<int32_t>(offsetof(Uri_t100236324_StaticFields, ___U3CU3Ef__switchU24map16_37)); }
	inline Dictionary_2_t2736202052 * get_U3CU3Ef__switchU24map16_37() const { return ___U3CU3Ef__switchU24map16_37; }
	inline Dictionary_2_t2736202052 ** get_address_of_U3CU3Ef__switchU24map16_37() { return &___U3CU3Ef__switchU24map16_37; }
	inline void set_U3CU3Ef__switchU24map16_37(Dictionary_2_t2736202052 * value)
	{
		___U3CU3Ef__switchU24map16_37 = value;
		Il2CppCodeGenWriteBarrier((&___U3CU3Ef__switchU24map16_37), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // URI_T100236324_H
#ifndef SERIALIZATIONINFO_T950877179_H
#define SERIALIZATIONINFO_T950877179_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Runtime.Serialization.SerializationInfo
struct  SerializationInfo_t950877179  : public RuntimeObject
{
public:
	// System.Collections.Hashtable System.Runtime.Serialization.SerializationInfo::serialized
	Hashtable_t1853889766 * ___serialized_0;
	// System.Collections.ArrayList System.Runtime.Serialization.SerializationInfo::values
	ArrayList_t2718874744 * ___values_1;
	// System.String System.Runtime.Serialization.SerializationInfo::assemblyName
	String_t* ___assemblyName_2;
	// System.String System.Runtime.Serialization.SerializationInfo::fullTypeName
	String_t* ___fullTypeName_3;
	// System.Runtime.Serialization.IFormatterConverter System.Runtime.Serialization.SerializationInfo::converter
	RuntimeObject* ___converter_4;

public:
	inline static int32_t get_offset_of_serialized_0() { return static_cast<int32_t>(offsetof(SerializationInfo_t950877179, ___serialized_0)); }
	inline Hashtable_t1853889766 * get_serialized_0() const { return ___serialized_0; }
	inline Hashtable_t1853889766 ** get_address_of_serialized_0() { return &___serialized_0; }
	inline void set_serialized_0(Hashtable_t1853889766 * value)
	{
		___serialized_0 = value;
		Il2CppCodeGenWriteBarrier((&___serialized_0), value);
	}

	inline static int32_t get_offset_of_values_1() { return static_cast<int32_t>(offsetof(SerializationInfo_t950877179, ___values_1)); }
	inline ArrayList_t2718874744 * get_values_1() const { return ___values_1; }
	inline ArrayList_t2718874744 ** get_address_of_values_1() { return &___values_1; }
	inline void set_values_1(ArrayList_t2718874744 * value)
	{
		___values_1 = value;
		Il2CppCodeGenWriteBarrier((&___values_1), value);
	}

	inline static int32_t get_offset_of_assemblyName_2() { return static_cast<int32_t>(offsetof(SerializationInfo_t950877179, ___assemblyName_2)); }
	inline String_t* get_assemblyName_2() const { return ___assemblyName_2; }
	inline String_t** get_address_of_assemblyName_2() { return &___assemblyName_2; }
	inline void set_assemblyName_2(String_t* value)
	{
		___assemblyName_2 = value;
		Il2CppCodeGenWriteBarrier((&___assemblyName_2), value);
	}

	inline static int32_t get_offset_of_fullTypeName_3() { return static_cast<int32_t>(offsetof(SerializationInfo_t950877179, ___fullTypeName_3)); }
	inline String_t* get_fullTypeName_3() const { return ___fullTypeName_3; }
	inline String_t** get_address_of_fullTypeName_3() { return &___fullTypeName_3; }
	inline void set_fullTypeName_3(String_t* value)
	{
		___fullTypeName_3 = value;
		Il2CppCodeGenWriteBarrier((&___fullTypeName_3), value);
	}

	inline static int32_t get_offset_of_converter_4() { return static_cast<int32_t>(offsetof(SerializationInfo_t950877179, ___converter_4)); }
	inline RuntimeObject* get_converter_4() const { return ___converter_4; }
	inline RuntimeObject** get_address_of_converter_4() { return &___converter_4; }
	inline void set_converter_4(RuntimeObject* value)
	{
		___converter_4 = value;
		Il2CppCodeGenWriteBarrier((&___converter_4), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SERIALIZATIONINFO_T950877179_H
#ifndef DICTIONARY_2_T2736202052_H
#define DICTIONARY_2_T2736202052_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.Dictionary`2<System.String,System.Int32>
struct  Dictionary_2_t2736202052  : public RuntimeObject
{
public:
	// System.Int32[] System.Collections.Generic.Dictionary`2::table
	Int32U5BU5D_t385246372* ___table_4;
	// System.Collections.Generic.Link[] System.Collections.Generic.Dictionary`2::linkSlots
	LinkU5BU5D_t964245573* ___linkSlots_5;
	// TKey[] System.Collections.Generic.Dictionary`2::keySlots
	StringU5BU5D_t1281789340* ___keySlots_6;
	// TValue[] System.Collections.Generic.Dictionary`2::valueSlots
	Int32U5BU5D_t385246372* ___valueSlots_7;
	// System.Int32 System.Collections.Generic.Dictionary`2::touchedSlots
	int32_t ___touchedSlots_8;
	// System.Int32 System.Collections.Generic.Dictionary`2::emptySlot
	int32_t ___emptySlot_9;
	// System.Int32 System.Collections.Generic.Dictionary`2::count
	int32_t ___count_10;
	// System.Int32 System.Collections.Generic.Dictionary`2::threshold
	int32_t ___threshold_11;
	// System.Collections.Generic.IEqualityComparer`1<TKey> System.Collections.Generic.Dictionary`2::hcp
	RuntimeObject* ___hcp_12;
	// System.Runtime.Serialization.SerializationInfo System.Collections.Generic.Dictionary`2::serialization_info
	SerializationInfo_t950877179 * ___serialization_info_13;
	// System.Int32 System.Collections.Generic.Dictionary`2::generation
	int32_t ___generation_14;

public:
	inline static int32_t get_offset_of_table_4() { return static_cast<int32_t>(offsetof(Dictionary_2_t2736202052, ___table_4)); }
	inline Int32U5BU5D_t385246372* get_table_4() const { return ___table_4; }
	inline Int32U5BU5D_t385246372** get_address_of_table_4() { return &___table_4; }
	inline void set_table_4(Int32U5BU5D_t385246372* value)
	{
		___table_4 = value;
		Il2CppCodeGenWriteBarrier((&___table_4), value);
	}

	inline static int32_t get_offset_of_linkSlots_5() { return static_cast<int32_t>(offsetof(Dictionary_2_t2736202052, ___linkSlots_5)); }
	inline LinkU5BU5D_t964245573* get_linkSlots_5() const { return ___linkSlots_5; }
	inline LinkU5BU5D_t964245573** get_address_of_linkSlots_5() { return &___linkSlots_5; }
	inline void set_linkSlots_5(LinkU5BU5D_t964245573* value)
	{
		___linkSlots_5 = value;
		Il2CppCodeGenWriteBarrier((&___linkSlots_5), value);
	}

	inline static int32_t get_offset_of_keySlots_6() { return static_cast<int32_t>(offsetof(Dictionary_2_t2736202052, ___keySlots_6)); }
	inline StringU5BU5D_t1281789340* get_keySlots_6() const { return ___keySlots_6; }
	inline StringU5BU5D_t1281789340** get_address_of_keySlots_6() { return &___keySlots_6; }
	inline void set_keySlots_6(StringU5BU5D_t1281789340* value)
	{
		___keySlots_6 = value;
		Il2CppCodeGenWriteBarrier((&___keySlots_6), value);
	}

	inline static int32_t get_offset_of_valueSlots_7() { return static_cast<int32_t>(offsetof(Dictionary_2_t2736202052, ___valueSlots_7)); }
	inline Int32U5BU5D_t385246372* get_valueSlots_7() const { return ___valueSlots_7; }
	inline Int32U5BU5D_t385246372** get_address_of_valueSlots_7() { return &___valueSlots_7; }
	inline void set_valueSlots_7(Int32U5BU5D_t385246372* value)
	{
		___valueSlots_7 = value;
		Il2CppCodeGenWriteBarrier((&___valueSlots_7), value);
	}

	inline static int32_t get_offset_of_touchedSlots_8() { return static_cast<int32_t>(offsetof(Dictionary_2_t2736202052, ___touchedSlots_8)); }
	inline int32_t get_touchedSlots_8() const { return ___touchedSlots_8; }
	inline int32_t* get_address_of_touchedSlots_8() { return &___touchedSlots_8; }
	inline void set_touchedSlots_8(int32_t value)
	{
		___touchedSlots_8 = value;
	}

	inline static int32_t get_offset_of_emptySlot_9() { return static_cast<int32_t>(offsetof(Dictionary_2_t2736202052, ___emptySlot_9)); }
	inline int32_t get_emptySlot_9() const { return ___emptySlot_9; }
	inline int32_t* get_address_of_emptySlot_9() { return &___emptySlot_9; }
	inline void set_emptySlot_9(int32_t value)
	{
		___emptySlot_9 = value;
	}

	inline static int32_t get_offset_of_count_10() { return static_cast<int32_t>(offsetof(Dictionary_2_t2736202052, ___count_10)); }
	inline int32_t get_count_10() const { return ___count_10; }
	inline int32_t* get_address_of_count_10() { return &___count_10; }
	inline void set_count_10(int32_t value)
	{
		___count_10 = value;
	}

	inline static int32_t get_offset_of_threshold_11() { return static_cast<int32_t>(offsetof(Dictionary_2_t2736202052, ___threshold_11)); }
	inline int32_t get_threshold_11() const { return ___threshold_11; }
	inline int32_t* get_address_of_threshold_11() { return &___threshold_11; }
	inline void set_threshold_11(int32_t value)
	{
		___threshold_11 = value;
	}

	inline static int32_t get_offset_of_hcp_12() { return static_cast<int32_t>(offsetof(Dictionary_2_t2736202052, ___hcp_12)); }
	inline RuntimeObject* get_hcp_12() const { return ___hcp_12; }
	inline RuntimeObject** get_address_of_hcp_12() { return &___hcp_12; }
	inline void set_hcp_12(RuntimeObject* value)
	{
		___hcp_12 = value;
		Il2CppCodeGenWriteBarrier((&___hcp_12), value);
	}

	inline static int32_t get_offset_of_serialization_info_13() { return static_cast<int32_t>(offsetof(Dictionary_2_t2736202052, ___serialization_info_13)); }
	inline SerializationInfo_t950877179 * get_serialization_info_13() const { return ___serialization_info_13; }
	inline SerializationInfo_t950877179 ** get_address_of_serialization_info_13() { return &___serialization_info_13; }
	inline void set_serialization_info_13(SerializationInfo_t950877179 * value)
	{
		___serialization_info_13 = value;
		Il2CppCodeGenWriteBarrier((&___serialization_info_13), value);
	}

	inline static int32_t get_offset_of_generation_14() { return static_cast<int32_t>(offsetof(Dictionary_2_t2736202052, ___generation_14)); }
	inline int32_t get_generation_14() const { return ___generation_14; }
	inline int32_t* get_address_of_generation_14() { return &___generation_14; }
	inline void set_generation_14(int32_t value)
	{
		___generation_14 = value;
	}
};

struct Dictionary_2_t2736202052_StaticFields
{
public:
	// System.Collections.Generic.Dictionary`2/Transform`1<TKey,TValue,System.Collections.DictionaryEntry> System.Collections.Generic.Dictionary`2::<>f__am$cacheB
	Transform_1_t3530625384 * ___U3CU3Ef__amU24cacheB_15;

public:
	inline static int32_t get_offset_of_U3CU3Ef__amU24cacheB_15() { return static_cast<int32_t>(offsetof(Dictionary_2_t2736202052_StaticFields, ___U3CU3Ef__amU24cacheB_15)); }
	inline Transform_1_t3530625384 * get_U3CU3Ef__amU24cacheB_15() const { return ___U3CU3Ef__amU24cacheB_15; }
	inline Transform_1_t3530625384 ** get_address_of_U3CU3Ef__amU24cacheB_15() { return &___U3CU3Ef__amU24cacheB_15; }
	inline void set_U3CU3Ef__amU24cacheB_15(Transform_1_t3530625384 * value)
	{
		___U3CU3Ef__amU24cacheB_15 = value;
		Il2CppCodeGenWriteBarrier((&___U3CU3Ef__amU24cacheB_15), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // DICTIONARY_2_T2736202052_H
#ifndef URIPARSER_T3890150400_H
#define URIPARSER_T3890150400_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.UriParser
struct  UriParser_t3890150400  : public RuntimeObject
{
public:
	// System.String System.UriParser::scheme_name
	String_t* ___scheme_name_2;
	// System.Int32 System.UriParser::default_port
	int32_t ___default_port_3;

public:
	inline static int32_t get_offset_of_scheme_name_2() { return static_cast<int32_t>(offsetof(UriParser_t3890150400, ___scheme_name_2)); }
	inline String_t* get_scheme_name_2() const { return ___scheme_name_2; }
	inline String_t** get_address_of_scheme_name_2() { return &___scheme_name_2; }
	inline void set_scheme_name_2(String_t* value)
	{
		___scheme_name_2 = value;
		Il2CppCodeGenWriteBarrier((&___scheme_name_2), value);
	}

	inline static int32_t get_offset_of_default_port_3() { return static_cast<int32_t>(offsetof(UriParser_t3890150400, ___default_port_3)); }
	inline int32_t get_default_port_3() const { return ___default_port_3; }
	inline int32_t* get_address_of_default_port_3() { return &___default_port_3; }
	inline void set_default_port_3(int32_t value)
	{
		___default_port_3 = value;
	}
};

struct UriParser_t3890150400_StaticFields
{
public:
	// System.Object System.UriParser::lock_object
	RuntimeObject * ___lock_object_0;
	// System.Collections.Hashtable System.UriParser::table
	Hashtable_t1853889766 * ___table_1;
	// System.Text.RegularExpressions.Regex System.UriParser::uri_regex
	Regex_t3657309853 * ___uri_regex_4;
	// System.Text.RegularExpressions.Regex System.UriParser::auth_regex
	Regex_t3657309853 * ___auth_regex_5;

public:
	inline static int32_t get_offset_of_lock_object_0() { return static_cast<int32_t>(offsetof(UriParser_t3890150400_StaticFields, ___lock_object_0)); }
	inline RuntimeObject * get_lock_object_0() const { return ___lock_object_0; }
	inline RuntimeObject ** get_address_of_lock_object_0() { return &___lock_object_0; }
	inline void set_lock_object_0(RuntimeObject * value)
	{
		___lock_object_0 = value;
		Il2CppCodeGenWriteBarrier((&___lock_object_0), value);
	}

	inline static int32_t get_offset_of_table_1() { return static_cast<int32_t>(offsetof(UriParser_t3890150400_StaticFields, ___table_1)); }
	inline Hashtable_t1853889766 * get_table_1() const { return ___table_1; }
	inline Hashtable_t1853889766 ** get_address_of_table_1() { return &___table_1; }
	inline void set_table_1(Hashtable_t1853889766 * value)
	{
		___table_1 = value;
		Il2CppCodeGenWriteBarrier((&___table_1), value);
	}

	inline static int32_t get_offset_of_uri_regex_4() { return static_cast<int32_t>(offsetof(UriParser_t3890150400_StaticFields, ___uri_regex_4)); }
	inline Regex_t3657309853 * get_uri_regex_4() const { return ___uri_regex_4; }
	inline Regex_t3657309853 ** get_address_of_uri_regex_4() { return &___uri_regex_4; }
	inline void set_uri_regex_4(Regex_t3657309853 * value)
	{
		___uri_regex_4 = value;
		Il2CppCodeGenWriteBarrier((&___uri_regex_4), value);
	}

	inline static int32_t get_offset_of_auth_regex_5() { return static_cast<int32_t>(offsetof(UriParser_t3890150400_StaticFields, ___auth_regex_5)); }
	inline Regex_t3657309853 * get_auth_regex_5() const { return ___auth_regex_5; }
	inline Regex_t3657309853 ** get_address_of_auth_regex_5() { return &___auth_regex_5; }
	inline void set_auth_regex_5(Regex_t3657309853 * value)
	{
		___auth_regex_5 = value;
		Il2CppCodeGenWriteBarrier((&___auth_regex_5), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // URIPARSER_T3890150400_H
#ifndef COLLECTIONBASE_T2727926298_H
#define COLLECTIONBASE_T2727926298_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.CollectionBase
struct  CollectionBase_t2727926298  : public RuntimeObject
{
public:
	// System.Collections.ArrayList System.Collections.CollectionBase::list
	ArrayList_t2718874744 * ___list_0;

public:
	inline static int32_t get_offset_of_list_0() { return static_cast<int32_t>(offsetof(CollectionBase_t2727926298, ___list_0)); }
	inline ArrayList_t2718874744 * get_list_0() const { return ___list_0; }
	inline ArrayList_t2718874744 ** get_address_of_list_0() { return &___list_0; }
	inline void set_list_0(ArrayList_t2718874744 * value)
	{
		___list_0 = value;
		Il2CppCodeGenWriteBarrier((&___list_0), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // COLLECTIONBASE_T2727926298_H
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
#ifndef MEMBERINFO_T_H
#define MEMBERINFO_T_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Reflection.MemberInfo
struct  MemberInfo_t  : public RuntimeObject
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // MEMBERINFO_T_H
#ifndef STREAM_T1273022909_H
#define STREAM_T1273022909_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.IO.Stream
struct  Stream_t1273022909  : public RuntimeObject
{
public:

public:
};

struct Stream_t1273022909_StaticFields
{
public:
	// System.IO.Stream System.IO.Stream::Null
	Stream_t1273022909 * ___Null_0;

public:
	inline static int32_t get_offset_of_Null_0() { return static_cast<int32_t>(offsetof(Stream_t1273022909_StaticFields, ___Null_0)); }
	inline Stream_t1273022909 * get_Null_0() const { return ___Null_0; }
	inline Stream_t1273022909 ** get_address_of_Null_0() { return &___Null_0; }
	inline void set_Null_0(Stream_t1273022909 * value)
	{
		___Null_0 = value;
		Il2CppCodeGenWriteBarrier((&___Null_0), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // STREAM_T1273022909_H
#ifndef ARRAYLIST_T2718874744_H
#define ARRAYLIST_T2718874744_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.ArrayList
struct  ArrayList_t2718874744  : public RuntimeObject
{
public:
	// System.Int32 System.Collections.ArrayList::_size
	int32_t ____size_1;
	// System.Object[] System.Collections.ArrayList::_items
	ObjectU5BU5D_t2843939325* ____items_2;
	// System.Int32 System.Collections.ArrayList::_version
	int32_t ____version_3;

public:
	inline static int32_t get_offset_of__size_1() { return static_cast<int32_t>(offsetof(ArrayList_t2718874744, ____size_1)); }
	inline int32_t get__size_1() const { return ____size_1; }
	inline int32_t* get_address_of__size_1() { return &____size_1; }
	inline void set__size_1(int32_t value)
	{
		____size_1 = value;
	}

	inline static int32_t get_offset_of__items_2() { return static_cast<int32_t>(offsetof(ArrayList_t2718874744, ____items_2)); }
	inline ObjectU5BU5D_t2843939325* get__items_2() const { return ____items_2; }
	inline ObjectU5BU5D_t2843939325** get_address_of__items_2() { return &____items_2; }
	inline void set__items_2(ObjectU5BU5D_t2843939325* value)
	{
		____items_2 = value;
		Il2CppCodeGenWriteBarrier((&____items_2), value);
	}

	inline static int32_t get_offset_of__version_3() { return static_cast<int32_t>(offsetof(ArrayList_t2718874744, ____version_3)); }
	inline int32_t get__version_3() const { return ____version_3; }
	inline int32_t* get_address_of__version_3() { return &____version_3; }
	inline void set__version_3(int32_t value)
	{
		____version_3 = value;
	}
};

struct ArrayList_t2718874744_StaticFields
{
public:
	// System.Object[] System.Collections.ArrayList::EmptyArray
	ObjectU5BU5D_t2843939325* ___EmptyArray_4;

public:
	inline static int32_t get_offset_of_EmptyArray_4() { return static_cast<int32_t>(offsetof(ArrayList_t2718874744_StaticFields, ___EmptyArray_4)); }
	inline ObjectU5BU5D_t2843939325* get_EmptyArray_4() const { return ___EmptyArray_4; }
	inline ObjectU5BU5D_t2843939325** get_address_of_EmptyArray_4() { return &___EmptyArray_4; }
	inline void set_EmptyArray_4(ObjectU5BU5D_t2843939325* value)
	{
		___EmptyArray_4 = value;
		Il2CppCodeGenWriteBarrier((&___EmptyArray_4), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ARRAYLIST_T2718874744_H
#ifndef EXCEPTION_T_H
#define EXCEPTION_T_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Exception
struct  Exception_t  : public RuntimeObject
{
public:
	// System.IntPtr[] System.Exception::trace_ips
	IntPtrU5BU5D_t4013366056* ___trace_ips_0;
	// System.Exception System.Exception::inner_exception
	Exception_t * ___inner_exception_1;
	// System.String System.Exception::message
	String_t* ___message_2;
	// System.String System.Exception::help_link
	String_t* ___help_link_3;
	// System.String System.Exception::class_name
	String_t* ___class_name_4;
	// System.String System.Exception::stack_trace
	String_t* ___stack_trace_5;
	// System.String System.Exception::_remoteStackTraceString
	String_t* ____remoteStackTraceString_6;
	// System.Int32 System.Exception::remote_stack_index
	int32_t ___remote_stack_index_7;
	// System.Int32 System.Exception::hresult
	int32_t ___hresult_8;
	// System.String System.Exception::source
	String_t* ___source_9;
	// System.Collections.IDictionary System.Exception::_data
	RuntimeObject* ____data_10;

public:
	inline static int32_t get_offset_of_trace_ips_0() { return static_cast<int32_t>(offsetof(Exception_t, ___trace_ips_0)); }
	inline IntPtrU5BU5D_t4013366056* get_trace_ips_0() const { return ___trace_ips_0; }
	inline IntPtrU5BU5D_t4013366056** get_address_of_trace_ips_0() { return &___trace_ips_0; }
	inline void set_trace_ips_0(IntPtrU5BU5D_t4013366056* value)
	{
		___trace_ips_0 = value;
		Il2CppCodeGenWriteBarrier((&___trace_ips_0), value);
	}

	inline static int32_t get_offset_of_inner_exception_1() { return static_cast<int32_t>(offsetof(Exception_t, ___inner_exception_1)); }
	inline Exception_t * get_inner_exception_1() const { return ___inner_exception_1; }
	inline Exception_t ** get_address_of_inner_exception_1() { return &___inner_exception_1; }
	inline void set_inner_exception_1(Exception_t * value)
	{
		___inner_exception_1 = value;
		Il2CppCodeGenWriteBarrier((&___inner_exception_1), value);
	}

	inline static int32_t get_offset_of_message_2() { return static_cast<int32_t>(offsetof(Exception_t, ___message_2)); }
	inline String_t* get_message_2() const { return ___message_2; }
	inline String_t** get_address_of_message_2() { return &___message_2; }
	inline void set_message_2(String_t* value)
	{
		___message_2 = value;
		Il2CppCodeGenWriteBarrier((&___message_2), value);
	}

	inline static int32_t get_offset_of_help_link_3() { return static_cast<int32_t>(offsetof(Exception_t, ___help_link_3)); }
	inline String_t* get_help_link_3() const { return ___help_link_3; }
	inline String_t** get_address_of_help_link_3() { return &___help_link_3; }
	inline void set_help_link_3(String_t* value)
	{
		___help_link_3 = value;
		Il2CppCodeGenWriteBarrier((&___help_link_3), value);
	}

	inline static int32_t get_offset_of_class_name_4() { return static_cast<int32_t>(offsetof(Exception_t, ___class_name_4)); }
	inline String_t* get_class_name_4() const { return ___class_name_4; }
	inline String_t** get_address_of_class_name_4() { return &___class_name_4; }
	inline void set_class_name_4(String_t* value)
	{
		___class_name_4 = value;
		Il2CppCodeGenWriteBarrier((&___class_name_4), value);
	}

	inline static int32_t get_offset_of_stack_trace_5() { return static_cast<int32_t>(offsetof(Exception_t, ___stack_trace_5)); }
	inline String_t* get_stack_trace_5() const { return ___stack_trace_5; }
	inline String_t** get_address_of_stack_trace_5() { return &___stack_trace_5; }
	inline void set_stack_trace_5(String_t* value)
	{
		___stack_trace_5 = value;
		Il2CppCodeGenWriteBarrier((&___stack_trace_5), value);
	}

	inline static int32_t get_offset_of__remoteStackTraceString_6() { return static_cast<int32_t>(offsetof(Exception_t, ____remoteStackTraceString_6)); }
	inline String_t* get__remoteStackTraceString_6() const { return ____remoteStackTraceString_6; }
	inline String_t** get_address_of__remoteStackTraceString_6() { return &____remoteStackTraceString_6; }
	inline void set__remoteStackTraceString_6(String_t* value)
	{
		____remoteStackTraceString_6 = value;
		Il2CppCodeGenWriteBarrier((&____remoteStackTraceString_6), value);
	}

	inline static int32_t get_offset_of_remote_stack_index_7() { return static_cast<int32_t>(offsetof(Exception_t, ___remote_stack_index_7)); }
	inline int32_t get_remote_stack_index_7() const { return ___remote_stack_index_7; }
	inline int32_t* get_address_of_remote_stack_index_7() { return &___remote_stack_index_7; }
	inline void set_remote_stack_index_7(int32_t value)
	{
		___remote_stack_index_7 = value;
	}

	inline static int32_t get_offset_of_hresult_8() { return static_cast<int32_t>(offsetof(Exception_t, ___hresult_8)); }
	inline int32_t get_hresult_8() const { return ___hresult_8; }
	inline int32_t* get_address_of_hresult_8() { return &___hresult_8; }
	inline void set_hresult_8(int32_t value)
	{
		___hresult_8 = value;
	}

	inline static int32_t get_offset_of_source_9() { return static_cast<int32_t>(offsetof(Exception_t, ___source_9)); }
	inline String_t* get_source_9() const { return ___source_9; }
	inline String_t** get_address_of_source_9() { return &___source_9; }
	inline void set_source_9(String_t* value)
	{
		___source_9 = value;
		Il2CppCodeGenWriteBarrier((&___source_9), value);
	}

	inline static int32_t get_offset_of__data_10() { return static_cast<int32_t>(offsetof(Exception_t, ____data_10)); }
	inline RuntimeObject* get__data_10() const { return ____data_10; }
	inline RuntimeObject** get_address_of__data_10() { return &____data_10; }
	inline void set__data_10(RuntimeObject* value)
	{
		____data_10 = value;
		Il2CppCodeGenWriteBarrier((&____data_10), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // EXCEPTION_T_H
#ifndef TYPECONVERTER_T2249118273_H
#define TYPECONVERTER_T2249118273_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.ComponentModel.TypeConverter
struct  TypeConverter_t2249118273  : public RuntimeObject
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TYPECONVERTER_T2249118273_H
#ifndef HASHTABLE_T1853889766_H
#define HASHTABLE_T1853889766_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Hashtable
struct  Hashtable_t1853889766  : public RuntimeObject
{
public:
	// System.Int32 System.Collections.Hashtable::inUse
	int32_t ___inUse_1;
	// System.Int32 System.Collections.Hashtable::modificationCount
	int32_t ___modificationCount_2;
	// System.Single System.Collections.Hashtable::loadFactor
	float ___loadFactor_3;
	// System.Collections.Hashtable/Slot[] System.Collections.Hashtable::table
	SlotU5BU5D_t2994659099* ___table_4;
	// System.Int32[] System.Collections.Hashtable::hashes
	Int32U5BU5D_t385246372* ___hashes_5;
	// System.Int32 System.Collections.Hashtable::threshold
	int32_t ___threshold_6;
	// System.Collections.Hashtable/HashKeys System.Collections.Hashtable::hashKeys
	HashKeys_t1568156503 * ___hashKeys_7;
	// System.Collections.Hashtable/HashValues System.Collections.Hashtable::hashValues
	HashValues_t618387445 * ___hashValues_8;
	// System.Collections.IHashCodeProvider System.Collections.Hashtable::hcpRef
	RuntimeObject* ___hcpRef_9;
	// System.Collections.IComparer System.Collections.Hashtable::comparerRef
	RuntimeObject* ___comparerRef_10;
	// System.Runtime.Serialization.SerializationInfo System.Collections.Hashtable::serializationInfo
	SerializationInfo_t950877179 * ___serializationInfo_11;
	// System.Collections.IEqualityComparer System.Collections.Hashtable::equalityComparer
	RuntimeObject* ___equalityComparer_12;

public:
	inline static int32_t get_offset_of_inUse_1() { return static_cast<int32_t>(offsetof(Hashtable_t1853889766, ___inUse_1)); }
	inline int32_t get_inUse_1() const { return ___inUse_1; }
	inline int32_t* get_address_of_inUse_1() { return &___inUse_1; }
	inline void set_inUse_1(int32_t value)
	{
		___inUse_1 = value;
	}

	inline static int32_t get_offset_of_modificationCount_2() { return static_cast<int32_t>(offsetof(Hashtable_t1853889766, ___modificationCount_2)); }
	inline int32_t get_modificationCount_2() const { return ___modificationCount_2; }
	inline int32_t* get_address_of_modificationCount_2() { return &___modificationCount_2; }
	inline void set_modificationCount_2(int32_t value)
	{
		___modificationCount_2 = value;
	}

	inline static int32_t get_offset_of_loadFactor_3() { return static_cast<int32_t>(offsetof(Hashtable_t1853889766, ___loadFactor_3)); }
	inline float get_loadFactor_3() const { return ___loadFactor_3; }
	inline float* get_address_of_loadFactor_3() { return &___loadFactor_3; }
	inline void set_loadFactor_3(float value)
	{
		___loadFactor_3 = value;
	}

	inline static int32_t get_offset_of_table_4() { return static_cast<int32_t>(offsetof(Hashtable_t1853889766, ___table_4)); }
	inline SlotU5BU5D_t2994659099* get_table_4() const { return ___table_4; }
	inline SlotU5BU5D_t2994659099** get_address_of_table_4() { return &___table_4; }
	inline void set_table_4(SlotU5BU5D_t2994659099* value)
	{
		___table_4 = value;
		Il2CppCodeGenWriteBarrier((&___table_4), value);
	}

	inline static int32_t get_offset_of_hashes_5() { return static_cast<int32_t>(offsetof(Hashtable_t1853889766, ___hashes_5)); }
	inline Int32U5BU5D_t385246372* get_hashes_5() const { return ___hashes_5; }
	inline Int32U5BU5D_t385246372** get_address_of_hashes_5() { return &___hashes_5; }
	inline void set_hashes_5(Int32U5BU5D_t385246372* value)
	{
		___hashes_5 = value;
		Il2CppCodeGenWriteBarrier((&___hashes_5), value);
	}

	inline static int32_t get_offset_of_threshold_6() { return static_cast<int32_t>(offsetof(Hashtable_t1853889766, ___threshold_6)); }
	inline int32_t get_threshold_6() const { return ___threshold_6; }
	inline int32_t* get_address_of_threshold_6() { return &___threshold_6; }
	inline void set_threshold_6(int32_t value)
	{
		___threshold_6 = value;
	}

	inline static int32_t get_offset_of_hashKeys_7() { return static_cast<int32_t>(offsetof(Hashtable_t1853889766, ___hashKeys_7)); }
	inline HashKeys_t1568156503 * get_hashKeys_7() const { return ___hashKeys_7; }
	inline HashKeys_t1568156503 ** get_address_of_hashKeys_7() { return &___hashKeys_7; }
	inline void set_hashKeys_7(HashKeys_t1568156503 * value)
	{
		___hashKeys_7 = value;
		Il2CppCodeGenWriteBarrier((&___hashKeys_7), value);
	}

	inline static int32_t get_offset_of_hashValues_8() { return static_cast<int32_t>(offsetof(Hashtable_t1853889766, ___hashValues_8)); }
	inline HashValues_t618387445 * get_hashValues_8() const { return ___hashValues_8; }
	inline HashValues_t618387445 ** get_address_of_hashValues_8() { return &___hashValues_8; }
	inline void set_hashValues_8(HashValues_t618387445 * value)
	{
		___hashValues_8 = value;
		Il2CppCodeGenWriteBarrier((&___hashValues_8), value);
	}

	inline static int32_t get_offset_of_hcpRef_9() { return static_cast<int32_t>(offsetof(Hashtable_t1853889766, ___hcpRef_9)); }
	inline RuntimeObject* get_hcpRef_9() const { return ___hcpRef_9; }
	inline RuntimeObject** get_address_of_hcpRef_9() { return &___hcpRef_9; }
	inline void set_hcpRef_9(RuntimeObject* value)
	{
		___hcpRef_9 = value;
		Il2CppCodeGenWriteBarrier((&___hcpRef_9), value);
	}

	inline static int32_t get_offset_of_comparerRef_10() { return static_cast<int32_t>(offsetof(Hashtable_t1853889766, ___comparerRef_10)); }
	inline RuntimeObject* get_comparerRef_10() const { return ___comparerRef_10; }
	inline RuntimeObject** get_address_of_comparerRef_10() { return &___comparerRef_10; }
	inline void set_comparerRef_10(RuntimeObject* value)
	{
		___comparerRef_10 = value;
		Il2CppCodeGenWriteBarrier((&___comparerRef_10), value);
	}

	inline static int32_t get_offset_of_serializationInfo_11() { return static_cast<int32_t>(offsetof(Hashtable_t1853889766, ___serializationInfo_11)); }
	inline SerializationInfo_t950877179 * get_serializationInfo_11() const { return ___serializationInfo_11; }
	inline SerializationInfo_t950877179 ** get_address_of_serializationInfo_11() { return &___serializationInfo_11; }
	inline void set_serializationInfo_11(SerializationInfo_t950877179 * value)
	{
		___serializationInfo_11 = value;
		Il2CppCodeGenWriteBarrier((&___serializationInfo_11), value);
	}

	inline static int32_t get_offset_of_equalityComparer_12() { return static_cast<int32_t>(offsetof(Hashtable_t1853889766, ___equalityComparer_12)); }
	inline RuntimeObject* get_equalityComparer_12() const { return ___equalityComparer_12; }
	inline RuntimeObject** get_address_of_equalityComparer_12() { return &___equalityComparer_12; }
	inline void set_equalityComparer_12(RuntimeObject* value)
	{
		___equalityComparer_12 = value;
		Il2CppCodeGenWriteBarrier((&___equalityComparer_12), value);
	}
};

struct Hashtable_t1853889766_StaticFields
{
public:
	// System.Int32[] System.Collections.Hashtable::primeTbl
	Int32U5BU5D_t385246372* ___primeTbl_13;

public:
	inline static int32_t get_offset_of_primeTbl_13() { return static_cast<int32_t>(offsetof(Hashtable_t1853889766_StaticFields, ___primeTbl_13)); }
	inline Int32U5BU5D_t385246372* get_primeTbl_13() const { return ___primeTbl_13; }
	inline Int32U5BU5D_t385246372** get_address_of_primeTbl_13() { return &___primeTbl_13; }
	inline void set_primeTbl_13(Int32U5BU5D_t385246372* value)
	{
		___primeTbl_13 = value;
		Il2CppCodeGenWriteBarrier((&___primeTbl_13), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // HASHTABLE_T1853889766_H
#ifndef STRINGBUILDER_T_H
#define STRINGBUILDER_T_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Text.StringBuilder
struct  StringBuilder_t  : public RuntimeObject
{
public:
	// System.Int32 System.Text.StringBuilder::_length
	int32_t ____length_1;
	// System.String System.Text.StringBuilder::_str
	String_t* ____str_2;
	// System.String System.Text.StringBuilder::_cached_str
	String_t* ____cached_str_3;
	// System.Int32 System.Text.StringBuilder::_maxCapacity
	int32_t ____maxCapacity_4;

public:
	inline static int32_t get_offset_of__length_1() { return static_cast<int32_t>(offsetof(StringBuilder_t, ____length_1)); }
	inline int32_t get__length_1() const { return ____length_1; }
	inline int32_t* get_address_of__length_1() { return &____length_1; }
	inline void set__length_1(int32_t value)
	{
		____length_1 = value;
	}

	inline static int32_t get_offset_of__str_2() { return static_cast<int32_t>(offsetof(StringBuilder_t, ____str_2)); }
	inline String_t* get__str_2() const { return ____str_2; }
	inline String_t** get_address_of__str_2() { return &____str_2; }
	inline void set__str_2(String_t* value)
	{
		____str_2 = value;
		Il2CppCodeGenWriteBarrier((&____str_2), value);
	}

	inline static int32_t get_offset_of__cached_str_3() { return static_cast<int32_t>(offsetof(StringBuilder_t, ____cached_str_3)); }
	inline String_t* get__cached_str_3() const { return ____cached_str_3; }
	inline String_t** get_address_of__cached_str_3() { return &____cached_str_3; }
	inline void set__cached_str_3(String_t* value)
	{
		____cached_str_3 = value;
		Il2CppCodeGenWriteBarrier((&____cached_str_3), value);
	}

	inline static int32_t get_offset_of__maxCapacity_4() { return static_cast<int32_t>(offsetof(StringBuilder_t, ____maxCapacity_4)); }
	inline int32_t get__maxCapacity_4() const { return ____maxCapacity_4; }
	inline int32_t* get_address_of__maxCapacity_4() { return &____maxCapacity_4; }
	inline void set__maxCapacity_4(int32_t value)
	{
		____maxCapacity_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // STRINGBUILDER_T_H
#ifndef EXPRESSION_T2722445759_H
#define EXPRESSION_T2722445759_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Text.RegularExpressions.Syntax.Expression
struct  Expression_t2722445759  : public RuntimeObject
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // EXPRESSION_T2722445759_H
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
#ifndef LINKREF_T2971865410_H
#define LINKREF_T2971865410_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Text.RegularExpressions.LinkRef
struct  LinkRef_t2971865410  : public RuntimeObject
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LINKREF_T2971865410_H
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
#ifndef REFERENCE_T1799410108_H
#define REFERENCE_T1799410108_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Text.RegularExpressions.Syntax.Reference
struct  Reference_t1799410108  : public Expression_t2722445759
{
public:
	// System.Text.RegularExpressions.Syntax.CapturingGroup System.Text.RegularExpressions.Syntax.Reference::group
	CapturingGroup_t751358689 * ___group_0;
	// System.Boolean System.Text.RegularExpressions.Syntax.Reference::ignore
	bool ___ignore_1;

public:
	inline static int32_t get_offset_of_group_0() { return static_cast<int32_t>(offsetof(Reference_t1799410108, ___group_0)); }
	inline CapturingGroup_t751358689 * get_group_0() const { return ___group_0; }
	inline CapturingGroup_t751358689 ** get_address_of_group_0() { return &___group_0; }
	inline void set_group_0(CapturingGroup_t751358689 * value)
	{
		___group_0 = value;
		Il2CppCodeGenWriteBarrier((&___group_0), value);
	}

	inline static int32_t get_offset_of_ignore_1() { return static_cast<int32_t>(offsetof(Reference_t1799410108, ___ignore_1)); }
	inline bool get_ignore_1() const { return ___ignore_1; }
	inline bool* get_address_of_ignore_1() { return &___ignore_1; }
	inline void set_ignore_1(bool value)
	{
		___ignore_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // REFERENCE_T1799410108_H
#ifndef BYTE_T1134296376_H
#define BYTE_T1134296376_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Byte
struct  Byte_t1134296376 
{
public:
	// System.Byte System.Byte::m_value
	uint8_t ___m_value_2;

public:
	inline static int32_t get_offset_of_m_value_2() { return static_cast<int32_t>(offsetof(Byte_t1134296376, ___m_value_2)); }
	inline uint8_t get_m_value_2() const { return ___m_value_2; }
	inline uint8_t* get_address_of_m_value_2() { return &___m_value_2; }
	inline void set_m_value_2(uint8_t value)
	{
		___m_value_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // BYTE_T1134296376_H
#ifndef DEFAULTURIPARSER_T95882050_H
#define DEFAULTURIPARSER_T95882050_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.DefaultUriParser
struct  DefaultUriParser_t95882050  : public UriParser_t3890150400
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // DEFAULTURIPARSER_T95882050_H
#ifndef MEMORYSTREAM_T94973147_H
#define MEMORYSTREAM_T94973147_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.IO.MemoryStream
struct  MemoryStream_t94973147  : public Stream_t1273022909
{
public:
	// System.Boolean System.IO.MemoryStream::canWrite
	bool ___canWrite_1;
	// System.Boolean System.IO.MemoryStream::allowGetBuffer
	bool ___allowGetBuffer_2;
	// System.Int32 System.IO.MemoryStream::capacity
	int32_t ___capacity_3;
	// System.Int32 System.IO.MemoryStream::length
	int32_t ___length_4;
	// System.Byte[] System.IO.MemoryStream::internalBuffer
	ByteU5BU5D_t4116647657* ___internalBuffer_5;
	// System.Int32 System.IO.MemoryStream::initialIndex
	int32_t ___initialIndex_6;
	// System.Boolean System.IO.MemoryStream::expandable
	bool ___expandable_7;
	// System.Boolean System.IO.MemoryStream::streamClosed
	bool ___streamClosed_8;
	// System.Int32 System.IO.MemoryStream::position
	int32_t ___position_9;
	// System.Int32 System.IO.MemoryStream::dirty_bytes
	int32_t ___dirty_bytes_10;

public:
	inline static int32_t get_offset_of_canWrite_1() { return static_cast<int32_t>(offsetof(MemoryStream_t94973147, ___canWrite_1)); }
	inline bool get_canWrite_1() const { return ___canWrite_1; }
	inline bool* get_address_of_canWrite_1() { return &___canWrite_1; }
	inline void set_canWrite_1(bool value)
	{
		___canWrite_1 = value;
	}

	inline static int32_t get_offset_of_allowGetBuffer_2() { return static_cast<int32_t>(offsetof(MemoryStream_t94973147, ___allowGetBuffer_2)); }
	inline bool get_allowGetBuffer_2() const { return ___allowGetBuffer_2; }
	inline bool* get_address_of_allowGetBuffer_2() { return &___allowGetBuffer_2; }
	inline void set_allowGetBuffer_2(bool value)
	{
		___allowGetBuffer_2 = value;
	}

	inline static int32_t get_offset_of_capacity_3() { return static_cast<int32_t>(offsetof(MemoryStream_t94973147, ___capacity_3)); }
	inline int32_t get_capacity_3() const { return ___capacity_3; }
	inline int32_t* get_address_of_capacity_3() { return &___capacity_3; }
	inline void set_capacity_3(int32_t value)
	{
		___capacity_3 = value;
	}

	inline static int32_t get_offset_of_length_4() { return static_cast<int32_t>(offsetof(MemoryStream_t94973147, ___length_4)); }
	inline int32_t get_length_4() const { return ___length_4; }
	inline int32_t* get_address_of_length_4() { return &___length_4; }
	inline void set_length_4(int32_t value)
	{
		___length_4 = value;
	}

	inline static int32_t get_offset_of_internalBuffer_5() { return static_cast<int32_t>(offsetof(MemoryStream_t94973147, ___internalBuffer_5)); }
	inline ByteU5BU5D_t4116647657* get_internalBuffer_5() const { return ___internalBuffer_5; }
	inline ByteU5BU5D_t4116647657** get_address_of_internalBuffer_5() { return &___internalBuffer_5; }
	inline void set_internalBuffer_5(ByteU5BU5D_t4116647657* value)
	{
		___internalBuffer_5 = value;
		Il2CppCodeGenWriteBarrier((&___internalBuffer_5), value);
	}

	inline static int32_t get_offset_of_initialIndex_6() { return static_cast<int32_t>(offsetof(MemoryStream_t94973147, ___initialIndex_6)); }
	inline int32_t get_initialIndex_6() const { return ___initialIndex_6; }
	inline int32_t* get_address_of_initialIndex_6() { return &___initialIndex_6; }
	inline void set_initialIndex_6(int32_t value)
	{
		___initialIndex_6 = value;
	}

	inline static int32_t get_offset_of_expandable_7() { return static_cast<int32_t>(offsetof(MemoryStream_t94973147, ___expandable_7)); }
	inline bool get_expandable_7() const { return ___expandable_7; }
	inline bool* get_address_of_expandable_7() { return &___expandable_7; }
	inline void set_expandable_7(bool value)
	{
		___expandable_7 = value;
	}

	inline static int32_t get_offset_of_streamClosed_8() { return static_cast<int32_t>(offsetof(MemoryStream_t94973147, ___streamClosed_8)); }
	inline bool get_streamClosed_8() const { return ___streamClosed_8; }
	inline bool* get_address_of_streamClosed_8() { return &___streamClosed_8; }
	inline void set_streamClosed_8(bool value)
	{
		___streamClosed_8 = value;
	}

	inline static int32_t get_offset_of_position_9() { return static_cast<int32_t>(offsetof(MemoryStream_t94973147, ___position_9)); }
	inline int32_t get_position_9() const { return ___position_9; }
	inline int32_t* get_address_of_position_9() { return &___position_9; }
	inline void set_position_9(int32_t value)
	{
		___position_9 = value;
	}

	inline static int32_t get_offset_of_dirty_bytes_10() { return static_cast<int32_t>(offsetof(MemoryStream_t94973147, ___dirty_bytes_10)); }
	inline int32_t get_dirty_bytes_10() const { return ___dirty_bytes_10; }
	inline int32_t* get_address_of_dirty_bytes_10() { return &___dirty_bytes_10; }
	inline void set_dirty_bytes_10(int32_t value)
	{
		___dirty_bytes_10 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // MEMORYSTREAM_T94973147_H
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
#ifndef SYSTEMEXCEPTION_T176217640_H
#define SYSTEMEXCEPTION_T176217640_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.SystemException
struct  SystemException_t176217640  : public Exception_t
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SYSTEMEXCEPTION_T176217640_H
#ifndef URITYPECONVERTER_T3695916615_H
#define URITYPECONVERTER_T3695916615_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.UriTypeConverter
struct  UriTypeConverter_t3695916615  : public TypeConverter_t2249118273
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // URITYPECONVERTER_T3695916615_H
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
#ifndef GENERICURIPARSER_T1141496137_H
#define GENERICURIPARSER_T1141496137_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.GenericUriParser
struct  GenericUriParser_t1141496137  : public UriParser_t3890150400
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // GENERICURIPARSER_T1141496137_H
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
#ifndef EXPRESSIONCOLLECTION_T1810289389_H
#define EXPRESSIONCOLLECTION_T1810289389_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Text.RegularExpressions.Syntax.ExpressionCollection
struct  ExpressionCollection_t1810289389  : public CollectionBase_t2727926298
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // EXPRESSIONCOLLECTION_T1810289389_H
#ifndef CHAR_T3634460470_H
#define CHAR_T3634460470_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Char
struct  Char_t3634460470 
{
public:
	// System.Char System.Char::m_value
	Il2CppChar ___m_value_2;

public:
	inline static int32_t get_offset_of_m_value_2() { return static_cast<int32_t>(offsetof(Char_t3634460470, ___m_value_2)); }
	inline Il2CppChar get_m_value_2() const { return ___m_value_2; }
	inline Il2CppChar* get_address_of_m_value_2() { return &___m_value_2; }
	inline void set_m_value_2(Il2CppChar value)
	{
		___m_value_2 = value;
	}
};

struct Char_t3634460470_StaticFields
{
public:
	// System.Byte* System.Char::category_data
	uint8_t* ___category_data_3;
	// System.Byte* System.Char::numeric_data
	uint8_t* ___numeric_data_4;
	// System.Double* System.Char::numeric_data_values
	double* ___numeric_data_values_5;
	// System.UInt16* System.Char::to_lower_data_low
	uint16_t* ___to_lower_data_low_6;
	// System.UInt16* System.Char::to_lower_data_high
	uint16_t* ___to_lower_data_high_7;
	// System.UInt16* System.Char::to_upper_data_low
	uint16_t* ___to_upper_data_low_8;
	// System.UInt16* System.Char::to_upper_data_high
	uint16_t* ___to_upper_data_high_9;

public:
	inline static int32_t get_offset_of_category_data_3() { return static_cast<int32_t>(offsetof(Char_t3634460470_StaticFields, ___category_data_3)); }
	inline uint8_t* get_category_data_3() const { return ___category_data_3; }
	inline uint8_t** get_address_of_category_data_3() { return &___category_data_3; }
	inline void set_category_data_3(uint8_t* value)
	{
		___category_data_3 = value;
	}

	inline static int32_t get_offset_of_numeric_data_4() { return static_cast<int32_t>(offsetof(Char_t3634460470_StaticFields, ___numeric_data_4)); }
	inline uint8_t* get_numeric_data_4() const { return ___numeric_data_4; }
	inline uint8_t** get_address_of_numeric_data_4() { return &___numeric_data_4; }
	inline void set_numeric_data_4(uint8_t* value)
	{
		___numeric_data_4 = value;
	}

	inline static int32_t get_offset_of_numeric_data_values_5() { return static_cast<int32_t>(offsetof(Char_t3634460470_StaticFields, ___numeric_data_values_5)); }
	inline double* get_numeric_data_values_5() const { return ___numeric_data_values_5; }
	inline double** get_address_of_numeric_data_values_5() { return &___numeric_data_values_5; }
	inline void set_numeric_data_values_5(double* value)
	{
		___numeric_data_values_5 = value;
	}

	inline static int32_t get_offset_of_to_lower_data_low_6() { return static_cast<int32_t>(offsetof(Char_t3634460470_StaticFields, ___to_lower_data_low_6)); }
	inline uint16_t* get_to_lower_data_low_6() const { return ___to_lower_data_low_6; }
	inline uint16_t** get_address_of_to_lower_data_low_6() { return &___to_lower_data_low_6; }
	inline void set_to_lower_data_low_6(uint16_t* value)
	{
		___to_lower_data_low_6 = value;
	}

	inline static int32_t get_offset_of_to_lower_data_high_7() { return static_cast<int32_t>(offsetof(Char_t3634460470_StaticFields, ___to_lower_data_high_7)); }
	inline uint16_t* get_to_lower_data_high_7() const { return ___to_lower_data_high_7; }
	inline uint16_t** get_address_of_to_lower_data_high_7() { return &___to_lower_data_high_7; }
	inline void set_to_lower_data_high_7(uint16_t* value)
	{
		___to_lower_data_high_7 = value;
	}

	inline static int32_t get_offset_of_to_upper_data_low_8() { return static_cast<int32_t>(offsetof(Char_t3634460470_StaticFields, ___to_upper_data_low_8)); }
	inline uint16_t* get_to_upper_data_low_8() const { return ___to_upper_data_low_8; }
	inline uint16_t** get_address_of_to_upper_data_low_8() { return &___to_upper_data_low_8; }
	inline void set_to_upper_data_low_8(uint16_t* value)
	{
		___to_upper_data_low_8 = value;
	}

	inline static int32_t get_offset_of_to_upper_data_high_9() { return static_cast<int32_t>(offsetof(Char_t3634460470_StaticFields, ___to_upper_data_high_9)); }
	inline uint16_t* get_to_upper_data_high_9() const { return ___to_upper_data_high_9; }
	inline uint16_t** get_address_of_to_upper_data_high_9() { return &___to_upper_data_high_9; }
	inline void set_to_upper_data_high_9(uint16_t* value)
	{
		___to_upper_data_high_9 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // CHAR_T3634460470_H
#ifndef COMPOSITEEXPRESSION_T1252229802_H
#define COMPOSITEEXPRESSION_T1252229802_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Text.RegularExpressions.Syntax.CompositeExpression
struct  CompositeExpression_t1252229802  : public Expression_t2722445759
{
public:
	// System.Text.RegularExpressions.Syntax.ExpressionCollection System.Text.RegularExpressions.Syntax.CompositeExpression::expressions
	ExpressionCollection_t1810289389 * ___expressions_0;

public:
	inline static int32_t get_offset_of_expressions_0() { return static_cast<int32_t>(offsetof(CompositeExpression_t1252229802, ___expressions_0)); }
	inline ExpressionCollection_t1810289389 * get_expressions_0() const { return ___expressions_0; }
	inline ExpressionCollection_t1810289389 ** get_address_of_expressions_0() { return &___expressions_0; }
	inline void set_expressions_0(ExpressionCollection_t1810289389 * value)
	{
		___expressions_0 = value;
		Il2CppCodeGenWriteBarrier((&___expressions_0), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // COMPOSITEEXPRESSION_T1252229802_H
#ifndef URISCHEME_T722425697_H
#define URISCHEME_T722425697_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Uri/UriScheme
struct  UriScheme_t722425697 
{
public:
	// System.String System.Uri/UriScheme::scheme
	String_t* ___scheme_0;
	// System.String System.Uri/UriScheme::delimiter
	String_t* ___delimiter_1;
	// System.Int32 System.Uri/UriScheme::defaultPort
	int32_t ___defaultPort_2;

public:
	inline static int32_t get_offset_of_scheme_0() { return static_cast<int32_t>(offsetof(UriScheme_t722425697, ___scheme_0)); }
	inline String_t* get_scheme_0() const { return ___scheme_0; }
	inline String_t** get_address_of_scheme_0() { return &___scheme_0; }
	inline void set_scheme_0(String_t* value)
	{
		___scheme_0 = value;
		Il2CppCodeGenWriteBarrier((&___scheme_0), value);
	}

	inline static int32_t get_offset_of_delimiter_1() { return static_cast<int32_t>(offsetof(UriScheme_t722425697, ___delimiter_1)); }
	inline String_t* get_delimiter_1() const { return ___delimiter_1; }
	inline String_t** get_address_of_delimiter_1() { return &___delimiter_1; }
	inline void set_delimiter_1(String_t* value)
	{
		___delimiter_1 = value;
		Il2CppCodeGenWriteBarrier((&___delimiter_1), value);
	}

	inline static int32_t get_offset_of_defaultPort_2() { return static_cast<int32_t>(offsetof(UriScheme_t722425697, ___defaultPort_2)); }
	inline int32_t get_defaultPort_2() const { return ___defaultPort_2; }
	inline int32_t* get_address_of_defaultPort_2() { return &___defaultPort_2; }
	inline void set_defaultPort_2(int32_t value)
	{
		___defaultPort_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of System.Uri/UriScheme
struct UriScheme_t722425697_marshaled_pinvoke
{
	char* ___scheme_0;
	char* ___delimiter_1;
	int32_t ___defaultPort_2;
};
// Native definition for COM marshalling of System.Uri/UriScheme
struct UriScheme_t722425697_marshaled_com
{
	Il2CppChar* ___scheme_0;
	Il2CppChar* ___delimiter_1;
	int32_t ___defaultPort_2;
};
#endif // URISCHEME_T722425697_H
#ifndef ADDRESSFAMILY_T2612549059_H
#define ADDRESSFAMILY_T2612549059_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Net.Sockets.AddressFamily
struct  AddressFamily_t2612549059 
{
public:
	// System.Int32 System.Net.Sockets.AddressFamily::value__
	int32_t ___value___1;

public:
	inline static int32_t get_offset_of_value___1() { return static_cast<int32_t>(offsetof(AddressFamily_t2612549059, ___value___1)); }
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
#endif // ADDRESSFAMILY_T2612549059_H
#ifndef ARGUMENTEXCEPTION_T132251570_H
#define ARGUMENTEXCEPTION_T132251570_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.ArgumentException
struct  ArgumentException_t132251570  : public SystemException_t176217640
{
public:
	// System.String System.ArgumentException::param_name
	String_t* ___param_name_12;

public:
	inline static int32_t get_offset_of_param_name_12() { return static_cast<int32_t>(offsetof(ArgumentException_t132251570, ___param_name_12)); }
	inline String_t* get_param_name_12() const { return ___param_name_12; }
	inline String_t** get_address_of_param_name_12() { return &___param_name_12; }
	inline void set_param_name_12(String_t* value)
	{
		___param_name_12 = value;
		Il2CppCodeGenWriteBarrier((&___param_name_12), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ARGUMENTEXCEPTION_T132251570_H
#ifndef REPETITION_T2393242404_H
#define REPETITION_T2393242404_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Text.RegularExpressions.Syntax.Repetition
struct  Repetition_t2393242404  : public CompositeExpression_t1252229802
{
public:
	// System.Int32 System.Text.RegularExpressions.Syntax.Repetition::min
	int32_t ___min_1;
	// System.Int32 System.Text.RegularExpressions.Syntax.Repetition::max
	int32_t ___max_2;
	// System.Boolean System.Text.RegularExpressions.Syntax.Repetition::lazy
	bool ___lazy_3;

public:
	inline static int32_t get_offset_of_min_1() { return static_cast<int32_t>(offsetof(Repetition_t2393242404, ___min_1)); }
	inline int32_t get_min_1() const { return ___min_1; }
	inline int32_t* get_address_of_min_1() { return &___min_1; }
	inline void set_min_1(int32_t value)
	{
		___min_1 = value;
	}

	inline static int32_t get_offset_of_max_2() { return static_cast<int32_t>(offsetof(Repetition_t2393242404, ___max_2)); }
	inline int32_t get_max_2() const { return ___max_2; }
	inline int32_t* get_address_of_max_2() { return &___max_2; }
	inline void set_max_2(int32_t value)
	{
		___max_2 = value;
	}

	inline static int32_t get_offset_of_lazy_3() { return static_cast<int32_t>(offsetof(Repetition_t2393242404, ___lazy_3)); }
	inline bool get_lazy_3() const { return ___lazy_3; }
	inline bool* get_address_of_lazy_3() { return &___lazy_3; }
	inline void set_lazy_3(bool value)
	{
		___lazy_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // REPETITION_T2393242404_H
#ifndef URIKIND_T3816567336_H
#define URIKIND_T3816567336_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.UriKind
struct  UriKind_t3816567336 
{
public:
	// System.Int32 System.UriKind::value__
	int32_t ___value___1;

public:
	inline static int32_t get_offset_of_value___1() { return static_cast<int32_t>(offsetof(UriKind_t3816567336, ___value___1)); }
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
#endif // URIKIND_T3816567336_H
#ifndef NOTSUPPORTEDEXCEPTION_T1314879016_H
#define NOTSUPPORTEDEXCEPTION_T1314879016_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.NotSupportedException
struct  NotSupportedException_t1314879016  : public SystemException_t176217640
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // NOTSUPPORTEDEXCEPTION_T1314879016_H
#ifndef STREAMINGCONTEXTSTATES_T3580100459_H
#define STREAMINGCONTEXTSTATES_T3580100459_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Runtime.Serialization.StreamingContextStates
struct  StreamingContextStates_t3580100459 
{
public:
	// System.Int32 System.Runtime.Serialization.StreamingContextStates::value__
	int32_t ___value___1;

public:
	inline static int32_t get_offset_of_value___1() { return static_cast<int32_t>(offsetof(StreamingContextStates_t3580100459, ___value___1)); }
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
#endif // STREAMINGCONTEXTSTATES_T3580100459_H
#ifndef RUNTIMETYPEHANDLE_T3027515415_H
#define RUNTIMETYPEHANDLE_T3027515415_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.RuntimeTypeHandle
struct  RuntimeTypeHandle_t3027515415 
{
public:
	// System.IntPtr System.RuntimeTypeHandle::value
	intptr_t ___value_0;

public:
	inline static int32_t get_offset_of_value_0() { return static_cast<int32_t>(offsetof(RuntimeTypeHandle_t3027515415, ___value_0)); }
	inline intptr_t get_value_0() const { return ___value_0; }
	inline intptr_t* get_address_of_value_0() { return &___value_0; }
	inline void set_value_0(intptr_t value)
	{
		___value_0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // RUNTIMETYPEHANDLE_T3027515415_H
#ifndef FORMATEXCEPTION_T154580423_H
#define FORMATEXCEPTION_T154580423_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.FormatException
struct  FormatException_t154580423  : public SystemException_t176217640
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // FORMATEXCEPTION_T154580423_H
#ifndef BINDINGFLAGS_T2721792723_H
#define BINDINGFLAGS_T2721792723_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Reflection.BindingFlags
struct  BindingFlags_t2721792723 
{
public:
	// System.Int32 System.Reflection.BindingFlags::value__
	int32_t ___value___1;

public:
	inline static int32_t get_offset_of_value___1() { return static_cast<int32_t>(offsetof(BindingFlags_t2721792723, ___value___1)); }
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
#endif // BINDINGFLAGS_T2721792723_H
#ifndef NUMBERSTYLES_T617258130_H
#define NUMBERSTYLES_T617258130_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Globalization.NumberStyles
struct  NumberStyles_t617258130 
{
public:
	// System.Int32 System.Globalization.NumberStyles::value__
	int32_t ___value___1;

public:
	inline static int32_t get_offset_of_value___1() { return static_cast<int32_t>(offsetof(NumberStyles_t617258130, ___value___1)); }
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
#endif // NUMBERSTYLES_T617258130_H
#ifndef INVALIDOPERATIONEXCEPTION_T56020091_H
#define INVALIDOPERATIONEXCEPTION_T56020091_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.InvalidOperationException
struct  InvalidOperationException_t56020091  : public SystemException_t176217640
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // INVALIDOPERATIONEXCEPTION_T56020091_H
#ifndef GROUP_T1458537008_H
#define GROUP_T1458537008_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Text.RegularExpressions.Syntax.Group
struct  Group_t1458537008  : public CompositeExpression_t1252229802
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // GROUP_T1458537008_H
#ifndef URIHOSTNAMETYPE_T881866241_H
#define URIHOSTNAMETYPE_T881866241_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.UriHostNameType
struct  UriHostNameType_t881866241 
{
public:
	// System.Int32 System.UriHostNameType::value__
	int32_t ___value___1;

public:
	inline static int32_t get_offset_of_value___1() { return static_cast<int32_t>(offsetof(UriHostNameType_t881866241, ___value___1)); }
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
#endif // URIHOSTNAMETYPE_T881866241_H
#ifndef POSITION_T2536274344_H
#define POSITION_T2536274344_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Text.RegularExpressions.Position
struct  Position_t2536274344 
{
public:
	// System.UInt16 System.Text.RegularExpressions.Position::value__
	uint16_t ___value___1;

public:
	inline static int32_t get_offset_of_value___1() { return static_cast<int32_t>(offsetof(Position_t2536274344, ___value___1)); }
	inline uint16_t get_value___1() const { return ___value___1; }
	inline uint16_t* get_address_of_value___1() { return &___value___1; }
	inline void set_value___1(uint16_t value)
	{
		___value___1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // POSITION_T2536274344_H
#ifndef REGEXOPTIONS_T92845595_H
#define REGEXOPTIONS_T92845595_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Text.RegularExpressions.RegexOptions
struct  RegexOptions_t92845595 
{
public:
	// System.Int32 System.Text.RegularExpressions.RegexOptions::value__
	int32_t ___value___1;

public:
	inline static int32_t get_offset_of_value___1() { return static_cast<int32_t>(offsetof(RegexOptions_t92845595, ___value___1)); }
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
#endif // REGEXOPTIONS_T92845595_H
#ifndef URIPARTIAL_T1736313903_H
#define URIPARTIAL_T1736313903_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.UriPartial
struct  UriPartial_t1736313903 
{
public:
	// System.Int32 System.UriPartial::value__
	int32_t ___value___1;

public:
	inline static int32_t get_offset_of_value___1() { return static_cast<int32_t>(offsetof(UriPartial_t1736313903, ___value___1)); }
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
#endif // URIPARTIAL_T1736313903_H
#ifndef ANCHORINFO_T3387011151_H
#define ANCHORINFO_T3387011151_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Text.RegularExpressions.Syntax.AnchorInfo
struct  AnchorInfo_t3387011151  : public RuntimeObject
{
public:
	// System.Text.RegularExpressions.Syntax.Expression System.Text.RegularExpressions.Syntax.AnchorInfo::expr
	Expression_t2722445759 * ___expr_0;
	// System.Text.RegularExpressions.Position System.Text.RegularExpressions.Syntax.AnchorInfo::pos
	uint16_t ___pos_1;
	// System.Int32 System.Text.RegularExpressions.Syntax.AnchorInfo::offset
	int32_t ___offset_2;
	// System.String System.Text.RegularExpressions.Syntax.AnchorInfo::str
	String_t* ___str_3;
	// System.Int32 System.Text.RegularExpressions.Syntax.AnchorInfo::width
	int32_t ___width_4;
	// System.Boolean System.Text.RegularExpressions.Syntax.AnchorInfo::ignore
	bool ___ignore_5;

public:
	inline static int32_t get_offset_of_expr_0() { return static_cast<int32_t>(offsetof(AnchorInfo_t3387011151, ___expr_0)); }
	inline Expression_t2722445759 * get_expr_0() const { return ___expr_0; }
	inline Expression_t2722445759 ** get_address_of_expr_0() { return &___expr_0; }
	inline void set_expr_0(Expression_t2722445759 * value)
	{
		___expr_0 = value;
		Il2CppCodeGenWriteBarrier((&___expr_0), value);
	}

	inline static int32_t get_offset_of_pos_1() { return static_cast<int32_t>(offsetof(AnchorInfo_t3387011151, ___pos_1)); }
	inline uint16_t get_pos_1() const { return ___pos_1; }
	inline uint16_t* get_address_of_pos_1() { return &___pos_1; }
	inline void set_pos_1(uint16_t value)
	{
		___pos_1 = value;
	}

	inline static int32_t get_offset_of_offset_2() { return static_cast<int32_t>(offsetof(AnchorInfo_t3387011151, ___offset_2)); }
	inline int32_t get_offset_2() const { return ___offset_2; }
	inline int32_t* get_address_of_offset_2() { return &___offset_2; }
	inline void set_offset_2(int32_t value)
	{
		___offset_2 = value;
	}

	inline static int32_t get_offset_of_str_3() { return static_cast<int32_t>(offsetof(AnchorInfo_t3387011151, ___str_3)); }
	inline String_t* get_str_3() const { return ___str_3; }
	inline String_t** get_address_of_str_3() { return &___str_3; }
	inline void set_str_3(String_t* value)
	{
		___str_3 = value;
		Il2CppCodeGenWriteBarrier((&___str_3), value);
	}

	inline static int32_t get_offset_of_width_4() { return static_cast<int32_t>(offsetof(AnchorInfo_t3387011151, ___width_4)); }
	inline int32_t get_width_4() const { return ___width_4; }
	inline int32_t* get_address_of_width_4() { return &___width_4; }
	inline void set_width_4(int32_t value)
	{
		___width_4 = value;
	}

	inline static int32_t get_offset_of_ignore_5() { return static_cast<int32_t>(offsetof(AnchorInfo_t3387011151, ___ignore_5)); }
	inline bool get_ignore_5() const { return ___ignore_5; }
	inline bool* get_address_of_ignore_5() { return &___ignore_5; }
	inline void set_ignore_5(bool value)
	{
		___ignore_5 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ANCHORINFO_T3387011151_H
#ifndef POSITIONASSERTION_T3339288061_H
#define POSITIONASSERTION_T3339288061_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Text.RegularExpressions.Syntax.PositionAssertion
struct  PositionAssertion_t3339288061  : public Expression_t2722445759
{
public:
	// System.Text.RegularExpressions.Position System.Text.RegularExpressions.Syntax.PositionAssertion::pos
	uint16_t ___pos_0;

public:
	inline static int32_t get_offset_of_pos_0() { return static_cast<int32_t>(offsetof(PositionAssertion_t3339288061, ___pos_0)); }
	inline uint16_t get_pos_0() const { return ___pos_0; }
	inline uint16_t* get_address_of_pos_0() { return &___pos_0; }
	inline void set_pos_0(uint16_t value)
	{
		___pos_0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // POSITIONASSERTION_T3339288061_H
#ifndef IPADDRESS_T241777590_H
#define IPADDRESS_T241777590_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Net.IPAddress
struct  IPAddress_t241777590  : public RuntimeObject
{
public:
	// System.Int64 System.Net.IPAddress::m_Address
	int64_t ___m_Address_0;
	// System.Net.Sockets.AddressFamily System.Net.IPAddress::m_Family
	int32_t ___m_Family_1;
	// System.UInt16[] System.Net.IPAddress::m_Numbers
	UInt16U5BU5D_t3326319531* ___m_Numbers_2;
	// System.Int64 System.Net.IPAddress::m_ScopeId
	int64_t ___m_ScopeId_3;
	// System.Int32 System.Net.IPAddress::m_HashCode
	int32_t ___m_HashCode_11;

public:
	inline static int32_t get_offset_of_m_Address_0() { return static_cast<int32_t>(offsetof(IPAddress_t241777590, ___m_Address_0)); }
	inline int64_t get_m_Address_0() const { return ___m_Address_0; }
	inline int64_t* get_address_of_m_Address_0() { return &___m_Address_0; }
	inline void set_m_Address_0(int64_t value)
	{
		___m_Address_0 = value;
	}

	inline static int32_t get_offset_of_m_Family_1() { return static_cast<int32_t>(offsetof(IPAddress_t241777590, ___m_Family_1)); }
	inline int32_t get_m_Family_1() const { return ___m_Family_1; }
	inline int32_t* get_address_of_m_Family_1() { return &___m_Family_1; }
	inline void set_m_Family_1(int32_t value)
	{
		___m_Family_1 = value;
	}

	inline static int32_t get_offset_of_m_Numbers_2() { return static_cast<int32_t>(offsetof(IPAddress_t241777590, ___m_Numbers_2)); }
	inline UInt16U5BU5D_t3326319531* get_m_Numbers_2() const { return ___m_Numbers_2; }
	inline UInt16U5BU5D_t3326319531** get_address_of_m_Numbers_2() { return &___m_Numbers_2; }
	inline void set_m_Numbers_2(UInt16U5BU5D_t3326319531* value)
	{
		___m_Numbers_2 = value;
		Il2CppCodeGenWriteBarrier((&___m_Numbers_2), value);
	}

	inline static int32_t get_offset_of_m_ScopeId_3() { return static_cast<int32_t>(offsetof(IPAddress_t241777590, ___m_ScopeId_3)); }
	inline int64_t get_m_ScopeId_3() const { return ___m_ScopeId_3; }
	inline int64_t* get_address_of_m_ScopeId_3() { return &___m_ScopeId_3; }
	inline void set_m_ScopeId_3(int64_t value)
	{
		___m_ScopeId_3 = value;
	}

	inline static int32_t get_offset_of_m_HashCode_11() { return static_cast<int32_t>(offsetof(IPAddress_t241777590, ___m_HashCode_11)); }
	inline int32_t get_m_HashCode_11() const { return ___m_HashCode_11; }
	inline int32_t* get_address_of_m_HashCode_11() { return &___m_HashCode_11; }
	inline void set_m_HashCode_11(int32_t value)
	{
		___m_HashCode_11 = value;
	}
};

struct IPAddress_t241777590_StaticFields
{
public:
	// System.Net.IPAddress System.Net.IPAddress::Any
	IPAddress_t241777590 * ___Any_4;
	// System.Net.IPAddress System.Net.IPAddress::Broadcast
	IPAddress_t241777590 * ___Broadcast_5;
	// System.Net.IPAddress System.Net.IPAddress::Loopback
	IPAddress_t241777590 * ___Loopback_6;
	// System.Net.IPAddress System.Net.IPAddress::None
	IPAddress_t241777590 * ___None_7;
	// System.Net.IPAddress System.Net.IPAddress::IPv6Any
	IPAddress_t241777590 * ___IPv6Any_8;
	// System.Net.IPAddress System.Net.IPAddress::IPv6Loopback
	IPAddress_t241777590 * ___IPv6Loopback_9;
	// System.Net.IPAddress System.Net.IPAddress::IPv6None
	IPAddress_t241777590 * ___IPv6None_10;

public:
	inline static int32_t get_offset_of_Any_4() { return static_cast<int32_t>(offsetof(IPAddress_t241777590_StaticFields, ___Any_4)); }
	inline IPAddress_t241777590 * get_Any_4() const { return ___Any_4; }
	inline IPAddress_t241777590 ** get_address_of_Any_4() { return &___Any_4; }
	inline void set_Any_4(IPAddress_t241777590 * value)
	{
		___Any_4 = value;
		Il2CppCodeGenWriteBarrier((&___Any_4), value);
	}

	inline static int32_t get_offset_of_Broadcast_5() { return static_cast<int32_t>(offsetof(IPAddress_t241777590_StaticFields, ___Broadcast_5)); }
	inline IPAddress_t241777590 * get_Broadcast_5() const { return ___Broadcast_5; }
	inline IPAddress_t241777590 ** get_address_of_Broadcast_5() { return &___Broadcast_5; }
	inline void set_Broadcast_5(IPAddress_t241777590 * value)
	{
		___Broadcast_5 = value;
		Il2CppCodeGenWriteBarrier((&___Broadcast_5), value);
	}

	inline static int32_t get_offset_of_Loopback_6() { return static_cast<int32_t>(offsetof(IPAddress_t241777590_StaticFields, ___Loopback_6)); }
	inline IPAddress_t241777590 * get_Loopback_6() const { return ___Loopback_6; }
	inline IPAddress_t241777590 ** get_address_of_Loopback_6() { return &___Loopback_6; }
	inline void set_Loopback_6(IPAddress_t241777590 * value)
	{
		___Loopback_6 = value;
		Il2CppCodeGenWriteBarrier((&___Loopback_6), value);
	}

	inline static int32_t get_offset_of_None_7() { return static_cast<int32_t>(offsetof(IPAddress_t241777590_StaticFields, ___None_7)); }
	inline IPAddress_t241777590 * get_None_7() const { return ___None_7; }
	inline IPAddress_t241777590 ** get_address_of_None_7() { return &___None_7; }
	inline void set_None_7(IPAddress_t241777590 * value)
	{
		___None_7 = value;
		Il2CppCodeGenWriteBarrier((&___None_7), value);
	}

	inline static int32_t get_offset_of_IPv6Any_8() { return static_cast<int32_t>(offsetof(IPAddress_t241777590_StaticFields, ___IPv6Any_8)); }
	inline IPAddress_t241777590 * get_IPv6Any_8() const { return ___IPv6Any_8; }
	inline IPAddress_t241777590 ** get_address_of_IPv6Any_8() { return &___IPv6Any_8; }
	inline void set_IPv6Any_8(IPAddress_t241777590 * value)
	{
		___IPv6Any_8 = value;
		Il2CppCodeGenWriteBarrier((&___IPv6Any_8), value);
	}

	inline static int32_t get_offset_of_IPv6Loopback_9() { return static_cast<int32_t>(offsetof(IPAddress_t241777590_StaticFields, ___IPv6Loopback_9)); }
	inline IPAddress_t241777590 * get_IPv6Loopback_9() const { return ___IPv6Loopback_9; }
	inline IPAddress_t241777590 ** get_address_of_IPv6Loopback_9() { return &___IPv6Loopback_9; }
	inline void set_IPv6Loopback_9(IPAddress_t241777590 * value)
	{
		___IPv6Loopback_9 = value;
		Il2CppCodeGenWriteBarrier((&___IPv6Loopback_9), value);
	}

	inline static int32_t get_offset_of_IPv6None_10() { return static_cast<int32_t>(offsetof(IPAddress_t241777590_StaticFields, ___IPv6None_10)); }
	inline IPAddress_t241777590 * get_IPv6None_10() const { return ___IPv6None_10; }
	inline IPAddress_t241777590 ** get_address_of_IPv6None_10() { return &___IPv6None_10; }
	inline void set_IPv6None_10(IPAddress_t241777590 * value)
	{
		___IPv6None_10 = value;
		Il2CppCodeGenWriteBarrier((&___IPv6None_10), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // IPADDRESS_T241777590_H
#ifndef ARGUMENTOUTOFRANGEEXCEPTION_T777629997_H
#define ARGUMENTOUTOFRANGEEXCEPTION_T777629997_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.ArgumentOutOfRangeException
struct  ArgumentOutOfRangeException_t777629997  : public ArgumentException_t132251570
{
public:
	// System.Object System.ArgumentOutOfRangeException::actual_value
	RuntimeObject * ___actual_value_13;

public:
	inline static int32_t get_offset_of_actual_value_13() { return static_cast<int32_t>(offsetof(ArgumentOutOfRangeException_t777629997, ___actual_value_13)); }
	inline RuntimeObject * get_actual_value_13() const { return ___actual_value_13; }
	inline RuntimeObject ** get_address_of_actual_value_13() { return &___actual_value_13; }
	inline void set_actual_value_13(RuntimeObject * value)
	{
		___actual_value_13 = value;
		Il2CppCodeGenWriteBarrier((&___actual_value_13), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ARGUMENTOUTOFRANGEEXCEPTION_T777629997_H
#ifndef REGULAREXPRESSION_T3834220169_H
#define REGULAREXPRESSION_T3834220169_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Text.RegularExpressions.Syntax.RegularExpression
struct  RegularExpression_t3834220169  : public Group_t1458537008
{
public:
	// System.Int32 System.Text.RegularExpressions.Syntax.RegularExpression::group_count
	int32_t ___group_count_1;

public:
	inline static int32_t get_offset_of_group_count_1() { return static_cast<int32_t>(offsetof(RegularExpression_t3834220169, ___group_count_1)); }
	inline int32_t get_group_count_1() const { return ___group_count_1; }
	inline int32_t* get_address_of_group_count_1() { return &___group_count_1; }
	inline void set_group_count_1(int32_t value)
	{
		___group_count_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // REGULAREXPRESSION_T3834220169_H
#ifndef CAPTURINGGROUP_T751358689_H
#define CAPTURINGGROUP_T751358689_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Text.RegularExpressions.Syntax.CapturingGroup
struct  CapturingGroup_t751358689  : public Group_t1458537008
{
public:
	// System.Int32 System.Text.RegularExpressions.Syntax.CapturingGroup::gid
	int32_t ___gid_1;
	// System.String System.Text.RegularExpressions.Syntax.CapturingGroup::name
	String_t* ___name_2;

public:
	inline static int32_t get_offset_of_gid_1() { return static_cast<int32_t>(offsetof(CapturingGroup_t751358689, ___gid_1)); }
	inline int32_t get_gid_1() const { return ___gid_1; }
	inline int32_t* get_address_of_gid_1() { return &___gid_1; }
	inline void set_gid_1(int32_t value)
	{
		___gid_1 = value;
	}

	inline static int32_t get_offset_of_name_2() { return static_cast<int32_t>(offsetof(CapturingGroup_t751358689, ___name_2)); }
	inline String_t* get_name_2() const { return ___name_2; }
	inline String_t** get_address_of_name_2() { return &___name_2; }
	inline void set_name_2(String_t* value)
	{
		___name_2 = value;
		Il2CppCodeGenWriteBarrier((&___name_2), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // CAPTURINGGROUP_T751358689_H
#ifndef ARGUMENTNULLEXCEPTION_T1615371798_H
#define ARGUMENTNULLEXCEPTION_T1615371798_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.ArgumentNullException
struct  ArgumentNullException_t1615371798  : public ArgumentException_t132251570
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ARGUMENTNULLEXCEPTION_T1615371798_H
#ifndef TYPE_T_H
#define TYPE_T_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Type
struct  Type_t  : public MemberInfo_t
{
public:
	// System.RuntimeTypeHandle System.Type::_impl
	RuntimeTypeHandle_t3027515415  ____impl_1;

public:
	inline static int32_t get_offset_of__impl_1() { return static_cast<int32_t>(offsetof(Type_t, ____impl_1)); }
	inline RuntimeTypeHandle_t3027515415  get__impl_1() const { return ____impl_1; }
	inline RuntimeTypeHandle_t3027515415 * get_address_of__impl_1() { return &____impl_1; }
	inline void set__impl_1(RuntimeTypeHandle_t3027515415  value)
	{
		____impl_1 = value;
	}
};

struct Type_t_StaticFields
{
public:
	// System.Char System.Type::Delimiter
	Il2CppChar ___Delimiter_2;
	// System.Type[] System.Type::EmptyTypes
	TypeU5BU5D_t3940880105* ___EmptyTypes_3;
	// System.Reflection.MemberFilter System.Type::FilterAttribute
	MemberFilter_t426314064 * ___FilterAttribute_4;
	// System.Reflection.MemberFilter System.Type::FilterName
	MemberFilter_t426314064 * ___FilterName_5;
	// System.Reflection.MemberFilter System.Type::FilterNameIgnoreCase
	MemberFilter_t426314064 * ___FilterNameIgnoreCase_6;
	// System.Object System.Type::Missing
	RuntimeObject * ___Missing_7;

public:
	inline static int32_t get_offset_of_Delimiter_2() { return static_cast<int32_t>(offsetof(Type_t_StaticFields, ___Delimiter_2)); }
	inline Il2CppChar get_Delimiter_2() const { return ___Delimiter_2; }
	inline Il2CppChar* get_address_of_Delimiter_2() { return &___Delimiter_2; }
	inline void set_Delimiter_2(Il2CppChar value)
	{
		___Delimiter_2 = value;
	}

	inline static int32_t get_offset_of_EmptyTypes_3() { return static_cast<int32_t>(offsetof(Type_t_StaticFields, ___EmptyTypes_3)); }
	inline TypeU5BU5D_t3940880105* get_EmptyTypes_3() const { return ___EmptyTypes_3; }
	inline TypeU5BU5D_t3940880105** get_address_of_EmptyTypes_3() { return &___EmptyTypes_3; }
	inline void set_EmptyTypes_3(TypeU5BU5D_t3940880105* value)
	{
		___EmptyTypes_3 = value;
		Il2CppCodeGenWriteBarrier((&___EmptyTypes_3), value);
	}

	inline static int32_t get_offset_of_FilterAttribute_4() { return static_cast<int32_t>(offsetof(Type_t_StaticFields, ___FilterAttribute_4)); }
	inline MemberFilter_t426314064 * get_FilterAttribute_4() const { return ___FilterAttribute_4; }
	inline MemberFilter_t426314064 ** get_address_of_FilterAttribute_4() { return &___FilterAttribute_4; }
	inline void set_FilterAttribute_4(MemberFilter_t426314064 * value)
	{
		___FilterAttribute_4 = value;
		Il2CppCodeGenWriteBarrier((&___FilterAttribute_4), value);
	}

	inline static int32_t get_offset_of_FilterName_5() { return static_cast<int32_t>(offsetof(Type_t_StaticFields, ___FilterName_5)); }
	inline MemberFilter_t426314064 * get_FilterName_5() const { return ___FilterName_5; }
	inline MemberFilter_t426314064 ** get_address_of_FilterName_5() { return &___FilterName_5; }
	inline void set_FilterName_5(MemberFilter_t426314064 * value)
	{
		___FilterName_5 = value;
		Il2CppCodeGenWriteBarrier((&___FilterName_5), value);
	}

	inline static int32_t get_offset_of_FilterNameIgnoreCase_6() { return static_cast<int32_t>(offsetof(Type_t_StaticFields, ___FilterNameIgnoreCase_6)); }
	inline MemberFilter_t426314064 * get_FilterNameIgnoreCase_6() const { return ___FilterNameIgnoreCase_6; }
	inline MemberFilter_t426314064 ** get_address_of_FilterNameIgnoreCase_6() { return &___FilterNameIgnoreCase_6; }
	inline void set_FilterNameIgnoreCase_6(MemberFilter_t426314064 * value)
	{
		___FilterNameIgnoreCase_6 = value;
		Il2CppCodeGenWriteBarrier((&___FilterNameIgnoreCase_6), value);
	}

	inline static int32_t get_offset_of_Missing_7() { return static_cast<int32_t>(offsetof(Type_t_StaticFields, ___Missing_7)); }
	inline RuntimeObject * get_Missing_7() const { return ___Missing_7; }
	inline RuntimeObject ** get_address_of_Missing_7() { return &___Missing_7; }
	inline void set_Missing_7(RuntimeObject * value)
	{
		___Missing_7 = value;
		Il2CppCodeGenWriteBarrier((&___Missing_7), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TYPE_T_H
#ifndef STREAMINGCONTEXT_T3711869237_H
#define STREAMINGCONTEXT_T3711869237_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Runtime.Serialization.StreamingContext
struct  StreamingContext_t3711869237 
{
public:
	// System.Runtime.Serialization.StreamingContextStates System.Runtime.Serialization.StreamingContext::state
	int32_t ___state_0;
	// System.Object System.Runtime.Serialization.StreamingContext::additional
	RuntimeObject * ___additional_1;

public:
	inline static int32_t get_offset_of_state_0() { return static_cast<int32_t>(offsetof(StreamingContext_t3711869237, ___state_0)); }
	inline int32_t get_state_0() const { return ___state_0; }
	inline int32_t* get_address_of_state_0() { return &___state_0; }
	inline void set_state_0(int32_t value)
	{
		___state_0 = value;
	}

	inline static int32_t get_offset_of_additional_1() { return static_cast<int32_t>(offsetof(StreamingContext_t3711869237, ___additional_1)); }
	inline RuntimeObject * get_additional_1() const { return ___additional_1; }
	inline RuntimeObject ** get_address_of_additional_1() { return &___additional_1; }
	inline void set_additional_1(RuntimeObject * value)
	{
		___additional_1 = value;
		Il2CppCodeGenWriteBarrier((&___additional_1), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of System.Runtime.Serialization.StreamingContext
struct StreamingContext_t3711869237_marshaled_pinvoke
{
	int32_t ___state_0;
	Il2CppIUnknown* ___additional_1;
};
// Native definition for COM marshalling of System.Runtime.Serialization.StreamingContext
struct StreamingContext_t3711869237_marshaled_com
{
	int32_t ___state_0;
	Il2CppIUnknown* ___additional_1;
};
#endif // STREAMINGCONTEXT_T3711869237_H
#ifndef REGEX_T3657309853_H
#define REGEX_T3657309853_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Text.RegularExpressions.Regex
struct  Regex_t3657309853  : public RuntimeObject
{
public:
	// System.Text.RegularExpressions.IMachineFactory System.Text.RegularExpressions.Regex::machineFactory
	RuntimeObject* ___machineFactory_1;
	// System.Collections.IDictionary System.Text.RegularExpressions.Regex::mapping
	RuntimeObject* ___mapping_2;
	// System.Int32 System.Text.RegularExpressions.Regex::group_count
	int32_t ___group_count_3;
	// System.Int32 System.Text.RegularExpressions.Regex::gap
	int32_t ___gap_4;
	// System.Boolean System.Text.RegularExpressions.Regex::refsInitialized
	bool ___refsInitialized_5;
	// System.String[] System.Text.RegularExpressions.Regex::group_names
	StringU5BU5D_t1281789340* ___group_names_6;
	// System.Int32[] System.Text.RegularExpressions.Regex::group_numbers
	Int32U5BU5D_t385246372* ___group_numbers_7;
	// System.String System.Text.RegularExpressions.Regex::pattern
	String_t* ___pattern_8;
	// System.Text.RegularExpressions.RegexOptions System.Text.RegularExpressions.Regex::roptions
	int32_t ___roptions_9;
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> System.Text.RegularExpressions.Regex::capnames
	Dictionary_2_t2736202052 * ___capnames_10;
	// System.Collections.Generic.Dictionary`2<System.Int32,System.Int32> System.Text.RegularExpressions.Regex::caps
	Dictionary_2_t1839659084 * ___caps_11;
	// System.Int32 System.Text.RegularExpressions.Regex::capsize
	int32_t ___capsize_12;
	// System.String[] System.Text.RegularExpressions.Regex::capslist
	StringU5BU5D_t1281789340* ___capslist_13;

public:
	inline static int32_t get_offset_of_machineFactory_1() { return static_cast<int32_t>(offsetof(Regex_t3657309853, ___machineFactory_1)); }
	inline RuntimeObject* get_machineFactory_1() const { return ___machineFactory_1; }
	inline RuntimeObject** get_address_of_machineFactory_1() { return &___machineFactory_1; }
	inline void set_machineFactory_1(RuntimeObject* value)
	{
		___machineFactory_1 = value;
		Il2CppCodeGenWriteBarrier((&___machineFactory_1), value);
	}

	inline static int32_t get_offset_of_mapping_2() { return static_cast<int32_t>(offsetof(Regex_t3657309853, ___mapping_2)); }
	inline RuntimeObject* get_mapping_2() const { return ___mapping_2; }
	inline RuntimeObject** get_address_of_mapping_2() { return &___mapping_2; }
	inline void set_mapping_2(RuntimeObject* value)
	{
		___mapping_2 = value;
		Il2CppCodeGenWriteBarrier((&___mapping_2), value);
	}

	inline static int32_t get_offset_of_group_count_3() { return static_cast<int32_t>(offsetof(Regex_t3657309853, ___group_count_3)); }
	inline int32_t get_group_count_3() const { return ___group_count_3; }
	inline int32_t* get_address_of_group_count_3() { return &___group_count_3; }
	inline void set_group_count_3(int32_t value)
	{
		___group_count_3 = value;
	}

	inline static int32_t get_offset_of_gap_4() { return static_cast<int32_t>(offsetof(Regex_t3657309853, ___gap_4)); }
	inline int32_t get_gap_4() const { return ___gap_4; }
	inline int32_t* get_address_of_gap_4() { return &___gap_4; }
	inline void set_gap_4(int32_t value)
	{
		___gap_4 = value;
	}

	inline static int32_t get_offset_of_refsInitialized_5() { return static_cast<int32_t>(offsetof(Regex_t3657309853, ___refsInitialized_5)); }
	inline bool get_refsInitialized_5() const { return ___refsInitialized_5; }
	inline bool* get_address_of_refsInitialized_5() { return &___refsInitialized_5; }
	inline void set_refsInitialized_5(bool value)
	{
		___refsInitialized_5 = value;
	}

	inline static int32_t get_offset_of_group_names_6() { return static_cast<int32_t>(offsetof(Regex_t3657309853, ___group_names_6)); }
	inline StringU5BU5D_t1281789340* get_group_names_6() const { return ___group_names_6; }
	inline StringU5BU5D_t1281789340** get_address_of_group_names_6() { return &___group_names_6; }
	inline void set_group_names_6(StringU5BU5D_t1281789340* value)
	{
		___group_names_6 = value;
		Il2CppCodeGenWriteBarrier((&___group_names_6), value);
	}

	inline static int32_t get_offset_of_group_numbers_7() { return static_cast<int32_t>(offsetof(Regex_t3657309853, ___group_numbers_7)); }
	inline Int32U5BU5D_t385246372* get_group_numbers_7() const { return ___group_numbers_7; }
	inline Int32U5BU5D_t385246372** get_address_of_group_numbers_7() { return &___group_numbers_7; }
	inline void set_group_numbers_7(Int32U5BU5D_t385246372* value)
	{
		___group_numbers_7 = value;
		Il2CppCodeGenWriteBarrier((&___group_numbers_7), value);
	}

	inline static int32_t get_offset_of_pattern_8() { return static_cast<int32_t>(offsetof(Regex_t3657309853, ___pattern_8)); }
	inline String_t* get_pattern_8() const { return ___pattern_8; }
	inline String_t** get_address_of_pattern_8() { return &___pattern_8; }
	inline void set_pattern_8(String_t* value)
	{
		___pattern_8 = value;
		Il2CppCodeGenWriteBarrier((&___pattern_8), value);
	}

	inline static int32_t get_offset_of_roptions_9() { return static_cast<int32_t>(offsetof(Regex_t3657309853, ___roptions_9)); }
	inline int32_t get_roptions_9() const { return ___roptions_9; }
	inline int32_t* get_address_of_roptions_9() { return &___roptions_9; }
	inline void set_roptions_9(int32_t value)
	{
		___roptions_9 = value;
	}

	inline static int32_t get_offset_of_capnames_10() { return static_cast<int32_t>(offsetof(Regex_t3657309853, ___capnames_10)); }
	inline Dictionary_2_t2736202052 * get_capnames_10() const { return ___capnames_10; }
	inline Dictionary_2_t2736202052 ** get_address_of_capnames_10() { return &___capnames_10; }
	inline void set_capnames_10(Dictionary_2_t2736202052 * value)
	{
		___capnames_10 = value;
		Il2CppCodeGenWriteBarrier((&___capnames_10), value);
	}

	inline static int32_t get_offset_of_caps_11() { return static_cast<int32_t>(offsetof(Regex_t3657309853, ___caps_11)); }
	inline Dictionary_2_t1839659084 * get_caps_11() const { return ___caps_11; }
	inline Dictionary_2_t1839659084 ** get_address_of_caps_11() { return &___caps_11; }
	inline void set_caps_11(Dictionary_2_t1839659084 * value)
	{
		___caps_11 = value;
		Il2CppCodeGenWriteBarrier((&___caps_11), value);
	}

	inline static int32_t get_offset_of_capsize_12() { return static_cast<int32_t>(offsetof(Regex_t3657309853, ___capsize_12)); }
	inline int32_t get_capsize_12() const { return ___capsize_12; }
	inline int32_t* get_address_of_capsize_12() { return &___capsize_12; }
	inline void set_capsize_12(int32_t value)
	{
		___capsize_12 = value;
	}

	inline static int32_t get_offset_of_capslist_13() { return static_cast<int32_t>(offsetof(Regex_t3657309853, ___capslist_13)); }
	inline StringU5BU5D_t1281789340* get_capslist_13() const { return ___capslist_13; }
	inline StringU5BU5D_t1281789340** get_address_of_capslist_13() { return &___capslist_13; }
	inline void set_capslist_13(StringU5BU5D_t1281789340* value)
	{
		___capslist_13 = value;
		Il2CppCodeGenWriteBarrier((&___capslist_13), value);
	}
};

struct Regex_t3657309853_StaticFields
{
public:
	// System.Text.RegularExpressions.FactoryCache System.Text.RegularExpressions.Regex::cache
	FactoryCache_t2327118887 * ___cache_0;

public:
	inline static int32_t get_offset_of_cache_0() { return static_cast<int32_t>(offsetof(Regex_t3657309853_StaticFields, ___cache_0)); }
	inline FactoryCache_t2327118887 * get_cache_0() const { return ___cache_0; }
	inline FactoryCache_t2327118887 ** get_address_of_cache_0() { return &___cache_0; }
	inline void set_cache_0(FactoryCache_t2327118887 * value)
	{
		___cache_0 = value;
		Il2CppCodeGenWriteBarrier((&___cache_0), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // REGEX_T3657309853_H
#ifndef URIFORMATEXCEPTION_T953270471_H
#define URIFORMATEXCEPTION_T953270471_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.UriFormatException
struct  UriFormatException_t953270471  : public FormatException_t154580423
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // URIFORMATEXCEPTION_T953270471_H
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
// System.Uri/UriScheme[]
struct UriSchemeU5BU5D_t2082808316  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) UriScheme_t722425697  m_Items[1];

public:
	inline UriScheme_t722425697  GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline UriScheme_t722425697 * GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, UriScheme_t722425697  value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline UriScheme_t722425697  GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline UriScheme_t722425697 * GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, UriScheme_t722425697  value)
	{
		m_Items[index] = value;
	}
};
// System.Char[]
struct CharU5BU5D_t3528271667  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) Il2CppChar m_Items[1];

public:
	inline Il2CppChar GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Il2CppChar* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Il2CppChar value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline Il2CppChar GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Il2CppChar* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Il2CppChar value)
	{
		m_Items[index] = value;
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
// System.Byte[]
struct ByteU5BU5D_t4116647657  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) uint8_t m_Items[1];

public:
	inline uint8_t GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline uint8_t* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, uint8_t value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline uint8_t GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline uint8_t* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, uint8_t value)
	{
		m_Items[index] = value;
	}
};


// System.Void System.Collections.Generic.Dictionary`2<System.Object,System.Int32>::.ctor(System.Int32)
extern "C"  void Dictionary_2__ctor_m182537451_gshared (Dictionary_2_t3384741 * __this, int32_t p0, const RuntimeMethod* method);
// System.Void System.Collections.Generic.Dictionary`2<System.Object,System.Int32>::Add(!0,!1)
extern "C"  void Dictionary_2_Add_m1279427033_gshared (Dictionary_2_t3384741 * __this, RuntimeObject * p0, int32_t p1, const RuntimeMethod* method);
// System.Boolean System.Collections.Generic.Dictionary`2<System.Object,System.Int32>::TryGetValue(!0,!1&)
extern "C"  bool Dictionary_2_TryGetValue_m3959998165_gshared (Dictionary_2_t3384741 * __this, RuntimeObject * p0, int32_t* p1, const RuntimeMethod* method);

// System.Void System.Text.RegularExpressions.Syntax.Expression::.ctor()
extern "C"  void Expression__ctor_m1600460087 (Expression_t2722445759 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Text.RegularExpressions.Syntax.AnchorInfo::.ctor(System.Text.RegularExpressions.Syntax.Expression,System.Int32,System.Int32,System.Text.RegularExpressions.Position)
extern "C"  void AnchorInfo__ctor_m46784903 (AnchorInfo_t3387011151 * __this, Expression_t2722445759 * ___expr0, int32_t ___offset1, int32_t ___width2, uint16_t ___pos3, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Text.RegularExpressions.Syntax.AnchorInfo::.ctor(System.Text.RegularExpressions.Syntax.Expression,System.Int32)
extern "C"  void AnchorInfo__ctor_m3523994803 (AnchorInfo_t3387011151 * __this, Expression_t2722445759 * ___expr0, int32_t ___width1, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Int32 System.Text.RegularExpressions.Syntax.CapturingGroup::get_Index()
extern "C"  int32_t CapturingGroup_get_Index_m3406974370 (CapturingGroup_t751358689 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Text.RegularExpressions.Syntax.Group::.ctor()
extern "C"  void Group__ctor_m2980794822 (Group_t1458537008 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Int32 System.Text.RegularExpressions.Syntax.AnchorInfo::get_Offset()
extern "C"  int32_t AnchorInfo_get_Offset_m2045445765 (AnchorInfo_t3387011151 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean System.Text.RegularExpressions.Syntax.AnchorInfo::get_IsPosition()
extern "C"  bool AnchorInfo_get_IsPosition_m2100552190 (AnchorInfo_t3387011151 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Text.RegularExpressions.Position System.Text.RegularExpressions.Syntax.AnchorInfo::get_Position()
extern "C"  uint16_t AnchorInfo_get_Position_m1133366486 (AnchorInfo_t3387011151 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean System.Text.RegularExpressions.Syntax.AnchorInfo::get_IsSubstring()
extern "C"  bool AnchorInfo_get_IsSubstring_m1536110387 (AnchorInfo_t3387011151 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String System.Text.RegularExpressions.Syntax.AnchorInfo::get_Substring()
extern "C"  String_t* AnchorInfo_get_Substring_m1799385132 (AnchorInfo_t3387011151 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean System.Text.RegularExpressions.Syntax.AnchorInfo::get_IgnoreCase()
extern "C"  bool AnchorInfo_get_IgnoreCase_m4084905689 (AnchorInfo_t3387011151 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Text.RegularExpressions.Syntax.Group::Compile(System.Text.RegularExpressions.ICompiler,System.Boolean)
extern "C"  void Group_Compile_m3355488790 (Group_t1458537008 * __this, RuntimeObject* ___cmp0, bool ___reverse1, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Text.RegularExpressions.Syntax.CompositeExpression::.ctor()
extern "C"  void CompositeExpression__ctor_m2434860303 (CompositeExpression_t1252229802 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Text.RegularExpressions.Syntax.ExpressionCollection System.Text.RegularExpressions.Syntax.CompositeExpression::get_Expressions()
extern "C"  ExpressionCollection_t1810289389 * CompositeExpression_get_Expressions_m2951105322 (CompositeExpression_t1252229802 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Text.RegularExpressions.Syntax.ExpressionCollection::Add(System.Text.RegularExpressions.Syntax.Expression)
extern "C"  void ExpressionCollection_Add_m41125344 (ExpressionCollection_t1810289389 * __this, Expression_t2722445759 * ___e0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Text.RegularExpressions.Syntax.Expression System.Text.RegularExpressions.Syntax.ExpressionCollection::get_Item(System.Int32)
extern "C"  Expression_t2722445759 * ExpressionCollection_get_Item_m3510736379 (ExpressionCollection_t1810289389 * __this, int32_t ___i0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Text.RegularExpressions.Syntax.ExpressionCollection::set_Item(System.Int32,System.Text.RegularExpressions.Syntax.Expression)
extern "C"  void ExpressionCollection_set_Item_m2040804459 (ExpressionCollection_t1810289389 * __this, int32_t ___i0, Expression_t2722445759 * ___value1, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Text.RegularExpressions.Syntax.Expression System.Text.RegularExpressions.Syntax.Repetition::get_Expression()
extern "C"  Expression_t2722445759 * Repetition_get_Expression_m2673886232 (Repetition_t2393242404 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Int32 System.Text.RegularExpressions.Syntax.Expression::GetFixedWidth()
extern "C"  int32_t Expression_GetFixedWidth_m945658 (Expression_t2722445759 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Int32 System.Text.RegularExpressions.Syntax.Repetition::get_Minimum()
extern "C"  int32_t Repetition_get_Minimum_m2550947568 (Repetition_t2393242404 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean System.Text.RegularExpressions.Syntax.AnchorInfo::get_IsComplete()
extern "C"  bool AnchorInfo_get_IsComplete_m4053892818 (AnchorInfo_t3387011151 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Text.StringBuilder::.ctor(System.String)
extern "C"  void StringBuilder__ctor_m2989139009 (StringBuilder_t * __this, String_t* p0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Text.StringBuilder System.Text.StringBuilder::Append(System.String)
extern "C"  StringBuilder_t * StringBuilder_Append_m1965104174 (StringBuilder_t * __this, String_t* p0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String System.Text.StringBuilder::ToString()
extern "C"  String_t* StringBuilder_ToString_m3317489284 (StringBuilder_t * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Text.RegularExpressions.Syntax.AnchorInfo::.ctor(System.Text.RegularExpressions.Syntax.Expression,System.Int32,System.Int32,System.String,System.Boolean)
extern "C"  void AnchorInfo__ctor_m3869855453 (AnchorInfo_t3387011151 * __this, Expression_t2722445759 * ___expr0, int32_t ___offset1, int32_t ___width2, String_t* ___str3, bool ___ignore4, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Uri::.ctor(System.String,System.Boolean)
extern "C"  void Uri__ctor_m3577021606 (Uri_t100236324 * __this, String_t* ___uriString0, bool ___dontEscape1, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String System.Runtime.Serialization.SerializationInfo::GetString(System.String)
extern "C"  String_t* SerializationInfo_GetString_m3155282843 (SerializationInfo_t950877179 * __this, String_t* p0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Object::.ctor()
extern "C"  void Object__ctor_m297566312 (RuntimeObject * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Uri::ParseUri(System.UriKind)
extern "C"  void Uri_ParseUri_m2150795567 (Uri_t100236324 * __this, int32_t ___kind0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean System.Uri::get_IsAbsoluteUri()
extern "C"  bool Uri_get_IsAbsoluteUri_m3666899587 (Uri_t100236324 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.UriFormatException::.ctor(System.String)
extern "C"  void UriFormatException__ctor_m3083316541 (UriFormatException_t953270471 * __this, String_t* ___message0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String Locale::GetText(System.String,System.Object[])
extern "C"  String_t* Locale_GetText_m2640320736 (RuntimeObject * __this /* static, unused */, String_t* ___fmt0, ObjectU5BU5D_t2843939325* ___args1, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.ArgumentException::.ctor(System.String)
extern "C"  void ArgumentException__ctor_m1312628991 (ArgumentException_t132251570 * __this, String_t* p0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String System.Uri::ParseNoExceptions(System.UriKind,System.String)
extern "C"  String_t* Uri_ParseNoExceptions_m4274141693 (Uri_t100236324 * __this, int32_t ___kind0, String_t* ___uriString1, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean System.Uri::op_Equality(System.Uri,System.Uri)
extern "C"  bool Uri_op_Equality_m685520154 (RuntimeObject * __this /* static, unused */, Uri_t100236324 * ___u10, Uri_t100236324 * ___u21, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String System.Uri::get_OriginalString()
extern "C"  String_t* Uri_get_OriginalString_m3715995233 (Uri_t100236324 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Uri::Merge(System.Uri,System.String)
extern "C"  void Uri_Merge_m76373955 (Uri_t100236324 * __this, Uri_t100236324 * ___baseUri0, String_t* ___relativeUri1, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String System.String::Concat(System.String,System.String)
extern "C"  String_t* String_Concat_m3937257545 (RuntimeObject * __this /* static, unused */, String_t* p0, String_t* p1, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Uri/UriScheme::.ctor(System.String,System.String,System.Int32)
extern "C"  void UriScheme__ctor_m1399779782 (UriScheme_t722425697 * __this, String_t* ___s0, String_t* ___d1, int32_t ___p2, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.ArgumentNullException::.ctor(System.String)
extern "C"  void ArgumentNullException__ctor_m1170824041 (ArgumentNullException_t1615371798 * __this, String_t* p0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.ArgumentOutOfRangeException::.ctor(System.String)
extern "C"  void ArgumentOutOfRangeException__ctor_m3628145864 (ArgumentOutOfRangeException_t777629997 * __this, String_t* p0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Int32 System.String::get_Length()
extern "C"  int32_t String_get_Length_m3847582255 (String_t* __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Char System.String::get_Chars(System.Int32)
extern "C"  Il2CppChar String_get_Chars_m2986988803 (String_t* __this, int32_t p0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Int32 System.String::IndexOf(System.Char)
extern "C"  int32_t String_IndexOf_m363431711 (String_t* __this, Il2CppChar p0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Int32 System.String::IndexOfAny(System.Char[])
extern "C"  int32_t String_IndexOfAny_m4159774896 (String_t* __this, CharU5BU5D_t3528271667* p0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String System.Uri::get_Scheme()
extern "C"  String_t* Uri_get_Scheme_m2109479391 (Uri_t100236324 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Int32 System.String::CompareOrdinal(System.String,System.Int32,System.String,System.Int32,System.Int32)
extern "C"  int32_t String_CompareOrdinal_m1012192092 (RuntimeObject * __this /* static, unused */, String_t* p0, int32_t p1, String_t* p2, int32_t p3, int32_t p4, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean System.Uri::IsPredefinedScheme(System.String)
extern "C"  bool Uri_IsPredefinedScheme_m1188665625 (RuntimeObject * __this /* static, unused */, String_t* ___scheme0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String System.String::Substring(System.Int32)
extern "C"  String_t* String_Substring_m2848979100 (String_t* __this, int32_t p0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean System.String::op_Equality(System.String,System.String)
extern "C"  bool String_op_Equality_m920492651 (RuntimeObject * __this /* static, unused */, String_t* p0, String_t* p1, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String System.Uri::EscapeString(System.String)
extern "C"  String_t* Uri_EscapeString_m2061933484 (RuntimeObject * __this /* static, unused */, String_t* ___str0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String System.String::Substring(System.Int32,System.Int32)
extern "C"  String_t* String_Substring_m1610150815 (String_t* __this, int32_t p0, int32_t p1, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String System.String::Concat(System.Object,System.Object,System.Object)
extern "C"  String_t* String_Concat_m1715369213 (RuntimeObject * __this /* static, unused */, RuntimeObject * p0, RuntimeObject * p1, RuntimeObject * p2, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Int32 System.String::LastIndexOf(System.Char)
extern "C"  int32_t String_LastIndexOf_m3451222878 (String_t* __this, Il2CppChar p0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Int32 System.String::IndexOf(System.String,System.Int32)
extern "C"  int32_t String_IndexOf_m3406607758 (String_t* __this, String_t* p0, int32_t p1, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String System.String::Remove(System.Int32,System.Int32)
extern "C"  String_t* String_Remove_m562998446 (String_t* __this, int32_t p0, int32_t p1, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Int32 System.String::LastIndexOf(System.Char,System.Int32)
extern "C"  int32_t String_LastIndexOf_m578673845 (String_t* __this, Il2CppChar p0, int32_t p1, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean System.String::op_Inequality(System.String,System.String)
extern "C"  bool String_op_Inequality_m215368492 (RuntimeObject * __this /* static, unused */, String_t* p0, String_t* p1, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean System.String::EndsWith(System.String)
extern "C"  bool String_EndsWith_m1901926500 (String_t* __this, String_t* p0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Uri::EnsureAbsoluteUri()
extern "C"  void Uri_EnsureAbsoluteUri_m2231483494 (Uri_t100236324 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Collections.Generic.Dictionary`2<System.String,System.Int32>::.ctor(System.Int32)
#define Dictionary_2__ctor_m2392909825(__this, p0, method) ((  void (*) (Dictionary_2_t2736202052 *, int32_t, const RuntimeMethod*))Dictionary_2__ctor_m182537451_gshared)(__this, p0, method)
// System.Void System.Collections.Generic.Dictionary`2<System.String,System.Int32>::Add(!0,!1)
#define Dictionary_2_Add_m282647386(__this, p0, p1, method) ((  void (*) (Dictionary_2_t2736202052 *, String_t*, int32_t, const RuntimeMethod*))Dictionary_2_Add_m1279427033_gshared)(__this, p0, p1, method)
// System.Boolean System.Collections.Generic.Dictionary`2<System.String,System.Int32>::TryGetValue(!0,!1&)
#define Dictionary_2_TryGetValue_m1013208020(__this, p0, p1, method) ((  bool (*) (Dictionary_2_t2736202052 *, String_t*, int32_t*, const RuntimeMethod*))Dictionary_2_TryGetValue_m3959998165_gshared)(__this, p0, p1, method)
// System.Boolean System.String::StartsWith(System.String)
extern "C"  bool String_StartsWith_m1759067526 (String_t* __this, String_t* p0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String System.Uri::GetLeftPart(System.UriPartial)
extern "C"  String_t* Uri_GetLeftPart_m3979111399 (Uri_t100236324 * __this, int32_t ___part0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Int32 System.Uri::GetDefaultPort(System.String)
extern "C"  int32_t Uri_GetDefaultPort_m2547653357 (RuntimeObject * __this /* static, unused */, String_t* ___scheme0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String System.Uri::get_Host()
extern "C"  String_t* Uri_get_Host_m255565830 (Uri_t100236324 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.UriHostNameType System.Uri::CheckHostName(System.String)
extern "C"  int32_t Uri_CheckHostName_m2213216182 (RuntimeObject * __this /* static, unused */, String_t* ___name0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean System.Uri::get_IsFile()
extern "C"  bool Uri_get_IsFile_m2450018824 (Uri_t100236324 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean System.Net.IPAddress::TryParse(System.String,System.Net.IPAddress&)
extern "C"  bool IPAddress_TryParse_m2320149543 (RuntimeObject * __this /* static, unused */, String_t* ___ipString0, IPAddress_t241777590 ** ___address1, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean System.Net.IPv6Address::TryParse(System.String,System.Net.IPv6Address&)
extern "C"  bool IPv6Address_TryParse_m2586816298 (RuntimeObject * __this /* static, unused */, String_t* ___ipString0, IPv6Address_t2709566769 ** ___result1, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean System.Net.IPv6Address::IsLoopback(System.Net.IPv6Address)
extern "C"  bool IPv6Address_IsLoopback_m3712926451 (RuntimeObject * __this /* static, unused */, IPv6Address_t2709566769 * ___addr0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String System.Uri::get_AbsolutePath()
extern "C"  String_t* Uri_get_AbsolutePath_m590948575 (Uri_t100236324 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean System.Uri::get_IsUnc()
extern "C"  bool Uri_get_IsUnc_m2977972311 (Uri_t100236324 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String System.String::Replace(System.Char,System.Char)
extern "C"  String_t* String_Replace_m3726209165 (String_t* __this, Il2CppChar p0, Il2CppChar p1, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String System.Char::ToString()
extern "C"  String_t* Char_ToString_m3588025615 (Il2CppChar* __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String System.Uri::get_Query()
extern "C"  String_t* Uri_get_Query_m2772518875 (Uri_t100236324 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean System.Uri::IsIPv4Address(System.String)
extern "C"  bool Uri_IsIPv4Address_m3535481943 (RuntimeObject * __this /* static, unused */, String_t* ___name0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean System.Uri::IsDomainAddress(System.String)
extern "C"  bool Uri_IsDomainAddress_m2867513594 (RuntimeObject * __this /* static, unused */, String_t* ___name0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String[] System.String::Split(System.Char[])
extern "C"  StringU5BU5D_t1281789340* String_Split_m3646115398 (String_t* __this, CharU5BU5D_t3528271667* p0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean System.UInt32::TryParse(System.String,System.UInt32&)
extern "C"  bool UInt32_TryParse_m2819179361 (RuntimeObject * __this /* static, unused */, String_t* p0, uint32_t* p1, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean System.Char::IsLetterOrDigit(System.Char)
extern "C"  bool Char_IsLetterOrDigit_m3494175785 (RuntimeObject * __this /* static, unused */, Il2CppChar p0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean System.Uri::IsAlpha(System.Char)
extern "C"  bool Uri_IsAlpha_m1282293464 (RuntimeObject * __this /* static, unused */, Il2CppChar ___c0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean System.Char::IsDigit(System.Char)
extern "C"  bool Char_IsDigit_m3646673943 (RuntimeObject * __this /* static, unused */, Il2CppChar p0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Uri::.ctor(System.String)
extern "C"  void Uri__ctor_m800430703 (Uri_t100236324 * __this, String_t* ___uriString0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean System.Uri::InternalEquals(System.Uri)
extern "C"  bool Uri_InternalEquals_m2029068366 (Uri_t100236324 * __this, Uri_t100236324 * ___uri0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Globalization.CultureInfo System.Globalization.CultureInfo::get_InvariantCulture()
extern "C"  CultureInfo_t4157843068 * CultureInfo_get_InvariantCulture_m3532445182 (RuntimeObject * __this /* static, unused */, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String System.String::ToLower(System.Globalization.CultureInfo)
extern "C"  String_t* String_ToLower_m3490221821 (String_t* __this, CultureInfo_t4157843068 * p0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Int32 System.String::GetHashCode()
extern "C"  int32_t String_GetHashCode_m1906374149 (String_t* __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String System.Uri::GetOpaqueWiseSchemeDelimiter()
extern "C"  String_t* Uri_GetOpaqueWiseSchemeDelimiter_m1909471550 (Uri_t100236324 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Text.StringBuilder::.ctor()
extern "C"  void StringBuilder__ctor_m3121283359 (StringBuilder_t * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Text.StringBuilder System.Text.StringBuilder::Append(System.Char)
extern "C"  StringBuilder_t * StringBuilder_Append_m2383614642 (StringBuilder_t * __this, Il2CppChar p0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Text.StringBuilder System.Text.StringBuilder::Append(System.Int32)
extern "C"  StringBuilder_t * StringBuilder_Append_m890240332 (StringBuilder_t * __this, int32_t p0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean System.Uri::CompactEscaped(System.String)
extern "C"  bool Uri_CompactEscaped_m2984961597 (RuntimeObject * __this /* static, unused */, String_t* ___scheme0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String System.Uri::Reduce(System.String,System.Boolean)
extern "C"  String_t* Uri_Reduce_m3122437040 (RuntimeObject * __this /* static, unused */, String_t* ___path0, bool ___compact_escaped1, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean System.Uri::IsHexDigit(System.Char)
extern "C"  bool Uri_IsHexDigit_m3389749670 (RuntimeObject * __this /* static, unused */, Il2CppChar ___digit0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String System.Uri::Unescape(System.String,System.Boolean)
extern "C"  String_t* Uri_Unescape_m910903869 (RuntimeObject * __this /* static, unused */, String_t* ___str0, bool ___excludeSpecial1, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String System.String::Concat(System.Object,System.Object)
extern "C"  String_t* String_Concat_m904156431 (RuntimeObject * __this /* static, unused */, RuntimeObject * p0, RuntimeObject * p1, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Uri::AppendQueryAndFragment(System.String&)
extern "C"  void Uri_AppendQueryAndFragment_m3170766010 (Uri_t100236324 * __this, String_t** ___result0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String System.Uri::EscapeString(System.String,System.Boolean,System.Boolean,System.Boolean)
extern "C"  String_t* Uri_EscapeString_m3864445955 (RuntimeObject * __this /* static, unused */, String_t* ___str0, bool ___escapeReserved1, bool ___escapeHex2, bool ___escapeBrackets3, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean System.Uri::IsHexEncoding(System.String,System.Int32)
extern "C"  bool Uri_IsHexEncoding_m3290929897 (RuntimeObject * __this /* static, unused */, String_t* ___pattern0, int32_t ___index1, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Text.Encoding System.Text.Encoding::get_UTF8()
extern "C"  Encoding_t1523322056 * Encoding_get_UTF8_m1008486739 (RuntimeObject * __this /* static, unused */, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String System.Uri::HexEscape(System.Char)
extern "C"  String_t* Uri_HexEscape_m1589417657 (RuntimeObject * __this /* static, unused */, Il2CppChar ___character0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Uri::Parse(System.UriKind,System.String)
extern "C"  void Uri_Parse_m736300106 (Uri_t100236324 * __this, int32_t ___kind0, String_t* ___uriString1, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Char System.Uri::HexUnescapeMultiByte(System.String,System.Int32&,System.Char&)
extern "C"  Il2CppChar Uri_HexUnescapeMultiByte_m332853996 (RuntimeObject * __this /* static, unused */, String_t* ___pattern0, int32_t* ___index1, Il2CppChar* ___surrogate2, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String System.String::TrimStart(System.Char[])
extern "C"  String_t* String_TrimStart_m1431283012 (String_t* __this, CharU5BU5D_t3528271667* p0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String System.String::Replace(System.String,System.String)
extern "C"  String_t* String_Replace_m1273907647 (String_t* __this, String_t* p0, String_t* p1, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String System.String::Trim()
extern "C"  String_t* String_Trim_m923598732 (String_t* __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Uri::ParseAsUnixAbsoluteFilePath(System.String)
extern "C"  void Uri_ParseAsUnixAbsoluteFilePath_m1476768041 (Uri_t100236324 * __this, String_t* ___uriString0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Uri::ParseAsWindowsUNC(System.String)
extern "C"  void Uri_ParseAsWindowsUNC_m2348878458 (Uri_t100236324 * __this, String_t* ___uriString0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String System.Uri::ParseAsWindowsAbsoluteFilePath(System.String)
extern "C"  String_t* Uri_ParseAsWindowsAbsoluteFilePath_m708354183 (Uri_t100236324 * __this, String_t* ___uriString0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean System.Uri::CheckSchemeName(System.String)
extern "C"  bool Uri_CheckSchemeName_m108657675 (RuntimeObject * __this /* static, unused */, String_t* ___schemeName0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String Locale::GetText(System.String)
extern "C"  String_t* Locale_GetText_m3875126938 (RuntimeObject * __this /* static, unused */, String_t* ___msg0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Int32 System.String::IndexOf(System.Char,System.Int32)
extern "C"  int32_t String_IndexOf_m2466398549 (String_t* __this, Il2CppChar p0, int32_t p1, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Int32 System.String::IndexOf(System.Char,System.Int32,System.Int32)
extern "C"  int32_t String_IndexOf_m1248948328 (String_t* __this, Il2CppChar p0, int32_t p1, int32_t p2, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Int32 System.String::LastIndexOf(System.Char,System.Int32,System.Int32)
extern "C"  int32_t String_LastIndexOf_m3228770703 (String_t* __this, Il2CppChar p0, int32_t p1, int32_t p2, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean System.Int32::TryParse(System.String,System.Globalization.NumberStyles,System.IFormatProvider,System.Int32&)
extern "C"  bool Int32_TryParse_m135955795 (RuntimeObject * __this /* static, unused */, String_t* p0, int32_t p1, RuntimeObject* p2, int32_t* p3, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String System.Net.IPv6Address::ToString(System.Boolean)
extern "C"  String_t* IPv6Address_ToString_m3978087033 (IPv6Address_t2709566769 * __this, bool ___fullLength0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String System.String::Concat(System.String,System.String,System.String)
extern "C"  String_t* String_Concat_m3755062657 (RuntimeObject * __this /* static, unused */, String_t* p0, String_t* p1, String_t* p2, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.UriParser System.Uri::get_Parser()
extern "C"  UriParser_t3890150400 * Uri_get_Parser_m3737125102 (Uri_t100236324 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Char System.Char::ToUpper(System.Char)
extern "C"  Il2CppChar Char_ToUpper_m3999570441 (RuntimeObject * __this /* static, unused */, Il2CppChar p0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Collections.ArrayList::.ctor()
extern "C"  void ArrayList__ctor_m4254721275 (ArrayList_t2718874744 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Text.StringBuilder::set_Length(System.Int32)
extern "C"  void StringBuilder_set_Length_m1410065908 (StringBuilder_t * __this, int32_t p0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Int32 System.Uri::FromHex(System.Char)
extern "C"  int32_t Uri_FromHex_m2610708947 (RuntimeObject * __this /* static, unused */, Il2CppChar ___digit0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.UriParser System.UriParser::GetParser(System.String)
extern "C"  UriParser_t3890150400 * UriParser_GetParser_m544052729 (RuntimeObject * __this /* static, unused */, String_t* ___schemeName0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Int32 System.UriParser::get_DefaultPort()
extern "C"  int32_t UriParser_get_DefaultPort_m2544851211 (UriParser_t3890150400 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.String System.Uri::GetSchemeDelimiter(System.String)
extern "C"  String_t* Uri_GetSchemeDelimiter_m2374610473 (RuntimeObject * __this /* static, unused */, String_t* ___scheme0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.DefaultUriParser::.ctor(System.String)
extern "C"  void DefaultUriParser__ctor_m2634681684 (DefaultUriParser_t95882050 * __this, String_t* ___scheme0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean System.Uri::TryCreate(System.String,System.UriKind,System.Uri&)
extern "C"  bool Uri_TryCreate_m385949523 (RuntimeObject * __this /* static, unused */, String_t* ___uriString0, int32_t ___uriKind1, Uri_t100236324 ** ___result2, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean System.Uri::IsWellFormedOriginalString()
extern "C"  bool Uri_IsWellFormedOriginalString_m1655593438 (Uri_t100236324 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Uri::.ctor(System.String,System.UriKind,System.Boolean&)
extern "C"  void Uri__ctor_m1916875437 (Uri_t100236324 * __this, String_t* ___uriString0, int32_t ___uriKind1, bool* ___success2, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.IO.MemoryStream::.ctor()
extern "C"  void MemoryStream__ctor_m2678285228 (MemoryStream_t94973147 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Char[] System.Uri::GetChars(System.IO.MemoryStream,System.Text.Encoding)
extern "C"  CharU5BU5D_t3528271667* Uri_GetChars_m3587178967 (RuntimeObject * __this /* static, unused */, MemoryStream_t94973147 * ___b0, Encoding_t1523322056 * ___e1, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Text.StringBuilder System.Text.StringBuilder::Append(System.Char[])
extern "C"  StringBuilder_t * StringBuilder_Append_m168475016 (StringBuilder_t * __this, CharU5BU5D_t3528271667* p0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Int32 System.Uri::GetChar(System.String,System.Int32,System.Int32)
extern "C"  int32_t Uri_GetChar_m2610276660 (RuntimeObject * __this /* static, unused */, String_t* ___str0, int32_t ___offset1, int32_t ___length2, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Int32 System.Uri::GetInt(System.Byte)
extern "C"  int32_t Uri_GetInt_m3269354035 (RuntimeObject * __this /* static, unused */, uint8_t ___b0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.InvalidOperationException::.ctor(System.String)
extern "C"  void InvalidOperationException__ctor_m237278729 (InvalidOperationException_t56020091 * __this, String_t* p0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean System.Object::Equals(System.Object,System.Object)
extern "C"  bool Object_Equals_m1397037629 (RuntimeObject * __this /* static, unused */, RuntimeObject * p0, RuntimeObject * p1, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.FormatException::.ctor(System.String)
extern "C"  void FormatException__ctor_m4049685996 (FormatException_t154580423 * __this, String_t* p0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.FormatException::.ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)
extern "C"  void FormatException__ctor_m3747066592 (FormatException_t154580423 * __this, SerializationInfo_t950877179 * p0, StreamingContext_t3711869237  p1, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Text.RegularExpressions.Regex::.ctor(System.String)
extern "C"  void Regex__ctor_m897876424 (Regex_t3657309853 * __this, String_t* ___pattern0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Collections.Hashtable::.ctor()
extern "C"  void Hashtable__ctor_m1815022027 (Hashtable_t1853889766 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.DefaultUriParser::.ctor()
extern "C"  void DefaultUriParser__ctor_m2377995797 (DefaultUriParser_t95882050 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.UriParser::InternalRegister(System.Collections.Hashtable,System.UriParser,System.String,System.Int32)
extern "C"  void UriParser_InternalRegister_m3643767086 (RuntimeObject * __this /* static, unused */, Hashtable_t1853889766 * ___table0, UriParser_t3890150400 * ___uriParser1, String_t* ___schemeName2, int32_t ___defaultPort3, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Threading.Monitor::Enter(System.Object)
extern "C"  void Monitor_Enter_m2249409497 (RuntimeObject * __this /* static, unused */, RuntimeObject * p0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Threading.Monitor::Exit(System.Object)
extern "C"  void Monitor_Exit_m3585316909 (RuntimeObject * __this /* static, unused */, RuntimeObject * p0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.UriParser::set_SchemeName(System.String)
extern "C"  void UriParser_set_SchemeName_m266448765 (UriParser_t3890150400 * __this, String_t* ___value0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.UriParser::set_DefaultPort(System.Int32)
extern "C"  void UriParser_set_DefaultPort_m4007715058 (UriParser_t3890150400 * __this, int32_t ___value0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.UriParser::CreateDefaults()
extern "C"  void UriParser_CreateDefaults_m404296154 (RuntimeObject * __this /* static, unused */, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Type System.Type::GetTypeFromHandle(System.RuntimeTypeHandle)
extern "C"  Type_t * Type_GetTypeFromHandle_m1620074514 (RuntimeObject * __this /* static, unused */, RuntimeTypeHandle_t3027515415  p0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean System.UriTypeConverter::CanConvert(System.Type)
extern "C"  bool UriTypeConverter_CanConvert_m4004296934 (UriTypeConverter_t3695916615 * __this, Type_t * ___type0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Type System.Object::GetType()
extern "C"  Type_t * Object_GetType_m88164663 (RuntimeObject * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.NotSupportedException::.ctor(System.String)
extern "C"  void NotSupportedException__ctor_m2494070935 (NotSupportedException_t1314879016 * __this, String_t* p0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.Uri::.ctor(System.String,System.UriKind)
extern "C"  void Uri__ctor_m3040793867 (Uri_t100236324 * __this, String_t* ___uriString0, int32_t ___uriKind1, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Object System.ComponentModel.TypeConverter::ConvertFrom(System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,System.Object)
extern "C"  RuntimeObject * TypeConverter_ConvertFrom_m1024238132 (TypeConverter_t2249118273 * __this, RuntimeObject* ___context0, CultureInfo_t4157843068 * ___culture1, RuntimeObject * ___value2, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean System.Uri::op_Inequality(System.Uri,System.Uri)
extern "C"  bool Uri_op_Inequality_m839253362 (RuntimeObject * __this /* static, unused */, Uri_t100236324 * ___u10, Uri_t100236324 * ___u21, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Object System.ComponentModel.TypeConverter::ConvertTo(System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,System.Object,System.Type)
extern "C"  RuntimeObject * TypeConverter_ConvertTo_m3165899902 (TypeConverter_t2249118273 * __this, RuntimeObject* ___context0, CultureInfo_t4157843068 * ___culture1, RuntimeObject * ___value2, Type_t * ___destinationType3, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void System.Text.RegularExpressions.Syntax.PositionAssertion::.ctor(System.Text.RegularExpressions.Position)
extern "C"  void PositionAssertion__ctor_m569003936 (PositionAssertion_t3339288061 * __this, uint16_t ___pos0, const RuntimeMethod* method)
{
	{
		Expression__ctor_m1600460087(__this, /*hidden argument*/NULL);
		uint16_t L_0 = ___pos0;
		__this->set_pos_0(L_0);
		return;
	}
}
// System.Void System.Text.RegularExpressions.Syntax.PositionAssertion::Compile(System.Text.RegularExpressions.ICompiler,System.Boolean)
extern "C"  void PositionAssertion_Compile_m2500980346 (PositionAssertion_t3339288061 * __this, RuntimeObject* ___cmp0, bool ___reverse1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (PositionAssertion_Compile_m2500980346_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = ___cmp0;
		uint16_t L_1 = __this->get_pos_0();
		InterfaceActionInvoker1< uint16_t >::Invoke(9 /* System.Void System.Text.RegularExpressions.ICompiler::EmitPosition(System.Text.RegularExpressions.Position) */, ICompiler_t118549125_il2cpp_TypeInfo_var, L_0, L_1);
		return;
	}
}
// System.Void System.Text.RegularExpressions.Syntax.PositionAssertion::GetWidth(System.Int32&,System.Int32&)
extern "C"  void PositionAssertion_GetWidth_m856687117 (PositionAssertion_t3339288061 * __this, int32_t* ___min0, int32_t* ___max1, const RuntimeMethod* method)
{
	int32_t V_0 = 0;
	{
		int32_t* L_0 = ___min0;
		int32_t* L_1 = ___max1;
		int32_t L_2 = 0;
		V_0 = L_2;
		*((int32_t*)(L_1)) = (int32_t)L_2;
		int32_t L_3 = V_0;
		*((int32_t*)(L_0)) = (int32_t)L_3;
		return;
	}
}
// System.Boolean System.Text.RegularExpressions.Syntax.PositionAssertion::IsComplex()
extern "C"  bool PositionAssertion_IsComplex_m3339056668 (PositionAssertion_t3339288061 * __this, const RuntimeMethod* method)
{
	{
		return (bool)0;
	}
}
// System.Text.RegularExpressions.Syntax.AnchorInfo System.Text.RegularExpressions.Syntax.PositionAssertion::GetAnchorInfo(System.Boolean)
extern "C"  AnchorInfo_t3387011151 * PositionAssertion_GetAnchorInfo_m32057718 (PositionAssertion_t3339288061 * __this, bool ___revers0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (PositionAssertion_GetAnchorInfo_m32057718_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	uint16_t V_0 = 0;
	{
		uint16_t L_0 = __this->get_pos_0();
		V_0 = L_0;
		uint16_t L_1 = V_0;
		switch (((int32_t)il2cpp_codegen_subtract((int32_t)L_1, (int32_t)2)))
		{
			case 0:
			{
				goto IL_0020;
			}
			case 1:
			{
				goto IL_0020;
			}
			case 2:
			{
				goto IL_0020;
			}
		}
	}
	{
		goto IL_002f;
	}

IL_0020:
	{
		uint16_t L_2 = __this->get_pos_0();
		AnchorInfo_t3387011151 * L_3 = (AnchorInfo_t3387011151 *)il2cpp_codegen_object_new(AnchorInfo_t3387011151_il2cpp_TypeInfo_var);
		AnchorInfo__ctor_m46784903(L_3, __this, 0, 0, L_2, /*hidden argument*/NULL);
		return L_3;
	}

IL_002f:
	{
		AnchorInfo_t3387011151 * L_4 = (AnchorInfo_t3387011151 *)il2cpp_codegen_object_new(AnchorInfo_t3387011151_il2cpp_TypeInfo_var);
		AnchorInfo__ctor_m3523994803(L_4, __this, 0, /*hidden argument*/NULL);
		return L_4;
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
// System.Void System.Text.RegularExpressions.Syntax.Reference::.ctor(System.Boolean)
extern "C"  void Reference__ctor_m1870245246 (Reference_t1799410108 * __this, bool ___ignore0, const RuntimeMethod* method)
{
	{
		Expression__ctor_m1600460087(__this, /*hidden argument*/NULL);
		bool L_0 = ___ignore0;
		__this->set_ignore_1(L_0);
		return;
	}
}
// System.Text.RegularExpressions.Syntax.CapturingGroup System.Text.RegularExpressions.Syntax.Reference::get_CapturingGroup()
extern "C"  CapturingGroup_t751358689 * Reference_get_CapturingGroup_m3861468528 (Reference_t1799410108 * __this, const RuntimeMethod* method)
{
	{
		CapturingGroup_t751358689 * L_0 = __this->get_group_0();
		return L_0;
	}
}
// System.Void System.Text.RegularExpressions.Syntax.Reference::set_CapturingGroup(System.Text.RegularExpressions.Syntax.CapturingGroup)
extern "C"  void Reference_set_CapturingGroup_m1130974240 (Reference_t1799410108 * __this, CapturingGroup_t751358689 * ___value0, const RuntimeMethod* method)
{
	{
		CapturingGroup_t751358689 * L_0 = ___value0;
		__this->set_group_0(L_0);
		return;
	}
}
// System.Boolean System.Text.RegularExpressions.Syntax.Reference::get_IgnoreCase()
extern "C"  bool Reference_get_IgnoreCase_m241264953 (Reference_t1799410108 * __this, const RuntimeMethod* method)
{
	{
		bool L_0 = __this->get_ignore_1();
		return L_0;
	}
}
// System.Void System.Text.RegularExpressions.Syntax.Reference::Compile(System.Text.RegularExpressions.ICompiler,System.Boolean)
extern "C"  void Reference_Compile_m4195878675 (Reference_t1799410108 * __this, RuntimeObject* ___cmp0, bool ___reverse1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Reference_Compile_m4195878675_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = ___cmp0;
		CapturingGroup_t751358689 * L_1 = __this->get_group_0();
		int32_t L_2 = CapturingGroup_get_Index_m3406974370(L_1, /*hidden argument*/NULL);
		bool L_3 = __this->get_ignore_1();
		bool L_4 = ___reverse1;
		InterfaceActionInvoker3< int32_t, bool, bool >::Invoke(14 /* System.Void System.Text.RegularExpressions.ICompiler::EmitReference(System.Int32,System.Boolean,System.Boolean) */, ICompiler_t118549125_il2cpp_TypeInfo_var, L_0, L_2, L_3, L_4);
		return;
	}
}
// System.Void System.Text.RegularExpressions.Syntax.Reference::GetWidth(System.Int32&,System.Int32&)
extern "C"  void Reference_GetWidth_m3130781491 (Reference_t1799410108 * __this, int32_t* ___min0, int32_t* ___max1, const RuntimeMethod* method)
{
	{
		int32_t* L_0 = ___min0;
		*((int32_t*)(L_0)) = (int32_t)0;
		int32_t* L_1 = ___max1;
		*((int32_t*)(L_1)) = (int32_t)((int32_t)2147483647LL);
		return;
	}
}
// System.Boolean System.Text.RegularExpressions.Syntax.Reference::IsComplex()
extern "C"  bool Reference_IsComplex_m3000063927 (Reference_t1799410108 * __this, const RuntimeMethod* method)
{
	{
		return (bool)1;
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
// System.Void System.Text.RegularExpressions.Syntax.RegularExpression::.ctor()
extern "C"  void RegularExpression__ctor_m119502265 (RegularExpression_t3834220169 * __this, const RuntimeMethod* method)
{
	{
		Group__ctor_m2980794822(__this, /*hidden argument*/NULL);
		__this->set_group_count_1(0);
		return;
	}
}
// System.Void System.Text.RegularExpressions.Syntax.RegularExpression::set_GroupCount(System.Int32)
extern "C"  void RegularExpression_set_GroupCount_m3908887512 (RegularExpression_t3834220169 * __this, int32_t ___value0, const RuntimeMethod* method)
{
	{
		int32_t L_0 = ___value0;
		__this->set_group_count_1(L_0);
		return;
	}
}
// System.Void System.Text.RegularExpressions.Syntax.RegularExpression::Compile(System.Text.RegularExpressions.ICompiler,System.Boolean)
extern "C"  void RegularExpression_Compile_m2385682508 (RegularExpression_t3834220169 * __this, RuntimeObject* ___cmp0, bool ___reverse1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (RegularExpression_Compile_m2385682508_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	AnchorInfo_t3387011151 * V_2 = NULL;
	LinkRef_t2971865410 * V_3 = NULL;
	{
		VirtActionInvoker2< int32_t*, int32_t* >::Invoke(5 /* System.Void System.Text.RegularExpressions.Syntax.Group::GetWidth(System.Int32&,System.Int32&) */, __this, (&V_0), (&V_1));
		RuntimeObject* L_0 = ___cmp0;
		int32_t L_1 = __this->get_group_count_1();
		int32_t L_2 = V_0;
		int32_t L_3 = V_1;
		InterfaceActionInvoker3< int32_t, int32_t, int32_t >::Invoke(23 /* System.Void System.Text.RegularExpressions.ICompiler::EmitInfo(System.Int32,System.Int32,System.Int32) */, ICompiler_t118549125_il2cpp_TypeInfo_var, L_0, L_1, L_2, L_3);
		bool L_4 = ___reverse1;
		AnchorInfo_t3387011151 * L_5 = VirtFuncInvoker1< AnchorInfo_t3387011151 *, bool >::Invoke(6 /* System.Text.RegularExpressions.Syntax.AnchorInfo System.Text.RegularExpressions.Syntax.Group::GetAnchorInfo(System.Boolean) */, __this, L_4);
		V_2 = L_5;
		RuntimeObject* L_6 = ___cmp0;
		LinkRef_t2971865410 * L_7 = InterfaceFuncInvoker0< LinkRef_t2971865410 * >::Invoke(28 /* System.Text.RegularExpressions.LinkRef System.Text.RegularExpressions.ICompiler::NewLink() */, ICompiler_t118549125_il2cpp_TypeInfo_var, L_6);
		V_3 = L_7;
		RuntimeObject* L_8 = ___cmp0;
		bool L_9 = ___reverse1;
		AnchorInfo_t3387011151 * L_10 = V_2;
		int32_t L_11 = AnchorInfo_get_Offset_m2045445765(L_10, /*hidden argument*/NULL);
		LinkRef_t2971865410 * L_12 = V_3;
		InterfaceActionInvoker3< bool, int32_t, LinkRef_t2971865410 * >::Invoke(25 /* System.Void System.Text.RegularExpressions.ICompiler::EmitAnchor(System.Boolean,System.Int32,System.Text.RegularExpressions.LinkRef) */, ICompiler_t118549125_il2cpp_TypeInfo_var, L_8, L_9, L_11, L_12);
		AnchorInfo_t3387011151 * L_13 = V_2;
		bool L_14 = AnchorInfo_get_IsPosition_m2100552190(L_13, /*hidden argument*/NULL);
		if (!L_14)
		{
			goto IL_0051;
		}
	}
	{
		RuntimeObject* L_15 = ___cmp0;
		AnchorInfo_t3387011151 * L_16 = V_2;
		uint16_t L_17 = AnchorInfo_get_Position_m1133366486(L_16, /*hidden argument*/NULL);
		InterfaceActionInvoker1< uint16_t >::Invoke(9 /* System.Void System.Text.RegularExpressions.ICompiler::EmitPosition(System.Text.RegularExpressions.Position) */, ICompiler_t118549125_il2cpp_TypeInfo_var, L_15, L_17);
		goto IL_006f;
	}

IL_0051:
	{
		AnchorInfo_t3387011151 * L_18 = V_2;
		bool L_19 = AnchorInfo_get_IsSubstring_m1536110387(L_18, /*hidden argument*/NULL);
		if (!L_19)
		{
			goto IL_006f;
		}
	}
	{
		RuntimeObject* L_20 = ___cmp0;
		AnchorInfo_t3387011151 * L_21 = V_2;
		String_t* L_22 = AnchorInfo_get_Substring_m1799385132(L_21, /*hidden argument*/NULL);
		AnchorInfo_t3387011151 * L_23 = V_2;
		bool L_24 = AnchorInfo_get_IgnoreCase_m4084905689(L_23, /*hidden argument*/NULL);
		bool L_25 = ___reverse1;
		InterfaceActionInvoker3< String_t*, bool, bool >::Invoke(8 /* System.Void System.Text.RegularExpressions.ICompiler::EmitString(System.String,System.Boolean,System.Boolean) */, ICompiler_t118549125_il2cpp_TypeInfo_var, L_20, L_22, L_24, L_25);
	}

IL_006f:
	{
		RuntimeObject* L_26 = ___cmp0;
		InterfaceActionInvoker0::Invoke(2 /* System.Void System.Text.RegularExpressions.ICompiler::EmitTrue() */, ICompiler_t118549125_il2cpp_TypeInfo_var, L_26);
		RuntimeObject* L_27 = ___cmp0;
		LinkRef_t2971865410 * L_28 = V_3;
		InterfaceActionInvoker1< LinkRef_t2971865410 * >::Invoke(29 /* System.Void System.Text.RegularExpressions.ICompiler::ResolveLink(System.Text.RegularExpressions.LinkRef) */, ICompiler_t118549125_il2cpp_TypeInfo_var, L_27, L_28);
		RuntimeObject* L_29 = ___cmp0;
		bool L_30 = ___reverse1;
		Group_Compile_m3355488790(__this, L_29, L_30, /*hidden argument*/NULL);
		RuntimeObject* L_31 = ___cmp0;
		InterfaceActionInvoker0::Invoke(2 /* System.Void System.Text.RegularExpressions.ICompiler::EmitTrue() */, ICompiler_t118549125_il2cpp_TypeInfo_var, L_31);
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
// System.Void System.Text.RegularExpressions.Syntax.Repetition::.ctor(System.Int32,System.Int32,System.Boolean)
extern "C"  void Repetition__ctor_m1672362629 (Repetition_t2393242404 * __this, int32_t ___min0, int32_t ___max1, bool ___lazy2, const RuntimeMethod* method)
{
	{
		CompositeExpression__ctor_m2434860303(__this, /*hidden argument*/NULL);
		ExpressionCollection_t1810289389 * L_0 = CompositeExpression_get_Expressions_m2951105322(__this, /*hidden argument*/NULL);
		ExpressionCollection_Add_m41125344(L_0, (Expression_t2722445759 *)NULL, /*hidden argument*/NULL);
		int32_t L_1 = ___min0;
		__this->set_min_1(L_1);
		int32_t L_2 = ___max1;
		__this->set_max_2(L_2);
		bool L_3 = ___lazy2;
		__this->set_lazy_3(L_3);
		return;
	}
}
// System.Text.RegularExpressions.Syntax.Expression System.Text.RegularExpressions.Syntax.Repetition::get_Expression()
extern "C"  Expression_t2722445759 * Repetition_get_Expression_m2673886232 (Repetition_t2393242404 * __this, const RuntimeMethod* method)
{
	{
		ExpressionCollection_t1810289389 * L_0 = CompositeExpression_get_Expressions_m2951105322(__this, /*hidden argument*/NULL);
		Expression_t2722445759 * L_1 = ExpressionCollection_get_Item_m3510736379(L_0, 0, /*hidden argument*/NULL);
		return L_1;
	}
}
// System.Void System.Text.RegularExpressions.Syntax.Repetition::set_Expression(System.Text.RegularExpressions.Syntax.Expression)
extern "C"  void Repetition_set_Expression_m1234887071 (Repetition_t2393242404 * __this, Expression_t2722445759 * ___value0, const RuntimeMethod* method)
{
	{
		ExpressionCollection_t1810289389 * L_0 = CompositeExpression_get_Expressions_m2951105322(__this, /*hidden argument*/NULL);
		Expression_t2722445759 * L_1 = ___value0;
		ExpressionCollection_set_Item_m2040804459(L_0, 0, L_1, /*hidden argument*/NULL);
		return;
	}
}
// System.Int32 System.Text.RegularExpressions.Syntax.Repetition::get_Minimum()
extern "C"  int32_t Repetition_get_Minimum_m2550947568 (Repetition_t2393242404 * __this, const RuntimeMethod* method)
{
	{
		int32_t L_0 = __this->get_min_1();
		return L_0;
	}
}
// System.Void System.Text.RegularExpressions.Syntax.Repetition::Compile(System.Text.RegularExpressions.ICompiler,System.Boolean)
extern "C"  void Repetition_Compile_m988726715 (Repetition_t2393242404 * __this, RuntimeObject* ___cmp0, bool ___reverse1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Repetition_Compile_m988726715_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	LinkRef_t2971865410 * V_0 = NULL;
	LinkRef_t2971865410 * V_1 = NULL;
	{
		Expression_t2722445759 * L_0 = Repetition_get_Expression_m2673886232(__this, /*hidden argument*/NULL);
		bool L_1 = VirtFuncInvoker0< bool >::Invoke(7 /* System.Boolean System.Text.RegularExpressions.Syntax.Expression::IsComplex() */, L_0);
		if (!L_1)
		{
			goto IL_0049;
		}
	}
	{
		RuntimeObject* L_2 = ___cmp0;
		LinkRef_t2971865410 * L_3 = InterfaceFuncInvoker0< LinkRef_t2971865410 * >::Invoke(28 /* System.Text.RegularExpressions.LinkRef System.Text.RegularExpressions.ICompiler::NewLink() */, ICompiler_t118549125_il2cpp_TypeInfo_var, L_2);
		V_0 = L_3;
		RuntimeObject* L_4 = ___cmp0;
		int32_t L_5 = __this->get_min_1();
		int32_t L_6 = __this->get_max_2();
		bool L_7 = __this->get_lazy_3();
		LinkRef_t2971865410 * L_8 = V_0;
		InterfaceActionInvoker4< int32_t, int32_t, bool, LinkRef_t2971865410 * >::Invoke(20 /* System.Void System.Text.RegularExpressions.ICompiler::EmitRepeat(System.Int32,System.Int32,System.Boolean,System.Text.RegularExpressions.LinkRef) */, ICompiler_t118549125_il2cpp_TypeInfo_var, L_4, L_5, L_6, L_7, L_8);
		Expression_t2722445759 * L_9 = Repetition_get_Expression_m2673886232(__this, /*hidden argument*/NULL);
		RuntimeObject* L_10 = ___cmp0;
		bool L_11 = ___reverse1;
		VirtActionInvoker2< RuntimeObject*, bool >::Invoke(4 /* System.Void System.Text.RegularExpressions.Syntax.Expression::Compile(System.Text.RegularExpressions.ICompiler,System.Boolean) */, L_9, L_10, L_11);
		RuntimeObject* L_12 = ___cmp0;
		LinkRef_t2971865410 * L_13 = V_0;
		InterfaceActionInvoker1< LinkRef_t2971865410 * >::Invoke(21 /* System.Void System.Text.RegularExpressions.ICompiler::EmitUntil(System.Text.RegularExpressions.LinkRef) */, ICompiler_t118549125_il2cpp_TypeInfo_var, L_12, L_13);
		goto IL_0083;
	}

IL_0049:
	{
		RuntimeObject* L_14 = ___cmp0;
		LinkRef_t2971865410 * L_15 = InterfaceFuncInvoker0< LinkRef_t2971865410 * >::Invoke(28 /* System.Text.RegularExpressions.LinkRef System.Text.RegularExpressions.ICompiler::NewLink() */, ICompiler_t118549125_il2cpp_TypeInfo_var, L_14);
		V_1 = L_15;
		RuntimeObject* L_16 = ___cmp0;
		int32_t L_17 = __this->get_min_1();
		int32_t L_18 = __this->get_max_2();
		bool L_19 = __this->get_lazy_3();
		LinkRef_t2971865410 * L_20 = V_1;
		InterfaceActionInvoker4< int32_t, int32_t, bool, LinkRef_t2971865410 * >::Invoke(24 /* System.Void System.Text.RegularExpressions.ICompiler::EmitFastRepeat(System.Int32,System.Int32,System.Boolean,System.Text.RegularExpressions.LinkRef) */, ICompiler_t118549125_il2cpp_TypeInfo_var, L_16, L_17, L_18, L_19, L_20);
		Expression_t2722445759 * L_21 = Repetition_get_Expression_m2673886232(__this, /*hidden argument*/NULL);
		RuntimeObject* L_22 = ___cmp0;
		bool L_23 = ___reverse1;
		VirtActionInvoker2< RuntimeObject*, bool >::Invoke(4 /* System.Void System.Text.RegularExpressions.Syntax.Expression::Compile(System.Text.RegularExpressions.ICompiler,System.Boolean) */, L_21, L_22, L_23);
		RuntimeObject* L_24 = ___cmp0;
		InterfaceActionInvoker0::Invoke(2 /* System.Void System.Text.RegularExpressions.ICompiler::EmitTrue() */, ICompiler_t118549125_il2cpp_TypeInfo_var, L_24);
		RuntimeObject* L_25 = ___cmp0;
		LinkRef_t2971865410 * L_26 = V_1;
		InterfaceActionInvoker1< LinkRef_t2971865410 * >::Invoke(29 /* System.Void System.Text.RegularExpressions.ICompiler::ResolveLink(System.Text.RegularExpressions.LinkRef) */, ICompiler_t118549125_il2cpp_TypeInfo_var, L_25, L_26);
	}

IL_0083:
	{
		return;
	}
}
// System.Void System.Text.RegularExpressions.Syntax.Repetition::GetWidth(System.Int32&,System.Int32&)
extern "C"  void Repetition_GetWidth_m1827161831 (Repetition_t2393242404 * __this, int32_t* ___min0, int32_t* ___max1, const RuntimeMethod* method)
{
	{
		Expression_t2722445759 * L_0 = Repetition_get_Expression_m2673886232(__this, /*hidden argument*/NULL);
		int32_t* L_1 = ___min0;
		int32_t* L_2 = ___max1;
		VirtActionInvoker2< int32_t*, int32_t* >::Invoke(5 /* System.Void System.Text.RegularExpressions.Syntax.Expression::GetWidth(System.Int32&,System.Int32&) */, L_0, L_1, L_2);
		int32_t* L_3 = ___min0;
		int32_t* L_4 = ___min0;
		int32_t L_5 = __this->get_min_1();
		*((int32_t*)(L_3)) = (int32_t)((int32_t)il2cpp_codegen_multiply((int32_t)(*((int32_t*)L_4)), (int32_t)L_5));
		int32_t* L_6 = ___max1;
		if ((((int32_t)(*((int32_t*)L_6))) == ((int32_t)((int32_t)2147483647LL))))
		{
			goto IL_0034;
		}
	}
	{
		int32_t L_7 = __this->get_max_2();
		if ((!(((uint32_t)L_7) == ((uint32_t)((int32_t)65535)))))
		{
			goto IL_0040;
		}
	}

IL_0034:
	{
		int32_t* L_8 = ___max1;
		*((int32_t*)(L_8)) = (int32_t)((int32_t)2147483647LL);
		goto IL_004b;
	}

IL_0040:
	{
		int32_t* L_9 = ___max1;
		int32_t* L_10 = ___max1;
		int32_t L_11 = __this->get_max_2();
		*((int32_t*)(L_9)) = (int32_t)((int32_t)il2cpp_codegen_multiply((int32_t)(*((int32_t*)L_10)), (int32_t)L_11));
	}

IL_004b:
	{
		return;
	}
}
// System.Text.RegularExpressions.Syntax.AnchorInfo System.Text.RegularExpressions.Syntax.Repetition::GetAnchorInfo(System.Boolean)
extern "C"  AnchorInfo_t3387011151 * Repetition_GetAnchorInfo_m2615648496 (Repetition_t2393242404 * __this, bool ___reverse0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Repetition_GetAnchorInfo_m2615648496_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	AnchorInfo_t3387011151 * V_1 = NULL;
	String_t* V_2 = NULL;
	StringBuilder_t * V_3 = NULL;
	int32_t V_4 = 0;
	{
		int32_t L_0 = Expression_GetFixedWidth_m945658(__this, /*hidden argument*/NULL);
		V_0 = L_0;
		int32_t L_1 = Repetition_get_Minimum_m2550947568(__this, /*hidden argument*/NULL);
		if (L_1)
		{
			goto IL_001a;
		}
	}
	{
		int32_t L_2 = V_0;
		AnchorInfo_t3387011151 * L_3 = (AnchorInfo_t3387011151 *)il2cpp_codegen_object_new(AnchorInfo_t3387011151_il2cpp_TypeInfo_var);
		AnchorInfo__ctor_m3523994803(L_3, __this, L_2, /*hidden argument*/NULL);
		return L_3;
	}

IL_001a:
	{
		Expression_t2722445759 * L_4 = Repetition_get_Expression_m2673886232(__this, /*hidden argument*/NULL);
		bool L_5 = ___reverse0;
		AnchorInfo_t3387011151 * L_6 = VirtFuncInvoker1< AnchorInfo_t3387011151 *, bool >::Invoke(6 /* System.Text.RegularExpressions.Syntax.AnchorInfo System.Text.RegularExpressions.Syntax.Expression::GetAnchorInfo(System.Boolean) */, L_4, L_5);
		V_1 = L_6;
		AnchorInfo_t3387011151 * L_7 = V_1;
		bool L_8 = AnchorInfo_get_IsPosition_m2100552190(L_7, /*hidden argument*/NULL);
		if (!L_8)
		{
			goto IL_0046;
		}
	}
	{
		AnchorInfo_t3387011151 * L_9 = V_1;
		int32_t L_10 = AnchorInfo_get_Offset_m2045445765(L_9, /*hidden argument*/NULL);
		int32_t L_11 = V_0;
		AnchorInfo_t3387011151 * L_12 = V_1;
		uint16_t L_13 = AnchorInfo_get_Position_m1133366486(L_12, /*hidden argument*/NULL);
		AnchorInfo_t3387011151 * L_14 = (AnchorInfo_t3387011151 *)il2cpp_codegen_object_new(AnchorInfo_t3387011151_il2cpp_TypeInfo_var);
		AnchorInfo__ctor_m46784903(L_14, __this, L_10, L_11, L_13, /*hidden argument*/NULL);
		return L_14;
	}

IL_0046:
	{
		AnchorInfo_t3387011151 * L_15 = V_1;
		bool L_16 = AnchorInfo_get_IsSubstring_m1536110387(L_15, /*hidden argument*/NULL);
		if (!L_16)
		{
			goto IL_00bc;
		}
	}
	{
		AnchorInfo_t3387011151 * L_17 = V_1;
		bool L_18 = AnchorInfo_get_IsComplete_m4053892818(L_17, /*hidden argument*/NULL);
		if (!L_18)
		{
			goto IL_00a2;
		}
	}
	{
		AnchorInfo_t3387011151 * L_19 = V_1;
		String_t* L_20 = AnchorInfo_get_Substring_m1799385132(L_19, /*hidden argument*/NULL);
		V_2 = L_20;
		String_t* L_21 = V_2;
		StringBuilder_t * L_22 = (StringBuilder_t *)il2cpp_codegen_object_new(StringBuilder_t_il2cpp_TypeInfo_var);
		StringBuilder__ctor_m2989139009(L_22, L_21, /*hidden argument*/NULL);
		V_3 = L_22;
		V_4 = 1;
		goto IL_0080;
	}

IL_0072:
	{
		StringBuilder_t * L_23 = V_3;
		String_t* L_24 = V_2;
		StringBuilder_Append_m1965104174(L_23, L_24, /*hidden argument*/NULL);
		int32_t L_25 = V_4;
		V_4 = ((int32_t)il2cpp_codegen_add((int32_t)L_25, (int32_t)1));
	}

IL_0080:
	{
		int32_t L_26 = V_4;
		int32_t L_27 = Repetition_get_Minimum_m2550947568(__this, /*hidden argument*/NULL);
		if ((((int32_t)L_26) < ((int32_t)L_27)))
		{
			goto IL_0072;
		}
	}
	{
		int32_t L_28 = V_0;
		StringBuilder_t * L_29 = V_3;
		String_t* L_30 = StringBuilder_ToString_m3317489284(L_29, /*hidden argument*/NULL);
		AnchorInfo_t3387011151 * L_31 = V_1;
		bool L_32 = AnchorInfo_get_IgnoreCase_m4084905689(L_31, /*hidden argument*/NULL);
		AnchorInfo_t3387011151 * L_33 = (AnchorInfo_t3387011151 *)il2cpp_codegen_object_new(AnchorInfo_t3387011151_il2cpp_TypeInfo_var);
		AnchorInfo__ctor_m3869855453(L_33, __this, 0, L_28, L_30, L_32, /*hidden argument*/NULL);
		return L_33;
	}

IL_00a2:
	{
		AnchorInfo_t3387011151 * L_34 = V_1;
		int32_t L_35 = AnchorInfo_get_Offset_m2045445765(L_34, /*hidden argument*/NULL);
		int32_t L_36 = V_0;
		AnchorInfo_t3387011151 * L_37 = V_1;
		String_t* L_38 = AnchorInfo_get_Substring_m1799385132(L_37, /*hidden argument*/NULL);
		AnchorInfo_t3387011151 * L_39 = V_1;
		bool L_40 = AnchorInfo_get_IgnoreCase_m4084905689(L_39, /*hidden argument*/NULL);
		AnchorInfo_t3387011151 * L_41 = (AnchorInfo_t3387011151 *)il2cpp_codegen_object_new(AnchorInfo_t3387011151_il2cpp_TypeInfo_var);
		AnchorInfo__ctor_m3869855453(L_41, __this, L_35, L_36, L_38, L_40, /*hidden argument*/NULL);
		return L_41;
	}

IL_00bc:
	{
		int32_t L_42 = V_0;
		AnchorInfo_t3387011151 * L_43 = (AnchorInfo_t3387011151 *)il2cpp_codegen_object_new(AnchorInfo_t3387011151_il2cpp_TypeInfo_var);
		AnchorInfo__ctor_m3523994803(L_43, __this, L_42, /*hidden argument*/NULL);
		return L_43;
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
// System.Void System.Uri::.ctor(System.String)
extern "C"  void Uri__ctor_m800430703 (Uri_t100236324 * __this, String_t* ___uriString0, const RuntimeMethod* method)
{
	{
		String_t* L_0 = ___uriString0;
		Uri__ctor_m3577021606(__this, L_0, (bool)0, /*hidden argument*/NULL);
		return;
	}
}
// System.Void System.Uri::.ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)
extern "C"  void Uri__ctor_m3848281005 (Uri_t100236324 * __this, SerializationInfo_t950877179 * ___serializationInfo0, StreamingContext_t3711869237  ___streamingContext1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri__ctor_m3848281005_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		SerializationInfo_t950877179 * L_0 = ___serializationInfo0;
		String_t* L_1 = SerializationInfo_GetString_m3155282843(L_0, _stringLiteral1705674066, /*hidden argument*/NULL);
		Uri__ctor_m3577021606(__this, L_1, (bool)1, /*hidden argument*/NULL);
		return;
	}
}
// System.Void System.Uri::.ctor(System.String,System.UriKind)
extern "C"  void Uri__ctor_m3040793867 (Uri_t100236324 * __this, String_t* ___uriString0, int32_t ___uriKind1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri__ctor_m3040793867_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	String_t* V_0 = NULL;
	int32_t V_1 = 0;
	{
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_0 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_scheme_3(L_0);
		String_t* L_1 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_host_4(L_1);
		__this->set_port_5((-1));
		String_t* L_2 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_path_6(L_2);
		String_t* L_3 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_query_7(L_3);
		String_t* L_4 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_fragment_8(L_4);
		String_t* L_5 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_userinfo_9(L_5);
		__this->set_isAbsoluteUri_12((bool)1);
		Object__ctor_m297566312(__this, /*hidden argument*/NULL);
		String_t* L_6 = ___uriString0;
		__this->set_source_2(L_6);
		int32_t L_7 = ___uriKind1;
		Uri_ParseUri_m2150795567(__this, L_7, /*hidden argument*/NULL);
		int32_t L_8 = ___uriKind1;
		V_1 = L_8;
		int32_t L_9 = V_1;
		switch (L_9)
		{
			case 0:
			{
				goto IL_00b3;
			}
			case 1:
			{
				goto IL_007d;
			}
			case 2:
			{
				goto IL_0098;
			}
		}
	}
	{
		goto IL_00b8;
	}

IL_007d:
	{
		bool L_10 = Uri_get_IsAbsoluteUri_m3666899587(__this, /*hidden argument*/NULL);
		if (L_10)
		{
			goto IL_0093;
		}
	}
	{
		UriFormatException_t953270471 * L_11 = (UriFormatException_t953270471 *)il2cpp_codegen_object_new(UriFormatException_t953270471_il2cpp_TypeInfo_var);
		UriFormatException__ctor_m3083316541(L_11, _stringLiteral1267661654, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_11,Uri__ctor_m3040793867_RuntimeMethod_var);
	}

IL_0093:
	{
		goto IL_00d9;
	}

IL_0098:
	{
		bool L_12 = Uri_get_IsAbsoluteUri_m3666899587(__this, /*hidden argument*/NULL);
		if (!L_12)
		{
			goto IL_00ae;
		}
	}
	{
		UriFormatException_t953270471 * L_13 = (UriFormatException_t953270471 *)il2cpp_codegen_object_new(UriFormatException_t953270471_il2cpp_TypeInfo_var);
		UriFormatException__ctor_m3083316541(L_13, _stringLiteral3167450820, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_13,Uri__ctor_m3040793867_RuntimeMethod_var);
	}

IL_00ae:
	{
		goto IL_00d9;
	}

IL_00b3:
	{
		goto IL_00d9;
	}

IL_00b8:
	{
		ObjectU5BU5D_t2843939325* L_14 = ((ObjectU5BU5D_t2843939325*)SZArrayNew(ObjectU5BU5D_t2843939325_il2cpp_TypeInfo_var, (uint32_t)1));
		int32_t L_15 = ___uriKind1;
		int32_t L_16 = L_15;
		RuntimeObject * L_17 = Box(UriKind_t3816567336_il2cpp_TypeInfo_var, &L_16);
		ArrayElementTypeCheck (L_14, L_17);
		(L_14)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(0), (RuntimeObject *)L_17);
		String_t* L_18 = Locale_GetText_m2640320736(NULL /*static, unused*/, _stringLiteral2894849996, L_14, /*hidden argument*/NULL);
		V_0 = L_18;
		String_t* L_19 = V_0;
		ArgumentException_t132251570 * L_20 = (ArgumentException_t132251570 *)il2cpp_codegen_object_new(ArgumentException_t132251570_il2cpp_TypeInfo_var);
		ArgumentException__ctor_m1312628991(L_20, L_19, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_20,Uri__ctor_m3040793867_RuntimeMethod_var);
	}

IL_00d9:
	{
		return;
	}
}
// System.Void System.Uri::.ctor(System.String,System.UriKind,System.Boolean&)
extern "C"  void Uri__ctor_m1916875437 (Uri_t100236324 * __this, String_t* ___uriString0, int32_t ___uriKind1, bool* ___success2, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri__ctor_m1916875437_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	String_t* V_0 = NULL;
	int32_t V_1 = 0;
	{
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_0 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_scheme_3(L_0);
		String_t* L_1 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_host_4(L_1);
		__this->set_port_5((-1));
		String_t* L_2 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_path_6(L_2);
		String_t* L_3 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_query_7(L_3);
		String_t* L_4 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_fragment_8(L_4);
		String_t* L_5 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_userinfo_9(L_5);
		__this->set_isAbsoluteUri_12((bool)1);
		Object__ctor_m297566312(__this, /*hidden argument*/NULL);
		String_t* L_6 = ___uriString0;
		if (L_6)
		{
			goto IL_0060;
		}
	}
	{
		bool* L_7 = ___success2;
		*((int8_t*)(L_7)) = (int8_t)0;
		return;
	}

IL_0060:
	{
		int32_t L_8 = ___uriKind1;
		if (!L_8)
		{
			goto IL_0095;
		}
	}
	{
		int32_t L_9 = ___uriKind1;
		if ((((int32_t)L_9) == ((int32_t)1)))
		{
			goto IL_0095;
		}
	}
	{
		int32_t L_10 = ___uriKind1;
		if ((((int32_t)L_10) == ((int32_t)2)))
		{
			goto IL_0095;
		}
	}
	{
		ObjectU5BU5D_t2843939325* L_11 = ((ObjectU5BU5D_t2843939325*)SZArrayNew(ObjectU5BU5D_t2843939325_il2cpp_TypeInfo_var, (uint32_t)1));
		int32_t L_12 = ___uriKind1;
		int32_t L_13 = L_12;
		RuntimeObject * L_14 = Box(UriKind_t3816567336_il2cpp_TypeInfo_var, &L_13);
		ArrayElementTypeCheck (L_11, L_14);
		(L_11)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(0), (RuntimeObject *)L_14);
		String_t* L_15 = Locale_GetText_m2640320736(NULL /*static, unused*/, _stringLiteral2894849996, L_11, /*hidden argument*/NULL);
		V_0 = L_15;
		String_t* L_16 = V_0;
		ArgumentException_t132251570 * L_17 = (ArgumentException_t132251570 *)il2cpp_codegen_object_new(ArgumentException_t132251570_il2cpp_TypeInfo_var);
		ArgumentException__ctor_m1312628991(L_17, L_16, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_17,Uri__ctor_m1916875437_RuntimeMethod_var);
	}

IL_0095:
	{
		String_t* L_18 = ___uriString0;
		__this->set_source_2(L_18);
		int32_t L_19 = ___uriKind1;
		String_t* L_20 = ___uriString0;
		String_t* L_21 = Uri_ParseNoExceptions_m4274141693(__this, L_19, L_20, /*hidden argument*/NULL);
		if (!L_21)
		{
			goto IL_00b1;
		}
	}
	{
		bool* L_22 = ___success2;
		*((int8_t*)(L_22)) = (int8_t)0;
		goto IL_0100;
	}

IL_00b1:
	{
		bool* L_23 = ___success2;
		*((int8_t*)(L_23)) = (int8_t)1;
		int32_t L_24 = ___uriKind1;
		V_1 = L_24;
		int32_t L_25 = V_1;
		switch (L_25)
		{
			case 0:
			{
				goto IL_00f3;
			}
			case 1:
			{
				goto IL_00cd;
			}
			case 2:
			{
				goto IL_00e0;
			}
		}
	}
	{
		goto IL_00f8;
	}

IL_00cd:
	{
		bool L_26 = Uri_get_IsAbsoluteUri_m3666899587(__this, /*hidden argument*/NULL);
		if (L_26)
		{
			goto IL_00db;
		}
	}
	{
		bool* L_27 = ___success2;
		*((int8_t*)(L_27)) = (int8_t)0;
	}

IL_00db:
	{
		goto IL_0100;
	}

IL_00e0:
	{
		bool L_28 = Uri_get_IsAbsoluteUri_m3666899587(__this, /*hidden argument*/NULL);
		if (!L_28)
		{
			goto IL_00ee;
		}
	}
	{
		bool* L_29 = ___success2;
		*((int8_t*)(L_29)) = (int8_t)0;
	}

IL_00ee:
	{
		goto IL_0100;
	}

IL_00f3:
	{
		goto IL_0100;
	}

IL_00f8:
	{
		bool* L_30 = ___success2;
		*((int8_t*)(L_30)) = (int8_t)0;
		goto IL_0100;
	}

IL_0100:
	{
		return;
	}
}
// System.Void System.Uri::.ctor(System.Uri,System.Uri)
extern "C"  void Uri__ctor_m253204164 (Uri_t100236324 * __this, Uri_t100236324 * ___baseUri0, Uri_t100236324 * ___relativeUri1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri__ctor_m253204164_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	Uri_t100236324 * G_B2_0 = NULL;
	Uri_t100236324 * G_B2_1 = NULL;
	Uri_t100236324 * G_B1_0 = NULL;
	Uri_t100236324 * G_B1_1 = NULL;
	String_t* G_B3_0 = NULL;
	Uri_t100236324 * G_B3_1 = NULL;
	Uri_t100236324 * G_B3_2 = NULL;
	{
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_0 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_scheme_3(L_0);
		String_t* L_1 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_host_4(L_1);
		__this->set_port_5((-1));
		String_t* L_2 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_path_6(L_2);
		String_t* L_3 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_query_7(L_3);
		String_t* L_4 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_fragment_8(L_4);
		String_t* L_5 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_userinfo_9(L_5);
		__this->set_isAbsoluteUri_12((bool)1);
		Object__ctor_m297566312(__this, /*hidden argument*/NULL);
		Uri_t100236324 * L_6 = ___baseUri0;
		Uri_t100236324 * L_7 = ___relativeUri1;
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		bool L_8 = Uri_op_Equality_m685520154(NULL /*static, unused*/, L_7, (Uri_t100236324 *)NULL, /*hidden argument*/NULL);
		G_B1_0 = L_6;
		G_B1_1 = __this;
		if (!L_8)
		{
			G_B2_0 = L_6;
			G_B2_1 = __this;
			goto IL_006e;
		}
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_9 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		G_B3_0 = L_9;
		G_B3_1 = G_B1_0;
		G_B3_2 = G_B1_1;
		goto IL_0074;
	}

IL_006e:
	{
		Uri_t100236324 * L_10 = ___relativeUri1;
		String_t* L_11 = Uri_get_OriginalString_m3715995233(L_10, /*hidden argument*/NULL);
		G_B3_0 = L_11;
		G_B3_1 = G_B2_0;
		G_B3_2 = G_B2_1;
	}

IL_0074:
	{
		Uri_Merge_m76373955(G_B3_2, G_B3_1, G_B3_0, /*hidden argument*/NULL);
		return;
	}
}
// System.Void System.Uri::.ctor(System.String,System.Boolean)
extern "C"  void Uri__ctor_m3577021606 (Uri_t100236324 * __this, String_t* ___uriString0, bool ___dontEscape1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri__ctor_m3577021606_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_0 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_scheme_3(L_0);
		String_t* L_1 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_host_4(L_1);
		__this->set_port_5((-1));
		String_t* L_2 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_path_6(L_2);
		String_t* L_3 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_query_7(L_3);
		String_t* L_4 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_fragment_8(L_4);
		String_t* L_5 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_userinfo_9(L_5);
		__this->set_isAbsoluteUri_12((bool)1);
		Object__ctor_m297566312(__this, /*hidden argument*/NULL);
		bool L_6 = ___dontEscape1;
		__this->set_userEscaped_14(L_6);
		String_t* L_7 = ___uriString0;
		__this->set_source_2(L_7);
		Uri_ParseUri_m2150795567(__this, 1, /*hidden argument*/NULL);
		bool L_8 = __this->get_isAbsoluteUri_12();
		if (L_8)
		{
			goto IL_0087;
		}
	}
	{
		String_t* L_9 = ___uriString0;
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_10 = String_Concat_m3937257545(NULL /*static, unused*/, _stringLiteral1833178994, L_9, /*hidden argument*/NULL);
		UriFormatException_t953270471 * L_11 = (UriFormatException_t953270471 *)il2cpp_codegen_object_new(UriFormatException_t953270471_il2cpp_TypeInfo_var);
		UriFormatException__ctor_m3083316541(L_11, L_10, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_11,Uri__ctor_m3577021606_RuntimeMethod_var);
	}

IL_0087:
	{
		return;
	}
}
// System.Void System.Uri::.ctor(System.Uri,System.String)
extern "C"  void Uri__ctor_m4293005803 (Uri_t100236324 * __this, Uri_t100236324 * ___baseUri0, String_t* ___relativeUri1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri__ctor_m4293005803_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_0 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_scheme_3(L_0);
		String_t* L_1 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_host_4(L_1);
		__this->set_port_5((-1));
		String_t* L_2 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_path_6(L_2);
		String_t* L_3 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_query_7(L_3);
		String_t* L_4 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_fragment_8(L_4);
		String_t* L_5 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_userinfo_9(L_5);
		__this->set_isAbsoluteUri_12((bool)1);
		Object__ctor_m297566312(__this, /*hidden argument*/NULL);
		Uri_t100236324 * L_6 = ___baseUri0;
		String_t* L_7 = ___relativeUri1;
		Uri_Merge_m76373955(__this, L_6, L_7, /*hidden argument*/NULL);
		return;
	}
}
// System.Void System.Uri::.cctor()
extern "C"  void Uri__cctor_m38080231 (RuntimeObject * __this /* static, unused */, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri__cctor_m38080231_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->set_hexUpperChars_19(_stringLiteral598647136);
		((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->set_SchemeDelimiter_20(_stringLiteral1057238085);
		((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->set_UriSchemeFile_21(_stringLiteral1629333464);
		((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->set_UriSchemeFtp_22(_stringLiteral228733076);
		((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->set_UriSchemeGopher_23(_stringLiteral2386815142);
		((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->set_UriSchemeHttp_24(_stringLiteral3140485902);
		((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->set_UriSchemeHttps_25(_stringLiteral1973861653);
		((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->set_UriSchemeMailto_26(_stringLiteral416809914);
		((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->set_UriSchemeNews_27(_stringLiteral15098073);
		((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->set_UriSchemeNntp_28(_stringLiteral3139830536);
		((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->set_UriSchemeNetPipe_29(_stringLiteral3041793228);
		((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->set_UriSchemeNetTcp_30(_stringLiteral1761547464);
		UriSchemeU5BU5D_t2082808316* L_0 = ((UriSchemeU5BU5D_t2082808316*)SZArrayNew(UriSchemeU5BU5D_t2082808316_il2cpp_TypeInfo_var, (uint32_t)8));
		String_t* L_1 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeHttp_24();
		String_t* L_2 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_SchemeDelimiter_20();
		UriScheme_t722425697  L_3;
		memset(&L_3, 0, sizeof(L_3));
		UriScheme__ctor_m1399779782((&L_3), L_1, L_2, ((int32_t)80), /*hidden argument*/NULL);
		*(UriScheme_t722425697 *)((L_0)->GetAddressAtUnchecked(static_cast<il2cpp_array_size_t>(0))) = L_3;
		UriSchemeU5BU5D_t2082808316* L_4 = L_0;
		String_t* L_5 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeHttps_25();
		String_t* L_6 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_SchemeDelimiter_20();
		UriScheme_t722425697  L_7;
		memset(&L_7, 0, sizeof(L_7));
		UriScheme__ctor_m1399779782((&L_7), L_5, L_6, ((int32_t)443), /*hidden argument*/NULL);
		*(UriScheme_t722425697 *)((L_4)->GetAddressAtUnchecked(static_cast<il2cpp_array_size_t>(1))) = L_7;
		UriSchemeU5BU5D_t2082808316* L_8 = L_4;
		String_t* L_9 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeFtp_22();
		String_t* L_10 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_SchemeDelimiter_20();
		UriScheme_t722425697  L_11;
		memset(&L_11, 0, sizeof(L_11));
		UriScheme__ctor_m1399779782((&L_11), L_9, L_10, ((int32_t)21), /*hidden argument*/NULL);
		*(UriScheme_t722425697 *)((L_8)->GetAddressAtUnchecked(static_cast<il2cpp_array_size_t>(2))) = L_11;
		UriSchemeU5BU5D_t2082808316* L_12 = L_8;
		String_t* L_13 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeFile_21();
		String_t* L_14 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_SchemeDelimiter_20();
		UriScheme_t722425697  L_15;
		memset(&L_15, 0, sizeof(L_15));
		UriScheme__ctor_m1399779782((&L_15), L_13, L_14, (-1), /*hidden argument*/NULL);
		*(UriScheme_t722425697 *)((L_12)->GetAddressAtUnchecked(static_cast<il2cpp_array_size_t>(3))) = L_15;
		UriSchemeU5BU5D_t2082808316* L_16 = L_12;
		String_t* L_17 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeMailto_26();
		UriScheme_t722425697  L_18;
		memset(&L_18, 0, sizeof(L_18));
		UriScheme__ctor_m1399779782((&L_18), L_17, _stringLiteral3452614550, ((int32_t)25), /*hidden argument*/NULL);
		*(UriScheme_t722425697 *)((L_16)->GetAddressAtUnchecked(static_cast<il2cpp_array_size_t>(4))) = L_18;
		UriSchemeU5BU5D_t2082808316* L_19 = L_16;
		String_t* L_20 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeNews_27();
		UriScheme_t722425697  L_21;
		memset(&L_21, 0, sizeof(L_21));
		UriScheme__ctor_m1399779782((&L_21), L_20, _stringLiteral3452614550, ((int32_t)119), /*hidden argument*/NULL);
		*(UriScheme_t722425697 *)((L_19)->GetAddressAtUnchecked(static_cast<il2cpp_array_size_t>(5))) = L_21;
		UriSchemeU5BU5D_t2082808316* L_22 = L_19;
		String_t* L_23 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeNntp_28();
		String_t* L_24 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_SchemeDelimiter_20();
		UriScheme_t722425697  L_25;
		memset(&L_25, 0, sizeof(L_25));
		UriScheme__ctor_m1399779782((&L_25), L_23, L_24, ((int32_t)119), /*hidden argument*/NULL);
		*(UriScheme_t722425697 *)((L_22)->GetAddressAtUnchecked(static_cast<il2cpp_array_size_t>(6))) = L_25;
		UriSchemeU5BU5D_t2082808316* L_26 = L_22;
		String_t* L_27 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeGopher_23();
		String_t* L_28 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_SchemeDelimiter_20();
		UriScheme_t722425697  L_29;
		memset(&L_29, 0, sizeof(L_29));
		UriScheme__ctor_m1399779782((&L_29), L_27, L_28, ((int32_t)70), /*hidden argument*/NULL);
		*(UriScheme_t722425697 *)((L_26)->GetAddressAtUnchecked(static_cast<il2cpp_array_size_t>(7))) = L_29;
		((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->set_schemes_31(L_26);
		return;
	}
}
// System.Void System.Uri::Merge(System.Uri,System.String)
extern "C"  void Uri_Merge_m76373955 (Uri_t100236324 * __this, Uri_t100236324 * ___baseUri0, String_t* ___relativeUri1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_Merge_m76373955_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	{
		Uri_t100236324 * L_0 = ___baseUri0;
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		bool L_1 = Uri_op_Equality_m685520154(NULL /*static, unused*/, L_0, (Uri_t100236324 *)NULL, /*hidden argument*/NULL);
		if (!L_1)
		{
			goto IL_0017;
		}
	}
	{
		ArgumentNullException_t1615371798 * L_2 = (ArgumentNullException_t1615371798 *)il2cpp_codegen_object_new(ArgumentNullException_t1615371798_il2cpp_TypeInfo_var);
		ArgumentNullException__ctor_m1170824041(L_2, _stringLiteral4058229981, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_2,Uri_Merge_m76373955_RuntimeMethod_var);
	}

IL_0017:
	{
		Uri_t100236324 * L_3 = ___baseUri0;
		bool L_4 = Uri_get_IsAbsoluteUri_m3666899587(L_3, /*hidden argument*/NULL);
		if (L_4)
		{
			goto IL_002d;
		}
	}
	{
		ArgumentOutOfRangeException_t777629997 * L_5 = (ArgumentOutOfRangeException_t777629997 *)il2cpp_codegen_object_new(ArgumentOutOfRangeException_t777629997_il2cpp_TypeInfo_var);
		ArgumentOutOfRangeException__ctor_m3628145864(L_5, _stringLiteral4058229981, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_5,Uri_Merge_m76373955_RuntimeMethod_var);
	}

IL_002d:
	{
		String_t* L_6 = ___relativeUri1;
		if (L_6)
		{
			goto IL_003a;
		}
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_7 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		___relativeUri1 = L_7;
	}

IL_003a:
	{
		String_t* L_8 = ___relativeUri1;
		int32_t L_9 = String_get_Length_m3847582255(L_8, /*hidden argument*/NULL);
		if ((((int32_t)L_9) < ((int32_t)2)))
		{
			goto IL_0071;
		}
	}
	{
		String_t* L_10 = ___relativeUri1;
		Il2CppChar L_11 = String_get_Chars_m2986988803(L_10, 0, /*hidden argument*/NULL);
		if ((!(((uint32_t)L_11) == ((uint32_t)((int32_t)92)))))
		{
			goto IL_0071;
		}
	}
	{
		String_t* L_12 = ___relativeUri1;
		Il2CppChar L_13 = String_get_Chars_m2986988803(L_12, 1, /*hidden argument*/NULL);
		if ((!(((uint32_t)L_13) == ((uint32_t)((int32_t)92)))))
		{
			goto IL_0071;
		}
	}
	{
		String_t* L_14 = ___relativeUri1;
		__this->set_source_2(L_14);
		Uri_ParseUri_m2150795567(__this, 1, /*hidden argument*/NULL);
		return;
	}

IL_0071:
	{
		String_t* L_15 = ___relativeUri1;
		int32_t L_16 = String_IndexOf_m363431711(L_15, ((int32_t)58), /*hidden argument*/NULL);
		V_0 = L_16;
		int32_t L_17 = V_0;
		if ((((int32_t)L_17) == ((int32_t)(-1))))
		{
			goto IL_0107;
		}
	}
	{
		String_t* L_18 = ___relativeUri1;
		CharU5BU5D_t3528271667* L_19 = ((CharU5BU5D_t3528271667*)SZArrayNew(CharU5BU5D_t3528271667_il2cpp_TypeInfo_var, (uint32_t)3));
		(L_19)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(0), (Il2CppChar)((int32_t)47));
		CharU5BU5D_t3528271667* L_20 = L_19;
		(L_20)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(1), (Il2CppChar)((int32_t)92));
		CharU5BU5D_t3528271667* L_21 = L_20;
		(L_21)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(2), (Il2CppChar)((int32_t)63));
		int32_t L_22 = String_IndexOfAny_m4159774896(L_18, L_21, /*hidden argument*/NULL);
		V_1 = L_22;
		int32_t L_23 = V_1;
		int32_t L_24 = V_0;
		if ((((int32_t)L_23) > ((int32_t)L_24)))
		{
			goto IL_00ab;
		}
	}
	{
		int32_t L_25 = V_1;
		if ((((int32_t)L_25) >= ((int32_t)0)))
		{
			goto IL_0107;
		}
	}

IL_00ab:
	{
		Uri_t100236324 * L_26 = ___baseUri0;
		String_t* L_27 = Uri_get_Scheme_m2109479391(L_26, /*hidden argument*/NULL);
		String_t* L_28 = ___relativeUri1;
		int32_t L_29 = V_0;
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		int32_t L_30 = String_CompareOrdinal_m1012192092(NULL /*static, unused*/, L_27, 0, L_28, 0, L_29, /*hidden argument*/NULL);
		if (L_30)
		{
			goto IL_00ed;
		}
	}
	{
		Uri_t100236324 * L_31 = ___baseUri0;
		String_t* L_32 = Uri_get_Scheme_m2109479391(L_31, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		bool L_33 = Uri_IsPredefinedScheme_m1188665625(NULL /*static, unused*/, L_32, /*hidden argument*/NULL);
		if (!L_33)
		{
			goto IL_00ed;
		}
	}
	{
		String_t* L_34 = ___relativeUri1;
		int32_t L_35 = String_get_Length_m3847582255(L_34, /*hidden argument*/NULL);
		int32_t L_36 = V_0;
		if ((((int32_t)L_35) <= ((int32_t)((int32_t)il2cpp_codegen_add((int32_t)L_36, (int32_t)1)))))
		{
			goto IL_00fc;
		}
	}
	{
		String_t* L_37 = ___relativeUri1;
		int32_t L_38 = V_0;
		Il2CppChar L_39 = String_get_Chars_m2986988803(L_37, ((int32_t)il2cpp_codegen_add((int32_t)L_38, (int32_t)1)), /*hidden argument*/NULL);
		if ((!(((uint32_t)L_39) == ((uint32_t)((int32_t)47)))))
		{
			goto IL_00fc;
		}
	}

IL_00ed:
	{
		String_t* L_40 = ___relativeUri1;
		__this->set_source_2(L_40);
		Uri_ParseUri_m2150795567(__this, 1, /*hidden argument*/NULL);
		return;
	}

IL_00fc:
	{
		String_t* L_41 = ___relativeUri1;
		int32_t L_42 = V_0;
		String_t* L_43 = String_Substring_m2848979100(L_41, ((int32_t)il2cpp_codegen_add((int32_t)L_42, (int32_t)1)), /*hidden argument*/NULL);
		___relativeUri1 = L_43;
	}

IL_0107:
	{
		Uri_t100236324 * L_44 = ___baseUri0;
		String_t* L_45 = L_44->get_scheme_3();
		__this->set_scheme_3(L_45);
		Uri_t100236324 * L_46 = ___baseUri0;
		String_t* L_47 = L_46->get_host_4();
		__this->set_host_4(L_47);
		Uri_t100236324 * L_48 = ___baseUri0;
		int32_t L_49 = L_48->get_port_5();
		__this->set_port_5(L_49);
		Uri_t100236324 * L_50 = ___baseUri0;
		String_t* L_51 = L_50->get_userinfo_9();
		__this->set_userinfo_9(L_51);
		Uri_t100236324 * L_52 = ___baseUri0;
		bool L_53 = L_52->get_isUnc_10();
		__this->set_isUnc_10(L_53);
		Uri_t100236324 * L_54 = ___baseUri0;
		bool L_55 = L_54->get_isUnixFilePath_1();
		__this->set_isUnixFilePath_1(L_55);
		Uri_t100236324 * L_56 = ___baseUri0;
		bool L_57 = L_56->get_isOpaquePart_11();
		__this->set_isOpaquePart_11(L_57);
		String_t* L_58 = ___relativeUri1;
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_59 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		bool L_60 = String_op_Equality_m920492651(NULL /*static, unused*/, L_58, L_59, /*hidden argument*/NULL);
		if (!L_60)
		{
			goto IL_0190;
		}
	}
	{
		Uri_t100236324 * L_61 = ___baseUri0;
		String_t* L_62 = L_61->get_path_6();
		__this->set_path_6(L_62);
		Uri_t100236324 * L_63 = ___baseUri0;
		String_t* L_64 = L_63->get_query_7();
		__this->set_query_7(L_64);
		Uri_t100236324 * L_65 = ___baseUri0;
		String_t* L_66 = L_65->get_fragment_8();
		__this->set_fragment_8(L_66);
		return;
	}

IL_0190:
	{
		String_t* L_67 = ___relativeUri1;
		int32_t L_68 = String_IndexOf_m363431711(L_67, ((int32_t)35), /*hidden argument*/NULL);
		V_0 = L_68;
		int32_t L_69 = V_0;
		if ((((int32_t)L_69) == ((int32_t)(-1))))
		{
			goto IL_01e5;
		}
	}
	{
		bool L_70 = __this->get_userEscaped_14();
		if (!L_70)
		{
			goto IL_01bd;
		}
	}
	{
		String_t* L_71 = ___relativeUri1;
		int32_t L_72 = V_0;
		String_t* L_73 = String_Substring_m2848979100(L_71, L_72, /*hidden argument*/NULL);
		__this->set_fragment_8(L_73);
		goto IL_01db;
	}

IL_01bd:
	{
		String_t* L_74 = ___relativeUri1;
		int32_t L_75 = V_0;
		String_t* L_76 = String_Substring_m2848979100(L_74, ((int32_t)il2cpp_codegen_add((int32_t)L_75, (int32_t)1)), /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_77 = Uri_EscapeString_m2061933484(NULL /*static, unused*/, L_76, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_78 = String_Concat_m3937257545(NULL /*static, unused*/, _stringLiteral3452614525, L_77, /*hidden argument*/NULL);
		__this->set_fragment_8(L_78);
	}

IL_01db:
	{
		String_t* L_79 = ___relativeUri1;
		int32_t L_80 = V_0;
		String_t* L_81 = String_Substring_m1610150815(L_79, 0, L_80, /*hidden argument*/NULL);
		___relativeUri1 = L_81;
	}

IL_01e5:
	{
		String_t* L_82 = ___relativeUri1;
		int32_t L_83 = String_IndexOf_m363431711(L_82, ((int32_t)63), /*hidden argument*/NULL);
		V_0 = L_83;
		int32_t L_84 = V_0;
		if ((((int32_t)L_84) == ((int32_t)(-1))))
		{
			goto IL_0228;
		}
	}
	{
		String_t* L_85 = ___relativeUri1;
		int32_t L_86 = V_0;
		String_t* L_87 = String_Substring_m2848979100(L_85, L_86, /*hidden argument*/NULL);
		__this->set_query_7(L_87);
		bool L_88 = __this->get_userEscaped_14();
		if (L_88)
		{
			goto IL_021e;
		}
	}
	{
		String_t* L_89 = __this->get_query_7();
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_90 = Uri_EscapeString_m2061933484(NULL /*static, unused*/, L_89, /*hidden argument*/NULL);
		__this->set_query_7(L_90);
	}

IL_021e:
	{
		String_t* L_91 = ___relativeUri1;
		int32_t L_92 = V_0;
		String_t* L_93 = String_Substring_m1610150815(L_91, 0, L_92, /*hidden argument*/NULL);
		___relativeUri1 = L_93;
	}

IL_0228:
	{
		String_t* L_94 = ___relativeUri1;
		int32_t L_95 = String_get_Length_m3847582255(L_94, /*hidden argument*/NULL);
		if ((((int32_t)L_95) <= ((int32_t)0)))
		{
			goto IL_02a1;
		}
	}
	{
		String_t* L_96 = ___relativeUri1;
		Il2CppChar L_97 = String_get_Chars_m2986988803(L_96, 0, /*hidden argument*/NULL);
		if ((!(((uint32_t)L_97) == ((uint32_t)((int32_t)47)))))
		{
			goto IL_02a1;
		}
	}
	{
		String_t* L_98 = ___relativeUri1;
		int32_t L_99 = String_get_Length_m3847582255(L_98, /*hidden argument*/NULL);
		if ((((int32_t)L_99) <= ((int32_t)1)))
		{
			goto IL_027d;
		}
	}
	{
		String_t* L_100 = ___relativeUri1;
		Il2CppChar L_101 = String_get_Chars_m2986988803(L_100, 1, /*hidden argument*/NULL);
		if ((!(((uint32_t)L_101) == ((uint32_t)((int32_t)47)))))
		{
			goto IL_027d;
		}
	}
	{
		String_t* L_102 = __this->get_scheme_3();
		Il2CppChar L_103 = ((Il2CppChar)((int32_t)58));
		RuntimeObject * L_104 = Box(Char_t3634460470_il2cpp_TypeInfo_var, &L_103);
		String_t* L_105 = ___relativeUri1;
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_106 = String_Concat_m1715369213(NULL /*static, unused*/, L_102, L_104, L_105, /*hidden argument*/NULL);
		__this->set_source_2(L_106);
		Uri_ParseUri_m2150795567(__this, 1, /*hidden argument*/NULL);
		return;
	}

IL_027d:
	{
		String_t* L_107 = ___relativeUri1;
		__this->set_path_6(L_107);
		bool L_108 = __this->get_userEscaped_14();
		if (L_108)
		{
			goto IL_02a0;
		}
	}
	{
		String_t* L_109 = __this->get_path_6();
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_110 = Uri_EscapeString_m2061933484(NULL /*static, unused*/, L_109, /*hidden argument*/NULL);
		__this->set_path_6(L_110);
	}

IL_02a0:
	{
		return;
	}

IL_02a1:
	{
		Uri_t100236324 * L_111 = ___baseUri0;
		String_t* L_112 = L_111->get_path_6();
		__this->set_path_6(L_112);
		String_t* L_113 = ___relativeUri1;
		int32_t L_114 = String_get_Length_m3847582255(L_113, /*hidden argument*/NULL);
		if ((((int32_t)L_114) > ((int32_t)0)))
		{
			goto IL_02ca;
		}
	}
	{
		String_t* L_115 = __this->get_query_7();
		int32_t L_116 = String_get_Length_m3847582255(L_115, /*hidden argument*/NULL);
		if ((((int32_t)L_116) <= ((int32_t)0)))
		{
			goto IL_02f4;
		}
	}

IL_02ca:
	{
		String_t* L_117 = __this->get_path_6();
		int32_t L_118 = String_LastIndexOf_m3451222878(L_117, ((int32_t)47), /*hidden argument*/NULL);
		V_0 = L_118;
		int32_t L_119 = V_0;
		if ((((int32_t)L_119) < ((int32_t)0)))
		{
			goto IL_02f4;
		}
	}
	{
		String_t* L_120 = __this->get_path_6();
		int32_t L_121 = V_0;
		String_t* L_122 = String_Substring_m1610150815(L_120, 0, ((int32_t)il2cpp_codegen_add((int32_t)L_121, (int32_t)1)), /*hidden argument*/NULL);
		__this->set_path_6(L_122);
	}

IL_02f4:
	{
		String_t* L_123 = ___relativeUri1;
		int32_t L_124 = String_get_Length_m3847582255(L_123, /*hidden argument*/NULL);
		if (L_124)
		{
			goto IL_0300;
		}
	}
	{
		return;
	}

IL_0300:
	{
		String_t* L_125 = __this->get_path_6();
		String_t* L_126 = ___relativeUri1;
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_127 = String_Concat_m3937257545(NULL /*static, unused*/, L_125, L_126, /*hidden argument*/NULL);
		__this->set_path_6(L_127);
		V_2 = 0;
	}

IL_0314:
	{
		String_t* L_128 = __this->get_path_6();
		int32_t L_129 = V_2;
		int32_t L_130 = String_IndexOf_m3406607758(L_128, _stringLiteral3450582914, L_129, /*hidden argument*/NULL);
		V_0 = L_130;
		int32_t L_131 = V_0;
		if ((!(((uint32_t)L_131) == ((uint32_t)(-1)))))
		{
			goto IL_0332;
		}
	}
	{
		goto IL_0386;
	}

IL_0332:
	{
		int32_t L_132 = V_0;
		if (L_132)
		{
			goto IL_0350;
		}
	}
	{
		String_t* L_133 = __this->get_path_6();
		String_t* L_134 = String_Remove_m562998446(L_133, 0, 2, /*hidden argument*/NULL);
		__this->set_path_6(L_134);
		goto IL_0381;
	}

IL_0350:
	{
		String_t* L_135 = __this->get_path_6();
		int32_t L_136 = V_0;
		Il2CppChar L_137 = String_get_Chars_m2986988803(L_135, ((int32_t)il2cpp_codegen_subtract((int32_t)L_136, (int32_t)1)), /*hidden argument*/NULL);
		if ((((int32_t)L_137) == ((int32_t)((int32_t)46))))
		{
			goto IL_037d;
		}
	}
	{
		String_t* L_138 = __this->get_path_6();
		int32_t L_139 = V_0;
		String_t* L_140 = String_Remove_m562998446(L_138, L_139, 2, /*hidden argument*/NULL);
		__this->set_path_6(L_140);
		goto IL_0381;
	}

IL_037d:
	{
		int32_t L_141 = V_0;
		V_2 = ((int32_t)il2cpp_codegen_add((int32_t)L_141, (int32_t)1));
	}

IL_0381:
	{
		goto IL_0314;
	}

IL_0386:
	{
		String_t* L_142 = __this->get_path_6();
		int32_t L_143 = String_get_Length_m3847582255(L_142, /*hidden argument*/NULL);
		if ((((int32_t)L_143) <= ((int32_t)1)))
		{
			goto IL_03f4;
		}
	}
	{
		String_t* L_144 = __this->get_path_6();
		String_t* L_145 = __this->get_path_6();
		int32_t L_146 = String_get_Length_m3847582255(L_145, /*hidden argument*/NULL);
		Il2CppChar L_147 = String_get_Chars_m2986988803(L_144, ((int32_t)il2cpp_codegen_subtract((int32_t)L_146, (int32_t)1)), /*hidden argument*/NULL);
		if ((!(((uint32_t)L_147) == ((uint32_t)((int32_t)46)))))
		{
			goto IL_03f4;
		}
	}
	{
		String_t* L_148 = __this->get_path_6();
		String_t* L_149 = __this->get_path_6();
		int32_t L_150 = String_get_Length_m3847582255(L_149, /*hidden argument*/NULL);
		Il2CppChar L_151 = String_get_Chars_m2986988803(L_148, ((int32_t)il2cpp_codegen_subtract((int32_t)L_150, (int32_t)2)), /*hidden argument*/NULL);
		if ((!(((uint32_t)L_151) == ((uint32_t)((int32_t)47)))))
		{
			goto IL_03f4;
		}
	}
	{
		String_t* L_152 = __this->get_path_6();
		String_t* L_153 = __this->get_path_6();
		int32_t L_154 = String_get_Length_m3847582255(L_153, /*hidden argument*/NULL);
		String_t* L_155 = String_Remove_m562998446(L_152, ((int32_t)il2cpp_codegen_subtract((int32_t)L_154, (int32_t)1)), 1, /*hidden argument*/NULL);
		__this->set_path_6(L_155);
	}

IL_03f4:
	{
		V_2 = 0;
	}

IL_03f6:
	{
		String_t* L_156 = __this->get_path_6();
		int32_t L_157 = V_2;
		int32_t L_158 = String_IndexOf_m3406607758(L_156, _stringLiteral3139614613, L_157, /*hidden argument*/NULL);
		V_0 = L_158;
		int32_t L_159 = V_0;
		if ((!(((uint32_t)L_159) == ((uint32_t)(-1)))))
		{
			goto IL_0414;
		}
	}
	{
		goto IL_048b;
	}

IL_0414:
	{
		int32_t L_160 = V_0;
		if (L_160)
		{
			goto IL_0421;
		}
	}
	{
		V_2 = 3;
		goto IL_03f6;
	}

IL_0421:
	{
		String_t* L_161 = __this->get_path_6();
		int32_t L_162 = V_0;
		int32_t L_163 = String_LastIndexOf_m578673845(L_161, ((int32_t)47), ((int32_t)il2cpp_codegen_subtract((int32_t)L_162, (int32_t)1)), /*hidden argument*/NULL);
		V_3 = L_163;
		int32_t L_164 = V_3;
		if ((!(((uint32_t)L_164) == ((uint32_t)(-1)))))
		{
			goto IL_0442;
		}
	}
	{
		int32_t L_165 = V_0;
		V_2 = ((int32_t)il2cpp_codegen_add((int32_t)L_165, (int32_t)1));
		goto IL_0486;
	}

IL_0442:
	{
		String_t* L_166 = __this->get_path_6();
		int32_t L_167 = V_3;
		int32_t L_168 = V_0;
		int32_t L_169 = V_3;
		String_t* L_170 = String_Substring_m1610150815(L_166, ((int32_t)il2cpp_codegen_add((int32_t)L_167, (int32_t)1)), ((int32_t)il2cpp_codegen_subtract((int32_t)((int32_t)il2cpp_codegen_subtract((int32_t)L_168, (int32_t)L_169)), (int32_t)1)), /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_171 = String_op_Inequality_m215368492(NULL /*static, unused*/, L_170, _stringLiteral3450648450, /*hidden argument*/NULL);
		if (!L_171)
		{
			goto IL_0482;
		}
	}
	{
		String_t* L_172 = __this->get_path_6();
		int32_t L_173 = V_3;
		int32_t L_174 = V_0;
		int32_t L_175 = V_3;
		String_t* L_176 = String_Remove_m562998446(L_172, ((int32_t)il2cpp_codegen_add((int32_t)L_173, (int32_t)1)), ((int32_t)il2cpp_codegen_add((int32_t)((int32_t)il2cpp_codegen_subtract((int32_t)L_174, (int32_t)L_175)), (int32_t)3)), /*hidden argument*/NULL);
		__this->set_path_6(L_176);
		goto IL_0486;
	}

IL_0482:
	{
		int32_t L_177 = V_0;
		V_2 = ((int32_t)il2cpp_codegen_add((int32_t)L_177, (int32_t)1));
	}

IL_0486:
	{
		goto IL_03f6;
	}

IL_048b:
	{
		String_t* L_178 = __this->get_path_6();
		int32_t L_179 = String_get_Length_m3847582255(L_178, /*hidden argument*/NULL);
		if ((((int32_t)L_179) <= ((int32_t)3)))
		{
			goto IL_0522;
		}
	}
	{
		String_t* L_180 = __this->get_path_6();
		bool L_181 = String_EndsWith_m1901926500(L_180, _stringLiteral2623387541, /*hidden argument*/NULL);
		if (!L_181)
		{
			goto IL_0522;
		}
	}
	{
		String_t* L_182 = __this->get_path_6();
		String_t* L_183 = __this->get_path_6();
		int32_t L_184 = String_get_Length_m3847582255(L_183, /*hidden argument*/NULL);
		int32_t L_185 = String_LastIndexOf_m578673845(L_182, ((int32_t)47), ((int32_t)il2cpp_codegen_subtract((int32_t)L_184, (int32_t)4)), /*hidden argument*/NULL);
		V_0 = L_185;
		int32_t L_186 = V_0;
		if ((((int32_t)L_186) == ((int32_t)(-1))))
		{
			goto IL_0522;
		}
	}
	{
		String_t* L_187 = __this->get_path_6();
		int32_t L_188 = V_0;
		String_t* L_189 = __this->get_path_6();
		int32_t L_190 = String_get_Length_m3847582255(L_189, /*hidden argument*/NULL);
		int32_t L_191 = V_0;
		String_t* L_192 = String_Substring_m1610150815(L_187, ((int32_t)il2cpp_codegen_add((int32_t)L_188, (int32_t)1)), ((int32_t)il2cpp_codegen_subtract((int32_t)((int32_t)il2cpp_codegen_subtract((int32_t)L_190, (int32_t)L_191)), (int32_t)4)), /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_193 = String_op_Inequality_m215368492(NULL /*static, unused*/, L_192, _stringLiteral3450648450, /*hidden argument*/NULL);
		if (!L_193)
		{
			goto IL_0522;
		}
	}
	{
		String_t* L_194 = __this->get_path_6();
		int32_t L_195 = V_0;
		String_t* L_196 = __this->get_path_6();
		int32_t L_197 = String_get_Length_m3847582255(L_196, /*hidden argument*/NULL);
		int32_t L_198 = V_0;
		String_t* L_199 = String_Remove_m562998446(L_194, ((int32_t)il2cpp_codegen_add((int32_t)L_195, (int32_t)1)), ((int32_t)il2cpp_codegen_subtract((int32_t)((int32_t)il2cpp_codegen_subtract((int32_t)L_197, (int32_t)L_198)), (int32_t)1)), /*hidden argument*/NULL);
		__this->set_path_6(L_199);
	}

IL_0522:
	{
		bool L_200 = __this->get_userEscaped_14();
		if (L_200)
		{
			goto IL_053e;
		}
	}
	{
		String_t* L_201 = __this->get_path_6();
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_202 = Uri_EscapeString_m2061933484(NULL /*static, unused*/, L_201, /*hidden argument*/NULL);
		__this->set_path_6(L_202);
	}

IL_053e:
	{
		return;
	}
}
// System.String System.Uri::get_AbsolutePath()
extern "C"  String_t* Uri_get_AbsolutePath_m590948575 (Uri_t100236324 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_get_AbsolutePath_m590948575_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	String_t* V_0 = NULL;
	String_t* V_1 = NULL;
	Dictionary_2_t2736202052 * V_2 = NULL;
	int32_t V_3 = 0;
	{
		Uri_EnsureAbsoluteUri_m2231483494(__this, /*hidden argument*/NULL);
		String_t* L_0 = Uri_get_Scheme_m2109479391(__this, /*hidden argument*/NULL);
		V_1 = L_0;
		String_t* L_1 = V_1;
		if (!L_1)
		{
			goto IL_0066;
		}
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		Dictionary_2_t2736202052 * L_2 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_U3CU3Ef__switchU24map12_33();
		if (L_2)
		{
			goto IL_0042;
		}
	}
	{
		Dictionary_2_t2736202052 * L_3 = (Dictionary_2_t2736202052 *)il2cpp_codegen_object_new(Dictionary_2_t2736202052_il2cpp_TypeInfo_var);
		Dictionary_2__ctor_m2392909825(L_3, 2, /*hidden argument*/Dictionary_2__ctor_m2392909825_RuntimeMethod_var);
		V_2 = L_3;
		Dictionary_2_t2736202052 * L_4 = V_2;
		Dictionary_2_Add_m282647386(L_4, _stringLiteral416809914, 0, /*hidden argument*/Dictionary_2_Add_m282647386_RuntimeMethod_var);
		Dictionary_2_t2736202052 * L_5 = V_2;
		Dictionary_2_Add_m282647386(L_5, _stringLiteral1629333464, 0, /*hidden argument*/Dictionary_2_Add_m282647386_RuntimeMethod_var);
		Dictionary_2_t2736202052 * L_6 = V_2;
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->set_U3CU3Ef__switchU24map12_33(L_6);
	}

IL_0042:
	{
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		Dictionary_2_t2736202052 * L_7 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_U3CU3Ef__switchU24map12_33();
		String_t* L_8 = V_1;
		bool L_9 = Dictionary_2_TryGetValue_m1013208020(L_7, L_8, (&V_3), /*hidden argument*/Dictionary_2_TryGetValue_m1013208020_RuntimeMethod_var);
		if (!L_9)
		{
			goto IL_0066;
		}
	}
	{
		int32_t L_10 = V_3;
		if (!L_10)
		{
			goto IL_005f;
		}
	}
	{
		goto IL_0066;
	}

IL_005f:
	{
		String_t* L_11 = __this->get_path_6();
		return L_11;
	}

IL_0066:
	{
		String_t* L_12 = __this->get_path_6();
		int32_t L_13 = String_get_Length_m3847582255(L_12, /*hidden argument*/NULL);
		if (L_13)
		{
			goto IL_00a4;
		}
	}
	{
		String_t* L_14 = Uri_get_Scheme_m2109479391(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_15 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_SchemeDelimiter_20();
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_16 = String_Concat_m3937257545(NULL /*static, unused*/, L_14, L_15, /*hidden argument*/NULL);
		V_0 = L_16;
		String_t* L_17 = __this->get_path_6();
		String_t* L_18 = V_0;
		bool L_19 = String_StartsWith_m1759067526(L_17, L_18, /*hidden argument*/NULL);
		if (!L_19)
		{
			goto IL_009e;
		}
	}
	{
		return _stringLiteral3452614529;
	}

IL_009e:
	{
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_20 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		return L_20;
	}

IL_00a4:
	{
		String_t* L_21 = __this->get_path_6();
		return L_21;
	}
}
// System.String System.Uri::get_AbsoluteUri()
extern "C"  String_t* Uri_get_AbsoluteUri_m2582056986 (Uri_t100236324 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_get_AbsoluteUri_m2582056986_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		Uri_EnsureAbsoluteUri_m2231483494(__this, /*hidden argument*/NULL);
		String_t* L_0 = __this->get_cachedAbsoluteUri_15();
		if (L_0)
		{
			goto IL_006e;
		}
	}
	{
		String_t* L_1 = Uri_GetLeftPart_m3979111399(__this, 2, /*hidden argument*/NULL);
		__this->set_cachedAbsoluteUri_15(L_1);
		String_t* L_2 = __this->get_query_7();
		int32_t L_3 = String_get_Length_m3847582255(L_2, /*hidden argument*/NULL);
		if ((((int32_t)L_3) <= ((int32_t)0)))
		{
			goto IL_0046;
		}
	}
	{
		String_t* L_4 = __this->get_cachedAbsoluteUri_15();
		String_t* L_5 = __this->get_query_7();
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_6 = String_Concat_m3937257545(NULL /*static, unused*/, L_4, L_5, /*hidden argument*/NULL);
		__this->set_cachedAbsoluteUri_15(L_6);
	}

IL_0046:
	{
		String_t* L_7 = __this->get_fragment_8();
		int32_t L_8 = String_get_Length_m3847582255(L_7, /*hidden argument*/NULL);
		if ((((int32_t)L_8) <= ((int32_t)0)))
		{
			goto IL_006e;
		}
	}
	{
		String_t* L_9 = __this->get_cachedAbsoluteUri_15();
		String_t* L_10 = __this->get_fragment_8();
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_11 = String_Concat_m3937257545(NULL /*static, unused*/, L_9, L_10, /*hidden argument*/NULL);
		__this->set_cachedAbsoluteUri_15(L_11);
	}

IL_006e:
	{
		String_t* L_12 = __this->get_cachedAbsoluteUri_15();
		return L_12;
	}
}
// System.String System.Uri::get_Authority()
extern "C"  String_t* Uri_get_Authority_m3816772302 (Uri_t100236324 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_get_Authority_m3816772302_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	String_t* G_B3_0 = NULL;
	{
		Uri_EnsureAbsoluteUri_m2231483494(__this, /*hidden argument*/NULL);
		String_t* L_0 = Uri_get_Scheme_m2109479391(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		int32_t L_1 = Uri_GetDefaultPort_m2547653357(NULL /*static, unused*/, L_0, /*hidden argument*/NULL);
		int32_t L_2 = __this->get_port_5();
		if ((!(((uint32_t)L_1) == ((uint32_t)L_2))))
		{
			goto IL_0027;
		}
	}
	{
		String_t* L_3 = __this->get_host_4();
		G_B3_0 = L_3;
		goto IL_0042;
	}

IL_0027:
	{
		String_t* L_4 = __this->get_host_4();
		int32_t L_5 = __this->get_port_5();
		int32_t L_6 = L_5;
		RuntimeObject * L_7 = Box(Int32_t2950945753_il2cpp_TypeInfo_var, &L_6);
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_8 = String_Concat_m1715369213(NULL /*static, unused*/, L_4, _stringLiteral3452614550, L_7, /*hidden argument*/NULL);
		G_B3_0 = L_8;
	}

IL_0042:
	{
		return G_B3_0;
	}
}
// System.String System.Uri::get_Fragment()
extern "C"  String_t* Uri_get_Fragment_m575158891 (Uri_t100236324 * __this, const RuntimeMethod* method)
{
	{
		Uri_EnsureAbsoluteUri_m2231483494(__this, /*hidden argument*/NULL);
		String_t* L_0 = __this->get_fragment_8();
		return L_0;
	}
}
// System.String System.Uri::get_Host()
extern "C"  String_t* Uri_get_Host_m255565830 (Uri_t100236324 * __this, const RuntimeMethod* method)
{
	{
		Uri_EnsureAbsoluteUri_m2231483494(__this, /*hidden argument*/NULL);
		String_t* L_0 = __this->get_host_4();
		return L_0;
	}
}
// System.UriHostNameType System.Uri::get_HostNameType()
extern "C"  int32_t Uri_get_HostNameType_m1143766868 (Uri_t100236324 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_get_HostNameType_m1143766868_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	String_t* V_1 = NULL;
	Dictionary_2_t2736202052 * V_2 = NULL;
	int32_t V_3 = 0;
	int32_t G_B12_0 = 0;
	{
		Uri_EnsureAbsoluteUri_m2231483494(__this, /*hidden argument*/NULL);
		String_t* L_0 = Uri_get_Host_m255565830(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		int32_t L_1 = Uri_CheckHostName_m2213216182(NULL /*static, unused*/, L_0, /*hidden argument*/NULL);
		V_0 = L_1;
		int32_t L_2 = V_0;
		if (!L_2)
		{
			goto IL_001a;
		}
	}
	{
		int32_t L_3 = V_0;
		return L_3;
	}

IL_001a:
	{
		String_t* L_4 = Uri_get_Scheme_m2109479391(__this, /*hidden argument*/NULL);
		V_1 = L_4;
		String_t* L_5 = V_1;
		if (!L_5)
		{
			goto IL_0069;
		}
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		Dictionary_2_t2736202052 * L_6 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_U3CU3Ef__switchU24map13_34();
		if (L_6)
		{
			goto IL_004a;
		}
	}
	{
		Dictionary_2_t2736202052 * L_7 = (Dictionary_2_t2736202052 *)il2cpp_codegen_object_new(Dictionary_2_t2736202052_il2cpp_TypeInfo_var);
		Dictionary_2__ctor_m2392909825(L_7, 1, /*hidden argument*/Dictionary_2__ctor_m2392909825_RuntimeMethod_var);
		V_2 = L_7;
		Dictionary_2_t2736202052 * L_8 = V_2;
		Dictionary_2_Add_m282647386(L_8, _stringLiteral416809914, 0, /*hidden argument*/Dictionary_2_Add_m282647386_RuntimeMethod_var);
		Dictionary_2_t2736202052 * L_9 = V_2;
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->set_U3CU3Ef__switchU24map13_34(L_9);
	}

IL_004a:
	{
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		Dictionary_2_t2736202052 * L_10 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_U3CU3Ef__switchU24map13_34();
		String_t* L_11 = V_1;
		bool L_12 = Dictionary_2_TryGetValue_m1013208020(L_10, L_11, (&V_3), /*hidden argument*/Dictionary_2_TryGetValue_m1013208020_RuntimeMethod_var);
		if (!L_12)
		{
			goto IL_0069;
		}
	}
	{
		int32_t L_13 = V_3;
		if (!L_13)
		{
			goto IL_0067;
		}
	}
	{
		goto IL_0069;
	}

IL_0067:
	{
		return (int32_t)(1);
	}

IL_0069:
	{
		bool L_14 = Uri_get_IsFile_m2450018824(__this, /*hidden argument*/NULL);
		if (!L_14)
		{
			goto IL_007a;
		}
	}
	{
		G_B12_0 = 1;
		goto IL_007b;
	}

IL_007a:
	{
		int32_t L_15 = V_0;
		G_B12_0 = ((int32_t)(L_15));
	}

IL_007b:
	{
		return (int32_t)(G_B12_0);
	}
}
// System.Boolean System.Uri::get_IsDefaultPort()
extern "C"  bool Uri_get_IsDefaultPort_m3984463462 (Uri_t100236324 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_get_IsDefaultPort_m3984463462_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		Uri_EnsureAbsoluteUri_m2231483494(__this, /*hidden argument*/NULL);
		String_t* L_0 = Uri_get_Scheme_m2109479391(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		int32_t L_1 = Uri_GetDefaultPort_m2547653357(NULL /*static, unused*/, L_0, /*hidden argument*/NULL);
		int32_t L_2 = __this->get_port_5();
		return (bool)((((int32_t)L_1) == ((int32_t)L_2))? 1 : 0);
	}
}
// System.Boolean System.Uri::get_IsFile()
extern "C"  bool Uri_get_IsFile_m2450018824 (Uri_t100236324 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_get_IsFile_m2450018824_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		Uri_EnsureAbsoluteUri_m2231483494(__this, /*hidden argument*/NULL);
		String_t* L_0 = Uri_get_Scheme_m2109479391(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_1 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeFile_21();
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_2 = String_op_Equality_m920492651(NULL /*static, unused*/, L_0, L_1, /*hidden argument*/NULL);
		return L_2;
	}
}
// System.Boolean System.Uri::get_IsLoopback()
extern "C"  bool Uri_get_IsLoopback_m2492530169 (Uri_t100236324 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_get_IsLoopback_m2492530169_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	IPAddress_t241777590 * V_0 = NULL;
	IPv6Address_t2709566769 * V_1 = NULL;
	{
		Uri_EnsureAbsoluteUri_m2231483494(__this, /*hidden argument*/NULL);
		String_t* L_0 = Uri_get_Host_m255565830(__this, /*hidden argument*/NULL);
		int32_t L_1 = String_get_Length_m3847582255(L_0, /*hidden argument*/NULL);
		if (L_1)
		{
			goto IL_001d;
		}
	}
	{
		bool L_2 = Uri_get_IsFile_m2450018824(__this, /*hidden argument*/NULL);
		return L_2;
	}

IL_001d:
	{
		String_t* L_3 = __this->get_host_4();
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_4 = String_op_Equality_m920492651(NULL /*static, unused*/, L_3, _stringLiteral405613428, /*hidden argument*/NULL);
		if (L_4)
		{
			goto IL_0047;
		}
	}
	{
		String_t* L_5 = __this->get_host_4();
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_6 = String_op_Equality_m920492651(NULL /*static, unused*/, L_5, _stringLiteral1305937687, /*hidden argument*/NULL);
		if (!L_6)
		{
			goto IL_0049;
		}
	}

IL_0047:
	{
		return (bool)1;
	}

IL_0049:
	{
		String_t* L_7 = __this->get_host_4();
		IL2CPP_RUNTIME_CLASS_INIT(IPAddress_t241777590_il2cpp_TypeInfo_var);
		bool L_8 = IPAddress_TryParse_m2320149543(NULL /*static, unused*/, L_7, (&V_0), /*hidden argument*/NULL);
		if (!L_8)
		{
			goto IL_006d;
		}
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(IPAddress_t241777590_il2cpp_TypeInfo_var);
		IPAddress_t241777590 * L_9 = ((IPAddress_t241777590_StaticFields*)il2cpp_codegen_static_fields_for(IPAddress_t241777590_il2cpp_TypeInfo_var))->get_Loopback_6();
		IPAddress_t241777590 * L_10 = V_0;
		bool L_11 = VirtFuncInvoker1< bool, RuntimeObject * >::Invoke(0 /* System.Boolean System.Net.IPAddress::Equals(System.Object) */, L_9, L_10);
		if (!L_11)
		{
			goto IL_006d;
		}
	}
	{
		return (bool)1;
	}

IL_006d:
	{
		String_t* L_12 = __this->get_host_4();
		IL2CPP_RUNTIME_CLASS_INIT(IPv6Address_t2709566769_il2cpp_TypeInfo_var);
		bool L_13 = IPv6Address_TryParse_m2586816298(NULL /*static, unused*/, L_12, (&V_1), /*hidden argument*/NULL);
		if (!L_13)
		{
			goto IL_008c;
		}
	}
	{
		IPv6Address_t2709566769 * L_14 = V_1;
		IL2CPP_RUNTIME_CLASS_INIT(IPv6Address_t2709566769_il2cpp_TypeInfo_var);
		bool L_15 = IPv6Address_IsLoopback_m3712926451(NULL /*static, unused*/, L_14, /*hidden argument*/NULL);
		if (!L_15)
		{
			goto IL_008c;
		}
	}
	{
		return (bool)1;
	}

IL_008c:
	{
		return (bool)0;
	}
}
// System.Boolean System.Uri::get_IsUnc()
extern "C"  bool Uri_get_IsUnc_m2977972311 (Uri_t100236324 * __this, const RuntimeMethod* method)
{
	{
		Uri_EnsureAbsoluteUri_m2231483494(__this, /*hidden argument*/NULL);
		bool L_0 = __this->get_isUnc_10();
		return L_0;
	}
}
// System.String System.Uri::get_LocalPath()
extern "C"  String_t* Uri_get_LocalPath_m2837234216 (Uri_t100236324 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_get_LocalPath_m2837234216_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	String_t* V_1 = NULL;
	bool V_2 = false;
	String_t* V_3 = NULL;
	Il2CppChar V_4 = 0x0;
	int32_t G_B9_0 = 0;
	int32_t G_B11_0 = 0;
	{
		Uri_EnsureAbsoluteUri_m2231483494(__this, /*hidden argument*/NULL);
		String_t* L_0 = __this->get_cachedLocalPath_17();
		if (!L_0)
		{
			goto IL_0018;
		}
	}
	{
		String_t* L_1 = __this->get_cachedLocalPath_17();
		return L_1;
	}

IL_0018:
	{
		bool L_2 = Uri_get_IsFile_m2450018824(__this, /*hidden argument*/NULL);
		if (L_2)
		{
			goto IL_002a;
		}
	}
	{
		String_t* L_3 = Uri_get_AbsolutePath_m590948575(__this, /*hidden argument*/NULL);
		return L_3;
	}

IL_002a:
	{
		String_t* L_4 = __this->get_path_6();
		int32_t L_5 = String_get_Length_m3847582255(L_4, /*hidden argument*/NULL);
		if ((((int32_t)L_5) <= ((int32_t)3)))
		{
			goto IL_0076;
		}
	}
	{
		String_t* L_6 = __this->get_path_6();
		Il2CppChar L_7 = String_get_Chars_m2986988803(L_6, 1, /*hidden argument*/NULL);
		if ((!(((uint32_t)L_7) == ((uint32_t)((int32_t)58)))))
		{
			goto IL_0076;
		}
	}
	{
		String_t* L_8 = __this->get_path_6();
		Il2CppChar L_9 = String_get_Chars_m2986988803(L_8, 2, /*hidden argument*/NULL);
		if ((((int32_t)L_9) == ((int32_t)((int32_t)92))))
		{
			goto IL_0073;
		}
	}
	{
		String_t* L_10 = __this->get_path_6();
		Il2CppChar L_11 = String_get_Chars_m2986988803(L_10, 2, /*hidden argument*/NULL);
		G_B9_0 = ((((int32_t)L_11) == ((int32_t)((int32_t)47)))? 1 : 0);
		goto IL_0074;
	}

IL_0073:
	{
		G_B9_0 = 1;
	}

IL_0074:
	{
		G_B11_0 = G_B9_0;
		goto IL_0077;
	}

IL_0076:
	{
		G_B11_0 = 0;
	}

IL_0077:
	{
		V_0 = (bool)G_B11_0;
		bool L_12 = Uri_get_IsUnc_m2977972311(__this, /*hidden argument*/NULL);
		if (L_12)
		{
			goto IL_00b9;
		}
	}
	{
		String_t* L_13 = __this->get_path_6();
		String_t* L_14 = VirtFuncInvoker1< String_t*, String_t* >::Invoke(4 /* System.String System.Uri::Unescape(System.String) */, __this, L_13);
		V_1 = L_14;
		bool L_15 = V_0;
		V_2 = L_15;
		bool L_16 = V_2;
		if (!L_16)
		{
			goto IL_00ad;
		}
	}
	{
		String_t* L_17 = V_1;
		String_t* L_18 = String_Replace_m3726209165(L_17, ((int32_t)47), ((int32_t)92), /*hidden argument*/NULL);
		__this->set_cachedLocalPath_17(L_18);
		goto IL_00b4;
	}

IL_00ad:
	{
		String_t* L_19 = V_1;
		__this->set_cachedLocalPath_17(L_19);
	}

IL_00b4:
	{
		goto IL_018f;
	}

IL_00b9:
	{
		String_t* L_20 = __this->get_path_6();
		int32_t L_21 = String_get_Length_m3847582255(L_20, /*hidden argument*/NULL);
		if ((((int32_t)L_21) <= ((int32_t)1)))
		{
			goto IL_0103;
		}
	}
	{
		String_t* L_22 = __this->get_path_6();
		Il2CppChar L_23 = String_get_Chars_m2986988803(L_22, 1, /*hidden argument*/NULL);
		if ((!(((uint32_t)L_23) == ((uint32_t)((int32_t)58)))))
		{
			goto IL_0103;
		}
	}
	{
		String_t* L_24 = __this->get_path_6();
		IL2CPP_RUNTIME_CLASS_INIT(Path_t1605229823_il2cpp_TypeInfo_var);
		Il2CppChar L_25 = ((Path_t1605229823_StaticFields*)il2cpp_codegen_static_fields_for(Path_t1605229823_il2cpp_TypeInfo_var))->get_AltDirectorySeparatorChar_1();
		Il2CppChar L_26 = ((Path_t1605229823_StaticFields*)il2cpp_codegen_static_fields_for(Path_t1605229823_il2cpp_TypeInfo_var))->get_DirectorySeparatorChar_2();
		String_t* L_27 = String_Replace_m3726209165(L_24, L_25, L_26, /*hidden argument*/NULL);
		String_t* L_28 = VirtFuncInvoker1< String_t*, String_t* >::Invoke(4 /* System.String System.Uri::Unescape(System.String) */, __this, L_27);
		__this->set_cachedLocalPath_17(L_28);
		goto IL_018f;
	}

IL_0103:
	{
		IL2CPP_RUNTIME_CLASS_INIT(Path_t1605229823_il2cpp_TypeInfo_var);
		Il2CppChar L_29 = ((Path_t1605229823_StaticFields*)il2cpp_codegen_static_fields_for(Path_t1605229823_il2cpp_TypeInfo_var))->get_DirectorySeparatorChar_2();
		if ((!(((uint32_t)L_29) == ((uint32_t)((int32_t)92)))))
		{
			goto IL_017d;
		}
	}
	{
		String_t* L_30 = __this->get_host_4();
		V_3 = L_30;
		String_t* L_31 = __this->get_path_6();
		int32_t L_32 = String_get_Length_m3847582255(L_31, /*hidden argument*/NULL);
		if ((((int32_t)L_32) <= ((int32_t)0)))
		{
			goto IL_0161;
		}
	}
	{
		String_t* L_33 = __this->get_path_6();
		int32_t L_34 = String_get_Length_m3847582255(L_33, /*hidden argument*/NULL);
		if ((((int32_t)L_34) > ((int32_t)1)))
		{
			goto IL_014b;
		}
	}
	{
		String_t* L_35 = __this->get_path_6();
		Il2CppChar L_36 = String_get_Chars_m2986988803(L_35, 0, /*hidden argument*/NULL);
		if ((((int32_t)L_36) == ((int32_t)((int32_t)47))))
		{
			goto IL_0161;
		}
	}

IL_014b:
	{
		String_t* L_37 = V_3;
		String_t* L_38 = __this->get_path_6();
		String_t* L_39 = String_Replace_m3726209165(L_38, ((int32_t)47), ((int32_t)92), /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_40 = String_Concat_m3937257545(NULL /*static, unused*/, L_37, L_39, /*hidden argument*/NULL);
		V_3 = L_40;
	}

IL_0161:
	{
		String_t* L_41 = V_3;
		String_t* L_42 = VirtFuncInvoker1< String_t*, String_t* >::Invoke(4 /* System.String System.Uri::Unescape(System.String) */, __this, L_41);
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_43 = String_Concat_m3937257545(NULL /*static, unused*/, _stringLiteral3458119668, L_42, /*hidden argument*/NULL);
		__this->set_cachedLocalPath_17(L_43);
		goto IL_018f;
	}

IL_017d:
	{
		String_t* L_44 = __this->get_path_6();
		String_t* L_45 = VirtFuncInvoker1< String_t*, String_t* >::Invoke(4 /* System.String System.Uri::Unescape(System.String) */, __this, L_44);
		__this->set_cachedLocalPath_17(L_45);
	}

IL_018f:
	{
		String_t* L_46 = __this->get_cachedLocalPath_17();
		int32_t L_47 = String_get_Length_m3847582255(L_46, /*hidden argument*/NULL);
		if (L_47)
		{
			goto IL_01b3;
		}
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(Path_t1605229823_il2cpp_TypeInfo_var);
		Il2CppChar L_48 = ((Path_t1605229823_StaticFields*)il2cpp_codegen_static_fields_for(Path_t1605229823_il2cpp_TypeInfo_var))->get_DirectorySeparatorChar_2();
		V_4 = L_48;
		String_t* L_49 = Char_ToString_m3588025615((&V_4), /*hidden argument*/NULL);
		__this->set_cachedLocalPath_17(L_49);
	}

IL_01b3:
	{
		String_t* L_50 = __this->get_cachedLocalPath_17();
		return L_50;
	}
}
// System.String System.Uri::get_PathAndQuery()
extern "C"  String_t* Uri_get_PathAndQuery_m2396197970 (Uri_t100236324 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_get_PathAndQuery_m2396197970_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		Uri_EnsureAbsoluteUri_m2231483494(__this, /*hidden argument*/NULL);
		String_t* L_0 = __this->get_path_6();
		String_t* L_1 = Uri_get_Query_m2772518875(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_2 = String_Concat_m3937257545(NULL /*static, unused*/, L_0, L_1, /*hidden argument*/NULL);
		return L_2;
	}
}
// System.Int32 System.Uri::get_Port()
extern "C"  int32_t Uri_get_Port_m184067428 (Uri_t100236324 * __this, const RuntimeMethod* method)
{
	{
		Uri_EnsureAbsoluteUri_m2231483494(__this, /*hidden argument*/NULL);
		int32_t L_0 = __this->get_port_5();
		return L_0;
	}
}
// System.String System.Uri::get_Query()
extern "C"  String_t* Uri_get_Query_m2772518875 (Uri_t100236324 * __this, const RuntimeMethod* method)
{
	{
		Uri_EnsureAbsoluteUri_m2231483494(__this, /*hidden argument*/NULL);
		String_t* L_0 = __this->get_query_7();
		return L_0;
	}
}
// System.String System.Uri::get_Scheme()
extern "C"  String_t* Uri_get_Scheme_m2109479391 (Uri_t100236324 * __this, const RuntimeMethod* method)
{
	{
		Uri_EnsureAbsoluteUri_m2231483494(__this, /*hidden argument*/NULL);
		String_t* L_0 = __this->get_scheme_3();
		return L_0;
	}
}
// System.Boolean System.Uri::get_IsAbsoluteUri()
extern "C"  bool Uri_get_IsAbsoluteUri_m3666899587 (Uri_t100236324 * __this, const RuntimeMethod* method)
{
	{
		bool L_0 = __this->get_isAbsoluteUri_12();
		return L_0;
	}
}
// System.String System.Uri::get_OriginalString()
extern "C"  String_t* Uri_get_OriginalString_m3715995233 (Uri_t100236324 * __this, const RuntimeMethod* method)
{
	String_t* G_B3_0 = NULL;
	{
		String_t* L_0 = __this->get_source_2();
		if (!L_0)
		{
			goto IL_0016;
		}
	}
	{
		String_t* L_1 = __this->get_source_2();
		G_B3_0 = L_1;
		goto IL_001c;
	}

IL_0016:
	{
		String_t* L_2 = VirtFuncInvoker0< String_t* >::Invoke(3 /* System.String System.Uri::ToString() */, __this);
		G_B3_0 = L_2;
	}

IL_001c:
	{
		return G_B3_0;
	}
}
// System.UriHostNameType System.Uri::CheckHostName(System.String)
extern "C"  int32_t Uri_CheckHostName_m2213216182 (RuntimeObject * __this /* static, unused */, String_t* ___name0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_CheckHostName_m2213216182_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	IPv6Address_t2709566769 * V_0 = NULL;
	{
		String_t* L_0 = ___name0;
		if (!L_0)
		{
			goto IL_0011;
		}
	}
	{
		String_t* L_1 = ___name0;
		int32_t L_2 = String_get_Length_m3847582255(L_1, /*hidden argument*/NULL);
		if (L_2)
		{
			goto IL_0013;
		}
	}

IL_0011:
	{
		return (int32_t)(0);
	}

IL_0013:
	{
		String_t* L_3 = ___name0;
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		bool L_4 = Uri_IsIPv4Address_m3535481943(NULL /*static, unused*/, L_3, /*hidden argument*/NULL);
		if (!L_4)
		{
			goto IL_0020;
		}
	}
	{
		return (int32_t)(3);
	}

IL_0020:
	{
		String_t* L_5 = ___name0;
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		bool L_6 = Uri_IsDomainAddress_m2867513594(NULL /*static, unused*/, L_5, /*hidden argument*/NULL);
		if (!L_6)
		{
			goto IL_002d;
		}
	}
	{
		return (int32_t)(2);
	}

IL_002d:
	{
		String_t* L_7 = ___name0;
		IL2CPP_RUNTIME_CLASS_INIT(IPv6Address_t2709566769_il2cpp_TypeInfo_var);
		bool L_8 = IPv6Address_TryParse_m2586816298(NULL /*static, unused*/, L_7, (&V_0), /*hidden argument*/NULL);
		if (!L_8)
		{
			goto IL_003c;
		}
	}
	{
		return (int32_t)(4);
	}

IL_003c:
	{
		return (int32_t)(0);
	}
}
// System.Boolean System.Uri::IsIPv4Address(System.String)
extern "C"  bool Uri_IsIPv4Address_m3535481943 (RuntimeObject * __this /* static, unused */, String_t* ___name0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_IsIPv4Address_m3535481943_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	StringU5BU5D_t1281789340* V_0 = NULL;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	uint32_t V_3 = 0;
	{
		String_t* L_0 = ___name0;
		CharU5BU5D_t3528271667* L_1 = ((CharU5BU5D_t3528271667*)SZArrayNew(CharU5BU5D_t3528271667_il2cpp_TypeInfo_var, (uint32_t)1));
		(L_1)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(0), (Il2CppChar)((int32_t)46));
		StringU5BU5D_t1281789340* L_2 = String_Split_m3646115398(L_0, L_1, /*hidden argument*/NULL);
		V_0 = L_2;
		StringU5BU5D_t1281789340* L_3 = V_0;
		if ((((int32_t)(((int32_t)((int32_t)(((RuntimeArray *)L_3)->max_length))))) == ((int32_t)4)))
		{
			goto IL_001d;
		}
	}
	{
		return (bool)0;
	}

IL_001d:
	{
		V_1 = 0;
		goto IL_0057;
	}

IL_0024:
	{
		StringU5BU5D_t1281789340* L_4 = V_0;
		int32_t L_5 = V_1;
		int32_t L_6 = L_5;
		String_t* L_7 = (L_4)->GetAtUnchecked(static_cast<il2cpp_array_size_t>(L_6));
		int32_t L_8 = String_get_Length_m3847582255(L_7, /*hidden argument*/NULL);
		V_2 = L_8;
		int32_t L_9 = V_2;
		if (L_9)
		{
			goto IL_0035;
		}
	}
	{
		return (bool)0;
	}

IL_0035:
	{
		StringU5BU5D_t1281789340* L_10 = V_0;
		int32_t L_11 = V_1;
		int32_t L_12 = L_11;
		String_t* L_13 = (L_10)->GetAtUnchecked(static_cast<il2cpp_array_size_t>(L_12));
		bool L_14 = UInt32_TryParse_m2819179361(NULL /*static, unused*/, L_13, (&V_3), /*hidden argument*/NULL);
		if (L_14)
		{
			goto IL_0046;
		}
	}
	{
		return (bool)0;
	}

IL_0046:
	{
		uint32_t L_15 = V_3;
		if ((!(((uint32_t)L_15) > ((uint32_t)((int32_t)255)))))
		{
			goto IL_0053;
		}
	}
	{
		return (bool)0;
	}

IL_0053:
	{
		int32_t L_16 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add((int32_t)L_16, (int32_t)1));
	}

IL_0057:
	{
		int32_t L_17 = V_1;
		if ((((int32_t)L_17) < ((int32_t)4)))
		{
			goto IL_0024;
		}
	}
	{
		return (bool)1;
	}
}
// System.Boolean System.Uri::IsDomainAddress(System.String)
extern "C"  bool Uri_IsDomainAddress_m2867513594 (RuntimeObject * __this /* static, unused */, String_t* ___name0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_IsDomainAddress_m2867513594_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	Il2CppChar V_3 = 0x0;
	{
		String_t* L_0 = ___name0;
		int32_t L_1 = String_get_Length_m3847582255(L_0, /*hidden argument*/NULL);
		V_0 = L_1;
		V_1 = 0;
		V_2 = 0;
		goto IL_006e;
	}

IL_0010:
	{
		String_t* L_2 = ___name0;
		int32_t L_3 = V_2;
		Il2CppChar L_4 = String_get_Chars_m2986988803(L_2, L_3, /*hidden argument*/NULL);
		V_3 = L_4;
		int32_t L_5 = V_1;
		if (L_5)
		{
			goto IL_0030;
		}
	}
	{
		Il2CppChar L_6 = V_3;
		IL2CPP_RUNTIME_CLASS_INIT(Char_t3634460470_il2cpp_TypeInfo_var);
		bool L_7 = Char_IsLetterOrDigit_m3494175785(NULL /*static, unused*/, L_6, /*hidden argument*/NULL);
		if (L_7)
		{
			goto IL_002b;
		}
	}
	{
		return (bool)0;
	}

IL_002b:
	{
		goto IL_005c;
	}

IL_0030:
	{
		Il2CppChar L_8 = V_3;
		if ((!(((uint32_t)L_8) == ((uint32_t)((int32_t)46)))))
		{
			goto IL_003f;
		}
	}
	{
		V_1 = 0;
		goto IL_005c;
	}

IL_003f:
	{
		Il2CppChar L_9 = V_3;
		IL2CPP_RUNTIME_CLASS_INIT(Char_t3634460470_il2cpp_TypeInfo_var);
		bool L_10 = Char_IsLetterOrDigit_m3494175785(NULL /*static, unused*/, L_9, /*hidden argument*/NULL);
		if (L_10)
		{
			goto IL_005c;
		}
	}
	{
		Il2CppChar L_11 = V_3;
		if ((((int32_t)L_11) == ((int32_t)((int32_t)45))))
		{
			goto IL_005c;
		}
	}
	{
		Il2CppChar L_12 = V_3;
		if ((((int32_t)L_12) == ((int32_t)((int32_t)95))))
		{
			goto IL_005c;
		}
	}
	{
		return (bool)0;
	}

IL_005c:
	{
		int32_t L_13 = V_1;
		int32_t L_14 = ((int32_t)il2cpp_codegen_add((int32_t)L_13, (int32_t)1));
		V_1 = L_14;
		if ((!(((uint32_t)L_14) == ((uint32_t)((int32_t)64)))))
		{
			goto IL_006a;
		}
	}
	{
		return (bool)0;
	}

IL_006a:
	{
		int32_t L_15 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add((int32_t)L_15, (int32_t)1));
	}

IL_006e:
	{
		int32_t L_16 = V_2;
		int32_t L_17 = V_0;
		if ((((int32_t)L_16) < ((int32_t)L_17)))
		{
			goto IL_0010;
		}
	}
	{
		return (bool)1;
	}
}
// System.Boolean System.Uri::CheckSchemeName(System.String)
extern "C"  bool Uri_CheckSchemeName_m108657675 (RuntimeObject * __this /* static, unused */, String_t* ___schemeName0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_CheckSchemeName_m108657675_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	Il2CppChar V_2 = 0x0;
	{
		String_t* L_0 = ___schemeName0;
		if (!L_0)
		{
			goto IL_0011;
		}
	}
	{
		String_t* L_1 = ___schemeName0;
		int32_t L_2 = String_get_Length_m3847582255(L_1, /*hidden argument*/NULL);
		if (L_2)
		{
			goto IL_0013;
		}
	}

IL_0011:
	{
		return (bool)0;
	}

IL_0013:
	{
		String_t* L_3 = ___schemeName0;
		Il2CppChar L_4 = String_get_Chars_m2986988803(L_3, 0, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		bool L_5 = Uri_IsAlpha_m1282293464(NULL /*static, unused*/, L_4, /*hidden argument*/NULL);
		if (L_5)
		{
			goto IL_0026;
		}
	}
	{
		return (bool)0;
	}

IL_0026:
	{
		String_t* L_6 = ___schemeName0;
		int32_t L_7 = String_get_Length_m3847582255(L_6, /*hidden argument*/NULL);
		V_0 = L_7;
		V_1 = 1;
		goto IL_0070;
	}

IL_0034:
	{
		String_t* L_8 = ___schemeName0;
		int32_t L_9 = V_1;
		Il2CppChar L_10 = String_get_Chars_m2986988803(L_8, L_9, /*hidden argument*/NULL);
		V_2 = L_10;
		Il2CppChar L_11 = V_2;
		IL2CPP_RUNTIME_CLASS_INIT(Char_t3634460470_il2cpp_TypeInfo_var);
		bool L_12 = Char_IsDigit_m3646673943(NULL /*static, unused*/, L_11, /*hidden argument*/NULL);
		if (L_12)
		{
			goto IL_006c;
		}
	}
	{
		Il2CppChar L_13 = V_2;
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		bool L_14 = Uri_IsAlpha_m1282293464(NULL /*static, unused*/, L_13, /*hidden argument*/NULL);
		if (L_14)
		{
			goto IL_006c;
		}
	}
	{
		Il2CppChar L_15 = V_2;
		if ((((int32_t)L_15) == ((int32_t)((int32_t)46))))
		{
			goto IL_006c;
		}
	}
	{
		Il2CppChar L_16 = V_2;
		if ((((int32_t)L_16) == ((int32_t)((int32_t)43))))
		{
			goto IL_006c;
		}
	}
	{
		Il2CppChar L_17 = V_2;
		if ((((int32_t)L_17) == ((int32_t)((int32_t)45))))
		{
			goto IL_006c;
		}
	}
	{
		return (bool)0;
	}

IL_006c:
	{
		int32_t L_18 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add((int32_t)L_18, (int32_t)1));
	}

IL_0070:
	{
		int32_t L_19 = V_1;
		int32_t L_20 = V_0;
		if ((((int32_t)L_19) < ((int32_t)L_20)))
		{
			goto IL_0034;
		}
	}
	{
		return (bool)1;
	}
}
// System.Boolean System.Uri::IsAlpha(System.Char)
extern "C"  bool Uri_IsAlpha_m1282293464 (RuntimeObject * __this /* static, unused */, Il2CppChar ___c0, const RuntimeMethod* method)
{
	int32_t V_0 = 0;
	int32_t G_B5_0 = 0;
	int32_t G_B7_0 = 0;
	{
		Il2CppChar L_0 = ___c0;
		V_0 = L_0;
		int32_t L_1 = V_0;
		if ((((int32_t)L_1) < ((int32_t)((int32_t)65))))
		{
			goto IL_0012;
		}
	}
	{
		int32_t L_2 = V_0;
		if ((((int32_t)L_2) <= ((int32_t)((int32_t)90))))
		{
			goto IL_0027;
		}
	}

IL_0012:
	{
		int32_t L_3 = V_0;
		if ((((int32_t)L_3) < ((int32_t)((int32_t)97))))
		{
			goto IL_0024;
		}
	}
	{
		int32_t L_4 = V_0;
		G_B5_0 = ((((int32_t)((((int32_t)L_4) > ((int32_t)((int32_t)122)))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_0025;
	}

IL_0024:
	{
		G_B5_0 = 0;
	}

IL_0025:
	{
		G_B7_0 = G_B5_0;
		goto IL_0028;
	}

IL_0027:
	{
		G_B7_0 = 1;
	}

IL_0028:
	{
		return (bool)G_B7_0;
	}
}
// System.Boolean System.Uri::Equals(System.Object)
extern "C"  bool Uri_Equals_m3263316701 (Uri_t100236324 * __this, RuntimeObject * ___comparant0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_Equals_m3263316701_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	Uri_t100236324 * V_0 = NULL;
	String_t* V_1 = NULL;
	{
		RuntimeObject * L_0 = ___comparant0;
		if (L_0)
		{
			goto IL_0008;
		}
	}
	{
		return (bool)0;
	}

IL_0008:
	{
		RuntimeObject * L_1 = ___comparant0;
		V_0 = ((Uri_t100236324 *)IsInstClass((RuntimeObject*)L_1, Uri_t100236324_il2cpp_TypeInfo_var));
		Uri_t100236324 * L_2 = V_0;
		if (L_2)
		{
			goto IL_002b;
		}
	}
	{
		RuntimeObject * L_3 = ___comparant0;
		V_1 = ((String_t*)IsInstSealed((RuntimeObject*)L_3, String_t_il2cpp_TypeInfo_var));
		String_t* L_4 = V_1;
		if (L_4)
		{
			goto IL_0024;
		}
	}
	{
		return (bool)0;
	}

IL_0024:
	{
		String_t* L_5 = V_1;
		Uri_t100236324 * L_6 = (Uri_t100236324 *)il2cpp_codegen_object_new(Uri_t100236324_il2cpp_TypeInfo_var);
		Uri__ctor_m800430703(L_6, L_5, /*hidden argument*/NULL);
		V_0 = L_6;
	}

IL_002b:
	{
		Uri_t100236324 * L_7 = V_0;
		bool L_8 = Uri_InternalEquals_m2029068366(__this, L_7, /*hidden argument*/NULL);
		return L_8;
	}
}
// System.Boolean System.Uri::InternalEquals(System.Uri)
extern "C"  bool Uri_InternalEquals_m2029068366 (Uri_t100236324 * __this, Uri_t100236324 * ___uri0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_InternalEquals_m2029068366_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	CultureInfo_t4157843068 * V_0 = NULL;
	int32_t G_B10_0 = 0;
	{
		bool L_0 = __this->get_isAbsoluteUri_12();
		Uri_t100236324 * L_1 = ___uri0;
		bool L_2 = L_1->get_isAbsoluteUri_12();
		if ((((int32_t)L_0) == ((int32_t)L_2)))
		{
			goto IL_0013;
		}
	}
	{
		return (bool)0;
	}

IL_0013:
	{
		bool L_3 = __this->get_isAbsoluteUri_12();
		if (L_3)
		{
			goto IL_0030;
		}
	}
	{
		String_t* L_4 = __this->get_source_2();
		Uri_t100236324 * L_5 = ___uri0;
		String_t* L_6 = L_5->get_source_2();
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_7 = String_op_Equality_m920492651(NULL /*static, unused*/, L_4, L_6, /*hidden argument*/NULL);
		return L_7;
	}

IL_0030:
	{
		IL2CPP_RUNTIME_CLASS_INIT(CultureInfo_t4157843068_il2cpp_TypeInfo_var);
		CultureInfo_t4157843068 * L_8 = CultureInfo_get_InvariantCulture_m3532445182(NULL /*static, unused*/, /*hidden argument*/NULL);
		V_0 = L_8;
		String_t* L_9 = __this->get_scheme_3();
		CultureInfo_t4157843068 * L_10 = V_0;
		String_t* L_11 = String_ToLower_m3490221821(L_9, L_10, /*hidden argument*/NULL);
		Uri_t100236324 * L_12 = ___uri0;
		String_t* L_13 = L_12->get_scheme_3();
		CultureInfo_t4157843068 * L_14 = V_0;
		String_t* L_15 = String_ToLower_m3490221821(L_13, L_14, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_16 = String_op_Equality_m920492651(NULL /*static, unused*/, L_11, L_15, /*hidden argument*/NULL);
		if (!L_16)
		{
			goto IL_00b4;
		}
	}
	{
		String_t* L_17 = __this->get_host_4();
		CultureInfo_t4157843068 * L_18 = V_0;
		String_t* L_19 = String_ToLower_m3490221821(L_17, L_18, /*hidden argument*/NULL);
		Uri_t100236324 * L_20 = ___uri0;
		String_t* L_21 = L_20->get_host_4();
		CultureInfo_t4157843068 * L_22 = V_0;
		String_t* L_23 = String_ToLower_m3490221821(L_21, L_22, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_24 = String_op_Equality_m920492651(NULL /*static, unused*/, L_19, L_23, /*hidden argument*/NULL);
		if (!L_24)
		{
			goto IL_00b4;
		}
	}
	{
		int32_t L_25 = __this->get_port_5();
		Uri_t100236324 * L_26 = ___uri0;
		int32_t L_27 = L_26->get_port_5();
		if ((!(((uint32_t)L_25) == ((uint32_t)L_27))))
		{
			goto IL_00b4;
		}
	}
	{
		String_t* L_28 = __this->get_query_7();
		Uri_t100236324 * L_29 = ___uri0;
		String_t* L_30 = L_29->get_query_7();
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_31 = String_op_Equality_m920492651(NULL /*static, unused*/, L_28, L_30, /*hidden argument*/NULL);
		if (!L_31)
		{
			goto IL_00b4;
		}
	}
	{
		String_t* L_32 = __this->get_path_6();
		Uri_t100236324 * L_33 = ___uri0;
		String_t* L_34 = L_33->get_path_6();
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_35 = String_op_Equality_m920492651(NULL /*static, unused*/, L_32, L_34, /*hidden argument*/NULL);
		G_B10_0 = ((int32_t)(L_35));
		goto IL_00b5;
	}

IL_00b4:
	{
		G_B10_0 = 0;
	}

IL_00b5:
	{
		return (bool)G_B10_0;
	}
}
// System.Int32 System.Uri::GetHashCode()
extern "C"  int32_t Uri_GetHashCode_m321999866 (Uri_t100236324 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_GetHashCode_m321999866_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	CultureInfo_t4157843068 * V_0 = NULL;
	{
		int32_t L_0 = __this->get_cachedHashCode_18();
		if (L_0)
		{
			goto IL_007a;
		}
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(CultureInfo_t4157843068_il2cpp_TypeInfo_var);
		CultureInfo_t4157843068 * L_1 = CultureInfo_get_InvariantCulture_m3532445182(NULL /*static, unused*/, /*hidden argument*/NULL);
		V_0 = L_1;
		bool L_2 = __this->get_isAbsoluteUri_12();
		if (!L_2)
		{
			goto IL_0069;
		}
	}
	{
		String_t* L_3 = __this->get_scheme_3();
		CultureInfo_t4157843068 * L_4 = V_0;
		String_t* L_5 = String_ToLower_m3490221821(L_3, L_4, /*hidden argument*/NULL);
		int32_t L_6 = String_GetHashCode_m1906374149(L_5, /*hidden argument*/NULL);
		String_t* L_7 = __this->get_host_4();
		CultureInfo_t4157843068 * L_8 = V_0;
		String_t* L_9 = String_ToLower_m3490221821(L_7, L_8, /*hidden argument*/NULL);
		int32_t L_10 = String_GetHashCode_m1906374149(L_9, /*hidden argument*/NULL);
		int32_t L_11 = __this->get_port_5();
		String_t* L_12 = __this->get_query_7();
		int32_t L_13 = String_GetHashCode_m1906374149(L_12, /*hidden argument*/NULL);
		String_t* L_14 = __this->get_path_6();
		int32_t L_15 = String_GetHashCode_m1906374149(L_14, /*hidden argument*/NULL);
		__this->set_cachedHashCode_18(((int32_t)((int32_t)((int32_t)((int32_t)((int32_t)((int32_t)((int32_t)((int32_t)L_6^(int32_t)L_10))^(int32_t)L_11))^(int32_t)L_13))^(int32_t)L_15)));
		goto IL_007a;
	}

IL_0069:
	{
		String_t* L_16 = __this->get_source_2();
		int32_t L_17 = String_GetHashCode_m1906374149(L_16, /*hidden argument*/NULL);
		__this->set_cachedHashCode_18(L_17);
	}

IL_007a:
	{
		int32_t L_18 = __this->get_cachedHashCode_18();
		return L_18;
	}
}
// System.String System.Uri::GetLeftPart(System.UriPartial)
extern "C"  String_t* Uri_GetLeftPart_m3979111399 (Uri_t100236324 * __this, int32_t ___part0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_GetLeftPart_m3979111399_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	StringBuilder_t * V_1 = NULL;
	StringBuilder_t * V_2 = NULL;
	int32_t V_3 = 0;
	String_t* V_4 = NULL;
	Dictionary_2_t2736202052 * V_5 = NULL;
	int32_t V_6 = 0;
	{
		Uri_EnsureAbsoluteUri_m2231483494(__this, /*hidden argument*/NULL);
		int32_t L_0 = ___part0;
		V_3 = L_0;
		int32_t L_1 = V_3;
		switch (L_1)
		{
			case 0:
			{
				goto IL_001f;
			}
			case 1:
			{
				goto IL_0031;
			}
			case 2:
			{
				goto IL_0134;
			}
		}
	}
	{
		goto IL_02ad;
	}

IL_001f:
	{
		String_t* L_2 = __this->get_scheme_3();
		String_t* L_3 = Uri_GetOpaqueWiseSchemeDelimiter_m1909471550(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_4 = String_Concat_m3937257545(NULL /*static, unused*/, L_2, L_3, /*hidden argument*/NULL);
		return L_4;
	}

IL_0031:
	{
		String_t* L_5 = __this->get_scheme_3();
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_6 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeMailto_26();
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_7 = String_op_Equality_m920492651(NULL /*static, unused*/, L_5, L_6, /*hidden argument*/NULL);
		if (L_7)
		{
			goto IL_005b;
		}
	}
	{
		String_t* L_8 = __this->get_scheme_3();
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_9 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeNews_27();
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_10 = String_op_Equality_m920492651(NULL /*static, unused*/, L_8, L_9, /*hidden argument*/NULL);
		if (!L_10)
		{
			goto IL_0061;
		}
	}

IL_005b:
	{
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_11 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		return L_11;
	}

IL_0061:
	{
		StringBuilder_t * L_12 = (StringBuilder_t *)il2cpp_codegen_object_new(StringBuilder_t_il2cpp_TypeInfo_var);
		StringBuilder__ctor_m3121283359(L_12, /*hidden argument*/NULL);
		V_1 = L_12;
		StringBuilder_t * L_13 = V_1;
		String_t* L_14 = __this->get_scheme_3();
		StringBuilder_Append_m1965104174(L_13, L_14, /*hidden argument*/NULL);
		StringBuilder_t * L_15 = V_1;
		String_t* L_16 = Uri_GetOpaqueWiseSchemeDelimiter_m1909471550(__this, /*hidden argument*/NULL);
		StringBuilder_Append_m1965104174(L_15, L_16, /*hidden argument*/NULL);
		String_t* L_17 = __this->get_path_6();
		int32_t L_18 = String_get_Length_m3847582255(L_17, /*hidden argument*/NULL);
		if ((((int32_t)L_18) <= ((int32_t)1)))
		{
			goto IL_00c3;
		}
	}
	{
		String_t* L_19 = __this->get_path_6();
		Il2CppChar L_20 = String_get_Chars_m2986988803(L_19, 1, /*hidden argument*/NULL);
		if ((!(((uint32_t)L_20) == ((uint32_t)((int32_t)58)))))
		{
			goto IL_00c3;
		}
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_21 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeFile_21();
		String_t* L_22 = __this->get_scheme_3();
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_23 = String_op_Equality_m920492651(NULL /*static, unused*/, L_21, L_22, /*hidden argument*/NULL);
		if (!L_23)
		{
			goto IL_00c3;
		}
	}
	{
		StringBuilder_t * L_24 = V_1;
		StringBuilder_Append_m2383614642(L_24, ((int32_t)47), /*hidden argument*/NULL);
	}

IL_00c3:
	{
		String_t* L_25 = __this->get_userinfo_9();
		int32_t L_26 = String_get_Length_m3847582255(L_25, /*hidden argument*/NULL);
		if ((((int32_t)L_26) <= ((int32_t)0)))
		{
			goto IL_00e8;
		}
	}
	{
		StringBuilder_t * L_27 = V_1;
		String_t* L_28 = __this->get_userinfo_9();
		StringBuilder_t * L_29 = StringBuilder_Append_m1965104174(L_27, L_28, /*hidden argument*/NULL);
		StringBuilder_Append_m2383614642(L_29, ((int32_t)64), /*hidden argument*/NULL);
	}

IL_00e8:
	{
		StringBuilder_t * L_30 = V_1;
		String_t* L_31 = __this->get_host_4();
		StringBuilder_Append_m1965104174(L_30, L_31, /*hidden argument*/NULL);
		String_t* L_32 = __this->get_scheme_3();
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		int32_t L_33 = Uri_GetDefaultPort_m2547653357(NULL /*static, unused*/, L_32, /*hidden argument*/NULL);
		V_0 = L_33;
		int32_t L_34 = __this->get_port_5();
		if ((((int32_t)L_34) == ((int32_t)(-1))))
		{
			goto IL_012d;
		}
	}
	{
		int32_t L_35 = __this->get_port_5();
		int32_t L_36 = V_0;
		if ((((int32_t)L_35) == ((int32_t)L_36)))
		{
			goto IL_012d;
		}
	}
	{
		StringBuilder_t * L_37 = V_1;
		StringBuilder_t * L_38 = StringBuilder_Append_m2383614642(L_37, ((int32_t)58), /*hidden argument*/NULL);
		int32_t L_39 = __this->get_port_5();
		StringBuilder_Append_m890240332(L_38, L_39, /*hidden argument*/NULL);
	}

IL_012d:
	{
		StringBuilder_t * L_40 = V_1;
		String_t* L_41 = StringBuilder_ToString_m3317489284(L_40, /*hidden argument*/NULL);
		return L_41;
	}

IL_0134:
	{
		StringBuilder_t * L_42 = (StringBuilder_t *)il2cpp_codegen_object_new(StringBuilder_t_il2cpp_TypeInfo_var);
		StringBuilder__ctor_m3121283359(L_42, /*hidden argument*/NULL);
		V_2 = L_42;
		StringBuilder_t * L_43 = V_2;
		String_t* L_44 = __this->get_scheme_3();
		StringBuilder_Append_m1965104174(L_43, L_44, /*hidden argument*/NULL);
		StringBuilder_t * L_45 = V_2;
		String_t* L_46 = Uri_GetOpaqueWiseSchemeDelimiter_m1909471550(__this, /*hidden argument*/NULL);
		StringBuilder_Append_m1965104174(L_45, L_46, /*hidden argument*/NULL);
		String_t* L_47 = __this->get_path_6();
		int32_t L_48 = String_get_Length_m3847582255(L_47, /*hidden argument*/NULL);
		if ((((int32_t)L_48) <= ((int32_t)1)))
		{
			goto IL_0196;
		}
	}
	{
		String_t* L_49 = __this->get_path_6();
		Il2CppChar L_50 = String_get_Chars_m2986988803(L_49, 1, /*hidden argument*/NULL);
		if ((!(((uint32_t)L_50) == ((uint32_t)((int32_t)58)))))
		{
			goto IL_0196;
		}
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_51 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeFile_21();
		String_t* L_52 = __this->get_scheme_3();
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_53 = String_op_Equality_m920492651(NULL /*static, unused*/, L_51, L_52, /*hidden argument*/NULL);
		if (!L_53)
		{
			goto IL_0196;
		}
	}
	{
		StringBuilder_t * L_54 = V_2;
		StringBuilder_Append_m2383614642(L_54, ((int32_t)47), /*hidden argument*/NULL);
	}

IL_0196:
	{
		String_t* L_55 = __this->get_userinfo_9();
		int32_t L_56 = String_get_Length_m3847582255(L_55, /*hidden argument*/NULL);
		if ((((int32_t)L_56) <= ((int32_t)0)))
		{
			goto IL_01bb;
		}
	}
	{
		StringBuilder_t * L_57 = V_2;
		String_t* L_58 = __this->get_userinfo_9();
		StringBuilder_t * L_59 = StringBuilder_Append_m1965104174(L_57, L_58, /*hidden argument*/NULL);
		StringBuilder_Append_m2383614642(L_59, ((int32_t)64), /*hidden argument*/NULL);
	}

IL_01bb:
	{
		StringBuilder_t * L_60 = V_2;
		String_t* L_61 = __this->get_host_4();
		StringBuilder_Append_m1965104174(L_60, L_61, /*hidden argument*/NULL);
		String_t* L_62 = __this->get_scheme_3();
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		int32_t L_63 = Uri_GetDefaultPort_m2547653357(NULL /*static, unused*/, L_62, /*hidden argument*/NULL);
		V_0 = L_63;
		int32_t L_64 = __this->get_port_5();
		if ((((int32_t)L_64) == ((int32_t)(-1))))
		{
			goto IL_0200;
		}
	}
	{
		int32_t L_65 = __this->get_port_5();
		int32_t L_66 = V_0;
		if ((((int32_t)L_65) == ((int32_t)L_66)))
		{
			goto IL_0200;
		}
	}
	{
		StringBuilder_t * L_67 = V_2;
		StringBuilder_t * L_68 = StringBuilder_Append_m2383614642(L_67, ((int32_t)58), /*hidden argument*/NULL);
		int32_t L_69 = __this->get_port_5();
		StringBuilder_Append_m890240332(L_68, L_69, /*hidden argument*/NULL);
	}

IL_0200:
	{
		String_t* L_70 = __this->get_path_6();
		int32_t L_71 = String_get_Length_m3847582255(L_70, /*hidden argument*/NULL);
		if ((((int32_t)L_71) <= ((int32_t)0)))
		{
			goto IL_02a6;
		}
	}
	{
		String_t* L_72 = Uri_get_Scheme_m2109479391(__this, /*hidden argument*/NULL);
		V_4 = L_72;
		String_t* L_73 = V_4;
		if (!L_73)
		{
			goto IL_0284;
		}
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		Dictionary_2_t2736202052 * L_74 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_U3CU3Ef__switchU24map14_35();
		if (L_74)
		{
			goto IL_0253;
		}
	}
	{
		Dictionary_2_t2736202052 * L_75 = (Dictionary_2_t2736202052 *)il2cpp_codegen_object_new(Dictionary_2_t2736202052_il2cpp_TypeInfo_var);
		Dictionary_2__ctor_m2392909825(L_75, 2, /*hidden argument*/Dictionary_2__ctor_m2392909825_RuntimeMethod_var);
		V_5 = L_75;
		Dictionary_2_t2736202052 * L_76 = V_5;
		Dictionary_2_Add_m282647386(L_76, _stringLiteral416809914, 0, /*hidden argument*/Dictionary_2_Add_m282647386_RuntimeMethod_var);
		Dictionary_2_t2736202052 * L_77 = V_5;
		Dictionary_2_Add_m282647386(L_77, _stringLiteral15098073, 0, /*hidden argument*/Dictionary_2_Add_m282647386_RuntimeMethod_var);
		Dictionary_2_t2736202052 * L_78 = V_5;
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->set_U3CU3Ef__switchU24map14_35(L_78);
	}

IL_0253:
	{
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		Dictionary_2_t2736202052 * L_79 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_U3CU3Ef__switchU24map14_35();
		String_t* L_80 = V_4;
		bool L_81 = Dictionary_2_TryGetValue_m1013208020(L_79, L_80, (&V_6), /*hidden argument*/Dictionary_2_TryGetValue_m1013208020_RuntimeMethod_var);
		if (!L_81)
		{
			goto IL_0284;
		}
	}
	{
		int32_t L_82 = V_6;
		if (!L_82)
		{
			goto IL_0272;
		}
	}
	{
		goto IL_0284;
	}

IL_0272:
	{
		StringBuilder_t * L_83 = V_2;
		String_t* L_84 = __this->get_path_6();
		StringBuilder_Append_m1965104174(L_83, L_84, /*hidden argument*/NULL);
		goto IL_02a6;
	}

IL_0284:
	{
		StringBuilder_t * L_85 = V_2;
		String_t* L_86 = __this->get_path_6();
		String_t* L_87 = Uri_get_Scheme_m2109479391(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		bool L_88 = Uri_CompactEscaped_m2984961597(NULL /*static, unused*/, L_87, /*hidden argument*/NULL);
		String_t* L_89 = Uri_Reduce_m3122437040(NULL /*static, unused*/, L_86, L_88, /*hidden argument*/NULL);
		StringBuilder_Append_m1965104174(L_85, L_89, /*hidden argument*/NULL);
		goto IL_02a6;
	}

IL_02a6:
	{
		StringBuilder_t * L_90 = V_2;
		String_t* L_91 = StringBuilder_ToString_m3317489284(L_90, /*hidden argument*/NULL);
		return L_91;
	}

IL_02ad:
	{
		return (String_t*)NULL;
	}
}
// System.Int32 System.Uri::FromHex(System.Char)
extern "C"  int32_t Uri_FromHex_m2610708947 (RuntimeObject * __this /* static, unused */, Il2CppChar ___digit0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_FromHex_m2610708947_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		Il2CppChar L_0 = ___digit0;
		if ((((int32_t)((int32_t)48)) > ((int32_t)L_0)))
		{
			goto IL_0015;
		}
	}
	{
		Il2CppChar L_1 = ___digit0;
		if ((((int32_t)L_1) > ((int32_t)((int32_t)57))))
		{
			goto IL_0015;
		}
	}
	{
		Il2CppChar L_2 = ___digit0;
		return ((int32_t)il2cpp_codegen_subtract((int32_t)L_2, (int32_t)((int32_t)48)));
	}

IL_0015:
	{
		Il2CppChar L_3 = ___digit0;
		if ((((int32_t)((int32_t)97)) > ((int32_t)L_3)))
		{
			goto IL_002d;
		}
	}
	{
		Il2CppChar L_4 = ___digit0;
		if ((((int32_t)L_4) > ((int32_t)((int32_t)102))))
		{
			goto IL_002d;
		}
	}
	{
		Il2CppChar L_5 = ___digit0;
		return ((int32_t)il2cpp_codegen_add((int32_t)((int32_t)il2cpp_codegen_subtract((int32_t)L_5, (int32_t)((int32_t)97))), (int32_t)((int32_t)10)));
	}

IL_002d:
	{
		Il2CppChar L_6 = ___digit0;
		if ((((int32_t)((int32_t)65)) > ((int32_t)L_6)))
		{
			goto IL_0045;
		}
	}
	{
		Il2CppChar L_7 = ___digit0;
		if ((((int32_t)L_7) > ((int32_t)((int32_t)70))))
		{
			goto IL_0045;
		}
	}
	{
		Il2CppChar L_8 = ___digit0;
		return ((int32_t)il2cpp_codegen_add((int32_t)((int32_t)il2cpp_codegen_subtract((int32_t)L_8, (int32_t)((int32_t)65))), (int32_t)((int32_t)10)));
	}

IL_0045:
	{
		ArgumentException_t132251570 * L_9 = (ArgumentException_t132251570 *)il2cpp_codegen_object_new(ArgumentException_t132251570_il2cpp_TypeInfo_var);
		ArgumentException__ctor_m1312628991(L_9, _stringLiteral2699191085, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_9,Uri_FromHex_m2610708947_RuntimeMethod_var);
	}
}
// System.String System.Uri::HexEscape(System.Char)
extern "C"  String_t* Uri_HexEscape_m1589417657 (RuntimeObject * __this /* static, unused */, Il2CppChar ___character0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_HexEscape_m1589417657_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		Il2CppChar L_0 = ___character0;
		if ((((int32_t)L_0) <= ((int32_t)((int32_t)255))))
		{
			goto IL_0016;
		}
	}
	{
		ArgumentOutOfRangeException_t777629997 * L_1 = (ArgumentOutOfRangeException_t777629997 *)il2cpp_codegen_object_new(ArgumentOutOfRangeException_t777629997_il2cpp_TypeInfo_var);
		ArgumentOutOfRangeException__ctor_m3628145864(L_1, _stringLiteral1776941794, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_1,Uri_HexEscape_m1589417657_RuntimeMethod_var);
	}

IL_0016:
	{
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_2 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_hexUpperChars_19();
		Il2CppChar L_3 = ___character0;
		Il2CppChar L_4 = String_get_Chars_m2986988803(L_2, ((int32_t)((int32_t)((int32_t)((int32_t)L_3&(int32_t)((int32_t)240)))>>(int32_t)4)), /*hidden argument*/NULL);
		Il2CppChar L_5 = L_4;
		RuntimeObject * L_6 = Box(Char_t3634460470_il2cpp_TypeInfo_var, &L_5);
		String_t* L_7 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_hexUpperChars_19();
		Il2CppChar L_8 = ___character0;
		Il2CppChar L_9 = String_get_Chars_m2986988803(L_7, ((int32_t)((int32_t)L_8&(int32_t)((int32_t)15))), /*hidden argument*/NULL);
		Il2CppChar L_10 = L_9;
		RuntimeObject * L_11 = Box(Char_t3634460470_il2cpp_TypeInfo_var, &L_10);
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_12 = String_Concat_m1715369213(NULL /*static, unused*/, _stringLiteral3452614523, L_6, L_11, /*hidden argument*/NULL);
		return L_12;
	}
}
// System.Boolean System.Uri::IsHexDigit(System.Char)
extern "C"  bool Uri_IsHexDigit_m3389749670 (RuntimeObject * __this /* static, unused */, Il2CppChar ___digit0, const RuntimeMethod* method)
{
	int32_t G_B7_0 = 0;
	int32_t G_B9_0 = 0;
	{
		Il2CppChar L_0 = ___digit0;
		if ((((int32_t)((int32_t)48)) > ((int32_t)L_0)))
		{
			goto IL_0010;
		}
	}
	{
		Il2CppChar L_1 = ___digit0;
		if ((((int32_t)L_1) <= ((int32_t)((int32_t)57))))
		{
			goto IL_0035;
		}
	}

IL_0010:
	{
		Il2CppChar L_2 = ___digit0;
		if ((((int32_t)((int32_t)97)) > ((int32_t)L_2)))
		{
			goto IL_0020;
		}
	}
	{
		Il2CppChar L_3 = ___digit0;
		if ((((int32_t)L_3) <= ((int32_t)((int32_t)102))))
		{
			goto IL_0035;
		}
	}

IL_0020:
	{
		Il2CppChar L_4 = ___digit0;
		if ((((int32_t)((int32_t)65)) > ((int32_t)L_4)))
		{
			goto IL_0032;
		}
	}
	{
		Il2CppChar L_5 = ___digit0;
		G_B7_0 = ((((int32_t)((((int32_t)L_5) > ((int32_t)((int32_t)70)))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_0033;
	}

IL_0032:
	{
		G_B7_0 = 0;
	}

IL_0033:
	{
		G_B9_0 = G_B7_0;
		goto IL_0036;
	}

IL_0035:
	{
		G_B9_0 = 1;
	}

IL_0036:
	{
		return (bool)G_B9_0;
	}
}
// System.Boolean System.Uri::IsHexEncoding(System.String,System.Int32)
extern "C"  bool Uri_IsHexEncoding_m3290929897 (RuntimeObject * __this /* static, unused */, String_t* ___pattern0, int32_t ___index1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_IsHexEncoding_m3290929897_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t G_B6_0 = 0;
	{
		int32_t L_0 = ___index1;
		String_t* L_1 = ___pattern0;
		int32_t L_2 = String_get_Length_m3847582255(L_1, /*hidden argument*/NULL);
		if ((((int32_t)((int32_t)il2cpp_codegen_add((int32_t)L_0, (int32_t)3))) <= ((int32_t)L_2)))
		{
			goto IL_0010;
		}
	}
	{
		return (bool)0;
	}

IL_0010:
	{
		String_t* L_3 = ___pattern0;
		int32_t L_4 = ___index1;
		int32_t L_5 = L_4;
		___index1 = ((int32_t)il2cpp_codegen_add((int32_t)L_5, (int32_t)1));
		Il2CppChar L_6 = String_get_Chars_m2986988803(L_3, L_5, /*hidden argument*/NULL);
		if ((!(((uint32_t)L_6) == ((uint32_t)((int32_t)37)))))
		{
			goto IL_0047;
		}
	}
	{
		String_t* L_7 = ___pattern0;
		int32_t L_8 = ___index1;
		int32_t L_9 = L_8;
		___index1 = ((int32_t)il2cpp_codegen_add((int32_t)L_9, (int32_t)1));
		Il2CppChar L_10 = String_get_Chars_m2986988803(L_7, L_9, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		bool L_11 = Uri_IsHexDigit_m3389749670(NULL /*static, unused*/, L_10, /*hidden argument*/NULL);
		if (!L_11)
		{
			goto IL_0047;
		}
	}
	{
		String_t* L_12 = ___pattern0;
		int32_t L_13 = ___index1;
		Il2CppChar L_14 = String_get_Chars_m2986988803(L_12, L_13, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		bool L_15 = Uri_IsHexDigit_m3389749670(NULL /*static, unused*/, L_14, /*hidden argument*/NULL);
		G_B6_0 = ((int32_t)(L_15));
		goto IL_0048;
	}

IL_0047:
	{
		G_B6_0 = 0;
	}

IL_0048:
	{
		return (bool)G_B6_0;
	}
}
// System.Void System.Uri::AppendQueryAndFragment(System.String&)
extern "C"  void Uri_AppendQueryAndFragment_m3170766010 (Uri_t100236324 * __this, String_t** ___result0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_AppendQueryAndFragment_m3170766010_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	String_t* V_0 = NULL;
	String_t* G_B4_0 = NULL;
	{
		String_t* L_0 = __this->get_query_7();
		int32_t L_1 = String_get_Length_m3847582255(L_0, /*hidden argument*/NULL);
		if ((((int32_t)L_1) <= ((int32_t)0)))
		{
			goto IL_005e;
		}
	}
	{
		String_t* L_2 = __this->get_query_7();
		Il2CppChar L_3 = String_get_Chars_m2986988803(L_2, 0, /*hidden argument*/NULL);
		if ((!(((uint32_t)L_3) == ((uint32_t)((int32_t)63)))))
		{
			goto IL_0047;
		}
	}
	{
		Il2CppChar L_4 = ((Il2CppChar)((int32_t)63));
		RuntimeObject * L_5 = Box(Char_t3634460470_il2cpp_TypeInfo_var, &L_4);
		String_t* L_6 = __this->get_query_7();
		String_t* L_7 = String_Substring_m2848979100(L_6, 1, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_8 = Uri_Unescape_m910903869(NULL /*static, unused*/, L_7, (bool)0, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_9 = String_Concat_m904156431(NULL /*static, unused*/, L_5, L_8, /*hidden argument*/NULL);
		G_B4_0 = L_9;
		goto IL_0053;
	}

IL_0047:
	{
		String_t* L_10 = __this->get_query_7();
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_11 = Uri_Unescape_m910903869(NULL /*static, unused*/, L_10, (bool)0, /*hidden argument*/NULL);
		G_B4_0 = L_11;
	}

IL_0053:
	{
		V_0 = G_B4_0;
		String_t** L_12 = ___result0;
		String_t** L_13 = ___result0;
		String_t* L_14 = V_0;
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_15 = String_Concat_m3937257545(NULL /*static, unused*/, (*((String_t**)L_13)), L_14, /*hidden argument*/NULL);
		*((RuntimeObject **)(L_12)) = (RuntimeObject *)L_15;
		Il2CppCodeGenWriteBarrier((RuntimeObject **)(L_12), (RuntimeObject *)L_15);
	}

IL_005e:
	{
		String_t* L_16 = __this->get_fragment_8();
		int32_t L_17 = String_get_Length_m3847582255(L_16, /*hidden argument*/NULL);
		if ((((int32_t)L_17) <= ((int32_t)0)))
		{
			goto IL_007e;
		}
	}
	{
		String_t** L_18 = ___result0;
		String_t** L_19 = ___result0;
		String_t* L_20 = __this->get_fragment_8();
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_21 = String_Concat_m3937257545(NULL /*static, unused*/, (*((String_t**)L_19)), L_20, /*hidden argument*/NULL);
		*((RuntimeObject **)(L_18)) = (RuntimeObject *)L_21;
		Il2CppCodeGenWriteBarrier((RuntimeObject **)(L_18), (RuntimeObject *)L_21);
	}

IL_007e:
	{
		return;
	}
}
// System.String System.Uri::ToString()
extern "C"  String_t* Uri_ToString_m3742105950 (Uri_t100236324 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_ToString_m3742105950_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		String_t* L_0 = __this->get_cachedToString_16();
		if (!L_0)
		{
			goto IL_0012;
		}
	}
	{
		String_t* L_1 = __this->get_cachedToString_16();
		return L_1;
	}

IL_0012:
	{
		bool L_2 = __this->get_isAbsoluteUri_12();
		if (!L_2)
		{
			goto IL_0035;
		}
	}
	{
		String_t* L_3 = Uri_GetLeftPart_m3979111399(__this, 2, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_4 = Uri_Unescape_m910903869(NULL /*static, unused*/, L_3, (bool)1, /*hidden argument*/NULL);
		__this->set_cachedToString_16(L_4);
		goto IL_0047;
	}

IL_0035:
	{
		String_t* L_5 = __this->get_path_6();
		String_t* L_6 = VirtFuncInvoker1< String_t*, String_t* >::Invoke(4 /* System.String System.Uri::Unescape(System.String) */, __this, L_5);
		__this->set_cachedToString_16(L_6);
	}

IL_0047:
	{
		String_t** L_7 = __this->get_address_of_cachedToString_16();
		Uri_AppendQueryAndFragment_m3170766010(__this, L_7, /*hidden argument*/NULL);
		String_t* L_8 = __this->get_cachedToString_16();
		return L_8;
	}
}
// System.String System.Uri::EscapeString(System.String)
extern "C"  String_t* Uri_EscapeString_m2061933484 (RuntimeObject * __this /* static, unused */, String_t* ___str0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_EscapeString_m2061933484_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		String_t* L_0 = ___str0;
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_1 = Uri_EscapeString_m3864445955(NULL /*static, unused*/, L_0, (bool)0, (bool)1, (bool)1, /*hidden argument*/NULL);
		return L_1;
	}
}
// System.String System.Uri::EscapeString(System.String,System.Boolean,System.Boolean,System.Boolean)
extern "C"  String_t* Uri_EscapeString_m3864445955 (RuntimeObject * __this /* static, unused */, String_t* ___str0, bool ___escapeReserved1, bool ___escapeHex2, bool ___escapeBrackets3, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_EscapeString_m3864445955_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	StringBuilder_t * V_0 = NULL;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	ByteU5BU5D_t4116647657* V_3 = NULL;
	int32_t V_4 = 0;
	int32_t V_5 = 0;
	Il2CppChar V_6 = 0x0;
	{
		String_t* L_0 = ___str0;
		if (L_0)
		{
			goto IL_000c;
		}
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_1 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		return L_1;
	}

IL_000c:
	{
		StringBuilder_t * L_2 = (StringBuilder_t *)il2cpp_codegen_object_new(StringBuilder_t_il2cpp_TypeInfo_var);
		StringBuilder__ctor_m3121283359(L_2, /*hidden argument*/NULL);
		V_0 = L_2;
		String_t* L_3 = ___str0;
		int32_t L_4 = String_get_Length_m3847582255(L_3, /*hidden argument*/NULL);
		V_1 = L_4;
		V_2 = 0;
		goto IL_0105;
	}

IL_0020:
	{
		String_t* L_5 = ___str0;
		int32_t L_6 = V_2;
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		bool L_7 = Uri_IsHexEncoding_m3290929897(NULL /*static, unused*/, L_5, L_6, /*hidden argument*/NULL);
		if (!L_7)
		{
			goto IL_0044;
		}
	}
	{
		StringBuilder_t * L_8 = V_0;
		String_t* L_9 = ___str0;
		int32_t L_10 = V_2;
		String_t* L_11 = String_Substring_m1610150815(L_9, L_10, 3, /*hidden argument*/NULL);
		StringBuilder_Append_m1965104174(L_8, L_11, /*hidden argument*/NULL);
		int32_t L_12 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add((int32_t)L_12, (int32_t)2));
		goto IL_0101;
	}

IL_0044:
	{
		IL2CPP_RUNTIME_CLASS_INIT(Encoding_t1523322056_il2cpp_TypeInfo_var);
		Encoding_t1523322056 * L_13 = Encoding_get_UTF8_m1008486739(NULL /*static, unused*/, /*hidden argument*/NULL);
		CharU5BU5D_t3528271667* L_14 = ((CharU5BU5D_t3528271667*)SZArrayNew(CharU5BU5D_t3528271667_il2cpp_TypeInfo_var, (uint32_t)1));
		String_t* L_15 = ___str0;
		int32_t L_16 = V_2;
		Il2CppChar L_17 = String_get_Chars_m2986988803(L_15, L_16, /*hidden argument*/NULL);
		(L_14)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(0), (Il2CppChar)L_17);
		ByteU5BU5D_t4116647657* L_18 = VirtFuncInvoker1< ByteU5BU5D_t4116647657*, CharU5BU5D_t3528271667* >::Invoke(12 /* System.Byte[] System.Text.Encoding::GetBytes(System.Char[]) */, L_13, L_14);
		V_3 = L_18;
		ByteU5BU5D_t4116647657* L_19 = V_3;
		V_4 = (((int32_t)((int32_t)(((RuntimeArray *)L_19)->max_length))));
		V_5 = 0;
		goto IL_00f8;
	}

IL_006c:
	{
		ByteU5BU5D_t4116647657* L_20 = V_3;
		int32_t L_21 = V_5;
		int32_t L_22 = L_21;
		uint8_t L_23 = (L_20)->GetAtUnchecked(static_cast<il2cpp_array_size_t>(L_22));
		V_6 = (((int32_t)((uint16_t)L_23)));
		Il2CppChar L_24 = V_6;
		if ((((int32_t)L_24) <= ((int32_t)((int32_t)32))))
		{
			goto IL_00d6;
		}
	}
	{
		Il2CppChar L_25 = V_6;
		if ((((int32_t)L_25) >= ((int32_t)((int32_t)127))))
		{
			goto IL_00d6;
		}
	}
	{
		Il2CppChar L_26 = V_6;
		int32_t L_27 = String_IndexOf_m363431711(_stringLiteral1759775709, L_26, /*hidden argument*/NULL);
		if ((!(((uint32_t)L_27) == ((uint32_t)(-1)))))
		{
			goto IL_00d6;
		}
	}
	{
		bool L_28 = ___escapeHex2;
		if (!L_28)
		{
			goto IL_00a6;
		}
	}
	{
		Il2CppChar L_29 = V_6;
		if ((((int32_t)L_29) == ((int32_t)((int32_t)35))))
		{
			goto IL_00d6;
		}
	}

IL_00a6:
	{
		bool L_30 = ___escapeBrackets3;
		if (!L_30)
		{
			goto IL_00be;
		}
	}
	{
		Il2CppChar L_31 = V_6;
		if ((((int32_t)L_31) == ((int32_t)((int32_t)91))))
		{
			goto IL_00d6;
		}
	}
	{
		Il2CppChar L_32 = V_6;
		if ((((int32_t)L_32) == ((int32_t)((int32_t)93))))
		{
			goto IL_00d6;
		}
	}

IL_00be:
	{
		bool L_33 = ___escapeReserved1;
		if (!L_33)
		{
			goto IL_00e9;
		}
	}
	{
		Il2CppChar L_34 = V_6;
		int32_t L_35 = String_IndexOf_m363431711(_stringLiteral259003225, L_34, /*hidden argument*/NULL);
		if ((((int32_t)L_35) == ((int32_t)(-1))))
		{
			goto IL_00e9;
		}
	}

IL_00d6:
	{
		StringBuilder_t * L_36 = V_0;
		Il2CppChar L_37 = V_6;
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_38 = Uri_HexEscape_m1589417657(NULL /*static, unused*/, L_37, /*hidden argument*/NULL);
		StringBuilder_Append_m1965104174(L_36, L_38, /*hidden argument*/NULL);
		goto IL_00f2;
	}

IL_00e9:
	{
		StringBuilder_t * L_39 = V_0;
		Il2CppChar L_40 = V_6;
		StringBuilder_Append_m2383614642(L_39, L_40, /*hidden argument*/NULL);
	}

IL_00f2:
	{
		int32_t L_41 = V_5;
		V_5 = ((int32_t)il2cpp_codegen_add((int32_t)L_41, (int32_t)1));
	}

IL_00f8:
	{
		int32_t L_42 = V_5;
		int32_t L_43 = V_4;
		if ((((int32_t)L_42) < ((int32_t)L_43)))
		{
			goto IL_006c;
		}
	}

IL_0101:
	{
		int32_t L_44 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add((int32_t)L_44, (int32_t)1));
	}

IL_0105:
	{
		int32_t L_45 = V_2;
		int32_t L_46 = V_1;
		if ((((int32_t)L_45) < ((int32_t)L_46)))
		{
			goto IL_0020;
		}
	}
	{
		StringBuilder_t * L_47 = V_0;
		String_t* L_48 = StringBuilder_ToString_m3317489284(L_47, /*hidden argument*/NULL);
		return L_48;
	}
}
// System.Void System.Uri::ParseUri(System.UriKind)
extern "C"  void Uri_ParseUri_m2150795567 (Uri_t100236324 * __this, int32_t ___kind0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_ParseUri_m2150795567_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		int32_t L_0 = ___kind0;
		String_t* L_1 = __this->get_source_2();
		Uri_Parse_m736300106(__this, L_0, L_1, /*hidden argument*/NULL);
		bool L_2 = __this->get_userEscaped_14();
		if (!L_2)
		{
			goto IL_0019;
		}
	}
	{
		return;
	}

IL_0019:
	{
		String_t* L_3 = __this->get_host_4();
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_4 = Uri_EscapeString_m3864445955(NULL /*static, unused*/, L_3, (bool)0, (bool)1, (bool)0, /*hidden argument*/NULL);
		__this->set_host_4(L_4);
		String_t* L_5 = __this->get_host_4();
		int32_t L_6 = String_get_Length_m3847582255(L_5, /*hidden argument*/NULL);
		if ((((int32_t)L_6) <= ((int32_t)1)))
		{
			goto IL_0086;
		}
	}
	{
		String_t* L_7 = __this->get_host_4();
		Il2CppChar L_8 = String_get_Chars_m2986988803(L_7, 0, /*hidden argument*/NULL);
		if ((((int32_t)L_8) == ((int32_t)((int32_t)91))))
		{
			goto IL_0086;
		}
	}
	{
		String_t* L_9 = __this->get_host_4();
		String_t* L_10 = __this->get_host_4();
		int32_t L_11 = String_get_Length_m3847582255(L_10, /*hidden argument*/NULL);
		Il2CppChar L_12 = String_get_Chars_m2986988803(L_9, ((int32_t)il2cpp_codegen_subtract((int32_t)L_11, (int32_t)1)), /*hidden argument*/NULL);
		if ((((int32_t)L_12) == ((int32_t)((int32_t)93))))
		{
			goto IL_0086;
		}
	}
	{
		String_t* L_13 = __this->get_host_4();
		IL2CPP_RUNTIME_CLASS_INIT(CultureInfo_t4157843068_il2cpp_TypeInfo_var);
		CultureInfo_t4157843068 * L_14 = CultureInfo_get_InvariantCulture_m3532445182(NULL /*static, unused*/, /*hidden argument*/NULL);
		String_t* L_15 = String_ToLower_m3490221821(L_13, L_14, /*hidden argument*/NULL);
		__this->set_host_4(L_15);
	}

IL_0086:
	{
		String_t* L_16 = __this->get_path_6();
		int32_t L_17 = String_get_Length_m3847582255(L_16, /*hidden argument*/NULL);
		if ((((int32_t)L_17) <= ((int32_t)0)))
		{
			goto IL_00a8;
		}
	}
	{
		String_t* L_18 = __this->get_path_6();
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_19 = Uri_EscapeString_m2061933484(NULL /*static, unused*/, L_18, /*hidden argument*/NULL);
		__this->set_path_6(L_19);
	}

IL_00a8:
	{
		return;
	}
}
// System.String System.Uri::Unescape(System.String)
extern "C"  String_t* Uri_Unescape_m3373094076 (Uri_t100236324 * __this, String_t* ___str0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_Unescape_m3373094076_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		String_t* L_0 = ___str0;
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_1 = Uri_Unescape_m910903869(NULL /*static, unused*/, L_0, (bool)0, /*hidden argument*/NULL);
		return L_1;
	}
}
// System.String System.Uri::Unescape(System.String,System.Boolean)
extern "C"  String_t* Uri_Unescape_m910903869 (RuntimeObject * __this /* static, unused */, String_t* ___str0, bool ___excludeSpecial1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_Unescape_m910903869_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	StringBuilder_t * V_0 = NULL;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	Il2CppChar V_3 = 0x0;
	Il2CppChar V_4 = 0x0;
	Il2CppChar V_5 = 0x0;
	{
		String_t* L_0 = ___str0;
		if (L_0)
		{
			goto IL_000c;
		}
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_1 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		return L_1;
	}

IL_000c:
	{
		StringBuilder_t * L_2 = (StringBuilder_t *)il2cpp_codegen_object_new(StringBuilder_t_il2cpp_TypeInfo_var);
		StringBuilder__ctor_m3121283359(L_2, /*hidden argument*/NULL);
		V_0 = L_2;
		String_t* L_3 = ___str0;
		int32_t L_4 = String_get_Length_m3847582255(L_3, /*hidden argument*/NULL);
		V_1 = L_4;
		V_2 = 0;
		goto IL_00ca;
	}

IL_0020:
	{
		String_t* L_5 = ___str0;
		int32_t L_6 = V_2;
		Il2CppChar L_7 = String_get_Chars_m2986988803(L_5, L_6, /*hidden argument*/NULL);
		V_3 = L_7;
		Il2CppChar L_8 = V_3;
		if ((!(((uint32_t)L_8) == ((uint32_t)((int32_t)37)))))
		{
			goto IL_00be;
		}
	}
	{
		String_t* L_9 = ___str0;
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		Il2CppChar L_10 = Uri_HexUnescapeMultiByte_m332853996(NULL /*static, unused*/, L_9, (&V_2), (&V_4), /*hidden argument*/NULL);
		V_5 = L_10;
		bool L_11 = ___excludeSpecial1;
		if (!L_11)
		{
			goto IL_005c;
		}
	}
	{
		Il2CppChar L_12 = V_5;
		if ((!(((uint32_t)L_12) == ((uint32_t)((int32_t)35)))))
		{
			goto IL_005c;
		}
	}
	{
		StringBuilder_t * L_13 = V_0;
		StringBuilder_Append_m1965104174(L_13, _stringLiteral2671228134, /*hidden argument*/NULL);
		goto IL_00b5;
	}

IL_005c:
	{
		bool L_14 = ___excludeSpecial1;
		if (!L_14)
		{
			goto IL_007c;
		}
	}
	{
		Il2CppChar L_15 = V_5;
		if ((!(((uint32_t)L_15) == ((uint32_t)((int32_t)37)))))
		{
			goto IL_007c;
		}
	}
	{
		StringBuilder_t * L_16 = V_0;
		StringBuilder_Append_m1965104174(L_16, _stringLiteral3834027548, /*hidden argument*/NULL);
		goto IL_00b5;
	}

IL_007c:
	{
		bool L_17 = ___excludeSpecial1;
		if (!L_17)
		{
			goto IL_009c;
		}
	}
	{
		Il2CppChar L_18 = V_5;
		if ((!(((uint32_t)L_18) == ((uint32_t)((int32_t)63)))))
		{
			goto IL_009c;
		}
	}
	{
		StringBuilder_t * L_19 = V_0;
		StringBuilder_Append_m1965104174(L_19, _stringLiteral3000541767, /*hidden argument*/NULL);
		goto IL_00b5;
	}

IL_009c:
	{
		StringBuilder_t * L_20 = V_0;
		Il2CppChar L_21 = V_5;
		StringBuilder_Append_m2383614642(L_20, L_21, /*hidden argument*/NULL);
		Il2CppChar L_22 = V_4;
		if (!L_22)
		{
			goto IL_00b5;
		}
	}
	{
		StringBuilder_t * L_23 = V_0;
		Il2CppChar L_24 = V_4;
		StringBuilder_Append_m2383614642(L_23, L_24, /*hidden argument*/NULL);
	}

IL_00b5:
	{
		int32_t L_25 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_subtract((int32_t)L_25, (int32_t)1));
		goto IL_00c6;
	}

IL_00be:
	{
		StringBuilder_t * L_26 = V_0;
		Il2CppChar L_27 = V_3;
		StringBuilder_Append_m2383614642(L_26, L_27, /*hidden argument*/NULL);
	}

IL_00c6:
	{
		int32_t L_28 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add((int32_t)L_28, (int32_t)1));
	}

IL_00ca:
	{
		int32_t L_29 = V_2;
		int32_t L_30 = V_1;
		if ((((int32_t)L_29) < ((int32_t)L_30)))
		{
			goto IL_0020;
		}
	}
	{
		StringBuilder_t * L_31 = V_0;
		String_t* L_32 = StringBuilder_ToString_m3317489284(L_31, /*hidden argument*/NULL);
		return L_32;
	}
}
// System.Void System.Uri::ParseAsWindowsUNC(System.String)
extern "C"  void Uri_ParseAsWindowsUNC_m2348878458 (Uri_t100236324 * __this, String_t* ___uriString0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_ParseAsWindowsUNC_m2348878458_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_0 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeFile_21();
		__this->set_scheme_3(L_0);
		__this->set_port_5((-1));
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_1 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_fragment_8(L_1);
		String_t* L_2 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_query_7(L_2);
		__this->set_isUnc_10((bool)1);
		String_t* L_3 = ___uriString0;
		CharU5BU5D_t3528271667* L_4 = ((CharU5BU5D_t3528271667*)SZArrayNew(CharU5BU5D_t3528271667_il2cpp_TypeInfo_var, (uint32_t)1));
		(L_4)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(0), (Il2CppChar)((int32_t)92));
		String_t* L_5 = String_TrimStart_m1431283012(L_3, L_4, /*hidden argument*/NULL);
		___uriString0 = L_5;
		String_t* L_6 = ___uriString0;
		int32_t L_7 = String_IndexOf_m363431711(L_6, ((int32_t)92), /*hidden argument*/NULL);
		V_0 = L_7;
		int32_t L_8 = V_0;
		if ((((int32_t)L_8) <= ((int32_t)0)))
		{
			goto IL_0072;
		}
	}
	{
		String_t* L_9 = ___uriString0;
		int32_t L_10 = V_0;
		String_t* L_11 = String_Substring_m2848979100(L_9, L_10, /*hidden argument*/NULL);
		__this->set_path_6(L_11);
		String_t* L_12 = ___uriString0;
		int32_t L_13 = V_0;
		String_t* L_14 = String_Substring_m1610150815(L_12, 0, L_13, /*hidden argument*/NULL);
		__this->set_host_4(L_14);
		goto IL_0084;
	}

IL_0072:
	{
		String_t* L_15 = ___uriString0;
		__this->set_host_4(L_15);
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_16 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_path_6(L_16);
	}

IL_0084:
	{
		String_t* L_17 = __this->get_path_6();
		String_t* L_18 = String_Replace_m1273907647(L_17, _stringLiteral3452614644, _stringLiteral3452614529, /*hidden argument*/NULL);
		__this->set_path_6(L_18);
		return;
	}
}
// System.String System.Uri::ParseAsWindowsAbsoluteFilePath(System.String)
extern "C"  String_t* Uri_ParseAsWindowsAbsoluteFilePath_m708354183 (Uri_t100236324 * __this, String_t* ___uriString0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_ParseAsWindowsAbsoluteFilePath_m708354183_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		String_t* L_0 = ___uriString0;
		int32_t L_1 = String_get_Length_m3847582255(L_0, /*hidden argument*/NULL);
		if ((((int32_t)L_1) <= ((int32_t)2)))
		{
			goto IL_002e;
		}
	}
	{
		String_t* L_2 = ___uriString0;
		Il2CppChar L_3 = String_get_Chars_m2986988803(L_2, 2, /*hidden argument*/NULL);
		if ((((int32_t)L_3) == ((int32_t)((int32_t)92))))
		{
			goto IL_002e;
		}
	}
	{
		String_t* L_4 = ___uriString0;
		Il2CppChar L_5 = String_get_Chars_m2986988803(L_4, 2, /*hidden argument*/NULL);
		if ((((int32_t)L_5) == ((int32_t)((int32_t)47))))
		{
			goto IL_002e;
		}
	}
	{
		return _stringLiteral796679200;
	}

IL_002e:
	{
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_6 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeFile_21();
		__this->set_scheme_3(L_6);
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_7 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_host_4(L_7);
		__this->set_port_5((-1));
		String_t* L_8 = ___uriString0;
		String_t* L_9 = String_Replace_m1273907647(L_8, _stringLiteral3452614644, _stringLiteral3452614529, /*hidden argument*/NULL);
		__this->set_path_6(L_9);
		String_t* L_10 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_fragment_8(L_10);
		String_t* L_11 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_query_7(L_11);
		return (String_t*)NULL;
	}
}
// System.Void System.Uri::ParseAsUnixAbsoluteFilePath(System.String)
extern "C"  void Uri_ParseAsUnixAbsoluteFilePath_m1476768041 (Uri_t100236324 * __this, String_t* ___uriString0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_ParseAsUnixAbsoluteFilePath_m1476768041_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		__this->set_isUnixFilePath_1((bool)1);
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_0 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeFile_21();
		__this->set_scheme_3(L_0);
		__this->set_port_5((-1));
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_1 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_fragment_8(L_1);
		String_t* L_2 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_query_7(L_2);
		String_t* L_3 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_host_4(L_3);
		__this->set_path_6((String_t*)NULL);
		String_t* L_4 = ___uriString0;
		int32_t L_5 = String_get_Length_m3847582255(L_4, /*hidden argument*/NULL);
		if ((((int32_t)L_5) < ((int32_t)2)))
		{
			goto IL_008f;
		}
	}
	{
		String_t* L_6 = ___uriString0;
		Il2CppChar L_7 = String_get_Chars_m2986988803(L_6, 0, /*hidden argument*/NULL);
		if ((!(((uint32_t)L_7) == ((uint32_t)((int32_t)47)))))
		{
			goto IL_008f;
		}
	}
	{
		String_t* L_8 = ___uriString0;
		Il2CppChar L_9 = String_get_Chars_m2986988803(L_8, 1, /*hidden argument*/NULL);
		if ((!(((uint32_t)L_9) == ((uint32_t)((int32_t)47)))))
		{
			goto IL_008f;
		}
	}
	{
		String_t* L_10 = ___uriString0;
		CharU5BU5D_t3528271667* L_11 = ((CharU5BU5D_t3528271667*)SZArrayNew(CharU5BU5D_t3528271667_il2cpp_TypeInfo_var, (uint32_t)1));
		(L_11)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(0), (Il2CppChar)((int32_t)47));
		String_t* L_12 = String_TrimStart_m1431283012(L_10, L_11, /*hidden argument*/NULL);
		___uriString0 = L_12;
		Il2CppChar L_13 = ((Il2CppChar)((int32_t)47));
		RuntimeObject * L_14 = Box(Char_t3634460470_il2cpp_TypeInfo_var, &L_13);
		String_t* L_15 = ___uriString0;
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_16 = String_Concat_m904156431(NULL /*static, unused*/, L_14, L_15, /*hidden argument*/NULL);
		__this->set_path_6(L_16);
	}

IL_008f:
	{
		String_t* L_17 = __this->get_path_6();
		if (L_17)
		{
			goto IL_00a1;
		}
	}
	{
		String_t* L_18 = ___uriString0;
		__this->set_path_6(L_18);
	}

IL_00a1:
	{
		return;
	}
}
// System.Void System.Uri::Parse(System.UriKind,System.String)
extern "C"  void Uri_Parse_m736300106 (Uri_t100236324 * __this, int32_t ___kind0, String_t* ___uriString1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_Parse_m736300106_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	String_t* V_0 = NULL;
	{
		String_t* L_0 = ___uriString1;
		if (L_0)
		{
			goto IL_0011;
		}
	}
	{
		ArgumentNullException_t1615371798 * L_1 = (ArgumentNullException_t1615371798 *)il2cpp_codegen_object_new(ArgumentNullException_t1615371798_il2cpp_TypeInfo_var);
		ArgumentNullException__ctor_m1170824041(L_1, _stringLiteral3582941166, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_1,Uri_Parse_m736300106_RuntimeMethod_var);
	}

IL_0011:
	{
		int32_t L_2 = ___kind0;
		String_t* L_3 = ___uriString1;
		String_t* L_4 = Uri_ParseNoExceptions_m4274141693(__this, L_2, L_3, /*hidden argument*/NULL);
		V_0 = L_4;
		String_t* L_5 = V_0;
		if (!L_5)
		{
			goto IL_0027;
		}
	}
	{
		String_t* L_6 = V_0;
		UriFormatException_t953270471 * L_7 = (UriFormatException_t953270471 *)il2cpp_codegen_object_new(UriFormatException_t953270471_il2cpp_TypeInfo_var);
		UriFormatException__ctor_m3083316541(L_7, L_6, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_7,Uri_Parse_m736300106_RuntimeMethod_var);
	}

IL_0027:
	{
		return;
	}
}
// System.String System.Uri::ParseNoExceptions(System.UriKind,System.String)
extern "C"  String_t* Uri_ParseNoExceptions_m4274141693 (Uri_t100236324 * __this, int32_t ___kind0, String_t* ___uriString1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_ParseNoExceptions_m4274141693_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	String_t* V_2 = NULL;
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	bool V_5 = false;
	bool V_6 = false;
	bool V_7 = false;
	int32_t V_8 = 0;
	int32_t V_9 = 0;
	String_t* V_10 = NULL;
	bool V_11 = false;
	IPv6Address_t2709566769 * V_12 = NULL;
	UriFormatException_t953270471 * V_13 = NULL;
	int32_t G_B50_0 = 0;
	int32_t G_B55_0 = 0;
	int32_t G_B57_0 = 0;
	int32_t G_B139_0 = 0;
	{
		String_t* L_0 = ___uriString1;
		String_t* L_1 = String_Trim_m923598732(L_0, /*hidden argument*/NULL);
		___uriString1 = L_1;
		String_t* L_2 = ___uriString1;
		int32_t L_3 = String_get_Length_m3847582255(L_2, /*hidden argument*/NULL);
		V_0 = L_3;
		int32_t L_4 = V_0;
		if (L_4)
		{
			goto IL_002b;
		}
	}
	{
		int32_t L_5 = ___kind0;
		if ((((int32_t)L_5) == ((int32_t)2)))
		{
			goto IL_0022;
		}
	}
	{
		int32_t L_6 = ___kind0;
		if (L_6)
		{
			goto IL_002b;
		}
	}

IL_0022:
	{
		__this->set_isAbsoluteUri_12((bool)0);
		return (String_t*)NULL;
	}

IL_002b:
	{
		int32_t L_7 = V_0;
		if ((((int32_t)L_7) > ((int32_t)1)))
		{
			goto IL_003f;
		}
	}
	{
		int32_t L_8 = ___kind0;
		if ((((int32_t)L_8) == ((int32_t)2)))
		{
			goto IL_003f;
		}
	}
	{
		return _stringLiteral3313991234;
	}

IL_003f:
	{
		V_1 = 0;
		String_t* L_9 = ___uriString1;
		int32_t L_10 = String_IndexOf_m363431711(L_9, ((int32_t)58), /*hidden argument*/NULL);
		V_1 = L_10;
		int32_t L_11 = V_1;
		if (L_11)
		{
			goto IL_0056;
		}
	}
	{
		return _stringLiteral1267661654;
	}

IL_0056:
	{
		int32_t L_12 = V_1;
		if ((((int32_t)L_12) >= ((int32_t)0)))
		{
			goto IL_00d5;
		}
	}
	{
		String_t* L_13 = ___uriString1;
		Il2CppChar L_14 = String_get_Chars_m2986988803(L_13, 0, /*hidden argument*/NULL);
		if ((!(((uint32_t)L_14) == ((uint32_t)((int32_t)47)))))
		{
			goto IL_0091;
		}
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(Path_t1605229823_il2cpp_TypeInfo_var);
		Il2CppChar L_15 = ((Path_t1605229823_StaticFields*)il2cpp_codegen_static_fields_for(Path_t1605229823_il2cpp_TypeInfo_var))->get_DirectorySeparatorChar_2();
		if ((!(((uint32_t)L_15) == ((uint32_t)((int32_t)47)))))
		{
			goto IL_0091;
		}
	}
	{
		String_t* L_16 = ___uriString1;
		Uri_ParseAsUnixAbsoluteFilePath_m1476768041(__this, L_16, /*hidden argument*/NULL);
		int32_t L_17 = ___kind0;
		if ((!(((uint32_t)L_17) == ((uint32_t)2))))
		{
			goto IL_008c;
		}
	}
	{
		__this->set_isAbsoluteUri_12((bool)0);
	}

IL_008c:
	{
		goto IL_00d3;
	}

IL_0091:
	{
		String_t* L_18 = ___uriString1;
		int32_t L_19 = String_get_Length_m3847582255(L_18, /*hidden argument*/NULL);
		if ((((int32_t)L_19) < ((int32_t)2)))
		{
			goto IL_00c5;
		}
	}
	{
		String_t* L_20 = ___uriString1;
		Il2CppChar L_21 = String_get_Chars_m2986988803(L_20, 0, /*hidden argument*/NULL);
		if ((!(((uint32_t)L_21) == ((uint32_t)((int32_t)92)))))
		{
			goto IL_00c5;
		}
	}
	{
		String_t* L_22 = ___uriString1;
		Il2CppChar L_23 = String_get_Chars_m2986988803(L_22, 1, /*hidden argument*/NULL);
		if ((!(((uint32_t)L_23) == ((uint32_t)((int32_t)92)))))
		{
			goto IL_00c5;
		}
	}
	{
		String_t* L_24 = ___uriString1;
		Uri_ParseAsWindowsUNC_m2348878458(__this, L_24, /*hidden argument*/NULL);
		goto IL_00d3;
	}

IL_00c5:
	{
		__this->set_isAbsoluteUri_12((bool)0);
		String_t* L_25 = ___uriString1;
		__this->set_path_6(L_25);
	}

IL_00d3:
	{
		return (String_t*)NULL;
	}

IL_00d5:
	{
		int32_t L_26 = V_1;
		if ((!(((uint32_t)L_26) == ((uint32_t)1))))
		{
			goto IL_0105;
		}
	}
	{
		String_t* L_27 = ___uriString1;
		Il2CppChar L_28 = String_get_Chars_m2986988803(L_27, 0, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		bool L_29 = Uri_IsAlpha_m1282293464(NULL /*static, unused*/, L_28, /*hidden argument*/NULL);
		if (L_29)
		{
			goto IL_00f3;
		}
	}
	{
		return _stringLiteral1563818855;
	}

IL_00f3:
	{
		String_t* L_30 = ___uriString1;
		String_t* L_31 = Uri_ParseAsWindowsAbsoluteFilePath_m708354183(__this, L_30, /*hidden argument*/NULL);
		V_2 = L_31;
		String_t* L_32 = V_2;
		if (!L_32)
		{
			goto IL_0103;
		}
	}
	{
		String_t* L_33 = V_2;
		return L_33;
	}

IL_0103:
	{
		return (String_t*)NULL;
	}

IL_0105:
	{
		String_t* L_34 = ___uriString1;
		int32_t L_35 = V_1;
		String_t* L_36 = String_Substring_m1610150815(L_34, 0, L_35, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(CultureInfo_t4157843068_il2cpp_TypeInfo_var);
		CultureInfo_t4157843068 * L_37 = CultureInfo_get_InvariantCulture_m3532445182(NULL /*static, unused*/, /*hidden argument*/NULL);
		String_t* L_38 = String_ToLower_m3490221821(L_36, L_37, /*hidden argument*/NULL);
		__this->set_scheme_3(L_38);
		String_t* L_39 = __this->get_scheme_3();
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		bool L_40 = Uri_CheckSchemeName_m108657675(NULL /*static, unused*/, L_39, /*hidden argument*/NULL);
		if (L_40)
		{
			goto IL_0138;
		}
	}
	{
		String_t* L_41 = Locale_GetText_m3875126938(NULL /*static, unused*/, _stringLiteral3874466473, /*hidden argument*/NULL);
		return L_41;
	}

IL_0138:
	{
		int32_t L_42 = V_1;
		V_3 = ((int32_t)il2cpp_codegen_add((int32_t)L_42, (int32_t)1));
		String_t* L_43 = ___uriString1;
		int32_t L_44 = String_get_Length_m3847582255(L_43, /*hidden argument*/NULL);
		V_4 = L_44;
		String_t* L_45 = ___uriString1;
		int32_t L_46 = V_3;
		int32_t L_47 = String_IndexOf_m2466398549(L_45, ((int32_t)35), L_46, /*hidden argument*/NULL);
		V_1 = L_47;
		bool L_48 = Uri_get_IsUnc_m2977972311(__this, /*hidden argument*/NULL);
		if (L_48)
		{
			goto IL_019e;
		}
	}
	{
		int32_t L_49 = V_1;
		if ((((int32_t)L_49) == ((int32_t)(-1))))
		{
			goto IL_019e;
		}
	}
	{
		bool L_50 = __this->get_userEscaped_14();
		if (!L_50)
		{
			goto IL_017d;
		}
	}
	{
		String_t* L_51 = ___uriString1;
		int32_t L_52 = V_1;
		String_t* L_53 = String_Substring_m2848979100(L_51, L_52, /*hidden argument*/NULL);
		__this->set_fragment_8(L_53);
		goto IL_019b;
	}

IL_017d:
	{
		String_t* L_54 = ___uriString1;
		int32_t L_55 = V_1;
		String_t* L_56 = String_Substring_m2848979100(L_54, ((int32_t)il2cpp_codegen_add((int32_t)L_55, (int32_t)1)), /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_57 = Uri_EscapeString_m2061933484(NULL /*static, unused*/, L_56, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_58 = String_Concat_m3937257545(NULL /*static, unused*/, _stringLiteral3452614525, L_57, /*hidden argument*/NULL);
		__this->set_fragment_8(L_58);
	}

IL_019b:
	{
		int32_t L_59 = V_1;
		V_4 = L_59;
	}

IL_019e:
	{
		String_t* L_60 = ___uriString1;
		int32_t L_61 = V_3;
		int32_t L_62 = V_4;
		int32_t L_63 = V_3;
		int32_t L_64 = String_IndexOf_m1248948328(L_60, ((int32_t)63), L_61, ((int32_t)il2cpp_codegen_subtract((int32_t)L_62, (int32_t)L_63)), /*hidden argument*/NULL);
		V_1 = L_64;
		int32_t L_65 = V_1;
		if ((((int32_t)L_65) == ((int32_t)(-1))))
		{
			goto IL_01e3;
		}
	}
	{
		String_t* L_66 = ___uriString1;
		int32_t L_67 = V_1;
		int32_t L_68 = V_4;
		int32_t L_69 = V_1;
		String_t* L_70 = String_Substring_m1610150815(L_66, L_67, ((int32_t)il2cpp_codegen_subtract((int32_t)L_68, (int32_t)L_69)), /*hidden argument*/NULL);
		__this->set_query_7(L_70);
		int32_t L_71 = V_1;
		V_4 = L_71;
		bool L_72 = __this->get_userEscaped_14();
		if (L_72)
		{
			goto IL_01e3;
		}
	}
	{
		String_t* L_73 = __this->get_query_7();
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_74 = Uri_EscapeString_m2061933484(NULL /*static, unused*/, L_73, /*hidden argument*/NULL);
		__this->set_query_7(L_74);
	}

IL_01e3:
	{
		String_t* L_75 = __this->get_scheme_3();
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		bool L_76 = Uri_IsPredefinedScheme_m1188665625(NULL /*static, unused*/, L_75, /*hidden argument*/NULL);
		if (!L_76)
		{
			goto IL_0255;
		}
	}
	{
		String_t* L_77 = __this->get_scheme_3();
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_78 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeMailto_26();
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_79 = String_op_Inequality_m215368492(NULL /*static, unused*/, L_77, L_78, /*hidden argument*/NULL);
		if (!L_79)
		{
			goto IL_0255;
		}
	}
	{
		String_t* L_80 = __this->get_scheme_3();
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_81 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeNews_27();
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_82 = String_op_Inequality_m215368492(NULL /*static, unused*/, L_80, L_81, /*hidden argument*/NULL);
		if (!L_82)
		{
			goto IL_0255;
		}
	}
	{
		int32_t L_83 = V_4;
		int32_t L_84 = V_3;
		if ((((int32_t)((int32_t)il2cpp_codegen_subtract((int32_t)L_83, (int32_t)L_84))) < ((int32_t)2)))
		{
			goto IL_024f;
		}
	}
	{
		int32_t L_85 = V_4;
		int32_t L_86 = V_3;
		if ((((int32_t)((int32_t)il2cpp_codegen_subtract((int32_t)L_85, (int32_t)L_86))) < ((int32_t)2)))
		{
			goto IL_0255;
		}
	}
	{
		String_t* L_87 = ___uriString1;
		int32_t L_88 = V_3;
		Il2CppChar L_89 = String_get_Chars_m2986988803(L_87, L_88, /*hidden argument*/NULL);
		if ((!(((uint32_t)L_89) == ((uint32_t)((int32_t)47)))))
		{
			goto IL_0255;
		}
	}
	{
		String_t* L_90 = ___uriString1;
		int32_t L_91 = V_3;
		Il2CppChar L_92 = String_get_Chars_m2986988803(L_90, ((int32_t)il2cpp_codegen_add((int32_t)L_91, (int32_t)1)), /*hidden argument*/NULL);
		if ((((int32_t)L_92) == ((int32_t)((int32_t)47))))
		{
			goto IL_0255;
		}
	}

IL_024f:
	{
		return _stringLiteral94042051;
	}

IL_0255:
	{
		int32_t L_93 = V_4;
		int32_t L_94 = V_3;
		if ((((int32_t)((int32_t)il2cpp_codegen_subtract((int32_t)L_93, (int32_t)L_94))) < ((int32_t)2)))
		{
			goto IL_027c;
		}
	}
	{
		String_t* L_95 = ___uriString1;
		int32_t L_96 = V_3;
		Il2CppChar L_97 = String_get_Chars_m2986988803(L_95, L_96, /*hidden argument*/NULL);
		if ((!(((uint32_t)L_97) == ((uint32_t)((int32_t)47)))))
		{
			goto IL_027c;
		}
	}
	{
		String_t* L_98 = ___uriString1;
		int32_t L_99 = V_3;
		Il2CppChar L_100 = String_get_Chars_m2986988803(L_98, ((int32_t)il2cpp_codegen_add((int32_t)L_99, (int32_t)1)), /*hidden argument*/NULL);
		G_B50_0 = ((((int32_t)L_100) == ((int32_t)((int32_t)47)))? 1 : 0);
		goto IL_027d;
	}

IL_027c:
	{
		G_B50_0 = 0;
	}

IL_027d:
	{
		V_5 = (bool)G_B50_0;
		String_t* L_101 = __this->get_scheme_3();
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_102 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeFile_21();
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_103 = String_op_Equality_m920492651(NULL /*static, unused*/, L_101, L_102, /*hidden argument*/NULL);
		if (!L_103)
		{
			goto IL_02b7;
		}
	}
	{
		bool L_104 = V_5;
		if (!L_104)
		{
			goto IL_02b7;
		}
	}
	{
		int32_t L_105 = V_4;
		int32_t L_106 = V_3;
		if ((((int32_t)((int32_t)il2cpp_codegen_subtract((int32_t)L_105, (int32_t)L_106))) == ((int32_t)2)))
		{
			goto IL_02b4;
		}
	}
	{
		String_t* L_107 = ___uriString1;
		int32_t L_108 = V_3;
		Il2CppChar L_109 = String_get_Chars_m2986988803(L_107, ((int32_t)il2cpp_codegen_add((int32_t)L_108, (int32_t)2)), /*hidden argument*/NULL);
		G_B55_0 = ((((int32_t)L_109) == ((int32_t)((int32_t)47)))? 1 : 0);
		goto IL_02b5;
	}

IL_02b4:
	{
		G_B55_0 = 1;
	}

IL_02b5:
	{
		G_B57_0 = G_B55_0;
		goto IL_02b8;
	}

IL_02b7:
	{
		G_B57_0 = 0;
	}

IL_02b8:
	{
		V_6 = (bool)G_B57_0;
		V_7 = (bool)0;
		bool L_110 = V_5;
		if (!L_110)
		{
			goto IL_03a8;
		}
	}
	{
		int32_t L_111 = ___kind0;
		if ((!(((uint32_t)L_111) == ((uint32_t)2))))
		{
			goto IL_02d1;
		}
	}
	{
		return _stringLiteral1541500764;
	}

IL_02d1:
	{
		String_t* L_112 = __this->get_scheme_3();
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_113 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeMailto_26();
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_114 = String_op_Inequality_m215368492(NULL /*static, unused*/, L_112, L_113, /*hidden argument*/NULL);
		if (!L_114)
		{
			goto IL_02ff;
		}
	}
	{
		String_t* L_115 = __this->get_scheme_3();
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_116 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeNews_27();
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_117 = String_op_Inequality_m215368492(NULL /*static, unused*/, L_115, L_116, /*hidden argument*/NULL);
		if (!L_117)
		{
			goto IL_02ff;
		}
	}
	{
		int32_t L_118 = V_3;
		V_3 = ((int32_t)il2cpp_codegen_add((int32_t)L_118, (int32_t)2));
	}

IL_02ff:
	{
		String_t* L_119 = __this->get_scheme_3();
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_120 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeFile_21();
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_121 = String_op_Equality_m920492651(NULL /*static, unused*/, L_119, L_120, /*hidden argument*/NULL);
		if (!L_121)
		{
			goto IL_0383;
		}
	}
	{
		V_8 = 2;
		int32_t L_122 = V_3;
		V_9 = L_122;
		goto IL_033f;
	}

IL_031f:
	{
		String_t* L_123 = ___uriString1;
		int32_t L_124 = V_9;
		Il2CppChar L_125 = String_get_Chars_m2986988803(L_123, L_124, /*hidden argument*/NULL);
		if ((((int32_t)L_125) == ((int32_t)((int32_t)47))))
		{
			goto IL_0333;
		}
	}
	{
		goto IL_0348;
	}

IL_0333:
	{
		int32_t L_126 = V_8;
		V_8 = ((int32_t)il2cpp_codegen_add((int32_t)L_126, (int32_t)1));
		int32_t L_127 = V_9;
		V_9 = ((int32_t)il2cpp_codegen_add((int32_t)L_127, (int32_t)1));
	}

IL_033f:
	{
		int32_t L_128 = V_9;
		int32_t L_129 = V_4;
		if ((((int32_t)L_128) < ((int32_t)L_129)))
		{
			goto IL_031f;
		}
	}

IL_0348:
	{
		int32_t L_130 = V_8;
		if ((((int32_t)L_130) < ((int32_t)4)))
		{
			goto IL_0377;
		}
	}
	{
		V_6 = (bool)0;
		goto IL_035c;
	}

IL_0358:
	{
		int32_t L_131 = V_3;
		V_3 = ((int32_t)il2cpp_codegen_add((int32_t)L_131, (int32_t)1));
	}

IL_035c:
	{
		int32_t L_132 = V_3;
		int32_t L_133 = V_4;
		if ((((int32_t)L_132) >= ((int32_t)L_133)))
		{
			goto IL_0372;
		}
	}
	{
		String_t* L_134 = ___uriString1;
		int32_t L_135 = V_3;
		Il2CppChar L_136 = String_get_Chars_m2986988803(L_134, L_135, /*hidden argument*/NULL);
		if ((((int32_t)L_136) == ((int32_t)((int32_t)47))))
		{
			goto IL_0358;
		}
	}

IL_0372:
	{
		goto IL_0383;
	}

IL_0377:
	{
		int32_t L_137 = V_8;
		if ((((int32_t)L_137) < ((int32_t)3)))
		{
			goto IL_0383;
		}
	}
	{
		int32_t L_138 = V_3;
		V_3 = ((int32_t)il2cpp_codegen_add((int32_t)L_138, (int32_t)1));
	}

IL_0383:
	{
		int32_t L_139 = V_4;
		int32_t L_140 = V_3;
		if ((((int32_t)((int32_t)il2cpp_codegen_subtract((int32_t)L_139, (int32_t)L_140))) <= ((int32_t)1)))
		{
			goto IL_03a3;
		}
	}
	{
		String_t* L_141 = ___uriString1;
		int32_t L_142 = V_3;
		Il2CppChar L_143 = String_get_Chars_m2986988803(L_141, ((int32_t)il2cpp_codegen_add((int32_t)L_142, (int32_t)1)), /*hidden argument*/NULL);
		if ((!(((uint32_t)L_143) == ((uint32_t)((int32_t)58)))))
		{
			goto IL_03a3;
		}
	}
	{
		V_6 = (bool)0;
		V_7 = (bool)1;
	}

IL_03a3:
	{
		goto IL_03d2;
	}

IL_03a8:
	{
		String_t* L_144 = __this->get_scheme_3();
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		bool L_145 = Uri_IsPredefinedScheme_m1188665625(NULL /*static, unused*/, L_144, /*hidden argument*/NULL);
		if (L_145)
		{
			goto IL_03d2;
		}
	}
	{
		String_t* L_146 = ___uriString1;
		int32_t L_147 = V_3;
		int32_t L_148 = V_4;
		int32_t L_149 = V_3;
		String_t* L_150 = String_Substring_m1610150815(L_146, L_147, ((int32_t)il2cpp_codegen_subtract((int32_t)L_148, (int32_t)L_149)), /*hidden argument*/NULL);
		__this->set_path_6(L_150);
		__this->set_isOpaquePart_11((bool)1);
		return (String_t*)NULL;
	}

IL_03d2:
	{
		bool L_151 = V_6;
		if (!L_151)
		{
			goto IL_03e0;
		}
	}
	{
		V_1 = (-1);
		goto IL_040a;
	}

IL_03e0:
	{
		String_t* L_152 = ___uriString1;
		int32_t L_153 = V_3;
		int32_t L_154 = V_4;
		int32_t L_155 = V_3;
		int32_t L_156 = String_IndexOf_m1248948328(L_152, ((int32_t)47), L_153, ((int32_t)il2cpp_codegen_subtract((int32_t)L_154, (int32_t)L_155)), /*hidden argument*/NULL);
		V_1 = L_156;
		int32_t L_157 = V_1;
		if ((!(((uint32_t)L_157) == ((uint32_t)(-1)))))
		{
			goto IL_040a;
		}
	}
	{
		bool L_158 = V_7;
		if (!L_158)
		{
			goto IL_040a;
		}
	}
	{
		String_t* L_159 = ___uriString1;
		int32_t L_160 = V_3;
		int32_t L_161 = V_4;
		int32_t L_162 = V_3;
		int32_t L_163 = String_IndexOf_m1248948328(L_159, ((int32_t)92), L_160, ((int32_t)il2cpp_codegen_subtract((int32_t)L_161, (int32_t)L_162)), /*hidden argument*/NULL);
		V_1 = L_163;
	}

IL_040a:
	{
		int32_t L_164 = V_1;
		if ((!(((uint32_t)L_164) == ((uint32_t)(-1)))))
		{
			goto IL_044b;
		}
	}
	{
		String_t* L_165 = __this->get_scheme_3();
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_166 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeMailto_26();
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_167 = String_op_Inequality_m215368492(NULL /*static, unused*/, L_165, L_166, /*hidden argument*/NULL);
		if (!L_167)
		{
			goto IL_0446;
		}
	}
	{
		String_t* L_168 = __this->get_scheme_3();
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_169 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeNews_27();
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_170 = String_op_Inequality_m215368492(NULL /*static, unused*/, L_168, L_169, /*hidden argument*/NULL);
		if (!L_170)
		{
			goto IL_0446;
		}
	}
	{
		__this->set_path_6(_stringLiteral3452614529);
	}

IL_0446:
	{
		goto IL_045f;
	}

IL_044b:
	{
		String_t* L_171 = ___uriString1;
		int32_t L_172 = V_1;
		int32_t L_173 = V_4;
		int32_t L_174 = V_1;
		String_t* L_175 = String_Substring_m1610150815(L_171, L_172, ((int32_t)il2cpp_codegen_subtract((int32_t)L_173, (int32_t)L_174)), /*hidden argument*/NULL);
		__this->set_path_6(L_175);
		int32_t L_176 = V_1;
		V_4 = L_176;
	}

IL_045f:
	{
		bool L_177 = V_6;
		if (!L_177)
		{
			goto IL_046d;
		}
	}
	{
		V_1 = (-1);
		goto IL_047b;
	}

IL_046d:
	{
		String_t* L_178 = ___uriString1;
		int32_t L_179 = V_3;
		int32_t L_180 = V_4;
		int32_t L_181 = V_3;
		int32_t L_182 = String_IndexOf_m1248948328(L_178, ((int32_t)64), L_179, ((int32_t)il2cpp_codegen_subtract((int32_t)L_180, (int32_t)L_181)), /*hidden argument*/NULL);
		V_1 = L_182;
	}

IL_047b:
	{
		int32_t L_183 = V_1;
		if ((((int32_t)L_183) == ((int32_t)(-1))))
		{
			goto IL_0496;
		}
	}
	{
		String_t* L_184 = ___uriString1;
		int32_t L_185 = V_3;
		int32_t L_186 = V_1;
		int32_t L_187 = V_3;
		String_t* L_188 = String_Substring_m1610150815(L_184, L_185, ((int32_t)il2cpp_codegen_subtract((int32_t)L_186, (int32_t)L_187)), /*hidden argument*/NULL);
		__this->set_userinfo_9(L_188);
		int32_t L_189 = V_1;
		V_3 = ((int32_t)il2cpp_codegen_add((int32_t)L_189, (int32_t)1));
	}

IL_0496:
	{
		__this->set_port_5((-1));
		bool L_190 = V_6;
		if (!L_190)
		{
			goto IL_04ab;
		}
	}
	{
		V_1 = (-1);
		goto IL_04bc;
	}

IL_04ab:
	{
		String_t* L_191 = ___uriString1;
		int32_t L_192 = V_4;
		int32_t L_193 = V_4;
		int32_t L_194 = V_3;
		int32_t L_195 = String_LastIndexOf_m3228770703(L_191, ((int32_t)58), ((int32_t)il2cpp_codegen_subtract((int32_t)L_192, (int32_t)1)), ((int32_t)il2cpp_codegen_subtract((int32_t)L_193, (int32_t)L_194)), /*hidden argument*/NULL);
		V_1 = L_195;
	}

IL_04bc:
	{
		int32_t L_196 = V_1;
		if ((((int32_t)L_196) == ((int32_t)(-1))))
		{
			goto IL_0566;
		}
	}
	{
		int32_t L_197 = V_1;
		int32_t L_198 = V_4;
		if ((((int32_t)L_197) == ((int32_t)((int32_t)il2cpp_codegen_subtract((int32_t)L_198, (int32_t)1)))))
		{
			goto IL_0566;
		}
	}
	{
		String_t* L_199 = ___uriString1;
		int32_t L_200 = V_1;
		int32_t L_201 = V_4;
		int32_t L_202 = V_1;
		String_t* L_203 = String_Substring_m1610150815(L_199, ((int32_t)il2cpp_codegen_add((int32_t)L_200, (int32_t)1)), ((int32_t)il2cpp_codegen_subtract((int32_t)L_201, (int32_t)((int32_t)il2cpp_codegen_add((int32_t)L_202, (int32_t)1)))), /*hidden argument*/NULL);
		V_10 = L_203;
		String_t* L_204 = V_10;
		int32_t L_205 = String_get_Length_m3847582255(L_204, /*hidden argument*/NULL);
		if ((((int32_t)L_205) <= ((int32_t)0)))
		{
			goto IL_0544;
		}
	}
	{
		String_t* L_206 = V_10;
		String_t* L_207 = V_10;
		int32_t L_208 = String_get_Length_m3847582255(L_207, /*hidden argument*/NULL);
		Il2CppChar L_209 = String_get_Chars_m2986988803(L_206, ((int32_t)il2cpp_codegen_subtract((int32_t)L_208, (int32_t)1)), /*hidden argument*/NULL);
		if ((((int32_t)L_209) == ((int32_t)((int32_t)93))))
		{
			goto IL_0544;
		}
	}
	{
		String_t* L_210 = V_10;
		IL2CPP_RUNTIME_CLASS_INIT(CultureInfo_t4157843068_il2cpp_TypeInfo_var);
		CultureInfo_t4157843068 * L_211 = CultureInfo_get_InvariantCulture_m3532445182(NULL /*static, unused*/, /*hidden argument*/NULL);
		int32_t* L_212 = __this->get_address_of_port_5();
		bool L_213 = Int32_TryParse_m135955795(NULL /*static, unused*/, L_210, 7, L_211, L_212, /*hidden argument*/NULL);
		if (!L_213)
		{
			goto IL_0536;
		}
	}
	{
		int32_t L_214 = __this->get_port_5();
		if ((((int32_t)L_214) < ((int32_t)0)))
		{
			goto IL_0536;
		}
	}
	{
		int32_t L_215 = __this->get_port_5();
		if ((((int32_t)L_215) <= ((int32_t)((int32_t)65535))))
		{
			goto IL_053c;
		}
	}

IL_0536:
	{
		return _stringLiteral2669708615;
	}

IL_053c:
	{
		int32_t L_216 = V_1;
		V_4 = L_216;
		goto IL_0561;
	}

IL_0544:
	{
		int32_t L_217 = __this->get_port_5();
		if ((!(((uint32_t)L_217) == ((uint32_t)(-1)))))
		{
			goto IL_0561;
		}
	}
	{
		String_t* L_218 = __this->get_scheme_3();
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		int32_t L_219 = Uri_GetDefaultPort_m2547653357(NULL /*static, unused*/, L_218, /*hidden argument*/NULL);
		__this->set_port_5(L_219);
	}

IL_0561:
	{
		goto IL_0583;
	}

IL_0566:
	{
		int32_t L_220 = __this->get_port_5();
		if ((!(((uint32_t)L_220) == ((uint32_t)(-1)))))
		{
			goto IL_0583;
		}
	}
	{
		String_t* L_221 = __this->get_scheme_3();
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		int32_t L_222 = Uri_GetDefaultPort_m2547653357(NULL /*static, unused*/, L_221, /*hidden argument*/NULL);
		__this->set_port_5(L_222);
	}

IL_0583:
	{
		String_t* L_223 = ___uriString1;
		int32_t L_224 = V_3;
		int32_t L_225 = V_4;
		int32_t L_226 = V_3;
		String_t* L_227 = String_Substring_m1610150815(L_223, L_224, ((int32_t)il2cpp_codegen_subtract((int32_t)L_225, (int32_t)L_226)), /*hidden argument*/NULL);
		___uriString1 = L_227;
		String_t* L_228 = ___uriString1;
		__this->set_host_4(L_228);
		bool L_229 = V_6;
		if (!L_229)
		{
			goto IL_05c7;
		}
	}
	{
		Il2CppChar L_230 = ((Il2CppChar)((int32_t)47));
		RuntimeObject * L_231 = Box(Char_t3634460470_il2cpp_TypeInfo_var, &L_230);
		String_t* L_232 = ___uriString1;
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_233 = String_Concat_m904156431(NULL /*static, unused*/, L_231, L_232, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_234 = Uri_Reduce_m3122437040(NULL /*static, unused*/, L_233, (bool)1, /*hidden argument*/NULL);
		__this->set_path_6(L_234);
		String_t* L_235 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_host_4(L_235);
		goto IL_071c;
	}

IL_05c7:
	{
		String_t* L_236 = __this->get_host_4();
		int32_t L_237 = String_get_Length_m3847582255(L_236, /*hidden argument*/NULL);
		if ((!(((uint32_t)L_237) == ((uint32_t)2))))
		{
			goto IL_0612;
		}
	}
	{
		String_t* L_238 = __this->get_host_4();
		Il2CppChar L_239 = String_get_Chars_m2986988803(L_238, 1, /*hidden argument*/NULL);
		if ((!(((uint32_t)L_239) == ((uint32_t)((int32_t)58)))))
		{
			goto IL_0612;
		}
	}
	{
		String_t* L_240 = __this->get_host_4();
		String_t* L_241 = __this->get_path_6();
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_242 = String_Concat_m3937257545(NULL /*static, unused*/, L_240, L_241, /*hidden argument*/NULL);
		__this->set_path_6(L_242);
		String_t* L_243 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_host_4(L_243);
		goto IL_071c;
	}

IL_0612:
	{
		bool L_244 = __this->get_isUnixFilePath_1();
		if (!L_244)
		{
			goto IL_063a;
		}
	}
	{
		String_t* L_245 = ___uriString1;
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_246 = String_Concat_m3937257545(NULL /*static, unused*/, _stringLiteral3450582913, L_245, /*hidden argument*/NULL);
		___uriString1 = L_246;
		String_t* L_247 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_host_4(L_247);
		goto IL_071c;
	}

IL_063a:
	{
		String_t* L_248 = __this->get_scheme_3();
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_249 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeFile_21();
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_250 = String_op_Equality_m920492651(NULL /*static, unused*/, L_248, L_249, /*hidden argument*/NULL);
		if (!L_250)
		{
			goto IL_065b;
		}
	}
	{
		__this->set_isUnc_10((bool)1);
		goto IL_071c;
	}

IL_065b:
	{
		String_t* L_251 = __this->get_scheme_3();
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_252 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeNews_27();
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_253 = String_op_Equality_m920492651(NULL /*static, unused*/, L_251, L_252, /*hidden argument*/NULL);
		if (!L_253)
		{
			goto IL_069d;
		}
	}
	{
		String_t* L_254 = __this->get_host_4();
		int32_t L_255 = String_get_Length_m3847582255(L_254, /*hidden argument*/NULL);
		if ((((int32_t)L_255) <= ((int32_t)0)))
		{
			goto IL_0698;
		}
	}
	{
		String_t* L_256 = __this->get_host_4();
		__this->set_path_6(L_256);
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_257 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_2();
		__this->set_host_4(L_257);
	}

IL_0698:
	{
		goto IL_071c;
	}

IL_069d:
	{
		String_t* L_258 = __this->get_host_4();
		int32_t L_259 = String_get_Length_m3847582255(L_258, /*hidden argument*/NULL);
		if (L_259)
		{
			goto IL_071c;
		}
	}
	{
		String_t* L_260 = __this->get_scheme_3();
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_261 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeHttp_24();
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_262 = String_op_Equality_m920492651(NULL /*static, unused*/, L_260, L_261, /*hidden argument*/NULL);
		if (L_262)
		{
			goto IL_0716;
		}
	}
	{
		String_t* L_263 = __this->get_scheme_3();
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_264 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeGopher_23();
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_265 = String_op_Equality_m920492651(NULL /*static, unused*/, L_263, L_264, /*hidden argument*/NULL);
		if (L_265)
		{
			goto IL_0716;
		}
	}
	{
		String_t* L_266 = __this->get_scheme_3();
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_267 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeNntp_28();
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_268 = String_op_Equality_m920492651(NULL /*static, unused*/, L_266, L_267, /*hidden argument*/NULL);
		if (L_268)
		{
			goto IL_0716;
		}
	}
	{
		String_t* L_269 = __this->get_scheme_3();
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_270 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeHttps_25();
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_271 = String_op_Equality_m920492651(NULL /*static, unused*/, L_269, L_270, /*hidden argument*/NULL);
		if (L_271)
		{
			goto IL_0716;
		}
	}
	{
		String_t* L_272 = __this->get_scheme_3();
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_273 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeFtp_22();
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_274 = String_op_Equality_m920492651(NULL /*static, unused*/, L_272, L_273, /*hidden argument*/NULL);
		if (!L_274)
		{
			goto IL_071c;
		}
	}

IL_0716:
	{
		return _stringLiteral4171376173;
	}

IL_071c:
	{
		String_t* L_275 = __this->get_host_4();
		int32_t L_276 = String_get_Length_m3847582255(L_275, /*hidden argument*/NULL);
		if ((((int32_t)L_276) <= ((int32_t)0)))
		{
			goto IL_073d;
		}
	}
	{
		String_t* L_277 = __this->get_host_4();
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		int32_t L_278 = Uri_CheckHostName_m2213216182(NULL /*static, unused*/, L_277, /*hidden argument*/NULL);
		G_B139_0 = ((((int32_t)L_278) == ((int32_t)0))? 1 : 0);
		goto IL_073e;
	}

IL_073d:
	{
		G_B139_0 = 0;
	}

IL_073e:
	{
		V_11 = (bool)G_B139_0;
		bool L_279 = V_11;
		if (L_279)
		{
			goto IL_07c1;
		}
	}
	{
		String_t* L_280 = __this->get_host_4();
		int32_t L_281 = String_get_Length_m3847582255(L_280, /*hidden argument*/NULL);
		if ((((int32_t)L_281) <= ((int32_t)1)))
		{
			goto IL_07c1;
		}
	}
	{
		String_t* L_282 = __this->get_host_4();
		Il2CppChar L_283 = String_get_Chars_m2986988803(L_282, 0, /*hidden argument*/NULL);
		if ((!(((uint32_t)L_283) == ((uint32_t)((int32_t)91)))))
		{
			goto IL_07c1;
		}
	}
	{
		String_t* L_284 = __this->get_host_4();
		String_t* L_285 = __this->get_host_4();
		int32_t L_286 = String_get_Length_m3847582255(L_285, /*hidden argument*/NULL);
		Il2CppChar L_287 = String_get_Chars_m2986988803(L_284, ((int32_t)il2cpp_codegen_subtract((int32_t)L_286, (int32_t)1)), /*hidden argument*/NULL);
		if ((!(((uint32_t)L_287) == ((uint32_t)((int32_t)93)))))
		{
			goto IL_07c1;
		}
	}
	{
		String_t* L_288 = __this->get_host_4();
		IL2CPP_RUNTIME_CLASS_INIT(IPv6Address_t2709566769_il2cpp_TypeInfo_var);
		bool L_289 = IPv6Address_TryParse_m2586816298(NULL /*static, unused*/, L_288, (&V_12), /*hidden argument*/NULL);
		if (!L_289)
		{
			goto IL_07be;
		}
	}
	{
		IPv6Address_t2709566769 * L_290 = V_12;
		String_t* L_291 = IPv6Address_ToString_m3978087033(L_290, (bool)1, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_292 = String_Concat_m3755062657(NULL /*static, unused*/, _stringLiteral3452614645, L_291, _stringLiteral3452614643, /*hidden argument*/NULL);
		__this->set_host_4(L_292);
		goto IL_07c1;
	}

IL_07be:
	{
		V_11 = (bool)1;
	}

IL_07c1:
	{
		bool L_293 = V_11;
		if (!L_293)
		{
			goto IL_07fe;
		}
	}
	{
		UriParser_t3890150400 * L_294 = Uri_get_Parser_m3737125102(__this, /*hidden argument*/NULL);
		if (((DefaultUriParser_t95882050 *)IsInstClass((RuntimeObject*)L_294, DefaultUriParser_t95882050_il2cpp_TypeInfo_var)))
		{
			goto IL_07e3;
		}
	}
	{
		UriParser_t3890150400 * L_295 = Uri_get_Parser_m3737125102(__this, /*hidden argument*/NULL);
		if (L_295)
		{
			goto IL_07fe;
		}
	}

IL_07e3:
	{
		String_t* L_296 = __this->get_host_4();
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_297 = String_Concat_m3755062657(NULL /*static, unused*/, _stringLiteral833983382, L_296, _stringLiteral3452614535, /*hidden argument*/NULL);
		String_t* L_298 = Locale_GetText_m3875126938(NULL /*static, unused*/, L_297, /*hidden argument*/NULL);
		return L_298;
	}

IL_07fe:
	{
		V_13 = (UriFormatException_t953270471 *)NULL;
		UriParser_t3890150400 * L_299 = Uri_get_Parser_m3737125102(__this, /*hidden argument*/NULL);
		if (!L_299)
		{
			goto IL_081a;
		}
	}
	{
		UriParser_t3890150400 * L_300 = Uri_get_Parser_m3737125102(__this, /*hidden argument*/NULL);
		VirtActionInvoker2< Uri_t100236324 *, UriFormatException_t953270471 ** >::Invoke(4 /* System.Void System.UriParser::InitializeAndValidate(System.Uri,System.UriFormatException&) */, L_300, __this, (&V_13));
	}

IL_081a:
	{
		UriFormatException_t953270471 * L_301 = V_13;
		if (!L_301)
		{
			goto IL_0829;
		}
	}
	{
		UriFormatException_t953270471 * L_302 = V_13;
		String_t* L_303 = VirtFuncInvoker0< String_t* >::Invoke(7 /* System.String System.Exception::get_Message() */, L_302);
		return L_303;
	}

IL_0829:
	{
		String_t* L_304 = __this->get_scheme_3();
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_305 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeMailto_26();
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_306 = String_op_Inequality_m215368492(NULL /*static, unused*/, L_304, L_305, /*hidden argument*/NULL);
		if (!L_306)
		{
			goto IL_0884;
		}
	}
	{
		String_t* L_307 = __this->get_scheme_3();
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_308 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeNews_27();
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_309 = String_op_Inequality_m215368492(NULL /*static, unused*/, L_307, L_308, /*hidden argument*/NULL);
		if (!L_309)
		{
			goto IL_0884;
		}
	}
	{
		String_t* L_310 = __this->get_scheme_3();
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_311 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeFile_21();
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_312 = String_op_Inequality_m215368492(NULL /*static, unused*/, L_310, L_311, /*hidden argument*/NULL);
		if (!L_312)
		{
			goto IL_0884;
		}
	}
	{
		String_t* L_313 = __this->get_path_6();
		String_t* L_314 = __this->get_scheme_3();
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		bool L_315 = Uri_CompactEscaped_m2984961597(NULL /*static, unused*/, L_314, /*hidden argument*/NULL);
		String_t* L_316 = Uri_Reduce_m3122437040(NULL /*static, unused*/, L_313, L_315, /*hidden argument*/NULL);
		__this->set_path_6(L_316);
	}

IL_0884:
	{
		return (String_t*)NULL;
	}
}
// System.Boolean System.Uri::CompactEscaped(System.String)
extern "C"  bool Uri_CompactEscaped_m2984961597 (RuntimeObject * __this /* static, unused */, String_t* ___scheme0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_CompactEscaped_m2984961597_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	String_t* V_0 = NULL;
	Dictionary_2_t2736202052 * V_1 = NULL;
	int32_t V_2 = 0;
	{
		String_t* L_0 = ___scheme0;
		V_0 = L_0;
		String_t* L_1 = V_0;
		if (!L_1)
		{
			goto IL_007a;
		}
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		Dictionary_2_t2736202052 * L_2 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_U3CU3Ef__switchU24map15_36();
		if (L_2)
		{
			goto IL_005b;
		}
	}
	{
		Dictionary_2_t2736202052 * L_3 = (Dictionary_2_t2736202052 *)il2cpp_codegen_object_new(Dictionary_2_t2736202052_il2cpp_TypeInfo_var);
		Dictionary_2__ctor_m2392909825(L_3, 5, /*hidden argument*/Dictionary_2__ctor_m2392909825_RuntimeMethod_var);
		V_1 = L_3;
		Dictionary_2_t2736202052 * L_4 = V_1;
		Dictionary_2_Add_m282647386(L_4, _stringLiteral1629333464, 0, /*hidden argument*/Dictionary_2_Add_m282647386_RuntimeMethod_var);
		Dictionary_2_t2736202052 * L_5 = V_1;
		Dictionary_2_Add_m282647386(L_5, _stringLiteral3140485902, 0, /*hidden argument*/Dictionary_2_Add_m282647386_RuntimeMethod_var);
		Dictionary_2_t2736202052 * L_6 = V_1;
		Dictionary_2_Add_m282647386(L_6, _stringLiteral1973861653, 0, /*hidden argument*/Dictionary_2_Add_m282647386_RuntimeMethod_var);
		Dictionary_2_t2736202052 * L_7 = V_1;
		Dictionary_2_Add_m282647386(L_7, _stringLiteral3041793228, 0, /*hidden argument*/Dictionary_2_Add_m282647386_RuntimeMethod_var);
		Dictionary_2_t2736202052 * L_8 = V_1;
		Dictionary_2_Add_m282647386(L_8, _stringLiteral1761547464, 0, /*hidden argument*/Dictionary_2_Add_m282647386_RuntimeMethod_var);
		Dictionary_2_t2736202052 * L_9 = V_1;
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->set_U3CU3Ef__switchU24map15_36(L_9);
	}

IL_005b:
	{
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		Dictionary_2_t2736202052 * L_10 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_U3CU3Ef__switchU24map15_36();
		String_t* L_11 = V_0;
		bool L_12 = Dictionary_2_TryGetValue_m1013208020(L_10, L_11, (&V_2), /*hidden argument*/Dictionary_2_TryGetValue_m1013208020_RuntimeMethod_var);
		if (!L_12)
		{
			goto IL_007a;
		}
	}
	{
		int32_t L_13 = V_2;
		if (!L_13)
		{
			goto IL_0078;
		}
	}
	{
		goto IL_007a;
	}

IL_0078:
	{
		return (bool)1;
	}

IL_007a:
	{
		return (bool)0;
	}
}
// System.String System.Uri::Reduce(System.String,System.Boolean)
extern "C"  String_t* Uri_Reduce_m3122437040 (RuntimeObject * __this /* static, unused */, String_t* ___path0, bool ___compact_escaped1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_Reduce_m3122437040_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	StringBuilder_t * V_0 = NULL;
	int32_t V_1 = 0;
	Il2CppChar V_2 = 0x0;
	Il2CppChar V_3 = 0x0;
	Il2CppChar V_4 = 0x0;
	ArrayList_t2718874744 * V_5 = NULL;
	int32_t V_6 = 0;
	int32_t V_7 = 0;
	String_t* V_8 = NULL;
	int32_t V_9 = 0;
	bool V_10 = false;
	String_t* V_11 = NULL;
	RuntimeObject* V_12 = NULL;
	Il2CppChar V_13 = 0x0;
	RuntimeObject* V_14 = NULL;
	Exception_t * __last_unhandled_exception = 0;
	NO_UNUSED_WARNING (__last_unhandled_exception);
	Exception_t * __exception_local = 0;
	NO_UNUSED_WARNING (__exception_local);
	int32_t __leave_target = 0;
	NO_UNUSED_WARNING (__leave_target);
	{
		String_t* L_0 = ___path0;
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_1 = String_op_Equality_m920492651(NULL /*static, unused*/, L_0, _stringLiteral3452614529, /*hidden argument*/NULL);
		if (!L_1)
		{
			goto IL_0012;
		}
	}
	{
		String_t* L_2 = ___path0;
		return L_2;
	}

IL_0012:
	{
		StringBuilder_t * L_3 = (StringBuilder_t *)il2cpp_codegen_object_new(StringBuilder_t_il2cpp_TypeInfo_var);
		StringBuilder__ctor_m3121283359(L_3, /*hidden argument*/NULL);
		V_0 = L_3;
		bool L_4 = ___compact_escaped1;
		if (!L_4)
		{
			goto IL_00f5;
		}
	}
	{
		V_1 = 0;
		goto IL_00dc;
	}

IL_0025:
	{
		String_t* L_5 = ___path0;
		int32_t L_6 = V_1;
		Il2CppChar L_7 = String_get_Chars_m2986988803(L_5, L_6, /*hidden argument*/NULL);
		V_2 = L_7;
		Il2CppChar L_8 = V_2;
		V_13 = L_8;
		Il2CppChar L_9 = V_13;
		if ((((int32_t)L_9) == ((int32_t)((int32_t)37))))
		{
			goto IL_0055;
		}
	}
	{
		Il2CppChar L_10 = V_13;
		if ((((int32_t)L_10) == ((int32_t)((int32_t)92))))
		{
			goto IL_0047;
		}
	}
	{
		goto IL_00cb;
	}

IL_0047:
	{
		StringBuilder_t * L_11 = V_0;
		StringBuilder_Append_m2383614642(L_11, ((int32_t)47), /*hidden argument*/NULL);
		goto IL_00d8;
	}

IL_0055:
	{
		int32_t L_12 = V_1;
		String_t* L_13 = ___path0;
		int32_t L_14 = String_get_Length_m3847582255(L_13, /*hidden argument*/NULL);
		if ((((int32_t)L_12) >= ((int32_t)((int32_t)il2cpp_codegen_subtract((int32_t)L_14, (int32_t)2)))))
		{
			goto IL_00be;
		}
	}
	{
		String_t* L_15 = ___path0;
		int32_t L_16 = V_1;
		Il2CppChar L_17 = String_get_Chars_m2986988803(L_15, ((int32_t)il2cpp_codegen_add((int32_t)L_16, (int32_t)1)), /*hidden argument*/NULL);
		V_3 = L_17;
		String_t* L_18 = ___path0;
		int32_t L_19 = V_1;
		Il2CppChar L_20 = String_get_Chars_m2986988803(L_18, ((int32_t)il2cpp_codegen_add((int32_t)L_19, (int32_t)2)), /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Char_t3634460470_il2cpp_TypeInfo_var);
		Il2CppChar L_21 = Char_ToUpper_m3999570441(NULL /*static, unused*/, L_20, /*hidden argument*/NULL);
		V_4 = L_21;
		Il2CppChar L_22 = V_3;
		if ((!(((uint32_t)L_22) == ((uint32_t)((int32_t)50)))))
		{
			goto IL_008e;
		}
	}
	{
		Il2CppChar L_23 = V_4;
		if ((((int32_t)L_23) == ((int32_t)((int32_t)70))))
		{
			goto IL_009f;
		}
	}

IL_008e:
	{
		Il2CppChar L_24 = V_3;
		if ((!(((uint32_t)L_24) == ((uint32_t)((int32_t)53)))))
		{
			goto IL_00b1;
		}
	}
	{
		Il2CppChar L_25 = V_4;
		if ((!(((uint32_t)L_25) == ((uint32_t)((int32_t)67)))))
		{
			goto IL_00b1;
		}
	}

IL_009f:
	{
		StringBuilder_t * L_26 = V_0;
		StringBuilder_Append_m2383614642(L_26, ((int32_t)47), /*hidden argument*/NULL);
		int32_t L_27 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add((int32_t)L_27, (int32_t)2));
		goto IL_00b9;
	}

IL_00b1:
	{
		StringBuilder_t * L_28 = V_0;
		Il2CppChar L_29 = V_2;
		StringBuilder_Append_m2383614642(L_28, L_29, /*hidden argument*/NULL);
	}

IL_00b9:
	{
		goto IL_00c6;
	}

IL_00be:
	{
		StringBuilder_t * L_30 = V_0;
		Il2CppChar L_31 = V_2;
		StringBuilder_Append_m2383614642(L_30, L_31, /*hidden argument*/NULL);
	}

IL_00c6:
	{
		goto IL_00d8;
	}

IL_00cb:
	{
		StringBuilder_t * L_32 = V_0;
		Il2CppChar L_33 = V_2;
		StringBuilder_Append_m2383614642(L_32, L_33, /*hidden argument*/NULL);
		goto IL_00d8;
	}

IL_00d8:
	{
		int32_t L_34 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add((int32_t)L_34, (int32_t)1));
	}

IL_00dc:
	{
		int32_t L_35 = V_1;
		String_t* L_36 = ___path0;
		int32_t L_37 = String_get_Length_m3847582255(L_36, /*hidden argument*/NULL);
		if ((((int32_t)L_35) < ((int32_t)L_37)))
		{
			goto IL_0025;
		}
	}
	{
		StringBuilder_t * L_38 = V_0;
		String_t* L_39 = StringBuilder_ToString_m3317489284(L_38, /*hidden argument*/NULL);
		___path0 = L_39;
		goto IL_0101;
	}

IL_00f5:
	{
		String_t* L_40 = ___path0;
		String_t* L_41 = String_Replace_m3726209165(L_40, ((int32_t)92), ((int32_t)47), /*hidden argument*/NULL);
		___path0 = L_41;
	}

IL_0101:
	{
		ArrayList_t2718874744 * L_42 = (ArrayList_t2718874744 *)il2cpp_codegen_object_new(ArrayList_t2718874744_il2cpp_TypeInfo_var);
		ArrayList__ctor_m4254721275(L_42, /*hidden argument*/NULL);
		V_5 = L_42;
		V_6 = 0;
		goto IL_01a3;
	}

IL_0110:
	{
		String_t* L_43 = ___path0;
		int32_t L_44 = V_6;
		int32_t L_45 = String_IndexOf_m2466398549(L_43, ((int32_t)47), L_44, /*hidden argument*/NULL);
		V_7 = L_45;
		int32_t L_46 = V_7;
		if ((!(((uint32_t)L_46) == ((uint32_t)(-1)))))
		{
			goto IL_012c;
		}
	}
	{
		String_t* L_47 = ___path0;
		int32_t L_48 = String_get_Length_m3847582255(L_47, /*hidden argument*/NULL);
		V_7 = L_48;
	}

IL_012c:
	{
		String_t* L_49 = ___path0;
		int32_t L_50 = V_6;
		int32_t L_51 = V_7;
		int32_t L_52 = V_6;
		String_t* L_53 = String_Substring_m1610150815(L_49, L_50, ((int32_t)il2cpp_codegen_subtract((int32_t)L_51, (int32_t)L_52)), /*hidden argument*/NULL);
		V_8 = L_53;
		int32_t L_54 = V_7;
		V_6 = ((int32_t)il2cpp_codegen_add((int32_t)L_54, (int32_t)1));
		String_t* L_55 = V_8;
		int32_t L_56 = String_get_Length_m3847582255(L_55, /*hidden argument*/NULL);
		if (!L_56)
		{
			goto IL_015e;
		}
	}
	{
		String_t* L_57 = V_8;
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_58 = String_op_Equality_m920492651(NULL /*static, unused*/, L_57, _stringLiteral3452614530, /*hidden argument*/NULL);
		if (!L_58)
		{
			goto IL_0163;
		}
	}

IL_015e:
	{
		goto IL_01a3;
	}

IL_0163:
	{
		String_t* L_59 = V_8;
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_60 = String_op_Equality_m920492651(NULL /*static, unused*/, L_59, _stringLiteral3450648450, /*hidden argument*/NULL);
		if (!L_60)
		{
			goto IL_0199;
		}
	}
	{
		ArrayList_t2718874744 * L_61 = V_5;
		int32_t L_62 = VirtFuncInvoker0< int32_t >::Invoke(23 /* System.Int32 System.Collections.ArrayList::get_Count() */, L_61);
		V_9 = L_62;
		int32_t L_63 = V_9;
		if (L_63)
		{
			goto IL_0189;
		}
	}
	{
		goto IL_01a3;
	}

IL_0189:
	{
		ArrayList_t2718874744 * L_64 = V_5;
		int32_t L_65 = V_9;
		VirtActionInvoker1< int32_t >::Invoke(39 /* System.Void System.Collections.ArrayList::RemoveAt(System.Int32) */, L_64, ((int32_t)il2cpp_codegen_subtract((int32_t)L_65, (int32_t)1)));
		goto IL_01a3;
	}

IL_0199:
	{
		ArrayList_t2718874744 * L_66 = V_5;
		String_t* L_67 = V_8;
		VirtFuncInvoker1< int32_t, RuntimeObject * >::Invoke(30 /* System.Int32 System.Collections.ArrayList::Add(System.Object) */, L_66, L_67);
	}

IL_01a3:
	{
		int32_t L_68 = V_6;
		String_t* L_69 = ___path0;
		int32_t L_70 = String_get_Length_m3847582255(L_69, /*hidden argument*/NULL);
		if ((((int32_t)L_68) < ((int32_t)L_70)))
		{
			goto IL_0110;
		}
	}
	{
		ArrayList_t2718874744 * L_71 = V_5;
		int32_t L_72 = VirtFuncInvoker0< int32_t >::Invoke(23 /* System.Int32 System.Collections.ArrayList::get_Count() */, L_71);
		if (L_72)
		{
			goto IL_01c2;
		}
	}
	{
		return _stringLiteral3452614529;
	}

IL_01c2:
	{
		StringBuilder_t * L_73 = V_0;
		StringBuilder_set_Length_m1410065908(L_73, 0, /*hidden argument*/NULL);
		String_t* L_74 = ___path0;
		Il2CppChar L_75 = String_get_Chars_m2986988803(L_74, 0, /*hidden argument*/NULL);
		if ((!(((uint32_t)L_75) == ((uint32_t)((int32_t)47)))))
		{
			goto IL_01e0;
		}
	}
	{
		StringBuilder_t * L_76 = V_0;
		StringBuilder_Append_m2383614642(L_76, ((int32_t)47), /*hidden argument*/NULL);
	}

IL_01e0:
	{
		V_10 = (bool)1;
		ArrayList_t2718874744 * L_77 = V_5;
		RuntimeObject* L_78 = VirtFuncInvoker0< RuntimeObject* >::Invoke(43 /* System.Collections.IEnumerator System.Collections.ArrayList::GetEnumerator() */, L_77);
		V_12 = L_78;
	}

IL_01ec:
	try
	{ // begin try (depth: 1)
		{
			goto IL_0220;
		}

IL_01f1:
		{
			RuntimeObject* L_79 = V_12;
			RuntimeObject * L_80 = InterfaceFuncInvoker0< RuntimeObject * >::Invoke(0 /* System.Object System.Collections.IEnumerator::get_Current() */, IEnumerator_t1853284238_il2cpp_TypeInfo_var, L_79);
			V_11 = ((String_t*)CastclassSealed((RuntimeObject*)L_80, String_t_il2cpp_TypeInfo_var));
			bool L_81 = V_10;
			if (!L_81)
			{
				goto IL_020e;
			}
		}

IL_0206:
		{
			V_10 = (bool)0;
			goto IL_0217;
		}

IL_020e:
		{
			StringBuilder_t * L_82 = V_0;
			StringBuilder_Append_m2383614642(L_82, ((int32_t)47), /*hidden argument*/NULL);
		}

IL_0217:
		{
			StringBuilder_t * L_83 = V_0;
			String_t* L_84 = V_11;
			StringBuilder_Append_m1965104174(L_83, L_84, /*hidden argument*/NULL);
		}

IL_0220:
		{
			RuntimeObject* L_85 = V_12;
			bool L_86 = InterfaceFuncInvoker0< bool >::Invoke(1 /* System.Boolean System.Collections.IEnumerator::MoveNext() */, IEnumerator_t1853284238_il2cpp_TypeInfo_var, L_85);
			if (L_86)
			{
				goto IL_01f1;
			}
		}

IL_022c:
		{
			IL2CPP_LEAVE(0x247, FINALLY_0231);
		}
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_0231;
	}

FINALLY_0231:
	{ // begin finally (depth: 1)
		{
			RuntimeObject* L_87 = V_12;
			V_14 = ((RuntimeObject*)IsInst((RuntimeObject*)L_87, IDisposable_t3640265483_il2cpp_TypeInfo_var));
			RuntimeObject* L_88 = V_14;
			if (L_88)
			{
				goto IL_023f;
			}
		}

IL_023e:
		{
			IL2CPP_END_FINALLY(561)
		}

IL_023f:
		{
			RuntimeObject* L_89 = V_14;
			InterfaceActionInvoker0::Invoke(0 /* System.Void System.IDisposable::Dispose() */, IDisposable_t3640265483_il2cpp_TypeInfo_var, L_89);
			IL2CPP_END_FINALLY(561)
		}
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(561)
	{
		IL2CPP_JUMP_TBL(0x247, IL_0247)
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
	}

IL_0247:
	{
		String_t* L_90 = ___path0;
		bool L_91 = String_EndsWith_m1901926500(L_90, _stringLiteral3452614529, /*hidden argument*/NULL);
		if (!L_91)
		{
			goto IL_0260;
		}
	}
	{
		StringBuilder_t * L_92 = V_0;
		StringBuilder_Append_m2383614642(L_92, ((int32_t)47), /*hidden argument*/NULL);
	}

IL_0260:
	{
		StringBuilder_t * L_93 = V_0;
		String_t* L_94 = StringBuilder_ToString_m3317489284(L_93, /*hidden argument*/NULL);
		return L_94;
	}
}
// System.Char System.Uri::HexUnescapeMultiByte(System.String,System.Int32&,System.Char&)
extern "C"  Il2CppChar Uri_HexUnescapeMultiByte_m332853996 (RuntimeObject * __this /* static, unused */, String_t* ___pattern0, int32_t* ___index1, Il2CppChar* ___surrogate2, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_HexUnescapeMultiByte_m332853996_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	ByteU5BU5D_t4116647657* V_5 = NULL;
	bool V_6 = false;
	int32_t V_7 = 0;
	int32_t V_8 = 0;
	int32_t V_9 = 0;
	uint8_t V_10 = 0x0;
	int32_t V_11 = 0;
	int32_t V_12 = 0;
	int32_t V_13 = 0;
	{
		Il2CppChar* L_0 = ___surrogate2;
		*((int16_t*)(L_0)) = (int16_t)0;
		String_t* L_1 = ___pattern0;
		if (L_1)
		{
			goto IL_0014;
		}
	}
	{
		ArgumentException_t132251570 * L_2 = (ArgumentException_t132251570 *)il2cpp_codegen_object_new(ArgumentException_t132251570_il2cpp_TypeInfo_var);
		ArgumentException__ctor_m1312628991(L_2, _stringLiteral2326546891, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_2,Uri_HexUnescapeMultiByte_m332853996_RuntimeMethod_var);
	}

IL_0014:
	{
		int32_t* L_3 = ___index1;
		if ((((int32_t)(*((int32_t*)L_3))) < ((int32_t)0)))
		{
			goto IL_0029;
		}
	}
	{
		int32_t* L_4 = ___index1;
		String_t* L_5 = ___pattern0;
		int32_t L_6 = String_get_Length_m3847582255(L_5, /*hidden argument*/NULL);
		if ((((int32_t)(*((int32_t*)L_4))) < ((int32_t)L_6)))
		{
			goto IL_0034;
		}
	}

IL_0029:
	{
		ArgumentOutOfRangeException_t777629997 * L_7 = (ArgumentOutOfRangeException_t777629997 *)il2cpp_codegen_object_new(ArgumentOutOfRangeException_t777629997_il2cpp_TypeInfo_var);
		ArgumentOutOfRangeException__ctor_m3628145864(L_7, _stringLiteral797640427, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_7,Uri_HexUnescapeMultiByte_m332853996_RuntimeMethod_var);
	}

IL_0034:
	{
		String_t* L_8 = ___pattern0;
		int32_t* L_9 = ___index1;
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		bool L_10 = Uri_IsHexEncoding_m3290929897(NULL /*static, unused*/, L_8, (*((int32_t*)L_9)), /*hidden argument*/NULL);
		if (L_10)
		{
			goto IL_0053;
		}
	}
	{
		String_t* L_11 = ___pattern0;
		int32_t* L_12 = ___index1;
		int32_t* L_13 = ___index1;
		int32_t L_14 = (*((int32_t*)L_13));
		V_13 = L_14;
		*((int32_t*)(L_12)) = (int32_t)((int32_t)il2cpp_codegen_add((int32_t)L_14, (int32_t)1));
		int32_t L_15 = V_13;
		Il2CppChar L_16 = String_get_Chars_m2986988803(L_11, L_15, /*hidden argument*/NULL);
		return L_16;
	}

IL_0053:
	{
		int32_t* L_17 = ___index1;
		int32_t* L_18 = ___index1;
		int32_t L_19 = (*((int32_t*)L_18));
		V_13 = L_19;
		*((int32_t*)(L_17)) = (int32_t)((int32_t)il2cpp_codegen_add((int32_t)L_19, (int32_t)1));
		int32_t L_20 = V_13;
		V_0 = L_20;
		String_t* L_21 = ___pattern0;
		int32_t* L_22 = ___index1;
		int32_t* L_23 = ___index1;
		int32_t L_24 = (*((int32_t*)L_23));
		V_13 = L_24;
		*((int32_t*)(L_22)) = (int32_t)((int32_t)il2cpp_codegen_add((int32_t)L_24, (int32_t)1));
		int32_t L_25 = V_13;
		Il2CppChar L_26 = String_get_Chars_m2986988803(L_21, L_25, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		int32_t L_27 = Uri_FromHex_m2610708947(NULL /*static, unused*/, L_26, /*hidden argument*/NULL);
		V_1 = L_27;
		String_t* L_28 = ___pattern0;
		int32_t* L_29 = ___index1;
		int32_t* L_30 = ___index1;
		int32_t L_31 = (*((int32_t*)L_30));
		V_13 = L_31;
		*((int32_t*)(L_29)) = (int32_t)((int32_t)il2cpp_codegen_add((int32_t)L_31, (int32_t)1));
		int32_t L_32 = V_13;
		Il2CppChar L_33 = String_get_Chars_m2986988803(L_28, L_32, /*hidden argument*/NULL);
		int32_t L_34 = Uri_FromHex_m2610708947(NULL /*static, unused*/, L_33, /*hidden argument*/NULL);
		V_2 = L_34;
		int32_t L_35 = V_1;
		V_3 = L_35;
		V_4 = 0;
		goto IL_00a1;
	}

IL_0097:
	{
		int32_t L_36 = V_4;
		V_4 = ((int32_t)il2cpp_codegen_add((int32_t)L_36, (int32_t)1));
		int32_t L_37 = V_3;
		V_3 = ((int32_t)((int32_t)L_37<<(int32_t)1));
	}

IL_00a1:
	{
		int32_t L_38 = V_3;
		if ((((int32_t)((int32_t)((int32_t)L_38&(int32_t)8))) == ((int32_t)8)))
		{
			goto IL_0097;
		}
	}
	{
		int32_t L_39 = V_4;
		if ((((int32_t)L_39) > ((int32_t)1)))
		{
			goto IL_00b9;
		}
	}
	{
		int32_t L_40 = V_1;
		int32_t L_41 = V_2;
		return (((int32_t)((uint16_t)((int32_t)((int32_t)((int32_t)((int32_t)L_40<<(int32_t)4))|(int32_t)L_41)))));
	}

IL_00b9:
	{
		int32_t L_42 = V_4;
		V_5 = ((ByteU5BU5D_t4116647657*)SZArrayNew(ByteU5BU5D_t4116647657_il2cpp_TypeInfo_var, (uint32_t)L_42));
		V_6 = (bool)0;
		ByteU5BU5D_t4116647657* L_43 = V_5;
		int32_t L_44 = V_1;
		int32_t L_45 = V_2;
		(L_43)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(0), (uint8_t)(((int32_t)((uint8_t)((int32_t)((int32_t)((int32_t)((int32_t)L_44<<(int32_t)4))|(int32_t)L_45))))));
		V_7 = 1;
		goto IL_014b;
	}

IL_00d7:
	{
		String_t* L_46 = ___pattern0;
		int32_t* L_47 = ___index1;
		int32_t* L_48 = ___index1;
		int32_t L_49 = (*((int32_t*)L_48));
		V_13 = L_49;
		*((int32_t*)(L_47)) = (int32_t)((int32_t)il2cpp_codegen_add((int32_t)L_49, (int32_t)1));
		int32_t L_50 = V_13;
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		bool L_51 = Uri_IsHexEncoding_m3290929897(NULL /*static, unused*/, L_46, L_50, /*hidden argument*/NULL);
		if (L_51)
		{
			goto IL_00f5;
		}
	}
	{
		V_6 = (bool)1;
		goto IL_0154;
	}

IL_00f5:
	{
		String_t* L_52 = ___pattern0;
		int32_t* L_53 = ___index1;
		int32_t* L_54 = ___index1;
		int32_t L_55 = (*((int32_t*)L_54));
		V_13 = L_55;
		*((int32_t*)(L_53)) = (int32_t)((int32_t)il2cpp_codegen_add((int32_t)L_55, (int32_t)1));
		int32_t L_56 = V_13;
		Il2CppChar L_57 = String_get_Chars_m2986988803(L_52, L_56, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		int32_t L_58 = Uri_FromHex_m2610708947(NULL /*static, unused*/, L_57, /*hidden argument*/NULL);
		V_8 = L_58;
		int32_t L_59 = V_8;
		if ((((int32_t)((int32_t)((int32_t)L_59&(int32_t)((int32_t)12)))) == ((int32_t)8)))
		{
			goto IL_0120;
		}
	}
	{
		V_6 = (bool)1;
		goto IL_0154;
	}

IL_0120:
	{
		String_t* L_60 = ___pattern0;
		int32_t* L_61 = ___index1;
		int32_t* L_62 = ___index1;
		int32_t L_63 = (*((int32_t*)L_62));
		V_13 = L_63;
		*((int32_t*)(L_61)) = (int32_t)((int32_t)il2cpp_codegen_add((int32_t)L_63, (int32_t)1));
		int32_t L_64 = V_13;
		Il2CppChar L_65 = String_get_Chars_m2986988803(L_60, L_64, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		int32_t L_66 = Uri_FromHex_m2610708947(NULL /*static, unused*/, L_65, /*hidden argument*/NULL);
		V_9 = L_66;
		ByteU5BU5D_t4116647657* L_67 = V_5;
		int32_t L_68 = V_7;
		int32_t L_69 = V_8;
		int32_t L_70 = V_9;
		(L_67)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(L_68), (uint8_t)(((int32_t)((uint8_t)((int32_t)((int32_t)((int32_t)((int32_t)L_69<<(int32_t)4))|(int32_t)L_70))))));
		int32_t L_71 = V_7;
		V_7 = ((int32_t)il2cpp_codegen_add((int32_t)L_71, (int32_t)1));
	}

IL_014b:
	{
		int32_t L_72 = V_7;
		int32_t L_73 = V_4;
		if ((((int32_t)L_72) < ((int32_t)L_73)))
		{
			goto IL_00d7;
		}
	}

IL_0154:
	{
		bool L_74 = V_6;
		if (!L_74)
		{
			goto IL_0166;
		}
	}
	{
		int32_t* L_75 = ___index1;
		int32_t L_76 = V_0;
		*((int32_t*)(L_75)) = (int32_t)((int32_t)il2cpp_codegen_add((int32_t)L_76, (int32_t)3));
		ByteU5BU5D_t4116647657* L_77 = V_5;
		int32_t L_78 = 0;
		uint8_t L_79 = (L_77)->GetAtUnchecked(static_cast<il2cpp_array_size_t>(L_78));
		return (((int32_t)((uint16_t)L_79)));
	}

IL_0166:
	{
		V_10 = (uint8_t)((int32_t)255);
		uint8_t L_80 = V_10;
		int32_t L_81 = V_4;
		V_10 = (uint8_t)(((int32_t)((uint8_t)((int32_t)((int32_t)L_80>>(int32_t)((int32_t)((int32_t)((int32_t)il2cpp_codegen_add((int32_t)L_81, (int32_t)1))&(int32_t)((int32_t)31))))))));
		ByteU5BU5D_t4116647657* L_82 = V_5;
		int32_t L_83 = 0;
		uint8_t L_84 = (L_82)->GetAtUnchecked(static_cast<il2cpp_array_size_t>(L_83));
		uint8_t L_85 = V_10;
		V_11 = ((int32_t)((int32_t)L_84&(int32_t)L_85));
		V_12 = 1;
		goto IL_01a4;
	}

IL_018b:
	{
		int32_t L_86 = V_11;
		V_11 = ((int32_t)((int32_t)L_86<<(int32_t)6));
		int32_t L_87 = V_11;
		ByteU5BU5D_t4116647657* L_88 = V_5;
		int32_t L_89 = V_12;
		int32_t L_90 = L_89;
		uint8_t L_91 = (L_88)->GetAtUnchecked(static_cast<il2cpp_array_size_t>(L_90));
		V_11 = ((int32_t)((int32_t)L_87|(int32_t)((int32_t)((int32_t)L_91&(int32_t)((int32_t)63)))));
		int32_t L_92 = V_12;
		V_12 = ((int32_t)il2cpp_codegen_add((int32_t)L_92, (int32_t)1));
	}

IL_01a4:
	{
		int32_t L_93 = V_12;
		int32_t L_94 = V_4;
		if ((((int32_t)L_93) < ((int32_t)L_94)))
		{
			goto IL_018b;
		}
	}
	{
		int32_t L_95 = V_11;
		if ((((int32_t)L_95) > ((int32_t)((int32_t)65535))))
		{
			goto IL_01bd;
		}
	}
	{
		int32_t L_96 = V_11;
		return (((int32_t)((uint16_t)L_96)));
	}

IL_01bd:
	{
		int32_t L_97 = V_11;
		V_11 = ((int32_t)il2cpp_codegen_subtract((int32_t)L_97, (int32_t)((int32_t)65536)));
		Il2CppChar* L_98 = ___surrogate2;
		int32_t L_99 = V_11;
		*((int16_t*)(L_98)) = (int16_t)(((int32_t)((uint16_t)((int32_t)((int32_t)((int32_t)((int32_t)L_99&(int32_t)((int32_t)1023)))|(int32_t)((int32_t)56320))))));
		int32_t L_100 = V_11;
		return (((int32_t)((uint16_t)((int32_t)((int32_t)((int32_t)((int32_t)L_100>>(int32_t)((int32_t)10)))|(int32_t)((int32_t)55296))))));
	}
}
// System.String System.Uri::GetSchemeDelimiter(System.String)
extern "C"  String_t* Uri_GetSchemeDelimiter_m2374610473 (RuntimeObject * __this /* static, unused */, String_t* ___scheme0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_GetSchemeDelimiter_m2374610473_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		V_0 = 0;
		goto IL_0037;
	}

IL_0007:
	{
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		UriSchemeU5BU5D_t2082808316* L_0 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_schemes_31();
		int32_t L_1 = V_0;
		String_t* L_2 = ((L_0)->GetAddressAtUnchecked(static_cast<il2cpp_array_size_t>(L_1)))->get_scheme_0();
		String_t* L_3 = ___scheme0;
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_4 = String_op_Equality_m920492651(NULL /*static, unused*/, L_2, L_3, /*hidden argument*/NULL);
		if (!L_4)
		{
			goto IL_0033;
		}
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		UriSchemeU5BU5D_t2082808316* L_5 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_schemes_31();
		int32_t L_6 = V_0;
		String_t* L_7 = ((L_5)->GetAddressAtUnchecked(static_cast<il2cpp_array_size_t>(L_6)))->get_delimiter_1();
		return L_7;
	}

IL_0033:
	{
		int32_t L_8 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_add((int32_t)L_8, (int32_t)1));
	}

IL_0037:
	{
		int32_t L_9 = V_0;
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		UriSchemeU5BU5D_t2082808316* L_10 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_schemes_31();
		if ((((int32_t)L_9) < ((int32_t)(((int32_t)((int32_t)(((RuntimeArray *)L_10)->max_length)))))))
		{
			goto IL_0007;
		}
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_11 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_SchemeDelimiter_20();
		return L_11;
	}
}
// System.Int32 System.Uri::GetDefaultPort(System.String)
extern "C"  int32_t Uri_GetDefaultPort_m2547653357 (RuntimeObject * __this /* static, unused */, String_t* ___scheme0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_GetDefaultPort_m2547653357_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	UriParser_t3890150400 * V_0 = NULL;
	{
		String_t* L_0 = ___scheme0;
		IL2CPP_RUNTIME_CLASS_INIT(UriParser_t3890150400_il2cpp_TypeInfo_var);
		UriParser_t3890150400 * L_1 = UriParser_GetParser_m544052729(NULL /*static, unused*/, L_0, /*hidden argument*/NULL);
		V_0 = L_1;
		UriParser_t3890150400 * L_2 = V_0;
		if (L_2)
		{
			goto IL_000f;
		}
	}
	{
		return (-1);
	}

IL_000f:
	{
		UriParser_t3890150400 * L_3 = V_0;
		int32_t L_4 = UriParser_get_DefaultPort_m2544851211(L_3, /*hidden argument*/NULL);
		return L_4;
	}
}
// System.String System.Uri::GetOpaqueWiseSchemeDelimiter()
extern "C"  String_t* Uri_GetOpaqueWiseSchemeDelimiter_m1909471550 (Uri_t100236324 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_GetOpaqueWiseSchemeDelimiter_m1909471550_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		bool L_0 = __this->get_isOpaquePart_11();
		if (!L_0)
		{
			goto IL_0011;
		}
	}
	{
		return _stringLiteral3452614550;
	}

IL_0011:
	{
		String_t* L_1 = __this->get_scheme_3();
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_2 = Uri_GetSchemeDelimiter_m2374610473(NULL /*static, unused*/, L_1, /*hidden argument*/NULL);
		return L_2;
	}
}
// System.Boolean System.Uri::IsPredefinedScheme(System.String)
extern "C"  bool Uri_IsPredefinedScheme_m1188665625 (RuntimeObject * __this /* static, unused */, String_t* ___scheme0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_IsPredefinedScheme_m1188665625_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	String_t* V_0 = NULL;
	Dictionary_2_t2736202052 * V_1 = NULL;
	int32_t V_2 = 0;
	{
		String_t* L_0 = ___scheme0;
		V_0 = L_0;
		String_t* L_1 = V_0;
		if (!L_1)
		{
			goto IL_00b7;
		}
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		Dictionary_2_t2736202052 * L_2 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_U3CU3Ef__switchU24map16_37();
		if (L_2)
		{
			goto IL_0098;
		}
	}
	{
		Dictionary_2_t2736202052 * L_3 = (Dictionary_2_t2736202052 *)il2cpp_codegen_object_new(Dictionary_2_t2736202052_il2cpp_TypeInfo_var);
		Dictionary_2__ctor_m2392909825(L_3, ((int32_t)10), /*hidden argument*/Dictionary_2__ctor_m2392909825_RuntimeMethod_var);
		V_1 = L_3;
		Dictionary_2_t2736202052 * L_4 = V_1;
		Dictionary_2_Add_m282647386(L_4, _stringLiteral3140485902, 0, /*hidden argument*/Dictionary_2_Add_m282647386_RuntimeMethod_var);
		Dictionary_2_t2736202052 * L_5 = V_1;
		Dictionary_2_Add_m282647386(L_5, _stringLiteral1973861653, 0, /*hidden argument*/Dictionary_2_Add_m282647386_RuntimeMethod_var);
		Dictionary_2_t2736202052 * L_6 = V_1;
		Dictionary_2_Add_m282647386(L_6, _stringLiteral1629333464, 0, /*hidden argument*/Dictionary_2_Add_m282647386_RuntimeMethod_var);
		Dictionary_2_t2736202052 * L_7 = V_1;
		Dictionary_2_Add_m282647386(L_7, _stringLiteral228733076, 0, /*hidden argument*/Dictionary_2_Add_m282647386_RuntimeMethod_var);
		Dictionary_2_t2736202052 * L_8 = V_1;
		Dictionary_2_Add_m282647386(L_8, _stringLiteral3139830536, 0, /*hidden argument*/Dictionary_2_Add_m282647386_RuntimeMethod_var);
		Dictionary_2_t2736202052 * L_9 = V_1;
		Dictionary_2_Add_m282647386(L_9, _stringLiteral2386815142, 0, /*hidden argument*/Dictionary_2_Add_m282647386_RuntimeMethod_var);
		Dictionary_2_t2736202052 * L_10 = V_1;
		Dictionary_2_Add_m282647386(L_10, _stringLiteral416809914, 0, /*hidden argument*/Dictionary_2_Add_m282647386_RuntimeMethod_var);
		Dictionary_2_t2736202052 * L_11 = V_1;
		Dictionary_2_Add_m282647386(L_11, _stringLiteral15098073, 0, /*hidden argument*/Dictionary_2_Add_m282647386_RuntimeMethod_var);
		Dictionary_2_t2736202052 * L_12 = V_1;
		Dictionary_2_Add_m282647386(L_12, _stringLiteral3041793228, 0, /*hidden argument*/Dictionary_2_Add_m282647386_RuntimeMethod_var);
		Dictionary_2_t2736202052 * L_13 = V_1;
		Dictionary_2_Add_m282647386(L_13, _stringLiteral1761547464, 0, /*hidden argument*/Dictionary_2_Add_m282647386_RuntimeMethod_var);
		Dictionary_2_t2736202052 * L_14 = V_1;
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->set_U3CU3Ef__switchU24map16_37(L_14);
	}

IL_0098:
	{
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		Dictionary_2_t2736202052 * L_15 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_U3CU3Ef__switchU24map16_37();
		String_t* L_16 = V_0;
		bool L_17 = Dictionary_2_TryGetValue_m1013208020(L_15, L_16, (&V_2), /*hidden argument*/Dictionary_2_TryGetValue_m1013208020_RuntimeMethod_var);
		if (!L_17)
		{
			goto IL_00b7;
		}
	}
	{
		int32_t L_18 = V_2;
		if (!L_18)
		{
			goto IL_00b5;
		}
	}
	{
		goto IL_00b7;
	}

IL_00b5:
	{
		return (bool)1;
	}

IL_00b7:
	{
		return (bool)0;
	}
}
// System.UriParser System.Uri::get_Parser()
extern "C"  UriParser_t3890150400 * Uri_get_Parser_m3737125102 (Uri_t100236324 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_get_Parser_m3737125102_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		UriParser_t3890150400 * L_0 = __this->get_parser_32();
		if (L_0)
		{
			goto IL_0037;
		}
	}
	{
		String_t* L_1 = Uri_get_Scheme_m2109479391(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(UriParser_t3890150400_il2cpp_TypeInfo_var);
		UriParser_t3890150400 * L_2 = UriParser_GetParser_m544052729(NULL /*static, unused*/, L_1, /*hidden argument*/NULL);
		__this->set_parser_32(L_2);
		UriParser_t3890150400 * L_3 = __this->get_parser_32();
		if (L_3)
		{
			goto IL_0037;
		}
	}
	{
		DefaultUriParser_t95882050 * L_4 = (DefaultUriParser_t95882050 *)il2cpp_codegen_object_new(DefaultUriParser_t95882050_il2cpp_TypeInfo_var);
		DefaultUriParser__ctor_m2634681684(L_4, _stringLiteral3452614534, /*hidden argument*/NULL);
		__this->set_parser_32(L_4);
	}

IL_0037:
	{
		UriParser_t3890150400 * L_5 = __this->get_parser_32();
		return L_5;
	}
}
// System.Boolean System.Uri::IsWellFormedOriginalString()
extern "C"  bool Uri_IsWellFormedOriginalString_m1655593438 (Uri_t100236324 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_IsWellFormedOriginalString_m1655593438_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		String_t* L_0 = Uri_get_OriginalString_m3715995233(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_1 = Uri_EscapeString_m2061933484(NULL /*static, unused*/, L_0, /*hidden argument*/NULL);
		String_t* L_2 = Uri_get_OriginalString_m3715995233(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_3 = String_op_Equality_m920492651(NULL /*static, unused*/, L_1, L_2, /*hidden argument*/NULL);
		return L_3;
	}
}
// System.Boolean System.Uri::IsWellFormedUriString(System.String,System.UriKind)
extern "C"  bool Uri_IsWellFormedUriString_m3476662626 (RuntimeObject * __this /* static, unused */, String_t* ___uriString0, int32_t ___uriKind1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_IsWellFormedUriString_m3476662626_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	Uri_t100236324 * V_0 = NULL;
	{
		String_t* L_0 = ___uriString0;
		if (L_0)
		{
			goto IL_0008;
		}
	}
	{
		return (bool)0;
	}

IL_0008:
	{
		String_t* L_1 = ___uriString0;
		int32_t L_2 = ___uriKind1;
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		bool L_3 = Uri_TryCreate_m385949523(NULL /*static, unused*/, L_1, L_2, (&V_0), /*hidden argument*/NULL);
		if (!L_3)
		{
			goto IL_001d;
		}
	}
	{
		Uri_t100236324 * L_4 = V_0;
		bool L_5 = Uri_IsWellFormedOriginalString_m1655593438(L_4, /*hidden argument*/NULL);
		return L_5;
	}

IL_001d:
	{
		return (bool)0;
	}
}
// System.Boolean System.Uri::TryCreate(System.String,System.UriKind,System.Uri&)
extern "C"  bool Uri_TryCreate_m385949523 (RuntimeObject * __this /* static, unused */, String_t* ___uriString0, int32_t ___uriKind1, Uri_t100236324 ** ___result2, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_TryCreate_m385949523_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	Uri_t100236324 * V_1 = NULL;
	{
		String_t* L_0 = ___uriString0;
		int32_t L_1 = ___uriKind1;
		Uri_t100236324 * L_2 = (Uri_t100236324 *)il2cpp_codegen_object_new(Uri_t100236324_il2cpp_TypeInfo_var);
		Uri__ctor_m1916875437(L_2, L_0, L_1, (&V_0), /*hidden argument*/NULL);
		V_1 = L_2;
		bool L_3 = V_0;
		if (!L_3)
		{
			goto IL_0015;
		}
	}
	{
		Uri_t100236324 ** L_4 = ___result2;
		Uri_t100236324 * L_5 = V_1;
		*((RuntimeObject **)(L_4)) = (RuntimeObject *)L_5;
		Il2CppCodeGenWriteBarrier((RuntimeObject **)(L_4), (RuntimeObject *)L_5);
		return (bool)1;
	}

IL_0015:
	{
		Uri_t100236324 ** L_6 = ___result2;
		*((RuntimeObject **)(L_6)) = (RuntimeObject *)NULL;
		Il2CppCodeGenWriteBarrier((RuntimeObject **)(L_6), (RuntimeObject *)NULL);
		return (bool)0;
	}
}
// System.String System.Uri::UnescapeDataString(System.String)
extern "C"  String_t* Uri_UnescapeDataString_m3282767665 (RuntimeObject * __this /* static, unused */, String_t* ___stringToUnescape0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_UnescapeDataString_m3282767665_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	StringBuilder_t * V_0 = NULL;
	int64_t V_1 = 0;
	MemoryStream_t94973147 * V_2 = NULL;
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	{
		String_t* L_0 = ___stringToUnescape0;
		if (L_0)
		{
			goto IL_0011;
		}
	}
	{
		ArgumentNullException_t1615371798 * L_1 = (ArgumentNullException_t1615371798 *)il2cpp_codegen_object_new(ArgumentNullException_t1615371798_il2cpp_TypeInfo_var);
		ArgumentNullException__ctor_m1170824041(L_1, _stringLiteral682703636, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_1,Uri_UnescapeDataString_m3282767665_RuntimeMethod_var);
	}

IL_0011:
	{
		String_t* L_2 = ___stringToUnescape0;
		int32_t L_3 = String_IndexOf_m363431711(L_2, ((int32_t)37), /*hidden argument*/NULL);
		if ((!(((uint32_t)L_3) == ((uint32_t)(-1)))))
		{
			goto IL_002f;
		}
	}
	{
		String_t* L_4 = ___stringToUnescape0;
		int32_t L_5 = String_IndexOf_m363431711(L_4, ((int32_t)43), /*hidden argument*/NULL);
		if ((!(((uint32_t)L_5) == ((uint32_t)(-1)))))
		{
			goto IL_002f;
		}
	}
	{
		String_t* L_6 = ___stringToUnescape0;
		return L_6;
	}

IL_002f:
	{
		StringBuilder_t * L_7 = (StringBuilder_t *)il2cpp_codegen_object_new(StringBuilder_t_il2cpp_TypeInfo_var);
		StringBuilder__ctor_m3121283359(L_7, /*hidden argument*/NULL);
		V_0 = L_7;
		String_t* L_8 = ___stringToUnescape0;
		int32_t L_9 = String_get_Length_m3847582255(L_8, /*hidden argument*/NULL);
		V_1 = (((int64_t)((int64_t)L_9)));
		MemoryStream_t94973147 * L_10 = (MemoryStream_t94973147 *)il2cpp_codegen_object_new(MemoryStream_t94973147_il2cpp_TypeInfo_var);
		MemoryStream__ctor_m2678285228(L_10, /*hidden argument*/NULL);
		V_2 = L_10;
		V_4 = 0;
		goto IL_015e;
	}

IL_004b:
	{
		String_t* L_11 = ___stringToUnescape0;
		int32_t L_12 = V_4;
		Il2CppChar L_13 = String_get_Chars_m2986988803(L_11, L_12, /*hidden argument*/NULL);
		if ((!(((uint32_t)L_13) == ((uint32_t)((int32_t)37)))))
		{
			goto IL_0122;
		}
	}
	{
		int32_t L_14 = V_4;
		int64_t L_15 = V_1;
		if ((((int64_t)(((int64_t)((int64_t)((int32_t)il2cpp_codegen_add((int32_t)L_14, (int32_t)2)))))) >= ((int64_t)L_15)))
		{
			goto IL_0122;
		}
	}
	{
		String_t* L_16 = ___stringToUnescape0;
		int32_t L_17 = V_4;
		Il2CppChar L_18 = String_get_Chars_m2986988803(L_16, ((int32_t)il2cpp_codegen_add((int32_t)L_17, (int32_t)1)), /*hidden argument*/NULL);
		if ((((int32_t)L_18) == ((int32_t)((int32_t)37))))
		{
			goto IL_0122;
		}
	}
	{
		String_t* L_19 = ___stringToUnescape0;
		int32_t L_20 = V_4;
		Il2CppChar L_21 = String_get_Chars_m2986988803(L_19, ((int32_t)il2cpp_codegen_add((int32_t)L_20, (int32_t)1)), /*hidden argument*/NULL);
		if ((!(((uint32_t)L_21) == ((uint32_t)((int32_t)117)))))
		{
			goto IL_00ee;
		}
	}
	{
		int32_t L_22 = V_4;
		int64_t L_23 = V_1;
		if ((((int64_t)(((int64_t)((int64_t)((int32_t)il2cpp_codegen_add((int32_t)L_22, (int32_t)5)))))) >= ((int64_t)L_23)))
		{
			goto IL_00ee;
		}
	}
	{
		MemoryStream_t94973147 * L_24 = V_2;
		int64_t L_25 = VirtFuncInvoker0< int64_t >::Invoke(8 /* System.Int64 System.IO.MemoryStream::get_Length() */, L_24);
		if ((((int64_t)L_25) <= ((int64_t)(((int64_t)((int64_t)0))))))
		{
			goto IL_00b9;
		}
	}
	{
		StringBuilder_t * L_26 = V_0;
		MemoryStream_t94973147 * L_27 = V_2;
		IL2CPP_RUNTIME_CLASS_INIT(Encoding_t1523322056_il2cpp_TypeInfo_var);
		Encoding_t1523322056 * L_28 = Encoding_get_UTF8_m1008486739(NULL /*static, unused*/, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		CharU5BU5D_t3528271667* L_29 = Uri_GetChars_m3587178967(NULL /*static, unused*/, L_27, L_28, /*hidden argument*/NULL);
		StringBuilder_Append_m168475016(L_26, L_29, /*hidden argument*/NULL);
		MemoryStream_t94973147 * L_30 = V_2;
		VirtActionInvoker1< int64_t >::Invoke(19 /* System.Void System.IO.MemoryStream::SetLength(System.Int64) */, L_30, (((int64_t)((int64_t)0))));
	}

IL_00b9:
	{
		String_t* L_31 = ___stringToUnescape0;
		int32_t L_32 = V_4;
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		int32_t L_33 = Uri_GetChar_m2610276660(NULL /*static, unused*/, L_31, ((int32_t)il2cpp_codegen_add((int32_t)L_32, (int32_t)2)), 4, /*hidden argument*/NULL);
		V_3 = L_33;
		int32_t L_34 = V_3;
		if ((((int32_t)L_34) == ((int32_t)(-1))))
		{
			goto IL_00e0;
		}
	}
	{
		StringBuilder_t * L_35 = V_0;
		int32_t L_36 = V_3;
		StringBuilder_Append_m2383614642(L_35, (((int32_t)((uint16_t)L_36))), /*hidden argument*/NULL);
		int32_t L_37 = V_4;
		V_4 = ((int32_t)il2cpp_codegen_add((int32_t)L_37, (int32_t)5));
		goto IL_00e9;
	}

IL_00e0:
	{
		StringBuilder_t * L_38 = V_0;
		StringBuilder_Append_m2383614642(L_38, ((int32_t)37), /*hidden argument*/NULL);
	}

IL_00e9:
	{
		goto IL_011d;
	}

IL_00ee:
	{
		String_t* L_39 = ___stringToUnescape0;
		int32_t L_40 = V_4;
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		int32_t L_41 = Uri_GetChar_m2610276660(NULL /*static, unused*/, L_39, ((int32_t)il2cpp_codegen_add((int32_t)L_40, (int32_t)1)), 2, /*hidden argument*/NULL);
		int32_t L_42 = L_41;
		V_3 = L_42;
		if ((((int32_t)L_42) == ((int32_t)(-1))))
		{
			goto IL_0114;
		}
	}
	{
		MemoryStream_t94973147 * L_43 = V_2;
		int32_t L_44 = V_3;
		VirtActionInvoker1< uint8_t >::Invoke(21 /* System.Void System.IO.MemoryStream::WriteByte(System.Byte) */, L_43, (uint8_t)(((int32_t)((uint8_t)L_44))));
		int32_t L_45 = V_4;
		V_4 = ((int32_t)il2cpp_codegen_add((int32_t)L_45, (int32_t)2));
		goto IL_011d;
	}

IL_0114:
	{
		StringBuilder_t * L_46 = V_0;
		StringBuilder_Append_m2383614642(L_46, ((int32_t)37), /*hidden argument*/NULL);
	}

IL_011d:
	{
		goto IL_0158;
	}

IL_0122:
	{
		MemoryStream_t94973147 * L_47 = V_2;
		int64_t L_48 = VirtFuncInvoker0< int64_t >::Invoke(8 /* System.Int64 System.IO.MemoryStream::get_Length() */, L_47);
		if ((((int64_t)L_48) <= ((int64_t)(((int64_t)((int64_t)0))))))
		{
			goto IL_0149;
		}
	}
	{
		StringBuilder_t * L_49 = V_0;
		MemoryStream_t94973147 * L_50 = V_2;
		IL2CPP_RUNTIME_CLASS_INIT(Encoding_t1523322056_il2cpp_TypeInfo_var);
		Encoding_t1523322056 * L_51 = Encoding_get_UTF8_m1008486739(NULL /*static, unused*/, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		CharU5BU5D_t3528271667* L_52 = Uri_GetChars_m3587178967(NULL /*static, unused*/, L_50, L_51, /*hidden argument*/NULL);
		StringBuilder_Append_m168475016(L_49, L_52, /*hidden argument*/NULL);
		MemoryStream_t94973147 * L_53 = V_2;
		VirtActionInvoker1< int64_t >::Invoke(19 /* System.Void System.IO.MemoryStream::SetLength(System.Int64) */, L_53, (((int64_t)((int64_t)0))));
	}

IL_0149:
	{
		StringBuilder_t * L_54 = V_0;
		String_t* L_55 = ___stringToUnescape0;
		int32_t L_56 = V_4;
		Il2CppChar L_57 = String_get_Chars_m2986988803(L_55, L_56, /*hidden argument*/NULL);
		StringBuilder_Append_m2383614642(L_54, L_57, /*hidden argument*/NULL);
	}

IL_0158:
	{
		int32_t L_58 = V_4;
		V_4 = ((int32_t)il2cpp_codegen_add((int32_t)L_58, (int32_t)1));
	}

IL_015e:
	{
		int32_t L_59 = V_4;
		int64_t L_60 = V_1;
		if ((((int64_t)(((int64_t)((int64_t)L_59)))) < ((int64_t)L_60)))
		{
			goto IL_004b;
		}
	}
	{
		MemoryStream_t94973147 * L_61 = V_2;
		int64_t L_62 = VirtFuncInvoker0< int64_t >::Invoke(8 /* System.Int64 System.IO.MemoryStream::get_Length() */, L_61);
		if ((((int64_t)L_62) <= ((int64_t)(((int64_t)((int64_t)0))))))
		{
			goto IL_0186;
		}
	}
	{
		StringBuilder_t * L_63 = V_0;
		MemoryStream_t94973147 * L_64 = V_2;
		IL2CPP_RUNTIME_CLASS_INIT(Encoding_t1523322056_il2cpp_TypeInfo_var);
		Encoding_t1523322056 * L_65 = Encoding_get_UTF8_m1008486739(NULL /*static, unused*/, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		CharU5BU5D_t3528271667* L_66 = Uri_GetChars_m3587178967(NULL /*static, unused*/, L_64, L_65, /*hidden argument*/NULL);
		StringBuilder_Append_m168475016(L_63, L_66, /*hidden argument*/NULL);
	}

IL_0186:
	{
		V_2 = (MemoryStream_t94973147 *)NULL;
		StringBuilder_t * L_67 = V_0;
		String_t* L_68 = StringBuilder_ToString_m3317489284(L_67, /*hidden argument*/NULL);
		return L_68;
	}
}
// System.Int32 System.Uri::GetInt(System.Byte)
extern "C"  int32_t Uri_GetInt_m3269354035 (RuntimeObject * __this /* static, unused */, uint8_t ___b0, const RuntimeMethod* method)
{
	Il2CppChar V_0 = 0x0;
	{
		uint8_t L_0 = ___b0;
		V_0 = (((int32_t)((uint16_t)L_0)));
		Il2CppChar L_1 = V_0;
		if ((((int32_t)L_1) < ((int32_t)((int32_t)48))))
		{
			goto IL_0018;
		}
	}
	{
		Il2CppChar L_2 = V_0;
		if ((((int32_t)L_2) > ((int32_t)((int32_t)57))))
		{
			goto IL_0018;
		}
	}
	{
		Il2CppChar L_3 = V_0;
		return ((int32_t)il2cpp_codegen_subtract((int32_t)L_3, (int32_t)((int32_t)48)));
	}

IL_0018:
	{
		Il2CppChar L_4 = V_0;
		if ((((int32_t)L_4) < ((int32_t)((int32_t)97))))
		{
			goto IL_0030;
		}
	}
	{
		Il2CppChar L_5 = V_0;
		if ((((int32_t)L_5) > ((int32_t)((int32_t)102))))
		{
			goto IL_0030;
		}
	}
	{
		Il2CppChar L_6 = V_0;
		return ((int32_t)il2cpp_codegen_add((int32_t)((int32_t)il2cpp_codegen_subtract((int32_t)L_6, (int32_t)((int32_t)97))), (int32_t)((int32_t)10)));
	}

IL_0030:
	{
		Il2CppChar L_7 = V_0;
		if ((((int32_t)L_7) < ((int32_t)((int32_t)65))))
		{
			goto IL_0048;
		}
	}
	{
		Il2CppChar L_8 = V_0;
		if ((((int32_t)L_8) > ((int32_t)((int32_t)70))))
		{
			goto IL_0048;
		}
	}
	{
		Il2CppChar L_9 = V_0;
		return ((int32_t)il2cpp_codegen_add((int32_t)((int32_t)il2cpp_codegen_subtract((int32_t)L_9, (int32_t)((int32_t)65))), (int32_t)((int32_t)10)));
	}

IL_0048:
	{
		return (-1);
	}
}
// System.Int32 System.Uri::GetChar(System.String,System.Int32,System.Int32)
extern "C"  int32_t Uri_GetChar_m2610276660 (RuntimeObject * __this /* static, unused */, String_t* ___str0, int32_t ___offset1, int32_t ___length2, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_GetChar_m2610276660_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	Il2CppChar V_3 = 0x0;
	int32_t V_4 = 0;
	{
		V_0 = 0;
		int32_t L_0 = ___length2;
		int32_t L_1 = ___offset1;
		V_1 = ((int32_t)il2cpp_codegen_add((int32_t)L_0, (int32_t)L_1));
		int32_t L_2 = ___offset1;
		V_2 = L_2;
		goto IL_003d;
	}

IL_000d:
	{
		String_t* L_3 = ___str0;
		int32_t L_4 = V_2;
		Il2CppChar L_5 = String_get_Chars_m2986988803(L_3, L_4, /*hidden argument*/NULL);
		V_3 = L_5;
		Il2CppChar L_6 = V_3;
		if ((((int32_t)L_6) <= ((int32_t)((int32_t)127))))
		{
			goto IL_001f;
		}
	}
	{
		return (-1);
	}

IL_001f:
	{
		Il2CppChar L_7 = V_3;
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		int32_t L_8 = Uri_GetInt_m3269354035(NULL /*static, unused*/, (uint8_t)(((int32_t)((uint8_t)L_7))), /*hidden argument*/NULL);
		V_4 = L_8;
		int32_t L_9 = V_4;
		if ((!(((uint32_t)L_9) == ((uint32_t)(-1)))))
		{
			goto IL_0032;
		}
	}
	{
		return (-1);
	}

IL_0032:
	{
		int32_t L_10 = V_0;
		int32_t L_11 = V_4;
		V_0 = ((int32_t)il2cpp_codegen_add((int32_t)((int32_t)((int32_t)L_10<<(int32_t)4)), (int32_t)L_11));
		int32_t L_12 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add((int32_t)L_12, (int32_t)1));
	}

IL_003d:
	{
		int32_t L_13 = V_2;
		int32_t L_14 = V_1;
		if ((((int32_t)L_13) < ((int32_t)L_14)))
		{
			goto IL_000d;
		}
	}
	{
		int32_t L_15 = V_0;
		return L_15;
	}
}
// System.Char[] System.Uri::GetChars(System.IO.MemoryStream,System.Text.Encoding)
extern "C"  CharU5BU5D_t3528271667* Uri_GetChars_m3587178967 (RuntimeObject * __this /* static, unused */, MemoryStream_t94973147 * ___b0, Encoding_t1523322056 * ___e1, const RuntimeMethod* method)
{
	{
		Encoding_t1523322056 * L_0 = ___e1;
		MemoryStream_t94973147 * L_1 = ___b0;
		ByteU5BU5D_t4116647657* L_2 = VirtFuncInvoker0< ByteU5BU5D_t4116647657* >::Invoke(27 /* System.Byte[] System.IO.MemoryStream::GetBuffer() */, L_1);
		MemoryStream_t94973147 * L_3 = ___b0;
		int64_t L_4 = VirtFuncInvoker0< int64_t >::Invoke(8 /* System.Int64 System.IO.MemoryStream::get_Length() */, L_3);
		CharU5BU5D_t3528271667* L_5 = VirtFuncInvoker3< CharU5BU5D_t3528271667*, ByteU5BU5D_t4116647657*, int32_t, int32_t >::Invoke(15 /* System.Char[] System.Text.Encoding::GetChars(System.Byte[],System.Int32,System.Int32) */, L_0, L_2, 0, (((int32_t)((int32_t)L_4))));
		return L_5;
	}
}
// System.Void System.Uri::EnsureAbsoluteUri()
extern "C"  void Uri_EnsureAbsoluteUri_m2231483494 (Uri_t100236324 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_EnsureAbsoluteUri_m2231483494_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		bool L_0 = Uri_get_IsAbsoluteUri_m3666899587(__this, /*hidden argument*/NULL);
		if (L_0)
		{
			goto IL_0016;
		}
	}
	{
		InvalidOperationException_t56020091 * L_1 = (InvalidOperationException_t56020091 *)il2cpp_codegen_object_new(InvalidOperationException_t56020091_il2cpp_TypeInfo_var);
		InvalidOperationException__ctor_m237278729(L_1, _stringLiteral2193443264, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_1,Uri_EnsureAbsoluteUri_m2231483494_RuntimeMethod_var);
	}

IL_0016:
	{
		return;
	}
}
// System.Boolean System.Uri::op_Equality(System.Uri,System.Uri)
extern "C"  bool Uri_op_Equality_m685520154 (RuntimeObject * __this /* static, unused */, Uri_t100236324 * ___u10, Uri_t100236324 * ___u21, const RuntimeMethod* method)
{
	{
		Uri_t100236324 * L_0 = ___u10;
		Uri_t100236324 * L_1 = ___u21;
		bool L_2 = Object_Equals_m1397037629(NULL /*static, unused*/, L_0, L_1, /*hidden argument*/NULL);
		return L_2;
	}
}
// System.Boolean System.Uri::op_Inequality(System.Uri,System.Uri)
extern "C"  bool Uri_op_Inequality_m839253362 (RuntimeObject * __this /* static, unused */, Uri_t100236324 * ___u10, Uri_t100236324 * ___u21, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Uri_op_Inequality_m839253362_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		Uri_t100236324 * L_0 = ___u10;
		Uri_t100236324 * L_1 = ___u21;
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		bool L_2 = Uri_op_Equality_m685520154(NULL /*static, unused*/, L_0, L_1, /*hidden argument*/NULL);
		return (bool)((((int32_t)L_2) == ((int32_t)0))? 1 : 0);
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
// Conversion methods for marshalling of: System.Uri/UriScheme
extern "C" void UriScheme_t722425697_marshal_pinvoke(const UriScheme_t722425697& unmarshaled, UriScheme_t722425697_marshaled_pinvoke& marshaled)
{
	marshaled.___scheme_0 = il2cpp_codegen_marshal_string(unmarshaled.get_scheme_0());
	marshaled.___delimiter_1 = il2cpp_codegen_marshal_string(unmarshaled.get_delimiter_1());
	marshaled.___defaultPort_2 = unmarshaled.get_defaultPort_2();
}
extern "C" void UriScheme_t722425697_marshal_pinvoke_back(const UriScheme_t722425697_marshaled_pinvoke& marshaled, UriScheme_t722425697& unmarshaled)
{
	unmarshaled.set_scheme_0(il2cpp_codegen_marshal_string_result(marshaled.___scheme_0));
	unmarshaled.set_delimiter_1(il2cpp_codegen_marshal_string_result(marshaled.___delimiter_1));
	int32_t unmarshaled_defaultPort_temp_2 = 0;
	unmarshaled_defaultPort_temp_2 = marshaled.___defaultPort_2;
	unmarshaled.set_defaultPort_2(unmarshaled_defaultPort_temp_2);
}
// Conversion method for clean up from marshalling of: System.Uri/UriScheme
extern "C" void UriScheme_t722425697_marshal_pinvoke_cleanup(UriScheme_t722425697_marshaled_pinvoke& marshaled)
{
	il2cpp_codegen_marshal_free(marshaled.___scheme_0);
	marshaled.___scheme_0 = NULL;
	il2cpp_codegen_marshal_free(marshaled.___delimiter_1);
	marshaled.___delimiter_1 = NULL;
}
// Conversion methods for marshalling of: System.Uri/UriScheme
extern "C" void UriScheme_t722425697_marshal_com(const UriScheme_t722425697& unmarshaled, UriScheme_t722425697_marshaled_com& marshaled)
{
	marshaled.___scheme_0 = il2cpp_codegen_marshal_bstring(unmarshaled.get_scheme_0());
	marshaled.___delimiter_1 = il2cpp_codegen_marshal_bstring(unmarshaled.get_delimiter_1());
	marshaled.___defaultPort_2 = unmarshaled.get_defaultPort_2();
}
extern "C" void UriScheme_t722425697_marshal_com_back(const UriScheme_t722425697_marshaled_com& marshaled, UriScheme_t722425697& unmarshaled)
{
	unmarshaled.set_scheme_0(il2cpp_codegen_marshal_bstring_result(marshaled.___scheme_0));
	unmarshaled.set_delimiter_1(il2cpp_codegen_marshal_bstring_result(marshaled.___delimiter_1));
	int32_t unmarshaled_defaultPort_temp_2 = 0;
	unmarshaled_defaultPort_temp_2 = marshaled.___defaultPort_2;
	unmarshaled.set_defaultPort_2(unmarshaled_defaultPort_temp_2);
}
// Conversion method for clean up from marshalling of: System.Uri/UriScheme
extern "C" void UriScheme_t722425697_marshal_com_cleanup(UriScheme_t722425697_marshaled_com& marshaled)
{
	il2cpp_codegen_marshal_free_bstring(marshaled.___scheme_0);
	marshaled.___scheme_0 = NULL;
	il2cpp_codegen_marshal_free_bstring(marshaled.___delimiter_1);
	marshaled.___delimiter_1 = NULL;
}
// System.Void System.Uri/UriScheme::.ctor(System.String,System.String,System.Int32)
extern "C"  void UriScheme__ctor_m1399779782 (UriScheme_t722425697 * __this, String_t* ___s0, String_t* ___d1, int32_t ___p2, const RuntimeMethod* method)
{
	{
		String_t* L_0 = ___s0;
		__this->set_scheme_0(L_0);
		String_t* L_1 = ___d1;
		__this->set_delimiter_1(L_1);
		int32_t L_2 = ___p2;
		__this->set_defaultPort_2(L_2);
		return;
	}
}
extern "C"  void UriScheme__ctor_m1399779782_AdjustorThunk (RuntimeObject * __this, String_t* ___s0, String_t* ___d1, int32_t ___p2, const RuntimeMethod* method)
{
	UriScheme_t722425697 * _thisAdjusted = reinterpret_cast<UriScheme_t722425697 *>(__this + 1);
	UriScheme__ctor_m1399779782(_thisAdjusted, ___s0, ___d1, ___p2, method);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void System.UriFormatException::.ctor()
extern "C"  void UriFormatException__ctor_m1115096473 (UriFormatException_t953270471 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (UriFormatException__ctor_m1115096473_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		String_t* L_0 = Locale_GetText_m3875126938(NULL /*static, unused*/, _stringLiteral2864059369, /*hidden argument*/NULL);
		FormatException__ctor_m4049685996(__this, L_0, /*hidden argument*/NULL);
		return;
	}
}
// System.Void System.UriFormatException::.ctor(System.String)
extern "C"  void UriFormatException__ctor_m3083316541 (UriFormatException_t953270471 * __this, String_t* ___message0, const RuntimeMethod* method)
{
	{
		String_t* L_0 = ___message0;
		FormatException__ctor_m4049685996(__this, L_0, /*hidden argument*/NULL);
		return;
	}
}
// System.Void System.UriFormatException::.ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)
extern "C"  void UriFormatException__ctor_m3466512970 (UriFormatException_t953270471 * __this, SerializationInfo_t950877179 * ___info0, StreamingContext_t3711869237  ___context1, const RuntimeMethod* method)
{
	{
		SerializationInfo_t950877179 * L_0 = ___info0;
		StreamingContext_t3711869237  L_1 = ___context1;
		FormatException__ctor_m3747066592(__this, L_0, L_1, /*hidden argument*/NULL);
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
// System.Void System.UriParser::.ctor()
extern "C"  void UriParser__ctor_m2454688443 (UriParser_t3890150400 * __this, const RuntimeMethod* method)
{
	{
		Object__ctor_m297566312(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void System.UriParser::.cctor()
extern "C"  void UriParser__cctor_m3655686731 (RuntimeObject * __this /* static, unused */, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (UriParser__cctor_m3655686731_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject * L_0 = (RuntimeObject *)il2cpp_codegen_object_new(RuntimeObject_il2cpp_TypeInfo_var);
		Object__ctor_m297566312(L_0, /*hidden argument*/NULL);
		((UriParser_t3890150400_StaticFields*)il2cpp_codegen_static_fields_for(UriParser_t3890150400_il2cpp_TypeInfo_var))->set_lock_object_0(L_0);
		Regex_t3657309853 * L_1 = (Regex_t3657309853 *)il2cpp_codegen_object_new(Regex_t3657309853_il2cpp_TypeInfo_var);
		Regex__ctor_m897876424(L_1, _stringLiteral528199797, /*hidden argument*/NULL);
		((UriParser_t3890150400_StaticFields*)il2cpp_codegen_static_fields_for(UriParser_t3890150400_il2cpp_TypeInfo_var))->set_uri_regex_4(L_1);
		Regex_t3657309853 * L_2 = (Regex_t3657309853 *)il2cpp_codegen_object_new(Regex_t3657309853_il2cpp_TypeInfo_var);
		Regex__ctor_m897876424(L_2, _stringLiteral3698381084, /*hidden argument*/NULL);
		((UriParser_t3890150400_StaticFields*)il2cpp_codegen_static_fields_for(UriParser_t3890150400_il2cpp_TypeInfo_var))->set_auth_regex_5(L_2);
		return;
	}
}
// System.Void System.UriParser::InitializeAndValidate(System.Uri,System.UriFormatException&)
extern "C"  void UriParser_InitializeAndValidate_m2008117311 (UriParser_t3890150400 * __this, Uri_t100236324 * ___uri0, UriFormatException_t953270471 ** ___parsingError1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (UriParser_InitializeAndValidate_m2008117311_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		Uri_t100236324 * L_0 = ___uri0;
		String_t* L_1 = Uri_get_Scheme_m2109479391(L_0, /*hidden argument*/NULL);
		String_t* L_2 = __this->get_scheme_name_2();
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_3 = String_op_Inequality_m215368492(NULL /*static, unused*/, L_1, L_2, /*hidden argument*/NULL);
		if (!L_3)
		{
			goto IL_003c;
		}
	}
	{
		String_t* L_4 = __this->get_scheme_name_2();
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		bool L_5 = String_op_Inequality_m215368492(NULL /*static, unused*/, L_4, _stringLiteral3452614534, /*hidden argument*/NULL);
		if (!L_5)
		{
			goto IL_003c;
		}
	}
	{
		UriFormatException_t953270471 ** L_6 = ___parsingError1;
		UriFormatException_t953270471 * L_7 = (UriFormatException_t953270471 *)il2cpp_codegen_object_new(UriFormatException_t953270471_il2cpp_TypeInfo_var);
		UriFormatException__ctor_m3083316541(L_7, _stringLiteral2140524769, /*hidden argument*/NULL);
		*((RuntimeObject **)(L_6)) = (RuntimeObject *)L_7;
		Il2CppCodeGenWriteBarrier((RuntimeObject **)(L_6), (RuntimeObject *)L_7);
		goto IL_003f;
	}

IL_003c:
	{
		UriFormatException_t953270471 ** L_8 = ___parsingError1;
		*((RuntimeObject **)(L_8)) = (RuntimeObject *)NULL;
		Il2CppCodeGenWriteBarrier((RuntimeObject **)(L_8), (RuntimeObject *)NULL);
	}

IL_003f:
	{
		return;
	}
}
// System.Void System.UriParser::OnRegister(System.String,System.Int32)
extern "C"  void UriParser_OnRegister_m3283921560 (UriParser_t3890150400 * __this, String_t* ___schemeName0, int32_t ___defaultPort1, const RuntimeMethod* method)
{
	{
		return;
	}
}
// System.Void System.UriParser::set_SchemeName(System.String)
extern "C"  void UriParser_set_SchemeName_m266448765 (UriParser_t3890150400 * __this, String_t* ___value0, const RuntimeMethod* method)
{
	{
		String_t* L_0 = ___value0;
		__this->set_scheme_name_2(L_0);
		return;
	}
}
// System.Int32 System.UriParser::get_DefaultPort()
extern "C"  int32_t UriParser_get_DefaultPort_m2544851211 (UriParser_t3890150400 * __this, const RuntimeMethod* method)
{
	{
		int32_t L_0 = __this->get_default_port_3();
		return L_0;
	}
}
// System.Void System.UriParser::set_DefaultPort(System.Int32)
extern "C"  void UriParser_set_DefaultPort_m4007715058 (UriParser_t3890150400 * __this, int32_t ___value0, const RuntimeMethod* method)
{
	{
		int32_t L_0 = ___value0;
		__this->set_default_port_3(L_0);
		return;
	}
}
// System.Void System.UriParser::CreateDefaults()
extern "C"  void UriParser_CreateDefaults_m404296154 (RuntimeObject * __this /* static, unused */, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (UriParser_CreateDefaults_m404296154_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	Hashtable_t1853889766 * V_0 = NULL;
	RuntimeObject * V_1 = NULL;
	Exception_t * __last_unhandled_exception = 0;
	NO_UNUSED_WARNING (__last_unhandled_exception);
	Exception_t * __exception_local = 0;
	NO_UNUSED_WARNING (__exception_local);
	int32_t __leave_target = 0;
	NO_UNUSED_WARNING (__leave_target);
	{
		IL2CPP_RUNTIME_CLASS_INIT(UriParser_t3890150400_il2cpp_TypeInfo_var);
		Hashtable_t1853889766 * L_0 = ((UriParser_t3890150400_StaticFields*)il2cpp_codegen_static_fields_for(UriParser_t3890150400_il2cpp_TypeInfo_var))->get_table_1();
		if (!L_0)
		{
			goto IL_000b;
		}
	}
	{
		return;
	}

IL_000b:
	{
		Hashtable_t1853889766 * L_1 = (Hashtable_t1853889766 *)il2cpp_codegen_object_new(Hashtable_t1853889766_il2cpp_TypeInfo_var);
		Hashtable__ctor_m1815022027(L_1, /*hidden argument*/NULL);
		V_0 = L_1;
		Hashtable_t1853889766 * L_2 = V_0;
		DefaultUriParser_t95882050 * L_3 = (DefaultUriParser_t95882050 *)il2cpp_codegen_object_new(DefaultUriParser_t95882050_il2cpp_TypeInfo_var);
		DefaultUriParser__ctor_m2377995797(L_3, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		String_t* L_4 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeFile_21();
		IL2CPP_RUNTIME_CLASS_INIT(UriParser_t3890150400_il2cpp_TypeInfo_var);
		UriParser_InternalRegister_m3643767086(NULL /*static, unused*/, L_2, L_3, L_4, (-1), /*hidden argument*/NULL);
		Hashtable_t1853889766 * L_5 = V_0;
		DefaultUriParser_t95882050 * L_6 = (DefaultUriParser_t95882050 *)il2cpp_codegen_object_new(DefaultUriParser_t95882050_il2cpp_TypeInfo_var);
		DefaultUriParser__ctor_m2377995797(L_6, /*hidden argument*/NULL);
		String_t* L_7 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeFtp_22();
		UriParser_InternalRegister_m3643767086(NULL /*static, unused*/, L_5, L_6, L_7, ((int32_t)21), /*hidden argument*/NULL);
		Hashtable_t1853889766 * L_8 = V_0;
		DefaultUriParser_t95882050 * L_9 = (DefaultUriParser_t95882050 *)il2cpp_codegen_object_new(DefaultUriParser_t95882050_il2cpp_TypeInfo_var);
		DefaultUriParser__ctor_m2377995797(L_9, /*hidden argument*/NULL);
		String_t* L_10 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeGopher_23();
		UriParser_InternalRegister_m3643767086(NULL /*static, unused*/, L_8, L_9, L_10, ((int32_t)70), /*hidden argument*/NULL);
		Hashtable_t1853889766 * L_11 = V_0;
		DefaultUriParser_t95882050 * L_12 = (DefaultUriParser_t95882050 *)il2cpp_codegen_object_new(DefaultUriParser_t95882050_il2cpp_TypeInfo_var);
		DefaultUriParser__ctor_m2377995797(L_12, /*hidden argument*/NULL);
		String_t* L_13 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeHttp_24();
		UriParser_InternalRegister_m3643767086(NULL /*static, unused*/, L_11, L_12, L_13, ((int32_t)80), /*hidden argument*/NULL);
		Hashtable_t1853889766 * L_14 = V_0;
		DefaultUriParser_t95882050 * L_15 = (DefaultUriParser_t95882050 *)il2cpp_codegen_object_new(DefaultUriParser_t95882050_il2cpp_TypeInfo_var);
		DefaultUriParser__ctor_m2377995797(L_15, /*hidden argument*/NULL);
		String_t* L_16 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeHttps_25();
		UriParser_InternalRegister_m3643767086(NULL /*static, unused*/, L_14, L_15, L_16, ((int32_t)443), /*hidden argument*/NULL);
		Hashtable_t1853889766 * L_17 = V_0;
		DefaultUriParser_t95882050 * L_18 = (DefaultUriParser_t95882050 *)il2cpp_codegen_object_new(DefaultUriParser_t95882050_il2cpp_TypeInfo_var);
		DefaultUriParser__ctor_m2377995797(L_18, /*hidden argument*/NULL);
		String_t* L_19 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeMailto_26();
		UriParser_InternalRegister_m3643767086(NULL /*static, unused*/, L_17, L_18, L_19, ((int32_t)25), /*hidden argument*/NULL);
		Hashtable_t1853889766 * L_20 = V_0;
		DefaultUriParser_t95882050 * L_21 = (DefaultUriParser_t95882050 *)il2cpp_codegen_object_new(DefaultUriParser_t95882050_il2cpp_TypeInfo_var);
		DefaultUriParser__ctor_m2377995797(L_21, /*hidden argument*/NULL);
		String_t* L_22 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeNetPipe_29();
		UriParser_InternalRegister_m3643767086(NULL /*static, unused*/, L_20, L_21, L_22, (-1), /*hidden argument*/NULL);
		Hashtable_t1853889766 * L_23 = V_0;
		DefaultUriParser_t95882050 * L_24 = (DefaultUriParser_t95882050 *)il2cpp_codegen_object_new(DefaultUriParser_t95882050_il2cpp_TypeInfo_var);
		DefaultUriParser__ctor_m2377995797(L_24, /*hidden argument*/NULL);
		String_t* L_25 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeNetTcp_30();
		UriParser_InternalRegister_m3643767086(NULL /*static, unused*/, L_23, L_24, L_25, (-1), /*hidden argument*/NULL);
		Hashtable_t1853889766 * L_26 = V_0;
		DefaultUriParser_t95882050 * L_27 = (DefaultUriParser_t95882050 *)il2cpp_codegen_object_new(DefaultUriParser_t95882050_il2cpp_TypeInfo_var);
		DefaultUriParser__ctor_m2377995797(L_27, /*hidden argument*/NULL);
		String_t* L_28 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeNews_27();
		UriParser_InternalRegister_m3643767086(NULL /*static, unused*/, L_26, L_27, L_28, ((int32_t)119), /*hidden argument*/NULL);
		Hashtable_t1853889766 * L_29 = V_0;
		DefaultUriParser_t95882050 * L_30 = (DefaultUriParser_t95882050 *)il2cpp_codegen_object_new(DefaultUriParser_t95882050_il2cpp_TypeInfo_var);
		DefaultUriParser__ctor_m2377995797(L_30, /*hidden argument*/NULL);
		String_t* L_31 = ((Uri_t100236324_StaticFields*)il2cpp_codegen_static_fields_for(Uri_t100236324_il2cpp_TypeInfo_var))->get_UriSchemeNntp_28();
		UriParser_InternalRegister_m3643767086(NULL /*static, unused*/, L_29, L_30, L_31, ((int32_t)119), /*hidden argument*/NULL);
		Hashtable_t1853889766 * L_32 = V_0;
		DefaultUriParser_t95882050 * L_33 = (DefaultUriParser_t95882050 *)il2cpp_codegen_object_new(DefaultUriParser_t95882050_il2cpp_TypeInfo_var);
		DefaultUriParser__ctor_m2377995797(L_33, /*hidden argument*/NULL);
		UriParser_InternalRegister_m3643767086(NULL /*static, unused*/, L_32, L_33, _stringLiteral4255182569, ((int32_t)389), /*hidden argument*/NULL);
		RuntimeObject * L_34 = ((UriParser_t3890150400_StaticFields*)il2cpp_codegen_static_fields_for(UriParser_t3890150400_il2cpp_TypeInfo_var))->get_lock_object_0();
		V_1 = L_34;
		RuntimeObject * L_35 = V_1;
		Monitor_Enter_m2249409497(NULL /*static, unused*/, L_35, /*hidden argument*/NULL);
	}

IL_00e6:
	try
	{ // begin try (depth: 1)
		{
			IL2CPP_RUNTIME_CLASS_INIT(UriParser_t3890150400_il2cpp_TypeInfo_var);
			Hashtable_t1853889766 * L_36 = ((UriParser_t3890150400_StaticFields*)il2cpp_codegen_static_fields_for(UriParser_t3890150400_il2cpp_TypeInfo_var))->get_table_1();
			if (L_36)
			{
				goto IL_00fb;
			}
		}

IL_00f0:
		{
			Hashtable_t1853889766 * L_37 = V_0;
			IL2CPP_RUNTIME_CLASS_INIT(UriParser_t3890150400_il2cpp_TypeInfo_var);
			((UriParser_t3890150400_StaticFields*)il2cpp_codegen_static_fields_for(UriParser_t3890150400_il2cpp_TypeInfo_var))->set_table_1(L_37);
			goto IL_00fd;
		}

IL_00fb:
		{
			V_0 = (Hashtable_t1853889766 *)NULL;
		}

IL_00fd:
		{
			IL2CPP_LEAVE(0x109, FINALLY_0102);
		}
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_0102;
	}

FINALLY_0102:
	{ // begin finally (depth: 1)
		RuntimeObject * L_38 = V_1;
		Monitor_Exit_m3585316909(NULL /*static, unused*/, L_38, /*hidden argument*/NULL);
		IL2CPP_END_FINALLY(258)
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(258)
	{
		IL2CPP_JUMP_TBL(0x109, IL_0109)
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
	}

IL_0109:
	{
		return;
	}
}
// System.Void System.UriParser::InternalRegister(System.Collections.Hashtable,System.UriParser,System.String,System.Int32)
extern "C"  void UriParser_InternalRegister_m3643767086 (RuntimeObject * __this /* static, unused */, Hashtable_t1853889766 * ___table0, UriParser_t3890150400 * ___uriParser1, String_t* ___schemeName2, int32_t ___defaultPort3, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (UriParser_InternalRegister_m3643767086_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	DefaultUriParser_t95882050 * V_0 = NULL;
	{
		UriParser_t3890150400 * L_0 = ___uriParser1;
		String_t* L_1 = ___schemeName2;
		UriParser_set_SchemeName_m266448765(L_0, L_1, /*hidden argument*/NULL);
		UriParser_t3890150400 * L_2 = ___uriParser1;
		int32_t L_3 = ___defaultPort3;
		UriParser_set_DefaultPort_m4007715058(L_2, L_3, /*hidden argument*/NULL);
		UriParser_t3890150400 * L_4 = ___uriParser1;
		if (!((GenericUriParser_t1141496137 *)IsInstClass((RuntimeObject*)L_4, GenericUriParser_t1141496137_il2cpp_TypeInfo_var)))
		{
			goto IL_0026;
		}
	}
	{
		Hashtable_t1853889766 * L_5 = ___table0;
		String_t* L_6 = ___schemeName2;
		UriParser_t3890150400 * L_7 = ___uriParser1;
		VirtActionInvoker2< RuntimeObject *, RuntimeObject * >::Invoke(28 /* System.Void System.Collections.Hashtable::Add(System.Object,System.Object) */, L_5, L_6, L_7);
		goto IL_0042;
	}

IL_0026:
	{
		DefaultUriParser_t95882050 * L_8 = (DefaultUriParser_t95882050 *)il2cpp_codegen_object_new(DefaultUriParser_t95882050_il2cpp_TypeInfo_var);
		DefaultUriParser__ctor_m2377995797(L_8, /*hidden argument*/NULL);
		V_0 = L_8;
		DefaultUriParser_t95882050 * L_9 = V_0;
		String_t* L_10 = ___schemeName2;
		UriParser_set_SchemeName_m266448765(L_9, L_10, /*hidden argument*/NULL);
		DefaultUriParser_t95882050 * L_11 = V_0;
		int32_t L_12 = ___defaultPort3;
		UriParser_set_DefaultPort_m4007715058(L_11, L_12, /*hidden argument*/NULL);
		Hashtable_t1853889766 * L_13 = ___table0;
		String_t* L_14 = ___schemeName2;
		DefaultUriParser_t95882050 * L_15 = V_0;
		VirtActionInvoker2< RuntimeObject *, RuntimeObject * >::Invoke(28 /* System.Void System.Collections.Hashtable::Add(System.Object,System.Object) */, L_13, L_14, L_15);
	}

IL_0042:
	{
		UriParser_t3890150400 * L_16 = ___uriParser1;
		String_t* L_17 = ___schemeName2;
		int32_t L_18 = ___defaultPort3;
		VirtActionInvoker2< String_t*, int32_t >::Invoke(5 /* System.Void System.UriParser::OnRegister(System.String,System.Int32) */, L_16, L_17, L_18);
		return;
	}
}
// System.UriParser System.UriParser::GetParser(System.String)
extern "C"  UriParser_t3890150400 * UriParser_GetParser_m544052729 (RuntimeObject * __this /* static, unused */, String_t* ___schemeName0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (UriParser_GetParser_m544052729_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	String_t* V_0 = NULL;
	{
		String_t* L_0 = ___schemeName0;
		if (L_0)
		{
			goto IL_0008;
		}
	}
	{
		return (UriParser_t3890150400 *)NULL;
	}

IL_0008:
	{
		IL2CPP_RUNTIME_CLASS_INIT(UriParser_t3890150400_il2cpp_TypeInfo_var);
		UriParser_CreateDefaults_m404296154(NULL /*static, unused*/, /*hidden argument*/NULL);
		String_t* L_1 = ___schemeName0;
		IL2CPP_RUNTIME_CLASS_INIT(CultureInfo_t4157843068_il2cpp_TypeInfo_var);
		CultureInfo_t4157843068 * L_2 = CultureInfo_get_InvariantCulture_m3532445182(NULL /*static, unused*/, /*hidden argument*/NULL);
		String_t* L_3 = String_ToLower_m3490221821(L_1, L_2, /*hidden argument*/NULL);
		V_0 = L_3;
		Hashtable_t1853889766 * L_4 = ((UriParser_t3890150400_StaticFields*)il2cpp_codegen_static_fields_for(UriParser_t3890150400_il2cpp_TypeInfo_var))->get_table_1();
		String_t* L_5 = V_0;
		RuntimeObject * L_6 = VirtFuncInvoker1< RuntimeObject *, RuntimeObject * >::Invoke(25 /* System.Object System.Collections.Hashtable::get_Item(System.Object) */, L_4, L_5);
		return ((UriParser_t3890150400 *)CastclassClass((RuntimeObject*)L_6, UriParser_t3890150400_il2cpp_TypeInfo_var));
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
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Boolean System.UriTypeConverter::CanConvert(System.Type)
extern "C"  bool UriTypeConverter_CanConvert_m4004296934 (UriTypeConverter_t3695916615 * __this, Type_t * ___type0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (UriTypeConverter_CanConvert_m4004296934_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		Type_t * L_0 = ___type0;
		RuntimeTypeHandle_t3027515415  L_1 = { reinterpret_cast<intptr_t> (String_t_0_0_0_var) };
		IL2CPP_RUNTIME_CLASS_INIT(Type_t_il2cpp_TypeInfo_var);
		Type_t * L_2 = Type_GetTypeFromHandle_m1620074514(NULL /*static, unused*/, L_1, /*hidden argument*/NULL);
		if ((!(((RuntimeObject*)(Type_t *)L_0) == ((RuntimeObject*)(Type_t *)L_2))))
		{
			goto IL_0012;
		}
	}
	{
		return (bool)1;
	}

IL_0012:
	{
		Type_t * L_3 = ___type0;
		RuntimeTypeHandle_t3027515415  L_4 = { reinterpret_cast<intptr_t> (Uri_t100236324_0_0_0_var) };
		IL2CPP_RUNTIME_CLASS_INIT(Type_t_il2cpp_TypeInfo_var);
		Type_t * L_5 = Type_GetTypeFromHandle_m1620074514(NULL /*static, unused*/, L_4, /*hidden argument*/NULL);
		if ((!(((RuntimeObject*)(Type_t *)L_3) == ((RuntimeObject*)(Type_t *)L_5))))
		{
			goto IL_0024;
		}
	}
	{
		return (bool)1;
	}

IL_0024:
	{
		return (bool)0;
	}
}
// System.Boolean System.UriTypeConverter::CanConvertFrom(System.ComponentModel.ITypeDescriptorContext,System.Type)
extern "C"  bool UriTypeConverter_CanConvertFrom_m3865653726 (UriTypeConverter_t3695916615 * __this, RuntimeObject* ___context0, Type_t * ___sourceType1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (UriTypeConverter_CanConvertFrom_m3865653726_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		Type_t * L_0 = ___sourceType1;
		if (L_0)
		{
			goto IL_0011;
		}
	}
	{
		ArgumentNullException_t1615371798 * L_1 = (ArgumentNullException_t1615371798 *)il2cpp_codegen_object_new(ArgumentNullException_t1615371798_il2cpp_TypeInfo_var);
		ArgumentNullException__ctor_m1170824041(L_1, _stringLiteral652524914, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_1,UriTypeConverter_CanConvertFrom_m3865653726_RuntimeMethod_var);
	}

IL_0011:
	{
		Type_t * L_2 = ___sourceType1;
		bool L_3 = UriTypeConverter_CanConvert_m4004296934(__this, L_2, /*hidden argument*/NULL);
		return L_3;
	}
}
// System.Boolean System.UriTypeConverter::CanConvertTo(System.ComponentModel.ITypeDescriptorContext,System.Type)
extern "C"  bool UriTypeConverter_CanConvertTo_m3367801835 (UriTypeConverter_t3695916615 * __this, RuntimeObject* ___context0, Type_t * ___destinationType1, const RuntimeMethod* method)
{
	{
		Type_t * L_0 = ___destinationType1;
		if (L_0)
		{
			goto IL_0008;
		}
	}
	{
		return (bool)0;
	}

IL_0008:
	{
		Type_t * L_1 = ___destinationType1;
		bool L_2 = UriTypeConverter_CanConvert_m4004296934(__this, L_1, /*hidden argument*/NULL);
		return L_2;
	}
}
// System.Object System.UriTypeConverter::ConvertFrom(System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,System.Object)
extern "C"  RuntimeObject * UriTypeConverter_ConvertFrom_m3320288643 (UriTypeConverter_t3695916615 * __this, RuntimeObject* ___context0, CultureInfo_t4157843068 * ___culture1, RuntimeObject * ___value2, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (UriTypeConverter_ConvertFrom_m3320288643_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	String_t* V_0 = NULL;
	{
		RuntimeObject * L_0 = ___value2;
		if (L_0)
		{
			goto IL_0011;
		}
	}
	{
		ArgumentNullException_t1615371798 * L_1 = (ArgumentNullException_t1615371798 *)il2cpp_codegen_object_new(ArgumentNullException_t1615371798_il2cpp_TypeInfo_var);
		ArgumentNullException__ctor_m1170824041(L_1, _stringLiteral3493618073, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_1,UriTypeConverter_ConvertFrom_m3320288643_RuntimeMethod_var);
	}

IL_0011:
	{
		RuntimeObject* L_2 = ___context0;
		RuntimeObject * L_3 = ___value2;
		Type_t * L_4 = Object_GetType_m88164663(L_3, /*hidden argument*/NULL);
		bool L_5 = VirtFuncInvoker2< bool, RuntimeObject*, Type_t * >::Invoke(4 /* System.Boolean System.UriTypeConverter::CanConvertFrom(System.ComponentModel.ITypeDescriptorContext,System.Type) */, __this, L_2, L_4);
		if (L_5)
		{
			goto IL_0033;
		}
	}
	{
		String_t* L_6 = Locale_GetText_m3875126938(NULL /*static, unused*/, _stringLiteral2299570518, /*hidden argument*/NULL);
		NotSupportedException_t1314879016 * L_7 = (NotSupportedException_t1314879016 *)il2cpp_codegen_object_new(NotSupportedException_t1314879016_il2cpp_TypeInfo_var);
		NotSupportedException__ctor_m2494070935(L_7, L_6, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_7,UriTypeConverter_ConvertFrom_m3320288643_RuntimeMethod_var);
	}

IL_0033:
	{
		RuntimeObject * L_8 = ___value2;
		if (!((Uri_t100236324 *)IsInstClass((RuntimeObject*)L_8, Uri_t100236324_il2cpp_TypeInfo_var)))
		{
			goto IL_0040;
		}
	}
	{
		RuntimeObject * L_9 = ___value2;
		return L_9;
	}

IL_0040:
	{
		RuntimeObject * L_10 = ___value2;
		V_0 = ((String_t*)IsInstSealed((RuntimeObject*)L_10, String_t_il2cpp_TypeInfo_var));
		String_t* L_11 = V_0;
		if (!L_11)
		{
			goto IL_0055;
		}
	}
	{
		String_t* L_12 = V_0;
		Uri_t100236324 * L_13 = (Uri_t100236324 *)il2cpp_codegen_object_new(Uri_t100236324_il2cpp_TypeInfo_var);
		Uri__ctor_m3040793867(L_13, L_12, 0, /*hidden argument*/NULL);
		return L_13;
	}

IL_0055:
	{
		RuntimeObject* L_14 = ___context0;
		CultureInfo_t4157843068 * L_15 = ___culture1;
		RuntimeObject * L_16 = ___value2;
		RuntimeObject * L_17 = TypeConverter_ConvertFrom_m1024238132(__this, L_14, L_15, L_16, /*hidden argument*/NULL);
		return L_17;
	}
}
// System.Object System.UriTypeConverter::ConvertTo(System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,System.Object,System.Type)
extern "C"  RuntimeObject * UriTypeConverter_ConvertTo_m3611054432 (UriTypeConverter_t3695916615 * __this, RuntimeObject* ___context0, CultureInfo_t4157843068 * ___culture1, RuntimeObject * ___value2, Type_t * ___destinationType3, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (UriTypeConverter_ConvertTo_m3611054432_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	Uri_t100236324 * V_0 = NULL;
	{
		RuntimeObject* L_0 = ___context0;
		Type_t * L_1 = ___destinationType3;
		bool L_2 = VirtFuncInvoker2< bool, RuntimeObject*, Type_t * >::Invoke(5 /* System.Boolean System.UriTypeConverter::CanConvertTo(System.ComponentModel.ITypeDescriptorContext,System.Type) */, __this, L_0, L_1);
		if (L_2)
		{
			goto IL_001e;
		}
	}
	{
		String_t* L_3 = Locale_GetText_m3875126938(NULL /*static, unused*/, _stringLiteral1835507732, /*hidden argument*/NULL);
		NotSupportedException_t1314879016 * L_4 = (NotSupportedException_t1314879016 *)il2cpp_codegen_object_new(NotSupportedException_t1314879016_il2cpp_TypeInfo_var);
		NotSupportedException__ctor_m2494070935(L_4, L_3, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_4,UriTypeConverter_ConvertTo_m3611054432_RuntimeMethod_var);
	}

IL_001e:
	{
		RuntimeObject * L_5 = ___value2;
		V_0 = ((Uri_t100236324 *)IsInstClass((RuntimeObject*)L_5, Uri_t100236324_il2cpp_TypeInfo_var));
		Uri_t100236324 * L_6 = V_0;
		IL2CPP_RUNTIME_CLASS_INIT(Uri_t100236324_il2cpp_TypeInfo_var);
		bool L_7 = Uri_op_Inequality_m839253362(NULL /*static, unused*/, L_6, (Uri_t100236324 *)NULL, /*hidden argument*/NULL);
		if (!L_7)
		{
			goto IL_005c;
		}
	}
	{
		Type_t * L_8 = ___destinationType3;
		RuntimeTypeHandle_t3027515415  L_9 = { reinterpret_cast<intptr_t> (String_t_0_0_0_var) };
		IL2CPP_RUNTIME_CLASS_INIT(Type_t_il2cpp_TypeInfo_var);
		Type_t * L_10 = Type_GetTypeFromHandle_m1620074514(NULL /*static, unused*/, L_9, /*hidden argument*/NULL);
		if ((!(((RuntimeObject*)(Type_t *)L_8) == ((RuntimeObject*)(Type_t *)L_10))))
		{
			goto IL_0049;
		}
	}
	{
		Uri_t100236324 * L_11 = V_0;
		String_t* L_12 = VirtFuncInvoker0< String_t* >::Invoke(3 /* System.String System.Uri::ToString() */, L_11);
		return L_12;
	}

IL_0049:
	{
		Type_t * L_13 = ___destinationType3;
		RuntimeTypeHandle_t3027515415  L_14 = { reinterpret_cast<intptr_t> (Uri_t100236324_0_0_0_var) };
		IL2CPP_RUNTIME_CLASS_INIT(Type_t_il2cpp_TypeInfo_var);
		Type_t * L_15 = Type_GetTypeFromHandle_m1620074514(NULL /*static, unused*/, L_14, /*hidden argument*/NULL);
		if ((!(((RuntimeObject*)(Type_t *)L_13) == ((RuntimeObject*)(Type_t *)L_15))))
		{
			goto IL_005c;
		}
	}
	{
		Uri_t100236324 * L_16 = V_0;
		return L_16;
	}

IL_005c:
	{
		RuntimeObject* L_17 = ___context0;
		CultureInfo_t4157843068 * L_18 = ___culture1;
		RuntimeObject * L_19 = ___value2;
		Type_t * L_20 = ___destinationType3;
		RuntimeObject * L_21 = TypeConverter_ConvertTo_m3165899902(__this, L_17, L_18, L_19, L_20, /*hidden argument*/NULL);
		return L_21;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
