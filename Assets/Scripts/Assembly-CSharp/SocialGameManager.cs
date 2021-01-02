using System;
using System.Collections.Generic;

public class SocialGameManager : Singleton<SocialGameManager>
{
	public static void RegisterProvider(ISocialProvider provider)
	{
		Singleton<SocialGameManager>.Instance.m_provider = provider;
	}

	public void Authenticate()
	{
		this.m_provider.Authenticate();
	}

	public bool Authenticated
	{
		get
		{
			return this.m_provider.Authenticated;
		}
	}

	public void ShowAchievementsView()
	{
		this.m_provider.ShowAchievementsView();
	}

	public void ShowLeaderboardsView()
	{
		this.m_provider.ShowLeaderboardsView();
	}

	public void LoadAchievements()
	{
		this.m_provider.LoadAchievements();
	}

	public void LoadLeaderboardScores()
	{
		this.m_provider.LoadLeaderboardScores();
	}

	public void LoadScoreForLeaderboard(string leaderboardId)
	{
		this.m_provider.LoadScoreForLeaderboard(leaderboardId);
	}

	public bool TryReportAchievementProgress(string achievementId, double progress, Func<int, bool> condition)
	{
		try
		{
			int achievementLimit = Singleton<AchievementData>.Instance.GetAchievementLimit(achievementId);
			if (condition(achievementLimit))
			{
				this.ReportAchievementProgress(achievementId, progress);
				return true;
			}
		}
		catch (KeyNotFoundException)
		{
		}
		return false;
	}

	public void ReportAchievementProgress(string achievementId, double progress)
	{
		this.m_provider.ReportAchievementProgress(achievementId, progress);
	}

	public void ReportLeaderboardScore(string leaderboardId, long score, Action<bool> handler)
	{
		this.m_provider.ReportLeaderboardScore(leaderboardId, score, handler);
	}

	public void SyncAllAchievementsNow()
	{
		this.m_provider.SyncAllAchievementsNow();
	}

	public void ResetAchievementData()
	{
		this.m_provider.ResetAchievementData();
	}

	public bool ViewsActive()
	{
		return this.m_provider.ViewsActive();
	}

	public void CloseViews()
	{
		this.m_provider.CloseViews();
	}

	private void Awake()
	{
		base.SetAsPersistant();
	}

	private ISocialProvider m_provider;
}
