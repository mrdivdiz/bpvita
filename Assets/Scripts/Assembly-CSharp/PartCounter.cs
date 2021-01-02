using System;
using UnityEngine;

public class PartCounter : MonoBehaviour
{
	private void Awake()
	{
		this.m_textMesh = base.GetComponent<TextMesh>();
		if (((Singleton<BuildCustomizationLoader>.Instance.IsHDVersion && Singleton<BuildCustomizationLoader>.Instance.CustomerID.Equals("amazon")) || (Singleton<BuildCustomizationLoader>.Instance.IsHDVersion && Singleton<BuildCustomizationLoader>.Instance.CustomerID.Equals("nook"))) && Screen.width > 1024)
		{
			this.m_textMesh.GetComponent<Renderer>().material.shader = Shader.Find("_Custom/Unlit_Alpha8Bit_Color");
		}
		EventManager.Connect<PartCountChanged>(new EventManager.OnEvent<PartCountChanged>(this.ReceivePartCountChangedEvent));
	}

	private void OnDestroy()
	{
		EventManager.Disconnect<PartCountChanged>(new EventManager.OnEvent<PartCountChanged>(this.ReceivePartCountChangedEvent));
	}

	private void ReceivePartCountChangedEvent(PartCountChanged data)
	{
		if (data.partType == this.m_partType)
		{
			this.m_textMesh.text = data.count.ToString();
			GameObject icon = base.transform.parent.GetComponent<DraggableButton>().Icon;
			if (icon)
			{
				Renderer[] componentsInChildren = icon.GetComponentsInChildren<Renderer>();
				if (componentsInChildren != null)
				{
					for (int i = 0; i < componentsInChildren.Length; i++)
					{
						componentsInChildren[i].sharedMaterial = this.GetAtlasMaterial(componentsInChildren[i].sharedMaterial, data.count);
					}
				}
			}
		}
	}

	private Material GetAtlasMaterial(Material currentAtlasMaterial, int index)
	{
		int num = 0;
		if (currentAtlasMaterial != null)
		{
			if (currentAtlasMaterial.name.StartsWith("IngameAtlas2"))
			{
				num = 1;
			}
			else if (currentAtlasMaterial.name.StartsWith("IngameAtlas3"))
			{
				num = 2;
			}
		}
		Material result;
		if (index == 0)
		{
			if (num == 0)
			{
				result = base.transform.parent.GetComponent<Renderer>().sharedMaterials[1];
			}
			else
			{
				result = AtlasMaterials.Instance.GrayMaterials[num];
			}
		}
		else if (num == 0)
		{
			result = base.transform.parent.GetComponent<Renderer>().sharedMaterials[0];
		}
		else
		{
			result = AtlasMaterials.Instance.RenderQueueMaterials[num];
		}
		return result;
	}

	public BasePart.PartType m_partType;

	private TextMesh m_textMesh;
}
