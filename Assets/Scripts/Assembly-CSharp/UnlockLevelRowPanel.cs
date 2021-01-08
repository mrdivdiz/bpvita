using UnityEngine;

public class UnlockLevelRowPanel : MonoBehaviour
{
	public event OnWatchAdPressed WatchAd;

	public event OnPayPressed Pay;

	public LevelRowUnlockDialog UnlockDialog
	{
		get
		{
			return this.unlockDialog;
		}
	}

	public Vector2 BackgroundScale
	{
		set
		{
			this.bgPanel.gameObject.transform.localScale = value;
			this.bgCollider.gameObject.transform.localScale = value;
		}
	}

	public int Page
	{
		get
		{
			return this.page;
		}
		set
		{
			this.page = value;
		}
	}

	public Vector2 RealSize
	{
		get
		{
			return new Vector2(this.bgCollider.size.x * this.bgCollider.transform.localScale.x, this.bgCollider.size.y * this.bgCollider.transform.localScale.y);
		}
	}

	public Vector2 UnscaledSize
	{
		get
		{
			return new Vector2(this.bgCollider.size.x, this.bgCollider.size.y);
		}
	}

	public Vector2 PanelSize
	{
		get
		{
			return new Vector2((float)this.bgPanel.m_width, (float)this.bgPanel.m_height);
		}
	}

	private void Awake()
	{
		this.openPopupButton = base.transform.Find("OpenPopupButton").gameObject;
		this.unlockDialog = UnityEngine.Object.Instantiate<GameObject>(this.unlockDialogPrefab).GetComponent<LevelRowUnlockDialog>();
		this.UnlockDialog.transform.position = new Vector3(0f, 0f, -95f);
		this.unlockDialog.Close();
	}

	private void Start()
	{
		this.PositionButton();
	}

	public void SetCost(int cost)
	{
		string text = string.Format("[snout] {0}", cost);
		GameObject gameObject = this.unlockDialog.transform.Find("PayUnlockBtn/Text").gameObject;
		gameObject.GetComponent<TextMesh>().text = text;
		gameObject = this.unlockDialog.transform.Find("PayUnlockBtnDisabled/Text").gameObject;
		gameObject.GetComponent<TextMesh>().text = text;
		this.unlockDialog.ShowConfirmEnabled = (() => GameProgress.SnoutCoinCount() >= cost);
	}

	public void AdButtonPressed()
	{
		if (this.WatchAd != null)
		{
			this.WatchAd();
		}
	}

	public void PayButtonPressed()
	{
		if (this.Pay != null)
		{
			this.Pay();
		}
	}

	public void OpenUnlockDialog()
	{
		this.unlockDialog.Open();
		UserSettings.SetInt(Singleton<GameManager>.Instance.CurrentSceneName + "_active_page", this.page);
		Transform transform = this.unlockDialog.transform.Find("PayUnlockBtn");
		if (transform)
		{
			Button component = transform.GetComponent<Button>();
			component.MethodToCall.SetMethod(this, "PayButtonPressed");
		}
	}

	public void PulseButton()
	{
		this.openPopupButton.GetComponent<Animation>().Play();
	}

	private void PositionButton()
	{
		float num = -this.RealSize.x / 2f;
		float x = this.openPopupButton.GetComponent<BoxCollider>().size.x;
		this.openPopupButton.transform.localPosition = new Vector3(num + x / 2f + this.buttonOffset, 0f, -5.1f);
	}

	[SerializeField]
	private GameObject unlockDialogPrefab;

	[SerializeField]
	private BoxCollider bgCollider;

	[SerializeField]
	private Panel bgPanel;

	[SerializeField]
	private float buttonOffset;

	private LevelRowUnlockDialog unlockDialog;

	private GameObject openPopupButton;

	private int page;

	public delegate void OnWatchAdPressed();

	public delegate void OnPayPressed();
}
