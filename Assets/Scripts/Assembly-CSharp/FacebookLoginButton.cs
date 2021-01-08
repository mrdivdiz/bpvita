using UnityEngine;

public class FacebookLoginButton : MonoBehaviour
{
	private void Awake()
	{
		this.SetButtons(true);
	}

	private void SetButtons(bool showLogin)
	{
		this.loginButton.SetActive(showLogin);
		this.bubble.SetActive(showLogin);
		this.logoutButton.SetActive(!showLogin);
	}

	public void ButtonPressed()
	{
	}

	[SerializeField]
	private GameObject loginButton;

	[SerializeField]
	private GameObject bubble;

	[SerializeField]
	private GameObject logoutButton;

	[SerializeField]
	private GameObject hideOnOpen;

	private ConnectToFacebookDialog connectDialog;

	private TextDialog disconnectDialog;
}
