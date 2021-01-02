public class GameLevelLoaded : EventManager.Event
{
	public GameLevelLoaded(int levelIndex, int episodeIndex)
	{
		this.levelIndex = levelIndex;
		this.episodeIndex = episodeIndex;
	}

	public int levelIndex;

	public int episodeIndex;
}
