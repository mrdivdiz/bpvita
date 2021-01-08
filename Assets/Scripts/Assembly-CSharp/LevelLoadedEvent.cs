public struct LevelLoadedEvent : EventManager.Event
{
	public LevelLoadedEvent(GameManager.GameState currentGameState)
	{
		this.currentGameState = currentGameState;
	}

	public GameManager.GameState currentGameState;
}
