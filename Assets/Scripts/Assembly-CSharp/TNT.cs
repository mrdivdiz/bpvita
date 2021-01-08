using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNT : BasePart
{
	public override bool CanBeEnclosed()
	{
		return true;
	}

	public override void Awake()
	{
		base.Awake();
		Transform transform = base.transform.Find("LeftAttachment");
		Transform transform2 = base.transform.Find("RightAttachment");
		Transform transform3 = base.transform.Find("TopAttachment");
		Transform transform4 = base.transform.Find("BottomAttachment");
		if (transform)
		{
			this.m_leftAttachment = transform.gameObject;
			this.m_leftAttachment.SetActive(false);
		}
		if (transform2)
		{
			this.m_rightAttachment = transform2.gameObject;
			this.m_rightAttachment.SetActive(false);
		}
		if (transform3)
		{
			this.m_topAttachment = transform3.gameObject;
			this.m_topAttachment.SetActive(false);
		}
		if (transform4)
		{
			this.m_bottomAttachment = transform4.gameObject;
			this.m_bottomAttachment.SetActive(false);
		}
	}

	public override void Initialize()
	{
		base.contraption.ChangeOneShotPartAmount(this.m_partType, this.EffectDirection(), 1);
	}

	public override void OnCollisionEnter(Collision c)
	{
		base.OnCollisionEnter(c);
		float magnitude = c.relativeVelocity.magnitude;
		if (magnitude > this.m_triggerSpeed)
		{
			this.Explode();
		}
	}

	public override void ChangeVisualConnections()
	{
		bool active = base.contraption.CanConnectTo(this, BasePart.Rotate(BasePart.Direction.Up, this.m_gridRotation));
		bool active2 = base.contraption.CanConnectTo(this, BasePart.Rotate(BasePart.Direction.Down, this.m_gridRotation));
		bool active3 = base.contraption.CanConnectTo(this, BasePart.Rotate(BasePart.Direction.Left, this.m_gridRotation));
		bool active4 = base.contraption.CanConnectTo(this, BasePart.Rotate(BasePart.Direction.Right, this.m_gridRotation));
		if (this.m_leftAttachment)
		{
			this.m_leftAttachment.SetActive(active3);
		}
		if (this.m_rightAttachment)
		{
			this.m_rightAttachment.SetActive(active4);
		}
		if (this.m_topAttachment)
		{
			this.m_topAttachment.SetActive(active);
		}
		if (this.m_bottomAttachment)
		{
			this.m_bottomAttachment.SetActive(active2);
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(base.transform.position, this.m_explosionRadius);
	}

	protected override void OnTouch()
	{
		this.Explode();
	}

	public virtual void Explode()
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
				if (component && !(component is AlienTNT))
				{
					component.Explode();
				}
			}
			Singleton<AudioManager>.Instance.SpawnOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.tntExplosion, base.transform.position);
			WPFMonoBehaviour.effectManager.CreateParticles(this.smokeCloud, base.transform.position - Vector3.forward * 5f, true);
			if (this.extraEffect)
			{
				WPFMonoBehaviour.effectManager.CreateParticles(this.extraEffect, base.transform.position - Vector3.forward * 4f, true);
			}
			this.CheckForTNTAchievement();
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
		}
	}

	protected int CountChildColliders(GameObject obj, int count)
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

	protected GameObject FindParentWithRigidBody(GameObject obj)
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

	protected void AddExplosionForce(GameObject target, float forceFactor)
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

	public void CheckForTNTAchievement()
	{
		if (Singleton<SocialGameManager>.IsInstantiated() && Singleton<GameManager>.Instance.IsInGame())
		{
			int brokenTNTs = GameProgress.GetInt("Broken_TNTs", 0, GameProgress.Location.Local, null) + 1;
			GameProgress.SetInt("Broken_TNTs", brokenTNTs, GameProgress.Location.Local);
			Action<List<string>> action = delegate(List<string> achievements)
			{
				foreach (string achievementId in achievements)
				{
					if (Singleton<SocialGameManager>.Instance.TryReportAchievementProgress(achievementId, 100.0, (int limit) => brokenTNTs > limit))
					{
						break;
					}
				}
			};
			action(new List<string>
			{
				"grp.BOOM_BOOM_III",
				"grp.BOOM_BOOM_II",
				"grp.BOOM_BOOM_I"
			});
		}
	}

	protected virtual IEnumerator ShineLight()
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

	public float m_explosionImpulse;

	public float m_explosionRadius;

	public float m_triggerSpeed;

	[SerializeField]
	protected GameObject extraEffect;

	protected bool m_triggered;

	private GameObject m_leftAttachment;

	private GameObject m_rightAttachment;

	private GameObject m_topAttachment;

	private GameObject m_bottomAttachment;

	public GameObject smokeCloud;
}
