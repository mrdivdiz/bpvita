using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : WPFMonoBehaviour
{
	private void Start()
	{
		EventManager.Connect(new EventManager.OnEvent<GameStateChanged>(this.ReceiveGameStateChanged));
		EventManager.Connect(new EventManager.OnEvent<UIEvent>(this.ReceiveUIEvent));
		this.m_pointerVisual = UnityEngine.Object.Instantiate<GameObject>(this.m_pointerPrefab);
		this.m_clickIndicator = UnityEngine.Object.Instantiate<GameObject>(this.m_clickIndicatorPrefab);
		this.m_clickIndicator.SetActive(false);
		this.m_pointerVisual.GetComponentInChildren<Renderer>().sortingLayerName = "Popup";
		this.m_clickIndicator.GetComponentInChildren<Renderer>().sortingLayerName = "Popup";
		Tutorial.SetOrderInLayer(this.m_pointerVisual, 3002);
		Tutorial.SetOrderInLayer(this.m_clickIndicator, 3002);
		this.m_pointer = new Pointer(this.m_pointerVisual, this.m_clickIndicator);
	}

	public void ReceiveUIEvent(UIEvent data)
	{
		UIEvent.Type type = data.type;
		if (type != UIEvent.Type.OpenIapMenu)
		{
			if (type == UIEvent.Type.CloseIapMenu)
			{
				this.m_shopIsOpen = false;
			}
		}
		else
		{
			this.m_shopIsOpen = true;
		}
	}

	public static void SetRenderQueue(GameObject parent, int queue)
	{
		Renderer component = parent.GetComponent<Renderer>();
		if (component != null && component.sharedMaterial != null)
		{
			component.material.renderQueue = queue;
		}
		for (int i = 0; i < parent.transform.childCount; i++)
		{
			Tutorial.SetRenderQueue(parent.transform.GetChild(i).gameObject, queue);
		}
	}

	public static void SetOrderInLayer(GameObject parent, int order)
	{
		Renderer component = parent.GetComponent<Renderer>();
		if (component != null)
		{
			component.sortingOrder = order;
		}
		for (int i = 0; i < parent.transform.childCount; i++)
		{
			Tutorial.SetOrderInLayer(parent.transform.GetChild(i).gameObject, order);
		}
	}

	private void OnDestroy()
	{
		EventManager.Disconnect(new EventManager.OnEvent<GameStateChanged>(this.ReceiveGameStateChanged));
		EventManager.Disconnect(new EventManager.OnEvent<UIEvent>(this.ReceiveUIEvent));
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
		if (this.m_toolBoxButton == null && GameObject.Find("ToolBoxButton") != null)
		{
			this.m_toolBoxButton = GameObject.Find("ToolBoxButton").GetComponent<ToolboxButton>();
		}
		if (!this.m_setupCompleted || this.m_shopIsOpen)
		{
			return;
		}
		if (WPFMonoBehaviour.levelManager.gameState == LevelManager.GameState.Building)
		{
			if ((this.m_state == Tutorial.State.OpenBook || this.m_state == Tutorial.State.DragPart || this.m_state == Tutorial.State.Initial) && WPFMonoBehaviour.levelManager.ContraptionProto.FindPig() != null && !this.m_contraptionStarted)
			{
				this.m_pointer.Show(false);
				this.m_state = Tutorial.State.StartContraption;
				this.m_playing = true;
				this.m_timeline = this.m_startContraptionTimeline;
				this.m_timeline.Start();
			}
			if (!this.m_playing && (this.m_state == Tutorial.State.DragPart || this.m_state == Tutorial.State.Initial) && WPFMonoBehaviour.levelManager.ContraptionProto.Parts.Count == 0 && this.m_constructionUI && !this.m_constructionUI.IsDragging())
			{
				this.m_playing = true;
				this.m_state = Tutorial.State.DragPart;
				this.m_timeline = this.m_dragPartTimeline;
				this.m_timeline.Start();
			}
			if (this.m_state == Tutorial.State.StartContraption && WPFMonoBehaviour.levelManager.ContraptionProto.FindPig() == null)
			{
				this.m_state = Tutorial.State.Initial;
				this.m_playing = false;
				this.m_pointer.Show(false);
			}
			if (this.m_toolBoxButton != null && this.m_toolBoxButton.ToolboxOpen)
			{
				this.m_playing = false;
				this.m_pointer.Show(false);
			}
			if (!this.m_playing && this.m_state == Tutorial.State.OpenBook)
			{
				if (!this.m_tutorialBookOpened)
				{
					this.m_playing = true;
					this.m_timeline = this.m_tutorialTimeline;
					this.m_timeline.Start();
				}
				else
				{
					this.m_state = Tutorial.State.Initial;
					this.m_playing = false;
					this.m_pointer.Show(false);
				}
			}
		}
		if (!this.m_playing)
		{
			return;
		}
		this.m_timeline.Update();
		if (this.m_timeline.IsFinished())
		{
			this.m_timeline.Start();
		}
		if ((this.m_state == Tutorial.State.DragPart || this.m_state == Tutorial.State.DragPig) && this.m_constructionUI.IsDragging())
		{
			this.m_playing = false;
			this.m_pointer.Show(false);
		}
		if (this.m_state == Tutorial.State.StartEngine && WPFMonoBehaviour.levelManager.ContraptionRunning && WPFMonoBehaviour.levelManager.ContraptionRunning.SomePoweredPartsEnabled())
		{
			this.m_playing = false;
			this.m_pointer.Show(false);
		}
	}

	private void SetupTutorial()
	{
		this.m_playing = true;
		InGameGUI inGameGUI = WPFMonoBehaviour.levelManager.InGameGUI;
		this.m_partselector = inGameGUI.BuildMenu.PartSelector;
		this.m_constructionUI = WPFMonoBehaviour.levelManager.ConstructionUI;
		GameObject tutorialButton = inGameGUI.BuildMenu.TutorialButton;
		GameObject playButton = inGameGUI.BuildMenu.PlayButton;
		if (this.m_constructionUI == null)
		{
			return;
		}
		this.m_tutorialTimeline = new PointerTimeLine(this.m_pointer);
		List<Vector3> list = new List<Vector3>();
		list.Add(tutorialButton.transform.position + 21f * Vector3.down);
		list.Add(tutorialButton.transform.position);
		this.m_tutorialTimeline.AddEvent(new PointerTimeLine.Wait(0.1f));
		this.m_tutorialTimeline.AddEvent(new PointerTimeLine.Move(list, 2.5f));
		this.m_tutorialTimeline.AddEvent(new PointerTimeLine.Press());
		this.m_tutorialTimeline.AddEvent(new PointerTimeLine.Wait(0.5f));
		this.m_tutorialTimeline.AddEvent(new PointerTimeLine.Release());
		this.m_tutorialTimeline.AddEvent(new PointerTimeLine.Wait(0.75f));
		this.m_tutorialTimeline.AddEvent(new PointerTimeLine.Hide());
		this.m_dragPartTimeline = new PointerTimeLine(this.m_pointer);
		ConstructionUI.PartDesc partDesc = this.m_constructionUI.FindPartDesc(BasePart.PartType.WoodenFrame);
		GameObject gameObject = this.m_partselector.FindPartButton(partDesc);
		Vector3 position = gameObject.transform.position;
		Vector3 vector = this.m_constructionUI.GridPositionToGuiPosition(this.m_dragTargetX, this.m_dragTargetY);
		List<Vector3> list2 = new List<Vector3>();
		list2.Add(position + 3f * Vector3.down + 1f * Vector3.left);
		list2.Add(position);
		this.m_dragPartTimeline.AddEvent(new PointerTimeLine.Move(list2, 1.5f));
		List<Vector3> list3 = new List<Vector3>();
		list3.Add(position);
		list3.Add(0.5f * (position + vector) + 0.5f * Vector3.left);
		list3.Add(vector);
		this.m_dragPartTimeline.AddEvent(new PointerTimeLine.Press());
		this.m_dragPartTimeline.AddEvent(new PointerTimeLine.Wait(0.5f));
		this.m_dragPartTimeline.AddEvent(new PointerTimeLine.Move(list3, 1.75f));
		this.m_dragPartTimeline.AddEvent(new PointerTimeLine.Wait(0.2f));
		this.m_dragPartTimeline.AddEvent(new PointerTimeLine.Release());
		this.m_dragPartTimeline.AddEvent(new PointerTimeLine.Wait(0.5f));
		this.m_dragPartTimeline.AddEvent(new PointerTimeLine.Hide());
		this.m_dragPartTimeline.AddEvent(new PointerTimeLine.Wait(2f));
		ConstructionUI.PartDesc partDesc2 = this.m_constructionUI.FindPartDesc(BasePart.PartType.Pig);
		GameObject gameObject2 = this.m_partselector.FindPartButton(partDesc2);
		Vector3 position2 = gameObject2.transform.position;
		Vector3 vector2 = this.m_constructionUI.GridPositionToGuiPosition(this.m_pigTargetX, this.m_pigTargetY);
		this.m_dragPigTimeline = new PointerTimeLine(this.m_pointer);
		List<Vector3> list4 = new List<Vector3>();
		list4.Add(position2 + 3f * Vector3.down + 1f * Vector3.left);
		list4.Add(position2);
		this.m_dragPigTimeline.AddEvent(new PointerTimeLine.Move(list4, 1.5f));
		List<Vector3> list5 = new List<Vector3>();
		list5.Add(position2);
		list5.Add(0.5f * (position2 + vector2) + 0.5f * Vector3.left);
		list5.Add(vector2);
		this.m_dragPigTimeline.AddEvent(new PointerTimeLine.Press());
		this.m_dragPigTimeline.AddEvent(new PointerTimeLine.Wait(0.5f));
		this.m_dragPigTimeline.AddEvent(new PointerTimeLine.Move(list5, 1.75f));
		this.m_dragPigTimeline.AddEvent(new PointerTimeLine.Wait(0.2f));
		this.m_dragPigTimeline.AddEvent(new PointerTimeLine.Release());
		this.m_dragPigTimeline.AddEvent(new PointerTimeLine.Wait(0.5f));
		this.m_dragPigTimeline.AddEvent(new PointerTimeLine.Hide());
		this.m_dragPigTimeline.AddEvent(new PointerTimeLine.Wait(2f));
		this.m_startContraptionTimeline = new PointerTimeLine(this.m_pointer);
		List<Vector3> list6 = new List<Vector3>();
		list6.Add(playButton.transform.position + 11f * Vector3.down);
		list6.Add(playButton.transform.position + 5.5f * Vector3.down + 0.5f * Vector3.left);
		list6.Add(playButton.transform.position);
		this.m_startContraptionTimeline.AddEvent(new PointerTimeLine.Wait(1f));
		this.m_startContraptionTimeline.AddEvent(new PointerTimeLine.Move(list6, 2f));
		this.m_startContraptionTimeline.AddEvent(new PointerTimeLine.Press());
		this.m_startContraptionTimeline.AddEvent(new PointerTimeLine.Wait(0.5f));
		this.m_startContraptionTimeline.AddEvent(new PointerTimeLine.Release());
		this.m_startContraptionTimeline.AddEvent(new PointerTimeLine.Wait(0.75f));
		this.m_startContraptionTimeline.AddEvent(new PointerTimeLine.Hide());
		if (!this.m_tutorialBookOpened)
		{
			this.m_state = Tutorial.State.OpenBook;
			this.m_timeline = this.m_tutorialTimeline;
			this.m_timeline.Start();
		}
		else if (WPFMonoBehaviour.levelManager.ContraptionProto.Parts.Count == 0)
		{
			this.m_state = Tutorial.State.DragPart;
			this.m_timeline = this.m_dragPartTimeline;
			this.m_timeline.Start();
		}
		else if (!this.m_contraptionStarted)
		{
			this.m_state = Tutorial.State.StartContraption;
			this.m_timeline = this.m_startContraptionTimeline;
			this.m_timeline.Start();
		}
		else
		{
			this.m_playing = false;
		}
		this.m_setupCompleted = true;
	}

	private void ReceiveGameStateChanged(GameStateChanged data)
	{
		this.m_setupCompleted = false;
		if (data.state == LevelManager.GameState.TutorialBook)
		{
			this.m_state = Tutorial.State.Initial;
			this.m_playing = false;
			this.m_pointer.Show(false);
			this.m_tutorialBookOpened = true;
		}
		else if (data.state == LevelManager.GameState.Building)
		{
			if (!this.m_finished)
			{
				base.StartCoroutine(this.StartTutorial());
			}
		}
		else if (data.state == LevelManager.GameState.Running)
		{
			this.m_playing = false;
			this.m_pointer.Show(false);
			this.m_state = Tutorial.State.Initial;
			this.m_contraptionStarted = true;
		}
		else
		{
			this.m_playing = false;
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
			this.SetupTutorial();
		}
		yield break;
	}

	private IEnumerator StartEngineTutorial()
	{
		yield return new WaitForSeconds(0.5f);
		if (WPFMonoBehaviour.levelManager.gameState == LevelManager.GameState.Running)
		{
			this.m_startEnginesTimeLine = new PointerTimeLine(this.m_pointer);
			GameObject gameObject = GameObject.Find("300_EnginesButton");
			if (gameObject)
			{
				List<Vector3> list = new List<Vector3>();
				list.Add(gameObject.transform.position + 11f * Vector3.down);
				list.Add(gameObject.transform.position + 5.5f * Vector3.down + 0.5f * Vector3.left);
				list.Add(gameObject.transform.position);
				this.m_startEnginesTimeLine.AddEvent(new PointerTimeLine.Wait(1f));
				this.m_startEnginesTimeLine.AddEvent(new PointerTimeLine.Move(list, 2f));
				this.m_startEnginesTimeLine.AddEvent(new PointerTimeLine.Press());
				this.m_startEnginesTimeLine.AddEvent(new PointerTimeLine.Wait(0.5f));
				this.m_startEnginesTimeLine.AddEvent(new PointerTimeLine.Release());
				this.m_startEnginesTimeLine.AddEvent(new PointerTimeLine.Wait(0.75f));
				this.m_startEnginesTimeLine.AddEvent(new PointerTimeLine.Hide());
				this.m_timeline = this.m_startEnginesTimeLine;
				this.m_timeline.Start();
				this.m_state = Tutorial.State.StartEngine;
				this.m_playing = true;
			}
		}
		yield break;
	}

	public GameObject m_pointerPrefab;

	public GameObject m_clickIndicatorPrefab;

	public int m_dragTargetX;

	public int m_dragTargetY = 1;

	public int m_pigTargetX;

	public int m_pigTargetY = 1;

	private bool m_playing;

	private bool m_finished;

	private bool m_setupCompleted;

	private PartSelector m_partselector;

	private ConstructionUI m_constructionUI;

	private GameObject m_pointerVisual;

	private GameObject m_clickIndicator;

	private Pointer m_pointer;

	private PointerTimeLine m_tutorialTimeline;

	private PointerTimeLine m_dragPartTimeline;

	private PointerTimeLine m_dragPigTimeline;

	private PointerTimeLine m_startContraptionTimeline;

	private PointerTimeLine m_startEnginesTimeLine;

	private PointerTimeLine m_timeline;

	private State m_state;

	private bool m_tutorialBookOpened;

	private bool m_contraptionStarted;

	private ToolboxButton m_toolBoxButton;

	private bool m_shopIsOpen;

	private enum State
	{
		Initial,
		OpenBook,
		DragPart,
		DragPig,
		StartContraption,
		StartEngine
	}

	public class Pointer
	{
		public Pointer(GameObject pointer, GameObject clickIndicator)
		{
			this.m_pointer = pointer;
			this.m_pointer.transform.localScale = 1.05f * Vector3.zero;
			this.m_clickIndicator = clickIndicator;
		}

		public void SetPressHandler(OnPress onPress)
		{
			this.onPress = onPress;
		}

		public void SetPosition(Vector3 position)
		{
			this.m_pointer.transform.position = position;
		}

		public void Show(bool show)
		{
			if (this.m_pointer)
			{
				this.m_pointer.SetActive(show);
			}
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
			this.m_pressTimer += Time.unscaledDeltaTime;
			if (this.m_clickIndicatorOn && this.m_pressTimer >= 0.5f)
			{
				this.m_clickIndicatorOn = false;
				if (this.m_clickIndicator)
				{
					this.m_clickIndicator.SetActive(false);
				}
			}
		}

		private GameObject m_pointer;

		private GameObject m_clickIndicator;

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
				this.m_timer += Time.unscaledDeltaTime;
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
				this.m_timer += Time.unscaledDeltaTime;
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
