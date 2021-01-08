using System;
using System.Collections.Generic;

public interface IAPInterface
{
	event Action<bool> readyForTransactionsEvent;

	event Action<string> purchaseSucceededEvent;

	event Action<string> purchaseFailedEvent;

	event Action<string> purchaseCancelledEvent;

	event Action transactionsRestoredEvent;

	event Action<string> transactionRestoreFailedEvent;

	event Action<List<IAPProductInfo>> productListReceivedEvent;

	event Action<string> productListRequestFailedEvent;

	event Action<IapManager.CodeRedeemError> codeRedeemFailedEvent;

	event Action<bool> codeVerificationEvent;

	event Func<string, bool> deliverItem;

	bool UserInitiatedRestore { get; }

	void init();

	void deInit();

	bool readyForTransactions();

	void purchaseProduct(string productId);

	void restoreTransactions();

	void fetchAvailableProducts(string[] requestedProductIds);

	void OnLevelWasLoaded();
}
