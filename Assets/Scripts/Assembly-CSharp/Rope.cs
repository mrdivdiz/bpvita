using System;
using System.Collections.Generic;
using UnityEngine;

public class Rope : BasePart
{
	public override Vector3 Position
	{
		get
		{
			return this.m_nodes[this.m_nodes.Count / 2].gameObject.transform.position;
		}
	}

	public bool IsCut()
	{
		return this.m_ropeCut;
	}

	public bool IsLeftPart(Collider collider)
	{
		if (!this.m_ropeCut)
		{
			return true;
		}
		for (int i = 0; i < this.m_cutIndex; i++)
		{
			if (this.m_nodes[i].gameObject.GetComponent<Collider>() == collider)
			{
				return true;
			}
		}
		return false;
	}

	public BasePart LeftPart
	{
		get
		{
			return this.m_leftPart;
		}
	}

	public BasePart RightPart
	{
		get
		{
			return this.m_rightPart;
		}
	}

	public GameObject FirstSegment
	{
		get
		{
			return this.m_nodes[0].gameObject;
		}
	}

	public GameObject LastSegment
	{
		get
		{
			return this.m_nodes[this.m_nodes.Count - 1].gameObject;
		}
	}

	public static Vector3 PositionOnSpline(List<Vector3> controlPoints, float t)
	{
		int count = controlPoints.Count;
		int num = Mathf.FloorToInt(t * (float)(count - 1));
		Vector3 a = controlPoints[Mathf.Clamp(num - 1, 0, count - 1)];
		Vector3 b = controlPoints[Mathf.Clamp(num, 0, count - 1)];
		Vector3 c = controlPoints[Mathf.Clamp(num + 1, 0, count - 1)];
		Vector3 d = controlPoints[Mathf.Clamp(num + 2, 0, count - 1)];
		float i = t * (float)(count - 1) - (float)num;
		return MathsUtil.CatmullRomInterpolate(a, b, c, d, i);
	}

	public override void Awake()
	{
		base.Awake();
		if (this.m_gridVisualizationNode)
		{
			this.m_gridVisualizationNode.SetActive(true);
		}
	}

	private void Start()
	{
		if (base.rigidbody)
		{
			base.rigidbody.isKinematic = true;
		}
		this.m_lineRenderer = base.GetComponent<LineRenderer>();
		if (!this.m_lineRenderer)
		{
			this.m_lineRenderer = base.gameObject.AddComponent<LineRenderer>();
		}
		this.m_lineRenderer.useWorldSpace = true;
		this.m_lineRenderer.SetWidth(0.2f, 0.2f);
		Color color = new Color(255f, 60f, 90f);
		this.m_lineRenderer.SetColors(color, color);
		this.m_lineRenderer.sharedMaterial = this.m_material;
	}

	private void CreateSecondLineRenderer()
	{
		this.m_lineRenderer2 = new GameObject
		{
			name = "LineRenderer2",
			transform = 
			{
				parent = base.transform
			}
		}.AddComponent<LineRenderer>();
		this.m_lineRenderer2.useWorldSpace = true;
		this.m_lineRenderer2.SetWidth(0.2f, 0.2f);
		Color color = new Color(255f, 60f, 90f);
		this.m_lineRenderer2.SetColors(color, color);
		this.m_lineRenderer2.sharedMaterial = this.m_material;
	}

	public override void Initialize()
	{
		if (this.RightPart && this.RightPart.GetComponent<Rope>())
		{
			Rope.Node node = this.m_nodes[this.m_nodes.Count - 1];
			node.gameObject.transform.position = this.RightPart.GetComponent<Rope>().FirstSegment.transform.position;
			this.CreateJoint(node.gameObject, this.RightPart.GetComponent<Rope>().FirstSegment.GetComponent<Rigidbody>());
		}
		base.contraption.ChangeOneShotPartAmount(BasePart.BaseType(this.m_partType), this.EffectDirection(), 1);
		if (this.m_gridVisualizationNode)
		{
			this.m_gridVisualizationNode.SetActive(false);
		}
	}

	public int FindInteractiveSegment(Vector3 position)
	{
		int num = -1;
		float num2 = 1000f;
		for (int i = 0; i < this.m_nodes.Count; i++)
		{
			Vector3 position2 = this.m_nodes[i].gameObject.transform.position;
			position2.z = 0f;
			float num3 = Vector3.Distance(position2, position);
			if (num3 <= this.m_interactiveRadius && num3 < num2)
			{
				num2 = num3;
				num = i;
				num = Mathf.Clamp(num, 2, this.m_nodes.Count - 2);
			}
		}
		return num;
	}

	public override bool IsInInteractiveRadius(Vector3 position)
	{
		return this.FindInteractiveSegment(position) != -1;
	}

	protected override void OnTouch(bool hasPosition, Vector3 touchPosition)
	{
		if (!this.m_ropeCut)
		{
			int num = -1;
			if (hasPosition)
			{
				num = this.FindInteractiveSegment(touchPosition);
			}
			if (num != -1)
			{
				this.Cut(num);
			}
			else
			{
				this.Cut(4);
			}
		}
	}

	private void Update()
	{
		if (!this.m_ropeCut)
		{
			this.RenderRope(this.m_lineRenderer, 0, this.m_nodes.Count);
		}
		else
		{
			this.RenderRope(this.m_lineRenderer, 0, this.m_cutIndex);
			this.RenderRope(this.m_lineRenderer2, this.m_cutIndex, this.m_nodes.Count);
		}
	}

	private void RenderRope(LineRenderer lineRenderer, int startIndex, int endIndex)
	{
		this.m_splinePoints.Clear();
		Rope rope = null;
		if (this.m_leftPart)
		{
			rope = this.m_leftPart.GetComponent<Rope>();
		}
		for (int i = startIndex; i < endIndex; i++)
		{
			Rigidbody rigidbody = this.m_nodes[i].rigidbody;
			Vector3 position = rigidbody.gameObject.transform.position;
			if (i == 0 && rope)
			{
				position = rope.LastSegment.transform.position;
			}
			position.z = -1f;
			this.m_splinePoints.Add(position);
		}
		if (this.m_splinePoints.Count > 1)
		{
			lineRenderer.SetVertexCount(20);
			for (int j = 0; j < 20; j++)
			{
				float t = (float)j / 19f;
				lineRenderer.SetPosition(j, Rope.PositionOnSpline(this.m_splinePoints, t));
			}
		}
		else
		{
			lineRenderer.SetVertexCount(0);
		}
	}

	private Joint CreateJoint(GameObject target, Rigidbody connectedBody)
	{
		HingeJoint hingeJoint = target.AddComponent<HingeJoint>();
		hingeJoint.connectedBody = connectedBody;
		hingeJoint.axis = Vector3.forward;
		hingeJoint.breakForce = float.PositiveInfinity;
		hingeJoint.breakTorque = float.PositiveInfinity;
		hingeJoint.enablePreprocessing = false;
		this.AddConnectedBodyToJoint(hingeJoint, connectedBody);
		return hingeJoint;
	}

	private void AddConnectedBodyToJoint(Joint joint, Rigidbody connectedBody)
	{
		joint.connectedBody = connectedBody;
		if (connectedBody != null)
		{
			joint.anchor = connectedBody.position - joint.transform.position;
		}
	}

	public void Create(BasePart leftPart, BasePart rightPart)
	{
		this.m_leftPart = leftPart;
		this.m_rightPart = rightPart;
		Vector3 vector = base.transform.position - 0.5f * base.transform.right;
		Quaternion quaternion = base.transform.rotation;
		float num = 74.4f;
		quaternion = Quaternion.AngleAxis(-num, Vector3.forward);
		if (this.m_gridRotation != BasePart.GridRotation.Deg_0)
		{
			quaternion *= Quaternion.AngleAxis(-90f, Vector3.forward);
		}
		int num2 = 8;
		Joint joint = null;
		if (leftPart && !leftPart.GetComponent<Rope>())
		{
			joint = this.CreateJoint(leftPart.gameObject, null);
		}
		for (int i = 0; i < num2; i++)
		{
			if (i == num2 - 1 && rightPart && !rightPart.GetComponent<Rope>())
			{
				vector = base.transform.position + 0.5f * base.transform.right;
			}
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.m_segment, vector, quaternion);
			Rigidbody component = gameObject.GetComponent<Rigidbody>();
			if (joint != null)
			{
				this.AddConnectedBodyToJoint(joint, component);
				joint = null;
			}
			this.m_nodes.Add(new Rope.Node(gameObject, component, joint));
			if (i == num2 - 1 && rightPart && !rightPart.GetComponent<Rope>())
			{
				joint = this.CreateJoint(rightPart.gameObject, component);
			}
			vector += 0.5f * (quaternion * Vector3.right);
			quaternion = ((i % 2 != 0) ? Quaternion.AngleAxis(-num, Vector3.forward) : Quaternion.AngleAxis(num, Vector3.forward));
			if (this.m_gridRotation != BasePart.GridRotation.Deg_0)
			{
				quaternion *= Quaternion.AngleAxis(-90f, Vector3.forward);
			}
			gameObject.transform.parent = base.transform;
		}
		if (base.renderer)
		{
			base.renderer.enabled = false;
		}
	}

	private void Cut(int nodeIndex)
	{
		if (!this.m_ropeCut)
		{
			base.contraption.ChangeOneShotPartAmount(BasePart.BaseType(this.m_partType), this.EffectDirection(), -1);
			this.m_ropeCut = true;
			this.m_cutIndex = nodeIndex;
			this.CreateSecondLineRenderer();
			int num = this.m_cutIndex;
			this.m_lineRenderer.material.mainTextureScale = new Vector2(20f * (float)(num - 1) / (float)(this.m_nodes.Count - 1), 1f);
			num = this.m_nodes.Count - num;
			this.m_lineRenderer2.material.mainTextureScale = new Vector2(20f * (float)(num - 1) / (float)(this.m_nodes.Count - 1), 1f);
			base.contraption.FindComponentsConnectedByRope();
		}
	}

	private float Sigmoid(float t)
	{
		return 1f / (1f + Mathf.Exp(-t));
	}

	private float ResponseCurve(float t)
	{
		return (this.Sigmoid(8f * (t - 0.5f)) - 0.01798f) / 0.9641f;
	}

	public void FixedUpdate()
	{
		if (this.m_nodes.Count == 0)
		{
			return;
		}
		float num = Mathf.Max(this.m_nodes[0].rigidbody.velocity.magnitude, this.m_nodes[this.m_nodes.Count - 1].rigidbody.velocity.magnitude);
		Rope rope = (!(this.m_rightPart != null)) ? null : this.m_rightPart.GetComponent<Rope>();
		if (rope)
		{
			Vector3 position = this.m_nodes[this.m_nodes.Count - 1].rigidbody.position;
			Vector3 position2 = rope.FirstSegment.GetComponent<Rigidbody>().position;
			if (Vector3.Distance(position, position2) > 0.1f)
			{
				rope.FirstSegment.GetComponent<Rigidbody>().position = position;
			}
		}
		for (int i = 0; i < this.m_nodes.Count; i++)
		{
			Rigidbody rigidbody = this.m_nodes[i].rigidbody;
			Rigidbody rigidbody2;
			if (i == 0)
			{
				rigidbody2 = rigidbody;
			}
			else
			{
				rigidbody2 = this.m_nodes[i - 1].rigidbody;
			}
			Rigidbody rigidbody3;
			if (i == this.m_nodes.Count - 1)
			{
				rigidbody3 = rigidbody;
			}
			else
			{
				rigidbody3 = this.m_nodes[i + 1].rigidbody;
			}
			float magnitude = (rigidbody.velocity - 0.4f * rigidbody2.velocity - 0.4f * rigidbody3.velocity).magnitude;
			rigidbody.AddForce(-0.02f * magnitude * magnitude * rigidbody.velocity.normalized, ForceMode.Force);
			rigidbody.drag = 0.5f + 6f / (1f + 4f * num * num);
		}
		for (int j = 1; j < this.m_nodes.Count; j++)
		{
			if (!this.m_ropeCut || j != this.m_cutIndex)
			{
				Rigidbody rigidbody4 = this.m_nodes[j - 1].rigidbody;
				Rigidbody rigidbody5 = this.m_nodes[j].rigidbody;
				Vector3 a = rigidbody5.gameObject.transform.position - rigidbody4.gameObject.transform.position;
				float num2 = a.magnitude;
				if (num2 > 0.5f)
				{
					num2 -= 0.5f;
					if (num2 < 1f)
					{
						num2 = Mathf.Pow(num2, 0.75f);
					}
					else
					{
						num2 = Mathf.Pow(num2, 2f);
					}
					num2 = Mathf.Clamp(num2, 0f, 2f);
					a = num2 * a.normalized;
					Vector3 a2 = -a;
					rigidbody4.AddForce(70f * a, ForceMode.Force);
					rigidbody5.AddForce(70f * a2, ForceMode.Force);
				}
				else if (num2 < 0.4f)
				{
					rigidbody4.AddForce(50f * (num2 - 0.4f) * a.normalized, ForceMode.Force);
					rigidbody5.AddForce(-50f * (num2 - 0.4f) * a.normalized, ForceMode.Force);
				}
			}
		}
		if (!this.m_ropeCut)
		{
			this.PullEndpoints();
		}
	}

	private void PullEndpoints()
	{
		float num = 0f;
		for (int i = 1; i < this.m_nodes.Count; i++)
		{
			Rigidbody rigidbody = this.m_nodes[i - 1].rigidbody;
			Rigidbody rigidbody2 = this.m_nodes[i].rigidbody;
			if (rigidbody && rigidbody2)
			{
				float num2 = Vector3.Distance(rigidbody.position, rigidbody2.position);
				if (i > 1 && i < this.m_nodes.Count - 2)
				{
					if (num2 > 1.25f)
					{
						this.Cut(i);
						return;
					}
				}
				else if (num2 > 1.75f)
				{
					this.Cut(i);
					return;
				}
				num += num2;
			}
		}
		float num3 = 0.5f * (float)this.m_nodes.Count;
		float num4 = num / (1.18f * num3) - 1f;
		float num5 = 0.4f;
		num4 = num5 * this.ResponseCurve(num4 / num5);
		num4 = Mathf.Clamp(num4, 0f, num5);
		float num6 = num4 - this.m_previousStretchFactor;
		this.m_previousStretchFactor = num4;
		if (num > 1.18f * num3)
		{
			Rigidbody rigidbody3 = this.m_nodes[0].rigidbody;
			Rigidbody rigidbody4 = this.m_nodes[1].rigidbody;
			Vector3 position = rigidbody3.position;
			Vector3 position2 = rigidbody4.position;
			if (num6 < 0f)
			{
				num4 *= 0.7f;
			}
			float num7 = 750f;
			float num8 = num7 * num4;
			num8 = Mathf.Clamp(num8, 0f, 300f);
			Vector3 force = num8 * (position2 - position).normalized;
			if (this.LeftPart)
			{
				rigidbody3.AddForceAtPosition(force, position, ForceMode.Force);
			}
			rigidbody3 = this.m_nodes[this.m_nodes.Count - 1].rigidbody;
			rigidbody4 = this.m_nodes[this.m_nodes.Count - 2].rigidbody;
			position = rigidbody3.position;
			position2 = rigidbody4.position;
			force = num8 * (position2 - position).normalized;
			if (this.RightPart)
			{
				rigidbody3.AddForceAtPosition(force, position, ForceMode.Force);
			}
		}
	}

	public GameObject m_segment;

	public Material m_material;

	public GameObject m_gridVisualizationNode;

	private BasePart m_leftPart;

	private BasePart m_rightPart;

	private List<Rope.Node> m_nodes = new List<Rope.Node>();

	private LineRenderer m_lineRenderer;

	private LineRenderer m_lineRenderer2;

	private bool m_ropeCut;

	private int m_cutIndex;

	private List<Vector3> m_splinePoints = new List<Vector3>();

	private float m_previousStretchFactor;

	private struct Node
	{
		public Node(GameObject gameObject, Rigidbody rigidbody, Joint joint)
		{
			this.gameObject = gameObject;
			this.rigidbody = rigidbody;
			this.joint = joint;
		}

		public GameObject gameObject;

		public Rigidbody rigidbody;

		public Joint joint;
	}
}
