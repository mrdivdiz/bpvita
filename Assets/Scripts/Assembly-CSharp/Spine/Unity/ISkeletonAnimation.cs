namespace Spine.Unity
{
    public interface ISkeletonAnimation
	{
		event UpdateBonesDelegate UpdateLocal;

		event UpdateBonesDelegate UpdateWorld;

		event UpdateBonesDelegate UpdateComplete;

		void LateUpdate();

		Skeleton Skeleton { get; }
	}
}
