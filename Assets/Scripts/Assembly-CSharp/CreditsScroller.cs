using System.Collections.Generic;
using UnityEngine;

public class CreditsScroller : MonoBehaviour
{
	public void InstantiateCredits()
	{
		float y = 0f;
		List<CreditsCluster> list = new List<CreditsCluster>(base.GetComponentsInChildren<CreditsCluster>());
		list.Sort((CreditsCluster c1, CreditsCluster c2) => c1.gameObject.name.CompareTo(c2.gameObject.name));
		foreach (CreditsCluster creditsCluster in list.ToArray())
		{
			y = creditsCluster.CreateCreditsCluster(new Vector3(0f, y, 0f)) + -2f;
		}
	}

	public void CleanCredits()
	{
		foreach (CreditsCluster creditsCluster in base.GetComponentsInChildren<CreditsCluster>())
		{
			TextMesh[] componentsInChildren2 = creditsCluster.GetComponentsInChildren<TextMesh>();
			foreach (TextMesh textMesh in componentsInChildren2)
			{
				UnityEngine.Object.DestroyImmediate(textMesh.gameObject);
			}
		}
	}

	private void Start()
	{
		if (this.m_disableScrolling)
		{
			return;
		}
		base.transform.position = new Vector3(base.transform.position.x, 25f, base.transform.position.z);
		this.m_position = base.transform.position;
		Transform[] componentsInChildren = base.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren)
		{
			if (-transform.localPosition.y > this.wrapLimitUp)
			{
				this.wrapLimitUp = -transform.localPosition.y;
			}
		}
		this.wrapLimitUp += 12f;
	}

	private void Awake()
	{
		GameObject.Find("PigJumping").GetComponent<Animation>().Play("PigLevelCompleteAnimation");
		GameObject.Find("PigJumping").GetComponent<Animation>().wrapMode = WrapMode.Loop;
		GameObject.Find("Pig_Shadow").GetComponent<Animation>().Play("LevelCompleteShadowAnimation");
		GameObject.Find("Pig_Shadow").GetComponent<Animation>().wrapMode = WrapMode.Loop;
		string text = string.Format("Version {0} - {1}", Singleton<BuildCustomizationLoader>.Instance.ApplicationVersion, Singleton<BuildCustomizationLoader>.Instance.SVNRevisionNumber);
		GameObject.Find("VersionID").GetComponent<TextMesh>().text = text;
		GameObject.Find("VersionIDShadow").GetComponent<TextMesh>().text = text;
	}

	private void OnEnable()
	{
		if (this.m_disableScrolling)
		{
			return;
		}
		this.m_scrolling = true;
		base.transform.position = (this.m_position = new Vector3(this.m_position.x, 25f, this.m_position.z));
	}

	private void OnDisable()
	{
		if (this.m_disableScrolling)
		{
			return;
		}
		base.transform.position = new Vector3(base.transform.position.x, this.wrapLimitUp, base.transform.position.z);
		this.m_position = base.transform.position;
	}

	private void Update()
	{
		if (this.m_disableScrolling)
		{
			return;
		}
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
		else if (pointer.dragging && !LootCrateOpenDialog.DialogOpen)
		{
			Vector3 vector = component.ScreenToWorldPoint(pointer.position);
			Vector3 newDelta = vector - this.m_dragStartPosition;
			this.CalculateScrollVelocity(newDelta);
			this.m_dragStartPosition = vector;
			this.m_position.y = this.m_position.y + newDelta.y;
		}
		else if (Input.GetAxis("Mouse ScrollWheel") != 0f)
		{
			this.m_position.y = this.m_position.y + -10f * Input.GetAxis("Mouse ScrollWheel");
		}
		else if (this.m_scrollVelocity.magnitude > 0.01f)
		{
			Vector3 vector2 = Time.deltaTime * this.m_scrollVelocity;
			this.m_scrollVelocity *= Mathf.Pow(0.925f, Time.deltaTime / 0.0166666675f);
			this.m_position.y = this.m_position.y + vector2.y;
		}
		if (this.m_scrolling || LootCrateOpenDialog.DialogOpen)
		{
			this.m_position.y = this.m_position.y + 1.5f * Time.deltaTime;
		}
		if (this.m_position.y < 25f)
		{
			this.m_position = new Vector3(this.m_position.x, this.wrapLimitUp, this.m_position.z);
		}
		else if (this.m_position.y > this.wrapLimitUp)
		{
			this.m_position = new Vector3(this.m_position.x, 25f, this.m_position.z);
		}
		base.transform.position = this.m_position;
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

    public void LaunchEula()
    {
        URLManager.Instance.OpenURL(URLManager.LinkType.Eula);
    }

    public void LaunchPrivacyPolicy()
    {
        URLManager.Instance.OpenURL(URLManager.LinkType.Privacy);
    }

    public bool m_disableScrolling;

	private bool m_scrolling;

	private Vector3 m_dragStartPosition;

	private Queue<ScrollData> m_scrollHistory = new Queue<ScrollData>();

	private Vector3 m_scrollVelocity;

	private Vector3 m_position;

	private float wrapLimitUp = -1f;

	private const float clusterOffset = -2f;

	private const float WrapLimitDown = 25f;

	private const float AutoScrollSpeed = 1.5f;

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
