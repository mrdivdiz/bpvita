public class CollectBoxAchievement : WPFMonoBehaviour
{
	private void Awake()
	{
		UnityEngine.Object.Destroy(base.gameObject);
	}

	public string boxToCollect;

	public string achievementId;
}
