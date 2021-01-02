using System;

[Serializable]
public class e2dCurvePerlinPreset : e2dPreset
{
	public override void Copy(e2dPreset other)
	{
		e2dCurvePerlinPreset e2dCurvePerlinPreset = (e2dCurvePerlinPreset)other;
		this.octaves = e2dCurvePerlinPreset.octaves;
		this.frequencyPerUnit = e2dCurvePerlinPreset.frequencyPerUnit;
		this.persistence = e2dCurvePerlinPreset.persistence;
	}

	public override void UpdateValues(e2dTerrainGenerator generator)
	{
		generator.Perlin.Copy(this);
	}

	public override e2dPreset Clone()
	{
		e2dCurvePerlinPreset e2dCurvePerlinPreset = new e2dCurvePerlinPreset();
		e2dCurvePerlinPreset.Copy(this);
		return e2dCurvePerlinPreset;
	}

	public int octaves;

	public float frequencyPerUnit;

	public float persistence;
}
