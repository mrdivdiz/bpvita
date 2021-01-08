using UnityEngine;

public class BoxingGlove : MonoBehaviour
{
	private void OnCollisionEnter(Collision coll)
	{
		if (!BoxingGlove.suckerPunchReported && Singleton<SocialGameManager>.IsInstantiated() && coll.collider.gameObject.GetComponent<KingPig>())
		{
			BoxingGlove.suckerPunchReported = true;
			Singleton<SocialGameManager>.Instance.ReportAchievementProgress("grp.SUCKER_PUNCH", 100.0);
		}
	}

	private static bool suckerPunchReported;
}
