using UnityEngine;

public class DeviceInfo
{
	public static bool UsesTouchInput
	{
		get
		{
			RuntimePlatform runtimePlatform = Application.platform;
			return runtimePlatform == RuntimePlatform.IPhonePlayer || runtimePlatform == RuntimePlatform.Android;
		}
	}

	public static DeviceFamily ActiveDeviceFamily
	{
		get
		{
			return DeviceInfo.DeviceFamily.Android;
		}
	}

	public static bool IsDesktop
	{
		get
		{
			RuntimePlatform runtimePlatform = Application.platform;
			return runtimePlatform == RuntimePlatform.OSXEditor || runtimePlatform == RuntimePlatform.OSXPlayer || runtimePlatform == RuntimePlatform.WindowsPlayer || runtimePlatform == RuntimePlatform.WindowsEditor;
		}
	}

	public enum DeviceFamily
	{
		Ios,
		Android,
		Pc,
		Osx,
		BB10,
		WP8
	}
}
