namespace PlayFab.PlayStreamModels
{
    public class PlayerReceiptValidationEventData : PlayStreamEventBase
	{
		public string Error;

		public string PaymentProvider;

		public PaymentType? PaymentType;

		public string ReceiptContent;

		public string TitleId;

		public bool Valid;
	}
}
