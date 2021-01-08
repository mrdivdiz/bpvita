using UnityEngine;

public class VerticalScroller : Widget
{
	public float TotalHeight
	{
		get
		{
			return this.upperPadding + this.lowerPadding + this.height;
		}
	}

	public float UpperBound
	{
		get
		{
			return this.upperBound - this.upperPadding;
		}
	}

	public float LowerBound
	{
		get
		{
			return this.lowerBound;
		}
	}

	private void Awake()
	{
		this.hudCamera = WPFMonoBehaviour.hudCamera;
		if (this.lowerBound > this.upperBound)
		{
			this.lowerBound = this.upperBound;
		}
	}

	private void Update()
	{
		if (this.isDragging && Input.GetMouseButtonUp(0))
		{
			this.isDragging = false;
		}
		if (!this.isDragging)
		{
			if (this.root.transform.localPosition.y < this.UpperBound)
			{
				float d = this.UpperBound - this.root.transform.localPosition.y;
				this.Move(Vector3.up * Time.deltaTime * d * this.snapBackStrength);
			}
			else if (this.root.transform.localPosition.y > this.TotalHeight + this.LowerBound)
			{
				float d2 = this.root.transform.localPosition.y - (this.TotalHeight + this.LowerBound);
				this.Move(Vector3.down * Time.deltaTime * d2 * this.snapBackStrength);
			}
			else if (!Mathf.Approximately(this.velocity, 0f))
			{
				this.Move(Vector3.up * Time.deltaTime * this.velocity);
				if (this.velocity > 0f)
				{
					this.velocity -= Time.deltaTime * 10f;
					if (this.velocity < 0f)
					{
						this.velocity = 0f;
					}
				}
				else
				{
					this.velocity += Time.deltaTime * 10f;
					if (this.velocity > 0f)
					{
						this.velocity = 0f;
					}
				}
			}
		}
	}

	private void Move(Vector3 deltaMovement)
	{
		this.root.transform.localPosition += deltaMovement;
		for (int i = 0; i < this.followRoot.Length; i++)
		{
			this.followRoot[i].transform.localPosition += deltaMovement;
		}
	}

	public void AddHeight(float delta)
	{
		this.height += delta;
	}

	protected override void OnInput(InputEvent input)
	{
		InputEvent.EventType type = input.type;
		if (type != InputEvent.EventType.Press)
		{
			if (type != InputEvent.EventType.Release)
			{
				if (type == InputEvent.EventType.Drag)
				{
					this.OnDrag(input.position);
				}
			}
			else
			{
				this.OnRelease();
			}
		}
		else
		{
			this.OnPress(input.position);
		}
	}

	public void OnPress(Vector3 position)
	{
		if (this.isDragging)
		{
			return;
		}
		this.isDragging = true;
		this.lastPosition = this.hudCamera.ScreenToWorldPoint(position).y;
	}

	public new void OnRelease()
	{
		this.isDragging = false;
	}

	public void OnDrag(Vector3 position)
	{
		if (this.isDragging)
		{
			Vector3 vector = this.hudCamera.ScreenToWorldPoint(position);
			this.Move(Vector3.up * (vector.y - this.lastPosition));
			this.velocity = vector.y - this.lastPosition;
			this.lastPosition = vector.y;
		}
	}

	public void SetLowerPadding(float newValue)
	{
		this.lowerPadding = newValue;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.white;
		Gizmos.DrawLine(base.transform.position + Vector3.up * this.lowerBound + Vector3.left * this.width * 0.5f, base.transform.position + Vector3.up * this.upperBound + Vector3.left * this.width * 0.5f);
		Gizmos.DrawLine(base.transform.position + Vector3.up * this.lowerBound + Vector3.right * this.width * 0.5f, base.transform.position + Vector3.up * this.upperBound + Vector3.right * this.width * 0.5f);
		Gizmos.DrawLine(base.transform.position + Vector3.up * this.lowerBound + Vector3.left * this.width * 0.5f, base.transform.position + Vector3.up * this.lowerBound + Vector3.right * this.width * 0.5f);
		Gizmos.DrawLine(base.transform.position + Vector3.up * this.upperBound + Vector3.left * this.width * 0.5f, base.transform.position + Vector3.up * this.upperBound + Vector3.right * this.width * 0.5f);
	}

	[SerializeField]
	private GameObject root;

	[SerializeField]
	private GameObject[] followRoot;

	[SerializeField]
	private float upperBound = 10f;

	[SerializeField]
	private float lowerBound = -10f;

	[SerializeField]
	private float width = 10f;

	[SerializeField]
	private float upperPadding;

	[SerializeField]
	private float lowerPadding;

	[SerializeField]
	private float snapBackStrength = 10f;

	public float height;

	private Camera hudCamera;

	private bool isDragging;

	private float lastPosition;

	private float velocity;
}
