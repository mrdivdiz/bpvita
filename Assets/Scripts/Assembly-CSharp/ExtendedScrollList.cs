using System.Collections.Generic;
using UnityEngine;

public class ExtendedScrollList : Widget, WidgetListener
{
	public int UsedRows
	{
		get
		{
			return this.usedRows;
		}
	}

	public void SetButtonScale(float buttonScale)
	{
		this.buttonScale = buttonScale;
		this.offset *= buttonScale;
	}

	public void SetMaxRows(int rows)
	{
		this.maxRows = rows;
	}

	public void ScrollLeft()
	{
		this.scrollTargetOffset = this.scrollOffset - 0.5f * this.scrollAreaWidth;
		this.updatePlacement = true;
		this.onRightBorder = false;
		float num = -0.5f * (float)this.horizontalCount * this.offset.x;
		float num2 = this.ScreenWidth() * 0.5f;
		float num3 = num - this.scrollTargetOffset;
		float num4 = -num2 + this.scrollButtonWidth;
		if (Mathf.Abs(num3 - num4) < 3f)
		{
			this.scrollTargetOffset -= 3f;
		}
		if (num3 > num4)
		{
			this.scrollTargetOffset = num - num4 - 0.01f;
		}
		this.scrollTargetSet = true;
		this.scrollTargetStart = this.scrollOffset;
		this.scrollTargetSetTime = Time.time;
	}

	public void ScrollRight()
	{
		this.scrollTargetOffset = this.scrollOffset + 0.5f * this.scrollAreaWidth;
		this.updatePlacement = true;
		this.onLeftBorder = false;
		float num = 0.5f * (float)this.horizontalCount * this.offset.x;
		float num2 = this.ScreenWidth() * 0.5f;
		float num3 = num - this.scrollTargetOffset;
		float num4 = num2 - this.scrollButtonWidth;
		if (Mathf.Abs(num3 - num4) < 3f)
		{
			this.scrollTargetOffset += 3f;
		}
		if (num3 < num4)
		{
			this.scrollTargetOffset = num - num4 + 0.01f;
		}
		this.scrollTargetSet = true;
		this.scrollTargetStart = this.scrollOffset;
		this.scrollTargetSetTime = Time.time;
	}

	public override void SetListener(WidgetListener listener)
	{
		this.m_listener = listener;
	}

	protected override void OnInput(InputEvent input)
	{
		if (input.type == InputEvent.EventType.Press && this.canScroll)
		{
			this.dragging = true;
			this.dragStart = Singleton<GuiManager>.Instance.FindCamera().ScreenToWorldPoint(GuiManager.GetPointer().position);
			this.scrollOffsetAtDragStart = this.scrollOffset;
			this.dragDirectionDetected = false;
			this.dragLocked = false;
		}
	}

	public GameObject FindButton(object dragObject)
	{
		foreach (GameObject gameObject in this.buttons)
		{
			DraggableButton component = gameObject.GetComponent<DraggableButton>();
			if (component && component.DragObject == dragObject)
			{
				return component.gameObject;
			}
		}
		return null;
	}

	public void SetSelection(object targetObject)
	{
		foreach (GameObject gameObject in this.buttons)
		{
			DraggableButton component = gameObject.GetComponent<DraggableButton>();
			if (component && component.DragObject == targetObject)
			{
				this.Select(component, targetObject);
				component.Select();
			}
		}
	}

	public void Select(Widget widget, object targetObject)
	{
		foreach (GameObject gameObject in this.buttons)
		{
			Widget component = gameObject.GetComponent<Widget>();
			if (component && component != widget)
			{
				component.Deselect();
			}
		}
		if (this.m_listener != null)
		{
			this.m_listener.Select(widget, targetObject);
		}
		if (targetObject is ConstructionUI.PartDesc)
		{
			EventManager.Send(new PartSelectedEvent((targetObject as ConstructionUI.PartDesc).part.m_partType));
		}
	}

	public void ResetSelection()
	{
		foreach (GameObject gameObject in this.buttons)
		{
			Widget component = gameObject.GetComponent<Widget>();
			if (component)
			{
				component.Deselect();
			}
		}
	}

	public void StartDrag(Widget widget, object targetObject)
	{
		if (this.m_listener != null)
		{
			this.m_listener.StartDrag(widget, targetObject);
		}
	}

	public void CancelDrag(Widget widget, object targetObject)
	{
		if (this.m_listener != null)
		{
			this.m_listener.CancelDrag(widget, targetObject);
		}
	}

	public void Drop(Widget widget, Vector3 dropPosition, object targetObject)
	{
		if (this.m_listener != null)
		{
			this.m_listener.Drop(widget, dropPosition, targetObject);
		}
	}

	public void AddButton(Widget button)
	{
		button.transform.localScale *= this.buttonScale;
		button.SetListener(this);
		this.buttons.Add(button.gameObject);
		this.PlaceButtons(ExtendedScrollList.Action.Place);
	}

	public void RemoveButton(Widget button)
	{
		button.SetListener(null);
		this.buttons.Remove(button.gameObject);
		UnityEngine.Object.Destroy(button.gameObject);
		this.PlaceButtons(ExtendedScrollList.Action.Place);
	}

	private float ScreenWidth()
	{
		if (this.fillScreenWidth)
		{
			return 20f * (float)Screen.width / (float)Screen.height - this.leftMargin - this.rightMargin;
		}
		if (this.screenWidth <= 0f)
		{
			float x = this.leftButton.transform.Find("Button").GetComponent<Collider>().bounds.min.x;
			float x2 = this.rightButton.transform.Find("Button").GetComponent<Collider>().bounds.max.x;
			this.screenWidth = Mathf.Abs(x - x2);
		}
		return this.screenWidth;
	}

	private void Start()
	{
		Vector3 point = this.leftButton.transform.Find("Button").GetComponent<Sprite>().Size;
		this.scrollButtonWidth = Mathf.Abs((this.leftButton.transform.Find("Button").transform.rotation * point).x);
		if (this.fillScreenWidth)
		{
			float num = (float)this.horizontalCount * this.offset.x * 0.5f;
			if (num > 10f * (float)Screen.width / (float)Screen.height - this.leftMargin - this.rightMargin)
			{
				Vector3 localPosition = base.transform.localPosition;
				localPosition.x += 0.5f * this.leftMargin;
				localPosition.x -= 0.5f * this.rightMargin;
				base.transform.localPosition = localPosition;
				localPosition = this.scrollButtonOffset.transform.localPosition;
				localPosition.x += 0.5f * this.leftMargin;
				localPosition.x -= 0.5f * this.rightMargin;
				this.scrollButtonOffset.transform.localPosition = localPosition;
			}
		}
		this.scrollAreaWidth = this.ScreenWidth() - 2.5f * this.scrollButtonWidth;
		float num2 = -0.5f * (float)this.horizontalCount * this.offset.x;
		float num3 = this.ScreenWidth() * 0.5f;
		float num4 = -num3 + this.scrollButtonWidth;
		this.scrollOffset = num2 - num4 - 0.01f;
		this.SetBorderStates();
	}

	private void Update()
	{
		if (this.scrollTargetSet)
		{
			float num = Mathf.Abs(this.scrollTargetStart - this.scrollTargetOffset) / (0.5f * this.scrollAreaWidth);
			if (num < 0.1f)
			{
				num = 0.1f;
			}
			float num2 = Mathf.Pow(4f * (Time.time - this.scrollTargetSetTime) / num, 1f);
			if (num2 > 1f)
			{
				num2 = 1f;
				this.scrollTargetSet = false;
			}
			this.scrollOffset = Mathf.Lerp(this.scrollTargetStart, this.scrollTargetOffset, num2);
			this.PlaceButtons(ExtendedScrollList.Action.Place);
		}
		if (this.dragging)
		{
			Vector3 b = Singleton<GuiManager>.Instance.FindCamera().ScreenToWorldPoint(GuiManager.GetPointer().position);
			if (this.dragDirectionDetected && this.dragLocked)
			{
				float num3 = this.dragStart.x - b.x;
				if (num3 != 0f)
				{
					this.onLeftBorder = false;
					this.onRightBorder = false;
				}
				this.scrollOffset = this.scrollOffsetAtDragStart + num3;
				while (this.scrollHistory.Count > 0)
				{
                    ScrollInfo scrollInfo = this.scrollHistory.Peek();
					if (scrollInfo.time >= Time.time - 0.1f)
					{
						float num4 = Time.time - scrollInfo.time;
						if (num4 > 0f)
						{
							this.scrollVelocity = (this.scrollOffset - scrollInfo.offset) / num4;
						}
						break;
					}
					this.scrollHistory.Dequeue();
				}
				this.scrollHistory.Enqueue(new ScrollInfo(Time.time, this.scrollOffset));
				this.PlaceButtons(ExtendedScrollList.Action.Place);
			}
			if (!this.dragDirectionDetected && Vector3.Distance(this.dragStart, b) > 0.5f)
			{
				this.dragDirectionDetected = true;
				bool flag = Mathf.Abs(this.dragStart.x - b.x) < 2.5f * (b.y - this.dragStart.y);
				if (flag)
				{
					this.dragging = false;
				}
				else
				{
					this.dragLocked = true;
				}
			}
			if (GuiManager.GetPointer().up || (this.dragDirectionDetected && !this.dragLocked))
			{
				this.dragging = false;
			}
		}
		else if (Mathf.Abs(this.scrollVelocity) > 0.01f)
		{
			float num5 = Time.deltaTime * this.scrollVelocity;
			if (num5 != 0f)
			{
				this.onLeftBorder = false;
				this.onRightBorder = false;
			}
			this.scrollOffset += num5;
			this.scrollVelocity *= Mathf.Pow(0.9f, Time.deltaTime / 0.0166666675f);
			this.PlaceButtons(ExtendedScrollList.Action.Place);
		}
		this.SetBorderStates();
		if (this.updatePlacement)
		{
			this.PlaceButtons(ExtendedScrollList.Action.Place);
			this.updatePlacement = false;
		}
	}

	public void Clear()
	{
		foreach (GameObject obj in this.buttons)
		{
			UnityEngine.Object.Destroy(obj);
		}
		this.buttons.Clear();
	}

	private void OnDrawGizmos()
	{
		if (this.buttonPrefab)
		{
			this.PlaceButtons(ExtendedScrollList.Action.DrawGizmos);
		}
		if (!Application.isPlaying && this.fillScreenWidth)
		{
			float y = 1f;
			if (this.leftButton)
			{
				y = this.leftButton.transform.Find("Button").GetComponent<Collider>().bounds.size.y;
			}
			float num = -13.333333f + this.leftMargin;
			float num2 = 13.333333f + this.rightMargin;
			Vector3 position = base.transform.position;
			position.x = 0.5f * (num + num2);
			Gizmos.DrawWireCube(position, new Vector3(num2 - num, y, 0f));
		}
	}

	private void SetBorderStates()
	{
		float num = -0.5f * (float)this.horizontalCount * this.offset.x;
		float num2 = this.ScreenWidth() * 0.5f;
		if (num > -num2)
		{
			if (this.leftButton.activeInHierarchy || this.rightButton.activeInHierarchy)
			{
				if (this.scrollOffset != 0f || this.scrollVelocity != 0f)
				{
					this.scrollOffset = 0f;
					this.scrollVelocity = 0f;
					this.PlaceButtons(ExtendedScrollList.Action.Place);
				}
				this.leftButton.SetActive(false);
				this.rightButton.SetActive(false);
				this.canScroll = false;
			}
		}
		else if (!this.leftButton.activeInHierarchy || !this.rightButton.activeInHierarchy)
		{
			this.leftButton.SetActive(true);
			this.EnableScrollButtonLeft(true);
			this.rightButton.SetActive(true);
			this.EnableScrollButtonRight(true);
			this.canScroll = true;
		}
		if (this.canScroll)
		{
			float num3 = num - this.scrollOffset;
			float num4 = -num2 + this.scrollButtonWidth;
			if (num3 - num4 > 0.001f)
			{
				this.scrollOffset = num - num4;
				this.scrollVelocity = 0f;
				this.EnableScrollButtonLeft(false);
				this.onLeftBorder = true;
				this.PlaceButtons(ExtendedScrollList.Action.Place);
			}
			else if (!this.onLeftBorder)
			{
				this.EnableScrollButtonLeft(true);
			}
			float num5 = -num;
			float num6 = num5 - this.scrollOffset;
			float num7 = num2 - this.scrollButtonWidth;
			if (num6 - num7 < -0.001f)
			{
				this.scrollOffset = num5 - num7;
				this.scrollVelocity = 0f;
				this.EnableScrollButtonRight(false);
				this.onRightBorder = true;
				this.PlaceButtons(ExtendedScrollList.Action.Place);
			}
			else if (!this.onRightBorder)
			{
				this.EnableScrollButtonRight(true);
			}
		}
		else
		{
			this.scrollOffset = 0f;
		}
	}

	private void EnableScrollButtonLeft(bool enable)
	{
		if (this.isLeftEnabled != enable)
		{
			this.isLeftEnabled = enable;
			this.EnableRendererRecursively(this.leftButton, enable);
		}
	}

	private void EnableScrollButtonRight(bool enable)
	{
		if (this.isRightEnabled != enable)
		{
			this.isRightEnabled = enable;
			this.EnableRendererRecursively(this.rightButton, enable);
		}
	}

	private void EnableRendererRecursively(GameObject obj, bool enable)
	{
		Renderer component = obj.GetComponent<Renderer>();
		if (component)
		{
			component.enabled = enable;
		}
		Collider component2 = obj.GetComponent<Collider>();
		if (component2)
		{
			component2.enabled = enable;
		}
		for (int i = 0; i < obj.transform.childCount; i++)
		{
			this.EnableRendererRecursively(obj.transform.GetChild(i).gameObject, enable);
		}
	}

	private void PlaceScrollButtons()
	{
		Vector3 localPosition = this.scrollButtonOffset.transform.localPosition;
		if (this.usedRows > 1)
		{
			localPosition.y = 0.5f * (float)(this.usedRows - 1) * this.offset.y;
		}
		else
		{
			localPosition.y = 0f;
		}
		float num = this.ScreenWidth() * 0.5f;
		Vector3 localPosition2 = this.leftButton.transform.localPosition;
		localPosition2.x = -num + this.scrollButtonWidth * 0.5f;
		this.leftButton.transform.localPosition = localPosition2;
		localPosition2 = this.rightButton.transform.localPosition;
		localPosition2.x = num - this.scrollButtonWidth * 0.5f;
		this.rightButton.transform.localPosition = localPosition2;
		this.scrollButtonOffset.transform.localPosition = localPosition;
	}

	private void PlaceButtons(Action action)
	{
		if (action == ExtendedScrollList.Action.Place)
		{
			this.horizontalCount = this.buttons.Count;
			this.scrollAreaWidth = this.ScreenWidth() - 2.5f * this.scrollButtonWidth;
			int num = (int)this.scrollAreaWidth / (int)this.offset.x - 3;
			if (this.horizontalCount > num)
			{
				this.usedRows = this.maxRows;
				this.horizontalCount = this.horizontalCount / this.usedRows + ((this.horizontalCount % this.usedRows != 0) ? 1 : 0);
			}
			else
			{
				this.usedRows = 1;
			}
			this.PlaceScrollButtons();
		}
		int num2 = 0;
		int num3 = 0;
		Vector3 position = base.transform.position;
		position.x -= 0.5f * ((float)(this.horizontalCount - 1) * this.offset.x) + this.scrollOffset;
		position.y -= 0.5f * this.buttonPrefab.GetComponent<Sprite>().Size.y;
		position.y += (float)(this.usedRows - 1) * this.offset.y;
		Vector3 vector = position;
		int num4 = this.count;
		if (action == ExtendedScrollList.Action.Place)
		{
			num4 = this.buttons.Count;
		}
		for (int i = 0; i < num4; i++)
		{
			if (action == ExtendedScrollList.Action.Place)
			{
				this.buttons[i].transform.position = vector;
			}
			else
			{
				Gizmos.DrawWireCube(vector, this.buttonPrefab.GetComponent<Sprite>().Size);
			}
			vector.x += this.offset.x;
			num2++;
			if (num2 >= this.horizontalCount)
			{
				num2 = 0;
				vector.x = position.x;
				vector.y -= this.offset.y;
				num3++;
				if (num3 >= this.usedRows)
				{
					vector = new Vector3(100000f, 0f, 0f);
				}
			}
		}
	}

	private void OnEnable()
	{
		this.ScreenWidth();
		this.isLeftEnabled = (this.isRightEnabled = true);
		this.EnableScrollButtonLeft(false);
		this.EnableScrollButtonRight(false);
		this.SetBorderStates();
	}

	public GameObject leftButton;

	public GameObject rightButton;

	public GameObject scrollButtonOffset;

	public GameObject buttonPrefab;

	public int horizontalCount = 10;

	public Vector2 offset = new Vector2(10f, 10f);

	public int count = 20;

	public int maxRows = 1;

	public bool fillScreenWidth = true;

	public float leftMargin;

	public float rightMargin;

	public WidgetListener m_listener;

	private List<GameObject> buttons = new List<GameObject>();

	private bool dragging;

	private bool dragDirectionDetected;

	private bool dragLocked;

	private Vector3 dragStart;

	private float scrollOffsetAtDragStart;

	private float scrollOffset;

	private float scrollTargetOffset;

	private float scrollTargetStart;

	private bool scrollTargetSet;

	private float scrollTargetSetTime;

	private float scrollVelocity;

	private Queue<ScrollInfo> scrollHistory = new Queue<ScrollInfo>();

	private bool canScroll = true;

	private float scrollButtonWidth;

	private float scrollAreaWidth;

	private bool onLeftBorder;

	private bool onRightBorder;

	private bool updatePlacement;

	private int usedRows = 1;

	private float buttonScale = 1f;

	private float screenWidth = -1f;

	private bool isLeftEnabled;

	private bool isRightEnabled;

	private enum Action
	{
		Place,
		DrawGizmos
	}

	private struct ScrollInfo
	{
		public ScrollInfo(float time, float offset)
		{
			this.time = time;
			this.offset = offset;
		}

		public float time;

		public float offset;
	}
}
