using System;
using UnityEngine;

public class ScrapButton : SoftCurrencyButton
{
	public static ScrapButton Instance
	{
		get
		{
			return ScrapButton.instance;
		}
	}

	protected override void ButtonAwake()
	{
		ScrapButton.instance = this;
		if (!Singleton<BuildCustomizationLoader>.Instance.IsOdyssey)
		{
			if (Singleton<DoubleRewardManager>.Instance.HasDoubleReward)
			{
				this.OnGainedDoubleReward();
			}
			else
			{
				this.OnDoubleRewardEnded();
			}
		}
	}

	private void OnDestroy()
	{
		if (Singleton<DoubleRewardManager>.IsInstantiated())
		{
			DoubleRewardManager doubleRewardManager = Singleton<DoubleRewardManager>.Instance;
			doubleRewardManager.OnAdWatched = (Action)Delegate.Remove(doubleRewardManager.OnAdWatched, new Action(this.OnGainedDoubleReward));
		}
	}

	protected override void ButtonEnabled()
	{
		EventManager.Connect(new EventManager.OnEvent<WorkshopMenu.CraftingMachineEvent>(this.OnCraftingMachineEvent));
		this.UpdateCount(GameProgress.GetInt("Machine_scrap_amount", 0, GameProgress.Location.Local, null));
		base.UpdateAmount(true);
	}

	protected override void ButtonDisabled()
	{
		EventManager.Disconnect(new EventManager.OnEvent<WorkshopMenu.CraftingMachineEvent>(this.OnCraftingMachineEvent));
	}

	protected override int GetCurrencyCount()
	{
		return GameProgress.ScrapCount() - this.scrapCountInsideMachine;
	}

	public override AudioSource[] GetHitSounds()
	{
		return WPFMonoBehaviour.gameData.commonAudioCollection.nutHit;
	}

	public override AudioSource[] GetFlySounds()
	{
		return WPFMonoBehaviour.gameData.commonAudioCollection.nutFly;
	}

	protected override AudioSource GetLoopSound()
	{
		return null;
	}

	protected override void OnUpdate()
	{
	}

	private void OnCraftingMachineEvent(WorkshopMenu.CraftingMachineEvent data)
	{
		WorkshopMenu.CraftingMachineAction action = data.action;
		if (action == WorkshopMenu.CraftingMachineAction.RemoveScrap || action == WorkshopMenu.CraftingMachineAction.AddScrap || action == WorkshopMenu.CraftingMachineAction.ResetScrap)
		{
			this.UpdateCount(data.scrapAmountInMachine);
		}
	}

	private void UpdateCount(int insideMachineAmount)
	{
		this.scrapCountInsideMachine = insideMachineAmount;
		base.UpdateAmount(false);
	}

	public void OpenWorkshop()
	{
	}

	private void OnDoubleRewardEnded()
	{
		DoubleRewardManager doubleRewardManager = Singleton<DoubleRewardManager>.Instance;
		doubleRewardManager.OnAdWatched = (Action)Delegate.Combine(doubleRewardManager.OnAdWatched, new Action(this.OnGainedDoubleReward));
	}

	private void OnGainedDoubleReward()
	{
		DoubleRewardManager doubleRewardManager = Singleton<DoubleRewardManager>.Instance;
		doubleRewardManager.OnAdWatched = (Action)Delegate.Remove(doubleRewardManager.OnAdWatched, new Action(this.OnGainedDoubleReward));
	}

	private void UpdatePlacement(float relativePosition)
	{
	}

	[SerializeField]
	private float doubleRewardedPosition;

	[SerializeField]
	private float regularPosition;

	protected static ScrapButton instance;

	private int scrapCountInsideMachine;
}
