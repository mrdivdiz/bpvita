using UnityEngine;

public class PlayBundleAudio : WPFMonoBehaviour
{
	private void Start()
	{
		if (this.playOnStart)
		{
			this.Play2dEffect();
		}
	}

	public void Play2dEffect()
	{
		AudioSource loadedAudioSource = WPFMonoBehaviour.gameData.commonAudioCollection.GetLoadedAudioSource(this.bundleAudio);
		if (loadedAudioSource != null)
		{
			Singleton<AudioManager>.Instance.Play2dEffect(loadedAudioSource);
		}
	}

	[SerializeField]
	private BundleDataObject bundleAudio;

	[SerializeField]
	private bool playOnStart;
}
