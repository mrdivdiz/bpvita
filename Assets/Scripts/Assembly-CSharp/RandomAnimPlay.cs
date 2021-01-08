using System.Collections;
using UnityEngine;

public class RandomAnimPlay : MonoBehaviour
{
	private void Start()
	{
		base.StartCoroutine(this.PlayAnimation());
	}

	private IEnumerator PlayAnimation()
	{
		for (;;)
		{
			yield return new WaitForSeconds(this.minTimeout + UnityEngine.Random.value * (this.maxTimeout - this.minTimeout));
			if (this.animationName != null && !base.GetComponent<Animation>().IsPlaying(this.animationName))
			{
				base.GetComponent<Animation>().Play(this.animationName);
			}
		}
		yield break;
	}

	public string animationName;

	public float minTimeout = 2f;

	public float maxTimeout = 5f;
}
