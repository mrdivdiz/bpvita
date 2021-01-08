using UnityEngine;

[RequireComponent(typeof(Button))]
public class ButtonSwipe : MonoBehaviour
{
	private void OnEnable()
	{
		this.m_button = base.GetComponent<Button>();
		this.m_button.SetInputDelegate(new Button.InputDelegate(this.OnButtonInput));
		if (this.m_disableButtonRelease)
		{
			this.m_button.SetActivateOnRelease(false);
		}
	}

	private void OnButtonInput(InputEvent input)
	{
		if (input.type == InputEvent.EventType.Press)
		{
			this.m_dragStart = input.position;
		}
		if (input.type == InputEvent.EventType.Drag)
		{
			Vector3 vector = input.position - this.m_dragStart;
			vector /= (float)Screen.height;
			float num;
			if (this.m_directional)
			{
				num = Vector3.Dot(this.m_direction.normalized, vector);
			}
			else
			{
				num = vector.magnitude;
			}
			if (num > this.m_thresholdDistance)
			{
				this.m_button.Activate();
			}
		}
	}

	public bool m_directional = true;

	public Vector3 m_direction;

	public float m_thresholdDistance = 0.3f;

	public bool m_disableButtonRelease;

	private Button m_button;

	private Vector3 m_dragStart;
}
