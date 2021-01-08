using System;

namespace PlayFab
{
	[Flags]
	public enum PlayFabLogLevel
	{
		None = 0,
		Debug = 1,
		Info = 2,
		Warning = 4,
		Error = 8,
		All = 15
	}
}
