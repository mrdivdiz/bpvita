using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnDrawGizmos()
	{
		foreach (Vector3 center in this.m_outlineVertexList)
		{
			Gizmos.DrawWireSphere(center, 0.01f);
		}
		foreach (Vector3 center2 in this.m_innerMeshPointsList)
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(center2, 0.1f);
		}
	}

	public bool m_outlineDetailMesh;

	public bool m_innerDetailMesh;

	[HideInInspector]
	public List<Vector3> m_outlineVertexList = new List<Vector3>();

	[HideInInspector]
	public List<Vector3> m_innerMeshPointsList = new List<Vector3>();

	public int m_innerDetailMeshAMount;
}
