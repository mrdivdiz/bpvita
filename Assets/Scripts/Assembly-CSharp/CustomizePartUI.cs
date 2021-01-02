using System;
using System.Collections.Generic;
using UnityEngine;

public class CustomizePartUI : WPFMonoBehaviour
{
	public void InitButtons(PartListing partListing, Action<BasePart.PartType> onButtonPressed)
	{
		this.cachedPartListing = partListing;
		this.onButtonPressed = onButtonPressed;
		if (this.initButtonsDone)
		{
			return;
		}
		if (this.customPartWidget != null)
		{
			Transform transform = this.cachedPartListing.transform.Find("Close");
			if (transform)
			{
				this.customPartWidget.closeButton = transform.GetComponent<Button>();
			}
		}
		for (int i = 0; i < Enum.GetNames(typeof(BasePart.PartType)).Length; i++)
		{
			for (int j = 0; j < Enum.GetNames(typeof(BasePart.PartTier)).Length; j++)
			{
				BasePart.PartType partType = (BasePart.PartType)i;
				List<GameObject> partTierInstances = this.cachedPartListing.GetPartTierInstances(partType, (BasePart.PartTier)j);
				if (partTierInstances != null)
				{
					for (int k = 0; k < partTierInstances.Count; k++)
					{
						bool enabled = j == 0;
						int customPartIndex = WPFMonoBehaviour.gameData.GetCustomPartIndex(partType, partTierInstances[k].name);
						if (j > 0)
						{
							enabled = CustomizationManager.IsPartUnlocked(WPFMonoBehaviour.gameData.GetCustomPart(partType, customPartIndex));
						}
						BoxCollider component = partTierInstances[k].GetComponent<BoxCollider>();
						if (component != null)
						{
							component.enabled = enabled;
							Button component2 = partTierInstances[k].GetComponent<Button>();
							component2.MethodToCall.SetMethod(this, "CustomButtonPressed", new object[]
							{
								i,
								customPartIndex
							});
						}
					}
				}
			}
		}
		this.cachedPartListing.CreateSelectionIcons();
		this.initButtonsDone = true;
	}

	public void CustomButtonPressed(int partTypeIndex, int partIndex)
	{
		if (this.cachedPartListing.LastMovement > 1.5f)
		{
			return;
		}
		BasePart customPart = WPFMonoBehaviour.gameData.GetCustomPart((BasePart.PartType)partTypeIndex, partIndex);
		this.cachedPartListing.UpdateSelectionIcon((BasePart.PartType)partTypeIndex, customPart.name);
		this.cachedPartListing.PlaySelectionAudio((BasePart.PartType)partTypeIndex, customPart.name);
		if (!CustomizationManager.IsPartUsed(customPart))
		{
			this.cachedPartListing.ShowExperienceParticles((BasePart.PartType)partTypeIndex, customPart.name);
			CustomizationManager.SetPartUsed(customPart, true);
		}
		if (CustomizationManager.IsPartNew(customPart))
		{
			CustomizationManager.SetPartNew(customPart, false);
		}
		CustomizationManager.SetLastUsedPartIndex((BasePart.PartType)partTypeIndex, partIndex);
		EventManager.Send(new PartCustomizationEvent((BasePart.PartType)partTypeIndex, partIndex));
		if (this.onButtonPressed != null)
		{
			this.onButtonPressed((BasePart.PartType)partTypeIndex);
			if (this.customPartWidget != null)
			{
				this.customPartWidget.ClosePastList();
			}
		}
	}

	private const float MOVEMENT_LIMIT = 1.5f;

	public CustomizePartWidget customPartWidget;

	private bool initButtonsDone;

	private Action<BasePart.PartType> onButtonPressed;

	private PartListing cachedPartListing;

	public struct PartCustomizationEvent : EventManager.Event
	{
		public PartCustomizationEvent(BasePart.PartType customizedPart, int customPartIndex)
		{
			this.customizedPart = customizedPart;
			this.customPartIndex = customPartIndex;
		}

		public BasePart.PartType customizedPart;

		public int customPartIndex;
	}
}
