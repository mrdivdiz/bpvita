using UnityEngine;

public class DessertsCounter : WPFMonoBehaviour
{
	private void Start()
	{
		this.text = base.transform.Find("AnimationNode/DessertsCounter").GetComponent<TextMesh>();
		this.textShadow = base.transform.Find("AnimationNode/DessertsCounter/DessertsCounterShadow").GetComponent<TextMesh>();
		EventManager.Connect(new EventManager.OnEvent<Dessert.DessertCollectedEvent>(this.ReceiveDessertCollected));
	}

	private void OnEnable()
	{
		base.gameObject.SetActive(WPFMonoBehaviour.levelManager.m_sandbox && GameProgress.GetBool("ChiefPigExploded", false, GameProgress.Location.Local, null));
	}

	private void OnDestroy()
	{
		EventManager.Disconnect(new EventManager.OnEvent<Dessert.DessertCollectedEvent>(this.ReceiveDessertCollected));
	}

	private void ReceiveDessertCollected(Dessert.DessertCollectedEvent eventData)
	{
		this.playEffects = (this.needToUpdateCounter = true);
	}

	private void LateUpdate()
	{
		if (this.needToUpdateCounter)
		{
			this.needToUpdateCounter = false;
			this.text.text = WPFMonoBehaviour.levelManager.m_CollectedDessertsCount.ToString();
			this.textShadow.text = WPFMonoBehaviour.levelManager.m_CollectedDessertsCount.ToString();
		}
		if (this.playEffects)
		{
			this.playEffects = false;
			base.transform.Find("AnimationNode").GetComponent<Animation>().Play();
			base.transform.Find("StarburstEffect").GetComponent<ParticleSystem>().Play();
		}
	}

	private TextMesh textShadow;

	private TextMesh text;

	private bool needToUpdateCounter = true;

	private bool playEffects;
}
