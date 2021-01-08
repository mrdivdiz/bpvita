using UnityEngine;

public class LevelSelectorUnlockButton : MonoBehaviour
{
	private void Update()
	{
		float x = GameObject.Find("LevelSelector").GetComponent<LevelSelector>().UnlockFullVersionButtonX();
		Vector3 localPosition = base.transform.localPosition;
		localPosition.x = x;
		base.transform.localPosition = localPosition;
	}

	private void Start()
	{
		if (this.m_pulseIfLevelCompleted != 0 && LevelInfo.IsLevelCompleted(Singleton<GameManager>.Instance.CurrentEpisodeIndex, this.m_pulseIfLevelCompleted - 1))
		{
			EventManager.Send(new PulseButtonEvent(UIEvent.Type.OpenUnlockFullVersionIapMenu, true));
		}
	}

	public int m_pulseIfLevelCompleted;
}
