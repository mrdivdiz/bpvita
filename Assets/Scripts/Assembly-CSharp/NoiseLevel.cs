using UnityEngine;

public class NoiseLevel : MonoBehaviour
{
	public float Level
	{
		get
		{
			return this.noiseLevel * base.GetComponent<AudioSource>().volume / this.baseVolume;
		}
	}

	private void Awake()
	{
		this.baseVolume = base.GetComponent<AudioSource>().volume;
	}

	[SerializeField]
	private float noiseLevel;

	private float baseVolume;
}
