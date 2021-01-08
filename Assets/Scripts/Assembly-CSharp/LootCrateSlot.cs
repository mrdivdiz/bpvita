using System;
using Spine.Unity;
using UnityEngine;

public class LootCrateSlot : WPFMonoBehaviour
{
	private void FindComponents()
	{
		if (this.areComponentsSet)
		{
			return;
		}
		this.lootCrateSlots = base.transform.parent.GetComponent<LootCrateSlots>();
		this.priceTf = this.activeTf.Find("Price");
		this.timeTf = this.activeTf.Find("Time");
		this.crateHolder = this.activeTf.Find("Crate");
		Transform transform = this.priceTf.Find("Label");
		if (transform != null)
		{
			this.priceLabel = transform.GetComponentsInChildren<TextMesh>();
		}
		transform = this.timeTf.Find("Label");
		if (transform != null)
		{
			this.timeLabel = transform.GetComponentsInChildren<TextMesh>();
		}
		transform = this.activeTf.Find("Info");
		if (transform != null)
		{
			this.activeInfoLabel = transform.GetComponentsInChildren<TextMesh>();
		}
		transform = this.timeTf.Find("Lock");
		if (transform != null)
		{
			this.lockIcon = transform.GetComponent<Renderer>();
		}
		transform = this.timeTf.Find("Clock");
		if (transform != null)
		{
			this.clockIcon = transform.GetComponent<Renderer>();
		}
		this.areComponentsSet = true;
		this.ChangeState(LootCrateSlot.State.Empty);
	}

	private void OnDestroy()
	{
		if (Singleton<TimeManager>.IsInstantiated() && Singleton<TimeManager>.Instance.HasTimer(this.identifier))
		{
			Singleton<TimeManager>.Instance.Unsubscribe(this.identifier, new OnTimedOut(this.OnCrateUnlocked));
		}
	}

	private void ChangeState(State newState)
	{
		this.state = newState;
		if (this.state == LootCrateSlot.State.Empty)
		{
			this.crateType = LootCrateType.None;
		}
		this.activeTf.gameObject.SetActive(this.state != LootCrateSlot.State.Empty);
		this.emptyTf.gameObject.SetActive(this.state == LootCrateSlot.State.Empty);
		this.unlockedTf.gameObject.SetActive(this.state == LootCrateSlot.State.Unlocked);
		this.priceTf.gameObject.SetActive(this.state == LootCrateSlot.State.Locked);
		this.timeTf.gameObject.SetActive(this.state != LootCrateSlot.State.Unlocked);
		this.lockIcon.enabled = (this.state == LootCrateSlot.State.Inactive);
		this.clockIcon.enabled = (this.state == LootCrateSlot.State.Locked);
		bool flag = this.state == LootCrateSlot.State.Unlocked || this.state == LootCrateSlot.State.Inactive;
		this.crateHolder.transform.localScale = Vector3.one * ((!flag) ? 1f : 1.2f);
		this.crateHolder.transform.localPosition = Vector3.up * ((!flag) ? 0.1f : 0f);
		if (this.crateType != LootCrateType.None && this.crateHolder.childCount == 0 && this.state != LootCrateSlot.State.Empty)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(LootCrateSlots.GetCratePrefab(this.crateType));
			gameObject.transform.parent = this.crateHolder;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localScale = Vector3.one;
			gameObject.transform.localRotation = Quaternion.identity;
		}
		else if (this.crateHolder.childCount > 0 && this.state == LootCrateSlot.State.Empty)
		{
			for (int i = 0; i < this.crateHolder.childCount; i++)
			{
				Transform child = this.crateHolder.GetChild(i);
				if (child)
				{
					UnityEngine.Object.Destroy(child.gameObject);
				}
			}
		}
		if (this.state == LootCrateSlot.State.Locked)
		{
			Localizer.LocaleParameters localeParameters = Singleton<Localizer>.Instance.Resolve(this.openNowLocalization, null);
			TextMeshHelper.UpdateTextMeshes(this.activeInfoLabel, localeParameters.translation, false);
			TextMeshHelper.Wrap(this.activeInfoLabel, (!TextMeshHelper.UsesKanjiCharacters()) ? 8 : 4);
		}
		else
		{
			TextMeshHelper.UpdateTextMeshes(this.activeInfoLabel, string.Empty, false);
		}
		this.UpdateLabels();
	}

	private void Update()
	{
		if (this.nextLabelUpdateTime <= Time.realtimeSinceStartup)
		{
			this.nextLabelUpdateTime = Time.realtimeSinceStartup + 60f;
			this.UpdateLabels();
		}
	}

	private void UpdateLabels()
	{
		string formattedTimeFromSeconds = LootCrateSlot.GetFormattedTimeFromSeconds((int)this.TimeLeftInSeconds());
		this.nextLabelUpdateTime = Time.realtimeSinceStartup + 1f;
		TextMeshHelper.UpdateTextMeshes(this.timeLabel, formattedTimeFromSeconds, false);
		TextMeshHelper.UpdateTextMeshes(this.priceLabel, string.Format("{0} [snout]", LootCrateSlot.GetSnoutCoinPrice(this.crateType, this.TimeLeftInSeconds())), false);
		TextMeshSpriteIcons[] componentsInChildren = this.priceTf.GetComponentsInChildren<TextMeshSpriteIcons>();
		if (componentsInChildren != null)
		{
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].UpdateIcons();
			}
		}
	}

	public static string GetFormattedTimeFromSeconds(int timeLeft)
	{
		int num = Mathf.FloorToInt((float)timeLeft / 3600f);
		int num2 = Mathf.FloorToInt((float)timeLeft % 3600f / 60f);
		int num3 = Mathf.FloorToInt((float)timeLeft % 60f);
		string result = string.Empty;
		if (num > 0 && num2 > 0)
		{
			result = string.Format("{0}h {1}m", num, num2);
		}
		else if (num > 0)
		{
			result = string.Format("{0}h", num);
		}
		else if (num2 > 0 && num3 > 0)
		{
			result = string.Format("{0}m {1}s", num2, num3);
		}
		else if (num2 > 0)
		{
			result = string.Format("{0}m", num2);
		}
		else
		{
			result = string.Format("{0}s", num3);
		}
		return result;
	}

	private float TimeLeftInSeconds()
	{
		if (!string.IsNullOrEmpty(this.identifier) && Singleton<TimeManager>.Instance.HasTimer(this.identifier))
		{
			return Mathf.Clamp(Singleton<TimeManager>.Instance.TimeLeft(this.identifier), 0f, float.MaxValue);
		}
		if (this.state == LootCrateSlot.State.Inactive)
		{
			return (float)LootCrateSlots.GetOpenTimeForCrate(this.crateType);
		}
		return 0f;
	}

	public bool IsOccupied()
	{
		return this.state != LootCrateSlot.State.Empty;
	}

	public void Initialize(bool isNew, int index, LootCrateType crateType)
	{
		this.FindComponents();
		this.index = index;
		this.crateType = crateType;
		this.identifier = LootCrateSlot.GetSlotIdentifier(index);
		this.hasTimer = false;
		if (isNew)
		{
			LootCrateSlots.AddLootCrateToSlot(index, crateType);
			this.ChangeState(LootCrateSlot.State.Inactive);
		}
		else
		{
			this.TryRecover();
		}
	}

	private void TryRecover()
	{
		string[] array = GameProgress.GetString(this.identifier, string.Empty, GameProgress.Location.Local, null).Split(new char[]
		{
			','
		});
		if (array != null && array.Length >= 2 && this.UpdateSlotFromString(array) && this.state == LootCrateSlot.State.Empty)
		{
			GameProgress.DeleteKey(this.identifier, GameProgress.Location.Local);
			return;
		}
		if (!Singleton<TimeManager>.Instance.Initialized)
		{
			Singleton<TimeManager>.Instance.OnInitialize += this.UpdateTimer;
		}
		else
		{
			this.UpdateTimer();
		}
	}

	private void UpdateTimer()
	{
		Singleton<TimeManager>.Instance.OnInitialize -= this.UpdateTimer;
		this.hasTimer = Singleton<TimeManager>.Instance.HasTimer(this.identifier);
		if (this.hasTimer)
		{
			Singleton<TimeManager>.Instance.Subscribe(this.identifier, new OnTimedOut(this.OnCrateUnlocked));
			GameProgress.SetString(this.identifier, string.Format("{0},{1}", LootCrateSlot.State.Locked.ToString(), this.crateType.ToString()), GameProgress.Location.Local);
			this.ChangeState(LootCrateSlot.State.Locked);
		}
	}

	public void OpenCrate()
	{
		if (Singleton<TimeManager>.Instance.HasTimer(this.identifier))
		{
			Singleton<TimeManager>.Instance.RemoveTimer(this.identifier);
		}
		GameProgress.DeleteKey(this.identifier, GameProgress.Location.Local);
		LootCrate.SpawnLootCrateOpeningDialog(this.crateType, 1, WPFMonoBehaviour.s_hudCamera, null, new LootCrate.AnalyticData("Slot", this.unlockPrice.ToString(), LootCrate.AdWatched.NotApplicaple));
		this.ChangeState(LootCrateSlot.State.Empty);
		LootCrateSlots.InformCrateOpened(this.identifier, this.crateType);
	}

	private void OnCrateUnlocked(int secondsSinceDone)
	{
		if (GameProgress.HasKey(this.identifier, GameProgress.Location.Local, null))
		{
			GameProgress.SetString(this.identifier, string.Format("{0},{1}", LootCrateSlot.State.Unlocked.ToString(), this.crateType.ToString()), GameProgress.Location.Local);
			this.ChangeState(LootCrateSlot.State.Unlocked);
		}
		LootCrateSlots.InformCrateUnlocked(this.identifier, this.crateType, this.unlockPrice);
	}

	private bool UpdateSlotFromString(string[] data)
	{
		try
		{
			this.crateType = (LootCrateType)Enum.Parse(typeof(LootCrateType), data[1], true);
		}
		catch
		{
			this.crateType = LootCrateType.None;
		}
        State newState = LootCrateSlot.State.Empty;
		try
		{
			newState = (State)Enum.Parse(typeof(State), data[0], true);
		}
		catch
		{
			newState = LootCrateSlot.State.Empty;
		}
		if (data.Length > 2 && data[2] == "new")
		{
			this.AppearAnimation();
			GameProgress.SetString(this.identifier, string.Format("{0},{1}", data[0], data[1]), GameProgress.Location.Local);
		}
		if (this.crateType == LootCrateType.None)
		{
			newState = LootCrateSlot.State.Empty;
		}
		this.ChangeState(newState);
		return true;
	}

	public static int GetSnoutCoinPrice(LootCrateType crateType, float timeLeft)
	{
		string valueKey = crateType.ToString();
		int num = 0;
		if (Singleton<GameConfigurationManager>.Instance.HasValue("lootcrate_open_hour_rates", valueKey))
		{
			num = Singleton<GameConfigurationManager>.Instance.GetValue<int>("lootcrate_open_hour_rates", valueKey);
		}
		if (num <= 0)
		{
			num = 15;
		}
		return (int)Mathf.Clamp((float)num * (timeLeft / 3600f), 2f, 9999f);
	}

	public void OnSlotPressed()
	{
		if (Singleton<TimeManager>.Instance.CurrentEpochTime == 0)
		{
			return;
		}
		UnityEngine.Debug.LogWarning(string.Concat(new string[]
		{
			"[OnSlotPressed] ",
			this.index.ToString(),
			": state(",
			this.state.ToString(),
			")"
		}));
		if (this.state == LootCrateSlot.State.Inactive)
		{
			if (LootCrateSlots.IsUnlockingInProgress())
			{
				this.ShowPurchasePopup(UnlockLootCrateSlotDialog.UnlockType.PurchaseInactiveCrate);
			}
			else
			{
				this.ShowPurchasePopup(UnlockLootCrateSlotDialog.UnlockType.StartUnlocking);
			}
		}
		else if (this.state == LootCrateSlot.State.Locked)
		{
			this.ShowPurchasePopup(UnlockLootCrateSlotDialog.UnlockType.PurchaseLockedCrate);
		}
		else if (this.state == LootCrateSlot.State.Unlocked)
		{
			this.OpenCrate();
		}
	}

	private void ShowPurchasePopup(UnlockLootCrateSlotDialog.UnlockType unlockType)
	{
		this.unlockPrice = 0;
		int snoutPrice = LootCrateSlot.GetSnoutCoinPrice(this.crateType, this.TimeLeftInSeconds());
		this.lootCrateSlots.ShowUnlockDialog(this.crateType, snoutPrice, (int)this.TimeLeftInSeconds(), delegate
		{
			if (unlockType == UnlockLootCrateSlotDialog.UnlockType.StartUnlocking)
			{
				this.ActivateLootCrateSlot();
			}
			else if (GameProgress.UseSnoutCoins(snoutPrice))
			{
				this.unlockPrice = snoutPrice;
				Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.snoutCoinUse);
				SnoutButton.Instance.UpdateAmount(false);
				this.OnCrateUnlocked(0);
				this.OpenCrate();
			}
		}, unlockType);
	}

	private void ActivateLootCrateSlot()
	{
		int num = LootCrateSlots.TryToActivateLootCrateAtSlot(this.index, this.crateType, new OnTimedOut(this.OnCrateUnlocked));
		if (num != -1)
		{
			if (num != 0)
			{
				if (num == 1)
				{
					this.UpdateTimer();
				}
			}
			else
			{
				this.ChangeState(LootCrateSlot.State.Locked);
			}
		}
	}

	public static string GetSlotIdentifier(int index)
	{
		return string.Format("LootCrateSlot_{0}", index);
	}

	private void AppearAnimation()
	{
		this.skeletonAnimation.transform.parent = base.transform.parent;
		base.transform.parent = this.animationTf;
		this.skeletonAnimation.state.AddAnimation(0, "Intro1", false, 0f);
		this.skeletonAnimation.state.Update(Time.deltaTime);
	}

	[SerializeField]
	private string openNowLocalization;

	[SerializeField]
	private Transform activeTf;

	[SerializeField]
	private Transform emptyTf;

	[SerializeField]
	private Transform unlockedTf;

	[SerializeField]
	private Transform animationTf;

	[SerializeField]
	private SkeletonAnimation skeletonAnimation;

	private Transform priceTf;

	private Transform timeTf;

	private Transform crateHolder;

	private Renderer lockIcon;

	private Renderer clockIcon;

	private TextMesh[] timeLabel;

	private TextMesh[] priceLabel;

	private TextMesh[] activeInfoLabel;

	private State state;

	private LootCrateType crateType = LootCrateType.None;

	private int index;

	private string identifier;

	private int unlockPrice;

	private LootCrateSlots lootCrateSlots;

	private float nextLabelUpdateTime;

	private bool areComponentsSet;

	private bool hasTimer;

	private const string CONFIG_LOOTCRATE_OPENING_RATES = "lootcrate_open_hour_rates";

	public enum State
	{
		Empty,
		Inactive,
		Locked,
		Unlocked
	}
}
