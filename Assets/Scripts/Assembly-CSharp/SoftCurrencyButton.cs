using System.Collections;
using UnityEngine;

public class SoftCurrencyButton : MonoBehaviour, ICurrencyParticleEffectTarget
{
	public float ScreenPlacementFromTop
	{
		get
		{
			return this.screenPlacementFromTop;
		}
	}

	public float ScreenPlacementFromBottom
	{
		get
		{
			return this.screenPlacementFromBottom;
		}
	}

	public ScreenPlacement Placement
	{
		get
		{
			return this.screenPlacement;
		}
	}

	public CurrencyParticleEffect CurrencyEffect
	{
		get
		{
			return this.currencyEffect;
		}
	}

	protected virtual void ButtonAwake()
	{
	}

	private void Awake()
	{
		this.currencyEffect = base.GetComponent<CurrencyParticleEffect>();
		this.screenPlacement = base.GetComponent<ScreenPlacement>();
		if (this.currencyEffect)
		{
			this.currencyEffect.SetTarget(this);
		}
		this.shinyEffect = base.transform.Find("SoftCurrencyIcon/Shiny");
		this.plusIcon = base.transform.Find("PlusIcon");
		this.ShowButton(false);
		this.ButtonAwake();
		EventManager.Connect(new EventManager.OnEvent<PlayerChangedEvent>(this.OnPlayerChanged));
	}

	private void OnDestroy()
	{
		EventManager.Disconnect(new EventManager.OnEvent<PlayerChangedEvent>(this.OnPlayerChanged));
	}

	protected virtual void OnPlayerChanged(PlayerChangedEvent data)
	{
		this.UpdateAmount(true);
	}

	protected virtual void ButtonEnabled()
	{
	}

	private void OnEnable()
	{
		this.nextUpdate = Time.realtimeSinceStartup + 2f;
		this.UpdateAmount(true);
		this.ButtonEnabled();
	}

	protected virtual void ButtonDisabled()
	{
	}

	private void OnDisable()
	{
		this.isShining = false;
		if (this.shinyEffect != null)
		{
			this.shinyEffect.localScale = Vector3.one * 0.001f;
		}
		this.ButtonDisabled();
	}

	protected virtual int GetCurrencyCount()
	{
		return 0;
	}

	public void UpdateAmount(bool forceUpdate = false)
	{
		if (this.labels == null || !GameProgress.Initialized)
		{
			return;
		}
		this.targetAmount = this.GetCurrencyCount();
		this.nextUpdate = Time.realtimeSinceStartup;
		if (forceUpdate)
		{
			this.currentAmount = this.targetAmount;
			TextMeshHelper.UpdateTextMeshes(this.labels, string.Format("{0}", this.currentAmount), false);
		}
	}

	private IEnumerator ShinyEffect()
	{
		if (this.isShining || this.shinyEffect == null)
		{
			yield break;
		}
		this.isShining = true;
		float fade = 0f;
		while (fade < 1f)
		{
			fade += Time.deltaTime;
			this.shinyEffect.localEulerAngles = Vector3.forward * fade * 540f;
			if (fade <= 0.5f)
			{
				this.shinyEffect.localScale = Vector3.Lerp(Vector3.one * 0.001f, Vector3.one, fade * 2f);
			}
			else
			{
				this.shinyEffect.localScale = Vector3.Lerp(Vector3.one, Vector3.one * 0.001f, (fade - 0.5f) * 2f);
			}
			yield return null;
		}
		this.shinyEffect.localScale = Vector3.one * 0.001f;
		yield return new WaitForSeconds(UnityEngine.Random.Range(10f, 15f));
		this.isShining = false;
		yield break;
	}

	public virtual AudioSource[] GetHitSounds()
	{
		return null;
	}

	public virtual AudioSource[] GetFlySounds()
	{
		return null;
	}

	protected virtual AudioSource GetLoopSound()
	{
		return null;
	}

	private void PlayLoopSound()
	{
		if (this.counterLoopSource == null)
		{
			AudioSource loopSound = this.GetLoopSound();
			if (loopSound != null)
			{
				this.counterLoopSource = Singleton<AudioManager>.Instance.SpawnLoopingEffect(loopSound, base.transform).GetComponent<AudioSource>();
			}
		}
		int num = this.targetAmount - this.currentAmount;
		float b;
		if (num > 0)
		{
			b = 1.5f;
		}
		else
		{
			b = 0.8f;
		}
		if (this.counterLoopSource != null)
		{
			this.counterLoopSource.pitch = Mathf.Lerp(this.counterLoopSource.pitch, b, Time.deltaTime);
		}
	}

	private void StopLoopSound()
	{
		if (this.counterLoopSource != null)
		{
			GameObject gameObject = this.counterLoopSource.gameObject;
			Singleton<AudioManager>.Instance.RemoveLoopingEffect(ref gameObject);
			this.counterLoopSource.pitch = 1f;
			this.counterLoopSource = null;
		}
	}

	public static int GetDeltaAmount(int current, int target)
	{
		int num = Mathf.Abs(target - current);
		int result = 1;
		if (num > 1000)
		{
			result = UnityEngine.Random.Range(500, 1000);
		}
		else if (num > 100)
		{
			result = UnityEngine.Random.Range(50, 100);
		}
		else if (num > 20)
		{
			result = UnityEngine.Random.Range(10, 20);
		}
		else if (num > 5)
		{
			result = UnityEngine.Random.Range(1, 5);
		}
		return result;
	}

	protected virtual void OnUpdate()
	{
	}

	private void Update()
	{
		if (!this.isShining)
		{
			base.StartCoroutine(this.ShinyEffect());
		}
		if (this.currentAmount != this.targetAmount && Time.realtimeSinceStartup >= this.nextUpdate && this.labels != null)
		{
			this.nextUpdate = Time.realtimeSinceStartup + SoftCurrencyButton.updateInterval;
			int deltaAmount = SoftCurrencyButton.GetDeltaAmount(this.currentAmount, this.targetAmount);
			if (this.currentAmount < this.targetAmount)
			{
				this.currentAmount += deltaAmount;
			}
			else if (this.currentAmount > this.targetAmount)
			{
				this.currentAmount -= deltaAmount;
			}
			for (int i = 0; i < this.labels.Length; i++)
			{
				this.labels[i].text = string.Format("{0}", this.currentAmount);
			}
		}
		if (this.targetAmount - this.currentAmount != 0)
		{
			this.PlayLoopSound();
		}
		else
		{
			this.StopLoopSound();
		}
		this.OnUpdate();
	}

	public virtual void AddParticles(GameObject target, int amount, float delay = 0f, float burstRate = 0f)
	{
		if (this.currencyEffect == null)
		{
			return;
		}
		float num = 0f;
		for (int i = 0; i < amount; i++)
		{
			if (!Mathf.Approximately(burstRate, 0f) && burstRate > 0f)
			{
				num += 1f / burstRate;
			}
			this.currencyEffect.AddParticle(target.transform, UnityEngine.Random.insideUnitCircle.normalized * UnityEngine.Random.Range(20f, 25f), delay + num);
		}
	}

	public void CurrencyParticleAdded(int amount = 1)
	{
		this.targetAmount += amount;
	}

	public void EnableButton(bool enable)
	{
		if (this.plusIcon != null)
		{
			this.plusIcon.gameObject.SetActive(enable);
		}
		if (base.GetComponent<Collider>() != null)
		{
			base.GetComponent<Collider>().enabled = enable;
		}
		if (enable)
		{
			this.nextUpdate = Time.realtimeSinceStartup + 2f;
		}
	}

	public virtual void ShowButton(bool show = true)
	{
		this.UpdateAmount(true);
	}

	public void RecoverToPreviousPosition()
	{
	}

	public void SetCurrencyButton(Transform target, Position pos, bool enableButton)
	{
		this.EnableButton(enableButton);
		this.ShowButton(true);
	}

	[SerializeField]
	protected float screenPlacementFromTop = 1f;

	[SerializeField]
	protected float screenPlacementFromBottom = 2f;

	[SerializeField]
	protected TextMesh[] labels;

	private int targetAmount;

	private int currentAmount;

	public static float updateInterval = 0.02f;

	protected float nextUpdate;

	private ScreenPlacement screenPlacement;

	protected CurrencyParticleEffect currencyEffect;

	private Transform shinyEffect;

	private Transform plusIcon;

	private AudioSource counterLoopSource;

	public Vector3 lastLocalPosition = Vector3.zero;

	private Vector3 previousPosition = Vector3.zero;

	private bool isShining;

	public enum Position
	{
		None,
		Top,
		Bottom
	}
}
