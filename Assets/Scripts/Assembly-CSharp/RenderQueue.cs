using UnityEngine;

[ExecuteInEditMode]
public class RenderQueue : WPFMonoBehaviour
{
	private void Awake()
	{
		if (base.renderer)
		{
			this.renderQueue = base.renderer.sharedMaterial.renderQueue;
		}
	}

	private void Update()
	{
		if (base.renderer && this.setNow)
		{
			base.renderer.sharedMaterial.renderQueue = this.renderQueue;
			this.setNow = false;
		}
	}

	public int renderQueue;

	public bool setNow;
}
