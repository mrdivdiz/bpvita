using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceLevelButton : MonoBehaviour
{
	private void Start()
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = GameProgress.GetRaceLevelUnlocked(this.m_raceLevelIdentifier) || GameProgress.AllLevelsUnlocked();
		bool flag4 = LevelInfo.IsContentLimited(-1, this.m_levelNumber);
		bool flag5 = GameProgress.IsLevelAdUnlocked(this.m_raceLevelIdentifier);
		int levelIndex = this.m_raceLevelSelector.m_raceLevels.GetLevelIndex(this.m_raceLevelIdentifier);
		if (levelIndex > 0)
		{
			RaceLevels.LevelData levelData = this.m_raceLevelSelector.m_raceLevels.Levels[levelIndex - 1];
			int @int = GameProgress.GetInt(levelData.SceneName + "_stars", 0, GameProgress.Location.Local, null);
			if (GameProgress.GetRaceLevelUnlocked(levelData.m_identifier) && @int > 0)
			{
				flag = true;
			}
			if (GameProgress.GetRaceLevelUnlocked(levelData.m_identifier) || GameProgress.AllLevelsUnlocked())
			{
				flag2 = true;
			}
		}
		if (!Singleton<BuildCustomizationLoader>.Instance.IsOdyssey && flag2 && !flag3)
		{
			int cost = Singleton<VirtualCatalogManager>.Instance.GetProductPrice("road_hogs_level_unlock");
			this.AddRoadHogsUnlockDialog(base.GetComponent<Button>(), this.m_raceLevelIdentifier, cost, () => GameProgress.SnoutCoinCount() >= cost);
		}
		else if (!flag3)
		{
			Animation animation = base.gameObject.AddComponent<Animation>();
			animation.AddClip(this.shake, this.shake.name);
			ButtonAnimation buttonAnimation = base.gameObject.AddComponent<ButtonAnimation>();
			buttonAnimation.PlayWholeAnimation = true;
			buttonAnimation.ActivateAnimationName = this.shake.name;
			base.gameObject.AddComponent<InactiveButton>();
		}
		if (!flag4 && flag && !flag3)
		{
			GameProgress.SetRaceLevelUnlocked(this.m_raceLevelIdentifier, true);
		}
		if (flag4 && (flag || flag2 || flag5))
		{
			flag4 = false;
		}
		GameProgress.ButtonUnlockState buttonUnlockState = GameProgress.GetButtonUnlockState("RaceLevelButton_" + this.m_raceLevelIdentifier);
		if (flag3 && buttonUnlockState == GameProgress.ButtonUnlockState.Locked && !flag4)
		{
			base.StartCoroutine(this.UnlockNowSequence());
		}
		if ((flag3 && !flag4) || !base.transform.Find("Lock"))
		{
			Button component = base.GetComponent<Button>();
			component.MethodToCall.SetMethod(this.m_raceLevelSelector.gameObject.GetComponent<RaceLevelSelector>(), "LoadRaceLevel", this.m_raceLevelIdentifier);
			string sceneName = WPFMonoBehaviour.gameData.FindRaceLevel(this.m_raceLevelIdentifier).SceneName;
			int int2 = GameProgress.GetInt(this.m_raceLevelSelector.FindLevelFile(this.m_raceLevelIdentifier) + "_stars", 0, GameProgress.Location.Local, null);
			bool flag6 = GameProgress.HasCollectedSnoutCoins(sceneName, 0);
			bool flag7 = GameProgress.HasCollectedSnoutCoins(sceneName, 1);
			bool flag8 = GameProgress.HasCollectedSnoutCoins(sceneName, 2);
			GameObject[] array = new GameObject[]
			{
				component.transform.Find("StarSet/Star1").gameObject,
				component.transform.Find("StarSet/Star2").gameObject,
				component.transform.Find("StarSet/Star3").gameObject,
				component.transform.Find("CoinSet/Star1").gameObject,
				component.transform.Find("CoinSet/Star2").gameObject,
				component.transform.Find("CoinSet/Star3").gameObject
			};
			int num = 0;
			if (flag6)
			{
				num++;
			}
			if (flag7)
			{
				num++;
			}
			if (flag8)
			{
				num++;
			}
			for (int i = 0; i < 3; i++)
			{
				bool flag9 = i + 1 <= int2;
				bool flag10 = i + 1 <= num || Singleton<BuildCustomizationLoader>.Instance.IsOdyssey;
				array[i].SetActive(flag9 && !flag10);
				array[i + 3].SetActive(flag9 && flag10);
			}
			string sceneName2 = this.m_raceLevelSelector.m_raceLevels.GetLevelData(this.m_raceLevelIdentifier).SceneName;
			if (GameProgress.HasBestTime(sceneName2))
			{
				float num2 = Mathf.Clamp(GameProgress.GetBestTime(sceneName2), 0f, 3599.99f);
				TimeSpan timeSpan = TimeSpan.FromSeconds((double)num2);
				base.transform.Find("BestTime").GetComponent<TextMesh>().text = string.Format("{0:D2}:{1:D2}.{2:D2}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 10);
				base.transform.Find("BestTime").gameObject.SetActive(true);
				base.transform.Find("TimeBG").gameObject.SetActive(true);
			}
		}
		else
		{
			base.transform.Find("StarSet").gameObject.SetActive(false);
			base.transform.Find("CoinSet").gameObject.SetActive(false);
			base.transform.Find("BestTime").gameObject.SetActive(false);
			base.transform.Find("TimeBG").gameObject.SetActive(false);
		}
	}

	private void AddRoadHogsUnlockDialog(Button button, string levelIdentifier, int price, Func<bool> requirements)
	{
		GameData gameData = Singleton<GameManager>.Instance.gameData;
		if (gameData.m_roadHogsUnlockDialog != null && gameData.m_genericButtonPrefab != null)
		{
			GameObject gameObject = base.transform.Find("Finger").gameObject;
			gameObject.GetComponent<Renderer>().enabled = true;
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(gameData.m_roadHogsUnlockDialog);
			gameObject2.transform.position = new Vector3(0f, 0f, -15f);
			GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(gameData.m_genericButtonPrefab);
			gameObject3.transform.parent = base.transform;
			gameObject3.transform.localPosition = Vector3.zero + new Vector3(0f, 0f, -1f);
			gameObject3.transform.localRotation = Quaternion.identity;
			gameObject3.GetComponent<BoxCollider>().size = base.gameObject.GetComponent<BoxCollider>().size;
			TextDialog dialog = gameObject2.GetComponent<TextDialog>();
			button.MethodToCall.SetMethod(dialog, "Open");
			gameObject3.GetComponent<Button>().MethodToCall.SetMethod(dialog, "Open");
			dialog.ConfirmButtonText = string.Format("[snout] {0}", price);
			dialog.ShowConfirmEnabled = (() => true);
			dialog.Close();
			dialog.SetOnConfirm(delegate
			{
				if (!GameProgress.GetRaceLevelUnlocked(levelIdentifier) && !GameProgress.IsLevelAdUnlocked(levelIdentifier) && requirements() && GameProgress.UseSnoutCoins(price))
				{
					GameProgress.SetRaceLevelUnlocked(levelIdentifier, true);
					GameProgress.SetButtonUnlockState("RaceLevelButton_" + levelIdentifier, GameProgress.ButtonUnlockState.Locked);
					Singleton<GameManager>.Instance.ReloadCurrentLevel(true);
					EventManager.Connect(new EventManager.OnEvent<LevelLoadedEvent>(this.DelayedPurchaseSound));
				}
				else if (!requirements() && Singleton<IapManager>.IsInstantiated())
				{
					dialog.Close();
					Singleton<IapManager>.Instance.OpenShopPage(new Action(dialog.Open), "SnoutCoinShop");
				}
				else
				{
					dialog.Close();
				}
			});
		}
	}

	private void DelayedPurchaseSound(LevelLoadedEvent data)
	{
		EventManager.Disconnect(new EventManager.OnEvent<LevelLoadedEvent>(this.DelayedPurchaseSound));
		Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.snoutCoinUse);
	}

	private IEnumerator UnlockNowSequence()
	{
		yield return null;
		GameProgress.UnlockButton("RaceLevelButton_" + this.m_raceLevelIdentifier);
		base.transform.Find("Lock").GetComponent<ButtonLock>().NotifyUnlocked();
		yield break;
	}

	public string m_raceLevelIdentifier;

	public int m_levelNumber;

	[SerializeField]
	private RaceLevelSelector m_raceLevelSelector;

	[SerializeField]
	private TextMesh m_starsText;

	[SerializeField]
	private AnimationClip shake;
}
