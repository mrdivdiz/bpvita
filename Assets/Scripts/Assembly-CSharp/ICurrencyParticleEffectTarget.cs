using UnityEngine;

public interface ICurrencyParticleEffectTarget
{
	void CurrencyParticleAdded(int amount = 1);

	void UpdateAmount(bool force = false);

	AudioSource[] GetHitSounds();

	AudioSource[] GetFlySounds();
}
