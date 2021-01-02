using System;
using UnityEngine;

internal class SnapshotEffect : MonoBehaviour
{
	public event Action SnapshotFinished;

	private void Awake()
	{
		this.m_snapshotMaterial = new Material(this.snapshotShader);
		this.m_snapshotMaterial.hideFlags = HideFlags.HideAndDontSave;
		base.enabled = false;
	}

	private void OnEnable()
	{
		this.m_renderFunc = new Action<RenderTexture, RenderTexture>(this.SnapshotFunc);
		this.SnapshotFinished = null;
	}

	private void OnDisable()
	{
		if (this.SnapshotFinished != null)
		{
			this.SnapshotFinished();
		}
	}

	private void OnDestroy()
	{
		UnityEngine.Object.Destroy(this.m_snapshotMaterial);
	}

	private void SaveSnapshot()
	{
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		this.m_renderFunc(source, destination);
	}

	private void SnapshotFunc(RenderTexture source, RenderTexture destination)
	{
		this.SaveSnapshot();
		if (this.snapshotSound != null)
		{
			Singleton<AudioManager>.Instance.Play2dEffect(this.snapshotSound);
		}
		Graphics.Blit(source, destination);
		this.m_snapshotTimer = this.snapshotFadeTime;
		this.m_renderFunc = new Action<RenderTexture, RenderTexture>(this.FadeFunc);
	}

	private void FadeFunc(RenderTexture source, RenderTexture destination)
	{
		float num = this.m_snapshotTimer / this.snapshotFadeTime;
		this.m_snapshotMaterial.SetFloat("_Saturation", 1f - num);
		this.m_snapshotMaterial.SetFloat("_RampOffset", num);
		Graphics.Blit(source, destination, this.m_snapshotMaterial);
		this.m_snapshotTimer -= GameTime.RealTimeDelta;
		base.enabled = (this.m_snapshotTimer > 0f);
	}

	[SerializeField]
	private Shader snapshotShader;

	[SerializeField]
	private AudioSource snapshotSound;

	[SerializeField]
	private float snapshotFadeTime;

	private Material m_snapshotMaterial;

	private float m_snapshotTimer;

	private Action<RenderTexture, RenderTexture> m_renderFunc;
}
