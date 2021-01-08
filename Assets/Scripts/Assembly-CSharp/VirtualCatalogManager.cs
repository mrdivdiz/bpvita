using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class VirtualCatalogManager : Singleton<VirtualCatalogManager>
{
    public static event Action onVirtualProductListParsed;

    public bool HasCatalog
    {
        get
        {
            return this.hasCatalog;
        }
    }

    private void Awake()
    {
        base.SetAsPersistant();
        this.hasCatalog = false;
        this.secureJson = new SecureJsonManager("virtualcatalog");
        this.secureJson.Initialize(new Action<string>(this.OnDataLoaded));
    }

    private void OnDataLoaded(string rawData)
    {
        this.virtualCatalogDictionary = new Dictionary<string, VirtualProductInfo>();
        Hashtable hashtable = MiniJSON.jsonDecode(rawData) as Hashtable;
        if (hashtable != null)
        {
            if (hashtable.ContainsKey("catalog"))
            {
                ArrayList arrayList = (ArrayList)hashtable["catalog"];
                IEnumerator enumerator = arrayList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        object obj = enumerator.Current;
                        Hashtable hashtable2 = (Hashtable)obj;
                        if (hashtable2.ContainsKey("productID"))
                        {
                            string key = (string)hashtable2["productID"];
                            if (!this.virtualCatalogDictionary.ContainsKey(key))
                            {
                                VirtualProductInfo value = new VirtualProductInfo(hashtable2);
                                this.virtualCatalogDictionary.Add(key, value);
                            }
                        }
                    }
                }
                finally
                {
                    IDisposable disposable;
                    if ((disposable = (enumerator as IDisposable)) != null)
                    {
                        disposable.Dispose();
                    }
                }
                this.hasCatalog = true;
                if (VirtualCatalogManager.onVirtualProductListParsed != null)
                {
                    VirtualCatalogManager.onVirtualProductListParsed();
                }
            }
        }
    }

    public int GetProductPrice(IapManager.InAppPurchaseItemType itemType)
    {
        string productIdByItem = Singleton<IapManager>.Instance.GetProductIdByItem(itemType);
        if (string.IsNullOrEmpty(productIdByItem))
        {
            return -1;
        }
        string key = productIdByItem.Substring(productIdByItem.LastIndexOf(".") + 1);
        if (this.virtualCatalogDictionary != null && this.virtualCatalogDictionary.ContainsKey(key))
        {
            return this.virtualCatalogDictionary[key].price;
        }
        return -1;
    }

    public string GetProductLocalizationKey(IapManager.InAppPurchaseItemType itemType)
    {
        string text = Singleton<IapManager>.Instance.GetProductIdByItem(itemType);
        if (string.IsNullOrEmpty(text))
        {
            return string.Empty;
        }
        text = text.Substring(text.LastIndexOf(".") + 1);
        if (this.virtualCatalogDictionary != null && this.virtualCatalogDictionary.ContainsKey(text))
        {
            return this.virtualCatalogDictionary[text].localizationKey;
        }
        return string.Empty;
    }

    public int GetProductPrice(string id)
    {
        if (this.virtualCatalogDictionary != null && this.virtualCatalogDictionary.ContainsKey(id))
        {
            return this.virtualCatalogDictionary[id].price;
        }
        return -1;
    }

    public Hashtable GetProductRewards(IapManager.InAppPurchaseItemType itemType)
    {
        string productIdByItem = Singleton<IapManager>.Instance.GetProductIdByItem(itemType);
        if (string.IsNullOrEmpty(productIdByItem))
        {
            return null;
        }
        string key = productIdByItem.Substring(productIdByItem.LastIndexOf(".") + 1);
        if (this.virtualCatalogDictionary != null && this.virtualCatalogDictionary.ContainsKey(key))
        {
            return this.virtualCatalogDictionary[key].rewards;
        }
        return null;
    }

    public int GetCustomRewardValue(string itemName, string customKey)
    {
        Hashtable productRewards = this.GetProductRewards(itemName);
        int result;
        if (productRewards != null && productRewards.ContainsKey(customKey) && int.TryParse((string)productRewards[customKey], out result))
        {
            return result;
        }
        return -1;
    }

    public int GetProductRewardCount(IapManager.InAppPurchaseItemType itemType)
    {
        Hashtable productRewards = this.GetProductRewards(itemType);
        if (productRewards == null)
        {
            return 0;
        }
        return productRewards.Count;
    }

    public IapManager.BundleItem[] GetProductRewardsAsBundleItems(IapManager.InAppPurchaseItemType itemType)
    {
        Hashtable productRewards = this.GetProductRewards(itemType);
        List<IapManager.BundleItem> list = new List<IapManager.BundleItem>();
        IDictionaryEnumerator enumerator = productRewards.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                object obj = enumerator.Current;
                DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
                if (Enum.IsDefined(typeof(IapManager.BundleItem.BundleItemType), (string)dictionaryEntry.Key))
                {
                    IapManager.BundleItem.BundleItemType type = (IapManager.BundleItem.BundleItemType)Enum.Parse(typeof(IapManager.BundleItem.BundleItemType), (string)dictionaryEntry.Key);
                    int count = int.Parse((string)dictionaryEntry.Value);
                    list.Add(new IapManager.BundleItem(type, count));
                }
            }
        }
        finally
        {
            IDisposable disposable;
            if ((disposable = (enumerator as IDisposable)) != null)
            {
                disposable.Dispose();
            }
        }
        return list.ToArray();
    }

    public Hashtable GetProductRewards(string id)
    {
        if (this.virtualCatalogDictionary != null && this.virtualCatalogDictionary.ContainsKey(id))
        {
            return this.virtualCatalogDictionary[id].rewards;
        }
        return null;
    }

    private void PrintHashtable(Hashtable hash, int indentation, ref StringBuilder contents)
    {
        IDictionaryEnumerator enumerator = hash.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                object obj = enumerator.Current;
                DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
                if (indentation > 0)
                {
                    contents.Append(' ', indentation * 3);
                }
                contents.Append(dictionaryEntry.Key.ToString() + " : ");
                if (dictionaryEntry.Value is Hashtable)
                {
                    contents.Append('\n');
                    this.PrintHashtable((Hashtable)dictionaryEntry.Value, indentation + 1, ref contents);
                }
                else if (dictionaryEntry.Value is ArrayList)
                {
                    contents.Append('\n');
                    IEnumerator enumerator2 = ((ArrayList)dictionaryEntry.Value).GetEnumerator();
                    try
                    {
                        while (enumerator2.MoveNext())
                        {
                            object obj2 = enumerator2.Current;
                            if (obj2 is Hashtable)
                            {
                                this.PrintHashtable((Hashtable)obj2, indentation + 1, ref contents);
                            }
                            contents.Append('\n');
                        }
                    }
                    finally
                    {
                        IDisposable disposable;
                        if ((disposable = (enumerator2 as IDisposable)) != null)
                        {
                            disposable.Dispose();
                        }
                    }
                }
                else
                {
                    contents.Append(dictionaryEntry.Value.ToString());
                    contents.Append('\n');
                }
            }
        }
        finally
        {
            IDisposable disposable2;
            if ((disposable2 = (enumerator as IDisposable)) != null)
            {
                disposable2.Dispose();
            }
        }
    }

    private Dictionary<string, VirtualProductInfo> virtualCatalogDictionary;

    private bool hasCatalog;

    private SecureJsonManager secureJson;
}
