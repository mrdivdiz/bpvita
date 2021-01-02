using System.Collections;
using UnityEngine;

public class TimedHide : MonoBehaviour
{
	public void Show()
	{
		base.GetComponent<Renderer>().enabled = true;
		base.StartCoroutine(this.HideCountdown());
	}

	private void Start()
	{
		base.StartCoroutine(this.HideCountdown());
	}

	private IEnumerator HideCountdown()
	{
		yield return new WaitForSeconds(this.lifeTime);
		base.GetComponent<Renderer>().enabled = false;
		yield break;
	}

	[SerializeField]
	private float lifeTime = 1f;
}
