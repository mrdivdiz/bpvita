using System;
using UnityEngine;

[Serializable]
public class e2dCurveTexture
{
	public e2dCurveTexture(Texture _texture)
	{
		this.texture = _texture;
		this.size = new Vector2(1f, 1f);
		this.fixedAngle = false;
		this.fadeThreshold = 0.3f;
	}

	public Texture texture;

	public Vector2 size;

	public bool fixedAngle;

	public float fadeThreshold;
}
