using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeshCombine : Singleton<MeshCombine>
{
	private void Awake()
	{
		SceneManager.sceneLoaded += this.OnSceneLoaded;
	}

	private void OnDestroy()
	{
		SceneManager.sceneLoaded -= this.OnSceneLoaded;
	}

	private void Start()
	{
		base.SetAsPersistant();
		this.CombineScene();
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
	{
		this.CombineScene();
	}

	private void CombineScene()
	{
		List<List<GameObject>> list = this.FindGrounds();
		for (int i = 0; i < list.Count; i++)
		{
			List<GameObject> list2 = new List<GameObject>();
			for (int j = 0; j < list[i].Count; j++)
			{
				list2.AddRange(this.FindChilds(list[i][j]));
			}
			List<List<GameObject>> list3 = this.SortGameObjectsByMaterial(list2);
			for (int k = 0; k < list3.Count; k++)
			{
				this.Combine(list3[k].ToArray());
			}
		}
		List<List<GameObject>> list4 = this.FindProps();
		for (int l = 0; l < list4.Count; l++)
		{
			List<List<GameObject>> list5 = this.SortGameObjectsByMaterial(list4[l]);
			for (int m = 0; m < list5.Count; m++)
			{
				this.Combine(list5[m].ToArray());
			}
		}
		base.StartCoroutine(this.DelayedAction(delegate
		{
			Resources.UnloadUnusedAssets();
			GC.Collect();
		}));
	}

	private List<GameObject> FindChilds(GameObject parent)
	{
		List<GameObject> list = new List<GameObject>();
		for (int i = 0; i < parent.transform.childCount; i++)
		{
			GameObject gameObject = parent.transform.GetChild(i).gameObject;
			if (gameObject.tag == "Static" && gameObject.GetComponent<Renderer>() != null)
			{
				list.Add(gameObject);
			}
			list.AddRange(this.FindChilds(gameObject));
		}
		return list;
	}

	private void Combine(GameObject[] objects)
	{
		List<MeshFilter> list = new List<MeshFilter>();
		float num = 0f;
		for (int i = 0; i < objects.Length; i++)
		{
			if (i == 0)
			{
				num = objects[i].transform.position.z;
			}
			else
			{
				num = (num + objects[i].transform.position.z) * 0.5f;
			}
			MeshFilter component = objects[i].GetComponent<MeshFilter>();
			if (component != null)
			{
				list.Add(component);
			}
		}
		int num2 = 0;
		bool flag = true;
		while (flag)
		{
			List<MeshFilter> list2 = new List<MeshFilter>();
			while (list.Count > 0 && num2 + list[0].sharedMesh.vertexCount < 65534)
			{
				MeshFilter meshFilter = this.FindMeshFilter(list, 65534 - num2);
				if (!(meshFilter != null))
				{
					break;
				}
				if (!list2.Contains(meshFilter))
				{
					list2.Add(meshFilter);
					num2 += meshFilter.sharedMesh.vertexCount;
					list.Remove(meshFilter);
				}
			}
			this.Combine(list2.ToArray(), num);
			num2 = 0;
			flag = (list.Count > 0);
		}
	}

	private void Combine(MeshFilter[] meshFilters, float depth)
	{
		if (meshFilters.Length <= 0)
		{
			return;
		}
		CombineInstance[] array = new CombineInstance[meshFilters.Length];
		for (int i = 0; i < array.Length; i++)
		{
			meshFilters[i].transform.position -= Vector3.forward * depth;
			array[i].mesh = meshFilters[i].sharedMesh;
			array[i].transform = meshFilters[i].transform.localToWorldMatrix;
			meshFilters[i].GetComponent<Renderer>().enabled = false;
		}
		GameObject gameObject = new GameObject("CombinedMesh_" + meshFilters[0].GetComponent<Renderer>().sharedMaterial.name);
		gameObject.transform.position += Vector3.forward * depth;
		MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
		gameObject.AddComponent<MeshRenderer>();
		gameObject.GetComponent<Renderer>().sharedMaterial = meshFilters[0].GetComponent<Renderer>().sharedMaterial;
		meshFilter.sharedMesh = new Mesh();
		meshFilter.sharedMesh.name = "CombinedMesh";
		meshFilter.sharedMesh.CombineMeshes(array);
		for (int j = 0; j < meshFilters.Length; j++)
		{
			if (meshFilters[j].gameObject.GetComponent<PointLightSource>() == null)
			{
				UnityEngine.Object.Destroy(meshFilters[j].gameObject);
			}
		}
	}

	private MeshFilter FindMeshFilter(List<MeshFilter> meshFilters, int vertexLimit)
	{
		for (int i = 0; i < meshFilters.Count; i++)
		{
			if (meshFilters[i].sharedMesh.vertexCount <= vertexLimit)
			{
				return meshFilters[i];
			}
		}
		return null;
	}

	private List<List<GameObject>> SortGameObjectsByMaterial(List<GameObject> gameObjects)
	{
		List<string> list = new List<string>();
		List<List<GameObject>> list2 = new List<List<GameObject>>();
		for (int i = 0; i < gameObjects.Count; i++)
		{
			if (!(gameObjects[i].GetComponent<Renderer>() == null))
			{
				string item = string.Empty;
				if (gameObjects[i].GetComponent<Renderer>().sharedMaterial.mainTexture != null)
				{
					item = gameObjects[i].GetComponent<Renderer>().sharedMaterial.name + "_" + gameObjects[i].GetComponent<Renderer>().sharedMaterial.mainTexture.name;
				}
				else
				{
					item = gameObjects[i].GetComponent<Renderer>().sharedMaterial.name;
				}
				if (!list.Contains(item))
				{
					list.Add(item);
				}
			}
		}
		for (int j = 0; j < list.Count; j++)
		{
			list2.Add(new List<GameObject>());
		}
		for (int k = 0; k < gameObjects.Count; k++)
		{
			if (!(gameObjects[k].GetComponent<Renderer>() == null))
			{
				string item2 = string.Empty;
				if (gameObjects[k].GetComponent<Renderer>().sharedMaterial.mainTexture != null)
				{
					item2 = gameObjects[k].GetComponent<Renderer>().sharedMaterial.name + "_" + gameObjects[k].GetComponent<Renderer>().sharedMaterial.mainTexture.name;
				}
				else
				{
					item2 = gameObjects[k].GetComponent<Renderer>().sharedMaterial.name;
				}
				if (!list2[list.IndexOf(item2)].Contains(gameObjects[k]))
				{
					list2[list.IndexOf(item2)].Add(gameObjects[k]);
				}
			}
		}
		return list2;
	}

	private List<List<GameObject>> FindGrounds()
	{
		List<GameObject> list = new List<GameObject>(GameObject.FindGameObjectsWithTag("Ground"));
		List<List<GameObject>> list2 = new List<List<GameObject>>();
		List<int> list3 = new List<int>();
		this.groundDepths = new List<int>();
		this.groundDepths.Add(0);
		if (list.Count == 0)
		{
			return list2;
		}
		List<string> list4 = new List<string>();
		for (int i = 0; i < list.Count; i++)
		{
			int num = (int)(list[i].transform.position.z * 100f);
			bool flag = false;
			for (int j = 0; j < this.groundDepths.Count; j++)
			{
				if (this.groundDepths[j] == num)
				{
					flag = true;
				}
			}
			if (!flag)
			{
				int num2 = -1;
				for (int k = 0; k < this.groundDepths.Count; k++)
				{
					if (this.groundDepths[k] > num)
					{
						num2 = k;
						break;
					}
				}
				if (num2 >= 0)
				{
					this.groundDepths.Insert(num2, num);
				}
				else
				{
					this.groundDepths.Add(num);
				}
			}
			list3.Add(num);
			if (!list4.Contains(this.GenerateGroundName(list[i], num)))
			{
				list4.Add(this.GenerateGroundName(list[i], num));
			}
		}
		for (int l = 0; l < list4.Count; l++)
		{
			list2.Add(new List<GameObject>());
		}
		for (int m = 0; m < list.Count; m++)
		{
			list2[list4.IndexOf(this.GenerateGroundName(list[m], list3[m]))].Add(list[m]);
		}
		return list2;
	}

	private string GenerateGroundName(GameObject go, int depth)
	{
		if (depth >= 0)
		{
			return string.Format("{0}_{1}", go.name, depth);
		}
		return go.name;
	}

	private List<List<GameObject>> FindProps()
	{
		List<GameObject> list = new List<GameObject>(GameObject.FindGameObjectsWithTag("Prop"));
		List<List<GameObject>> list2 = new List<List<GameObject>>();
		if (list.Count == 0)
		{
			return list2;
		}
		List<bool> list3 = new List<bool>();
		for (int i = 0; i < list.Count; i++)
		{
			list3.Add(false);
		}
		for (int j = 0; j < this.groundDepths.Count; j++)
		{
			List<GameObject> list4 = new List<GameObject>();
			for (int k = 0; k < list.Count; k++)
			{
				int num = (int)(list[k].transform.position.z * 100f);
				if (!list3[k] && num < this.groundDepths[j])
				{
					int num2 = -1;
					for (int l = 0; l < list4.Count; l++)
					{
						int num3 = (int)(list4[l].transform.position.z * 100f);
						if (num3 < num)
						{
							num2 = l;
							break;
						}
					}
					if (num2 >= 0)
					{
						list4.Insert(num2, list[k]);
					}
					else
					{
						list4.Add(list[k]);
					}
					list3[k] = true;
				}
			}
			if (list4.Count > 0)
			{
				list2.Add(list4);
			}
		}
		return list2;
	}

	private IEnumerator DelayedAction(Action action)
	{
		yield return null;
		if (action != null)
		{
			action();
		}
		yield break;
	}

	private const int VERTEX_LIMIT = 65534;

	private List<int> groundDepths;
}
