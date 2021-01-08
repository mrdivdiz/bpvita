using System.Collections.Generic;
using UnityEngine;

public class GadgetButtonList : MonoBehaviour
{
	public List<GadgetButton> Buttons
	{
		get
		{
			return this.m_buttons;
		}
	}

	private void Start()
	{
		if (this.m_buttons.Count > 0)
		{
			this.m_spriteSize = this.m_buttons[0].GetComponent<Sprite>().Size;
		}
	}

	public void Sort(IComparer<GadgetButton> comparer)
	{
		this.m_buttons.Sort(comparer);
		this.PlaceButtons((float)Screen.width, (float)Screen.height);
	}

	private void Update()
	{
		if (this.m_screenWidth != (float)Screen.width || this.m_screenHeight != (float)Screen.height)
		{
			this.PlaceButtons((float)Screen.width, (float)Screen.height);
			this.m_screenWidth = (float)Screen.width;
			this.m_screenHeight = (float)Screen.height;
		}
	}

	private void PlaceButtons(float screenWidth, float screenHeight)
	{
		int num = 0;
		for (int i = 0; i < this.m_buttons.Count; i++)
		{
			if (this.m_buttons[i].Enabled)
			{
				num++;
			}
		}
		float num2 = this.m_spriteSize.x + this.m_spacing;
		Vector3 vector = base.transform.position - 0.5f * ((float)(num - 1) * num2) * Vector3.right;
		float num3 = 1f;
		float num4 = vector.x - base.transform.position.x;
		float num5 = 10f * screenWidth / screenHeight - 0.5f * num2;
		if (num4 < -num5)
		{
			num2 = this.m_spriteSize.x + 0.25f * this.m_spacing;
			num4 = (base.transform.position - 0.5f * ((float)(num - 1) * num2) * Vector3.right).x - base.transform.position.x;
			num5 = 10f * screenWidth / screenHeight - 0.5f * num2;
		}
		if (num4 < -num5)
		{
			num3 = -num5 / num4;
			base.transform.localScale = new Vector3(num3, 1f, 1f);
		}
		else
		{
			base.transform.localScale = Vector3.one;
		}
		vector = base.transform.position - num3 * (0.5f * ((float)(num - 1) * num2) * Vector3.right);
		num2 *= num3;
		for (int j = 0; j < this.m_buttons.Count; j++)
		{
			if (this.m_buttons[j].Enabled)
			{
				this.m_buttons[j].transform.position = vector;
				vector += num2 * Vector3.right;
			}
		}
	}

	[SerializeField]
	private float m_spacing = 1f;

	[SerializeField]
	private List<GadgetButton> m_buttons;

	private Vector2 m_spriteSize;

	private float m_screenWidth;

	private float m_screenHeight;

	public class NameComparer : IComparer<GameObject>
	{
		public int Compare(GameObject obj1, GameObject obj2)
		{
			return string.Compare(obj1.name, obj2.name);
		}
	}
}
