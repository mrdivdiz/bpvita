using System.Collections;
using Spine.Unity;
using UnityEngine;

public class CakeRaceMeter : MonoBehaviour
{
	public void EatCake()
	{
		if (this.currentCake >= 0 && this.currentCake < this.cakes.Length)
		{
			this.cakes[this.currentCake].state.SetAnimation(0, this.eatAnimationName, false);
			this.currentCake++;
		}
	}

	public void ResetCakes()
	{
		this.currentCake = 0;
		if (this.cakes == null)
		{
			base.StartCoroutine(this.Init());
		}
		else
		{
			for (int i = 4; i >= 0; i--)
			{
				if (this.cakes[i] != null)
				{
					base.StartCoroutine(this.DelayAnimation(this.cakes[i], 1f + 0.2f * (float)i));
				}
			}
		}
	}

	private IEnumerator DelayAnimation(SkeletonAnimation anim, float seconds)
	{
		Renderer rend = anim.GetComponent<Renderer>();
		rend.enabled = false;
		yield return new WaitForSeconds(seconds);
		anim.state.SetAnimation(0, this.introAnimationName, false);
		anim.state.AddAnimation(0, this.idleAnimationName, true, 0f);
		yield return null;
		rend.enabled = true;
		yield break;
	}

	private IEnumerator Init()
	{
		yield return null;
		this.cakes = new SkeletonAnimation[5];
		for (int i = 0; i < 5; i++)
		{
			Transform transform = base.transform.Find(string.Format("Cakes/Cake{0}", i));
			if (transform != null)
			{
				this.cakes[i] = transform.GetComponent<SkeletonAnimation>();
			}
		}
		this.ResetCakes();
		yield break;
	}

	public void SetScoreLabel(string text)
	{
		TextMeshHelper.UpdateTextMeshes(this.scoreLabel, text, false);
	}

	public void SetPlayerInfo(string name, int level, bool refreshTranslation = false)
	{
		if (string.IsNullOrEmpty(name))
		{
			name = "anonpig";
		}
		TextMeshHelper.UpdateTextMeshes(this.nameLabel, name, refreshTranslation);
		TextMeshHelper.UpdateTextMeshes(this.levelLabel, Mathf.Clamp(level, 0, 999).ToString(), refreshTranslation);
	}

	[SerializeField]
	private string introAnimationName;

	[SerializeField]
	private string idleAnimationName;

	[SerializeField]
	private string eatAnimationName;

	[SerializeField]
	private TextMesh[] scoreLabel;

	[SerializeField]
	private TextMesh[] nameLabel;

	[SerializeField]
	private TextMesh[] levelLabel;

	private SkeletonAnimation[] cakes;

	private int currentCake;
}
