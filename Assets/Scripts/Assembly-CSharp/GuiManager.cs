using System.Collections.Generic;
using UnityEngine;

public class GuiManager : Singleton<GuiManager>
{
	public static int PointerCount
	{
		get
		{
			return Singleton<GuiManager>.instance.m_pointers.Count;
		}
	}

	public static int TouchCount
	{
		get
		{
			return Singleton<GuiManager>.instance.m_touchCount;
		}
	}

	public AudioSource DefaultButtonAudio
	{
		get
		{
			return this.m_defaultButtonAudio;
		}
		set
		{
			this.m_defaultButtonAudio = value;
		}
	}

	public static Pointer GetPointer()
	{
		if (GuiManager.pointerGrabCount > 0)
		{
			return new Pointer();
		}
		return Singleton<GuiManager>.instance.m_pointers[0];
	}

	public static Pointer GetPointer(int index)
	{
		if (GuiManager.pointerGrabCount > 0)
		{
			return new Pointer();
		}
		return Singleton<GuiManager>.instance.m_pointers[index];
	}

	public Camera FindCamera()
	{
		GameObject gameObject = GameObject.FindGameObjectWithTag("HUDCamera");
		if (gameObject)
		{
			return gameObject.GetComponent<Camera>();
		}
		return null;
	}

	public void GrabPointer(object obj)
	{
		GuiManager.pointerGrabCount++;
		this.m_pointerGrabList.Add(obj);
	}

	public void ReleasePointer(object obj)
	{
		GuiManager.pointerGrabCount--;
		this.m_pointerGrabList.Remove(obj);
	}

	public void ResetFocus()
	{
		foreach (FocusData focusData in this.m_focusData)
		{
			if (focusData.mouseOver != null)
			{
				focusData.mouseOver.SendInput(new InputEvent(InputEvent.EventType.MouseLeave, Input.mousePosition));
				focusData.mouseOver = null;
			}
			focusData.target = null;
			focusData.fingerId = -1;
			focusData.primary = false;
		}
	}

	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(this);
		Singleton<GuiManager>.instance = this;
		this.guiLayerMask = 1 << base.gameObject.layer;
		this.m_touchIds = new List<int>();
		this.m_focusData = new List<FocusData>();
		this.m_pointers = new List<Pointer>();
		for (int i = 0; i < 4; i++)
		{
			this.m_touchIds.Add(-1);
			this.m_focusData.Add(new FocusData());
			this.m_pointers.Add(new Pointer());
		}
		this.m_originalResolutionWidth = Screen.width;
		this.m_originalResolutionHeight = Screen.height;
		this.m_startedInFullScreen = Screen.fullScreen;
		if (DeviceInfo.ActiveDeviceFamily == DeviceInfo.DeviceFamily.Pc)
		{
			this.m_originalResolutionHeightDescktop = Screen.resolutions[Screen.resolutions.Length - 1].height;
			this.m_originalResolutionWidthDescktop = Screen.resolutions[Screen.resolutions.Length - 1].width;
		}
		else
		{
			this.m_originalResolutionHeightDescktop = Screen.currentResolution.height;
			this.m_originalResolutionWidthDescktop = Screen.currentResolution.width;
		}
	}

	public bool IsEnabled
	{
		get
		{
			return this.m_enabled;
		}
		set
		{
			this.m_enabled = value;
		}
	}

	private Widget RayCast(Vector2 screenPosition)
	{
		Widget widget = null;
		Camera camera = this.FindCamera();
		this.guiLayerMask = 1 << camera.gameObject.layer;
		Ray ray = camera.ScreenPointToRay(screenPosition);
		RaycastHit raycastHit;
		if (Physics.Raycast(ray, out raycastHit, 100f, this.guiLayerMask))
		{
			widget = raycastHit.collider.gameObject.GetComponent<Widget>();
		}
		if (widget != null && widget.transform.position.z > this.m_layerBottomZ)
		{
			widget = null;
		}
		return widget;
	}

	private void MouseInput()
	{
        FocusData focusData = this.m_focusData[0];
		focusData.primary = true;
		this.PointerInput(0, true, Input.GetMouseButtonDown(0), Input.GetMouseButtonUp(0), Input.GetMouseButton(0), Input.mousePosition, 0, focusData, this.m_pointers[0]);
		this.m_pointers[0].secondaryDown = Input.GetMouseButtonDown(1);
		this.m_pointers[0].secondaryUp = Input.GetMouseButtonUp(1);
		this.m_pointers[0].secondaryDragging = Input.GetMouseButton(1);
		if (Input.GetMouseButton(0) || Input.GetMouseButtonUp(0))
		{
			this.m_touchCount = 1;
		}
		else
		{
			this.m_touchCount = 0;
		}
	}

	private void TouchInput()
	{
		this.m_touchCount = 0;
		for (int i = 0; i < this.m_touchIds.Count; i++)
		{
			int num = this.FindTouch(i);
			if (num != -1)
			{
				Touch touch = Input.touches[num];
				this.m_touchIds[i] = touch.fingerId;
				bool flag = touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled;
                FocusData focusData = this.GetFocusData(touch.fingerId);
				if (i == 0)
				{
					focusData.primary = true;
				}
				this.PointerInput(i, true, touch.phase == TouchPhase.Began, flag, !flag, touch.position, touch.fingerId, focusData, this.m_pointers[i]);
				this.m_touchCount++;
			}
			else
			{
				this.m_touchIds[i] = -1;
				this.PointerInput(i, false, false, false, false, Vector3.zero, -1, null, this.m_pointers[i]);
			}
		}
	}

	private FocusData GetFocusData(int fingerId)
	{
		for (int i = 0; i < this.m_focusData.Count; i++)
		{
			if (this.m_focusData[i].fingerId == fingerId)
			{
				return this.m_focusData[i];
			}
		}
		for (int j = 0; j < this.m_focusData.Count; j++)
		{
			if (this.m_focusData[j].fingerId == -1)
			{
				this.m_focusData[j].fingerId = fingerId;
				return this.m_focusData[j];
			}
		}
		return new FocusData();
	}

	private int FindTouch(int touchIdIndex)
	{
		int result = -1;
		for (int i = 0; i < Input.touchCount; i++)
		{
			Touch touch = Input.touches[i];
			if (this.m_touchIds[touchIdIndex] == -1 || this.m_touchIds[touchIdIndex] == touch.fingerId)
			{
				bool flag = false;
				for (int j = 0; j < touchIdIndex; j++)
				{
					if (touch.fingerId == this.m_touchIds[j])
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					result = i;
					break;
				}
			}
		}
		return result;
	}

	private void Update()
	{
		if (!this.m_enabled)
		{
			return;
		}
		if (DeviceInfo.UsesTouchInput)
		{
			this.TouchInput();
		}
		else
		{
			this.MouseInput();
		}
		this.HandleDoubleClick();
		if (DeviceInfo.ActiveDeviceFamily != DeviceInfo.DeviceFamily.Pc)
		{
			return;
		}
		if (!Screen.fullScreen && (Screen.height != this.m_originalResolutionHeight || Screen.width != this.m_originalResolutionWidth))
		{
			Screen.SetResolution(this.m_originalResolutionWidth, this.m_originalResolutionHeight, false);
		}
		if (Screen.fullScreen && (Screen.height != this.m_originalResolutionHeightDescktop || Screen.width != this.m_originalResolutionWidthDescktop))
		{
			Screen.SetResolution(this.m_originalResolutionWidthDescktop, this.m_originalResolutionHeightDescktop, true);
		}
	}

	private void HandleDoubleClick()
	{
		if (this.m_touchCount == 1)
		{
            Pointer pointer = this.m_pointers[0];
			if (pointer.secondaryDragging)
			{
				this.m_doubleClickActive = false;
			}
			else if (!this.m_doubleClickActive)
			{
				if (pointer.up)
				{
					this.m_doubleClickActive = true;
					this.m_doubleClickStartTime = Time.time;
					this.m_doubleClickPosition = pointer.position;
				}
			}
			else if (pointer.up)
			{
				if (Time.time - this.m_doubleClickStartTime < 0.4f && (pointer.position - this.m_doubleClickPosition).sqrMagnitude < 10000f)
				{
					this.m_doubleClickActive = false;
					pointer.doubleClick = true;
				}
				else
				{
					this.m_doubleClickActive = true;
					this.m_doubleClickStartTime = Time.time;
					this.m_doubleClickPosition = pointer.position;
				}
			}
		}
		else if (this.m_touchCount > 1)
		{
			this.m_doubleClickActive = false;
		}
	}

	private void PointerInput(int pointerIndex, bool touching, bool pointerDown, bool pointerUp, bool dragging, Vector3 position, int fingerId, FocusData focus, Pointer pointer)
	{
		Widget widget = this.RayCast(position);
		pointer.touching = touching;
		pointer.down = pointerDown;
		pointer.up = pointerUp;
		pointer.dragging = dragging;
		pointer.position = position;
		pointer.fingerId = fingerId;
		pointer.onWidget = (widget != null);
		pointer.widget = widget;
		pointer.doubleClick = false;
		if (widget && pointerDown)
		{
			pointer.touchUsed = true;
		}
		else if (pointerUp || !touching)
		{
			pointer.touchUsed = false;
		}
		if (widget != null && focus != null && !focus.primary && !widget.AllowMultitouch())
		{
			widget = null;
		}
		if (pointerDown)
		{
			if (widget)
			{
				focus.target = widget;
				focus.target.SendInput(new InputEvent(InputEvent.EventType.Press, position));
			}
			else
			{
				focus.target = null;
			}
		}
		if (pointerUp)
		{
			if (widget && widget == focus.target)
			{
				widget.SendInput(new InputEvent(InputEvent.EventType.Release, position));
			}
			focus.target = null;
		}
		if (touching)
		{
			if (widget != null && focus.mouseOver != widget && (focus.target == null || focus.target == widget))
			{
				if (focus.mouseOver != null)
				{
					focus.mouseOver.SendInput(new InputEvent(InputEvent.EventType.MouseLeave, position));
				}
				focus.mouseOver = widget;
				widget.SendInput(new InputEvent(InputEvent.EventType.MouseEnter, position));
				if (widget == focus.target && !pointerDown)
				{
					widget.SendInput(new InputEvent(InputEvent.EventType.MouseReturn, position));
				}
			}
			if (focus.mouseOver != null && widget != focus.mouseOver)
			{
				focus.mouseOver.SendInput(new InputEvent(InputEvent.EventType.MouseLeave, position));
				focus.mouseOver = null;
			}
		}
		if (pointerUp)
		{
			if (focus.mouseOver != null)
			{
				focus.mouseOver.SendInput(new InputEvent(InputEvent.EventType.MouseLeave, Input.mousePosition));
			}
			focus.mouseOver = null;
			focus.target = null;
			focus.fingerId = -1;
			focus.primary = false;
		}
		if (focus != null && focus.target != null)
		{
			focus.target.SendInput(new InputEvent(InputEvent.EventType.Drag, position));
		}
	}

	private void OnEnable()
	{
		KeyListener.keyPressed += this.HandleKeyListenerkeyPressed;
		HUDLayer[] array = UnityEngine.Object.FindObjectsOfType<HUDLayer>();
	}

	private void OnDisable()
	{
		KeyListener.keyPressed -= this.HandleKeyListenerkeyPressed;
	}

	public void AddLayer(HUDLayer layer)
	{
		float topLayerZ = this.GetTopLayerZ();
		Vector3 position = layer.transform.position;
		position.z = topLayerZ;
		layer.transform.position = position;
		this.m_layerBottomZ = position.z + 1f;
		this.m_layers.Add(layer);
		this.UpdateCameraZ();
	}

	public void RemoveLayer(HUDLayer layer)
	{
		this.m_layers.Remove(layer);
		if (this.m_layers.Count > 0)
		{
			this.m_layerBottomZ = this.m_layers[this.m_layers.Count - 1].transform.position.z + 1f;
		}
		this.UpdateCameraZ();
	}

	private float GetTopLayerZ()
	{
		if (this.m_layers.Count > 0)
		{
			HUDLayer hudlayer = this.m_layers[this.m_layers.Count - 1];
			return hudlayer.transform.position.z - hudlayer.GetDepth() - 2f;
		}
		return 0f;
	}

	private void UpdateCameraZ()
	{
		float topLayerZ = this.GetTopLayerZ();
		Camera camera = this.FindCamera();
		if (camera)
		{
			Vector3 position = camera.transform.position;
			position.z = topLayerZ;
			camera.transform.position = position;
		}
	}

	private void HandleKeyListenerkeyPressed(KeyCode obj)
	{
		if (DeviceInfo.IsDesktop && obj == KeyCode.F)
		{
			this.SetFullscreen();
		}
	}

	public void SetFullscreen()
	{
		bool flag = !Screen.fullScreen;
		if (flag)
		{
			if (this.m_startedInFullScreen)
			{
				Screen.SetResolution(this.m_originalResolutionWidth, this.m_originalResolutionHeight, true);
			}
			else
			{
				Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
			}
		}
		else
		{
			Screen.SetResolution(this.m_originalResolutionWidth, this.m_originalResolutionHeight, false);
		}
	}

	private void OnApplicationFocus(bool focus)
	{
		if (Application.platform == RuntimePlatform.OSXPlayer && focus && Screen.fullScreen && (Screen.currentResolution.width != Screen.width || Screen.currentResolution.height != Screen.height))
		{
			Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
		}
	}

	[SerializeField]
	private Texture m_hackTex;

	[SerializeField]
	private AudioSource m_defaultButtonAudio;

	private int guiLayerMask = 1;

	private bool m_enabled = true;

	private List<int> m_touchIds;

	private List<FocusData> m_focusData;

	private List<Pointer> m_pointers;

	private int m_touchCount;

	private List<object> m_pointerGrabList = new List<object>();

	private static int pointerGrabCount;

	private bool m_doubleClickActive;

	private float m_doubleClickStartTime;

	private Vector3 m_doubleClickPosition;

	private List<HUDLayer> m_layers = new List<HUDLayer>();

	private float m_layerBottomZ;

	private int m_originalResolutionWidth;

	private int m_originalResolutionHeight;

	private int m_originalResolutionWidthDescktop;

	private int m_originalResolutionHeightDescktop;

	private bool m_startedInFullScreen;

	public class Pointer
	{
		public bool touching;

		public bool down;

		public bool up;

		public bool dragging;

		public bool secondaryDown;

		public bool secondaryUp;

		public bool secondaryDragging;

		public bool doubleClick;

		public bool onWidget;

		public bool touchUsed;

		public int fingerId;

		public Widget widget;

		public Vector3 position;
	}

	private class FocusData
	{
		public int fingerId = -1;

		public bool primary;

		public Widget target;

		public Widget mouseOver;
	}
}
