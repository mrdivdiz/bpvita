namespace Spine.Unity
{
    public class SpineBone : SpineAttributeBase
	{
		public SpineBone(string startsWith = "", string dataField = "")
		{
			this.startsWith = startsWith;
			this.dataField = dataField;
		}

		public static Bone GetBone(string boneName, SkeletonRenderer renderer)
		{
			return (renderer.skeleton != null) ? renderer.skeleton.FindBone(boneName) : null;
		}

		public static BoneData GetBoneData(string boneName, SkeletonDataAsset skeletonDataAsset)
		{
			SkeletonData skeletonData = skeletonDataAsset.GetSkeletonData(true);
			return skeletonData.FindBone(boneName);
		}
	}
}
