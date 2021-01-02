using System;

namespace PlayFab.PlayStreamModels
{
	[Serializable]
	public class PlayerLocation
	{
		public string City;

		public ContinentCode ContinentCode;

		public CountryCode CountryCode;

		public double? Latitude;

		public double? Longitude;
	}
}
