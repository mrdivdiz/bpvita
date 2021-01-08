using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static class LootCrateRewards
{
	static LootCrateRewards()
	{
		SecureJsonManager secureJsonManager = LootCrateRewards.secureJson;
		secureJsonManager.Initialize(new Action<string>(LootCrateRewards.Initialize));
	}

	public static bool Initialized
	{
		get
		{
			return LootCrateRewards.initialized;
		}
	}

	private static Dictionary<LootCrateType, List<Slot>> Slots
	{
		get
		{
			if (LootCrateRewards.slots == null)
			{
				LootCrateRewards.slots = new Dictionary<LootCrateType, List<Slot>>();
				int num = Enum.GetNames(typeof(LootCrateType)).Length - 1;
				for (int i = 0; i < num; i++)
				{
					LootCrateType key = (LootCrateType)i;
					LootCrateRewards.slots.Add(key, new List<Slot>());
				}
			}
			return LootCrateRewards.slots;
		}
		set
		{
			LootCrateRewards.slots = value;
		}
	}

	private static void Initialize(string rawData)
	{
		Hashtable hashtable = MiniJSON.jsonDecode(rawData) as Hashtable;
		ArrayList arrayList = hashtable["data"] as ArrayList;
		int num = Enum.GetNames(typeof(LootCrateType)).Length - 1;
		IEnumerator enumerator = arrayList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Hashtable data = (Hashtable)obj;
                Slot slot = new Slot(data);
				for (int i = 0; i < num; i++)
				{
					LootCrateType lootCrateType = (LootCrateType)i;
					if (slot.ForLootCrate(lootCrateType))
					{
						LootCrateRewards.Slots[lootCrateType].Add(slot);
					}
				}
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
		LootCrateRewards.initialized = true;
	}

	public static SlotRewards[] GetRandomRewards(LootCrateType type)
	{
		if (type == LootCrateType.None)
		{
			return null;
		}
        SlotRewards[] array = new SlotRewards[LootCrateRewards.Slots[type].Count];
		for (int i = 0; i < LootCrateRewards.Slots[type].Count; i++)
		{
			array[i] = LootCrateRewards.Slots[type][i].GetRewards();
		}
		return array;
	}

	public static List<Tuple<Reward, BasePart.PartTier>> MinimumRewards(LootCrateType type)
	{
		List<Tuple<Reward, BasePart.PartTier>> list = new List<Tuple<Reward, BasePart.PartTier>>();
		if (!LootCrateRewards.initialized)
		{
			return list;
		}
		List<Slot> list2 = LootCrateRewards.slots[type];
		for (int i = 0; i < list2.Count; i++)
		{
			list.Add(list2[i].MinimumReward());
		}
		list.Sort(new RewardSorter<Tuple<Reward, BasePart.PartTier>>());
		return list;
	}

	private static bool initialized;

	private static Dictionary<LootCrateType, List<Slot>> slots;

	private static SecureJsonManager secureJson = new SecureJsonManager("lootcraterewards");

	public enum Powerup
	{
		None,
		Magnet,
		Superglue,
		Turbo,
		Supermechanic,
		NightVision
	}

	public enum Reward
	{
		None,
		Part,
		Powerup,
		Dessert,
		Scrap,
		Coin
	}

	private class RewardSorter<T> : IComparer<T> where T : Tuple<Reward, BasePart.PartTier>
	{
		public int Compare(T x, T y)
		{
			if (x.Item1 == LootCrateRewards.Reward.Part && y.Item1 != LootCrateRewards.Reward.Part)
			{
				return -1;
			}
			if (y.Item1 == LootCrateRewards.Reward.Part && x.Item1 != LootCrateRewards.Reward.Part)
			{
				return 1;
			}
			if (x.Item1 == y.Item1 && x.Item1 == LootCrateRewards.Reward.Part)
			{
				return y.Item2 - x.Item2;
			}
			return 0;
		}
	}

	public struct SlotRewards
	{
		public SlotRewards(Reward type, int value)
		{
			this.type = type;
			this.value = value;
		}

		public Reward Type
		{
			get
			{
				return this.type;
			}
		}

		public BasePart.PartTier PartTier
		{
			get
			{
				return (BasePart.PartTier)((this.type != LootCrateRewards.Reward.Part) ? 0 : this.value);
			}
		}

		public Powerup Powerup
		{
			get
			{
				return (Powerup)((this.type != LootCrateRewards.Reward.Powerup) ? 0 : this.value);
			}
		}

		public int Desserts
		{
			get
			{
				return (this.type != LootCrateRewards.Reward.Dessert) ? 0 : this.value;
			}
		}

		public int Scrap
		{
			get
			{
				return (this.type != LootCrateRewards.Reward.Scrap) ? 0 : this.value;
			}
		}

		public int Coins
		{
			get
			{
				return (this.type != LootCrateRewards.Reward.Coin) ? 0 : this.value;
			}
		}

		public bool GoldenCupcake
		{
			get
			{
				return this.type == LootCrateRewards.Reward.Dessert && this.value == 0;
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Reward type: ");
			stringBuilder.Append(this.type);
			stringBuilder.Append("\n");
			switch (this.type)
			{
			case LootCrateRewards.Reward.Part:
				stringBuilder.Append("Part tier: ");
				stringBuilder.Append(this.PartTier);
				break;
			case LootCrateRewards.Reward.Powerup:
				stringBuilder.Append("Powerup type: ");
				stringBuilder.Append(this.Powerup);
				break;
			case LootCrateRewards.Reward.Dessert:
				stringBuilder.Append("Dessert count: ");
				stringBuilder.Append(this.Desserts);
				break;
			case LootCrateRewards.Reward.Scrap:
				stringBuilder.Append("Scrap count: ");
				stringBuilder.Append(this.Scrap);
				break;
			case LootCrateRewards.Reward.Coin:
				stringBuilder.Append("Coin amount: ");
				stringBuilder.Append(this.Coins);
				break;
			}
			return stringBuilder.ToString();
		}

		private Reward type;

		private int value;
	}

	private class Slot
	{
		public Slot(Hashtable data)
		{
			this.chances = new List<Tuple<Reward, int>>();
			this.noDessertChances = new List<Tuple<Reward, int>>();
			int num = Convert.ToInt32(data["PartChance"]);
			int num2 = Convert.ToInt32(data["PowerupChance"]);
			int num3 = Convert.ToInt32(data["DessertChance"]);
			int num4 = Convert.ToInt32(data["ScrapChance"]);
			int num5 = Convert.ToInt32(data["CoinChance"]);
			int num6 = Convert.ToInt32(data["GoldenCupCakeChance"]);
			this.scrapVariation = Convert.ToInt32(data["ScrapVariation"]);
			this.lootBoxMask = Convert.ToInt32(data["LootBoxMask"]);
			if (num > 0)
			{
				this.partChances = this.FromHashtable<BasePart.PartTier, int>(data["PartChances"] as Hashtable);
				this.chances.Add(new Tuple<Reward, int>(LootCrateRewards.Reward.Part, num));
				this.noDessertChances.Add(new Tuple<Reward, int>(LootCrateRewards.Reward.Part, num));
			}
			if (num2 > 0)
			{
				this.powerupChances = this.FromHashtable<Powerup, int>(data["PowerupChances"] as Hashtable);
				int num7 = (this.chances.Count <= 0) ? 0 : this.chances[this.chances.Count - 1].Item2;
				this.chances.Add(new Tuple<Reward, int>(LootCrateRewards.Reward.Powerup, num2 + num7));
				this.noDessertChances.Add(new Tuple<Reward, int>(LootCrateRewards.Reward.Powerup, num2 + num7));
			}
			if (num3 > 0)
			{
				this.dessertChances = this.FromHashtable<int, int>(data["DessertChances"] as Hashtable);
				int num8 = (this.chances.Count <= 0) ? 0 : this.chances[this.chances.Count - 1].Item2;
				this.chances.Add(new Tuple<Reward, int>(LootCrateRewards.Reward.Dessert, num3 + num8));
			}
			if (num4 > 0)
			{
				this.scrapChances = this.FromHashtable<int, int>(data["ScrapChances"] as Hashtable);
				int num9 = (this.chances.Count <= 0) ? 0 : this.chances[this.chances.Count - 1].Item2;
				this.chances.Add(new Tuple<Reward, int>(LootCrateRewards.Reward.Scrap, num4 + num9));
				num9 = ((this.noDessertChances.Count <= 0) ? 0 : this.noDessertChances[this.noDessertChances.Count - 1].Item2);
				this.noDessertChances.Add(new Tuple<Reward, int>(LootCrateRewards.Reward.Scrap, num4 + num9));
			}
			if (num5 > 0)
			{
				this.coinChances = this.FromHashtable<int, int>(data["CoinChances"] as Hashtable);
				int num10 = (this.chances.Count <= 0) ? 0 : this.chances[this.chances.Count - 1].Item2;
				this.chances.Add(new Tuple<Reward, int>(LootCrateRewards.Reward.Coin, num5 + num10));
				num10 = ((this.noDessertChances.Count <= 0) ? 0 : this.noDessertChances[this.noDessertChances.Count - 1].Item2);
				this.noDessertChances.Add(new Tuple<Reward, int>(LootCrateRewards.Reward.Coin, num5 + num10));
			}
			if (num6 > 0)
			{
				if (this.dessertChances == null)
				{
					this.dessertChances = new List<Tuple<int, int>>();
				}
				int num11 = (this.dessertChances.Count <= 0) ? 0 : this.dessertChances[this.dessertChances.Count - 1].Item2;
				this.dessertChances.Add(new Tuple<int, int>(0, num6 + num11));
			}
		}

		private List<Tuple<Reward, int>> CurrentChances
		{
			get
			{
				if (Application.isPlaying)
				{
					return (!GameProgress.GetBool("ChiefPigExploded", false, GameProgress.Location.Local, null)) ? this.noDessertChances : this.chances;
				}
				return this.chances;
			}
		}

		private int ChanceMax
		{
			get
			{
				return this.MaxChance(LootCrateRewards.Reward.Part) + this.MaxChance(LootCrateRewards.Reward.Powerup) + this.MaxChance(LootCrateRewards.Reward.Scrap) + this.MaxChance(LootCrateRewards.Reward.Coin) + this.MaxChance(LootCrateRewards.Reward.Dessert);
			}
		}

		private List<Tuple<T1, T2>> FromHashtable<T1, T2>(Hashtable data)
		{
			List<Tuple<T1, T2>> list = new List<Tuple<T1, T2>>();
			int num = 0;
			IEnumerator enumerator = data.Keys.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					int num2 = (int)Convert.ChangeType(data[obj], typeof(int));
					if (num2 > 0)
					{
						string text = (string)Convert.ChangeType(obj, typeof(string));
						T1 item;
						if (typeof(T1).IsEnum)
						{
							item = (T1)((object)Enum.Parse(typeof(T1), text));
						}
						else
						{
							item = (T1)((object)Convert.ChangeType(int.Parse(text), typeof(T1)));
						}
						list.Add(new Tuple<T1, T2>(item, (T2)((object)Convert.ChangeType(num2 + num, typeof(T2)))));
						num += num2;
					}
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
			return list;
		}

		public SlotRewards GetRewards()
		{
			List<Tuple<Reward, int>> currentChances = this.CurrentChances;
            Reward type = LootCrateRewards.Reward.None;
			int num = 0;
			int num2 = UnityEngine.Random.Range(0, currentChances[currentChances.Count - 1].Item2);
			for (int i = 0; i < currentChances.Count; i++)
			{
				if (num2 < currentChances[i].Item2)
				{
					type = currentChances[i].Item1;
					break;
				}
			}
			switch (type)
			{
			case LootCrateRewards.Reward.Part:
				num2 = UnityEngine.Random.Range(0, this.partChances[this.partChances.Count - 1].Item2);
				num = (int)this.partChances[this.GetRewardIndex(this.partChances, num2)].Item1;
				break;
			case LootCrateRewards.Reward.Powerup:
				num2 = UnityEngine.Random.Range(0, this.powerupChances[this.powerupChances.Count - 1].Item2);
				num = (int)this.powerupChances[this.GetRewardIndex(this.powerupChances, num2)].Item1;
				break;
			case LootCrateRewards.Reward.Dessert:
				num2 = UnityEngine.Random.Range(0, this.dessertChances[this.dessertChances.Count - 1].Item2);
				num = this.dessertChances[this.GetRewardIndex(this.dessertChances, num2)].Item1;
				break;
			case LootCrateRewards.Reward.Scrap:
			{
				num2 = UnityEngine.Random.Range(0, this.scrapChances[this.scrapChances.Count - 1].Item2);
				num = this.scrapChances[this.GetRewardIndex(this.scrapChances, num2)].Item1;
				float num3 = (float)UnityEngine.Random.Range(-this.scrapVariation, this.scrapVariation);
				num = Mathf.RoundToInt((float)num * (1f + num3 / 100f));
				break;
			}
			case LootCrateRewards.Reward.Coin:
				num2 = UnityEngine.Random.Range(0, this.coinChances[this.coinChances.Count - 1].Item2);
				num = this.coinChances[this.GetRewardIndex(this.coinChances, num2)].Item1;
				break;
			}
			return new SlotRewards(type, num);
		}

		public Tuple<Reward, BasePart.PartTier> MinimumReward()
		{
			if (this.MaxChance(LootCrateRewards.Reward.Part) == this.ChanceMax)
			{
				if (this.PartChance(BasePart.PartTier.Common) > 0)
				{
					return new Tuple<Reward, BasePart.PartTier>(LootCrateRewards.Reward.Part, BasePart.PartTier.Common);
				}
				if (this.PartChance(BasePart.PartTier.Rare) > 0)
				{
					return new Tuple<Reward, BasePart.PartTier>(LootCrateRewards.Reward.Part, BasePart.PartTier.Rare);
				}
				return new Tuple<Reward, BasePart.PartTier>(LootCrateRewards.Reward.Part, BasePart.PartTier.Epic);
			}
			else
			{
				if (this.MaxChance(LootCrateRewards.Reward.Dessert) > 0)
				{
					return new Tuple<Reward, BasePart.PartTier>(LootCrateRewards.Reward.Dessert, BasePart.PartTier.Regular);
				}
				if (this.MaxChance(LootCrateRewards.Reward.Scrap) > 0)
				{
					return new Tuple<Reward, BasePart.PartTier>(LootCrateRewards.Reward.Scrap, BasePart.PartTier.Regular);
				}
				if (this.MaxChance(LootCrateRewards.Reward.Powerup) > 0)
				{
					return new Tuple<Reward, BasePart.PartTier>(LootCrateRewards.Reward.Powerup, BasePart.PartTier.Regular);
				}
				if (this.MaxChance(LootCrateRewards.Reward.Coin) > 0)
				{
					return new Tuple<Reward, BasePart.PartTier>(LootCrateRewards.Reward.Coin, BasePart.PartTier.Regular);
				}
				return null;
			}
		}

		private int MaxChance(Reward type)
		{
			switch (type)
			{
			case LootCrateRewards.Reward.Part:
				return (this.partChances == null) ? 0 : this.partChances[this.partChances.Count - 1].Item2;
			case LootCrateRewards.Reward.Powerup:
				return (this.powerupChances == null) ? 0 : this.powerupChances[this.powerupChances.Count - 1].Item2;
			case LootCrateRewards.Reward.Dessert:
				return (this.dessertChances == null) ? 0 : this.dessertChances[this.dessertChances.Count - 1].Item2;
			case LootCrateRewards.Reward.Scrap:
				return (this.scrapChances == null) ? 0 : this.scrapChances[this.scrapChances.Count - 1].Item2;
			case LootCrateRewards.Reward.Coin:
				return (this.coinChances == null) ? 0 : this.coinChances[this.coinChances.Count - 1].Item2;
			}
			return 0;
		}

		private int PartChance(BasePart.PartTier tier)
		{
			int result = 0;
			for (int i = 0; i < this.partChances.Count; i++)
			{
				if (this.partChances[i].Item1 == tier)
				{
					result = this.partChances[i].Item2;
					break;
				}
			}
			return result;
		}

		private int GetRewardIndex<T1, T2>(List<Tuple<T1, T2>> list, int value)
		{
			for (int i = 0; i < list.Count; i++)
			{
				int num = Convert.ToInt32(list[i].Item2);
				if (value < num)
				{
					return i;
				}
			}
			return 0;
		}

		public bool ForLootCrate(LootCrateType type)
		{
			int num = 1 << (int)type;
			return (num & this.lootBoxMask) == num;
		}

		private const string PART_CHANCES = "PartChances";

		private const string POWERUP_CHANCES = "PowerupChances";

		private const string DESSERT_CHANCES = "DessertChances";

		private const string SCRAP_VARIATION = "ScrapVariation";

		private const string SCRAP_CHANCES = "ScrapChances";

		private const string COIN_CHANCES = "CoinChances";

		private const string PART_CHANCE = "PartChance";

		private const string POWERUP_CHANCE = "PowerupChance";

		private const string DESSERT_CHANCE = "DessertChance";

		private const string SCRAP_CHANCE = "ScrapChance";

		private const string COIN_CHANCE = "CoinChance";

		private const string LOOT_BOX_MASK = "LootBoxMask";

		private const string GOLDEN_CUPCAKE_CHANCE = "GoldenCupCakeChance";

		private List<Tuple<BasePart.PartTier, int>> partChances;

		private List<Tuple<Powerup, int>> powerupChances;

		private List<Tuple<int, int>> dessertChances;

		private List<Tuple<int, int>> scrapChances;

		private List<Tuple<int, int>> coinChances;

		private List<Tuple<Reward, int>> chances;

		private List<Tuple<Reward, int>> noDessertChances;

		private int scrapVariation;

		private int lootBoxMask;
	}
}
