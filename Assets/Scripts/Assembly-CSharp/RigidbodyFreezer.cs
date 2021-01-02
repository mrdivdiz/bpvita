using UnityEngine;

public class RigidbodyFreezer : WPFMonoBehaviour
{
	private void Start()
	{
		EventManager.Connect(new EventManager.OnEvent<UIEvent>(this.ReceiveUIEvent));
		this.frozen = false;
		this.rigidbodies = base.GetComponentsInChildren<Rigidbody>(true);
		this.origConstraints = new RigidbodyConstraints[this.rigidbodies.Length];
		for (int i = 0; i < this.rigidbodies.Length; i++)
		{
			this.origConstraints[i] = this.rigidbodies[i].constraints;
		}
	}

	private void OnDestroy()
	{
		EventManager.Disconnect(new EventManager.OnEvent<UIEvent>(this.ReceiveUIEvent));
	}

	private void Update()
	{
		this.CheckDistance();
	}

	private void ReceiveUIEvent(UIEvent data)
	{
		UIEvent.Type type = data.type;
		if (type == UIEvent.Type.Play)
		{
			this.Freeze();
			this.FindContraption();
		}
	}

	private void FindContraption()
	{
		if (this.contraptionTf == null)
		{
			BasePart basePart = WPFMonoBehaviour.levelManager.ContraptionRunning.FindPart(BasePart.PartType.Pig);
			if (basePart)
			{
				this.contraptionTf = basePart.transform;
			}
		}
		if (this.contraptionTf == null)
		{
		}
	}

	private void Freeze()
	{
		for (int i = 0; i < this.rigidbodies.Length; i++)
		{
			if (this.rigidbodies[i])
			{
				this.rigidbodies[i].constraints = RigidbodyConstraints.FreezeAll;
				this.rigidbodies[i].Sleep();
			}
		}
		this.frozen = true;
	}

	private void Unfreeze()
	{
		for (int i = 0; i < this.rigidbodies.Length; i++)
		{
			this.rigidbodies[i].constraints = this.origConstraints[i];
			this.rigidbodies[i].WakeUp();
		}
		this.frozen = false;
	}

	private void CheckDistance()
	{
		if (this.contraptionTf == null || (this.unfreezeOnce && !this.frozen))
		{
			return;
		}
		if ((this.contraptionTf.position - base.transform.position).sqrMagnitude < this.sqrDistanceLimit)
		{
			if (!this.frozen)
			{
				return;
			}
			this.Unfreeze();
		}
		else
		{
			if (this.frozen)
			{
				return;
			}
			this.Freeze();
		}
	}

	public float sqrDistanceLimit = 500f;

	public bool unfreezeOnce = true;

	private const string CONTRAPTION_NAME = "Part_Pig_01_SET(Clone)(Clone)";

	private Transform contraptionTf;

	private Rigidbody[] rigidbodies;

	private RigidbodyConstraints[] origConstraints;

	private bool frozen;
}
