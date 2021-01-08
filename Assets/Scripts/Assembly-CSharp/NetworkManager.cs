using System;
using System.Collections;
using System.Net;
using System.Threading;
using UnityEngine;

public class NetworkManager : Singleton<NetworkManager>
{
    private bool HasAddress
    {
        get
        {
            return !string.IsNullOrEmpty(this.ipAddress);
        }
    }

    public bool HasNetworkAccess
    {
        get
        {
            return this.connected;
        }
    }

    public void Awake()
    {
        this.resolvingConnectivity = false;
        this.resolvingIpAddress = false;
        this.resolvingAddrFailed = false;
        this.connected = false;
        this.hasFocus = true;
        this.lastCheck = -1f;
        this.resolveThread = null;
        this.fallbackThread = null;
    }

    public void Start()
    {
        base.SetAsPersistant();
        this.hostName = "cloud.rovio.com";
    }

    private void OnApplicationFocus(bool focusStatus)
    {
        this.hasFocus = focusStatus;
        if (focusStatus)
        {
            this.waitingCheck = true;
            if (this.OnFocus != null)
            {
                this.OnFocus();
                this.OnFocus = null;
            }
        }
        else
        {
            try
            {
                if (this.resolvingIpAddress && this.resolveThread != null)
                {
                    this.resolveThread.Abort();
                }
                if (this.fallbackChecking && this.fallbackThread != null)
                {
                    this.fallbackThread.Abort();
                }
            }
            catch
            {
            }
        }
    }

    public void CheckAccess(OnCheckResponseDelegate OnResponse)
    {
        if (UnityEngine.Application.internetReachability == NetworkReachability.NotReachable)
        {
            OnResponse(false);
            return;
        }
        if (!this.HasAddress)
        {
            if (!this.resolvingIpAddress)
            {
                this.resolveThread = new Thread(new ThreadStart(this.ResolveIpAddress));
                this.resolveThread.Start();
            }
            this.waitingCheck = true;
            this.OnCheckResponse = (OnCheckResponseDelegate)Delegate.Combine(this.OnCheckResponse, OnResponse);
        }
        else if (this.resolvingConnectivity)
        {
            this.OnCheckResponse = (OnCheckResponseDelegate)Delegate.Combine(this.OnCheckResponse, OnResponse);
        }
        else if (Time.realtimeSinceStartup - this.lastCheck > 10f)
        {
            this.OnCheckResponse = (OnCheckResponseDelegate)Delegate.Combine(this.OnCheckResponse, OnResponse);
            base.StartCoroutine(this.CheckAccess(15f));
            this.lastCheck = Time.realtimeSinceStartup;
        }
        else
        {
            OnResponse(this.connected);
        }
    }

    public void UnsubscribeFromResponse(OnCheckResponseDelegate OnResponse)
    {
        this.OnCheckResponse = (OnCheckResponseDelegate)Delegate.Remove(this.OnCheckResponse, OnResponse);
    }

    public void Update()
    {
        if (this.waitingCheck && this.HasAddress && !this.resolvingConnectivity)
        {
            base.StartCoroutine(this.CheckAccess(15f));
        }
        else if (this.waitingCheck && !this.HasAddress && !this.resolvingConnectivity && this.resolvingAddrFailed)
        {
            if (this.OnCheckResponse != null)
            {
                this.OnCheckResponse(false);
            }
            this.OnCheckResponse = null;
            this.waitingCheck = false;
        }
        if (!this.continousCheck)
        {
            return;
        }
        if (Time.realtimeSinceStartup - this.lastCheck < 10f)
        {
            return;
        }
        if (this.HasAddress && !this.resolvingConnectivity)
        {
            base.StartCoroutine(this.CheckAccess(15f));
            this.lastCheck = Time.realtimeSinceStartup;
        }
        else if (!this.HasAddress && !this.resolvingIpAddress && this.hasFocus)
        {
            this.resolveThread = new Thread(new ThreadStart(this.ResolveIpAddress));
            this.resolveThread.Start();
        }
    }

    private void ResolveIpAddress()
    {
        this.resolvingIpAddress = true;
        try
        {
            IPHostEntry hostEntry = Dns.GetHostEntry(this.hostName);
            if (hostEntry.AddressList.Length > 0)
            {
                this.ipAddress = hostEntry.AddressList[0].ToString();
                this.resolvingAddrFailed = false;
            }
        }
        catch
        {
            this.resolvingAddrFailed = true;
        }
        finally
        {
            this.resolvingIpAddress = false;
        }
    }

    private IEnumerator CheckAccess(float timeout)
    {
        float startTime = Time.realtimeSinceStartup;
        this.resolvingConnectivity = true;
        Ping ping = new Ping(this.ipAddress);
        float timeLeft = timeout;
        while (!ping.isDone && timeLeft > 0f)
        {
            yield return null;
            timeLeft -= GameTime.RealTimeDelta;
        }
        if (ping.isDone && (float)ping.time > 0f)
        {
            if (!this.connected && this.OnNetworkChange != null)
            {
                this.OnNetworkChange(true);
            }
            if (this.OnCheckResponse != null)
            {
                this.OnCheckResponse(true);
            }
            this.connected = true;
            this.OnCheckResponse = null;
            this.resolvingConnectivity = false;
            this.waitingCheck = false;
        }
        else if (this.hasFocus)
        {
            this.fallbackChecking = true;
            base.StartCoroutine(this.WaitFallback());
            this.fallbackThread = new Thread(new ThreadStart(this.FallbackResolveAccess));
            this.fallbackThread.Start();
        }
        else
        {
            this.OnFocus = (Action)Delegate.Combine(this.OnFocus, new Action(delegate ()
            {
                this.fallbackChecking = true;
                base.StartCoroutine(this.WaitFallback());
                this.fallbackThread = new Thread(new ThreadStart(this.FallbackResolveAccess));
                this.fallbackThread.Start();
            }));
        }
        ping.DestroyPing();
        yield break;
    }

    private IEnumerator WaitFallback()
    {
        while (this.fallbackChecking)
        {
            yield return null;
        }
        this.resolvingConnectivity = false;
        this.waitingCheck = false;
        this.connected = this.fallbackCheck;
        if (this.OnCheckResponse != null)
        {
            this.OnCheckResponse(this.fallbackCheck);
        }
        if (this.fallbackCheck != this.connected && this.OnNetworkChange != null)
        {
            this.OnNetworkChange(this.fallbackCheck);
        }
        this.OnCheckResponse = null;
        yield break;
    }

    private void FallbackResolveAccess()
    {
        try
        {
            IPHostEntry hostEntry = Dns.GetHostEntry(this.hostName);
            if (hostEntry.AddressList.Length > 0)
            {
                this.fallbackCheck = true;
            }
            else
            {
                this.fallbackCheck = false;
            }
        }
        catch
        {
        }
        finally
        {
            this.fallbackChecking = false;
        }
    }

    public OnNetworkChangedDelegate OnNetworkChange;

    private OnCheckResponseDelegate OnCheckResponse;

    private const float MINIMUM_INTERVAL = 10f;

    private const float UPDATE_INTERVAL = 10f;

    private const float CHECK_TIMEOUT = 15f;

    [SerializeField]
    private bool continousCheck;

    private string ipAddress;

    private string hostName;

    private bool resolvingConnectivity;

    private bool resolvingIpAddress;

    private bool resolvingAddrFailed;

    private bool connected;

    private bool waitingCheck;

    private bool fallbackChecking;

    private bool fallbackCheck;

    private bool hasFocus;

    private float lastCheck;

    private Thread resolveThread;

    private Thread fallbackThread;

    private Action OnFocus;

    public delegate void OnNetworkChangedDelegate(bool hasNetwork);

    public delegate void OnCheckResponseDelegate(bool hasNetwork);
}
