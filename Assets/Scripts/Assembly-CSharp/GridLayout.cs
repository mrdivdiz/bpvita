using System;
using UnityEngine;

[ExecuteInEditMode]
public class GridLayout : MonoBehaviour
{
	public float HorizontalGap
	{
		get
		{
			return this.horizontalGap;
		}
	}

	public float VerticalGap
	{
		get
		{
			return this.verticalGap;
		}
	}

	private void Awake()
	{
		this.UpdateLayout();
	}

	public void UpdateLayout()
	{
		if (this.items <= 0)
		{
			this.items = 1;
		}
		int num = 0;
		for (int i = 0; i < base.transform.childCount; i++)
		{
			if (base.transform.GetChild(i).gameObject.activeInHierarchy)
			{
				num++;
			}
		}
		float num2 = 0f;
        GridAlign gridAlign = this.gridAlign;
		if (gridAlign != GridLayout.GridAlign.Center)
		{
			if (gridAlign == GridLayout.GridAlign.Right)
			{
				num2 = (float)Mathf.Clamp(num - 1, 0, this.items - 1) * this.horizontalGap;
			}
		}
		else
		{
			num2 = (float)Mathf.Clamp(num - 1, 0, this.items - 1) * this.horizontalGap * 0.5f;
		}
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		for (int j = 0; j < base.transform.childCount; j++)
		{
			Transform child = base.transform.GetChild(j);
			if (child.gameObject.activeInHierarchy)
			{
				if (num5 > 0 && num5 % this.items == 0)
				{
					num3++;
					num4 = 0;
				}
                GridType gridType = this.gridType;
				if (gridType != GridLayout.GridType.Horizontal)
				{
					if (gridType == GridLayout.GridType.Vertical)
					{
						child.localPosition = -Vector3.up * (this.verticalGap * (float)num4) + Vector3.right * (this.horizontalGap * (float)num3);
					}
				}
				else
				{
					child.localPosition = Vector3.right * (this.horizontalGap * (float)num4 - num2) - Vector3.up * (this.verticalGap * (float)num3);
				}
				num4++;
				num5++;
			}
		}
		if (this.onUpdateLayout != null)
		{
			this.onUpdateLayout();
		}
	}

	[SerializeField]
	private GridType gridType;

	[SerializeField]
	private GridAlign gridAlign;

	[SerializeField]
	private int items = 5;

	[SerializeField]
	private float horizontalGap = 2f;

	[SerializeField]
	private float verticalGap = 2f;

	public Action onUpdateLayout;

	private enum GridType
	{
		Horizontal,
		Vertical
	}

	private enum GridAlign
	{
		Left,
		Right,
		Center
	}
}
