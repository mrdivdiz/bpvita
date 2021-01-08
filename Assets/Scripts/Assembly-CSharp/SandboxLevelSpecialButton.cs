using UnityEngine;

public class SandboxLevelSpecialButton : MonoBehaviour
{
	private void Start()
	{
		if (base.transform.parent != null && base.transform.parent.parent != null)
		{
			this.m_sandboxSelector = base.transform.parent.parent.GetComponent<SandboxSelector>();
		}
		this.starSet = base.transform.Find("StarSet");
		if (this.starSet != null)
		{
			this.starSet.parent = base.transform.parent;
		}
		if (this.IsUnlocked())
		{
			this.ShowUnlocked();
		}
		else
		{
			this.ShowLocked();
		}
	}

	private void OnEnable()
	{
		IapManager.onPurchaseSucceeded += this.HandleIapManageronPurchaseSucceeded;
	}

	private void OnDisable()
	{
		IapManager.onPurchaseSucceeded -= this.HandleIapManageronPurchaseSucceeded;
	}

	private bool IsUnlocked()
	{
		return !Singleton<BuildCustomizationLoader>.Instance.IAPEnabled || Singleton<BuildCustomizationLoader>.Instance.IsOdyssey || GameProgress.GetSandboxUnlocked("S-F");
	}

	private void ShowLocked()
	{
		Button component = base.GetComponent<Button>();
		component.MethodToCall.SetMethod(this.m_sandboxSelector, "OpenIAPPopup");
	}

	private void ShowUnlocked()
	{
		Button component = base.GetComponent<Button>();
		component.MethodToCall.SetMethod(this.m_sandboxSelector.gameObject.GetComponent<SandboxSelector>(), "LoadSandboxLevel", this.m_sandboxIdentifier);
		base.transform.Find("Finger").gameObject.SetActive(false);
		string str = WPFMonoBehaviour.gameData.m_sandboxLevels.GetLevelData(this.m_sandboxIdentifier).m_starBoxCount.ToString();
		this.m_starsText.text = GameProgress.SandboxStarCount(this.m_sandboxSelector.FindLevelFile(this.m_sandboxIdentifier)).ToString() + "/" + str;
	}

	private void HandleIapManageronPurchaseSucceeded(IapManager.InAppPurchaseItemType type)
	{
		this.ShowUnlocked();
	}

	[SerializeField]
	private string m_sandboxIdentifier;

	[SerializeField]
	private SandboxSelector m_sandboxSelector;

	[SerializeField]
	private TextMesh m_starsText;

	private Transform starSet;
}
