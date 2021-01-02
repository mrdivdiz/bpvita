using System;

namespace PlayFab.PlayStreamModels
{
	public class TitleNewsUpdatedEventData : PlayStreamEventBase
	{
		public DateTime DateCreated;

		public string NewsId;

		public string NewsTitle;

		public NewsStatus? Status;
	}
}
