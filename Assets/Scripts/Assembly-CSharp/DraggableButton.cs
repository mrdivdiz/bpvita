using System.Reflection;
using UnityEngine;

[RequireComponent(typeof(Sprite))]
[RequireComponent(typeof(BoxCollider))]
public class DraggableButton : Widget
{
	public override void SetListener(WidgetListener listener)
	{
		this.m_listener = listener;
	}

	public bool isDragging
	{
		get
		{
			return this.dragging;
		}
	}

	public GameObject Icon
	{
		get
		{
			return this.icon;
		}
		set
		{
			this.icon = value;
		}
	}

	public object DragObject
	{
		get
		{
			return this.dragObject;
		}
		set
		{
			this.dragObject = value;
		}
	}

	public GameObject DragIconPrefab
	{
		get
		{
			return this.dragIconPrefab;
		}
		set
		{
			this.dragIconPrefab = value;
		}
	}

	public float DragIconScale
	{
		get
		{
			return this.dragIconScale;
		}
		set
		{
			this.dragIconScale = value;
		}
	}

	public GameObject MessageTargetObject
	{
		get
		{
			return this.messageTargetObject;
		}
		set
		{
			this.messageTargetObject = value;
			this.BindTarget();
		}
	}

	public string TargetComponent
	{
		get
		{
			return this.targetComponent;
		}
		set
		{
			this.targetComponent = value;
			this.BindTarget();
		}
	}

	public string MethodToInvoke
	{
		get
		{
			return this.methodToInvoke;
		}
		set
		{
			this.methodToInvoke = value;
			this.BindTarget();
		}
	}

	public string MessageParameter
	{
		get
		{
			return this.messageParameter;
		}
		set
		{
			this.messageParameter = value;
			this.BindTarget();
		}
	}

	public void CancelDrag()
	{
		if (this.dragging)
		{
			this.dragging = false;
			if (this.dragIcon != null)
			{
				this.dragIcon.SetActive(false);
				this.dragIcon.transform.localPosition = Vector3.zero;
			}
			if (this.m_listener != null)
			{
				this.m_listener.CancelDrag(this, this.dragObject);
			}
		}
	}

	public override void Select()
	{
		this.selectedVisual.GetComponent<Renderer>().enabled = true;
		base.GetComponent<Renderer>().enabled = false;
	}

	public override void Deselect()
	{
		this.CancelDrag();
		this.selectedVisual.GetComponent<Renderer>().enabled = false;
		base.GetComponent<Renderer>().enabled = true;
	}

	private void Awake()
	{
		this.BindTarget();
		this.ButtonAwake();
		this.selectedVisual = base.transform.Find("Selected").gameObject;
		this.selectedVisual.GetComponent<Renderer>().enabled = false;
	}

	private void Start()
	{
		if (this.dragIconPrefab)
		{
			this.dragIcon = UnityEngine.Object.Instantiate<GameObject>(this.dragIconPrefab);
			this.dragIcon.transform.parent = base.transform;
			this.dragIcon.transform.localScale = new Vector3(this.dragIconScale, this.dragIconScale, 1f);
			this.dragIcon.transform.localPosition = Vector3.zero;
			this.dragIcon.SetActive(false);
		}
	}

	protected virtual void ButtonAwake()
	{
	}

	private void BindTarget()
	{
		this.methodInfo = null;
		if (this.messageTargetObject && this.targetComponent != string.Empty && this.methodToInvoke != string.Empty)
		{
			this.component = this.messageTargetObject.GetComponent(this.targetComponent);
			if (this.component)
			{
				this.methodInfo = this.component.GetType().GetMethod(this.methodToInvoke);
				if (this.methodInfo != null)
				{
					ParameterInfo[] parameters = this.methodInfo.GetParameters();
					if (parameters.Length > 0)
					{
						this.hasStringParameter = (parameters[0].ParameterType == typeof(string));
						this.parameterArray = new object[]
						{
							this.messageParameter
						};
					}
				}
			}
		}
	}

	protected override void OnActivate()
	{
		if (this.messageTargetObject && this.methodInfo != null)
		{
			if (this.hasStringParameter)
			{
				this.methodInfo.Invoke(this.component, this.parameterArray);
			}
			else
			{
				this.methodInfo.Invoke(this.component, null);
			}
		}
	}

	protected override void OnInput(InputEvent input)
	{
		AudioManager instance = Singleton<AudioManager>.Instance;
		if (input.type == InputEvent.EventType.Press)
		{
			this.down = true;
			this.dragging = true;
			if (this.dragIcon)
			{
				this.dragIcon.SetActive(true);
			}
			if (this.m_listener != null)
			{
				this.m_listener.StartDrag(this, this.dragObject);
			}
			this.selectedVisual.GetComponent<Renderer>().enabled = true;
			base.GetComponent<Renderer>().enabled = false;
			if (this.m_listener != null)
			{
				this.m_listener.Select(this, this.dragObject);
			}
		}
		else if (input.type == InputEvent.EventType.Release)
		{
			this.down = false;
			base.Activate();
			instance.Play2dEffect(Singleton<GuiManager>.Instance.DefaultButtonAudio);
		}
		else if (input.type == InputEvent.EventType.MouseEnter)
		{
			this.down = true;
		}
		else if (input.type == InputEvent.EventType.MouseLeave)
		{
			this.down = false;
		}
	}

	private void Update()
	{
		if (this.dragging)
		{
			GuiManager.Pointer pointer = GuiManager.GetPointer();
			Vector3 vector = Singleton<GuiManager>.Instance.FindCamera().ScreenToWorldPoint(pointer.position);
			float z = base.transform.position.z - 1f;
			Vector3 position = new Vector3(vector.x, vector.y, z);
			if (this.dragIcon)
			{
				this.dragIcon.transform.position = position;
			}
			if (pointer.up)
			{
				if (this.dragIcon)
				{
					this.dragIcon.SetActive(false);
					this.dragIcon.transform.localPosition = Vector3.zero;
				}
				this.dragging = false;
				if (this.m_listener != null)
				{
					this.m_listener.Drop(this, position, this.dragObject);
				}
			}
		}
		if (this.animate)
		{
			float num = base.transform.localScale.x;
			if (this.down && num < 1.2f)
			{
				num = Mathf.Min(num + Time.deltaTime * 7f, 1.2f);
			}
			else if (!this.down && num > 1f)
			{
				num = Mathf.Max(num - Time.deltaTime * 7f, 1f);
			}
			base.transform.localScale = new Vector3(num, num, 1f);
		}
		this.ButtonUpdate();
	}

	protected virtual void ButtonUpdate()
	{
	}

	private WidgetListener m_listener;

	[SerializeField]
	private GameObject icon;

	[SerializeField]
	private object dragObject;

	[SerializeField]
	private GameObject dragIconPrefab;

	[SerializeField]
	private float dragIconScale = 1f;

	[SerializeField]
	private GameObject messageTargetObject;

	[SerializeField]
	private string targetComponent;

	[SerializeField]
	private string methodToInvoke;

	[SerializeField]
	private string messageParameter;

	[SerializeField]
	private bool animate = true;

	private Component component;

	private MethodInfo methodInfo;

	private bool hasStringParameter;

	private object[] parameterArray;

	private bool down;

	private const float HoverSoundDelay = 0.15f;

	private GameObject dragIcon;

	private bool dragging;

	private GameObject selectedVisual;
}
