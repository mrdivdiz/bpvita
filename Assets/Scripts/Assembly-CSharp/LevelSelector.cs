using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : WPFMonoBehaviour
{
	public static string DifferentiatedLevelLabel(int levelIndex)
	{
		int num = levelIndex + 1;
		if (num % 5 != 0)
		{
			return (num - num / 5).ToString();
		}
		int num2 = num / 5;
		if (num2 >= 1 && num2 <= 9)
		{
			return LevelSelector.romanNumeralStrings[num2 - 1];
		}
		return "Z";
	}

	public List<EpisodeLevelInfo> Levels
	{
		get
		{
			return this.m_levels;
		}
		set
		{
			this.m_levels = value;
		}
	}

	public List<int> StarLevelLimits
	{
		get
		{
			return this.m_starlimitsLevels;
		}
		set
		{
			this.m_starlimitsLevels = value;
		}
	}

	public int EpisodeIndex
	{
		get
		{
			return this.m_episodeLevelsGameDataIndex;
		}
	}

	public string OpeningCutscene
	{
		get
		{
			return this.m_startingCutsceneButton.GetComponent<Button>().MethodToCall.GetParameter<string>(0);
		}
	}

	public string MidCutscene
	{
		get
		{
			if (this.m_midCutsceneButton != null)
			{
				return this.m_midCutsceneButton.GetComponent<Button>().MethodToCall.GetParameter<string>(0);
			}
			return null;
		}
	}

	public string EndingCutscene
	{
		get
		{
			return this.m_endingCutsceneButton.GetComponent<Button>().MethodToCall.GetParameter<string>(0);
		}
	}

	public int CurrentPage
	{
		get
		{
			return Mathf.Clamp(Mathf.RoundToInt(this.m_buttonGrid.transform.localPosition.x / -WPFMonoBehaviour.hudCamera.ScreenToWorldPoint(new Vector3((float)Screen.width, 0f, 0f)).x), 1, this.m_pageCount);
		}
	}

	private float ButtonXGap
	{
		get
		{
			return Mathf.Clamp((float)Screen.width / 7f, (float)(80 * Screen.width) / 1024f, (float)(160 * Screen.height) / 768f);
		}
	}

	private void OnEnable()
	{
		IapManager.onPurchaseSucceeded += this.HandleIapManageronPurchaseSucceeded;
		EventManager.Connect(new EventManager.OnEvent<UIEvent>(this.ReceiveUIEvent));
		KeyListener.keyReleased += this.HandleKeyListenerkeyReleased;
		if (DeviceInfo.IsDesktop)
		{
			KeyListener.mouseWheel += this.HandleKeyListenerMouseWheel;
		}
	}

	private void HandleKeyListenerkeyReleased(KeyCode obj)
	{
		if (obj == KeyCode.Escape)
		{
			this.GoToEpisodeSelection();
		}
		else if (DeviceInfo.ActiveDeviceFamily != DeviceInfo.DeviceFamily.Android && obj == KeyCode.RightArrow && this.m_rightScroll.activeInHierarchy)
		{
			this.NextPage();
		}
		else if (DeviceInfo.ActiveDeviceFamily != DeviceInfo.DeviceFamily.Android && obj == KeyCode.LeftArrow && this.m_leftScroll.activeInHierarchy)
		{
			this.PreviousPage();
		}
	}

	private void HandleKeyListenerMouseWheel(float delta)
	{
		if (delta < 0f && this.m_rightScroll.activeInHierarchy && !this.m_interacting)
		{
			this.NextPage();
		}
		else if (delta > 0f && this.m_leftScroll.activeInHierarchy && !this.m_interacting)
		{
			this.PreviousPage();
		}
	}

	private void OnDisable()
	{
		IapManager.onPurchaseSucceeded -= this.HandleIapManageronPurchaseSucceeded;
		EventManager.Disconnect(new EventManager.OnEvent<UIEvent>(this.ReceiveUIEvent));
		KeyListener.keyReleased -= this.HandleKeyListenerkeyReleased;
		if (DeviceInfo.IsDesktop)
		{
			KeyListener.mouseWheel -= this.HandleKeyListenerMouseWheel;
		}
	}

	private void Awake()
	{
		if (GameTime.IsPaused())
		{
			GameTime.Pause(false);
		}
		this.m_page = UserSettings.GetInt(Singleton<GameManager>.Instance.CurrentSceneName + "_active_page", 0);
		if (GameProgress.GetBool("show_content_limit_popup", false, GameProgress.Location.Local, null))
		{
			GameProgress.DeleteKey("show_content_limit_popup", GameProgress.Location.Local);
			if (Singleton<BuildCustomizationLoader>.Instance.IsContentLimited)
			{
				if (this.m_page == 0)
				{
					EventManager.SendOnNextUpdate(this, new PulseButtonEvent(UIEvent.Type.OpenUnlockFullVersionIapMenu, false));
					LevelInfo.DisplayContentLimitNotification();
				}
			}
			else
			{
				LevelInfo.DisplayContentLimitNotification();
			}
		}
		this.Levels = WPFMonoBehaviour.gameData.m_episodeLevels[this.EpisodeIndex].m_levelInfos;
		this.StarLevelLimits = WPFMonoBehaviour.gameData.m_episodeLevels[this.EpisodeIndex].StarLevelLimits;
		this.m_pageCount = Mathf.RoundToInt((float)(this.m_levels.Count / this.m_levelsPerPage));
		this.m_buttonGrid = base.transform.Find("ButtonGrid").GetComponent<ButtonGrid>();
		this.m_currentScreenWidth = Screen.width;
		this.m_currentScreenHeight = Screen.height;
		this.m_page = Mathf.Min(this.m_page, this.m_pageCount);
		Singleton<GameManager>.Instance.OpenEpisode(this);
		this.CreateButtons();
		this.CreatePageDots();
		this.LayoutButtons(this.m_page);
		if (DeviceInfo.UsesTouchInput)
		{
			this.m_leftScroll.SetActive(false);
			this.m_rightScroll.SetActive(false);
		}
		if (GameProgress.TotalDessertCount() > 0)
		{
			EventManager.Send(new PulseButtonEvent(UIEvent.Type.None, true));
		}
	}

	private void OnPageChanged()
	{
	}

	public void ReceiveUIEvent(UIEvent data)
	{
		if (data.type == UIEvent.Type.OpenUnlockFullVersionIapMenu)
		{
		}
	}

	public void SendExitLevelSelectionFlurryEvent()
	{
	}

	public void SendStandardFlurryEvent(string eventName, string id)
	{
	}

	public void GoToEpisodeSelection()
	{
		Singleton<GameManager>.Instance.LoadEpisodeSelection(false);
	}

	public void GoToKingPigFeed()
	{
		Singleton<GameManager>.Instance.LoadKingPigFeed(false);
	}

	public void LoadLevel(string levelIndex)
	{
		if (this.startedLevelLoading)
		{
			return;
		}
		this.startedLevelLoading = true;
		this.SendStandardFlurryEvent("Select Level", levelIndex);
		int num = int.Parse(levelIndex);
		if (num >= 0)
		{
			if (this.m_oneTimeCutscene.enabled && !GameProgress.GetBool(this.m_oneTimeCutscene.saveId, false, GameProgress.Location.Local, null))
			{
				Singleton<GameManager>.Instance.LoadLevelAfterCutScene(this.m_levels[num], this.m_oneTimeCutscene.cutScene);
				GameProgress.SetBool(this.m_oneTimeCutscene.saveId, true, GameProgress.Location.Local);
			}
			else
			{
				Singleton<GameManager>.Instance.LoadLevel(num);
			}
			return;
		}
		this.startedLevelLoading = false;
	}

	public IEnumerator LoadLevelDelayed(string episodeBundleId, int levelIndex)
	{
		while (!Bundle.IsBundleLoaded(episodeBundleId))
		{
			yield return null;
		}
		if (this.m_oneTimeCutscene.enabled && !GameProgress.GetBool(this.m_oneTimeCutscene.saveId, false, GameProgress.Location.Local, null))
		{
			Singleton<GameManager>.Instance.LoadLevelAfterCutScene(this.m_levels[levelIndex], this.m_oneTimeCutscene.cutScene);
			GameProgress.SetBool(this.m_oneTimeCutscene.saveId, true, GameProgress.Location.Local);
		}
		else
		{
			Singleton<GameManager>.Instance.LoadLevel(levelIndex);
		}
		yield break;
	}

	public void LoadStarLevel(string levelIndex)
	{
		this.SendStandardFlurryEvent("Select Level", levelIndex);
		if (this.m_oneTimeCutscene.enabled && !GameProgress.GetBool(this.m_oneTimeCutscene.saveId, false, GameProgress.Location.Local, null))
		{
			Singleton<GameManager>.Instance.LoadLevelAfterCutScene(this.m_levels[int.Parse(levelIndex)], this.m_oneTimeCutscene.cutScene);
			GameProgress.SetBool(this.m_oneTimeCutscene.saveId, true, GameProgress.Location.Local);
		}
		else
		{
			Singleton<GameManager>.Instance.LoadStarLevelTransition(this.m_levels[int.Parse(levelIndex)]);
		}
	}

	public void LoadOpeningCutscene(string cutscene)
	{
		Singleton<GameManager>.Instance.LoadOpeningCutscene();
		if (this.m_oneTimeCutscene.enabled)
		{
			GameProgress.SetBool(this.m_oneTimeCutscene.saveId, true, GameProgress.Location.Local);
		}
	}

	public void LoadMidCutscene(string cutscene, bool isStartedFromLevelSelection = false)
	{
		Singleton<GameManager>.Instance.LoadMidCutscene(isStartedFromLevelSelection);
	}

	public void LoadEndingCutscene(string cutscene)
	{
		Singleton<GameManager>.Instance.LoadEndingCutscene();
	}

	public void NextPage()
	{
		int page = this.m_page;
		this.m_page = Mathf.Clamp(this.m_page + 1, 0, this.m_pageCount - 1);
		if (page != this.m_page)
		{
			this.OnPageChanged();
		}
		for (int i = 0; i < this.m_dotsList.Count; i++)
		{
			if (i == this.m_page)
			{
				this.m_dotsList[i].Enable();
			}
			else
			{
				this.m_dotsList[i].Disable();
			}
		}
	}

	public void PreviousPage()
	{
		int page = this.m_page;
		this.m_page = Mathf.Clamp(this.m_page - 1, 0, this.m_pageCount - 1);
		if (page != this.m_page)
		{
			this.OnPageChanged();
		}
		for (int i = 0; i < this.m_dotsList.Count; i++)
		{
			if (i == this.m_page)
			{
				this.m_dotsList[i].Enable();
			}
			else
			{
				this.m_dotsList[i].Disable();
			}
		}
	}

	private void CreateButtons()
	{
		int num = 0;
		this.m_buttonGrid.Clear();
		for (int i = 0; i < this.m_levels.Count; i++)
		{
			int num2 = i / 5;
			int page = num2 / 3;
			bool flag = LevelInfo.IsContentLimited(this.EpisodeIndex, i);
			bool flag2 = LevelInfo.IsStarLevel(this.EpisodeIndex, i);
			bool flag3 = LevelInfo.IsLevelUnlocked(this.EpisodeIndex, i);
			bool flag4 = LevelInfo.CanAdUnlock(this.EpisodeIndex, i);
			bool flag5 = i % 5 == 0;
			bool flag6 = i == 0 || LevelInfo.IsLevelCompleted(this.EpisodeIndex, (!flag5) ? (i - 1) : (i - 2));
			bool flag7 = true;
			bool flag8 = LevelInfo.IsLevelUnlocked(this.EpisodeIndex, num2 * 5);
			bool showRowUnlockStarEffect = GameProgress.GetShowRowUnlockStarEffect(this.EpisodeIndex, num2);
			bool flag9 = num2 != 0 || true;
			Button button = (!flag2) ? UnityEngine.Object.Instantiate<GameObject>(this.m_levelButtonPrefab).GetComponent<Button>() : UnityEngine.Object.Instantiate<GameObject>(this.m_levelJokerButtonPrefab).GetComponent<Button>();
			button.name = "LevelButton";
			button.transform.parent = this.m_buttonGrid.transform;
			this.m_buttonGrid.AddButton(button);
			if (flag3 || ((flag7 || flag8) && flag6 && !flag2))
			{
				num = i;
				this.UnlockLevel(button, i, flag2);
			}
			else if (flag2 && (flag7 || !flag))
			{
				this.LockLevel(button, i, flag2, false, true);
			}
			else if (!flag)
			{
				this.LockLevel(button, i, flag2, false, false);
			}
			else if (flag5 && flag9 && flag4)
			{
				this.AddUnlockPanel(button, num2, page, this.EpisodeIndex, flag6);
				this.LockLevel(button, i, flag2, LevelInfo.IsContentLimited(this.EpisodeIndex, i), flag7 || flag8);
			}
			else if (flag5 && !flag9)
			{
				this.AddLockedPanel(button);
				this.LockLevel(button, i, flag2, LevelInfo.IsContentLimited(this.EpisodeIndex, i), flag7 || flag8);
			}
			else
			{
				bool isContentLimited = LevelInfo.IsContentLimited(this.EpisodeIndex, i);
				this.LockLevel(button, i, flag2, isContentLimited, flag7 || flag8);
			}
			if (showRowUnlockStarEffect)
			{
				this.ShowStarEffect();
				GameProgress.SetShowRowUnlockStarEffect(this.EpisodeIndex, num2, false);
			}
			if (i == 0 && GameProgress.GetInt(this.OpeningCutscene + "_played", 0, GameProgress.Location.Local, null) == 0)
			{
				button.MethodToCall.SetMethod(button.MethodToCall.TargetObject.GetComponent(button.MethodToCall.TargetComponent), "LoadOpeningCutscene");
			}
			if (this.MidCutscene != null && i == 15 && LevelInfo.IsLevelUnlocked(this.EpisodeIndex, i) && GameProgress.GetInt(this.MidCutscene + "_played", 0, GameProgress.Location.Local, null) == 0)
			{
				button.MethodToCall.SetMethod(button.MethodToCall.TargetObject.GetComponent(button.MethodToCall.TargetComponent), "LoadMidCutscene");
			}
			int index;
			if (Singleton<DailyChallenge>.Instance.IsDailyChallenge(this.EpisodeIndex, i, out index) && Singleton<DailyChallenge>.Instance.IsLocationRevealed(index) && !Singleton<DailyChallenge>.Instance.DailyChallengeCollected(index))
			{
				GameObject gameObject;
				switch (Singleton<DailyChallenge>.Instance.TodaysLootCrate(index))
				{
				default:
					gameObject = UnityEngine.Object.Instantiate<GameObject>(this.m_woodCrate);
					break;
				case LootCrateType.Metal:
					gameObject = UnityEngine.Object.Instantiate<GameObject>(this.m_metalCrate);
					break;
				case LootCrateType.Gold:
					gameObject = UnityEngine.Object.Instantiate<GameObject>(this.m_goldCrate);
					break;
				case LootCrateType.Cardboard:
					gameObject = UnityEngine.Object.Instantiate<GameObject>(this.m_cardboardCrate);
					break;
				case LootCrateType.Glass:
					gameObject = UnityEngine.Object.Instantiate<GameObject>(this.m_glassCrate);
					break;
				case LootCrateType.Bronze:
					gameObject = UnityEngine.Object.Instantiate<GameObject>(this.m_bronzeCrate);
					break;
				case LootCrateType.Marble:
					gameObject = UnityEngine.Object.Instantiate<GameObject>(this.m_marbleCrate);
					break;
				}
				gameObject.layer = button.gameObject.layer;
				gameObject.transform.parent = button.transform;
				gameObject.transform.localPosition = new Vector3(1.25f, 1.25f, -1f);
				gameObject.GetComponent<Animation>().Play();
			}
		}
		if (this.m_pageTwoComingSoon && this.m_levels.Count > 15)
		{
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.m_comingSoonIcon);
			gameObject2.transform.parent = this.m_buttonGrid.transform.GetChild(22);
			gameObject2.transform.localPosition = Vector3.zero - Vector3.forward * 4f;
			if (!this.m_pageThreeComingSoon || this.m_levels.Count <= 30)
			{
				Transform transform = UnityEngine.Object.Instantiate<Transform>(gameObject2.transform.GetChild(0));
				transform.parent = gameObject2.transform;
				Vector3 localPosition = Vector3.zero + Vector3.right * WPFMonoBehaviour.hudCamera.ScreenToWorldPoint(new Vector3((float)Screen.width * 1.5f, 0f, 0f)).x;
				localPosition.y = gameObject2.transform.GetChild(0).transform.localPosition.y;
				transform.transform.localPosition = localPosition;
				this.m_extraDarkLayerRight = transform.gameObject;
			}
		}
		if (this.m_pageThreeComingSoon && this.m_levels.Count > 30)
		{
			GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.m_comingSoonIcon);
			gameObject3.transform.parent = this.m_buttonGrid.transform.GetChild(37);
			gameObject3.transform.localPosition = Vector3.zero - Vector3.forward * 4f;
			Transform transform2 = UnityEngine.Object.Instantiate<Transform>(gameObject3.transform.GetChild(0));
			transform2.parent = gameObject3.transform;
			Vector3 localPosition2 = Vector3.zero + Vector3.right * WPFMonoBehaviour.hudCamera.ScreenToWorldPoint(new Vector3((float)Screen.width * 1.5f, 0f, 0f)).x;
			localPosition2.y = gameObject3.transform.GetChild(0).transform.localPosition.y;
			transform2.transform.localPosition = localPosition2;
			this.m_extraDarkLayerRight = transform2.gameObject;
		}
		this.m_startingCutsceneButton.gameObject.SetActive(GameProgress.GetInt(this.m_startingCutsceneButton.GetComponent<Button>().MethodToCall.GetParameter<string>(0) + "_played", 0, GameProgress.Location.Local, null) == 1);
		bool active = num >= this.m_midCutsceneButtonPage * 15 && this.m_levels.Count > 15 && !string.IsNullOrEmpty(this.MidCutscene) && GameProgress.GetInt(this.m_midCutsceneButton.GetComponent<Button>().MethodToCall.GetParameter<string>(0) + "_played", 0, GameProgress.Location.Local, null) == 1;
		bool active2 = this.m_levels.Count > 15 && !string.IsNullOrEmpty(this.EndingCutscene) && GameProgress.GetInt(this.m_endingCutsceneButton.GetComponent<Button>().MethodToCall.GetParameter<string>(0) + "_played", 0, GameProgress.Location.Local, null) == 1;
		if (this.m_midCutsceneButton)
		{
			this.m_midCutsceneButton.gameObject.SetActive(active);
		}
		if (this.m_endingCutsceneButton)
		{
			this.m_endingCutsceneButton.gameObject.SetActive(active2);
		}
	}

	private void CreatePageDots()
	{
		Vector3 position = -Vector3.up * WPFMonoBehaviour.hudCamera.orthographicSize / 1.25f;
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(new GameObject(), position, Quaternion.identity);
		gameObject.name = "PageDots";
		gameObject.transform.parent = base.transform;
		float num = -(float)this.m_pageCount / 2f * 1.2f;
		for (int i = 0; i < this.m_pageCount; i++)
		{
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.m_pageDot);
			gameObject2.transform.parent = gameObject.transform;
			gameObject2.transform.localPosition = new Vector3(num + (float)i * 1.2f, 0f, -95f);
			gameObject2.name = "Dot" + i + 1;
			PageDot component = gameObject2.GetComponent<PageDot>();
			this.m_dotsList.Add(component);
			if (i == this.m_page)
			{
				this.m_dotsList[i].Enable();
			}
			else
			{
				this.m_dotsList[i].Disable();
			}
		}
	}

	public float UnlockFullVersionButtonX()
	{
		float num = 4f;
		float num2 = (float)Screen.width / (float)Screen.height;
		if (num2 < 1.45f)
		{
			num /= 1.45f / num2;
		}
		float num3 = Mathf.Clamp((float)Screen.width / 7f, (float)(80 * Screen.width) / 1024f, (float)(160 * Screen.height) / 768f);
		Vector2 v = new Vector2(((float)Screen.width - num3 * 4f) / 2f, (float)Screen.height * 0.75f);
		return WPFMonoBehaviour.hudCamera.ScreenToWorldPoint(v).x - num;
	}

	private void LayoutButtons(int activePage)
	{
		int page = this.m_page;
		this.m_page = activePage;
		if (page != this.m_page)
		{
			this.OnPageChanged();
		}
		float num = Mathf.Clamp((float)Screen.width / 7f, (float)(80 * Screen.width) / 1024f, (float)(160 * Screen.height) / 768f);
		Vector2 vector = new Vector2(((float)Screen.width - num * (float)(this.m_buttonGrid.horizontalCount - 1)) / 2f, (float)Screen.height * 0.75f);
		Vector2 vector2 = new Vector2(num, (float)Screen.height * 0.22f);
		int num2 = Screen.width / 4;
		this.m_rightDragLimit = -WPFMonoBehaviour.hudCamera.ScreenToWorldPoint(new Vector3((float)(Screen.width * this.m_pageCount - num2), 0f, 0f)).x;
		this.m_leftDragLimit = -WPFMonoBehaviour.hudCamera.ScreenToWorldPoint(new Vector3((float)num2, 0f, 0f)).x;
		int num3 = Screen.width * this.m_page;
		this.m_buttonGrid.transform.position = new Vector3(-WPFMonoBehaviour.hudCamera.ScreenToWorldPoint(new Vector3((float)(Screen.width / 2 + num3), 0f, 0f)).x, this.m_buttonGrid.transform.localPosition.y, this.m_buttonGrid.transform.localPosition.z);
		for (int i = this.m_buttonGrid.transform.childCount - 1; i >= 0; i--)
		{
			int num4 = i % this.m_levelsPerPage / 5;
			int num5 = i % 5;
			int num6 = i / this.m_levelsPerPage;
			int num7 = Screen.width * num6;
			Button component = this.m_buttonGrid.transform.GetChild(i).GetComponent<Button>();
			Vector3 position = new Vector3(vector.x + (float)num5 * vector2.x + (float)num7 - (float)num3, vector.y - (float)num4 * vector2.y, 20f);
			Vector3 position2 = WPFMonoBehaviour.hudCamera.ScreenToWorldPoint(position);
			if (!GameProgress.GetFullVersionUnlocked() && this.m_episodeLevelsGameDataIndex > 0 && num6 == 0 && num4 == 0)
			{
				position2.z -= 10f;
			}
			component.transform.position = position2;
		}
		for (int j = 0; j < this.m_dotsList.Count; j++)
		{
			if (j == this.m_page)
			{
				this.m_dotsList[j].Enable();
			}
			else
			{
				this.m_dotsList[j].Disable();
			}
		}
		if (this.m_extraDarkLayerRight)
		{
			Vector3 localPosition = this.m_extraDarkLayerRight.transform.localPosition;
			localPosition.x = WPFMonoBehaviour.hudCamera.ScreenToWorldPoint(new Vector3((float)Screen.width * 1.5f, 0f, 0f)).x;
			this.m_extraDarkLayerRight.transform.localPosition = localPosition;
		}
	}

	private void Update()
	{
		if (this.m_currentScreenWidth != Screen.width || this.m_currentScreenHeight != Screen.height)
		{
			this.LayoutButtons(this.m_page);
			this.m_currentScreenWidth = Screen.width;
			this.m_currentScreenHeight = Screen.height;
		}
		if (!this.m_interacting)
		{
			Vector3 a = new Vector3(-WPFMonoBehaviour.hudCamera.ScreenToWorldPoint(new Vector3((float)(Screen.width / 2 + Screen.width * this.m_page), 0f, 0f)).x, this.m_buttonGrid.transform.localPosition.y, this.m_buttonGrid.transform.localPosition.z);
			this.m_buttonGrid.transform.position += (a - this.m_buttonGrid.transform.position) * Time.deltaTime * 4f;
			float magnitude = (a - this.m_buttonGrid.transform.position).magnitude;
			if (magnitude < 1f)
			{
				if (UserSettings.GetInt(Singleton<GameManager>.Instance.CurrentSceneName + "_active_page", -1) != this.m_page)
				{
					UserSettings.SetInt(Singleton<GameManager>.Instance.CurrentSceneName + "_active_page", this.m_page);
				}
				if (!DeviceInfo.UsesTouchInput)
				{
					this.m_rightScroll.SetActive(true);
					this.m_leftScroll.SetActive(true);
				}
			}
			else if (!DeviceInfo.UsesTouchInput)
			{
				this.m_rightScroll.SetActive(false);
				this.m_leftScroll.SetActive(false);
			}
			if (!DeviceInfo.UsesTouchInput)
			{
				if (this.CurrentPage == 0)
				{
					this.m_leftScroll.SetActive(false);
				}
				if (this.CurrentPage == this.m_pageCount || this.m_pageCount == 1)
				{
					this.m_rightScroll.SetActive(false);
				}
			}
		}
		if (this.m_isIapOpen || this.m_isDialogOpen)
		{
			return;
		}
		GuiManager.Pointer pointer = GuiManager.GetPointer();
		if (pointer.down && pointer.widget != this.m_leftScroll.GetComponent<Widget>() && pointer.widget != this.m_rightScroll.GetComponent<Widget>())
		{
			this.m_initialInputPos = pointer.position;
			this.m_lastInputPos = pointer.position;
			this.m_interacting = true;
		}
		if (pointer.dragging && this.m_interacting)
		{
			Vector3 vector = WPFMonoBehaviour.hudCamera.ScreenToWorldPoint(this.m_lastInputPos);
			Vector3 vector2 = WPFMonoBehaviour.hudCamera.ScreenToWorldPoint(pointer.position);
			this.m_lastInputPos = pointer.position;
			float num = vector2.x - vector.x;
			this.m_buttonGrid.transform.localPosition = new Vector3(Mathf.Clamp(this.m_buttonGrid.transform.localPosition.x + num, this.m_rightDragLimit, this.m_leftDragLimit), this.m_buttonGrid.transform.localPosition.y, this.m_buttonGrid.transform.localPosition.z);
			Vector3 vector3 = WPFMonoBehaviour.hudCamera.ScreenToWorldPoint(this.m_initialInputPos);
			if (!DeviceInfo.UsesTouchInput && Mathf.Abs(vector2.x - vector3.x) > 0.2f)
			{
				this.m_rightScroll.SetActive(false);
				this.m_leftScroll.SetActive(false);
			}
			if (Mathf.Abs(vector2.x - vector3.x) > 1f)
			{
				Singleton<GuiManager>.Instance.ResetFocus();
			}
		}
		if (pointer.up && this.m_interacting)
		{
			float num2 = this.m_lastInputPos.x - this.m_initialInputPos.x;
			int page = this.m_page;
			if (num2 < (float)(-(float)Screen.width / 16))
			{
				this.m_page++;
				this.m_page = Mathf.Clamp(this.m_page, 0, this.m_pageCount - 1);
				for (int i = 0; i < this.m_dotsList.Count; i++)
				{
					if (i == this.m_page)
					{
						this.m_dotsList[i].Enable();
					}
					else
					{
						this.m_dotsList[i].Disable();
					}
				}
			}
			else if (num2 > (float)(Screen.width / 16))
			{
				this.m_page--;
				this.m_page = Mathf.Clamp(this.m_page, 0, this.m_pageCount - 1);
				for (int j = 0; j < this.m_dotsList.Count; j++)
				{
					if (j == this.m_page)
					{
						this.m_dotsList[j].Enable();
					}
					else
					{
						this.m_dotsList[j].Disable();
					}
				}
			}
			this.m_page = Mathf.Clamp(this.m_page, 0, this.m_pageCount - 1);
			if (page != this.m_page)
			{
				this.OnPageChanged();
			}
			this.m_interacting = false;
		}
		if (this.m_startingCutsceneButton.gameObject.activeInHierarchy)
		{
			float num3 = 4f;
			float num4 = (float)Screen.width / (float)Screen.height;
			if (num4 < 1.45f)
			{
				num3 /= 1.45f / num4;
			}
			Vector3 position = this.m_buttonGrid.transform.GetChild(0).position - Vector3.right * num3;
			this.m_startingCutsceneButton.position = position;
		}
		if (this.m_midCutsceneButton && this.m_midCutsceneButton.gameObject.activeInHierarchy && this.m_midCutsceneButtonPage * 15 < this.m_buttonGrid.transform.childCount)
		{
			float num5 = 4f;
			float num6 = (float)Screen.width / (float)Screen.height;
			if (num6 < 1.45f)
			{
				num5 /= 1.45f / num6;
			}
			int num7 = this.m_midCutsceneButtonPage * 15;
			Mathf.Clamp(num7, 0, this.m_buttonGrid.transform.childCount - 1);
			Vector3 position2 = this.m_buttonGrid.transform.GetChild(num7).position - Vector3.right * num5;
			this.m_midCutsceneButton.position = position2;
		}
		if (this.m_endingCutsceneButton.gameObject.activeInHierarchy)
		{
			float num8 = 4f;
			float num9 = (float)Screen.width / (float)Screen.height;
			if (num9 < 1.45f)
			{
				num8 /= 1.45f / num9;
			}
			this.m_endingCutsceneButton.position = this.m_buttonGrid.transform.GetChild(this.m_buttonGrid.transform.childCount - 1).position + Vector3.right * num8;
		}
	}

	private bool isInInteractiveArea(Vector2 touchPos)
	{
		return touchPos.y > (float)Screen.height * 0.1f && touchPos.y < (float)Screen.height * 0.8f;
	}

	private void ShowStarEffect()
	{
		base.StartCoroutine(this.PlaySoundEffect());
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.m_starEffect);
		gameObject.transform.position = new Vector3(0f, 0f, -90f);
		gameObject.GetComponent<ParticleSystem>().Play();
	}

	private IEnumerator PlaySoundEffect()
	{
		yield return null;
		Singleton<AudioManager>.Instance.Play2dEffect(Singleton<GameManager>.Instance.gameData.commonAudioCollection.sandboxLevelUnlocked);
		yield break;
	}

	private void UnlockLevel(Button button, int index, bool isJoker)
	{
		button.transform.Find("LevelNumber").GetComponent<TextMesh>().text = LevelSelector.DifferentiatedLevelLabel(index);
		button.transform.Find("Lock").gameObject.SetActive(false);
		button.MethodToCall.SetMethod(base.gameObject.GetComponent<LevelSelector>(), (!isJoker) ? "LoadLevel" : "LoadStarLevel", index.ToString());
		ButtonAnimation component = button.GetComponent<ButtonAnimation>();
		if (component != null)
		{
			component.RemoveInputListener();
		}
		string sceneName = this.Levels[index].sceneName;
		int @int = GameProgress.GetInt(sceneName + "_stars", 0, GameProgress.Location.Local, null);
		bool flag = GameProgress.HasCollectedSnoutCoins(sceneName, 0);
		bool flag2 = GameProgress.HasCollectedSnoutCoins(sceneName, 1);
		bool flag3 = GameProgress.HasCollectedSnoutCoins(sceneName, 2);
		GameObject[] array = new GameObject[]
		{
			button.transform.Find("StarSet/Star1").gameObject,
			button.transform.Find("StarSet/Star2").gameObject,
			button.transform.Find("StarSet/Star3").gameObject,
			button.transform.Find("CoinSet/Star1").gameObject,
			button.transform.Find("CoinSet/Star2").gameObject,
			button.transform.Find("CoinSet/Star3").gameObject
		};
		int num = 0;
		if (flag)
		{
			num++;
		}
		if (flag2)
		{
			num++;
		}
		if (flag3)
		{
			num++;
		}
		for (int i = 0; i < 3; i++)
		{
			bool flag4 = i + 1 <= @int;
			bool flag5 = i + 1 <= num || Singleton<BuildCustomizationLoader>.Instance.IsOdyssey;
			array[i].SetActive(flag4 && !flag5);
			array[i + 3].SetActive(flag4 && flag5);
		}
		if (isJoker)
		{
			GameObject gameObject = button.transform.Find("StarSetsLocked").gameObject;
			gameObject.SetActive(false);
		}
	}

	private void AddUnlockPanel(Button button, int row, int page, int episodeIndex, bool pulse)
	{
		if (WPFMonoBehaviour.gameData.m_levelRowUnlockPanel)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(WPFMonoBehaviour.gameData.m_levelRowUnlockPanel);
			UnlockLevelRowPanel component = gameObject.GetComponent<UnlockLevelRowPanel>();
			gameObject.transform.parent = button.transform;
			float num = Mathf.Abs((WPFMonoBehaviour.hudCamera.ScreenToWorldPoint(Vector3.zero) - WPFMonoBehaviour.hudCamera.ScreenToWorldPoint(new Vector3(this.ButtonXGap, 0f, 0f))).x);
			float x = button.GetComponent<BoxCollider>().size.x;
			float num2 = 16.666666f + x;
			float num3 = num * 4f + x;
			component.BackgroundScale = new Vector2(num3 / num2, 1f);
			float x2 = 2f * num - component.RealSize.x / component.PanelSize.x * (component.PanelSize.x - 25f) / 2f;
			gameObject.transform.localPosition = new Vector3(x2, 0f, 1f);
			string[] levels = new string[]
			{
				LevelInfo.GetLevelNames(episodeIndex)[row * 5],
				LevelInfo.GetLevelNames(episodeIndex)[row * 5 + 1],
				LevelInfo.GetLevelNames(episodeIndex)[row * 5 + 2],
				LevelInfo.GetLevelNames(episodeIndex)[row * 5 + 3],
				LevelInfo.GetLevelNames(episodeIndex)[row * 5 + 4]
			};
			component.UnlockDialog.OnAdFinishedSuccesfully = delegate()
			{
				GameProgress.SetShowRowUnlockStarEffect(episodeIndex, row, true);
				Singleton<GameManager>.Instance.ReloadCurrentLevel(true);
			};
			if (pulse)
			{
				component.PulseButton();
			}
			int cost = Singleton<VirtualCatalogManager>.Instance.GetProductPrice(string.Format("level_row_{0}_unlock", row));
			if (cost <= 0)
			{
				cost = 20 + row * 5;
			}
			component.Page = page;
			component.SetCost(cost);
			GameObject gameObject2 = component.UnlockDialog.transform.Find("PayUnlockBtn").gameObject;
			if (gameObject2 != null)
			{
				Button component2 = gameObject2.GetComponent<Button>();
				component2.enabled = (GameProgress.SnoutCoinCount() >= cost);
				component.Pay += delegate()
				{
					if (!GameProgress.IsLevelAdUnlocked(levels[0]) && GameProgress.UseSnoutCoins(cost))
					{
						GameProgress.SetShowRowUnlockStarEffect(episodeIndex, row, true);
						Singleton<GameManager>.Instance.ReloadCurrentLevel(true);
						EventManager.Connect(new EventManager.OnEvent<LevelLoadedEvent>(this.DelayedPurchaseSound));
					}
				};
			}
			component.UnlockDialog.onOpen += delegate()
			{
				this.m_isDialogOpen = true;
			};
			component.UnlockDialog.onClose += delegate()
			{
				this.m_isDialogOpen = false;
			};
		}
	}

	private void DelayedPurchaseSound(LevelLoadedEvent data)
	{
		EventManager.Disconnect(new EventManager.OnEvent<LevelLoadedEvent>(this.DelayedPurchaseSound));
		Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.snoutCoinUse);
	}

	private void AddLockedPanel(Button button)
	{
		if (WPFMonoBehaviour.gameData.m_lockedLevelRowPanel)
		{
			float num = Mathf.Abs((WPFMonoBehaviour.hudCamera.ScreenToWorldPoint(Vector3.zero) - WPFMonoBehaviour.hudCamera.ScreenToWorldPoint(new Vector3(this.ButtonXGap, 0f, 0f))).x);
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(WPFMonoBehaviour.gameData.m_lockedLevelRowPanel);
			gameObject.transform.parent = button.transform;
			gameObject.transform.localPosition = new Vector3(2f * num, 0f, 1f);
			float x = button.GetComponent<BoxCollider>().size.x;
			float num2 = 16.666666f + x;
			float num3 = num * 4f + x;
			gameObject.transform.localScale = new Vector3(num3 / num2, 1f, 1f);
		}
	}

	private void LockLevel(Button button, int index, bool isJoker, bool isContentLimited, bool isAdUnlocked)
	{
		button.transform.Find("LevelNumber").gameObject.SetActive(false);
		GameObject gameObject = button.transform.Find("StarSet").gameObject;
		gameObject.SetActive(false);
		button.gameObject.AddComponent<InactiveButton>();
		Transform transform = button.transform.Find("CoinSet");
		if (transform != null)
		{
			transform.gameObject.SetActive(false);
		}
		if (isContentLimited)
		{
			button.MethodToCall.SetMethod(base.gameObject.GetComponent<LevelSelector>(), "ShowContentLimitNotification");
		}
		if (isJoker)
		{
			this.UpdateJokerStars(button, index, isAdUnlocked);
		}
	}

	private void UpdateJokerStars(Button jokerButton, int levelIndex, bool isAdUnlocked)
	{
		if (isAdUnlocked)
		{
			int num;
			int num2;
			LevelInfo.GetStarLevelStars(this.EpisodeIndex, levelIndex, out num, out num2);
			TextMesh component = jokerButton.transform.Find("StarSetsLocked/StarsCollected").GetComponent<TextMesh>();
			component.text = string.Concat(new object[]
			{
				string.Empty,
				num,
				"/",
				num2
			});
		}
		else
		{
			jokerButton.transform.Find("StarSet").gameObject.SetActive(false);
			jokerButton.transform.Find("StarSetsLocked").gameObject.SetActive(false);
		}
	}

	public void OpenUnlockFullVersionPurchasePage()
	{
		if (Singleton<BuildCustomizationLoader>.Instance.IAPEnabled)
		{
			this.m_isIapOpen = true;
			Singleton<IapManager>.Instance.EnableUnlockFullVersionPurchasePage();
		}
	}

	public void ShowContentLimitNotification()
	{
		LevelInfo.DisplayContentLimitNotification();
	}

	private void HandleIapManageronPurchaseSucceeded(IapManager.InAppPurchaseItemType type)
	{
	}

	private void OnApplicationPause(bool paused)
	{
		if (paused)
		{
			this.m_interacting = false;
		}
	}

	public GameObject m_levelButtonPrefab;

	public GameObject m_levelJokerButtonPrefab;

	private const int m_levelsPerRow = 5;

	public int m_levelsPerPage = 15;

	[SerializeField]
	private int m_episodeLevelsGameDataIndex;

	[SerializeField]
	private Transform m_startingCutsceneButton;

	[SerializeField]
	private Transform m_midCutsceneButton;

	[SerializeField]
	private int m_midCutsceneButtonPage;

	[SerializeField]
	private Transform m_endingCutsceneButton;

	[SerializeField]
	private GameObject m_leftScroll;

	[SerializeField]
	private GameObject m_rightScroll;

	[SerializeField]
	private GameObject m_comingSoonIcon;

	[SerializeField]
	private GameObject m_pageContentLimitedOverlay;

	[SerializeField]
	private GameObject m_partialPageContentLimitedOverlay;

	[SerializeField]
	private GameObject m_pageDot;

	[SerializeField]
	private GameObject m_starEffect;

	[SerializeField]
	private GameObject m_woodCrate;

	[SerializeField]
	private GameObject m_metalCrate;

	[SerializeField]
	private GameObject m_goldCrate;

	[SerializeField]
	private GameObject m_cardboardCrate;

	[SerializeField]
	private GameObject m_glassCrate;

	[SerializeField]
	private GameObject m_bronzeCrate;

	[SerializeField]
	private GameObject m_marbleCrate;

	public bool m_pageTwoComingSoon;

	public bool m_pageThreeComingSoon;

	public OneTimeCutScene m_oneTimeCutscene;

	private List<EpisodeLevelInfo> m_levels = new List<EpisodeLevelInfo>();

	private List<int> m_starlimitsLevels = new List<int>();

	private List<PageDot> m_dotsList = new List<PageDot>();

	private int m_page;

	private int m_pageCount;

	private Vector2 m_initialInputPos;

	private Vector2 m_lastInputPos;

	private ButtonGrid m_buttonGrid;

	private float m_leftDragLimit;

	private float m_rightDragLimit;

	private bool m_interacting;

	private int m_currentScreenWidth;

	private int m_currentScreenHeight;

	private bool m_isIapOpen;

	private bool m_isDialogOpen;

	private GameObject m_extraDarkLayerRight;

	private static string[] romanNumeralStrings = new string[]
	{
		"I",
		"II",
		"III",
		"IV",
		"V",
		"VI",
		"VII",
		"VIII",
		"IX"
	};

	private bool startedLevelLoading;

	[Serializable]
	public class OneTimeCutScene
	{
		public bool enabled;

		public string cutScene;

		public string saveId;
	}
}
