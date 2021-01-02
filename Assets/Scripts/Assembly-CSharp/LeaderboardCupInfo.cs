using System;
using System.Collections;
using UnityEngine;

public class LeaderboardCupInfo : MonoBehaviour
{
	private void OnEnable()
	{
		this.Init(null);
		if (this.leaderboardDialog != null && this.leaderboardDialog.ShowingCupAnimation)
		{
			return;
		}
		int currentLeaderboardCup = (int)CakeRaceMenu.GetCurrentLeaderboardCup();
		for (int i = 1; i <= this.cups.Length; i++)
		{
			this.EnableCup((PlayFabLeaderboard.Leaderboard)i, i == currentLeaderboardCup);
		}
	}

	private void OnDisable()
	{
		for (int i = 0; i < this.cups.Length; i++)
		{
			GameObject gameObject = this.cups[i].Find("CupIcon").gameObject;
			Animation animation = (!gameObject) ? null : gameObject.GetComponent<Animation>();
			if (animation)
			{
				animation.Stop();
			}
		}
	}

	public void Init(LeaderboardDialog newDialog = null)
	{
		if (this.initialized)
		{
			return;
		}
		if (newDialog != null)
		{
			this.leaderboardDialog = newDialog;
		}
		if (this.cups == null)
		{
			this.cups = new Transform[6];
			for (int i = 1; i <= 6; i++)
			{
				string name = string.Format("CupGrid/Cup{0}", i);
				this.cups[i - 1] = base.transform.Find(name);
			}
		}
		this.initialized = true;
	}

	private IEnumerator AnimEnableCup(PlayFabLeaderboard.Leaderboard cup, bool enable)
	{
		this.Init(null);
		if (this.cups == null)
		{
			yield break;
		}
		int cupIndex = (int)cup;
		cupIndex--;
		if (cupIndex >= 0 && cupIndex < this.cups.Length && this.cups[cupIndex] != null)
		{
			Transform currentCupGraphics = this.cups[cupIndex].Find("BarYou");
			Transform shine = this.cups[cupIndex].Find("Shine");
			if (currentCupGraphics.gameObject.activeSelf == enable)
			{
				yield break;
			}
			if (!enable && shine)
			{
				shine.gameObject.SetActive(true);
				shine.transform.localScale = Vector3.one;
				yield return base.StartCoroutine(CoroutineRunner.DeltaAction(0.5f, false, delegate(float t)
				{
					shine.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, t);
				}));
				shine.gameObject.SetActive(false);
			}
			else if (enable && shine)
			{
				shine.gameObject.SetActive(true);
				shine.transform.localScale = Vector3.zero;
				yield return base.StartCoroutine(CoroutineRunner.DeltaAction(0.5f, false, delegate(float t)
				{
					shine.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, t);
				}));
				GameObject icon = this.cups[cupIndex].Find("CupIcon").gameObject;
				Animation animation = (!icon) ? null : icon.GetComponent<Animation>();
				animation.Play();
			}
			if (currentCupGraphics != null)
			{
				currentCupGraphics.gameObject.SetActive(enable);
			}
		}
		yield break;
	}

	private void EnableCup(PlayFabLeaderboard.Leaderboard cup, bool enable)
	{
		this.Init(null);
		if (this.cups == null)
		{
			return;
		}
		int num = cup - PlayFabLeaderboard.Leaderboard.CakeRaceCupF;
		if (num >= 0 && num < this.cups.Length && this.cups[num] != null)
		{
			Transform transform = this.cups[num].Find("BarYou");
			Transform transform2 = this.cups[num].Find("Shine");
			if (transform)
			{
				transform.gameObject.SetActive(enable);
			}
			if (transform2)
			{
				transform2.gameObject.SetActive(enable);
			}
		}
	}

	public void ShowCupAnimation(int cupIndex, Action callback)
	{
		base.StartCoroutine(this.PlayCupAdvanceAnimation((PlayFabLeaderboard.Leaderboard)cupIndex, callback));
	}

	private IEnumerator PlayCupAdvanceAnimation(PlayFabLeaderboard.Leaderboard newCup, Action callback)
	{
		int oldCupIndex = newCup - PlayFabLeaderboard.Leaderboard.CakeRaceCupF;
		for (int i = 0; i <= this.cups.Length; i++)
		{
			this.EnableCup((PlayFabLeaderboard.Leaderboard)i, false);
		}
		this.EnableCup((PlayFabLeaderboard.Leaderboard)oldCupIndex, true);
		yield return new WaitForSeconds(0.75f);
		yield return base.StartCoroutine(this.AnimEnableCup((PlayFabLeaderboard.Leaderboard)oldCupIndex, false));
		yield return base.StartCoroutine(this.AnimEnableCup(newCup, true));
		if (callback != null)
		{
			callback();
		}
		yield break;
	}

	private Transform[] cups;

	private LeaderboardDialog leaderboardDialog;

	private bool initialized;
}
