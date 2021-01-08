using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
	public bool NightVisionOn
	{
		get
		{
			return this.nvOn;
		}
	}

	public static LightManager Instance
	{
		get
		{
			return LightManager.instance;
		}
	}

	private void Awake()
	{
		LightManager.instance = this;
		this.nightVisionMask = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Lights/MaskQuadNightVision"));
		this.nightVisionMask.transform.parent = WPFMonoBehaviour.ingameCamera.transform;
		this.nightVisionMask.transform.localPosition = Vector3.forward * 0.5f;
		this.nightVisionMask.SetActive(false);
		EventManager.Connect(new EventManager.OnEvent<GameStateChanged>(this.OnGameStateChanged));
	}

	private void OnDestroy()
	{
		EventManager.Disconnect(new EventManager.OnEvent<GameStateChanged>(this.OnGameStateChanged));
	}

	public void Init(LevelManager _levelManager)
	{
		this.levelManager = _levelManager;
		this.mask = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Lights/MaskQuad"));
		this.mask.transform.parent = WPFMonoBehaviour.ingameCamera.transform;
		this.mask.transform.localPosition = Vector3.forward * 2.5f;
		this.pointLightPrefab = Resources.Load<GameObject>("Prefabs/Lights/PointLight");
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Lights/PointLightContainer"));
		if (gameObject != null)
		{
			gameObject.transform.position = WPFMonoBehaviour.ingameCamera.transform.position + Vector3.forward;
			this.container = gameObject.GetComponent<PointLightContainer>();
			if (this.container != null)
			{
				GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.pointLightPrefab);
				this.startPls = gameObject2.GetComponent<PointLightSource>();
				if (this.startPls != null)
				{
					this.startPls.size = 1f + 0.5f * (float)Mathf.Max(this.levelManager.GridWidth, this.levelManager.GridHeight);
					this.startPls.usesCurves = false;
				}
				if (gameObject2 != null)
				{
					gameObject2.name = "StartPointLight";
					Vector3 vector = this.levelManager.StartingPosition;
					vector += 0.5f * Vector3.up * (float)this.levelManager.GridHeight;
					vector -= Vector3.up * 0.5f;
					if (this.levelManager.GridWidth % 2 == 0)
					{
						vector += Vector3.right * 0.5f;
					}
					gameObject2.transform.position = vector;
				}
			}
		}
		this.isInit = true;
	}

	[ContextMenu("Toggle Nightvision")]
	public void ToggleNightVision()
	{
		if (!this.isInit)
		{
			return;
		}
		this.nvOn = !this.nvOn;
		this.nightVisionMask.SetActive(this.nvOn);
		Renderer component = this.mask.GetComponent<Renderer>();
		component.sharedMaterial = ((!this.nvOn) ? this.maskNormalMaterial : this.maskNVMaterial);
		this.container.borderMaterial = ((!this.nvOn) ? this.lightBorderNormalMaterial : this.lightBorderNVMaterial);
		this.UpdateLights(true);
		if (Singleton<SocialGameManager>.IsInstantiated())
		{
			Singleton<SocialGameManager>.Instance.ReportAchievementProgress("grp.LIGHT_UP_DARKNESS", 100.0);
		}
	}

	private void OnGameStateChanged(GameStateChanged newState)
	{
		if (!this.isInit)
		{
			return;
		}
		if (newState.state == LevelManager.GameState.Building)
		{
			if (this.startPls)
			{
				this.startPls.isEnabled = true;
			}
			if (this.disableNv && this.nvOn)
			{
				this.ToggleNightVision();
				this.disableNv = false;
			}
		}
		else if (newState.state == LevelManager.GameState.Running)
		{
			if (this.startPls)
			{
				this.startPls.isEnabled = false;
			}
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.pointLightPrefab);
			PointLightSource component = gameObject.GetComponent<PointLightSource>();
			if (component != null)
			{
				component.size = 2f;
				component.canCollide = true;
				component.canLitObjects = true;
				component.usesCurves = false;
			}
			if (this.nvOn)
			{
				this.disableNv = true;
			}
			if (gameObject != null)
			{
				gameObject.transform.parent = this.levelManager.ContraptionRunning.FindPig().transform;
				gameObject.transform.localPosition = Vector3.zero;
			}
			BasePart basePart = this.levelManager.ContraptionRunning.FindPart(BasePart.PartType.GoldenPig);
			if (basePart)
			{
				Transform transform = basePart.transform;
				GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.pointLightPrefab);
				PointLightSource component2 = gameObject2.GetComponent<PointLightSource>();
				if (component2 != null)
				{
					component2.size = 2f;
					component2.canCollide = true;
					component2.canLitObjects = true;
					component2.usesCurves = false;
				}
				gameObject2.transform.parent = transform.Find("Graphics");
				gameObject2.transform.localPosition = Vector3.zero;
			}
			List<WPFMonoBehaviour> list = new List<WPFMonoBehaviour>();
			foreach (TNT item in UnityEngine.Object.FindObjectsOfType<TNT>())
			{
				list.Add(item);
			}
			foreach (TNTBox item2 in UnityEngine.Object.FindObjectsOfType<TNTBox>())
			{
				list.Add(item2);
			}
			foreach (DynamicTNTBox item3 in UnityEngine.Object.FindObjectsOfType<DynamicTNTBox>())
			{
				list.Add(item3);
			}
			foreach (WPFMonoBehaviour wpfmonoBehaviour in list)
			{
				GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.pointLightPrefab);
				PointLightSource component3 = gameObject3.GetComponent<PointLightSource>();
				component3.size = 4f;
				component3.canCollide = true;
				component3.canLitObjects = true;
				component3.isEnabled = false;
				gameObject3.transform.parent = wpfmonoBehaviour.transform;
				gameObject3.transform.localPosition = Vector3.zero;
			}
			Rocket[] array4 = UnityEngine.Object.FindObjectsOfType<Rocket>();
			foreach (Rocket rocket in array4)
			{
				GameObject gameObject4 = UnityEngine.Object.Instantiate<GameObject>(this.pointLightPrefab);
				PointLightSource component4 = gameObject4.GetComponent<PointLightSource>();
				component4.size = 2f;
				component4.canCollide = true;
				component4.canLitObjects = true;
				component4.isEnabled = false;
				gameObject4.transform.parent = rocket.transform;
				gameObject4.transform.localPosition = Vector3.zero;
			}
			this.UpdateLights(true);
		}
		if (newState.state == LevelManager.GameState.Building && newState.prevState == LevelManager.GameState.Running)
		{
			this.UpdateLights(true);
		}
	}

	public void UpdateLights(bool waitOneFrame = true)
	{
		if (waitOneFrame)
		{
			base.StartCoroutine(this.WaitAndUpdate());
			return;
		}
		this.container.UpdateMeshes();
	}

	private IEnumerator WaitAndUpdate()
	{
		yield return new WaitForEndOfFrame();
		this.UpdateLights(false);
		yield break;
	}

	public static List<Vector3> enabledLightPositions;

	private static LightManager instance;

	[SerializeField]
	private Material maskNormalMaterial;

	[SerializeField]
	private Material maskNVMaterial;

	[SerializeField]
	private Material lightBorderNormalMaterial;

	[SerializeField]
	private Material lightBorderNVMaterial;

	private bool disableNv;

	private bool isInit;

	private bool nvOn;

	private PointLightContainer container;

	private GameObject pointLightPrefab;

	private LevelManager levelManager;

	private PointLightSource startPls;

	private GameObject mask;

	private GameObject nightVisionMask;
}
