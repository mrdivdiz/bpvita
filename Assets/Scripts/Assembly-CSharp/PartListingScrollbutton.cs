using System;
using UnityEngine;

public class PartListingScrollbutton : Widget
{
	private void Update()
	{
		if (!this.interacting)
		{
			base.transform.position = this.graphicsTf.position + Vector3.back;
		}
	}

	protected override void OnInput(InputEvent input)
	{
		if (input.type == InputEvent.EventType.Drag && !this.interacting)
		{
			this.interacting = true;
			if (this.OnDragBegin != null)
			{
				this.OnDragBegin();
			}
		}
		if (input.type == InputEvent.EventType.Drag)
		{
			Vector3 vector = WPFMonoBehaviour.hudCamera.ScreenToWorldPoint(input.position);
			vector = base.transform.parent.InverseTransformPoint(vector);
			vector.z = -1f;
			base.transform.localPosition = vector;
			if (this.OnDrag != null)
			{
				this.OnDrag(vector.x);
			}
		}
		if (input.type == InputEvent.EventType.Release && this.interacting)
		{
			this.interacting = false;
			if (this.OnDragEnd != null)
			{
				this.OnDragEnd();
			}
		}
		this.lastEvent = input.type;
		this.receivingInput = true;
	}

	private void LateUpdate()
	{
		if (!this.receivingInput && this.lastEvent != InputEvent.EventType.Release)
		{
			this.OnInput(new InputEvent(InputEvent.EventType.Release, Input.mousePosition));
		}
		else
		{
			this.receivingInput = false;
		}
	}

	[SerializeField]
	private Transform graphicsTf;

	public Action<float> OnDrag;

	public Action OnDragBegin;

	public Action OnDragEnd;

	private bool interacting;

	private bool receivingInput;

	private InputEvent.EventType lastEvent;
}
