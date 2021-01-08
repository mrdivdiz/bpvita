using UnityEngine;

public class InGameTutorialMenu : WPFMonoBehaviour
{
	private void OnEnable()
	{
		Resources.UnloadUnusedAssets();
		if (WPFMonoBehaviour.levelManager != null && WPFMonoBehaviour.levelManager.CurrentGameMode is CakeRaceMode)
		{
			this.m_tutorialBook = UnityEngine.Object.Instantiate<GameObject>(this.m_cakeRaceTutorialBookPrefab);
		}
		else
		{
			this.m_tutorialBook = UnityEngine.Object.Instantiate<GameObject>(this.m_tutorialBookPrefab);
		}
		this.m_tutorialBook.transform.parent = base.transform;
	}

	private void OnDisable()
	{
		UnityEngine.Object.Destroy(this.m_tutorialBook);
		if (WPFMonoBehaviour.levelManager.m_showPowerupTutorial)
		{
			WPFMonoBehaviour.levelManager.m_showPowerupTutorial = false;
			GameProgress.SetBool("PowerupTutorialShown", true, GameProgress.Location.Local);
		}
		Resources.UnloadUnusedAssets();
	}

	public GameObject m_tutorialBookPrefab;

	[SerializeField]
	private GameObject m_cakeRaceTutorialBookPrefab;

	private GameObject m_tutorialBook;
}
