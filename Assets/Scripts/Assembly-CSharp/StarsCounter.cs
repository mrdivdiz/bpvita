using UnityEngine;

public class StarsCounter : WPFMonoBehaviour
{
	private void Awake()
	{
		StarBox.onCollected += this.BoxCollected;
		PartBox.onCollected += this.BoxCollected;
		this.starsCounterText = base.transform.Find("AnimationNode/StarsCounter").GetComponent<TextMesh>();
		this.starsCounterTextShadow = base.transform.Find("AnimationNode/StarsCounter/StarsCounterShadow").GetComponent<TextMesh>();
		if (WPFMonoBehaviour.levelManager.m_sandbox)
		{
			SandboxLevels.LevelData levelData = WPFMonoBehaviour.gameData.m_sandboxLevels.GetLevelData(Singleton<GameManager>.Instance.CurrentLevelIdentifier);
			this.maxStars = ((levelData == null) ? "20" : levelData.m_starBoxCount.ToString());
		}
		this.UpdateBoxCount();
	}

	private void OnDestroy()
	{
		StarBox.onCollected -= this.BoxCollected;
		PartBox.onCollected -= this.BoxCollected;
	}

	private void UpdateBoxCount()
	{
		int num = GameProgress.SandboxStarCount(Singleton<GameManager>.Instance.CurrentSceneName);
		this.starsCounterText.text = ((num >= 10) ? (num + "/" + this.maxStars) : string.Concat(new object[]
		{
			"0",
			num,
			"/",
			this.maxStars
		}));
		this.starsCounterTextShadow.text = this.starsCounterText.text;
	}

	private void BoxCollected()
	{
		this.UpdateBoxCount();
		base.transform.Find("AnimationNode").GetComponent<Animation>().Play();
		base.transform.Find("StarburstEffect").GetComponent<ParticleSystem>().Play();
	}

	private void OnEnable()
	{
		base.gameObject.SetActive(WPFMonoBehaviour.levelManager.m_sandbox);
	}

	private TextMesh starsCounterTextShadow;

	private TextMesh starsCounterText;

	private string maxStars;
}
