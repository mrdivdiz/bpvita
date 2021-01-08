using System.Collections;
using UnityEngine;

public class Star : WPFMonoBehaviour
{
	private void OnTriggerEnter(Collider col)
	{
		this.CheckTrigger(col.transform);
	}

	private void CheckTrigger(Transform t)
	{
		if (!(t.tag == "Contraption") || this.m_isTriggered)
		{
			if (t.parent)
			{
				this.CheckTrigger(t.parent);
			}
			return;
		}
		BasePart component = t.GetComponent<BasePart>();
		if ((component != null && (component.m_partType == BasePart.PartType.Balloon || component.m_partType == BasePart.PartType.Balloons2 || component.m_partType == BasePart.PartType.Balloons3)) || Vector3.Distance(t.position, WPFMonoBehaviour.levelManager.ContraptionRunning.m_cameraTarget.transform.position) > 2f)
		{
			return;
		}
		this.m_isTriggered = true;
		base.StartCoroutine(this.PlayAnimation());
	}

	public IEnumerator PlayAnimation()
	{
		Singleton<AudioManager>.Instance.Play2dEffect(WPFMonoBehaviour.gameData.commonAudioCollection.goalBoxCollected);
		float timer = 1f;
		while (timer > 0f)
		{
			base.transform.localScale += Vector3.one * 0.1f * Mathf.Pow(timer, 2f);
			base.transform.position += Vector3.up * 0.1f * Mathf.Pow(timer, 2f);
			timer -= 0.03f;
			yield return new WaitForSeconds(0.03f);
		}
		base.gameObject.GetComponent<Renderer>().enabled = false;
		GameObject particles = UnityEngine.Object.Instantiate<GameObject>(WPFMonoBehaviour.gameData.m_particles, base.transform.position, Quaternion.identity);
		yield return new WaitForSeconds(1.5f);
		WPFMonoBehaviour.levelManager.NotifyStarCollected();
		UnityEngine.Object.Destroy(particles);
		UnityEngine.Object.Destroy(base.gameObject);
		yield break;
	}

	protected bool m_isTriggered;
}
