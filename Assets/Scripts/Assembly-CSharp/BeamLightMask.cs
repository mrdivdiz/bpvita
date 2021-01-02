using UnityEngine;

public class BeamLightMask : PointLightMask
{
	private void Update()
	{
		this.UpdateMesh();
	}

	public override void UpdateMesh()
	{
		if (this.borderMesh == null && this.border != null)
		{
			this.borderMesh = this.border.GetComponent<MeshFilter>().mesh;
		}
		if (this.mesh.vertices.Length != this.vertexCount * 2 || this.radius != this.lastRadius || this.angle != this.lastAngle || this.cutHeight != this.lastCutHeight)
		{
			if (this.vertexCount % 2 == 0)
			{
				this.vertexCount++;
			}
			this.mesh.Clear();
			this.newVertices = new Vector3[this.vertexCount * 2];
			this.newTriangles = new int[(this.vertexCount - 1) * 6];
			int num = this.vertexCount;
			int num2 = 0;
			for (int i = 0; i < this.newTriangles.Length / 2; i += 3)
			{
				if (num2 < this.vertexCount / 2)
				{
					this.newTriangles[i] = num2;
					this.newTriangles[i + 1] = num;
					this.newTriangles[i + 2] = num2 + 1;
				}
				else
				{
					this.newTriangles[i] = num2;
					this.newTriangles[i + 1] = num + 1;
					this.newTriangles[i + 2] = num2 + 1;
				}
				num2++;
				num++;
			}
			num = this.vertexCount;
			num2 = 0;
			for (int j = this.newTriangles.Length / 2; j < this.newTriangles.Length; j += 3)
			{
				if (num2 < this.vertexCount / 2)
				{
					this.newTriangles[j] = num;
					this.newTriangles[j + 1] = num + 1;
					this.newTriangles[j + 2] = num2 + 1;
				}
				else
				{
					this.newTriangles[j] = num;
					this.newTriangles[j + 1] = num + 1;
					this.newTriangles[j + 2] = num2;
				}
				num2++;
				num++;
			}
			float num3 = this.angle * 0.0174532924f;
			float f = 1.57079637f - num3 / 2f;
			float f2 = 1.57079637f + num3 / 2f;
			float d = this.cutHeight / Mathf.Cos(num3 / 2f);
			Vector3 vector = new Vector3(this.radius * Mathf.Cos(f2), this.radius * Mathf.Sin(f2));
			Vector3 a = new Vector3(this.radius * Mathf.Cos(f), this.radius * Mathf.Sin(f));
			Vector3 vector2 = vector.normalized * d;
			Vector3 vector3 = a.normalized * d;
			Vector3 vector4 = vector3 - vector2;
			float num4 = Vector3.Distance(vector3, vector2);
			float d2 = num4 / (float)(this.vertexCount - 1);
			int num5 = 0;
			this.newVertices[this.newVertices.Length / 2 - 1] = vector3;
			for (int k = 0; k < this.newVertices.Length / 2 - 1; k++)
			{
				this.newVertices[k] = vector2 + vector4.normalized * (float)num5 * d2;
				num5++;
			}
			float[] array = new float[this.vertexCount];
			float num6 = num3 / 2f;
			array[0] = -num6;
			array[array.Length - 1] = 3.14159274f + num6;
			float num7 = (3.14159274f + 2f * num6) / (float)(this.vertexCount - 1);
			for (int l = 1; l < array.Length - 1; l++)
			{
				array[l] = array[0] + (float)l * num7;
			}
			float num8 = num3 / 2f;
			float f3 = 1.57079637f - num8;
			Vector3 b = new Vector3((vector.x + a.x) / 2f, (vector.y + a.y) / 2f);
			float magnitude = (a - b).magnitude;
			float num9 = magnitude / Mathf.Tan(f3);
			this.arcCenter = new Vector3(b.x, b.y + num9);
			float num10 = num9 / Mathf.Cos(f3);
			num5 = array.Length - 1;
			for (int m = this.vertexCount; m < this.newVertices.Length; m++)
			{
				float x = this.arcCenter.x + num10 * Mathf.Cos(array[num5]);
				float y = this.arcCenter.y + num10 * Mathf.Sin(array[num5]);
				this.newVertices[m] = new Vector3(x, y);
				num5--;
			}
			this.newUV = new Vector2[this.newVertices.Length];
			for (int n = 0; n < this.newUV.Length; n++)
			{
				this.newUV[n] = new Vector2(this.newVertices[n].x, this.newVertices[n].y);
			}
			if (this.border != null)
			{
				vector2 = new Vector3(vector2.x - this.borderWidth * Mathf.Sin(0.7853982f), vector2.y - this.borderWidth * Mathf.Cos(0.7853982f));
				vector3 = new Vector3(vector3.x + this.borderWidth * Mathf.Sin(0.7853982f), vector3.y - this.borderWidth * Mathf.Cos(0.7853982f));
				vector4 = vector3 - vector2;
				num4 = Vector3.Distance(vector3, vector2);
				d2 = num4 / (float)(this.vertexCount - 1);
				num5 = 0;
				Vector3[] array2 = new Vector3[this.newVertices.Length];
				array2[array2.Length / 2 - 1] = vector3;
				for (int num11 = 0; num11 < array2.Length / 2 - 1; num11++)
				{
					array2[num11] = vector2 + vector4.normalized * (float)num5 * d2;
					num5++;
				}
				array = new float[this.vertexCount];
				num6 = num3 / 2f;
				array[0] = -num6;
				array[array.Length - 1] = 3.14159274f + num6;
				num7 = (3.14159274f + 2f * num6) / (float)(this.vertexCount - 1);
				for (int num12 = 1; num12 < array.Length - 1; num12++)
				{
					array[num12] = array[0] + (float)num12 * num7;
				}
				num10 += this.borderWidth;
				this.colliderSize = num10;
				num5 = array.Length - 1;
				for (int num13 = this.vertexCount; num13 < array2.Length; num13++)
				{
					float x2 = this.arcCenter.x + num10 * Mathf.Cos(array[num5]);
					float y2 = this.arcCenter.y + num10 * Mathf.Sin(array[num5]);
					array2[num13] = new Vector3(x2, y2);
					num5--;
				}
				this.borderMesh.vertices = array2;
				this.borderMesh.uv = this.newUV;
				this.borderMesh.triangles = this.newTriangles;
				this.borderMesh.RecalculateNormals();
				this.borderMesh.RecalculateBounds();
			}
			this.mesh.vertices = this.newVertices;
			this.mesh.uv = this.newUV;
			this.mesh.triangles = this.newTriangles;
			this.mesh.RecalculateNormals();
			this.mesh.RecalculateBounds();
			this.lastRadius = this.radius;
			this.lastAngle = this.angle;
			this.lastCutHeight = this.cutHeight;
		}
	}

	public float angle = 90f;

	public float cutHeight = 1f;

	public Vector3 arcCenter;

	private float lastAngle;

	private float lastCutHeight;
}
