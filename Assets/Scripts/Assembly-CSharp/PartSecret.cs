using UnityEngine;

public class PartSecret : MonoBehaviour
{
	private void Awake()
	{
		if (GameProgress.GetBool(this.key, false, GameProgress.Location.Local, null))
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private void Start()
	{
		if (this.gameCamera == null)
		{
			this.gameCamera = WPFMonoBehaviour.mainCamera;
		}
	}

	private void Update()
	{
		if (this.gameCamera == null)
		{
			return;
		}
		Vector3 position = Vector3.zero;
		bool flag = false;
		for (int i = 0; i < Input.touchCount; i++)
		{
			Touch touch = Input.GetTouch(i);
			if (touch.phase == TouchPhase.Began)
			{
				position = touch.position;
				flag = true;
			}
		}
		if (Input.GetMouseButtonDown(0))
		{
			position = Input.mousePosition;
			flag = true;
		}
		if (!flag)
		{
			return;
		}
		Ray ray = this.gameCamera.ScreenPointToRay(position);
		int layerMask = 1 << LayerMask.NameToLayer("Default");
		RaycastHit raycastHit;
		if (Physics.Raycast(ray, out raycastHit, 3.40282347E+38f, layerMask) && raycastHit.transform == base.transform)
		{
			if (this.onTapAnimation)
			{
				this.onTapAnimation.Play();
			}
			this.secretTapCount--;
			if (this.secretTapCount == 0)
			{
				this.SetSecret();
			}
		}
	}

	public void SetSecret()
	{
		GameProgress.SetBool(this.key, true, GameProgress.Location.Local);
		UnityEngine.Debug.Log(this.key + " set");
		this.Collect();
	}

	private void Collect()
	{
		if (this.partToUnlock != null)
		{
			CustomizationManager.UnlockPart(this.partToUnlock, "secret");
		}
		if (this.collectEffect != null)
		{
			this.collectEffect.Emit(5);
		}
		MeshRenderer[] componentsInChildren = base.GetComponentsInChildren<MeshRenderer>();
		if (componentsInChildren != null && componentsInChildren.Length > 0)
		{
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].enabled = false;
			}
		}
	}

	public Camera gameCamera;

	public string key = "Secret";

	public int secretTapCount = 3;

	public BasePart partToUnlock;

	public Animation onTapAnimation;

	public ParticleSystem collectEffect;
}
