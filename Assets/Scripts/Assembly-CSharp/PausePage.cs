using UnityEngine;

public class PausePage : MonoBehaviour
{
	private void OnEnable()
	{
		this.m_levelNumber = base.transform.Find("LevelNumber").GetComponent<TextMesh>();
		string currentLevelIdentifier = Singleton<GameManager>.Instance.CurrentLevelIdentifier;
		this.m_levelNumber.text = currentLevelIdentifier;
	}

	private TextMesh m_levelNumber;
}
