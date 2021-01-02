using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Fan : WPFMonoBehaviour
{
	private void Awake()
	{
		this.boxCollider = (base.GetComponent<Collider>() as BoxCollider);
		this.affectedParts = new List<Rigidbody>();
		this.partsInZone = new List<BasePart>();
		this.fanRotation = new Vector3(0f, 10f);
	}

	private IEnumerator Start()
	{
		while (!Bundle.initialized)
		{
			yield return null;
		}
		this.audioManager = Singleton<AudioManager>.Instance;
		EventManager.Connect(new EventManager.OnEvent<UIEvent>(this.ReceiveUIEvent));
		this.fanSound = WPFMonoBehaviour.gameData.commonAudioCollection.environmentFanLoop;
		this.targetVolume = this.fanSound.volume;
		this.InitValues();
		yield break;
	}

	private void OnDestroy()
	{
		EventManager.Disconnect(new EventManager.OnEvent<UIEvent>(this.ReceiveUIEvent));
	}

	private void InitValues()
	{
		this.delayedStart += this.onTime;
		this.fanTop = this.FanTop;
		this.fanUp = this.FanUp;
		this.paused = true;
		this.spinDown = new AnimationCurve();
		this.initialized = true;
	}

	public Vector3 FanTop
	{
		get
		{
			if (this.initialized)
			{
				return this.fanTop;
			}
			if (this.boxCollider == null)
			{
				this.boxCollider = (base.GetComponent<Collider>() as BoxCollider);
			}
			this.fanTop = base.transform.position + this.boxCollider.center.magnitude * this.FanUp + this.FanUp * (this.boxCollider.size.y / 2f);
			return this.fanTop;
		}
		set
		{
			if (this.boxCollider == null)
			{
				this.boxCollider = (base.GetComponent<Collider>() as BoxCollider);
			}
			float num = Vector3.Angle(value - base.transform.position, Vector3.up);
			if (value.x > base.transform.position.x)
			{
				num = -num;
			}
			base.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, num));
			float magnitude = (value - base.transform.position).magnitude;
			this.boxCollider.size = new Vector3(this.boxCollider.size.x, magnitude);
			this.boxCollider.center = base.transform.InverseTransformPoint((value - base.transform.position).normalized * magnitude / 2f + base.transform.position);
			this.fanTop = base.transform.position + this.boxCollider.center.magnitude * this.FanUp + this.FanUp * (this.boxCollider.size.y / 2f);
		}
	}

	public Vector3 FanUp
	{
		get
		{
			if (this.initialized)
			{
				return this.fanUp;
			}
			this.fanUp = base.transform.up;
			return this.fanUp;
		}
	}

	private bool ShouldAffect(BasePart part)
	{
		if (part is Frame)
		{
			return true;
		}
		if (part is Wings)
		{
			return true;
		}
		if (part is Tail)
		{
			return true;
		}
		if (part is Balloon)
		{
			return true;
		}
		if (part is Pig)
		{
			return part.enclosedInto == null;
		}
		return !part.contraption.PartIsConnected(part);
	}

	private void OnTriggerEnter(Collider other)
	{
		BasePart component = other.GetComponent<BasePart>();
		Rigidbody rigidbody = (!(other.tag == "Dynamic")) ? null : other.GetComponent<Rigidbody>();
		if (rigidbody == null && component != null && this.ShouldAffect(component))
		{
			rigidbody = component.rigidbody;
		}
		if (rigidbody != null && !this.affectedParts.Contains(rigidbody))
		{
			this.affectedParts.Add(rigidbody);
		}
		if (component != null)
		{
			this.partsInZone.Add(component);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		BasePart component = other.GetComponent<BasePart>();
		Rigidbody rigidbody = other.GetComponent<Rigidbody>();
		rigidbody = ((!(component != null)) ? rigidbody : component.rigidbody);
		if (rigidbody != null && this.affectedParts.Contains(rigidbody))
		{
			this.affectedParts.Remove(rigidbody);
		}
		if (component != null)
		{
			this.partsInZone.Remove(component);
		}
	}

	private void Update()
	{
		if (this.paused)
		{
			return;
		}
		switch (this.state)
		{
		case State.Inactive:
			this.Inactive();
			break;
		case State.DelayedStart:
			this.DelayedStart();
			break;
		case State.SpinUp:
			this.SpinUp();
			break;
		case State.SpinDown:
			this.SpinDown();
			break;
		case State.Spinning:
			this.Spinning();
			break;
		}
		if (this.running)
		{
			this.fanSprite.transform.Rotate(this.fanRotation * Mathf.Clamp(this.force, 0f, 10f));
		}
	}

	private void FixedUpdate()
	{
		if (!this.running)
		{
			return;
		}
		for (int i = 0; i < this.partsInZone.Count; i++)
		{
			if (this.partsInZone[i] == null)
			{
				this.partsInZone.RemoveAt(i);
			}
			else if (this.affectedParts.Contains(this.partsInZone[i].rigidbody))
			{
				this.partsInZone.RemoveAt(i);
			}
			else if (this.partsInZone[i].contraption.PartIsConnected(this.partsInZone[i]))
			{
				this.affectedParts.Add(this.partsInZone[i].rigidbody);
				this.partsInZone.RemoveAt(i);
			}
		}
		for (int j = 0; j < this.affectedParts.Count; j++)
		{
			if (this.affectedParts[j] == null)
			{
				this.affectedParts.RemoveAt(j);
			}
			else
			{
				Vector3 vector = this.CalculateForce(this.affectedParts[j].transform.position);
				this.affectedParts[j].AddForce(vector);
			}
		}
	}

	private Vector3 CalculateForce(Vector3 position)
	{
		Vector3 vector = this.NormalizePosition(position);
		float num = this.verticalRamp.Evaluate(vector.y);
		float num2 = this.horizontalRamp.Evaluate(vector.x);
		return this.fanUp * (num * num2) * this.force;
	}

	private Vector3 NormalizePosition(Vector3 position)
	{
		Vector3 vector = this.FanTop;
		Vector3 onNormal = this.FanUp;
		Vector3 result = default(Vector3);
		Vector3 b = Vector3.Project(position - vector, onNormal) + vector;
		result.y = Mathf.Clamp01((vector - b).magnitude / this.boxCollider.size.y);
		result.x = Mathf.Clamp01((position - b).magnitude / (this.boxCollider.size.x / 2f));
		result.x = Mathf.Abs(result.x -= 1f);
		return result;
	}

	private bool ContraptionInProximity()
	{
		if (this.contraptionTf == null)
		{
			this.FindContraption();
		}
		return !(this.contraptionTf == null) && (this.contraptionTf.position - base.transform.position).sqrMagnitude < this.hearingDistance;
	}

	private void FindContraption()
	{
		if (this.contraptionTf == null)
		{
			this.contraptionTf = Camera.main.transform;
		}
		if (this.contraptionTf == null)
		{
		}
	}

	public void TurnOn()
	{
		base.StartCoroutine(this.AudioFadeIn());
		this.state = State.SpinUp;
		this.running = true;
		this.particles.Play();
		ParticleSystem.EmissionModule emission = this.particles.emission;
		emission.enabled = true;
		this.counter = 0f;
	}

	public void TurnOff()
	{
		this.running = false;
		ParticleSystem.EmissionModule emission = this.particles.emission;
		emission.enabled = false;
		this.state = State.SpinDown;
		this.counter = 0f;
		for (int i = 0; i < this.spinDown.length; i++)
		{
			this.spinDown.RemoveKey(i);
		}
		this.spinDown.AddKey(new Keyframe(0f, Mathf.Clamp(this.force, 0f, 10f)));
		this.spinDown.AddKey(new Keyframe(2f, 0f));
		this.angleLeft = 360f - this.fanSprite.transform.localRotation.eulerAngles.y;
		this.angleLeft += ((this.angleLeft >= 180f) ? 0f : 180f);
		base.StartCoroutine(this.AudioFadeOut());
	}

	private void ReceiveUIEvent(UIEvent data)
	{
		UIEvent.Type type = data.type;
		if (type != UIEvent.Type.Building)
		{
			if (type != UIEvent.Type.Play)
			{
				if (type != UIEvent.Type.Pause)
				{
					if (type == UIEvent.Type.ContinueFromPause)
					{
						this.paused = false;
					}
				}
				else
				{
					this.paused = true;
				}
			}
			else
			{
				this.paused = false;
				if (!this.alwaysOn && this.delayedStart > 0f)
				{
					this.state = State.DelayedStart;
				}
				else
				{
					this.TurnOn();
				}
				this.FindContraption();
			}
		}
		else
		{
			this.TurnOff();
			this.state = State.Inactive;
			this.fanSprite.transform.localRotation = Quaternion.identity;
			this.paused = true;
		}
	}

	private void DelayedStart()
	{
		if (this.counter < this.delayedStart)
		{
			this.counter += Time.deltaTime;
		}
		else
		{
			this.TurnOn();
		}
	}

	private void SpinUp()
	{
		if (this.counter < this.startTime)
		{
			this.counter += Time.deltaTime;
			float num = this.counter / this.startTime;
			this.force = this.targetForce * Mathf.Clamp01(this.spinupRamp.Evaluate(num));
			if (this.loopingSound != null)
			{
				this.loopingSound.GetComponent<AudioSource>().volume = num;
			}
		}
		else
		{
			this.state = State.Spinning;
			this.counter = 0f;
			this.force = this.targetForce;
		}
	}

	private void SpinDown()
	{
		if (this.angleLeft > 0f && !this.running)
		{
			float num = this.spinDown.Evaluate(this.counter);
			this.fanSprite.transform.Rotate(new Vector3(0f, 1f) * num);
			this.angleLeft -= num;
			if (this.angleLeft < 3f || this.counter > 2f)
			{
				if (Mathf.Abs(this.fanSprite.transform.localRotation.eulerAngles.y - 180f) < 90f)
				{
					this.fanSprite.transform.localRotation = Quaternion.Euler(new Vector3(0f, 180f));
				}
				else
				{
					this.fanSprite.transform.localRotation = Quaternion.identity;
				}
				this.angleLeft = 0f;
			}
			this.counter += Time.deltaTime;
		}
		else
		{
			this.state = State.Inactive;
			this.counter = 0f;
			this.running = false;
		}
	}

	private void Inactive()
	{
		if (this.counter < this.offTime)
		{
			this.counter += Time.deltaTime;
		}
		else
		{
			this.TurnOn();
		}
	}

	private void Spinning()
	{
		if (this.alwaysOn)
		{
			return;
		}
		if (this.counter < this.onTime)
		{
			this.counter += Time.deltaTime;
		}
		else
		{
			this.TurnOff();
		}
	}

	private IEnumerator AudioFadeIn()
	{
		if (this.ContraptionInProximity())
		{
			Singleton<AudioManager>.Instance.SpawnOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.environmentFanStart, base.transform.position);
		}
		yield return new WaitForSeconds(0.5f);
		if (this.ContraptionInProximity())
		{
			this.loopingSound = this.audioManager.SpawnCombinedLoopingEffect(this.fanSound, base.gameObject.transform);
		}
		float time = 2f;
		float counter = 0f;
		while (counter < time && this.loopingSound != null)
		{
			counter += Time.deltaTime;
			this.loopingSound.GetComponent<AudioSource>().volume = counter / time * this.targetVolume;
			yield return null;
		}
		if (this.loopingSound != null)
		{
			this.loopingSound.GetComponent<AudioSource>().volume = this.targetVolume;
		}
		yield break;
	}

	private IEnumerator AudioFadeOut()
	{
		float time = 0.75f;
		float counter = time;
		while (counter > 0f && this.loopingSound != null)
		{
			counter -= Time.deltaTime;
			this.loopingSound.GetComponent<AudioSource>().volume = counter / time * this.targetVolume;
			yield return null;
		}
		if (this.loopingSound != null)
		{
			this.audioManager.RemoveCombinedLoopingEffect(this.fanSound, this.loopingSound);
			this.loopingSound = null;
		}
		yield break;
	}

	public GameObject fanSprite;

	public ParticleSystem particles;

	public float targetForce;

	public AnimationCurve verticalRamp;

	public AnimationCurve horizontalRamp;

	public AnimationCurve spinupRamp;

	public bool alwaysOn;

	public float delayedStart;

	public float startTime;

	public float offTime;

	public float onTime;

	public float hearingDistance = 1000f;

	public float counter;

	private float force;

	private bool running;

	private bool paused;

	private List<Rigidbody> affectedParts;

	private List<BasePart> partsInZone;

	private Vector3 fanRotation;

	private BoxCollider boxCollider;

	private AudioSource fanSound;

	private GameObject loopingSound;

	private AudioManager audioManager;

	private Vector3 fanTop;

	private Vector3 fanUp;

	private bool initialized;

	private float targetVolume;

	private Transform contraptionTf;

	private State state;

	private AnimationCurve spinDown;

	private float angleLeft;

	private const string CONTRAPTION_NAME = "Part_Pig_01_SET(Clone)(Clone)";
}
