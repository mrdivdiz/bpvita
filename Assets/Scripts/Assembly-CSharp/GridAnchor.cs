using System;
using UnityEngine;

public class GridAnchor : MonoBehaviour
{
	private void Awake()
	{
		this.OnUpdateLayout();
		if (this.grid != null)
		{
			GridLayout gridLayout = this.grid;
			gridLayout.onUpdateLayout = (Action)Delegate.Combine(gridLayout.onUpdateLayout, new Action(this.OnUpdateLayout));
		}
	}

	private void OnDestroy()
	{
		if (this.grid != null)
		{
			GridLayout gridLayout = this.grid;
			gridLayout.onUpdateLayout = (Action)Delegate.Remove(gridLayout.onUpdateLayout, new Action(this.OnUpdateLayout));
		}
	}

	private void OnUpdateLayout()
	{
        SnapSide snapSide = this.snapToSide;
		if (snapSide == GridAnchor.SnapSide.Bottom)
		{
			base.transform.position = this.grid.transform.position + Vector3.down * (this.grid.VerticalGap * (float)this.grid.transform.childCount);
		}
	}

	[SerializeField]
	private GridLayout grid;

	[SerializeField]
	private SnapSide snapToSide = GridAnchor.SnapSide.Bottom;

	public enum SnapSide
	{
		Top,
		Bottom,
		Left,
		Right
	}
}
