using UnityEngine;

[ExecuteInEditMode]
public class NeatLayout : MonoBehaviour
{
	private int TotalRows
	{
		get
		{
			return this.ActiveChildCount / (this.RowMax + 1) + 1;
		}
	}

	private int RowMax
	{
		get
		{
			if (!this.evenDistribution)
			{
				return this.rowItems;
			}
			if (this.ActiveChildCount < 2 * this.rowItems - 2)
			{
				return Mathf.CeilToInt((float)this.ActiveChildCount / 2f);
			}
			return this.rowItems;
		}
	}

	private int ActiveChildCount
	{
		get
		{
			int num = 0;
			for (int i = 0; i < base.transform.childCount; i++)
			{
				if (base.transform.GetChild(i).gameObject.activeSelf)
				{
					MeshRenderer[] componentsInChildren = base.transform.GetChild(i).GetComponentsInChildren<MeshRenderer>();
					for (int j = 0; j < componentsInChildren.Length; j++)
					{
						if (componentsInChildren[j].enabled)
						{
							num++;
							break;
						}
					}
				}
			}
			return num;
		}
	}

	private int ObjectsInRow(int row)
	{
		return Mathf.Clamp(this.ActiveChildCount - row * this.RowMax, 0, this.RowMax);
	}

	private int RowIndex(int index)
	{
		return index % this.RowMax;
	}

	private bool IsActive(Transform child)
	{
		MeshRenderer[] componentsInChildren = child.GetComponentsInChildren<MeshRenderer>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (componentsInChildren[i].enabled)
			{
				return true;
			}
		}
		return false;
	}

	private void Start()
	{
		this.OrganizeChildren();
	}

	private void OnEnable()
	{
		this.OrganizeChildren();
	}

	private void OrganizeChildren()
	{
		int num = 0;
		for (int i = 0; i < base.transform.childCount; i++)
		{
			Transform child = base.transform.GetChild(i);
			if (this.IsActive(child) && child.gameObject.activeInHierarchy)
			{
				Vector2 v = new Vector2(this.horizontalGap, this.verticalGap);
				int num2 = num / this.RowMax;
                Align align = this.align;
				if (align != NeatLayout.Align.Middle)
				{
					if (align != NeatLayout.Align.Right)
					{
						if (align == NeatLayout.Align.Left)
						{
							v.y = this.verticalGap * (float)num2;
							v.x = this.horizontalGap * (float)num;
						}
					}
					else
					{
						v.y = this.verticalGap * (float)num2;
						v.x = -this.horizontalGap * (float)num;
					}
				}
				else
				{
					v.y *= -((float)num2 - (float)this.TotalRows / 2f);
					v.x *= (float)this.RowIndex(num) - (float)this.ObjectsInRow(num2) / 2f;
					v.y -= this.verticalGap / 2f;
					v.x += this.horizontalGap / 2f;
				}
				child.localPosition = v;
				num++;
			}
		}
	}

	[SerializeField]
	private Align align;

	[SerializeField]
	private float horizontalGap;

	[SerializeField]
	private float verticalGap;

	[SerializeField]
	private int rowItems = 4;

	[SerializeField]
	private bool evenDistribution;

	public enum Align
	{
		Left,
		Right,
		Middle
	}
}
