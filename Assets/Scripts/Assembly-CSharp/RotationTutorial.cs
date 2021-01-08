using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTutorial : WPFMonoBehaviour
{
	private void Start()
	{
		if (GameProgress.GetBool(Singleton<GameManager>.Instance.CurrentSceneName + "_Rotation_Tutorial_Completed", false, GameProgress.Location.Local, null))
		{
			this.m_state = RotationTutorial.State.Stopped;
			return;
		}
		EventManager.Connect(new EventManager.OnEvent<GameStateChanged>(this.ReceiveGameStateChanged));
		this.m_pointerVisual = UnityEngine.Object.Instantiate<GameObject>(this.m_pointerPrefab);
		this.m_clickIndicator = UnityEngine.Object.Instantiate<GameObject>(this.m_clickIndicatorPrefab);
		this.m_rotationIcon = UnityEngine.Object.Instantiate<GameObject>(this.m_rotationIconPrefab);
		this.m_clickIndicator.SetActive(false);
		this.SetRenderQueue(this.m_pointerVisual, 3002);
		this.SetRenderQueue(this.m_clickIndicator, 3002);
		this.SetRenderQueue(this.m_rotationIcon, 3002);
		this.m_pointer = new Pointer(this.m_pointerVisual, this.m_clickIndicator, this.m_rotationIcon);
		this.m_acceptablePartsList = new List<BasePart.PartType>();
		this.m_acceptablePartsList.Add(BasePart.PartType.CokeBottle);
		this.m_acceptablePartsList.Add(BasePart.PartType.SpringBoxingGlove);
		this.m_acceptablePartsList.Add(BasePart.PartType.GrapplingHook);
	}

	private void SetRenderQueue(GameObject parent, int queue)
	{
		if (parent.GetComponent<Renderer>() && parent.GetComponent<Renderer>().sharedMaterial)
		{
			parent.GetComponent<Renderer>().material.renderQueue = queue;
		}
		for (int i = 0; i < parent.transform.childCount; i++)
		{
			this.SetRenderQueue(parent.transform.GetChild(i).gameObject, queue);
		}
	}

	private void OnDestroy()
	{
		EventManager.Disconnect(new EventManager.OnEvent<GameStateChanged>(this.ReceiveGameStateChanged));
	}

	public static Vector3 PositionOnSpline(List<Vector3> controlPoints, float t)
	{
		int count = controlPoints.Count;
		int num = Mathf.FloorToInt(t * (float)(count - 1));
		Vector3 a = controlPoints[Mathf.Clamp(num - 1, 0, count - 1)];
		Vector3 b = controlPoints[Mathf.Clamp(num, 0, count - 1)];
		Vector3 c = controlPoints[Mathf.Clamp(num + 1, 0, count - 1)];
		Vector3 d = controlPoints[Mathf.Clamp(num + 2, 0, count - 1)];
		float i = t * (float)(count - 1) - (float)num;
		return MathsUtil.CatmullRomInterpolate(a, b, c, d, i);
	}

	private void Update()
	{
		if (this.m_state == RotationTutorial.State.Waiting)
		{
			foreach (BasePart.PartType type in this.m_acceptablePartsList)
			{
				if (WPFMonoBehaviour.levelManager.ContraptionProto.HasPart(type))
				{
					this.m_startTimer -= Time.deltaTime;
					if (this.m_startTimer <= 0f)
					{
						this.SetupTutorial();
					}
				}
			}
		}
		else if (this.m_state == RotationTutorial.State.Playing)
		{
			if (this.m_targetPart)
			{
				this.m_timeline.Update();
				if (this.m_timeline.IsFinished())
				{
					this.m_timeline.Start();
				}
				if (this.m_targetPart.transform.position != this.m_originalTargetPosition)
				{
					this.SetupTutorial();
				}
				if (this.m_targetPart.m_gridRotation == this.m_originalTargetRotation)
				{
					this.m_originalTargetRotation = this.m_targetPart.m_gridRotation;
					this.m_pointer.Show(false);
					this.m_startTimer = 1f;
					this.m_state = RotationTutorial.State.Stopped;
					GameProgress.SetBool(Singleton<GameManager>.Instance.CurrentSceneName + "_Rotation_Tutorial_Completed", true, GameProgress.Location.Local);
				}
			}
			else
			{
				foreach (BasePart.PartType type2 in this.m_acceptablePartsList)
				{
					if (WPFMonoBehaviour.levelManager.ContraptionProto.HasPart(type2))
					{
						this.m_startTimer -= Time.deltaTime;
						if (this.m_startTimer <= 0f)
						{
							this.SetupTutorial();
						}
					}
					else
					{
						this.m_pointer.Show(false);
						this.m_startTimer = 1f;
					}
				}
			}
		}
	}

	private void SetupTutorial()
	{
		foreach (BasePart.PartType type in this.m_acceptablePartsList)
		{
			this.m_targetPart = WPFMonoBehaviour.levelManager.ContraptionProto.FindPart(type);
			if (this.m_targetPart != null)
			{
				break;
			}
		}
		if (this.m_targetPart == null)
		{
			throw new MissingReferenceException("Could not find a proper part for rotation tutorial.");
		}
		this.m_originalTargetPosition = this.m_targetPart.transform.position;
		this.m_state = RotationTutorial.State.Playing;
		this.m_timeline = new PointerTimeLine(this.m_pointer);
		Vector3 position = WPFMonoBehaviour.ingameCamera.GetComponent<Camera>().WorldToScreenPoint(this.m_targetPart.transform.position + 0.3f * Vector3.down);
		Vector3 item = WPFMonoBehaviour.hudCamera.GetComponent<Camera>().ScreenToWorldPoint(position);
		List<Vector3> list = new List<Vector3>();
		list.Add(item);
		this.m_timeline.AddEvent(new PointerTimeLine.Move(list, 0.5f));
		this.m_timeline.AddEvent(new PointerTimeLine.Press());
		this.m_timeline.AddEvent(new PointerTimeLine.Wait(0.5f));
		this.m_timeline.Start();
	}

	private void ReceiveGameStateChanged(GameStateChanged data)
	{
		if (this.m_state == RotationTutorial.State.Stopped)
		{
			return;
		}
		if (data.state == LevelManager.GameState.Building)
		{
			base.StartCoroutine(this.StartTutorial());
		}
		else
		{
			this.m_state = RotationTutorial.State.Initial;
			this.m_pointer.Show(false);
		}
	}

	private IEnumerator StartTutorial()
	{
		Vector3 cameraPosition;
		do
		{
			cameraPosition = WPFMonoBehaviour.ingameCamera.transform.position;
			yield return new WaitForSeconds(0.2f);
		}
		while (Vector3.Distance(WPFMonoBehaviour.ingameCamera.transform.position, cameraPosition) >= 0.05f);
		if (WPFMonoBehaviour.levelManager.gameState == LevelManager.GameState.Building)
		{
			this.m_state = RotationTutorial.State.Waiting;
			this.m_startTimer = 1f;
		}
		yield break;
	}

	public GameObject m_pointerPrefab;

	public GameObject m_clickIndicatorPrefab;

	public GameObject m_rotationIconPrefab;

	private GameObject m_pointerVisual;

	private GameObject m_clickIndicator;

	private GameObject m_rotationIcon;

	private ConstructionUI m_constructionUI;

	private PartSelector m_partselector;

	private Pointer m_pointer;

	private State m_state;

	private BasePart m_targetPart;

	[SerializeField]
	private BasePart.GridRotation m_originalTargetRotation;

	private Vector3 m_originalTargetPosition;

	private PointerTimeLine m_timeline;

	private float m_startTimer = 1f;

	private const string m_rotationTutorialKey = "_Rotation_Tutorial_Completed";

	private List<BasePart.PartType> m_acceptablePartsList;

	private enum State
	{
		Initial,
		Waiting,
		Playing,
		Stopped
	}

	public class Pointer
	{
		public Pointer(GameObject pointer, GameObject clickIndicator, GameObject rotationIcon)
		{
			this.m_pointer = pointer;
			this.m_pointer.transform.localScale = 1.05f * Vector3.zero;
			this.m_clickIndicator = clickIndicator;
			this.m_rotationIcon = rotationIcon;
		}

		public void SetPressHandler(OnPress onPress)
		{
			this.onPress = onPress;
		}

		public void SetPosition(Vector3 position)
		{
			this.m_pointer.transform.position = position;
			this.m_rotationIcon.transform.position = position - 2.75f * Vector3.up + 0.25f * Vector3.right;
		}

		public void Show(bool show)
		{
			this.m_pointer.SetActive(show);
			this.m_rotationIcon.SetActive(show);
			if (!show && this.m_clickIndicator)
			{
				this.m_clickIndicator.SetActive(false);
			}
		}

		public void Press()
		{
			this.m_pressTimer = 0f;
			this.m_clickIndicatorOn = true;
			if (this.m_clickIndicator)
			{
				this.m_clickIndicator.SetActive(true);
				this.m_clickIndicator.transform.position = this.m_pointer.transform.position;
			}
			this.m_pointer.transform.localScale = 0.85f * Vector3.one;
			if (this.onPress != null)
			{
				this.onPress();
			}
		}

		public void Release()
		{
			this.m_pointer.transform.localScale = 1.05f * Vector3.one;
		}

		public void Update()
		{
			this.m_pressTimer += Time.deltaTime;
			if (this.m_clickIndicatorOn && this.m_pressTimer >= 0.5f)
			{
				this.m_clickIndicatorOn = false;
				if (this.m_clickIndicator)
				{
					this.m_clickIndicator.SetActive(false);
				}
			}
			this.m_rotationIcon.transform.Rotate(Vector3.forward, -1f * Time.deltaTime);
		}

		private GameObject m_pointer;

		private GameObject m_clickIndicator;

		private GameObject m_rotationIcon;

		private float m_pressTimer;

		private bool m_clickIndicatorOn;

		private OnPress onPress;

		public delegate void OnPress();
	}

	public class PointerTimeLine
	{
		public PointerTimeLine(Pointer pointer)
		{
			this.m_pointer = pointer;
		}

		public bool IsFinished()
		{
			return this.m_finished;
		}

		public void Start()
		{
			this.m_pointer.Release();
			this.m_eventIndex = 0;
			if (this.m_eventIndex < this.m_events.Count)
			{
				this.m_events[this.m_eventIndex].Start();
			}
			this.m_finished = false;
		}

		public void Update()
		{
			if (this.m_eventIndex < this.m_events.Count)
			{
                PointerEvent pointerEvent = this.m_events[this.m_eventIndex];
				pointerEvent.Update();
				if (pointerEvent.Finished())
				{
					this.m_eventIndex++;
					if (this.m_eventIndex < this.m_events.Count)
					{
						this.m_events[this.m_eventIndex].Start();
					}
					else
					{
						this.m_finished = true;
					}
				}
			}
			this.m_pointer.Update();
		}

		public void AddEvent(PointerEvent e)
		{
			e.SetPointer(this.m_pointer);
			this.m_events.Add(e);
		}

		private Pointer m_pointer;

		private List<PointerEvent> m_events = new List<PointerEvent>();

		private Vector3 m_position;

		private int m_eventIndex;

		private bool m_finished;

		public class PointerEvent
		{
			public void SetPointer(Pointer pointer)
			{
				this.m_pointer = pointer;
			}

			public virtual void Start()
			{
			}

			public virtual void Update()
			{
			}

			public virtual bool Finished()
			{
				return this.m_finished;
			}

			protected Pointer m_pointer;

			protected bool m_finished;
		}

		public class Move : PointerEvent
        {
			public Move(List<Vector3> positions, float time)
			{
				this.m_time = time;
				this.m_positions = positions;
			}

			public override void Start()
			{
				this.m_timer = 0f;
				this.m_finished = false;
				if (this.m_positions.Count > 0)
				{
					this.m_pointer.SetPosition(this.m_positions[0]);
				}
				this.m_pointer.Show(true);
			}

			public override void Update()
			{
				this.m_timer += Time.deltaTime;
				if (this.m_timer >= this.m_time)
				{
					this.m_finished = true;
				}
				float num = MathsUtil.EaseInOutQuad(this.m_timer, 0f, 1f, this.m_time);
				num = 0.5f * num + 0.5f * (this.m_timer / this.m_time);
				this.m_pointer.SetPosition(Tutorial.PositionOnSpline(this.m_positions, num));
			}

			private float m_time;

			private float m_timer;

			private List<Vector3> m_positions;
		}

		public class Wait : PointerEvent
        {
			public Wait(float time)
			{
				this.m_time = time;
			}

			public override void Start()
			{
				this.m_finished = false;
				this.m_timer = 0f;
			}

			public override void Update()
			{
				this.m_timer += Time.deltaTime;
				if (this.m_timer > this.m_time)
				{
					this.m_finished = true;
				}
			}

			private float m_time;

			private float m_timer;
		}

		public class Press : PointerEvent
        {
			public override void Start()
			{
				this.m_pointer.Press();
				this.m_finished = true;
			}
		}

		public class Release : PointerEvent
        {
			public override void Start()
			{
				this.m_pointer.Release();
				this.m_finished = true;
			}
		}

		public class Hide : PointerEvent
        {
			public override void Start()
			{
				this.m_pointer.Show(false);
				this.m_finished = true;
			}
		}
	}
}
