using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DailyChallengeLoader : WPFMonoBehaviour
{
	public bool ImageReady
	{
		get
		{
			return this.hasImage;
		}
	}

	private void Awake()
	{
		this.initialized = false;
		DailyChallengeLoader.instances.Add(this.challengeIndex, this);
		DailyChallengeLoader.dailyMaterials.Add(this.challengeIndex, this.dailyImage.GetComponent<Renderer>().material);
		this.SetState(DailyChallengeLoader.State.None);
	}

	private void OnEnable()
	{
		if (this.loading)
		{
			return;
		}
		if (!this.hasImage || this.state == DailyChallengeLoader.State.Error || this.state == DailyChallengeLoader.State.None)
		{
			this.SetDisabled();
			Singleton<NetworkManager>.Instance.CheckAccess(new NetworkManager.OnCheckResponseDelegate(this.OnNetworkCheck));
		}
		else if (this.state == DailyChallengeLoader.State.Ready)
		{
			this.SetState(this.state);
		}
	}

	private void OnNetworkCheck(bool hasInternet)
	{
		if (!hasInternet)
		{
			this.SetDisabled();
			return;
		}
		if (this.initialized)
		{
			this.LoadImage();
		}
		else if (Singleton<DailyChallenge>.Instance.Initialized)
		{
			this.Initialize();
		}
		else
		{
			this.SetDisabled();
			DailyChallenge instance = Singleton<DailyChallenge>.Instance;
			instance.OnInitialize = (Action)Delegate.Combine(instance.OnInitialize, new Action(this.Initialize));
		}
	}

	private void Initialize()
	{
		if (!HatchManager.IsLoggedIn)
		{
			HatchManager.onLoginSuccess = (Action)Delegate.Combine(HatchManager.onLoginSuccess, new Action(this.Initialize));
			return;
		}
		this.initialized = true;
		DailyChallenge instance = Singleton<DailyChallenge>.Instance;
		instance.OnDailyChallengeChanged = (Action)Delegate.Combine(instance.OnDailyChallengeChanged, new Action(this.LoadImage));
		HatchManager.onLoginSuccess = (Action)Delegate.Remove(HatchManager.onLoginSuccess, new Action(this.Initialize));
		this.LoadImage();
	}

	private void OnDestroy()
	{
		DailyChallengeLoader.instances.Remove(this.challengeIndex);
		DailyChallengeLoader.dailyMaterials.Remove(this.challengeIndex);
		if (Singleton<DailyChallenge>.IsInstantiated())
		{
			DailyChallenge instance = Singleton<DailyChallenge>.Instance;
			instance.OnInitialize = (Action)Delegate.Remove(instance.OnInitialize, new Action(this.Initialize));
			DailyChallenge instance2 = Singleton<DailyChallenge>.Instance;
			instance2.OnDailyChallengeChanged = (Action)Delegate.Remove(instance2.OnDailyChallengeChanged, new Action(this.LoadImage));
		}
		if (Singleton<NetworkManager>.IsInstantiated())
		{
			Singleton<NetworkManager>.Instance.UnsubscribeFromResponse(new NetworkManager.OnCheckResponseDelegate(this.OnNetworkCheck));
		}
	}

	private void SetDisabled()
	{
		this.adButton.SetActive(false);
		this.errorImage.SetActive(false);
		this.loadingImage.SetActive(false);
		this.collected.SetActive(false);
		this.dailyImage.SetActive(true);
		this.disabled.SetActive(true);
	}

	private void LoadImage()
	{
	}

	private void SetState(State state)
	{
		bool flag = Singleton<DailyChallenge>.Instance.HasChallenge && Singleton<DailyChallenge>.Instance.DailyChallengeCollected(this.challengeIndex);
		this.state = state;
		switch (state)
		{
		case DailyChallengeLoader.State.None:
			break;
		case DailyChallengeLoader.State.Loading:
			this.hasImage = false;
			this.disabled.SetActive(false);
			this.errorImage.SetActive(false);
			this.dailyImage.SetActive(false);
			this.collected.SetActive(false);
			this.loadingImage.SetActive(true);
			if (this.crateIcon != null)
			{
				this.crateIcon.SetActive(false);
			}
			if (this.OnImageLoading != null)
			{
				this.OnImageLoading();
			}
			goto IL_242;
		case DailyChallengeLoader.State.Error:
			this.dailyImage.SetActive(false);
			this.loadingImage.SetActive(false);
			this.collected.SetActive(false);
			this.disabled.SetActive(true);
			this.hasImage = false;
			if (this.crateIcon != null)
			{
				this.crateIcon.SetActive(false);
			}
			goto IL_242;
		case DailyChallengeLoader.State.Ready:
			this.adButton.SetActive(true);
			this.errorImage.SetActive(false);
			this.loadingImage.SetActive(false);
			this.disabled.SetActive(false);
			this.dailyImage.SetActive(true);
			this.collected.SetActive(flag);
			DailyChallengeLoader.dailyMaterials[this.challengeIndex].SetFloat("_Grayness", (!flag) ? 0f : 1f);
			this.UpdateLootCrateImage(flag);
			this.hasImage = true;
			if (this.OnImageReady != null)
			{
				this.OnImageReady();
			}
			this.OnImageReady = null;
			goto IL_242;
		case DailyChallengeLoader.State.TimeOut:
			if (base.gameObject.activeInHierarchy)
			{
				base.StartCoroutine(this.Retry());
			}
			break;
		default:
			goto IL_242;
		}
		this.dailyImage.SetActive(false);
		this.loadingImage.SetActive(false);
		this.collected.SetActive(false);
		this.errorImage.SetActive(false);
		this.hasImage = false;
		if (this.crateIcon != null)
		{
			this.crateIcon.SetActive(false);
		}
		IL_242:
		this.loading = (state == DailyChallengeLoader.State.Loading);
	}

	private void UpdateLootCrateImage(bool collected)
	{
		if (this.crateIcon != null)
		{
			UnityEngine.Object.Destroy(this.crateIcon);
		}
		if (collected)
		{
			return;
		}
		GameObject gameObject = WPFMonoBehaviour.gameData.m_lootCrates[(int)Singleton<DailyChallenge>.Instance.TodaysLootCrate(this.challengeIndex)];
		this.crateIcon = UnityEngine.Object.Instantiate<GameObject>(gameObject.transform.Find("Icon").gameObject);
		this.crateIcon.gameObject.layer = this.lootCratePos.gameObject.layer;
		this.crateIcon.transform.parent = this.lootCratePos;
		this.crateIcon.transform.localPosition = Vector3.zero;
		for (int i = 0; i < this.crateIcon.transform.childCount; i++)
		{
			this.crateIcon.transform.GetChild(i).gameObject.layer = this.lootCratePos.gameObject.layer;
		}
		Renderer[] componentsInChildren = this.crateIcon.GetComponentsInChildren<Renderer>();
		for (int j = 0; j < componentsInChildren.Length; j++)
		{
			componentsInChildren[j].sortingLayerName = "Popup";
		}
	}

	private IEnumerator TimeoutCheck()
	{
		yield return new WaitForRealSeconds(15f);
		if (this.state == DailyChallengeLoader.State.Loading)
		{
			this.SetState(DailyChallengeLoader.State.TimeOut);
		}
		yield break;
	}

	private IEnumerator Retry()
	{
		yield return new WaitForRealSeconds(5f);
		if (this.state == DailyChallengeLoader.State.TimeOut)
		{
			this.LoadImage();
		}
		yield break;
	}

	public Action OnImageReady;

	public Action OnImageLoading;

	private const float TIMEOUT_LIMIT = 15f;

	private const float RETRY_TIME = 5f;

	[SerializeField]
	private GameObject errorImage;

	[SerializeField]
	private GameObject loadingImage;

	[SerializeField]
	private GameObject dailyImage;

	[SerializeField]
	private GameObject disabled;

	[SerializeField]
	private Transform lootCratePos;

	[SerializeField]
	private GameObject collected;

	[SerializeField]
	private GameObject adButton;

	[SerializeField]
	private int challengeIndex;

	private bool loading;

	private bool hasImage;

	private bool initialized;

	private string currentKey;

	private GameObject crateIcon;

	private State state;

	private static Dictionary<int, DailyChallengeLoader> instances = new Dictionary<int, DailyChallengeLoader>();

	private static Dictionary<int, Material> dailyMaterials = new Dictionary<int, Material>();

	private enum State
	{
		None,
		Loading,
		Error,
		Ready,
		TimeOut
	}
}
