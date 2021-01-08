using UnityEngine;

public class CompactEpisodeTarget : Widget
{
	protected override void OnActivate()
	{
		if (this.episodeSelector != null)
		{
			this.episodeSelector.MoveToTargetIndex(this.elementIndex, this.isSandboxSelection);
		}
	}

	public void SetAsLastTarget()
	{
		UserSettings.SetInt(CompactEpisodeSelector.CurrentSandboxEpisodeKey, this.elementIndex);
	}

	[SerializeField]
	private int elementIndex;

	[SerializeField]
	private bool isSandboxSelection;

	public CompactEpisodeSelector episodeSelector;
}
