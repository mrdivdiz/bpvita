using System;
using System.Collections.Generic;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetPlayerCombinedInfoResultPayload
	{
		public UserAccountInfo AccountInfo;

		public List<CharacterInventory> CharacterInventories;

		public List<CharacterResult> CharacterList;

		public PlayerProfileModel PlayerProfile;

		public List<StatisticValue> PlayerStatistics;

		public Dictionary<string, string> TitleData;

		public Dictionary<string, UserDataRecord> UserData;

		public uint UserDataVersion;

		public List<ItemInstance> UserInventory;

		public Dictionary<string, UserDataRecord> UserReadOnlyData;

		public uint UserReadOnlyDataVersion;

		public Dictionary<string, int> UserVirtualCurrency;

		public Dictionary<string, VirtualCurrencyRechargeTime> UserVirtualCurrencyRechargeTimes;
	}
}
