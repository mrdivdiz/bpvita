using System;
using UnityEngine;

public class CrossPromoButton : MonoBehaviour
{
	private void Awake()
	{
		UnityEngine.Debug.LogWarning("CrossPromoButton::Awake");
		if (this.crossPromoType == CrossPromoButton.CrossPromoType.Main && AdvertisementHandler.CrossPromoMainRenderable != null)
		{
			if (AdvertisementHandler.GetCrossPromoMainTexture() != null)
			{
				UnityEngine.Debug.LogWarning("CrossPromoButton::Awake::OnRenderableReady: Main");
				this.OnRenderableReady(true);
			}
			else
			{
				UnityEngine.Debug.LogWarning("CrossPromoButton::Awake::GetCrossPromoMainTexture is NULL");
				AdvertisementHandler.RenderableHandler crossPromoMainRenderable = AdvertisementHandler.CrossPromoMainRenderable;
				crossPromoMainRenderable.onRenderableReady = (Action<bool>)Delegate.Combine(crossPromoMainRenderable.onRenderableReady, new Action<bool>(this.OnRenderableReady));
				base.gameObject.SetActive(false);
			}
		}
		else if (this.crossPromoType == CrossPromoButton.CrossPromoType.Episode && AdvertisementHandler.CrossPromoEpisodeRenderable != null)
		{
			if (AdvertisementHandler.GetCrossPromoEpisodeTexture() != null)
			{
				UnityEngine.Debug.LogWarning("CrossPromoButton::Awake::OnRenderableReady: Episode");
				this.OnRenderableReady(true);
			}
			else
			{
				UnityEngine.Debug.LogWarning("CrossPromoButton::Awake::GetCrossPromoEpisodeTexture is NULL");
				AdvertisementHandler.RenderableHandler crossPromoEpisodeRenderable = AdvertisementHandler.CrossPromoEpisodeRenderable;
				crossPromoEpisodeRenderable.onRenderableReady = (Action<bool>)Delegate.Combine(crossPromoEpisodeRenderable.onRenderableReady, new Action<bool>(this.OnRenderableReady));
				base.gameObject.SetActive(false);
			}
		}
		else
		{
			base.gameObject.SetActive(false);
		}
	}

	private void OnDestroy()
	{
		if (this.crossPromoType == CrossPromoButton.CrossPromoType.Main && AdvertisementHandler.CrossPromoMainRenderable != null)
		{
			AdvertisementHandler.RenderableHandler crossPromoMainRenderable = AdvertisementHandler.CrossPromoMainRenderable;
			crossPromoMainRenderable.onRenderableReady = (Action<bool>)Delegate.Remove(crossPromoMainRenderable.onRenderableReady, new Action<bool>(this.OnRenderableReady));
		}
		else if (this.crossPromoType == CrossPromoButton.CrossPromoType.Episode && AdvertisementHandler.CrossPromoEpisodeRenderable != null)
		{
			AdvertisementHandler.RenderableHandler crossPromoEpisodeRenderable = AdvertisementHandler.CrossPromoEpisodeRenderable;
			crossPromoEpisodeRenderable.onRenderableReady = (Action<bool>)Delegate.Remove(crossPromoEpisodeRenderable.onRenderableReady, new Action<bool>(this.OnRenderableReady));
		}
	}

	public void OnPressed()
	{
	}

	private void OnRenderableReady(bool isReady)
	{
		if (!UnityEngine.Application.isPlaying || !isReady)
		{
			return;
		}
		UnityEngine.Debug.LogWarning("CrossPromoButton::OnRenderableReady texture set");
		Renderer component = this.sprite.GetComponent<Renderer>();
		if (this.crossPromoType == CrossPromoButton.CrossPromoType.Main && AdvertisementHandler.CrossPromoMainRenderable != null)
		{
			component.material.mainTexture = AdvertisementHandler.GetCrossPromoMainTexture();
		}
		else if (this.crossPromoType == CrossPromoButton.CrossPromoType.Episode && AdvertisementHandler.CrossPromoEpisodeRenderable != null)
		{
			component.material.mainTexture = AdvertisementHandler.GetCrossPromoEpisodeTexture();
		}
		if (component.material != null && component.material.mainTexture != null)
		{
			float num = (float)component.material.mainTexture.width;
			float num2 = (float)component.material.mainTexture.height;
			component.transform.localScale = Vector3.up * component.transform.localScale.y + Vector3.right * component.transform.localScale.y * (num / num2);
			this.OnRenderableShow();
		}
	}

	public void OnRenderableShow()
	{
		if (this.reportedImpression || !this.sendImpressions)
		{
			return;
		}
		UnityEngine.Debug.LogWarning("OnRenderableShow: CrossPromoButton");
		UnityEngine.Debug.LogWarning("SHOW: CrossPromoButton");
		base.gameObject.SetActive(true);
		this.reportedImpression = true;
	}

	public void OnRenderableHide()
	{
	}

	[SerializeField]
	private CrossPromoType crossPromoType;

	[SerializeField]
	private UnmanagedSprite sprite;

	[SerializeField]
	private bool sendImpressions = true;

	private bool reportedImpression;

	public enum CrossPromoType
	{
		Main,
		Episode
	}
}
