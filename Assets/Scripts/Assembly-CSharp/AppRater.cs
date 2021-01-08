using System.Collections;
using UnityEngine;

public class AppRater : Singleton<AppRater>
{
	private void Awake()
	{
		base.SetAsPersistant();
		if (!GameProgress.GetBool("AppRaterDisabled", false, GameProgress.Location.Local, null))
		{
			int num = GameProgress.GetInt("AppRaterInterval", 0, GameProgress.Location.Local, null);
			num++;
			if (num >= 15)
			{
				base.StartCoroutine(this.ShowRatingPrompt());
				GameProgress.SetInt("AppRaterInterval", 0, GameProgress.Location.Local);
			}
			else
			{
				GameProgress.SetInt("AppRaterInterval", num, GameProgress.Location.Local);
			}
		}
	}

	public void OnButtonPressed(string index)
	{
		if (index == "1")
		{
			Singleton<URLManager>.Instance.OpenURL(URLManager.LinkType.AppRaterLink);
		}
		GameProgress.SetBool("AppRaterDisabled", true, GameProgress.Location.Local);
	}

	private IEnumerator ShowRatingPrompt()
	{
		yield return new WaitForSeconds(1f);
		Localizer.LocaleParameters ratingTextTitle = Singleton<Localizer>.Instance.Resolve("ITEM_RATE_US_TITLE", null);
		Localizer.LocaleParameters ratingTextMsg = Singleton<Localizer>.Instance.Resolve("ITEM_RATE_US_PROMPT", null);
		Localizer.LocaleParameters ratingTextYes = Singleton<Localizer>.Instance.Resolve("ITEM_RATE_US_SELECT_YES", null);
		Localizer.LocaleParameters ratingTextNo = Singleton<Localizer>.Instance.Resolve("ITEM_RATE_US_SELECT_NO", null);
		yield break;
	}
}
