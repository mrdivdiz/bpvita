using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Draggable))]
public class ScrollableList : MonoBehaviour
{
	private void Awake()
	{
		this._draggable = base.GetComponent<Draggable>();
		this._collider = base.GetComponent<BoxCollider>();
	}

	public void Add(GameObject item)
	{
		item.transform.localPosition = this._lastPosition;
		this._items.Add(item);
		this._draggable.AddAnchor(-this._lastPosition - new Vector3(0f, this.itemHeight / 2f));
		Vector3 size = this._collider.size;
		Vector3 center = this._collider.center;
		if (this._draggable.LimitToAxis == Draggable.Direction.Horizontal)
		{
			this._lastPosition.x = this._lastPosition.x + this.itemWidth;
			size.x = this._lastPosition.x;
			center.x = this._lastPosition.x / 2f + this.itemWidth / 2f;
		}
		if (this._draggable.LimitToAxis == Draggable.Direction.Vertical)
		{
			this._lastPosition.y = this._lastPosition.y - this.itemHeight;
			size.y = this._lastPosition.y;
			center.y = this._lastPosition.y / 2f + this.itemHeight / 2f;
		}
		else
		{
			this._lastPosition += new Vector3(-this.itemHeight, this.itemWidth, 0f);
		}
		if ((float)this._items.Count * this.itemHeight > this.listHeight)
		{
			this._draggable.MaxPosition.y = (float)this._items.Count * this.itemHeight - this.listHeight;
		}
		if (this._draggable.MaxPosition.y < this._draggable.MinPosition.y)
		{
			this._draggable.MaxPosition.y = this._draggable.MinPosition.y;
		}
		this._collider.size = size;
		this._collider.center = center;
	}

	public void Clear()
	{
		foreach (GameObject obj in this._items)
		{
			UnityEngine.Object.Destroy(obj);
		}
		this._items.Clear();
		this._lastPosition = Vector3.zero;
		this._draggable.Reset();
	}

	private List<GameObject> _items = new List<GameObject>();

	private Vector3 _lastPosition = Vector3.zero;

	private Draggable _draggable;

	private BoxCollider _collider;

	public float itemHeight;

	public float itemWidth;

	public float listHeight;
}
