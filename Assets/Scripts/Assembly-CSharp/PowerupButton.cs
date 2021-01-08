using UnityEngine;

public class PowerupButton : MonoBehaviour
{
	private void Start()
	{
		this.Initialize();
	}

	private void Initialize()
	{
		if (this.initialized)
		{
			return;
		}
		this.textMeshes = base.GetComponentsInChildren<TextMesh>();
		this.initialized = true;
	}

	public void SetText(string text)
	{
		this.Initialize();
		for (int i = 0; i < this.textMeshes.Length; i++)
		{
			this.textMeshes[i].text = text;
		}
	}

	public void SetAvailable(bool available)
	{
		this.disabledIcon.SetActive(!available);
	}

	public void SetUsedState(bool used)
	{
		this.spriteAnimation.Play((!used) ? "Default" : "Used");
	}

	[SerializeField]
	private GameObject disabledIcon;

	[SerializeField]
	private SpriteAnimation spriteAnimation;

	private TextMesh[] textMeshes;

	private bool initialized;
}
