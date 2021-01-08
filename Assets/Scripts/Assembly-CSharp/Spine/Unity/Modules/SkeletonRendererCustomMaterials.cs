using System;
using System.Collections.Generic;
using UnityEngine;

namespace Spine.Unity.Modules
{
	[ExecuteInEditMode]
	public class SkeletonRendererCustomMaterials : MonoBehaviour
	{
		private void SetCustomSlotMaterials()
		{
			if (this.skeletonRenderer == null)
			{
				return;
			}
			for (int i = 0; i < this.customSlotMaterials.Count; i++)
			{
                SlotMaterialOverride slotMaterialOverride = this.customSlotMaterials[i];
				if (!slotMaterialOverride.overrideDisabled && !string.IsNullOrEmpty(slotMaterialOverride.slotName))
				{
					Slot key = this.skeletonRenderer.skeleton.FindSlot(slotMaterialOverride.slotName);
					this.skeletonRenderer.CustomSlotMaterials[key] = slotMaterialOverride.material;
				}
			}
		}

		private void RemoveCustomSlotMaterials()
		{
			if (this.skeletonRenderer == null)
			{
				return;
			}
			for (int i = 0; i < this.customSlotMaterials.Count; i++)
			{
                SlotMaterialOverride slotMaterialOverride = this.customSlotMaterials[i];
				if (!string.IsNullOrEmpty(slotMaterialOverride.slotName))
				{
					Slot key = this.skeletonRenderer.skeleton.FindSlot(slotMaterialOverride.slotName);
					Material x;
					if (this.skeletonRenderer.CustomSlotMaterials.TryGetValue(key, out x))
					{
						if (!(x != slotMaterialOverride.material))
						{
							this.skeletonRenderer.CustomSlotMaterials.Remove(key);
						}
					}
				}
			}
		}

		private void SetCustomMaterialOverrides()
		{
			if (this.skeletonRenderer == null)
			{
				return;
			}
			for (int i = 0; i < this.customMaterialOverrides.Count; i++)
			{
                AtlasMaterialOverride atlasMaterialOverride = this.customMaterialOverrides[i];
				if (!atlasMaterialOverride.overrideDisabled)
				{
					this.skeletonRenderer.CustomMaterialOverride[atlasMaterialOverride.originalMaterial] = atlasMaterialOverride.replacementMaterial;
				}
			}
		}

		private void RemoveCustomMaterialOverrides()
		{
			if (this.skeletonRenderer == null)
			{
				return;
			}
			for (int i = 0; i < this.customMaterialOverrides.Count; i++)
			{
                AtlasMaterialOverride atlasMaterialOverride = this.customMaterialOverrides[i];
				Material x;
				if (this.skeletonRenderer.CustomMaterialOverride.TryGetValue(atlasMaterialOverride.originalMaterial, out x))
				{
					if (!(x != atlasMaterialOverride.replacementMaterial))
					{
						this.skeletonRenderer.CustomMaterialOverride.Remove(atlasMaterialOverride.originalMaterial);
					}
				}
			}
		}

		private void OnEnable()
		{
			if (this.skeletonRenderer == null)
			{
				this.skeletonRenderer = base.GetComponent<SkeletonRenderer>();
			}
			if (this.skeletonRenderer == null)
			{
				return;
			}
			this.skeletonRenderer.Initialize(false);
			this.SetCustomMaterialOverrides();
			this.SetCustomSlotMaterials();
		}

		private void OnDisable()
		{
			if (this.skeletonRenderer == null)
			{
				return;
			}
			this.RemoveCustomMaterialOverrides();
			this.RemoveCustomSlotMaterials();
		}

		public SkeletonRenderer skeletonRenderer;

		[SerializeField]
		private List<SlotMaterialOverride> customSlotMaterials = new List<SlotMaterialOverride>();

		[SerializeField]
		private List<AtlasMaterialOverride> customMaterialOverrides = new List<AtlasMaterialOverride>();

		[Serializable]
		public struct SlotMaterialOverride : IEquatable<SlotMaterialOverride>
		{
			public bool Equals(SlotMaterialOverride other)
			{
				return this.overrideDisabled == other.overrideDisabled && this.slotName == other.slotName && this.material == other.material;
			}

			public bool overrideDisabled;

			[SpineSlot("", "", false)]
			public string slotName;

			public Material material;
		}

		[Serializable]
		public struct AtlasMaterialOverride : IEquatable<AtlasMaterialOverride>
		{
			public bool Equals(AtlasMaterialOverride other)
			{
				return this.overrideDisabled == other.overrideDisabled && this.originalMaterial == other.originalMaterial && this.replacementMaterial == other.replacementMaterial;
			}

			public bool overrideDisabled;

			public Material originalMaterial;

			public Material replacementMaterial;
		}
	}
}
