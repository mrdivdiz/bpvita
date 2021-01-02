using System.Reflection;
using System.Text;
using UnityEngine;
using UnityEngine.Rendering;

namespace PlayFab
{
    public class PlayFabDataGatherer
	{
		public PlayFabDataGatherer()
		{
			this.ProductName = Application.productName;
			this.Version = Application.version;
			this.Company = Application.companyName;
			this.Platform = Application.platform;
			this.GraphicsMultiThreaded = SystemInfo.graphicsMultiThreaded;
			this.GraphicsType = SystemInfo.graphicsDeviceType;
			this.DataPath = Application.dataPath;
			this.PersistentDataPath = Application.persistentDataPath;
			this.StreamingAssetsPath = Application.streamingAssetsPath;
			this.TargetFrameRate = Application.targetFrameRate;
			this.UnityVersion = Application.unityVersion;
			this.RunInBackground = Application.runInBackground;
			this.DeviceModel = SystemInfo.deviceModel;
			this.DeviceName = SystemInfo.deviceName;
			this.DeviceType = SystemInfo.deviceType;
            this.DeviceUniqueId = SystemInfo.deviceUniqueIdentifier;
			this.OperatingSystem = SystemInfo.operatingSystem;
			this.GraphicsDeviceId = SystemInfo.graphicsDeviceID;
			this.GraphicsDeviceName = SystemInfo.graphicsDeviceName;
			this.GraphicsMemorySize = SystemInfo.graphicsMemorySize;
			this.GraphicsShaderLevel = SystemInfo.graphicsShaderLevel;
			this.SystemMemorySize = SystemInfo.systemMemorySize;
			this.ProcessorCount = SystemInfo.processorCount;
			this.ProcessorType = SystemInfo.processorType;
			this.SupportsAccelerometer = SystemInfo.supportsAccelerometer;
			this.SupportsGyroscope = SystemInfo.supportsGyroscope;
			this.SupportsLocationService = SystemInfo.supportsLocationService;
		}

		public string GenerateReport()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Logging System Info: ========================================\n");
			foreach (FieldInfo fieldInfo in base.GetType().GetFields())
			{
				string arg = fieldInfo.GetValue(this).ToString();
				stringBuilder.AppendFormat("System Info - {0}: {1}\n", fieldInfo.Name, arg);
			}
			return stringBuilder.ToString();
		}

		public string ProductName;

		public string ProductBundle;

		public string Version;

		public string Company;

		public RuntimePlatform Platform;

		public bool GraphicsMultiThreaded;

		public GraphicsDeviceType GraphicsType;

		public string DataPath;

		public string PersistentDataPath;

		public string StreamingAssetsPath;

		public int TargetFrameRate;

		public string UnityVersion;

		public bool RunInBackground;

		public string DeviceModel;

		public string DeviceName;

		public DeviceType DeviceType;

		public string DeviceUniqueId;

		public string OperatingSystem;

		public int GraphicsDeviceId;

		public string GraphicsDeviceName;

		public int GraphicsMemorySize;

		public int GraphicsShaderLevel;

		public int SystemMemorySize;

		public int ProcessorCount;

		public int ProcessorFrequency;

		public string ProcessorType;

		public bool SupportsAccelerometer;

		public bool SupportsGyroscope;

		public bool SupportsLocationService;
	}
}
