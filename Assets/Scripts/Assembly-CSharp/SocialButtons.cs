using UnityEngine;

public class SocialButtons : SliderButton
{
	private void LoadButtonToSocialMedia(string name, string methodToInvoke)
	{
		GameObject original = (GameObject)Resources.Load("SocialButtons/" + name);
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(original);
		gameObject.transform.parent = base.gameObject.transform;
		gameObject.name = name;
		gameObject.transform.localPosition = new Vector3(0f, 0f, 3f);
		gameObject.GetComponent<Button>().MethodToCall.SetMethod(GameObject.Find("MainMenuLogic").GetComponent<MainMenu>(), methodToInvoke);
	}

	private void Awake()
	{
		if (Singleton<Localizer>.Instance.CurrentLocale == "zh-CN" || Singleton<BuildCustomizationLoader>.Instance.IsChina)
		{
			this.LoadButtonToSocialMedia("WeibosButton", "LaunchWeibos");
			this.LoadButtonToSocialMedia("FilmButton", "LaunchYoutubeFilmChina");
			this.isChina = true;
		}
		else
		{
			this.LoadButtonToSocialMedia("FacebookButton", "LaunchFacebook");
			this.LoadButtonToSocialMedia("TwitterButton", "LaunchTwitter");
			this.LoadButtonToSocialMedia("FilmButton", "LaunchYoutubeFilm");
		}
		EventManager.Connect(new EventManager.OnEvent<LocalizationReloaded>(this.ReceiveLocalizationReloaded));
	}

	private void OnDestroy()
	{
		EventManager.Disconnect(new EventManager.OnEvent<LocalizationReloaded>(this.ReceiveLocalizationReloaded));
	}

	private void ReceiveLocalizationReloaded(LocalizationReloaded localizationReloaded)
	{
		bool flag = (this.isChina && localizationReloaded.currentLanguage != "zh-CN") || (!this.isChina && localizationReloaded.currentLanguage == "zh-CN");
		if (flag)
		{
			int childCount = base.transform.childCount;
			int num = childCount;
			while (--num >= 0)
			{
				Transform child = base.transform.GetChild(num);
				if (child.name.Contains("Button"))
				{
					UnityEngine.Object.DestroyImmediate(child.gameObject);
				}
			}
			if (Singleton<Localizer>.Instance.CurrentLocale == "zh-CN" || Singleton<BuildCustomizationLoader>.Instance.IsChina)
			{
				this.LoadButtonToSocialMedia("WeibosButton", "LaunchWeibos");
				this.LoadButtonToSocialMedia("FilmButton", "LaunchYoutubeFilmChina");
				this.isChina = true;
			}
			else
			{
				this.LoadButtonToSocialMedia("FacebookButton", "LaunchFacebook");
				this.LoadButtonToSocialMedia("TwitterButton", "LaunchTwitter");
				this.LoadButtonToSocialMedia("FilmButton", "LaunchYoutubeFilm");
				this.isChina = false;
			}
			base.SetInitialValues();
			GameObject.Find("MainMenuLogic").GetComponent<MainMenu>().SocialButtonReset();
		}
	}

	private bool isChina;
}
