using CakeRace;
using UnityEngine;

public class CakeRaceReplayEntry : MonoBehaviour
{
	private void Awake()
	{
		Transform transform = base.transform.Find("TrackLabel");
		if (transform != null)
		{
			this.trackLabel = transform.GetComponentsInChildren<TextMesh>();
		}
		transform = base.transform.Find("ScoreLabel");
		if (transform != null)
		{
			this.scoreLabel = transform.GetComponentsInChildren<TextMesh>();
		}
		transform = base.transform.Find("KingsFavorite/KingsFavoriteActive");
		if (transform != null)
		{
			this.kingsFavoriteIcon = transform.GetComponent<Renderer>();
		}
		transform = base.transform.Find("CakeGrid");
		if (transform != null)
		{
			this.cakes = new Renderer[5];
			for (int i = 0; i < 5; i++)
			{
				string name = string.Format("Cake{0}", i + 1);
				Transform transform2 = transform.Find(name);
				if (transform2 != null)
				{
					this.cakes[i] = transform2.GetComponent<Renderer>();
				}
			}
		}
	}

	public void SetDialog(LeaderboardDialog parentDialog)
	{
		this.dialog = parentDialog;
	}

	public void SetInfo(int track, CakeRaceReplay replay)
	{
		if (replay == null || !replay.IsValid)
		{
			this.SetInfo(track, 0, 0, false);
			return;
		}
		int score = CakeRaceReplay.TotalScore(replay);
		int num = replay.GetCollectedCakeCount();
		if (replay.GetCakeCollectTime(-1) >= 0)
		{
			num--;
		}
		this.SetInfo(track, score, num, replay.HasKingsFavoritePart);
	}

	public void SetInfo(int track, int score, int cakeCount, bool kingsFavorite)
	{
		TextMeshHelper.UpdateTextMeshes(this.trackLabel, string.Format("{0}", track + 1), false);
		TextMeshHelper.UpdateTextMeshes(this.scoreLabel, (score > 0) ? string.Format("{0:n0}", score) : "-", false);
		this.kingsFavoriteIcon.enabled = kingsFavorite;
		for (int i = 0; i < this.cakes.Length; i++)
		{
			this.cakes[i].enabled = (i < cakeCount);
		}
	}

	private LeaderboardDialog dialog;

	private TextMesh[] trackLabel;

	private TextMesh[] scoreLabel;

	private Renderer[] cakes;

	private Renderer kingsFavoriteIcon;
}
