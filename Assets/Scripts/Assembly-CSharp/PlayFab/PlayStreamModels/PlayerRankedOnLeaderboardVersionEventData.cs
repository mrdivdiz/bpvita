namespace PlayFab.PlayStreamModels
{
    public class PlayerRankedOnLeaderboardVersionEventData : PlayStreamEventBase
	{
		public LeaderboardSource LeaderboardSource;

		public uint Rank;

		public string TitleId;

		public int Value;

		public uint Version;

		public LeaderboardVersionChangeBehavior? VersionChangeBehavior;
	}
}
