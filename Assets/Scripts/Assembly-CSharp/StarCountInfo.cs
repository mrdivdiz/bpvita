using UnityEngine;

public class StarCountInfo : MonoBehaviour
{
	private void OnShowButton()
	{
		if (this.label == null)
		{
			this.label = base.transform.GetComponentInChildren<TextMesh>();
		}
		this.UpdateCount();
	}

	public void UpdateCount()
	{
		if (this.label == null)
		{
			return;
		}
		int num = 0;
		if (GameProgress.Initialized)
		{
			num = GameProgress.GetAllStars();
		}
		this.label.text = string.Format("{0}", num);
	}

	private TextMesh label;
}
