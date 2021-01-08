using UnityEngine;

public class PitchRandomizer : AudioFX
{
	protected override void ProcessAudio()
	{
		base.ProcessAudio();
		Mathf.Clamp(this.m_pitchMin, -3f, this.m_pitchMax);
		Mathf.Clamp(this.m_pitchMax, this.m_pitchMin, 3f);
		base.GetComponent<AudioSource>().pitch = UnityEngine.Random.Range(this.m_pitchMin, this.m_pitchMax);
	}

	public float m_pitchMin;

	public float m_pitchMax;
}
