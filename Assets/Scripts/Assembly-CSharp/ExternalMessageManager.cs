public class ExternalMessageManager : Singleton<ExternalMessageManager>
{
	public static event ExternalAppMessageReceived onExternalAppMessageReceived;

	public void OnMessageReceived(string message)
	{
		if (ExternalMessageManager.onExternalAppMessageReceived != null)
		{
			ExternalMessageManager.onExternalAppMessageReceived(message);
		}
	}

	private void Awake()
	{
		base.SetAsPersistant();
	}

	public delegate void ExternalAppMessageReceived(string message);
}
