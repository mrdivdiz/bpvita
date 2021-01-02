using UnityEngine;

public class LevelUnloadNotifier : MonoBehaviour
{
	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
		if (Singleton<GameManager>.Instance != null)
		{
			Singleton<GameManager>.Instance.OnLevelUnloading();
		}
	}
}
