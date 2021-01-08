using UnityEngine;

public class HUDLayer : MonoBehaviour
{
	public float GetDepth()
	{
		return this.FindDepth(base.transform, base.transform.position.z);
	}

	private float FindDepth(Transform obj, float parentDepth)
	{
		float num = parentDepth - obj.localPosition.z;
		float num2 = num;
		for (int i = 0; i < obj.childCount; i++)
		{
			float num3 = this.FindDepth(obj.GetChild(i), num);
			if (num3 > num2)
			{
				num2 = num3;
			}
		}
		return num2;
	}

	private void OnEnable()
	{
		Singleton<GuiManager>.Instance.AddLayer(this);
	}

	private void OnDisable()
	{
		Singleton<GuiManager>.Instance.RemoveLayer(this);
	}
}
