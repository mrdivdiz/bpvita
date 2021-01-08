using UnityEngine;

public class Widget : MonoBehaviour
{
	public virtual void SetListener(WidgetListener listener)
	{
	}

	public void SendInput(InputEvent input)
	{
		if (base.transform.parent && base.transform.parent.GetComponent<Widget>())
		{
			base.transform.parent.GetComponent<Widget>().SendInput(input);
		}
		this.OnInput(input);
	}

	public void Activate()
	{
		if (base.transform.parent && base.transform.parent.GetComponent<Widget>())
		{
			base.transform.parent.GetComponent<Widget>().Activate();
		}
		this.OnActivate();
	}

	public void Release()
	{
		if (base.transform.parent && base.transform.parent.GetComponent<Widget>())
		{
			base.transform.parent.GetComponent<Widget>().Release();
		}
		this.OnRelease();
	}

	public virtual bool AllowMultitouch()
	{
		return false;
	}

	public virtual void Select()
	{
	}

	public virtual void Deselect()
	{
	}

	protected virtual void OnInput(InputEvent input)
	{
	}

	protected virtual void OnActivate()
	{
	}

	protected virtual void OnRelease()
	{
	}
}
