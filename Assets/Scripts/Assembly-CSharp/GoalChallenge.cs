using UnityEngine;

public class GoalChallenge : WPFMonoBehaviour
{
	public Challenge.IconPlacement Icon
	{
		get
		{
			return this.m_icon;
		}
	}

	public GameObject TutorialPage
	{
		get
		{
			return this.m_tutorialPage;
		}
	}

	[SerializeField]
	private Challenge.IconPlacement m_icon;

	[SerializeField]
	private GameObject m_tutorialPage;
}
