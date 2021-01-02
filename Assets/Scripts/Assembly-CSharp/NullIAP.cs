using System;
using System.Collections.Generic;

public class NullIAP : IAPInterface
{
	public event Action<bool> readyForTransactionsEvent;

	public event Action<string> purchaseSucceededEvent;

	public event Action<string> purchaseFailedEvent;

	public event Action<string> purchaseCancelledEvent;

	public event Action transactionsRestoredEvent;

	public event Action<string> transactionRestoreFailedEvent;

	public event Action<List<IAPProductInfo>> productListReceivedEvent;

	public event Action<string> productListRequestFailedEvent;

	public event Action<IapManager.CodeRedeemError> codeRedeemFailedEvent;

	public event Action<bool> codeVerificationEvent;

	public event Func<string, bool> deliverItem;

	public void init()
	{
	}

	public void deInit()
	{
	}

	public bool readyForTransactions()
	{
		return false;
	}

	public void purchaseProduct(string productId)
	{
	}

	public void restoreTransactions()
	{
	}

	public void fetchAvailableProducts(string[] requestedProductIds)
	{
	}

	public bool UserInitiatedRestore
	{
		get
		{
			return false;
		}
	}

	public void redeemCode(string code)
	{
	}

	public void verifyCode(string code)
	{
	}

	public void getBalance(IapManager.CurrencyType currency, Action<int> response)
	{
		response(0);
	}

	public void OnLevelWasLoaded()
	{
	}
}
