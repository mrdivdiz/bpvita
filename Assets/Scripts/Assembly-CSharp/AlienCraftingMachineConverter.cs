using System;
using System.Collections;
using Spine.Unity;
using UnityEngine;

public class AlienCraftingMachineConverter : WPFMonoBehaviour
{
	public bool RoutineShown
	{
		get
		{
			return GameProgress.GetBool("AlienCraftingMachineShown", false, GameProgress.Location.Local, null);
		}
		set
		{
			GameProgress.SetBool("AlienCraftingMachineShown", value, GameProgress.Location.Local);
		}
	}

	public bool ShowingRoutine
	{
		get
		{
			return this.m_showingRoutine;
		}
	}

	public bool IsAlienMachine
	{
		get
		{
			return this.customizationsCheck.AllCommon && this.customizationsCheck.AllRare && this.customizationsCheck.AllEpic;
		}
	}

	private void Awake()
	{
		this.m_curtainRenderers = this.m_curtainAnimation.gameObject.GetComponentsInChildren<Renderer>();
		for (int i = 0; i < this.m_curtainRenderers.Length; i++)
		{
			this.m_curtainRenderers[i].enabled = false;
		}
	}

	private void Start()
	{
		if (this.IsAlienMachine && !this.RoutineShown)
		{
			EventManager.Connect(new EventManager.OnEvent<WorkshopMenu.CraftingMachineEvent>(this.OnCraftingMachineEvent));
		}
		EventManager.Connect(new EventManager.OnEvent<UIEvent>(this.OnUIEvenet));
	}

	private void OnDestroy()
	{
		EventManager.Disconnect(new EventManager.OnEvent<WorkshopMenu.CraftingMachineEvent>(this.OnCraftingMachineEvent));
		EventManager.Disconnect(new EventManager.OnEvent<UIEvent>(this.OnUIEvenet));
	}

	[ContextMenu("Upgrade to alien machine")]
	private void ContextMenuShow()
	{
		base.StartCoroutine(this.Show());
	}

	private void OnCraftingMachineEvent(WorkshopMenu.CraftingMachineEvent data)
	{
		WorkshopMenu.CraftingMachineAction action = data.action;
		if (action == WorkshopMenu.CraftingMachineAction.Idle)
		{
			EventManager.Disconnect(new EventManager.OnEvent<WorkshopMenu.CraftingMachineEvent>(this.OnCraftingMachineEvent));
			this.Check();
		}
	}

	private void OnUIEvenet(UIEvent data)
	{
		UIEvent.Type type = data.type;
		if (type == UIEvent.Type.ClosedLootWheel)
		{
			this.Check();
		}
	}

	public void Check()
	{
		if (this.IsAlienMachine && !this.RoutineShown)
		{
			base.StartCoroutine(this.Show());
		}
	}

	private IEnumerator Show()
	{
		this.m_showingRoutine = true;
		if (this.OnBeginUpgrade != null)
		{
			this.OnBeginUpgrade();
		}
		this.m_curtainAnimation.state.End += this.OnIntroEnd;
		this.m_curtainAnimation.state.SetAnimation(0, this.m_curtainIntroAnimationName, false);
		yield return null;
		for (int i = 0; i < this.m_curtainRenderers.Length; i++)
		{
			this.m_curtainRenderers[i].enabled = true;
		}
		yield break;
	}

	private void OnIntroEnd(Spine.AnimationState state, int trackIndex)
	{
		this.m_curtainAnimation.state.End -= this.OnIntroEnd;
		AudioSource craftPart = WPFMonoBehaviour.gameData.commonAudioCollection.craftPart;
		Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(craftPart);
		this.dustParticles.Play();
		this.ConvertToAlien();
		if (this.OnMachineBehindCurtain != null)
		{
			this.OnMachineBehindCurtain();
		}
		CoroutineRunner.Instance.DelayAction(delegate
		{
			this.dustParticles.Stop();
			this.m_curtainAnimation.state.End += this.OnOutroEnd;
			this.m_curtainAnimation.state.SetAnimation(0, this.m_curtainOutroAnimationName, false);
			Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.alienMachineReveal);
		}, craftPart.clip.length, false);
	}

	public void ConvertToAlien()
	{
		this.m_craftingMachineAnimation.initialSkinName = this.m_alienSkinName;
		this.m_craftingMachineAnimation.Initialize(true);
		this.alienScrapCounter.SetActive(true);
		this.normalScrapCounter.SetActive(false);
		this.alienPartSilhouette.SetActive(true);
		for (int i = 0; i < this.m_collectIndicators.Length; i++)
		{
			this.m_collectIndicators[i].SetActive(false);
		}
	}

	private void OnOutroEnd(Spine.AnimationState state, int trackIndex)
	{
		this.m_curtainAnimation.state.End -= this.OnOutroEnd;
		this.m_isAlienMachine = true;
		this.RoutineShown = true;
		this.m_showingRoutine = false;
		if (this.OnEndUpgrade != null)
		{
			this.OnEndUpgrade();
		}
	}

	public Action OnBeginUpgrade;

	public Action OnEndUpgrade;

	public Action OnMachineBehindCurtain;

	[SerializeField]
	private SkeletonAnimation m_curtainAnimation;

	[SerializeField]
	private string m_curtainIntroAnimationName;

	[SerializeField]
	private string m_curtainOutroAnimationName;

	[SerializeField]
	private SkeletonAnimation m_craftingMachineAnimation;

	[SerializeField]
	private string m_alienSkinName;

	[SerializeField]
	private CustomizationsFullCheck customizationsCheck;

	[SerializeField]
	private GameObject normalScrapCounter;

	[SerializeField]
	private GameObject alienScrapCounter;

	[SerializeField]
	private GameObject alienPartSilhouette;

	[SerializeField]
	private GameObject[] m_collectIndicators;

	[SerializeField]
	private ParticleSystem dustParticles;

	private Renderer[] m_curtainRenderers;

	private bool m_showingRoutine;

	private bool m_isAlienMachine;
}
