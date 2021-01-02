using System;
using UnityEngine;

public class Sandbag : BasePart
{
	public override void Awake()
	{
		base.Awake();
		if (this.m_actualVisualizationNode && this.m_gridVisualizationNode)
		{
			this.m_actualVisualizationNode.SetActive(false);
			this.m_gridVisualizationNode.SetActive(true);
		}
	}

	public override bool IsIntegralPart()
	{
		return false;
	}

	public bool IsAttached()
	{
		return !this.m_dropped;
	}

	public override void Initialize()
	{
		if (this.m_actualVisualizationNode && this.m_gridVisualizationNode)
		{
			this.m_gridVisualizationNode.SetActive(false);
			this.m_actualVisualizationNode.SetActive(true);
		}
		this.m_connectedPart = base.contraption.FindPartAt(this.m_coordX, this.m_coordY + 1);
		if (this.m_connectedPart && !this.m_connectedPart.IsPartOfChassis() && this.m_connectedPart.m_partType != BasePart.PartType.Pig)
		{
			this.m_connectedPart = null;
		}
		if (this.m_connectedPart)
		{
			this.m_dropped = false;
			base.contraption.ChangeOneShotPartAmount(BasePart.BaseType(this.m_partType), this.EffectDirection(), 1);
		}
		else
		{
			this.m_dropped = true;
			base.gameObject.layer = LayerMask.NameToLayer("DroppedSandbag");
		}
		this.m_partType = BasePart.PartType.Sandbag;
		if (this.m_numberOfBalloons > 1)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(base.gameObject);
			gameObject.transform.position = base.transform.position;
			Sandbag component = gameObject.GetComponent<Sandbag>();
			component.m_numberOfBalloons = this.m_numberOfBalloons - 1;
			base.contraption.AddRuntimePart(component);
			gameObject.transform.parent = base.contraption.transform;
		}
		if (!base.gameObject.GetComponent<SphereCollider>())
		{
			SphereCollider sphereCollider = base.gameObject.AddComponent<SphereCollider>();
			sphereCollider.radius = 0.13f;
			sphereCollider.center = new Vector3(0f, -0.1f, 0f);
		}
		if (!base.rigidbody)
		{
			base.rigidbody = base.gameObject.AddComponent<Rigidbody>();
		}
		base.rigidbody.mass = this.m_mass;
		base.rigidbody.drag = 1f;
		base.rigidbody.angularDrag = 10f;
		base.rigidbody.constraints = (RigidbodyConstraints)56;
		if (this.m_connectedPart)
		{
			Vector3 position = base.transform.position;
			base.transform.position = this.m_connectedPart.transform.position - Vector3.up * 0.5f;
			SpringJoint springJoint = base.gameObject.AddComponent<SpringJoint>();
			springJoint.connectedBody = this.m_connectedPart.rigidbody;
			this.m_connectedLocalPos = this.m_connectedPart.transform.InverseTransformPoint(base.transform.position);
			int numberOfBalloons = this.m_numberOfBalloons;
			Vector3 b;
			float maxDistance;
			if (numberOfBalloons != 1)
			{
				if (numberOfBalloons != 2)
				{
					b = new Vector3(0f, -0.35f, -0.03f);
					maxDistance = 0.65f;
				}
				else
				{
					b = new Vector3(0.35f, -0.3f, -0.02f);
					maxDistance = 0.55f;
				}
			}
			else
			{
				b = new Vector3(-0.15f, -0.15f, -0.01f);
				maxDistance = 0.5f;
			}
			springJoint.minDistance = 0f;
			springJoint.maxDistance = maxDistance;
			springJoint.anchor = Vector3.up * 0.5f;
			springJoint.spring = 100f;
			springJoint.damper = 10f;
			base.transform.position = position + b;
			LineRenderer lineRenderer = base.gameObject.AddComponent<LineRenderer>();
			lineRenderer.material = this.m_stringMaterial;
			lineRenderer.SetVertexCount(2);
			lineRenderer.SetWidth(0.05f, 0.05f);
			lineRenderer.SetColors(Color.black, Color.black);
		}
		else
		{
			int numberOfBalloons2 = this.m_numberOfBalloons;
			Vector3 b2;
			if (numberOfBalloons2 != 1)
			{
				if (numberOfBalloons2 != 2)
				{
					b2 = new Vector3(0f, -0.35f, -0.03f);
				}
				else
				{
					b2 = new Vector3(0.35f, -0.3f, -0.02f);
				}
			}
			else
			{
				b2 = new Vector3(-0.15f, -0.15f, -0.01f);
			}
			base.transform.position += b2;
		}
	}

	protected override void OnTouch()
	{
		this.Drop();
	}

	public void Drop()
	{
		if (!this.m_dropped)
		{
			this.m_dropped = true;
			SpringJoint component = base.GetComponent<SpringJoint>();
			base.contraption.ChangeOneShotPartAmount(BasePart.BaseType(this.m_partType), this.EffectDirection(), -1);
			base.gameObject.layer = LayerMask.NameToLayer("DroppedSandbag");
			if (component && component.connectedBody)
			{
				component.connectedBody.AddForce(5f * Vector3.up, ForceMode.Impulse);
				base.rigidbody.AddForce(-4f * Vector3.up, ForceMode.Impulse);
			}
			if (component)
			{
				UnityEngine.Object.Destroy(component);
			}
			LineRenderer component2 = base.GetComponent<LineRenderer>();
			if (component2)
			{
				UnityEngine.Object.Destroy(component2);
			}
		}
	}

	public new void LateUpdate()
	{
		base.LateUpdate();
		SpringJoint component = base.GetComponent<SpringJoint>();
		if (!component)
		{
			return;
		}
		LineRenderer component2 = base.GetComponent<LineRenderer>();
		Vector3 position = base.transform.position + base.transform.up * 0.4f;
		if (component.connectedBody)
		{
			Vector3 position2 = component.connectedBody.transform.TransformPoint(this.m_connectedLocalPos);
			component2.SetPosition(0, position);
			component2.SetPosition(1, position2);
		}
	}

	public bool m_inWorldCoordinates = true;

	public Vector3 m_direction = Vector3.up;

	public int m_numberOfBalloons = 1;

	public bool m_dropped;

	public Material m_stringMaterial;

	public GameObject m_actualVisualizationNode;

	public GameObject m_gridVisualizationNode;

	protected BasePart m_connectedPart;

	protected Vector3 m_connectedLocalPos;
}
