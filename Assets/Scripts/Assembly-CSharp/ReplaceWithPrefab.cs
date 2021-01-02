using UnityEngine;

public class ReplaceWithPrefab : MonoBehaviour
{
	private void Awake()
	{
		if (this.prefab == null)
		{
			return;
		}
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.prefab);
		gameObject.transform.parent = base.transform.parent;
		gameObject.transform.localPosition = base.transform.localPosition;
		gameObject.transform.localRotation = base.transform.localRotation;
		gameObject.transform.localScale = base.transform.localScale;
		UnityEngine.Object.Destroy(base.gameObject);
	}

	public GameObject prefab;
}
