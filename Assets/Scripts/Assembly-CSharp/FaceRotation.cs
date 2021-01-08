using System;
using System.Collections.Generic;
using UnityEngine;

public class FaceRotation : MonoBehaviour
{
	public void SetTargetDirection(Vector3 direction)
	{
		if (!this.m_followMouse)
		{
			this.m_targetDirectionSet = true;
			this.m_targetDirection = direction;
		}
	}

	public void ScaleFaceZ(float scale)
	{
		foreach (TargetInfo targetInfo in this.m_targets)
		{
			if (targetInfo != null)
			{
                TargetInfo targetInfo2 = targetInfo;
				targetInfo2.m_targetPosition.z = targetInfo2.m_targetPosition.z * scale;
			}
		}
	}

	private void Start()
	{
		if (!this.m_positionsSet)
		{
			this.m_positionsSet = true;
			foreach (TargetInfo targetInfo in this.m_targets)
			{
				if (targetInfo != null)
				{
					targetInfo.m_targetPosition = targetInfo.m_target.transform.localPosition;
				}
			}
		}
		this.m_targetDirectionSet = false;
	}

	private void Update()
	{
		if (this.m_followMouse)
		{
			Vector3 a;
			if (GameObject.FindGameObjectWithTag("MainCamera"))
			{
				a = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
			}
			else
			{
				a = GameObject.FindGameObjectWithTag("HUDCamera").GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
			}
			Vector3 a2 = a - base.transform.position;
			a2.z = 0f;
			this.m_normalizedDirection = 0.3f * a2;
		}
		if (this.m_targetDirectionSet)
		{
			this.m_normalizedDirection = this.m_targetDirection;
		}
		this.m_normalizedDirection = Quaternion.Inverse(base.transform.rotation) * this.m_normalizedDirection;
		if (this.m_normalizedDirection.sqrMagnitude > 1f)
		{
			this.m_normalizedDirection.Normalize();
		}
		Vector3 vector = this.m_maxMove * this.m_normalizedDirection;
		Vector3 vector2 = new Vector3(vector.x, vector.y, this.m_zOffset);
		Vector3 normalized = vector2.normalized;
		Quaternion rotation = Quaternion.FromToRotation(new Vector3(0f, 0f, this.m_zOffset), normalized);
		for (int i = 0; i < this.m_targets.Count; i++)
		{
			this.RotateTarget(this.m_targets[i], rotation);
		}
	}

	private void RotateTarget(TargetInfo info, Quaternion rotation)
	{
		if (info == null)
		{
			return;
		}
		Vector3 targetPosition = info.m_targetPosition;
		targetPosition.z = info.m_zOffset;
		Vector3 vector = rotation * targetPosition;
		Quaternion rotation2 = Quaternion.FromToRotation(targetPosition, vector);
		Vector3 vector2 = rotation2 * Vector3.right;
		Vector3 vector3 = rotation2 * Vector3.up;
		Vector3 one = Vector3.one;
		if (info.ignoreX)
		{
			vector.x = info.m_targetPosition.x;
		}
		else
		{
			one.x = vector2.x;
		}
		if (info.ignoreY)
		{
			vector.y = info.m_targetPosition.y;
		}
		else
		{
			one.y = vector3.y;
		}
		vector.z = info.m_targetPosition.z;
		info.m_target.transform.localPosition = vector;
		info.m_target.transform.localScale = new Vector3(info.m_scaleFactor.x * one.x + (1f - info.m_scaleFactor.x), info.m_scaleFactor.y * one.y + (1f - info.m_scaleFactor.y), 1f);
	}

	public bool m_followMouse;

	public float m_maxMove = 0.2f;

	public float m_zOffset = -0.5f;

	public List<TargetInfo> m_targets;

	private Vector3 m_normalizedDirection;

	private Vector3 m_targetDirection;

	private bool m_targetDirectionSet;

	private Vector3 m_target2Position;

	[SerializeField]
	[HideInInspector]
	private bool m_positionsSet;

	[Serializable]
	public class TargetInfo
	{
		public bool ignoreX;

		public bool ignoreY;

		public GameObject m_target;

		public float m_zOffset = 1f;

		public Vector2 m_scaleFactor = new Vector2(1f, 1f);

		[HideInInspector]
		public Vector3 m_targetPosition;
	}
}
