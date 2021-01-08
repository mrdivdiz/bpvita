using System;
using System.Collections.Generic;
using UnityEngine;

public class SingletonSpawner : MonoBehaviour
{
	public static bool SpawnDone
	{
		get
		{
			return SingletonSpawner.spawnDone;
		}
	}

	private void Awake()
	{
		this.Initialize();
	}

	private void Initialize()
	{
		if (SingletonSpawner.spawnDone)
		{
			return;
		}
		Application.targetFrameRate = 60;
		foreach (GameObject gameObject in this.m_commonSingletons)
		{
			if (!GameObject.Find(gameObject.name))
			{
				GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(gameObject);
				gameObject2.name = gameObject.name;
				gameObject2.SetActive(true);
			}
		}
		this.SpawnPlatformSingletons();
		SingletonSpawner.spawnDone = true;
	}

	private void SpawnPlatformSingletons()
	{
		foreach (PlatformSingleton platformSingleton in this.m_platformSingletons)
		{
            if (platformSingleton.platforms.Contains(DeviceInfo.ActiveDeviceFamily) && !GameObject.Find(platformSingleton.singleton.name))
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(platformSingleton.singleton);
				gameObject.name = platformSingleton.singleton.name;
				gameObject.SetActive(true);
			}
		}
	}

	private void OnEnable()
	{
	}

	[SerializeField]
	private List<PlatformSingleton> m_platformSingletons;

	[SerializeField]
	private List<GameObject> m_commonSingletons;

	private static bool spawnDone;

	[Serializable]
	public class PlatformSingleton
	{
		public List<DeviceInfo.DeviceFamily> platforms = new List<DeviceInfo.DeviceFamily>();

		public GameObject singleton;
	}
}
