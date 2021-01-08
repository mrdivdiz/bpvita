using System;
using System.Collections.Generic;
using UnityEngine;

namespace CakeRace
{
	[Serializable]
	public struct StartInfo
	{
		public Vector3 Position
		{
			get
			{
				return this.m_position;
			}
		}

		public List<int> GridData
		{
			get
			{
				return new List<int>(this.m_gridData);
			}
		}

		public void GetGridSize(out int columns, out int rows)
		{
			columns = 0;
			rows = 0;
			if (this.m_gridData == null)
			{
				return;
			}
			for (int i = 0; i < this.m_gridData.Length; i++)
			{
				if (this.m_gridData[i] > 0)
				{
					rows++;
					columns = Mathf.Max(columns, WPFMonoBehaviour.GetNumberOfHighestBit(this.m_gridData[i]) + 1);
				}
			}
		}

		[SerializeField]
		private Vector3 m_position;

		[SerializeField]
		private int[] m_gridData;
	}
}
