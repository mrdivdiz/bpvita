using UnityEngine;

public class GameTime : MonoBehaviour
{
	public static float RealTimeDelta
	{
		get
		{
			if (GameTime.m_isFixedUpdate)
			{
				return GameTime.m_fixedUpdateRealTimeDelta;
			}
			return GameTime.m_realTimeDelta;
		}
	}

	public static float DeltaTime
	{
		get
		{
			return Time.deltaTime;
		}
	}

	public static bool IsPaused()
	{
		return GameTime.m_paused;
	}

	public static void Pause(bool pause)
	{
		GameTime.m_paused = pause;
		if (pause)
		{
			Time.timeScale = 0f;
		}
		else
		{
			Time.timeScale = 1f;
		}
		EventManager.Send(new GameTimePaused(GameTime.m_paused));
	}

	public void ExternalPause(string msg)
	{
		if (msg == "true")
		{
			if (!GameTime.m_isExternalPaused)
			{
				GameTime.m_prevPaused = GameTime.m_paused;
			}
			GameTime.m_isExternalPaused = true;
			GameTime.Pause(true);
		}
		else if (msg == "false")
		{
			GameTime.m_isExternalPaused = false;
			if (!GameTime.m_prevPaused)
			{
				GameTime.Pause(false);
			}
		}
	}

	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(this);
		GameTime.m_instance = this;
	}

	private void Update()
	{
		GameTime.m_isFixedUpdate = false;
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		GameTime.m_realTimeDelta = realtimeSinceStartup - GameTime.m_previousRealTime;
		GameTime.m_realTimeDelta = Mathf.Clamp(GameTime.m_realTimeDelta, 0f, 1f);
		GameTime.m_previousRealTime = realtimeSinceStartup;
	}

	private void FixedUpdate()
	{
		GameTime.m_isFixedUpdate = true;
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		GameTime.m_fixedUpdateRealTimeDelta = realtimeSinceStartup - GameTime.m_previousFixedUpdateTime;
		GameTime.m_fixedUpdateRealTimeDelta = Mathf.Clamp(GameTime.m_fixedUpdateRealTimeDelta, 0f, 1f);
		GameTime.m_previousFixedUpdateTime = realtimeSinceStartup;
	}

	private static GameTime m_instance;

	private static float m_realTimeDelta;

	private static float m_previousRealTime;

	private static float m_previousFixedUpdateTime;

	private static float m_fixedUpdateRealTimeDelta;

	private static bool m_isFixedUpdate;

	private static bool m_paused;

	private static bool m_prevPaused;

	private static bool m_isExternalPaused;
}
