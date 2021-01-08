using Pathfinding.Serialization.JsonFx;
using UnityEngine;

public class BuildCustomizationLoader : Singleton<BuildCustomizationLoader>
{
	public bool IAPEnabled
	{
		get
		{
			return this.m_configuration.EnableIAP;
		}
	}

	public string SkynestBackend
	{
		get
		{
			return this.m_configuration.SkynestBackend;
		}
	}

	public bool IsChina
	{
		get
		{
			return this.m_configuration.BuildTypeChina;
		}
	}

	public string CustomerID
	{
		get
		{
			return this.m_configuration.CustomerId;
		}
	}

	public string SVNRevisionNumber
	{
		get
		{
			return this.m_configuration.SvnRevision;
		}
	}

	public string ApplicationVersion
	{
		get
		{
			return this.m_configuration.ApplicationVersion;
		}
	}

	public bool IsContentLimited
	{
		get
		{
			return this.m_configuration.BuildTypeContentLimited;
		}
	}

	public bool IsHDVersion
	{
		get
		{
			return this.m_configuration.BuildTypeHD;
		}
	}

	public bool IsDevelopmentBuild
	{
		get
		{
			return this.m_configuration.DevelopmentBuild;
		}
	}

	public bool CheatsEnabled
	{
		get
		{
			return this.m_configuration.EnableCheats;
		}
	}

	public bool LessCheats
	{
		get
		{
			return this.m_configuration.LessCheats;
		}
	}

	public bool IsOdyssey
	{
		get
		{
			return this.m_configuration.CustomerId == "AmazonUlt";
		}
	}

	private void Awake()
	{
		base.SetAsPersistant();
		TextAsset textAsset = Resources.Load<TextAsset>("gameConfig");
		this.m_configuration = JsonReader.Deserialize<BuildConfiguration>(textAsset.text);
		if (this.m_gameBuildParamLoader)
		{
			this.m_gameBuildParamLoader = UnityEngine.Object.Instantiate<GameObject>(this.m_gameBuildParamLoader);
			this.m_gameBuildParamLoader.SetActive(true);
		}
	}

	public GameObject m_gameBuildParamLoader;

	[SerializeField]
	private BuildConfiguration m_configuration;
}
