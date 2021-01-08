using System;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class LocationModel
	{
		public string City;

		public ContinentCode? ContinentCode;

		public CountryCode? CountryCode;

		public double? Latitude;

		public double? Longitude;
	}
}
