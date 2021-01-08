using System;

namespace PlayFab.PlayStreamModels
{
	[Serializable]
	public class LogStatement
	{
		public object Data;

		public string Level;

		public string Message;
	}
}
