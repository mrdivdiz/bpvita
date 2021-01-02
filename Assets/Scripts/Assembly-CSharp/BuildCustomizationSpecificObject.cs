public class BuildCustomizationSpecificObject : WPFMonoBehaviour
{
	private void Start()
	{
		Condition condition = this.m_condition;
		if (condition != BuildCustomizationSpecificObject.Condition.IsContentLimited)
		{
			if (condition != BuildCustomizationSpecificObject.Condition.IsContentLimitedHasFieldOfDreams)
			{
				if (condition == BuildCustomizationSpecificObject.Condition.HasLeaderboards)
				{
					this.DestroyIf(true);
				}
			}
			else
			{
				this.DestroyIf(GameProgress.GetFullVersionUnlocked() || !GameProgress.GetSandboxUnlocked("S-F"));
			}
		}
		else
		{
			this.DestroyIf(GameProgress.GetFullVersionUnlocked());
		}
	}

	private void DestroyIf(bool flag)
	{
		if (flag && !this.m_not)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	public Condition m_condition;

	public bool m_not;

	public enum Condition
	{
		IsContentLimited,
		IsContentLimitedHasFieldOfDreams,
		HasLeaderboards
	}
}
