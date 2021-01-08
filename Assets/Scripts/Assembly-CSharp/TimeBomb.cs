using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBomb : BasePart
{
	public override bool CanBeEnclosed()
	{
		return true;
	}

	public override bool ValidatePart()
	{
		return true;
	}

	public override void Awake()
	{
		base.Awake();
		this.m_Visualization = base.transform.Find("Visualization").gameObject;
	}

	private void OnDestroy()
	{
		EventManager.Disconnect<GameStateChanged>(new EventManager.OnEvent<GameStateChanged>(this.OnGameStateChanged));
	}

	public override void Initialize()
	{
		base.contraption.ChangeOneShotPartAmount(this.m_partType, this.EffectDirection(), 1);
		EventManager.Connect<GameStateChanged>(new EventManager.OnEvent<GameStateChanged>(this.OnGameStateChanged));
		this.CheckRotations();
	}

	private void OnGameStateChanged(GameStateChanged data)
	{
		if (data.state == LevelManager.GameState.CakeRaceCompleted)
		{
			EventManager.Disconnect<GameStateChanged>(new EventManager.OnEvent<GameStateChanged>(this.OnGameStateChanged));
			this.Explode();
		}
	}

	public override void ChangeVisualConnections()
	{
	}

	protected override void OnTouch()
	{
		this.Explode();
	}

	public void Explode()
	{
		if (!this.m_triggered)
		{
			this.m_triggered = true;
			base.contraption.ChangeOneShotPartAmount(this.m_partType, this.EffectDirection(), -1);
			Collider[] array = Physics.OverlapSphere(base.transform.position, this.m_explosionRadius);
			foreach (Collider collider in array)
			{
				GameObject gameObject = this.FindParentWithRigidBody(collider.gameObject);
				if (gameObject != null)
				{
					int num = this.CountChildColliders(gameObject, 0);
					this.AddExplosionForce(gameObject, 1f / (float)num);
				}
				TNT component = collider.GetComponent<TNT>();
				if (component)
				{
					component.Explode();
				}
			}
			Singleton<AudioManager>.Instance.SpawnOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.tntExplosion, base.transform.position);
			WPFMonoBehaviour.effectManager.CreateParticles(this.smokeCloudPrefab, base.transform.position - Vector3.forward * 12f, true);
			this.CheckForAchievements();
			base.contraption.RemovePart(this);
			List<Joint> list = base.contraption.FindPartFixedJoints(this);
			if (list.Count > 0)
			{
				for (int j = 0; j < list.Count; j++)
				{
					bool flag = list[j].gameObject == this || list[j].connectedBody == this;
					bool flag2 = float.IsInfinity(list[j].breakForce);
					if (!flag2 || flag)
					{
						UnityEngine.Object.Destroy(list[j]);
					}
				}
				base.HandleJointBreak(float.MaxValue, true);
			}
			base.StartCoroutine(this.ShineLight());
			EventManager.Disconnect<GameStateChanged>(new EventManager.OnEvent<GameStateChanged>(this.OnGameStateChanged));
			EventManager.Send<TimeBombExplodeEvent>(new TimeBombExplodeEvent());
		}
	}

	private int CountChildColliders(GameObject obj, int count)
	{
		if (obj.GetComponent<Collider>())
		{
			count++;
		}
		for (int i = 0; i < obj.transform.childCount; i++)
		{
			count = this.CountChildColliders(obj.transform.GetChild(i).gameObject, count);
		}
		return count;
	}

	private GameObject FindParentWithRigidBody(GameObject obj)
	{
		if (obj.GetComponent<Rigidbody>())
		{
			return obj;
		}
		if (obj.transform.parent)
		{
			return this.FindParentWithRigidBody(obj.transform.parent.gameObject);
		}
		return null;
	}

	private void AddExplosionForce(GameObject target, float forceFactor)
	{
		Vector3 vector = target.transform.position - base.transform.position;
		float f = Mathf.Max(vector.magnitude, 1f);
		float num = forceFactor * this.m_explosionImpulse / Mathf.Pow(f, 1.5f);
		Rigidbody component = target.GetComponent<Rigidbody>();
		if (component.mass < 0.1f)
		{
			num *= component.mass;
		}
		else if (component.mass < 0.4f)
		{
			num *= component.mass / 0.4f;
		}
		Pig component2 = target.GetComponent<Pig>();
		if (component2)
		{
			component2.PrepareForTNT(base.transform.position, num);
			num *= 1.15f;
		}
		component.AddForce(num * vector.normalized, ForceMode.Impulse);
	}

	public void CheckForAchievements()
	{
		if (!Singleton<SocialGameManager>.IsInstantiated() || Singleton<GameManager>.Instance.IsInGame())
		{
		}
	}

	private void Update()
	{
		Vector3 position = base.transform.position;
		LevelManager.CameraLimits currentCameraLimits = WPFMonoBehaviour.levelManager.CurrentCameraLimits;
		if (position.x > currentCameraLimits.topLeft.x + currentCameraLimits.size.x * 1.1f || position.x < currentCameraLimits.topLeft.x - currentCameraLimits.size.x * 0.1f)
		{
			EventManager.Send<TimeBomb.BombOutOfBounds>(new TimeBomb.BombOutOfBounds());
		}
	}

	private IEnumerator ShineLight()
	{
		PointLightSource pls = base.GetComponentInChildren<PointLightSource>();
		if (pls)
		{
			MeshRenderer renderer = base.transform.GetComponentInChildren<MeshRenderer>();
			if (renderer)
			{
				renderer.enabled = false;
			}
			PointLightSource pointLightSource = pls;
			pointLightSource.onLightTurnOff = (Action)Delegate.Combine(pointLightSource.onLightTurnOff, new Action(delegate()
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}));
			pls.isEnabled = true;
			yield return new WaitForSeconds(pls.turnOnCurve[pls.turnOnCurve.length - 1].time);
			pls.isEnabled = false;
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		yield break;
	}

	public override void SetRotation(BasePart.GridRotation rotation)
	{
		this.m_gridRotation = rotation;
		this.m_Visualization.transform.localRotation = Quaternion.AngleAxis(base.GetRotationAngle(rotation), Vector3.forward);
		this.CheckRotations();
	}

	private void FlipRotation(Transform target, bool flipX, bool flipY)
	{
		Vector3 localScale = target.localScale;
		if (flipX)
		{
			localScale.x = -Mathf.Abs(localScale.x);
		}
		else
		{
			localScale.x = Mathf.Abs(localScale.x);
		}
		if (flipY)
		{
			localScale.y = -Mathf.Abs(localScale.y);
		}
		else
		{
			localScale.y = Mathf.Abs(localScale.y);
		}
		target.localScale = localScale;
	}

	private void CheckRotations()
	{
		if (this.m_checkRotation && this.m_gridRotation == BasePart.GridRotation.Deg_90)
		{
			this.FlipRotation(this.m_Visualization.transform, true, false);
		}
		else if (this.m_checkRotation)
		{
			this.FlipRotation(this.m_Visualization.transform, false, false);
		}
	}

	[SerializeField]
	private float m_explosionImpulse;

	[SerializeField]
	private float m_explosionRadius;

	[SerializeField]
	private float m_triggerSpeed;

	[SerializeField]
	private GameObject smokeCloudPrefab;

	private GameObject m_Visualization;

	[SerializeField]
	private bool m_checkRotation;

	private bool m_triggered;

	public class BombOutOfBounds : EventManager.Event
	{
	}
}
