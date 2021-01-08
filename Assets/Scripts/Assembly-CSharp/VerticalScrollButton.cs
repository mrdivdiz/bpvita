using UnityEngine;

public class VerticalScrollButton : Widget
{
	public void SetScroller(VerticalScroller scroller)
	{
		this.vScroller = scroller;
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
					if (Mathf.Abs(this.dragStartedAt - input.position.y) > this.dragStartLimit)
					{
						this.dragStartedAt = -1f;
						this.vScroller.OnDrag(input.position);
					}
				}
			}
			else
			{
				this.vScroller.OnRelease();
				if (Mathf.Abs(this.dragStartedAt - input.position.y) <= this.dragStartLimit)
				{
					base.SendMessage("VerticalScrollButtonActivate", SendMessageOptions.DontRequireReceiver);
				}
			}
		}
		else
		{
			this.vScroller.OnPress(input.position);
			this.dragStartedAt = input.position.y;
		}
	}

	[SerializeField]
	private float dragStartLimit = 0.2f;

	private float dragStartedAt = -1f;

	private VerticalScroller vScroller;
}
