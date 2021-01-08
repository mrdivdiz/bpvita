using UnityEngine;

public class ResourceBarItem : WPFMonoBehaviour
{
	public float Width
	{
		get
		{
			return this.paddingLeft + this.paddingRight;
		}
	}

	public float PaddingLeft
	{
		get
		{
			return this.paddingLeft;
		}
	}

	public float PaddingRight
	{
		get
		{
			return this.paddingRight;
		}
	}

	public bool IsShowing
	{
		get
		{
			return this.show;
		}
	}

	public bool IsEnabled { get; private set; }

	public void SetItem(bool show, bool enable)
	{
		this.show = show;
		this.IsEnabled = enable;
		base.transform.localPosition = Vector3.right * base.transform.localPosition.x + Vector3.up * ((!show) ? 3f : 0f);
		if (this.enabledObjects != null)
		{
			this.enabledObjects.SetActive(enable);
		}
		if (base.collider != null)
		{
			base.collider.enabled = enable;
		}
		if (show)
		{
			base.SendMessage("OnShowButton", base.gameObject, SendMessageOptions.DontRequireReceiver);
		}
		else
		{
			base.SendMessage("OnHideButton", base.gameObject, SendMessageOptions.DontRequireReceiver);
		}
		if (enable)
		{
			base.SendMessage("OnEnableButton", base.gameObject, SendMessageOptions.DontRequireReceiver);
		}
		else
		{
			base.SendMessage("OnDisableButton", base.gameObject, SendMessageOptions.DontRequireReceiver);
		}
		this.isInit = true;
	}

	public void SetHorizontalPosition(float horizontalPosition)
	{
		base.transform.localPosition = new Vector3(horizontalPosition, base.transform.localPosition.y, base.transform.localPosition.z);
	}

	private void OnDrawGizmos()
	{
		if (base.transform != null)
		{
			Gizmos.color = Color.white;
			float d = this.paddingRight - this.paddingLeft;
			Gizmos.DrawWireCube(base.transform.position + Vector3.right * d * 0.5f, Vector3.right * this.Width + Vector3.up * 2f);
		}
	}

	[SerializeField]
	private GameObject enabledObjects;

	[SerializeField]
	private float paddingLeft;

	[SerializeField]
	private float paddingRight;

	private bool show = true;

	private Vector3 targetPosition = Vector3.zero;

	private bool isInit;
}
