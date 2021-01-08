using System;
using System.Collections.Generic;
using System.Text;

namespace PlayFab
{
	public class PlayFabError
	{
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (this.ErrorDetails != null)
			{
				foreach (KeyValuePair<string, List<string>> keyValuePair in this.ErrorDetails)
				{
					stringBuilder.Append(keyValuePair.Key);
					stringBuilder.Append(": ");
					stringBuilder.Append(string.Join(", ", keyValuePair.Value.ToArray()));
					stringBuilder.Append(" | ");
				}
			}
			return string.Format("{0} PlayFabError({1}, {2}, {3} {4}", new object[]
			{
				this.ApiEndpoint,
				this.Error,
				this.ErrorMessage,
				this.HttpCode,
				this.HttpStatus
			}) + ((stringBuilder.Length <= 0) ? ")" : (" - Details: " + stringBuilder.ToString() + ")"));
		}

		public string GenerateErrorReport()
		{
			if (PlayFabError._tempSb == null)
			{
				PlayFabError._tempSb = new StringBuilder();
			}
			PlayFabError._tempSb.Length = 0;
			PlayFabError._tempSb.Append(this.ApiEndpoint).Append(": ").Append(this.ErrorMessage);
			if (this.ErrorDetails != null)
			{
				foreach (KeyValuePair<string, List<string>> keyValuePair in this.ErrorDetails)
				{
					foreach (string value in keyValuePair.Value)
					{
						PlayFabError._tempSb.Append("\n").Append(keyValuePair.Key).Append(": ").Append(value);
					}
				}
			}
			return PlayFabError._tempSb.ToString();
		}

		public string ApiEndpoint;

		public int HttpCode;

		public string HttpStatus;

		public PlayFabErrorCode Error;

		public string ErrorMessage;

		public Dictionary<string, List<string>> ErrorDetails;

		public object CustomData;

		[ThreadStatic]
		private static StringBuilder _tempSb;
	}
}
