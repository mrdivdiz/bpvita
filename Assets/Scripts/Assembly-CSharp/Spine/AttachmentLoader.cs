namespace Spine
{
    public interface AttachmentLoader
	{
		RegionAttachment NewRegionAttachment(Skin skin, string name, string path);

		MeshAttachment NewMeshAttachment(Skin skin, string name, string path);

		BoundingBoxAttachment NewBoundingBoxAttachment(Skin skin, string name);

		PathAttachment NewPathAttachment(Skin skin, string name);
	}
}
