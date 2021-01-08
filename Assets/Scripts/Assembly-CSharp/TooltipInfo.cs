using UnityEngine;

public class TooltipInfo : MonoBehaviour
{
	private void Awake()
	{
		if (!this.useAttachedButton)
		{
			return;
		}
		Button component = base.transform.GetComponent<Button>();
		if (component == null && base.transform.parent != null)
		{
			component = base.transform.parent.GetComponent<Button>();
		}
		if (component != null)
		{
			component.enabled = true;
			component.MethodToCall.SetMethod(this, "Show");
		}
	}

	public void Show()
	{
		if (this.tooltip == null)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(WPFMonoBehaviour.gameData.m_tooltipPrefab);
			gameObject.transform.position = base.transform.position;
			this.tooltip = gameObject.GetComponent<Tooltip>();
			this.tooltip.SetLocaleKey(this.tooltipLocaleKey);
			this.tooltip.SetTarget((!(this.tooltipTarget != null)) ? base.transform : this.tooltipTarget);
		}
	}

	[SerializeField]
	private bool useAttachedButton;

	[SerializeField]
	private string tooltipLocaleKey = "default";

	[SerializeField]
	private Transform tooltipTarget;

	private Tooltip tooltip;
}
