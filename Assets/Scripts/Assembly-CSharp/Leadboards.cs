using System;
using System.Text;
using PlayFab;
using PlayFab.ClientModels;

public static class Leadboards
{
	public static void GetLeaderboards()
	{
		GetLeaderboardRequest request = new GetLeaderboardRequest
		{
			StartPosition = 0,
			MaxResultsCount = new int?(50),
			StatisticName = "Score"
		};
		Action<GetLeaderboardResult> resultCallback = new Action<GetLeaderboardResult>(Leadboards.OnSuccess);
		PlayFabClientAPI.GetLeaderboard(request, resultCallback, new Action<PlayFabError>(Leadboards.OnError), null, null);
	}

	private static void OnSuccess(GetLeaderboardResult result)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (PlayerLeaderboardEntry playerLeaderboardEntry in result.Leaderboard)
		{
			stringBuilder.Append("********************\n");
			stringBuilder.AppendFormat("Position: {0}\n", playerLeaderboardEntry.Position);
			stringBuilder.AppendFormat("Name: {0}\n", playerLeaderboardEntry.DisplayName);
			stringBuilder.AppendFormat("Score: {0}\n", playerLeaderboardEntry.StatValue);
			stringBuilder.Append("\n");
		}
	}

	private static void OnError(PlayFabError error)
	{
	}
}
