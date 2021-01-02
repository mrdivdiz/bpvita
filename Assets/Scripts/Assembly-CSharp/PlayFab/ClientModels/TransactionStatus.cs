namespace PlayFab.ClientModels
{
    public enum TransactionStatus
	{
		CreateCart,
		Init,
		Approved,
		Succeeded,
		FailedByProvider,
		DisputePending,
		RefundPending,
		Refunded,
		RefundFailed,
		ChargedBack,
		FailedByUber,
		FailedByPlayFab,
		Revoked,
		TradePending,
		Traded,
		Upgraded,
		StackPending,
		Stacked,
		Other,
		Failed
	}
}
