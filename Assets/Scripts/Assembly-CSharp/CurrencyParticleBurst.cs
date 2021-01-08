using UnityEngine;

public class CurrencyParticleBurst : WPFMonoBehaviour
{
	private void Start()
	{
		IapManager.CurrencyType currencyType = this.currencyType;
		if (currencyType != IapManager.CurrencyType.SnoutCoin)
		{
			if (currencyType == IapManager.CurrencyType.Scrap)
			{
				this.parentButton = ScrapButton.Instance;
			}
		}
		else
		{
			this.parentButton = SnoutButton.Instance;
		}
		if (this.burstAmount <= 0 || this.parentButton == null || this.parentButton.CurrencyEffect == null)
		{
			this.CheckDestroy();
			return;
		}
	}

	private void CheckDestroy()
	{
		if (this.selfDestruct)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	public void Burst()
	{
		if (this.parentButton == null || this.parentButton.CurrencyEffect == null)
		{
			return;
		}
		this.burstRate = Mathf.Clamp(this.burstRate, 1f, float.PositiveInfinity);
		float num = 0f;
		for (int i = 0; i < this.burstAmount; i++)
		{
			this.parentButton.CurrencyEffect.AddParticle(base.transform.position, UnityEngine.Random.insideUnitCircle.normalized * UnityEngine.Random.Range(20f, 25f), num);
			num += 1f / this.burstRate;
		}
		this.CheckDestroy();
	}

	public void SetBurst(int newAmount, float newRate, bool burstNow = true)
	{
		this.burstAmount = newAmount;
		this.burstRate = newRate;
		if (burstNow)
		{
			this.Burst();
		}
	}

	[SerializeField]
	private IapManager.CurrencyType currencyType = IapManager.CurrencyType.SnoutCoin;

	[SerializeField]
	private int burstAmount = 1;

	[SerializeField]
	private float burstRate = 20f;

	[SerializeField]
	private bool selfDestruct = true;

	private SoftCurrencyButton parentButton;
}
