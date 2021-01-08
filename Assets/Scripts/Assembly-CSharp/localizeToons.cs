using UnityEngine;

public class localizeToons : MonoBehaviour
{
	private void Start()
	{
		this.localized = false;
	}

	private void OnEnable()
	{
		EventManager.Connect(new EventManager.OnEvent<LocalizationReloaded>(this.RefreshPrefabLocale));
		this.RefreshPrefabLocale(new LocalizationReloaded(Singleton<Localizer>.Instance.CurrentLocale));
	}

	private void OnDisable()
	{
		EventManager.Disconnect(new EventManager.OnEvent<LocalizationReloaded>(this.RefreshPrefabLocale));
	}

	private void updateToons(GameObject from, GameObject to, string name)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(to, from.transform.position, from.transform.rotation);
		gameObject.transform.parent = from.transform.parent;
		gameObject.transform.name = name;
		UnityEngine.Object.Destroy(from);
	}

	private void RefreshPrefabLocale(LocalizationReloaded localeChange)
	{
		MonoBehaviour.print("== Language changed: " + localeChange);
		MonoBehaviour.print("locale: " + localeChange.currentLanguage);
		string currentLanguage = localeChange.currentLanguage;
		if (currentLanguage == "zh-CN")
		{
			this.updateToons(GameObject.Find("Toons"), this.ToonsPrefab_CN, "Toons");
			this.localized = true;
		}
		else if (this.localized)
		{
			this.updateToons(GameObject.Find("Toons"), this.ToonsPrefab, "Toons");
			this.localized = false;
		}
	}

	private void Update()
	{
	}

	public GameObject ToonsPrefab_CN;

	public GameObject ToonsPrefab;

	private bool localized;
}
