using UnityEngine;

public class Cork : WPFMonoBehaviour
{
	public void Fly(Vector3 velocity, float rotation, float lifetime)
	{
		this.velocity = velocity;
		this.rotation = rotation;
		this.lifetime = lifetime;
		this.flying = true;
		Singleton<AudioManager>.Instance.SpawnOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.bottleCork, base.transform.position);
	}

	private void Update()
	{
		if (this.flying)
		{
			base.transform.position += Time.deltaTime * (this.velocity + Time.deltaTime * 9.81f * Vector3.down);
			base.transform.rotation *= Quaternion.AngleAxis(Time.deltaTime * this.rotation, Vector3.forward);
			this.lifetime -= Time.deltaTime;
			if (this.lifetime <= 0f)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
	}

	private bool flying;

	private Vector3 velocity;

	private float lifetime;

	private float rotation;
}
