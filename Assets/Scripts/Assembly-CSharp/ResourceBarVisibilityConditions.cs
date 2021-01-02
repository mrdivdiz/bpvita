using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBarVisibilityConditions : MonoBehaviour
{
	private void Start()
	{
        ResourceBarItemCondition resourceBarItemCondition = this.visibilityConditions;
		resourceBarItemCondition.OnStateChangedEvent = (Action<bool>)Delegate.Combine(resourceBarItemCondition.OnStateChangedEvent, new Action<bool>(this.OnVisibilityChanged));
        ResourceBarItemCondition resourceBarItemCondition2 = this.enableConditions;
		resourceBarItemCondition2.OnStateChangedEvent = (Action<bool>)Delegate.Combine(resourceBarItemCondition2.OnStateChangedEvent, new Action<bool>(this.OnEnableChanged));
		Singleton<ComplexVisibilityManager>.Instance.Subscribe(this.visibilityConditions, ResourceBar.Instance.IsItemActive(this.item));
		Singleton<ComplexVisibilityManager>.Instance.Subscribe(this.enableConditions, ResourceBar.Instance.IsItemEnabled(this.item));
	}

	private void OnDestroy()
	{
		if (Singleton<ComplexVisibilityManager>.IsInstantiated())
		{
			Singleton<ComplexVisibilityManager>.Instance.Unsubscribe(this.visibilityConditions);
			Singleton<ComplexVisibilityManager>.Instance.Unsubscribe(this.enableConditions);
		}
	}

	private void OnVisibilityChanged(bool newState)
	{
		ResourceBar.Instance.ShowItem(this.item, newState, ResourceBar.Instance.IsItemEnabled(this.item));
	}

	private void OnEnableChanged(bool newState)
	{
		ResourceBar.Instance.ShowItem(this.item, ResourceBar.Instance.IsItemActive(this.item), newState);
	}

	private void OnHideButton(GameObject sender)
	{
		Singleton<ComplexVisibilityManager>.Instance.StateChanged(this.visibilityConditions, false);
	}

	private void OnShowButton(GameObject sender)
	{
		Singleton<ComplexVisibilityManager>.Instance.StateChanged(this.visibilityConditions, true);
	}

	private void OnEnableButton(GameObject sender)
	{
		Singleton<ComplexVisibilityManager>.Instance.StateChanged(this.enableConditions, true);
	}

	private void OnDisableButton(GameObject sender)
	{
		Singleton<ComplexVisibilityManager>.Instance.StateChanged(this.enableConditions, false);
	}

	[SerializeField]
	private ResourceBarItemCondition visibilityConditions;

	[SerializeField]
	private ResourceBarItemCondition enableConditions;

	[SerializeField]
	private ResourceBar.Item item;

	[Serializable]
	private class ResourceBarItemCondition : IComplexVisibilityObject
	{
		public List<ComplexVisibilityManager.Condition> ShowConditions
		{
			get
			{
				return this.showConditions;
			}
		}

		public List<ComplexVisibilityManager.Condition> HideConditions
		{
			get
			{
				return this.hideConditions;
			}
		}

		public void OnStateChanged(bool newState)
		{
			if (this.OnStateChangedEvent != null)
			{
				this.OnStateChangedEvent(newState);
			}
		}

		public Action<bool> OnStateChangedEvent;

		[SerializeField]
		private List<ComplexVisibilityManager.Condition> showConditions;

		[SerializeField]
		private List<ComplexVisibilityManager.Condition> hideConditions;
	}
}
