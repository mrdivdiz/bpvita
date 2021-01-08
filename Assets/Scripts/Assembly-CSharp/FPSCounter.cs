using System.Diagnostics;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
	private void Awake()
	{
		base.enabled = false;
		if (base.enabled)
		{
			this.m_fps = (base.GetComponent(typeof(GUIText)) as GUIText);
			this.m_fps.pixelOffset = new Vector2(-(float)Screen.width / 2f, -(float)Screen.height / 2f);
			this.m_fps.alignment = TextAlignment.Left;
			this.m_fps.anchor = TextAnchor.LowerLeft;
			this.m_fps.fontSize = 13;
			UnityEngine.Object.DontDestroyOnLoad(this);
			this.m_stopwatch.Start();
		}
	}

	private void Update()
	{
		this.timeleft -= Time.deltaTime;
		this.frames += 1f;
		if (this.timeleft <= 0f)
		{
			float num = (float)this.m_stopwatch.ElapsedMilliseconds / 1000f;
			float num2 = this.frames / num;
			this.m_fps.text = num2.ToString("f2");
			this.timeleft = this.updateInterval;
			this.frames = 0f;
			this.m_fps.pixelOffset = new Vector2((float)(-(float)Screen.width / 2), (float)(-(float)Screen.height / 2));
			this.m_stopwatch.Reset();
			this.m_stopwatch.Start();
		}
	}

	private GUIText m_fps;

	private float updateInterval = 0.5f;

	private float frames;

	private float timeleft;

	private Stopwatch m_stopwatch = new Stopwatch();
}
