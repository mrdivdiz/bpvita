using System;
using System.Collections;
using UnityEngine;

public class FreeCrateAdReward : WPFMonoBehaviour
{
	private void Awake()
	{
		this.renderers = base.GetComponentsInChildren<Renderer>(true);
		this.colliders = base.GetComponentsInChildren<Collider>(true);
		this.Activate(false);
		if (Singleton<GameConfigurationManager>.Instance.HasData)
		{
			this.Initialize();
		}
		else
		{
			GameConfigurationManager instance = Singleton<GameConfigurationManager>.Instance;
			instance.OnHasData = (Action)Delegate.Combine(instance.OnHasData, new Action(this.Initialize));
		}
	}

	private void Initialize()
	{
		GameConfigurationManager instance = Singleton<GameConfigurationManager>.Instance;
		instance.OnHasData = (Action)Delegate.Remove(instance.OnHasData, new Action(this.Initialize));
		string value = Singleton<GameConfigurationManager>.Instance.GetValue<string>("free_crate_ad_reward", "LootCrateType");
		try
		{
			this.reward = (LootCrateType)Enum.Parse(typeof(LootCrateType), value);
		}
		catch (ArgumentException)
		{
			this.reward = LootCrateType.Cardboard;
		}
		this.adReward = new AdReward(AdvertisementHandler.FreeLootCratePlacement);
		AdReward adReward = this.adReward;
		adReward.OnAdFinished = (Action)Delegate.Combine(adReward.OnAdFinished, new Action(this.OnAdFinished));
		AdReward adReward2 = this.adReward;
		adReward2.OnCancel = (Action)Delegate.Combine(adReward2.OnCancel, new Action(this.OnAdCancel));
		AdReward adReward3 = this.adReward;
		adReward3.OnConfirmationFailed = (Action)Delegate.Combine(adReward3.OnConfirmationFailed, new Action(this.OnConfirmationFailed));
		AdReward adReward4 = this.adReward;
		adReward4.OnFailed = (Action)Delegate.Combine(adReward4.OnFailed, new Action(this.OnAdFailed));
		AdReward adReward5 = this.adReward;
		adReward5.OnLoading = (Action)Delegate.Combine(adReward5.OnLoading, new Action(this.OnAdLoading));
		AdReward adReward6 = this.adReward;
		adReward6.OnReady = (Action)Delegate.Combine(adReward6.OnReady, new Action(this.OnAdReady));
		AdReward adReward7 = this.adReward;
		adReward7.OnAdPlayFailed = (Action)Delegate.Combine(adReward7.OnAdPlayFailed, new Action(this.OnAdPlayFailed));
		this.adReward.Load();
	}

	private void OnDestroy()
	{
		if (this.adReward != null)
		{
			this.adReward.Dispose();
		}
	}

	private void Activate(bool activate)
	{
		for (int i = 0; i < this.renderers.Length; i++)
		{
			if (this.renderers[i] != null)
			{
				this.renderers[i].enabled = activate;
			}
		}
		for (int j = 0; j < this.colliders.Length; j++)
		{
			if (this.colliders[j] != null)
			{
				this.colliders[j].enabled = activate;
			}
		}
		if (this.currentCrateIcon != null)
		{
			this.currentCrateIcon.SetActive(activate);
		}
	}

	private void OnAdReady()
	{
		this.Activate(true);
		if (this.currentCrateIcon != null)
		{
			UnityEngine.Object.Destroy(this.currentCrateIcon);
		}
		this.currentCrateIcon = LootCrateGraphicSpawner.CreateCrate(this.reward, this.cratePosition, Vector3.zero, Vector3.one, Quaternion.identity);
		LayerHelper.SetLayer(this.currentCrateIcon, base.gameObject.layer, true);
	}

	private void OnAdLoading()
	{
		this.Activate(false);
	}

	private void OnAdFailed()
	{
		this.Activate(false);
		base.StartCoroutine(this.WaitAndLoad());
	}

	private IEnumerator WaitAndLoad()
	{
		float waitTime = 10f;
		while (waitTime > 0f)
		{
			waitTime -= Time.deltaTime;
			yield return null;
		}
		this.adReward.Load();
		yield break;
	}

	private void OnConfirmationFailed()
	{
		this.adReward.Load();
	}

	private void OnAdCancel()
	{
		this.adReward.Load();
	}

	private void OnAdFinished()
	{
		LootCrate.SpawnLootCrateOpeningDialog(this.reward, 1, WPFMonoBehaviour.hudCamera, null, new LootCrate.AnalyticData("Advertisement", "0", LootCrate.AdWatched.Yes));
		this.adReward.Load();
	}

	private void OnAdPlayFailed()
	{
		if (this.errorPopup == null)
		{
			this.errorPopup = this.CreateErrorPopup();
		}
		this.errorPopup.Open();
	}

	public void PlayVideo()
	{
		this.adReward.Play();
	}

	private NotificationPopup CreateErrorPopup()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.m_errorPopup);
		gameObject.transform.position = WPFMonoBehaviour.hudCamera.transform.position + Vector3.forward * 3f;
		NotificationPopup component = gameObject.GetComponent<NotificationPopup>();
		component.Close();
		component.SetText("IN_APP_PURCHASE_NOT_READY");
		return component;
	}

	private const string CRATE_CONFIG_NAME = "free_crate_ad_reward";

	private const string CRATE_TYPE = "LootCrateType";

	[SerializeField]
	private Transform cratePosition;

	[SerializeField]
	private GameObject m_errorPopup;

	private NotificationPopup errorPopup;

	private AdReward adReward;

	private Renderer[] renderers;

	private Collider[] colliders;

	private LootCrateType reward;

	private GameObject currentCrateIcon;
}
