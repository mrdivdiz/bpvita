using System.Collections;
using UnityEngine;

public class UnlockSandboxSequence : MonoBehaviour
{
	private void Awake()
	{
		this.episodeSelector = CompactEpisodeSelector.Instance;
		if (this.buttonLock == null)
		{
			this.buttonLock = base.GetComponentInChildren<ButtonLock>();
		}
		SandboxLevelButton component = base.GetComponent<SandboxLevelButton>();
		if (component != null)
		{
			if (!GameProgress.GetSandboxUnlocked(component.m_sandboxIdentifier))
			{
				GameProgress.SetSandboxUnlocked(component.m_sandboxIdentifier, true);
			}
			this.buttonUnlockKey = string.Format("SandboxLevelButton_{0}", component.m_sandboxIdentifier);
			bool flag = GameProgress.GetFullVersionUnlocked() || GameProgress.GetSandboxUnlocked(component.m_sandboxIdentifier) || (component.m_sandboxIdentifier.Equals("S-F") && GameProgress.GetSandboxUnlocked("S-F"));
			if (flag)
			{
				if (GameProgress.GetButtonUnlockState(this.buttonUnlockKey) == GameProgress.ButtonUnlockState.Locked)
				{
					this.episodeSelector.StartCoroutine(this.UnlockSequence());
				}
			}
			else
			{
				GameProgress.SetButtonUnlockState(this.buttonUnlockKey, GameProgress.ButtonUnlockState.Locked);
				Transform transform = base.transform.Find("StarSet");
				if (transform != null)
				{
					transform.gameObject.SetActive(false);
				}
			}
			return;
		}
		SandboxSkullLevelButton component2 = base.GetComponent<SandboxSkullLevelButton>();
		if (component2 != null)
		{
			if (!GameProgress.GetSandboxUnlocked(component2.m_sandboxIdentifier))
			{
				GameProgress.SetSandboxUnlocked(component2.m_sandboxIdentifier, true);
			}
			this.buttonUnlockKey = string.Format("SandboxLevelButton_{0}", component2.m_sandboxIdentifier);
			bool flag2 = GameProgress.GetFullVersionUnlocked() || GameProgress.GetSandboxUnlocked(component2.m_sandboxIdentifier);
			if (flag2)
			{
				if (GameProgress.GetButtonUnlockState(this.buttonUnlockKey) == GameProgress.ButtonUnlockState.Locked)
				{
					this.episodeSelector.StartCoroutine(this.UnlockSequence());
				}
				else
				{
					GameProgress.SetButtonUnlockState(this.buttonUnlockKey, GameProgress.ButtonUnlockState.Locked);
					Transform transform2 = base.transform.Find("StarSet");
					if (transform2 != null)
					{
						transform2.gameObject.SetActive(false);
					}
				}
			}
		}
	}

	private IEnumerator UnlockSequence()
	{
		while (!this.episodeSelector.IsRotated)
		{
			yield return null;
		}
		if (base.GetComponent<EpisodeButton>())
		{
			this.episodeSelector.MoveToTarget(base.transform);
		}
		else
		{
			this.episodeSelector.MoveToTarget(base.transform.parent);
		}
		yield return new WaitForSeconds(0.5f);
		while (!this.episodeSelector.IsRotated)
		{
			yield return null;
		}
		GameProgress.UnlockButton(this.buttonUnlockKey);
		if (this.buttonLock != null)
		{
			this.buttonLock.NotifyUnlocked();
		}
		yield break;
	}

	public CompactEpisodeSelector episodeSelector;

	private SandboxSkullLevelButton sandboxSkullLevelButton;

	private ButtonLock buttonLock;

	private string buttonUnlockKey = string.Empty;
}
