using UnityEngine;

public class AudioFX : MonoBehaviour
{
	public virtual void Awake()
	{
		if (this.type == AudioFX.FXType.Preprocess)
		{
			this.ProcessAudio();
		}
	}

	public virtual void Update()
	{
		if (this.type == AudioFX.FXType.Continuous)
		{
			this.ProcessAudio();
		}
	}

	protected virtual void ProcessAudio()
	{
		if (base.GetComponent<AudioSource>() == null)
		{
			return;
		}
	}

	[SerializeField]
	protected FXType type;

	public enum FXType
	{
		Preprocess,
		Continuous
	}
}
