using System;
using UnityEngine;

public class GoldenPig : BasePart
{
	public override bool CanBeEnclosed()
	{
		return true;
	}

	public override void Initialize()
	{
		base.rigidbody.drag = 0.5f;
		base.rigidbody.angularDrag = 1f;
		if (!this.loopingRollingSound)
		{
			this.loopingRollingSound = Singleton<AudioManager>.Instance.SpawnLoopingEffect(WPFMonoBehaviour.gameData.commonAudioCollection.goldenPigRoll, base.transform).GetComponent<AudioSource>();
		}
		this.loopingRollingSound.volume = 0f;
		this.loopingRollingSound.Play();
	}

	private void Update()
	{
		this.UpdateSoundEffect();
	}

	protected override void UpdateSoundEffect()
	{
		if (!this.loopingRollingSound)
		{
			return;
		}
		this.targetVolume = ((!this.m_isOnGround) ? 0f : (Mathf.Clamp01(base.rigidbody.velocity.magnitude) / 1f));
		this.loopingRollingSound.volume = Mathf.Lerp(this.loopingRollingSound.volume, this.targetVolume, Time.deltaTime * 5f);
	}

	private AudioSource loopingRollingSound;

	private float targetVolume;
}
