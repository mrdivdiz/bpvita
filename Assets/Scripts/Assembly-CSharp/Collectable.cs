using UnityEngine;

public class Collectable : Goal
{
	public void OnDataLoaded()
	{
		this.originalPosition = base.transform.position;
		this.m_renderer = base.GetComponent<Renderer>();
		this.m_childRenderers = base.GetComponentsOnlyInChildren<Renderer>();
		this.m_collider = base.GetComponent<Collider>();
		this.m_childColliders = base.GetComponentsOnlyInChildren<Collider>();
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

	protected void DisableGoal(bool disable)
	{
		if (this.m_renderer != null)
		{
			this.m_renderer.enabled = !disable;
		}
		if (this.m_collider != null)
		{
			this.m_collider.enabled = !disable;
		}
		this.disabled = disable;
		this.HideChildren(disable);
		Rigidbody component = base.GetComponent<Rigidbody>();
		if (component)
		{
			component.isKinematic = disable;
		}
	}

	protected void HideChildren(bool hide)
	{
		for (int i = 0; i < this.m_childRenderers.Length; i++)
		{
			this.m_childRenderers[i].enabled = !hide;
		}
		for (int j = 0; j < this.m_childColliders.Length; j++)
		{
			this.m_childColliders[j].enabled = !hide;
		}
	}

	protected override void OnGoalEnter(BasePart part)
	{
		if (this.collected || WPFMonoBehaviour.levelManager.gameState == LevelManager.GameState.Completed)
		{
			return;
		}
		if (this.collectedEffect)
		{
			UnityEngine.Object.Instantiate<ParticleSystem>(this.collectedEffect, base.transform.position, this.collectedEffect.transform.rotation);
		}
		AudioManager instance = Singleton<AudioManager>.Instance;
		instance.SpawnOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.bonusBoxCollected, base.transform.position);
		this.collected = true;
		EventManager.Send(default(ObjectiveAchieved));
		this.DisableGoal(true);
	}

	protected override void OnReset()
	{
		this.collected = false;
		base.transform.position = this.originalPosition;
		this.DisableGoal(false);
	}

	[SerializeField]
	protected ParticleSystem collectedEffect;

	public bool collected;

	protected bool disabled;

	private Vector3 originalPosition;

	private Renderer m_renderer;

	private Renderer[] m_childRenderers;

	private Collider m_collider;

	private Collider[] m_childColliders;
}
