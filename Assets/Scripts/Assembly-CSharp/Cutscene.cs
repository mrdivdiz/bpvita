using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
	public void Awake()
	{
		this.m_scrolling = true;
		float y = this.m_comic.GetComponent<UnmanagedSprite>().Size.y;
		this.m_position = new Vector3(0f, -10f - 0.5f * y + 3f);
		this.m_continueButtonHeight = this.m_continueButton.GetComponent<Sprite>().Size.y;
	}

	private void Update()
	{
		float num = (float)Screen.width / (float)Screen.height / 1.33333337f;
		this.m_comic.transform.localScale = new Vector3(num, num, num);
		float y = this.m_comic.GetComponent<UnmanagedSprite>().Size.y;
		float num2 = 0.5f * y - 10f + 1.3f * num * this.m_continueButtonHeight;
		float a = 10f - 0.5f * y;
		Camera component = GameObject.FindGameObjectWithTag("HUDCamera").GetComponent<Camera>();
		GuiManager.Pointer pointer = GuiManager.GetPointer();
		if (pointer.up)
		{
			this.m_scrolling = true;
		}
		if (pointer.down)
		{
			this.m_scrolling = false;
			this.m_dragStartPosition = component.ScreenToWorldPoint(pointer.position);
		}
		else if (pointer.dragging)
		{
			Vector3 vector = component.ScreenToWorldPoint(pointer.position);
			Vector3 newDelta = vector - this.m_dragStartPosition;
			this.CalculateScrollVelocity(newDelta);
			this.m_dragStartPosition = vector;
			float min = Mathf.Min(a, this.m_position.y);
			this.m_position.y = this.m_position.y + newDelta.y;
			this.m_position.y = Mathf.Clamp(this.m_position.y, min, num2);
		}
		else if (Input.GetAxis("Mouse ScrollWheel") != 0f)
		{
			float min2 = Mathf.Min(a, this.m_position.y);
			this.m_position.y = this.m_position.y + -10f * Input.GetAxis("Mouse ScrollWheel") * 2f;
			this.m_position.y = Mathf.Clamp(this.m_position.y, min2, num2);
		}
		else if (this.m_scrollVelocity.magnitude > 0.01f)
		{
			Vector3 vector2 = Time.deltaTime * this.m_scrollVelocity;
			this.m_scrollVelocity *= Mathf.Pow(0.925f, Time.deltaTime / 0.0166666675f);
			float min3 = Mathf.Min(a, this.m_position.y);
			this.m_position.y = this.m_position.y + vector2.y;
			this.m_position.y = Mathf.Clamp(this.m_position.y, min3, num2);
		}
		if (this.m_scrolling)
		{
			this.m_position.y = this.m_position.y + 2f * Time.deltaTime;
			this.m_position.y = Mathf.Min(this.m_position.y, num2);
		}
		this.m_comic.transform.position = this.m_position;
	}

	public void Continue()
	{
        Type cutsceneType = this.m_cutsceneType;
		if (cutsceneType != Cutscene.Type.EpisodeStart)
		{
			if (cutsceneType == Cutscene.Type.EpisodeEnd)
			{
				Singleton<GameManager>.Instance.LoadEpisodeSelection(false);
			}
		}
		else if (GameProgress.GetInt(Singleton<GameManager>.Instance.CurrentSceneName + "_played", 0, GameProgress.Location.Local, null) == 1)
		{
			Singleton<GameManager>.Instance.LoadLevelSelection(Singleton<GameManager>.Instance.CurrentEpisode, false);
		}
		else
		{
			Singleton<GameManager>.Instance.LoadLevel(0);
		}
		GameProgress.SetInt(Singleton<GameManager>.Instance.CurrentSceneName + "_played", 1, GameProgress.Location.Local);
	}

	private void CalculateScrollVelocity(Vector3 newDelta)
	{
		while (this.m_scrollHistory.Count > 0 && this.m_scrollHistory.Peek().time < Time.time - 0.1f)
		{
			this.m_scrollHistory.Dequeue();
		}
		this.m_scrollHistory.Enqueue(new ScrollData(Time.time, newDelta));
		Vector3 vector = Vector3.zero;
		float time = this.m_scrollHistory.Peek().time;
		float num = 0f;
		foreach (ScrollData scrollData in this.m_scrollHistory)
		{
			vector += scrollData.delta;
			num = scrollData.time - time;
		}
		if (num > 0f)
		{
			vector /= num;
		}
		this.m_scrollVelocity = vector;
	}

	[SerializeField]
	private Type m_cutsceneType;

	public GameObject m_continueButton;

	public GameObject m_comic;

	public float m_continueButtonDelay;

	private Vector3 m_position;

	private bool m_scrolling;

	private Vector3 m_dragStartPosition;

	private Queue<ScrollData> m_scrollHistory = new Queue<ScrollData>();

	private Vector3 m_scrollVelocity;

	private float m_continueButtonHeight;

	private const float WheelScrollSpeedAdjustment = 2f;

	public enum Type
	{
		EpisodeStart,
		EpisodeEnd
	}

	private class ScrollData
	{
		public ScrollData(float time, Vector3 delta)
		{
			this.time = time;
			this.delta = delta;
		}

		public float time;

		public Vector3 delta;
	}
}
