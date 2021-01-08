using UnityEngine;

public class CrateCompassIndicator : WPFMonoBehaviour
{
	public bool Done
	{
		get
		{
			return this.m_done;
		}
	}

	private void Awake()
	{
		this.m_viewHalfWidth = 10f * (float)Screen.width / (float)Screen.height;
		this.m_viewHalfHeight = this.m_viewHalfWidth * (float)Screen.height / (float)Screen.width;
		this.m_meter = base.transform.Find("CrateCompassArrow/DistanceMeter").GetComponent<LineRenderer>();
	}

	private void Update()
	{
		if (this.m_crate == null || this.m_crate.collected || this.m_crate.transform.position.y < -20f)
		{
			this.TurnOff();
			return;
		}
		this.UpdateArrow();
		this.DrawMeter(this.m_normalizedDistance);
	}

	public void AttachToCrate(LootCrate crate)
	{
		this.m_crate = crate;
		this.SetCrateImage();
	}

	public void Show()
	{
		if (this.m_crate == null || this.m_crate.Collected)
		{
			this.TurnOff();
			return;
		}
		if (!base.gameObject.activeInHierarchy)
		{
			this.SetCrateImage();
			this.UpdateArrow();
			base.gameObject.SetActive(true);
		}
	}

	public void Hide()
	{
		if (base.gameObject.activeInHierarchy)
		{
			base.gameObject.SetActive(false);
		}
	}

	private void TurnOff()
	{
		this.m_done = true;
		base.gameObject.SetActive(false);
	}

	private void SetCrateImage()
	{
		if (this.m_crate == null || this.m_currentSprite != null)
		{
			return;
		}
		this.m_currentSprite = LootCrateGraphicSpawner.CreateCrateSmall(this.m_crate.CrateType, this.m_spriteParent, Vector3.zero, Vector3.one, Quaternion.identity);
		LayerHelper.SetLayer(this.m_currentSprite, base.gameObject.layer, true);
	}

	private void DrawMeter(float ratio)
	{
		int num = (int)(ratio * 2f * 3.14159274f / 0.08726647f) + 1;
		this.m_meter.SetVertexCount(num);
		for (int i = 0; i < num; i++)
		{
			float f = 1.57079637f - (float)i * 0.08726647f;
			float x = 0.9f * Mathf.Cos(f);
			float y = 0.9f * Mathf.Sin(f);
			this.m_meter.SetPosition(i, new Vector3(x, y));
		}
	}

	private void UpdateArrow()
	{
		if (this.m_crate == null)
		{
			return;
		}
		float num = 0f;
		float num2 = 0f;
		if (WPFMonoBehaviour.hudCamera)
		{
			num = WPFMonoBehaviour.hudCamera.transform.position.x;
			num2 = WPFMonoBehaviour.hudCamera.transform.position.y;
		}
		Vector3 position = WPFMonoBehaviour.mainCamera.transform.position;
		Vector2 vector = this.m_crate.transform.position - position;
		vector.Normalize();
		float num3 = Mathf.Min(Mathf.Abs(this.m_viewHalfWidth / vector.x), Mathf.Abs(this.m_viewHalfHeight / vector.y));
		vector.Scale(new Vector3(num3 + this.m_offset, num3 + this.m_offset, 0f));
		float orthographicSize = WPFMonoBehaviour.mainCamera.orthographicSize;
		float x = Mathf.Clamp(Mathf.Abs(this.m_crate.transform.position.x - position.x), orthographicSize * (float)Screen.width / (float)Screen.height, 50f) - orthographicSize * (float)Screen.width / (float)Screen.height;
		float y = Mathf.Clamp(Mathf.Abs(this.m_crate.transform.position.y - position.y), orthographicSize, 50f) - orthographicSize;
		Vector3 vector2 = new Vector3(x, y, 0f);
		this.m_normalizedDistance = Mathf.Clamp01(vector2.magnitude / 50f);
		base.transform.position = new Vector3(num + vector.x, num2 + vector.y, base.transform.position.z);
		Transform child = base.transform.GetChild(0);
		if (child != null)
		{
			child.localRotation = Quaternion.LookRotation(child.forward, new Vector3(vector.x, vector.y, 0f));
		}
	}

	public bool CheckCrateOnScreen()
	{
		Vector3 position = Camera.main.transform.position;
		return Mathf.Abs(this.m_crate.transform.position.y - position.y) < Camera.main.orthographicSize && Mathf.Abs(this.m_crate.transform.position.x - position.x) < Camera.main.orthographicSize * (float)Screen.width / (float)Screen.height;
	}

	private const float DEFAULT_CAMERA_SIZE = 10f;

	private const float MAX_DISTANCE = 50f;

	[SerializeField]
	private float m_offset;

	[SerializeField]
	private Transform m_spriteParent;

	private LootCrate m_crate;

	private GameObject m_currentSprite;

	private float m_viewHalfWidth;

	private float m_viewHalfHeight;

	private bool m_done;

	private LineRenderer m_meter;

	private float m_normalizedDistance;
}
