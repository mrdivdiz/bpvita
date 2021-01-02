using System;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;

public class CakeRaceKingsFavorite : Singleton<CakeRaceKingsFavorite>
{
	public BasePart CurrentFavorite { get; private set; }

	private void Start()
	{
		if (Singleton<PlayFabManager>.Instance.Initialized)
		{
			this.FetchRandomSeed();
		}
		else
		{
			PlayFabManager instance = Singleton<PlayFabManager>.Instance;
			instance.OnLogin = (Action<string, string>)Delegate.Combine(instance.OnLogin, new Action<string, string>(this.OnPlayFabLogin));
		}
		base.SetAsPersistant();
	}

	private void OnPlayFabLogin(string playfabId, string facebookbId)
	{
		this.FetchRandomSeed();
	}

	private void UpdateRandomPart(int newSeed)
	{
		UnityEngine.Random.State state = UnityEngine.Random.state;
		this.randomSeed = newSeed;
		UnityEngine.Random.InitState(this.randomSeed);
		BasePart.PartTier partTier = (BasePart.PartTier)UnityEngine.Random.Range(0, 4);
		List<BasePart> allTierParts = CustomizationManager.GetAllTierParts(partTier, (partTier != BasePart.PartTier.Regular) ? CustomizationManager.PartFlags.Craftable : CustomizationManager.PartFlags.None);
		if (allTierParts.Count > 0)
		{
			int index = UnityEngine.Random.Range(0, allTierParts.Count);
			this.CurrentFavorite = allTierParts[index];
		}
		if (this.OnPartAcquired != null)
		{
			this.OnPartAcquired();
		}
		UnityEngine.Random.state = state;
	}

	private void FetchRandomSeed()
	{
		if (this.isFetchingSeed)
		{
			return;
		}
		this.isFetchingSeed = true;
		Singleton<PlayFabManager>.Instance.GetTitleData(new List<string>
		{
			"kings_favorite_random_seed"
		}, new Action<GetTitleDataResult>(this.OnSeedFetched), new Action<PlayFabError>(this.OnSeedFetchError));
	}

	private void OnSeedFetched(GetTitleDataResult result)
	{
		int newSeed;
		if (result != null && result.Data != null && result.Data.ContainsKey("kings_favorite_random_seed") && int.TryParse(result.Data["kings_favorite_random_seed"], out newSeed))
		{
			this.UpdateRandomPart(newSeed);
		}
		this.isFetchingSeed = false;
	}

	private void OnSeedFetchError(PlayFabError error)
	{
		this.isFetchingSeed = false;
	}

	public void ClearCurrentFavorite()
	{
		this.CurrentFavorite = null;
		this.FetchRandomSeed();
	}

	private const string RANDOM_SEED_KEY = "kings_favorite_random_seed";

	public Action OnPartAcquired;

	private bool isFetchingSeed;

	private int randomSeed;
}
