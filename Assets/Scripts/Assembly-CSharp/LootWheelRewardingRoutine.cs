using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class LootWheelRewardingRoutine : WPFMonoBehaviour
{
	private void Awake()
	{
		this.horns = base.transform.Find("Horns");
		this.hornAnimations = this.horns.gameObject.GetComponentsInChildren<SkeletonAnimation>();
		this.hornRenderers = this.horns.gameObject.GetComponentsInChildren<Renderer>();
		if (this.hornAnimations[0].state == null)
		{
			this.hornAnimations[0].Initialize(true);
		}
		this.hornAnimations[0].state.Event += this.OnAnimationEvent;
		this.horns.gameObject.SetActive(false);
		this.rewardParticleSystem = this.CreateParticles(this.rewardParticles, Vector3.zero, base.transform);
		this.rewardParticleSystem.Stop();
		this.rewardParticleSystem.playOnAwake = false;
		this.confetti1ParticleSystem = this.CreateParticles(this.confettiParticles, new Vector3(0.333333343f, 0f), base.transform);
		this.confetti1ParticleSystem.playOnAwake = false;
		this.confetti1ParticleSystem.Stop();
		this.confetti2ParticleSystem = this.CreateParticles(this.confettiParticles, new Vector3(0.6666667f, 0f), base.transform);
		this.confetti2ParticleSystem.playOnAwake = false;
		this.confetti2ParticleSystem.Stop();
		if (this.rewardAnimation.state == null)
		{
			this.rewardAnimation.Initialize(true);
		}
		this.rewardAnimation.state.Event += this.OnAnimationEvent;
		this.bgDictionary = new Dictionary<BackgroundType, GameObject>
		{
			{
				LootWheelRewardingRoutine.BackgroundType.Epic,
				this.epicRewardBackground
			},
			{
				LootWheelRewardingRoutine.BackgroundType.Rare,
				this.rareRewardBackground
			},
			{
				LootWheelRewardingRoutine.BackgroundType.Common,
				this.commonRewardBackground
			},
			{
				LootWheelRewardingRoutine.BackgroundType.Regular,
				this.regularRewardBackground
			}
		};
	}

	private ParticleSystem CreateParticles(GameObject prefab, Vector3 screenPosition, Transform parent)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(prefab);
		LayerHelper.SetSortingLayer(gameObject, "Popup", true);
		LayerHelper.SetLayer(gameObject, base.gameObject.layer, true);
		LayerHelper.SetOrderInLayer(gameObject, 1, true);
		Vector3 position = WPFMonoBehaviour.hudCamera.ViewportToWorldPoint(screenPosition);
		gameObject.transform.position = position;
		gameObject.transform.parent = parent;
		Vector3 localPosition = gameObject.transform.localPosition;
		localPosition.z = 0f;
		gameObject.transform.localPosition = localPosition;
		gameObject.transform.rotation = Quaternion.identity;
		return gameObject.GetComponent<ParticleSystem>();
	}

	private void OnEnable()
	{
		Singleton<GuiManager>.Instance.GrabPointer(this);
		Singleton<KeyListener>.Instance.GrabFocus(this);
		KeyListener.keyReleased += this.HandleKeyReleased;
	}

	private void OnDisable()
	{
		if (Singleton<GuiManager>.IsInstantiated())
		{
			Singleton<GuiManager>.Instance.ReleasePointer(this);
		}
		if (Singleton<KeyListener>.IsInstantiated())
		{
			Singleton<KeyListener>.Instance.ReleaseFocus(this);
		}
		KeyListener.keyReleased -= this.HandleKeyReleased;
		base.StopAllCoroutines();
		this.horns.gameObject.SetActive(false);
		if (this.icon)
		{
			UnityEngine.Object.Destroy(this.icon);
		}
		if (this.OnClosed != null)
		{
			this.OnClosed();
			this.OnClosed = null;
		}
		for (int i = 0; i < this.hornAnimations.Length; i++)
		{
			if (this.hornAnimations[i] && this.hornAnimations[i].state != null)
			{
				this.hornAnimations[i].state.ClearTracks();
			}
		}
		if (this.rewardAnimation != null && this.rewardAnimation.state != null)
		{
			this.rewardAnimation.state.End -= this.OnAnimationEnd;
		}
	}

	public void OnPressed()
	{
		if (!base.gameObject.activeSelf)
		{
			return;
		}
		base.gameObject.SetActive(false);
		BackgroundMask.Show(false, this, string.Empty, null, default(Vector3), false);
		if (this.OnClosed != null)
		{
			this.OnClosed();
		}
	}

	public void ShowRewarding(bool showHorns, int rewardAmount, GameObject target, BackgroundType bgType, Action OnEnd)
	{
		base.gameObject.SetActive(true);
		this.ShowHorns(showHorns);
		BackgroundMask.Show(true, this, "Popup", base.transform, Vector3.forward * 0.1f, false);
		this.icon = this.ConstructIcon(target, bgType, rewardAmount);
		this.icon.transform.parent = this.targetPosition;
		this.icon.transform.localPosition = Vector3.zero;
		this.icon.transform.localRotation = Quaternion.identity;
		this.icon.transform.localScale = Vector3.one;
		this.OnClosed = OnEnd;
		this.ShowAnimation();
	}

	private GameObject ConstructIcon(GameObject target, BackgroundType bgType, int rewardAmount)
	{
		GameObject gameObject = new GameObject();
		gameObject = UnityEngine.Object.Instantiate<GameObject>(this.bgDictionary[bgType]);
		target.transform.parent = gameObject.transform;
		target.transform.localPosition = Vector3.back * 0.1f;
		target.transform.localRotation = Quaternion.identity;
		target.transform.localScale = Vector3.one;
		if (bgType == LootWheelRewardingRoutine.BackgroundType.Regular)
		{
			Transform transform = gameObject.transform.Find("Label");
			Transform transform2 = gameObject.transform.Find("Text");
			if (rewardAmount > 1)
			{
				TextMesh[] componentsInChildren = transform2.gameObject.GetComponentsInChildren<TextMesh>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].text = rewardAmount.ToString();
				}
			}
			else
			{
				transform.gameObject.SetActive(false);
				transform2.gameObject.SetActive(false);
			}
		}
		return gameObject;
	}

	private void ShowAnimation()
	{
		this.rewardAnimation.state.ClearTracks();
		Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.lootWheelPrizeFly);
		this.rewardAnimation.state.AddAnimation(0, this.rewardAnimationName, false, 0f);
		this.rewardAnimation.state.End += this.OnAnimationEnd;
	}

	private void OnAnimationEnd(Spine.AnimationState state, int trackIndex)
	{
		if (this.icon != null)
		{
			this.rewardParticleSystem.transform.position = this.icon.transform.position;
			this.rewardParticleSystem.Play();
			Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.bonusBoxCollected);
			base.StartCoroutine(CoroutineRunner.DelayActionSequence(delegate
			{
				this.OnPressed();
			}, this.rewardParticleSystem.startLifetime + this.rewardParticleSystem.duration, false));
		}
	}

	private void OnAnimationEvent(Spine.AnimationState state, int trackIndex, Spine.Event e)
	{
		string name = e.Data.Name;
		if (name != null)
		{
			if (!(name == "ground_hit"))
			{
				if (!(name == "confetti1"))
				{
					if (!(name == "confetti2"))
					{
						if (name == "jump")
						{
							AudioSource[] rewardBounce = WPFMonoBehaviour.gameData.commonAudioCollection.rewardBounce;
							Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(rewardBounce[UnityEngine.Random.Range(0, rewardBounce.Length)]);
						}
					}
					else
					{
						this.confetti2ParticleSystem.Play();
					}
				}
				else
				{
					this.confetti1ParticleSystem.Play();
				}
			}
			else
			{
				AudioSource[] cratePillowHit = WPFMonoBehaviour.gameData.commonAudioCollection.cratePillowHit;
				Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(cratePillowHit[UnityEngine.Random.Range(0, cratePillowHit.Length)]);
			}
		}
	}

	private void ShowHorns(bool show)
	{
		this.horns.gameObject.SetActive(show);
		if (!show)
		{
			return;
		}
		base.StartCoroutine(this.ShowHorns());
	}

	private IEnumerator ShowHorns()
	{
		for (int i = 0; i < this.hornRenderers.Length; i++)
		{
			this.hornRenderers[i].enabled = false;
		}
		for (int j = 0; j < this.hornAnimations.Length; j++)
		{
			this.hornAnimations[j].state.ClearTracks();
			this.hornAnimations[j].state.AddAnimation(0, this.hornAnimation, false, 0f);
		}
		yield return null;
		for (int k = 0; k < this.hornRenderers.Length; k++)
		{
			this.hornRenderers[k].enabled = true;
		}
		yield return new WaitForSeconds(1f);
		Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.winTrumpet[0]);
		yield break;
	}

	private void HandleKeyReleased(KeyCode key)
	{
		if (key == KeyCode.Escape)
		{
			this.OnPressed();
		}
	}

	[SerializeField]
	private float showTime;

	[SerializeField]
	private Transform targetPosition;

	[SerializeField]
	private string hornAnimation;

	[SerializeField]
	private string rewardAnimationName;

	[SerializeField]
	private GameObject rewardParticles;

	[SerializeField]
	private GameObject confettiParticles;

	[SerializeField]
	private SkeletonAnimation rewardAnimation;

	[SerializeField]
	private GameObject epicRewardBackground;

	[SerializeField]
	private GameObject rareRewardBackground;

	[SerializeField]
	private GameObject commonRewardBackground;

	[SerializeField]
	private GameObject regularRewardBackground;

	private Transform horns;

	private GameObject icon;

	private SkeletonAnimation[] hornAnimations;

	private Renderer[] hornRenderers;

	private ParticleSystem rewardParticleSystem;

	private ParticleSystem confetti1ParticleSystem;

	private ParticleSystem confetti2ParticleSystem;

	private Dictionary<BackgroundType, GameObject> bgDictionary;

	private Action OnClosed;

	public enum BackgroundType
	{
		Epic,
		Rare,
		Common,
		Regular
	}
}
