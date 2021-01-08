using UnityEngine;

public class CreditsMenu : MonoBehaviour
{
	public void CloseCredits()
	{
		GameObject.Find("MainMenuLogic").GetComponent<MainMenu>().CloseCredits();
	}

	public void Start()
	{
		if (Singleton<SocialGameManager>.IsInstantiated())
		{
			Singleton<SocialGameManager>.Instance.ReportAchievementProgress("grp.LITERATE", 100.0);
		}
	}
}
