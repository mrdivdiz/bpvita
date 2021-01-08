using System;
using System.Collections.Generic;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetPlayerCombinedInfoRequestParams
	{
		public bool GetCharacterInventories;

		public bool GetCharacterList;

		public bool GetPlayerProfile;

		public bool GetPlayerStatistics;

		public bool GetTitleData;

		public bool GetUserAccountInfo;

		public bool GetUserData;

		public bool GetUserInventory;

		public bool GetUserReadOnlyData;

		public bool GetUserVirtualCurrency;

		public List<string> PlayerStatisticNames;

		public PlayerProfileViewConstraints ProfileConstraints;

		public List<string> TitleDataKeys;

		public List<string> UserDataKeys;

		public List<string> UserReadOnlyDataKeys;
	}
}
