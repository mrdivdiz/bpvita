using System.Collections.Generic;
using UnityEngine;

public class ToolboxButton : SliderButton
{
	public bool ToolboxOpen
	{
		get
		{
			return this.isButtonOut;
		}
	}

	private void OnEnable()
	{
		this.InitAnimationStates(this.isButtonOut, new AnimationState[]
		{
			base.GetComponent<Animation>()["ToolBoxButtonSlide"],
			this.m_button.GetComponent<Animation>()["ToolBoxButton"]
		});
		this.m_button.transform.Find("Gear").transform.rotation = Quaternion.identity;
		this.EnableRendererRecursively(base.gameObject, this.isButtonOut);
		this.ActivateToggleList(!this.isButtonOut);
		this.m_powerupTutorialShown = GameProgress.GetBool("PowerupTutorialShown", false, GameProgress.Location.Local, null);
	}

	private void Reset()
	{
		for (int i = 0; i < base.transform.childCount; i++)
		{
			Transform child = base.transform.GetChild(i);
			Vector3 localPosition = child.localPosition;
			localPosition.x = (localPosition.y = 0f);
			child.localPosition = localPosition;
			child.localRotation = Quaternion.identity;
			child.localScale = Vector3.one * 0.2f;
		}
		this.isButtonOut = false;
	}

	public void OnPressed()
	{
		if (base.GetComponent<Animation>().isPlaying)
		{
			return;
		}
		this.EnableRendererRecursively(base.gameObject, true);
		bool reverse = this.isButtonOut;
		this.InitAnimationStates(reverse, new AnimationState[]
		{
			base.GetComponent<Animation>()["ToolBoxButtonSlide"],
			this.m_button.GetComponent<Animation>()["ToolBoxButton"]
		});
		base.GetComponent<Animation>().Play();
		this.m_button.GetComponent<Animation>().Play();
		this.isButtonOut = !this.isButtonOut;
		if (this.isButtonOut)
		{
			this.ActivateToggleList(false);
		}
		if (!this.m_powerupTutorialShown && !WPFMonoBehaviour.levelManager.m_showPowerupTutorial)
		{
			WPFMonoBehaviour.levelManager.m_showPowerupTutorial = true;
			EventManager.Send(new UIEvent(UIEvent.Type.OpenTutorial));
			this.m_openList = true;
		}
	}

	private void Update()
	{
		if (!base.GetComponent<Animation>().isPlaying && this.lastIsPlaying && !this.isButtonOut)
		{
			this.ActivateToggleList(true);
		}
		if (this.m_openList)
		{
			this.Reset();
			this.OnPressed();
			this.m_openList = false;
		}
		this.lastIsPlaying = base.GetComponent<Animation>().isPlaying;
	}

	private void ActivateToggleList(bool state)
	{
		foreach (GameObject gameObject in this.m_toggleList)
		{
			gameObject.SetActive(state);
		}
	}

	private void InitAnimationStates(bool reverse, params AnimationState[] states)
	{
		foreach (AnimationState animationState in states)
		{
			animationState.speed = (float)((!reverse) ? 1 : -1);
			animationState.time = ((!reverse) ? 0f : animationState.length);
		}
	}

	private void EnableRendererRecursively(GameObject obj, bool enable)
	{
		if (obj.GetComponent<Renderer>())
		{
			obj.GetComponent<Renderer>().enabled = enable;
		}
		if (obj.GetComponent<Collider>())
		{
			obj.GetComponent<Collider>().enabled = enable;
		}
		for (int i = 0; i < obj.transform.childCount; i++)
		{
			this.EnableRendererRecursively(obj.transform.GetChild(i).gameObject, enable);
		}
	}

	public void OpenMenu()
	{
		this.ActivateToggleList(true);
	}

	public List<GameObject> m_toggleList = new List<GameObject>();

	public GameObject m_button;

	public GameObject m_scrollLeftButton;

	private bool isButtonOut;

	private bool lastIsPlaying;

	private const string AnimName = "ToolBoxButtonSlide";

	private const string ToolBoxAnimName = "ToolBoxButton";

	private bool m_powerupTutorialShown;

	private bool m_openList;
}
