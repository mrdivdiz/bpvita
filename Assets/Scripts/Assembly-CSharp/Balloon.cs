using System;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : BasePart
{
	public override void Awake()
	{
		base.Awake();
		base.enabled = false;
		if (this.m_actualVisualizationNode && this.m_gridVisualizationNode)
		{
			this.SetRenderersInChildred(this.m_actualVisualizationNode, false);
			this.SetRenderersInChildred(this.m_gridVisualizationNode, true);
		}
	}

	private void SetRenderersInChildred(GameObject target, bool enable)
	{
		if (target == null)
		{
			return;
		}
		Renderer[] componentsInChildren = target.GetComponentsInChildren<Renderer>();
		if (componentsInChildren == null || componentsInChildren.Length == 0)
		{
			return;
		}
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].enabled = enable;
		}
	}

	public override bool IsIntegralPart()
	{
		return false;
	}

	public override void PrePlaced()
	{
	}

	public override void Initialize()
	{
		if (this.m_actualVisualizationNode && this.m_gridVisualizationNode)
		{
			this.SetRenderersInChildred(this.m_gridVisualizationNode, false);
			this.SetRenderersInChildred(this.m_actualVisualizationNode, true);
		}
		int num = 1;
		while (num < 6 && !this.m_connectedPart)
		{
			this.m_connectedPart = base.contraption.FindPartAt(this.m_coordX, this.m_coordY - num);
			if (this.m_connectedPart && !this.m_connectedPart.IsPartOfChassis() && this.m_connectedPart.m_partType != BasePart.PartType.Pig && this.m_connectedPart.m_partType != BasePart.PartType.Kicker)
			{
				this.m_connectedPart = null;
			}
			num++;
		}
		this.m_partType = BasePart.PartType.Balloon;
		base.contraption.ChangeOneShotPartAmount(BasePart.BaseType(this.m_partType), this.EffectDirection(), 1);
		if (this.m_numberOfBalloons > 1)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(base.gameObject);
			gameObject.transform.position = base.transform.position;
			Balloon component = gameObject.GetComponent<Balloon>();
			component.m_numberOfBalloons = this.m_numberOfBalloons - 1;
			base.contraption.AddRuntimePart(component);
			gameObject.transform.parent = base.contraption.transform;
		}
		if (!base.gameObject.GetComponent<SphereCollider>())
		{
			SphereCollider sphereCollider = base.gameObject.AddComponent<SphereCollider>();
			sphereCollider.radius = 0.5f;
		}
		if (!base.rigidbody)
		{
			base.gameObject.AddComponent<Rigidbody>();
		}
		base.rigidbody.mass = 0.1f;
		base.rigidbody.drag = 2f;
		base.rigidbody.angularDrag = 0.5f;
		base.rigidbody.constraints = (RigidbodyConstraints)48;
		if (this.m_connectedPart)
		{
			this.m_connectedPart.EnsureRigidbody();
			Vector3 position = base.transform.position;
			float num2 = Vector3.Distance(this.m_connectedPart.transform.position, position) - 0.5f;
			float num3 = 0f;
			Vector3 b;
			if (this.m_connectedPart.m_partType == BasePart.PartType.Pig)
			{
				b = Vector3.zero;
				num3 = 0.3f;
			}
			else
			{
				b = Vector3.up * 0.5f;
			}
			base.transform.position = this.m_connectedPart.transform.position + b;
			this.m_springJoint = base.gameObject.AddComponent<SpringJoint>();
			this.m_springJoint.connectedBody = this.m_connectedPart.rigidbody;
			base.contraption.AddJointToMap(this, this.m_connectedPart, this.m_springJoint);
			float maxDistance = UnityEngine.Random.Range(0.8f, 1.2f) * num2 + num3;
			this.m_springJoint.minDistance = 0f;
			this.m_springJoint.maxDistance = maxDistance;
			this.m_springJoint.anchor = Vector3.up * -0.5f;
			this.m_springJoint.spring = 100f;
			this.m_springJoint.damper = 10f;
			this.m_springJoint.enablePreprocessing = false;
			this.m_balancer = this.m_connectedPart.gameObject.GetComponent<BalloonBalancer>();
			if (!this.m_balancer)
			{
				this.m_balancer = this.m_connectedPart.gameObject.AddComponent<BalloonBalancer>();
			}
			this.m_balancer.AddBalloon();
			Transform transform = base.transform;
			if (this.m_actualVisualizationNode)
			{
				transform = this.m_actualVisualizationNode.transform;
			}
			this.m_rope = transform.gameObject.AddComponent<RopeVisualization>();
			this.m_connectedLocalPos = this.m_connectedPart.transform.InverseTransformPoint(base.transform.position);
			this.m_springJoint.autoConfigureConnectedAnchor = false;
			this.m_springJoint.connectedAnchor = this.m_connectedLocalPos;
			this.m_rope.m_stringMaterial = this.m_stringMaterial;
			this.m_rope.m_pos1Anchor = Vector3.up * -0.5f + 1.1f * Vector3.forward;
			this.m_rope.m_pos2Transform = this.m_connectedPart.transform;
			this.m_rope.m_pos2Anchor = this.m_connectedLocalPos + 1.1f * Vector3.forward;
			base.transform.position = position + UnityEngine.Random.Range(-1f, 1f) * Vector3.forward + UnityEngine.Random.Range(-1f, 1f) * Vector3.right * 0.5f;
		}
	}

	public void ConfigureExtraBalanceJoint(float powerFactor)
	{
		if (this.m_balancer)
		{
			this.m_balancer.Configure(powerFactor);
		}
	}

	private float LimitForceForSpeed(float forceMagnitude, Vector3 forceDir)
	{
		Vector3 velocity = base.rigidbody.velocity;
		float num = Vector3.Dot(velocity.normalized, forceDir);
		if (num > 0f)
		{
			Vector3 vector = velocity * num;
			if (vector.magnitude > this.m_maximumSpeed)
			{
				return forceMagnitude / (1f + vector.magnitude - this.m_maximumSpeed);
			}
		}
		return forceMagnitude;
	}

	public void FixedUpdate()
	{
		float d = this.LimitForceForSpeed(this.m_force, this.m_direction);
		base.rigidbody.AddForce(d * this.m_direction, ForceMode.Force);
		if (this.m_springJoint && !this.m_springJoint.connectedBody)
		{
			UnityEngine.Object.Destroy(this.m_rope.GetComponent<LineRenderer>());
			UnityEngine.Object.Destroy(this.m_rope);
			UnityEngine.Object.Destroy(this.m_springJoint);
			base.contraption.ChangeOneShotPartAmount(BasePart.BaseType(this.m_partType), this.EffectDirection(), -1);
		}
	}

	protected override void OnTouch()
	{
		this.Pop();
	}

	public override void OnCollisionEnter(Collision coll)
	{
		foreach (ContactPoint contactPoint in coll.contacts)
		{
			if (contactPoint.otherCollider.gameObject.layer == BasePart.m_groundLayer || contactPoint.otherCollider.gameObject.layer == BasePart.m_iceGroundLayer || contactPoint.otherCollider.CompareTag("Sharp"))
			{
				this.Pop();
				break;
			}
		}
	}

	public void Pop()
	{
		if (!this.m_popped)
		{
			this.m_popped = true;
			AudioSource effectSource;
			if (this.m_ghostBalloon)
			{
				effectSource = WPFMonoBehaviour.gameData.commonAudioCollection.ghostBalloonPop[UnityEngine.Random.Range(0, WPFMonoBehaviour.gameData.commonAudioCollection.ghostBalloonPop.Length)];
			}
			else
			{
				effectSource = WPFMonoBehaviour.gameData.commonAudioCollection.balloonPop;
			}
			Singleton<AudioManager>.Instance.SpawnOneShotEffect(effectSource, base.transform.position);
			WPFMonoBehaviour.effectManager.CreateParticles(WPFMonoBehaviour.gameData.m_ballonParticles, base.transform.position, false);
			base.contraption.ChangeOneShotPartAmount(BasePart.BaseType(this.m_partType), this.EffectDirection(), -1);
			if (this.m_balancer)
			{
				this.m_balancer.RemoveBalloon();
			}
			this.CheckBalloonPopperAchievement();
			base.contraption.RemovePart(this);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	public override void EnsureRigidbody()
	{
		if (base.rigidbody == null)
		{
			base.rigidbody = base.gameObject.AddComponent<Rigidbody>();
		}
		base.rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
	}

	public void CheckBalloonPopperAchievement()
	{
		if (Singleton<SocialGameManager>.IsInstantiated() && Singleton<GameManager>.Instance.IsInGame())
		{
			int poppedBalloons = GameProgress.GetInt("Popped_Balloons", 0, GameProgress.Location.Local, null) + 1;
			GameProgress.SetInt("Popped_Balloons", poppedBalloons, GameProgress.Location.Local);
			Action<List<string>> action = delegate(List<string> achievements)
			{
				foreach (string achievementId in achievements)
				{
					if (Singleton<SocialGameManager>.Instance.TryReportAchievementProgress(achievementId, 100.0, (int limit) => poppedBalloons >= limit))
					{
						break;
					}
				}
			};
			action(new List<string>
			{
				"grp.POPPERS_THEORY_III",
				"grp.POPPERS_THEORY_II",
				"grp.POPPERS_THEORY_I"
			});
		}
	}

	public float m_force = 10f;

	public float m_maximumSpeed = 10f;

	public bool m_inWorldCoordinates = true;

	public Vector3 m_direction = Vector3.up;

	public int m_numberOfBalloons = 1;

	public bool m_popped;

	public bool m_ghostBalloon;

	public GameObject m_actualVisualizationNode;

	public GameObject m_gridVisualizationNode;

	public Material m_stringMaterial;

	protected BasePart m_connectedPart;

	protected Vector3 m_connectedLocalPos;

	protected BalloonBalancer m_balancer;

	protected SpringJoint m_springJoint;

	protected RopeVisualization m_rope;
}
