using System;
using UnityEngine;

namespace CakeRace
{
	[Serializable]
	public struct ObjectLocation
	{
		public Vector3 Position
		{
			get
			{
				return this.m_position;
			}
		}

		public Quaternion Rotation
		{
			get
			{
				return this.m_rotation;
			}
		}

		public GameObject Prefab
		{
			get
			{
				return this.m_prefab;
			}
		}

		[SerializeField]
		private Vector3 m_position;

		[SerializeField]
		private Quaternion m_rotation;

		[SerializeField]
		private GameObject m_prefab;
	}
}
