using UnityEngine;

public class UnscaledParticles : MonoBehaviour
{
	private void Awake()
	{
		if (this.particles == null)
		{
			this.particles = base.GetComponent<ParticleSystem>();
		}
	}

	private void Update()
	{
		if (Time.timeScale != 1f)
		{
			this.particles.Simulate(Time.unscaledDeltaTime, true, false);
		}
	}

	[SerializeField]
	private ParticleSystem particles;
}
