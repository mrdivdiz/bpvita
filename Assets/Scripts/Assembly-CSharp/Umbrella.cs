using System;
using UnityEngine;

public class Umbrella : BasePart
{
	public override bool CanBeEnabled()
	{
		return this.m_isConnected;
	}

	public override bool HasOnOffToggle()
	{
		return false;
	}

	public override bool IsEnabled()
	{
		return this.m_enabled;
	}

	public override bool IsPowered()
	{
		return false;
	}

	public override BasePart.Direction EffectDirection()
	{
		return BasePart.Rotate(BasePart.Direction.Up, this.m_gridRotation);
	}

	public override void Awake()
	{
		base.Awake();
		this.m_visualization = base.transform.Find("UmbrellaVisualization").gameObject;
		this.m_openSprite = this.m_visualization.transform.Find("OpenSprite").gameObject;
		this.m_closedPosition = -0.05f * Vector3.up;
		this.m_closedPosition.z = this.m_visualization.transform.localPosition.z;
		this.m_openPosition = 0.25f * Vector3.up;
		this.m_openPosition.z = this.m_visualization.transform.localPosition.z;
	}

	public override void InitializeEngine()
	{
		this.m_isConnected = (base.contraption.ComponentPartCount(base.ConnectedComponent) > 1);
		float num = 0.25f;
		this.m_maximumForce = this.m_force * num;
	}

	public override void Initialize()
	{
		base.Initialize();
		this.m_openPosition = Vector3.zero;
		this.m_openPosition.z = this.m_visualization.transform.localPosition.z;
		this.m_moveTime = 0.25f;
		this.MaxScale = 1f;
		this.m_visualization.transform.localPosition = this.m_openPosition;
		Vector3 localScale = this.m_visualization.transform.localScale;
		localScale.x = this.MaxScale;
		localScale.y = 1f;
		this.m_visualization.transform.localScale = localScale;
	}

	private void FixedUpdate()
	{
		if (!base.contraption || !base.contraption.IsRunning)
		{
			return;
		}
		if (this.m_open)
		{
			Vector3 position = base.transform.position + 0.2f * base.transform.up;
			Vector3 vector = base.rigidbody.velocity - base.WindVelocity;
			base.WindVelocity = Vector3.zero;
			float d = Vector3.Dot(base.transform.up, vector.normalized);
			float magnitude = (d * vector).magnitude;
			float num = Mathf.Sign(Vector3.Cross(vector, base.transform.right).z);
			float num2 = num * 1f * magnitude * magnitude;
			if (Mathf.Abs(num2) > 60f)
			{
				num2 = 60f * Mathf.Sign(num2);
			}
			Vector3 a = base.transform.up;
			base.rigidbody.AddForceAtPosition(num2 * a, position, ForceMode.Force);
			d = Vector3.Dot(base.transform.right, vector.normalized);
			magnitude = (d * vector).magnitude;
			num = Mathf.Sign(Vector3.Cross(base.transform.up, vector).z);
			num2 = num * 0.5f * magnitude * magnitude;
			if (Mathf.Abs(num2) > 60f)
			{
				num2 = 60f * Mathf.Sign(num2);
			}
			a = base.transform.right;
			base.rigidbody.AddForceAtPosition(num2 * a, position, ForceMode.Force);
		}
		if (this.m_enabled)
		{
			this.m_timer += Time.deltaTime;
			if (this.m_open)
			{
				float num3 = this.m_timer / this.m_moveTime;
				num3 = Mathf.Min(num3, 1f);
				Vector3 localPosition = Vector3.Lerp(this.m_openPosition, this.m_closedPosition, num3);
				Vector3 localScale = this.m_visualization.transform.localScale;
				num3 = Mathf.Pow(num3, 3f);
				localScale.x = num3 * 0.4f + (1f - num3) * this.MaxScale;
				localScale.y = num3 * 2f + (1f - num3) * 1f;
				localPosition.y -= 0.45f * (localScale.y - 1f);
				this.m_visualization.transform.localScale = localScale;
				this.m_visualization.transform.localPosition = localPosition;
				float maximumForce = this.m_maximumForce;
				base.rigidbody.AddForce(maximumForce * base.transform.up, ForceMode.Force);
			}
			else
			{
				float num4 = this.m_timer / this.m_moveTime;
				num4 = Mathf.Min(num4, 1f);
				Vector3 localPosition2 = Vector3.Lerp(this.m_closedPosition, this.m_openPosition, num4);
				Vector3 localScale2 = this.m_visualization.transform.localScale;
				num4 = Mathf.Pow(num4, 6f);
				localScale2.x = num4 * this.MaxScale + (1f - num4) * 0.4f;
				localScale2.y = num4 * 1f + (1f - num4) * 2f;
				localPosition2.y -= 0.45f * (localScale2.y - 1f);
				this.m_visualization.transform.localScale = localScale2;
				this.m_visualization.transform.localPosition = localPosition2;
				float d2 = -0.2f * this.m_maximumForce;
				base.rigidbody.AddForce(d2 * base.transform.up, ForceMode.Force);
			}
			if (this.m_timer > this.m_moveTime)
			{
				this.m_timer = 0f;
				this.m_open = !this.m_open;
				this.m_enabled = false;
				if (this.m_open)
				{
					Singleton<AudioManager>.Instance.SpawnOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.umbrellaOpen, base.transform.position);
				}
				else
				{
					Singleton<AudioManager>.Instance.SpawnOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.umbrellaClose, base.transform.position);
				}
			}
		}
	}

	protected override void OnTouch()
	{
		if (!this.m_isConnected && !this.m_enabled)
		{
			return;
		}
		this.SetEnabled(!this.m_enabled);
	}

	public override void SetEnabled(bool enabled)
	{
		this.m_enabled = enabled;
	}

	private void Open(bool open)
	{
		if (this.m_open != open)
		{
			this.m_open = open;
			if (open)
			{
				this.m_openSprite.GetComponent<Renderer>().enabled = true;
				this.m_openSprite.GetComponent<Collider>().enabled = true;
				this.m_openSprite.GetComponent<Collider>().isTrigger = false;
				this.m_visualization.transform.localPosition = this.m_openPosition;
			}
			else
			{
				this.m_openSprite.GetComponent<Renderer>().enabled = false;
				this.m_openSprite.GetComponent<Collider>().enabled = false;
				this.m_openSprite.GetComponent<Collider>().isTrigger = true;
				this.m_visualization.transform.localPosition = this.m_closedPosition;
			}
		}
	}

	public float m_force;

	public bool m_enabled;

	private float m_maximumForce;

	private GameObject m_visualization;

	private GameObject m_openSprite;

	private bool m_open = true;

	private float m_timer;

	private float m_moveTime = 0.25f;

	private Vector3 m_closedPosition;

	private Vector3 m_openPosition;

	private bool m_isConnected;

	private const float MinScale = 0.4f;

	private float MaxScale = 1f;
}
