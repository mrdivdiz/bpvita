using System;
using System.Collections.Generic;
using UnityEngine;

public class AdvertisementHandler
{

	public static string LevelRewardVideoPlacement
	{
		get
		{
			return AdvertisementHandler.levelRewardVideoPlacement;
		}
	}

	public static string SnoutCoinRewardVideoPlacement
	{
		get
		{
			return AdvertisementHandler.snoutCoinRewardVideoPlacement;
		}
	}

	public static string DoubleRewardPlacement
	{
		get
		{
			return AdvertisementHandler.doubleRewardPlacement;
		}
	}

	public static string ExtraCoinsRewardPlacement
	{
		get
		{
			return AdvertisementHandler.extraCoinsRewardPlacement;
		}
	}

	public static string DailyChallengeRevealPlacement
	{
		get
		{
			return AdvertisementHandler.dailyChallengeRevealPlacement;
		}
	}

	public static string FreeLootCratePlacement
	{
		get
		{
			return AdvertisementHandler.freeLootCratePlacement;
		}
	}

	public static RenderableHandler MainMenuPromoRenderable
	{
		get
		{
			return AdvertisementHandler.mainMenuPromoRenderable;
		}
	}

	public static RenderableHandler CrossPromoMainRenderable
	{
		get
		{
			return AdvertisementHandler.crossPromoMainRenderable;
		}
	}

	public static RenderableHandler CrossPromoEpisodeRenderable
	{
		get
		{
			return AdvertisementHandler.crossPromoEpisodeRenderable;
		}
	}

	public static Texture2D GetRewardNativeTexture()
	{
		if (AdvertisementHandler.rewardNativeRenderable != null)
		{
			return AdvertisementHandler.rewardNativeRenderable.m_texture;
		}
		return null;
	}

	public static Texture2D GetMainMenuPopupTexture()
	{
		if (AdvertisementHandler.mainMenuPromoRenderable != null)
		{
			return AdvertisementHandler.mainMenuPromoRenderable.m_texture;
		}
		return null;
	}

	public static Texture2D GetCrossPromoMainTexture()
	{
		if (AdvertisementHandler.crossPromoMainRenderable != null)
		{
			return AdvertisementHandler.crossPromoMainRenderable.m_texture;
		}
		return null;
	}

	public static Texture2D GetCrossPromoEpisodeTexture()
	{
		if (AdvertisementHandler.crossPromoEpisodeRenderable != null)
		{
			return AdvertisementHandler.crossPromoEpisodeRenderable.m_texture;
		}
		return null;
	}

	public static bool IsAdvertisementReady(string placement)
	{
		return false;
	}

	private static RenderableHandler rewardNativeRenderable;

	private static RenderableHandler mainMenuPromoRenderable;

	private static RenderableHandler crossPromoMainRenderable;

	private static RenderableHandler crossPromoEpisodeRenderable;

	private static string dailyChallengeRevealPlacement = "RewardVideo.DailyChallengeReveal";

	private static string levelRewardVideoPlacement = "RewardVideo.LevelUnlock";

	private static string snoutCoinRewardVideoPlacement = "RewardVideo.SnoutReward";

	private static string timeRewardVideoPlacement = "RewardVideo";

	private static string rewardNativePlacement = "RewardNative";

	private static string mainMenuPopupPlacement = "MainMenuPopup";

	private static string interstitialPlacement = "LevelStartInterstitial";

	private static string doubleRewardPlacement = "RewardVideo.DoubleReward";

	private static string extraCoinsRewardPlacement = "RewardVideo.ExtraCoins";

	private static string pauseMenuPromoPlacement = "NewsFeed.pause";

	private static string freeLootCratePlacement = "RewardVideo.FreeLootCrate";

	private static string crossPromoMainPlacement = "InGameNative.MainMenu";

	private static string crossPromoEpisodePlacement = "InGameNative.EpisodeMenu";

	public class RenderableHandler
	{
		public RenderableHandler(string placement)
		{
			this.m_placementName = placement;
			this.m_texture = null;
		}

		public bool OnRenderableReady(string placement, string contentType, List<byte> content)
		{
			if (!placement.Equals(this.m_placementName) || content == null)
			{
				if (this.onRenderableReady != null)
				{
					this.onRenderableReady(false);
				}
				return false;
			}
			if (contentType.StartsWith("image/"))
			{
				Texture2D texture2D = new Texture2D(1, 1);
				if (texture2D.LoadImage(content.ToArray()))
				{
					this.m_texture = texture2D;
					if (this.onRenderableReady != null)
					{
						this.onRenderableReady(true);
					}
					return true;
				}
			}
			if (this.onRenderableReady != null)
			{
				this.onRenderableReady(false);
			}
			return false;
		}

		public string m_placementName;

		public Texture2D m_texture;

		public Action<bool> onRenderableReady;
	}
}
