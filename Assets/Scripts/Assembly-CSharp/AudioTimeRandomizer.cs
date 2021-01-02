using System.Collections;
using UnityEngine;

public class AudioTimeRandomizer : MonoBehaviour
{
	private void Start()
	{
		this.baseAudioSource = base.GetComponent<AudioSource>();
		this.audioManager = Singleton<AudioManager>.Instance;
		base.StartCoroutine(this.SpawnAudios());
	}

	private void OnDestroy()
	{
		this.doRandomize = false;
	}

	private IEnumerator SpawnAudios()
	{
		while (this.doRandomize)
		{
			yield return new WaitForSeconds(UnityEngine.Random.Range(this.minDelay, this.maxDelay));
			if (this.is3DSound)
			{
				this.audioManager.SpawnOneShotEffect(this.baseAudioSource, base.transform);
			}
			else
			{
				this.audioManager.Play2dEffect(this.baseAudioSource);
			}
		}
		yield break;
	}

	[SerializeField]
	private float minDelay = 1f;

	[SerializeField]
	private float maxDelay = 2f;

	[SerializeField]
	private bool is3DSound;

	private AudioSource baseAudioSource;

	private AudioManager audioManager;

	private bool doRandomize = true;
}
