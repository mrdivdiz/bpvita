public class Achievements : WPFMonoBehaviour
{
	public static bool GetAchievementStatus(AchievementType achievement)
	{
		switch (achievement)
		{
		case Achievements.AchievementType.Time:
			if (WPFMonoBehaviour.levelManager.TimeElapsed < WPFMonoBehaviour.levelManager.TimeLimit)
			{
				return true;
			}
			break;
		case Achievements.AchievementType.CoolPilot:
			if ((float)WPFMonoBehaviour.levelManager.m_totalDestroyedParts / (float)WPFMonoBehaviour.levelManager.m_totalAvailableParts < 0.25f)
			{
				return true;
			}
			break;
		case Achievements.AchievementType.CrazyPilot:
			if ((float)WPFMonoBehaviour.levelManager.m_totalDestroyedParts / (float)WPFMonoBehaviour.levelManager.m_totalAvailableParts > 0.5f)
			{
				return true;
			}
			break;
		}
		return false;
	}

	public enum AchievementType
	{
		Time,
		CoolPilot,
		CrazyPilot,
		SavedParts,
		Eggs
	}
}
