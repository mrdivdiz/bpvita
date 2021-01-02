using System.Collections;
using UnityEngine;

public class ButtonLock : MonoBehaviour
{
	private void OnEnable()
	{
		if (this.isBeingUnlocked)
		{
			this.NotifyUnlocked();
		}
	}

	private void OnDisable()
	{
		this.isBeingUnlocked = base.GetComponent<Animation>().isPlaying;
	}

	private void Start()
	{
		this.UpdateState();
		this.m_started = true;
	}

	public void NotifyUnlocked()
	{
		if (this.m_started)
		{
			this.UpdateState();
		}
	}

	private void UpdateState()
	{
		GameProgress.ButtonUnlockState buttonUnlockState = GameProgress.GetButtonUnlockState(this.m_buttonId);
		if (buttonUnlockState == GameProgress.ButtonUnlockState.Unlocked)
		{
			base.gameObject.SetActive(false);
		}
		else if (buttonUnlockState == GameProgress.ButtonUnlockState.UnlockNow)
		{
			this.Unlock();
		}
		else
		{
			base.gameObject.SetActive(true);
			if (base.transform.parent.GetComponent<TooltipInfo>() == null)
			{
				base.transform.parent.GetComponent<Button>().Lock(true);
			}
		}
	}

	private void Unlock()
	{
		base.gameObject.SetActive(true);
		GameProgress.SetButtonUnlockState(this.m_buttonId, GameProgress.ButtonUnlockState.Unlocked);
		base.transform.parent.GetComponent<Button>().Lock(false);
		RaceLevelButton component = base.transform.parent.GetComponent<RaceLevelButton>();
		if (this.m_raceLevelSelector != null)
		{
			string sceneName = this.m_raceLevelSelector.m_raceLevels.GetLevelData(component.m_raceLevelIdentifier).SceneName;
			if (GameProgress.IsLevelCompleted(sceneName))
			{
				base.gameObject.SetActive(false);
				return;
			}
		}
		base.GetComponent<Animation>().Play();
		if (this.m_unlockSound)
		{
			Singleton<AudioManager>.Instance.Play2dEffect(this.m_unlockSound);
		}
		if (this.m_unlockParticles)
		{
			base.StartCoroutine(this.StartParticles(base.GetComponent<Animation>().clip.length));
		}
	}

	private IEnumerator StartParticles(float delay)
	{
		yield return new WaitForSeconds(delay);
		if (this.m_unlockParticles)
		{
			this.m_unlockParticles.Play();
		}
		yield break;
	}

	public string m_buttonId = "undefined";

	public AudioSource m_unlockSound;

	public ParticleSystem m_unlockParticles;

	private bool m_started;

	[SerializeField]
	private RaceLevelSelector m_raceLevelSelector;

	private bool isBeingUnlocked;
}
