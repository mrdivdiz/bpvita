using System;

[Serializable]
public class e2dCurveVoronoiPreset : e2dPreset
{
	public override void Copy(e2dPreset other)
	{
		e2dCurveVoronoiPreset e2dCurveVoronoiPreset = (e2dCurveVoronoiPreset)other;
		this.peakType = e2dCurveVoronoiPreset.peakType;
		this.frequencyPerUnit = e2dCurveVoronoiPreset.frequencyPerUnit;
		this.peakRatio = e2dCurveVoronoiPreset.peakRatio;
		this.peakWidth = e2dCurveVoronoiPreset.peakWidth;
		this.usePeaks = e2dCurveVoronoiPreset.usePeaks;
	}

	public override void UpdateValues(e2dTerrainGenerator generator)
	{
		generator.Voronoi.Copy(this);
	}

	public override e2dPreset Clone()
	{
		e2dCurveVoronoiPreset e2dCurveVoronoiPreset = new e2dCurveVoronoiPreset();
		e2dCurveVoronoiPreset.Copy(this);
		return e2dCurveVoronoiPreset;
	}

	public e2dVoronoiPeakType peakType;

	public float frequencyPerUnit;

	public float peakRatio;

	public float peakWidth;

	public bool usePeaks;
}
