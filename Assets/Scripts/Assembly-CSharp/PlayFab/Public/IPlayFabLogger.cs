using System.Net;

namespace PlayFab.Public
{
    public interface IPlayFabLogger
	{
		IPAddress ip { get; set; }

		int port { get; set; }

		string url { get; set; }

		void OnEnable();

		void OnDisable();

		void OnDestroy();
	}
}
