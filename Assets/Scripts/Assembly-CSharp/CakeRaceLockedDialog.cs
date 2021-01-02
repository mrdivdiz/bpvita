using UnityEngine;

public class CakeRaceLockedDialog : TextDialog
{
	public new void Close()
	{
		base.Close();
	}

	public void SetLevelRequirement(int levelRequirement)
	{
		Localizer.LocaleParameters localeParameters = Singleton<Localizer>.Instance.Resolve(this.descriptionKey, null);
		if (localeParameters.translation.Contains("{0}"))
		{
			TextMeshHelper.UpdateTextMeshes(this.descriptionLabel, string.Format(localeParameters.translation, levelRequirement), false);
		}
		else
		{
			TextMeshHelper.UpdateTextMeshes(this.descriptionLabel, localeParameters.translation, false);
		}
		TextMeshHelper.Wrap(this.descriptionLabel, (!TextMeshHelper.UsesKanjiCharacters()) ? 16 : 8);
		TextMeshHelper.UpdateTextMeshes(this.levelRequirementLabel, levelRequirement.ToString(), false);
	}

	[SerializeField]
	private TextMesh[] levelRequirementLabel;

	[SerializeField]
	private TextMesh[] descriptionLabel;

	[SerializeField]
	private string descriptionKey;
}
