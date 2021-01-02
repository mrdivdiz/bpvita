using UnityEngine;

public class BirdCompassIndicator : WPFMonoBehaviour
{
	public bool Done
	{
		get
		{
			return this.m_done;
		}
	}

	public void AttachToBird(Bird bird)
	{
		this.m_bird = bird;
	}

	public void Show()
	{
		if (this.m_bird == null || this.m_bird.IsCollided())
		{
			this.TurnOff();
			return;
		}
		if (!base.gameObject.activeInHierarchy)
		{
			this.SetBirdImage();
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

	private void SetBirdImage()
	{
		string text = this.m_bird.GetBirdType().ToString();
		if (this.m_bird.IsSleeping())
		{
			text += "_sleep";
			this.m_compassAnimation.Play("Sleep");
		}
		else
		{
			text += "_awake";
			this.m_compassAnimation.Play("Awake");
		}
		this.m_animation.Play(text);
	}

	private void Awake()
	{
		this.m_viewHalfWidth = 10f * (float)Screen.width / (float)Screen.height;
		this.m_viewHalfHeight = this.m_viewHalfWidth * (float)Screen.height / (float)Screen.width;
		this.m_animation = base.GetComponent<SpriteAnimation>();
		this.m_compassAnimation = base.transform.Find("BirdCompassArrow").GetComponent<SpriteAnimation>();
		this.m_meter = base.transform.Find("BirdCompassArrow/WakeUpMeter").GetComponent<LineRenderer>();
	}

	private void Update()
	{
		if (this.m_bird == null || this.m_bird.IsCollided() || this.m_bird.transform.position.y < -20f)
		{
			this.TurnOff();
			return;
		}
		this.SetBirdImage();
		this.DrawMeter(this.m_bird.WakeUpProgress());
		this.UpdateArrow();
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
		if (this.m_bird == null)
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
		Vector2 vector = this.m_bird.transform.position - Camera.main.transform.position;
		vector.Normalize();
		float num3 = Mathf.Min(Mathf.Abs(this.m_viewHalfWidth / vector.x), Mathf.Abs(this.m_viewHalfHeight / vector.y));
		vector.Scale(new Vector3(num3 + this.m_offset, num3 + this.m_offset, 0f));
		base.transform.position = new Vector3(num + vector.x, num2 + vector.y, base.transform.position.z);
		Transform child = base.transform.GetChild(0);
		if (child != null)
		{
			child.localRotation = Quaternion.LookRotation(child.forward, new Vector3(vector.x, vector.y, 0f));
		}
	}

	public bool CheckBirdOnScreen()
	{
		Vector3 position = Camera.main.transform.position;
		return Mathf.Abs(this.m_bird.transform.position.y - position.y) < Camera.main.orthographicSize && Mathf.Abs(this.m_bird.transform.position.x - position.x) < Camera.main.orthographicSize * (float)Screen.width / (float)Screen.height;
	}

	private Bird m_bird;

	private GameObject m_hudCamera;

	public float m_offset;

	public const float DefaultCameraSize = 10f;

	private float m_viewHalfWidth;

	private float m_viewHalfHeight;

	private bool m_done;

	private LineRenderer m_meter;

	private SpriteAnimation m_compassAnimation;

	private SpriteAnimation m_animation;
}
