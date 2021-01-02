using System;
using UnityEngine;

public class Dessert : OneTimeCollectable
{
	private void Awake()
	{
		if (this.prefabGlow && base.transform.childCount == 0)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.prefabGlow, base.transform.position + this.prefabGlow.transform.localPosition, this.prefabGlow.transform.localRotation * base.transform.rotation);
			gameObject.transform.parent = base.transform;
		}
	}

	public override void OnCollected()
	{
		base.OnCollected();
		EventManager.Send(new DessertCollectedEvent(this));
	}

	public override void Collect()
	{
		if (this.collected)
		{
			return;
		}
		if (this.collectedEffect)
		{
			UnityEngine.Object.Instantiate<ParticleSystem>(this.collectedEffect, base.transform.position, base.transform.rotation);
		}
		AudioManager instance = Singleton<AudioManager>.Instance;
		instance.Play2dEffect(WPFMonoBehaviour.gameData.commonAudioCollection.dessertCollected);
		this.collected = true;
		this.DisableGoal(true);
		EventManager.Send(default(ObjectiveAchieved));
		this.OnCollected();
	}

	protected override string GetNameKey()
	{
		return string.Empty;
	}

	public GameObject prefabGlow;

	public GameObject prefabIcon;

	public string saveId;

	[NonSerialized]
	public DessertPlace place;

	public struct DessertCollectedEvent : EventManager.Event
	{
		public DessertCollectedEvent(Dessert dessert)
		{
			this.dessert = dessert;
		}

		public Dessert dessert;
	}
}
