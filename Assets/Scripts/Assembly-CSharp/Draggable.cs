using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Draggable : Widget
{
	private void Awake()
	{
		this._hudCamera = GameObject.Find("HUDCamera").GetComponent<Camera>();
		this._initialPosition = base.transform.localPosition;
		this.MinPosition = this._initialPosition;
		this.MaxPosition = this._initialPosition;
		this._moveTarget = this._initialPosition;
	}

	private Vector3 ScreenToWorldToLocalPosition(Vector3 point)
	{
		Vector4 vector = base.transform.localToWorldMatrix * base.transform.localPosition;
		Vector3 v = this._hudCamera.ScreenToWorldPoint(point);
		v.z = vector.z;
		return base.transform.localToWorldMatrix * v;
	}

	private Vector3 ClampToLimitedAxis(Vector3 point)
	{
		if (this.LimitToAxis == Draggable.Direction.Horizontal)
		{
			point.y = base.transform.localPosition.y;
		}
		else if (this.LimitToAxis == Draggable.Direction.Vertical)
		{
			point.x = base.transform.localPosition.x;
		}
		return point;
	}

	private Vector3 ClampBetweenLimits(Vector3 point)
	{
		if (this.LimitToAxis == Draggable.Direction.Horizontal)
		{
			if (point.x < this.MinPosition.x)
			{
				point.x = this.MinPosition.x;
			}
			else if (point.x > this.MaxPosition.x)
			{
				point.x = this.MaxPosition.x;
			}
		}
		else if (this.LimitToAxis == Draggable.Direction.Vertical)
		{
			if (point.y < this.MinPosition.y)
			{
				point.y = this.MinPosition.y;
			}
			else if (point.y > this.MaxPosition.y)
			{
				point.y = this.MaxPosition.y;
			}
		}
		return this.ClampToLimitedAxis(point);
	}

	protected override void OnInput(InputEvent input)
	{
		base.OnInput(input);
		if (input.type == InputEvent.EventType.Press)
		{
			this._velocity = Vector3.zero;
			this._dragging = true;
			this._offset = this.ClampToLimitedAxis(base.transform.localPosition - this.ScreenToWorldToLocalPosition(input.position));
		}
		else if (input.type == InputEvent.EventType.Release)
		{
			this._dragging = false;
			this._offset = this.ClampBetweenLimits(base.transform.localPosition);
		}
		else if (input.type == InputEvent.EventType.Drag && this._dragging)
		{
			Vector3 point = this.ScreenToWorldToLocalPosition(input.position);
			this._moveTarget = this.ClampToLimitedAxis(point) + this._offset;
		}
	}

	private void FixedUpdate()
	{
		Vector3 vector = base.transform.localPosition;
		vector = Vector3.SmoothDamp(vector, this._moveTarget, ref this._velocity, Time.smoothDeltaTime * 3.5f);
		vector = this.ClampBetweenLimits(vector);
		base.transform.localPosition = vector;
	}

	public void Reset()
	{
		base.transform.localPosition = this._initialPosition;
		this.MinPosition = this._initialPosition;
		this.MaxPosition = this._initialPosition;
		this._moveTarget = Vector3.zero;
	}

	private void OnDisable()
	{
		this.Reset();
	}

	public void AddAnchor(Vector3 anchor)
	{
		this._achors.Add(anchor);
	}

	private Vector3 _offset = Vector3.zero;

	private Vector3 _velocity = Vector3.zero;

	private Vector3 _initialPosition;

	private Vector3 _moveTarget = Vector3.zero;

	private bool _dragging;

	private Camera _hudCamera;

	private List<Vector3> _achors = new List<Vector3>();

	public Direction LimitToAxis;

	public float DampingTime = 1.5f;

	public float MaxVelocity = 2f;

	public Vector3 MinPosition;

	public Vector3 MaxPosition;

	public enum Direction
	{
		None,
		Horizontal,
		Vertical
	}
}
