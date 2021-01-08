using UnityEngine;

public class UserSettings : MonoBehaviour
{
	private void Awake()
	{
		UserSettings.m_data = new SettingsData(Application.persistentDataPath + "/Settings.xml", false, string.Empty);
		UserSettings.m_data.Load();
		UnityEngine.Object.DontDestroyOnLoad(this);
	}

	public static void SetInt(string key, int value)
	{
		UserSettings.m_data.SetInt(key, value);
		UserSettings.Save();
	}

	public static int GetInt(string key, int defaultValue = 0)
	{
		return UserSettings.m_data.GetInt(key, defaultValue);
	}

	public static void SetFloat(string key, float value)
	{
		UserSettings.m_data.SetFloat(key, value);
		UserSettings.Save();
	}

	public static float GetFloat(string key, float defaultValue = 0f)
	{
		return UserSettings.m_data.GetFloat(key, defaultValue);
	}

	public static void SetString(string key, string value)
	{
		UserSettings.m_data.SetString(key, value);
		UserSettings.Save();
	}

	public static string GetString(string key, string defaultValue = "")
	{
		return UserSettings.m_data.GetString(key, defaultValue);
	}

	public static void SetBool(string key, bool value)
	{
		UserSettings.m_data.SetBool(key, value);
		UserSettings.Save();
	}

	public static bool GetBool(string key, bool defaultValue = false)
	{
		return UserSettings.m_data.GetBool(key, defaultValue);
	}

	public static bool HasKey(string key)
	{
		return UserSettings.m_data.HasKey(key);
	}

	public static void DeleteKey(string key)
	{
		UserSettings.m_data.DeleteKey(key);
	}

	public static void DeleteAll()
	{
		UserSettings.m_data.DeleteAll();
	}

	public static void Save()
	{
		UserSettings.m_data.Save();
	}

	public static void Load()
	{
		UserSettings.m_data.Load();
	}

	private static SettingsData m_data;
}
