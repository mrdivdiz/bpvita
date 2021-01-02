using System;
using System.Collections;
using Spine.Unity;
using UnityEngine;

public class DailyChallengeButton : WPFMonoBehaviour
{
	private bool DailyChallengeShown
	{
		get
		{
			return GameProgress.GetBool("DailyChallengeShown", false, GameProgress.Location.Local, null);
		}
		set
		{
			GameProgress.SetBool("DailyChallengeShown", value, GameProgress.Location.Local);
		}
	}

	private bool ShowingCutscene
	{
		get
		{
			return GameProgress.GetBool("DailyChallengeCutscene", false, GameProgress.Location.Local, null);
		}
		set
		{
			GameProgress.SetBool("DailyChallengeCutscene", value, GameProgress.Location.Local);
		}
	}

	private void Awake()
	{
		if (!this.DailyChallengeShown && WPFMonoBehaviour.levelManager != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		this.lootCrates = new GameObject();
		this.lootCrates.transform.parent = base.transform;
		this.lootCrates.transform.localPosition = Vector3.zero;
		this.lootCrates.transform.localScale = Vector3.one;
		this.noConnAnim = this.noConnection.GetComponent<Animation>();
		this.noConnection.SetActive(false);
		this.networkFailure = true;
	}

	private void Start()
	{
		this.dialog = DailyChallengeDialog.Create();
		this.dialog.transform.position = WPFMonoBehaviour.hudCamera.transform.position + new Vector3(0f, 0f, 10f);
		this.dialog.Close();
		if (this.ShowingCutscene)
		{
			this.dialog.Open();
			this.ShowingCutscene = false;
			this.DailyChallengeShown = true;
		}
		this.anim.state.SetAnimation(0, "Search", true);
		base.StartCoroutine(this.LoadingIndicator());
		this.loading = true;
		this.checkingNetwork = true;
		Singleton<NetworkManager>.Instance.CheckAccess(new NetworkManager.OnCheckResponseDelegate(this.OnNetworkCheck));
	}

	private void OnEnable()
	{
		if (!this.checkingNetwork && !this.networkFailure)
		{
			this.UpdateLootCrates();
		}
	}

	private void OnNetworkCheck(bool hasInternet)
	{
		this.networkFailure = (!hasInternet || !HatchManager.IsLoggedIn);
		this.checkingNetwork = false;
		this.loading = false;
		this.loadingIndicator.SetActive(false);
		if (this.networkFailure)
		{
			this.UpdateLootCrates();
			return;
		}
		if (Singleton<DailyChallenge>.Instance.Initialized)
		{
			this.OnDailyChallengeInitialized();
		}
		else
		{
			DailyChallenge instance = Singleton<DailyChallenge>.Instance;
			instance.OnInitialize = (Action)Delegate.Combine(instance.OnInitialize, new Action(this.OnDailyChallengeInitialized));
		}
	}

	private void OnDestroy()
	{
		if (Singleton<DailyChallenge>.IsInstantiated())
		{
			DailyChallenge instance = Singleton<DailyChallenge>.Instance;
			instance.OnDailyChallengeChanged = (Action)Delegate.Remove(instance.OnDailyChallengeChanged, new Action(this.UpdateLootCrates));
			DailyChallenge instance2 = Singleton<DailyChallenge>.Instance;
			instance2.OnInitialize = (Action)Delegate.Remove(instance2.OnInitialize, new Action(this.OnDailyChallengeInitialized));
		}
		if (Singleton<NetworkManager>.IsInstantiated())
		{
			Singleton<NetworkManager>.Instance.UnsubscribeFromResponse(new NetworkManager.OnCheckResponseDelegate(this.OnNetworkCheck));
		}
	}

	private void OnDailyChallengeInitialized()
	{
		this.UpdateLootCrates();
		DailyChallenge instance = Singleton<DailyChallenge>.Instance;
		instance.OnDailyChallengeChanged = (Action)Delegate.Combine(instance.OnDailyChallengeChanged, new Action(this.UpdateLootCrates));
	}

	private void UpdateLootCrates()
	{
		for (int i = 0; i < this.lootCrates.transform.childCount; i++)
		{
			UnityEngine.Object.Destroy(this.lootCrates.transform.GetChild(i).gameObject);
		}
		this.noConnection.SetActive(this.networkFailure);
		if (this.networkFailure)
		{
			return;
		}
		int num = 0;
		for (int j = 0; j < this.cratePositions.Length; j++)
		{
			GameObject gameObject;
			GameObject gameObject2;
			switch (Singleton<DailyChallenge>.Instance.TodaysLootCrate(j))
			{
			case LootCrateType.Wood:
				gameObject = UnityEngine.Object.Instantiate<GameObject>(this.woodCrateSilhouette);
				gameObject2 = ((!Singleton<DailyChallenge>.Instance.Challenges[j].collected && !this.networkFailure) ? UnityEngine.Object.Instantiate<GameObject>(this.woodCrate) : null);
				break;
			case LootCrateType.Metal:
				gameObject = UnityEngine.Object.Instantiate<GameObject>(this.metalCrateSilhouette);
				gameObject2 = ((!Singleton<DailyChallenge>.Instance.Challenges[j].collected && !this.networkFailure) ? UnityEngine.Object.Instantiate<GameObject>(this.metalCrate) : null);
				break;
			case LootCrateType.Gold:
				gameObject = UnityEngine.Object.Instantiate<GameObject>(this.goldCrateSilhouette);
				gameObject2 = ((!Singleton<DailyChallenge>.Instance.Challenges[j].collected && !this.networkFailure) ? UnityEngine.Object.Instantiate<GameObject>(this.goldCrate) : null);
				break;
			case LootCrateType.Cardboard:
				gameObject = UnityEngine.Object.Instantiate<GameObject>(this.cardboardCrateSilhouette);
				gameObject2 = ((!Singleton<DailyChallenge>.Instance.Challenges[j].collected && !this.networkFailure) ? UnityEngine.Object.Instantiate<GameObject>(this.cardboardCrate) : null);
				break;
			case LootCrateType.Glass:
				gameObject = UnityEngine.Object.Instantiate<GameObject>(this.glassCrateSilhouette);
				gameObject2 = ((!Singleton<DailyChallenge>.Instance.Challenges[j].collected && !this.networkFailure) ? UnityEngine.Object.Instantiate<GameObject>(this.glassCrate) : null);
				break;
			case LootCrateType.Bronze:
				gameObject = UnityEngine.Object.Instantiate<GameObject>(this.bronzeCrateSilhouette);
				gameObject2 = ((!Singleton<DailyChallenge>.Instance.Challenges[j].collected && !this.networkFailure) ? UnityEngine.Object.Instantiate<GameObject>(this.bronzeCrate) : null);
				break;
			case LootCrateType.Marble:
				gameObject = UnityEngine.Object.Instantiate<GameObject>(this.marbleCrateSilhouette);
				gameObject2 = ((!Singleton<DailyChallenge>.Instance.Challenges[j].collected && !this.networkFailure) ? UnityEngine.Object.Instantiate<GameObject>(this.marbleCrate) : null);
				break;
			default:
				gameObject = UnityEngine.Object.Instantiate<GameObject>(this.woodCrateSilhouette);
				gameObject2 = null;
				break;
			}
			gameObject.transform.parent = this.lootCrates.transform;
			gameObject.transform.position = this.cratePositions[j].transform.position;
			gameObject.transform.localScale = Vector3.one;
			gameObject.transform.localRotation = Quaternion.identity;
			gameObject.layer = base.gameObject.layer;
			if (gameObject2 != null)
			{
				gameObject2.transform.parent = this.lootCrates.transform;
				gameObject2.transform.localPosition = gameObject.transform.localPosition + new Vector3(0f, 0f, -0.1f);
				gameObject2.transform.localScale = Vector3.one;
				gameObject2.transform.localRotation = Quaternion.identity;
				gameObject2.layer = base.gameObject.layer;
			}
			num += ((!Singleton<DailyChallenge>.Instance.Challenges[j].collected) ? 1 : 0);
		}
		if (num > 0)
		{
			this.anim.state.SetAnimation(0, "LootFound", true);
		}
	}

	public void OnPress()
	{
		if (this.networkFailure)
		{
			this.noConnAnim.Play();
			if (!this.checkingNetwork)
			{
				this.checkingNetwork = true;
				Singleton<NetworkManager>.Instance.CheckAccess(new NetworkManager.OnCheckResponseDelegate(this.OnNetworkCheck));
			}
			return;
		}
		if (this.DailyChallengeShown && WPFMonoBehaviour.levelManager == null)
		{
			this.dialog.Open();
		}
		else if (this.DailyChallengeShown && WPFMonoBehaviour.levelManager != null)
		{
			WPFMonoBehaviour.levelManager.InGameGUI.Hide();
			this.dialog.Open(delegate()
			{
				if (WPFMonoBehaviour.levelManager)
				{
					WPFMonoBehaviour.levelManager.InGameGUI.Show();
				}
			});
		}
		else
		{
			this.ShowingCutscene = true;
			Singleton<Loader>.Instance.LoadLevel("DailyChallenge", GameManager.GameState.Cutscene, true, true);
		}
	}

	public void CreateNewChallenge()
	{
	}

	private IEnumerator LoadingIndicator()
	{
		TextMesh[] texts = this.loadingIndicator.GetComponentsInChildren<TextMesh>();
		this.loadingIndicator.gameObject.SetActive(true);
		float wait = 0.6f;
		for (int i = 0; i < texts.Length; i++)
		{
			texts[i].text = string.Empty;
		}
		yield return new WaitForRealSeconds(wait);
		while (this.loading)
		{
			if (!this.loadingIndicator.gameObject.activeInHierarchy || !this.loading)
			{
				break;
			}
			for (int j = 0; j < texts.Length; j++)
			{
				texts[j].text = ".";
			}
			yield return new WaitForRealSeconds(wait);
			if (!this.loadingIndicator.gameObject.activeInHierarchy || !this.loading)
			{
				break;
			}
			for (int k = 0; k < texts.Length; k++)
			{
				texts[k].text = "..";
			}
			yield return new WaitForRealSeconds(wait);
			if (!this.loadingIndicator.gameObject.activeInHierarchy || !this.loading)
			{
				break;
			}
			for (int l = 0; l < texts.Length; l++)
			{
				texts[l].text = "...";
			}
			yield return new WaitForRealSeconds(wait);
		}
		this.loadingIndicator.gameObject.SetActive(false);
		yield break;
	}

	private const string SEARCH_ANIM = "Search";

	private const string LOOT_FOUND_ANIM = "LootFound";

	[SerializeField]
	private GameObject woodCrate;

	[SerializeField]
	private GameObject woodCrateSilhouette;

	[SerializeField]
	private GameObject metalCrate;

	[SerializeField]
	private GameObject metalCrateSilhouette;

	[SerializeField]
	private GameObject goldCrate;

	[SerializeField]
	private GameObject goldCrateSilhouette;

	[SerializeField]
	private GameObject cardboardCrate;

	[SerializeField]
	private GameObject cardboardCrateSilhouette;

	[SerializeField]
	private GameObject glassCrate;

	[SerializeField]
	private GameObject glassCrateSilhouette;

	[SerializeField]
	private GameObject bronzeCrate;

	[SerializeField]
	private GameObject bronzeCrateSilhouette;

	[SerializeField]
	private GameObject marbleCrate;

	[SerializeField]
	private GameObject marbleCrateSilhouette;

	[SerializeField]
	private GameObject[] cratePositions;

	[SerializeField]
	private SkeletonAnimation anim;

	[SerializeField]
	private GameObject noConnection;

	[SerializeField]
	private GameObject loadingIndicator;

	private GameObject lootCrates;

	private Animation noConnAnim;

	private DailyChallengeDialog dialog;

	private bool networkFailure;

	private bool checkingNetwork;

	private bool loading;
}
