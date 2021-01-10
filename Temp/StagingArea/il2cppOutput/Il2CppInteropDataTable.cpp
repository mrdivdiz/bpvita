#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "il2cpp-class-internals.h"
#include "codegen/il2cpp-codegen.h"
#include "il2cpp-object-internals.h"


// System.IntPtr[]
struct IntPtrU5BU5D_t4013366056;
// System.String
struct String_t;
// System.Collections.IDictionary
struct IDictionary_t1363984059;
// System.UInt32[]
struct UInt32U5BU5D_t2770800703;
// System.Char[]
struct CharU5BU5D_t3528271667;
// System.Byte[]
struct ByteU5BU5D_t4116647657;
// Ionic.Zlib.DeflateManager
struct DeflateManager_t740995428;
// Ionic.Zlib.InflateManager
struct InflateManager_t3407211616;




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
#ifndef CRC32_T2128839853_H
#define CRC32_T2128839853_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Ionic.Crc.CRC32
struct  CRC32_t2128839853  : public RuntimeObject
{
public:
	static const Il2CppGuid CLSID;

public:
	// System.UInt32 Ionic.Crc.CRC32::dwPolynomial
	uint32_t ___dwPolynomial_0;
	// System.Int64 Ionic.Crc.CRC32::_TotalBytesRead
	int64_t ____TotalBytesRead_1;
	// System.Boolean Ionic.Crc.CRC32::reverseBits
	bool ___reverseBits_2;
	// System.UInt32[] Ionic.Crc.CRC32::crc32Table
	UInt32U5BU5D_t2770800703* ___crc32Table_3;
	// System.UInt32 Ionic.Crc.CRC32::_register
	uint32_t ____register_5;

public:
	inline static int32_t get_offset_of_dwPolynomial_0() { return static_cast<int32_t>(offsetof(CRC32_t2128839853, ___dwPolynomial_0)); }
	inline uint32_t get_dwPolynomial_0() const { return ___dwPolynomial_0; }
	inline uint32_t* get_address_of_dwPolynomial_0() { return &___dwPolynomial_0; }
	inline void set_dwPolynomial_0(uint32_t value)
	{
		___dwPolynomial_0 = value;
	}

	inline static int32_t get_offset_of__TotalBytesRead_1() { return static_cast<int32_t>(offsetof(CRC32_t2128839853, ____TotalBytesRead_1)); }
	inline int64_t get__TotalBytesRead_1() const { return ____TotalBytesRead_1; }
	inline int64_t* get_address_of__TotalBytesRead_1() { return &____TotalBytesRead_1; }
	inline void set__TotalBytesRead_1(int64_t value)
	{
		____TotalBytesRead_1 = value;
	}

	inline static int32_t get_offset_of_reverseBits_2() { return static_cast<int32_t>(offsetof(CRC32_t2128839853, ___reverseBits_2)); }
	inline bool get_reverseBits_2() const { return ___reverseBits_2; }
	inline bool* get_address_of_reverseBits_2() { return &___reverseBits_2; }
	inline void set_reverseBits_2(bool value)
	{
		___reverseBits_2 = value;
	}

	inline static int32_t get_offset_of_crc32Table_3() { return static_cast<int32_t>(offsetof(CRC32_t2128839853, ___crc32Table_3)); }
	inline UInt32U5BU5D_t2770800703* get_crc32Table_3() const { return ___crc32Table_3; }
	inline UInt32U5BU5D_t2770800703** get_address_of_crc32Table_3() { return &___crc32Table_3; }
	inline void set_crc32Table_3(UInt32U5BU5D_t2770800703* value)
	{
		___crc32Table_3 = value;
		Il2CppCodeGenWriteBarrier((&___crc32Table_3), value);
	}

	inline static int32_t get_offset_of__register_5() { return static_cast<int32_t>(offsetof(CRC32_t2128839853, ____register_5)); }
	inline uint32_t get__register_5() const { return ____register_5; }
	inline uint32_t* get_address_of__register_5() { return &____register_5; }
	inline void set__register_5(uint32_t value)
	{
		____register_5 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // CRC32_T2128839853_H
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
#ifndef ZLIBEXCEPTION_T2135990123_H
#define ZLIBEXCEPTION_T2135990123_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Ionic.Zlib.ZlibException
struct  ZlibException_t2135990123  : public Exception_t
{
public:
	static const Il2CppGuid CLSID;

public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ZLIBEXCEPTION_T2135990123_H
#ifndef COMPRESSIONLEVEL_T957220238_H
#define COMPRESSIONLEVEL_T957220238_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Ionic.Zlib.CompressionLevel
struct  CompressionLevel_t957220238 
{
public:
	// System.Int32 Ionic.Zlib.CompressionLevel::value__
	int32_t ___value___1;

public:
	inline static int32_t get_offset_of_value___1() { return static_cast<int32_t>(offsetof(CompressionLevel_t957220238, ___value___1)); }
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
#endif // COMPRESSIONLEVEL_T957220238_H
#ifndef COMPRESSIONSTRATEGY_T2822174634_H
#define COMPRESSIONSTRATEGY_T2822174634_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Ionic.Zlib.CompressionStrategy
struct  CompressionStrategy_t2822174634 
{
public:
	// System.Int32 Ionic.Zlib.CompressionStrategy::value__
	int32_t ___value___1;

public:
	inline static int32_t get_offset_of_value___1() { return static_cast<int32_t>(offsetof(CompressionStrategy_t2822174634, ___value___1)); }
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
#endif // COMPRESSIONSTRATEGY_T2822174634_H
#ifndef ZLIBCODEC_T3653667923_H
#define ZLIBCODEC_T3653667923_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Ionic.Zlib.ZlibCodec
struct  ZlibCodec_t3653667923  : public RuntimeObject
{
public:
	static const Il2CppGuid CLSID;

public:
	// System.Byte[] Ionic.Zlib.ZlibCodec::InputBuffer
	ByteU5BU5D_t4116647657* ___InputBuffer_0;
	// System.Int32 Ionic.Zlib.ZlibCodec::NextIn
	int32_t ___NextIn_1;
	// System.Int32 Ionic.Zlib.ZlibCodec::AvailableBytesIn
	int32_t ___AvailableBytesIn_2;
	// System.Int64 Ionic.Zlib.ZlibCodec::TotalBytesIn
	int64_t ___TotalBytesIn_3;
	// System.Byte[] Ionic.Zlib.ZlibCodec::OutputBuffer
	ByteU5BU5D_t4116647657* ___OutputBuffer_4;
	// System.Int32 Ionic.Zlib.ZlibCodec::NextOut
	int32_t ___NextOut_5;
	// System.Int32 Ionic.Zlib.ZlibCodec::AvailableBytesOut
	int32_t ___AvailableBytesOut_6;
	// System.Int64 Ionic.Zlib.ZlibCodec::TotalBytesOut
	int64_t ___TotalBytesOut_7;
	// System.String Ionic.Zlib.ZlibCodec::Message
	String_t* ___Message_8;
	// Ionic.Zlib.DeflateManager Ionic.Zlib.ZlibCodec::dstate
	DeflateManager_t740995428 * ___dstate_9;
	// Ionic.Zlib.InflateManager Ionic.Zlib.ZlibCodec::istate
	InflateManager_t3407211616 * ___istate_10;
	// System.UInt32 Ionic.Zlib.ZlibCodec::_Adler32
	uint32_t ____Adler32_11;
	// Ionic.Zlib.CompressionLevel Ionic.Zlib.ZlibCodec::CompressLevel
	int32_t ___CompressLevel_12;
	// System.Int32 Ionic.Zlib.ZlibCodec::WindowBits
	int32_t ___WindowBits_13;
	// Ionic.Zlib.CompressionStrategy Ionic.Zlib.ZlibCodec::Strategy
	int32_t ___Strategy_14;

public:
	inline static int32_t get_offset_of_InputBuffer_0() { return static_cast<int32_t>(offsetof(ZlibCodec_t3653667923, ___InputBuffer_0)); }
	inline ByteU5BU5D_t4116647657* get_InputBuffer_0() const { return ___InputBuffer_0; }
	inline ByteU5BU5D_t4116647657** get_address_of_InputBuffer_0() { return &___InputBuffer_0; }
	inline void set_InputBuffer_0(ByteU5BU5D_t4116647657* value)
	{
		___InputBuffer_0 = value;
		Il2CppCodeGenWriteBarrier((&___InputBuffer_0), value);
	}

	inline static int32_t get_offset_of_NextIn_1() { return static_cast<int32_t>(offsetof(ZlibCodec_t3653667923, ___NextIn_1)); }
	inline int32_t get_NextIn_1() const { return ___NextIn_1; }
	inline int32_t* get_address_of_NextIn_1() { return &___NextIn_1; }
	inline void set_NextIn_1(int32_t value)
	{
		___NextIn_1 = value;
	}

	inline static int32_t get_offset_of_AvailableBytesIn_2() { return static_cast<int32_t>(offsetof(ZlibCodec_t3653667923, ___AvailableBytesIn_2)); }
	inline int32_t get_AvailableBytesIn_2() const { return ___AvailableBytesIn_2; }
	inline int32_t* get_address_of_AvailableBytesIn_2() { return &___AvailableBytesIn_2; }
	inline void set_AvailableBytesIn_2(int32_t value)
	{
		___AvailableBytesIn_2 = value;
	}

	inline static int32_t get_offset_of_TotalBytesIn_3() { return static_cast<int32_t>(offsetof(ZlibCodec_t3653667923, ___TotalBytesIn_3)); }
	inline int64_t get_TotalBytesIn_3() const { return ___TotalBytesIn_3; }
	inline int64_t* get_address_of_TotalBytesIn_3() { return &___TotalBytesIn_3; }
	inline void set_TotalBytesIn_3(int64_t value)
	{
		___TotalBytesIn_3 = value;
	}

	inline static int32_t get_offset_of_OutputBuffer_4() { return static_cast<int32_t>(offsetof(ZlibCodec_t3653667923, ___OutputBuffer_4)); }
	inline ByteU5BU5D_t4116647657* get_OutputBuffer_4() const { return ___OutputBuffer_4; }
	inline ByteU5BU5D_t4116647657** get_address_of_OutputBuffer_4() { return &___OutputBuffer_4; }
	inline void set_OutputBuffer_4(ByteU5BU5D_t4116647657* value)
	{
		___OutputBuffer_4 = value;
		Il2CppCodeGenWriteBarrier((&___OutputBuffer_4), value);
	}

	inline static int32_t get_offset_of_NextOut_5() { return static_cast<int32_t>(offsetof(ZlibCodec_t3653667923, ___NextOut_5)); }
	inline int32_t get_NextOut_5() const { return ___NextOut_5; }
	inline int32_t* get_address_of_NextOut_5() { return &___NextOut_5; }
	inline void set_NextOut_5(int32_t value)
	{
		___NextOut_5 = value;
	}

	inline static int32_t get_offset_of_AvailableBytesOut_6() { return static_cast<int32_t>(offsetof(ZlibCodec_t3653667923, ___AvailableBytesOut_6)); }
	inline int32_t get_AvailableBytesOut_6() const { return ___AvailableBytesOut_6; }
	inline int32_t* get_address_of_AvailableBytesOut_6() { return &___AvailableBytesOut_6; }
	inline void set_AvailableBytesOut_6(int32_t value)
	{
		___AvailableBytesOut_6 = value;
	}

	inline static int32_t get_offset_of_TotalBytesOut_7() { return static_cast<int32_t>(offsetof(ZlibCodec_t3653667923, ___TotalBytesOut_7)); }
	inline int64_t get_TotalBytesOut_7() const { return ___TotalBytesOut_7; }
	inline int64_t* get_address_of_TotalBytesOut_7() { return &___TotalBytesOut_7; }
	inline void set_TotalBytesOut_7(int64_t value)
	{
		___TotalBytesOut_7 = value;
	}

	inline static int32_t get_offset_of_Message_8() { return static_cast<int32_t>(offsetof(ZlibCodec_t3653667923, ___Message_8)); }
	inline String_t* get_Message_8() const { return ___Message_8; }
	inline String_t** get_address_of_Message_8() { return &___Message_8; }
	inline void set_Message_8(String_t* value)
	{
		___Message_8 = value;
		Il2CppCodeGenWriteBarrier((&___Message_8), value);
	}

	inline static int32_t get_offset_of_dstate_9() { return static_cast<int32_t>(offsetof(ZlibCodec_t3653667923, ___dstate_9)); }
	inline DeflateManager_t740995428 * get_dstate_9() const { return ___dstate_9; }
	inline DeflateManager_t740995428 ** get_address_of_dstate_9() { return &___dstate_9; }
	inline void set_dstate_9(DeflateManager_t740995428 * value)
	{
		___dstate_9 = value;
		Il2CppCodeGenWriteBarrier((&___dstate_9), value);
	}

	inline static int32_t get_offset_of_istate_10() { return static_cast<int32_t>(offsetof(ZlibCodec_t3653667923, ___istate_10)); }
	inline InflateManager_t3407211616 * get_istate_10() const { return ___istate_10; }
	inline InflateManager_t3407211616 ** get_address_of_istate_10() { return &___istate_10; }
	inline void set_istate_10(InflateManager_t3407211616 * value)
	{
		___istate_10 = value;
		Il2CppCodeGenWriteBarrier((&___istate_10), value);
	}

	inline static int32_t get_offset_of__Adler32_11() { return static_cast<int32_t>(offsetof(ZlibCodec_t3653667923, ____Adler32_11)); }
	inline uint32_t get__Adler32_11() const { return ____Adler32_11; }
	inline uint32_t* get_address_of__Adler32_11() { return &____Adler32_11; }
	inline void set__Adler32_11(uint32_t value)
	{
		____Adler32_11 = value;
	}

	inline static int32_t get_offset_of_CompressLevel_12() { return static_cast<int32_t>(offsetof(ZlibCodec_t3653667923, ___CompressLevel_12)); }
	inline int32_t get_CompressLevel_12() const { return ___CompressLevel_12; }
	inline int32_t* get_address_of_CompressLevel_12() { return &___CompressLevel_12; }
	inline void set_CompressLevel_12(int32_t value)
	{
		___CompressLevel_12 = value;
	}

	inline static int32_t get_offset_of_WindowBits_13() { return static_cast<int32_t>(offsetof(ZlibCodec_t3653667923, ___WindowBits_13)); }
	inline int32_t get_WindowBits_13() const { return ___WindowBits_13; }
	inline int32_t* get_address_of_WindowBits_13() { return &___WindowBits_13; }
	inline void set_WindowBits_13(int32_t value)
	{
		___WindowBits_13 = value;
	}

	inline static int32_t get_offset_of_Strategy_14() { return static_cast<int32_t>(offsetof(ZlibCodec_t3653667923, ___Strategy_14)); }
	inline int32_t get_Strategy_14() const { return ___Strategy_14; }
	inline int32_t* get_address_of_Strategy_14() { return &___Strategy_14; }
	inline void set_Strategy_14(int32_t value)
	{
		___Strategy_14 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ZLIBCODEC_T3653667923_H



extern "C" void Context_t1744531130_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Context_t1744531130_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Context_t1744531130_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Context_t1744531130_0_0_0;
extern "C" void Escape_t3294788190_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Escape_t3294788190_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Escape_t3294788190_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Escape_t3294788190_0_0_0;
extern "C" void PreviousInfo_t2148130204_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void PreviousInfo_t2148130204_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void PreviousInfo_t2148130204_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType PreviousInfo_t2148130204_0_0_0;
extern "C" void DelegatePInvokeWrapper_AppDomainInitializer_t682969308();
extern const RuntimeType AppDomainInitializer_t682969308_0_0_0;
extern "C" void DelegatePInvokeWrapper_Swapper_t2822380397();
extern const RuntimeType Swapper_t2822380397_0_0_0;
extern "C" void DictionaryEntry_t3123975638_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void DictionaryEntry_t3123975638_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void DictionaryEntry_t3123975638_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType DictionaryEntry_t3123975638_0_0_0;
extern "C" void Slot_t3975888750_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Slot_t3975888750_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Slot_t3975888750_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Slot_t3975888750_0_0_0;
extern "C" void Slot_t384495010_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Slot_t384495010_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Slot_t384495010_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Slot_t384495010_0_0_0;
extern "C" void Enum_t4135868527_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Enum_t4135868527_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Enum_t4135868527_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Enum_t4135868527_0_0_0;
extern "C" void DelegatePInvokeWrapper_ReadDelegate_t714865915();
extern const RuntimeType ReadDelegate_t714865915_0_0_0;
extern "C" void DelegatePInvokeWrapper_WriteDelegate_t4270993571();
extern const RuntimeType WriteDelegate_t4270993571_0_0_0;
extern "C" void MonoIOStat_t592533987_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void MonoIOStat_t592533987_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void MonoIOStat_t592533987_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType MonoIOStat_t592533987_0_0_0;
extern "C" void MonoEnumInfo_t3694469084_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void MonoEnumInfo_t3694469084_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void MonoEnumInfo_t3694469084_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType MonoEnumInfo_t3694469084_0_0_0;
extern "C" void CustomAttributeNamedArgument_t287865710_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void CustomAttributeNamedArgument_t287865710_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void CustomAttributeNamedArgument_t287865710_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType CustomAttributeNamedArgument_t287865710_0_0_0;
extern "C" void CustomAttributeTypedArgument_t2723150157_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void CustomAttributeTypedArgument_t2723150157_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void CustomAttributeTypedArgument_t2723150157_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType CustomAttributeTypedArgument_t2723150157_0_0_0;
extern "C" void ILTokenInfo_t2325775114_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ILTokenInfo_t2325775114_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ILTokenInfo_t2325775114_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ILTokenInfo_t2325775114_0_0_0;
extern "C" void MonoResource_t4103430009_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void MonoResource_t4103430009_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void MonoResource_t4103430009_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType MonoResource_t4103430009_0_0_0;
extern "C" void RefEmitPermissionSet_t484390987_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void RefEmitPermissionSet_t484390987_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void RefEmitPermissionSet_t484390987_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType RefEmitPermissionSet_t484390987_0_0_0;
extern "C" void MonoEventInfo_t346866618_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void MonoEventInfo_t346866618_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void MonoEventInfo_t346866618_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType MonoEventInfo_t346866618_0_0_0;
extern "C" void MonoMethodInfo_t1248819020_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void MonoMethodInfo_t1248819020_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void MonoMethodInfo_t1248819020_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType MonoMethodInfo_t1248819020_0_0_0;
extern "C" void MonoPropertyInfo_t3087356066_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void MonoPropertyInfo_t3087356066_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void MonoPropertyInfo_t3087356066_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType MonoPropertyInfo_t3087356066_0_0_0;
extern "C" void ParameterModifier_t1461694466_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ParameterModifier_t1461694466_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ParameterModifier_t1461694466_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ParameterModifier_t1461694466_0_0_0;
extern "C" void ResourceCacheItem_t51292791_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ResourceCacheItem_t51292791_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ResourceCacheItem_t51292791_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ResourceCacheItem_t51292791_0_0_0;
extern "C" void ResourceInfo_t2872965302_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ResourceInfo_t2872965302_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ResourceInfo_t2872965302_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ResourceInfo_t2872965302_0_0_0;
extern "C" void DelegatePInvokeWrapper_CrossContextDelegate_t387175271();
extern const RuntimeType CrossContextDelegate_t387175271_0_0_0;
extern "C" void DelegatePInvokeWrapper_CallbackHandler_t3280319253();
extern const RuntimeType CallbackHandler_t3280319253_0_0_0;
extern "C" void SerializationEntry_t648286436_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void SerializationEntry_t648286436_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void SerializationEntry_t648286436_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType SerializationEntry_t648286436_0_0_0;
extern "C" void StreamingContext_t3711869237_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void StreamingContext_t3711869237_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void StreamingContext_t3711869237_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType StreamingContext_t3711869237_0_0_0;
extern "C" void DSAParameters_t1885824122_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void DSAParameters_t1885824122_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void DSAParameters_t1885824122_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType DSAParameters_t1885824122_0_0_0;
extern "C" void RSAParameters_t1728406613_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void RSAParameters_t1728406613_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void RSAParameters_t1728406613_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType RSAParameters_t1728406613_0_0_0;
extern "C" void SecurityFrame_t1422462475_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void SecurityFrame_t1422462475_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void SecurityFrame_t1422462475_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType SecurityFrame_t1422462475_0_0_0;
extern "C" void DelegatePInvokeWrapper_ThreadStart_t1006689297();
extern const RuntimeType ThreadStart_t1006689297_0_0_0;
extern "C" void ValueType_t3640485471_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ValueType_t3640485471_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ValueType_t3640485471_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ValueType_t3640485471_0_0_0;
extern "C" void DelegatePInvokeWrapper_ReadMethod_t893206259();
extern const RuntimeType ReadMethod_t893206259_0_0_0;
extern "C" void DelegatePInvokeWrapper_UnmanagedReadOrWrite_t876388624();
extern const RuntimeType UnmanagedReadOrWrite_t876388624_0_0_0;
extern "C" void DelegatePInvokeWrapper_WriteMethod_t2538911768();
extern const RuntimeType WriteMethod_t2538911768_0_0_0;
extern "C" void DelegatePInvokeWrapper_ReadDelegate_t4266946825();
extern const RuntimeType ReadDelegate_t4266946825_0_0_0;
extern "C" void DelegatePInvokeWrapper_WriteDelegate_t2016697242();
extern const RuntimeType WriteDelegate_t2016697242_0_0_0;
extern "C" void DelegatePInvokeWrapper_SocketAsyncCall_t1521370843();
extern const RuntimeType SocketAsyncCall_t1521370843_0_0_0;
extern "C" void SocketAsyncResult_t2080034863_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void SocketAsyncResult_t2080034863_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void SocketAsyncResult_t2080034863_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType SocketAsyncResult_t2080034863_0_0_0;
extern "C" void X509ChainStatus_t133602714_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void X509ChainStatus_t133602714_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void X509ChainStatus_t133602714_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType X509ChainStatus_t133602714_0_0_0;
extern "C" void IntStack_t2189327687_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void IntStack_t2189327687_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void IntStack_t2189327687_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType IntStack_t2189327687_0_0_0;
extern "C" void Interval_t1802865632_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Interval_t1802865632_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Interval_t1802865632_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Interval_t1802865632_0_0_0;
extern "C" void DelegatePInvokeWrapper_CostDelegate_t1722821004();
extern const RuntimeType CostDelegate_t1722821004_0_0_0;
extern "C" void UriScheme_t722425697_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void UriScheme_t722425697_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void UriScheme_t722425697_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType UriScheme_t722425697_0_0_0;
extern "C" void DelegatePInvokeWrapper_Action_t1264377477();
extern const RuntimeType Action_t1264377477_0_0_0;
extern "C" void AnimationCurve_t3046754366_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void AnimationCurve_t3046754366_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void AnimationCurve_t3046754366_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType AnimationCurve_t3046754366_0_0_0;
extern "C" void DelegatePInvokeWrapper_AdvertisingIdentifierCallback_t586914420();
extern const RuntimeType AdvertisingIdentifierCallback_t586914420_0_0_0;
extern "C" void DelegatePInvokeWrapper_LogCallback_t3588208630();
extern const RuntimeType LogCallback_t3588208630_0_0_0;
extern "C" void DelegatePInvokeWrapper_LowMemoryCallback_t4104246196();
extern const RuntimeType LowMemoryCallback_t4104246196_0_0_0;
extern "C" void AssetBundleCreateRequest_t3119663542_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void AssetBundleCreateRequest_t3119663542_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void AssetBundleCreateRequest_t3119663542_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType AssetBundleCreateRequest_t3119663542_0_0_0;
extern "C" void AssetBundleRequest_t699759206_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void AssetBundleRequest_t699759206_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void AssetBundleRequest_t699759206_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType AssetBundleRequest_t699759206_0_0_0;
extern "C" void AsyncOperation_t1445031843_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void AsyncOperation_t1445031843_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void AsyncOperation_t1445031843_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType AsyncOperation_t1445031843_0_0_0;
extern "C" void OrderBlock_t1585977831_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void OrderBlock_t1585977831_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void OrderBlock_t1585977831_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType OrderBlock_t1585977831_0_0_0;
extern "C" void Coroutine_t3829159415_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Coroutine_t3829159415_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Coroutine_t3829159415_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Coroutine_t3829159415_0_0_0;
extern "C" void DelegatePInvokeWrapper_CSSMeasureFunc_t1554030124();
extern const RuntimeType CSSMeasureFunc_t1554030124_0_0_0;
extern "C" void CullingGroup_t2096318768_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void CullingGroup_t2096318768_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void CullingGroup_t2096318768_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType CullingGroup_t2096318768_0_0_0;
extern "C" void DelegatePInvokeWrapper_StateChanged_t2136737110();
extern const RuntimeType StateChanged_t2136737110_0_0_0;
extern "C" void DelegatePInvokeWrapper_DisplaysUpdatedDelegate_t51287044();
extern const RuntimeType DisplaysUpdatedDelegate_t51287044_0_0_0;
extern "C" void DelegatePInvokeWrapper_UnityAction_t3245792599();
extern const RuntimeType UnityAction_t3245792599_0_0_0;
extern "C" void FailedToLoadScriptObject_t547604379_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void FailedToLoadScriptObject_t547604379_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void FailedToLoadScriptObject_t547604379_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType FailedToLoadScriptObject_t547604379_0_0_0;
extern "C" void Gradient_t3067099924_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Gradient_t3067099924_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Gradient_t3067099924_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Gradient_t3067099924_0_0_0;
extern "C" void Object_t631007953_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Object_t631007953_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Object_t631007953_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Object_t631007953_0_0_0;
extern "C" void PlayableBinding_t354260709_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void PlayableBinding_t354260709_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void PlayableBinding_t354260709_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType PlayableBinding_t354260709_0_0_0;
extern "C" void RectOffset_t1369453676_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void RectOffset_t1369453676_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void RectOffset_t1369453676_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType RectOffset_t1369453676_0_0_0;
extern "C" void ResourceRequest_t3109103591_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ResourceRequest_t3109103591_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ResourceRequest_t3109103591_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ResourceRequest_t3109103591_0_0_0;
extern "C" void ScriptableObject_t2528358522_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ScriptableObject_t2528358522_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ScriptableObject_t2528358522_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ScriptableObject_t2528358522_0_0_0;
extern "C" void HitInfo_t3229609740_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void HitInfo_t3229609740_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void HitInfo_t3229609740_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType HitInfo_t3229609740_0_0_0;
extern "C" void TrackedReference_t1199777556_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void TrackedReference_t1199777556_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void TrackedReference_t1199777556_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType TrackedReference_t1199777556_0_0_0;
extern "C" void DelegatePInvokeWrapper_RequestAtlasCallback_t3100554279();
extern const RuntimeType RequestAtlasCallback_t3100554279_0_0_0;
extern "C" void WorkRequest_t1354518612_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void WorkRequest_t1354518612_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void WorkRequest_t1354518612_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType WorkRequest_t1354518612_0_0_0;
extern "C" void WaitForSeconds_t1699091251_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void WaitForSeconds_t1699091251_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void WaitForSeconds_t1699091251_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType WaitForSeconds_t1699091251_0_0_0;
extern "C" void YieldInstruction_t403091072_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void YieldInstruction_t403091072_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void YieldInstruction_t403091072_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType YieldInstruction_t403091072_0_0_0;
extern "C" void DelegatePInvokeWrapper_PCMReaderCallback_t1677636661();
extern const RuntimeType PCMReaderCallback_t1677636661_0_0_0;
extern "C" void DelegatePInvokeWrapper_PCMSetPositionCallback_t1059417452();
extern const RuntimeType PCMSetPositionCallback_t1059417452_0_0_0;
extern "C" void DelegatePInvokeWrapper_AudioConfigurationChangeHandler_t2089929874();
extern const RuntimeType AudioConfigurationChangeHandler_t2089929874_0_0_0;
extern "C" void Collision2D_t2842956331_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Collision2D_t2842956331_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Collision2D_t2842956331_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Collision2D_t2842956331_0_0_0;
extern "C" void ContactFilter2D_t3805203441_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ContactFilter2D_t3805203441_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ContactFilter2D_t3805203441_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ContactFilter2D_t3805203441_0_0_0;
extern "C" void RaycastHit2D_t2279581989_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void RaycastHit2D_t2279581989_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void RaycastHit2D_t2279581989_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType RaycastHit2D_t2279581989_0_0_0;
extern "C" void DelegatePInvokeWrapper_FontTextureRebuildCallback_t2467502454();
extern const RuntimeType FontTextureRebuildCallback_t2467502454_0_0_0;
extern "C" void TextGenerationSettings_t1351628751_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void TextGenerationSettings_t1351628751_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void TextGenerationSettings_t1351628751_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType TextGenerationSettings_t1351628751_0_0_0;
extern "C" void TextGenerator_t3211863866_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void TextGenerator_t3211863866_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void TextGenerator_t3211863866_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType TextGenerator_t3211863866_0_0_0;
extern "C" void DownloadHandler_t2937767557_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void DownloadHandler_t2937767557_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void DownloadHandler_t2937767557_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType DownloadHandler_t2937767557_0_0_0;
extern "C" void DownloadHandlerBuffer_t2928496527_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void DownloadHandlerBuffer_t2928496527_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void DownloadHandlerBuffer_t2928496527_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType DownloadHandlerBuffer_t2928496527_0_0_0;
extern "C" void UnityWebRequest_t463507806_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void UnityWebRequest_t463507806_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void UnityWebRequest_t463507806_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType UnityWebRequest_t463507806_0_0_0;
extern "C" void UnityWebRequestAsyncOperation_t3852015985_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void UnityWebRequestAsyncOperation_t3852015985_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void UnityWebRequestAsyncOperation_t3852015985_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType UnityWebRequestAsyncOperation_t3852015985_0_0_0;
extern "C" void UploadHandler_t2993558019_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void UploadHandler_t2993558019_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void UploadHandler_t2993558019_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType UploadHandler_t2993558019_0_0_0;
extern "C" void UploadHandlerRaw_t25761545_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void UploadHandlerRaw_t25761545_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void UploadHandlerRaw_t25761545_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType UploadHandlerRaw_t25761545_0_0_0;
extern "C" void DelegatePInvokeWrapper_OnNavMeshPreUpdate_t1580782682();
extern const RuntimeType OnNavMeshPreUpdate_t1580782682_0_0_0;
extern "C" void AnimationEvent_t1536042487_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void AnimationEvent_t1536042487_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void AnimationEvent_t1536042487_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType AnimationEvent_t1536042487_0_0_0;
extern "C" void AnimatorTransitionInfo_t2534804151_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void AnimatorTransitionInfo_t2534804151_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void AnimatorTransitionInfo_t2534804151_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType AnimatorTransitionInfo_t2534804151_0_0_0;
extern "C" void HumanBone_t2465339518_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void HumanBone_t2465339518_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void HumanBone_t2465339518_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType HumanBone_t2465339518_0_0_0;
extern "C" void SkeletonBone_t4134054672_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void SkeletonBone_t4134054672_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void SkeletonBone_t4134054672_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType SkeletonBone_t4134054672_0_0_0;
extern "C" void Event_t2956885303_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Event_t2956885303_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Event_t2956885303_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Event_t2956885303_0_0_0;
extern "C" void DelegatePInvokeWrapper_WindowFunction_t3146511083();
extern const RuntimeType WindowFunction_t3146511083_0_0_0;
extern "C" void GUIContent_t3050628031_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void GUIContent_t3050628031_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void GUIContent_t3050628031_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType GUIContent_t3050628031_0_0_0;
extern "C" void DelegatePInvokeWrapper_SkinChangedDelegate_t1143955295();
extern const RuntimeType SkinChangedDelegate_t1143955295_0_0_0;
extern "C" void GUIStyle_t3956901511_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void GUIStyle_t3956901511_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void GUIStyle_t3956901511_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType GUIStyle_t3956901511_0_0_0;
extern "C" void GUIStyleState_t1397964415_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void GUIStyleState_t1397964415_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void GUIStyleState_t1397964415_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType GUIStyleState_t1397964415_0_0_0;
extern "C" void SliderHandler_t1154919399_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void SliderHandler_t1154919399_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void SliderHandler_t1154919399_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType SliderHandler_t1154919399_0_0_0;
extern "C" void DelegatePInvokeWrapper_NativeDeviceDiscoveredCallback_t3494240628();
extern const RuntimeType NativeDeviceDiscoveredCallback_t3494240628_0_0_0;
extern "C" void DelegatePInvokeWrapper_NativeEventCallback_t83445637();
extern const RuntimeType NativeEventCallback_t83445637_0_0_0;
extern "C" void NativeInputDeviceInfo_t3032009285_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void NativeInputDeviceInfo_t3032009285_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void NativeInputDeviceInfo_t3032009285_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType NativeInputDeviceInfo_t3032009285_0_0_0;
extern "C" void DelegatePInvokeWrapper_NativeUpdateCallback_t2379345390();
extern const RuntimeType NativeUpdateCallback_t2379345390_0_0_0;
extern "C" void EmissionModule_t311448003_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void EmissionModule_t311448003_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void EmissionModule_t311448003_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType EmissionModule_t311448003_0_0_0;
extern "C" void Collision_t4262080450_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Collision_t4262080450_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Collision_t4262080450_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Collision_t4262080450_0_0_0;
extern "C" void ControllerColliderHit_t240592346_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ControllerColliderHit_t240592346_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ControllerColliderHit_t240592346_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ControllerColliderHit_t240592346_0_0_0;
extern "C" void RaycastHit_t1056001966_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void RaycastHit_t1056001966_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void RaycastHit_t1056001966_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType RaycastHit_t1056001966_0_0_0;
extern "C" void TileAnimationData_t649120048_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void TileAnimationData_t649120048_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void TileAnimationData_t649120048_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType TileAnimationData_t649120048_0_0_0;
extern "C" void TileData_t2042394239_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void TileData_t2042394239_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void TileData_t2042394239_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType TileData_t2042394239_0_0_0;
extern "C" void DelegatePInvokeWrapper_WillRenderCanvases_t3309123499();
extern const RuntimeType WillRenderCanvases_t3309123499_0_0_0;
extern "C" void TagName_t2891256255_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void TagName_t2891256255_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void TagName_t2891256255_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType TagName_t2891256255_0_0_0;
extern "C" void QNameValueType_t615604793_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void QNameValueType_t615604793_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void QNameValueType_t615604793_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType QNameValueType_t615604793_0_0_0;
extern "C" void StringArrayValueType_t3147326440_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void StringArrayValueType_t3147326440_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void StringArrayValueType_t3147326440_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType StringArrayValueType_t3147326440_0_0_0;
extern "C" void StringValueType_t261329552_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void StringValueType_t261329552_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void StringValueType_t261329552_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType StringValueType_t261329552_0_0_0;
extern "C" void UriValueType_t2866347695_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void UriValueType_t2866347695_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void UriValueType_t2866347695_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType UriValueType_t2866347695_0_0_0;
extern "C" void NsDecl_t3938094415_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void NsDecl_t3938094415_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void NsDecl_t3938094415_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType NsDecl_t3938094415_0_0_0;
extern "C" void NsScope_t3958624705_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void NsScope_t3958624705_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void NsScope_t3958624705_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType NsScope_t3958624705_0_0_0;
extern "C" void DelegatePInvokeWrapper_CharGetter_t1703763694();
extern const RuntimeType CharGetter_t1703763694_0_0_0;
extern "C" void RaycastResult_t3360306849_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void RaycastResult_t3360306849_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void RaycastResult_t3360306849_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType RaycastResult_t3360306849_0_0_0;
extern "C" void ColorTween_t809614380_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ColorTween_t809614380_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ColorTween_t809614380_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ColorTween_t809614380_0_0_0;
extern "C" void FloatTween_t1274330004_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void FloatTween_t1274330004_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void FloatTween_t1274330004_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType FloatTween_t1274330004_0_0_0;
extern "C" void Resources_t1597885468_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Resources_t1597885468_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Resources_t1597885468_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Resources_t1597885468_0_0_0;
extern "C" void DelegatePInvokeWrapper_OnValidateInput_t2355412304();
extern const RuntimeType OnValidateInput_t2355412304_0_0_0;
extern "C" void Navigation_t3049316579_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Navigation_t3049316579_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Navigation_t3049316579_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Navigation_t3049316579_0_0_0;
extern "C" void SpriteState_t1362986479_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void SpriteState_t1362986479_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void SpriteState_t1362986479_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType SpriteState_t1362986479_0_0_0;
extern "C" void QueuedDebugLogEntry_t2072794530_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void QueuedDebugLogEntry_t2072794530_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void QueuedDebugLogEntry_t2072794530_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType QueuedDebugLogEntry_t2072794530_0_0_0;
extern "C" void AchievementDataHolder_t290853885_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void AchievementDataHolder_t290853885_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void AchievementDataHolder_t290853885_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType AchievementDataHolder_t290853885_0_0_0;
extern "C" void DelegatePInvokeWrapper_OnAudioMuted_t2328156291();
extern const RuntimeType OnAudioMuted_t2328156291_0_0_0;
extern "C" void BackgroundData_t3682119881_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void BackgroundData_t3682119881_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void BackgroundData_t3682119881_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType BackgroundData_t3682119881_0_0_0;
extern "C" void BirdWakeUpEvent_t4025743789_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void BirdWakeUpEvent_t4025743789_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void BirdWakeUpEvent_t4025743789_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType BirdWakeUpEvent_t4025743789_0_0_0;
extern "C" void DelegatePInvokeWrapper_InputDelegate_t60576951();
extern const RuntimeType InputDelegate_t60576951_0_0_0;
extern "C" void CakeRaceInfo_t990596595_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void CakeRaceInfo_t990596595_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void CakeRaceInfo_t990596595_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType CakeRaceInfo_t990596595_0_0_0;
extern "C" void ObjectLocation_t2396930893_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ObjectLocation_t2396930893_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ObjectLocation_t2396930893_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ObjectLocation_t2396930893_0_0_0;
extern "C" void StartInfo_t2919652100_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void StartInfo_t2919652100_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void StartInfo_t2919652100_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType StartInfo_t2919652100_0_0_0;
extern "C" void TimerModePair_t2879060035_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void TimerModePair_t2879060035_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void TimerModePair_t2879060035_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType TimerModePair_t2879060035_0_0_0;
extern "C" void ConnectedComponent_t2516682977_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ConnectedComponent_t2516682977_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ConnectedComponent_t2516682977_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ConnectedComponent_t2516682977_0_0_0;
extern "C" void JointConnection_t3688484570_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void JointConnection_t3688484570_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void JointConnection_t3688484570_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType JointConnection_t3688484570_0_0_0;
extern "C" void ChallengeConfigs_t2059436732_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ChallengeConfigs_t2059436732_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ChallengeConfigs_t2059436732_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ChallengeConfigs_t2059436732_0_0_0;
extern "C" void ChallengeInfo_t2275744116_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ChallengeInfo_t2275744116_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ChallengeInfo_t2275744116_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ChallengeInfo_t2275744116_0_0_0;
extern "C" void DessertCollectedEvent_t4241761954_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void DessertCollectedEvent_t4241761954_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void DessertCollectedEvent_t4241761954_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType DessertCollectedEvent_t4241761954_0_0_0;
extern "C" void DelegatePInvokeWrapper_OnClose_t3291647407();
extern const RuntimeType OnClose_t3291647407_0_0_0;
extern "C" void DelegatePInvokeWrapper_OnOpen_t2905586510();
extern const RuntimeType OnOpen_t2905586510_0_0_0;
extern "C" void DelegatePInvokeWrapper_ExternalAppMessageReceived_t1638583432();
extern const RuntimeType ExternalAppMessageReceived_t1638583432_0_0_0;
extern "C" void AchievementDataStruct_t1666718540_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void AchievementDataStruct_t1666718540_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void AchievementDataStruct_t1666718540_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType AchievementDataStruct_t1666718540_0_0_0;
extern "C" void AchievementQueueBlock_t1460733219_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void AchievementQueueBlock_t1460733219_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void AchievementQueueBlock_t1460733219_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType AchievementQueueBlock_t1460733219_0_0_0;
extern "C" void LeaderboardDataStruct_t2092881696_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void LeaderboardDataStruct_t2092881696_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void LeaderboardDataStruct_t2092881696_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType LeaderboardDataStruct_t2092881696_0_0_0;
extern "C" void GameTimePaused_t1121804034_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void GameTimePaused_t1121804034_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void GameTimePaused_t1121804034_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType GameTimePaused_t1121804034_0_0_0;
extern "C" void DelegatePInvokeWrapper_PurchaseFailed_t1639931944();
extern const RuntimeType PurchaseFailed_t1639931944_0_0_0;
extern "C" void DelegatePInvokeWrapper_PurchaseSucceeded_t2204089269();
extern const RuntimeType PurchaseSucceeded_t2204089269_0_0_0;
extern "C" void DelegatePInvokeWrapper_RestorePurchaseComplete_t3798189757();
extern const RuntimeType RestorePurchaseComplete_t3798189757_0_0_0;
extern "C" void ApplyNightVisionEvent_t3252991219_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ApplyNightVisionEvent_t3252991219_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ApplyNightVisionEvent_t3252991219_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ApplyNightVisionEvent_t3252991219_0_0_0;
extern "C" void ApplySuperGlueEvent_t66780888_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ApplySuperGlueEvent_t66780888_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ApplySuperGlueEvent_t66780888_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ApplySuperGlueEvent_t66780888_0_0_0;
extern "C" void ApplySuperMagnetEvent_t2211318601_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ApplySuperMagnetEvent_t2211318601_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ApplySuperMagnetEvent_t2211318601_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ApplySuperMagnetEvent_t2211318601_0_0_0;
extern "C" void ApplyTurboChargeEvent_t2820362279_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ApplyTurboChargeEvent_t2820362279_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ApplyTurboChargeEvent_t2820362279_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ApplyTurboChargeEvent_t2820362279_0_0_0;
extern "C" void AutoBuildEvent_t2414972399_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void AutoBuildEvent_t2414972399_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void AutoBuildEvent_t2414972399_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType AutoBuildEvent_t2414972399_0_0_0;
extern "C" void DelegatePInvokeWrapper_OnClose_t3070614049();
extern const RuntimeType OnClose_t3070614049_0_0_0;
extern "C" void DelegatePInvokeWrapper_CompressFunc_t3594827279();
extern const RuntimeType CompressFunc_t3594827279_0_0_0;
extern "C" void DessertPlacePair_t1365446491_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void DessertPlacePair_t1365446491_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void DessertPlacePair_t1365446491_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType DessertPlacePair_t1365446491_0_0_0;
extern "C" void LoadLevelEvent_t1076517439_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void LoadLevelEvent_t1076517439_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void LoadLevelEvent_t1076517439_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType LoadLevelEvent_t1076517439_0_0_0;
extern "C" void LocalizationReloaded_t1062245660_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void LocalizationReloaded_t1062245660_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void LocalizationReloaded_t1062245660_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType LocalizationReloaded_t1062245660_0_0_0;
extern "C" void AnalyticData_t3667669175_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void AnalyticData_t3667669175_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void AnalyticData_t3667669175_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType AnalyticData_t3667669175_0_0_0;
extern "C" void LootWheelReward_t1830224244_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void LootWheelReward_t1830224244_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void LootWheelReward_t1830224244_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType LootWheelReward_t1830224244_0_0_0;
extern "C" void MeshObject_t85759963_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void MeshObject_t85759963_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void MeshObject_t85759963_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType MeshObject_t85759963_0_0_0;
extern "C" void DelegatePInvokeWrapper_OnCheckResponseDelegate_t1854801344();
extern const RuntimeType OnCheckResponseDelegate_t1854801344_0_0_0;
extern "C" void DelegatePInvokeWrapper_OnNetworkChangedDelegate_t2214548974();
extern const RuntimeType OnNetworkChangedDelegate_t2214548974_0_0_0;
extern "C" void DelegatePInvokeWrapper_OnInitializeHandler_t608088752();
extern const RuntimeType OnInitializeHandler_t608088752_0_0_0;
extern "C" void DelegatePInvokeWrapper_OnTimedOut_t1431860576();
extern const RuntimeType OnTimedOut_t1431860576_0_0_0;
extern "C" void DelegatePInvokeWrapper_OnTimerHandler_t3671552975();
extern const RuntimeType OnTimerHandler_t3671552975_0_0_0;
extern "C" void DelegatePInvokeWrapper_PageChanged_t3614939429();
extern const RuntimeType PageChanged_t3614939429_0_0_0;
extern "C" void ParallaxCustomLayer_t3964718142_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ParallaxCustomLayer_t3964718142_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ParallaxCustomLayer_t3964718142_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ParallaxCustomLayer_t3964718142_0_0_0;
extern "C" void DelegatePInvokeWrapper_Collected_t634675809();
extern const RuntimeType Collected_t634675809_0_0_0;
extern "C" void PulseButtonEvent_t3712592501_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void PulseButtonEvent_t3712592501_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void PulseButtonEvent_t3712592501_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType PulseButtonEvent_t3712592501_0_0_0;
extern "C" void Node_t1829454632_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Node_t1829454632_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Node_t1829454632_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Node_t1829454632_0_0_0;
extern "C" void DelegatePInvokeWrapper_OnPress_t1412303708();
extern const RuntimeType OnPress_t1412303708_0_0_0;
extern "C" void AnimationPair_t1784808777_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void AnimationPair_t1784808777_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void AnimationPair_t1784808777_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType AnimationPair_t1784808777_0_0_0;
extern "C" void AttachmentKeyTuple_t1548106539_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void AttachmentKeyTuple_t1548106539_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void AttachmentKeyTuple_t1548106539_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType AttachmentKeyTuple_t1548106539_0_0_0;
extern "C" void MeshAndMaterials_t908474435_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void MeshAndMaterials_t908474435_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void MeshAndMaterials_t908474435_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType MeshAndMaterials_t908474435_0_0_0;
extern "C" void SubmeshInstruction_t414082835_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void SubmeshInstruction_t414082835_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void SubmeshInstruction_t414082835_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType SubmeshInstruction_t414082835_0_0_0;
extern "C" void AtlasMaterialOverride_t2435041389_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void AtlasMaterialOverride_t2435041389_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void AtlasMaterialOverride_t2435041389_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType AtlasMaterialOverride_t2435041389_0_0_0;
extern "C" void SlotMaterialOverride_t1001979181_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void SlotMaterialOverride_t1001979181_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void SlotMaterialOverride_t1001979181_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType SlotMaterialOverride_t1001979181_0_0_0;
extern "C" void TransformPair_t3795417756_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void TransformPair_t3795417756_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void TransformPair_t3795417756_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType TransformPair_t3795417756_0_0_0;
extern "C" void DelegatePInvokeWrapper_SkeletonUtilityDelegate_t487527757();
extern const RuntimeType SkeletonUtilityDelegate_t487527757_0_0_0;
extern "C" void Hierarchy_t2161623951_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Hierarchy_t2161623951_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Hierarchy_t2161623951_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Hierarchy_t2161623951_0_0_0;
extern "C" void DelegatePInvokeWrapper_OnPlay_t1571682685();
extern const RuntimeType OnPlay_t1571682685_0_0_0;
extern "C" void DelegatePInvokeWrapper_Collected_t732746415();
extern const RuntimeType Collected_t732746415_0_0_0;
extern "C" void DelegatePInvokeWrapper_OnClose_t772094743();
extern const RuntimeType OnClose_t772094743_0_0_0;
extern "C" void DelegatePInvokeWrapper_OnConfirm_t1805170460();
extern const RuntimeType OnConfirm_t1805170460_0_0_0;
extern "C" void DelegatePInvokeWrapper_OnOpen_t1527099976();
extern const RuntimeType OnOpen_t1527099976_0_0_0;
extern "C" void TextKeyPair_t1148982378_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void TextKeyPair_t1148982378_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void TextKeyPair_t1148982378_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType TextKeyPair_t1148982378_0_0_0;
extern "C" void DelegatePInvokeWrapper_OnPress_t3738947737();
extern const RuntimeType OnPress_t3738947737_0_0_0;
extern "C" void DelegatePInvokeWrapper_OnPayPressed_t3240706507();
extern const RuntimeType OnPayPressed_t3240706507_0_0_0;
extern "C" void DelegatePInvokeWrapper_OnWatchAdPressed_t561592073();
extern const RuntimeType OnWatchAdPressed_t561592073_0_0_0;
extern "C" void ConditionStruct_t3952177795_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ConditionStruct_t3952177795_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ConditionStruct_t3952177795_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ConditionStruct_t3952177795_0_0_0;
extern "C" void DelegatePInvokeWrapper_ConditionChange_t1091918374();
extern const RuntimeType ConditionChange_t1091918374_0_0_0;
extern "C" void DelegatePInvokeWrapper_ConditionCheck_t690039966();
extern const RuntimeType ConditionCheck_t690039966_0_0_0;
extern const RuntimeType CRC32_t2128839853_0_0_0;
extern const RuntimeType ZlibCodec_t3653667923_0_0_0;
extern const RuntimeType ZlibException_t2135990123_0_0_0;
extern Il2CppInteropData g_Il2CppInteropData[200] = 
{
	{ NULL, Context_t1744531130_marshal_pinvoke, Context_t1744531130_marshal_pinvoke_back, Context_t1744531130_marshal_pinvoke_cleanup, NULL, NULL, &Context_t1744531130_0_0_0 } /* Mono.Globalization.Unicode.SimpleCollator/Context */,
	{ NULL, Escape_t3294788190_marshal_pinvoke, Escape_t3294788190_marshal_pinvoke_back, Escape_t3294788190_marshal_pinvoke_cleanup, NULL, NULL, &Escape_t3294788190_0_0_0 } /* Mono.Globalization.Unicode.SimpleCollator/Escape */,
	{ NULL, PreviousInfo_t2148130204_marshal_pinvoke, PreviousInfo_t2148130204_marshal_pinvoke_back, PreviousInfo_t2148130204_marshal_pinvoke_cleanup, NULL, NULL, &PreviousInfo_t2148130204_0_0_0 } /* Mono.Globalization.Unicode.SimpleCollator/PreviousInfo */,
	{ DelegatePInvokeWrapper_AppDomainInitializer_t682969308, NULL, NULL, NULL, NULL, NULL, &AppDomainInitializer_t682969308_0_0_0 } /* System.AppDomainInitializer */,
	{ DelegatePInvokeWrapper_Swapper_t2822380397, NULL, NULL, NULL, NULL, NULL, &Swapper_t2822380397_0_0_0 } /* System.Array/Swapper */,
	{ NULL, DictionaryEntry_t3123975638_marshal_pinvoke, DictionaryEntry_t3123975638_marshal_pinvoke_back, DictionaryEntry_t3123975638_marshal_pinvoke_cleanup, NULL, NULL, &DictionaryEntry_t3123975638_0_0_0 } /* System.Collections.DictionaryEntry */,
	{ NULL, Slot_t3975888750_marshal_pinvoke, Slot_t3975888750_marshal_pinvoke_back, Slot_t3975888750_marshal_pinvoke_cleanup, NULL, NULL, &Slot_t3975888750_0_0_0 } /* System.Collections.Hashtable/Slot */,
	{ NULL, Slot_t384495010_marshal_pinvoke, Slot_t384495010_marshal_pinvoke_back, Slot_t384495010_marshal_pinvoke_cleanup, NULL, NULL, &Slot_t384495010_0_0_0 } /* System.Collections.SortedList/Slot */,
	{ NULL, Enum_t4135868527_marshal_pinvoke, Enum_t4135868527_marshal_pinvoke_back, Enum_t4135868527_marshal_pinvoke_cleanup, NULL, NULL, &Enum_t4135868527_0_0_0 } /* System.Enum */,
	{ DelegatePInvokeWrapper_ReadDelegate_t714865915, NULL, NULL, NULL, NULL, NULL, &ReadDelegate_t714865915_0_0_0 } /* System.IO.FileStream/ReadDelegate */,
	{ DelegatePInvokeWrapper_WriteDelegate_t4270993571, NULL, NULL, NULL, NULL, NULL, &WriteDelegate_t4270993571_0_0_0 } /* System.IO.FileStream/WriteDelegate */,
	{ NULL, MonoIOStat_t592533987_marshal_pinvoke, MonoIOStat_t592533987_marshal_pinvoke_back, MonoIOStat_t592533987_marshal_pinvoke_cleanup, NULL, NULL, &MonoIOStat_t592533987_0_0_0 } /* System.IO.MonoIOStat */,
	{ NULL, MonoEnumInfo_t3694469084_marshal_pinvoke, MonoEnumInfo_t3694469084_marshal_pinvoke_back, MonoEnumInfo_t3694469084_marshal_pinvoke_cleanup, NULL, NULL, &MonoEnumInfo_t3694469084_0_0_0 } /* System.MonoEnumInfo */,
	{ NULL, CustomAttributeNamedArgument_t287865710_marshal_pinvoke, CustomAttributeNamedArgument_t287865710_marshal_pinvoke_back, CustomAttributeNamedArgument_t287865710_marshal_pinvoke_cleanup, NULL, NULL, &CustomAttributeNamedArgument_t287865710_0_0_0 } /* System.Reflection.CustomAttributeNamedArgument */,
	{ NULL, CustomAttributeTypedArgument_t2723150157_marshal_pinvoke, CustomAttributeTypedArgument_t2723150157_marshal_pinvoke_back, CustomAttributeTypedArgument_t2723150157_marshal_pinvoke_cleanup, NULL, NULL, &CustomAttributeTypedArgument_t2723150157_0_0_0 } /* System.Reflection.CustomAttributeTypedArgument */,
	{ NULL, ILTokenInfo_t2325775114_marshal_pinvoke, ILTokenInfo_t2325775114_marshal_pinvoke_back, ILTokenInfo_t2325775114_marshal_pinvoke_cleanup, NULL, NULL, &ILTokenInfo_t2325775114_0_0_0 } /* System.Reflection.Emit.ILTokenInfo */,
	{ NULL, MonoResource_t4103430009_marshal_pinvoke, MonoResource_t4103430009_marshal_pinvoke_back, MonoResource_t4103430009_marshal_pinvoke_cleanup, NULL, NULL, &MonoResource_t4103430009_0_0_0 } /* System.Reflection.Emit.MonoResource */,
	{ NULL, RefEmitPermissionSet_t484390987_marshal_pinvoke, RefEmitPermissionSet_t484390987_marshal_pinvoke_back, RefEmitPermissionSet_t484390987_marshal_pinvoke_cleanup, NULL, NULL, &RefEmitPermissionSet_t484390987_0_0_0 } /* System.Reflection.Emit.RefEmitPermissionSet */,
	{ NULL, MonoEventInfo_t346866618_marshal_pinvoke, MonoEventInfo_t346866618_marshal_pinvoke_back, MonoEventInfo_t346866618_marshal_pinvoke_cleanup, NULL, NULL, &MonoEventInfo_t346866618_0_0_0 } /* System.Reflection.MonoEventInfo */,
	{ NULL, MonoMethodInfo_t1248819020_marshal_pinvoke, MonoMethodInfo_t1248819020_marshal_pinvoke_back, MonoMethodInfo_t1248819020_marshal_pinvoke_cleanup, NULL, NULL, &MonoMethodInfo_t1248819020_0_0_0 } /* System.Reflection.MonoMethodInfo */,
	{ NULL, MonoPropertyInfo_t3087356066_marshal_pinvoke, MonoPropertyInfo_t3087356066_marshal_pinvoke_back, MonoPropertyInfo_t3087356066_marshal_pinvoke_cleanup, NULL, NULL, &MonoPropertyInfo_t3087356066_0_0_0 } /* System.Reflection.MonoPropertyInfo */,
	{ NULL, ParameterModifier_t1461694466_marshal_pinvoke, ParameterModifier_t1461694466_marshal_pinvoke_back, ParameterModifier_t1461694466_marshal_pinvoke_cleanup, NULL, NULL, &ParameterModifier_t1461694466_0_0_0 } /* System.Reflection.ParameterModifier */,
	{ NULL, ResourceCacheItem_t51292791_marshal_pinvoke, ResourceCacheItem_t51292791_marshal_pinvoke_back, ResourceCacheItem_t51292791_marshal_pinvoke_cleanup, NULL, NULL, &ResourceCacheItem_t51292791_0_0_0 } /* System.Resources.ResourceReader/ResourceCacheItem */,
	{ NULL, ResourceInfo_t2872965302_marshal_pinvoke, ResourceInfo_t2872965302_marshal_pinvoke_back, ResourceInfo_t2872965302_marshal_pinvoke_cleanup, NULL, NULL, &ResourceInfo_t2872965302_0_0_0 } /* System.Resources.ResourceReader/ResourceInfo */,
	{ DelegatePInvokeWrapper_CrossContextDelegate_t387175271, NULL, NULL, NULL, NULL, NULL, &CrossContextDelegate_t387175271_0_0_0 } /* System.Runtime.Remoting.Contexts.CrossContextDelegate */,
	{ DelegatePInvokeWrapper_CallbackHandler_t3280319253, NULL, NULL, NULL, NULL, NULL, &CallbackHandler_t3280319253_0_0_0 } /* System.Runtime.Serialization.SerializationCallbacks/CallbackHandler */,
	{ NULL, SerializationEntry_t648286436_marshal_pinvoke, SerializationEntry_t648286436_marshal_pinvoke_back, SerializationEntry_t648286436_marshal_pinvoke_cleanup, NULL, NULL, &SerializationEntry_t648286436_0_0_0 } /* System.Runtime.Serialization.SerializationEntry */,
	{ NULL, StreamingContext_t3711869237_marshal_pinvoke, StreamingContext_t3711869237_marshal_pinvoke_back, StreamingContext_t3711869237_marshal_pinvoke_cleanup, NULL, NULL, &StreamingContext_t3711869237_0_0_0 } /* System.Runtime.Serialization.StreamingContext */,
	{ NULL, DSAParameters_t1885824122_marshal_pinvoke, DSAParameters_t1885824122_marshal_pinvoke_back, DSAParameters_t1885824122_marshal_pinvoke_cleanup, NULL, NULL, &DSAParameters_t1885824122_0_0_0 } /* System.Security.Cryptography.DSAParameters */,
	{ NULL, RSAParameters_t1728406613_marshal_pinvoke, RSAParameters_t1728406613_marshal_pinvoke_back, RSAParameters_t1728406613_marshal_pinvoke_cleanup, NULL, NULL, &RSAParameters_t1728406613_0_0_0 } /* System.Security.Cryptography.RSAParameters */,
	{ NULL, SecurityFrame_t1422462475_marshal_pinvoke, SecurityFrame_t1422462475_marshal_pinvoke_back, SecurityFrame_t1422462475_marshal_pinvoke_cleanup, NULL, NULL, &SecurityFrame_t1422462475_0_0_0 } /* System.Security.SecurityFrame */,
	{ DelegatePInvokeWrapper_ThreadStart_t1006689297, NULL, NULL, NULL, NULL, NULL, &ThreadStart_t1006689297_0_0_0 } /* System.Threading.ThreadStart */,
	{ NULL, ValueType_t3640485471_marshal_pinvoke, ValueType_t3640485471_marshal_pinvoke_back, ValueType_t3640485471_marshal_pinvoke_cleanup, NULL, NULL, &ValueType_t3640485471_0_0_0 } /* System.ValueType */,
	{ DelegatePInvokeWrapper_ReadMethod_t893206259, NULL, NULL, NULL, NULL, NULL, &ReadMethod_t893206259_0_0_0 } /* System.IO.Compression.DeflateStream/ReadMethod */,
	{ DelegatePInvokeWrapper_UnmanagedReadOrWrite_t876388624, NULL, NULL, NULL, NULL, NULL, &UnmanagedReadOrWrite_t876388624_0_0_0 } /* System.IO.Compression.DeflateStream/UnmanagedReadOrWrite */,
	{ DelegatePInvokeWrapper_WriteMethod_t2538911768, NULL, NULL, NULL, NULL, NULL, &WriteMethod_t2538911768_0_0_0 } /* System.IO.Compression.DeflateStream/WriteMethod */,
	{ DelegatePInvokeWrapper_ReadDelegate_t4266946825, NULL, NULL, NULL, NULL, NULL, &ReadDelegate_t4266946825_0_0_0 } /* System.Net.FtpDataStream/ReadDelegate */,
	{ DelegatePInvokeWrapper_WriteDelegate_t2016697242, NULL, NULL, NULL, NULL, NULL, &WriteDelegate_t2016697242_0_0_0 } /* System.Net.FtpDataStream/WriteDelegate */,
	{ DelegatePInvokeWrapper_SocketAsyncCall_t1521370843, NULL, NULL, NULL, NULL, NULL, &SocketAsyncCall_t1521370843_0_0_0 } /* System.Net.Sockets.Socket/SocketAsyncCall */,
	{ NULL, SocketAsyncResult_t2080034863_marshal_pinvoke, SocketAsyncResult_t2080034863_marshal_pinvoke_back, SocketAsyncResult_t2080034863_marshal_pinvoke_cleanup, NULL, NULL, &SocketAsyncResult_t2080034863_0_0_0 } /* System.Net.Sockets.Socket/SocketAsyncResult */,
	{ NULL, X509ChainStatus_t133602714_marshal_pinvoke, X509ChainStatus_t133602714_marshal_pinvoke_back, X509ChainStatus_t133602714_marshal_pinvoke_cleanup, NULL, NULL, &X509ChainStatus_t133602714_0_0_0 } /* System.Security.Cryptography.X509Certificates.X509ChainStatus */,
	{ NULL, IntStack_t2189327687_marshal_pinvoke, IntStack_t2189327687_marshal_pinvoke_back, IntStack_t2189327687_marshal_pinvoke_cleanup, NULL, NULL, &IntStack_t2189327687_0_0_0 } /* System.Text.RegularExpressions.Interpreter/IntStack */,
	{ NULL, Interval_t1802865632_marshal_pinvoke, Interval_t1802865632_marshal_pinvoke_back, Interval_t1802865632_marshal_pinvoke_cleanup, NULL, NULL, &Interval_t1802865632_0_0_0 } /* System.Text.RegularExpressions.Interval */,
	{ DelegatePInvokeWrapper_CostDelegate_t1722821004, NULL, NULL, NULL, NULL, NULL, &CostDelegate_t1722821004_0_0_0 } /* System.Text.RegularExpressions.IntervalCollection/CostDelegate */,
	{ NULL, UriScheme_t722425697_marshal_pinvoke, UriScheme_t722425697_marshal_pinvoke_back, UriScheme_t722425697_marshal_pinvoke_cleanup, NULL, NULL, &UriScheme_t722425697_0_0_0 } /* System.Uri/UriScheme */,
	{ DelegatePInvokeWrapper_Action_t1264377477, NULL, NULL, NULL, NULL, NULL, &Action_t1264377477_0_0_0 } /* System.Action */,
	{ NULL, AnimationCurve_t3046754366_marshal_pinvoke, AnimationCurve_t3046754366_marshal_pinvoke_back, AnimationCurve_t3046754366_marshal_pinvoke_cleanup, NULL, NULL, &AnimationCurve_t3046754366_0_0_0 } /* UnityEngine.AnimationCurve */,
	{ DelegatePInvokeWrapper_AdvertisingIdentifierCallback_t586914420, NULL, NULL, NULL, NULL, NULL, &AdvertisingIdentifierCallback_t586914420_0_0_0 } /* UnityEngine.Application/AdvertisingIdentifierCallback */,
	{ DelegatePInvokeWrapper_LogCallback_t3588208630, NULL, NULL, NULL, NULL, NULL, &LogCallback_t3588208630_0_0_0 } /* UnityEngine.Application/LogCallback */,
	{ DelegatePInvokeWrapper_LowMemoryCallback_t4104246196, NULL, NULL, NULL, NULL, NULL, &LowMemoryCallback_t4104246196_0_0_0 } /* UnityEngine.Application/LowMemoryCallback */,
	{ NULL, AssetBundleCreateRequest_t3119663542_marshal_pinvoke, AssetBundleCreateRequest_t3119663542_marshal_pinvoke_back, AssetBundleCreateRequest_t3119663542_marshal_pinvoke_cleanup, NULL, NULL, &AssetBundleCreateRequest_t3119663542_0_0_0 } /* UnityEngine.AssetBundleCreateRequest */,
	{ NULL, AssetBundleRequest_t699759206_marshal_pinvoke, AssetBundleRequest_t699759206_marshal_pinvoke_back, AssetBundleRequest_t699759206_marshal_pinvoke_cleanup, NULL, NULL, &AssetBundleRequest_t699759206_0_0_0 } /* UnityEngine.AssetBundleRequest */,
	{ NULL, AsyncOperation_t1445031843_marshal_pinvoke, AsyncOperation_t1445031843_marshal_pinvoke_back, AsyncOperation_t1445031843_marshal_pinvoke_cleanup, NULL, NULL, &AsyncOperation_t1445031843_0_0_0 } /* UnityEngine.AsyncOperation */,
	{ NULL, OrderBlock_t1585977831_marshal_pinvoke, OrderBlock_t1585977831_marshal_pinvoke_back, OrderBlock_t1585977831_marshal_pinvoke_cleanup, NULL, NULL, &OrderBlock_t1585977831_0_0_0 } /* UnityEngine.BeforeRenderHelper/OrderBlock */,
	{ NULL, Coroutine_t3829159415_marshal_pinvoke, Coroutine_t3829159415_marshal_pinvoke_back, Coroutine_t3829159415_marshal_pinvoke_cleanup, NULL, NULL, &Coroutine_t3829159415_0_0_0 } /* UnityEngine.Coroutine */,
	{ DelegatePInvokeWrapper_CSSMeasureFunc_t1554030124, NULL, NULL, NULL, NULL, NULL, &CSSMeasureFunc_t1554030124_0_0_0 } /* UnityEngine.CSSLayout.CSSMeasureFunc */,
	{ NULL, CullingGroup_t2096318768_marshal_pinvoke, CullingGroup_t2096318768_marshal_pinvoke_back, CullingGroup_t2096318768_marshal_pinvoke_cleanup, NULL, NULL, &CullingGroup_t2096318768_0_0_0 } /* UnityEngine.CullingGroup */,
	{ DelegatePInvokeWrapper_StateChanged_t2136737110, NULL, NULL, NULL, NULL, NULL, &StateChanged_t2136737110_0_0_0 } /* UnityEngine.CullingGroup/StateChanged */,
	{ DelegatePInvokeWrapper_DisplaysUpdatedDelegate_t51287044, NULL, NULL, NULL, NULL, NULL, &DisplaysUpdatedDelegate_t51287044_0_0_0 } /* UnityEngine.Display/DisplaysUpdatedDelegate */,
	{ DelegatePInvokeWrapper_UnityAction_t3245792599, NULL, NULL, NULL, NULL, NULL, &UnityAction_t3245792599_0_0_0 } /* UnityEngine.Events.UnityAction */,
	{ NULL, FailedToLoadScriptObject_t547604379_marshal_pinvoke, FailedToLoadScriptObject_t547604379_marshal_pinvoke_back, FailedToLoadScriptObject_t547604379_marshal_pinvoke_cleanup, NULL, NULL, &FailedToLoadScriptObject_t547604379_0_0_0 } /* UnityEngine.FailedToLoadScriptObject */,
	{ NULL, Gradient_t3067099924_marshal_pinvoke, Gradient_t3067099924_marshal_pinvoke_back, Gradient_t3067099924_marshal_pinvoke_cleanup, NULL, NULL, &Gradient_t3067099924_0_0_0 } /* UnityEngine.Gradient */,
	{ NULL, Object_t631007953_marshal_pinvoke, Object_t631007953_marshal_pinvoke_back, Object_t631007953_marshal_pinvoke_cleanup, NULL, NULL, &Object_t631007953_0_0_0 } /* UnityEngine.Object */,
	{ NULL, PlayableBinding_t354260709_marshal_pinvoke, PlayableBinding_t354260709_marshal_pinvoke_back, PlayableBinding_t354260709_marshal_pinvoke_cleanup, NULL, NULL, &PlayableBinding_t354260709_0_0_0 } /* UnityEngine.Playables.PlayableBinding */,
	{ NULL, RectOffset_t1369453676_marshal_pinvoke, RectOffset_t1369453676_marshal_pinvoke_back, RectOffset_t1369453676_marshal_pinvoke_cleanup, NULL, NULL, &RectOffset_t1369453676_0_0_0 } /* UnityEngine.RectOffset */,
	{ NULL, ResourceRequest_t3109103591_marshal_pinvoke, ResourceRequest_t3109103591_marshal_pinvoke_back, ResourceRequest_t3109103591_marshal_pinvoke_cleanup, NULL, NULL, &ResourceRequest_t3109103591_0_0_0 } /* UnityEngine.ResourceRequest */,
	{ NULL, ScriptableObject_t2528358522_marshal_pinvoke, ScriptableObject_t2528358522_marshal_pinvoke_back, ScriptableObject_t2528358522_marshal_pinvoke_cleanup, NULL, NULL, &ScriptableObject_t2528358522_0_0_0 } /* UnityEngine.ScriptableObject */,
	{ NULL, HitInfo_t3229609740_marshal_pinvoke, HitInfo_t3229609740_marshal_pinvoke_back, HitInfo_t3229609740_marshal_pinvoke_cleanup, NULL, NULL, &HitInfo_t3229609740_0_0_0 } /* UnityEngine.SendMouseEvents/HitInfo */,
	{ NULL, TrackedReference_t1199777556_marshal_pinvoke, TrackedReference_t1199777556_marshal_pinvoke_back, TrackedReference_t1199777556_marshal_pinvoke_cleanup, NULL, NULL, &TrackedReference_t1199777556_0_0_0 } /* UnityEngine.TrackedReference */,
	{ DelegatePInvokeWrapper_RequestAtlasCallback_t3100554279, NULL, NULL, NULL, NULL, NULL, &RequestAtlasCallback_t3100554279_0_0_0 } /* UnityEngine.U2D.SpriteAtlasManager/RequestAtlasCallback */,
	{ NULL, WorkRequest_t1354518612_marshal_pinvoke, WorkRequest_t1354518612_marshal_pinvoke_back, WorkRequest_t1354518612_marshal_pinvoke_cleanup, NULL, NULL, &WorkRequest_t1354518612_0_0_0 } /* UnityEngine.UnitySynchronizationContext/WorkRequest */,
	{ NULL, WaitForSeconds_t1699091251_marshal_pinvoke, WaitForSeconds_t1699091251_marshal_pinvoke_back, WaitForSeconds_t1699091251_marshal_pinvoke_cleanup, NULL, NULL, &WaitForSeconds_t1699091251_0_0_0 } /* UnityEngine.WaitForSeconds */,
	{ NULL, YieldInstruction_t403091072_marshal_pinvoke, YieldInstruction_t403091072_marshal_pinvoke_back, YieldInstruction_t403091072_marshal_pinvoke_cleanup, NULL, NULL, &YieldInstruction_t403091072_0_0_0 } /* UnityEngine.YieldInstruction */,
	{ DelegatePInvokeWrapper_PCMReaderCallback_t1677636661, NULL, NULL, NULL, NULL, NULL, &PCMReaderCallback_t1677636661_0_0_0 } /* UnityEngine.AudioClip/PCMReaderCallback */,
	{ DelegatePInvokeWrapper_PCMSetPositionCallback_t1059417452, NULL, NULL, NULL, NULL, NULL, &PCMSetPositionCallback_t1059417452_0_0_0 } /* UnityEngine.AudioClip/PCMSetPositionCallback */,
	{ DelegatePInvokeWrapper_AudioConfigurationChangeHandler_t2089929874, NULL, NULL, NULL, NULL, NULL, &AudioConfigurationChangeHandler_t2089929874_0_0_0 } /* UnityEngine.AudioSettings/AudioConfigurationChangeHandler */,
	{ NULL, Collision2D_t2842956331_marshal_pinvoke, Collision2D_t2842956331_marshal_pinvoke_back, Collision2D_t2842956331_marshal_pinvoke_cleanup, NULL, NULL, &Collision2D_t2842956331_0_0_0 } /* UnityEngine.Collision2D */,
	{ NULL, ContactFilter2D_t3805203441_marshal_pinvoke, ContactFilter2D_t3805203441_marshal_pinvoke_back, ContactFilter2D_t3805203441_marshal_pinvoke_cleanup, NULL, NULL, &ContactFilter2D_t3805203441_0_0_0 } /* UnityEngine.ContactFilter2D */,
	{ NULL, RaycastHit2D_t2279581989_marshal_pinvoke, RaycastHit2D_t2279581989_marshal_pinvoke_back, RaycastHit2D_t2279581989_marshal_pinvoke_cleanup, NULL, NULL, &RaycastHit2D_t2279581989_0_0_0 } /* UnityEngine.RaycastHit2D */,
	{ DelegatePInvokeWrapper_FontTextureRebuildCallback_t2467502454, NULL, NULL, NULL, NULL, NULL, &FontTextureRebuildCallback_t2467502454_0_0_0 } /* UnityEngine.Font/FontTextureRebuildCallback */,
	{ NULL, TextGenerationSettings_t1351628751_marshal_pinvoke, TextGenerationSettings_t1351628751_marshal_pinvoke_back, TextGenerationSettings_t1351628751_marshal_pinvoke_cleanup, NULL, NULL, &TextGenerationSettings_t1351628751_0_0_0 } /* UnityEngine.TextGenerationSettings */,
	{ NULL, TextGenerator_t3211863866_marshal_pinvoke, TextGenerator_t3211863866_marshal_pinvoke_back, TextGenerator_t3211863866_marshal_pinvoke_cleanup, NULL, NULL, &TextGenerator_t3211863866_0_0_0 } /* UnityEngine.TextGenerator */,
	{ NULL, DownloadHandler_t2937767557_marshal_pinvoke, DownloadHandler_t2937767557_marshal_pinvoke_back, DownloadHandler_t2937767557_marshal_pinvoke_cleanup, NULL, NULL, &DownloadHandler_t2937767557_0_0_0 } /* UnityEngine.Networking.DownloadHandler */,
	{ NULL, DownloadHandlerBuffer_t2928496527_marshal_pinvoke, DownloadHandlerBuffer_t2928496527_marshal_pinvoke_back, DownloadHandlerBuffer_t2928496527_marshal_pinvoke_cleanup, NULL, NULL, &DownloadHandlerBuffer_t2928496527_0_0_0 } /* UnityEngine.Networking.DownloadHandlerBuffer */,
	{ NULL, UnityWebRequest_t463507806_marshal_pinvoke, UnityWebRequest_t463507806_marshal_pinvoke_back, UnityWebRequest_t463507806_marshal_pinvoke_cleanup, NULL, NULL, &UnityWebRequest_t463507806_0_0_0 } /* UnityEngine.Networking.UnityWebRequest */,
	{ NULL, UnityWebRequestAsyncOperation_t3852015985_marshal_pinvoke, UnityWebRequestAsyncOperation_t3852015985_marshal_pinvoke_back, UnityWebRequestAsyncOperation_t3852015985_marshal_pinvoke_cleanup, NULL, NULL, &UnityWebRequestAsyncOperation_t3852015985_0_0_0 } /* UnityEngine.Networking.UnityWebRequestAsyncOperation */,
	{ NULL, UploadHandler_t2993558019_marshal_pinvoke, UploadHandler_t2993558019_marshal_pinvoke_back, UploadHandler_t2993558019_marshal_pinvoke_cleanup, NULL, NULL, &UploadHandler_t2993558019_0_0_0 } /* UnityEngine.Networking.UploadHandler */,
	{ NULL, UploadHandlerRaw_t25761545_marshal_pinvoke, UploadHandlerRaw_t25761545_marshal_pinvoke_back, UploadHandlerRaw_t25761545_marshal_pinvoke_cleanup, NULL, NULL, &UploadHandlerRaw_t25761545_0_0_0 } /* UnityEngine.Networking.UploadHandlerRaw */,
	{ DelegatePInvokeWrapper_OnNavMeshPreUpdate_t1580782682, NULL, NULL, NULL, NULL, NULL, &OnNavMeshPreUpdate_t1580782682_0_0_0 } /* UnityEngine.AI.NavMesh/OnNavMeshPreUpdate */,
	{ NULL, AnimationEvent_t1536042487_marshal_pinvoke, AnimationEvent_t1536042487_marshal_pinvoke_back, AnimationEvent_t1536042487_marshal_pinvoke_cleanup, NULL, NULL, &AnimationEvent_t1536042487_0_0_0 } /* UnityEngine.AnimationEvent */,
	{ NULL, AnimatorTransitionInfo_t2534804151_marshal_pinvoke, AnimatorTransitionInfo_t2534804151_marshal_pinvoke_back, AnimatorTransitionInfo_t2534804151_marshal_pinvoke_cleanup, NULL, NULL, &AnimatorTransitionInfo_t2534804151_0_0_0 } /* UnityEngine.AnimatorTransitionInfo */,
	{ NULL, HumanBone_t2465339518_marshal_pinvoke, HumanBone_t2465339518_marshal_pinvoke_back, HumanBone_t2465339518_marshal_pinvoke_cleanup, NULL, NULL, &HumanBone_t2465339518_0_0_0 } /* UnityEngine.HumanBone */,
	{ NULL, SkeletonBone_t4134054672_marshal_pinvoke, SkeletonBone_t4134054672_marshal_pinvoke_back, SkeletonBone_t4134054672_marshal_pinvoke_cleanup, NULL, NULL, &SkeletonBone_t4134054672_0_0_0 } /* UnityEngine.SkeletonBone */,
	{ NULL, Event_t2956885303_marshal_pinvoke, Event_t2956885303_marshal_pinvoke_back, Event_t2956885303_marshal_pinvoke_cleanup, NULL, NULL, &Event_t2956885303_0_0_0 } /* UnityEngine.Event */,
	{ DelegatePInvokeWrapper_WindowFunction_t3146511083, NULL, NULL, NULL, NULL, NULL, &WindowFunction_t3146511083_0_0_0 } /* UnityEngine.GUI/WindowFunction */,
	{ NULL, GUIContent_t3050628031_marshal_pinvoke, GUIContent_t3050628031_marshal_pinvoke_back, GUIContent_t3050628031_marshal_pinvoke_cleanup, NULL, NULL, &GUIContent_t3050628031_0_0_0 } /* UnityEngine.GUIContent */,
	{ DelegatePInvokeWrapper_SkinChangedDelegate_t1143955295, NULL, NULL, NULL, NULL, NULL, &SkinChangedDelegate_t1143955295_0_0_0 } /* UnityEngine.GUISkin/SkinChangedDelegate */,
	{ NULL, GUIStyle_t3956901511_marshal_pinvoke, GUIStyle_t3956901511_marshal_pinvoke_back, GUIStyle_t3956901511_marshal_pinvoke_cleanup, NULL, NULL, &GUIStyle_t3956901511_0_0_0 } /* UnityEngine.GUIStyle */,
	{ NULL, GUIStyleState_t1397964415_marshal_pinvoke, GUIStyleState_t1397964415_marshal_pinvoke_back, GUIStyleState_t1397964415_marshal_pinvoke_cleanup, NULL, NULL, &GUIStyleState_t1397964415_0_0_0 } /* UnityEngine.GUIStyleState */,
	{ NULL, SliderHandler_t1154919399_marshal_pinvoke, SliderHandler_t1154919399_marshal_pinvoke_back, SliderHandler_t1154919399_marshal_pinvoke_cleanup, NULL, NULL, &SliderHandler_t1154919399_0_0_0 } /* UnityEngine.SliderHandler */,
	{ DelegatePInvokeWrapper_NativeDeviceDiscoveredCallback_t3494240628, NULL, NULL, NULL, NULL, NULL, &NativeDeviceDiscoveredCallback_t3494240628_0_0_0 } /* UnityEngineInternal.Input.NativeDeviceDiscoveredCallback */,
	{ DelegatePInvokeWrapper_NativeEventCallback_t83445637, NULL, NULL, NULL, NULL, NULL, &NativeEventCallback_t83445637_0_0_0 } /* UnityEngineInternal.Input.NativeEventCallback */,
	{ NULL, NativeInputDeviceInfo_t3032009285_marshal_pinvoke, NativeInputDeviceInfo_t3032009285_marshal_pinvoke_back, NativeInputDeviceInfo_t3032009285_marshal_pinvoke_cleanup, NULL, NULL, &NativeInputDeviceInfo_t3032009285_0_0_0 } /* UnityEngineInternal.Input.NativeInputDeviceInfo */,
	{ DelegatePInvokeWrapper_NativeUpdateCallback_t2379345390, NULL, NULL, NULL, NULL, NULL, &NativeUpdateCallback_t2379345390_0_0_0 } /* UnityEngineInternal.Input.NativeUpdateCallback */,
	{ NULL, EmissionModule_t311448003_marshal_pinvoke, EmissionModule_t311448003_marshal_pinvoke_back, EmissionModule_t311448003_marshal_pinvoke_cleanup, NULL, NULL, &EmissionModule_t311448003_0_0_0 } /* UnityEngine.ParticleSystem/EmissionModule */,
	{ NULL, Collision_t4262080450_marshal_pinvoke, Collision_t4262080450_marshal_pinvoke_back, Collision_t4262080450_marshal_pinvoke_cleanup, NULL, NULL, &Collision_t4262080450_0_0_0 } /* UnityEngine.Collision */,
	{ NULL, ControllerColliderHit_t240592346_marshal_pinvoke, ControllerColliderHit_t240592346_marshal_pinvoke_back, ControllerColliderHit_t240592346_marshal_pinvoke_cleanup, NULL, NULL, &ControllerColliderHit_t240592346_0_0_0 } /* UnityEngine.ControllerColliderHit */,
	{ NULL, RaycastHit_t1056001966_marshal_pinvoke, RaycastHit_t1056001966_marshal_pinvoke_back, RaycastHit_t1056001966_marshal_pinvoke_cleanup, NULL, NULL, &RaycastHit_t1056001966_0_0_0 } /* UnityEngine.RaycastHit */,
	{ NULL, TileAnimationData_t649120048_marshal_pinvoke, TileAnimationData_t649120048_marshal_pinvoke_back, TileAnimationData_t649120048_marshal_pinvoke_cleanup, NULL, NULL, &TileAnimationData_t649120048_0_0_0 } /* UnityEngine.Tilemaps.TileAnimationData */,
	{ NULL, TileData_t2042394239_marshal_pinvoke, TileData_t2042394239_marshal_pinvoke_back, TileData_t2042394239_marshal_pinvoke_cleanup, NULL, NULL, &TileData_t2042394239_0_0_0 } /* UnityEngine.Tilemaps.TileData */,
	{ DelegatePInvokeWrapper_WillRenderCanvases_t3309123499, NULL, NULL, NULL, NULL, NULL, &WillRenderCanvases_t3309123499_0_0_0 } /* UnityEngine.Canvas/WillRenderCanvases */,
	{ NULL, TagName_t2891256255_marshal_pinvoke, TagName_t2891256255_marshal_pinvoke_back, TagName_t2891256255_marshal_pinvoke_cleanup, NULL, NULL, &TagName_t2891256255_0_0_0 } /* Mono.Xml2.XmlTextReader/TagName */,
	{ NULL, QNameValueType_t615604793_marshal_pinvoke, QNameValueType_t615604793_marshal_pinvoke_back, QNameValueType_t615604793_marshal_pinvoke_cleanup, NULL, NULL, &QNameValueType_t615604793_0_0_0 } /* System.Xml.Schema.QNameValueType */,
	{ NULL, StringArrayValueType_t3147326440_marshal_pinvoke, StringArrayValueType_t3147326440_marshal_pinvoke_back, StringArrayValueType_t3147326440_marshal_pinvoke_cleanup, NULL, NULL, &StringArrayValueType_t3147326440_0_0_0 } /* System.Xml.Schema.StringArrayValueType */,
	{ NULL, StringValueType_t261329552_marshal_pinvoke, StringValueType_t261329552_marshal_pinvoke_back, StringValueType_t261329552_marshal_pinvoke_cleanup, NULL, NULL, &StringValueType_t261329552_0_0_0 } /* System.Xml.Schema.StringValueType */,
	{ NULL, UriValueType_t2866347695_marshal_pinvoke, UriValueType_t2866347695_marshal_pinvoke_back, UriValueType_t2866347695_marshal_pinvoke_cleanup, NULL, NULL, &UriValueType_t2866347695_0_0_0 } /* System.Xml.Schema.UriValueType */,
	{ NULL, NsDecl_t3938094415_marshal_pinvoke, NsDecl_t3938094415_marshal_pinvoke_back, NsDecl_t3938094415_marshal_pinvoke_cleanup, NULL, NULL, &NsDecl_t3938094415_0_0_0 } /* System.Xml.XmlNamespaceManager/NsDecl */,
	{ NULL, NsScope_t3958624705_marshal_pinvoke, NsScope_t3958624705_marshal_pinvoke_back, NsScope_t3958624705_marshal_pinvoke_cleanup, NULL, NULL, &NsScope_t3958624705_0_0_0 } /* System.Xml.XmlNamespaceManager/NsScope */,
	{ DelegatePInvokeWrapper_CharGetter_t1703763694, NULL, NULL, NULL, NULL, NULL, &CharGetter_t1703763694_0_0_0 } /* System.Xml.XmlReaderBinarySupport/CharGetter */,
	{ NULL, RaycastResult_t3360306849_marshal_pinvoke, RaycastResult_t3360306849_marshal_pinvoke_back, RaycastResult_t3360306849_marshal_pinvoke_cleanup, NULL, NULL, &RaycastResult_t3360306849_0_0_0 } /* UnityEngine.EventSystems.RaycastResult */,
	{ NULL, ColorTween_t809614380_marshal_pinvoke, ColorTween_t809614380_marshal_pinvoke_back, ColorTween_t809614380_marshal_pinvoke_cleanup, NULL, NULL, &ColorTween_t809614380_0_0_0 } /* UnityEngine.UI.CoroutineTween.ColorTween */,
	{ NULL, FloatTween_t1274330004_marshal_pinvoke, FloatTween_t1274330004_marshal_pinvoke_back, FloatTween_t1274330004_marshal_pinvoke_cleanup, NULL, NULL, &FloatTween_t1274330004_0_0_0 } /* UnityEngine.UI.CoroutineTween.FloatTween */,
	{ NULL, Resources_t1597885468_marshal_pinvoke, Resources_t1597885468_marshal_pinvoke_back, Resources_t1597885468_marshal_pinvoke_cleanup, NULL, NULL, &Resources_t1597885468_0_0_0 } /* UnityEngine.UI.DefaultControls/Resources */,
	{ DelegatePInvokeWrapper_OnValidateInput_t2355412304, NULL, NULL, NULL, NULL, NULL, &OnValidateInput_t2355412304_0_0_0 } /* UnityEngine.UI.InputField/OnValidateInput */,
	{ NULL, Navigation_t3049316579_marshal_pinvoke, Navigation_t3049316579_marshal_pinvoke_back, Navigation_t3049316579_marshal_pinvoke_cleanup, NULL, NULL, &Navigation_t3049316579_0_0_0 } /* UnityEngine.UI.Navigation */,
	{ NULL, SpriteState_t1362986479_marshal_pinvoke, SpriteState_t1362986479_marshal_pinvoke_back, SpriteState_t1362986479_marshal_pinvoke_cleanup, NULL, NULL, &SpriteState_t1362986479_0_0_0 } /* UnityEngine.UI.SpriteState */,
	{ NULL, QueuedDebugLogEntry_t2072794530_marshal_pinvoke, QueuedDebugLogEntry_t2072794530_marshal_pinvoke_back, QueuedDebugLogEntry_t2072794530_marshal_pinvoke_cleanup, NULL, NULL, &QueuedDebugLogEntry_t2072794530_0_0_0 } /* IngameDebugConsole.QueuedDebugLogEntry */,
	{ NULL, AchievementDataHolder_t290853885_marshal_pinvoke, AchievementDataHolder_t290853885_marshal_pinvoke_back, AchievementDataHolder_t290853885_marshal_pinvoke_cleanup, NULL, NULL, &AchievementDataHolder_t290853885_0_0_0 } /* AchievementData/AchievementDataHolder */,
	{ DelegatePInvokeWrapper_OnAudioMuted_t2328156291, NULL, NULL, NULL, NULL, NULL, &OnAudioMuted_t2328156291_0_0_0 } /* AudioManager/OnAudioMuted */,
	{ NULL, BackgroundData_t3682119881_marshal_pinvoke, BackgroundData_t3682119881_marshal_pinvoke_back, BackgroundData_t3682119881_marshal_pinvoke_cleanup, NULL, NULL, &BackgroundData_t3682119881_0_0_0 } /* BackgroundMask/BackgroundData */,
	{ NULL, BirdWakeUpEvent_t4025743789_marshal_pinvoke, BirdWakeUpEvent_t4025743789_marshal_pinvoke_back, BirdWakeUpEvent_t4025743789_marshal_pinvoke_cleanup, NULL, NULL, &BirdWakeUpEvent_t4025743789_0_0_0 } /* BirdWakeUpEvent */,
	{ DelegatePInvokeWrapper_InputDelegate_t60576951, NULL, NULL, NULL, NULL, NULL, &InputDelegate_t60576951_0_0_0 } /* Button/InputDelegate */,
	{ NULL, CakeRaceInfo_t990596595_marshal_pinvoke, CakeRaceInfo_t990596595_marshal_pinvoke_back, CakeRaceInfo_t990596595_marshal_pinvoke_cleanup, NULL, NULL, &CakeRaceInfo_t990596595_0_0_0 } /* CakeRace.CakeRaceInfo */,
	{ NULL, ObjectLocation_t2396930893_marshal_pinvoke, ObjectLocation_t2396930893_marshal_pinvoke_back, ObjectLocation_t2396930893_marshal_pinvoke_cleanup, NULL, NULL, &ObjectLocation_t2396930893_0_0_0 } /* CakeRace.ObjectLocation */,
	{ NULL, StartInfo_t2919652100_marshal_pinvoke, StartInfo_t2919652100_marshal_pinvoke_back, StartInfo_t2919652100_marshal_pinvoke_cleanup, NULL, NULL, &StartInfo_t2919652100_0_0_0 } /* CakeRace.StartInfo */,
	{ NULL, TimerModePair_t2879060035_marshal_pinvoke, TimerModePair_t2879060035_marshal_pinvoke_back, TimerModePair_t2879060035_marshal_pinvoke_cleanup, NULL, NULL, &TimerModePair_t2879060035_0_0_0 } /* CakeRaceHUD/TimerModePair */,
	{ NULL, ConnectedComponent_t2516682977_marshal_pinvoke, ConnectedComponent_t2516682977_marshal_pinvoke_back, ConnectedComponent_t2516682977_marshal_pinvoke_cleanup, NULL, NULL, &ConnectedComponent_t2516682977_0_0_0 } /* Contraption/ConnectedComponent */,
	{ NULL, JointConnection_t3688484570_marshal_pinvoke, JointConnection_t3688484570_marshal_pinvoke_back, JointConnection_t3688484570_marshal_pinvoke_cleanup, NULL, NULL, &JointConnection_t3688484570_0_0_0 } /* Contraption/JointConnection */,
	{ NULL, ChallengeConfigs_t2059436732_marshal_pinvoke, ChallengeConfigs_t2059436732_marshal_pinvoke_back, ChallengeConfigs_t2059436732_marshal_pinvoke_cleanup, NULL, NULL, &ChallengeConfigs_t2059436732_0_0_0 } /* DailyChallenge/ChallengeConfigs */,
	{ NULL, ChallengeInfo_t2275744116_marshal_pinvoke, ChallengeInfo_t2275744116_marshal_pinvoke_back, ChallengeInfo_t2275744116_marshal_pinvoke_cleanup, NULL, NULL, &ChallengeInfo_t2275744116_0_0_0 } /* DailyChallenge/ChallengeInfo */,
	{ NULL, DessertCollectedEvent_t4241761954_marshal_pinvoke, DessertCollectedEvent_t4241761954_marshal_pinvoke_back, DessertCollectedEvent_t4241761954_marshal_pinvoke_cleanup, NULL, NULL, &DessertCollectedEvent_t4241761954_0_0_0 } /* Dessert/DessertCollectedEvent */,
	{ DelegatePInvokeWrapper_OnClose_t3291647407, NULL, NULL, NULL, NULL, NULL, &OnClose_t3291647407_0_0_0 } /* Dialog/OnClose */,
	{ DelegatePInvokeWrapper_OnOpen_t2905586510, NULL, NULL, NULL, NULL, NULL, &OnOpen_t2905586510_0_0_0 } /* Dialog/OnOpen */,
	{ DelegatePInvokeWrapper_ExternalAppMessageReceived_t1638583432, NULL, NULL, NULL, NULL, NULL, &ExternalAppMessageReceived_t1638583432_0_0_0 } /* ExternalMessageManager/ExternalAppMessageReceived */,
	{ NULL, AchievementDataStruct_t1666718540_marshal_pinvoke, AchievementDataStruct_t1666718540_marshal_pinvoke_back, AchievementDataStruct_t1666718540_marshal_pinvoke_cleanup, NULL, NULL, &AchievementDataStruct_t1666718540_0_0_0 } /* GameCenterManager/AchievementDataStruct */,
	{ NULL, AchievementQueueBlock_t1460733219_marshal_pinvoke, AchievementQueueBlock_t1460733219_marshal_pinvoke_back, AchievementQueueBlock_t1460733219_marshal_pinvoke_cleanup, NULL, NULL, &AchievementQueueBlock_t1460733219_0_0_0 } /* GameCenterManager/AchievementQueueBlock */,
	{ NULL, LeaderboardDataStruct_t2092881696_marshal_pinvoke, LeaderboardDataStruct_t2092881696_marshal_pinvoke_back, LeaderboardDataStruct_t2092881696_marshal_pinvoke_cleanup, NULL, NULL, &LeaderboardDataStruct_t2092881696_0_0_0 } /* GameCenterManager/LeaderboardDataStruct */,
	{ NULL, GameTimePaused_t1121804034_marshal_pinvoke, GameTimePaused_t1121804034_marshal_pinvoke_back, GameTimePaused_t1121804034_marshal_pinvoke_cleanup, NULL, NULL, &GameTimePaused_t1121804034_0_0_0 } /* GameTimePaused */,
	{ DelegatePInvokeWrapper_PurchaseFailed_t1639931944, NULL, NULL, NULL, NULL, NULL, &PurchaseFailed_t1639931944_0_0_0 } /* IapManager/PurchaseFailed */,
	{ DelegatePInvokeWrapper_PurchaseSucceeded_t2204089269, NULL, NULL, NULL, NULL, NULL, &PurchaseSucceeded_t2204089269_0_0_0 } /* IapManager/PurchaseSucceeded */,
	{ DelegatePInvokeWrapper_RestorePurchaseComplete_t3798189757, NULL, NULL, NULL, NULL, NULL, &RestorePurchaseComplete_t3798189757_0_0_0 } /* IapManager/RestorePurchaseComplete */,
	{ NULL, ApplyNightVisionEvent_t3252991219_marshal_pinvoke, ApplyNightVisionEvent_t3252991219_marshal_pinvoke_back, ApplyNightVisionEvent_t3252991219_marshal_pinvoke_cleanup, NULL, NULL, &ApplyNightVisionEvent_t3252991219_0_0_0 } /* InGameBuildMenu/ApplyNightVisionEvent */,
	{ NULL, ApplySuperGlueEvent_t66780888_marshal_pinvoke, ApplySuperGlueEvent_t66780888_marshal_pinvoke_back, ApplySuperGlueEvent_t66780888_marshal_pinvoke_cleanup, NULL, NULL, &ApplySuperGlueEvent_t66780888_0_0_0 } /* InGameBuildMenu/ApplySuperGlueEvent */,
	{ NULL, ApplySuperMagnetEvent_t2211318601_marshal_pinvoke, ApplySuperMagnetEvent_t2211318601_marshal_pinvoke_back, ApplySuperMagnetEvent_t2211318601_marshal_pinvoke_cleanup, NULL, NULL, &ApplySuperMagnetEvent_t2211318601_0_0_0 } /* InGameBuildMenu/ApplySuperMagnetEvent */,
	{ NULL, ApplyTurboChargeEvent_t2820362279_marshal_pinvoke, ApplyTurboChargeEvent_t2820362279_marshal_pinvoke_back, ApplyTurboChargeEvent_t2820362279_marshal_pinvoke_cleanup, NULL, NULL, &ApplyTurboChargeEvent_t2820362279_0_0_0 } /* InGameBuildMenu/ApplyTurboChargeEvent */,
	{ NULL, AutoBuildEvent_t2414972399_marshal_pinvoke, AutoBuildEvent_t2414972399_marshal_pinvoke_back, AutoBuildEvent_t2414972399_marshal_pinvoke_cleanup, NULL, NULL, &AutoBuildEvent_t2414972399_0_0_0 } /* InGameBuildMenu/AutoBuildEvent */,
	{ DelegatePInvokeWrapper_OnClose_t3070614049, NULL, NULL, NULL, NULL, NULL, &OnClose_t3070614049_0_0_0 } /* InGameInAppPurchaseMenu/OnClose */,
	{ DelegatePInvokeWrapper_CompressFunc_t3594827279, NULL, NULL, NULL, NULL, NULL, &CompressFunc_t3594827279_0_0_0 } /* Ionic.Zlib.DeflateManager/CompressFunc */,
	{ NULL, DessertPlacePair_t1365446491_marshal_pinvoke, DessertPlacePair_t1365446491_marshal_pinvoke_back, DessertPlacePair_t1365446491_marshal_pinvoke_cleanup, NULL, NULL, &DessertPlacePair_t1365446491_0_0_0 } /* LevelManager/DessertPlacePair */,
	{ NULL, LoadLevelEvent_t1076517439_marshal_pinvoke, LoadLevelEvent_t1076517439_marshal_pinvoke_back, LoadLevelEvent_t1076517439_marshal_pinvoke_cleanup, NULL, NULL, &LoadLevelEvent_t1076517439_0_0_0 } /* LoadLevelEvent */,
	{ NULL, LocalizationReloaded_t1062245660_marshal_pinvoke, LocalizationReloaded_t1062245660_marshal_pinvoke_back, LocalizationReloaded_t1062245660_marshal_pinvoke_cleanup, NULL, NULL, &LocalizationReloaded_t1062245660_0_0_0 } /* LocalizationReloaded */,
	{ NULL, AnalyticData_t3667669175_marshal_pinvoke, AnalyticData_t3667669175_marshal_pinvoke_back, AnalyticData_t3667669175_marshal_pinvoke_cleanup, NULL, NULL, &AnalyticData_t3667669175_0_0_0 } /* LootCrate/AnalyticData */,
	{ NULL, LootWheelReward_t1830224244_marshal_pinvoke, LootWheelReward_t1830224244_marshal_pinvoke_back, LootWheelReward_t1830224244_marshal_pinvoke_cleanup, NULL, NULL, &LootWheelReward_t1830224244_0_0_0 } /* LootWheelRewards/LootWheelReward */,
	{ NULL, MeshObject_t85759963_marshal_pinvoke, MeshObject_t85759963_marshal_pinvoke_back, MeshObject_t85759963_marshal_pinvoke_cleanup, NULL, NULL, &MeshObject_t85759963_0_0_0 } /* MentalTools.MeshTool/MeshObject */,
	{ DelegatePInvokeWrapper_OnCheckResponseDelegate_t1854801344, NULL, NULL, NULL, NULL, NULL, &OnCheckResponseDelegate_t1854801344_0_0_0 } /* NetworkManager/OnCheckResponseDelegate */,
	{ DelegatePInvokeWrapper_OnNetworkChangedDelegate_t2214548974, NULL, NULL, NULL, NULL, NULL, &OnNetworkChangedDelegate_t2214548974_0_0_0 } /* NetworkManager/OnNetworkChangedDelegate */,
	{ DelegatePInvokeWrapper_OnInitializeHandler_t608088752, NULL, NULL, NULL, NULL, NULL, &OnInitializeHandler_t608088752_0_0_0 } /* OnInitializeHandler */,
	{ DelegatePInvokeWrapper_OnTimedOut_t1431860576, NULL, NULL, NULL, NULL, NULL, &OnTimedOut_t1431860576_0_0_0 } /* OnTimedOut */,
	{ DelegatePInvokeWrapper_OnTimerHandler_t3671552975, NULL, NULL, NULL, NULL, NULL, &OnTimerHandler_t3671552975_0_0_0 } /* OnTimerHandler */,
	{ DelegatePInvokeWrapper_PageChanged_t3614939429, NULL, NULL, NULL, NULL, NULL, &PageChanged_t3614939429_0_0_0 } /* PageScroller/PageChanged */,
	{ NULL, ParallaxCustomLayer_t3964718142_marshal_pinvoke, ParallaxCustomLayer_t3964718142_marshal_pinvoke_back, ParallaxCustomLayer_t3964718142_marshal_pinvoke_cleanup, NULL, NULL, &ParallaxCustomLayer_t3964718142_0_0_0 } /* ParallaxManager/ParallaxCustomLayer */,
	{ DelegatePInvokeWrapper_Collected_t634675809, NULL, NULL, NULL, NULL, NULL, &Collected_t634675809_0_0_0 } /* PartBox/Collected */,
	{ NULL, PulseButtonEvent_t3712592501_marshal_pinvoke, PulseButtonEvent_t3712592501_marshal_pinvoke_back, PulseButtonEvent_t3712592501_marshal_pinvoke_cleanup, NULL, NULL, &PulseButtonEvent_t3712592501_0_0_0 } /* PulseButtonEvent */,
	{ NULL, Node_t1829454632_marshal_pinvoke, Node_t1829454632_marshal_pinvoke_back, Node_t1829454632_marshal_pinvoke_cleanup, NULL, NULL, &Node_t1829454632_0_0_0 } /* Rope/Node */,
	{ DelegatePInvokeWrapper_OnPress_t1412303708, NULL, NULL, NULL, NULL, NULL, &OnPress_t1412303708_0_0_0 } /* RotationTutorial/Pointer/OnPress */,
	{ NULL, AnimationPair_t1784808777_marshal_pinvoke, AnimationPair_t1784808777_marshal_pinvoke_back, AnimationPair_t1784808777_marshal_pinvoke_cleanup, NULL, NULL, &AnimationPair_t1784808777_0_0_0 } /* Spine.AnimationStateData/AnimationPair */,
	{ NULL, AttachmentKeyTuple_t1548106539_marshal_pinvoke, AttachmentKeyTuple_t1548106539_marshal_pinvoke_back, AttachmentKeyTuple_t1548106539_marshal_pinvoke_cleanup, NULL, NULL, &AttachmentKeyTuple_t1548106539_0_0_0 } /* Spine.Skin/AttachmentKeyTuple */,
	{ NULL, MeshAndMaterials_t908474435_marshal_pinvoke, MeshAndMaterials_t908474435_marshal_pinvoke_back, MeshAndMaterials_t908474435_marshal_pinvoke_cleanup, NULL, NULL, &MeshAndMaterials_t908474435_0_0_0 } /* Spine.Unity.MeshGeneration.MeshAndMaterials */,
	{ NULL, SubmeshInstruction_t414082835_marshal_pinvoke, SubmeshInstruction_t414082835_marshal_pinvoke_back, SubmeshInstruction_t414082835_marshal_pinvoke_cleanup, NULL, NULL, &SubmeshInstruction_t414082835_0_0_0 } /* Spine.Unity.MeshGeneration.SubmeshInstruction */,
	{ NULL, AtlasMaterialOverride_t2435041389_marshal_pinvoke, AtlasMaterialOverride_t2435041389_marshal_pinvoke_back, AtlasMaterialOverride_t2435041389_marshal_pinvoke_cleanup, NULL, NULL, &AtlasMaterialOverride_t2435041389_0_0_0 } /* Spine.Unity.Modules.SkeletonRendererCustomMaterials/AtlasMaterialOverride */,
	{ NULL, SlotMaterialOverride_t1001979181_marshal_pinvoke, SlotMaterialOverride_t1001979181_marshal_pinvoke_back, SlotMaterialOverride_t1001979181_marshal_pinvoke_cleanup, NULL, NULL, &SlotMaterialOverride_t1001979181_0_0_0 } /* Spine.Unity.Modules.SkeletonRendererCustomMaterials/SlotMaterialOverride */,
	{ NULL, TransformPair_t3795417756_marshal_pinvoke, TransformPair_t3795417756_marshal_pinvoke_back, TransformPair_t3795417756_marshal_pinvoke_cleanup, NULL, NULL, &TransformPair_t3795417756_0_0_0 } /* Spine.Unity.Modules.SkeletonUtilityKinematicShadow/TransformPair */,
	{ DelegatePInvokeWrapper_SkeletonUtilityDelegate_t487527757, NULL, NULL, NULL, NULL, NULL, &SkeletonUtilityDelegate_t487527757_0_0_0 } /* Spine.Unity.SkeletonUtility/SkeletonUtilityDelegate */,
	{ NULL, Hierarchy_t2161623951_marshal_pinvoke, Hierarchy_t2161623951_marshal_pinvoke_back, Hierarchy_t2161623951_marshal_pinvoke_cleanup, NULL, NULL, &Hierarchy_t2161623951_0_0_0 } /* Spine.Unity.SpineAttachment/Hierarchy */,
	{ DelegatePInvokeWrapper_OnPlay_t1571682685, NULL, NULL, NULL, NULL, NULL, &OnPlay_t1571682685_0_0_0 } /* SpriteAnimation/OnPlay */,
	{ DelegatePInvokeWrapper_Collected_t732746415, NULL, NULL, NULL, NULL, NULL, &Collected_t732746415_0_0_0 } /* StarBox/Collected */,
	{ DelegatePInvokeWrapper_OnClose_t772094743, NULL, NULL, NULL, NULL, NULL, &OnClose_t772094743_0_0_0 } /* TextDialog/OnClose */,
	{ DelegatePInvokeWrapper_OnConfirm_t1805170460, NULL, NULL, NULL, NULL, NULL, &OnConfirm_t1805170460_0_0_0 } /* TextDialog/OnConfirm */,
	{ DelegatePInvokeWrapper_OnOpen_t1527099976, NULL, NULL, NULL, NULL, NULL, &OnOpen_t1527099976_0_0_0 } /* TextDialog/OnOpen */,
	{ NULL, TextKeyPair_t1148982378_marshal_pinvoke, TextKeyPair_t1148982378_marshal_pinvoke_back, TextKeyPair_t1148982378_marshal_pinvoke_cleanup, NULL, NULL, &TextKeyPair_t1148982378_0_0_0 } /* TextDialog/TextKeyPair */,
	{ DelegatePInvokeWrapper_OnPress_t3738947737, NULL, NULL, NULL, NULL, NULL, &OnPress_t3738947737_0_0_0 } /* Tutorial/Pointer/OnPress */,
	{ DelegatePInvokeWrapper_OnPayPressed_t3240706507, NULL, NULL, NULL, NULL, NULL, &OnPayPressed_t3240706507_0_0_0 } /* UnlockLevelRowPanel/OnPayPressed */,
	{ DelegatePInvokeWrapper_OnWatchAdPressed_t561592073, NULL, NULL, NULL, NULL, NULL, &OnWatchAdPressed_t561592073_0_0_0 } /* UnlockLevelRowPanel/OnWatchAdPressed */,
	{ NULL, ConditionStruct_t3952177795_marshal_pinvoke, ConditionStruct_t3952177795_marshal_pinvoke_back, ConditionStruct_t3952177795_marshal_pinvoke_cleanup, NULL, NULL, &ConditionStruct_t3952177795_0_0_0 } /* VisibilityCondition/ConditionStruct */,
	{ DelegatePInvokeWrapper_ConditionChange_t1091918374, NULL, NULL, NULL, NULL, NULL, &ConditionChange_t1091918374_0_0_0 } /* VisibilityConditionManager/ConditionChange */,
	{ DelegatePInvokeWrapper_ConditionCheck_t690039966, NULL, NULL, NULL, NULL, NULL, &ConditionCheck_t690039966_0_0_0 } /* VisibilityConditionManager/ConditionCheck */,
	{ NULL, NULL, NULL, NULL, NULL, &CRC32_t2128839853::CLSID, &CRC32_t2128839853_0_0_0 } /* Ionic.Crc.CRC32 */,
	{ NULL, NULL, NULL, NULL, NULL, &ZlibCodec_t3653667923::CLSID, &ZlibCodec_t3653667923_0_0_0 } /* Ionic.Zlib.ZlibCodec */,
	{ NULL, NULL, NULL, NULL, NULL, &ZlibException_t2135990123::CLSID, &ZlibException_t2135990123_0_0_0 } /* Ionic.Zlib.ZlibException */,
	NULL,
};
