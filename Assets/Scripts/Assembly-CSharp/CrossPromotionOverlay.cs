using UnityEngine;

public class CrossPromotionOverlay : MonoBehaviour
{
	public void Start()
	{
		this.shopStartPosition = base.transform.Find("Layout/ShopButton").gameObject.transform.localPosition;
		this.spaceStartPosition = base.transform.Find("Layout/SpaceButton").gameObject.transform.localPosition;
	}

	public void Update()
	{
		if (Singleton<Localizer>.Instance.CurrentLocale == "zh-CN" || Singleton<BuildCustomizationLoader>.Instance.IsChina)
		{
			base.transform.Find("Layout/SeasonsButton").gameObject.SetActive(false);
			base.transform.Find("Layout/ShopButton").gameObject.transform.localPosition = this.shopStartPosition + Vector3.left * 3.74f;
			base.transform.Find("Layout/SpaceButton").gameObject.transform.localPosition = this.spaceStartPosition + Vector3.left * 3.74f;
		}
		else
		{
			base.transform.Find("Layout/SeasonsButton").gameObject.SetActive(true);
			base.transform.Find("Layout/ShopButton").gameObject.transform.localPosition = this.shopStartPosition;
			base.transform.Find("Layout/SpaceButton").gameObject.transform.localPosition = this.spaceStartPosition;
		}
	}

	public void DismissDialog()
	{
		base.gameObject.SetActive(false);
	}

	public void OpenUrl(URLManager.LinkType linkType)
	{
		Singleton<URLManager>.Instance.OpenURL(linkType);
	}

	public void CloseDialog()
	{
		base.GetComponent<Animation>().Play("CrossPromotionOverlayFadeOut");
	}

	private Vector3 shopStartPosition;

	private Vector3 spaceStartPosition;
}
