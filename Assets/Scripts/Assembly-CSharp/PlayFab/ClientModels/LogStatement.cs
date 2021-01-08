using System;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class LogStatement
	{
		public object Data;

		public string Level;

		public string Message;
	}
}
