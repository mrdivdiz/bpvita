using System;

[Serializable]
public class e2dCurveMidpointPreset : e2dPreset
{
	public override void Copy(e2dPreset other)
	{
		e2dCurveMidpointPreset e2dCurveMidpointPreset = (e2dCurveMidpointPreset)other;
		this.frequencyPerUnit = e2dCurveMidpointPreset.frequencyPerUnit;
		this.roughness = e2dCurveMidpointPreset.roughness;
		this.usePeaks = e2dCurveMidpointPreset.usePeaks;
	}

	public override void UpdateValues(e2dTerrainGenerator generator)
	{
		generator.Midpoint.Copy(this);
	}

	public override e2dPreset Clone()
	{
		e2dCurveMidpointPreset e2dCurveMidpointPreset = new e2dCurveMidpointPreset();
		e2dCurveMidpointPreset.Copy(this);
		return e2dCurveMidpointPreset;
	}

	public float frequencyPerUnit;

	public float roughness;

	public bool usePeaks;
}
