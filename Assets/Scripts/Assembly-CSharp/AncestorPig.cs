using System.Collections.Generic;
using UnityEngine;

public class AncestorPig : WPFMonoBehaviour
{
	private void Start()
	{
		this.cachedTransform = base.transform;
		this.disappearEffect = base.transform.Find("DisappearEffect").GetComponent<ParticleSystem>();
		this.childPos = base.transform.Find("ChildPos").gameObject;
		this.graphics = base.transform.Find("Graphics").gameObject;
		this.eyes = this.graphics.transform.Find("Eyes").gameObject;
		this.pupilMover = this.graphics.transform.Find("PupilMover").gameObject;
		this.eyeAnimation = this.eyes.GetComponent<SpriteAnimation>();
		this.blinkTimer = UnityEngine.Random.Range(3f, 6f);
		EventManager.Connect(new EventManager.OnEvent<GameStateChanged>(this.OnGameStateChanged));
		if (!base.GetComponent<Collider>())
		{
			return;
		}
		float x = base.GetComponent<Collider>().bounds.extents.x;
		float y = base.GetComponent<Collider>().bounds.extents.y;
		this.collisionPoints = new List<Vector3>();
		this.collisionPoints.Add(base.transform.position);
		this.collisionPoints.Add(base.transform.TransformPoint(Vector3.right * x));
		this.collisionPoints.Add(base.transform.TransformPoint(Vector3.right * -x));
		this.collisionPoints.Add(base.transform.TransformPoint(Vector3.up * y));
		this.collisionPoints.Add(base.transform.TransformPoint(Vector3.up * -y));
	}

	private void OnDestroy()
	{
		EventManager.Disconnect(new EventManager.OnEvent<GameStateChanged>(this.OnGameStateChanged));
	}

	private void Update()
	{
		if (!this.isSeen)
		{
			this.cachedTransform.position += Vector3.zero;
			this.graphics.SetActive(true);
			base.GetComponent<Collider>().enabled = true;
			if (this.eyeAnimation)
			{
				this.blinkTimer -= Time.deltaTime;
				if (this.blinkTimer <= 0f)
				{
					switch (this.blinkTimes[this.currentBlinkTime])
					{
					case 1:
						this.eyeAnimation.Play("FastBlink");
						this.blinkTimer = 0.4f;
						goto IL_103;
					case 2:
						this.eyeAnimation.Play("SlowBlink");
						this.blinkTimer = 0.9f;
						goto IL_103;
					}
					this.eyeAnimation.Play("Normal");
					this.blinkTimer = UnityEngine.Random.Range(3f, 6f);
					IL_103:
					this.currentBlinkTime++;
					if (this.currentBlinkTime == this.blinkTimes.Length)
					{
						this.currentBlinkTime = 0;
					}
				}
				else
				{
					this.eyeAnimation.Play("Normal");
				}
				if (this.pig != null)
				{
					Vector3 a = this.pig.transform.position - base.transform.position;
					if (a.sqrMagnitude > 1f)
					{
						a.Normalize();
					}
					this.pupilMover.transform.localPosition = 0.035f * a;
				}
			}
		}
	}

	private void OnGameStateChanged(GameStateChanged newState)
	{
		if (newState.state == LevelManager.GameState.Building)
		{
			this.Recreate();
		}
		if (newState.state == LevelManager.GameState.Running)
		{
			this.Recreate();
			this.pig = WPFMonoBehaviour.levelManager.ContraptionRunning.FindPart(BasePart.PartType.Pig).gameObject;
		}
	}

	private void Recreate()
	{
		this.CreateChild();
		this.graphics.SetActive(false);
		base.GetComponent<Collider>().enabled = false;
		if (this.disappearEffect != null)
		{
			this.disappearEffect.Stop();
		}
		this.isSeen = false;
		this.blinkTimer = UnityEngine.Random.Range(3f, 6f);
	}

	private void OnTriggerEnter(Collider c)
	{
		this.CheckIfSeen(c);
	}

	private void OnTriggerStay(Collider c)
	{
		this.CheckIfSeen(c);
	}

	private void CheckIfSeen(Collider c)
	{
		LightTrigger component = c.GetComponent<LightTrigger>();
		if (component)
		{
			PointLightSource lightSource = component.LightSource;
			if (!lightSource.isEnabled)
			{
				return;
			}
			if (lightSource && lightSource.lightType == PointLightMask.LightType.PointLight)
			{
				this.Disappear();
			}
			else if (lightSource.lightType == PointLightMask.LightType.BeamLight)
			{
				if (Vector3.Distance(base.transform.position, lightSource.beamArcCenter) < lightSource.colliderSize)
				{
					this.Disappear();
				}
				else
				{
					float beamAngle = lightSource.beamAngle;
					Vector3 b = Vector3.up * c.transform.position.y + Vector3.right * c.transform.position.x;
					if (this.collisionPoints != null && this.collisionPoints.Count > 0)
					{
						foreach (Vector3 a in this.collisionPoints)
						{
							Vector3 from = a - b;
							float num = Vector3.Angle(from, lightSource.transform.up);
							float num2 = Vector3.Distance(a, b);
							if (num2 <= lightSource.baseLightSize + lightSource.borderWidth || num < beamAngle * 0.5f)
							{
								this.Disappear();
							}
						}
					}
					else
					{
						Vector3 a2 = Vector3.up * base.transform.position.y + Vector3.right * base.transform.position.x;
						Vector3 from2 = a2 - b;
						float num = Vector3.Angle(from2, lightSource.transform.up);
						float num2 = Vector3.Distance(a2, b);
						if (num2 <= lightSource.baseLightSize + lightSource.borderWidth || num < beamAngle * 0.5f)
						{
							this.Disappear();
						}
					}
				}
			}
		}
	}

	private void Disappear()
	{
		if (this.childObject && this.childObject.GetComponent<Rigidbody>())
		{
			this.childObject.GetComponent<Rigidbody>().isKinematic = false;
			this.childObject.GetComponent<Rigidbody>().WakeUp();
		}
		if (this.graphics.activeInHierarchy)
		{
			Singleton<AudioManager>.Instance.SpawnOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.ancientPigDisappear, base.transform.position);
		}
		this.graphics.SetActive(false);
		base.GetComponent<Collider>().enabled = false;
		this.disappearEffect.Play();
		this.isSeen = true;
		this.CheckForAncestorPigAchievement();
	}

	public void DestroyChildren()
	{
		if (this.childObject && this.childObject.GetComponent<Goal>())
		{
			return;
		}
		if (this.childObject != null)
		{
			this.childObject.transform.parent = null;
			UnityEngine.Object.Destroy(this.childObject);
		}
		if (this.childPos == null)
		{
			this.childPos = base.transform.Find("ChildPos").gameObject;
		}
		if (this.childPos.transform.childCount > 0)
		{
			for (int i = 0; i < this.childPos.transform.childCount; i++)
			{
				Transform child = this.childPos.transform.GetChild(i);
				child.parent = null;
				UnityEngine.Object.Destroy(child.gameObject);
			}
		}
	}

	private void CreateChild()
	{
		this.DestroyChildren();
		if (this.childPrefab == null)
		{
			SphereCollider sphereCollider = (SphereCollider)base.GetComponent<Collider>();
			float radius = sphereCollider.radius;
			LayerMask layerMask = 1 << LayerMask.NameToLayer("Light");
			RaycastHit raycastHit;
			if (Physics.SphereCast(base.transform.position - Vector3.forward * 2f, radius, Vector3.forward * 3f, out raycastHit, 3.40282347E+38f, ~layerMask.value))
			{
				Challenge componentInParent = raycastHit.collider.GetComponentInParent<Challenge>();
				if (componentInParent)
				{
					this.childObject = componentInParent.gameObject;
					if (this.childObject.GetComponent<Rigidbody>())
					{
						this.childObject.GetComponent<Rigidbody>().isKinematic = true;
					}
					this.childObject.transform.rotation = Quaternion.identity;
				}
			}
		}
		else
		{
			if (this.childPos == null)
			{
				this.childPos = base.transform.Find("ChildPos").gameObject;
			}
			this.childObject = UnityEngine.Object.Instantiate<GameObject>(this.childPrefab);
			this.childObject.name = this.childPrefab.name;
			this.childObject.transform.parent = this.childPos.transform;
			this.childObject.transform.localScale = Vector3.one;
			this.childObject.transform.localRotation = Quaternion.identity;
			if (this.childObject.GetComponent<Rigidbody>())
			{
				this.childObject.GetComponent<Rigidbody>().isKinematic = true;
			}
		}
		if (this.childObject)
		{
			this.childObject.transform.position = base.transform.position + Vector3.up * -this.childObject.GetComponent<Collider>().bounds.extents.y;
		}
	}

	public void CheckForAncestorPigAchievement()
	{
		if (Singleton<SocialGameManager>.IsInstantiated() && Singleton<GameManager>.Instance.IsInGame())
		{
			int revealedAncestorPigs = GameProgress.GetInt("Revealed_Ancestor_Pigs", 0, GameProgress.Location.Local, null) + 1;
			GameProgress.SetInt("Revealed_Ancestor_Pigs", revealedAncestorPigs, GameProgress.Location.Local);
			Singleton<SocialGameManager>.Instance.TryReportAchievementProgress("grp.SOMEONES_THERE", 100.0, (int limit) => revealedAncestorPigs > limit);
		}
	}

	private void OnDrawGizmos()
	{
	}

	public GameObject childPrefab;

	public GameObject childObject;

	[SerializeField]
	private GameObject childPos;

	private int[] blinkTimes = new int[]
	{
		2,
		2,
		0,
		1,
		2,
		0,
		1,
		2,
		1,
		0,
		2,
		1,
		2,
		0,
		2,
		2,
		2,
		3,
		2,
		1,
		2,
		0,
		1,
		2,
		1,
		0,
		2,
		2,
		2,
		0,
		2,
		1,
		2,
		0,
		2,
		1,
		2,
		0,
		1,
		1,
		3
	};

	private int currentBlinkTime;

	private GameObject graphics;

	private GameObject eyes;

	private GameObject pupilMover;

	private GameObject pig;

	private ParticleSystem disappearEffect;

	private bool isSeen;

	private SpriteAnimation eyeAnimation;

	private float blinkTimer;

	private List<Vector3> collisionPoints;

	private Transform cachedTransform;
}
