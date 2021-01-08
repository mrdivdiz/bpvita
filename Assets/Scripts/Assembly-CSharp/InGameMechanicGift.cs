using UnityEngine;

public class InGameMechanicGift : WPFMonoBehaviour
{
	private void Awake()
	{
		if (Singleton<Localizer>.Instance.CurrentLocale == "ja-JP")
		{
			base.transform.FindChildRecursively("FreeGiftFrom").GetComponent<TextMesh>().characterSize = 0.8f;
		}
		this.m_random = new System.Random();
	}

	private void SetTexture(Texture2D texture)
	{
		this.m_texture = texture;
		this.m_sprite = base.GetComponentInChildren<UnmanagedSprite>();
		this.m_sprite.GetComponent<Renderer>().sharedMaterial.mainTexture = this.m_texture;
	}

	private void SendClose()
	{
		EventManager.Send(new UIEvent(UIEvent.Type.CloseMechanicInfo));
	}

	private void OnEnable()
	{
		Singleton<KeyListener>.Instance.GrabFocus(this);
		KeyListener.keyReleased += this.HandleKeyListenerkeyReleased;
		if (WPFMonoBehaviour.levelManager.gameState != LevelManager.GameState.MechanicGiftScreen)
		{
			return;
		}
		this.superGlueButton.SetActive(false);
		this.turboChargeButton.SetActive(false);
		this.superMagnetButton.SetActive(false);
		Texture2D rewardNativeTexture = AdvertisementHandler.GetRewardNativeTexture();
		if (!WPFMonoBehaviour.levelManager.m_SuperGlueAllowed && !WPFMonoBehaviour.levelManager.m_SuperMagnetAllowed && !WPFMonoBehaviour.levelManager.m_TurboChargeAllowed)
		{
			this.SendClose();
		}
		else if (rewardNativeTexture != null)
		{
			this.GiveGift();
			this.SetTexture(rewardNativeTexture);
		}
		else
		{
			this.SendClose();
		}
	}

	private void OnDestroy()
	{
		this.m_texture = null;
		Resources.UnloadUnusedAssets();
	}

	private void OnDisable()
	{
		KeyListener.keyReleased -= this.HandleKeyListenerkeyReleased;
		Singleton<KeyListener>.Instance.ReleaseFocus(this);
	}

	private void HandleKeyListenerkeyReleased(KeyCode obj)
	{
		if (obj == KeyCode.Escape)
		{
			this.SendClose();
		}
	}

	private void GiveGift()
	{
		int num = this.m_random.Next(0, 3);
		string customTypeOfGain = "Branded reward";
		switch (num)
		{
		default:
			if (!WPFMonoBehaviour.levelManager.m_SuperGlueAllowed)
			{
				this.GiveGift();
			}
			else
			{
				this.superGlueButton.SetActive(true);
				GameProgress.AddSuperGlue(1);
				if (Singleton<IapManager>.Instance != null)
				{
					Singleton<IapManager>.Instance.SendFlurryInventoryGainEvent(IapManager.InAppPurchaseItemType.SuperGlueSingle, 1, customTypeOfGain);
				}
			}
			break;
		case 1:
			if (!WPFMonoBehaviour.levelManager.m_TurboChargeAllowed)
			{
				this.GiveGift();
			}
			else
			{
				this.turboChargeButton.SetActive(true);
				GameProgress.AddTurboCharge(1);
				if (Singleton<IapManager>.Instance != null)
				{
					Singleton<IapManager>.Instance.SendFlurryInventoryGainEvent(IapManager.InAppPurchaseItemType.TurboChargeSingle, 1, customTypeOfGain);
				}
			}
			break;
		case 2:
			if (!WPFMonoBehaviour.levelManager.m_SuperMagnetAllowed)
			{
				this.GiveGift();
			}
			else
			{
				this.superMagnetButton.SetActive(true);
				GameProgress.AddSuperMagnet(1);
				if (Singleton<IapManager>.Instance != null)
				{
					Singleton<IapManager>.Instance.SendFlurryInventoryGainEvent(IapManager.InAppPurchaseItemType.SuperMagnetSingle, 1, customTypeOfGain);
				}
			}
			break;
		}
	}

	private void Start()
	{
	}

	private void Update()
	{
		this.m_sprite.ResetSize();
		Vector3 zero = Vector3.zero;
		float num = 20f * WPFMonoBehaviour.hudCamera.aspect;
		float num2 = 20f;
		zero.x = 11.5f / num * (float)Screen.width;
		zero.y = 6.75f / num2 * (float)Screen.height;
		float num3 = Mathf.Max(zero.x / (float)this.m_texture.width, zero.y / (float)this.m_texture.height);
		num3 *= 768f / (float)Screen.height;
		this.m_sprite.transform.localScale = new Vector3(num3, num3, 1f);
	}

	private UnmanagedSprite m_sprite;

	private Texture2D m_texture;

	private System.Random m_random;

	public GameObject superGlueButton;

	public GameObject turboChargeButton;

	public GameObject superMagnetButton;
}
