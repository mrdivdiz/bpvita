using UnityEngine;

public class SpriteData
{
	public SpriteData(string id, string name, string materialId, Material material, int selectionX, int selectionY, int selectionWidth, int selectionHeight, int pivotX, int pivotY, int UVx, int UVy, int width, int height, int subdivisions, int opaqueBorderPixels, string atlasMaterialPath, Rect uv)
	{
		this.id = id;
		this.name = name;
		this.materialId = materialId;
		this.material = material;
		this.selectionX = selectionX;
		this.selectionY = selectionY;
		this.selectionWidth = selectionWidth;
		this.selectionHeight = selectionHeight;
		this.pivotX = pivotX;
		this.pivotY = pivotY;
		this.UVx = UVx;
		this.UVy = UVy;
		this.width = width;
		this.height = height;
		this.subdivisions = subdivisions;
		this.opaqueBorderPixels = opaqueBorderPixels;
		this.atlasMaterialPath = atlasMaterialPath;
		this.uv = uv;
	}

	public string id;

	public string name;

	public string materialId;

	public Material material;

	public int selectionX;

	public int selectionY;

	public int selectionWidth;

	public int selectionHeight;

	public int pivotX;

	public int pivotY;

	public int UVx;

	public int UVy;

	public int width = 16;

	public int height = 16;

	public int subdivisions = 16;

	public int opaqueBorderPixels;

	public string atlasMaterialPath;

	public Rect uv;
}
