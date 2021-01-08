using UnityEngine;

public static class LayerHelper
{
	public static void SetSortingLayer(GameObject go, string layer, bool children)
	{
		Renderer[] components = go.GetComponents<Renderer>();
		for (int i = 0; i < components.Length; i++)
		{
			components[i].sortingLayerName = layer;
		}
		if (children)
		{
			for (int j = 0; j < go.transform.childCount; j++)
			{
				LayerHelper.SetSortingLayer(go.transform.GetChild(j).gameObject, layer, children);
			}
		}
	}

	public static void SetOrderInLayer(GameObject go, int order, bool children)
	{
		Renderer[] components = go.GetComponents<Renderer>();
		for (int i = 0; i < components.Length; i++)
		{
			components[i].sortingOrder = order;
		}
		if (children)
		{
			for (int j = 0; j < go.transform.childCount; j++)
			{
				LayerHelper.SetOrderInLayer(go.transform.GetChild(j).gameObject, order, children);
			}
		}
	}

	public static void SetLayer(GameObject go, int layer, bool children)
	{
		go.layer = layer;
		if (children)
		{
			for (int i = 0; i < go.transform.childCount; i++)
			{
				LayerHelper.SetLayer(go.transform.GetChild(i).gameObject, layer, children);
			}
		}
	}
}
