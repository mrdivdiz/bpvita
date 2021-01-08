namespace Spine
{
    public class EventTimeline : Timeline
	{
		public EventTimeline(int frameCount)
		{
			this.frames = new float[frameCount];
			this.events = new Event[frameCount];
		}

		public float[] Frames
		{
			get
			{
				return this.frames;
			}
			set
			{
				this.frames = value;
			}
		}

		public Event[] Events
		{
			get
			{
				return this.events;
			}
			set
			{
				this.events = value;
			}
		}

		public int FrameCount
		{
			get
			{
				return this.frames.Length;
			}
		}

		public void SetFrame(int frameIndex, Event e)
		{
			this.frames[frameIndex] = e.Time;
			this.events[frameIndex] = e;
		}

		public void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha)
		{
			if (firedEvents == null)
			{
				return;
			}
			float[] array = this.frames;
			int num = array.Length;
			if (lastTime > time)
			{
				this.Apply(skeleton, lastTime, 2.14748365E+09f, firedEvents, alpha);
				lastTime = -1f;
			}
			else if (lastTime >= array[num - 1])
			{
				return;
			}
			if (time < array[0])
			{
				return;
			}
			int i;
			if (lastTime < array[0])
			{
				i = 0;
			}
			else
			{
				i = Animation.binarySearch(array, lastTime);
				float num2 = array[i];
				while (i > 0)
				{
					if (array[i - 1] != num2)
					{
						break;
					}
					i--;
				}
			}
			while (i < num && time >= array[i])
			{
				firedEvents.Add(this.events[i]);
				i++;
			}
		}

		internal float[] frames;

		private Event[] events;
	}
}
