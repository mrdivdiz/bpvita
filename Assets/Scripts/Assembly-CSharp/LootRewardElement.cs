using System;
using System.Collections;
using Spine.Unity;
using UnityEngine;

public class LootRewardElement : MonoBehaviour
{
	public Transform IconRoot
	{
		get
		{
			return this.iconRoot;
		}
	}

	public bool IsDuplicatePart
	{
		get
		{
			return this.isDuplicatePart;
		}
		set
		{
			this.isDuplicatePart = value;
		}
	}

	public ParticleSystem BlingEffect
	{
		get
		{
			return this.blingEffect;
		}
	}

	public BasePart.PartTier Tier
	{
		get
		{
			return this.tier;
		}
	}

	private void Awake()
	{
		this.skeletonAnimation = base.GetComponentInChildren<SkeletonAnimation>();
	}

	private IEnumerator WaitForOpening()
	{
		float waitTimeLeft = 1f;
		while (waitTimeLeft > 0f)
		{
			waitTimeLeft -= GameTime.RealTimeDelta;
			yield return null;
		}
		while (base.transform.parent.localPosition.magnitude > 0.1f)
		{
			yield return null;
		}
		if (this.onRewardOpened != null)
		{
			this.onRewardOpened();
		}
		if (this.openingEffect != null)
		{
			waitTimeLeft = 0.5f;
			while (waitTimeLeft > 0f)
			{
				waitTimeLeft -= GameTime.RealTimeDelta;
				yield return null;
			}
			GameObject go = UnityEngine.Object.Instantiate<GameObject>(this.openingEffect, base.transform.position, Quaternion.identity);
			go.transform.parent = base.transform.parent;
			go.transform.localScale = Vector3.one;
			go.transform.localPosition = Vector3.right * 1.5f - Vector3.forward * 2f;
			this.openingEffectAnimation = go.GetComponentInChildren<RealtimeSkeletonAnimation>();
			if (this.openingEffectAnimation != null)
			{
				this.openingEffectAnimation.state.End += this.OnEffectAnimationEnd;
				this.openingEffectAnimation.state.SetAnimation(0, "Intro1", false);
				this.openingEffectAnimation.state.AddAnimation(0, "Outro", false, 0f);
			}
		}
		this.PlayJumpAnimation();
		yield break;
	}

	private void OnEffectAnimationEnd(Spine.AnimationState state, int trackIndex)
	{
		if (this.openingEffectAnimation != null && state.ToString().Equals("Outro"))
		{
			this.openingEffectAnimation.state.End -= this.OnEffectAnimationEnd;
			UnityEngine.Object.Destroy(this.openingEffectAnimation.transform.parent.gameObject);
		}
	}

	private void OnOpenStart()
	{
		if (this.parentButton != null)
		{
			LootCrateButton lootCrateButton = this.parentButton;
			lootCrateButton.onOpeningStart = (Action)Delegate.Remove(lootCrateButton.onOpeningStart, new Action(this.OnOpenStart));
		}
		base.StartCoroutine(this.WaitForOpening());
	}

	public void InitElement(LootCrateButton button)
	{
		this.parentButton = button;
		LootCrateButton lootCrateButton = this.parentButton;
		lootCrateButton.onOpeningStart = (Action)Delegate.Combine(lootCrateButton.onOpeningStart, new Action(this.OnOpenStart));
	}

	private void PlayJumpAnimation()
	{
		if (this.tier == BasePart.PartTier.Regular || this.tier == BasePart.PartTier.Common)
		{
			return;
		}
		if (this.tier == BasePart.PartTier.Rare)
		{
			this.skeletonAnimation.state.AddAnimation(0, "Rare_Item", false, 0f);
		}
		if (this.tier == BasePart.PartTier.Epic)
		{
			this.skeletonAnimation.state.AddAnimation(0, "Epic_Item", false, 0f);
		}
		this.waitingAnimation = this.isDuplicatePart;
		this.skeletonAnimation.state.End += this.OnJumpAnimationEnd;
	}

	private void OnJumpAnimationEnd(Spine.AnimationState state, int trackIndex)
	{
		this.waitingAnimation = false;
		this.skeletonAnimation.state.End -= this.OnJumpAnimationEnd;
	}

	public void PlayScrapAnimation()
	{
		if (this.skeletonAnimation != null)
		{
			this.skeletonAnimation.state.SetAnimation(0, "Scrap1", false);
		}
		ScrapButton.Instance.AddParticles(base.gameObject, 10, 1f, 0f);
		base.StartCoroutine(this.DelaySalvageSound());
	}

	private IEnumerator DelaySalvageSound()
	{
		float waitTime = 0.85f;
		while (waitTime > 0f)
		{
			waitTime -= GameTime.RealTimeDelta;
			yield return null;
		}
		Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.salvagePart);
		yield break;
	}

	public IEnumerator WaitJumpAnimation()
	{
		while (this.waitingAnimation)
		{
			yield return null;
		}
		yield break;
	}

	[SerializeField]
	private Transform iconRoot;

	private bool isDuplicatePart;

	[SerializeField]
	private GameObject openingEffect;

	private LootCrateButton parentButton;

	[SerializeField]
	private ParticleSystem blingEffect;

	[SerializeField]
	private BasePart.PartTier tier;

	public Action onRewardOpened;

	private bool waitingAnimation;

	private SkeletonAnimation skeletonAnimation;

	private SkeletonAnimation openingEffectAnimation;
}
