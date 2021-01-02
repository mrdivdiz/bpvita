using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class PointLightSource : MonoBehaviour
{
	public bool isEnabled
	{
		get
		{
			return this._isEnabled;
		}
		set
		{
			this._isEnabled = value;
			if (this._isEnabled)
			{
				this.ResetLayer();
			}
			this.Toggle();
		}
	}

	public void Init()
	{
		this.lightTransform.localPosition = ((!this.isEnabled) ? new Vector3(this.lightTransform.localPosition.x, this.lightTransform.localPosition.y, -100f) : new Vector3(this.lightTransform.localPosition.x, this.lightTransform.localPosition.y, 0f));
		if (this.baseLightTransform)
		{
			this.baseLightTransform.localPosition = ((!this.isEnabled) ? new Vector3(this.baseLightTransform.localPosition.x, this.baseLightTransform.localPosition.y, -100f) : new Vector3(this.baseLightTransform.localPosition.x, this.baseLightTransform.localPosition.y, 0f));
		}
		if (!this.canCollide)
		{
			return;
		}
		this.lt = base.GetComponentInChildren<LightTrigger>();
		if (this.lt == null)
		{
			GameObject gameObject = new GameObject(base.transform.name + "_LightCollider");
			gameObject.transform.parent = base.transform;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localRotation = Quaternion.identity;
			gameObject.layer = LayerMask.NameToLayer("Light");
			if (gameObject.GetComponent<Rigidbody>() == null && base.gameObject.isStatic && this.canCollide)
			{
				gameObject.AddComponent<Rigidbody>();
				gameObject.GetComponent<Rigidbody>().isKinematic = true;
				gameObject.GetComponent<Rigidbody>().useGravity = false;
			}
			if (this.lightType == PointLightMask.LightType.PointLight)
			{
				this.sphereCollider = gameObject.AddComponent<SphereCollider>();
				this.sphereCollider.radius = ((!this.isEnabled) ? this.minColliderSize : this.colliderSize);
				this.sphereCollider.isTrigger = true;
			}
			else if (this.lightType == PointLightMask.LightType.BeamLight)
			{
				this.sphereCollider = gameObject.AddComponent<SphereCollider>();
				this.sphereCollider.radius = ((!this.isEnabled) ? this.minColliderSize : this.colliderSize);
				this.sphereCollider.isTrigger = true;
				this.sphereCollider.center = Vector3.up * this.beamArcCenter.y;
				this.sphereCollider2 = gameObject.AddComponent<SphereCollider>();
				this.sphereCollider2.radius = ((!this.isEnabled) ? this.minColliderSize : (this.size / 2f));
				this.sphereCollider2.isTrigger = true;
				this.sphereCollider2.center = Vector3.up * (this.size / 2f);
				this.baseLightCollider = gameObject.AddComponent<SphereCollider>();
				this.baseLightCollider.radius = ((!this.isEnabled) ? this.minColliderSize : (this.baseLightSize + 0.5f));
				this.baseLightCollider.isTrigger = true;
				this.baseLightCollider.center = Vector3.zero;
			}
			this.lt = gameObject.AddComponent<LightTrigger>();
			this.lt.Init(this);
		}
		else
		{
			if (this.lightType == PointLightMask.LightType.PointLight)
			{
				this.sphereCollider = this.lt.gameObject.GetComponent<SphereCollider>();
				this.sphereCollider.radius = ((!this.isEnabled) ? this.minColliderSize : this.colliderSize);
				this.sphereCollider.isTrigger = true;
				this.sphereCollider.gameObject.layer = LayerMask.NameToLayer("Light");
			}
			else if (this.lightType == PointLightMask.LightType.BeamLight)
			{
				SphereCollider[] components = this.lt.gameObject.GetComponents<SphereCollider>();
				this.sphereCollider = components[0];
				this.sphereCollider2 = components[1];
				this.baseLightCollider = components[2];
				this.sphereCollider.radius = ((!this.isEnabled) ? this.minColliderSize : this.colliderSize);
				this.sphereCollider.isTrigger = true;
				this.sphereCollider.center = this.beamArcCenter;
				this.sphereCollider2.radius = ((!this.isEnabled) ? this.minColliderSize : (this.size / 2f));
				this.sphereCollider2.isTrigger = true;
				this.sphereCollider2.center = Vector3.up * (this.size / 2f);
				this.baseLightCollider.radius = ((!this.isEnabled) ? this.minColliderSize : (this.baseLightSize + 0.5f));
				this.baseLightCollider.isTrigger = true;
				this.baseLightCollider.center = Vector3.zero;
			}
			this.lt.Init(this);
		}
		this.RefreshColliderSizes(this.isEnabled);
	}

	private void RefreshColliderSizes(bool _enabled)
	{
		if (!this.canCollide)
		{
			return;
		}
		if (this.lightType == PointLightMask.LightType.PointLight)
		{
			if (this.sphereCollider != null)
			{
				this.sphereCollider.radius = ((!_enabled) ? this.minColliderSize : this.colliderSize);
			}
		}
		else if (this.lightType == PointLightMask.LightType.BeamLight)
		{
			if (this.sphereCollider != null)
			{
				this.sphereCollider.radius = ((!_enabled) ? this.minColliderSize : this.colliderSize);
			}
			if (this.sphereCollider2 != null)
			{
				this.sphereCollider2.radius = ((!_enabled) ? this.minColliderSize : (this.size / 2f));
			}
			if (this.baseLightCollider != null)
			{
				this.baseLightCollider.radius = ((!_enabled) ? this.minColliderSize : (this.baseLightSize + 0.5f));
			}
			if (!this.canBeLit)
			{
				if (this.sphereCollider != null)
				{
					this.sphereCollider.enabled = _enabled;
				}
				if (this.sphereCollider2 != null)
				{
					this.sphereCollider2.enabled = _enabled;
				}
				if (this.baseLightCollider != null)
				{
					this.baseLightCollider.enabled = _enabled;
				}
			}
		}
	}

	private void ResetLayer()
	{
		if (this.sphereCollider != null)
		{
			this.sphereCollider.gameObject.layer = LayerMask.NameToLayer("Light");
		}
	}

	private void Toggle()
	{
		if (this.lightTransform != null)
		{
			base.StartCoroutine(this.LitSequence());
		}
	}

	private IEnumerator LitSequence()
	{
		float duration = 0f;
		if (this.isEnabled)
		{
			duration = this.turnOnCurve[this.turnOnCurve.length - 1].time;
			this.lightTransform.localPosition = new Vector3(this.lightTransform.localPosition.x, this.lightTransform.localPosition.y, 0f);
			if (this.baseLightTransform)
			{
				this.baseLightTransform.localPosition = new Vector3(this.baseLightTransform.localPosition.x, this.baseLightTransform.localPosition.y, 0f);
			}
		}
		else
		{
			duration = this.turnOffCurve[this.turnOffCurve.length - 1].time;
		}
		this.RefreshColliderSizes(!this.isEnabled);
		float timer = 0f;
		if (this.canCollide && this.sphereCollider == null)
		{
			UnityEngine.Debug.LogWarning(base.transform.name + " collider is NULL");
		}
		while (this.usesCurves && timer < duration)
		{
			float fade = 1f;
			if (this._isEnabled)
			{
				fade = this.turnOnCurve.Evaluate(timer);
			}
			else
			{
				fade = this.turnOffCurve.Evaluate(timer);
			}
			if (this.lightType == PointLightMask.LightType.PointLight)
			{
				this.lightTransform.localScale = Vector3.up * fade * this.size + Vector3.right * fade * this.size;
				if (this.sphereCollider != null)
				{
					this.sphereCollider.radius = fade * this.colliderSize;
				}
			}
			else
			{
				this.lightTransform.localScale = Vector3.up * fade + Vector3.right * fade;
				this.baseLightTransform.localScale = Vector3.up * fade * this.baseLightSize + Vector3.right * fade * this.baseLightSize;
				if (this.sphereCollider != null)
				{
					this.sphereCollider.radius = fade * this.colliderSize;
				}
				if (this.sphereCollider2 != null)
				{
					this.sphereCollider2.radius = fade * (this.size / 2f);
				}
				if (this.baseLightCollider != null)
				{
					this.baseLightCollider.radius = fade * (this.baseLightSize + 0.5f);
				}
			}
			if (this.lt)
			{
				this.lt.transform.position += Vector3.zero;
			}
			timer += Time.deltaTime;
			yield return null;
		}
		if (this.lightType == PointLightMask.LightType.PointLight)
		{
			this.lightTransform.localScale = Vector3.up * this.size + Vector3.right * this.size;
		}
		else
		{
			this.lightTransform.localScale = Vector3.up + Vector3.right;
			this.baseLightTransform.localScale = Vector3.up * this.baseLightSize + Vector3.right * this.baseLightSize;
		}
		this.RefreshColliderSizes(this.isEnabled);
		if (!this.isEnabled)
		{
			this.lightTransform.localPosition = new Vector3(this.lightTransform.localPosition.x, this.lightTransform.localPosition.y, -100f);
			if (this.baseLightTransform)
			{
				this.baseLightTransform.localPosition = new Vector3(this.baseLightTransform.localPosition.x, this.baseLightTransform.localPosition.y, 100f);
			}
			if (this.onLightTurnOff != null)
			{
				this.onLightTurnOff();
			}
		}
		else if (this.isEnabled && this.onLightTurnOn != null)
		{
			this.onLightTurnOn();
		}
		yield break;
	}

	private void OnDrawGizmos()
	{
		if (this.lightType == PointLightMask.LightType.PointLight)
		{
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireSphere(base.transform.position, this.size + this.borderWidth);
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(base.transform.position, this.minColliderSize);
		}
		else if (this.lightType == PointLightMask.LightType.BeamLight)
		{
			Gizmos.color = Color.white;
			Vector3 a = Quaternion.AngleAxis(0f - this.beamAngle / 2f, base.transform.forward) * base.transform.up;
			Vector3 a2 = Quaternion.AngleAxis(this.beamAngle - this.beamAngle / 2f, base.transform.forward) * base.transform.up;
			Gizmos.DrawLine(base.transform.position, base.transform.position + a * this.size);
			Gizmos.DrawLine(base.transform.position, base.transform.position + a2 * this.size);
			Gizmos.color = Color.green;
			float num = this.beamAngle * 0.6f;
			a = Quaternion.AngleAxis(0f - num, base.transform.forward) * base.transform.up;
			a2 = Quaternion.AngleAxis(num * 2f - num, base.transform.forward) * base.transform.up;
			Gizmos.DrawLine(base.transform.position, base.transform.position + a * this.size);
			Gizmos.DrawLine(base.transform.position, base.transform.position + a2 * this.size);
		}
	}

	public PointLightMask.LightType lightType;

	public float size = 1f;

	public float borderWidth = 0.3f;

	[HideInInspector]
	public float beamAngle = 45f;

	[HideInInspector]
	public float beamCut = 0.5f;

	public int vertexCount = 100;

	[HideInInspector]
	public float colliderSize;

	[HideInInspector]
	public Vector3 beamArcCenter;

	public Transform lightTransform;

	[HideInInspector]
	public Transform baseLightTransform;

	[HideInInspector]
	public float baseLightSize = 0.5f;

	public AnimationCurve turnOnCurve = AnimationCurve.Linear(0f, 0f, 0.3f, 1f);

	public AnimationCurve turnOffCurve = AnimationCurve.Linear(0f, 1f, 0.3f, 0f);

	public Action onLightTurnOff;

	public Action onLightTurnOn;

	[HideInInspector]
	[SerializeField]
	private bool _isEnabled;

	[SerializeField]
	private float minColliderSize = 0.2f;

	public bool canLitObjects;

	public bool canCollide;

	public bool canBeLit;

	public bool usesCurves = true;

	private SphereCollider sphereCollider;

	private SphereCollider sphereCollider2;

	private SphereCollider baseLightCollider;

	private LightTrigger lt;
}
