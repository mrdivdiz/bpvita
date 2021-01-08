using System;
using UnityEngine;

public class WorkshopIntro : MonoBehaviour
{
	private void Awake()
	{
		if (Singleton<GameConfigurationManager>.Instance.HasData)
		{
			this.Initialize();
		}
		else
		{
			GameConfigurationManager instance = Singleton<GameConfigurationManager>.Instance;
			instance.OnHasData = (Action)Delegate.Combine(instance.OnHasData, new Action(this.Initialize));
		}
	}

	private void Start()
	{
		this.ChangeButtonText();
	}

	private void OnEnable()
	{
		BackgroundMask.Show(true, this, "Popup", base.transform, Vector3.forward, false);
		EventManager.Send(new UIEvent(UIEvent.Type.OpenedWorkshopIntroduction));
	}

	private void OnDisable()
	{
		BackgroundMask.Show(false, this, string.Empty, null, default(Vector3), false);
		EventManager.Send(new UIEvent(UIEvent.Type.ClosedWorkshopIntroduction));
	}

	private void OnDestroy()
	{
		if (Singleton<GameConfigurationManager>.IsInstantiated())
		{
			GameConfigurationManager instance = Singleton<GameConfigurationManager>.Instance;
			instance.OnHasData = (Action)Delegate.Remove(instance.OnHasData, new Action(this.Initialize));
		}
	}

	private void Initialize()
	{
		base.GetComponent<TextDialog>().onClose += this.OnPressOk;
		this.reward = Singleton<GameConfigurationManager>.Instance.GetValue<int>("part_crafting_prices", "Common");
	}

	private void OnPressOk()
	{
		base.GetComponent<TextDialog>().onClose -= this.OnPressOk;
		int num = Mathf.Clamp(this.reward, 0, 200);
		ScrapButton.Instance.AddParticles(base.gameObject, num, 0f, (float)num);
		GameProgress.AddScrap(this.reward);
		if (WorkshopIntro.OnPressedOk != null)
		{
			WorkshopIntro.OnPressedOk();
		}
	}

	private void ChangeButtonText()
	{
		if (this.okButton == null)
		{
			return;
		}
		TextMesh component = this.okButton.GetComponent<TextMesh>();
		TextMeshLocale component2 = this.okButton.GetComponent<TextMeshLocale>();
		if (component == null || component2 == null)
		{
			return;
		}
		component2.RefreshTranslation(component.text);
		component2.enabled = false;
		component.text = string.Format(component.text, this.reward);
	}

	public static Action OnPressedOk;

	[SerializeField]
	private GameObject okButton;

	private int reward;
}
