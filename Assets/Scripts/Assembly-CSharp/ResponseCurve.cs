using System.Collections.Generic;
using UnityEngine;

public class ResponseCurve
{
	public void AddPoint(float x, float value)
	{
		this.data.Add(new DataPoint(x, value));
	}

	public float Get(float x)
	{
		if (this.data.Count < 2)
		{
			return 0f;
		}
        DataPoint dataPoint = this.data[0];
        DataPoint dataPoint2 = this.data[this.data.Count - 1];
		if (x < dataPoint.x)
		{
			return dataPoint.y;
		}
		if (x > dataPoint2.x)
		{
			return dataPoint2.y;
		}
		for (int i = 0; i < this.data.Count - 1; i++)
		{
			if (x >= this.data[i].x && x <= this.data[i + 1].x)
			{
				dataPoint = this.data[i];
				dataPoint2 = this.data[i + 1];
				break;
			}
		}
		return Mathf.Lerp(dataPoint.y, dataPoint2.y, (x - dataPoint.x) / (dataPoint2.x - dataPoint.x));
	}

	private List<DataPoint> data = new List<DataPoint>();

	private struct DataPoint
	{
		public DataPoint(float x, float y)
		{
			this.x = x;
			this.y = y;
		}

		public float x;

		public float y;
	}
}
