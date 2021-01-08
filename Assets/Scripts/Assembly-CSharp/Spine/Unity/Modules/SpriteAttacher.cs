using UnityEngine;

namespace Spine.Unity.Modules
{
    public class SpriteAttacher : MonoBehaviour
	{
		private void Start()
		{
			if (this.attachOnStart)
			{
				this.Attach();
			}
		}

		public void Attach()
		{
			ISkeletonComponent component = base.GetComponent<ISkeletonComponent>();
			SkeletonRenderer skeletonRenderer = component as SkeletonRenderer;
			if (skeletonRenderer != null)
			{
				this.applyPMA = skeletonRenderer.pmaVertexColors;
			}
			else
			{
				SkeletonGraphic skeletonGraphic = component as SkeletonGraphic;
				if (skeletonGraphic != null)
				{
					this.applyPMA = skeletonGraphic.SpineMeshGenerator.PremultiplyVertexColors;
				}
			}
			Shader shader = (!this.applyPMA) ? Shader.Find("Sprites/Default") : Shader.Find("Spine/Skeleton");
			this.loader = (this.loader ?? new SpriteAttachmentLoader(this.sprite, shader, this.applyPMA));
			if (this.attachment == null)
			{
				this.attachment = this.loader.NewRegionAttachment(null, this.sprite.name, string.Empty);
			}
			component.Skeleton.FindSlot(this.slot).Attachment = this.attachment;
			if (!this.keepLoaderInMemory)
			{
				this.loader = null;
			}
		}

		private const string DefaultPMAShader = "Spine/Skeleton";

		private const string DefaultStraightAlphaShader = "Sprites/Default";

		public bool attachOnStart = true;

		public bool keepLoaderInMemory = true;

		public UnityEngine.Sprite sprite;

		[SpineSlot("", "", false)]
		public string slot;

		private SpriteAttachmentLoader loader;

		private RegionAttachment attachment;

		private bool applyPMA;
	}
}
