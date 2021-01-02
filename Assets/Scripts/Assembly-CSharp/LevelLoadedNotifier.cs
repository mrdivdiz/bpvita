using System;
using UnityEngine;

public class LevelLoadedNotifier : MonoBehaviour
{
	public static event Action OnLevelLoaded;

	private void Start()
	{
		LevelLoadedNotifier.OnLevelLoaded();
		UnityEngine.Object.Destroy(base.gameObject);
	}

	// Note: this type is marked as 'beforefieldinit'.
	static LevelLoadedNotifier()
	{
		LevelLoadedNotifier.OnLevelLoaded = delegate()
		{
		};
	}
}
