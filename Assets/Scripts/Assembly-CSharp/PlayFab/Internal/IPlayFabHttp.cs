using System;

namespace PlayFab.Internal
{
	public interface IPlayFabHttp
	{
		bool SessionStarted { get; set; }

		string AuthKey { get; set; }

		string EntityToken { get; set; }

		void InitializeHttp();

		void Update();

		void OnDestroy();

		void SimpleGetCall(string fullUrl, Action<byte[]> successCallback, Action<string> errorCallback);

		void SimplePutCall(string fullUrl, byte[] payload, Action successCallback, Action<string> errorCallback);

		void MakeApiCall(CallRequestContainer reqContainer);

		int GetPendingMessages();
	}
}
