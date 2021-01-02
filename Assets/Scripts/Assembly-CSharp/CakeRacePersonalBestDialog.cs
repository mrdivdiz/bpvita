using CakeRace;
using UnityEngine;

public class CakeRacePersonalBestDialog : WPFMonoBehaviour
{
	private void Start()
	{
		if (!(WPFMonoBehaviour.levelManager.CurrentGameMode is CakeRaceMode))
		{
			base.gameObject.SetActive(false);
		}
	}

	private void OnEnable()
	{
		if (!(WPFMonoBehaviour.levelManager.CurrentGameMode is CakeRaceMode))
		{
			return;
		}
		this.SetScore((WPFMonoBehaviour.levelManager.CurrentGameMode as CakeRaceMode).PersonalBest());
	}

	private void SetScore(CakeRaceReplay replay)
	{
		if (replay == null)
		{
			for (int i = 0; i < this.cakes.Length; i++)
			{
				this.cakes[i].SetActive(false);
			}
			this.score.text = "-";
			this.kingsFavorite.SetActive(false);
		}
		else
		{
			for (int j = 0; j < this.cakes.Length; j++)
			{
				this.cakes[j].SetActive(replay.CakesCollected > j);
			}
			this.score.text = string.Format("{0:N0}", CakeRaceReplay.TotalScore(replay));
			this.kingsFavorite.SetActive(replay.HasKingsFavoritePart);
		}
	}

	private void OnUIEvent(UIEvent data)
	{
		if (!(WPFMonoBehaviour.levelManager.CurrentGameMode is CakeRaceMode))
		{
			return;
		}
		switch (data.type)
		{
		case UIEvent.Type.Building:
		case UIEvent.Type.Play:
		case UIEvent.Type.Pause:
			base.gameObject.SetActive(false);
			break;
		case UIEvent.Type.Preview:
			this.SetScore((WPFMonoBehaviour.levelManager.CurrentGameMode as CakeRaceMode).PersonalBest());
			base.gameObject.SetActive(true);
			break;
		}
	}

	[SerializeField]
	private GameObject[] cakes;

	[SerializeField]
	private TextMesh score;

	[SerializeField]
	private GameObject kingsFavorite;
}
