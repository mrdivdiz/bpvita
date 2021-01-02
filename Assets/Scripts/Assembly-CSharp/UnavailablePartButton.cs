using System;
using UnityEngine;

[RequireComponent(typeof(Sprite))]
[RequireComponent(typeof(BoxCollider))]
public class UnavailablePartButton : Widget
{
	private void Start()
	{
		this.m_lockAnimation = base.transform.Find("Lock").GetComponent<Animation>();
		this.m_starAnimation = base.transform.Find("Star").GetComponent<Animation>();
		this.m_starlimitAnimation = base.transform.Find("Starlimit").GetComponent<Animation>();
	}

	protected override void OnInput(InputEvent input)
	{
		if (input.type == InputEvent.EventType.Press)
		{
			if (this.m_lockAnimation != null && !this.m_lockAnimation.isPlaying)
			{
				this.m_lockAnimation.Play();
			}
			if (this.m_starAnimation != null && !this.m_starAnimation.isPlaying)
			{
				this.m_starAnimation.Play();
			}
			if (this.m_starlimitAnimation != null && !this.m_starlimitAnimation.isPlaying)
			{
				this.m_starlimitAnimation.Play();
			}
		}
		if (input.type == InputEvent.EventType.Release && this.OnPress != null)
		{
			this.OnPress();
		}
	}

	public Action OnPress;

	private Animation m_lockAnimation;

	private Animation m_starAnimation;

	private Animation m_starlimitAnimation;
}
