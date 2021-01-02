using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class LevelBalloon : WPFMonoBehaviour
{
	private void Start()
	{
		if (!this.useTargetAltitude)
		{
			this.targetAltitude = base.transform.position.y;
		}
		this.ropeVisual = base.GetComponent<RopeVisualization>();
		this.collected = false;
		this.rope = base.GetComponent<SpringJoint>();
		if (this.box.IsDisabled())
		{
			UnityEngine.Object.Destroy(base.transform.parent.gameObject);
			return;
		}
		this.partBox = (this.box as PartBox);
		this.starBox = (this.box as StarBox);
		if (this.partBox != null)
		{
			this.partBox.onCollect += this.PartBoxCollected;
		}
		else if (this.starBox != null)
		{
			this.starBox.onCollect += this.StarBoxCollected;
		}
		this.SaveState();
		EventManager.Connect(new EventManager.OnEvent<GameStateChanged>(this.OnGameStateChanged));
	}

	private void OnDestroy()
	{
		if (this.partBox != null)
		{
			this.partBox.onCollect -= this.PartBoxCollected;
		}
		else if (this.starBox != null)
		{
			this.starBox.onCollect -= this.StarBoxCollected;
		}
		EventManager.Disconnect(new EventManager.OnEvent<GameStateChanged>(this.OnGameStateChanged));
	}

	private void FixedUpdate()
	{
		if (this.collected || base.transform.position.y < this.targetAltitude)
		{
			base.rigidbody.AddForce(Vector3.up * this.upForce);
		}
		else
		{
			float d = Mathf.Abs(base.transform.position.y - this.targetAltitude - 1f) / 1f;
			base.rigidbody.AddForce(Vector3.up * this.upForce * d);
		}
	}

	private void PartBoxCollected(PartBox partbox)
	{
		this.collected = true;
		if (this.popOnCollect)
		{
			this.Pop();
		}
		else
		{
			this.Detach();
		}
	}

	private void StarBoxCollected()
	{
		this.PartBoxCollected(null);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.relativeVelocity.magnitude > this.breakForce)
		{
			this.Detach();
			this.Pop();
		}
	}

	private void OnGameStateChanged(GameStateChanged newState)
	{
		LevelManager.GameState state = newState.state;
		if (state == LevelManager.GameState.Running || state == LevelManager.GameState.ShowingUnlockedParts || state == LevelManager.GameState.Building)
		{
			this.LoadState();
		}
	}

	[ContextMenu("Pop")]
	private void Pop()
	{
		Singleton<AudioManager>.Instance.SpawnOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.balloonPop, base.transform.position);
		WPFMonoBehaviour.effectManager.CreateParticles(WPFMonoBehaviour.gameData.m_ballonParticles, base.transform.position, false);
		base.gameObject.SetActive(false);
	}

	private void Detach()
	{
		UnityEngine.Object.Destroy(this.rope);
		this.ropeVisual.enabled = false;
	}

	private void SaveState()
	{
		this.origPosition = base.transform.position;
		this.origRotation = base.transform.rotation;
		this.SaveSpringJointValues();
	}

	private void LoadState()
	{
		base.transform.position = this.origPosition;
		base.transform.rotation = this.origRotation;
		base.gameObject.SetActive(true);
		this.ropeVisual.enabled = true;
		this.collected = false;
		this.LoadSpringJointValues();
	}

	private void SaveSpringJointValues()
	{
		this.springJointValues = new SpringJointValues();
		this.springJointValues.autoConfigureConnectedAnchor = this.rope.autoConfigureConnectedAnchor;
		this.springJointValues.anchor = this.rope.anchor;
		this.springJointValues.breakForce = this.rope.breakForce;
		this.springJointValues.breakTorque = this.rope.breakTorque;
		this.springJointValues.connectedAnchor = this.rope.connectedAnchor;
		this.springJointValues.connectedRigidbody = this.rope.connectedBody;
		this.springJointValues.enableCollision = this.rope.enableCollision;
		this.springJointValues.maxDistance = this.rope.maxDistance;
		this.springJointValues.minDistance = this.rope.minDistance;
		this.springJointValues.damper = this.rope.damper;
	}

	private void LoadSpringJointValues()
	{
		if (this.rope == null)
		{
			this.rope = base.gameObject.AddComponent<SpringJoint>();
		}
		this.rope.autoConfigureConnectedAnchor = this.springJointValues.autoConfigureConnectedAnchor;
		this.rope.anchor = this.springJointValues.anchor;
		this.rope.breakForce = this.springJointValues.breakForce;
		this.rope.breakTorque = this.springJointValues.breakTorque;
		this.rope.connectedAnchor = this.springJointValues.connectedAnchor;
		this.rope.connectedBody = this.springJointValues.connectedRigidbody;
		this.rope.enableCollision = this.springJointValues.enableCollision;
		this.rope.maxDistance = this.springJointValues.maxDistance;
		this.rope.minDistance = this.springJointValues.minDistance;
		this.rope.damper = this.springJointValues.damper;
	}

	public bool popOnCollect;

	public bool useTargetAltitude;

	public float targetAltitude;

	public float upForce;

	public float breakForce;

	public OneTimeCollectable box;

	private SpringJoint rope;

	private RopeVisualization ropeVisual;

	private bool collected;

	private PartBox partBox;

	private StarBox starBox;

	private SpringJointValues springJointValues;

	private Vector3 origPosition;

	private Quaternion origRotation;
}
