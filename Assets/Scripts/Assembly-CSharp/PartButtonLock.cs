using UnityEngine;

public class PartButtonLock : MonoBehaviour
{
	private void OnEnable()
	{
		this.m_animation = base.GetComponent<Animation>();
		this.m_animation[base.GetComponent<Animation>().clip.name].time = this.m_time;
		this.m_animation.Play();
	}

	private void Update()
	{
		if (this.m_animation.isPlaying)
		{
			this.m_time = this.m_animation[this.m_animation.clip.name].time;
		}
	}

	private Animation m_animation;

	private float m_time;
}
