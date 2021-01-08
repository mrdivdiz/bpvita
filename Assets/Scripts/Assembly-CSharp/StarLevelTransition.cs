using UnityEngine;

public class StarLevelTransition : MonoBehaviour
{
	private void LoadLevel()
	{
		if (!this.m_loading)
		{
			this.m_loading = true;
			Singleton<GameManager>.Instance.LoadStarLevelAfterTransition();
		}
	}

	private void Start()
	{
		GameObject ambientCave = Singleton<GameManager>.Instance.gameData.commonAudioCollection.AmbientCave;
		Singleton<AudioManager>.Instance.Play2dEffect(ambientCave.GetComponent<AudioSource>());
	}

	private void Update()
	{
		this.m_skipTimer += Time.deltaTime;
		if (GuiManager.GetPointer().up && !this.m_skip && this.m_skipTimer > 1f)
		{
			this.m_skip = true;
			this.LoadLevel();
		}
	}

	private bool m_skip;

	private bool m_loading;

	private float m_skipTimer;
}
