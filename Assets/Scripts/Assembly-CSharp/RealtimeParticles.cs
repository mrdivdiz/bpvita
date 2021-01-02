using UnityEngine;

public class RealtimeParticles : MonoBehaviour
{
	private void Awake()
	{
		this.ps = base.GetComponent<ParticleSystem>();
	}

	private void Update()
	{
		if (this.ps == null)
		{
			return;
		}
		if (Time.timeScale < 0.01f)
		{
			if (this.emitCount > 0 && this.lastEmitTime + this.emitInterval < Time.realtimeSinceStartup)
			{
				this.ps.Emit(this.emitCount);
				this.lastEmitTime = Time.realtimeSinceStartup;
			}
			if (this.ps.particleCount > 0)
			{
				this.ps.Simulate(Time.unscaledDeltaTime, true, false);
			}
		}
	}

	[SerializeField]
	private float emitInterval = 1f;

	[SerializeField]
	private int emitCount;

	private ParticleSystem ps;

	private float lastEmitTime;
}
