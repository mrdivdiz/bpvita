using System.Collections;
using UnityEngine;

public class PullButton : Widget
{
	private void Awake()
	{
		this.hudCamera = GameObject.Find("HUDCamera").GetComponent<Camera>();
	}

	private void Update()
	{
		if (!this.isDragging && !this.isLocked)
		{
            PullType pullType = this.pullType;
			if (pullType != PullButton.PullType.Position)
			{
				if (pullType == PullButton.PullType.Rotation)
				{
					float num = this.targetTf.localEulerAngles.z;
					if (num > 0f)
					{
						num -= 360f;
					}
					this.targetTf.localEulerAngles = Vector3.Slerp(Vector3.forward * num, this.originalPosition, Time.deltaTime * 20f);
				}
			}
			else
			{
				this.targetTf.localPosition = Vector3.Lerp(this.targetTf.localPosition, this.originalPosition, Time.deltaTime * 20f);
			}
		}
	}

	public void LockDragging(bool lockDragging)
	{
		this.isLocked = lockDragging;
	}

	public void SetPositionOffset(Vector3 positionOffset)
	{
        PullType pullType = this.pullType;
		if (pullType != PullButton.PullType.Position)
		{
			if (pullType == PullButton.PullType.Rotation)
			{
				this.targetTf.localEulerAngles = this.originalPosition + positionOffset;
			}
		}
		else
		{
			this.targetTf.localPosition = this.originalPosition + positionOffset;
		}
	}

	protected override void OnInput(InputEvent input)
	{
		base.OnInput(input);
		if (this.isLocked)
		{
			return;
		}
		if (input.type == InputEvent.EventType.Press)
		{
			this.touchStartTime = Time.realtimeSinceStartup;
			this.lastPosition = this.hudCamera.ScreenToWorldPoint(input.position);
			this.isDragging = true;
		}
		else if (input.type == InputEvent.EventType.Release)
		{
			if (Time.realtimeSinceStartup - this.touchStartTime < this.tapTresholdTime)
			{
				base.StartCoroutine(this.ActivateSequence());
			}
			this.isDragging = false;
		}
		else if (input.type == InputEvent.EventType.Drag && this.isDragging)
		{
			Vector3 vector = this.hudCamera.ScreenToWorldPoint(input.position);
			float num = (vector.y - this.lastPosition.y) * this.dragScale;
			this.lastPosition = vector;
            PullType pullType = this.pullType;
			if (pullType != PullButton.PullType.Position)
			{
				if (pullType == PullButton.PullType.Rotation)
				{
					float num2 = this.targetTf.localEulerAngles.z;
					if (num2 > 0f)
					{
						num2 -= 360f;
					}
					float num3 = num2 + num;
					if (num3 < this.activatePosition.z)
					{
						this.targetTf.localEulerAngles = this.activatePosition;
						this.Activate();
					}
					else if (num3 > this.originalPosition.z)
					{
						this.targetTf.localEulerAngles = this.originalPosition;
					}
					else
					{
						this.targetTf.localEulerAngles = Vector3.forward * num3;
					}
				}
			}
			else
			{
				this.targetTf.Translate(Vector3.up * num);
				if (this.targetTf.localPosition.y < this.activatePosition.y)
				{
					this.targetTf.localPosition = this.activatePosition;
					this.Activate();
				}
				else if (this.targetTf.localPosition.y > this.originalPosition.y)
				{
					this.targetTf.localPosition = this.originalPosition;
				}
			}
		}
		else if (input.type == InputEvent.EventType.MouseLeave && this.isDragging)
		{
			this.isDragging = false;
		}
	}

	public bool IsActivating()
	{
		return this.isActivating;
	}

	private IEnumerator ActivateSequence()
	{
		if (this.isLocked)
		{
			yield break;
		}
		if (this.pullStartAudio)
		{
			this.pullStartAudio.Play2dEffect();
		}
		this.isLocked = true;
		this.isActivating = true;
		yield return null;
		this.isDragging = true;
		float fade = 1f;
		while (fade > 0f)
		{
			fade -= Time.deltaTime * 3f;
            PullType pullType = this.pullType;
			if (pullType != PullButton.PullType.Position)
			{
				if (pullType == PullButton.PullType.Rotation)
				{
					this.targetTf.localEulerAngles = Vector3.Slerp(this.activatePosition, this.originalPosition, fade);
				}
			}
			else
			{
				this.targetTf.localPosition = Vector3.Lerp(this.activatePosition, this.originalPosition, fade);
			}
			yield return null;
		}
		this.isActivating = false;
		this.Activate();
		this.isLocked = false;
		yield break;
	}

	private new void Activate()
	{
		this.isDragging = false;
		if (this.callObject != null && !string.IsNullOrEmpty(this.methodToCall))
		{
			this.callObject.SendMessage(this.methodToCall, SendMessageOptions.DontRequireReceiver);
		}
		if (this.pullEndAudio)
		{
			this.pullEndAudio.Play2dEffect();
		}
	}

	[SerializeField]
	private PullType pullType;

	[SerializeField]
	private GameObject callObject;

	[SerializeField]
	private string methodToCall;

	[SerializeField]
	private Transform targetTf;

	[SerializeField]
	private Vector3 originalPosition;

	[SerializeField]
	private Vector3 activatePosition;

	[SerializeField]
	private float tapTresholdTime = 0.1f;

	[SerializeField]
	private float dragScale = 1f;

	[SerializeField]
	private PlayBundleAudio pullStartAudio;

	[SerializeField]
	private PlayBundleAudio pullEndAudio;

	private bool isDragging;

	private bool isLocked;

	private Vector3 lastPosition;

	private Camera hudCamera;

	private float touchStartTime;

	private bool isActivating;

	public enum PullType
	{
		Position,
		Rotation
	}
}
