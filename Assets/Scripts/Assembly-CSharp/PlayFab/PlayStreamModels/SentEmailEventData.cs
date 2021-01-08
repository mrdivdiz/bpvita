namespace PlayFab.PlayStreamModels
{
    public class SentEmailEventData : PlayStreamEventBase
	{
		public string Body;

		public string EmailName;

		public string EmailTemplateId;

		public string EmailTemplateName;

		public EmailTemplateType? EmailTemplateType;

		public string ErrorMessage;

		public string ErrorName;

		public string Subject;

		public bool Success;

		public string TitleId;

		public string Token;
	}
}
