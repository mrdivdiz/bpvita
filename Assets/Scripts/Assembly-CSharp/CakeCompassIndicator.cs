using CakeRace;
using UnityEngine;

public class CakeCompassIndicator : MonoBehaviour
{
	public bool Done
	{
		get
		{
			return this.m_done;
		}
	}

	public void AttachToCake(Cake cake)
	{
		this.m_cake = cake;
	}

	public void Show()
	{
		if (this.m_cake == null || this.m_cake.collected)
		{
			this.TurnOff();
			return;
		}
		if (!base.gameObject.activeInHierarchy)
		{
			this.SetCakeImage();
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

	private void SetCakeImage()
	{
	}

	private void Awake()
	{
		this.m_viewHalfWidth = 10f * (float)Screen.width / (float)Screen.height;
		this.m_viewHalfHeight = this.m_viewHalfWidth * (float)Screen.height / (float)Screen.width;
		this.m_animation = base.GetComponent<SpriteAnimation>();
		this.m_compassAnimation = base.transform.Find("CakeCompassArrow").GetComponent<SpriteAnimation>();
		this.m_meter = base.transform.Find("CakeCompassArrow/DistanceMeter").GetComponent<LineRenderer>();
	}

	private void Update()
	{
		if (this.m_cake == null || this.m_cake.collected || this.m_cake.transform.position.y < -20f)
		{
			this.TurnOff();
			return;
		}
		this.SetCakeImage();
		this.UpdateArrow();
		this.DrawMeter(this.m_normalizedDistanceToCake);
	}

	private void TurnOff()
	{
		this.m_done = true;
		base.gameObject.SetActive(false);
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
		if (this.m_cake == null)
		{
			return;
		}
		float num = 0f;
		float num2 = 0f;
		this.m_hudCamera = GameObject.FindWithTag("HUDCamera");
		if (this.m_hudCamera)
		{
			num = this.m_hudCamera.transform.position.x;
			num2 = this.m_hudCamera.transform.position.y;
		}
		Vector3 position = Camera.main.transform.position;
		Vector2 vector = this.m_cake.transform.position - position;
		vector.Normalize();
		float num3 = Mathf.Min(Mathf.Abs(this.m_viewHalfWidth / vector.x), Mathf.Abs(this.m_viewHalfHeight / vector.y));
		vector.Scale(new Vector3(num3 + this.m_offset, num3 + this.m_offset, 0f));
		float orthographicSize = Camera.main.orthographicSize;
		float x = Mathf.Clamp(Mathf.Abs(this.m_cake.transform.position.x - position.x), orthographicSize * (float)Screen.width / (float)Screen.height, this.m_maxDistanceToCake) - orthographicSize * (float)Screen.width / (float)Screen.height;
		float y = Mathf.Clamp(Mathf.Abs(this.m_cake.transform.position.y - position.y), orthographicSize, this.m_maxDistanceToCake) - orthographicSize;
		Vector3 vector2 = new Vector3(x, y, 0f);
		this.m_normalizedDistanceToCake = Mathf.Clamp01(vector2.magnitude / this.m_maxDistanceToCake);
		base.transform.position = new Vector3(num + vector.x, num2 + vector.y, base.transform.position.z);
		Transform child = base.transform.GetChild(0);
		if (child != null)
		{
			child.localRotation = Quaternion.LookRotation(child.forward, new Vector3(vector.x, vector.y, 0f));
		}
	}

	public bool CheckCakeOnScreen()
	{
		Vector3 position = Camera.main.transform.position;
		return Mathf.Abs(this.m_cake.transform.position.y - position.y) < Camera.main.orthographicSize && Mathf.Abs(this.m_cake.transform.position.x - position.x) < Camera.main.orthographicSize * (float)Screen.width / (float)Screen.height;
	}

	private Cake m_cake;

	private GameObject m_hudCamera;

	public float m_offset;

	public const float DefaultCameraSize = 10f;

	private float m_viewHalfWidth;

	private float m_viewHalfHeight;

	private bool m_done;

	private LineRenderer m_meter;

	private SpriteAnimation m_compassAnimation;

	private SpriteAnimation m_animation;

	private float m_normalizedDistanceToCake;

	private float m_maxDistanceToCake = 50f;
}
