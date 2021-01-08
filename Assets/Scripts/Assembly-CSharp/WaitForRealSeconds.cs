using UnityEngine;

public class WaitForRealSeconds : CustomYieldInstruction
{
	public WaitForRealSeconds(float time)
	{
		this.endTime = Time.realtimeSinceStartup + time;
	}

	public override bool keepWaiting
	{
		get
		{
			return Time.realtimeSinceStartup < this.endTime;
		}
	}

	private float endTime;
}
