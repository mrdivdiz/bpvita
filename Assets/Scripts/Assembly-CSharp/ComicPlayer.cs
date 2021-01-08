using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComicPlayer : MonoBehaviour
{
    private IEnumerator Start()
    {
        for (int i = 0; i < this.m_comicStrips.Count; i++)
        {
            ComicStrip comicStrip = this.m_comicStrips[i];
            float x = comicStrip.m_strip.GetComponent<UnmanagedSprite>().Size.x;
            this.m_startPos = -10f * (float)Screen.width / (float)Screen.height + 0.5f * x + 4f * (float)Screen.width / (float)Screen.height;
            this.m_startPos_3_2 = -15f + 0.5f * x + 6f;
            comicStrip.m_strip.transform.position = new Vector3(this.m_startPos, 0f, (float)i);
            float num = 0f;
            this.m_comicStrips[i].m_strip.GetComponent<Renderer>().material.SetColor("_Color", new Color(1f, 1f, 1f, num));
            this.FadeChildren(num, this.m_comicStrips[i], false);
        }
        this.m_continueButton.SetActive(GameProgress.GetInt(Singleton<GameManager>.Instance.CurrentSceneName + "_played", 0, GameProgress.Location.Local, null) == 1);
        if (ScreenPlacement.IsAspectRatioNarrowerThan(4f, 3f))
        {
            this.m_continueButton.transform.Translate(-2.5f, 0f, 0f);
        }
        base.StartCoroutine(this.UpdateStrips());
        yield return null;
        if (this.m_soundTrack && this.m_currentStrip == 0)
        {
            Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(this.m_soundTrack);
        }
        for (int j = 0; j < this.m_currentStrip; j++)
        {
            this.m_time += this.GetComicPageTime(j);
        }
        yield break;
    }

    private float GetComicPageTime(int index)
    {
        float x = this.m_comicStrips[index].m_strip.GetComponent<UnmanagedSprite>().Size.x;
        float num = -0.15f * x;
        if (ScreenPlacement.IsAspectRatioNarrowerThan(4f, 3f))
        {
            num -= 2.5f;
        }
        float num2 = (this.m_startPos - num) / (this.m_startPos_3_2 - num);
        float num3 = num2 * this.m_comicStrips[index].m_speed;
        float num4 = Mathf.Abs(this.m_startPos - num) / num3;
        float num5 = 2f * (1f / this.m_comicStrips[index].m_fadingSpeed);
        return num4 + num5;
    }

    private IEnumerator UpdateStrips()
    {
        float alpha = 0f;
        while (this.m_currentStrip < this.m_comicStrips.Count)
        {
            float comicWidth = this.m_comicStrips[this.m_currentStrip].m_strip.GetComponent<UnmanagedSprite>().Size.x;
            float endPos = -0.15f * comicWidth;
            float speedFactor = (this.m_startPos - endPos) / (this.m_startPos_3_2 - endPos);
            if (ScreenPlacement.IsAspectRatioNarrowerThan(4f, 3f))
            {
                endPos -= 2.5f;
            }
            if (this.m_comicStrips[this.m_currentStrip].m_strip.transform.position.x <= endPos)
            {
                this.m_comicStrips[this.m_currentStrip].m_strip.transform.position = new Vector3(endPos, 0f);
                if (this.m_currentStrip < this.m_comicStrips.Count - 1)
                {
                    while (alpha > 0f)
                    {
                        alpha -= Time.deltaTime * this.m_comicStrips[this.m_currentStrip].m_fadingSpeed;
                        this.m_comicStrips[this.m_currentStrip].m_strip.GetComponent<Renderer>().material.SetColor("_Color", new Color(1f, 1f, 1f, alpha));
                        this.FadeChildren(alpha, this.m_comicStrips[this.m_currentStrip], false);
                        yield return new WaitForEndOfFrame();
                    }
                    UnityEngine.Object.Destroy(this.m_comicStrips[this.m_currentStrip].m_strip);
                }
                this.m_comicStrips[this.m_currentStrip] = null;
                this.m_currentStrip++;
            }
            else
            {
                while (alpha < 1f)
                {
                    alpha += Time.deltaTime * this.m_comicStrips[this.m_currentStrip].m_fadingSpeed;
                    this.m_comicStrips[this.m_currentStrip].m_strip.GetComponent<Renderer>().material.SetColor("_Color", new Color(1f, 1f, 1f, alpha));
                    this.FadeChildren(alpha, this.m_comicStrips[this.m_currentStrip], true);
                    yield return new WaitForEndOfFrame();
                }
                this.m_comicStrips[this.m_currentStrip].m_strip.transform.position -= Vector3.right * speedFactor * this.m_comicStrips[this.m_currentStrip].m_speed * Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
        }
        this.m_continueButton.SetActive(true);
        yield break;
    }

    private void FadeChildren(float alpha, ComicStrip currentStrip, bool activateChild)
    {
        for (int i = 0; i < currentStrip.m_strip.transform.childCount; i++)
        {
            Transform transform = currentStrip.m_strip.transform.GetChild(i);
            if (activateChild)
            {
                transform.gameObject.SetActive(true);
            }
            transform.GetComponent<Renderer>().material.SetColor("_Color", new Color(1f, 1f, 1f, alpha));
        }
    }

    private void Update()
    {
        if (GuiManager.GetPointer().up)
        {
            this.m_continueButton.SetActive(true);
        }
        this.UpdateSounds();
        this.m_time += Time.deltaTime;
    }

    private void UpdateSounds()
    {
        if (this.m_soundIndex < this.m_soundEffects.Count)
        {
            SoundEffect soundEffect = this.m_soundEffects[this.m_soundIndex];
            if (this.m_time >= soundEffect.time)
            {
                if (soundEffect.source == null)
                {
                }
                else
                {
                    AudioSource audioSource = Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(soundEffect.source);
                    if (audioSource)
                    {
                        audioSource.volume = soundEffect.volume;
                    }
                }
                this.m_soundIndex++;
            }
        }
    }

    public void Continue()
    {
        if (this.m_cutsceneType != ComicPlayer.Type.EpisodeStart && this.m_cutsceneType != ComicPlayer.Type.CakeRace && LevelInfo.CanAdUnlockNextLevel(null))
        {
            Singleton<GameManager>.Instance.LoadLevelSelection(Singleton<GameManager>.Instance.CurrentEpisode, false);
            return;
        }
        switch (this.m_cutsceneType)
        {
            case ComicPlayer.Type.EpisodeStart:
                if (GameProgress.GetInt(Singleton<GameManager>.Instance.CurrentSceneName + "_played", 0, GameProgress.Location.Local, null) == 1)
                {
                    Singleton<GameManager>.Instance.LoadLevelSelection(Singleton<GameManager>.Instance.CurrentEpisode, false);
                }
                else
                {
                    Singleton<GameManager>.Instance.LoadLevel(0);
                }
                break;
            case ComicPlayer.Type.EpisodeEnd:
                Singleton<GameManager>.Instance.LoadEpisodeSelection(false);
                break;
            case ComicPlayer.Type.EpisodeOneTime:
                Singleton<GameManager>.Instance.LoadLevel(Singleton<GameManager>.Instance.CurrentLevel);
                break;
            case ComicPlayer.Type.EpisodeContinue:
                if (Singleton<GameManager>.Instance.IsCutsceneStartedFromLevelSelection || (Singleton<BuildCustomizationLoader>.Instance.IsChina && GameProgress.GetInt("scenario_31_stars", 0, GameProgress.Location.Local, null) != 3))
                {
                    Singleton<GameManager>.Instance.LoadLevelSelection(Singleton<GameManager>.Instance.CurrentEpisode, false);
                }
                else if (LevelInfo.ValidLevelIndex(Singleton<GameManager>.Instance.CurrentEpisodeIndex, Singleton<GameManager>.Instance.NextLevel()))
                {
                    Singleton<GameManager>.Instance.LoadNextLevelAfterCutScene();
                }
                else
                {
                    Singleton<GameManager>.Instance.LoadLevelSelection(Singleton<GameManager>.Instance.CurrentEpisode, false);
                }
                break;
            case ComicPlayer.Type.DailyChallenge:
                Singleton<GameManager>.Instance.LoadEpisodeSelection(false);
                break;
            case ComicPlayer.Type.CakeRace:
                Singleton<GameManager>.Instance.LoadCakeRaceMenu(false);
                break;
        }
        GameProgress.SetInt(Singleton<GameManager>.Instance.CurrentSceneName + "_played", 1, GameProgress.Location.Local);
    }

    public void CrossPromoLink()
    {
        Singleton<URLManager>.Instance.OpenURL(URLManager.LinkType.MajorLazerMusic);
    }

    public void ShowConfirmationPopup()
    {
        if (Singleton<BuildCustomizationLoader>.Instance.IsChina)
        {
            return;
        }
        this.m_crossPromoConfirmationPopup.SetActive(true);
        this.SendStandardFlurryEvent("Music Promo dialog opened", "Music Promo Dialog Opened");
    }

    public void DismissConfirmationPopup()
    {
        this.m_crossPromoConfirmationPopup.SetActive(false);
        this.SendStandardFlurryEvent("Music Promo dialog closed", "Music Promo Dialog Closed");
    }

    public void SendStandardFlurryEvent(string eventName, string id)
    {
    }

    public AudioSource m_soundTrack;

    public GameObject m_continueButton;

    private float m_startPos_3_2;

    private float m_startPos;

    private int m_soundIndex;

    private float m_time;

    public int m_ContinueToLevelIndex;

    public bool m_muteDefaultMusic;

    public List<ComicStrip> m_comicStrips = new List<ComicStrip>();

    [SerializeField]
    private Type m_cutsceneType;

    [SerializeField]
    private List<SoundEffect> m_soundEffects = new List<SoundEffect>();

    private int m_currentStrip;

    public GameObject m_crossPromoConfirmationPopup;

    public enum Type
    {
        EpisodeStart,
        EpisodeEnd,
        EpisodeOneTime,
        EpisodeContinue,
        DailyChallenge,
        CakeRace
    }

    [Serializable]
    public class ComicStrip
    {
        public GameObject m_strip;

        public float m_speed = 2f;

        public float m_fadingSpeed = 1f;
    }

    [Serializable]
    public class SoundEffect
    {
        public float time;

        public AudioSource source;

        public float volume = 1f;
    }
}
