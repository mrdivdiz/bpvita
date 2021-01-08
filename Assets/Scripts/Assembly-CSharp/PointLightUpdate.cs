using UnityEngine;

public class PointLightUpdate : MonoBehaviour
{
	private void Start()
	{
		if (LightManager.Instance != null)
		{
			LightManager.Instance.UpdateLights(true);
		}
	}
}
