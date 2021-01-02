using UnityEngine;

public class HUD : WPFMonoBehaviour
{
	private void Start()
	{
		if (WPFMonoBehaviour.gameData.m_blueprintPrefab)
		{
			Transform transform = UnityEngine.Object.Instantiate<Transform>(WPFMonoBehaviour.gameData.m_blueprintPrefab, WPFMonoBehaviour.levelManager.StartingPosition, Quaternion.identity);
			transform.name = "BlueprintUI";
			transform.parent = WPFMonoBehaviour.levelManager.transform;
			if (WPFMonoBehaviour.levelManager.m_blueprintTexture)
			{
				transform.GetComponent<GUITexture>().texture = WPFMonoBehaviour.levelManager.m_blueprintTexture;
			}
		}
	}
}
