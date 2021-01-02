using System.Collections;
using UnityEngine;

public class SnoutCoinSingle : WPFMonoBehaviour
{
	public static void Spawn(Vector3 position, float delay = 0f)
	{
		if (SnoutCoinSingle.snoutCoinSinglePrefab == null)
		{
			SnoutCoinSingle.snoutCoinSinglePrefab = Resources.Load<GameObject>("UI/SnoutCoinSingle");
		}
		if (SnoutCoinSingle.snoutCoinSinglePrefab == null)
		{
			return;
		}
		if (delay > 0.01f)
		{
			CoroutineRunner.Instance.StartCoroutine(SnoutCoinSingle.SpawnDelay(position, delay));
			return;
		}
		UnityEngine.Object.Instantiate<GameObject>(SnoutCoinSingle.snoutCoinSinglePrefab, position, Quaternion.identity);
	}

	private static IEnumerator SpawnDelay(Vector3 position, float delay)
	{
		yield return new WaitForSeconds(delay);
		SnoutCoinSingle.Spawn(position, 0f);
		yield break;
	}

	private void Start()
	{
		Singleton<AudioManager>.Instance.SpawnOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.snoutCoinHit, Vector3.zero);
	}

	private void Update()
	{
		this.lifeTime -= Time.deltaTime;
		base.transform.position += Vector3.up * this.speed * Time.deltaTime;
		base.transform.localScale = Vector3.Lerp(Vector3.one * 0.01f, Vector3.one, Mathf.Clamp01(this.lifeTime * 2f));
		if (this.lifeTime <= 0f)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private const string snoutCoinSinglePrefabPath = "UI/SnoutCoinSingle";

	private static GameObject snoutCoinSinglePrefab;

	[SerializeField]
	private float lifeTime = 2f;

	[SerializeField]
	private float speed = 2f;
}
