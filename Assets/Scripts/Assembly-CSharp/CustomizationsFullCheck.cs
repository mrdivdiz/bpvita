using System.Collections;
using Spine.Unity;
using UnityEngine;

public class CustomizationsFullCheck : WPFMonoBehaviour
{
	public bool AllCommon
	{
		get
		{
			return CustomizationManager.CustomizationCount(BasePart.PartTier.Common, CustomizationManager.PartFlags.Locked | CustomizationManager.PartFlags.Craftable) <= 0;
		}
	}

	public bool AllRare
	{
		get
		{
			return CustomizationManager.CustomizationCount(BasePart.PartTier.Rare, CustomizationManager.PartFlags.Locked | CustomizationManager.PartFlags.Craftable) <= 0;
		}
	}

	public bool AllEpic
	{
		get
		{
			return CustomizationManager.CustomizationCount(BasePart.PartTier.Epic, CustomizationManager.PartFlags.Locked | CustomizationManager.PartFlags.Craftable) <= 0;
		}
	}

	private void Awake()
	{
		this.Check();
	}

	public void Check()
	{
		this.commonTierIndicator.SetActive(this.AllCommon);
		this.rareTierIndicator.SetActive(this.AllRare);
		this.epicTierIndicator.SetActive(this.AllEpic);
		if (!this.lamp1Disabled && this.AllCommon)
		{
			base.StartCoroutine(this.CreateOverride(this.lamp1));
			this.lamp1Disabled = true;
		}
		if (!this.lamp2Disabled && this.AllRare)
		{
			base.StartCoroutine(this.CreateOverride(this.lamp2));
			this.lamp2Disabled = true;
		}
		if (!this.lamp3Disabled && this.AllEpic)
		{
			base.StartCoroutine(this.CreateOverride(this.lamp3));
			this.lamp3Disabled = true;
		}
	}

	private IEnumerator CreateOverride(SkeletonUtilityBone target)
	{
		yield return null;
		GameObject go = target.skeletonUtility.SpawnBone(target.bone, target.transform.parent, SkeletonUtilityBone.Mode.Override, target.position, target.rotation, target.scale);
		go.name += " [Override]";
		go.transform.position = new Vector3(10000f, 0f, 0f);
		yield break;
	}

	[SerializeField]
	private GameObject commonTierIndicator;

	[SerializeField]
	private GameObject rareTierIndicator;

	[SerializeField]
	private GameObject epicTierIndicator;

	[SerializeField]
	private SkeletonUtilityBone lamp1;

	[SerializeField]
	private SkeletonUtilityBone lamp2;

	[SerializeField]
	private SkeletonUtilityBone lamp3;

	private bool lamp1Disabled;

	private bool lamp2Disabled;

	private bool lamp3Disabled;
}
