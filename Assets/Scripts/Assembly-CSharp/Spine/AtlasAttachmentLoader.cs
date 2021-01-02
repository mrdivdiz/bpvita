using System;

namespace Spine
{
	public class AtlasAttachmentLoader : AttachmentLoader
	{
		public AtlasAttachmentLoader(params Atlas[] atlasArray)
		{
			if (atlasArray == null)
			{
				throw new ArgumentNullException("atlas array cannot be null.");
			}
			this.atlasArray = atlasArray;
		}

		public RegionAttachment NewRegionAttachment(Skin skin, string name, string path)
		{
			AtlasRegion atlasRegion = this.FindRegion(path);
			if (atlasRegion == null)
			{
				throw new Exception(string.Concat(new string[]
				{
					"Region not found in atlas: ",
					path,
					" (region attachment: ",
					name,
					")"
				}));
			}
			RegionAttachment regionAttachment = new RegionAttachment(name);
			regionAttachment.RendererObject = atlasRegion;
			regionAttachment.SetUVs(atlasRegion.u, atlasRegion.v, atlasRegion.u2, atlasRegion.v2, atlasRegion.rotate);
			regionAttachment.regionOffsetX = atlasRegion.offsetX;
			regionAttachment.regionOffsetY = atlasRegion.offsetY;
			regionAttachment.regionWidth = (float)atlasRegion.width;
			regionAttachment.regionHeight = (float)atlasRegion.height;
			regionAttachment.regionOriginalWidth = (float)atlasRegion.originalWidth;
			regionAttachment.regionOriginalHeight = (float)atlasRegion.originalHeight;
			return regionAttachment;
		}

		public MeshAttachment NewMeshAttachment(Skin skin, string name, string path)
		{
			AtlasRegion atlasRegion = this.FindRegion(path);
			if (atlasRegion == null)
			{
				throw new Exception(string.Concat(new string[]
				{
					"Region not found in atlas: ",
					path,
					" (mesh attachment: ",
					name,
					")"
				}));
			}
			return new MeshAttachment(name)
			{
				RendererObject = atlasRegion,
				RegionU = atlasRegion.u,
				RegionV = atlasRegion.v,
				RegionU2 = atlasRegion.u2,
				RegionV2 = atlasRegion.v2,
				RegionRotate = atlasRegion.rotate,
				regionOffsetX = atlasRegion.offsetX,
				regionOffsetY = atlasRegion.offsetY,
				regionWidth = (float)atlasRegion.width,
				regionHeight = (float)atlasRegion.height,
				regionOriginalWidth = (float)atlasRegion.originalWidth,
				regionOriginalHeight = (float)atlasRegion.originalHeight
			};
		}

		public BoundingBoxAttachment NewBoundingBoxAttachment(Skin skin, string name)
		{
			return new BoundingBoxAttachment(name);
		}

		public PathAttachment NewPathAttachment(Skin skin, string name)
		{
			return new PathAttachment(name);
		}

		public AtlasRegion FindRegion(string name)
		{
			for (int i = 0; i < this.atlasArray.Length; i++)
			{
				AtlasRegion atlasRegion = this.atlasArray[i].FindRegion(name);
				if (atlasRegion != null)
				{
					return atlasRegion;
				}
			}
			return null;
		}

		private Atlas[] atlasArray;
	}
}
