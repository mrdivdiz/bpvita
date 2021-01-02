using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowLayout : MonoBehaviour
{
	private void Start()
	{
		this.Layout();
	}

	public void removeButton(GameObject button)
	{
		this.m_order.Remove(button);
		UnityEngine.Object.Destroy(button);
	}

	public void Layout()
	{
		Vector3 b = FlowLayout.GetDirectionVector(this.m_direction) * this.m_gap;
		Vector3 vector = Vector3.zero;
		if (this.m_direction == FlowLayout.Direction.CenterHorizontal)
		{
            int num = 0;
            foreach (GameObject x in this.m_order)
            {
                if (x.activeSelf)
                {
                    num++;
                }
            }
			vector.x = (float)(-(float)(num - 1)) * this.m_gap / 2f;
		}
		else if (this.m_direction == FlowLayout.Direction.CenterVertical)
		{
			int num2 = 0;
            foreach (GameObject x in this.m_order)
            {
                if (x.activeSelf)
                {
                    num2++;
                }
            }
            vector.y = (float)(num2 - 1) * this.m_gap / 2f;
		}
		foreach (GameObject gameObject in this.m_order)
		{
			if (gameObject.activeSelf)
			{
				gameObject.transform.localPosition = vector;
				vector += b;
			}
		}
	}

	private static Vector3 GetDirectionVector(Direction direction)
	{
		switch (direction)
		{
		case FlowLayout.Direction.LeftToRight:
		case FlowLayout.Direction.CenterHorizontal:
			return Vector3.right;
		case FlowLayout.Direction.RightToLeft:
			return Vector3.left;
		case FlowLayout.Direction.TopToBottom:
		case FlowLayout.Direction.CenterVertical:
			return Vector3.down;
		}
		return Vector3.up;
	}

	[SerializeField]
	private Direction m_direction;

	[SerializeField]
	private float m_gap;

	[SerializeField]
	private List<GameObject> m_order;

	public enum Direction
	{
		LeftToRight,
		RightToLeft,
		TopToBottom,
		BottomToTop,
		CenterHorizontal,
		CenterVertical
	}
}
