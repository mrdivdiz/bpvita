using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompactEpisodeSelector : MonoBehaviour
{
	public bool IsRotated
	{
		get
		{
			return this.m_isRotated;
		}
	}

	public bool IsRotating
	{
		get
		{
			return this.m_isRotating;
		}
	}

	public List<GameObject> Episodes
	{
		get
		{
			return this.m_episodes;
		}
	}

	public static CompactEpisodeSelector Instance
	{
		get
		{
			return CompactEpisodeSelector.instance;
		}
	}

	private List<GameObject> CurrentEpisodes
	{
		get
		{
			if (this.m_isRotated)
			{
				return this.m_episodesToggled;
			}
			return this.m_episodes;
		}
	}

	private int EpisodeCount
	{
		get
		{
			if (this.m_isRotated)
			{
				return this.m_episodesToggled.Count;
			}
			return this.m_episodes.Count;
		}
	}

	private float HorizontalGap
	{
		get
		{
			float num = 2f * this.m_hudCamera.orthographicSize * (float)Screen.width / (float)Screen.height;
			float num2 = this.EdgeMargin + this.m_episodeSize.x / 2f + this.m_scrollButtonMargin;
			float num3 = num - 2f * num2;
			float num4 = num3 / (float)(this.EpisodeCount - 1);
			if (num4 < this.MinGap)
			{
				this.MinGap = 6.5f;
				this.EdgeMargin = 2f;
				num2 = this.EdgeMargin + this.m_episodeSize.x / 2f + this.m_scrollButtonMargin;
				num3 = num - 2f * num2;
				this.m_episodesPerPage = (int)(num3 / this.MinGap) + 1;
				if (this.m_episodesPerPage < this.EpisodeCount && this.gameData != null && this.m_episodesPerPage > this.gameData.m_episodeLevels.Count)
				{
					this.m_episodesPerPage = this.gameData.m_episodeLevels.Count;
				}
				num4 = this.MinGap;
			}
			else if (num4 > this.MaxGap)
			{
				num4 = this.MaxGap;
			}
			return num4;
		}
	}

	private float ScrollPivotWidth
	{
		get
		{
			return this.HorizontalGap * (float)this.EpisodeCount - this.m_episodeSize.x / 2f;
		}
	}

	private void Awake()
	{
		this.m_leftLimit = 0f;
		this.m_rightLimit = 0f;
		CompactEpisodeSelector.instance = this;
		Singleton<GameManager>.Instance.CreateMenuBackground();
		this.m_hudCamera = GameObject.FindGameObjectWithTag("HUDCamera").GetComponent<Camera>();
		this.m_scrollPivot = base.transform.Find("ScrollPivot").gameObject;
		this.SetCenterEpisode(null);
		for (int i = 0; i < this.m_episodes.Count; i++)
		{
			this.m_episodes[i] = UnityEngine.Object.Instantiate<GameObject>(this.m_episodes[i]);
			this.m_episodes[i].transform.parent = this.m_scrollPivot.transform;
			CompactEpisodeTarget component = this.m_episodes[i].GetComponent<CompactEpisodeTarget>();
			if (component != null)
			{
				component.episodeSelector = this;
			}
		}
		for (int j = 0; j < this.m_episodesToggled.Count; j++)
		{
			this.m_episodesToggled[j] = UnityEngine.Object.Instantiate<GameObject>(this.m_episodesToggled[j]);
			this.m_episodesToggled[j].transform.parent = this.m_scrollPivot.transform;
			this.m_episodesToggled[j].SetActive(false);
			CompactEpisodeTarget component2 = this.m_episodesToggled[j].GetComponent<CompactEpisodeTarget>();
			if (component2 != null)
			{
				component2.episodeSelector = this;
			}
		}
		if (this.m_preButtons != null && this.m_preButtons.Count > 0)
		{
			for (int k = 0; k < this.m_preButtons.Count; k++)
			{
				this.m_preButtons[k] = UnityEngine.Object.Instantiate<GameObject>(this.m_preButtons[k]);
				this.m_preButtons[k].transform.parent = this.m_scrollPivot.transform;
				CompactEpisodeTarget component3 = this.m_preButtons[k].GetComponent<CompactEpisodeTarget>();
				if (component3 != null)
				{
					component3.episodeSelector = this;
				}
			}
		}
		this.m_screenWidth = Screen.width;
		this.m_screenHeight = Screen.height;
		this.isInitialized = true;
		this.Layout();
	}

	private void Start()
	{
		if (GameProgress.GetBool("show_content_limit_popup", false, GameProgress.Location.Local, null))
		{
			GameProgress.DeleteKey("show_content_limit_popup", GameProgress.Location.Local);
			LevelInfo.DisplayContentLimitNotification();
		}
		Transform transform = base.transform.Find("RightButtons/SandboxToggle/SandBox_Toggle(Clone)");
		if (transform != null)
		{
			this.m_buttonToggleAnimation = transform.GetComponent<Animation>();
		}
		if (this.m_buttonToggleAnimation != null)
		{
			AnimationClip clip = this.m_buttonToggleAnimation.GetClip("Sandbox_Toggle");
			if (clip != null)
			{
				this.m_buttonToggleAnimation.clip = clip;
				AnimationState animationState = this.m_buttonToggleAnimation["Sandbox_Toggle"];
				animationState.enabled = true;
				animationState.speed = 0f;
				animationState.normalizedTime = ((!this.m_isRotated) ? 0.5f : 1f);
				this.m_buttonToggleAnimation.Play();
				this.m_buttonToggleAnimation.Sample();
				this.m_buttonToggleAnimation.Stop();
			}
		}
	}

	private void OnEnable()
	{
		KeyListener.keyReleased += this.HandleKeyListenerkeyReleased;
		KeyListener.mouseWheel += this.HandleKeyListenerMouseWheel;
	}

	private void OnDisable()
	{
		KeyListener.keyReleased -= this.HandleKeyListenerkeyReleased;
		KeyListener.mouseWheel -= this.HandleKeyListenerMouseWheel;
	}

	private void Update()
	{
		if (this.m_screenWidth != Screen.width || this.m_screenHeight != Screen.height)
		{
			this.m_screenWidth = Screen.width;
			this.m_screenHeight = Screen.height;
			this.Layout();
		}
		GuiManager.Pointer pointer = GuiManager.GetPointer();
		if (pointer.down)
		{
			this.m_initialInputPos = pointer.position;
			this.m_lastInputPos = pointer.position;
			this.m_interacting = true;
			RaycastHit raycastHit;
			if (Physics.Raycast(this.m_hudCamera.ScreenPointToRay(pointer.position), out raycastHit))
			{
				if (raycastHit.collider.transform.name.Equals("SliderToggle"))
				{
					this.m_interacting = false;
				}
				Transform parent = raycastHit.collider.transform.parent;
				CompactEpisodeTarget component = raycastHit.collider.transform.GetComponent<CompactEpisodeTarget>();
				if (component || (raycastHit.collider.transform.GetComponent<Button>() == null && parent && parent.GetComponent<CompactEpisodeTarget>()))
				{
					if (component)
					{
						this.SetCenterEpisode(raycastHit.collider.transform.gameObject);
					}
					else
					{
						this.SetCenterEpisode(parent.gameObject);
					}
					if (this.m_centerEpisode == this.CurrentEpisodes[0] && this.m_preButtons != null)
					{
						this.SetCenterEpisode(this.m_preButtons[0]);
					}
					else if (this.m_centerEpisode == this.CurrentEpisodes[this.EpisodeCount - 1])
					{
						this.SetCenterEpisode(this.CurrentEpisodes[this.EpisodeCount - 2]);
					}
					if (this.m_isRotated)
					{
						for (int i = 0; i < this.m_episodesToggled.Count; i++)
						{
							if (this.m_centerEpisode == this.m_episodesToggled[i])
							{
								int value = Mathf.Clamp(i, 0, this.m_episodesToggled.Count - 1);
								UserSettings.SetInt(CompactEpisodeSelector.CurrentSandboxEpisodeKey, value);
							}
						}
					}
				}
			}
		}
		bool flag = TextDialog.DialogOpen || DailyChallengeDialog.DialogOpen || SnoutCoinShopPopup.DialogOpen || LootWheelPopup.DialogOpen;
		if (pointer.dragging && this.m_interacting && !flag && this.m_movableEpisodes)
		{
			Vector3 vector = this.m_hudCamera.ScreenToWorldPoint(this.m_lastInputPos);
			Vector3 vector2 = this.m_hudCamera.ScreenToWorldPoint(pointer.position);
			this.m_lastInputPos = pointer.position;
			this.m_deltaX = vector2.x - vector.x;
			if (Mathf.Abs(this.m_deltaX) > 0f)
			{
				this.MoveEpisodes(this.m_deltaX, true);
			}
			Vector3 vector3 = this.m_hudCamera.ScreenToWorldPoint(this.m_initialInputPos);
			if (!this.m_focusIsReset && Mathf.Abs(vector2.x - vector3.x) > 0.1f)
			{
				this.m_focusIsReset = true;
			}
			if (this.m_focusIsReset)
			{
				Singleton<GuiManager>.Instance.ResetFocus();
			}
		}
		if (pointer.up && this.m_interacting)
		{
			this.m_focusIsReset = false;
			this.m_interacting = false;
			this.m_moveToCenter = true;
		}
		if (!this.m_interacting && this.m_movableEpisodes && this.m_momentumSlide > 0 && this.m_centerEpisode)
		{
			float x = this.m_centerEpisode.transform.position.x;
			if (Mathf.Abs(this.m_deltaX) > 0.1f)
			{
				this.MoveEpisodes(this.m_deltaX, true);
				this.m_deltaX -= this.m_deltaX / (float)this.m_momentumSlide;
			}
			else if (this.m_centerEpisode != null && this.m_moveToCenter)
			{
				float num = Mathf.SmoothDamp(x, 0f, ref this.xVelocity, 0.2f);
				this.MoveEpisodes(num - x, false);
			}
		}
		this.ScaleEpisodes();
	}

	private void SetCenterEpisode(GameObject target)
	{
		if (this.m_preButtons != null && this.m_preButtons.Count > 0 && target == this.m_preButtons[0])
		{
			this.m_centerEpisode = ((!this.m_isRotated) ? this.m_preButtons[0] : this.m_episodesToggled[0]);
		}
		else
		{
			this.m_centerEpisode = target;
		}
	}

	public void MoveToTarget(Transform newTarget)
	{
		this.SetCenterEpisode(newTarget.gameObject);
		this.m_moveToCenter = true;
		this.m_interacting = false;
	}

	public void MoveToTargetIndex(int index, bool isSandbox = false)
	{
		if (isSandbox)
		{
			index = Mathf.Clamp(index, 0, this.m_episodesToggled.Count - 1);
			UserSettings.SetInt(CompactEpisodeSelector.CurrentSandboxEpisodeKey, index);
			if (index == 0 && this.m_preButtons != null)
			{
				this.SetCenterEpisode(this.m_preButtons[0]);
			}
			else
			{
				this.SetCenterEpisode(this.m_episodesToggled[index]);
			}
		}
		else
		{
			index = Mathf.Clamp(index, 0, this.m_episodes.Count - 1);
			UserSettings.SetString(CompactEpisodeSelector.CurrentEpisodeKey, this.m_episodes[index].name);
			if (index == 0 && this.m_preButtons != null)
			{
				this.SetCenterEpisode(this.m_preButtons[0]);
			}
			else
			{
				this.SetCenterEpisode(this.m_episodes[index]);
			}
		}
		this.m_moveToCenter = true;
		this.m_interacting = false;
	}

	private void MoveEpisodes(float delta, bool checkCenter = true)
	{
		float num = (this.m_preButtons == null || this.m_preButtons.Count <= 1) ? 0f : 2f;
		if (this.m_scrollPivot.transform.localPosition.x > num + this.m_limitMargin && delta > 0f)
		{
			if (this.m_preButtons != null && this.m_preButtons.Count > 1)
			{
				this.SetCenterEpisode(this.m_preButtons[0]);
			}
			else
			{
				this.SetCenterEpisode(this.CurrentEpisodes[0]);
			}
			this.m_deltaX = 0f;
		}
		else if (this.m_scrollPivot.transform.localPosition.x < -this.ScrollPivotWidth - this.m_limitMargin && delta < 0f)
		{
			this.SetCenterEpisode(this.CurrentEpisodes[this.EpisodeCount - 2]);
			this.m_deltaX = 0f;
		}
		else
		{
			this.m_scrollPivot.transform.localPosition = new Vector3(this.m_scrollPivot.transform.localPosition.x + delta, this.m_scrollPivot.transform.localPosition.y, this.m_scrollPivot.transform.localPosition.z);
		}
		if (checkCenter)
		{
			for (int i = 0; i < this.EpisodeCount; i++)
			{
				float num2 = Mathf.Abs(this.CurrentEpisodes[i].transform.position.x);
				if (this.m_centerEpisode == null || num2 < Mathf.Abs(this.m_centerEpisode.transform.position.x))
				{
					int num3 = Mathf.Clamp(i, 0, this.EpisodeCount - 2);
					if (num3 == 0 && this.m_preButtons != null)
					{
						this.SetCenterEpisode(this.m_preButtons[0]);
					}
					else
					{
						this.SetCenterEpisode(this.CurrentEpisodes[num3]);
					}
				}
			}
		}
	}

	private void ScaleEpisodes()
	{
		for (int i = 0; i < this.m_episodes.Count; i++)
		{
			GameObject gameObject = this.m_episodes[i];
			float time = 1f / (this.xMax - this.xMin) * (Mathf.Abs(gameObject.transform.position.x) - this.xMin);
			float num = Mathf.Clamp01(this.scalingCurve.Evaluate(time));
			if (float.IsNaN(num))
			{
				num = 0f;
			}
			gameObject.GetComponent<Collider>().enabled = (num >= 0.98f);
			gameObject.transform.localScale = new Vector3(num, num, 1f);
		}
		for (int j = 0; j < this.m_episodesToggled.Count; j++)
		{
			GameObject gameObject2 = this.m_episodesToggled[j];
			float time2 = 1f / (this.xMax - this.xMin) * (Mathf.Abs(gameObject2.transform.position.x) - this.xMin);
			float num2 = Mathf.Clamp01(this.scalingCurve.Evaluate(time2));
			if (float.IsNaN(num2))
			{
				num2 = 0f;
			}
			gameObject2.GetComponent<Collider>().enabled = (num2 >= 0.98f);
			gameObject2.transform.localScale = new Vector3(num2, num2, 1f);
		}
		if (this.m_preButtons != null && this.m_preButtons.Count > 0)
		{
			for (int k = 0; k < this.m_preButtons.Count; k++)
			{
				float time3 = 1f / (this.xMax - this.xMin) * (Mathf.Abs(this.m_preButtons[k].transform.position.x) - this.xMin);
				float num3 = Mathf.Clamp01(this.scalingCurve.Evaluate(time3));
				if (float.IsNaN(num3))
				{
					num3 = 0f;
				}
				this.m_preButtons[k].transform.localScale = new Vector3(num3, num3, 1f);
			}
		}
	}

	[ContextMenu("Layout")]
	private void Layout()
	{
		float horizontalGap = this.HorizontalGap;
        Sprite component = this.m_episodes[0].GetComponent<Sprite>();
		if (component == null)
		{
			UnmanagedSprite component2 = this.m_episodes[0].GetComponent<UnmanagedSprite>();
			if (component2 != null)
			{
				this.m_episodeSize = component2.Size;
			}
		}
		else
		{
			this.m_episodeSize = this.m_episodes[0].GetComponent<Sprite>().Size;
		}
		for (int i = 0; i < this.m_episodes.Count; i++)
		{
			this.m_episodes[i].transform.localPosition = Vector3.right * this.m_episodeSize.x / 2f + Vector3.right * horizontalGap * (float)i;
		}
		for (int j = 0; j < this.m_episodesToggled.Count; j++)
		{
			this.m_episodesToggled[j].transform.localPosition = Vector3.right * this.m_episodeSize.x / 2f + Vector3.right * horizontalGap * (float)j;
		}
		if (this.m_preButtons != null && this.m_preButtons.Count > 0)
		{
			for (int k = 0; k < this.m_preButtons.Count; k++)
			{
				this.m_preButtons[k].transform.localPosition = Vector3.left * this.m_preButtonsOffsets[k] * (float)(k + 1);
			}
		}
		bool @bool = UserSettings.GetBool(CompactEpisodeSelector.IsEpisodeToggledKey, false);
		if (@bool)
		{
			int @int = UserSettings.GetInt(CompactEpisodeSelector.CurrentSandboxEpisodeKey, 1);
			if (Mathf.Clamp(@int, 0, this.m_episodesToggled.Count - 1) == 0 && this.m_preButtons != null)
			{
				this.SetCenterEpisode(this.m_preButtons[0]);
			}
			else
			{
				this.SetCenterEpisode(this.m_episodesToggled[Mathf.Clamp(@int, 0, this.m_episodesToggled.Count - 1)]);
			}
		}
		else if (this.m_preButtons != null && this.m_preButtons.Count > 1)
		{
			this.SetCenterEpisode(this.m_preButtons[0]);
		}
		else
		{
			this.SetCenterEpisode(this.m_episodes[0]);
		}
		if (this.m_centerEpisode != null)
		{
			int num = 0;
			if (@bool)
			{
				for (int l = 0; l < this.m_episodesToggled.Count; l++)
				{
					if (this.m_episodesToggled[l] == this.m_centerEpisode)
					{
						num = Mathf.Clamp(l, 0, this.m_episodesToggled.Count - 1);
					}
				}
			}
			else
			{
				for (int m = 0; m < this.m_episodes.Count; m++)
				{
					if (this.m_episodes[m] == this.m_centerEpisode)
					{
						num = Mathf.Clamp(m, 0, this.m_episodes.Count - 1);
					}
				}
			}
			this.m_scrollPivot.transform.localPosition = -Vector3.right * this.m_episodeSize.x / 2f - Vector3.right * horizontalGap * (float)num + Vector3.up * this.m_scrollPivot.transform.localPosition.y;
		}
		this.MoveEpisodes(0f, false);
		this.m_moveToCenter = true;
		if (@bool)
		{
			this.SetRotation(1f);
		}
	}

	private bool isInInteractiveArea(Vector2 touchPos)
	{
		return touchPos.y > (float)Screen.height * 0.1f && touchPos.y < (float)Screen.height * 0.8f;
	}

	public void GoToMainMenu()
	{
		this.SendExitEpisodeSelectionFlurryEvent();
		Singleton<GameManager>.Instance.LoadMainMenu(false);
	}

	private void HandleKeyListenerkeyReleased(KeyCode obj)
	{
		if (obj == KeyCode.Escape)
		{
			this.GoToMainMenu();
		}
	}

	private void HandleKeyListenerMouseWheel(float delta)
	{
	}

	public void PrepareRotation()
	{
		if (this.m_isRotating)
		{
			return;
		}
	}

	public void ReleaseRotation(bool toggleRotation)
	{
		if (this.m_isRotating)
		{
			return;
		}
		base.StartCoroutine(this.RotateSequence(toggleRotation));
	}

	public void SetRotation(float rotation)
	{
		if (!this.isInitialized)
		{
			return;
		}
		this.m_currentRotation = rotation;
		bool isRotated = this.m_isRotated;
		this.m_isRotated = (this.m_currentRotation >= 0f);
		if (isRotated != this.m_isRotated)
		{
			this.OnRotated(this.m_isRotated);
			UserSettings.SetBool(CompactEpisodeSelector.IsEpisodeToggledKey, this.m_isRotated);
		}
		float t = (!this.m_isRotated) ? (this.m_currentRotation + 1f) : (1f - this.m_currentRotation);
		Vector3 vector = (!this.m_isRotated) ? Vector3.zero : (Vector3.up * 90f);
		Vector3 vector2 = (!this.m_isRotated) ? (Vector3.up * 90f) : Vector3.zero;
		for (int i = 0; i < this.m_episodes.Count; i++)
		{
			this.m_episodes[i].transform.localEulerAngles = Vector3.Lerp(vector, vector2, t);
			if (this.m_episodes[i].activeInHierarchy && this.m_isRotated)
			{
				this.m_episodes[i].SetActive(false);
			}
			else if (!this.m_episodes[i].activeInHierarchy && !this.m_isRotated)
			{
				this.m_episodes[i].SetActive(true);
			}
		}
		for (int j = 0; j < this.m_episodesToggled.Count; j++)
		{
			this.m_episodesToggled[j].transform.localEulerAngles = Vector3.Lerp(vector2, vector, t);
			if (!this.m_episodesToggled[j].activeInHierarchy && this.m_isRotated)
			{
				this.m_episodesToggled[j].SetActive(true);
			}
			else if (this.m_episodesToggled[j].activeInHierarchy && !this.m_isRotated)
			{
				this.m_episodesToggled[j].SetActive(false);
			}
		}
	}

	private IEnumerator RotateSequence(bool toggleRotation)
	{
		if (this.m_isRotating)
		{
			yield break;
		}
		this.m_isRotating = true;
		float targetRotation = (!this.m_isRotated) ? -1f : 1f;
		float newRotation = this.m_currentRotation;
		if (toggleRotation)
		{
			targetRotation *= -1f;
		}
		float fromState = (!this.m_isRotated) ? 0.5f : 0f;
		float toState = (!this.m_isRotated) ? 1f : 0.5f;
		AnimationState toggleState = null;
		AnimationClip toggleClip = null;
		if (this.m_buttonToggleAnimation != null)
		{
			toggleClip = this.m_buttonToggleAnimation.GetClip("Sandbox_Toggle");
			if (toggleClip != null)
			{
				this.m_buttonToggleAnimation.clip = toggleClip;
				toggleState = this.m_buttonToggleAnimation["Sandbox_Toggle"];
				toggleState.enabled = true;
				toggleState.speed = 0f;
				toggleState.normalizedTime = 0f;
				this.m_buttonToggleAnimation.Play();
			}
		}
		float fade = 0f;
		while (fade < 1f)
		{
			if (this.m_buttonToggleAnimation != null && toggleState != null)
			{
				toggleState.time = Mathf.Lerp(fromState, toState, fade);
				this.m_buttonToggleAnimation.Sample();
			}
			newRotation = Mathf.Lerp(newRotation, targetRotation, fade);
			this.SetRotation(newRotation);
			fade += Time.deltaTime * 5f;
			yield return null;
		}
		if (this.m_buttonToggleAnimation != null && toggleState != null)
		{
			toggleState.normalizedTime = toState;
			this.m_buttonToggleAnimation.Sample();
			this.m_buttonToggleAnimation.Stop();
		}
		this.SetRotation(targetRotation);
		this.m_isRotating = false;
		yield break;
	}

	private void OnRotated(bool rotated)
	{
		int num = -1;
		for (int i = 0; i < this.m_episodes.Count; i++)
		{
			if (this.m_centerEpisode == this.m_episodes[i])
			{
				num = i;
			}
		}
		if (num < 0)
		{
			for (int j = 0; j < this.m_episodesToggled.Count; j++)
			{
				if (this.m_centerEpisode == this.m_episodesToggled[j])
				{
					num = j;
				}
			}
		}
		int num2 = Mathf.Clamp(num, 0, this.EpisodeCount - 2);
		if (num2 == 0 && this.m_preButtons != null)
		{
			this.SetCenterEpisode(this.m_preButtons[0]);
		}
		else
		{
			this.SetCenterEpisode(this.CurrentEpisodes[num2]);
		}
	}

	public void SendExitEpisodeSelectionFlurryEvent()
	{
	}

	private void OnDrawGizmos()
	{
		if (this.m_centerEpisode != null)
		{
			Gizmos.color = Color.blue;
			Gizmos.DrawSphere(this.m_centerEpisode.transform.position, 0.5f);
			Gizmos.color = Color.yellow;
			Gizmos.DrawSphere(base.transform.position, 0.5f);
		}
		Gizmos.color = Color.green;
		Gizmos.DrawSphere(new Vector3(this.m_leftLimit, 0f), 0.5f);
		Gizmos.DrawSphere(new Vector3(this.m_rightLimit, 0f), 0.5f);
	}

	[SerializeField]
	private GameData gameData;

	[SerializeField]
	private List<GameObject> m_preButtons = new List<GameObject>();

	[SerializeField]
	private List<GameObject> m_episodes = new List<GameObject>();

	[SerializeField]
	private List<GameObject> m_episodesToggled = new List<GameObject>();

	[SerializeField]
	private float Gap;

	[SerializeField]
	private float MinGap = 6f;

	[SerializeField]
	private float MaxGap = 6f;

	[SerializeField]
	private float EdgeMargin = 0.65f;

	[SerializeField]
	private float m_scrollButtonMargin = 0.5f;

	[SerializeField]
	private int m_momentumSlide = 10;

	[SerializeField]
	private float m_limitMargin = 3f;

	[SerializeField]
	private AnimationCurve scalingCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

	[SerializeField]
	private float[] m_preButtonsOffsets;

	private int m_episodesPerPage;

	private int m_screenWidth;

	private int m_screenHeight;

	private Camera m_hudCamera;

	private bool m_interacting;

	private Vector2 m_initialInputPos;

	private Vector2 m_lastInputPos;

	private float m_leftLimit;

	private float m_rightLimit;

	private GameObject m_scrollPivot;

	private float m_scrollPivotWidth;

	private Vector2 m_episodeSize;

	private float m_deltaX;

	private bool m_moveToCenter;

	private bool m_movableEpisodes = true;

	[SerializeField]
	private GameObject m_centerEpisode;

	private bool m_focusIsReset;

	public static string CurrentEpisodeKey = "CurrentEpisode";

	public static string CurrentSandboxEpisodeKey = "CurrentSandboxEpisodeIndex";

	public static string IsEpisodeToggledKey = "IsEpisodeRotatorToggled";

	private static CompactEpisodeSelector instance;

	private bool m_isRotated;

	private bool m_isRotating;

	private float m_currentRotation = -1f;

	private bool isInitialized;

	private Animation m_buttonToggleAnimation;

	private float xVelocity;

	private float xMin;

	private float xMax = 60f;
}
