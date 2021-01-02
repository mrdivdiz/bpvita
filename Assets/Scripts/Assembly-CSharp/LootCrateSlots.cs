using System;
using System.Collections.Generic;
using UnityEngine;

public class LootCrateSlots : MonoBehaviour
{
	public static int SlotsAvailable { get; private set; }

	private void Awake()
	{
		LootCrateSlots.instance = this;
		List<LootCrateSlot> list = new List<LootCrateSlot>();
		for (int i = 0; i < this.slotCount; i++)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.lootCrateSlotPrefab);
			if (gameObject != null)
			{
				gameObject.name = string.Format("Slot{0}", i + 1);
				gameObject.transform.parent = base.transform;
				LootCrateSlot component = gameObject.GetComponent<LootCrateSlot>();
				component.Initialize(false, i, LootCrateType.None);
				list.Add(component);
			}
		}
		this.slots = list.ToArray();
		LootCrateSlots.SlotsAvailable = this.slots.Length;
		GridLayout component2 = base.GetComponent<GridLayout>();
		component2.UpdateLayout();
		if (this.slotsFullBubble != null)
		{
			this.slotsFullBubble.transform.position = this.slots[this.slotCount - 1].transform.position;
		}
		this.ShowFullBubble(LootCrateSlots.AreSlotsFull());
		if (LootCrateSlots.overflowCrateType != LootCrateType.None)
		{
			LootCrateType crateType = LootCrateSlots.overflowCrateType;
			this.unlockCrateSlotDialog = this.ShowNoFreeSlotsDialog(crateType, delegate
			{
				if (this.unlockCrateSlotDialog != null && GameProgress.UseSnoutCoins(this.unlockCrateSlotDialog.SnoutCoinPrice))
				{
					Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.snoutCoinUse);
					LootCrate.SpawnLootCrateOpeningDialog(crateType, 1, WPFMonoBehaviour.hudCamera, null, new LootCrate.AnalyticData("CakeRaceOverflowUnlock", this.unlockCrateSlotDialog.SnoutCoinPrice.ToString(), LootCrate.AdWatched.NotApplicaple));
					this.SendLootCrateUnlockedFlurryEvent(crateType, this.unlockCrateSlotDialog.SnoutCoinPrice, "overflow");
				}
			});
			LootCrateSlots.overflowCrateType = LootCrateType.None;
		}
	}

	private void OnDestroy()
	{
		LootCrateSlots.instance = null;
	}

	public bool IsPopUpOpen()
	{
		return this.unlockCrateSlotDialog != null;
	}

	public void ShowFullBubble(bool show)
	{
		if (this.slotsFullBubble != null)
		{
			this.slotsFullBubble.SetActive(show);
		}
	}

	public static GameObject GetCratePrefab(LootCrateType crateType)
	{
		GameObject[] array = WPFMonoBehaviour.gameData.m_lootCrateLargeIcons.ToArray();
		if (crateType >= LootCrateType.Wood && crateType < (LootCrateType)array.Length)
		{
			return array[(int)crateType];
		}
		return null;
	}

	public void ShowUnlockDialog(LootCrateType crateType, int price, int timeLeft, TextDialog.OnConfirm onConfirm, UnlockLootCrateSlotDialog.UnlockType unlockType)
	{
		if (Singleton<BuildCustomizationLoader>.Instance.IsOdyssey)
		{
			return;
		}
		if (this.unlockCrateSlotDialogPrefab == null)
		{
			return;
		}
		if (this.unlockCrateSlotDialog == null)
		{
			this.unlockCrateSlotDialog = UnityEngine.Object.Instantiate<GameObject>(this.unlockCrateSlotDialogPrefab).GetComponent<UnlockLootCrateSlotDialog>();
		}
		this.unlockCrateSlotDialog.Open();
		this.unlockCrateSlotDialog.SetInfoLabel(unlockType);
		this.unlockCrateSlotDialog.SetOnConfirm(onConfirm);
		this.unlockCrateSlotDialog.InitPopup(price, timeLeft, LootCrateSlots.GetCratePrefab(crateType), crateType);
	}

	public UnlockLootCrateSlotDialog ShowNoFreeSlotsDialog(LootCrateType crateType, TextDialog.OnConfirm onConfirm)
	{
		if (WPFMonoBehaviour.gameData.m_noFreeCrateSlotsPopup == null)
		{
			return null;
		}
		UnlockLootCrateSlotDialog component = UnityEngine.Object.Instantiate<GameObject>(WPFMonoBehaviour.gameData.m_noFreeCrateSlotsPopup).GetComponent<UnlockLootCrateSlotDialog>();
		component.Open();
		component.SetOnConfirm(onConfirm);
		int openTimeForCrate = LootCrateSlots.GetOpenTimeForCrate(crateType);
		component.InitPopup(LootCrateSlot.GetSnoutCoinPrice(crateType, (float)openTimeForCrate), openTimeForCrate, LootCrateSlots.GetCratePrefab(crateType), crateType);
		return component;
	}

	public static bool AreSlotsFull()
	{
		for (int i = 0; i < LootCrateSlots.SlotsAvailable; i++)
		{
			if (!LootCrateSlots.IsSlotOccupied(i))
			{
				return false;
			}
		}
		return true;
	}

	public static void AddLootCrateToFreeSlot(LootCrateType crateType)
	{
		for (int i = 0; i < LootCrateSlots.SlotsAvailable; i++)
		{
			if (!LootCrateSlots.IsSlotOccupied(i))
			{
				LootCrateSlots.AddLootCrateToSlot(i, crateType);
				int num = GameProgress.GetInt("loot_crates_added_to_slots", 0, GameProgress.Location.Local, null);
				GameProgress.SetInt("loot_crates_added_to_slots", ++num, GameProgress.Location.Local);
				if (LootCrateSlots.instance != null)
				{
					LootCrateSlots.instance.ShowFullBubble(LootCrateSlots.AreSlotsFull());
				}
				return;
			}
		}
		LootCrateSlots.overflowCrateType = crateType;
	}

	public static void AddLootCrateToSlot(int index, LootCrateType crateType)
	{
		string slotIdentifier = LootCrateSlot.GetSlotIdentifier(index);
		GameProgress.SetString(slotIdentifier, string.Format("{0},{1},{2}", LootCrateSlot.State.Inactive.ToString(), crateType.ToString(), "new"), GameProgress.Location.Local);
	}

	public static int TryToActivateLootCrateAtSlot(int index, LootCrateType crateType, OnTimedOut onCrateUnlocked)
	{
		if (LootCrateSlots.IsUnlockingInProgress())
		{
			return -1;
		}
		string slotIdentifier = LootCrateSlot.GetSlotIdentifier(index);
		GameProgress.SetString(slotIdentifier, string.Format("{0},{1}", LootCrateSlot.State.Locked.ToString(), crateType.ToString()), GameProgress.Location.Local);
		if (!Singleton<TimeManager>.Instance.HasTimer(slotIdentifier))
		{
			DateTime time = Singleton<TimeManager>.Instance.CurrentTime.AddSeconds((double)LootCrateSlots.GetOpenTimeForCrate(crateType));
			Singleton<TimeManager>.Instance.CreateTimer(slotIdentifier, time, onCrateUnlocked);
			GameProgress.SetString("LootCrateSlotOpening", slotIdentifier, GameProgress.Location.Local);
			if (LootCrateSlots.instance != null)
			{
				LootCrateSlots.instance.ShowFullBubble(LootCrateSlots.AreSlotsFull());
			}
			return 0;
		}
		return 1;
	}

	public static bool IsUnlockingInProgress()
	{
		return GameProgress.HasKey("LootCrateSlotOpening", GameProgress.Location.Local, null);
	}

	public static void InformCrateUnlocked(string identifier, LootCrateType crateType, int snoutCoinCost = 0)
	{
		if (GameProgress.GetString("LootCrateSlotOpening", string.Empty, GameProgress.Location.Local, null).Equals(identifier))
		{
			GameProgress.DeleteKey("LootCrateSlotOpening", GameProgress.Location.Local);
		}
		if (LootCrateSlots.instance != null)
		{
			LootCrateSlots.instance.SendLootCrateUnlockedFlurryEvent(crateType, snoutCoinCost, "default");
		}
	}

	private void SendLootCrateUnlockedFlurryEvent(LootCrateType crateType, int snoutCoinCost, string unlockType)
	{
		int num = GameProgress.GetInt("loot_crates_unlocked_from_slots", 0, GameProgress.Location.Local, null);
		GameProgress.SetInt("loot_crates_unlocked_from_slots", ++num, GameProgress.Location.Local);
	}

	public static void InformCrateOpened(string identifier, LootCrateType crateType)
	{
		if (LootCrateSlots.instance != null)
		{
			LootCrateSlots.instance.ShowFullBubble(LootCrateSlots.AreSlotsFull());
		}
	}

	public static int GetOpenTimeForCrate(LootCrateType crateType)
	{
		string valueKey = crateType.ToString();
		if (Singleton<GameConfigurationManager>.Instance.HasValue("lootcrate_open_times", valueKey))
		{
			int value = Singleton<GameConfigurationManager>.Instance.GetValue<int>("lootcrate_open_times", valueKey);
			if (value > 0)
			{
				return value;
			}
		}
		switch (crateType)
		{
		case LootCrateType.Wood:
			return LootCrateSlots.HoursToSeconds(8f);
		case LootCrateType.Metal:
			return LootCrateSlots.HoursToSeconds(24f);
		case LootCrateType.Gold:
			return LootCrateSlots.HoursToSeconds(48f);
		case LootCrateType.Cardboard:
			return LootCrateSlots.HoursToSeconds(2f);
		case LootCrateType.Glass:
			return LootCrateSlots.HoursToSeconds(4f);
		case LootCrateType.Bronze:
			return LootCrateSlots.HoursToSeconds(16f);
		case LootCrateType.Marble:
			return LootCrateSlots.HoursToSeconds(28f);
		default:
			return LootCrateSlots.HoursToSeconds(72f);
		}
	}

	private static int HoursToSeconds(float hours)
	{
		return Mathf.FloorToInt(3600f * hours);
	}

	private static bool IsSlotOccupied(int index)
	{
		string slotIdentifier = LootCrateSlot.GetSlotIdentifier(index);
		return GameProgress.HasKey(slotIdentifier, GameProgress.Location.Local, null);
	}

	[SerializeField]
	private GameObject lootCrateSlotPrefab;

	[SerializeField]
	private int slotCount = 4;

	[SerializeField]
	private GameObject unlockCrateSlotDialogPrefab;

	[SerializeField]
	private GameObject slotsFullBubble;

	private UnlockLootCrateSlotDialog unlockCrateSlotDialog;

	private LootCrateSlot[] slots;

	private static LootCrateType overflowCrateType = LootCrateType.None;

	private static LootCrateSlots instance;

	private const string CONFIG_LOOTCRATE_OPENING_TIME_KEY = "lootcrate_open_times";

	private const string CURRENT_OPENING_SLOT_IDENTIFIER = "LootCrateSlotOpening";
}
