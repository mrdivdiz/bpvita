using System;
using UnityEngine;

public class HatchManager : Singleton<HatchManager>
{
    public static bool IsInitialized
    {
        get
        {
            return Singleton<HatchManager>.instance != null && HatchManager.m_initialized;
        }
    }

    public static bool IsLoggedIn
    {
        get
        {
            return Singleton<HatchManager>.instance != null && HatchManager.m_isLoggedIn;
        }
    }

    public static HatchPlayer CurrentPlayer { get; private set; }

    public static bool HasLoginError
    {
        get
        {
            return Singleton<HatchManager>.instance == null || HatchManager.m_hasLoginError;
        }
    }

    private void Awake()
    {
        if (Singleton<HatchManager>.IsInstantiated() || HatchManager.m_initialized)
        {
            UnityEngine.Object.Destroy(base.gameObject);
            return;
        }
        base.SetAsPersistant();
        HatchManager.m_initialized = true;
    }

    private void Start()
    {
        Singleton<NetworkManager>.Instance.CheckAccess(new NetworkManager.OnCheckResponseDelegate(this.OnNetworkAccessChecked));
    }

    private void OnNetworkAccessChecked(bool hasNetwork)
    {
        if (hasNetwork)
        {
            this.LoginAuto();
        }
        else
        {
            this.OnLoginError(HatchManager.ErrorType.NoNetwork, "No network connection");
        }
    }

    public static bool IsProductionBuild()
    {
        return Singleton<BuildCustomizationLoader>.Instance.SkynestBackend.Equals("production");
    }

    private void LoginAuto()
    {
        HatchManager.m_isLoggedIn = false;
        this.InitPlayer(true);
    }

    private void OnLoginError(ErrorType errorType, string message)
    {
        this.InitPlayer(false);
        if (errorType == HatchManager.ErrorType.NoNetwork)
        {
            GameProgress.ChangePlayer(PlayerPrefs.GetString("offline_game_progress", string.Empty));
        }
        if (HatchManager.onLoginFailed != null)
        {
            HatchManager.onLoginFailed();
        }
        HatchManager.m_hasLoginError = true;
    }

    private void InitPlayer(bool online)
    {
        if (HatchManager.CurrentPlayer == null)
        {
            HatchManager.CurrentPlayer = new HatchPlayer("HatchID", "HatchCustomerID");
        }
        if (online)
        {
            Singleton<PlayFabManager>.Instance.Logout();
            this.LoginToPlayFab();
        }
    }

    private void PlayerIsReady()
    {
        if (Singleton<PlayFabManager>.Instance.IsSendingChunkCache)
        {
            EventManager.Connect(new EventManager.OnEvent<PlayFabEvent>(this.OnPlayFabEvent));
            return;
        }
        GameProgress.ChangePlayer(string.Empty);
        PlayerPrefs.SetString("offline_game_progress", string.Empty);
        HatchManager.m_isLoggedIn = true;
        if (HatchManager.onLoginSuccess != null)
        {
            HatchManager.onLoginSuccess();
        }
    }

    private void LoginToPlayFab()
    {
        PlayFabManager instance = Singleton<PlayFabManager>.Instance;
        instance.OnLogin = (Action<string, string>)Delegate.Combine(instance.OnLogin, new Action<string, string>(this.OnPlayFabLogin));
        Singleton<PlayFabManager>.Instance.Login(HatchManager.CurrentPlayer);
    }

    private void OnPlayFabLogin(string playFabId, string facebookId)
    {
        PlayFabManager instance = Singleton<PlayFabManager>.Instance;
        instance.OnLogin = (Action<string, string>)Delegate.Remove(instance.OnLogin, new Action<string, string>(this.OnPlayFabLogin));
        if (!string.IsNullOrEmpty(playFabId))
        {
            if (HatchManager.onPlayFabLoginSuccess != null)
            {
                HatchManager.onPlayFabLoginSuccess();
            }
            HatchManager.CurrentPlayer.AddPlayFabID(playFabId);
            this.PlayerIsReady();
        }
        else
        {
            this.OnLoginError(HatchManager.ErrorType.PlayFabLoginError, "Couldn't login to PlayFab");
        }
    }

    private void OnPlayFabEvent(PlayFabEvent data)
    {
        if (data.type == PlayFabEvent.Type.UserDataUploadEnded)
        {
            EventManager.Disconnect(new EventManager.OnEvent<PlayFabEvent>(this.OnPlayFabEvent));
            this.PlayerIsReady();
        }
    }

    private static bool m_initialized;

    private static bool m_isLoggedIn;

    private static bool m_hasLoginError;

    public static Action onLoginSuccess;

    public static Action onLoginFailed;

    public static Action onLogout;

    public static Action onPlayFabLoginSuccess;

    private enum ErrorType
    {
        None,
        SessionNotInitialized = -1,
        IdentityToSessionMigrationError = -2,
        FacebookLoginError = -3,
        PlayFabLoginError = -4,
        NoNetwork = -5,
        PlayerRegisterError = -6,
        RestoreSessionError = -7
    }

    public class HatchPlayer
    {
        public HatchPlayer(string hatchID, string hatchCustomerID)
        {
            this.HatchID = hatchID;
            this.HatchCustomerID = hatchCustomerID;
        }

        public string HatchID { get; private set; }

        public string HatchCustomerID { get; private set; }

        public string PlayFabID { get; private set; }

        public string PlayFabDisplayName { get; private set; }

        public string FacebookToken { get; private set; }

        public string FacebookID { get; private set; }

        public void AddPlayFabID(string playFabID)
        {
            this.PlayFabID = playFabID;
        }

        public void AddPlayFabDisplayName(string playFabDisplayName)
        {
            this.PlayFabDisplayName = playFabDisplayName;
        }
    }
}
