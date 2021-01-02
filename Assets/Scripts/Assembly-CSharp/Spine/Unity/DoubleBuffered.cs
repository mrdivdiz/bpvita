using System;

namespace Spine.Unity
{
	public class DoubleBuffered<T> where T : new()
	{
		public T GetNext()
		{
			this.usingA = !this.usingA;
			return (!this.usingA) ? this.b : this.a;
		}

		private readonly T a = Activator.CreateInstance<T>();

		private readonly T b = Activator.CreateInstance<T>();

		private bool usingA;
	}
}
