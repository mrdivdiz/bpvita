using UnityEngine;

public class ShopOpener : MonoBehaviour
{
	public void OpenShop()
	{
		if (Loader.isLoadingLevel || Singleton<BuildCustomizationLoader>.Instance.IsOdyssey)
		{
			return;
		}
		this.toggledGameObject.SetActive(false);
		Singleton<IapManager>.Instance.OpenShopPage(delegate
		{
			this.toggledGameObject.SetActive(true);
		}, null);
	}

	[SerializeField]
	private GameObject toggledGameObject;
}
