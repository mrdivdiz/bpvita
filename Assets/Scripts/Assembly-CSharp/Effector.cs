using System.Collections.Generic;
using UnityEngine;

public class Effector : WPFMonoBehaviour
{
	private void Start()
	{
	}

	private void FixedUpdate()
	{
		foreach (GameObject gameObject in this.m_influenceList)
		{
			if (gameObject && gameObject.GetComponent<Rigidbody>())
			{
				switch (this.m_type)
				{
				case Effector.Type.Wind:
					if (this.m_hasLinearFadeout)
					{
						gameObject.GetComponent<Rigidbody>().AddForce((Vector3.right * Mathf.Cos(this.m_angle * 0.0174532924f) + Vector3.up * Mathf.Sin(this.m_angle * 0.0174532924f)) * this.m_strenght / Mathf.Clamp((gameObject.transform.position - base.transform.position).magnitude, 1f, 100f), ForceMode.Force);
					}
					else
					{
						gameObject.GetComponent<Rigidbody>().AddForce((Vector3.right * Mathf.Cos(this.m_angle * 0.0174532924f) + Vector3.up * Mathf.Sin(this.m_angle * 0.0174532924f)) * this.m_strenght, ForceMode.Force);
					}
					break;
				case Effector.Type.Magnet:
					gameObject.GetComponent<Rigidbody>().AddForce((base.transform.position + this.m_effectorCenterPoint - gameObject.transform.position).normalized * this.m_strenght, ForceMode.Acceleration);
					break;
				case Effector.Type.Formula:
					this.ApplyFormulaEffector(this.m_formulaType, gameObject.GetComponent<Rigidbody>());
					break;
				}
			}
		}
	}

	private void OnTriggerEnter(Collider c)
	{
		if (c.GetComponent<Rigidbody>())
		{
			if (this.m_interactionTypeList.Count == 0)
			{
				this.m_influenceList.Add(c.gameObject);
				return;
			}
			foreach (string type in this.m_interactionTypeList)
			{
				Component component = c.GetComponent(type);
				if ((component && this.m_interactionType == Effector.InteractionType.Include) || (!component && this.m_interactionType == Effector.InteractionType.Exclude))
				{
					this.m_influenceList.Add(c.gameObject);
				}
			}
		}
	}

	private void OnTriggerExit(Collider c)
	{
		this.m_influenceList.Remove(c.gameObject);
	}

	private void OnCollisionEnter(Collision c)
	{
		if (c.rigidbody)
		{
            Type type = this.m_type;
			if (type == Effector.Type.Bumper)
			{
				foreach (ContactPoint contactPoint in c.contacts)
				{
					if (Vector3.Dot(contactPoint.normal, base.transform.up) <= 0.707f)
					{
						this.Bump(contactPoint.otherCollider.gameObject);
					}
				}
			}
		}
	}

	private void ApplyFormulaEffector(FormulaType type, Rigidbody rb)
	{
		switch (type)
		{
		case Effector.FormulaType.Sin:
			rb.AddForce((Vector3.right * Mathf.Cos(this.m_angle * 0.0174532924f) + Vector3.up * Mathf.Sin(this.m_angle * 0.0174532924f)) * this.m_strenght * Mathf.Sin(Time.time), ForceMode.Force);
			break;
		case Effector.FormulaType.Cos:
			rb.AddForce((Vector3.right * Mathf.Cos(this.m_angle * 0.0174532924f) + Vector3.up * Mathf.Sin(this.m_angle * 0.0174532924f)) * this.m_strenght * Mathf.Cos(Time.time), ForceMode.Force);
			break;
		case Effector.FormulaType.AbsSin:
			rb.AddForce((Vector3.right * Mathf.Cos(this.m_angle * 0.0174532924f) + Vector3.up * Mathf.Sin(this.m_angle * 0.0174532924f)) * this.m_strenght * Mathf.Abs(Mathf.Cos(Time.time)), ForceMode.Force);
			break;
		case Effector.FormulaType.AbsCos:
			rb.AddForce((Vector3.right * Mathf.Cos(this.m_angle * 0.0174532924f) + Vector3.up * Mathf.Sin(this.m_angle * 0.0174532924f)) * this.m_strenght * Mathf.Abs(Mathf.Cos(Time.time)), ForceMode.Force);
			break;
		}
	}

	private void Bump(GameObject go)
	{
		Vector3 vector = base.transform.up;
		vector = (go.transform.position - base.transform.position).normalized;
		Vector3 velocity = go.GetComponent<Rigidbody>().velocity;
		float num = Vector3.Dot(vector, velocity);
		Vector3 b = vector * num;
		Vector3 a = velocity - b;
		num = Mathf.Max(this.m_strenght, Mathf.Abs(num));
		Vector3 velocity2 = a + vector * num;
		go.GetComponent<Rigidbody>().velocity = velocity2;
		if (base.animation)
		{
			base.animation.Play();
		}
	}

	public Shape m_shape;

	public bool m_isTrigger = true;

	[HideInInspector]
	public float m_range = 5f;

	[HideInInspector]
	public float m_strenght = 5f;

	[HideInInspector]
	public float m_angle;

	[HideInInspector]
	public FormulaType m_formulaType;

	[HideInInspector]
	public bool m_useVectorUpForDirection;

	[HideInInspector]
	public bool m_hasLinearFadeout;

	public InteractionType m_interactionType;

	public List<string> m_interactionTypeList = new List<string>();

	protected List<GameObject> m_influenceList = new List<GameObject>();

	[HideInInspector]
	public Vector3 m_effectorCenterPoint;

	public Type m_type;

	public enum Type
	{
		Wind,
		Magnet,
		Formula,
		Bumper
	}

	public enum Shape
	{
		Box,
		Circle,
		Capsule
	}

	public enum InteractionType
	{
		Include,
		Exclude
	}

	public enum FormulaType
	{
		Sin,
		Cos,
		AbsSin,
		AbsCos
	}
}
