using UnityEngine;

public class GUITextureAspectFix : MonoBehaviour
{
	public void Awake()
	{
		this.m_origScale = base.transform.localScale;
		this.FixAspect();
	}

	public void LateUpdate()
	{
		this.FixAspect();
	}

	private void FixAspect()
	{
		GUITexture component = base.GetComponent<GUITexture>();
		Vector3 origScale = this.m_origScale;
		float num = (float)Screen.width / (float)Screen.height;
		float num2 = (float)component.texture.width / (float)component.texture.height;
		origScale.y *= num / num2;
		base.transform.localScale = origScale;
	}

	protected Vector3 m_origScale;
}
