using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
	private void Awake()
	{
		Vector3 position = base.transform.position;
		position.z += -100f;
		foreach (GameObject gameObject in this.m_cameraPrefabs)
		{
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(gameObject);
			gameObject2.name = gameObject.name;
			gameObject2.transform.parent = base.transform;
			gameObject2.transform.position = position;
		}
	}

	public List<GameObject> m_cameraPrefabs;
}
