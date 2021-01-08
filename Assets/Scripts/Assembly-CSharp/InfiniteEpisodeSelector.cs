using System.Collections.Generic;
using UnityEngine;

public class InfiniteEpisodeSelector : MonoBehaviour
{
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
	}

	private void Start()
	{
		if (GameProgress.GetBool("show_content_limit_popup", false, GameProgress.Location.Local, null))
		{
			GameProgress.DeleteKey("show_content_limit_popup", GameProgress.Location.Local);
			LevelInfo.DisplayContentLimitNotification();
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
		this.ScaleEpisodes();
		GuiManager.Pointer pointer = GuiManager.GetPointer();
		if (pointer.down)
		{
			this.m_initialInputPos = pointer.position;
			this.m_lastInputPos = pointer.position;
			this.m_interacting = true;
		}
		if (pointer.dragging && this.m_interacting && this.m_movableEpisodes)
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
			if (Mathf.Abs(vector2.x - vector3.x) > 1f)
			{
				Singleton<GuiManager>.Instance.ResetFocus();
			}
		}
		if (pointer.up && this.m_interacting)
		{
			this.m_interacting = false;
			this.m_moveToCenter = true;
		}
		if (!this.m_interacting && this.m_movableEpisodes && this.m_momentumSlide > 0)
		{
			float num = Mathf.Abs(this.m_centerEpisode.transform.localPosition.x);
			float num2 = Mathf.Sign(this.m_centerEpisode.transform.localPosition.x);
			if (Mathf.Abs(this.m_deltaX) > 0.1f)
			{
				this.MoveEpisodes(this.m_deltaX, true);
				this.m_deltaX -= this.m_deltaX / (float)this.m_momentumSlide;
				this.m_moveToCenter = true;
				if (this.m_deltaX < 0.15f && (double)num < 0.2)
				{
					this.m_deltaX = 0f;
				}
			}
			else if (this.m_centerEpisode != null && this.m_moveToCenter)
			{
				if ((double)num > 0.2)
				{
					this.MoveEpisodes(-num2 * Time.deltaTime * this.CenteringSpeed, false);
				}
				else
				{
					this.m_moveToCenter = false;
				}
			}
		}
	}

	private void MoveEpisodes(float delta, bool checkCenter = true)
	{
		float num = this.m_rightLimit * 2f;
		float num2 = Mathf.Abs(base.transform.localPosition.x - this.m_centerEpisode.transform.localPosition.x);
		if ((this.m_centerEpisode == this.m_episodes[0] || this.m_centerEpisode == this.m_episodes[this.m_episodes.Count - 1]) && !this.isInfinite && num2 < 0.5f && this.m_deltaX > 0f)
		{
			this.m_deltaX = 0f;
			return;
		}
		for (int i = 0; i < this.m_episodes.Count; i++)
		{
			GameObject gameObject = this.m_episodes[i];
			if (this.isInfinite)
			{
				if (gameObject.transform.position.x > this.m_rightLimit)
				{
					gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x - num, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
				}
				else if (gameObject.transform.position.x < this.m_leftLimit)
				{
					gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + num, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
				}
			}
			gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + delta, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
			if (checkCenter)
			{
				float num3 = Mathf.Abs(gameObject.transform.localPosition.x);
				if (this.m_centerEpisode == null || num3 < Mathf.Abs(this.m_centerEpisode.transform.localPosition.x))
				{
					this.m_centerEpisode = gameObject;
				}
			}
		}
	}

	private void ScaleEpisodes()
	{
		for (int i = 0; i < this.m_episodes.Count; i++)
		{
			GameObject gameObject = this.m_episodes[i];
			float num = Mathf.Abs(gameObject.transform.localPosition.x) / this.ScaleFactor;
			if (num > 0f)
			{
				float num2 = Mathf.Clamp(1f / num, 0f, 1f);
				gameObject.GetComponent<Collider>().enabled = (num2 >= 1f);
				gameObject.transform.localScale = new Vector3(num2, num2, 1f);
			}
		}
	}

	private void Layout()
	{
		float num = 2f * this.m_hudCamera.orthographicSize * (float)Screen.width / (float)Screen.height;
		int count = this.m_episodes.Count;
		this.m_episodeSize = this.m_episodes[0].GetComponent<Sprite>().Size;
		float num2 = num - 2f * this.m_episodeSize.x;
		float num3 = num2 - this.m_episodeSize.x * 3f;
		this.Gap = num3 / 4f;
		for (int i = 0; i < count; i++)
		{
			this.m_episodes[i].transform.position = Vector3.right * (this.m_episodeSize.x + this.Gap) * (float)i;
		}
		this.m_centerEpisode = this.m_episodes[0];
		float num4 = (float)((count - 1) / 2 + 1) * (this.m_episodeSize.x + this.Gap);
		this.m_rightLimit = num4;
		this.m_leftLimit = -num4;
		this.MoveEpisodes(0f, true);
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

	public void SendExitEpisodeSelectionFlurryEvent()
	{
	}

	private void OnDrawGizmos()
	{
		if (this.m_centerEpisode != null)
		{
			Gizmos.color = Color.blue;
			Gizmos.DrawSphere(this.m_centerEpisode.transform.localPosition, 0.5f);
			Gizmos.color = Color.yellow;
			Gizmos.DrawSphere(base.transform.localPosition, 0.5f);
		}
		Gizmos.color = Color.green;
		Gizmos.DrawSphere(new Vector3(this.m_leftLimit, 0f), 0.5f);
		Gizmos.DrawSphere(new Vector3(this.m_rightLimit, 0f), 0.5f);
	}

	[SerializeField]
	private GameData gameData;

	[SerializeField]
	private List<GameObject> m_episodes = new List<GameObject>();

	[SerializeField]
	private float Gap = 6f;

	[SerializeField]
	private int m_momentumSlide = 10;

	[SerializeField]
	private float ScaleFactor = 20f;

	[SerializeField]
	private float CenteringSpeed = 10f;

	[SerializeField]
	private bool isInfinite = true;

	private int m_screenWidth;

	private int m_screenHeight;

	private Camera m_hudCamera;

	private bool m_interacting;

	private Vector2 m_initialInputPos;

	private Vector2 m_lastInputPos;

	private float m_leftLimit;

	private float m_rightLimit;

	private GameObject m_scrollPivot;

	private Vector2 m_episodeSize;

	private float m_deltaX;

	private bool m_moveToCenter;

	private bool m_movableEpisodes = true;

	private GameObject m_centerEpisode;
}
