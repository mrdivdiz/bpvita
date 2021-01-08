using UnityEngine;

namespace CakeRace
{
    public class Cake : OneTimeCollectable
	{
		public event OnCakeCollectedHandler OnCakeCollected;

		public int CakeIndex
		{
			get
			{
				return this.m_cakeIndex;
			}
		}

		public bool CollectedByOtherPlayer { get; private set; }

		protected override string GetNameKey()
		{
			return string.Format("Cake{0}", this.m_cakeIndex);
		}

		private void Awake()
		{
			this.m_cakeIndex = Cake.s_cakeCount++;
			this.CollectedByOtherPlayer = false;
		}

		protected override void Start()
		{
			base.Start();
			this.isDynamic = false;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			Cake.s_cakeCount--;
		}

		public override void Collect()
		{
			if (WPFMonoBehaviour.levelManager.gameState != LevelManager.GameState.Running || this.collected)
			{
				return;
			}
			if (this.collectedEffect)
			{
				UnityEngine.Object.Instantiate<ParticleSystem>(this.collectedEffect, base.transform.position, base.transform.rotation);
			}
			AudioManager instance = Singleton<AudioManager>.Instance;
			instance.Play2dEffect(WPFMonoBehaviour.gameData.commonAudioCollection.bonusBoxCollected);
			this.collected = true;
			this.DisableGoal(true);
			EventManager.Send(default(ObjectiveAchieved));
			this.OnCollected();
		}

		public override void OnCollected()
		{
			if (this.OnCakeCollected != null)
			{
				this.OnCakeCollected(this);
			}
		}

		public void Reset()
		{
			this.DisableGoal(false);
		}

		private static int s_cakeCount;

		private int m_cakeIndex;

		private float m_maxDistance;
	}
}
