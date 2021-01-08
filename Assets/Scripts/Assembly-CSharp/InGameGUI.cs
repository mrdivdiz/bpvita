using UnityEngine;

public class InGameGUI : MonoBehaviour
{
	public InGameBuildMenu BuildMenu
	{
		get
		{
			return this.buildMenu;
		}
	}

	public InGameFlightMenu FlightMenu
	{
		get
		{
			return this.flightMenu;
		}
	}

	public PreviewMenu PreviewMenu
	{
		get
		{
			return this.previewMenu;
		}
	}

	public PausePage PauseMenu
	{
		get
		{
			return this.pauseMenu;
		}
	}

	public LevelComplete LevelCompleteMenu
	{
		get
		{
			return this.levelCompleteMenu;
		}
	}

	public TutorialBook TutorialBook
	{
		get
		{
			return this.tutorialBook;
		}
	}

	public InGameMechanicGift MechanicGiftScreen
	{
		get
		{
			return this.mechanicGiftScreen;
		}
	}

	public CakeRaceHUD CakeRaceHUD
	{
		get
		{
			return this.cakeRaceHud;
		}
	}

	private void Awake()
	{
		this.buildMenuGo = this.InstantiateMenu(this.buildMenuPrefab);
		this.flightMenuGo = this.InstantiateMenu(this.flightMenuPrefab);
		this.previewMenuGo = this.InstantiateMenu(this.previewMenuPrefab);
		this.pauseMenuGo = this.InstantiateMenu(this.pauseMenuPrefab);
		this.levelCompleteMenuGo = this.InstantiateMenu(this.levelCompleteMenuPrefab);
		this.tutorialBookMenuGo = this.InstantiateMenu(this.tutorialBookMenuPrefab);
		this.mechanicGiftScreenGo = this.InstantiateMenu(this.mechanicGiftScreenPrefab);
		this.cakeRaceCompleteMenuGo = this.InstantiateMenu(this.cakeRaceCompleteMenuPrefab);
		this.buildMenu = this.buildMenuGo.GetComponent<InGameBuildMenu>();
		this.flightMenu = this.flightMenuGo.GetComponent<InGameFlightMenu>();
		this.previewMenu = this.previewMenuGo.GetComponent<PreviewMenu>();
		this.pauseMenu = this.pauseMenuGo.GetComponent<PausePage>();
		this.levelCompleteMenu = this.levelCompleteMenuGo.GetComponent<LevelComplete>();
		this.tutorialBook = this.tutorialBookMenuGo.GetComponent<TutorialBook>();
		this.mechanicGiftScreen = this.mechanicGiftScreenGo.GetComponent<InGameMechanicGift>();
		this.cakeRaceCompleteMenu = this.cakeRaceCompleteMenuGo.GetComponent<CakeRaceComplete>();
		this.cakeRaceHud = this.flightMenuGo.GetComponentInChildren<CakeRaceHUD>();
	}

	private GameObject InstantiateMenu(GameObject prefab)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(prefab);
		gameObject.name = prefab.name;
		gameObject.transform.position = base.transform.position;
		gameObject.transform.parent = base.transform;
		gameObject.SetActive(false);
		return gameObject;
	}

	private void OnEnable()
	{
		EventManager.Connect(new EventManager.OnEvent<GameStateChanged>(this.ReceiveGameStateChangedEvent));
	}

	private void OnDisable()
	{
		EventManager.Disconnect(new EventManager.OnEvent<GameStateChanged>(this.ReceiveGameStateChangedEvent));
	}

	private void ReceiveGameStateChangedEvent(GameStateChanged data)
	{
		switch (data.state)
		{
		case LevelManager.GameState.Building:
			this.SetMenu(this.buildMenuGo);
			break;
		case LevelManager.GameState.PreviewWhileBuilding:
			this.SetMenu(this.previewMenuGo);
			break;
		case LevelManager.GameState.PreviewWhileRunning:
			this.SetMenu(this.previewMenuGo);
			break;
		case LevelManager.GameState.Running:
		case LevelManager.GameState.Continue:
			this.SetMenu(this.flightMenuGo);
			break;
		case LevelManager.GameState.Completed:
			this.SetMenu(this.levelCompleteMenuGo);
			break;
		case LevelManager.GameState.PausedWhileRunning:
			this.SetMenu(this.pauseMenuGo);
			break;
		case LevelManager.GameState.PausedWhileBuilding:
			this.SetMenu(this.pauseMenuGo);
			break;
		case LevelManager.GameState.TutorialBook:
			this.SetMenu(this.tutorialBookMenuGo);
			break;
		case LevelManager.GameState.ShowingUnlockedParts:
			this.SetMenu(this.buildMenuGo);
			break;
		case LevelManager.GameState.MechanicGiftScreen:
			this.SetMenu(this.mechanicGiftScreenGo);
			break;
		case LevelManager.GameState.LootCrateOpening:
			this.SetMenu(null);
			break;
		case LevelManager.GameState.CakeRaceCompleted:
			this.SetMenu(this.cakeRaceCompleteMenuGo);
			break;
		}
	}

	private void SetMenu(GameObject menu)
	{
		if (menu == this.currentMenu)
		{
			return;
		}
		this.ShowCurrentMenu(false);
		this.currentMenu = menu;
		if (this.currentMenu)
		{
			this.currentMenu.SetActive(true);
		}
	}

	public void ShowCurrentMenu(bool show = true)
	{
		if (this.currentMenu)
		{
			this.currentMenu.SetActive(show);
		}
	}

	public void Hide()
	{
		base.gameObject.SetActive(false);
	}

	public void Show()
	{
		base.gameObject.SetActive(true);
	}

	public GameObject buildMenuPrefab;

	public GameObject flightMenuPrefab;

	public GameObject previewMenuPrefab;

	public GameObject pauseMenuPrefab;

	public GameObject levelCompleteMenuPrefab;

	public GameObject tutorialBookMenuPrefab;

	public GameObject mechanicGiftScreenPrefab;

	public GameObject cakeRaceCompleteMenuPrefab;

	private GameObject buildMenuGo;

	private GameObject flightMenuGo;

	private GameObject previewMenuGo;

	private GameObject pauseMenuGo;

	private GameObject levelCompleteMenuGo;

	private GameObject tutorialBookMenuGo;

	private GameObject mechanicGiftScreenGo;

	private GameObject cakeRaceCompleteMenuGo;

	private InGameBuildMenu buildMenu;

	private InGameFlightMenu flightMenu;

	private PreviewMenu previewMenu;

	private PausePage pauseMenu;

	private LevelComplete levelCompleteMenu;

	private TutorialBook tutorialBook;

	private InGameMechanicGift mechanicGiftScreen;

	private CakeRaceComplete cakeRaceCompleteMenu;

	private CakeRaceHUD cakeRaceHud;

	private GameObject currentMenu;
}
