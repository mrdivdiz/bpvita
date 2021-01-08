using System;
using System.Collections.Generic;

public class CustomizationManager
{
    public static void UnlockPart(BasePart part, string unlockType)
    {
        if (CustomizationManager.IsPartUnlocked(part))
        {
            return;
        }
        CustomizationManager.cachedUnlockedPartCount = -1;
        GameProgress.SetBool(part.name, true, GameProgress.Location.Local);
        CustomizationManager.SetPartNew(part, true);
        CustomizationManager.SetPartUsed(part, false);
        CustomizationManager.CheckUnlockPartAchievements();
        if (CustomizationManager.OnPartUnlocked != null)
        {
            CustomizationManager.OnPartUnlocked(part);
        }
    }

    public static bool IsPartUnlocked(BasePart part)
    {
        return GameProgress.GetBool(part.name, false, GameProgress.Location.Local, null);
    }

    public static bool HasNewParts()
    {
        return GameProgress.GetInt("NewParts", 0, GameProgress.Location.Local, null) > 0;
    }

    public static int NewPartCount()
    {
        return GameProgress.GetInt("NewParts", 0, GameProgress.Location.Local, null);
    }

    public static void SetPartNew(BasePart part, bool isNew)
    {
        string key = string.Format("{0}_isNew", part.name);
        if (isNew && !GameProgress.HasKey(key, GameProgress.Location.Local, null))
        {
            GameProgress.SetBool(key, isNew, GameProgress.Location.Local);
            GameProgress.SetInt("NewParts", GameProgress.GetInt("NewParts", 0, GameProgress.Location.Local, null) + 1, GameProgress.Location.Local);
        }
        else if (!isNew && GameProgress.HasKey(key, GameProgress.Location.Local, null) && GameProgress.GetBool(key, false, GameProgress.Location.Local, null))
        {
            GameProgress.SetBool(key, isNew, GameProgress.Location.Local);
            GameProgress.SetInt("NewParts", GameProgress.GetInt("NewParts", 0, GameProgress.Location.Local, null) - 1, GameProgress.Location.Local);
        }
    }

    public static bool IsPartNew(BasePart part)
    {
        string key = string.Format("{0}_isNew", part.name);
        return GameProgress.GetBool(key, false, GameProgress.Location.Local, null);
    }

    public static bool IsPartUsed(BasePart part)
    {
        string key = string.Format("{0}_isUsed", part.name);
        return GameProgress.GetBool(key, false, GameProgress.Location.Local, null);
    }

    public static void SetPartUsed(BasePart part, bool used)
    {
        string key = string.Format("{0}_isUsed", part.name);
        if (!used && !GameProgress.HasKey(key, GameProgress.Location.Local, null))
        {
            GameProgress.SetBool(key, used, GameProgress.Location.Local);
        }
        else if (used && !GameProgress.GetBool(key, false, GameProgress.Location.Local, null))
        {
            GameProgress.SetBool(key, used, GameProgress.Location.Local);
            PlayerProgress.ExperienceType experienceType = PlayerProgress.ExperienceType.NewCommonPartViewed;
            if (part.m_partTier == BasePart.PartTier.Rare)
            {
                experienceType = PlayerProgress.ExperienceType.NewRarePartViewed;
            }
            else if (part.m_partTier == BasePart.PartTier.Epic)
            {
                experienceType = PlayerProgress.ExperienceType.NewEpicPartViewed;
            }
            else if (part.m_partTier == BasePart.PartTier.Legendary)
            {
                experienceType = PlayerProgress.ExperienceType.NewLegendaryPartViewed;
            }
            Singleton<PlayerProgress>.Instance.AddExperience(experienceType);
        }
    }

    private static bool HasPartFlags(BasePart part, PartFlags flags)
    {
        if (part == null)
        {
            return false;
        }
        PartFlags partFlags = CustomizationManager.PartFlags.None;
        if (!CustomizationManager.IsPartUnlocked(part))
        {
            partFlags |= CustomizationManager.PartFlags.Locked;
        }
        if (part.craftable)
        {
            partFlags |= CustomizationManager.PartFlags.Craftable;
        }
        if (part.lootCrateReward)
        {
            partFlags |= CustomizationManager.PartFlags.Rewardable;
        }
        return (partFlags & flags) == flags;
    }

    public static int GetUnlockedPartCount(bool useTier = false, BasePart.PartTier tier = BasePart.PartTier.Common)
    {
        int num = 0;
        if (!useTier)
        {
            num = CustomizationManager.cachedUnlockedPartCount;
        }
        if (num < 0 || useTier)
        {
            num = 0;
            List<CustomPartInfo> customParts = WPFMonoBehaviour.gameData.m_customParts;
            for (int i = 0; i < customParts.Count; i++)
            {
                if (customParts[i] != null && customParts[i].PartList != null && customParts[i].PartList.Count != 0)
                {
                    for (int j = 0; j < customParts[i].PartList.Count; j++)
                    {
                        if (CustomizationManager.IsPartUnlocked(customParts[i].PartList[j]) && (!useTier || (useTier && customParts[i].PartList[j].m_partTier == tier)))
                        {
                            num++;
                        }
                    }
                }
            }
        }
        if (!useTier)
        {
            CustomizationManager.cachedUnlockedPartCount = num;
        }
        return num;
    }

    public static int GetTotalPartCountForTier(BasePart.PartTier tier)
    {
        int num = CustomizationManager.cachedPartTierCount[(int)tier];
        if (num < 0)
        {
            num = CustomizationManager.GetAllTierParts(tier, CustomizationManager.PartFlags.None).Count;
        }
        return num;
    }

    public static List<BasePart> GetAllTierParts(BasePart.PartTier tier, PartFlags flags = CustomizationManager.PartFlags.None)
    {
        List<BasePart> list = new List<BasePart>();
        if (tier == BasePart.PartTier.Regular)
        {
            for (int i = 0; i < WPFMonoBehaviour.gameData.m_parts.Count; i++)
            {
                if (flags == CustomizationManager.PartFlags.None)
                {
                    list.Add(WPFMonoBehaviour.gameData.m_parts[i].GetComponent<BasePart>());
                }
            }
        }
        else
        {
            List<CustomPartInfo> customParts = WPFMonoBehaviour.gameData.m_customParts;
            for (int j = 0; j < customParts.Count; j++)
            {
                if (customParts[j] != null && customParts[j].PartList != null && customParts[j].PartList.Count != 0)
                {
                    for (int k = 0; k < customParts[j].PartList.Count; k++)
                    {
                        if (customParts[j].PartList[k].m_partTier == tier && CustomizationManager.HasPartFlags(customParts[j].PartList[k], flags))
                        {
                            list.Add(customParts[j].PartList[k]);
                        }
                    }
                }
            }
        }
        return list;
    }

    public static List<BasePart> GetCustomParts(BasePart.PartType type, BasePart.PartTier tier, bool onlyLocked = false)
    {
        List<BasePart> list = new List<BasePart>();
        List<CustomPartInfo> customParts = WPFMonoBehaviour.gameData.m_customParts;
        for (int i = 0; i < customParts.Count; i++)
        {
            if (customParts[i].PartType == type)
            {
                for (int j = 0; j < customParts[i].PartList.Count; j++)
                {
                    if (customParts[i].PartList[j].m_partTier == tier)
                    {
                        if (onlyLocked && !CustomizationManager.IsPartUnlocked(customParts[i].PartList[j]))
                        {
                            list.Add(customParts[i].PartList[j]);
                        }
                        else if (!onlyLocked)
                        {
                            list.Add(customParts[i].PartList[j]);
                        }
                    }
                }
                break;
            }
        }
        return list;
    }

    public static List<BasePart> GetCustomParts(BasePart.PartType type, bool onlyLocked = false)
    {
        List<BasePart> list = new List<BasePart>();
        List<CustomPartInfo> customParts = WPFMonoBehaviour.gameData.m_customParts;
        for (int i = 0; i < customParts.Count; i++)
        {
            if (customParts[i].PartType == type)
            {
                for (int j = 0; j < customParts[i].PartList.Count; j++)
                {
                    if (onlyLocked && !CustomizationManager.IsPartUnlocked(customParts[i].PartList[j]))
                    {
                        list.Add(customParts[i].PartList[j]);
                    }
                    else if (!onlyLocked)
                    {
                        list.Add(customParts[i].PartList[j]);
                    }
                }
                break;
            }
        }
        return list;
    }

    public static int CustomizationCount(BasePart.PartTier tier, PartFlags flags = CustomizationManager.PartFlags.None)
    {
        int num = 0;
        List<CustomPartInfo> customParts = WPFMonoBehaviour.gameData.m_customParts;
        for (int i = 0; i < customParts.Count; i++)
        {
            if (customParts[i] != null && customParts[i].PartList != null && customParts[i].PartList.Count != 0)
            {
                for (int j = 0; j < customParts[i].PartList.Count; j++)
                {
                    if (customParts[i].PartList[j].m_partTier == tier && CustomizationManager.HasPartFlags(customParts[i].PartList[j], flags))
                    {
                        num++;
                    }
                }
            }
        }
        return num;
    }

    public static BasePart GetRandomLootCrateRewardPartFromTier(BasePart.PartTier tier, bool onlyLocked = false)
    {
        BasePart result;
        if (!Singleton<PredefinedRewards>.Instance.AllRewardsGiven && Singleton<PredefinedRewards>.Instance.GetReward(tier, out result))
        {
            return result;
        }
        List<BasePart> allTierParts = CustomizationManager.GetAllTierParts(tier, (!onlyLocked) ? CustomizationManager.PartFlags.None : CustomizationManager.PartFlags.Locked);
        if (allTierParts.Count == 0)
        {
            return null;
        }
        int num = UnityEngine.Random.Range(0, allTierParts.Count);
        int num2 = num;
        while (!allTierParts[num].lootCrateReward)
        {
            num++;
            if (num >= allTierParts.Count)
            {
                num = 0;
            }
            if (num2 == num)
            {
                return null;
            }
        }
        return allTierParts[num];
    }

    public static BasePart GetRandomCraftablePartFromTier(BasePart.PartTier tier, bool onlyLocked = false)
    {
        BasePart result;
        if (!Singleton<PredefinedRewards>.Instance.AllRewardsGiven && Singleton<PredefinedRewards>.Instance.GetReward(tier, out result))
        {
            return result;
        }
        List<BasePart> allTierParts = CustomizationManager.GetAllTierParts(tier, (!onlyLocked) ? CustomizationManager.PartFlags.None : CustomizationManager.PartFlags.Locked);
        if (allTierParts.Count == 0)
        {
            return null;
        }
        int num = UnityEngine.Random.Range(0, allTierParts.Count);
        int num2 = num;
        while (!allTierParts[num].craftable)
        {
            num++;
            if (num >= allTierParts.Count)
            {
                num = 0;
            }
            if (num2 == num)
            {
                return null;
            }
        }
        return allTierParts[num];
    }

    public static BasePart GetRandomPartFromTier(BasePart.PartTier tier, bool onlyLocked = false)
    {
        List<BasePart> allTierParts = CustomizationManager.GetAllTierParts(tier, (!onlyLocked) ? CustomizationManager.PartFlags.None : CustomizationManager.PartFlags.Locked);
        if (allTierParts.Count == 0)
        {
            return null;
        }
        int index = UnityEngine.Random.Range(0, allTierParts.Count);
        return allTierParts[index];
    }

    public static void SetLastUsedPartIndex(BasePart.PartType partType, int index)
    {
        UserSettings.SetInt("LastUsed_" + partType.ToString(), index);
    }

    public static int GetLastUsedPartIndex(BasePart.PartType partType)
    {
        return UserSettings.GetInt("LastUsed_" + partType.ToString(), 0);
    }

    private static void CheckUnlockPartAchievements()
    {
        if (!Singleton<SocialGameManager>.IsInstantiated())
        {
            return;
        }
        bool flag = false;
        int common = 0;
        int rare = 0;
        int epic = 0;
        List<BasePart> allTierParts = CustomizationManager.GetAllTierParts(BasePart.PartTier.Common, CustomizationManager.PartFlags.None);
        List<BasePart> allTierParts2 = CustomizationManager.GetAllTierParts(BasePart.PartTier.Rare, CustomizationManager.PartFlags.None);
        List<BasePart> allTierParts3 = CustomizationManager.GetAllTierParts(BasePart.PartTier.Epic, CustomizationManager.PartFlags.None);
        foreach (BasePart basePart in allTierParts)
        {
            if (CustomizationManager.IsPartUnlocked(basePart))
            {
                common++;
                if (basePart.tags != null && basePart.tags.Contains("Gold"))
                {
                    flag = true;
                }
            }
        }
        foreach (BasePart basePart2 in allTierParts2)
        {
            if (CustomizationManager.IsPartUnlocked(basePart2))
            {
                rare++;
                if (basePart2.tags != null && basePart2.tags.Contains("Gold"))
                {
                    flag = true;
                }
            }
        }
        foreach (BasePart basePart3 in allTierParts3)
        {
            if (CustomizationManager.IsPartUnlocked(basePart3))
            {
                epic++;
                if (basePart3.tags != null && basePart3.tags.Contains("Gold"))
                {
                    flag = true;
                }
            }
        }
        if (common > 0)
        {
            Singleton<SocialGameManager>.Instance.TryReportAchievementProgress("grp.COMMON_COLLECTOR", 100.0, (int limit) => common >= limit);
        }
        if (rare > 0)
        {
            Singleton<SocialGameManager>.Instance.TryReportAchievementProgress("grp.RARE_COLLECTOR", 100.0, (int limit) => rare >= limit);
        }
        if (epic > 0)
        {
            Singleton<SocialGameManager>.Instance.TryReportAchievementProgress("grp.EPIC_COLLECTOR", 100.0, (int limit) => epic >= limit);
        }
        if (flag)
        {
            Singleton<SocialGameManager>.Instance.ReportAchievementProgress("grp.GET_GOLDEN_PART", 100.0);
        }
    }

    public static Action<BasePart> OnPartUnlocked;

    private const string NEW_PARTS_KEY = "NewParts";

    private static int cachedUnlockedPartCount = -1;

    private static int[] cachedPartTierCount = new int[]
    {
        -1,
        -1,
        -1,
        -1
    };

    [Flags]
    public enum PartFlags
    {
        None = 0,
        Locked = 1,
        Craftable = 2,
        Rewardable = 4
    }
}
