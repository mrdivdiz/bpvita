using System;
using System.Collections;
using System.Collections.Generic;

public class GameConfigurationManager : Singleton<GameConfigurationManager>
{
    public bool HasData
    {
        get
        {
            return this.hasData;
        }
    }

    private void Awake()
    {
        base.SetAsPersistant();
        this.hasData = false;
        this.secureJson = new SecureJsonManager("gameconfiguration");
        this.secureJson.Initialize(new Action<string>(this.OnDataLoaded));
    }

    private void OnDestroy()
    {
        this.secureJson = null;
        this.config = null;
    }

    private void OnDataLoaded(string rawData)
    {
        this.config = new Dictionary<string, ConfigData>();
        Hashtable hashtable = MiniJSON.jsonDecode(rawData) as Hashtable;
        IDictionaryEnumerator enumerator = hashtable.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                object obj = enumerator.Current;
                DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
                try
                {
                    this.config.Add((string)dictionaryEntry.Key, new ConfigData((string)dictionaryEntry.Key, (Hashtable)dictionaryEntry.Value));
                }
                catch
                {
                }
            }
        }
        finally
        {
            IDisposable disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
        this.hasData = true;
        if (this.OnHasData != null)
        {
            this.OnHasData();
        }
    }

    public Hashtable GetValues(string itemKey)
    {
        if (this.config != null && this.config.ContainsKey(itemKey))
        {
            return this.config[itemKey].ToHashtable();
        }
        return null;
    }

    public T GetValue<T>(string itemKey, string valueKey)
    {
        if (this.config != null && this.config.ContainsKey(itemKey) && this.config[itemKey].HasKey(valueKey))
        {
            Type typeFromHandle = typeof(T);
            string text = this.config[itemKey][valueKey];
            if (typeFromHandle == typeof(int))
            {
                int num;
                if (int.TryParse(text, out num))
                {
                    return (T)((object)Convert.ChangeType(num, typeof(T)));
                }
            }
            else if (typeFromHandle == typeof(string))
            {
                return (T)((object)Convert.ChangeType(text, typeof(T)));
            }
            else if (typeFromHandle == typeof(float))
            {
                float num2;
                if (float.TryParse(text, out num2))
                {
                    return (T)((object)Convert.ChangeType(num2, typeof(T)));
                }
            }
            else if (typeFromHandle == typeof(bool))
            {
                if (text.ToLower() == "true")
                {
                    return (T)((object)Convert.ChangeType(true, typeof(T)));
                }
                return default(T);
            }
        }
        return default(T);
    }

    public ConfigData GetConfig(string itemKey)
    {
        ConfigData configData;
        if (this.config != null && this.config.TryGetValue(itemKey, out configData))
        {
            return configData;
        }
        return null;
    }

    public bool HasValue(string itemKey, string valueKey)
    {
        return this.config != null && this.config.ContainsKey(itemKey) && this.config[itemKey].HasKey(valueKey);
    }

    public bool HasConfig(string itemKey)
    {
        return this.config != null && this.config.ContainsKey(itemKey);
    }

    public Action OnHasData;

    private Dictionary<string, ConfigData> config;

    private SecureJsonManager secureJson;

    private bool hasData;
}
