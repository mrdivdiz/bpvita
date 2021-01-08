using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(AudioSource))]
public class AudioArea : MonoBehaviour
{
	private void Start()
	{
		this.boxCollider = base.GetComponent<BoxCollider>();
		this.areaAudioSource = base.GetComponent<AudioSource>();
		this.audioManager = Singleton<AudioManager>.Instance;
	}

	private bool CheckTriggerType(ref Collider other)
	{
		return (this.triggeringType == AudioArea.TriggeringType.AudioListener && other.GetComponent<AudioListener>()) || (this.triggeringType == AudioArea.TriggeringType.Pig && other.GetComponent<Pig>());
	}

	private void OnTriggerEnter(Collider other)
	{
		if (this.CheckTriggerType(ref other) && !this.areaAudioSource.isPlaying)
		{
			if (this.areaAudioSource.loop)
			{
				this.audioManager.PlayLoopingEffect(ref this.areaAudioSource);
			}
			else
			{
				this.audioManager.Play2dEffect(this.areaAudioSource);
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (this.CheckTriggerType(ref other) && this.areaAudioSource.isPlaying && this.areaAudioSource.loop)
		{
			this.audioManager.StopLoopingEffect(this.areaAudioSource);
		}
	}

	private void OnDrawGizmos()
	{
		if (!this.boxCollider)
		{
			this.boxCollider = base.GetComponent<BoxCollider>();
		}
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireCube(base.transform.position, this.boxCollider.bounds.size);
	}

	[SerializeField]
	private TriggeringType triggeringType;

	private BoxCollider boxCollider;

	private AudioSource areaAudioSource;

	private AudioManager audioManager;

	private enum TriggeringType
	{
		Pig,
		AudioListener
	}
}
