using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

public class WPFPrefs : UnityEngine.Object
{
	public static void WriteGhostPlayerData(string filename, GhostPlayer gp)
	{
		#if !UNITY_EDITOR
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(GhostPlayer));
		FileStream fileStream = new FileStream("ux0:" + Path.DirectorySeparatorChar + "data" + "/" + filename, FileMode.Create);
		xmlSerializer.Serialize(fileStream, gp);
		fileStream.Close();
		#endif
	}

	public static GhostPlayer ReadGhostPlayerData(string filename)
	{
		#if !UNITY_EDITOR
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(GhostPlayer));
		GhostPlayer result = new GhostPlayer();
		try
		{
			FileStream fileStream = new FileStream("ux0:" + Path.DirectorySeparatorChar + "data" + "/" + filename, FileMode.Open);
			result = (xmlSerializer.Deserialize(fileStream) as GhostPlayer);
			fileStream.Close();
		}
		catch
		{
		}
		return result;
		#else
		GhostPlayer result = new GhostPlayer();
		return result;
		#endif
	}

	public static string ContraptionFileName(string levelName)
	{
		byte[] value = CryptoUtility.ComputeHash(Encoding.UTF8.GetBytes(levelName));
		return BitConverter.ToString(value).Substring(0, 30).Replace("-", string.Empty) + ".contraption";
	}

	public static void SaveContraptionDataset(string levelName, ContraptionDataset cds)
	{
		#if !UNITY_EDITOR
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(ContraptionDataset));
		MemoryStream memoryStream = new MemoryStream();
		StreamWriter textWriter = new StreamWriter(memoryStream, Encoding.UTF8);
		xmlSerializer.Serialize(textWriter, cds);
		byte[] clearTextBytes = memoryStream.ToArray();
		memoryStream.Close();
		byte[] array = WPFPrefs.m_crypto.Encrypt(clearTextBytes);
		string str = WPFPrefs.ContraptionFileName(levelName);
		//string text = "ux0:" + Path.DirectorySeparatorChar + "data" + "/contraptions";
		//Directory.CreateDirectory(text);
		FileStream fileStream = new FileStream("ux0:" + Path.DirectorySeparatorChar + "data" + "/" + str, FileMode.Create);
		fileStream.Write(array, 0, array.Length);
		fileStream.Close();
		#endif
	}

	public static void SaveLevelBluePrint(string levelName, ContraptionDataset cds, bool isSuperBlueprint = false, int superBluePrintIndex = 0)
	{
		#if !UNITY_EDITOR
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(ContraptionDataset));
		MemoryStream memoryStream = new MemoryStream();
		StreamWriter textWriter = new StreamWriter(memoryStream, Encoding.UTF8);
		xmlSerializer.Serialize(textWriter, cds);
		byte[] array = memoryStream.ToArray();
		memoryStream.Close();
		string path = (!isSuperBlueprint) ? "Data/Contraptions" : "Data/SuperContraptions";
		string path2 = levelName + "_contraption" + ((!isSuperBlueprint) ? string.Empty : string.Format("_{0:00}", superBluePrintIndex + 1)) + ".xml";
		//string path3 = Path.Combine(Application.dataPath, path);
		//string path4 = Path.Combine(path, path2);
		FileStream fileStream = new FileStream("ux0:" + Path.DirectorySeparatorChar + "data" + path2, FileMode.Create);
		fileStream.Write(array, 0, array.Length);
		fileStream.Close();
		#endif
	}

	public static ContraptionDataset LoadContraptionDataset(string levelName)
	{
		#if !UNITY_EDITOR
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(ContraptionDataset));
		ContraptionDataset result = new ContraptionDataset();
		string str = WPFPrefs.ContraptionFileName(levelName);
		string str2 = "ux0:" + Path.DirectorySeparatorChar + "data";
		if (!File.Exists(str2 + "/" + str))
		{
			return new ContraptionDataset();
		}
		try
		{
			FileStream fileStream = new FileStream(str2 + "/" + str, FileMode.Open);
			byte[] array = new byte[fileStream.Length];
			fileStream.Read(array, 0, array.Length);
			byte[] buffer = WPFPrefs.m_crypto.Decrypt(array, 0);
			MemoryStream stream = new MemoryStream(buffer);
			result = (xmlSerializer.Deserialize(stream) as ContraptionDataset);
			fileStream.Close();
		}
		catch
		{
		}
		return result;
		#else
		ContraptionDataset result = new ContraptionDataset();
		return result;
		#endif
	}

	public static ContraptionDataset LoadContraptionDataset(TextAsset textAsset)
	{
		#if !UNITY_EDITOR
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(ContraptionDataset));
		ContraptionDataset result = new ContraptionDataset();
		try
		{
			MemoryStream memoryStream = new MemoryStream(textAsset.bytes);
			result = (xmlSerializer.Deserialize(memoryStream) as ContraptionDataset);
			memoryStream.Close();
		}
		catch
		{
		}
		//ContraptionDataset result = new ContraptionDataset();
		return result;
		#else
		ContraptionDataset result = new ContraptionDataset();
		return result;
		#endif
	}

	private static CryptoUtility m_crypto = new CryptoUtility("3b91A049Ca7HvSjhxT35");
}
