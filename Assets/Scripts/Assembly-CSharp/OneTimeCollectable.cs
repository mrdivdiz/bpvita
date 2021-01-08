using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class OneTimeCollectable : WPFMonoBehaviour
{
	public bool Disabled
	{
		get
		{
			return this.disabled;
		}
	}

	public Vector3 StartPosition
	{
		get
		{
			return this.startPosition;
		}
	}

	public string NameKey
	{
		get
		{
			if (string.IsNullOrEmpty(this.cachedNameKey))
			{
				this.cachedNameKey = this.GetNameKey();
			}
			return this.cachedNameKey;
		}
	}

	protected virtual void Start()
	{
		this.startPosition = base.transform.position;
		this.startPositionInited = true;
		this.isDynamic = (base.GetComponent<LevelRigidbody>() != null);
		this.isBox = (this is PartBox || this is StarBox);
		if (this.isBox)
		{
			this.CheckIfGhost();
		}
		this.components = base.GetComponents<Component>();
		EventManager.Connect<UIEvent>(new EventManager.OnEvent<UIEvent>(this.OnUIEvent));
		EventManager.Connect<GameStateChanged>(new EventManager.OnEvent<GameStateChanged>(this.OnGameStateChanged));
	}

	protected virtual void OnDestroy()
	{
		EventManager.Disconnect<UIEvent>(new EventManager.OnEvent<UIEvent>(this.OnUIEvent));
		EventManager.Disconnect<GameStateChanged>(new EventManager.OnEvent<GameStateChanged>(this.OnGameStateChanged));
	}

	public void ResetToStartPosition()
	{
		if (this.startPositionInited && !this.collected)
		{
			base.transform.position = this.startPosition;
		}
	}

	private void OnTriggerEnter(Collider col)
	{
		if (this.disabled || WPFMonoBehaviour.levelManager.gameState == LevelManager.GameState.Completed)
		{
			return;
		}
		BasePart basePart = this.FindPart(col);
		if (basePart && WPFMonoBehaviour.levelManager && WPFMonoBehaviour.levelManager.ContraptionRunning)
		{
			WPFMonoBehaviour.levelManager.ContraptionRunning.FinishConnectedComponentSearch();
			BasePart basePart2 = WPFMonoBehaviour.levelManager.ContraptionRunning.FindPig();
			if (WPFMonoBehaviour.levelManager.ContraptionRunning.IsConnectedToPig(basePart, col))
			{
				this.Collect();
			}
			else if (basePart.m_partType == BasePart.PartType.GoldenPig)
			{
				this.Collect();
			}
			else
			{
				List<BasePart> parts = WPFMonoBehaviour.levelManager.ContraptionRunning.Parts;
				for (int i = 0; i < parts.Count; i++)
				{
					BasePart basePart3 = parts[i];
					if (basePart3 != null && basePart3.ConnectedComponent == basePart.ConnectedComponent && Vector3.Distance(basePart3.transform.position, basePart2.transform.position) < 2.5f)
					{
						this.Collect();
						break;
					}
				}
			}
		}
	}

	private BasePart FindPart(Collider collider)
	{
		Transform transform = collider.transform;
		while (transform != null)
		{
			BasePart component = transform.GetComponent<BasePart>();
			if (component)
			{
				return component;
			}
			transform = transform.parent;
		}
		return null;
	}

	protected virtual void DisableGoal(bool disable = true)
	{
		this.HideChildren(base.transform, disable);
		this.disabled = disable;
		this.collected = disable;
		for (int i = 0; i < this.components.Length; i++)
		{
			if (this.components[i] is MonoBehaviour)
			{
				(this.components[i] as MonoBehaviour).enabled = !disable;
			}
			else if (this.components[i] is Renderer)
			{
				(this.components[i] as Renderer).enabled = !disable;
			}
			else if (this.components[i] is Collider)
			{
				(this.components[i] as Collider).enabled = !disable;
			}
			else if (this.components[i] is Rigidbody)
			{
				UnityEngine.Debug.LogWarning("DisableGoal for " + base.transform.name + ", isKinematic will be " + (!this.isDynamic || disable).ToString());
				(this.components[i] as Rigidbody).isKinematic = (!this.isDynamic || disable);
				(this.components[i] as Rigidbody).detectCollisions = !disable;
			}
		}
	}

	public virtual bool IsDisabled()
	{
		return this.disabled;
	}

	private void HideChildren(Transform parent, bool hide = true)
	{
		for (int i = 0; i < parent.childCount; i++)
		{
			Transform child = parent.GetChild(i);
			Renderer component = child.GetComponent<Renderer>();
			if (component != null)
			{
				component.enabled = !hide;
			}
			child.gameObject.SetActive(!hide);
			this.HideChildren(child, hide);
		}
	}

	public virtual void Collect()
	{
		if (this.collected)
		{
			return;
		}
		if (this.collectedEffect)
		{
			UnityEngine.Object.Instantiate<ParticleSystem>(this.collectedEffect, base.transform.position, base.transform.rotation);
		}
		AudioManager instance = Singleton<AudioManager>.Instance;
		instance.Play2dEffect(WPFMonoBehaviour.gameData.commonAudioCollection.bonusBoxCollected);
		this.collected = true;
		this.DisableGoal(true);
		EventManager.Send<ObjectiveAchieved>(default(ObjectiveAchieved));
		this.OnCollected();
	}

	public virtual void OnCollected()
	{
	}

	protected virtual void OnUIEvent(UIEvent data)
	{
		if (!this.isBox)
		{
			return;
		}
		if (this.disabled && data.type == UIEvent.Type.Building)
		{
			this.CheckIfGhost();
			if (base.rigidbody != null)
			{
				base.rigidbody.isKinematic = true;
			}
		}
		if (!this.disabled && this.isDynamic && data.type == UIEvent.Type.Play)
		{
			base.rigidbody.isKinematic = false;
		}
	}

	protected virtual void OnGameStateChanged(GameStateChanged data)
	{
		if (data.state == LevelManager.GameState.Building)
		{
			this.ResetToStartPosition();
		}
	}

	private void CheckIfGhost()
	{
		if (this is StarBox || this is PartBox)
		{
			if (!string.IsNullOrEmpty(this.NameKey))
			{
				this.isGhost = GameProgress.HasSandboxStar(Singleton<GameManager>.Instance.CurrentSceneName, this.NameKey);
			}
			if (this.isGhost && this is StarBox)
			{
				this.MakeGhostBox();
			}
			else if (this.isGhost && this is PartBox)
			{
				this.MakeGhostBox();
			}
			return;
		}
	}

	private void MakeGhostBox()
	{
		MeshRenderer component = base.GetComponent<MeshRenderer>();
		if (component == null)
		{
			return;
		}
		int index = (!component.sharedMaterial.name.StartsWith("IngameAtlas2")) ? 0 : 1;
		component.sharedMaterial = AtlasMaterials.Instance.DimmedRenderQueueMaterials[index];
		Transform transform = base.transform.Find("Glow");
		if (transform != null)
		{
			transform.gameObject.SetActive(false);
		}
		if (this.disabled)
		{
			this.DisableGoal(false);
		}
	}

	protected void ShowXPParticles()
	{
		if (this.xpParticles)
		{
			UnityEngine.Object.Instantiate<GameObject>(this.xpParticles, base.transform.position, base.transform.rotation);
		}
	}

	protected abstract string GetNameKey();

	[SerializeField]
	protected ParticleSystem collectedEffect;

	[SerializeField]
	private GameObject xpParticles;

	public bool collected;

	private Vector3 startPosition = Vector3.zero;

	private bool startPositionInited;

	protected bool disabled;

	protected bool isDynamic;

	protected bool isBox;

	protected bool isGhost;

	protected Component[] components;

	private string cachedNameKey = string.Empty;
}
