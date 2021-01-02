using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class LevelRigidbody : WPFMonoBehaviour
{
	private void Awake()
	{
		this.m_transform = base.transform;
		this.m_hingeJoint = base.GetComponent<HingeJoint>();
		this.m_fixedJoint = base.GetComponent<FixedJoint>();
		this.m_iceMaterial = Resources.Load<PhysicMaterial>("Ground_PhysMat_Ice");
		this.m_icePartLayer = LayerMask.NameToLayer("IcePart");
		EventManager.Connect(new EventManager.OnEvent<GameStateChanged>(this.OnGameStateChanged));
	}

	private void OnDataLoaded()
	{
		if (this.isDataLoaded)
		{
			return;
		}
		this.isDataLoaded = true;
		if (this.lockPosition)
		{
			base.gameObject.layer = LayerMask.NameToLayer("FixedRigidbody");
		}
		this.SaveState();
		this.LoadState();
		base.rigidbody.isKinematic = this.freezeOnEnd;
	}

	private void OnDestroy()
	{
		EventManager.Disconnect(new EventManager.OnEvent<GameStateChanged>(this.OnGameStateChanged));
	}

	private void OnGameStateChanged(GameStateChanged newState)
	{
		if (newState.state == LevelManager.GameState.Running && this.lastTrackedState == LevelManager.GameState.Building)
		{
			this.ResetRigidbody();
			if (WPFMonoBehaviour.levelManager.HasGroundIce)
			{
				this.UpdateIceCollider();
			}
		}
		else if ((newState.state == LevelManager.GameState.Building || newState.state == LevelManager.GameState.ShowingUnlockedParts) && (this.lastTrackedState == LevelManager.GameState.Running || this.lastTrackedState == LevelManager.GameState.PausedWhileRunning))
		{
			this.EndLevel();
		}
		this.lastTrackedState = newState.state;
	}

	private void SaveState()
	{
		this.m_originalPosition = base.transform.localPosition;
		this.m_originalRotation = base.transform.localRotation;
		this.m_originalIsKinematic = base.rigidbody.isKinematic;
		if (this.m_hingeJoint)
		{
			if (this.m_originalHingeJointValues == null)
			{
				this.m_originalHingeJointValues = new HingeJointValues();
			}
			this.m_originalHingeJointValues.connectedBody = this.m_hingeJoint.connectedBody;
			this.m_originalHingeJointValues.anchor = this.m_hingeJoint.anchor;
			this.m_originalHingeJointValues.axis = this.m_hingeJoint.axis;
			this.m_originalHingeJointValues.connectedAnchor = this.m_hingeJoint.connectedAnchor;
			this.m_originalHingeJointValues.autoConfigureConnectedAnchor = this.m_hingeJoint.autoConfigureConnectedAnchor;
			this.m_originalHingeJointValues.useMotor = this.m_hingeJoint.useMotor;
			this.m_originalHingeJointValues.motor = this.m_hingeJoint.motor;
			this.m_originalHingeJointValues.useSpring = this.m_hingeJoint.useSpring;
			this.m_originalHingeJointValues.spring = this.m_hingeJoint.spring;
			this.m_originalHingeJointValues.useLimits = this.m_hingeJoint.useLimits;
			this.m_originalHingeJointValues.limits = this.m_hingeJoint.limits;
			this.m_originalHingeJointValues.breakForce = this.m_hingeJoint.breakForce;
			this.m_originalHingeJointValues.breakTorque = this.m_hingeJoint.breakTorque;
			this.m_originalHingeJointValues.enableCollision = this.m_hingeJoint.enableCollision;
			this.m_originalHingeJointValues.enablePreprocessing = this.m_hingeJoint.enablePreprocessing;
		}
	}

	private void LoadState()
	{
		if (base.gameObject != null && base.gameObject.activeInHierarchy)
		{
			base.StartCoroutine(this.LoadStateRoutine());
		}
	}

	private IEnumerator LoadStateRoutine()
	{
		this.ResetRigidbody();
		this.ResetTransform();
		yield return new WaitForFixedUpdate();
		this.ResetJoints();
		this.ResetEffects();
		yield break;
	}

	private void EndLevel()
	{
		this.LoadState();
		base.rigidbody.isKinematic = this.freezeOnEnd;
	}

	private void ResetRigidbody()
	{
		if (this == null)
		{
			return;
		}
		base.rigidbody.Sleep();
		base.rigidbody.isKinematic = this.m_originalIsKinematic;
		if (!this.m_originalIsKinematic)
		{
			base.rigidbody.WakeUp();
		}
		this.m_broken = false;
	}

	private void ResetTransform()
	{
		this.m_transform = (this.m_transform ?? base.transform);
		bool isKinematic = base.rigidbody.isKinematic;
		base.rigidbody.isKinematic = true;
		this.m_transform.localPosition = this.m_originalPosition;
		this.m_transform.localRotation = this.m_originalRotation;
		base.rigidbody.isKinematic = isKinematic;
	}

	private void ResetJoints()
	{
		if (this.lockPosition)
		{
			if (this.m_fixedJoint == null)
			{
				this.m_fixedJoint = base.gameObject.AddComponent<FixedJoint>();
			}
			this.m_fixedJoint.breakForce = this.breakForce;
			this.m_fixedJoint.enablePreprocessing = false;
		}
		if (this.m_hingeJoint == null && this.m_originalHingeJointValues != null)
		{
			this.m_hingeJoint = base.gameObject.AddComponent<HingeJoint>();
		}
		if (this.m_originalHingeJointValues == null || this.m_hingeJoint == null)
		{
			return;
		}
		this.m_hingeJoint.autoConfigureConnectedAnchor = this.m_originalHingeJointValues.autoConfigureConnectedAnchor;
		this.m_hingeJoint.connectedBody = this.m_originalHingeJointValues.connectedBody;
		this.m_hingeJoint.anchor = this.m_originalHingeJointValues.anchor;
		this.m_hingeJoint.axis = this.m_originalHingeJointValues.axis;
		this.m_hingeJoint.connectedAnchor = this.m_originalHingeJointValues.connectedAnchor;
		this.m_hingeJoint.motor = this.m_originalHingeJointValues.motor;
		this.m_hingeJoint.useMotor = this.m_originalHingeJointValues.useMotor;
		this.m_hingeJoint.spring = this.m_originalHingeJointValues.spring;
		this.m_hingeJoint.useSpring = this.m_originalHingeJointValues.useSpring;
		this.m_hingeJoint.limits = this.m_originalHingeJointValues.limits;
		this.m_hingeJoint.useLimits = this.m_originalHingeJointValues.useLimits;
		this.m_hingeJoint.breakForce = this.m_originalHingeJointValues.breakForce;
		this.m_hingeJoint.breakTorque = this.m_originalHingeJointValues.breakTorque;
		this.m_hingeJoint.enableCollision = this.m_originalHingeJointValues.enableCollision;
		this.m_hingeJoint.enablePreprocessing = this.m_originalHingeJointValues.enablePreprocessing;
	}

	private void ResetEffects()
	{
		if (this.breakEffect == null)
		{
			return;
		}
		this.breakEffect.transform.parent = base.transform;
		this.breakEffect.transform.localPosition = Vector3.zero;
		this.breakEffect.Stop();
	}

	private void UpdateIceCollider()
	{
		if (!this.m_createIceColliders)
		{
			return;
		}
		if (this.m_iceColliders == null)
		{
			this.m_normalColliders = new List<Collider>(base.gameObject.GetComponentsInChildren<Collider>(true));
			this.m_iceColliders = new List<Transform>();
			for (int i = 0; i < this.m_normalColliders.Count; i++)
			{
				if (this.m_normalColliders[i].gameObject.layer == LayerMask.NameToLayer("Light") || this.m_normalColliders[i].gameObject.layer == LayerMask.NameToLayer("Mouth") || this.m_normalColliders[i].isTrigger)
				{
					this.m_normalColliders.RemoveAt(i--);
				}
				else
				{
					Collider collider = new GameObject("IceCollider_" + i)
					{
						transform = 
						{
							parent = this.m_normalColliders[i].transform,
							localScale = Vector3.one,
							localPosition = Vector3.zero,
							localRotation = Quaternion.identity
						},
						layer = this.m_icePartLayer
					}.AddComponent(this.m_normalColliders[i].GetType()) as Collider;
					if (collider != null)
					{
						this.m_iceColliders.Add(collider.transform);
					}
				}
			}
		}
		bool flag = false;
		foreach (Transform transform in this.m_iceColliders)
		{
			if (transform.GetComponent<Collider>() != null)
			{
				UnityEngine.Object.Destroy(transform.GetComponent<Collider>());
				flag = true;
			}
		}
		for (int j = 0; j < this.m_iceColliders.Count; j++)
		{
			if (this.m_normalColliders[j] is SphereCollider)
			{
				SphereCollider sphereCollider = this.m_iceColliders[j].GetComponent<Collider>() as SphereCollider;
				if (sphereCollider == null || flag)
				{
					sphereCollider = this.m_iceColliders[j].gameObject.AddComponent<SphereCollider>();
					sphereCollider.radius = ((!(this.m_normalColliders[j] as SphereCollider == null)) ? (this.m_normalColliders[j] as SphereCollider).radius : 0.5f);
					sphereCollider.center = ((!(this.m_normalColliders[j] as SphereCollider == null)) ? (this.m_normalColliders[j] as SphereCollider).center : Vector3.zero);
				}
				if (sphereCollider != null)
				{
					sphereCollider.sharedMaterial = this.m_iceMaterial;
				}
			}
			else if (this.m_normalColliders[j] is BoxCollider)
			{
				BoxCollider boxCollider = this.m_iceColliders[j].GetComponent<Collider>() as BoxCollider;
				if (boxCollider == null || flag)
				{
					boxCollider = this.m_iceColliders[j].gameObject.AddComponent<BoxCollider>();
					boxCollider.size = (this.m_normalColliders[j] as BoxCollider).size;
					boxCollider.center = (this.m_normalColliders[j] as BoxCollider).center;
				}
				if (boxCollider != null)
				{
					boxCollider.sharedMaterial = this.m_iceMaterial;
				}
			}
			else if (this.m_normalColliders[j] is CapsuleCollider)
			{
				CapsuleCollider capsuleCollider = this.m_iceColliders[j].GetComponent<Collider>() as CapsuleCollider;
				if (capsuleCollider == null || flag)
				{
					capsuleCollider = this.m_iceColliders[j].gameObject.AddComponent<CapsuleCollider>();
					capsuleCollider.center = (this.m_normalColliders[j] as CapsuleCollider).center;
					capsuleCollider.radius = (this.m_normalColliders[j] as CapsuleCollider).radius;
					capsuleCollider.height = (this.m_normalColliders[j] as CapsuleCollider).height;
					capsuleCollider.direction = (this.m_normalColliders[j] as CapsuleCollider).direction;
				}
				if (capsuleCollider != null)
				{
					capsuleCollider.sharedMaterial = this.m_iceMaterial;
				}
			}
		}
	}

	protected void OnCollisionEnter(Collision c)
	{
		float num = 0f;
		foreach (ContactPoint contactPoint in c.contacts)
		{
			float num2 = Vector3.Dot(c.relativeVelocity, contactPoint.normal);
			if (num2 > num)
			{
				num = num2;
			}
		}
		if (!this.breakOnlyByGoldenPig && !this.breakOnlyByBird)
		{
			this.Break(num);
		}
		if (!this.lockPosition && Time.time - this.m_lastTimePlayedSFX > 0.25f)
		{
			this.PlayCollisionSFX(c);
		}
	}

	public void OnTriggerEnter(Collider other)
	{
		GoldenPig component = other.GetComponent<GoldenPig>();
		Bird component2 = other.GetComponent<Bird>();
		if ((this.breakOnlyByGoldenPig && component) || (this.breakOnlyByBird && component2))
		{
			this.Break(1f);
		}
	}

	public void Break(float collisionSpeed)
	{
		if ((!this.m_broken && !this.lockPosition && collisionSpeed > this.breakForce) || (this.lockPosition && this.m_fixedJoint == null))
		{
			this.m_broken = true;
			if (this.breakEffect != null)
			{
				this.breakEffect.transform.parent = null;
				this.breakEffect.Play();
			}
			this.PlayBreakSFX();
			base.rigidbody.isKinematic = true;
			if (this.chainReactionBreaking)
			{
				Collider[] array = Physics.OverlapSphere(base.transform.position, 2f);
				foreach (Collider collider in array)
				{
					LevelRigidbody component = collider.GetComponent<LevelRigidbody>();
					if (component)
					{
						component.Break(collisionSpeed);
					}
				}
			}
			base.transform.position = -Vector3.up * 1000f;
		}
	}

	protected void PlayBreakSFX()
	{
		AudioSource[] array = null;
		if (this.isRock)
		{
			array = WPFMonoBehaviour.gameData.commonAudioCollection.collisionRockBreak;
		}
		if (array != null)
		{
			Singleton<AudioManager>.Instance.SpawnOneShotEffect(array, base.transform.position);
		}
	}

	protected void PlayCollisionSFX(Collision collisionData)
	{
		AudioSource[] array = null;
		AudioSource[] array2 = null;
		AudioManager.AudioMaterial audioMaterial = this.audioMaterial;
		if (audioMaterial != AudioManager.AudioMaterial.Metal)
		{
			if (audioMaterial != AudioManager.AudioMaterial.Wood)
			{
				array = null;
				array2 = null;
			}
			else
			{
				array = WPFMonoBehaviour.gameData.commonAudioCollection.collisionWoodHit;
				array2 = WPFMonoBehaviour.gameData.commonAudioCollection.collisionWoodDamage;
			}
		}
		else
		{
			array = WPFMonoBehaviour.gameData.commonAudioCollection.collisionMetalHit;
			array2 = WPFMonoBehaviour.gameData.commonAudioCollection.collisionMetalDamage;
		}
		if (array != null && array2 != null)
		{
			float num = 0f;
			Vector3 soundPosition = Vector3.zero;
			IEnumerator enumerator = collisionData.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					ContactPoint contactPoint = (ContactPoint)obj;
					float num2 = Vector3.Dot(collisionData.relativeVelocity, contactPoint.normal);
					if (num2 > num)
					{
						num = num2;
						soundPosition = contactPoint.point;
					}
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
			if (num > 8f)
			{
				Singleton<AudioManager>.Instance.SpawnOneShotEffect(array2, soundPosition);
				this.m_lastTimePlayedSFX = Time.time;
			}
			else if (num > 2.5f)
			{
				AudioSource audioSource = Singleton<AudioManager>.Instance.SpawnOneShotEffect(array, soundPosition);
				this.m_lastTimePlayedSFX = Time.time;
				if (audioSource)
				{
					audioSource.volume = (num - 2f) / 8f;
				}
			}
		}
	}

	public float breakForce = float.PositiveInfinity;

	public bool breakOnlyByGoldenPig;

	public bool breakOnlyByBird;

	public bool chainReactionBreaking;

	public ParticleSystem breakEffect;

	public bool lockPosition;

	public bool freezeOnEnd = true;

	public AudioManager.AudioMaterial audioMaterial;

	public bool isRock;

	private bool m_originalIsKinematic;

	protected Vector3 m_originalPosition = Vector3.zero;

	protected Quaternion m_originalRotation = Quaternion.identity;

	private float m_lastTimePlayedSFX;

	private FixedJoint m_fixedJoint;

	protected HingeJointValues m_originalHingeJointValues;

	protected HingeJoint m_hingeJoint;

	protected Transform m_transform;

	private List<Collider> m_normalColliders;

	private List<Transform> m_iceColliders;

	private int m_icePartLayer;

	private PhysicMaterial m_iceMaterial;

	[SerializeField]
	private bool m_broken;

	[SerializeField]
	private bool m_createIceColliders;

	private LevelManager.GameState lastTrackedState;

	private bool isDataLoaded;

	protected class HingeJointValues
	{
		public Rigidbody connectedBody;

		public Vector3 anchor;

		public Vector3 axis;

		public Vector3 connectedAnchor;

		public bool autoConfigureConnectedAnchor;

		public bool useMotor;

		public JointMotor motor;

		public bool useSpring;

		public JointSpring spring;

		public bool useLimits;

		public JointLimits limits;

		public float breakForce;

		public float breakTorque;

		public bool enableCollision;

		public bool enablePreprocessing;
	}
}
