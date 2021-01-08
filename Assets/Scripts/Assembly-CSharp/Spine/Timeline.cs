namespace Spine
{
    public interface Timeline
	{
		void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> events, float alpha);
	}
}
