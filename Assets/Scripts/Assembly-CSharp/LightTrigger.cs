using UnityEngine;

public class LightTrigger : MonoBehaviour
{
	public PointLightSource LightSource
	{
		get
		{
			return this.pls;
		}
	}

	public void Init(PointLightSource pls)
	{
		this.pls = pls;
	}

	private void Start()
	{
		this.cachedTransform = base.transform;
	}

	private void Update()
	{
		this.cachedTransform.position += Vector3.zero;
	}

	private void OnTriggerEnter(Collider c)
	{
		if (this.pls == null)
		{
			return;
		}
		if (this.pls.lightType == PointLightMask.LightType.PointLight && this.pls.canLitObjects && this.pls.isEnabled)
		{
			c.SendMessageUpwards("Lit", SendMessageOptions.DontRequireReceiver);
		}
	}

	private void OnTriggerStay(Collider c)
	{
		if (this.pls == null)
		{
			return;
		}
		if (this.pls.lightType == PointLightMask.LightType.PointLight && this.pls.canLitObjects && this.pls.isEnabled)
		{
			c.SendMessage("Lit", SendMessageOptions.DontRequireReceiver);
		}
		else if (this.pls.lightType == PointLightMask.LightType.BeamLight && this.pls.canLitObjects && this.pls.isEnabled)
		{
			float beamAngle = this.pls.beamAngle;
			Vector3 a = Vector3.up * c.transform.position.y + Vector3.right * c.transform.position.x;
			Vector3 b = Vector3.up * base.transform.position.y + Vector3.right * base.transform.position.x;
			Vector3 from = a - b;
			float num = Vector3.Angle(from, this.pls.transform.up);
			float num2 = Vector3.Distance(a, b);
			if (num2 <= this.pls.baseLightSize + this.pls.borderWidth || num < beamAngle * 0.5f)
			{
				c.SendMessageUpwards("Lit", SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	public void Lit()
	{
		if (this.pls != null && !this.pls.isEnabled && this.pls.canBeLit)
		{
			this.pls.isEnabled = true;
		}
	}

	private PointLightSource pls;

	private Transform cachedTransform;
}
