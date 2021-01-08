using System;

namespace Spine
{
	public class EventData
	{
		public EventData(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name", "name cannot be null.");
			}
			this.name = name;
		}

		public string Name
		{
			get
			{
				return this.name;
			}
		}

		public int Int { get; set; }

		public float Float { get; set; }

		public string String { get; set; }

		public override string ToString()
		{
			return this.Name;
		}

		internal string name;
	}
}
