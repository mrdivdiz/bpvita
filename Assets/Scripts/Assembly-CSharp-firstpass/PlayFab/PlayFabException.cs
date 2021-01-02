using System;

namespace PlayFab
{
	public class PlayFabException : Exception
	{
		public PlayFabException(PlayFabExceptionCode code, string message) : base(message)
		{
			this.Code = code;
		}

		public readonly PlayFabExceptionCode Code;
	}
}
