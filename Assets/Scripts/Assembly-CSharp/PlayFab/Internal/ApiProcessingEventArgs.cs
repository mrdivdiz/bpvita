using PlayFab.SharedModels;

namespace PlayFab.Internal
{
    public class ApiProcessingEventArgs
	{
		public TRequest GetRequest<TRequest>() where TRequest : PlayFabRequestCommon
		{
			return this.Request as TRequest;
		}

		public string ApiEndpoint;

		public ApiProcessingEventType EventType;

		public PlayFabRequestCommon Request;

		public PlayFabResultCommon Result;
	}
}
