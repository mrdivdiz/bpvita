using System;
using UnityEngine;

public class VisibilityCondition : WPFMonoBehaviour
{
	private void Awake()
	{
		this.m_renderer = base.gameObject.GetComponent<Renderer>();
		this.m_collider = base.gameObject.GetComponent<Collider>();
		this.m_transform = base.gameObject.transform;
		if (Singleton<VisibilityConditionManager>.IsInstantiated())
		{
			Singleton<VisibilityConditionManager>.Instance.SubscribeToConditionChange(new VisibilityConditionManager.ConditionChange(this.SetEnabled), this.condition);
		}
	}

	private void OnDestroy()
	{
		if (Singleton<VisibilityConditionManager>.IsInstantiated())
		{
			Singleton<VisibilityConditionManager>.Instance.UnsubscribeToConditionChange(new VisibilityConditionManager.ConditionChange(this.SetEnabled), this.condition);
		}
	}

	public void UpdateState()
	{
		if (Singleton<VisibilityConditionManager>.IsInstantiated())
		{
			this.SetEnabled(this.condition, Singleton<VisibilityConditionManager>.Instance.GetState(this.condition));
		}
	}

	private void SetEnabled(Condition condition, bool enabled)
	{
		if (condition != this.condition)
		{
			return;
		}
		bool flag = false;
		if (this.not)
		{
			enabled = !enabled;
		}
		if (this.m_renderer && this.m_renderer.enabled != enabled)
		{
			flag = true;
			this.m_renderer.enabled = enabled;
		}
		if (this.m_collider && this.m_collider.enabled != enabled)
		{
			flag = true;
			this.m_collider.enabled = enabled;
		}
		if (flag || !this.m_renderer)
		{
			int childCount = this.m_transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				Transform child = this.m_transform.GetChild(i);
				Renderer component = child.GetComponent<Renderer>();
				if (component && component.enabled != enabled)
				{
					component.enabled = enabled;
				}
			}
		}
		if (this.disableGameObject)
		{
			base.gameObject.SetActive(enabled);
		}
	}

	public Condition condition;

	public bool not;

	[SerializeField]
	private bool disableGameObject;

	private Renderer m_renderer;

	private Collider m_collider;

	private Transform m_transform;

	[Serializable]
	public struct ConditionStruct
	{
		public Condition condition;

		public bool not;
	}

	public enum Condition
	{
		None,
		HasValidContraption,
		ShowEngineButton,
		HasRockets,
		IsPausedWhileRunning,
		HasContraption,
		QuestModeCanBuild,
		IsPuzzleMode,
		ShowPauseMenuReplayButton,
		HasMotorWheels,
		HasFans,
		HasPropellers,
		HasRotors,
		ShowBuyBluePrintButton,
		ShowAutoBuildButton,
		ShowTutorialButton,
		IsAutoBuilding,
		CanClearContraption,
		IsNotAutoBuilding,
		ShowBuildModeButtons,
		IAPEnabled,
		ChiefPigExploded,
		ShowSuperMechanicSwitch,
		IsSandbox,
		ShowSchematicsButton,
		EveryPlayAvailable,
		EveryPlayAvailableAndRecorded,
		EveryPlayRecording,
		GameCenterAvailable,
		IsFreeVersion,
		IsHDVersion,
		IsOdyssey,
		IsIOS,
		CheatsEnabled,
		IsDebugBuild,
		CollectedFreeShopLootcrate,
		HasNewParts,
		LessCheats,
		HasNetwork,
		BoughtFieldOfDreams,
		DailyChallengeComplete,
		IsCakeRaceMode,
		IsDecember
	}
}
