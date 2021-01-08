namespace Spine
{
    public class TrackEntry
	{
		public Animation Animation
		{
			get
			{
				return this.animation;
			}
		}

		public float Delay
		{
			get
			{
				return this.delay;
			}
			set
			{
				this.delay = value;
			}
		}

		public float Time
		{
			get
			{
				return this.time;
			}
			set
			{
				this.time = value;
			}
		}

		public float LastTime
		{
			get
			{
				return this.lastTime;
			}
			set
			{
				this.lastTime = value;
			}
		}

		public float EndTime
		{
			get
			{
				return this.endTime;
			}
			set
			{
				this.endTime = value;
			}
		}

		public float TimeScale
		{
			get
			{
				return this.timeScale;
			}
			set
			{
				this.timeScale = value;
			}
		}

		public float Mix
		{
			get
			{
				return this.mix;
			}
			set
			{
				this.mix = value;
			}
		}

		public bool Loop
		{
			get
			{
				return this.loop;
			}
			set
			{
				this.loop = value;
			}
		}

		public event AnimationState.StartEndDelegate Start;

		public event AnimationState.StartEndDelegate End;

		public event AnimationState.EventDelegate Event;

		public event AnimationState.CompleteDelegate Complete;

		internal void OnStart(AnimationState state, int index)
		{
			if (this.Start != null)
			{
				this.Start(state, index);
			}
		}

		internal void OnEnd(AnimationState state, int index)
		{
			if (this.End != null)
			{
				this.End(state, index);
			}
		}

		internal void OnEvent(AnimationState state, int index, Event e)
		{
			if (this.Event != null)
			{
				this.Event(state, index, e);
			}
		}

		internal void OnComplete(AnimationState state, int index, int loopCount)
		{
			if (this.Complete != null)
			{
				this.Complete(state, index, loopCount);
			}
		}

		public override string ToString()
		{
			return (this.animation != null) ? this.animation.name : "<none>";
		}

		internal TrackEntry next;

		internal TrackEntry previous;

		internal Animation animation;

		internal bool loop;

		internal float delay;

		internal float time;

		internal float lastTime = -1f;

		internal float endTime;

		internal float timeScale = 1f;

		internal float mixTime;

		internal float mixDuration;

		internal float mix = 1f;
	}
}
