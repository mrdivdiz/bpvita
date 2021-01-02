using System.Collections;
using UnityEngine;

public class PigMask : MonoBehaviour
{
	private void Start()
	{
		if (base.transform.childCount > 0)
		{
			this.m_mask = base.transform.GetChild(0).gameObject;
		}
		if (this.m_mask == null && Singleton<GameManager>.IsInstantiated() && Singleton<GameManager>.Instance.GetGameState() == GameManager.GameState.Level && Singleton<GameManager>.Instance.CurrentEpisodeLabel.Equals("5"))
		{
			this.m_mask = UnityEngine.Object.Instantiate<GameObject>(this.m_masks[UnityEngine.Random.Range(0, this.m_masks.Length)], base.transform.position, base.transform.rotation);
			this.m_mask.transform.parent = base.transform;
		}
		if (this.m_mask != null && WPFMonoBehaviour.levelManager && WPFMonoBehaviour.levelManager.gameState == LevelManager.GameState.Running)
		{
			base.StartCoroutine(this.FlyAway());
		}
	}

	private IEnumerator FlyAway()
	{
		while (WPFMonoBehaviour.levelManager.TimeElapsed <= 0f)
		{
			yield return new WaitForSeconds(0.1f);
		}
		Vector3 lastPos = base.transform.position;
		float lastTime = Time.time;
		for (;;)
		{
			yield return new WaitForSeconds(0.1f);
			float now = Time.time;
			float delta = now - lastTime;
			float curSpeed = Vector3.Distance(base.transform.position, lastPos) / delta;
			if (curSpeed > this.m_speedThreshold)
			{
				break;
			}
			lastPos = base.transform.position;
			lastTime = now;
		}
		Transform vis = this.m_mask.transform.Find("Visualization");
		Quaternion visRot = vis.rotation;
		base.transform.parent = null;
		base.transform.localRotation = Quaternion.identity;
		vis.rotation = visRot;
		this.m_mask.GetComponent<Animation>().Play();
		yield return new WaitForSeconds(1.2f);
		UnityEngine.Object.Destroy(base.gameObject);
		yield break;
	}

	public GameObject[] m_masks;

	public float m_speedThreshold = 1f;

	private GameObject m_mask;
}
