using System.Collections.Generic;
using UnityEngine;

public class ButtonGrid : MonoBehaviour
{
	public void AddButton(Button button)
	{
		this.buttons.Add(button.gameObject);
	}

	public void Clear()
	{
		foreach (GameObject obj in this.buttons)
		{
			UnityEngine.Object.Destroy(obj);
		}
		this.buttons.Clear();
	}

	private void OnDrawGizmos()
	{
		if (this.buttonPrefab)
		{
			this.PlaceButtons(ButtonGrid.Action.DrawGizmos);
		}
	}

	private void PlaceButtons(Action action)
	{
		int num = 0;
		Vector3 position = base.transform.position;
		position.x -= 0.5f * ((float)(this.horizontalCount - 1) * this.offset.x);
		position.y -= 0.5f * this.buttonPrefab.GetComponent<Sprite>().Size.y;
		Vector3 vector = position;
		int num2 = this.count;
		if (action == ButtonGrid.Action.Place)
		{
			num2 = this.buttons.Count;
		}
		for (int i = 0; i < num2; i++)
		{
			if (action == ButtonGrid.Action.Place)
			{
				this.buttons[i].transform.position = vector;
			}
			else
			{
				Gizmos.DrawWireCube(vector, this.buttonPrefab.GetComponent<Sprite>().Size);
			}
			vector.x += this.offset.x;
			num++;
			if (num >= this.horizontalCount)
			{
				num = 0;
				vector.x = position.x;
				vector.y -= this.offset.y;
			}
		}
	}

	public GameObject buttonPrefab;

	public int horizontalCount = 5;

	public Vector2 offset = new Vector2(10f, 10f);

	public int count = 20;

	private List<GameObject> buttons = new List<GameObject>();

	private enum Action
	{
		Place,
		DrawGizmos
	}
}
