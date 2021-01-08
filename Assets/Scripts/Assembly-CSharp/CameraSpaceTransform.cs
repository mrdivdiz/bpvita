using UnityEngine;

public class CameraSpaceTransform : MonoBehaviour
{
	public void Start()
	{
		if (GameObject.Find("3dPropsCamera"))
		{
			this.sourceCamera = GameObject.Find("GameCamera").GetComponent<Camera>();
			this.targetCamera = GameObject.Find("3dPropsCamera").GetComponent<Camera>();
			this.proxyTransform = base.transform;
			this.targetTransform = base.transform.Find("RotatingMap").transform;
			if (this.targetTransform && this.targetTransform.gameObject && this.targetTransform.gameObject.GetComponentInChildren<MeshRenderer>())
			{
				this.proxyTransform.gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
				this.targetTransform.gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
			}
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private void LateUpdate()
	{
		this.Start();
		this.targetTransform.position = this.targetCamera.ScreenToWorldPoint(this.sourceCamera.WorldToScreenPoint(this.proxyTransform.position));
		Vector3 b = this.targetCamera.ScreenToWorldPoint(this.sourceCamera.WorldToScreenPoint(this.proxyTransform.position + Vector3.right));
		float num = Vector3.Distance(this.targetTransform.position, b) * 0.1f;
		this.targetTransform.localScale = new Vector3(num, num, num);
	}

	private Camera sourceCamera;

	private Camera targetCamera;

	private Transform proxyTransform;

	private Transform targetTransform;

	private const float SizeCorrectionFactor = 0.1f;
}
