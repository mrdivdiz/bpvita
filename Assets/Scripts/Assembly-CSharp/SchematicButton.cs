using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchematicButton : SliderButton
{
	private static LevelManager LevelManager
	{
		get
		{
			return (!(SchematicButton.levelManager != null)) ? (SchematicButton.levelManager = UnityEngine.Object.FindObjectOfType<LevelManager>()) : SchematicButton.levelManager;
		}
	}

	public static string LastLoadedSlotKey
	{
		get
		{
			if (SchematicButton.LevelManager.CurrentGameMode is CakeRaceMode)
			{
				return string.Format("cr_{0}_LastLoadedContraptionSlotIndex", Singleton<GameManager>.Instance.CurrentSceneName);
			}
			return string.Format("{0}_LastLoadedContraptionSlotIndex", Singleton<GameManager>.Instance.CurrentSceneName);
		}
	}

	public bool ToolboxOpen
	{
		get
		{
			return this.isButtonOut;
		}
	}

	protected override void Start()
	{
		base.Start();
		if (SchematicButton.LevelManager != null && !SchematicButton.LevelManager.m_sandbox)
		{
			return;
		}
		this.origPositions = new List<Vector3>();
		this.targetPositions = new List<Vector3>();
		foreach (GameObject gameObject in this.toggleList)
		{
			this.origPositions.Add(gameObject.transform.position);
			this.targetPositions.Add(gameObject.transform.position + new Vector3(0f, 5f));
		}
		for (int i = 0; i < this.SLOT_COUNT; i++)
		{
			Transform transform = base.transform.FindChildRecursively(string.Format("Slot{0:00}", i + 1));
			if (!(transform == null))
			{
				Transform transform2 = transform.Find("SlotSelected");
				if (!(transform2 == null))
				{
					this.selectedSlotSprites.Add(transform2);
					transform2.GetComponent<Renderer>().enabled = false;
				}
			}
		}
		if (!GameProgress.HasKey(SchematicButton.LastLoadedSlotKey, GameProgress.Location.Local, null))
		{
			GameProgress.SetInt(SchematicButton.LastLoadedSlotKey, 0, GameProgress.Location.Local);
		}
	}

	private void OnEnable()
	{
		this.button.transform.Find("Gear").transform.rotation = Quaternion.identity;
		this.isButtonOut = (this.lastIsPlaying = (this.coroutineRunning = false));
		this.EnableRendererRecursively(base.gameObject, false);
		this.ActivateToggleList(true);
		if (this.toggleList != null && this.origPositions != null)
		{
			for (int i = 0; i < this.toggleList.Count; i++)
			{
				this.toggleList[i].transform.position = this.origPositions[i];
			}
		}
		EventManager.Connect(new EventManager.OnEvent<UIEvent>(this.OnReceivedEvent));
	}

	private void OnDisable()
	{
		for (int i = 0; i < base.transform.childCount; i++)
		{
			Transform child = base.transform.GetChild(i);
			Vector3 localPosition = child.localPosition;
			localPosition.x = (localPosition.y = 0f);
			child.localPosition = localPosition;
			child.localRotation = Quaternion.identity;
			child.localScale = Vector3.one * 0.2f;
		}
		EventManager.Disconnect(new EventManager.OnEvent<UIEvent>(this.OnReceivedEvent));
	}

	private void OnReceivedEvent(UIEvent data)
	{
		if (SchematicButton.LevelManager != null && !SchematicButton.LevelManager.m_sandbox)
		{
			return;
		}
		int num = -1;
		UIEvent.Type type = data.type;
		if (type != UIEvent.Type.LoadContraptionSlot1)
		{
			if (type != UIEvent.Type.LoadContraptionSlot2)
			{
				if (type == UIEvent.Type.LoadContraptionSlot3)
				{
					num = 2;
				}
			}
			else
			{
				num = 1;
			}
		}
		else
		{
			num = 0;
		}
		if (num >= 0)
		{
			GameProgress.SetInt(SchematicButton.LastLoadedSlotKey, num, GameProgress.Location.Local);
			for (int i = 0; i < this.selectedSlotSprites.Count; i++)
			{
				this.selectedSlotSprites[i].GetComponent<Renderer>().enabled = (num == i);
			}
		}
	}

	public void OnPressed()
	{
		if (base.GetComponent<Animation>().isPlaying || this.coroutineRunning)
		{
			return;
		}
		this.EnableRendererRecursively(base.gameObject, true);
		int @int = GameProgress.GetInt(SchematicButton.LastLoadedSlotKey, 0, GameProgress.Location.Local, null);
		for (int i = 0; i < this.selectedSlotSprites.Count; i++)
		{
			this.selectedSlotSprites[i].GetComponent<Renderer>().enabled = (@int == i);
		}
		bool flag = this.isButtonOut;
		this.InitAnimationStates(flag, new AnimationState[]
		{
			base.GetComponent<Animation>()["SchematicsButtonSlide"],
			this.button.GetComponent<Animation>()["ToolBoxButton"]
		});
		this.button.GetComponent<Animation>().Play();
		base.GetComponent<Animation>().Play();
		this.isButtonOut = !this.isButtonOut;
		if (this.isButtonOut)
		{
		}
		for (int j = 0; j < this.toggleList.Count; j++)
		{
			if (flag)
			{
				base.StartCoroutine(this.MoveObject(this.toggleList[j].transform, this.origPositions[j]));
			}
			else
			{
				base.StartCoroutine(this.MoveObject(this.toggleList[j].transform, this.targetPositions[j]));
			}
		}
	}

	private void Update()
	{
		if (!base.GetComponent<Animation>().isPlaying && this.lastIsPlaying && !this.isButtonOut)
		{
			this.ActivateToggleList(true);
		}
		if (this.m_openList)
		{
			this.OnPressed();
			this.m_openList = false;
		}
		this.lastIsPlaying = base.GetComponent<Animation>().isPlaying;
	}

	private void ActivateToggleList(bool state)
	{
		foreach (GameObject gameObject in this.toggleList)
		{
			gameObject.SetActive(state);
		}
	}

	private void InitAnimationStates(bool reverse, params AnimationState[] states)
	{
		foreach (AnimationState animationState in states)
		{
			animationState.speed = (float)((!reverse) ? 1 : -1);
			animationState.time = ((!reverse) ? 0f : animationState.length);
		}
	}

	private void EnableRendererRecursively(GameObject obj, bool enable)
	{
		if (obj.GetComponent<Renderer>())
		{
			obj.GetComponent<Renderer>().enabled = enable;
		}
		if (obj.GetComponent<Collider>())
		{
			obj.GetComponent<Collider>().enabled = enable;
		}
		for (int i = 0; i < obj.transform.childCount; i++)
		{
			this.EnableRendererRecursively(obj.transform.GetChild(i).gameObject, enable);
		}
	}

	public void OpenMenu()
	{
		this.ActivateToggleList(true);
	}

	private IEnumerator MoveObject(Transform tf, Vector3 targetPos)
	{
		this.coroutineRunning = true;
		Vector3 startPos = tf.position;
		float step = 0f;
		while (step < 1f)
		{
			tf.position = Vector3.Lerp(startPos, targetPos, step);
			step += this.hideSpeed * Time.deltaTime;
			yield return null;
		}
		tf.position = targetPos;
		this.coroutineRunning = false;
		yield break;
	}

	public float hideSpeed;

	public List<GameObject> toggleList = new List<GameObject>();

	public GameObject button;

	private bool isButtonOut;

	private bool lastIsPlaying;

	private bool coroutineRunning;

	private const string AnimName = "SchematicsButtonSlide";

	private const string ToolBoxAnimName = "ToolBoxButton";

	private List<Vector3> origPositions;

	private List<Vector3> targetPositions;

	private List<Transform> selectedSlotSprites = new List<Transform>();

	private static LevelManager levelManager;

	private readonly int SLOT_COUNT = 3;

	private bool m_openList;
}
