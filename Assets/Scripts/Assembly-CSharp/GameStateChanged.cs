public struct GameStateChanged : EventManager.Event
{
	public GameStateChanged(LevelManager.GameState state, LevelManager.GameState prevState)
	{
		this.state = state;
		this.prevState = prevState;
	}

	public LevelManager.GameState state;

	public LevelManager.GameState prevState;
}
