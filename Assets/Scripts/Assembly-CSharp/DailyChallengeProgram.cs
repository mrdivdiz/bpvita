using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class DailyChallengeProgram
{
	public DailyChallengeProgram()
	{
		this.specialDays = new Dictionary<DateTime, LootCrateType[]>();
		this.defaultProgram = new Dictionary<DayOfWeek, LootCrateType[]>();
		this.specialDaysJson = new SecureJsonManager("specialdays");
		this.defaultProgramJson = new SecureJsonManager("defaultdailyprogram");
		this.specialDaysJson.Initialize(new Action<string>(this.OnSpecialDaysLoaded));
		this.defaultProgramJson.Initialize(new Action<string>(this.OnDefaultProgramLoaded));
	}

	public bool Initialized
	{
		get
		{
			return this.specialDaysInitialized && this.defaultProgramInitialized;
		}
	}

	private void OnSpecialDaysLoaded(string data)
	{
		this.specialDaysInitialized = this.LoadSpecialDays(data);
	}

	private void OnDefaultProgramLoaded(string data)
	{
		this.defaultProgramInitialized = this.LoadDefaultProgram(data);
	}

	private bool LoadSpecialDays(string rawData)
	{
		if (string.IsNullOrEmpty(rawData))
		{
			return true;
		}
		Hashtable hashtable;
		if (this.DecodeJson(rawData, out hashtable))
		{
			this.specialDays = new Dictionary<DateTime, LootCrateType[]>();
			IEnumerator enumerator = hashtable.Keys.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					DateTime key = new DateTime(long.Parse(obj as string));
					ArrayList arrayList = hashtable[obj] as ArrayList;
					LootCrateType[] array = new LootCrateType[arrayList.Count];
					for (int i = 0; i < arrayList.Count; i++)
					{
						array[i] = (LootCrateType)Convert.ChangeType(arrayList[i], typeof(int));
					}
					this.specialDays.Add(key, array);
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
			return true;
		}
		return false;
	}

	private bool LoadDefaultProgram(string rawData)
	{
		Hashtable hashtable;
		if (this.DecodeJson(rawData, out hashtable))
		{
			this.defaultProgram = new Dictionary<DayOfWeek, LootCrateType[]>();
			IEnumerator enumerator = hashtable.Keys.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					DayOfWeek key = (DayOfWeek)int.Parse(obj as string);
					ArrayList arrayList = hashtable[obj] as ArrayList;
					LootCrateType[] array = new LootCrateType[arrayList.Count];
					for (int i = 0; i < arrayList.Count; i++)
					{
						array[i] = (LootCrateType)Convert.ChangeType(arrayList[i], typeof(int));
					}
					this.defaultProgram.Add(key, array);
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
			return true;
		}
		return false;
	}

	private bool DecodeJson(string rawData, out Hashtable data)
	{
		bool result;
		try
		{
			data = (MiniJSON.jsonDecode(rawData) as Hashtable);
			result = true;
		}
		catch
		{
			data = null;
			result = false;
		}
		return result;
	}

	private bool LoadData(string path, out Hashtable data)
	{
		if (!File.Exists(path))
		{
			data = null;
			return false;
		}
		StreamReader streamReader = null;
		bool result;
		try
		{
			streamReader = new StreamReader(path);
			string json = streamReader.ReadToEnd();
			data = (MiniJSON.jsonDecode(json) as Hashtable);
			result = true;
		}
		catch
		{
			data = null;
			result = false;
		}
		finally
		{
			if (streamReader != null)
			{
				streamReader.Dispose();
			}
		}
		return result;
	}

	public LootCrateType GetLootCrateType(DateTime date, int index)
	{
		if (this.specialDays.ContainsKey(date) && index >= 0 && index < this.specialDays[date].Length)
		{
			return this.specialDays[date][index];
		}
		if (this.defaultProgram.ContainsKey(date.DayOfWeek) && index >= 0 && index < this.defaultProgram[date.DayOfWeek].Length)
		{
			return this.defaultProgram[date.DayOfWeek][index];
		}
		return LootCrateType.Wood;
	}

	private const string SPECIAL_DAYS_JSON = "specialdays.json";

	private const string DEFAULT_PROGRAM_JSON = "defaultdailyprogram.json";

	private SecureJsonManager specialDaysJson;

	private SecureJsonManager defaultProgramJson;

	private Dictionary<DateTime, LootCrateType[]> specialDays;

	private Dictionary<DayOfWeek, LootCrateType[]> defaultProgram;

	private bool specialDaysInitialized;

	private bool defaultProgramInitialized;
}
