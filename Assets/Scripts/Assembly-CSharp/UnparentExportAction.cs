using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class UnparentExportAction : ExportAction
{
	private void OnEnable()
	{
		base.gameObject.hideFlags = HideFlags.None;
	}

	public override void StartActions()
	{
		if (this.childObjects == null)
		{
			this.childObjects = new List<Transform>();
		}
		if (base.transform.parent == null)
		{
			this.childObjects = new List<Transform>();
			for (int i = 0; i < base.transform.childCount; i++)
			{
				this.childObjects.Add(base.transform.GetChild(i));
			}
			for (int j = 0; j < this.childObjects.Count; j++)
			{
				this.childObjects[j].parent = null;
			}
		}
		base.gameObject.hideFlags = HideFlags.HideAndDontSave;
	}

	public override void EndActions()
	{
		base.gameObject.hideFlags = HideFlags.None;
		if (this.childObjects != null)
		{
			for (int i = 0; i < this.childObjects.Count; i++)
			{
				this.childObjects[i].transform.parent = base.transform;
			}
		}
	}

	private List<Transform> childObjects;
}
