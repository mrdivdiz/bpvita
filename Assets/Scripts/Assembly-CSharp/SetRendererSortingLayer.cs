using UnityEngine;

[ExecuteInEditMode]
public class SetRendererSortingLayer : MonoBehaviour
{
	private void OnEnable()
	{
		base.GetComponent<Renderer>().sortingLayerName = this.sortingLayerName;
		base.GetComponent<Renderer>().sortingOrder = this.sortingOrder;
	}

	[SerializeField]
	private string sortingLayerName = string.Empty;

	[SerializeField]
	private int sortingOrder;
}
