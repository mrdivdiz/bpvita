using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class WindArea : MonoBehaviour
{
	private void Awake()
	{
		EventManager.Connect(new EventManager.OnEvent<GameStateChanged>(this.ReceiveGameStateChangeEvent));
	}

	private void OnDestroy()
	{
		EventManager.Disconnect(new EventManager.OnEvent<GameStateChanged>(this.ReceiveGameStateChangeEvent));
	}

	private void Start()
	{
	}

	private void ReceiveGameStateChangeEvent(GameStateChanged newState)
	{
		if (newState.state == LevelManager.GameState.Running)
		{
			this.windEnabled = true;
		}
		else
		{
			this.windEnabled = false;
		}
		if (newState.state == LevelManager.GameState.Building)
		{
			this.ResetToInitialState();
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		BasePart component = other.GetComponent<BasePart>();
		if (component)
		{
			this.affectedParts.Add(component);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		BasePart component = other.GetComponent<BasePart>();
		if (component)
		{
			this.affectedParts.Remove(component);
		}
	}

	private void FixedUpdate()
	{
		if (this.windEnabled)
		{
			Vector3 a = this.WindDirection();
			foreach (BasePart basePart in this.affectedParts)
			{
				if (basePart)
				{
					Rigidbody rigidbody = basePart.rigidbody;
					if (rigidbody)
					{
						rigidbody.AddForce(a * this.m_windPowerFactor);
					}
					basePart.WindVelocity = 4f * a.normalized * this.m_windPowerFactor;
				}
			}
		}
	}

	private void ResetToInitialState()
	{
		this.affectedParts.Clear();
	}

	private Vector3 WindDirection()
	{
		return this.windDirectionHandle - base.transform.position;
	}

	private void OnDrawGizmos()
	{
		Bounds bounds = base.GetComponent<BoxCollider>().bounds;
		for (float num = bounds.min.y; num <= bounds.max.y; num += 8f)
		{
			for (float num2 = bounds.min.x; num2 <= bounds.max.x; num2 += 8f)
			{
				GizmoUtils.DrawArrow(new Vector3(num2, num, base.transform.position.z), this.WindDirection());
			}
		}
	}

	[SerializeField]
	public Vector3 windDirectionHandle = Vector3.up;

	public float m_windPowerFactor = 1f;

	public bool m_calculateParticleValues = true;

	private List<BasePart> affectedParts = new List<BasePart>();

	private bool windEnabled;
}
