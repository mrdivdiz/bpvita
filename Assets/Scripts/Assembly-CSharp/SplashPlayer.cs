using System.Collections;
using UnityEngine;

public class SplashPlayer : MonoBehaviour
{
	private IEnumerator Start()
	{
        UnityEngine.Object.Instantiate<GameObject>(this.singletonSpawnerPrefab);
		while (!SingletonSpawner.SpawnDone)
		{
			yield return null;
		}
		this.StartSplash();
		yield break;
	}

	private void StartSplash()
	{
		string arg;
		arg = "iPad";
		SplashScreenSequence original = Resources.Load<SplashScreenSequence>(string.Format("Splashes/Sequences/SplashSequence_{0}", arg));
		UnityEngine.Object.Instantiate<SplashScreenSequence>(original);
	}

	[SerializeField]
	private GameObject singletonSpawnerPrefab;
}
