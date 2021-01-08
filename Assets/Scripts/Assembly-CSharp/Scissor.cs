using UnityEngine;

public class Scissor : MonoBehaviour
{
	public void SetRectangle(Rect rect)
	{
		this.scissorRect = rect;
	}

	private void SetScissorRect(Camera cam, Rect r)
	{
		if (r.x < 0f)
		{
			r.width += r.x;
			r.x = 0f;
		}
		if (r.y < 0f)
		{
			r.height += r.y;
			r.y = 0f;
		}
		r.width = Mathf.Min(1f - r.x, r.width);
		r.height = Mathf.Min(1f - r.y, r.height);
		cam.rect = new Rect(0f, 0f, 1f, 1f);
		cam.ResetProjectionMatrix();
		Matrix4x4 projectionMatrix = cam.projectionMatrix;
		cam.rect = r;
		Matrix4x4 rhs = Matrix4x4.TRS(new Vector3(1f / r.width - 1f, 1f / r.height - 1f, 0f), Quaternion.identity, new Vector3(1f / r.width, 1f / r.height, 1f));
		Matrix4x4 lhs = Matrix4x4.TRS(new Vector3(-r.x * 2f / r.width, -r.y * 2f / r.height, 0f), Quaternion.identity, Vector3.one);
		cam.projectionMatrix = lhs * rhs * projectionMatrix;
	}

	private void OnPreRender()
	{
		this.SetScissorRect(base.GetComponent<Camera>(), this.scissorRect);
	}

	public Rect scissorRect = new Rect(0f, 0f, 1f, 1f);
}
