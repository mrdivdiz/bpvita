using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PositionSerializer : ExportAction
{
	private void OnDataLoaded()
	{
		if (base.transform.childCount != this.prefab.transform.childCount)
		{
			for (int i = 0; i < this.prefab.transform.childCount; i++)
			{
				GameObject gameObject = this.prefab.transform.GetChild(i).gameObject;
				GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(gameObject);
				gameObject2.transform.parent = base.transform;
				if (this.childLocalPositions.Count >= this.prefab.transform.childCount)
				{
					gameObject2.transform.localPosition = this.childLocalPositions[i];
				}
			}
		}
	}

	public void DestroyChildren()
	{
		for (int i = base.transform.childCount - 1; i >= 0; i--)
		{
			UnityEngine.Object.DestroyImmediate(base.transform.GetChild(i).gameObject);
		}
	}

	public override void StartActions()
	{
		if (base.transform.childCount == 0)
		{
			return;
		}
		this.DestroyChildren();
	}

	public override void EndActions()
	{
		this.OnDataLoaded();
	}

	public void SavePositions()
	{
		this.childLocalPositions = new List<Vector3>();
		for (int i = 0; i < base.transform.childCount; i++)
		{
			Vector3 localPosition = base.transform.GetChild(i).localPosition;
			this.childLocalPositions.Add(localPosition);
		}
	}

	public GameObject prefab;

	[HideInInspector]
	[SerializeField]
	private GameObject prefabCache;

	[SerializeField]
	private List<Vector3> childLocalPositions;
}
