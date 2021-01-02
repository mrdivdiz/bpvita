using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCollider : WPFMonoBehaviour
{
	private void Start()
	{
		EventManager.Connect(new EventManager.OnEvent<GameStateChanged>(this.OnGameStateChanged));
	}

	private void OnDestroy()
	{
		EventManager.Disconnect(new EventManager.OnEvent<GameStateChanged>(this.OnGameStateChanged));
	}

	private void OnGameStateChanged(GameStateChanged newState)
	{
		if (newState.state == LevelManager.GameState.Running)
		{
			this.visitedContraptionPartList = new List<BasePart>();
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		BasePart component = other.GetComponent<BasePart>();
		if (!component)
		{
			return;
		}
		if (this.visitedContraptionPartList.Contains(component))
		{
			return;
		}
		if (component.m_partType == BasePart.PartType.Pig)
		{
			this.pig = (Pig)component;
		}
		WPFMonoBehaviour.levelManager.ContraptionRunning.FinishConnectedComponentSearch();
		List<BasePart> parts = WPFMonoBehaviour.levelManager.ContraptionRunning.Parts;
		for (int i = 0; i < parts.Count; i++)
		{
			BasePart basePart = parts[i];
			if (basePart && basePart.ConnectedComponent == component.ConnectedComponent)
			{
				this.visitedContraptionPartList.Add(basePart);
				if (basePart.m_partType == BasePart.PartType.Pig)
				{
					this.pig = (Pig)basePart;
				}
			}
		}
		this.visitedContraptionPartList.Add(component);
		if (this.pig != null)
		{
			this.pig.CheckCameraLimits = false;
		}
		if (this.particleEffect)
		{
			WPFMonoBehaviour.effectManager.CreateParticles(this.particleEffect, component.transform.position, true);
			if (Singleton<SocialGameManager>.IsInstantiated())
			{
				Singleton<SocialGameManager>.Instance.ReportAchievementProgress("grp.WHEN_PIGS_FALL", 100.0);
			}
			Singleton<AudioManager>.Instance.SpawnOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.pigFall, other.transform.position);
			base.StartCoroutine(this.DelayedToBuilding(5f));
		}
	}

	private IEnumerator DelayedToBuilding(float duration)
	{
		yield return new WaitForSeconds(duration);
		if (this.pig != null)
		{
			this.pig.CheckCameraLimits = true;
		}
		yield break;
	}

	public GameObject particleEffect;

	private List<BasePart> visitedContraptionPartList;

	private Pig pig;
}
