using UnityEngine;

public class Slingshot : WPFMonoBehaviour
{
	private void Awake()
	{
		this.m_pad = base.transform.Find("Pad").gameObject;
		this.m_restPosition = this.m_pad.transform.localPosition;
		GameObject gameObject = new GameObject("Line1");
		gameObject.transform.parent = base.transform;
		gameObject.transform.localPosition = Vector3.zero;
		GameObject gameObject2 = new GameObject("Line2");
		gameObject2.transform.parent = base.transform;
		gameObject2.transform.localPosition = Vector3.zero;
		this.m_line1 = gameObject.AddComponent<LineRenderer>();
		this.m_line1.useWorldSpace = false;
		this.m_line1.SetWidth(0.25f, 0.25f);
		this.m_line1.sharedMaterial = this.m_rubberBandMaterial;
		this.m_line1.SetVertexCount(2);
		this.m_line1.SetPosition(0, new Vector3(0.47f, 2.23f, -0.012f));
		this.m_line1.SetPosition(1, new Vector3(-3f, -1f, -0.012f));
		this.m_line2 = gameObject2.AddComponent<LineRenderer>();
		this.m_line2.useWorldSpace = false;
		this.m_line2.SetWidth(0.25f, 0.25f);
		this.m_line2.sharedMaterial = this.m_rubberBandMaterial;
		this.m_line2.SetVertexCount(2);
		this.m_line2.SetPosition(0, new Vector3(-0.57f, 2.2f, -0.38f));
		this.m_line2.SetPosition(1, new Vector3(-3f, -1f, -0.38f));
		this.SetDrawPosition(Vector3.zero);
	}

	private void Update()
	{
		if (this.m_state == Slingshot.State.Free && this.m_drawPosition.sqrMagnitude > 0.0001f)
		{
			this.m_drawPosition *= 0.95f;
			this.SetDrawPosition(this.m_drawPosition);
		}
	}

	public void SetDrawPosition(Vector3 drawPosition)
	{
		this.m_drawPosition = drawPosition;
		Vector3 localPosition = drawPosition + this.m_restPosition;
		localPosition.z = this.m_restPosition.z;
		this.m_line1.SetPosition(1, new Vector3(localPosition.x, localPosition.y, -0.012f));
		this.m_line2.SetPosition(1, new Vector3(localPosition.x, localPosition.y, -0.38f));
		this.m_pad.transform.localPosition = localPosition;
		Vector3 vector = -drawPosition.normalized;
		float angle = 57.29578f * Mathf.Atan2(vector.y, vector.x);
		Quaternion quaternion = Quaternion.AngleAxis(angle, Vector3.forward);
		if (this.m_state == Slingshot.State.Free)
		{
			float num = 2f * drawPosition.sqrMagnitude;
			if (num < 1f)
			{
				quaternion = Quaternion.RotateTowards(quaternion, Quaternion.AngleAxis(0f, Vector3.forward), 180f * (1f - num));
			}
		}
		this.m_pad.transform.rotation = quaternion;
	}

	public bool IsFree()
	{
		return this.m_state == Slingshot.State.Free;
	}

	public void StartShot()
	{
		this.m_state = Slingshot.State.InUse;
		Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.slingshotStretched);
	}

	public void EndShot()
	{
		this.m_state = Slingshot.State.Free;
	}

	public Material m_rubberBandMaterial;

	private State m_state;

	private LineRenderer m_line1;

	private LineRenderer m_line2;

	private GameObject m_pad;

	private Vector3 m_restPosition;

	private Vector3 m_drawPosition;

	private enum State
	{
		Free,
		InUse
	}
}
