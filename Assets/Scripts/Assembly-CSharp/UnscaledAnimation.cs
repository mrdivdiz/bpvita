using UnityEngine;

public class UnscaledAnimation : MonoBehaviour
{
	private void Update()
	{
		if (this.animation.isPlaying && Time.timeScale != 1f)
		{
			this.animation[this.animation.clip.name].time = (this.time += Time.unscaledDeltaTime);
			this.animation.Sample();
		}
		if (this.animation[this.animation.clip.name].time > this.animation.clip.length)
		{
			this.animation.Stop();
			this.time = 0f;
		}
	}

	[SerializeField]
	private Animation animation;

	private bool playing;

	private float time;
}
