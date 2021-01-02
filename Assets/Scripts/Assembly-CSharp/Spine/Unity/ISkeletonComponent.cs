namespace Spine.Unity
{
    public interface ISkeletonComponent
	{
		SkeletonDataAsset SkeletonDataAsset { get; }

		Skeleton Skeleton { get; }
	}
}
