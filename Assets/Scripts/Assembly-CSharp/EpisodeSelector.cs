using System.Collections.Generic;
using UnityEngine;

public class EpisodeSelector : MonoBehaviour
{
	public int CurrentPage
	{
		get
		{
			return Mathf.Clamp(Mathf.RoundToInt(this.m_scrollPivot.transform.localPosition.x / -this.m_hudCamera.ScreenToWorldPoint(new Vector3((float)Screen.width, 0f, 0f)).x), 0, this.m_pageCount);
		}
	}

	public List<GameObject> Episodes
	{
		get
		{
			return this.m_episodes;
		}
	}

	private void Awake()
	{
		Singleton<GameManager>.Instance.CreateMenuBackground();
		this.m_hudCamera = GameObject.FindGameObjectWithTag("HUDCamera").GetComponent<Camera>();
		this.m_scrollPivot = base.transform.Find("ScrollPivot").gameObject;
		for (int i = 0; i < this.m_episodes.Count; i++)
		{
			this.m_episodes[i] = UnityEngine.Object.Instantiate<GameObject>(this.m_episodes[i]);
			this.m_episodes[i].transform.parent = this.m_scrollPivot.transform;
		}
		this.m_screenWidth = Screen.width;
		this.m_screenHeight = Screen.height;
		this.Layout();
		if (this.m_pageCount > 1)
		{
			this.CreatePageDots();
		}
		this.SetPage(UserSettings.GetInt(Singleton<GameManager>.Instance.CurrentSceneName + "_active_page", 0));
	}

	private void Start()
	{
		if (GameProgress.GetBool("show_content_limit_popup", false, GameProgress.Location.Local, null))
		{
			GameProgress.DeleteKey("show_content_limit_popup", GameProgress.Location.Local);
			LevelInfo.DisplayContentLimitNotification();
		}
	}

	private void SetPage(int page)
	{
		this.m_page = Mathf.Clamp(page, 0, this.m_pageCount - 1);
		Vector3 position = new Vector3(-this.m_hudCamera.ScreenToWorldPoint(new Vector3((float)(Screen.width / 2 + Screen.width * this.m_page), 0f, 0f)).x, this.m_scrollPivot.transform.localPosition.y, this.m_scrollPivot.transform.localPosition.z);
		this.m_scrollPivot.transform.position = position;
		for (int i = 0; i < this.m_dotsList.Count; i++)
		{
			if (i == this.m_page)
			{
				this.m_dotsList[i].Enable();
			}
			else
			{
				this.m_dotsList[i].Disable();
			}
		}
	}

	public void NextPage()
	{
		this.m_page = Mathf.Clamp(this.m_page + 1, 0, this.m_pageCount - 1);
		for (int i = 0; i < this.m_dotsList.Count; i++)
		{
			if (i == this.m_page)
			{
				this.m_dotsList[i].Enable();
			}
			else
			{
				this.m_dotsList[i].Disable();
			}
		}
	}

	public void PreviousPage()
	{
		this.m_page = Mathf.Clamp(this.m_page - 1, 0, this.m_pageCount - 1);
		for (int i = 0; i < this.m_dotsList.Count; i++)
		{
			if (i == this.m_page)
			{
				this.m_dotsList[i].Enable();
			}
			else
			{
				this.m_dotsList[i].Disable();
			}
		}
	}

	private void OnEnable()
	{
		KeyListener.keyReleased += this.HandleKeyListenerkeyReleased;
		KeyListener.mouseWheel += this.HandleKeyListenerMouseWheel;
		this.SetPage(UserSettings.GetInt(Singleton<GameManager>.Instance.CurrentSceneName + "_active_page", 0));
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
			this.SetPage(0);
			this.Layout();
			Transform transform = base.transform.Find("PageDots");
			int num = 0;
			if (transform != null)
			{
				num = transform.childCount;
			}
			if ((this.m_pageCount > 1 && transform == null) || num <= 1)
			{
				this.CreatePageDots();
			}
			else if (this.m_pageCount <= 1 && num >= 1)
			{
				transform.gameObject.SetActive(false);
			}
			else if (this.m_pageCount > 1 && num >= 1)
			{
				for (int i = 0; i < this.m_dotsList.Count; i++)
				{
					if (i == this.m_page)
					{
						this.m_dotsList[i].Enable();
					}
					else
					{
						this.m_dotsList[i].Disable();
					}
				}
			}
		}
		if (this.m_pageCount <= 1)
		{
			return;
		}
		if (!this.m_interacting)
		{
			Vector3 a = new Vector3(-this.m_hudCamera.ScreenToWorldPoint(new Vector3((float)(Screen.width / 2 + Screen.width * this.m_page), 0f, 0f)).x, this.m_scrollPivot.transform.localPosition.y, this.m_scrollPivot.transform.localPosition.z);
			this.m_scrollPivot.transform.position += (a - this.m_scrollPivot.transform.position) * Time.deltaTime * 4f;
			float magnitude = (a - this.m_scrollPivot.transform.position).magnitude;
			if (magnitude < 1f)
			{
				if (UserSettings.GetInt(Singleton<GameManager>.Instance.CurrentSceneName + "_active_page", -1) != this.m_page)
				{
					UserSettings.SetInt(Singleton<GameManager>.Instance.CurrentSceneName + "_active_page", this.m_page);
				}
				if (!DeviceInfo.UsesTouchInput)
				{
					this.m_rightScroll.SetActive(true);
					this.m_leftScroll.SetActive(true);
				}
			}
			else if (!DeviceInfo.UsesTouchInput)
			{
				this.m_rightScroll.SetActive(false);
				this.m_leftScroll.SetActive(false);
			}
			if (!DeviceInfo.UsesTouchInput)
			{
				if (this.CurrentPage == 0)
				{
					this.m_leftScroll.SetActive(false);
				}
				if (this.CurrentPage == this.m_pageCount || this.m_pageCount == 1)
				{
					this.m_rightScroll.SetActive(false);
				}
			}
		}
		GuiManager.Pointer pointer = GuiManager.GetPointer();
		if (pointer.down && pointer.widget != this.m_leftScroll.GetComponent<Widget>() && pointer.widget != this.m_rightScroll.GetComponent<Widget>())
		{
			this.m_initialInputPos = pointer.position;
			this.m_lastInputPos = pointer.position;
			this.m_interacting = true;
		}
		if (pointer.dragging && this.m_interacting)
		{
			Vector3 vector = this.m_hudCamera.ScreenToWorldPoint(this.m_lastInputPos);
			Vector3 vector2 = this.m_hudCamera.ScreenToWorldPoint(pointer.position);
			this.m_lastInputPos = pointer.position;
			float num2 = vector2.x - vector.x;
			this.m_scrollPivot.transform.localPosition = new Vector3(Mathf.Clamp(this.m_scrollPivot.transform.localPosition.x + num2, this.m_rightDragLimit, this.m_leftDragLimit), this.m_scrollPivot.transform.localPosition.y, this.m_scrollPivot.transform.localPosition.z);
			Vector3 vector3 = this.m_hudCamera.ScreenToWorldPoint(this.m_initialInputPos);
			if (!DeviceInfo.UsesTouchInput && Mathf.Abs(vector2.x - vector3.x) > 0.2f)
			{
				this.m_rightScroll.SetActive(false);
				this.m_leftScroll.SetActive(false);
			}
			if (Mathf.Abs(vector2.x - vector3.x) > 1f)
			{
				Singleton<GuiManager>.Instance.ResetFocus();
			}
		}
		if (pointer.up && this.m_interacting)
		{
			float num3 = this.m_lastInputPos.x - this.m_initialInputPos.x;
			if (num3 < (float)(-(float)Screen.width / 16))
			{
				this.m_page++;
				this.m_page = Mathf.Clamp(this.m_page, 0, this.m_pageCount - 1);
				for (int j = 0; j < this.m_dotsList.Count; j++)
				{
					if (j == this.m_page)
					{
						this.m_dotsList[j].Enable();
					}
					else
					{
						this.m_dotsList[j].Disable();
					}
				}
			}
			else if (num3 > (float)(Screen.width / 16))
			{
				this.m_page--;
				this.m_page = Mathf.Clamp(this.m_page, 0, this.m_pageCount - 1);
				for (int k = 0; k < this.m_dotsList.Count; k++)
				{
					if (k == this.m_page)
					{
						this.m_dotsList[k].Enable();
					}
					else
					{
						this.m_dotsList[k].Disable();
					}
				}
			}
			this.m_page = Mathf.Clamp(this.m_page, 0, this.m_pageCount - 1);
			this.m_interacting = false;
		}
	}

	private void Layout()
	{
		float num = 2f * this.m_hudCamera.orthographicSize * (float)Screen.width / (float)Screen.height;
		int count = this.m_episodes.Count;
		Vector2 size = this.m_episodes[0].GetComponent<Sprite>().Size;
		float num2 = this.EdgeMargin + size.x / 2f + this.m_scrollButtonMargin;
		float y = 1f;
		Vector3 vector = new Vector3(-num / 2f + num2, y);
		float num3 = num - 2f * num2;
		float num4 = num3 / (float)(count - 1);
		if (num4 < this.MinGap)
		{
			this.MinGap = 6.5f;
			this.EdgeMargin = 2f;
			num2 = this.EdgeMargin + size.x / 2f + this.m_scrollButtonMargin;
			y = 1f;
			vector = new Vector3(-num / 2f + num2, y);
			num3 = num - 2f * num2;
			this.m_episodesPerPage = (int)(num3 / this.MinGap) + 1;
			if (this.m_episodesPerPage < count && this.gameData != null && this.m_episodesPerPage > this.gameData.m_episodeLevels.Count)
			{
				this.m_episodesPerPage = this.gameData.m_episodeLevels.Count;
			}
			vector.x = -((float)(this.m_episodesPerPage - 1) * this.MinGap) / 2f;
			num4 = this.MinGap;
			this.m_pageCount = this.m_episodes.Count / this.m_episodesPerPage + ((this.m_episodes.Count % this.m_episodesPerPage != 0) ? 1 : 0);
		}
		else if (num4 > this.MaxGap)
		{
			this.m_pageCount = 1;
			vector.x += (num4 - this.MaxGap) * (float)(count - 1) / 2f;
			num4 = this.MaxGap;
		}
		if (this.m_pageCount == 1)
		{
			for (int i = 0; i < count; i++)
			{
				this.m_episodes[i].transform.position = vector + Vector3.right * num4 * (float)i;
			}
		}
		else
		{
			Vector3 a = vector;
			int j = 0;
			int num5 = 0;
			while (j < count)
			{
				int num6 = this.m_episodesPerPage;
				if (num6 > count - j)
				{
					num6 = count - j;
				}
				a.x = -((float)(num6 - 1) * this.MinGap) / 2f;
				vector = a + (float)num5 * num * Vector3.right;
				for (int k = 0; k < num6; k++)
				{
					this.m_episodes[j].transform.position = vector + Vector3.right * num4 * (float)k;
					j++;
					if (j >= count)
					{
						break;
					}
				}
				num5++;
			}
		}
		this.m_rightDragLimit = -this.m_hudCamera.ScreenToWorldPoint(new Vector3((float)(Screen.width * this.m_pageCount) - this.EdgeMargin, 0f, 0f)).x;
		this.m_leftDragLimit = -this.m_hudCamera.ScreenToWorldPoint(new Vector3(this.EdgeMargin, 0f, 0f)).x;
		if (DeviceInfo.UsesTouchInput || this.m_pageCount <= 1)
		{
			this.m_leftScroll.SetActive(false);
			this.m_rightScroll.SetActive(false);
		}
	}

	private void CreatePageDots()
	{
		Vector3 position = -Vector3.up * this.m_hudCamera.orthographicSize / 1.25f;
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(new GameObject(), position, Quaternion.identity);
		gameObject.name = "PageDots";
		gameObject.transform.parent = base.transform;
		float num = -(float)this.m_pageCount / 2f * 1.2f;
		for (int i = 0; i < this.m_pageCount; i++)
		{
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.m_pageDot);
			gameObject2.transform.parent = gameObject.transform;
			gameObject2.transform.localPosition = new Vector3(num + (float)i * 1.2f, 0f, -95f);
			gameObject2.name = "Dot" + i + 1;
			PageDot component = gameObject2.GetComponent<PageDot>();
			this.m_dotsList.Add(component);
			if (i == this.m_page)
			{
				this.m_dotsList[i].Enable();
			}
			else
			{
				this.m_dotsList[i].Disable();
			}
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
		else if (DeviceInfo.ActiveDeviceFamily != DeviceInfo.DeviceFamily.Android && obj == KeyCode.RightArrow && this.m_rightScroll.activeInHierarchy)
		{
			this.NextPage();
		}
		else if (DeviceInfo.ActiveDeviceFamily != DeviceInfo.DeviceFamily.Android && obj == KeyCode.LeftArrow && this.m_leftScroll.activeInHierarchy)
		{
			this.PreviousPage();
		}
	}

	private void HandleKeyListenerMouseWheel(float delta)
	{
		if (delta < 0f && this.m_rightScroll.activeInHierarchy && !this.m_interacting)
		{
			this.NextPage();
		}
		else if (delta > 0f && this.m_leftScroll.activeInHierarchy && !this.m_interacting)
		{
			this.PreviousPage();
		}
	}

	public void SendExitEpisodeSelectionFlurryEvent()
	{
	}

	[SerializeField]
	private GameData gameData;

	[SerializeField]
	private List<GameObject> m_episodes = new List<GameObject>();

	[SerializeField]
	private float MinGap = 6f;

	[SerializeField]
	private float MaxGap = 6f;

	[SerializeField]
	private float EdgeMargin = 0.65f;

	[SerializeField]
	private GameObject m_pageDot;

	[SerializeField]
	private GameObject m_leftScroll;

	[SerializeField]
	private GameObject m_rightScroll;

	[SerializeField]
	private float m_scrollButtonMargin = 0.5f;

	private int m_screenWidth;

	private int m_screenHeight;

	private Camera m_hudCamera;

	private int m_episodesPerPage;

	private int m_pageCount;

	private int m_page;

	private List<PageDot> m_dotsList = new List<PageDot>();

	private bool m_interacting;

	private Vector2 m_initialInputPos;

	private Vector2 m_lastInputPos;

	private float m_leftDragLimit;

	private float m_rightDragLimit;

	private GameObject m_scrollPivot;
}
