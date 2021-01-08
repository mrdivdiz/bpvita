using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(this);
		EventManager.Connect(new EventManager.OnEvent<LoadLevelEvent>(this.ReceiveLoadingLevelEvent));
		EventManager.Connect(new EventManager.OnEvent<GameStateChanged>(this.ReceiveGameStateChanged));
		this.m_globalMusicVolume = UserSettings.GetFloat("MusicVolume", 1f);
	}

	private void StartMusic(AudioSource music, float delay, float fadeInTime, MusicStartOption option = MusicManager.MusicStartOption.StartFromBeginning)
	{
		this.m_requestedMusic.Clear();
		this.m_requestedMusic.Add(new MusicChange(Time.time + delay, music, fadeInTime, option));
	}

	private void Update()
	{
		for (int i = 0; i < this.m_requestedMusic.Count; i++)
		{
			if (Time.time >= this.m_requestedMusic[i].time)
			{
				this.StartMusic(this.m_requestedMusic[i]);
				this.m_requestedMusic.RemoveAt(i);
				break;
			}
		}
		if (this.m_fadingOutMusic && this.m_music)
		{
			float num = this.m_music.GetComponent<AudioSource>().volume;
			num -= Time.deltaTime * this.m_fadeOutSpeed;
			num = Mathf.Clamp(num, 0f, 1f);
			this.m_music.GetComponent<AudioSource>().volume = num;
			if (num == 0f)
			{
				this.m_fadingOutMusic = false;
				this.StopMusic();
			}
		}
	}

	private void StartMusic(MusicChange data)
	{
		this.m_fadingOutMusic = false;
		if (this.m_music != null && this.m_musicPrefab != data.music.gameObject)
		{
			this.StopMusic();
		}
		if (this.m_music == null)
		{
			this.m_music = Singleton<AudioManager>.Instance.SpawnMusic(data.music);
			this.m_musicPrefab = data.music.gameObject;
			this.m_musicPrefabInstanceID = this.m_musicPrefab.GetInstanceID();
			float time;
			if (data.option == MusicManager.MusicStartOption.StartFromPreviousPosition && this.m_musicPositions.TryGetValue(this.m_musicPrefabInstanceID, out time))
			{
				this.m_music.GetComponent<AudioSource>().time = time;
			}
			this.m_music.GetComponent<AudioSource>().volume = this.m_musicPrefab.GetComponent<AudioSource>().volume * this.m_globalMusicVolume;
			this.m_music.GetComponent<AudioSource>().Play();
		}
		else
		{
			this.m_music.GetComponent<AudioSource>().volume = this.m_musicPrefab.GetComponent<AudioSource>().volume * this.m_globalMusicVolume;
			if (!this.m_music.GetComponent<AudioSource>().isPlaying)
			{
				this.m_music.GetComponent<AudioSource>().Play();
			}
		}
	}

	private void FadeOutMusic(float time)
	{
		if (this.m_music)
		{
			this.m_fadingOutMusic = true;
			this.m_fadeOutSpeed = this.m_music.GetComponent<AudioSource>().volume / time;
		}
	}

	private void StopMusic()
	{
		if (this.m_music != null)
		{
			this.m_musicPositions[this.m_musicPrefabInstanceID] = this.m_music.GetComponent<AudioSource>().time;
			this.m_musicPositions.Remove(this.m_musicPrefabInstanceID);
			Singleton<AudioManager>.Instance.RemoveMusic(this.m_music);
			this.m_music = null;
			this.m_musicPrefab = null;
			this.m_musicPrefabInstanceID = 0;
			this.m_fadingOutMusic = false;
			Resources.UnloadUnusedAssets();
		}
	}

	private void ReceiveLoadingLevelEvent(LoadLevelEvent data)
	{
		if (data.currentGameState == GameManager.GameState.Level && data.nextGameState != GameManager.GameState.Level)
		{
			this.StopMusic();
		}
		switch (data.nextGameState)
		{
		case GameManager.GameState.MainMenu:
		{
			GameObject gameObject = this.commonAudio.MusicTheme;
			this.StartMusic(gameObject.GetComponent<AudioSource>(), 0f, 2.2f, MusicManager.MusicStartOption.StartFromBeginning);
			break;
		}
		case GameManager.GameState.EpisodeSelection:
		case GameManager.GameState.LevelSelection:
		case GameManager.GameState.SandboxLevelSelection:
		{
			GameObject gameObject = this.commonAudio.LevelSelectionMusic;
			this.StartMusic(gameObject.GetComponent<AudioSource>(), 0f, 2.2f, MusicManager.MusicStartOption.StartFromBeginning);
			break;
		}
		case GameManager.GameState.Level:
		{
			this.FadeOutMusic(0.4f);
			GameObject gameObject;
			if (Singleton<GameManager>.Instance.OverrideBuildMusic)
			{
				gameObject = Singleton<GameManager>.Instance.OverriddenBuildMusic;
			}
			else
			{
				gameObject = this.commonAudio.BuildMusic;
			}
			this.StartMusic(gameObject.GetComponent<AudioSource>(), 0.6f, 2.2f, MusicManager.MusicStartOption.StartFromBeginning);
			break;
		}
		case GameManager.GameState.Cutscene:
			this.FadeOutMusic(0.4f);
			break;
		case GameManager.GameState.StarLevelCutscene:
			this.FadeOutMusic(0.4f);
			break;
		case GameManager.GameState.KingPigFeeding:
		{
			this.FadeOutMusic(0.4f);
			GameObject gameObject;
			if (Singleton<TimeManager>.IsInstantiated() && Singleton<TimeManager>.Instance.Initialized && Singleton<TimeManager>.Instance.CurrentTime.Month == 12)
			{
				gameObject = this.commonAudio.XmasThemeSong;
			}
			else
			{
				gameObject = this.commonAudio.FeedingMusic;
			}
			this.StartMusic(gameObject.GetComponent<AudioSource>(), 0.6f, 2.2f, MusicManager.MusicStartOption.StartFromBeginning);
			break;
		}
		case GameManager.GameState.WorkShop:
			this.FadeOutMusic(0.4f);
			this.StartMusic(this.commonAudio.craftAmbience, 0.6f, 2.2f, MusicManager.MusicStartOption.StartFromBeginning);
			break;
		case GameManager.GameState.CakeRaceMenu:
		{
			this.FadeOutMusic(0.4f);
			GameObject gameObject = this.commonAudio.CakeRaceTheme;
			this.StartMusic(gameObject.GetComponent<AudioSource>(), 0.6f, 2.2f, MusicManager.MusicStartOption.StartFromBeginning);
			break;
		}
		}
	}

	private void ReceiveGameStateChanged(GameStateChanged data)
	{
		LevelManager.GameState state = data.state;
		switch (state)
		{
		case LevelManager.GameState.Running:
		{
			GameObject gameObject;
			if (Singleton<GameManager>.Instance.OverrideInFlightMusic)
			{
				gameObject = Singleton<GameManager>.Instance.OverriddenInFlightMusic;
			}
			else
			{
				gameObject = this.commonAudio.InFlightMusic;
			}
			this.StartMusic(gameObject.GetComponent<AudioSource>(), 0f, 0.2f, MusicManager.MusicStartOption.StartFromBeginning);
			break;
		}
		default:
			if (state != LevelManager.GameState.Building)
			{
				if (state == LevelManager.GameState.CakeRaceCompleted)
				{
					this.FadeOutMusic(0.5f);
				}
			}
			else
			{
				GameObject gameObject2;
				if (Singleton<GameManager>.Instance.OverrideBuildMusic)
				{
					gameObject2 = Singleton<GameManager>.Instance.OverriddenBuildMusic;
				}
				else
				{
					gameObject2 = this.commonAudio.BuildMusic;
				}
				AudioSource component = gameObject2.GetComponent<AudioSource>();
				if (this.m_musicPrefab && this.m_musicPrefab.name != gameObject2.name)
				{
					this.FadeOutMusic(0.5f);
					this.StartMusic(component, 0.7f, 0.2f, MusicManager.MusicStartOption.StartFromPreviousPosition);
				}
				else
				{
					this.StartMusic(component, 0f, 0.2f, MusicManager.MusicStartOption.StartFromPreviousPosition);
				}
			}
			break;
		case LevelManager.GameState.Completed:
			this.FadeOutMusic(0.5f);
			break;
		}
		this.CheckNativeMusicPlayer();
	}

	private void CheckNativeMusicPlayer()
	{
		bool flag = MusicManager.isNativeMusicPlaying;
		MusicManager.isNativeMusicPlaying = MusicManager.IsNativeMusicPlaying();
		if (flag != MusicManager.isNativeMusicPlaying)
		{
			this.NativeMusicStateChanged(MusicManager.isNativeMusicPlaying);
		}
	}

	private void NativeMusicStateChanged(bool isPlaying)
	{
		if (isPlaying)
		{
			this.m_globalMusicVolume = 0f;
		}
		else
		{
			this.m_globalMusicVolume = 1f;
		}
		if (this.m_music && this.m_musicPrefab)
		{
			this.m_music.GetComponent<AudioSource>().volume = this.m_musicPrefab.GetComponent<AudioSource>().volume * this.m_globalMusicVolume;
		}
	}

	private void OnApplicationPause(bool paused)
	{
		if (!paused)
		{
			this.CheckNativeMusicPlayer();
		}
	}

	private void OnApplicationFocus(bool focus)
	{
		AudioListener.pause = !focus;
		if (focus)
		{
			this.CheckNativeMusicPlayer();
		}
	}

	private static bool _IsMusicPlaying()
	{
		return false;
	}

	public static bool IsNativeMusicPlaying()
	{
		return MusicManager._IsMusicPlaying();
	}

	[SerializeField]
	private CommonAudio commonAudio;

	private List<MusicChange> m_requestedMusic = new List<MusicChange>();

	private GameObject m_music;

	private GameObject m_musicPrefab;

	private int m_musicPrefabInstanceID;

	private Dictionary<int, float> m_musicPositions = new Dictionary<int, float>();

	private float m_globalMusicVolume = 1f;

	private bool m_fadingOutMusic;

	private float m_fadeOutSpeed;

	private static bool isNativeMusicPlaying;

	public enum MusicStartOption
	{
		StartFromBeginning,
		StartFromPreviousPosition
	}

	private class MusicChange
	{
		public MusicChange(float time, AudioSource music, float fadeInTime, MusicStartOption option)
		{
			this.time = time;
			this.music = music;
			this.fadeInTime = fadeInTime;
			this.option = option;
		}

		public float time;

		public AudioSource music;

		public float fadeInTime;

		public MusicStartOption option;
	}
}
