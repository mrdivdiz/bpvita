using UnityEngine;

public class CheatsToggle : MonoBehaviour
{
	private void Start()
	{
		this.toggleState = this.startState;
		for (int i = 0; i < this.cheats.Length; i++)
		{
			this.cheats[i].SetActive(this.startState);
		}
	}

	public void Toggle()
	{
		this.toggleState = !this.toggleState;
		for (int i = 0; i < this.cheats.Length; i++)
		{
			this.cheats[i].SetActive(this.toggleState);
		}
	}

	[SerializeField]
	private bool startState;

	[SerializeField]
	private GameObject[] cheats;

	private bool toggleState;
}
