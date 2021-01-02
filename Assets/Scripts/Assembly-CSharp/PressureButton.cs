using System.Collections;
using UnityEngine;

public class PressureButton : WPFMonoBehaviour
{
	private void OnDataLoaded()
	{
		if (!this.m_button)
		{
			this.m_button = base.transform.Find("Button").gameObject;
		}
		EventManager.Connect(new EventManager.OnEvent<GameStateChanged>(this.OnGameStateChanged));
	}

	private void OnDestroy()
	{
		EventManager.Disconnect(new EventManager.OnEvent<GameStateChanged>(this.OnGameStateChanged));
		base.StopAllCoroutines();
	}

	public void OnTriggerEnter(Collider other)
	{
		if (this.m_oneTimer && this.m_isPressed)
		{
			return;
		}
		if (other.gameObject.layer == LayerMask.NameToLayer("Contraption") || other.gameObject.tag == "Dynamic")
		{
			base.StopAllCoroutines();
			this.Pressed();
		}
	}

	public void OnTriggerStay(Collider other)
	{
		if (this.m_oneTimer && this.m_isPressed)
		{
			return;
		}
		if ((other.gameObject.layer == LayerMask.NameToLayer("Contraption") || other.gameObject.tag == "Dynamic") && !this.m_isPressed)
		{
			this.Pressed();
		}
	}

	public void OnTriggerExit(Collider other)
	{
		if ((!this.m_oneTimer && other.gameObject.layer == LayerMask.NameToLayer("Contraption")) || other.gameObject.tag == "Dynamic")
		{
			base.StartCoroutine(this.ReleaseDelayed(0.1f));
		}
	}

	private IEnumerator ReleaseDelayed(float delay)
	{
		this.m_isPressed = false;
		if (this.m_timer > 0f)
		{
			delay = this.m_timer;
		}
		yield return new WaitForSeconds(delay);
		if (!this.m_isPressed)
		{
			this.Released();
		}
		yield break;
	}

	private void Released()
	{
		if (!this.m_isPressed)
		{
			Singleton<AudioManager>.Instance.SpawnOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.pressureButtonRelease, base.transform);
		}
		if (this.m_button)
		{
			this.m_button.SetActive(true);
		}
		EventManager.Send(new PressureButtonReleased(this.m_pressureID));
		this.m_isPressed = false;
	}

	private void Pressed()
	{
		if (!this.m_isPressed)
		{
			Singleton<AudioManager>.Instance.SpawnOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.pressureButtonClick, base.transform);
		}
		this.m_isPressed = true;
		if (this.m_button)
		{
			this.m_button.SetActive(false);
		}
		EventManager.Send(new PressureButtonPressed(this.m_pressureID));
	}

	private void OnGameStateChanged(GameStateChanged newState)
	{
		if ((newState.state == LevelManager.GameState.Running && this.lastTrackedState == LevelManager.GameState.Building) || ((newState.state == LevelManager.GameState.Building || newState.state == LevelManager.GameState.ShowingUnlockedParts) && (this.lastTrackedState == LevelManager.GameState.Running || this.lastTrackedState == LevelManager.GameState.PausedWhileRunning)))
		{
			this.Released();
		}
		this.lastTrackedState = newState.state;
	}

	[SerializeField]
	private int m_pressureID;

	[SerializeField]
	private float m_timer;

	[SerializeField]
	private bool m_oneTimer;

	[SerializeField]
	private GameObject m_button;

	private bool m_isPressed;

	private LevelManager.GameState lastTrackedState;
}
