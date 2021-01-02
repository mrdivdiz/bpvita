using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using UnityEngine;

public class RuntimeSpriteDatabase : Singleton<RuntimeSpriteDatabase>
{
	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(this);
		Singleton<RuntimeSpriteDatabase>.instance = this;
	}

	public void SetData(List<SpriteData> data)
	{
		if (this.m_data != null)
		{
			this.m_data.Clear();
		}
		else
		{
			this.m_data = new Dictionary<string, SpriteData>();
		}
		foreach (SpriteData spriteData in data)
		{
			this.m_data[spriteData.id] = spriteData;
		}
	}

	public SpriteData Find(string id)
	{
		if (this.m_data == null)
		{
			this.Load();
		}
		SpriteData result;
		this.m_data.TryGetValue(id, out result);
		return result;
	}

	private void Load()
	{
		List<SpriteData> data = new List<SpriteData>();
		this.Load(data);
		this.SetData(data);
	}

	public void Load(List<SpriteData> data)
	{
		data.Clear();
		TextAsset textAsset = (TextAsset)Resources.Load("GUISystem/Sprites", typeof(TextAsset));
		using (MemoryStream memoryStream = new MemoryStream(textAsset.bytes, false))
		{
			using (StreamReader streamReader = new StreamReader(memoryStream, Encoding.UTF8))
			{
				string text = streamReader.ReadToEnd();
				char[] separator = new char[]
				{
					'\n'
				};
				string[] array = text.Split(separator);
				foreach (string text2 in array)
				{
					char[] separator2 = new char[]
					{
						'\t'
					};
					string[] array3 = text2.Split(separator2, StringSplitOptions.RemoveEmptyEntries);
					if (array3.Length == 14)
					{
						string name = array3[1].Substring(1, array3[1].Length - 2);
						string materialId = array3[2];
						SpriteData item = new SpriteData(array3[0], name, materialId, null, int.Parse(array3[3]), int.Parse(array3[4]), int.Parse(array3[5]), int.Parse(array3[6]), int.Parse(array3[7]), int.Parse(array3[8]), int.Parse(array3[9]), int.Parse(array3[10]), int.Parse(array3[11]), int.Parse(array3[12]), int.Parse(array3[13]), 0, string.Empty, default(Rect));
						data.Add(item);
					}
					else if (array3.Length == 15)
					{
						string name2 = array3[1].Substring(1, array3[1].Length - 2);
						string materialId2 = array3[2];
						SpriteData item2 = new SpriteData(array3[0], name2, materialId2, null, int.Parse(array3[3]), int.Parse(array3[4]), int.Parse(array3[5]), int.Parse(array3[6]), int.Parse(array3[7]), int.Parse(array3[8]), int.Parse(array3[9]), int.Parse(array3[10]), int.Parse(array3[11]), int.Parse(array3[12]), int.Parse(array3[13]), int.Parse(array3[14]), string.Empty, default(Rect));
						data.Add(item2);
					}
				}
			}
		}
		textAsset = (TextAsset)Resources.Load("GUISystem/SpriteMapping", typeof(TextAsset));
		using (MemoryStream memoryStream2 = new MemoryStream(textAsset.bytes, false))
		{
			using (StreamReader streamReader2 = new StreamReader(memoryStream2, Encoding.UTF8))
			{
				string text3 = streamReader2.ReadToEnd();
				char[] separator3 = new char[]
				{
					'\n'
				};
				char[] separator4 = new char[]
				{
					'\t'
				};
				foreach (string text4 in text3.Split(separator3, StringSplitOptions.RemoveEmptyEntries))
				{
					string[] array5 = text4.Split(separator4, StringSplitOptions.RemoveEmptyEntries);
					if (array5.Length == 5)
					{
						string b = array5[0];
						float x = float.Parse(array5[1], CultureInfo.InvariantCulture);
						float y = float.Parse(array5[2], CultureInfo.InvariantCulture);
						float width = float.Parse(array5[3], CultureInfo.InvariantCulture);
						float height = float.Parse(array5[4], CultureInfo.InvariantCulture);
						Rect uv = new Rect(x, y, width, height);
						for (int k = 0; k < data.Count; k++)
						{
							if (data[k].id == b)
							{
								data[k].uv = uv;
								break;
							}
						}
					}
				}
			}
		}
	}

	private Dictionary<string, SpriteData> m_data;
}
