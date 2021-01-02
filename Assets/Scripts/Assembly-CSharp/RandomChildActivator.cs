using System.Collections.Generic;
using UnityEngine;

public class RandomChildActivator : MonoBehaviour
{
	public GameObject ActivateChild()
	{
		if (this.children == null || this.children.Count == 0 || RandomChildActivator.indexToActivate > this.children.Count - 1)
		{
			return null;
		}
		GameObject result = null;
		for (int i = 0; i < this.children.Count; i++)
		{
			if (i == RandomChildActivator.indexToActivate)
			{
				this.children[i].SetActive(true);
				result = this.children[i];
			}
			else
			{
				this.children[i].SetActive(false);
			}
		}
		return result;
	}

	[ContextMenu("Random")]
	private void Rand()
	{
		RandomChildActivator.indexToActivate = UnityEngine.Random.Range(0, this.children.Count);
	}

	public List<GameObject> children;

	public static int indexToActivate;
}
