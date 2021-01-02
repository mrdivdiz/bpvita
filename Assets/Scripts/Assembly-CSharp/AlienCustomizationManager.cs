using System;
using System.Collections.Generic;

public static class AlienCustomizationManager
{
	static AlienCustomizationManager()
	{
		if (Singleton<GameConfigurationManager>.Instance.HasData)
		{
			AlienCustomizationManager.Initialize();
		}
		else
		{
			GameConfigurationManager instance = Singleton<GameConfigurationManager>.Instance;
			Delegate onHasData = instance.OnHasData;
			instance.OnHasData = (Action)Delegate.Combine(onHasData, new Action(AlienCustomizationManager.Initialize));
		}
	}

	public static bool Initialized
	{
		get
		{
			return AlienCustomizationManager.s_initialized;
		}
	}

	public static bool HasCraftableItems
	{
		get
		{
			return AlienCustomizationManager.UnlockablesLeft() > 0;
		}
	}

	private static void Initialize()
	{
		if (AlienCustomizationManager.s_initialized)
		{
			return;
		}
		AlienCustomizationManager.s_unlockOrder = new List<BasePart>();
		ConfigData config = Singleton<GameConfigurationManager>.Instance.GetConfig("alien_part_craft_order");
		List<BasePart> allTierParts = CustomizationManager.GetAllTierParts(BasePart.PartTier.Legendary, CustomizationManager.PartFlags.Craftable);
		if (config == null)
		{
			return;
		}
		for (int i = 0; i < config.Count; i++)
		{
			string key = i.ToString();
			if (config.HasKey(key))
			{
				string b = config[key];
				for (int j = 0; j < allTierParts.Count; j++)
				{
					if (allTierParts[j].name == b)
					{
						AlienCustomizationManager.s_unlockOrder.Add(allTierParts[j]);
						break;
					}
				}
			}
		}
		AlienCustomizationManager.s_initialized = true;
	}

	public static bool GetNextUnlockable(out BasePart part)
	{
		part = null;
		if (!AlienCustomizationManager.s_initialized)
		{
			return false;
		}
		for (int i = 0; i < AlienCustomizationManager.s_unlockOrder.Count; i++)
		{
			if (!CustomizationManager.IsPartUnlocked(AlienCustomizationManager.s_unlockOrder[i]))
			{
				part = AlienCustomizationManager.s_unlockOrder[i];
				break;
			}
		}
		return part != null;
	}

	public static int UnlockablesLeft()
	{
		int num = 0;
		if (!AlienCustomizationManager.s_initialized)
		{
			return 0;
		}
		for (int i = 0; i < AlienCustomizationManager.s_unlockOrder.Count; i++)
		{
			if (!CustomizationManager.IsPartUnlocked(AlienCustomizationManager.s_unlockOrder[i]))
			{
				num++;
			}
		}
		return num;
	}

	public static int GetPrice()
	{
		return 3000;
	}

	private const string ALIEN_CRAFT_CONFIG_NAME = "alien_part_craft_order";

	private const string ALIEN_PRICE_CONFIG_NAME = "none";

	private static bool s_initialized;

	private static List<BasePart> s_unlockOrder;
}
