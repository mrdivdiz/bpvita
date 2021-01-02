using System;
using System.Collections.Generic;
using UnityEngine;

public class AtlasMaterials : MonoBehaviour
{
    public static AtlasMaterials Instance
    {
        get
        {
            if (AtlasMaterials._instance == null)
            {
                GameObject gameObject = Resources.Load<GameObject>("Utility/AtlasMaterials");
                if (gameObject != null)
                {
                    GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(gameObject);
                    UnityEngine.Object.DontDestroyOnLoad(gameObject2);
                    AtlasMaterials._instance = gameObject2.GetComponent<AtlasMaterials>();
                }
            }
            return AtlasMaterials._instance;
        }
    }

    public static bool IsInstantiated
    {
        get
        {
            return AtlasMaterials._instance != null;
        }
    }

    public List<Material> NormalMaterials
    {
        get
        {
            return this.normalMaterials;
        }
    }

    public List<Material> DimmedRenderQueueMaterials
    {
        get
        {
            return this.dimmedRenderQueueMaterials;
        }
    }

    public List<Material> RenderQueueMaterials
    {
        get
        {
            return this.renderQueueMaterials;
        }
    }

    public List<Material> PartQueueZMaterials
    {
        get
        {
            return this.partQueueZMaterials;
        }
    }

    public List<Material> GrayMaterials
    {
        get
        {
            return this.grayMaterials;
        }
    }

    public List<Material> ShineMaterials
    {
        get
        {
            return this.shineMaterials;
        }
    }

    public List<Material> AlphaMaterials
    {
        get
        {
            return this.alphaMaterials;
        }
    }

    public Material GetMaterial(Material source, MaterialType materialType)
    {
        if (source == null)
        {
            return null;
        }
        int num = -1;
        for (int i = this.normalMaterials.Count - 1; i >= 0; i--)
        {
            if (source.name.StartsWith(this.normalMaterials[i].name))
            {
                num = i;
                break;
            }
        }
        if (num < 0)
        {
            return null;
        }
        switch (materialType)
        {
            case AtlasMaterials.MaterialType.Normal:
                if (num < this.normalMaterials.Count)
                {
                    return this.normalMaterials[num];
                }
                break;
            case AtlasMaterials.MaterialType.Dimmed:
                if (num < this.dimmedRenderQueueMaterials.Count)
                {
                    return this.dimmedRenderQueueMaterials[num];
                }
                break;
            case AtlasMaterials.MaterialType.PartRender:
                if (num < this.renderQueueMaterials.Count)
                {
                    return this.renderQueueMaterials[num];
                }
                break;
            case AtlasMaterials.MaterialType.PartZ:
                if (num < this.partQueueZMaterials.Count)
                {
                    return this.partQueueZMaterials[num];
                }
                break;
            case AtlasMaterials.MaterialType.Gray:
                if (num < this.grayMaterials.Count)
                {
                    return this.grayMaterials[num];
                }
                break;
            case AtlasMaterials.MaterialType.Shiny:
                if (num < this.shineMaterials.Count)
                {
                    return this.shineMaterials[num];
                }
                break;
            case AtlasMaterials.MaterialType.Alpha:
                if (num < this.alphaMaterials.Count)
                {
                    return this.alphaMaterials[num];
                }
                break;
        }
        return null;
    }

    public Material GetCachedMaterialInstance(Material source, MaterialType materialType)
    {
        if (source == null)
        {
            return null;
        }
        if (this.cachedMaterialInstances == null)
        {
            this.cachedMaterialInstances = new Dictionary<string, Material>();
        }
        string materialKey = this.GetMaterialKey(source, materialType);
        Material material;
        if (this.cachedMaterialInstances.TryGetValue(materialKey, out material))
        {
            return material;
        }
        Material material2 = this.GetMaterial(source, materialType);
        if (material2 == null)
        {
            return null;
        }
        material = new Material(material2);
        this.cachedMaterialInstances.Add(materialKey, material);
        this.AddMaterialInstance(material);
        return material;
    }

    private string GetMaterialKey(Material source, MaterialType materialType)
    {
        if (source.name.Contains("_"))
        {
            return string.Format("{0}_{1}", source.name.Split(new char[]
            {
                '_'
            })[0], materialType.ToString());
        }
        else
        {
            return string.Format("{0}_{1}", source.name, materialType.ToString());
        }
    }

    public void AddMaterialInstance(Material materialInstance)
    {
        if (materialInstance == null)
        {
            return;
        }
        if (this.materialInstances == null)
        {
            this.materialInstances = new Dictionary<int, List<Material>>();
        }
        int indexForMaterial = this.GetIndexForMaterial(materialInstance);
        if (indexForMaterial >= 0 && indexForMaterial < this.atlasMaterialReferencePaths.Count)
        {
            List<Material> list;
            if (this.materialInstances.TryGetValue(indexForMaterial, out list))
            {
                list.Add(materialInstance);
            }
            else
            {
                list = new List<Material>();
                list.Add(materialInstance);
                this.materialInstances.Add(indexForMaterial, list);
            }
        }
    }

    public void RemoveMaterialInstance(Material materialInstance)
    {
        if (materialInstance == null)
        {
            return;
        }
        if (this.materialInstances == null)
        {
            this.materialInstances = new Dictionary<int, List<Material>>();
        }
        int indexForMaterial = this.GetIndexForMaterial(materialInstance);
        List<Material> list;
        if (indexForMaterial >= 0 && indexForMaterial < this.atlasMaterialReferencePaths.Count && this.materialInstances.TryGetValue(indexForMaterial, out list))
        {
            list.Remove(materialInstance);
        }
    }

    private int GetIndexForMaterial(Material source)
    {
        if (source != null)
        {
            for (int i = this.normalMaterials.Count - 1; i >= 0; i--)
            {
                if (source.mainTexture.name.StartsWith(this.normalMaterials[i].name))
                {
                    return i;
                }
            }
        }
        return -1;
    }

    private void OnApplicationPause(bool paused)
    {
        this.ReleaseTextureMemory(paused);
    }

    private void ReleaseTextureMemory(bool release)
    {
        this.SetEmptyAtlases(release);
        if (this.loadingScreen != null && WPFMonoBehaviour.hudCamera != null)
        {
            this.loadingScreen.transform.position = WPFMonoBehaviour.hudCamera.transform.position + Vector3.forward;
            this.loadingScreen.SetActive(release);
        }
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }

    private void SetEmptyAtlases(bool setEmpty)
    {
        for (int i = 0; i < this.atlasMaterialReferencePaths.Count; i++)
        {
            Texture mainTexture = this.emptyTexture;
            if (!setEmpty && this.atlasMaterialReferencePaths[i] != null)
            {
                Material material = Resources.Load<Material>(this.atlasMaterialReferencePaths[i]);
                if (material != null)
                {
                    mainTexture = material.mainTexture;
                }
            }
            if (i < this.normalMaterials.Count)
            {
                this.normalMaterials[i].mainTexture = mainTexture;
            }
            if (i < this.dimmedRenderQueueMaterials.Count)
            {
                this.dimmedRenderQueueMaterials[i].mainTexture = mainTexture;
            }
            if (i < this.renderQueueMaterials.Count)
            {
                this.renderQueueMaterials[i].mainTexture = mainTexture;
            }
            if (i < this.partQueueZMaterials.Count)
            {
                this.partQueueZMaterials[i].mainTexture = mainTexture;
            }
            if (i < this.grayMaterials.Count)
            {
                this.grayMaterials[i].mainTexture = mainTexture;
            }
            if (i < this.shineMaterials.Count)
            {
                this.shineMaterials[i].mainTexture = mainTexture;
            }
            if (i < this.alphaMaterials.Count)
            {
                this.alphaMaterials[i].mainTexture = mainTexture;
            }
            if (this.materialInstances != null)
            {
                List<Material> list;
                if (this.materialInstances.TryGetValue(i, out list) && list != null)
                {
                    for (int j = 0; j < list.Count; j++)
                    {
                        list[j].mainTexture = mainTexture;
                    }
                }
            }
        }
    }

    private static AtlasMaterials _instance;

    [SerializeField]
    private Texture2D emptyTexture;

    [SerializeField]
    private GameObject loadingScreen;

    [SerializeField]
    private List<Material> normalMaterials;

    [SerializeField]
    private List<Material> dimmedRenderQueueMaterials;

    [SerializeField]
    private List<Material> renderQueueMaterials;

    [SerializeField]
    private List<Material> partQueueZMaterials;

    [SerializeField]
    private List<Material> grayMaterials;

    [SerializeField]
    private List<Material> shineMaterials;

    [SerializeField]
    private List<Material> alphaMaterials;

    private Dictionary<string, Material> cachedMaterialInstances;

    private Dictionary<int, List<Material>> materialInstances;

    private Dictionary<int, string> atlasMaterialReferencePaths = new Dictionary<int, string>
    {
        {
            0,
            "GUISystem/RefIngameAtlas"
        },
        {
            1,
            "GUISystem/RefIngameAtlas2"
        },
        {
            2,
            "GUISystem/RefIngameAtlas3"
        },
        {
            3,
            "GUISystem/RefMenuAtlas"
        },
        {
            4,
            "GUISystem/RefMenuAtlas2"
        }
    };

    public enum MaterialType
    {
        Normal,
        Dimmed,
        PartRender,
        PartZ,
        Gray,
        Shiny,
        Alpha
    }
}
