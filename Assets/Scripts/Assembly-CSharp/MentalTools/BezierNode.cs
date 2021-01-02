using System;
using UnityEngine;

namespace MentalTools
{
	[Serializable]
	public class BezierNode
	{
		public BezierNode()
		{
		}

		public BezierNode(Vector3 _position, Vector3 _tangent0, Vector3 _tangent1)
		{
			this.Set(_position, _tangent0, _tangent1);
		}

		public Vector3 Position
		{
			get
			{
				return this.position;
			}
			set
			{
				this.position = value;
			}
		}

		public Vector3 ForwardTangent
		{
			get
			{
				return this.tangent0;
			}
			set
			{
				this.tangent0 = value;
			}
		}

		public Vector3 BackwardTangent
		{
			get
			{
				return this.tangent1;
			}
			set
			{
				this.tangent1 = value;
			}
		}

		public BezierNode.TangentType ForwardTangentType
		{
			get
			{
				return this.tangetType0;
			}
			set
			{
				this.tangetType0 = value;
			}
		}

		public BezierNode.TangentType BackwardTangentType
		{
			get
			{
				return this.tangetType1;
			}
			set
			{
				this.tangetType1 = value;
			}
		}

		public void Set(Vector3 _position, Vector3 _tangent0, Vector3 _tangent1)
		{
			this.position = _position;
			this.tangent0 = _tangent0;
			this.tangent1 = _tangent1;
		}

		public void SetTangentType(int _index, BezierNode.TangentType _type)
		{
			if (_index == 0)
			{
				this.tangetType0 = _type;
			}
			else if (_index == 1)
			{
				this.tangetType1 = _type;
			}
		}

		[SerializeField]
		private Vector3 position;

		[SerializeField]
		private Vector3 tangent0;

		[SerializeField]
		private Vector3 tangent1;

		[SerializeField]
		private BezierNode.TangentType tangetType0 = BezierNode.TangentType.Free;

		[SerializeField]
		private BezierNode.TangentType tangetType1 = BezierNode.TangentType.Free;

		public enum TangentType
		{
			None,
			Free,
			Mirrored
		}
	}
}
