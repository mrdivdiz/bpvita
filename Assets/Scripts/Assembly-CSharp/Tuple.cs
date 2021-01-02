public class Tuple<T1, T2>
{
	public Tuple()
	{
		this.item1 = default(T1);
		this.item2 = default(T2);
	}

	public Tuple(T1 item1, T2 item2)
	{
		this.item1 = item1;
		this.item2 = item2;
	}

	public T1 Item1
	{
		get
		{
			return this.item1;
		}
		set
		{
			this.item1 = value;
		}
	}

	public T2 Item2
	{
		get
		{
			return this.item2;
		}
		set
		{
			this.item2 = value;
		}
	}

	private T1 item1;

	private T2 item2;
}
