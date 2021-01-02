using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Challenge : WPFMonoBehaviour
{
	public static List<Challenge> Challenges
	{
		get
		{
			return Challenge.s_challenges;
		}
	}

	public virtual ChallengeType Type
	{
		get
		{
			return Challenge.ChallengeType.DontUseParts;
		}
	}

	protected virtual void Awake()
	{
		Challenge.s_challenges.Add(this);
		this.Refresh();
	}

	protected virtual void OnDestroy()
	{
		Challenge.s_challenges.Remove(this);
		this.Refresh();
	}

	private void Refresh()
	{
		Challenge.s_challenges.Sort(new ChallengeOrder());
		for (int i = 0; i < Challenge.s_challenges.Count; i++)
		{
			Challenge.s_challenges[i].m_challengeNumber = i + 1;
		}
	}

	public int ChallengeNumber
	{
		get
		{
			return this.m_challengeNumber;
		}
		set
		{
			this.m_challengeNumber = value;
		}
	}

	public List<IconPlacement> Icons
	{
		get
		{
			return this.m_icons;
		}
	}

	public abstract bool IsCompleted();

	public virtual float TimeLimit()
	{
		return 0f;
	}

	public List<IconPlacement> m_icons;

	public GameObject m_tutorialBookPage;

	private static List<Challenge> s_challenges = new List<Challenge>();

	[SerializeField]
	private int m_challengeNumber;

	public enum ChallengeType
	{
		DontUseParts,
		Time,
		PerfectFlight,
		Transport,
		Box,
		Max
	}

	public class ChallengeOrder : IComparer<Challenge>
	{
		public int Compare(Challenge obj1, Challenge obj2)
		{
			return string.Compare(obj1.name, obj2.name);
		}
	}

	[Serializable]
	public class IconPlacement
	{
		public Vector3 position;

		public float scale = 1f;

		public GameObject icon;
	}
}
