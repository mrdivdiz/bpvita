using System;

namespace Spine
{
	public abstract class Attachment
	{
		public Attachment(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name", "name cannot be null");
			}
			this.Name = name;
		}

		public string Name { get; private set; }

		public override string ToString()
		{
			return this.Name;
		}
	}
}
