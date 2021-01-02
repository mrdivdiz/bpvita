using System;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class TextDialog : WPFMonoBehaviour
{
	public event OnClose onClose;

	public event OnOpen onOpen;

	private event OnConfirm onConfirm;

	public event OnOpen onShopPageOpened;

	public Func<bool> ShowConfirmEnabled
	{
		get
		{
			return this.showConfirmEnabled;
		}
		set
		{
			this.showConfirmEnabled = value;
		}
	}

	public string ConfirmButtonText
	{
		get
		{
			if (this.enabledConfirmButtonTxt != null && this.enabledConfirmButtonTxt.Length > 0)
			{
				return this.enabledConfirmButtonTxt[0].text;
			}
			return string.Empty;
		}
		set
		{
			if (this.enabledConfirmButtonTxt != null)
			{
				for (int i = 0; i < this.enabledConfirmButtonTxt.Length; i++)
				{
					this.enabledConfirmButtonTxt[i].text = value;
					this.enabledConfirmButtonTxt[i].SendMessage("TextUpdated", SendMessageOptions.DontRequireReceiver);
				}
			}
			if (this.disabledConfirmButtonTxt != null)
			{
				for (int j = 0; j < this.disabledConfirmButtonTxt.Length; j++)
				{
					this.disabledConfirmButtonTxt[j].text = value;
					this.disabledConfirmButtonTxt[j].SendMessage("TextUpdated", SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}

	public static bool DialogOpen
	{
		get
		{
			return TextDialog.s_dialogOpen;
		}
	}

	public bool IsOpen
	{
		get
		{
			return this.isOpened;
		}
	}

	protected virtual void Awake()
	{
		if (this.enabledConfirmButton)
		{
			this.enabledConfirmButtonTxt = this.enabledConfirmButton.GetComponentsInChildren<TextMesh>();
			this.enabledConfirmButton.SetActive(true);
		}
		if (this.disabledConfirmButton)
		{
			this.disabledConfirmButtonTxt = this.disabledConfirmButton.GetComponentsInChildren<TextMesh>();
			this.disabledConfirmButton.SetActive(false);
		}
		this.hidden = false;
		this.appearAnimation = base.GetComponent<SkeletonAnimation>();
		Transform transform = base.transform.Find("SkeletonUtility-Root/root/BN_Shake");
		if (transform)
		{
			this.dialogRoot = transform.gameObject;
		}
	}

	protected virtual void Start()
	{
		for (int i = 0; i < this.texts.Length; i++)
		{
			this.texts[i].textMesh.text = this.texts[i].localizationKey;
			TextMeshLocale component = this.texts[i].textMesh.gameObject.GetComponent<TextMeshLocale>();
			if (component != null)
			{
				component.RefreshTranslation(null);
				component.enabled = false;
				TextMeshHelper.Wrap(this.texts[i].textMesh, (!TextMeshHelper.UsesKanjiCharacters()) ? this.maxCharactersInLine : this.maxKanjiCharacterInLine, false);
			}
		}
	}

	public virtual void Open()
	{
		if (this.isOpened)
		{
			return;
		}
		this.isOpened = true;
		base.gameObject.SetActive(true);
		this.UpdateTextMeshSpriteIcons();
		this.PlayAppearAnimation();
		if (this.onOpen != null)
		{
			this.onOpen();
		}
	}

	public virtual void Close()
	{
		this.isOpened = false;
		base.gameObject.SetActive(false);
		if (this.onClose != null)
		{
			this.onClose();
		}
	}

	public void Confirm()
	{
		if (this.onConfirm != null)
		{
			this.onConfirm();
		}
	}

	public void OpenShop()
	{
		if (Singleton<IapManager>.IsInstantiated())
		{
			Singleton<IapManager>.Instance.OpenShopPage(new Action(this.EnableConfirmButton), "SnoutCoinShop");
		}
	}

	public void OpenShopPageAndClose(string shopPage)
	{
		if (Singleton<IapManager>.IsInstantiated())
		{
			MainMenu mainMenu = UnityEngine.Object.FindObjectOfType<MainMenu>();
			if (string.IsNullOrEmpty(shopPage) && mainMenu != null)
			{
				mainMenu.OpenShop();
			}
			else
			{
				Singleton<IapManager>.Instance.OpenShopPage(null, shopPage);
			}
			if (this.onShopPageOpened != null)
			{
				this.onShopPageOpened();
			}
		}
		this.Close();
	}

	public void SetOnConfirm(OnConfirm onConfirm)
	{
		this.onConfirm = onConfirm;
	}

	protected void EnableConfirmButton()
	{
		if (this.showConfirmEnabled != null)
		{
			this.EnableConfirmButton(this.showConfirmEnabled());
		}
	}

	protected void EnableConfirmButton(bool enable)
	{
		if (this.enabledConfirmButton && this.disabledConfirmButton)
		{
			this.enabledConfirmButton.SetActive(enable);
			this.disabledConfirmButton.SetActive(!enable);
		}
	}

	protected virtual void OnEnable()
	{
		this.isOpened = true;
		Singleton<GuiManager>.Instance.GrabPointer(this);
		Singleton<KeyListener>.Instance.GrabFocus(this);
		KeyListener.keyReleased += this.HandleKeyReleased;
		this.EnableConfirmButton();
		TextDialog.s_dialogOpen = true;
	}

	protected virtual void OnDisable()
	{
		this.isOpened = false;
		if (Singleton<GuiManager>.IsInstantiated())
		{
			Singleton<GuiManager>.Instance.ReleasePointer(this);
		}
		if (Singleton<KeyListener>.IsInstantiated())
		{
			Singleton<KeyListener>.Instance.ReleaseFocus(this);
		}
		KeyListener.keyReleased -= this.HandleKeyReleased;
		TextDialog.s_dialogOpen = false;
	}

	protected void HandleKeyReleased(KeyCode key)
	{
		if (key == KeyCode.Escape)
		{
			this.Close();
		}
	}

	protected void PlayAppearAnimation()
	{
		if (this.appearAnimation != null && this.dialogRoot != null)
		{
			List<Renderer> renderers = base.GetActiveComponents<Renderer>();
			for (int i = 0; i < renderers.Count; i++)
			{
				renderers[i].enabled = false;
			}
			if (this.appearAnimation.state == null)
			{
				this.appearAnimation.Initialize(true);
			}
			this.appearAnimation.state.ClearTracks();
			this.appearAnimation.state.SetAnimation(0, "PopUp", false);
			base.StartCoroutine(CoroutineRunner.DelayFrames(delegate
			{
				for (int j = 0; j < renderers.Count; j++)
				{
					if (renderers[j] != null)
					{
						renderers[j].enabled = true;
					}
				}
			}, 1));
		}
	}

	protected void Hide()
	{
		if (this.hidden)
		{
			return;
		}
		this.activeColliders = base.GetActiveComponents<Collider>();
		this.activeRenderers = base.GetActiveComponents<Renderer>();
		for (int i = 0; i < this.activeColliders.Count; i++)
		{
			this.activeColliders[i].enabled = false;
		}
		for (int j = 0; j < this.activeRenderers.Count; j++)
		{
			this.activeRenderers[j].enabled = false;
		}
		this.hidden = true;
	}

	protected void Show()
	{
		if (this.activeColliders == null || this.activeRenderers == null)
		{
		}
		for (int i = 0; i < this.activeColliders.Count; i++)
		{
			this.activeColliders[i].enabled = true;
		}
		for (int j = 0; j < this.activeRenderers.Count; j++)
		{
			this.activeRenderers[j].enabled = true;
		}
		this.hidden = false;
	}

	public void UpdateTextMeshSpriteIcons()
	{
		TextMesh[] componentsInChildren = base.gameObject.GetComponentsInChildren<TextMesh>(true);
		if (componentsInChildren == null || componentsInChildren.Length == 0)
		{
			return;
		}
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			TextMeshSpriteIcons.EnsureSpriteIcon(componentsInChildren[i]);
		}
	}

	private const string APPEAR_ANIMATION_NAME = "PopUp";

	[SerializeField]
	protected int maxCharactersInLine;

	[SerializeField]
	protected int maxKanjiCharacterInLine;

	[SerializeField]
	protected TextKeyPair[] texts;

	[SerializeField]
	private GameObject enabledConfirmButton;

	[SerializeField]
	private GameObject disabledConfirmButton;

	[SerializeField]
	private bool positionSoftCurrencyButton;

	[SerializeField]
	private SoftCurrencyButton.Position softCurrencyPosition;

	private SkeletonAnimation appearAnimation;

	private TextMesh[] enabledConfirmButtonTxt;

	private TextMesh[] disabledConfirmButtonTxt;

	private Func<bool> showConfirmEnabled;

	private List<Renderer> activeRenderers;

	private List<Collider> activeColliders;

	private bool hidden;

	protected GameObject dialogRoot;

	protected bool isOpened;

	protected static bool s_dialogOpen;

	public delegate void OnClose();

	public delegate void OnOpen();

	public delegate void OnConfirm();

	[Serializable]
	protected struct TextKeyPair
	{
		[SerializeField]
		public string localizationKey;

		[SerializeField]
		public TextMesh textMesh;
	}

	[Serializable]
	protected class LocalizeSprite
	{
		public static string GetLocalizedSprite(LocalizeSprite[] data, string localeId)
		{
			if (data.Length <= 0)
			{
				return string.Empty;
			}
			string empty = string.Empty;
			for (int i = 0; i < data.Length; i++)
			{
				if (data[i].localizationId.Equals(localeId))
				{
					return data[i].spriteId;
				}
			}
			if (string.IsNullOrEmpty(empty) && !localeId.Equals("en-EN"))
			{
				return TextDialog.LocalizeSprite.GetLocalizedSprite(data, "en-EN");
			}
			return data[0].localizationId;
		}

		[SerializeField]
		public string spriteId;

		[SerializeField]
		private string localizationId;
	}

	[Serializable]
	protected class SpriteScale
	{
		public static bool GetCustomScale(SpriteScale[] data, string spriteId, out Vector2 scale)
		{
			for (int i = 0; i < data.Length; i++)
			{
				if (data[i].spriteId.Equals(spriteId))
				{
					scale = data[i].scale;
					return true;
				}
			}
			scale = Vector2.zero;
			return false;
		}

		[SerializeField]
		public string spriteId;

		[SerializeField]
		private Vector2 scale;
	}
}
