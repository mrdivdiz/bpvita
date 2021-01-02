using UnityEngine;

public class ProgressResetButton : MonoBehaviour
{
	private void OnGUI()
	{
		if ((Singleton<BuildCustomizationLoader>.Instance.CheatsEnabled || Singleton<BuildCustomizationLoader>.Instance.LessCheats) && GUI.Button(new Rect(0f, 80f, 120f, 100f), "Open Cheats"))
		{
			Singleton<GameManager>.Instance.LoadCheatsPanel();
		}
	}
}
