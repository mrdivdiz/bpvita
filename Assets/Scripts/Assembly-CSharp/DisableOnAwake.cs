using UnityEngine;

public class DisableOnAwake : MonoBehaviour
{
	private void Awake()
	{
		base.gameObject.SetActive(false);
	}
}
