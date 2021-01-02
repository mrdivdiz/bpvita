using System;
using System.Globalization;
using System.IO;
using System.Text;
using PlayFab.Json;

namespace PlayFab.Internal
{
	internal static class PlayFabUtil
	{
		[Obsolete("This field has moved to SimpleJsonInstance.ApiSerializerStrategy", false)]
		public static SimpleJsonInstance.PlayFabSimpleJsonCuztomization ApiSerializerStrategy
		{
			get
			{
				return SimpleJsonInstance.ApiSerializerStrategy;
			}
		}

		public static string timeStamp
		{
			get
			{
				return DateTime.Now.ToString(PlayFabUtil._defaultDateTimeFormats[9]);
			}
		}

		public static string utcTimeStamp
		{
			get
			{
				return DateTime.UtcNow.ToString(PlayFabUtil._defaultDateTimeFormats[2]);
			}
		}

		public static string Format(string text, params object[] args)
		{
			return (args.Length <= 0) ? text : string.Format(text, args);
		}

		public static string ReadAllFileText(string filename)
		{
			if (PlayFabUtil._sb == null)
			{
				PlayFabUtil._sb = new StringBuilder();
			}
			PlayFabUtil._sb.Length = 0;
			FileStream input = new FileStream(filename, FileMode.Open);
			BinaryReader binaryReader = new BinaryReader(input);
			while (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
			{
				PlayFabUtil._sb.Append(binaryReader.ReadChar());
			}
			return PlayFabUtil._sb.ToString();
		}

		public static readonly string[] _defaultDateTimeFormats = new string[]
		{
			"yyyy-MM-ddTHH:mm:ss.FFFFFFZ",
			"yyyy-MM-ddTHH:mm:ss.FFFFZ",
			"yyyy-MM-ddTHH:mm:ss.FFFZ",
			"yyyy-MM-ddTHH:mm:ss.FFZ",
			"yyyy-MM-ddTHH:mm:ssZ",
			"yyyy-MM-dd HH:mm:ssZ",
			"yyyy-MM-dd HH:mm:ss.FFFFFF",
			"yyyy-MM-dd HH:mm:ss.FFFF",
			"yyyy-MM-dd HH:mm:ss.FFF",
			"yyyy-MM-dd HH:mm:ss.FF",
			"yyyy-MM-dd HH:mm:ss",
			"yyyy-MM-dd HH:mm.ss.FFFF",
			"yyyy-MM-dd HH:mm.ss.FFF",
			"yyyy-MM-dd HH:mm.ss.FF",
			"yyyy-MM-dd HH:mm.ss"
		};

		public const int DEFAULT_UTC_OUTPUT_INDEX = 2;

		public const int DEFAULT_LOCAL_OUTPUT_INDEX = 9;

		public static DateTimeStyles DateTimeStyles = DateTimeStyles.RoundtripKind;

		[ThreadStatic]
		private static StringBuilder _sb;
	}
}
