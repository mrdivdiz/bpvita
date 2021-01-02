using UnityEngine;

public class RopeVisualization : MonoBehaviour
{
	private void Awake()
	{
		this.lr = base.gameObject.AddComponent<LineRenderer>();
	}

	public void Start()
	{
		this.lr.material = this.m_stringMaterial;
		this.lr.SetVertexCount(2);
		this.lr.SetWidth(0.05f, 0.05f);
		this.lr.SetColors(Color.black, Color.black);
	}

	private void OnDisable()
	{
		if (this.lr)
		{
			this.lr.enabled = false;
		}
	}

	private void OnEnable()
	{
		if (this.lr)
		{
			this.lr.enabled = true;
		}
	}

	private void OnDestroy()
	{
		UnityEngine.Object.Destroy(this.lr);
	}

	public void LateUpdate()
	{
		Vector3 position = base.transform.TransformPoint(this.m_pos1Anchor);
		Vector3 position2 = this.m_pos2Transform.TransformPoint(this.m_pos2Anchor);
		this.lr.SetPosition(0, position);
		this.lr.SetPosition(1, position2);
	}

	public Material m_stringMaterial;

	public Vector3 m_pos1Anchor;

	public Vector3 m_pos2Anchor;

	public Transform m_pos2Transform;

	private LineRenderer lr;
}
