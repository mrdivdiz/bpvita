using System;
using UnityEngine;

public class DailyChallengeNextCrates : WPFMonoBehaviour
{
	private void Start()
	{
		if (!Singleton<DailyChallenge>.IsInstantiated())
		{
			return;
		}
		this.lootCrates = new GameObject("LootCrates").transform;
		this.lootCrates.transform.parent = base.transform;
		this.lootCrates.transform.localPosition = Vector3.zero;
		this.lootCrates.transform.localScale = Vector3.one;
		if (Singleton<DailyChallenge>.Instance.Initialized)
		{
			this.UpdateLootCrates();
			DailyChallenge instance = Singleton<DailyChallenge>.Instance;
			instance.OnDailyChallengeChanged = (Action)Delegate.Combine(instance.OnDailyChallengeChanged, new Action(this.UpdateLootCrates));
		}
		else
		{
			DailyChallenge instance2 = Singleton<DailyChallenge>.Instance;
			instance2.OnInitialize = (Action)Delegate.Combine(instance2.OnInitialize, new Action(delegate()
			{
				this.UpdateLootCrates();
				DailyChallenge instance3 = Singleton<DailyChallenge>.Instance;
				instance3.OnDailyChallengeChanged = (Action)Delegate.Combine(instance3.OnDailyChallengeChanged, new Action(this.UpdateLootCrates));
			}));
		}
	}

	private void OnDestroy()
	{
		if (Singleton<DailyChallenge>.IsInstantiated())
		{
			DailyChallenge instance = Singleton<DailyChallenge>.Instance;
			instance.OnDailyChallengeChanged = (Action)Delegate.Remove(instance.OnDailyChallengeChanged, new Action(this.UpdateLootCrates));
		}
	}

	private void UpdateLootCrates()
	{
		for (int i = 0; i < this.lootCrates.childCount; i++)
		{
			UnityEngine.Object.Destroy(this.lootCrates.GetChild(i).gameObject);
		}
		for (int j = 0; j < this.cratePositions.Length; j++)
		{
			GameObject gameObject;
			GameObject gameObject2;
			switch (Singleton<DailyChallenge>.Instance.TomorrowsLootCrate(j))
			{
			case LootCrateType.Wood:
				gameObject = UnityEngine.Object.Instantiate<GameObject>(this.woodCrateSilhouette);
				gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.woodCratePrefab);
				break;
			case LootCrateType.Metal:
				gameObject = UnityEngine.Object.Instantiate<GameObject>(this.metalCrateSilhouette);
				gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.metalCratePrefab);
				break;
			case LootCrateType.Gold:
				gameObject = UnityEngine.Object.Instantiate<GameObject>(this.goldCrateSilhouette);
				gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.goldCratePrefab);
				break;
			case LootCrateType.Cardboard:
				gameObject = UnityEngine.Object.Instantiate<GameObject>(this.cardboardCrateSilhouette);
				gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.cardboardCratePrefab);
				break;
			case LootCrateType.Glass:
				gameObject = UnityEngine.Object.Instantiate<GameObject>(this.glassCrateSilhouette);
				gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.glassCratePrefab);
				break;
			case LootCrateType.Bronze:
				gameObject = UnityEngine.Object.Instantiate<GameObject>(this.bronzeCrateSilhouette);
				gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.bronzeCratePrefab);
				break;
			case LootCrateType.Marble:
				gameObject = UnityEngine.Object.Instantiate<GameObject>(this.marbleCrateSilhouette);
				gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.marbleCratePrefab);
				break;
			default:
				return;
			}
			gameObject.transform.parent = this.lootCrates;
			gameObject.transform.position = this.cratePositions[j].transform.position;
			gameObject.transform.localScale = this.cratePositions[j].transform.localScale;
			gameObject.transform.localRotation = this.cratePositions[j].transform.localRotation;
			gameObject.layer = base.gameObject.layer;
			gameObject.GetComponent<Renderer>().sortingLayerName = "Popup";
			gameObject2.transform.parent = this.lootCrates.transform;
			gameObject2.transform.localPosition = gameObject.transform.localPosition + new Vector3(0f, 0f, -0.1f);
			gameObject2.transform.localScale = this.cratePositions[j].transform.localScale;
			gameObject2.transform.localRotation = this.cratePositions[j].transform.localRotation;
			gameObject2.layer = base.gameObject.layer;
			gameObject2.GetComponent<Renderer>().sortingLayerName = "Popup";
		}
	}

	[SerializeField]
	private GameObject[] cratePositions;

	[SerializeField]
	private GameObject woodCratePrefab;

	[SerializeField]
	private GameObject metalCratePrefab;

	[SerializeField]
	private GameObject goldCratePrefab;

	[SerializeField]
	private GameObject cardboardCratePrefab;

	[SerializeField]
	private GameObject glassCratePrefab;

	[SerializeField]
	private GameObject bronzeCratePrefab;

	[SerializeField]
	private GameObject marbleCratePrefab;

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

	private Transform lootCrates;
}
