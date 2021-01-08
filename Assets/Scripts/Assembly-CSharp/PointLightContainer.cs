using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PointLightContainer : MonoBehaviour
{
	private void Awake()
	{
		if (PointLightContainer.instance == null)
		{
			PointLightContainer.instance = this;
			return;
		}
		UnityEngine.Object.Destroy(base.gameObject);
	}

	private void Start()
	{
		this.root = base.transform;
		this.UpdateMeshes();
	}

	private void Update()
	{
		for (int i = 0; i < this.lights.Count; i++)
		{
			if (this.lights[i].lightSource != null)
			{
				this.lights[i].transform.position = new Vector3(this.lights[i].lightSource.position.x, this.lights[i].lightSource.position.y, this.lights[i].transform.position.z);
				this.lights[i].transform.rotation = Quaternion.AngleAxis(this.lights[i].lightSource.rotation.eulerAngles.z, Vector3.forward);
			}
			this.lights[i].border.transform.position = this.lights[i].transform.position + Vector3.forward * 0.5f;
			this.lights[i].border.transform.rotation = Quaternion.AngleAxis(this.lights[i].transform.rotation.eulerAngles.z, Vector3.forward);
			if (this.lights[i].lightType == PointLightMask.LightType.PointLight)
			{
				Vector3 localScale = this.lights[i].transform.localScale;
				this.lights[i].border.transform.localScale = new Vector3(localScale.x + this.lights[i].borderWidth, localScale.y + this.lights[i].borderWidth, 1f);
			}
			else
			{
				this.lights[i].border.transform.localScale = this.lights[i].transform.localScale;
			}
		}
	}

	public void UpdateMeshes()
	{
		if (this.lightContainer == null)
		{
			this.lightContainer = new GameObject("LightMeshes");
			this.lightContainer.transform.parent = this.root;
			this.lightContainer.transform.localPosition = Vector3.zero;
			this.lightContainer.transform.localScale = Vector3.one;
			this.lightContainer.transform.localRotation = Quaternion.identity;
		}
		if (this.lightContainer.transform.childCount > 0)
		{
			for (int i = 0; i < this.lightContainer.transform.childCount; i++)
			{
				UnityEngine.Object.Destroy(this.lightContainer.transform.GetChild(i).gameObject);
			}
		}
		this.lights = new List<PointLightMask>();
		this.lightSources = new List<PointLightSource>();
		foreach (PointLightSource item in UnityEngine.Object.FindObjectsOfType<PointLightSource>())
		{
			this.lightSources.Add(item);
		}
		for (int k = 0; k < this.lightSources.Count; k++)
		{
			PointLightSource lightSource = this.lightSources[k];
			this.CreateLight(k, lightSource);
		}
		if (this.lightSkinMesh == null)
		{
			this.lightSkinMesh = new GameObject("LightSkinnedMesh");
			this.lightSkinMesh.transform.parent = this.root;
			this.lightSkinMesh.transform.localPosition = Vector3.zero;
			this.lightSkinMesh.transform.localRotation = Quaternion.identity;
			this.lightSmr = this.lightSkinMesh.AddComponent<SkinnedMeshRenderer>();
			this.lightSmr.updateWhenOffscreen = true;
		}
		this.CollectMeshes();
	}

	private void CreateLight(int id, PointLightSource _lightSource)
	{
		Transform transform = this.lightContainer.transform;
		GameObject gameObject;
		if (_lightSource.lightType == PointLightMask.LightType.PointLight)
		{
			gameObject = UnityEngine.Object.Instantiate<GameObject>(this.pointLightPrefab);
			gameObject.name = string.Format("PointLight{0:00}", id);
		}
		else
		{
			gameObject = UnityEngine.Object.Instantiate<GameObject>(this.beamLightPrefab);
			gameObject.name = string.Format("BeamLight{0:00}", id);
		}
		gameObject.transform.parent = transform;
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.transform.localScale = Vector3.one;
		gameObject.transform.localRotation = Quaternion.identity;
		PointLightMask component = gameObject.GetComponent<PointLightMask>();
		component.border = UnityEngine.Object.Instantiate<GameObject>(this.borderPrefab);
		component.border.transform.parent = transform;
		component.border.transform.localPosition = new Vector3(0f, 0f, 0.1f);
		component.border.transform.localScale = Vector3.one;
		component.border.transform.localRotation = Quaternion.identity;
		component.border.name = string.Format("Border{0:00}", id);
		component.radius = _lightSource.size;
		component.borderWidth = _lightSource.borderWidth;
		component.lightSource = _lightSource.transform;
		component.vertexCount = _lightSource.vertexCount;
		_lightSource.lightTransform = component.transform;
		component.lightType = _lightSource.lightType;
		if (component.lightType == PointLightMask.LightType.BeamLight)
		{
			BeamLightMask beamLightMask = component as BeamLightMask;
			beamLightMask.angle = _lightSource.beamAngle;
			beamLightMask.cutHeight = _lightSource.beamCut;
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.pointLightPrefab);
			gameObject2.name = string.Format("BeamLightBase{0:00}", id);
			gameObject2.transform.parent = transform;
			gameObject2.transform.localPosition = Vector3.zero;
			gameObject2.transform.localScale = Vector3.one;
			gameObject2.transform.localRotation = Quaternion.identity;
			PointLightMask component2 = gameObject2.GetComponent<PointLightMask>();
			component2.border = UnityEngine.Object.Instantiate<GameObject>(this.borderPrefab);
			component2.border.transform.parent = transform;
			component2.border.transform.localPosition = new Vector3(0f, 0f, 0.1f);
			component2.border.transform.localScale = Vector3.one;
			component2.border.transform.localRotation = Quaternion.identity;
			component2.border.name = string.Format("Border{0:00}", id);
			component2.radius = 0.5f;
			component2.borderWidth = 0.5f;
			component2.lightSource = _lightSource.transform;
			component2.vertexCount = _lightSource.vertexCount;
			_lightSource.baseLightTransform = component2.transform;
			component2.lightType = PointLightMask.LightType.PointLight;
			component2.UpdateMesh();
			_lightSource.colliderSize = component2.radius + component2.borderWidth;
			this.lights.Add(component2);
		}
		component.UpdateMesh();
		if (component.lightType == PointLightMask.LightType.BeamLight)
		{
			BeamLightMask beamLightMask2 = (BeamLightMask)component;
			_lightSource.colliderSize = beamLightMask2.colliderSize;
			_lightSource.beamArcCenter = beamLightMask2.arcCenter;
		}
		else
		{
			_lightSource.colliderSize = _lightSource.size + _lightSource.borderWidth;
		}
		this.lights.Add(component);
	}

	public void CollectMeshes()
	{
		int count = this.lights.Count;
		Transform[] array = new Transform[count * 2];
		List<BoneWeight> list = new List<BoneWeight>();
		List<Matrix4x4> list2 = new List<Matrix4x4>();
		List<Vector3> list3 = new List<Vector3>();
		List<int> list4 = new List<int>();
		List<int> list5 = new List<int>();
		List<Vector2> list6 = new List<Vector2>();
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < count; i++)
		{
			PointLightMask pointLightMask = this.lights[i];
			MeshFilter meshFilter = pointLightMask.meshFilter;
			Transform transform = pointLightMask.transform;
			array[num2] = transform;
			list2.Add(array[num2].worldToLocalMatrix * this.root.localToWorldMatrix);
			for (int j = 0; j < meshFilter.sharedMesh.vertexCount; j++)
			{
				list3.Add(transform.localPosition + meshFilter.sharedMesh.vertices[j]);
				list6.Add(meshFilter.sharedMesh.uv[j]);
				list.Add(new BoneWeight
				{
					boneIndex0 = num2,
					weight0 = 1f
				});
			}
			for (int k = 0; k < meshFilter.sharedMesh.triangles.Length; k++)
			{
				list4.Add(num + meshFilter.sharedMesh.triangles[k]);
			}
			num += meshFilter.sharedMesh.vertexCount;
			num2++;
		}
		for (int l = 0; l < count; l++)
		{
			PointLightMask pointLightMask2 = this.lights[l];
			if (!(pointLightMask2.border == null))
			{
				MeshFilter component = pointLightMask2.border.GetComponent<MeshFilter>();
				Transform transform2 = pointLightMask2.border.transform;
				array[num2] = transform2;
				list2.Add(array[num2].worldToLocalMatrix * this.root.localToWorldMatrix);
				for (int m = 0; m < component.sharedMesh.vertexCount; m++)
				{
					list3.Add(transform2.localPosition + component.sharedMesh.vertices[m]);
					list6.Add(component.sharedMesh.uv[m]);
					list.Add(new BoneWeight
					{
						boneIndex0 = num2,
						weight0 = 1f
					});
				}
				for (int n = 0; n < component.sharedMesh.triangles.Length; n++)
				{
					list5.Add(num + component.sharedMesh.triangles[n]);
				}
				num += component.sharedMesh.vertexCount;
				num2++;
			}
		}
		Mesh mesh = new Mesh();
		mesh.name = "LightCompoundMesh";
		mesh.vertices = list3.ToArray();
		mesh.subMeshCount = 2;
		mesh.SetTriangles(list4.ToArray(), 0);
		mesh.SetTriangles(list5.ToArray(), 1);
		mesh.uv = list6.ToArray();
		mesh.boneWeights = list.ToArray();
		mesh.bindposes = list2.ToArray();
		mesh.RecalculateNormals();
		mesh.RecalculateBounds();
		Material[] sharedMaterials = new Material[]
		{
			this.lightMaterial,
			this.borderMaterial
		};
		this.lightSmr.sharedMaterials = sharedMaterials;
		this.lightSmr.bones = array;
		this.lightSmr.sharedMesh = mesh;
		this.lightSmr.shadowCastingMode = ShadowCastingMode.Off;
		this.lightSmr.receiveShadows = false;
		foreach (PointLightSource pointLightSource in this.lightSources)
		{
			if (pointLightSource.lightType == PointLightMask.LightType.PointLight)
			{
				pointLightSource.lightTransform.localScale = new Vector3(pointLightSource.size, pointLightSource.size, 1f);
			}
			else
			{
				pointLightSource.baseLightTransform.localScale = new Vector3(0.5f, 0.5f, 1f);
			}
			pointLightSource.Init();
		}
	}

	public Material lightMaterial;

	public Material borderMaterial;

	public GameObject pointLightPrefab;

	public GameObject beamLightPrefab;

	public GameObject borderPrefab;

	private GameObject lightContainer;

	private GameObject lightSkinMesh;

	private Transform root;

	private SkinnedMeshRenderer lightSmr;

	private List<PointLightMask> lights;

	private List<PointLightSource> lightSources;

	private static PointLightContainer instance;
}
