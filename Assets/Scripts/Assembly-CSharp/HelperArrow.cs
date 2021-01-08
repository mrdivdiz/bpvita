using UnityEngine;

public class HelperArrow : WPFMonoBehaviour
{
	public void Awake()
	{
		this.m_lineRenderer = base.GetComponent<LineRenderer>();
		if (!this.m_lineRenderer)
		{
			this.m_lineRenderer = base.gameObject.AddComponent<LineRenderer>();
		}
		this.m_lineRenderer.SetVertexCount(2);
		this.m_lineRenderer.material = this.m_materialArrow;
		Transform goalPosition = WPFMonoBehaviour.levelManager.GoalPosition;
		if (goalPosition)
		{
			this.m_target = goalPosition;
		}
		this.m_gameCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
	}

	public void LateUpdate()
	{
		if (!this.m_target)
		{
			return;
		}
		Vector3 vector = this.m_gameCamera.transform.position;
		Vector3 vector2 = this.m_target.transform.position;
		vector.z = 0f;
		vector2.z = 0f;
		Vector3 vector3 = vector2 - vector;
		float d = 1f;
		vector3 = vector3.normalized;
		vector -= vector3 * d;
		vector2 += vector3 * 0.5f;
		Vector3 vector4 = WPFMonoBehaviour.ClipAgainstViewport(vector, vector2);
		float num = Vector3.Distance(vector2, vector4);
		bool flag = false;
		if (num < 1f)
		{
			flag = true;
		}
		vector4 -= vector3 * d;
		Vector3 position = vector4 - vector3;
		Vector3 position2 = vector4;
		this.m_lineRenderer.SetPosition(0, position);
		this.m_lineRenderer.SetPosition(1, position2);
		if (flag)
		{
			this.m_alpha -= Time.deltaTime * 5f;
		}
		else
		{
			this.m_alpha += Time.deltaTime * 5f;
		}
		this.m_alpha = Mathf.Clamp01(this.m_alpha);
		Color white = Color.white;
		white.a = this.m_alpha;
		this.m_lineRenderer.SetColors(white, white);
	}

	public Material m_materialArrow;

	protected LineRenderer m_lineRenderer;

	protected Transform m_target;

	protected float m_alpha;

	protected Camera m_gameCamera;
}
