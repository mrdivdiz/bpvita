using System;

public interface ISocialProvider
{
	bool Authenticated { get; }

	void Authenticate();

	void ShowAchievementsView();

	void ShowLeaderboardsView();

	void LoadAchievements();

	void LoadLeaderboardScores();

	void LoadScoreForLeaderboard(string leaderboardId);

	void ReportAchievementProgress(string achievementId, double progress);

	void ReportLeaderboardScore(string leaderboardId, long score, Action<bool> handler);

	void SyncAllAchievementsNow();

	void ResetAchievementData();

	void CloseViews();

	bool ViewsActive();
}
