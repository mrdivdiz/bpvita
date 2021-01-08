using UnityEngine;

public class GoalBox : Goal
{
	public GameObject GoalAchivement
	{
		set
		{
			this.m_goalAchievement = value;
		}
	}

	public bool Collected
	{
		get
		{
			return this.collected;
		}
	}

	public bool Disabled
	{
		get
		{
			return this.disabled;
		}
	}

	protected override void Start()
	{
		base.Start();
		this.m_flagVisualization = this.m_flagObject.GetComponent<Renderer>().material;
		if (this.m_goalAchievement)
		{
			this.origGoalPosition = this.m_goalAchievement.transform.position;
		}
		this.m_pls = base.GetComponent<PointLightSource>();
	}

	protected void Update()
	{
		this.m_flagVisualization.mainTextureOffset -= Vector2.up * Time.deltaTime * 0.25f;
		if (this.m_flagVisualization.mainTextureOffset.y < -1f)
		{
			this.m_flagVisualization.mainTextureOffset = new Vector2(this.m_flagVisualization.mainTextureOffset.x, this.m_flagVisualization.mainTextureOffset.y + 1f);
		}
		if (this.m_goalAchievement)
		{
			this.m_goalAchievement.transform.position = this.origGoalPosition + Vector3.up * Mathf.Sin(Time.time * 3f) * 0.25f;
		}
	}

	protected void DisableGoal()
	{
		this.disabled = true;
		base.GetComponent<Collider>().enabled = false;
		if (this.m_pls != null)
		{
			this.m_pls.isEnabled = false;
		}
	}

	protected void HideChildren(Transform parent)
	{
		for (int i = 0; i < parent.childCount; i++)
		{
			Transform child = parent.GetChild(i);
			if (child.GetComponent<Renderer>())
			{
				child.GetComponent<Renderer>().enabled = false;
			}
			child.gameObject.SetActive(false);
			this.HideChildren(child);
		}
	}

	protected override void OnGoalEnter(BasePart part)
	{
		if (this.collected)
		{
			return;
		}
		WPFMonoBehaviour.levelManager.NotifyGoalReachedByPart(part.m_partType);
		if (WPFMonoBehaviour.levelManager.PlayerHasRequiredObjects())
		{
			this.m_flagObject.GetComponent<Animation>().Play();
			if (this.m_goalAchievement)
			{
				this.m_goalAchievement.GetComponent<Animation>().Play();
			}
			if (this.m_goalParticles != null)
			{
				this.m_goalParticles.Stop();
			}
			WPFMonoBehaviour.levelManager.NotifyGoalReached();
			this.collected = true;
			EventManager.Send(default(ObjectiveAchieved));
			this.DisableGoal();
		}
	}

	protected override void OnReset()
	{
	}

	protected bool collected;

	protected bool disabled;

	protected Material m_flagVisualization;

	[SerializeField]
	protected GameObject m_flagObject;

	[SerializeField]
	protected GameObject m_goalAchievement;

	[SerializeField]
	protected ParticleSystem m_goalParticles;

	protected Vector3 origGoalPosition;

	protected PointLightSource m_pls;
}
