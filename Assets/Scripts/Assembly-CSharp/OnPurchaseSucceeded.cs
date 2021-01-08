using UnityEngine;

public class OnPurchaseSucceeded : WPFMonoBehaviour
{
	private void Awake()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.particlesPrefab);
		this.particles = gameObject.GetComponent<ParticleSystem>();
		this.particles.Stop();
		IapManager.onPurchaseSucceeded += this.OnPurchase;
	}

	private void OnDestroy()
	{
		IapManager.onPurchaseSucceeded -= this.OnPurchase;
	}

	private void OnPurchase(IapManager.InAppPurchaseItemType item)
	{
		for (int i = 0; i < this.items.Length; i++)
		{
			if (this.items[i] == item)
			{
				this.particles.transform.position = base.transform.position;
				this.particles.Play();
				Singleton<AudioManager>.Instance.Play2dEffect(WPFMonoBehaviour.gameData.commonAudioCollection.snoutCoinPurchase);
				if (this.buildMenu != null)
				{
					this.buildMenu.RefreshPowerUpCounts();
				}
				break;
			}
		}
	}

	public InGameBuildMenu buildMenu;

	[SerializeField]
	private IapManager.InAppPurchaseItemType[] items;

	[SerializeField]
	private GameObject particlesPrefab;

	private ParticleSystem particles;
}
