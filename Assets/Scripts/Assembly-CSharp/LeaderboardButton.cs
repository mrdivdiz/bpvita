using UnityEngine;

public class LeaderboardButton : MonoBehaviour
{
	public void OpenLeaderboardDialog()
	{
		if (this.leaderboardDialogPrefab == null)
		{
			return;
		}
		if (this.leaderboardDialog == null)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.leaderboardDialogPrefab, 15f * Vector3.back + Vector3.down, Quaternion.identity);
			this.leaderboardDialog = gameObject.GetComponent<LeaderboardDialog>();
		}
		this.leaderboardDialog.Open();
	}

	[SerializeField]
	private GameObject leaderboardDialogPrefab;

	private LeaderboardDialog leaderboardDialog;
}
