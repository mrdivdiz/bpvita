using UnityEngine;

public class ConnectToFacebookDialog : TextDialog
{
	[SerializeField]
	private TextMesh[] titleLabel;
	[SerializeField]
	private TextMesh[] descLabel;
	[SerializeField]
	private TextMesh[] buttonLabel;
	[SerializeField]
	private string loginTitleKey;
	[SerializeField]
	private string loginDescKey;
	[SerializeField]
	private string loginButtonKey;
	[SerializeField]
	private string successTitleKey;
	[SerializeField]
	private string successDescKey;
	[SerializeField]
	private string successButtonKey;
	[SerializeField]
	private string errorTitleKey;
	[SerializeField]
	private string errorDescKey;
	[SerializeField]
	private string errorButtonKey;
	[SerializeField]
	private GameObject facebookCloudIcon;
	[SerializeField]
	private GameObject errorIcon;
}
