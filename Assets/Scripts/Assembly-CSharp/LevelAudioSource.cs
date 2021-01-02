using UnityEngine;

public class LevelAudioSource : MonoBehaviour
{
	private void Awake()
	{
		this.baseAudioSource = base.GetComponent<AudioSource>();
		this.baseAudioSource.playOnAwake = false;
		EventManager.Connect(new EventManager.OnEvent<GameStateChanged>(this.ReceiveGameStateChangeEvent));
	}

	private void OnDestroy()
	{
		EventManager.Disconnect(new EventManager.OnEvent<GameStateChanged>(this.ReceiveGameStateChangeEvent));
	}

	private void Start()
	{
		this.audioManager = Singleton<AudioManager>.Instance;
	}

	private void ReceiveGameStateChangeEvent(GameStateChanged newState)
	{
		if (newState.state == this.playOnGameState)
		{
			if (!this.playOnlyOnce || !this.audioPlayed)
			{
				this.audioManager.Play2dEffect(this.baseAudioSource);
				this.audioPlayed = true;
			}
		}
	}

	[SerializeField]
	private LevelManager.GameState playOnGameState = LevelManager.GameState.Running;

	[SerializeField]
	private bool playOnlyOnce;

	private AudioSource baseAudioSource;

	private AudioManager audioManager;

	private bool audioPlayed;
}
