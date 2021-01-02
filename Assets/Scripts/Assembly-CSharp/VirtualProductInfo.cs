using System;
using System.Collections;

public class VirtualProductInfo
{
	public VirtualProductInfo(string newProductID, string newLocalizationKey, IapManager.CurrencyType newCurrencyType, int newPrice, Hashtable newRewards)
	{
		this.productID = newProductID;
		this.localizationKey = newLocalizationKey;
		this.currencyType = newCurrencyType;
		this.price = newPrice;
		this.rewards = newRewards;
	}

	public VirtualProductInfo(Hashtable hash)
	{
		this.productID = (string)hash["productID"];
		this.localizationKey = (string)hash["localizationKey"];
		this.price = int.Parse((string)hash["price"]);
		this.rewards = (Hashtable)hash["rewards"];
		if (Enum.IsDefined(typeof(IapManager.CurrencyType), (string)hash["currencyType"]))
		{
			this.currencyType = (IapManager.CurrencyType)Enum.Parse(typeof(IapManager.CurrencyType), (string)hash["currencyType"]);
		}
	}

	public Hashtable ToHashtable()
	{
		return new Hashtable
		{
			{
				"productID",
				this.productID
			},
			{
				"localizationKey",
				this.localizationKey
			},
			{
				"currencyType",
				this.currencyType.ToString()
			},
			{
				"price",
				this.price.ToString()
			},
			{
				"rewards",
				this.rewards
			}
		};
	}

	public override string ToString()
	{
		return string.Format(string.Concat(new string[]
		{
			"[VirtualProductInfo] ",
			this.productID,
			", ",
			this.localizationKey,
			", ",
			this.currencyType.ToString(),
			", ",
			this.price.ToString()
		}), new object[0]);
	}

	public string productID;

	public string localizationKey;

	public IapManager.CurrencyType currencyType;

	public int price;

	public Hashtable rewards;

	public enum RewardType
	{
		Magnet,
		Turbo,
		Glue,
		Nightvision,
		Blueprint
	}
}
