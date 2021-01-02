using System.Collections.Generic;

namespace PlayFab.PlayStreamModels
{
    public class TitleAddedGameBuildEventData : PlayStreamEventBase
	{
		public string BuildId;

		public string DeveloperId;

		public int MaxGamesPerHost;

		public int MinFreeGameSlots;

		public List<Region> Regions;

		public string UserId;
	}
}
