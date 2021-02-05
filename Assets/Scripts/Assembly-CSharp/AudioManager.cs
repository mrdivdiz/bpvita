using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public static event OnAudioMuted onAudioMuted;

    public bool AudioMuted
    {
        get
        {
            return this.audioMuted;
        }
    }

    public bool Paused
    {
        get
        {
            return this.m_paused;
        }
    }

    public List<AudioSource> GetActiveLoopingSounds()
    {
        return this.activeLoopingSounds;
    }

    public List<AudioSource> GetActive3dOneShotSounds()
    {
        return this.active3dOneShotSounds;
    }

    public List<AudioSource> GetActive2dOneShotSounds()
    {
        return this.active2dOneShotSounds;
    }

    private void OnApplicationPause(bool pause)
    {
        this.m_applicationPaused = pause;
    }

    public void Play2dEffect(AudioClip effectClip)
    {
        if (!this.AudioMuted)
        {
            AudioSource.PlayClipAtPoint(effectClip, Vector3.zero);
        }
    }

    public AudioSource Play2dEffect(AudioSource effectSource)
    {
        return this.Spawn2dOneShotEffect(effectSource);
    }

    public AudioSource SpawnOneShotEffect(AudioSource[] effectSources, Vector3 soundPosition)
    {
        if (this.CheckRepeatLimit(ref effectSources[0]))
        {
            int num = UnityEngine.Random.Range(0, effectSources.Length);
            return this.SpawnOneShotEffect(effectSources[num], soundPosition);
        }
        return null;
    }

    public AudioSource SpawnOneShotEffect(AudioSource[] effectSources, Transform sourceParent)
    {
        if (this.CheckRepeatLimit(ref effectSources[0]))
        {
            int num = UnityEngine.Random.Range(0, effectSources.Length);
            return this.SpawnOneShotEffect(effectSources[num], sourceParent);
        }
        return null;
    }

    public void PlayLoopingEffect(ref AudioSource effectSource)
    {
        this.StartLoopingEffect(effectSource, null);
    }

    public AudioSource Spawn2dOneShotEffect(AudioSource effectSource)
    {
        if (base.gameObject.activeInHierarchy && !this.AudioMuted && this.active2dOneShotSounds.Count < 20)
        {
            AudioSource audioSource = UnityEngine.Object.Instantiate<AudioSource>(effectSource);
            audioSource.gameObject.name = "AudioOneShot -" + effectSource.name;
            audioSource.gameObject.transform.parent = base.transform;
            audioSource.Play();
            this.active2dOneShotSounds.Add(audioSource);
            base.StartCoroutine(this.Destroy2dOneShotEffect(audioSource));
            return audioSource;
        }
        return null;
    }

    public AudioSource SpawnOneShotEffect(AudioSource effectSource, Vector3 soundPosition)
    {
        if (base.gameObject.activeInHierarchy && this.active3dOneShotSounds.Count < 20)
        {
            AudioSource audioSource = UnityEngine.Object.Instantiate<AudioSource>(effectSource);
            audioSource.mute = this.AudioMuted;
            audioSource.transform.position = soundPosition;
            audioSource.gameObject.name = "AudioOneShot -" + effectSource.name;
            audioSource.gameObject.transform.parent = base.transform;
            audioSource.Play();
            this.active3dOneShotSounds.Add(audioSource);
            base.StartCoroutine(this.Destroy3dOneShotEffect(audioSource));
            return audioSource;
        }
        return null;
    }

    public AudioSource SpawnOneShotEffect(AudioSource effectSource, Transform sourceParent)
    {
        if (base.gameObject.activeInHierarchy && this.active3dOneShotSounds.Count < 20 && effectSource != null)
        {
            AudioSource audioSource = UnityEngine.Object.Instantiate<AudioSource>(effectSource);
            audioSource.mute = this.AudioMuted;
            audioSource.transform.parent = sourceParent;
            audioSource.transform.localPosition = Vector3.zero;
            audioSource.gameObject.name = "AudioOneShot -" + effectSource.name;
            audioSource.Play();
            this.active3dOneShotSounds.Add(audioSource);
            base.StartCoroutine(this.Destroy3dOneShotEffect(audioSource));
            return audioSource;
        }
        return null;
    }

    private IEnumerator Destroy2dOneShotEffect(AudioSource audioSource)
    {
        yield return new WaitForSeconds(5.0f);
        if (audioSource != null)
        {
            this.active2dOneShotSounds.Remove(audioSource);
            UnityEngine.Object.Destroy(audioSource.gameObject);
        }
        yield break;
    }

    private IEnumerator Destroy3dOneShotEffect(AudioSource audioSource)
    {
        yield return new WaitForSeconds(5.0f);
        if (audioSource != null)
        {
            this.active3dOneShotSounds.Remove(audioSource);
            UnityEngine.Object.Destroy(audioSource.gameObject);
        }
        yield break;
    }

    public GameObject SpawnLoopingEffect(AudioSource effectSource, Transform soundHost)
    {/*
        Transform transform = soundHost.Find("LoopingSound-" + effectSource.GetComponent<AudioSource>().clip.name);
        AudioSource audioSource;
        if (transform == null)
        {
            audioSource = UnityEngine.Object.Instantiate<AudioSource>(effectSource);
        }
        else
        {
            audioSource = transform.GetComponent<AudioSource>();
        }
        audioSource.gameObject.name = "LoopingSound-" + audioSource.GetComponent<AudioSource>().clip.name;
        this.StartLoopingEffect(audioSource, soundHost);
        return audioSource.gameObject;
    */return effectSource.gameObject;
	}

    public void StopLoopingEffect(AudioSource loopingEffect)
    {
        if (loopingEffect && loopingEffect.isPlaying)
        {
            this.activeLoopingSounds.Remove(loopingEffect);
            AudioVolumeFader component = loopingEffect.gameObject.GetComponent<AudioVolumeFader>();
            if (component && base.gameObject.activeInHierarchy)
            {
                float delay = component.FadeOut();
                base.StartCoroutine(this.DelayedStop(loopingEffect, delay));
            }
            else
            {
                loopingEffect.Stop();
            }
        }
    }

    public GameObject SpawnCombinedLoopingEffect(AudioSource effectSource, Transform soundHost)
    {
        CombinedLoopingEffect combinedLoopingEffect;
        if (!this.m_combinedLoops.TryGetValue(effectSource, out combinedLoopingEffect))
        {
            combinedLoopingEffect = new CombinedLoopingEffect(effectSource);
            this.m_combinedLoops[effectSource] = combinedLoopingEffect;
            this.m_combinedLoopValues = this.m_combinedLoops.Values.GetEnumerator();
        }
        return combinedLoopingEffect.AddLoop(soundHost);
    }

    public void RemoveCombinedLoopingEffect(AudioSource prefab, GameObject loopingEffect)
    {
        CombinedLoopingEffect combinedLoopingEffect;
        if (this.m_combinedLoops.TryGetValue(prefab, out combinedLoopingEffect))
        {
            combinedLoopingEffect.RemoveLoop(loopingEffect);
        }
    }

    private IEnumerator DelayedStop(AudioSource stoppingSource, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (stoppingSource != null)
        {
            stoppingSource.Stop();
        }
        yield break;
    }

    public void RemoveLoopingEffect(ref GameObject loopingEffect)
    {
        if (loopingEffect && loopingEffect.GetComponent<AudioSource>())
        {
            loopingEffect.GetComponent<AudioSource>().Stop();
            this.activeLoopingSounds.Remove(loopingEffect.GetComponent<AudioSource>());
            loopingEffect = null;
        }
    }

    public void MuteSounds(List<AudioSource> sounds, bool mute)
    {
        foreach (AudioSource audioSource in sounds)
        {
            if (audioSource)
            {
                audioSource.mute = mute;
            }
        }
    }

    public void PauseSounds(List<AudioSource> sounds, bool pause)
    {
        foreach (AudioSource audioSource in sounds)
        {
            if (audioSource)
            {
                if (pause && audioSource.isPlaying)
                {
                    audioSource.Pause();
                }
                else if (!pause && !audioSource.isPlaying && audioSource.gameObject.activeInHierarchy && audioSource.enabled)
                {
                    audioSource.Play();
                }
            }
        }
    }

    public void AbortSounds(List<AudioSource> sounds, bool pause)
    {
        if (pause)
        {
            foreach (AudioSource audioSource in sounds)
            {
                if (audioSource)
                {
                    audioSource.mute = true;
                    audioSource.Stop();
                }
            }
        }
    }

    public GameObject SpawnMusic(AudioSource musicPrefab)
    {
        GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(musicPrefab.gameObject);
        gameObject.GetComponent<AudioSource>().mute = this.audioMuted;
        UnityEngine.Object.DontDestroyOnLoad(gameObject);
        this.m_activeMusic.Add(gameObject.GetComponent<AudioSource>());
        return gameObject;
    }

    public void RemoveMusic(GameObject music)
    {
        if (music.GetComponent<AudioSource>().isPlaying)
        {
            music.GetComponent<AudioSource>().Stop();
        }
        this.m_activeMusic.Remove(music.GetComponent<AudioSource>());
        UnityEngine.Object.DestroyImmediate(music);
    }

    private void Awake()
    {
        base.SetAsPersistant();
        this.m_combinedLoopValues = this.m_combinedLoops.Values.GetEnumerator();
        this.LoadAudioParams();
        EventManager.Connect(new EventManager.OnEvent<GameTimePaused>(this.ReceiveGameTimePaused));
        EventManager.Connect(new EventManager.OnEvent<LevelLoadedEvent>(this.OnLevelLoaded));
    }

    private void OnDestroy()
    {
        EventManager.Disconnect(new EventManager.OnEvent<GameTimePaused>(this.ReceiveGameTimePaused));
        EventManager.Disconnect(new EventManager.OnEvent<LevelLoadedEvent>(this.OnLevelLoaded));
    }

    private void OnEnable()
    {
        KeyListener.keyPressed += this.HandleKeyListenerkeyPressed;
    }

    private void OnDisable()
    {
        KeyListener.keyPressed -= this.HandleKeyListenerkeyPressed;
    }

    private void OnLevelLoaded(LevelLoadedEvent e)
    {
        this.AbortSounds(this.active2dOneShotSounds, true);
        this.AbortSounds(this.active3dOneShotSounds, true);
    }

    private void HandleKeyListenerkeyPressed(KeyCode obj)
    {
        if (obj == KeyCode.S)
        {
            this.ToggleMute();
        }
    }

    private void StartLoopingEffect(AudioSource loopingSource, Transform optionalSoundHost)
    {
        loopingSource.loop = true;
        if (optionalSoundHost)
        {
            loopingSource.transform.parent = optionalSoundHost;
            loopingSource.transform.localPosition = Vector3.zero;
        }
        if (loopingSource.enabled)
        {
            AudioVolumeFader component = loopingSource.gameObject.GetComponent<AudioVolumeFader>();
            if (component)
            {
                component.FadeIn();
            }
            loopingSource.Play();
        }
        loopingSource.mute = this.audioMuted;
        this.activeLoopingSounds.Add(loopingSource);
    }

    private bool CheckRepeatLimit(ref AudioClip audioClip)
    {
        int instanceID = audioClip.GetInstanceID();
        if (!this.previousPlayTimes.ContainsKey(instanceID))
        {
            this.previousPlayTimes[instanceID] = Time.realtimeSinceStartup;
            return true;
        }
        float realtimeSinceStartup = Time.realtimeSinceStartup;
        if (this.previousPlayTimes[instanceID] < realtimeSinceStartup - 0.15f)
        {
            this.previousPlayTimes[instanceID] = realtimeSinceStartup;
            return true;
        }
        return false;
    }

    private bool CheckRepeatLimit(ref AudioSource audioSource)
    {
        int instanceID = audioSource.clip.GetInstanceID();
        if (!this.previousPlayTimes.ContainsKey(instanceID))
        {
            this.previousPlayTimes[instanceID] = Time.realtimeSinceStartup;
            return true;
        }
        float realtimeSinceStartup = Time.realtimeSinceStartup;
        if (this.previousPlayTimes[instanceID] < realtimeSinceStartup - 0.15f)
        {
            this.previousPlayTimes[instanceID] = realtimeSinceStartup;
            return true;
        }
        return false;
    }

    private void LoadAudioParams()
    {
        this.audioMuted = UserSettings.GetBool("AudioMuted", false);
        if (this.audioMuted)
        {
            AudioListener.volume = 0f;
        }
        else
        {
            AudioListener.volume = 1f;
        }
    }

    private void SaveAudioParams()
    {
        UserSettings.SetBool("AudioMuted", this.audioMuted);
        UserSettings.Save();
    }

    public void ToggleMute()
    {
        this.audioMuted = !this.audioMuted;
        if (this.audioMuted)
        {
            AudioListener.volume = 0f;
        }
        else
        {
            AudioListener.volume = 1f;
        }
        this.MuteSounds(this.activeLoopingSounds, this.audioMuted);
        this.MuteSounds(this.active3dOneShotSounds, this.audioMuted);
        this.MuteSounds(this.m_activeMusic, this.audioMuted);
        this.SaveAudioParams();
        if (AudioManager.onAudioMuted != null)
        {
            AudioManager.onAudioMuted(this.audioMuted);
        }
    }

    private void ReceiveGameTimePaused(GameTimePaused data)
    {
        this.m_paused = data.paused;
        this.PauseSounds(this.activeLoopingSounds, data.paused);
        this.PauseSounds(this.m_activeMusic, data.paused);
        this.PauseSounds(this.active3dOneShotSounds, data.paused);
        this.AbortSounds(this.active2dOneShotSounds, data.paused);
    }

    private void Update()
    {
        if (this.m_applicationPaused)
        {
            return;
        }
        this.m_counter++;
        if (this.m_counter > 10)
        {
            this.m_counter = 0;
        }
        if (this.m_counter == 1)
        {
            for (int i = 0; i < this.activeLoopingSounds.Count; i++)
            {
                if (!this.activeLoopingSounds[i])
                {
                    this.activeLoopingSounds.RemoveAt(i);
                    break;
                }
            }
        }
        if (this.m_counter == 2)
        {
            for (int j = 0; j < this.active3dOneShotSounds.Count; j++)
            {
                if (!this.active3dOneShotSounds[j])
                {
                    this.active3dOneShotSounds.RemoveAt(j);
                    break;
                }
            }
        }
        if (this.m_counter == 3)
        {
            for (int k = 0; k < this.active2dOneShotSounds.Count; k++)
            {
                if (!this.active2dOneShotSounds[k])
                {
                    this.active2dOneShotSounds.RemoveAt(k);
                    break;
                }
            }
        }
        this.m_combinedLoopValues.Reset();
        while (this.m_combinedLoopValues.MoveNext())
        {
            this.m_combinedLoopValues.Current.Update();
        }
    }

    private bool audioMuted;

    private Dictionary<int, float> previousPlayTimes = new Dictionary<int, float>();

    private List<AudioSource> activeLoopingSounds = new List<AudioSource>();

    private List<AudioSource> active3dOneShotSounds = new List<AudioSource>();

    private List<AudioSource> active2dOneShotSounds = new List<AudioSource>();

    private Dictionary<AudioSource, CombinedLoopingEffect> m_combinedLoops = new Dictionary<AudioSource, CombinedLoopingEffect>();

    private IEnumerator<CombinedLoopingEffect> m_combinedLoopValues;

    private List<AudioSource> m_activeMusic = new List<AudioSource>();

    private int m_counter;

    private bool m_paused;

    private const string AudioMuteKey = "AudioMuted";

    private const float AudioClipRepeatLimit = 0.15f;

    private bool m_applicationPaused;

    public delegate void OnAudioMuted(bool muted);

    public enum AudioMaterial
    {
        None,
        Wood,
        Metal
    }

    private class CombinedLoopingEffect
    {
        public CombinedLoopingEffect(AudioSource prefab)
        {
            this.prefab = prefab;
        }

        public GameObject AddLoop(Transform soundHost)
        {
            GameObject gameObject = Singleton<AudioManager>.Instance.SpawnLoopingEffect(this.prefab, soundHost);
            gameObject.GetComponent<AudioSource>().Stop();
            gameObject.GetComponent<AudioSource>().enabled = false;
            this.sources.Add(gameObject);
            this.Update();
            return gameObject;
        }

        public void RemoveLoop(GameObject effect)
        {
            this.sources.Remove(effect);
            Singleton<AudioManager>.Instance.RemoveLoopingEffect(ref effect);
            this.Update();
        }

        public void Update()
        {
            GameObject gameObject = null;
            float num = 10000f;
            GameObject gameObject2 = GameObject.FindGameObjectWithTag("MainCamera");
            if (gameObject2 == null)
            {
                return;
            }
            Vector3 position = gameObject2.transform.position;
            bool flag = false;
            for (int i = 0; i < this.sources.Count; i++)
            {
                GameObject gameObject3 = this.sources[i];
                if (gameObject3)
                {
                    float num2 = Vector3.Distance(gameObject3.transform.position, position) / (0.25f + gameObject3.GetComponent<AudioSource>().volume);
                    if (num2 < num)
                    {
                        num = num2;
                        gameObject = gameObject3;
                    }
                }
                else
                {
                    flag = true;
                }
            }
            if (this.activeSound)
            {
                float num3 = 0f;
                if (gameObject)
                {
                    for (int j = 0; j < this.sources.Count; j++)
                    {
                        GameObject gameObject4 = this.sources[j];
                        if (gameObject4 != null && gameObject4 != gameObject)
                        {
                            num3 += 0.7f * gameObject4.GetComponent<AudioSource>().volume * (4f / (4f + Vector3.Distance(gameObject.transform.position, gameObject4.transform.position)));
                        }
                    }
                    float max = Mathf.Min(1.75f * this.prefab.GetComponent<AudioSource>().volume, 1f);
                    this.activeSound.GetComponent<AudioSource>().volume = Mathf.Clamp(gameObject.GetComponent<AudioSource>().volume + num3, 0f, max);
                }
            }
            if (!gameObject)
            {
                if (this.activeSound)
                {
                    Singleton<AudioManager>.Instance.StopLoopingEffect(this.activeSound.GetComponent<AudioSource>());
                }
            }
            else if (!this.activeSound)
            {
                this.activeSound = UnityEngine.Object.Instantiate<AudioSource>(this.prefab).gameObject;
                this.activeSound.gameObject.name = "LoopingSoundCombined-" + this.prefab.GetComponent<AudioSource>().clip.name;
                NoiseLevel component = this.activeSound.GetComponent<NoiseLevel>();
                if (component)
                {
                    UnityEngine.Object.Destroy(component);
                }
                Singleton<AudioManager>.Instance.StartLoopingEffect(this.activeSound.GetComponent<AudioSource>(), gameObject.transform.parent);
            }
            else if (!this.activeSound.GetComponent<AudioSource>().isPlaying && !Singleton<AudioManager>.Instance.Paused && this.activeSound.activeInHierarchy && this.activeSound.GetComponent<AudioSource>().enabled)
            {
                Singleton<AudioManager>.Instance.StartLoopingEffect(this.activeSound.GetComponent<AudioSource>(), gameObject.transform.parent);
            }
            if (gameObject && this.activeSound && this.activeSound.transform.parent != gameObject.transform.parent)
            {
                this.activeSound.transform.parent = gameObject.transform.parent;
                this.activeSound.transform.localPosition = Vector3.zero;
            }
            if (flag)
            {
                for (int k = 0; k < this.sources.Count; k++)
                {
                    if (!this.sources[k])
                    {
                        this.sources.RemoveAt(k);
                        break;
                    }
                }
            }
        }

        public AudioSource prefab;

        public List<GameObject> sources = new List<GameObject>();

        public GameObject activeSound;
    }
}
