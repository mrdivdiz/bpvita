using UnityEngine;

public class ContentLock : MonoBehaviour
{
	public void Activate(bool forceLimit = false)
	{
		EpisodeButton component = base.transform.parent.GetComponent<EpisodeButton>();
		int index = component.Index;
		if (LevelInfo.IsContentLimited(index, 0) || forceLimit)
		{
			this.OverrideButtonAction();
		}
		else
		{
			base.gameObject.SetActive(false);
		}
	}

	private void OverrideButtonAction()
	{
		Button component = base.transform.parent.GetComponent<Button>();
		if (component != null)
		{
			component.MethodToCall.SetMethod(base.gameObject.GetComponent<ContentLock>(), "ShowContentLimitNotification");
		}
	}

	public void ShowContentLimitNotification()
	{
		LevelInfo.DisplayContentLimitNotification();
	}
}
