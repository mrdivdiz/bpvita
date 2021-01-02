public struct LoadLevelEvent : EventManager.Event
{
	public LoadLevelEvent(GameManager.GameState currentGameState, GameManager.GameState nextGameState, string levelName)
	{
		this.currentGameState = currentGameState;
		this.nextGameState = nextGameState;
		this.levelName = levelName;
	}

	public GameManager.GameState currentGameState;

	public GameManager.GameState nextGameState;

	public string levelName;
}
