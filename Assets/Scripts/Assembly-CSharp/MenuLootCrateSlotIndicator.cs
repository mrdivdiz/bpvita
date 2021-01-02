using System;
using UnityEngine;

public class MenuLootCrateSlotIndicator : MonoBehaviour
{
	private void Awake()
	{
		this.shine.SetActive(false);
	}

	private void Start()
	{
		if (Singleton<TimeManager>.IsInstantiated() && Singleton<TimeManager>.Instance.Initialized)
		{
			this.Check();
		}
		else
		{
			Singleton<TimeManager>.Instance.OnInitialize += this.Check;
		}
	}

	private void OnDestroy()
	{
		base.StopAllCoroutines();
	}

	private void Check()
	{
		int num;
		if (this.AnyLootCrateCollectible(out num))
		{
			this.SpawnCrateIcon(this.GetLootCrateType(num));
		}
		else if (this.FindNextUnlock(out num))
		{
			this.SetTimer(num);
		}
	}

	private bool AnyLootCrateCollectible(out int index)
	{
		index = -1;
		for (int i = 0; i < this.slotCount; i++)
		{
			string slotIdentifier = LootCrateSlot.GetSlotIdentifier(i);
			if (GameProgress.HasKey(slotIdentifier, GameProgress.Location.Local, null))
			{
				string[] array = GameProgress.GetString(slotIdentifier, string.Empty, GameProgress.Location.Local, null).Split(new char[]
				{
					','
				});
				if (array.Length > 0 && array[0] == "Unlocked")
				{
					index = i;
					return true;
				}
				if (Singleton<TimeManager>.Instance.HasTimer(slotIdentifier) && Singleton<TimeManager>.Instance.TimeLeft(slotIdentifier) <= 0f)
				{
					index = i;
					return true;
				}
			}
		}
		return false;
	}

	private LootCrateType GetLootCrateType(int index)
	{
		string slotIdentifier = LootCrateSlot.GetSlotIdentifier(index);
		string[] array = GameProgress.GetString(slotIdentifier, string.Empty, GameProgress.Location.Local, null).Split(new char[]
		{
			','
		});
		return (LootCrateType)Enum.Parse(typeof(LootCrateType), array[1], true);
	}

	private bool FindNextUnlock(out int index)
	{
		index = -1;
		float num = float.MaxValue;
		for (int i = 0; i < this.slotCount; i++)
		{
			string slotIdentifier = LootCrateSlot.GetSlotIdentifier(i);
			if (Singleton<TimeManager>.Instance.HasTimer(slotIdentifier) && Singleton<TimeManager>.Instance.TimeLeft(slotIdentifier) < num)
			{
				index = i;
				num = Singleton<TimeManager>.Instance.TimeLeft(slotIdentifier);
			}
		}
		return index >= 0;
	}

	private void SetTimer(int index)
	{
		string slotIdentifier = LootCrateSlot.GetSlotIdentifier(index);
		if (Singleton<TimeManager>.Instance.HasTimer(slotIdentifier))
		{
			float seconds = Singleton<TimeManager>.Instance.TimeLeft(slotIdentifier);
			base.StartCoroutine(CoroutineRunner.DelayActionSequence(new Action(this.Check), seconds, true));
		}
	}

	private void SpawnCrateIcon(LootCrateType type)
	{
		GameObject go = LootCrateGraphicSpawner.CreateCrateSilhouette(type, base.transform, Vector3.zero, Vector3.one, Quaternion.identity);
		LayerHelper.SetLayer(go, base.gameObject.layer, true);
		GameObject go2 = LootCrateGraphicSpawner.CreateCrateSmall(type, base.transform, Vector3.back * 0.1f, Vector3.one, Quaternion.identity);
		LayerHelper.SetLayer(go2, base.gameObject.layer, true);
		this.shine.SetActive(true);
	}

	[SerializeField]
	private GameObject shine;

	[SerializeField]
	private int slotCount;
}
