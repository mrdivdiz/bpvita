public abstract class e2dPreset
{
	public abstract void UpdateValues(e2dTerrainGenerator generator);

	public abstract void Copy(e2dPreset other);

	public abstract e2dPreset Clone();

	public string name;
}
