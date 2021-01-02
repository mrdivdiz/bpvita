using System;
using System.Collections;
using UnityEngine;

public class SecureJsonManager
{
	public SecureJsonManager(string newFileName)
	{
		this.fileName = newFileName;
	}

	public void Initialize(Action<string> onDataLoaded)
	{
        string rawAppConfig = Resources.Load<TextAsset>("rawAppConfig").text;
        Hashtable hashtable = MiniJSON.jsonDecode(rawAppConfig) as Hashtable;
        string key = this.fileName;
        if (hashtable.ContainsKey(key))
        {
            if (onDataLoaded != null)
            {
                onDataLoaded(MiniJSON.jsonEncode(hashtable[key]));
            }
        }
    }

	protected string fileName;
}
