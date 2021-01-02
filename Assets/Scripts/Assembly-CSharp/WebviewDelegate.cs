using UnityEngine;

public class WebviewDelegate : MonoBehaviour
{
	public virtual void webViewDidFinishLoad(string pageTitle)
	{
	}

	public virtual void webViewDidFail(string errorCode)
	{
	}
}
