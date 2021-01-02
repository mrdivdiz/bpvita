using System;
using System.Collections;
using System.Collections.Generic;

public class ConfigData
{
	public ConfigData(string configId)
	{
		this.configId = configId;
		this.keys = new List<string>();
		this.values = new List<string>();
	}

	public ConfigData(string configId, Hashtable data)
	{
		this.configId = configId;
		this.keys = new List<string>();
		this.values = new List<string>();
		IDictionaryEnumerator enumerator = data.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				this.keys.Add((string)dictionaryEntry.Key);
				this.values.Add((string)dictionaryEntry.Value);
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
	}

	public string ConfigID
	{
		get
		{
			return this.configId;
		}
		set
		{
			this.configId = value;
		}
	}

	public int Count
	{
		get
		{
			return this.keys.Count;
		}
	}

	public string[] Keys
	{
		get
		{
			return this.keys.ToArray();
		}
	}

	public string[] Values
	{
		get
		{
			return this.values.ToArray();
		}
	}

	public string this[string key]
	{
		get
		{
			if (this.keys.Contains(key))
			{
				return this.values[this.keys.IndexOf(key)];
			}
			throw new KeyNotFoundException("Key not found");
		}
		set
		{
			if (this.keys.Contains(key))
			{
				this.values[this.keys.IndexOf(key)] = value;
				return;
			}
			throw new KeyNotFoundException("Key not found");
		}
	}

	public bool HasKey(string key)
	{
		return this.keys != null && this.keys.Contains(key);
	}

	public void AddValue(string key, string value)
	{
		if (this.keys.Contains(key))
		{
			throw new ArgumentException("Key already exists");
		}
		this.keys.Add(key);
		this.values.Add(value);
	}

	public void RemoveValue(string key)
	{
		if (!this.keys.Contains(key))
		{
			throw new KeyNotFoundException("Key not found");
		}
		int index = this.keys.IndexOf(key);
		this.keys.RemoveAt(index);
		this.values.RemoveAt(index);
	}

	public void ReplaceKey(string oldKey, string newKey)
	{
		if (this.keys.Contains(oldKey))
		{
			this.keys[this.keys.IndexOf(oldKey)] = newKey;
		}
	}

	public Hashtable ToHashtable()
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < this.keys.Count; i++)
		{
			hashtable.Add(this.keys[i], this.values[i]);
		}
		return hashtable;
	}

	private string configId;

	private List<string> keys;

	private List<string> values;
}
