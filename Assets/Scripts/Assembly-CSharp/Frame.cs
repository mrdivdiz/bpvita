using System;
using UnityEngine;

public class Frame : BasePart
{
	public override bool CanEncloseParts()
	{
		return true;
	}

	public override bool IsPartOfChassis()
	{
		return true;
	}

	public override void Initialize()
	{
		if (this.m_enclosedPart)
		{
			FixedJoint fixedJoint = this.m_enclosedPart.gameObject.AddComponent<FixedJoint>();
			fixedJoint.connectedBody = base.rigidbody;
			float breakForce = base.contraption.GetJointConnectionStrength(this.GetJointConnectionStrength()) + base.contraption.GetJointConnectionStrength(this.m_enclosedPart.GetJointConnectionStrength());
			fixedJoint.breakForce = breakForce;
			fixedJoint.enablePreprocessing = false;
			base.contraption.AddJointToMap(this, this.m_enclosedPart, fixedJoint);
			this.IgnoreCollisionRecursive(base.collider, this.m_enclosedPart.gameObject);
		}
	}

	private void IgnoreCollisionRecursive(Collider collider, GameObject part)
	{
		if (part.activeInHierarchy && part.GetComponent<Collider>())
		{
			Physics.IgnoreCollision(collider, part.GetComponent<Collider>());
		}
		for (int i = 0; i < part.transform.childCount; i++)
		{
			this.IgnoreCollisionRecursive(collider, part.transform.GetChild(i).gameObject);
		}
	}

	public override void OnBreak()
	{
	}

	public Frame.FrameMaterial m_material;

	public Texture2D[] m_brokenTextures;

	public enum FrameMaterial
	{
		Wood,
		Metal
	}
}
