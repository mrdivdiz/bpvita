using UnityEngine;

public class DestroyWhenNoAudioPlaying : MonoBehaviour
{
	private void Update()
	{
		if (!base.GetComponent<AudioSource>())
		{
			return;
		}
		if (!base.GetComponent<AudioSource>().isPlaying)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
