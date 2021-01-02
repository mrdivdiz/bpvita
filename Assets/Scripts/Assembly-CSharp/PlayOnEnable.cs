using UnityEngine;

public class PlayOnEnable : MonoBehaviour
{
	private void OnEnable()
	{
		if (base.GetComponent<Animation>() && !string.IsNullOrEmpty(this.animName))
		{
			base.GetComponent<Animation>().Play(this.animName);
		}
		if (base.GetComponent<ParticleSystem>())
		{
			base.GetComponent<ParticleSystem>().Play();
		}
		if (this.soundEffect2d)
		{
			Singleton<AudioManager>.Instance.Play2dEffect(this.soundEffect2d);
		}
	}

	public string animName;

	public AudioSource soundEffect2d;
}
