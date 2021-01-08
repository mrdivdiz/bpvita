using System;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class PlayerLeaderboardEntry
	{
		public string DisplayName;

		public string PlayFabId;

		public int Position;

		public PlayerProfileModel Profile;

		public int StatValue;
	}
}
