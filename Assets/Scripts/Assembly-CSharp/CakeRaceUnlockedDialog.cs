public class CakeRaceUnlockedDialog : TextDialog
{
	protected override void Awake()
	{
		base.Awake();
		base.onClose += this.HandleClosed;
		this.m_try = false;
		ResourceBar.Instance.ShowItem(ResourceBar.Item.PlayerProgress, true, false);
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		EventManager.Send(new UIEvent(UIEvent.Type.OpenedCakeRaceUnlockedPopup));
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		EventManager.Send(new UIEvent(UIEvent.Type.ClosedCakeRaceUnlockedPopup));
	}

	private void OnDestroy()
	{
		base.onClose -= this.HandleClosed;
	}

	public void TryNow()
	{
		this.m_try = true;
		this.Close();
	}

	public new void Close()
	{
		if (this.m_try)
		{
			this.ForceCakeRace();
		}
		else
		{
			this.UnlockCakeRace();
		}
		base.Close();
	}

	private void ForceCakeRace()
	{
		MainMenu mainMenu = UnityEngine.Object.FindObjectOfType<MainMenu>();
		if (Singleton<GameManager>.Instance.GetGameState() == GameManager.GameState.MainMenu && mainMenu != null)
		{
			mainMenu.ForceCakeRaceButton();
		}
		else
		{
			Singleton<GameManager>.Instance.LoadMainMenu(true);
		}
	}

	private void UnlockCakeRace()
	{
		MainMenu mainMenu = UnityEngine.Object.FindObjectOfType<MainMenu>();
		if (Singleton<GameManager>.Instance.GetGameState() == GameManager.GameState.MainMenu && mainMenu != null)
		{
			mainMenu.UnlockCakeRaceButton();
		}
	}

	private void HandleClosed()
	{
		UnityEngine.Object.Destroy(base.gameObject);
	}

	private bool m_try;
}
