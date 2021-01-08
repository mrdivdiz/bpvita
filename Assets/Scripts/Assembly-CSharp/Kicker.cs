using System;
using System.Collections.Generic;
using UnityEngine;

public class Kicker : BasePart
{
	public override BasePart.Direction EffectDirection()
	{
		return BasePart.Rotate(BasePart.Direction.Right, this.m_gridRotation);
	}

	public override void SetRotation(BasePart.GridRotation rotation)
	{
		this.m_gridRotation = rotation;
		this.SetColorMark();
	}

	private void SetColorMark()
	{
		int num = this.m_colorMarks.Length;
		while (--num >= 0)
		{
			if (this.m_colorMarks[num])
			{
				this.m_colorMarks[num].GetComponent<Renderer>().enabled = false;
			}
		}
		if (this.m_colorMarks[(int)this.m_gridRotation])
		{
			this.m_colorMarks[(int)this.m_gridRotation].GetComponent<Renderer>().enabled = true;
		}
	}

	public override void Awake()
	{
		base.Awake();
		this.m_colorMarks[0] = base.transform.Find("Deg0").gameObject;
		this.m_colorMarks[1] = base.transform.Find("Deg90").gameObject;
		this.m_colorMarks[2] = base.transform.Find("Deg180").gameObject;
		this.m_colorMarks[3] = base.transform.Find("Deg270").gameObject;
		this.SetColorMark();
	}

	public override void Initialize()
	{
		if (WPFMonoBehaviour.levelManager.ContraptionRunning == null)
		{
			return;
		}
		this.m_JointsToBreak = WPFMonoBehaviour.levelManager.ContraptionRunning.FindPartFixedJoints(this);
		base.contraption.ChangeOneShotPartAmount(this.m_partType, this.EffectDirection(), 1);
	}

	protected override void OnTouch()
	{
		if (!this.m_isTriggered)
		{
			this.m_isTriggered = true;
			Singleton<AudioManager>.Instance.SpawnOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.kickerDetach, base.transform.position);
			base.contraption.ChangeOneShotPartAmount(this.m_partType, this.EffectDirection(), -1);
			for (int i = 0; i < this.m_JointsToBreak.Count; i++)
			{
				if (this.m_JointsToBreak[i])
				{
					UnityEngine.Object.Destroy(this.m_JointsToBreak[i]);
					BasePart component = this.m_JointsToBreak[i].gameObject.GetComponent<BasePart>();
					if (component)
					{
						component.HandleJointBreak(1000f, false);
					}
				}
				this.m_JointsToBreak[i] = null;
			}
			this.m_JointsToBreak.Clear();
		}
	}

	private bool m_isTriggered;

	private List<Joint> m_JointsToBreak;

	private GameObject[] m_colorMarks = new GameObject[8];
}
