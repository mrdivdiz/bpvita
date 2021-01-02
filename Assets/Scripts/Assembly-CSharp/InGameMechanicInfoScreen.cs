using UnityEngine;

public class InGameMechanicInfoScreen : MonoBehaviour
{
	private void OnEnable()
	{
		if (WPFMonoBehaviour.levelManager != null)
		{
			this.m_SuperAutoBuildButton.GetComponent<Button>().Lock(!WPFMonoBehaviour.levelManager.SuperBluePrintsAllowed);
			this.m_SuperAutoBuildButton.transform.Find("Disabled").gameObject.SetActive(!WPFMonoBehaviour.levelManager.SuperBluePrintsAllowed);
			this.m_SuperAutoBuildButton.transform.Find("Disabled").GetComponent<Renderer>().enabled = true;
			int num = GameProgress.BluePrintCount();
			if (WPFMonoBehaviour.levelManager.SuperBluePrintsAllowed && num > 0)
			{
				GameObject gameObject = this.m_SuperAutoBuildButton.transform.Find("AmountText").gameObject;
				GameObject gameObject2 = this.m_SuperAutoBuildButton.transform.Find("AmountTextShadow").gameObject;
				if (gameObject && gameObject2)
				{
					gameObject.GetComponent<TextMesh>().text = num.ToString();
					gameObject2.GetComponent<TextMesh>().text = num.ToString();
				}
			}
		}
		Singleton<KeyListener>.Instance.GrabFocus(this);
		KeyListener.keyReleased += this.HandleKeyListenerkeyReleased;
	}

	private void Start()
	{
		if (WPFMonoBehaviour.levelManager != null && !WPFMonoBehaviour.levelManager.SuperBluePrintsAllowed)
		{
			this.m_SuperAutoBuildButton.GetComponent<ButtonPulse>().StopPulse();
			this.m_AutoBuildButton.GetComponent<ButtonPulse>().Pulse();
		}
	}

	private void OnDisable()
	{
		KeyListener.keyReleased -= this.HandleKeyListenerkeyReleased;
		Singleton<KeyListener>.Instance.ReleaseFocus(this);
	}

	private void HandleKeyListenerkeyReleased(KeyCode obj)
	{
		if (obj == KeyCode.Escape)
		{
			EventManager.Send(new UIEvent(UIEvent.Type.CloseMechanicInfo));
		}
	}

	public void CloseAndUsePremanentMechanic(UIEvent.Type eventType)
	{
		base.gameObject.SetActive(false);
		EventManager.Send(new UIEvent(eventType));
	}

	public void CloseAndUseSuperMechanic(UIEvent.Type eventType)
	{
		base.gameObject.SetActive(false);
		EventManager.Send(new UIEvent(eventType));
	}

	public GameObject m_SuperAutoBuildButton;

	public GameObject m_AutoBuildButton;
}
