using UnityEngine;

public class SliderToggle : Widget
{
	private bool IsToggled
	{
		get
		{
			return this.episodeSelector != null && this.episodeSelector.IsRotated;
		}
	}

	private void Awake()
	{
		this.hudCamera = Singleton<GuiManager>.Instance.FindCamera();
		this.slider = base.transform.Find("Slider");
		this.leftIcon = base.transform.Find("LeftIcon");
		this.rightIcon = base.transform.Find("RightIcon");
		if (this.slider == null)
		{
			return;
		}
		this.sliderLeftPosition = this.slider.localPosition;
		this.sliderRightPosition = Vector3.up * this.sliderLeftPosition.y + Vector3.right * Mathf.Abs(this.sliderLeftPosition.x);
	}

	private void Start()
	{
		this.slider.localPosition = ((!this.IsToggled) ? this.sliderLeftPosition : this.sliderRightPosition);
	}

	private void Update()
	{
		if (this.leftIcon != null)
		{
			this.leftIcon.localScale = Vector3.Lerp(this.leftIcon.localScale, (!this.IsToggled) ? (Vector3.one * 1.2f) : Vector3.one, Time.deltaTime * 20f);
		}
		if (this.rightIcon != null)
		{
			this.rightIcon.localScale = Vector3.Lerp(this.rightIcon.localScale, (!this.IsToggled) ? Vector3.one : (Vector3.one * 1.2f), Time.deltaTime * 20f);
		}
		if (this.isDragging)
		{
			if (this.wasToggled != this.IsToggled && this.m_toggleSound && Time.realtimeSinceStartup - this.lastTimeToggleSoundPlayed > this.m_toggleSound.clip.length * 0.3f)
			{
				Singleton<AudioManager>.Instance.Play2dEffect(this.m_toggleSound);
				this.lastTimeToggleSoundPlayed = Time.realtimeSinceStartup;
			}
			GuiManager.Pointer pointer = GuiManager.GetPointer();
			if (pointer.widget != this)
			{
				this.OnInput(new InputEvent(InputEvent.EventType.Release, pointer.position));
			}
			this.wasToggled = this.IsToggled;
			return;
		}
		this.wasToggled = this.IsToggled;
		if (this.freezeFrames > 0)
		{
			this.freezeFrames--;
			return;
		}
		this.slider.localPosition = Vector3.Lerp(this.slider.localPosition, (!this.IsToggled) ? this.sliderLeftPosition : this.sliderRightPosition, Time.deltaTime * 20f);
	}

	protected override void OnInput(InputEvent input)
	{
		if (this.slider == null)
		{
			return;
		}
		if (this.episodeSelector != null && this.episodeSelector.IsRotating)
		{
			return;
		}
		InputEvent.EventType type = input.type;
		if (type != InputEvent.EventType.Press)
		{
			if (type != InputEvent.EventType.Release)
			{
				if (type == InputEvent.EventType.Drag)
				{
					this.OnDrag(input.position);
				}
			}
			else
			{
				this.OnPress(false, default(Vector3), false);
			}
		}
		else
		{
			this.OnPress(true, input.position, false);
		}
	}

	private void OnPress(bool pressed, Vector3 position = default(Vector3), bool forceToggle = false)
	{
		if (pressed)
		{
			this.toggleStateAtPress = this.IsToggled;
			this.pressStartTime = Time.realtimeSinceStartup;
			this.isDragging = true;
			this.lastDragPosition = position;
			if (this.episodeSelector != null)
			{
				this.episodeSelector.PrepareRotation();
			}
		}
		else if (this.isDragging)
		{
			this.isDragging = false;
			Vector3 vector = this.hudCamera.WorldToScreenPoint(base.transform.position);
			bool flag = this.toggleStateAtPress == this.IsToggled && Time.realtimeSinceStartup - this.pressStartTime < this.clickThreshold && ((!this.toggleStateAtPress && this.lastDragPosition.x > vector.x) || (this.toggleStateAtPress && this.lastDragPosition.x < vector.x));
			if (this.m_toggleSound && flag)
			{
				Singleton<AudioManager>.Instance.Play2dEffect(this.m_toggleSound);
			}
			if (flag || forceToggle)
			{
				this.freezeFrames = 4;
			}
			if (this.episodeSelector != null)
			{
				this.episodeSelector.ReleaseRotation(flag || forceToggle);
			}
		}
	}

	private void OnDrag(Vector3 position)
	{
		if (!this.isDragging)
		{
			return;
		}
		this.slider.position += Vector3.right * ((position - this.lastDragPosition) * (20f / (float)Screen.height)).x;
		if (this.slider.localPosition.x < this.sliderLeftPosition.x)
		{
			this.slider.localPosition = this.sliderLeftPosition;
		}
		else if (this.slider.localPosition.x > this.sliderRightPosition.x)
		{
			this.slider.localPosition = this.sliderRightPosition;
		}
		this.lastDragPosition = position;
		if (this.episodeSelector != null)
		{
			this.episodeSelector.SetRotation(this.slider.localPosition.x / this.sliderRightPosition.x);
		}
	}

	[SerializeField]
	private CompactEpisodeSelector episodeSelector;

	[SerializeField]
	private float clickThreshold = 1f;

	[SerializeField]
	public AudioSource m_toggleSound;

	private Camera hudCamera;

	private Transform leftIcon;

	private Transform rightIcon;

	private Transform slider;

	private bool isDragging;

	private Vector3 lastDragPosition = Vector3.zero;

	private Vector3 sliderLeftPosition = Vector3.zero;

	private Vector3 sliderRightPosition = Vector3.zero;

	private float pressStartTime;

	private bool toggleStateAtPress;

	private int freezeFrames;

	private bool wasToggled;

	private float lastTimeToggleSoundPlayed;
}
