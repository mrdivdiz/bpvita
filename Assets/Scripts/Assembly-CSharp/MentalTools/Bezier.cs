using System;
using System.Collections.Generic;
using UnityEngine;

namespace MentalTools
{
	[Serializable]
	public class Bezier
	{
		public Bezier()
		{
			this.nodes = new List<BezierNode>();
		}

		public int Count
		{
			get
			{
				return (this.nodes == null) ? 0 : this.nodes.Count;
			}
		}

		public BezierNode this[int index]
		{
			get
			{
				if (this.nodes != null && index >= 0 && index < this.nodes.Count)
				{
					return this.nodes[index];
				}
				return null;
			}
		}

		public BezierNode AddNode(Vector3 _pos, Vector3 _dir)
		{
			BezierNode bezierNode = new BezierNode(_pos, _dir, -_dir);
			this.nodes.Add(bezierNode);
			return bezierNode;
		}

		public BezierNode AddNode(Vector3 _pos, Vector3 _dir0, Vector3 _dir1)
		{
			BezierNode bezierNode = new BezierNode(_pos, _dir0, _dir1);
			this.nodes.Add(bezierNode);
			return bezierNode;
		}

		public void RemoveNode(int index)
		{
			this.nodes.RemoveAt(index);
		}

		public void ConfineToAxisSpace(MentalMath.AxisSpace space)
		{
			switch (space)
			{
			case MentalMath.AxisSpace.XY:
				for (int i = 0; i < this.nodes.Count; i++)
				{
					this.nodes[i].Position = new Vector3(this.nodes[i].Position.x, this.nodes[i].Position.y, 0f);
					this.nodes[i].BackwardTangent = new Vector3(this.nodes[i].BackwardTangent.x, this.nodes[i].BackwardTangent.y, 0f);
					this.nodes[i].ForwardTangent = new Vector3(this.nodes[i].ForwardTangent.x, this.nodes[i].ForwardTangent.y, 0f);
				}
				break;
			case MentalMath.AxisSpace.XZ:
				for (int j = 0; j < this.nodes.Count; j++)
				{
					this.nodes[j].Position = new Vector3(this.nodes[j].Position.x, 0f, this.nodes[j].Position.z);
					this.nodes[j].BackwardTangent = new Vector3(this.nodes[j].BackwardTangent.x, 0f, this.nodes[j].Position.z);
					this.nodes[j].ForwardTangent = new Vector3(this.nodes[j].ForwardTangent.x, 0f, this.nodes[j].Position.z);
				}
				break;
			case MentalMath.AxisSpace.YZ:
				for (int k = 0; k < this.nodes.Count; k++)
				{
					this.nodes[k].Position = new Vector3(0f, this.nodes[k].Position.y, this.nodes[k].Position.z);
					this.nodes[k].BackwardTangent = new Vector3(0f, this.nodes[k].BackwardTangent.y, this.nodes[k].Position.z);
					this.nodes[k].ForwardTangent = new Vector3(0f, this.nodes[k].ForwardTangent.y, this.nodes[k].Position.z);
				}
				break;
			}
		}

		public Vector3 GetPoint(float ct, bool loop)
		{
			return this.GetPoint(ct, loop, Vector3.zero);
		}

		public Vector3 GetPoint(float ct, bool loop, Vector3 root)
		{
			if (this.nodes == null || this.nodes.Count < 2)
			{
				return Vector3.zero;
			}
			int count = this.nodes.Count;
			ct = Mathf.Clamp01(ct);
			float num = ct / (1f / (float)((!loop) ? (count - 1) : count));
			int num2 = (!Mathf.Approximately(ct, 1f)) ? Mathf.Clamp(Mathf.FloorToInt(num), 0, (!loop) ? (count - 2) : (count - 1)) : ((!loop) ? (count - 2) : (count - 1));
			float num3 = (!Mathf.Approximately(ct, 1f)) ? (num % 1f) : 1f;
			Vector3 position = this.nodes[num2].Position;
			Vector3 a = position + this.nodes[num2].ForwardTangent;
			Vector3 position2 = this.nodes[(num2 + 1 < count) ? (num2 + 1) : 0].Position;
			Vector3 a2 = position2 + this.nodes[(num2 + 1 < count) ? (num2 + 1) : 0].BackwardTangent;
			return root + (Mathf.Pow(1f - num3, 3f) * position + 3f * Mathf.Pow(1f - num3, 2f) * num3 * a + 3f * (1f - num3) * Mathf.Pow(num3, 2f) * a2 + Mathf.Pow(num3, 3f) * position2);
		}

		[SerializeField]
		private List<BezierNode> nodes;
	}
}
