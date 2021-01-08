using System.Collections;
using UnityEngine;

public class SnoutCoinIntro : WPFMonoBehaviour
{
	private IEnumerator Start()
	{
		yield return new WaitForSeconds(1f);
		Singleton<AudioManager>.Instance.Play2dEffect(WPFMonoBehaviour.gameData.commonAudioCollection.snoutCoinIntro);
		yield break;
	}
}
