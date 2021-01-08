using System.Collections.Generic;
using CakeRace;
using UnityEngine;

public class CakeRaceTutorialBook : TutorialBook
{
	protected override void Awake()
	{
		if (CakeRaceMenu.WeeklyTrackIdentifiers == null)
		{
			return;
		}
		List<GameObject> list = new List<GameObject>();
		for (int i = 0; i < CakeRaceMenu.WeeklyTrackIdentifiers.Length; i++)
		{
			CakeRaceInfo? cakeRaceInfo;
			if (WPFMonoBehaviour.gameData.m_cakeRaceData.GetInfo(CakeRaceMenu.WeeklyTrackIdentifiers[i], out cakeRaceInfo))
			{
				if (cakeRaceInfo.Value.TutorialBookPrefab != null)
				{
					GameObject tutorialBookPrefab = cakeRaceInfo.Value.TutorialBookPrefab;
					GameObject item = this.m_pages[this.m_pages.IndexOf(tutorialBookPrefab) + 1];
					if (!list.Contains(tutorialBookPrefab) && !list.Contains(item))
					{
						list.Add(tutorialBookPrefab);
						list.Add(item);
					}
					if (CakeRaceMenu.WinCount <= i)
					{
						this.m_lastOpenedPage = ((list.IndexOf(tutorialBookPrefab) <= this.m_lastOpenedPage) ? this.m_lastOpenedPage : list.IndexOf(tutorialBookPrefab));
					}
					if (CakeRaceMode.CurrentCakeRaceInfo.UniqueIdentifier == CakeRaceMenu.WeeklyTrackIdentifiers[i])
					{
						this.m_currentPage = list.IndexOf(tutorialBookPrefab);
					}
				}
			}
		}
		if (list.Count >= 2)
		{
			this.m_pages = list;
		}
		else
		{
			this.m_lastOpenedPage = this.m_pages.Count;
		}
		this.m_initialized = true;
		base.Initialize();
	}

	private void OnEnable()
	{
		if (!this.m_initialized)
		{
			base.gameObject.SetActive(false);
		}
	}

	public override void TurnPageLeft()
	{
		base.TurnPageLeft();
	}

	public override void TurnPageRight()
	{
		base.TurnPageRight();
	}

	private bool m_initialized;
}
