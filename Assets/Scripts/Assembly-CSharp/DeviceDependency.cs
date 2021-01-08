using UnityEngine;

public class DeviceDependency : MonoBehaviour
{
	private void Awake()
	{
		DeviceInfo.DeviceFamily activeDeviceFamily = DeviceInfo.ActiveDeviceFamily;
		bool flag = false;
		foreach (DeviceInfo.DeviceFamily deviceFamily in this.enabledOnDevices)
		{
			if (activeDeviceFamily == deviceFamily)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			base.gameObject.SetActive(false);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	[SerializeField]
	private DeviceInfo.DeviceFamily[] enabledOnDevices;
}
