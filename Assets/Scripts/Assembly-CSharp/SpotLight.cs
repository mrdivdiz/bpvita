using System;
using UnityEngine;

public class SpotLight : BasePart
{
	public override void Awake()
	{
		base.Awake();
		this.m_leftAttachment = base.transform.Find("LeftAttachment").gameObject;
		this.m_rightAttachment = base.transform.Find("RightAttachment").gameObject;
		this.m_topAttachment = base.transform.Find("TopAttachment").gameObject;
		this.m_bottomAttachment = base.transform.Find("BottomAttachment").gameObject;
		this.m_bottomLeftAttachment = base.transform.Find("BottomLeftAttachment").gameObject;
		this.m_bottomRightAttachment = base.transform.Find("BottomRightAttachment").gameObject;
		this.m_topLeftAttachment = base.transform.Find("TopLeftAttachment").gameObject;
		this.m_topRightAttachment = base.transform.Find("TopRightAttachment").gameObject;
		this.m_leftAttachment.SetActive(false);
		this.m_rightAttachment.SetActive(false);
		this.m_topAttachment.SetActive(false);
		this.m_bottomAttachment.SetActive(false);
		this.m_bottomLeftAttachment.SetActive(false);
		this.m_bottomRightAttachment.SetActive(false);
		this.m_topLeftAttachment.SetActive(false);
		this.m_topRightAttachment.SetActive(false);
		this.lightSource = base.GetComponentInChildren<PointLightSource>();
		if (this.m_lightConeContainer != null)
		{
			this.m_lightConeContainer.transform.localScale = Vector3.one * this.m_lightConeTargetScale;
		}
	}

	public override BasePart.GridRotation AutoAlignRotation(BasePart.JointConnectionDirection target)
	{
		switch (target)
		{
		case BasePart.JointConnectionDirection.Right:
			return BasePart.GridRotation.Deg_90;
		case BasePart.JointConnectionDirection.Up:
			return BasePart.GridRotation.Deg_180;
		case BasePart.JointConnectionDirection.Left:
			return BasePart.GridRotation.Deg_270;
		case BasePart.JointConnectionDirection.Down:
			return BasePart.GridRotation.Deg_0;
		default:
			return BasePart.GridRotation.Deg_0;
		}
	}

	public override void ChangeVisualConnections()
	{
		bool flag = base.contraption.CanConnectTo(this, BasePart.Rotate(BasePart.Direction.Up, this.m_gridRotation));
		bool flag2 = base.contraption.CanConnectTo(this, BasePart.Rotate(BasePart.Direction.Down, this.m_gridRotation));
		bool flag3 = base.contraption.CanConnectTo(this, BasePart.Rotate(BasePart.Direction.Left, this.m_gridRotation));
		bool flag4 = base.contraption.CanConnectTo(this, BasePart.Rotate(BasePart.Direction.Right, this.m_gridRotation));
		bool flag5 = base.contraption.CanConnectTo(this, BasePart.Rotate(BasePart.Direction.UpLeft, this.m_gridRotation));
		bool flag6 = base.contraption.CanConnectTo(this, BasePart.Rotate(BasePart.Direction.DownLeft, this.m_gridRotation));
		bool flag7 = base.contraption.CanConnectTo(this, BasePart.Rotate(BasePart.Direction.UpRight, this.m_gridRotation));
		bool flag8 = base.contraption.CanConnectTo(this, BasePart.Rotate(BasePart.Direction.DownRight, this.m_gridRotation));
		bool flag9 = this.m_gridRotation == BasePart.GridRotation.Deg_135 || this.m_gridRotation == BasePart.GridRotation.Deg_45 || this.m_gridRotation == BasePart.GridRotation.Deg_225 || this.m_gridRotation == BasePart.GridRotation.Deg_315;
		this.m_leftAttachment.SetActive(flag3 && !flag9);
		this.m_rightAttachment.SetActive(flag4 && !flag9);
		this.m_topAttachment.SetActive(flag && !flag9);
		this.m_bottomAttachment.SetActive((flag2 && !flag9) || (!flag && !flag3 && !flag4 && !flag9));
		this.m_bottomLeftAttachment.SetActive(flag6 && flag9);
		this.m_bottomRightAttachment.SetActive(flag8 && flag9);
		this.m_topLeftAttachment.SetActive(flag5 && flag9);
		this.m_topRightAttachment.SetActive(flag7 && flag9);
		if (!flag && !flag6 && !flag3 && !flag4 && !flag5 && !flag6 && !flag7 && !flag8)
		{
			this.m_bottomAttachment.SetActive(true);
		}
	}

	private void FixedUpdate()
	{
		if (!base.contraption)
		{
			return;
		}
		if (this.m_lightConeContainer != null)
		{
			this.m_lightConeContainer.transform.localScale = Vector3.Lerp(this.m_lightConeContainer.transform.localScale, Vector3.forward + Vector3.up + Vector3.right * this.m_lightConeTargetScale, Time.deltaTime * 30f);
		}
	}

	public override bool CanBeEnabled()
	{
		return true;
	}

	public override bool HasOnOffToggle()
	{
		return true;
	}

	public override bool IsEnabled()
	{
		return this.activated;
	}

	public override bool IsIntegralPart()
	{
		return false;
	}

	public override bool IsPowered()
	{
		return false;
	}

	public override bool CanBeEnclosed()
	{
		return false;
	}

	public override void OnDetach()
	{
		base.OnDetach();
	}

	protected override void OnTouch()
	{
		Singleton<AudioManager>.Instance.SpawnOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.toggleLamp, base.transform.position);
		this.SetEnabled(!this.activated);
	}

	public override void SetEnabled(bool enabled)
	{
		this.activated = enabled;
		this.lightSource.isEnabled = this.activated;
		base.contraption.UpdateEngineStates(base.ConnectedComponent);
		this.m_lightConeTargetScale = ((!this.activated) ? 0.001f : 3f);
	}

	private bool activated;

	private GameObject m_leftAttachment;

	private GameObject m_rightAttachment;

	private GameObject m_topAttachment;

	private GameObject m_bottomAttachment;

	private GameObject m_bottomLeftAttachment;

	private GameObject m_bottomRightAttachment;

	private GameObject m_topLeftAttachment;

	private GameObject m_topRightAttachment;

	private PointLightSource lightSource;

	[SerializeField]
	private GameObject m_lightConeContainer;

	private float m_lightConeTargetScale;
}
