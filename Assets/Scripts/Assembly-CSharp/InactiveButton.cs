using System.Reflection;

public class InactiveButton : WPFMonoBehaviour
{
	private void Awake()
	{
		this.cachedButton = base.GetComponent<Button>();
		if (this.cachedButton != null)
		{
			InactiveButton.SetAnimate(this.cachedButton, false);
			this.cachedButton.SetInputDelegate(new Button.InputDelegate(this.InputHandler));
		}
	}

	private void OnDestroy()
	{
		if (this.cachedButton != null)
		{
			InactiveButton.SetAnimate(this.cachedButton, true);
			this.cachedButton.RemoveInputDelegate(new Button.InputDelegate(this.InputHandler));
		}
	}

	private void InputHandler(InputEvent input)
	{
		if (input.type == InputEvent.EventType.Press)
		{
			Singleton<AudioManager>.Instance.Play2dEffect(WPFMonoBehaviour.gameData.commonAudioCollection.inactiveButton);
		}
	}

	public static void SetAnimate(Button target, bool state)
	{
		FieldInfo field = typeof(Button).GetField("animate", BindingFlags.Instance | BindingFlags.NonPublic);
		field.SetValue(target, state);
	}

	private Button cachedButton;
}
