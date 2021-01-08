using UnityEngine;

public class BroadCaster : MonoBehaviour
{
	private void Start()
	{
	}

	public void OpenToons()
	{
		GameObject gameObject = GameObject.Find("MainMenuLogic");
		if (gameObject != null)
		{
			gameObject.BroadcastMessage("OpenToons");
		}
		base.gameObject.BroadcastMessage("Close");
	}

	private void Update()
	{
	}
}
