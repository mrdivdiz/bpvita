public class DisjointSet
{
	public DisjointSet(int count)
	{
		this.parents = new int[count];
		for (int i = 0; i < count; i++)
		{
			this.parents[i] = i;
		}
	}

	public int FindSet(int x)
	{
		int num = this.parents[x];
		if (x == num)
		{
			return num;
		}
		return this.parents[x] = this.FindSet(num);
	}

	public void Union(int x, int y)
	{
		this.parents[this.FindSet(x)] = this.FindSet(y);
	}

	private int[] parents;
}