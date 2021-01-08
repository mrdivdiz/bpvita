using System;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : Singleton<TimeManager>
{
    public TimeManager()
    {
    }

    public event OnInitializeHandler OnInitialize;

    private bool HasTime
    {
        get
        {
            return this.lastServerTime > 0 && this.lastServerTimeCheck > 0f;
        }
    }

    private bool CanUpdate
    {
        get
        {
            return (float)Singleton<TimeManager>.Instance.TimeFromStart.TotalSeconds - this.lastServerTimeCheck > 5f;
        }
    }

    public bool Initialized
    {
        get
        {
            return this.initialized;
        }
    }

    public TimeSpan TimeFromStart
    {
        get
        {
            return new TimeSpan(0, 0, (int)(TimeManager.realtimeSinceStartup - this.sessionStart));
        }
    }

    public DateTime CurrentTime
    {
        get
        {
            return DateTime.Now;
        }
    }

    public DateTime ServerTime
    {
        get
        {
            return DateTime.Now;
        }
    }

    public int CurrentEpochTime
    {
        get
        {
            //return (int)DateTimeOffset.Now.ToUniversalTime().ToUnixTimeSeconds();
            //return (int)DateTimeOffset.Now.ToUniversalTime().ToUnixTimeSeconds();
			return 0;
        }
    }

    public static double realtimeSinceStartup
    {
        get
        {
            return TimeManager.m_realtimeSinceStartup;
        }
    }

    private void Awake()
    {
        base.SetAsPersistant();
        this.sessionStart = TimeManager.realtimeSinceStartup;
        this.timers = new Dictionary<string, Timer>();
        this.lastServerTime = -1;
        this.lastServerTimeCheck = -1f;
        EventManager.Connect(new EventManager.OnEvent<PlayerChangedEvent>(this.OnPlayerChanged));
    }

    private void OnDestroy()
    {
        EventManager.Disconnect(new EventManager.OnEvent<PlayerChangedEvent>(this.OnPlayerChanged));
    }

    private void OnPlayerChanged(PlayerChangedEvent data)
    {
        this.initialized = false;
        this.sessionStart = TimeManager.realtimeSinceStartup;
        this.timers = new Dictionary<string, Timer>();
        this.lastServerTime = -1;
        this.lastServerTimeCheck = -1f;
    }

    private void Initialize()
    {
        if (this.initialized)
        {
            return;
        }
        string[] timerIds = GameProgress.GetTimerIds();
        for (int i = 0; i < timerIds.Length; i++)
        {
            if (!this.timers.ContainsKey(timerIds[i]))
            {
                this.timers.Add(timerIds[i], new Timer(timerIds[i], TimeManager.ConvertSeconds2DateTime(GameProgress.GetTimerData<int>(timerIds[i], "date")), null, this));
            }
        }
        this.initialized = true;
        if (this.OnInitialize != null)
        {
            this.OnInitialize();
        }
    }

    private void Update()
    {
        TimeManager.m_realtimeSinceStartup += (double)Time.unscaledDeltaTime;
        if (!this.HasTime && !this.timePending && this.CanUpdate)
        {
            this.timePending = true;
            this.ServerTimeSuccessfullCallback((ulong)this.lastServerTime);
        }
        else if (this.HasTime)
        {
            this.UpdateTimers();
        }
    }

    private void UpdateTimers()
    {
        Action action = null;
        Action action2 = null;
        foreach (string key in this.timers.Keys)
        {
            Timer timer = this.timers[key];
            if (timer.Check())
            {
                action = (Action)Delegate.Combine(action, new Action(timer.Fire));
                action2 = (Action)Delegate.Combine(action2, new Action(timer.SetRemoved));
            }
        }
        if (action != null || action2 != null)
        {
            action2();
            this.SaveTimers();
            action();
        }
    }

    private void SaveTimers()
    {
        List<string> list = new List<string>();
        List<string> list2 = new List<string>();
        foreach (string text in this.timers.Keys)
        {
            if (this.timers[text].Remove)
            {
                list.Add(text);
            }
            else
            {
                list2.Add(text);
            }
        }
        for (int i = 0; i < list.Count; i++)
        {
            this.timers.Remove(list[i]);
            GameProgress.RemoveTimerData(list[i], "date");
        }
        GameProgress.SetTimerIds(list2.ToArray());
        for (int j = 0; j < list2.Count; j++)
        {
            GameProgress.SetTimerData(list2[j], "date", TimeManager.ConvertDateTime2Seconds(this.timers[list2[j]].Date));
        }
    }

    private void ServerTimeSuccessfullCallback(ulong currentTime)
    {
        this.lastServerTimeCheck = (float)Singleton<TimeManager>.Instance.TimeFromStart.TotalSeconds;
        this.lastServerTime = (int)currentTime;
        this.timePending = false;
        if (!this.initialized)
        {
            this.Initialize();
        }
    }

    public void Subscribe(string id, OnTimedOut onTimedOut)
    {
        if (this.timers.ContainsKey(id))
        {
            this.timers[id].onTimedOut += onTimedOut;
        }
    }

    public void Unsubscribe(string id, OnTimedOut onTimedOut)
    {
        if (this.timers.ContainsKey(id))
        {
            this.timers[id].onTimedOut -= onTimedOut;
        }
    }

    public bool HasTimer(string id)
    {
        return this.timers.ContainsKey(id);
    }

    public float TimeLeft(string id)
    {
        if (!this.timers.ContainsKey(id))
        {
            return -1f;
        }
        return this.timers[id].TimeLeft;
    }

    public void CreateTimer(string id, DateTime time, OnTimedOut onTimedOut)
    {
        this.timers.Add(id, new Timer(id, time, onTimedOut, this));
        this.SaveTimers();
    }

    public void RemoveTimer(string id)
    {
        this.timers[id].SetRemoved();
        this.SaveTimers();
    }

    public void RemoveAllTimers()
    {
        foreach (string key in this.timers.Keys)
        {
            this.timers[key].SetRemoved();
        }
        this.SaveTimers();
    }

    private int GetTimeOffset()
    {
        if (GameProgress.HasKey("TimeOffset", GameProgress.Location.Local, null))
        {
            return GameProgress.GetInt("TimeOffset", 0, GameProgress.Location.Local, null);
        }
        int num = (int)DateTime.Now.Subtract(this.ServerTime).TotalSeconds;
        GameProgress.SetInt("TimeOffset", num, GameProgress.Location.Local);
        return num;
    }

    public static DateTime ConvertSeconds2DateTime(int seconds)
    {
        DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        return dateTime.AddSeconds((double)seconds);
    }

    public static int ConvertDateTime2Seconds(DateTime date)
    {
        return (int)date.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
    }

    private const float MAX_UPDATE_RATE = 5f;

    private double sessionStart;

    private Dictionary<string, Timer> timers;

    private bool timePending;

    private int lastServerTime;

    private int offset;

    private float lastServerTimeCheck;

    private bool initialized;

    private static double m_realtimeSinceStartup;

    private class Timer
    {
        public Timer(string id, DateTime time, OnTimedOut onTimedOut, TimeManager timeMan)
        {
            this.confirmed = false;
            this.confirming = false;
            this.lastCheck = -60f;
            this.id = id;
            this.time = (float)time.Subtract(timeMan.CurrentTime).TotalSeconds;
            this.inited = (float)timeMan.TimeFromStart.TotalSeconds;
            if (onTimedOut != null)
            {
                this.onTimedOut = (OnTimedOut)Delegate.Combine(this.onTimedOut, onTimedOut);
            }
            this.date = time;
            this.fired = false;
        }

        public event OnTimedOut onTimedOut;

        public bool Fired
        {
            get
            {
                return this.fired;
            }
        }

        public bool Remove
        {
            get
            {
                return this.remove;
            }
        }

        public float FireTime
        {
            get
            {
                return this.time;
            }
        }

        public float TimeLeft
        {
            get
            {
                return this.inited + this.time - (float)Singleton<TimeManager>.Instance.TimeFromStart.TotalSeconds;
            }
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }
        }

        private bool CanCheck
        {
            get
            {
                return TimeManager.realtimeSinceStartup - (double)this.lastCheck > 60.0;
            }
        }

        public bool Check()
        {
            if (this.TimeLeft < 0f && !this.confirming && !this.confirmed && this.CanCheck)
            {
                this.confirming = true;
                this.OnServerTimeSuccessfull(0u);
            }
            return !this.fired && this.onTimedOut != null && this.TimeLeft < 0f && this.confirmed;
        }

        public void Fire()
        {
            if (this.onTimedOut != null)
            {
                this.onTimedOut((int)(this.time - (float)Singleton<TimeManager>.Instance.TimeFromStart.TotalSeconds));
                this.fired = true;
            }
        }

        public void SetRemoved()
        {
            this.remove = true;
        }

        private void OnServerTimeSuccessfull(ulong serverTime)
        {
            DateTime t = DateTime.Now;
            this.confirmed = (t >= this.date);
            this.lastCheck = (float)TimeManager.realtimeSinceStartup;
            this.confirming = false;
        }

        private void OnServerTimeUnsuccessfull(int errorCode, string message)
        {
            this.lastCheck = (float)TimeManager.realtimeSinceStartup;
            this.confirming = false;
        }

        public const string DATE = "date";

        private const float CHECK_INTERVAL = 60f;

        public string id;

        public DateTime date;

        private bool fired;

        private bool remove;

        private bool confirming;

        private bool confirmed;

        private float time;

        private float inited;

        private float lastCheck;
    }
}
