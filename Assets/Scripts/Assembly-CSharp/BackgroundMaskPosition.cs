using UnityEngine;

public class BackgroundMaskPosition : MonoBehaviour
{
	private void OnEnable()
	{
		BackgroundMask.Show(true, this, this.sortingLayerName, base.transform, Vector3.zero, false);
	}

	private void OnDisable()
	{
		BackgroundMask.Show(false, this, string.Empty, null, default(Vector3), false);
	}

	[SerializeField]
	private string sortingLayerName = "Default";
}
