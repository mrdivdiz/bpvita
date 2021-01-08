public struct LocalizationReloaded : EventManager.Event
{
	public LocalizationReloaded(string currentLanguage)
	{
		this.currentLanguage = currentLanguage;
	}

	public string currentLanguage;
}
