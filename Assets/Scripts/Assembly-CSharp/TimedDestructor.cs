using System.Collections;
using UnityEngine;

public class TimedDestructor : MonoBehaviour
{
	private void Start()
	{
		base.StartCoroutine(this.DoDestroyCountdown());
	}

	private IEnumerator DoDestroyCountdown()
	{
		yield return new WaitForSeconds(this.lifeTime);
		UnityEngine.Object.Destroy(base.gameObject);
		yield break;
	}

	[SerializeField]
	private float lifeTime = 1f;
}
