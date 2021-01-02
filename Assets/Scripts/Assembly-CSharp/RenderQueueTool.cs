using UnityEngine;

[ExecuteInEditMode]
public class RenderQueueTool : MonoBehaviour
{
	private void Awake()
	{
		this.mr = base.GetComponent<Renderer>();
	}

	private void Update()
	{
		if (this.mr == null)
		{
			this.Awake();
		}
		else
		{
			this.renderQueue = this.mr.sharedMaterial.renderQueue;
			if (this.setNewValue)
			{
				this.mr.sharedMaterial.renderQueue = this.newValue;
				this.setNewValue = false;
			}
		}
	}

	public int renderQueue;

	public int newValue = -1;

	public bool setNewValue;

	private Renderer mr;
}
