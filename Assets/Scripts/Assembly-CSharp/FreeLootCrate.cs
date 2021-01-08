using System;
using UnityEngine;

public class FreeLootCrate : MonoBehaviour
{
	public static bool FreeShopLootCrateCollected
	{
		get
		{
			return GameProgress.GetInt("FreeShopCrateWood", 0, GameProgress.Location.Local, null) > 0;
		}
	}

	private void Awake()
	{
		Singleton<NetworkManager>.Instance.CheckAccess(new NetworkManager.OnCheckResponseDelegate(this.OnCheckNetworkResponse));
		NetworkManager instance = Singleton<NetworkManager>.Instance;
		instance.OnNetworkChange = (NetworkManager.OnNetworkChangedDelegate)Delegate.Combine(instance.OnNetworkChange, new NetworkManager.OnNetworkChangedDelegate(this.OnNetworkChange));
	}

	private void OnEnable()
	{
		if (string.IsNullOrEmpty(this.crateID))
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		this.Initialize(this.isEnabled);
	}

	private void OnDestroy()
	{
		if (Singleton<NetworkManager>.IsInstantiated())
		{
			NetworkManager instance = Singleton<NetworkManager>.Instance;
			instance.OnNetworkChange = (NetworkManager.OnNetworkChangedDelegate)Delegate.Remove(instance.OnNetworkChange, new NetworkManager.OnNetworkChangedDelegate(this.OnNetworkChange));
			Singleton<NetworkManager>.Instance.UnsubscribeFromResponse(new NetworkManager.OnCheckResponseDelegate(this.OnCheckNetworkResponse));
		}
	}

	private void OnCheckNetworkResponse(bool hasNetwork)
	{
		Singleton<NetworkManager>.Instance.UnsubscribeFromResponse(new NetworkManager.OnCheckResponseDelegate(this.OnCheckNetworkResponse));
		this.Initialize(hasNetwork);
	}

	private void OnNetworkChange(bool hasNetwork)
	{
		this.Initialize(hasNetwork);
	}

	private void Initialize(bool enable)
	{
		this.isEnabled = (GameProgress.GetInt(this.crateID + this.crateType.ToString(), 0, GameProgress.Location.Local, null) == 0 && enable);
		base.gameObject.SetActive(this.isEnabled);
	}

	public void GiveReward()
	{
		int @int = GameProgress.GetInt(this.crateID + this.crateType.ToString(), 0, GameProgress.Location.Local, null);
		if (@int <= 0)
		{
			GameProgress.SetInt(this.crateID + this.crateType.ToString(), @int + 1, GameProgress.Location.Local);
			WorkshopMenu.AnyLootCrateCollected = true;
			if (FreeLootCrate.OnFreeLootCrateCollected != null)
			{
				FreeLootCrate.OnFreeLootCrateCollected();
			}
			Camera hudCamera = Singleton<GuiManager>.Instance.FindCamera();
			LootCrate.SpawnLootCrateOpeningDialog(this.crateType, 1, hudCamera, null, new LootCrate.AnalyticData(this.crateID, "free", LootCrate.AdWatched.NotApplicaple));
			this.TryReportAchievements();
		}
		base.gameObject.SetActive(false);
	}

	private void TryReportAchievements()
	{
		int @int = GameProgress.GetInt(this.crateID + this.crateType.ToString(), 0, GameProgress.Location.Local, null);
		if (@int == 1 && this.crateID.Equals("FreeShopCrate") && Singleton<SocialGameManager>.IsInstantiated())
		{
			Singleton<SocialGameManager>.Instance.ReportAchievementProgress("grp.FREE_CRATE", 100.0);
		}
	}

	public static Action OnFreeLootCrateCollected;

	[SerializeField]
	private LootCrateType crateType;

	[SerializeField]
	private string crateID = string.Empty;

	private bool isEnabled;
}
