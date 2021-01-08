using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bundle : MonoBehaviour
{
    private void Awake()
    {
        if (Bundle.instance == null)
        {
            Bundle.instance = this;
            EventManager.Connect(new EventManager.OnEvent<LoadLevelEvent>(this.OnLoadLevelEvent));
            Bundle.checkingBundles = true;
            if (SceneManager.GetActiveScene().name.Equals("SplashScreen"))
            {
                base.StartCoroutine(this.CheckAssetBundles());
            }
            else
            {
                base.StartCoroutine(this.DelayAssetChecking());
            }
            UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
            return;
        }
        UnityEngine.Object.Destroy(this);
    }

    private IEnumerator DelayAssetChecking()
    {
        while (!SceneManager.GetActiveScene().name.Equals("SplashScreen"))
        {
            yield return null;
        }
        yield return null;
        base.StartCoroutine(this.CheckAssetBundles());
        yield break;
    }

    private void OnDestroy()
    {
        if (this != Bundle.instance)
        {
            return;
        }
        if (Bundle.bundleObjects != null)
        {
            foreach (KeyValuePair<string, BundleObject> keyValuePair in Bundle.bundleObjects)
            {
                Bundle.bundleObjects[keyValuePair.Key].UnloadBundle(true);
            }
        }
        EventManager.Disconnect(new EventManager.OnEvent<LoadLevelEvent>(this.OnLoadLevelEvent));
        Bundle.bundleObjects = null;
        Bundle.initialized = false;
    }

    public static void UnloadAssetBundle(string bundleId, bool unloadAllLoadedObjects)
    {
        if (Bundle.bundleObjects == null)
        {
            return;
        }
        BundleObject bundleObject;
        if (Bundle.bundleObjects.TryGetValue(bundleId, out bundleObject) && bundleObject.IsAssetBundleInMemory)
        {
            bundleObject.UnloadBundle(unloadAllLoadedObjects);
        }
    }

    private IEnumerator CheckAssetBundles(bool offlineMode = false)
    {
        if (this.checkAssetBundleCount == 0)
        {
            Bundle.bundleObjects = new Dictionary<string, BundleObject>();
        }
        Bundle.initialized = false;
        this.checkAssetBundleCount++;
        for (int i = 0; i < this.assetBundles.Count; i++)
        {
            string bundleId = this.assetBundles[i].assetBundleId;
            BundleObject bo;
            if (Bundle.bundleObjects.ContainsKey(bundleId))
            {
                bo = Bundle.bundleObjects[bundleId];
            }
            else
            {
                bo = new BundleObject(bundleId, "unity3d", this.assetBundles[i].loadAtStart, string.Empty);
            }
            string path = Path.Combine(UnityEngine.Application.streamingAssetsPath, "AssetBundles/" + bo.BundleFileName);
            bo.SetBundleLocation(path);
            if (!Bundle.bundleObjects.ContainsKey(bundleId))
            {
                Bundle.bundleObjects.Add(bundleId, bo);
            }
        }
        foreach (KeyValuePair<string, BundleObject> keyValuePair2 in Bundle.bundleObjects)
        {
            if (keyValuePair2.Value.LoadAtStart)
            {
                string bundleId = keyValuePair2.Key;
                base.StartCoroutine(this.LoadAssetBundle(bundleId, delegate
                {
                    this.BundleLoaded(bundleId);
                }));
            }
        }
        Bundle.checkingBundles = false;
        yield break;
    }

    private IEnumerator LoadAssetBundle(string bundleId, Action onFinish)
    {
        if (Bundle.bundleObjects == null || !Bundle.bundleObjects.ContainsKey(bundleId))
        {
            yield break;
        }
        BundleObject bo = Bundle.bundleObjects[bundleId];
        if (bo.IsAssetBundleInMemory)
        {
            if (onFinish != null)
            {
                onFinish();
            }
            yield break;
        }
        string path = bo.BundleLocation;
        if (!string.IsNullOrEmpty(path))
        {
            AssetBundleCreateRequest request = AssetBundle.LoadFromFileAsync(path);
            yield return request;
            AssetBundle assetBundle = request.assetBundle;
            if (assetBundle != null)
            {
                assetBundle.name = bo.BundleId;
                bo.SetLoadedBundle(assetBundle);
                if (onFinish != null)
                {
                    onFinish();
                }
            }
        }
        yield break;
    }

    public static void LoadBundleAsync(string bundleId, Action onFinish = null)
    {
        if (Bundle.IsBundleLoaded(bundleId))
        {
            return;
        }
        Bundle.instance.StartCoroutine(Bundle.instance.LoadAssetBundle(bundleId, onFinish));
    }

    public static bool IsBundleLoaded(string bundleId)
    {
        return Bundle.bundleObjects != null && Bundle.bundleObjects.ContainsKey(bundleId) && Bundle.bundleObjects[bundleId].IsAssetBundleInMemory;
    }

    public static bool HasBundle(string bundleId)
    {
        return Bundle.bundleObjects != null && Bundle.bundleObjects.ContainsKey(bundleId) && !string.IsNullOrEmpty(Bundle.bundleObjects[bundleId].BundleLocation);
    }

    public static string GetAssetBundleID(int episodeIndex)
    {
        switch (episodeIndex)
        {
            default:
                return Bundle.instance.assetBundles[0].assetBundleId;
            case 1:
                return Bundle.instance.assetBundles[2].assetBundleId;
            case 2:
                return Bundle.instance.assetBundles[3].assetBundleId;
            case 3:
                return Bundle.instance.assetBundles[1].assetBundleId;
            case 4:
                return Bundle.instance.assetBundles[4].assetBundleId;
            case 5:
                return Bundle.instance.assetBundles[5].assetBundleId;
        }
    }

    public static T LoadObject<T>(string bundleId, string objectName) where T : UnityEngine.Object
    {
        if (string.IsNullOrEmpty(objectName))
        {
            return default(T);
        }
        if (Bundle.bundleObjects == null)
        {
            return default(T);
        }
        if (!Bundle.bundleObjects.ContainsKey(bundleId))
        {
            return default(T);
        }
        if (!Bundle.bundleObjects[bundleId].IsAssetBundleInMemory)
        {
            return default(T);
        }
        try
        {
            return (T)Bundle.bundleObjects[bundleId].LoadedAssetBundle.LoadAsset(objectName, typeof(T));
        }
        catch
        {
            return default(T);
        }
    }

    public static T LoadObject<T>(string objectName) where T : UnityEngine.Object
    {
        if (string.IsNullOrEmpty(objectName))
        {
            return default(T);
        }
        T t = default(T);
        foreach (KeyValuePair<string, BundleObject> keyValuePair in Bundle.bundleObjects)
        {
            t = Bundle.LoadObject<T>(keyValuePair.Key, objectName);
            if (!EqualityComparer<T>.Default.Equals(t, default(T)))
            {
                break;
            }
        }
        return t;
    }

    private void BundleLoaded(string bundleId)
    {
        int num = 0;
        int num2 = 0;
        foreach (KeyValuePair<string, BundleObject> keyValuePair in Bundle.bundleObjects)
        {
            if (keyValuePair.Value.LoadAtStart)
            {
                num++;
            }
            if (keyValuePair.Value.IsAssetBundleInMemory)
            {
                num2++;
            }
        }
        if (num == num2)
        {
            Bundle.initialized = true;
            if (Bundle.AssetBundlesLoaded != null)
            {
                Bundle.AssetBundlesLoaded();
            }
        }
    }

    private void OnLoadLevelEvent(LoadLevelEvent data)
    {
        string levelName = data.levelName;
        if (!string.IsNullOrEmpty(levelName) && (levelName == "MainMenu" || levelName == "EpisodeSelection"))
        {
            for (int i = 0; i < this.assetBundles.Count; i++)
            {
                if (this.assetBundles[i].assetBundleId.StartsWith("Episode"))
                {
                    Bundle.UnloadAssetBundle(this.assetBundles[i].assetBundleId, true);
                }
            }
        }
    }

    public static Action AssetBundlesLoaded;

    public static Action AssetBundleLoadFailed;

    private static Bundle instance;

    private static Dictionary<string, BundleObject> bundleObjects;

    private int checkAssetBundleCount;

    public static bool checkingBundles;

    public static bool initialized;

    public List<LoadObject> assetBundles;

    public GameObject exitConfirmation;

    public class BundleObject
    {
        public BundleObject(string newBundleId, string newBundleFileExtension, bool newLoadAtStart, string newBundleLocation = "")
        {
            this.bundleLocation = newBundleLocation;
            this.bundleId = newBundleId;
            this.bundleFileExtension = newBundleFileExtension;
            this.loadAtStart = newLoadAtStart;
        }

        public string BundleFileName
        {
            get
            {
                return this.bundleId + "." + this.bundleFileExtension;
            }
        }

        public string BundleId
        {
            get
            {
                return this.bundleId;
            }
        }

        public string BundleLocation
        {
            get
            {
                return this.bundleLocation;
            }
        }

        public bool LoadAtStart
        {
            get
            {
                return this.loadAtStart;
            }
        }

        public bool IsAssetBundleInMemory
        {
            get
            {
                return this.assetBundle != null;
            }
        }

        public AssetBundle LoadedAssetBundle
        {
            get
            {
                return this.assetBundle;
            }
        }

        public void SetBundleLocation(string newBundleLocation)
        {
            this.bundleLocation = newBundleLocation;
        }

        public void SetLoadedBundle(AssetBundle newAssetBundle)
        {
            this.assetBundle = newAssetBundle;
        }

        public void UnloadBundle(bool unloadAllObjects)
        {
            if (this.assetBundle == null)
            {
                return;
            }
            this.assetBundle.Unload(unloadAllObjects);
            this.assetBundle = null;
        }

        private string bundleId;

        private string bundleFileExtension;

        private string bundleLocation;

        private bool loadAtStart;

        private AssetBundle assetBundle;
    }
}
