using System;

namespace Spine
{
	public class Event
	{
		public Event(float time, EventData data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data", "data cannot be null.");
			}
			this.Time = time;
			this.Data = data;
		}

		public EventData Data { get; private set; }

		public int Int { get; set; }

		public float Float { get; set; }

		public string String { get; set; }

		public float Time { get; private set; }

		public override string ToString()
		{
			return this.Data.Name;
		}
	}
}
