using System;

[Serializable]
public class e2dCurveWalkPreset : e2dPreset
{
	public override void Copy(e2dPreset other)
	{
		e2dCurveWalkPreset e2dCurveWalkPreset = (e2dCurveWalkPreset)other;
		this.angleChangePerUnit = e2dCurveWalkPreset.angleChangePerUnit;
		this.frequencyPerUnit = e2dCurveWalkPreset.frequencyPerUnit;
		this.cohesionPerUnit = e2dCurveWalkPreset.cohesionPerUnit;
	}

	public override void UpdateValues(e2dTerrainGenerator generator)
	{
		generator.Walk.Copy(this);
	}

	public override e2dPreset Clone()
	{
		e2dCurveWalkPreset e2dCurveWalkPreset = new e2dCurveWalkPreset();
		e2dCurveWalkPreset.Copy(this);
		return e2dCurveWalkPreset;
	}

	public float angleChangePerUnit;

	public float frequencyPerUnit;

	public float cohesionPerUnit;
}
