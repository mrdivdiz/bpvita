using UnityEngine;

public class AreaAchievement : MonoBehaviour
{
	private void Awake()
	{
		UnityEngine.Object.Destroy(base.gameObject);
	}

	public string achievementId;
}
