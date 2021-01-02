using System.Collections;
using UnityEngine;

public class MainMenuPromoPopup : MonoBehaviour
{
	private void Awake()
	{
		UnityEngine.Debug.LogWarning("MainMenuPromoPopup::Awake");
		this.sprite = base.GetComponentInChildren<UnmanagedSprite>();
		this.closeSprite = base.transform.Find("Close").gameObject.GetComponent<Sprite>();
		if (AdvertisementHandler.MainMenuPromoRenderable != null)
		{
			if (AdvertisementHandler.GetMainMenuPopupTexture() != null)
			{
				UnityEngine.Debug.LogWarning("MainMenuPromoPopup::Awake::OnRenderableReady");
				this.OnRenderableReady(true);
			}
		}
		else
		{
			UnityEngine.Debug.LogWarning("MainMenuPromoPopup::Awake::MainMenuPromoRenderable is NULL");
		}
		Dialog component = base.GetComponent<Dialog>();
		if (component != null)
		{
			component.onOpen += this.HideObjects;
			base.GetComponent<Dialog>().onClose += this.HandleClose;
		}
		EventManager.Connect(new EventManager.OnEvent<LevelLoadedEvent>(this.OnLevelLoaded));
		UnityEngine.Object.DontDestroyOnLoad(this);
	}

	private void OnLevelLoaded(LevelLoadedEvent data)
	{
		GameManager.GameState gameState = Singleton<GameManager>.Instance.GetGameState();
		if (base.gameObject.activeSelf && (gameState == GameManager.GameState.Level || gameState == GameManager.GameState.Cutscene))
		{
			base.GetComponent<Dialog>().Close();
		}
		else if (!base.gameObject.activeSelf && AdvertisementHandler.GetMainMenuPopupTexture() != null)
		{
			this.OnRenderableReady(true);
		}
	}

	private void OnDestroy()
	{
		EventManager.Disconnect(new EventManager.OnEvent<LevelLoadedEvent>(this.OnLevelLoaded));
		if (AdvertisementHandler.MainMenuPromoRenderable != null)
		{
		}
	}

	public void OnPressed()
	{
		if (Time.time - this.showTime > 0.5f)
		{
			base.gameObject.SetActive(false);
			base.GetComponent<Dialog>().Close();
		}
	}

	private void Update()
	{
		if (this.m_hudCamera == null)
		{
			GameObject gameObject = GameObject.FindWithTag("HUDCamera");
			if (gameObject != null)
			{
				this.m_hudCamera = gameObject.GetComponent<Camera>();
				this.Layout(this.m_hudCamera);
			}
		}
		this.HideObjects();
	}

	private void HideObjects()
	{
		GameManager.GameState gameState = Singleton<GameManager>.Instance.GetGameState();
		if (this.objectToShowOnClose == null)
		{
			string text = null;
			switch (gameState)
			{
			case GameManager.GameState.MainMenu:
				text = "MainMenuPage";
				break;
			case GameManager.GameState.EpisodeSelection:
				text = "EpisodeSelector";
				break;
			case GameManager.GameState.LevelSelection:
			case GameManager.GameState.SandboxLevelSelection:
			case GameManager.GameState.RaceLevelSelection:
				this.objectToShowOnClose = GameObject.Find("LevelSelector");
				if (this.objectToShowOnClose == null)
				{
					this.objectToShowOnClose = GameObject.Find("RaceLevelSelector");
					if (this.objectToShowOnClose == null)
					{
						this.objectToShowOnClose = GameObject.Find("SandboxSelector");
					}
				}
				break;
			}
			if (this.objectToShowOnClose == null && text != null)
			{
				this.objectToShowOnClose = GameObject.Find(text);
			}
		}
		if (this.objectToShowOnClose != null && this.objectToShowOnClose.activeSelf)
		{
			this.objectToShowOnClose.SetActive(false);
		}
	}

	private void HandleClose()
	{
		if (this.objectToShowOnClose)
		{
			this.objectToShowOnClose.SetActive(true);
		}
		Texture mainTexture = base.transform.Find("Popup").GetComponent<Renderer>().sharedMaterial.mainTexture;
		if (mainTexture)
		{
			UnityEngine.Object.Destroy(mainTexture);
			Resources.UnloadUnusedAssets();
		}
		this.OnRenderableHide();
	}

	private bool IsAllowedToShow()
	{
		GameManager.GameState gameState = Singleton<GameManager>.Instance.GetGameState();
		MainMenu mainMenu = UnityEngine.Object.FindObjectOfType(typeof(MainMenu)) as MainMenu;
		return (gameState == GameManager.GameState.MainMenu && mainMenu != null && mainMenu.IsUserInMainMenu()) || gameState == GameManager.GameState.RaceLevelSelection || gameState == GameManager.GameState.SandboxLevelSelection || gameState == GameManager.GameState.LevelSelection;
	}

	private void Layout(Camera hudCamera)
	{
		Texture mainTexture = this.sprite.GetComponent<Renderer>().sharedMaterial.mainTexture;
		if (mainTexture != null)
		{
			this.sprite.ResetSize();
			float num = 1f;
			if (mainTexture.width > Screen.width || mainTexture.height > Screen.height)
			{
				num = (float)Mathf.Min(Screen.width / mainTexture.width, Screen.height / mainTexture.height);
			}
			num *= 768f / (float)Screen.height;
			this.sprite.transform.localScale = new Vector3(num, num, 1f);
			Rect rect = new Rect((float)(Screen.width - mainTexture.width) / 2f, (float)(Screen.height - mainTexture.height) / 2f, (float)mainTexture.width, (float)mainTexture.height);
			float max = (float)Screen.width / (float)Screen.height * 10f - 1.4f;
			float max2 = 8.6f;
			Vector2 v = new Vector2((float)mainTexture.width + rect.x, (float)mainTexture.height + rect.y);
			v = hudCamera.ScreenToWorldPoint(v);
			v.x = Mathf.Clamp(v.x, 0f, max);
			v.y = Mathf.Clamp(v.y, 0f, max2);
			this.closeSprite.transform.position = new Vector3(v.x, v.y, -80f);
		}
	}

	private void OnRenderableReady(bool isReady)
	{
		if (!UnityEngine.Application.isPlaying)
		{
			return;
		}
		if (AdvertisementHandler.MainMenuPromoRenderable == null || !isReady)
		{
			return;
		}
		UnityEngine.Debug.LogWarning("MainMenuPromoPopup::OnRenderableReady texture set");
		this.sprite.GetComponent<Renderer>().sharedMaterial.mainTexture = AdvertisementHandler.GetMainMenuPopupTexture();
		if (this.IsAllowedToShow())
		{
			CoroutineRunner.Instance.StartCoroutine(this.DelayShow());
		}
	}

	private IEnumerator DelayShow()
	{
		UnityEngine.Debug.LogWarning("MainMenuPromoPopup::DelayShow(): BEFORE");
		yield return new WaitForEndOfFrame();
		UnityEngine.Debug.LogWarning("MainMenuPromoPopup::DelayShow(): AFTER");
		this.OnRenderableShow();
		yield break;
	}

	public void OnRenderableShow()
	{
		UnityEngine.Debug.LogWarning("OnRenderableShow: MainMenuPromoPopup");
		if (this.IsAllowedToShow())
		{
			UnityEngine.Debug.LogWarning("SHOW: MainMenuPromoPopup");
			this.showTime = Time.time;
			base.GetComponent<Dialog>().Open();
			EventManager.Send(new UIEvent(UIEvent.Type.OpenedMainMenuPromo));
		}
	}

	public void OnRenderableHide()
	{
		GameManager.GameState gameState = Singleton<GameManager>.Instance.GetGameState();
		base.gameObject.SetActive(false);
		EventManager.Send(new UIEvent(UIEvent.Type.ClosedMainMenuPromo));
	}

	private UnmanagedSprite sprite;

	private Sprite closeSprite;

	private GameObject objectToShowOnClose;

	private float showTime;

	private Camera m_hudCamera;
}
