using UnityEngine;

[ExecuteInEditMode]
public class CustomSpritePanel : MonoBehaviour
{
	private float Width
	{
		get
		{
			return Mathf.Clamp(this.width, 3f, 100f) - 1f;
		}
	}

	private float Height
	{
		get
		{
			return Mathf.Clamp(this.height, 3f, 100f) - 1f;
		}
	}

	private float HalfWidth
	{
		get
		{
			return this.Width * 0.5f;
		}
	}

	private float HalfHeight
	{
		get
		{
			return this.Height * 0.5f;
		}
	}

	private void Enable()
	{
		this.UpdatePieces();
	}

	private void Update()
	{
		this.UpdatePieces();
	}

	private void UpdatePieces()
	{
		if (!this.hasChanged || this.pieces == null || this.pieceOffsets == null)
		{
			return;
		}
		float num = (this.width >= 10f) ? ((this.width - 10f) * 0.15f) : 0f;
		float num2 = (this.height >= 10f) ? ((this.height - 10f) * 0.15f) : 0f;
		if (this.pieces.Length > 0 && this.pieces[0] != null && this.pieceOffsets.Length > 0)
		{
			this.pieces[0].localPosition = -Vector3.right * this.HalfWidth + Vector3.up * this.HalfHeight + this.pieceOffsets[0];
		}
		if (this.pieces.Length > 1 && this.pieces[1] != null && this.pieceOffsets.Length > 1)
		{
			this.pieces[1].localPosition = Vector3.up * this.HalfHeight + this.pieceOffsets[1];
		}
		if (this.pieces.Length > 1 && this.pieces[1] != null)
		{
			this.pieces[1].localScale = Vector3.up + Vector3.right * (this.HalfWidth + num);
		}
		if (this.pieces.Length > 2 && this.pieces[2] != null && this.pieceOffsets.Length > 2)
		{
			this.pieces[2].localPosition = Vector3.right * this.HalfWidth + Vector3.up * this.HalfHeight + this.pieceOffsets[2];
		}
		if (this.pieces.Length > 3 && this.pieces[3] != null && this.pieceOffsets.Length > 3)
		{
			this.pieces[3].localPosition = Vector3.right * this.HalfWidth + this.pieceOffsets[3];
		}
		if (this.pieces.Length > 3 && this.pieces[3] != null)
		{
			this.pieces[3].localScale = Vector3.up + Vector3.right * (this.HalfHeight + num2);
		}
		if (this.pieces.Length > 4 && this.pieces[4] != null && this.pieceOffsets.Length > 4)
		{
			this.pieces[4].localPosition = Vector3.right * this.HalfWidth - Vector3.up * this.HalfHeight + this.pieceOffsets[4];
		}
		if (this.pieces.Length > 5 && this.pieces[5] != null && this.pieceOffsets.Length > 5)
		{
			this.pieces[5].localPosition = -Vector3.up * this.HalfHeight + this.pieceOffsets[5];
		}
		if (this.pieces.Length > 5 && this.pieces[5] != null)
		{
			this.pieces[5].localScale = Vector3.up + Vector3.right * (this.HalfWidth + num);
		}
		if (this.pieces.Length > 6 && this.pieces[6] != null && this.pieceOffsets.Length > 6)
		{
			this.pieces[6].localPosition = -Vector3.right * this.HalfWidth - Vector3.up * this.HalfHeight + this.pieceOffsets[6];
		}
		if (this.pieces.Length > 7 && this.pieces[7] != null && this.pieceOffsets.Length > 7)
		{
			this.pieces[7].localPosition = -Vector3.right * this.HalfWidth + this.pieceOffsets[7];
		}
		if (this.pieces.Length > 7 && this.pieces[7] != null)
		{
			this.pieces[7].localScale = Vector3.up + Vector3.right * (this.HalfHeight + num2);
		}
		if (this.pieces.Length > 8 && this.pieces[8] != null && this.pieceOffsets.Length > 8)
		{
			this.pieces[8].localPosition = Vector3.zero + this.pieceOffsets[8];
		}
		if (this.pieces.Length > 8 && this.pieces[8] != null)
		{
			this.pieces[8].localScale = Vector3.right * (this.HalfWidth + num + 0.2f) + Vector3.up * (this.HalfHeight + num2 + 0.2f);
		}
		if (this.masks == null)
		{
			return;
		}
		if (this.masks.Length > 0 && this.masks[0] != null)
		{
			this.masks[0].localPosition = Vector3.right * (this.HalfWidth + 8.2f) - Vector3.forward * 5f;
		}
		if (this.masks.Length > 1 && this.masks[1] != null)
		{
			this.masks[1].localPosition = -Vector3.right * (this.HalfWidth + 8.2f) - Vector3.forward * 5f;
		}
	}

	public Transform[] pieces;

	public Vector3[] pieceOffsets;

	public Transform[] masks;

	public float width = 2f;

	public float height = 2f;

	private bool hasChanged = true;

	private enum Pieces
	{
		TopLeft,
		Top,
		TopRight,
		Right,
		BottomRight,
		Bottom,
		BottomLeft,
		Left,
		Center
	}
}
