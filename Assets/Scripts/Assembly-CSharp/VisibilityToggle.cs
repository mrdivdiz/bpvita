using System;
using UnityEngine;

public class VisibilityToggle : MonoBehaviour
{
	private void Awake()
	{
		this.Enable(this.isEnabledAtStart);
		if (string.IsNullOrEmpty(this.gameConfigTitle) || string.IsNullOrEmpty(this.gameConfigKey) || Singleton<GameConfigurationManager>.Instance == null)
		{
			return;
		}
		if (Singleton<GameConfigurationManager>.Instance.HasData)
		{
			this.OnDataFetched();
		}
		else
		{
			GameConfigurationManager instance = Singleton<GameConfigurationManager>.Instance;
			instance.OnHasData = (Action)Delegate.Combine(instance.OnHasData, new Action(this.OnDataFetched));
		}
	}

	private void OnDestroy()
	{
		if (Singleton<GameConfigurationManager>.Instance != null)
		{
			GameConfigurationManager instance = Singleton<GameConfigurationManager>.Instance;
			instance.OnHasData = (Action)Delegate.Remove(instance.OnHasData, new Action(this.OnDataFetched));
		}
	}

	private void OnDataFetched()
	{
		this.Enable(Singleton<GameConfigurationManager>.Instance.GetValue<bool>(this.gameConfigTitle, this.gameConfigKey));
	}

	private void Enable(bool enable)
	{
		UnityEngine.Debug.LogWarning("VisibilityToggle: " + enable.ToString());
		base.gameObject.SetActive(enable);
	}

	[SerializeField]
	private string gameConfigTitle = string.Empty;

	[SerializeField]
	private string gameConfigKey = string.Empty;

	[SerializeField]
	private bool isEnabledAtStart = true;
}
