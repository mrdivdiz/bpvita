using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreenSequence : MonoBehaviour
{
    private IEnumerator Start()
    {
        base.StartCoroutine(this.PlaySplashSequence());
        yield return null;
        base.StartCoroutine(this.RunStartUpChecks());
        yield break;
    }

    private GameObject LoadSplash(int id)
    {
        GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.m_splashes[id].m_splash, Vector3.zero, Quaternion.identity);
        gameObject.SetActive(true);
        return gameObject;
    }

    private void ReleaseSplash(GameObject splash)
    {
        splash.SetActive(false);
        UnityEngine.Object.Destroy(splash);
    }

    private IEnumerator PlaySplashSequence()
    {
        int currentSplash = 0;
        GameObject splash = this.LoadSplash(currentSplash);
        yield return new WaitForSeconds(this.m_splashes[currentSplash].m_time);
        while (++currentSplash < this.m_splashes.Count)
        {
            GameObject nextSplash = this.LoadSplash(currentSplash);
            this.ReleaseSplash(splash);
            splash = nextSplash;
            yield return new WaitForSeconds(this.m_splashes[currentSplash].m_time);
        }
        yield break;
    }

    private IEnumerator RunStartUpChecks()
    {
		
        while (!Bundle.initialized || Bundle.checkingBundles)
        {
            yield return null;
        }
        float timeout = 15f;
        while (!Singleton<GameConfigurationManager>.Instance.HasData && timeout > 0f)
        {
            timeout -= GameTime.RealTimeDelta;
            yield return null;
        }
        this.LoadMainMenu();
        yield break;
    }

    private void LoadMainMenu()
    {
        UnityEngine.Object.Destroy(this);
        Singleton<GameManager>.Instance.LoadMainMenu(true);
    }

    public List<SplashFrame> m_splashes = new List<SplashFrame>();

    [Serializable]
    public class SplashFrame
    {
        public GameObject m_splash;

        public float m_time;
    }
}
