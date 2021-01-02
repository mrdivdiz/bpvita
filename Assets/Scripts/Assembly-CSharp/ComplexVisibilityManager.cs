using System;
using System.Collections.Generic;

public class ComplexVisibilityManager : Singleton<ComplexVisibilityManager>
{
	private void Awake()
	{
		base.SetAsPersistant();
		EventManager.Connect(new EventManager.OnEvent<GameStateChanged>(this.OnGameStateChanged));
		EventManager.Connect(new EventManager.OnEvent<LevelLoadedEvent>(this.OnLevelLoaded));
		EventManager.Connect(new EventManager.OnEvent<LoadLevelEvent>(this.OnLoadlevel));
		EventManager.Connect(new EventManager.OnEvent<UIEvent>(this.OnReceivedUIEvent));
		this.states = new Dictionary<Condition, bool>();
		for (int i = 0; i < Enum.GetNames(typeof(Condition)).Length; i++)
		{
			this.states.Add((Condition)i, false);
		}
		this.states[ComplexVisibilityManager.Condition.Always] = true;
		this.states[ComplexVisibilityManager.Condition.IsOdyssey] = Singleton<BuildCustomizationLoader>.instance.IsOdyssey;
		this.listeners = new Dictionary<IComplexVisibilityObject, bool>();
	}

	private void OnDestroy()
	{
		EventManager.Disconnect(new EventManager.OnEvent<GameStateChanged>(this.OnGameStateChanged));
		EventManager.Disconnect(new EventManager.OnEvent<LevelLoadedEvent>(this.OnLevelLoaded));
		EventManager.Disconnect(new EventManager.OnEvent<LoadLevelEvent>(this.OnLoadlevel));
		EventManager.Disconnect(new EventManager.OnEvent<UIEvent>(this.OnReceivedUIEvent));
	}

	private void OnReceivedUIEvent(UIEvent data)
	{
		UIEvent.Type type = data.type;
		switch (type)
		{
		case UIEvent.Type.OpenedLootWheel:
			this.SwitchCondition(ComplexVisibilityManager.Condition.LootWheelOpen, true);
			break;
		case UIEvent.Type.ClosedLootWheel:
			this.SwitchCondition(ComplexVisibilityManager.Condition.LootWheelOpen, false);
			break;
		case UIEvent.Type.OpenedSnoutCoinShop:
			this.SwitchCondition(ComplexVisibilityManager.Condition.SnoutCoinShopOpen, true);
			break;
		case UIEvent.Type.ClosedSnoutCoinShop:
			this.SwitchCondition(ComplexVisibilityManager.Condition.SnoutCoinShopOpen, false);
			break;
		case UIEvent.Type.OpenedLootCrateDialog:
			this.SwitchCondition(ComplexVisibilityManager.Condition.LootCrateDialogOpen, true);
			break;
		case UIEvent.Type.ClosedLootCrateDialog:
			this.SwitchCondition(ComplexVisibilityManager.Condition.LootCrateDialogOpen, false);
			break;
		default:
			if (type != UIEvent.Type.OpenIapMenu)
			{
				if (type == UIEvent.Type.CloseIapMenu)
				{
					this.SwitchCondition(ComplexVisibilityManager.Condition.ShopOpen, false);
				}
			}
			else
			{
				this.SwitchCondition(ComplexVisibilityManager.Condition.ShopOpen, true);
			}
			break;
		case UIEvent.Type.OpenedMainMenuPromo:
			this.SwitchCondition(ComplexVisibilityManager.Condition.MainMenuPromo, true);
			break;
		case UIEvent.Type.ClosedMainMenuPromo:
			this.SwitchCondition(ComplexVisibilityManager.Condition.MainMenuPromo, false);
			break;
		case UIEvent.Type.OpenedPurchaseConfirmation:
			this.SwitchCondition(ComplexVisibilityManager.Condition.PurchaseProductConfirmation, true);
			break;
		case UIEvent.Type.ClosedPurchaseConfirmation:
			this.SwitchCondition(ComplexVisibilityManager.Condition.PurchaseProductConfirmation, false);
			break;
		case UIEvent.Type.OpenedNotificationPopup:
			this.SwitchCondition(ComplexVisibilityManager.Condition.NotificationPopupOpen, true);
			break;
		case UIEvent.Type.ClosedNotificationPopup:
			this.SwitchCondition(ComplexVisibilityManager.Condition.NotificationPopupOpen, false);
			break;
		case UIEvent.Type.ShopLockedScreen:
			this.SwitchCondition(ComplexVisibilityManager.Condition.ShopLockedScreen, true);
			break;
		case UIEvent.Type.ShopUnlockedScreen:
			this.SwitchCondition(ComplexVisibilityManager.Condition.ShopLockedScreen, false);
			break;
		case UIEvent.Type.OpenedCakeRaceUnlockedPopup:
			this.SwitchCondition(ComplexVisibilityManager.Condition.CakeRaceUnlockDialogOpen, true);
			break;
		case UIEvent.Type.ClosedCakeRaceUnlockedPopup:
			this.SwitchCondition(ComplexVisibilityManager.Condition.CakeRaceUnlockDialogOpen, false);
			break;
		case UIEvent.Type.OpenedDailyChallengeDialog:
			this.SwitchCondition(ComplexVisibilityManager.Condition.DailyChallengeDialogOpen, true);
			break;
		case UIEvent.Type.ClosedDailyChallengeDialog:
			this.SwitchCondition(ComplexVisibilityManager.Condition.DailyChallengeDialogOpen, false);
			break;
		case UIEvent.Type.OpenedWorkshopIntroduction:
			this.SwitchCondition(ComplexVisibilityManager.Condition.WorkshopIntroductionOpen, true);
			break;
		case UIEvent.Type.ClosedWorkshopIntroduction:
			this.SwitchCondition(ComplexVisibilityManager.Condition.WorkshopIntroductionOpen, false);
			break;
		case UIEvent.Type.OpenedPurchaseRoadHogsParts:
			this.SwitchCondition(ComplexVisibilityManager.Condition.PurchaseRoadHogsPartsOpen, true);
			break;
		case UIEvent.Type.ClosedPurchaseRoadHogsParts:
			this.SwitchCondition(ComplexVisibilityManager.Condition.PurchaseRoadHogsPartsOpen, false);
			break;
		}
	}

	private void OnLoadlevel(LoadLevelEvent data)
	{
		this.ChangeGeneralGameState(data.currentGameState, false);
	}

	private void OnLevelLoaded(LevelLoadedEvent data)
	{
		this.ChangeGeneralGameState(data.currentGameState, true);
	}

	private void ChangeGeneralGameState(GameManager.GameState state, bool newState)
	{
		switch (state)
		{
		case GameManager.GameState.MainMenu:
			this.SwitchCondition(ComplexVisibilityManager.Condition.InMainMenu, newState);
			break;
		case GameManager.GameState.EpisodeSelection:
			this.SwitchCondition(ComplexVisibilityManager.Condition.InEpisodeSelection, newState);
			break;
		case GameManager.GameState.LevelSelection:
			this.SwitchCondition(ComplexVisibilityManager.Condition.InLevelSelection, newState);
			break;
		case GameManager.GameState.Level:
			this.SwitchCondition(ComplexVisibilityManager.Condition.InLevel, newState);
			break;
		case GameManager.GameState.KingPigFeeding:
			this.SwitchCondition(ComplexVisibilityManager.Condition.InKingPigFeed, newState);
			break;
		case GameManager.GameState.WorkShop:
			this.SwitchCondition(ComplexVisibilityManager.Condition.InWorkshop, newState);
			break;
		case GameManager.GameState.CakeRaceMenu:
			this.SwitchCondition(ComplexVisibilityManager.Condition.InCakeRaceMenu, newState);
			break;
		}
	}

	private void OnGameStateChanged(GameStateChanged data)
	{
		this.ChangeLevelGameState(data.prevState, false);
		this.ChangeLevelGameState(data.state, true);
	}

	private void ChangeLevelGameState(LevelManager.GameState state, bool newState)
	{
		if (state != LevelManager.GameState.Completed)
		{
			if (state == LevelManager.GameState.CakeRaceCompleted)
			{
				this.SwitchCondition(ComplexVisibilityManager.Condition.CakeRaceCompleteScreen, newState);
			}
		}
		else
		{
			this.SwitchCondition(ComplexVisibilityManager.Condition.LevelCompleteScreen, newState);
		}
	}

	private void SwitchCondition(Condition condition, bool newState)
	{
		if (this.states[condition] != newState)
		{
			this.states[condition] = newState;
			this.Evaluate();
		}
	}

	public void Subscribe(IComplexVisibilityObject listener, bool currentState)
	{
		if (!this.listeners.ContainsKey(listener))
		{
			this.listeners.Add(listener, currentState);
		}
		this.Evaluate();
	}

	public void Unsubscribe(IComplexVisibilityObject listener)
	{
		if (this.listeners.ContainsKey(listener))
		{
			this.listeners.Remove(listener);
		}
	}

	public void StateChanged(IComplexVisibilityObject listener, bool newState)
	{
		if (this.listeners.ContainsKey(listener))
		{
			this.listeners[listener] = newState;
		}
	}

	private void Evaluate()
	{
		Action action = null;
		foreach (KeyValuePair<IComplexVisibilityObject, bool> keyValuePair in this.listeners)
		{
			bool flag = this.Evaluate(keyValuePair.Key.ShowConditions);
			bool flag2 = this.Evaluate(keyValuePair.Key.HideConditions);
			bool flag3 = flag && !flag2;
			if (keyValuePair.Value != flag3)
			{
				IComplexVisibilityObject target = keyValuePair.Key;
				bool newState = flag3;
				action = (Action)Delegate.Combine(action, new Action(delegate()
				{
					this.listeners[target] = newState;
					target.OnStateChanged(newState);
				}));
			}
		}
		if (action != null)
		{
			action();
		}
	}

	private bool Evaluate(List<Condition> conditions)
	{
		for (int i = 0; i < conditions.Count; i++)
		{
			if (this.states[conditions[i]])
			{
				return true;
			}
		}
		return false;
	}

	private Dictionary<Condition, bool> states;

	private Dictionary<IComplexVisibilityObject, bool> listeners;

	public enum Condition
	{
		Always,
		ShopOpen,
		SnoutCoinShopOpen,
		LootWheelOpen,
		LootCrateDialogOpen,
		InMainMenu,
		InEpisodeSelection,
		InLevelSelection,
		InWorkshop,
		InCakeRaceMenu,
		InKingPigFeed,
		InLevel,
		LevelCompleteScreen,
		CakeRaceCompleteScreen,
		MainMenuPromo,
		PurchaseProductConfirmation,
		NotificationPopupOpen,
		ShopLockedScreen,
		IsOdyssey,
		CakeRaceUnlockDialogOpen,
		DailyChallengeDialogOpen,
		WorkshopIntroductionOpen,
		PurchaseRoadHogsPartsOpen
	}
}
