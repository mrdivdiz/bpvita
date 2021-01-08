using UnityEngine;

public class PlayFabWorkingIcon : MonoBehaviour
{
	private void Awake()
	{
		EventManager.Connect(new EventManager.OnEvent<PlayFabEvent>(this.OnPlayFabEvent));
		this.renderers = base.GetComponentsInChildren<MeshRenderer>();
		this.Show(false);
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	private void OnDestroy()
	{
		EventManager.Disconnect(new EventManager.OnEvent<PlayFabEvent>(this.OnPlayFabEvent));
	}

	private void OnPlayFabEvent(PlayFabEvent data)
	{
		switch (data.type)
		{
		case PlayFabEvent.Type.UserDataUploadStarted:
		case PlayFabEvent.Type.UserDeltaChangeUploadStarted:
			if (this.networkActionCount <= 0)
			{
				this.Show(true);
			}
			this.networkActionCount++;
			this.spinning = true;
			break;
		case PlayFabEvent.Type.UserDataUploadEnded:
		case PlayFabEvent.Type.UserDeltaChangeUploadEnded:
			this.networkActionCount--;
			if (this.networkActionCount <= 0)
			{
				this.Show(false);
			}
			this.spinning = false;
			break;
		}
	}

	private void Show(bool show = true)
	{
		if (this.renderers == null || this.renderers.Length <= 0)
		{
			return;
		}
		for (int i = 0; i < this.renderers.Length; i++)
		{
			if (this.renderers[i] != null)
			{
				this.renderers[i].enabled = show;
			}
		}
	}

	private void Update()
	{
		if (this.spinning && this.spinner != null)
		{
			this.spinTime += GameTime.RealTimeDelta;
			if (this.spinTime > 1f)
			{
				this.spinTime -= 1f;
			}
			this.spinner.Rotate(Vector3.back, GameTime.RealTimeDelta * this.spinningSpeed.Evaluate(this.spinTime) * this.speedMultiplier, Space.Self);
		}
	}

	[SerializeField]
	private Transform spinner;

	[SerializeField]
	private AnimationCurve spinningSpeed;

	[SerializeField]
	private float speedMultiplier = 720f;

	private bool spinning;

	private float spinTime;

	private int networkActionCount;

	private MeshRenderer[] renderers;
}
