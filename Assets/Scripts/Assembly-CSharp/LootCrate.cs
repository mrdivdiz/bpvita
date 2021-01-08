using System;
using System.Collections;
using UnityEngine;

public class LootCrate : Collectable
{
	public LootCrateOpenDialog Dialog
	{
		get
		{
			return this.dialog;
		}
	}

	public LootCrateType CrateType
	{
		get
		{
			return this.crateType;
		}
	}

	protected override void Start()
	{
		base.Start();
		base.OnDataLoaded();
		this.originalCratePosition = base.transform.position;
		if (this.dialog == null)
		{
			this.dialog = LootCrate.SpawnLootCrateOpeningDialog();
		}
		base.rigidbody.useGravity = false;
		base.rigidbody.isKinematic = true;
	}

	protected override void OnGoalEnter(BasePart part)
	{
		if (this.collected || WPFMonoBehaviour.levelManager.gameState == LevelManager.GameState.Completed)
		{
			return;
		}
		if (this.collectedEffect)
		{
			UnityEngine.Object.Instantiate<ParticleSystem>(this.collectedEffect, base.transform.position, this.collectedEffect.transform.rotation);
		}
		if (!WorkshopMenu.FirstLootCrateCollected)
		{
			WorkshopMenu.FirstLootCrateCollected = true;
			if (Singleton<SocialGameManager>.IsInstantiated())
			{
				Singleton<SocialGameManager>.Instance.ReportAchievementProgress("grp.HIDDEN_CRATE", 100.0);
			}
		}
		Singleton<AudioManager>.Instance.SpawnOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.bonusBoxCollected, base.transform.position);
		this.collected = true;
		CoroutineRunner.Instance.StartCoroutine(this.BulletTime(true));
		PlayerProgressBar.Instance.DelayUpdate();
		if (this.RewardExperience != null)
		{
			base.StartCoroutine(this.SpawnDialog(this.RewardExperience()));
		}
		else
		{
			base.StartCoroutine(this.SpawnDialog(0));
		}
		base.DisableGoal(true);
		if (this.OnCollect != null)
		{
			this.OnCollect();
		}
	}

	protected override void OnReset()
	{
		this.collected = false;
		base.transform.position = this.originalCratePosition;
		base.DisableGoal(false);
		base.rigidbody.useGravity = false;
		base.rigidbody.isKinematic = true;
	}

	private IEnumerator SpawnDialog(int experience)
	{
		if (this.dialog != null)
		{
			this.dialog.PrepareOpening();
		}
		float waitTime = 1f / this.bulletTimeSpeed;
		while (waitTime > 0f)
		{
			waitTime -= GameTime.RealTimeDelta;
			yield return null;
		}
		if (this.dialog != null)
		{
			this.dialog.transform.position = WPFMonoBehaviour.hudCamera.transform.position + Vector3.forward * 5f;
			this.dialog.gameObject.SetActive(true);
			this.dialog.onClose += this.ContinueGame;
			this.dialog.AddLootCrate(this.crateType, 1, new AnalyticData(string.Format("daily_{0}", this.dailyIndex), "found", (!this.isAdRevealed) ? LootCrate.AdWatched.No : LootCrate.AdWatched.Yes), false, experience);
		}
		ResourceBar.Instance.ShowItem(ResourceBar.Item.PlayerProgress, true, false);
		UnityEngine.Object.Destroy(base.gameObject);
		yield break;
	}

	private void ContinueGame()
	{
		ResourceBar.Instance.ShowItem(ResourceBar.Item.PlayerProgress, false, true);
		CoroutineRunner.Instance.StartCoroutine(this.BulletTime(false));
		if (this.dialog != null)
		{
			this.dialog.onClose -= this.ContinueGame;
		}
	}

	private IEnumerator BulletTime(bool pause)
	{
		float fade = 0f;
		float fromTime = (!pause) ? 0f : 1f;
		float toTime = (!pause) ? 1f : 0f;
		while (fade < 1f)
		{
			Time.timeScale = Mathf.Lerp(fromTime, toTime, fade);
			fade += GameTime.RealTimeDelta * this.bulletTimeSpeed;
			yield return null;
		}
		GameTime.Pause(pause);
		yield break;
	}

	public void SetAnalyticData(int index, bool isAdRevealed)
	{
		this.dailyIndex = index;
		this.isAdRevealed = isAdRevealed;
	}

	public static LootCrateOpenDialog SpawnLootCrateOpeningDialog()
	{
		LootCrateOpenDialog lootCrateOpenDialog = LootCrateOpenDialog.CreateLootCrateOpenDialog();
		if (lootCrateOpenDialog != null)
		{
			lootCrateOpenDialog.gameObject.SetActive(false);
		}
		return lootCrateOpenDialog;
	}

	public static LootCrateOpenDialog SpawnLootCrateOpeningDialog(LootCrateType crateType, int amount, Camera hudCamera, Dialog.OnClose onClose, AnalyticData data)
	{
		if (Singleton<GameManager>.Instance.GetGameState() == GameManager.GameState.Undefined)
		{
			return null;
		}
		LootCrateOpenDialog lootCrateOpenDialog = LootCrateOpenDialog.CreateLootCrateOpenDialog();
		if (lootCrateOpenDialog != null && hudCamera != null)
		{
			lootCrateOpenDialog.transform.position = hudCamera.transform.position + Vector3.forward * 2.5f;
			lootCrateOpenDialog.gameObject.SetActive(true);
			lootCrateOpenDialog.onClose += onClose;
			lootCrateOpenDialog.AddLootCrate(crateType, amount, data, false, 0);
		}
		return lootCrateOpenDialog;
	}

	public Action OnCollect;

	public Func<int> RewardExperience;

	[SerializeField]
	private LootCrateType crateType;

	private LootCrateOpenDialog dialog;

	private int dailyIndex;

	private bool isAdRevealed;

	private Vector3 originalCratePosition;

	private float bulletTimeSpeed = 3f;

	public enum AdWatched
	{
		Yes,
		No,
		NotApplicaple
	}

	public struct AnalyticData
	{
		public AnalyticData(string receivedFrom, string price, AdWatched adWatched)
		{
			this.receivedFrom = receivedFrom;
			this.price = price;
			this.adWatched = adWatched;
		}

		public string receivedFrom;

		public string price;

		public AdWatched adWatched;
	}
}
