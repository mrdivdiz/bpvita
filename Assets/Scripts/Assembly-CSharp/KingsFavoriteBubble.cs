using System;
using UnityEngine;

public class KingsFavoriteBubble : MonoBehaviour
{
	private void Awake()
	{
		if (this.anim != null)
		{
			this.anim.gameObject.SetActive(false);
		}
	}

	private void Start()
	{
		CakeRaceKingsFavorite instance = Singleton<CakeRaceKingsFavorite>.Instance;
		instance.OnPartAcquired = (Action)Delegate.Combine(instance.OnPartAcquired, new Action(this.ShowCurrentFavoritePart));
		this.ShowCurrentFavoritePart();
	}

	private void OnDestroy()
	{
		if (Singleton<CakeRaceKingsFavorite>.IsInstantiated())
		{
			CakeRaceKingsFavorite instance = Singleton<CakeRaceKingsFavorite>.Instance;
			instance.OnPartAcquired = (Action)Delegate.Remove(instance.OnPartAcquired, new Action(this.ShowCurrentFavoritePart));
		}
	}

	private void ShowCurrentFavoritePart()
	{
		if (Singleton<CakeRaceKingsFavorite>.Instance.CurrentFavorite == null)
		{
			return;
		}
		if (this.partContainer.childCount > 0)
		{
			for (int i = 0; i < this.partContainer.childCount; i++)
			{
				UnityEngine.Object.Destroy(this.partContainer.GetChild(i).gameObject);
			}
		}
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(Singleton<CakeRaceKingsFavorite>.Instance.CurrentFavorite.m_constructionIconSprite.gameObject);
		gameObject.transform.parent = this.partContainer;
		gameObject.transform.localPosition = Vector3.back * 0.5f;
		GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.partTierBackgrounds[(int)Singleton<CakeRaceKingsFavorite>.Instance.CurrentFavorite.m_partTier]);
		gameObject2.transform.parent = this.partContainer;
		gameObject2.transform.localScale = Vector3.one * 0.5f;
		gameObject2.transform.localPosition = Vector3.zero;
		if (this.anim != null)
		{
			this.anim.gameObject.SetActive(true);
			this.anim.state.SetAnimation(0, "Intro1", false);
		}
	}

	public void OpenDialog()
	{
		if (this.dialog == null)
		{
			this.dialog = UnityEngine.Object.Instantiate<GameObject>(WPFMonoBehaviour.gameData.m_kingsFavoriteDialog).GetComponent<KingsFavoriteDialog>();
			this.dialog.transform.position = WPFMonoBehaviour.hudCamera.transform.position + Vector3.forward * 5f;
		}
		this.dialog.Open();
	}

	[SerializeField]
	private Transform partContainer;

	[SerializeField]
	private GameObject[] partTierBackgrounds;

	[SerializeField]
	private RealtimeSkeletonAnimation anim;

	private KingsFavoriteDialog dialog;
}
