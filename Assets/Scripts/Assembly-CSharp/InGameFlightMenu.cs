using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameFlightMenu : WPFMonoBehaviour
{
	public GadgetButtonList ButtonList
	{
		get
		{
			return this.buttonList;
		}
	}

	private void OnEnable()
	{
		if (WPFMonoBehaviour.levelManager && WPFMonoBehaviour.levelManager.ContraptionRunning)
		{
			this.SetGadgetButtonOrder(WPFMonoBehaviour.levelManager.ContraptionRunning.PartPlacements);
		}
		bool flag = WPFMonoBehaviour.levelManager.CurrentGameMode is CakeRaceMode;
		if (!Singleton<BuildCustomizationLoader>.Instance.CheatsEnabled || WPFMonoBehaviour.levelManager.m_sandbox || flag)
		{
			this.cheatButton1Star.SetActive(false);
			this.cheatButton3Stars.SetActive(false);
		}
		this.editorButtons.SetActive(false);
		this.leftButtons[0].SetActive(!flag);
		this.leftButtons[1].SetActive(flag);
		this.leftButtons[2].SetActive(!flag);
		base.StartCoroutine(this.WaitEndOfAwake());
		if (DeviceInfo.ActiveDeviceFamily != DeviceInfo.DeviceFamily.Ios)
		{
			this.snapshotButton.SetActive(false);
		}
	}

	private IEnumerator WaitEndOfAwake()
	{
		yield return new WaitForEndOfFrame();
		GridLayout grid = this.leftButtons[0].transform.parent.GetComponent<GridLayout>();
		if (grid != null)
		{
			grid.UpdateLayout();
		}
		yield break;
	}

	private void SetGadgetButtonOrder(List<Contraption.PartPlacementInfo> parts)
	{
		int num = 0;
		List<GadgetButton> buttons = this.buttonList.Buttons;
		for (int i = 0; i < buttons.Count; i++)
		{
			buttons[i].UpdateState();
			if (buttons[i].VisibilityCondition != null)
			{
				buttons[i].VisibilityCondition.UpdateState();
			}
			bool enabled = false;
			for (int j = 0; j < parts.Count; j++)
			{
				if (InGameFlightMenu.CombinedTypeForGadgetButtonOrdering(parts[j].partType) == buttons[i].m_partType && parts[j].direction == buttons[i].m_direction)
				{
					buttons[i].PlacementOrder = (float)j;
					if (parts[j].count > 0)
					{
						enabled = true;
						num++;
					}
					break;
				}
			}
			buttons[i].Enabled = enabled;
		}
		this.buttonList.Sort(new InGameFlightMenu.PartButtonOrder((float)num / 2f + ((num % 2 != 0) ? 0.5f : 0f)));
	}

	public static BasePart.PartType CombinedTypeForGadgetButtonOrdering(BasePart.PartType originalType)
	{
		BasePart.PartType partType = BasePart.BaseType(originalType);
		if (partType == BasePart.PartType.EngineBig)
		{
			partType = BasePart.PartType.Engine;
		}
		else if (partType == BasePart.PartType.EngineSmall)
		{
			partType = BasePart.PartType.Engine;
		}
		return partType;
	}

	public void CompleteLevelWithThreeStars()
	{
	}

	public void CompleteLevelWithOneStar()
	{
	}

	public Button superContraptionIndexButton;

	[SerializeField]
	private GameObject cheatButton1Star;

	[SerializeField]
	private GameObject cheatButton3Stars;

	[SerializeField]
	private GameObject editorButtons;

	[SerializeField]
	private GameObject snapshotButton;

	[SerializeField]
	private GameObject[] leftButtons;

	[SerializeField]
	private GadgetButtonList buttonList;

	public class PartButtonOrder : IComparer<GadgetButton>
	{
		public PartButtonOrder(float middle)
		{
			this.middle = middle;
		}

		public int Compare(GadgetButton obj1, GadgetButton obj2)
		{
			float placementOrder = this.middle;
			float placementOrder2 = this.middle;
			if (obj1)
			{
				placementOrder = obj1.PlacementOrder;
			}
			if (obj1)
			{
				placementOrder2 = obj2.PlacementOrder;
			}
			if (placementOrder < placementOrder2)
			{
				return -1;
			}
			if (placementOrder > placementOrder2)
			{
				return 1;
			}
			return 0;
		}

		private float middle;
	}
}
