using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using UnityEngine;

public class SettingsData
{
	public SettingsData(string fileName, bool useEncryption, string key)
	{
		this.m_fileName = fileName;
		this.m_useEncryption = useEncryption;
		this.m_crypto = new CryptoUtility(key);
	}

	public string FileName
	{
		get
		{
			return this.m_fileName;
		}
		set
		{
			this.m_fileName = value;
		}
	}

	public bool ChangedSinceLastSave
	{
		get
		{
			return this.m_changedSinceSave;
		}
	}

	public T Get<T>(string key, T defaultValue)
	{
		object obj;
		if (this.m_data.TryGetValue(key, out obj))
		{
			return (T)((object)obj);
		}
		return defaultValue;
	}

	public void SetInt(string key, int value)
	{
		this.SetValue(key, value);
	}

	public int GetInt(string key, int defaultValue)
	{
		return this.Get(key, defaultValue);
	}

	public int AddToInt(string key, int delta, int minValue = -2147483648, int maxValue = 2147483647)
	{
		object obj;
		if (this.m_data.TryGetValue(key, out obj))
		{
			int num = Mathf.Clamp((int)obj + delta, minValue, maxValue);
			this.SetValue(key, num);
			return num;
		}
		int num2 = Mathf.Clamp(delta, minValue, maxValue);
		this.SetValue(key, num2);
		return num2;
	}

	public void SetFloat(string key, float value)
	{
		this.SetValue(key, value);
	}

	public float GetFloat(string key, float defaultValue)
	{
		return this.Get(key, defaultValue);
	}

	public void SetString(string key, string value)
	{
		this.SetValue(key, value);
	}

	public string GetString(string key, string defaultValue)
	{
		return this.Get(key, defaultValue);
	}

	public void SetBool(string key, bool value)
	{
		this.SetValue(key, value);
	}

	public bool GetBool(string key, bool defaultValue)
	{
		return this.Get(key, defaultValue);
	}

	public bool HasKey(string key)
	{
		return this.m_data.ContainsKey(key);
	}

	public void DeleteKey(string key)
	{
		this.Change(delegate
		{
			this.m_data.Remove(key);
		});
	}

	public void DeleteAll()
	{
		this.Change(delegate
		{
			this.m_data.Clear();
		});
	}

	public bool Save()
	{
		XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
		xmlWriterSettings.Indent = true;
		xmlWriterSettings.IndentChars = "  ";
		xmlWriterSettings.NewLineChars = "\r\n";
		xmlWriterSettings.NewLineHandling = NewLineHandling.Replace;
		xmlWriterSettings.Encoding = Encoding.UTF8;
		MemoryStream memoryStream = new MemoryStream();
		XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
		xmlWriter.WriteStartDocument();
		xmlWriter.WriteStartElement("data");
		foreach (KeyValuePair<string, object> keyValuePair in this.m_data)
		{
			xmlWriter.WriteStartElement(keyValuePair.Value.GetType().Name);
			xmlWriter.WriteAttributeString("key", keyValuePair.Key);
			xmlWriter.WriteAttributeString("value", keyValuePair.Value.ToString());
			xmlWriter.WriteEndElement();
		}
		xmlWriter.WriteEndElement();
		xmlWriter.WriteEndDocument();
		xmlWriter.Close();
		if (this.m_useEncryption)
		{
			byte[] array = this.m_crypto.Encrypt(memoryStream.ToArray());
			byte[] array2 = CryptoUtility.ComputeHash(array);
			return this.TransactionalFileWrite(this.m_fileName, new byte[][]
			{
				array2,
				array
			});
		}
		return this.TransactionalFileWrite(this.m_fileName, new byte[][]
		{
			memoryStream.ToArray()
		});
	}

	public void Load()
	{
		try
		{
			if (File.Exists(this.m_fileName))
			{
				this.Load(this.m_fileName);
				return;
			}
		}
		catch
		{
		}
		try
		{
			if (File.Exists(this.m_fileName + ".bak"))
			{
				this.Load(this.m_fileName + ".bak");
				return;
			}
		}
		catch
		{
		}
		try
		{
			if (File.Exists(this.m_fileName + ".bak2"))
			{
				this.Load(this.m_fileName + ".bak2");
			}
		}
		catch
		{
		}
	}

	public void BackupData()
	{
		try
		{
			if (File.Exists(this.m_fileName))
			{
				FileInfo fileInfo = new FileInfo(this.m_fileName);
				if (fileInfo.Length > 0L)
				{
					File.Copy(this.m_fileName, this.m_fileName + ".bak2", true);
				}
			}
		}
		catch
		{
		}
	}

	private void Load(string fileName)
	{
		FileStream fileStream = new FileStream(fileName, FileMode.Open);
		byte[] array = new byte[fileStream.Length];
		fileStream.Read(array, 0, array.Length);
		fileStream.Close();
		byte[] buffer;
		if (this.m_useEncryption)
		{
			if (array.Length < 20)
			{
				throw new IOException("Corrupted data file: could not read hash");
			}
			byte[] array2 = this.m_crypto.ComputeHash(array, 20, array.Length - 20);
			for (int i = 0; i < 20; i++)
			{
				if (array2[i] != array[i])
				{
					throw new IOException("Corrupted data file");
				}
			}
			buffer = this.m_crypto.Decrypt(array, 20);
		}
		else
		{
			buffer = array;
		}
		MemoryStream stream = new MemoryStream(buffer);
		this.LoadXml(stream);
	}

	public void LoadXml(Stream stream)
	{
		XDocument xdocument = XDocument.Load(stream);
		this.DeleteAll();
		foreach (XElement xelement in xdocument.Element("data").Elements())
		{
			XAttribute xattribute = xelement.Attribute("key");
			XAttribute xattribute2 = xelement.Attribute("value");
			if (xelement.Name == "Int32")
			{
				int value;
				if (int.TryParse(xattribute2.Value, out value))
				{
					this.SetInt(xattribute.Value, value);
				}
			}
			else if (xelement.Name == "Single")
			{
				float value2;
				if (float.TryParse(xattribute2.Value, out value2))
				{
					this.SetFloat(xattribute.Value, value2);
				}
			}
			else if (xelement.Name == "Boolean")
			{
				bool value3;
				if (bool.TryParse(xattribute2.Value, out value3))
				{
					this.SetBool(xattribute.Value, value3);
				}
			}
			else if (xelement.Name == "String")
			{
				this.SetString(xattribute.Value, xattribute2.Value);
			}
		}
	}

	public void Set<T>(string key, T value)
	{
		this.SetValue(key, value);
	}

	private void SetValue(string key, object value)
	{
		this.Change(delegate
		{
			this.m_data[key] = value;
		});
	}

	private void Change(Action ChangeData)
	{
		ChangeData();
		this.m_changedSinceSave = true;
	}

	private bool TransactionalFileWrite(string filename, params byte[][] args)
	{
		string text = filename + ".tmp";
		try
		{
			using (FileStream fileStream = new FileStream(text, FileMode.Create))
			{
				foreach (byte[] array in args)
				{
					fileStream.Write(array, 0, array.Length);
				}
			}
			if (File.Exists(filename))
			{
				File.Replace(text, filename, filename + ".bak");
			}
			else
			{
				File.Move(text, filename);
			}
			this.m_changedSinceSave = false;
		}
		catch
		{
			return false;
		}
		return true;
	}

	private string m_fileName;

	private bool m_useEncryption;

	private Dictionary<string, object> m_data = new Dictionary<string, object>();

	private bool m_changedSinceSave;

	private CryptoUtility m_crypto;
}
