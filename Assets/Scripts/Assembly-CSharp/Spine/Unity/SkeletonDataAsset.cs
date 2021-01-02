using System;
using System.IO;
using UnityEngine;

namespace Spine.Unity
{
	public class SkeletonDataAsset : ScriptableObject
	{
		private void OnEnable()
		{
			if (this.atlasAssets == null)
			{
				this.atlasAssets = new AtlasAsset[0];
			}
		}

		public void Reset()
		{
			this.skeletonData = null;
			this.stateData = null;
		}

		public SkeletonData GetSkeletonData(bool quiet)
		{
			if (this.atlasAssets == null)
			{
				this.atlasAssets = new AtlasAsset[0];
				if (!quiet)
				{
				}
				this.Reset();
				return null;
			}
			if (this.skeletonJSON == null)
			{
				if (!quiet)
				{
				}
				this.Reset();
				return null;
			}
			if (this.atlasAssets.Length == 0)
			{
				this.Reset();
				return null;
			}
			Atlas[] array = new Atlas[this.atlasAssets.Length];
			for (int i = 0; i < this.atlasAssets.Length; i++)
			{
				if (this.atlasAssets[i] == null)
				{
					this.Reset();
					return null;
				}
				array[i] = this.atlasAssets[i].GetAtlas();
				if (array[i] == null)
				{
					this.Reset();
					return null;
				}
			}
			if (this.skeletonData != null)
			{
				return this.skeletonData;
			}
			AttachmentLoader attachmentLoader = new AtlasAttachmentLoader(array);
			float num = this.scale;
			try
			{
				if (this.skeletonJSON.name.ToLower().Contains(".skel"))
				{
					MemoryStream input = new MemoryStream(this.skeletonJSON.bytes);
					this.skeletonData = new SkeletonBinary(attachmentLoader)
					{
						Scale = num
					}.ReadSkeletonData(input);
				}
				else
				{
					StringReader reader = new StringReader(this.skeletonJSON.text);
					this.skeletonData = new SkeletonJson(attachmentLoader)
					{
						Scale = num
					}.ReadSkeletonData(reader);
				}
			}
			catch (Exception ex)
			{
				if (!quiet)
				{
				}
				return null;
			}
			this.stateData = new AnimationStateData(this.skeletonData);
			this.FillStateData();
			return this.skeletonData;
		}

		public void FillStateData()
		{
			if (this.stateData == null)
			{
				return;
			}
			this.stateData.DefaultMix = this.defaultMix;
			if (this.fromAnimation == null || this.toAnimation == null)
			{
				return;
			}
			int i = 0;
			int num = this.fromAnimation.Length;
			while (i < num)
			{
				if (this.fromAnimation[i].Length != 0 && this.toAnimation[i].Length != 0)
				{
					this.stateData.SetMix(this.fromAnimation[i], this.toAnimation[i], this.duration[i]);
				}
				i++;
			}
		}

		public AnimationStateData GetAnimationStateData()
		{
			if (this.stateData != null)
			{
				return this.stateData;
			}
			this.GetSkeletonData(false);
			return this.stateData;
		}

		public AtlasAsset[] atlasAssets;

		public float scale = 0.01f;

		public TextAsset skeletonJSON;

		public string[] fromAnimation;

		public string[] toAnimation;

		public float[] duration;

		public float defaultMix;

		public RuntimeAnimatorController controller;

		private SkeletonData skeletonData;

		private AnimationStateData stateData;
	}
}
