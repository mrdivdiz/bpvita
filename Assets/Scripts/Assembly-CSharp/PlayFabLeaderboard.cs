using System;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class PlayFabLeaderboard : MonoBehaviour
{
	public static Leaderboard LowestCup()
	{
		return PlayFabLeaderboard.Leaderboard.CakeRaceCupF;
	}

	public static Leaderboard HighestCup()
	{
		return PlayFabLeaderboard.Leaderboard.CakeRaceCupA;
	}

	public void AddScore(Leaderboard board, int score, Action<UpdatePlayerStatisticsResult> cb, Action<PlayFabError> errorCb)
	{
		StatisticUpdate item = new StatisticUpdate
		{
			StatisticName = PlayFabLeaderboard.GetBoardName(board, false),
			Value = score
		};
		UpdatePlayerStatisticsRequest request = new UpdatePlayerStatisticsRequest
		{
			Statistics = new List<StatisticUpdate>
			{
				item
			}
		};
		PlayFabClientAPI.UpdatePlayerStatistics(request, cb, errorCb, null, null);
	}

	public void AddScore(Leaderboard board, int score)
	{
		this.AddScore(board, score, new Action<UpdatePlayerStatisticsResult>(this.OnAddScoreSuccess), new Action<PlayFabError>(this.OnAddScoreError));
	}

	private void OnAddScoreSuccess(UpdatePlayerStatisticsResult result)
	{
	}

	private void OnAddScoreError(PlayFabError error)
	{
	}

	public void GetScore(Leaderboard board, Action<GetPlayerStatisticsResult> cb, Action<PlayFabError> errorCb)
	{
		StatisticUpdate statisticUpdate = new StatisticUpdate();
		statisticUpdate.StatisticName = PlayFabLeaderboard.GetBoardName(board, false);
		GetPlayerStatisticsRequest request = new GetPlayerStatisticsRequest
		{
			StatisticNames = new List<string>
			{
				board.ToString()
			}
		};
		PlayFabClientAPI.GetPlayerStatistics(request, cb, errorCb, null, null);
	}

	public void GetLeaderboard(Leaderboard board, Action<GetLeaderboardResult> cb, Action<PlayFabError> errorCb, bool previousSeason = false, int startPosition = 0, int maxCount = 50)
	{
		GetLeaderboardRequest request = new GetLeaderboardRequest
		{
			StatisticName = PlayFabLeaderboard.GetBoardName(board, previousSeason),
			StartPosition = startPosition,
			MaxResultsCount = new int?(maxCount)
		};
		PlayFabClientAPI.GetLeaderboard(request, cb, errorCb, null, null);
	}

	public void GetLeaderboardAroundPlayer(Leaderboard board, Action<GetLeaderboardAroundPlayerResult> cb, Action<PlayFabError> errorCb, bool previousSeason = false, int maxCount = 1)
	{
		GetLeaderboardAroundPlayerRequest request = new GetLeaderboardAroundPlayerRequest
		{
			StatisticName = PlayFabLeaderboard.GetBoardName(board, previousSeason),
			MaxResultsCount = new int?(maxCount)
		};
		PlayFabClientAPI.GetLeaderboardAroundPlayer(request, cb, errorCb, null, null);
	}

	private static string GetBoardName(Leaderboard board, bool previousSeason = false)
	{
		if ((!previousSeason && CakeRaceMenu.CurrentCakeRaceWeek() % 2 != 0) || (previousSeason && CakeRaceMenu.CurrentCakeRaceWeek() % 2 == 0))
		{
			switch (board)
			{
			case PlayFabLeaderboard.Leaderboard.CakeRaceCupF:
			case PlayFabLeaderboard.Leaderboard.CakeRaceCupE:
			case PlayFabLeaderboard.Leaderboard.CakeRaceCupD:
			case PlayFabLeaderboard.Leaderboard.CakeRaceCupC:
			case PlayFabLeaderboard.Leaderboard.CakeRaceCupB:
			case PlayFabLeaderboard.Leaderboard.CakeRaceCupA:
				return string.Format("{0}2", board.ToString());
			}
		}
		return board.ToString();
	}

	public enum Leaderboard
	{
		CakeRaceWins,
		CakeRaceCupF,
		CakeRaceCupE,
		CakeRaceCupD,
		CakeRaceCupC,
		CakeRaceCupB,
		CakeRaceCupA
	}
}
