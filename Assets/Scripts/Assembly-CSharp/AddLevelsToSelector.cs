using UnityEngine;

public class AddLevelsToSelector : MonoBehaviour
{
	private void Awake()
	{
		LevelSelector component = GameObject.Find("LevelSelector").GetComponent<LevelSelector>();
		component.Levels = this.m_episodeLevels.LevelInfos;
	}

	public Episode m_episodeLevels;
}
