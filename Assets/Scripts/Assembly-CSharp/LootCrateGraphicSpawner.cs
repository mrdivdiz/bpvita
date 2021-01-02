using UnityEngine;

public class LootCrateGraphicSpawner : WPFMonoBehaviour
{
	private static LootCrateGraphicSpawner Instance
	{
		get
		{
			if (LootCrateGraphicSpawner.s_instance == null)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(WPFMonoBehaviour.gameData.m_lootCrateGraphicsSpawner);
				LootCrateGraphicSpawner.s_instance = gameObject.GetComponent<LootCrateGraphicSpawner>();
			}
			return LootCrateGraphicSpawner.s_instance;
		}
	}

	public static GameObject CreateCrate(LootCrateType type, Transform parent, Vector3 localPosition, Vector3 localScale, Quaternion localRotation)
	{
		if (LootCrateGraphicSpawner.Instance == null)
		{
			return null;
		}
		GameObject prefab;
		switch (type)
		{
		case LootCrateType.Wood:
			prefab = LootCrateGraphicSpawner.Instance.woodCrate;
			break;
		case LootCrateType.Metal:
			prefab = LootCrateGraphicSpawner.Instance.metalCrate;
			break;
		case LootCrateType.Gold:
			prefab = LootCrateGraphicSpawner.Instance.goldCrate;
			break;
		case LootCrateType.Cardboard:
			prefab = LootCrateGraphicSpawner.Instance.cardboardCrate;
			break;
		case LootCrateType.Glass:
			prefab = LootCrateGraphicSpawner.Instance.glassCrate;
			break;
		case LootCrateType.Bronze:
			prefab = LootCrateGraphicSpawner.Instance.bronzeCrate;
			break;
		case LootCrateType.Marble:
			prefab = LootCrateGraphicSpawner.Instance.marbleCrate;
			break;
		default:
			return null;
		}
		return LootCrateGraphicSpawner.CreateObject(prefab, parent, localPosition, localScale, localRotation);
	}

	public static GameObject CreateCrateSmall(LootCrateType type, Transform parent, Vector3 localPosition, Vector3 localScale, Quaternion localRotation)
	{
		if (LootCrateGraphicSpawner.Instance == null)
		{
			return null;
		}
		GameObject prefab;
		switch (type)
		{
		case LootCrateType.Wood:
			prefab = LootCrateGraphicSpawner.Instance.woodCrateSmall;
			break;
		case LootCrateType.Metal:
			prefab = LootCrateGraphicSpawner.Instance.metalCrateSmall;
			break;
		case LootCrateType.Gold:
			prefab = LootCrateGraphicSpawner.Instance.goldCrateSmall;
			break;
		case LootCrateType.Cardboard:
			prefab = LootCrateGraphicSpawner.Instance.cardboardCrateSmall;
			break;
		case LootCrateType.Glass:
			prefab = LootCrateGraphicSpawner.Instance.glassCrateSmall;
			break;
		case LootCrateType.Bronze:
			prefab = LootCrateGraphicSpawner.Instance.bronzeCrateSmall;
			break;
		case LootCrateType.Marble:
			prefab = LootCrateGraphicSpawner.Instance.marbleCrateSmall;
			break;
		default:
			return null;
		}
		return LootCrateGraphicSpawner.CreateObject(prefab, parent, localPosition, localScale, localRotation);
	}

	public static GameObject CreateCrateSilhouette(LootCrateType type, Transform parent, Vector3 localPosition, Vector3 localScale, Quaternion localRotation)
	{
		if (LootCrateGraphicSpawner.Instance == null)
		{
			return null;
		}
		GameObject prefab;
		switch (type)
		{
		case LootCrateType.Wood:
			prefab = LootCrateGraphicSpawner.Instance.woodCrateSilhouette;
			break;
		case LootCrateType.Metal:
			prefab = LootCrateGraphicSpawner.Instance.metalCrateSilhouette;
			break;
		case LootCrateType.Gold:
			prefab = LootCrateGraphicSpawner.Instance.goldCrateSilhouette;
			break;
		case LootCrateType.Cardboard:
			prefab = LootCrateGraphicSpawner.Instance.cardboardCrateSilhouette;
			break;
		case LootCrateType.Glass:
			prefab = LootCrateGraphicSpawner.Instance.glassCrateSilhouette;
			break;
		case LootCrateType.Bronze:
			prefab = LootCrateGraphicSpawner.Instance.bronzeCrateSilhouette;
			break;
		case LootCrateType.Marble:
			prefab = LootCrateGraphicSpawner.Instance.marbleCrateSilhouette;
			break;
		default:
			return null;
		}
		return LootCrateGraphicSpawner.CreateObject(prefab, parent, localPosition, localScale, localRotation);
	}

	private static GameObject CreateObject(GameObject prefab, Transform parent, Vector3 localPosition, Vector3 localScale, Quaternion localRotation)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(prefab);
		gameObject.transform.parent = parent;
		gameObject.transform.localPosition = localPosition;
		gameObject.transform.localRotation = localRotation;
		gameObject.transform.localScale = localScale;
		return gameObject;
	}

	private static LootCrateGraphicSpawner s_instance;

	[SerializeField]
	private GameObject woodCrate;

	[SerializeField]
	private GameObject metalCrate;

	[SerializeField]
	private GameObject goldCrate;

	[SerializeField]
	private GameObject cardboardCrate;

	[SerializeField]
	private GameObject glassCrate;

	[SerializeField]
	private GameObject bronzeCrate;

	[SerializeField]
	private GameObject marbleCrate;

	[SerializeField]
	private GameObject woodCrateSmall;

	[SerializeField]
	private GameObject metalCrateSmall;

	[SerializeField]
	private GameObject goldCrateSmall;

	[SerializeField]
	private GameObject cardboardCrateSmall;

	[SerializeField]
	private GameObject glassCrateSmall;

	[SerializeField]
	private GameObject bronzeCrateSmall;

	[SerializeField]
	private GameObject marbleCrateSmall;

	[SerializeField]
	private GameObject woodCrateSilhouette;

	[SerializeField]
	private GameObject metalCrateSilhouette;

	[SerializeField]
	private GameObject goldCrateSilhouette;

	[SerializeField]
	private GameObject cardboardCrateSilhouette;

	[SerializeField]
	private GameObject glassCrateSilhouette;

	[SerializeField]
	private GameObject bronzeCrateSilhouette;

	[SerializeField]
	private GameObject marbleCrateSilhouette;
}
