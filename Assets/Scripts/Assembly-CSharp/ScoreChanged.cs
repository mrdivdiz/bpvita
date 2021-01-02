using UnityEngine;

public struct ScoreChanged : EventManager.Event
{
	public ScoreChanged(Vector3 scoreFloaterPosition)
	{
		this.scoreFloaterPosition = scoreFloaterPosition;
	}

	public Vector3 scoreFloaterPosition;
}
