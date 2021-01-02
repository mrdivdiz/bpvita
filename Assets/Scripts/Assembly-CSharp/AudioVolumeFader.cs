using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioVolumeFader : MonoBehaviour
{
	private void Start()
	{
		this.fadeAudioSource = base.gameObject.GetComponent<AudioSource>();
		this.originalVolume = this.fadeAudioSource.volume;
		this.fadeStep = this.originalVolume / this.fadeTime;
		this.fadeAudioSource.volume = 0f;
	}

	public float FadeIn()
	{
		this.activeFade = AudioVolumeFader.ActiveFade.FadeIn;
		base.StartCoroutine(this.DoFadeIn());
		return this.fadeTime;
	}

	public float FadeOut()
	{
		this.activeFade = AudioVolumeFader.ActiveFade.FadeOut;
		base.StartCoroutine(this.DoFadeOut());
		return this.fadeTime;
	}

	private IEnumerator DoFadeOut()
	{
		while (this.activeFade == AudioVolumeFader.ActiveFade.FadeIn)
		{
			yield return new WaitForEndOfFrame();
		}
		this.activeFade = AudioVolumeFader.ActiveFade.FadeOut;
		float linearVolume = this.fadeAudioSource.volume;
		while (linearVolume > 0f && this.activeFade != AudioVolumeFader.ActiveFade.FadeIn)
		{
			linearVolume -= this.fadeStep * Time.deltaTime;
			linearVolume = Mathf.Clamp(linearVolume, 0f, this.originalVolume);
			this.fadeAudioSource.volume = linearVolume;
			yield return new WaitForEndOfFrame();
		}
		this.activeFade = AudioVolumeFader.ActiveFade.NoFade;
		yield break;
	}

	private IEnumerator DoFadeIn()
	{
		while (this.activeFade == AudioVolumeFader.ActiveFade.FadeOut)
		{
			yield return new WaitForEndOfFrame();
		}
		this.activeFade = AudioVolumeFader.ActiveFade.FadeIn;
		float linearVolume = this.fadeAudioSource.volume;
		while (linearVolume < this.originalVolume && this.activeFade != AudioVolumeFader.ActiveFade.FadeOut)
		{
			linearVolume += this.fadeStep * Time.deltaTime;
			linearVolume = Mathf.Clamp(linearVolume, 0f, this.originalVolume);
			this.fadeAudioSource.volume = linearVolume;
			yield return new WaitForEndOfFrame();
		}
		this.activeFade = AudioVolumeFader.ActiveFade.NoFade;
		yield break;
	}

	[SerializeField]
	private float fadeTime = 1f;

	private float originalVolume = 1f;

	private float fadeStep = 1f;

	private AudioSource fadeAudioSource;

	private const float FadeCoefficient = 2.5f;

	private ActiveFade activeFade;

	private enum ActiveFade
	{
		NoFade,
		FadeOut,
		FadeIn
	}
}
