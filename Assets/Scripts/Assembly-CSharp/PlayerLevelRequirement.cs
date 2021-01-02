using System;
using UnityEngine;

public class PlayerLevelRequirement : MonoBehaviour
{
	public bool IsLocked
	{
		get
		{
			return this.isLocked;
		}
	}

	public int RequiredLevel
	{
		get
		{
			return this.levelRequirement;
		}
	}

	public static int GetRequiredLevel(string requirementKey)
	{
		int result = -1;
		if (Singleton<GameConfigurationManager>.Instance.HasValue("level_requirements", requirementKey))
		{
			result = Singleton<GameConfigurationManager>.Instance.GetValue<int>("level_requirements", requirementKey);
		}
		return result;
	}

	public string GetConfigKey()
	{
		return this.levelRequirementKey;
	}

	private void OnEnable()
	{
		int requiredLevel = PlayerLevelRequirement.GetRequiredLevel(this.levelRequirementKey);
		if (requiredLevel >= 0)
		{
			this.levelRequirement = requiredLevel;
		}
		this.Lock(this.levelRequirement > Singleton<PlayerProgress>.Instance.Level);
		EventManager.Connect(new EventManager.OnEvent<PlayerProgressEvent>(this.OnPlayerProgressEvent));
	}

	private void OnDisable()
	{
		EventManager.Disconnect(new EventManager.OnEvent<PlayerProgressEvent>(this.OnPlayerProgressEvent));
	}

	private void OnPlayerProgressEvent(PlayerProgressEvent data)
	{
		this.Lock(this.levelRequirement > Singleton<PlayerProgress>.Instance.Level);
	}

	private void Lock(bool doLock)
	{
		this.isLocked = doLock;
		if (this.lockedContainer)
		{
			this.lockedContainer.SetActive(doLock);
		}
		if (this.unlockedContainer)
		{
			this.unlockedContainer.SetActive(!doLock);
		}
		if (doLock)
		{
			TextMeshHelper.UpdateTextMeshes(this.levelLabel, this.levelRequirement.ToString(), false);
		}
		if (this.OnUnlock != null)
		{
			this.OnUnlock(!doLock);
		}
	}

	public Action<bool> OnUnlock;

	[SerializeField]
	private GameObject lockedContainer;

	[SerializeField]
	private GameObject unlockedContainer;

	[SerializeField]
	private Collider lockCollider;

	[SerializeField]
	private TextMesh[] levelLabel;

	[SerializeField]
	private int levelRequirement;

	[SerializeField]
	private string levelRequirementKey = string.Empty;

	private const string CONFIG_LEVEL_REQUIREMENT_KEY = "level_requirements";

	private bool isLocked = true;
}
