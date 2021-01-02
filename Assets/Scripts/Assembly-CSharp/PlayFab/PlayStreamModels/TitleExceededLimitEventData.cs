using System.Collections.Generic;

namespace PlayFab.PlayStreamModels
{
    public class TitleExceededLimitEventData : PlayStreamEventBase
	{
		public Dictionary<string, object> Details;

		public string LimitDisplayName;

		public string LimitId;

		public double LimitValue;

		public MetricUnit? Unit;

		public double Value;
	}
}
