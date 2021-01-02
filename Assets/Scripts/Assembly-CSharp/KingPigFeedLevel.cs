using System.Collections.Generic;
using UnityEngine;

public class KingPigFeedLevel : MonoBehaviour
{
	private void Awake()
	{
		if (GameTime.IsPaused())
		{
			GameTime.Pause(false);
		}
	}

	private void Start()
	{
		if (this.doubleRewardButton)
		{
			this.doubleRewardButton.gameObject.SetActive(true);
			this.doubleRewardButton.Show();
		}
	}

	private void OnEnable()
	{
		KeyListener.keyReleased += this.HandleKeyReleased;
	}

	private void OnDisable()
	{
		KeyListener.keyReleased -= this.HandleKeyReleased;
	}

	public void GoBack()
	{
		KingPigFeedButton.LastDessertCount = KingPigFeedButton.CurrentDessertCount();
		if ((Singleton<GameManager>.Instance.GetPrevGameState() == GameManager.GameState.LevelSelection || Singleton<GameManager>.Instance.GetPrevGameState() == GameManager.GameState.Level) && Singleton<GameManager>.Instance.CurrentEpisode != string.Empty)
		{
			Singleton<GameManager>.Instance.LoadLevelSelection(Singleton<GameManager>.Instance.CurrentEpisode, true);
		}
		else
		{
			Singleton<GameManager>.Instance.LoadEpisodeSelection(true);
		}
	}

	private void OnDestroy()
	{
		if (GameTime.IsPaused())
		{
			GameTime.Pause(false);
		}
		this.SendKingPigFeedingExitFlurryEvent();
	}

	public void SendKingPigFeedingExitFlurryEvent()
	{
	}

	private void HandleKeyReleased(KeyCode obj)
	{
		bool flag = false;
		if (obj == KeyCode.Escape && !flag)
		{
			this.GoBack();
		}
	}

	public void ShowTutorialScreen()
	{
		GameObject original = Resources.Load("UI/TutorialPage", typeof(GameObject)) as GameObject;
		UnityEngine.Object.Instantiate<GameObject>(original);
	}

	public void OpenShop()
	{
		base.gameObject.SetActive(false);
		Singleton<IapManager>.Instance.OpenShopPage(delegate
		{
			base.gameObject.SetActive(true);
		}, null);
	}

	[SerializeField]
	private DoubleRewardButton doubleRewardButton;
}
