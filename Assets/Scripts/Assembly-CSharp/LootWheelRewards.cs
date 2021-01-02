using System;

public class LootWheelRewards
{
	public LootWheelRewards()
	{
		if (Singleton<GameConfigurationManager>.Instance.HasData)
		{
			this.Initialize();
		}
		else
		{
			GameConfigurationManager instance = Singleton<GameConfigurationManager>.Instance;
			instance.OnHasData = (Action)Delegate.Combine(instance.OnHasData, new Action(this.Initialize));
		}
	}

	public bool Initialized
	{
		get
		{
			return this.m_initialized;
		}
	}

	public int TotalRewardValues
	{
		get
		{
			return this.m_totalValue;
		}
	}

	public float TotalRewardInverseValues
	{
		get
		{
			return this.m_totalInverseValue;
		}
	}

	public float RewardValueAvg
	{
		get
		{
			return this.m_rewardValueAvg;
		}
	}

	public float SpinPriceVariation
	{
		get
		{
			return this.m_spinPriceVariation;
		}
	}

	public float SpinPriceMultiplier
	{
		get
		{
			return this.m_spinPriceMultiplier;
		}
	}

	private void Initialize()
	{
		GameConfigurationManager instance = Singleton<GameConfigurationManager>.Instance;
		instance.OnHasData = (Action)Delegate.Remove(instance.OnHasData, new Action(this.Initialize));
		this.m_amounts = Singleton<GameConfigurationManager>.Instance.GetConfig("loot_wheel_prize_amounts");
		this.m_values = Singleton<GameConfigurationManager>.Instance.GetConfig("loot_wheel_prize_values");
		this.m_totalValue = 0;
		for (int i = 0; i < this.m_values.Keys.Length; i++)
		{
			int num = int.Parse(this.m_amounts[this.m_amounts.Keys[i]]);
			int num2 = int.Parse(this.m_values[this.m_values.Keys[i]]);
			this.m_totalValue += num * num2;
		}
		this.m_totalInverseValue = 0f;
		for (int j = 0; j < this.m_values.Keys.Length; j++)
		{
			int num3 = int.Parse(this.m_amounts[this.m_amounts.Keys[j]]);
			int num4 = int.Parse(this.m_values[this.m_values.Keys[j]]);
			this.m_totalInverseValue += (float)this.m_totalValue / ((float)num3 * (float)num4);
		}
		this.m_rewardValueAvg = (float)this.m_totalValue / (float)this.m_values.Count;
		if (Singleton<BuildCustomizationLoader>.Instance.IsOdyssey)
		{
			this.m_spinPriceMultiplier = 0f;
			this.m_spinPriceVariation = 0f;
		}
		else
		{
			ConfigData config = Singleton<GameConfigurationManager>.Instance.GetConfig("loot_wheel_spin_price_params");
			this.m_spinPriceVariation = float.Parse(config["variation_percentage"]);
			this.m_spinPriceMultiplier = float.Parse(config["price_multiplier"]);
		}
		this.m_initialized = true;
		if (this.OnInitialized != null)
		{
			this.OnInitialized();
		}
	}

	public LootWheelReward GetReward(WheelReward slot)
	{
		switch (slot)
		{
		case LootWheelRewards.WheelReward.Dessert1:
			return new LootWheelReward("dessert_0", this.m_amounts, this.m_values, LootWheelRewards.RewardType.Dessert);
		case LootWheelRewards.WheelReward.Dessert2:
			return new LootWheelReward("dessert_1", this.m_amounts, this.m_values, LootWheelRewards.RewardType.Dessert);
		case LootWheelRewards.WheelReward.Dessert3:
			return new LootWheelReward("dessert_2", this.m_amounts, this.m_values, LootWheelRewards.RewardType.Dessert);
		case LootWheelRewards.WheelReward.Scrap1:
			return new LootWheelReward("scrap_0", this.m_amounts, this.m_values, LootWheelRewards.RewardType.Scrap);
		case LootWheelRewards.WheelReward.Scrap2:
			return new LootWheelReward("scrap_1", this.m_amounts, this.m_values, LootWheelRewards.RewardType.Scrap);
		case LootWheelRewards.WheelReward.Powerup:
			return new LootWheelReward("powerup", this.m_amounts, this.m_values, LootWheelRewards.RewardType.Powerup, this.GetRandomPowerup());
		case LootWheelRewards.WheelReward.CommonPart:
			return new LootWheelReward("common", this.m_amounts, this.m_values, LootWheelRewards.RewardType.Part, this.GetRandomPart(BasePart.PartTier.Common));
		case LootWheelRewards.WheelReward.RarePart:
			return new LootWheelReward("rare", this.m_amounts, this.m_values, LootWheelRewards.RewardType.Part, this.GetRandomPart(BasePart.PartTier.Rare));
		case LootWheelRewards.WheelReward.EpicPart:
			return new LootWheelReward("epic", this.m_amounts, this.m_values, LootWheelRewards.RewardType.Part, this.GetRandomPart(BasePart.PartTier.Epic));
		default:
			throw new ArgumentException("Not a valid argument!");
		}
	}

	private BasePart GetRandomPart(BasePart.PartTier tier)
	{
		BasePart randomCraftablePartFromTier = CustomizationManager.GetRandomCraftablePartFromTier(tier, true);
		if (randomCraftablePartFromTier == null)
		{
			randomCraftablePartFromTier = CustomizationManager.GetRandomCraftablePartFromTier(tier, false);
		}
		return randomCraftablePartFromTier;
	}

	private LootCrateRewards.Powerup GetRandomPowerup()
	{
		switch (UnityEngine.Random.Range(0, 4))
		{
		case 0:
			return LootCrateRewards.Powerup.Magnet;
		case 1:
			return LootCrateRewards.Powerup.NightVision;
		case 2:
			return LootCrateRewards.Powerup.Superglue;
		case 3:
			return LootCrateRewards.Powerup.Turbo;
		default:
			return LootCrateRewards.Powerup.None;
		}
	}

	private const string PRIZE_AMOUNTS_CONFIG = "loot_wheel_prize_amounts";

	private const string PRIZE_VALUES_CONFIG = "loot_wheel_prize_values";

	private const string SPIN_PRICE_PARAMS = "loot_wheel_spin_price_params";

	private const string DESSERT_0 = "dessert_0";

	private const string DESSERT_1 = "dessert_1";

	private const string DESSERT_2 = "dessert_2";

	private const string SCRAP_0 = "scrap_0";

	private const string SCRAP_1 = "scrap_1";

	private const string POWERUP = "powerup";

	private const string COMMON = "common";

	private const string RARE = "rare";

	private const string EPIC = "epic";

	private const string VAR_PERCENTAGE = "variation_percentage";

	private const string PRICE_MULTIPLIER = "price_multiplier";

	private bool m_initialized;

	private int m_totalValue;

	private float m_totalInverseValue;

	private float m_rewardValueAvg;

	private float m_spinPriceVariation;

	private float m_spinPriceMultiplier;

	private ConfigData m_amounts;

	private ConfigData m_values;

	public Action OnInitialized;

	public enum RewardType
	{
		None,
		Dessert,
		Scrap,
		Powerup,
		Part
	}

	public enum WheelReward
	{
		None,
		Dessert1,
		Dessert2,
		Dessert3,
		Scrap1,
		Scrap2,
		Powerup,
		CommonPart,
		RarePart,
		EpicPart
	}

	public struct LootWheelReward
	{
		public LootWheelReward(int amount, int value, RewardType type)
		{
			this.m_amount = amount;
			this.m_value = value;
			this.m_type = type;
			this.m_powerup = LootCrateRewards.Powerup.None;
			this.m_part = null;
		}

		public LootWheelReward(string key, ConfigData amounts, ConfigData values, RewardType type)
		{
			this.m_amount = int.Parse(amounts[key]);
			this.m_value = int.Parse(values[key]);
			this.m_type = type;
			this.m_powerup = LootCrateRewards.Powerup.None;
			this.m_part = null;
		}

		public LootWheelReward(string key, ConfigData amounts, ConfigData values, RewardType type, LootCrateRewards.Powerup powerup)
		{
			this.m_amount = int.Parse(amounts[key]);
			this.m_value = int.Parse(values[key]);
			this.m_type = type;
			this.m_powerup = powerup;
			this.m_part = null;
		}

		public LootWheelReward(string key, ConfigData amounts, ConfigData values, RewardType type, BasePart part)
		{
			this.m_amount = int.Parse(amounts[key]);
			this.m_value = int.Parse(values[key]);
			this.m_type = type;
			this.m_powerup = LootCrateRewards.Powerup.None;
			this.m_part = part;
		}

		public int Amount
		{
			get
			{
				return this.m_amount;
			}
		}

		public int SingleValue
		{
			get
			{
				return this.m_value;
			}
		}

		public int TotalValue
		{
			get
			{
				return this.m_amount * this.m_value;
			}
		}

		public RewardType Type
		{
			get
			{
				return this.m_type;
			}
		}

		public LootCrateRewards.Powerup PowerupReward
		{
			get
			{
				return this.m_powerup;
			}
		}

		public BasePart PartReward
		{
			get
			{
				return this.m_part;
			}
		}

		public static LootWheelReward Empty
		{
			get
			{
				return default(LootWheelReward);
			}
		}

		private int m_amount;

		private int m_value;

		private RewardType m_type;

		private LootCrateRewards.Powerup m_powerup;

		private BasePart m_part;
	}
}
