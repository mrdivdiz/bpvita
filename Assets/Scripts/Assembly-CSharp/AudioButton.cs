using UnityEngine;

public class AudioButton : MonoBehaviour
{
	private void OnEnable()
	{
		AudioManager.onAudioMuted += this.HandleAudioManageronAudioMuted;
		this.audioOffButton = base.transform.Find("AudioOffButton").gameObject;
		this.audioOnButton = base.transform.Find("AudioOnButton").gameObject;
		this.audioOnButton.SetActive(false);
		this.audioOffButton.SetActive(false);
		this.RefreshAudioButtonState();
	}

	private void OnDisable()
	{
		AudioManager.onAudioMuted -= this.HandleAudioManageronAudioMuted;
	}

	private void HandleAudioManageronAudioMuted(bool muted)
	{
		this.RefreshAudioButtonState();
	}

	private void RefreshAudioButtonState()
	{
		if (Singleton<AudioManager>.IsInstantiated() && Singleton<AudioManager>.Instance.AudioMuted)
		{
			this.audioOnButton.SetActive(false);
			this.audioOffButton.SetActive(true);
		}
		else
		{
			this.audioOffButton.SetActive(false);
			this.audioOnButton.SetActive(true);
		}
	}

	public void ToggleAudio()
	{
		Singleton<AudioManager>.Instance.ToggleMute();
		this.RefreshAudioButtonState();
	}

	private GameObject audioOffButton;

	private GameObject audioOnButton;
}
