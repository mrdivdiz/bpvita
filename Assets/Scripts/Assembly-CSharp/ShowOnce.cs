using UnityEngine;

public class ShowOnce : MonoBehaviour
{
	private void Awake()
	{
		string text = "show_count_" + this.key;
		int @int = GameProgress.GetInt(text, 0, GameProgress.Location.Local, null);
		if (@int >= this.showTimes)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		GameProgress.SetInt(text, @int + 1, GameProgress.Location.Local);
	}

	public string key = string.Empty;

	private int showTimes = 1;
}
