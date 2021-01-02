using UnityEngine;

public class VisibilityMultiCondition : MonoBehaviour
{
	private void Awake()
	{
		if (!Singleton<VisibilityConditionManager>.IsInstantiated())
		{
			return;
		}
		this.lastStates = new bool[this.conditions.Length];
		this.m_renderer = base.gameObject.GetComponent<Renderer>();
		this.m_collider = base.gameObject.GetComponent<Collider>();
		this.m_transform = base.gameObject.transform;
		for (int i = 0; i < this.conditions.Length; i++)
		{
			Singleton<VisibilityConditionManager>.Instance.SubscribeToConditionChange(new VisibilityConditionManager.ConditionChange(this.OnConditionChange), this.conditions[i].condition);
		}
		this.UpdateState(true);
	}

	private void OnDestroy()
	{
		if (!Singleton<VisibilityConditionManager>.IsInstantiated())
		{
			return;
		}
		for (int i = 0; i < this.conditions.Length; i++)
		{
			Singleton<VisibilityConditionManager>.Instance.UnsubscribeToConditionChange(new VisibilityConditionManager.ConditionChange(this.OnConditionChange), this.conditions[i].condition);
		}
	}

	private void UpdateState(bool force = false)
	{
		bool flag = true;
		for (int i = 0; i < this.lastStates.Length; i++)
		{
			if (!this.lastStates[i])
			{
				flag = false;
				break;
			}
		}
		if (flag != this.lastState || force)
		{
			this.lastState = flag;
			this.SetEnabled(flag);
		}
	}

	private void OnConditionChange(VisibilityCondition.Condition condition, bool state)
	{
		int num;
		if (this.GetConditionIndex(condition, out num))
		{
			this.lastStates[num] = ((!this.conditions[num].not) ? state : (!state));
			this.UpdateState(false);
		}
	}

	private bool GetConditionIndex(VisibilityCondition.Condition condition, out int index)
	{
		index = 0;
		for (int i = 0; i < this.conditions.Length; i++)
		{
			if (this.conditions[i].condition == condition)
			{
				index = i;
				return true;
			}
		}
		return false;
	}

	private void SetEnabled(bool enabled)
	{
		bool flag = false;
		if (this.m_renderer && this.m_renderer.enabled != enabled)
		{
			flag = true;
			this.m_renderer.enabled = enabled;
		}
		if (this.m_collider && this.m_collider.enabled != enabled)
		{
			flag = true;
			this.m_collider.enabled = enabled;
		}
		if (flag || !this.m_renderer)
		{
			int childCount = this.m_transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				Transform child = this.m_transform.GetChild(i);
				Renderer component = child.GetComponent<Renderer>();
				if (component && component.enabled != enabled)
				{
					component.enabled = enabled;
				}
			}
		}
		if (this.disableGameObject)
		{
			base.gameObject.SetActive(enabled);
		}
	}

	[SerializeField]
	private VisibilityCondition.ConditionStruct[] conditions;

	[SerializeField]
	private bool disableGameObject;

	private bool[] lastStates;

	private bool lastState;

	private Renderer m_renderer;

	private Collider m_collider;

	private Transform m_transform;
}
