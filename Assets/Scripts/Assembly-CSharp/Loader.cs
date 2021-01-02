using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : Singleton<Loader>
{
	public string LastLoadedString
	{
		get
		{
			return this.m_lastLoadedLevel;
		}
	}

	public void LoadLevel(string levelName, GameManager.GameState nextState, bool showLoadingScreen, bool enableGUIAfterLoad = true)
	{
		Loader.isLoadingLevel = true;
		this.m_lastLoadedLevel = levelName;
		if (showLoadingScreen)
		{
			this.Show();
		}
		else
		{
			base.gameObject.SetActive(true);
		}
		GameProgress.Save();
		CoroutineRunner.Instance.StartCoroutine(this.LoadLevelAsync(levelName, nextState, enableGUIAfterLoad));
	}

	private IEnumerator LoadLevelAsync(string levelName, GameManager.GameState nextState, bool enableGUIAfterLoad = true)
	{
		Singleton<GuiManager>.Instance.IsEnabled = false;
		yield return null;
		if (!levelName.Equals("DailyChallenge") && !levelName.Equals("CakeRaceIntro") && (levelName.Equals("LevelStub") || nextState == GameManager.GameState.Cutscene || nextState == GameManager.GameState.StarLevelCutscene))
		{
			LevelLoader levelLoader = Singleton<GameManager>.instance.CurrentLevelLoader();
			string bundleId = (!(levelLoader != null)) ? string.Empty : levelLoader.AssetBundleName;
			if (!string.IsNullOrEmpty(bundleId) && Bundle.HasBundle(bundleId))
			{
				Bundle.LoadBundleAsync(bundleId, null);
				while (!Bundle.IsBundleLoaded(bundleId))
				{
					yield return null;
				}
			}
		}
		CoroutineRunner.Instance.StartCoroutine(this.DelayLoadLevelEvent(Singleton<GameManager>.Instance.GetGameState(), nextState, levelName));
		Singleton<GameManager>.Instance.SetLoadingLevelGameState(nextState);
		AsyncOperation async = SceneManager.LoadSceneAsync(levelName);
		yield return async;
		if (Singleton<GameManager>.Instance.GetGameState() == GameManager.GameState.LevelSelection || Singleton<GameManager>.Instance.GetGameState() == GameManager.GameState.SandboxLevelSelection || Singleton<GameManager>.Instance.GetGameState() == GameManager.GameState.EpisodeSelection)
		{
			GameTime.Pause(false);
		}
		Singleton<GuiManager>.Instance.IsEnabled = enableGUIAfterLoad;
		Loader.isLoadingLevel = false;
		yield break;
	}

	private void Awake()
	{
		base.SetAsPersistant();
		this.originalPosition = base.transform.position;
		SceneManager.sceneLoaded += this.OnSceneLoaded;
	}

	private void OnDestroy()
	{
		SceneManager.sceneLoaded -= this.OnSceneLoaded;
	}

	private void Start()
	{
		this.Hide();
	}

	private void Show()
	{
		this.RepositionToNearplane();
		base.gameObject.SetActive(true);
	}

	private void Hide()
	{
		base.gameObject.SetActive(false);
	}

	private void RepositionToNearplane()
	{
		Camera hudCamera = WPFMonoBehaviour.hudCamera;
		if (hudCamera)
		{
			float z = hudCamera.transform.position.z + hudCamera.nearClipPlane * 2f;
			base.transform.position = new Vector3(this.originalPosition.x, this.originalPosition.y - hudCamera.transform.InverseTransformPoint(0f, 0f, 0f).y, z);
		}
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
	{
		Singleton<GuiManager>.Instance.IsEnabled = true;
		this.Hide();
		this.RepositionToNearplane();
		this.DisableScreenSleep(Singleton<GameManager>.Instance.IsInGame());
		EventManager.SendOnNextUpdate(CoroutineRunner.Instance, new LevelLoadedEvent(Singleton<GameManager>.Instance.GetGameState()));
	}

	private IEnumerator DelayLoadLevelEvent(GameManager.GameState currentState, GameManager.GameState nextState, string levelName)
	{
		yield return new WaitForEndOfFrame();
		EventManager.Send(new LoadLevelEvent(currentState, nextState, levelName));
		yield break;
	}

	private void DisableScreenSleep(bool disable)
	{
		Screen.sleepTimeout = ((!disable) ? -2 : -1);
	}

	public static bool isLoadingLevel;

	private Vector3 originalPosition = Vector3.zero;

	private string m_lastLoadedLevel = string.Empty;
}
