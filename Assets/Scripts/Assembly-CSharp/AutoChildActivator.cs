using System.Collections.Generic;
using UnityEngine;

public class AutoChildActivator : MonoBehaviour
{
	private void Awake()
	{
		this.ActivateChild((this.activatedChild >= 0) ? this.activatedChild : UnityEngine.Random.Range(0, this.children.Count));
	}

	private void ActivateChild(int childIndex)
	{
		if (this.children == null || this.children.Count == 0)
		{
			return;
		}
		for (int i = 0; i < this.children.Count; i++)
		{
			if (i == childIndex)
			{
				this.children[i].SetActive(true);
			}
			else
			{
				this.children[i].SetActive(false);
			}
		}
		this.activatedChild = childIndex;
	}

	private void LateUpdate()
	{
		if (this.persist)
		{
			this.ActivateChild(this.activatedChild);
		}
	}

	[SerializeField]
	private List<GameObject> children;

	[SerializeField]
	private bool persist;

	[SerializeField]
	[HideInInspector]
	private int activatedChild = -1;
}
