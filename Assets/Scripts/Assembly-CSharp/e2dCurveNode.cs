using System;
using UnityEngine;

[Serializable]
public class e2dCurveNode
{
	public e2dCurveNode(Vector2 _position)
	{
		this.position = _position;
		this.texture = 0;
		this.grassRatio = 0f;
	}

	public bool Selected
	{
		get
		{
			return this.isSelected;
		}
		set
		{
			this.isSelected = value;
		}
	}

	public void Copy(e2dCurveNode other)
	{
		this.position = other.position;
		this.texture = other.texture;
		this.grassRatio = other.grassRatio;
	}

	public override bool Equals(object obj)
	{
		return obj is e2dCurveNode && this == (e2dCurveNode)obj;
	}

	public override int GetHashCode()
	{
		return Mathf.RoundToInt(1000f * this.position.x + 1000f * this.position.y + (float)this.texture + 1000f * this.grassRatio);
	}

	public static bool operator ==(e2dCurveNode a, e2dCurveNode b)
	{
		return a.position == b.position;
	}

	public static bool operator !=(e2dCurveNode a, e2dCurveNode b)
	{
		return !(a == b);
	}

	public Vector2 position;

	public int texture;

	public float grassRatio;

	private bool isSelected;
}
