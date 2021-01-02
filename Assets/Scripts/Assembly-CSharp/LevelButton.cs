using UnityEngine;

public class LevelButton : MonoBehaviour
{
	public string OnLevelButtonClicked()
	{
		return this.levelName;
	}

	private void Start()
	{
		if (this.levelName == string.Empty)
		{
			base.GetComponent<Renderer>().material.SetColor("_TintColor", Color.black);
			base.GetComponent<Animation>().enabled = false;
		}
	}

	[SerializeField]
	private string levelName = string.Empty;
}
