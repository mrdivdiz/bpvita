using System;
using UnityEngine;

public class SnoutButton : SoftCurrencyButton
{
	public static SnoutButton Instance
	{
		get
		{
			return SnoutButton.instance;
		}
	}

	protected override void ButtonAwake()
	{
		SnoutButton.instance = this;
	}

	protected override void ButtonEnabled()
	{
		IapManager.onPurchaseSucceeded += this.OnPurchase;
	}

	protected override void ButtonDisabled()
	{
		IapManager.onPurchaseSucceeded -= this.OnPurchase;
	}

	protected override int GetCurrencyCount()
	{
		return GameProgress.SnoutCoinCount();
	}

	public override AudioSource[] GetHitSounds()
	{
		return WPFMonoBehaviour.gameData.commonAudioCollection.snoutCoinHit;
	}

	public override AudioSource[] GetFlySounds()
	{
		return WPFMonoBehaviour.gameData.commonAudioCollection.snoutCoinFly;
	}

	protected override AudioSource GetLoopSound()
	{
		return null;
	}

	protected override void OnUpdate()
	{
	}

	private void OnPurchase(IapManager.InAppPurchaseItemType type)
	{
		base.UpdateAmount(false);
		if (!Singleton<IapManager>.Instance.SnoutCoinPurchasable(type))
		{
			this.PlayPurchaseSound();
		}
	}

	private void PlayPurchaseSound()
	{
		if (WPFMonoBehaviour.gameData == null || WPFMonoBehaviour.gameData.commonAudioCollection.snoutCoinPurchase == null)
		{
			return;
		}
		Singleton<AudioManager>.Instance.Play2dEffect(WPFMonoBehaviour.gameData.commonAudioCollection.snoutCoinPurchase);
	}

	public void OpenSnoutCoinPopup()
	{
		Singleton<IapManager>.Instance.OpenShopPage(new Action(base.RecoverToPreviousPosition), "SnoutCoinShop");
	}

	public override void AddParticles(GameObject target, int amount, float delay = 0f, float burstRate = 0f)
	{
		if (Singleton<BuildCustomizationLoader>.Instance.IsOdyssey)
		{
			return;
		}
		base.AddParticles(target, amount, delay, burstRate);
	}

	public override void ShowButton(bool show = true)
	{
		ResourceBar.Instance.ShowItem(ResourceBar.Item.SnoutCoin, !Singleton<BuildCustomizationLoader>.Instance.IsOdyssey && show, true);
	}

	private void OnShowButton()
	{
		base.UpdateAmount(true);
	}

	protected static SnoutButton instance;
}
