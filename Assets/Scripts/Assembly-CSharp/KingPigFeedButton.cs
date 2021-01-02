using UnityEngine;

public class KingPigFeedButton : Button
{
	public static int LastDessertCount
	{
		get
		{
			return GameProgress.GetInt("LastDessertCount", 0, GameProgress.Location.Local, null);
		}
		set
		{
			GameProgress.SetInt("LastDessertCount", value, GameProgress.Location.Local);
		}
	}

	protected override void ButtonAwake()
	{
		this.CheckWiggle();
		EventManager.Connect(new EventManager.OnEvent<UIEvent>(this.OnUIEvent));
	}

	private void OnDestroy()
	{
		EventManager.Disconnect(new EventManager.OnEvent<UIEvent>(this.OnUIEvent));
	}

	private void CheckWiggle()
	{
		bool @bool = GameProgress.GetBool("ChiefPigExploded", false, GameProgress.Location.Local, null);
		bool bool2 = GameProgress.GetBool("Kingpig_Visited", false, GameProgress.Location.Local, null);
		if (!Singleton<BuildCustomizationLoader>.Instance.IsChina)
		{
			base.gameObject.SetActive(@bool);
		}
		if (!bool2 || (this.HasDesserts() && KingPigFeedButton.LastDessertCount != KingPigFeedButton.CurrentDessertCount()))
		{
			this.Wiggle();
		}
	}

	private bool HasDesserts()
	{
		for (int i = 0; i < WPFMonoBehaviour.gameData.m_desserts.Count; i++)
		{
			if (GameProgress.DessertCount(WPFMonoBehaviour.gameData.m_desserts[i].name) > 0)
			{
				return true;
			}
		}
		return false;
	}

	public static int CurrentDessertCount()
	{
		int num = 0;
		for (int i = 0; i < WPFMonoBehaviour.gameData.m_desserts.Count; i++)
		{
			num += GameProgress.DessertCount(WPFMonoBehaviour.gameData.m_desserts[i].name);
		}
		return num;
	}

	private void Wiggle()
	{
		if (this.newTag != null && !this.wiggling)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.newTag);
			gameObject.transform.parent = base.transform;
			gameObject.transform.localPosition = new Vector3(1.1f, 1.1f, -1f);
			this.wiggling = true;
		}
	}

	protected override void OnActivate()
	{
		GameProgress.SetBool("Kingpig_Visited", true, GameProgress.Location.Local);
		Singleton<GameManager>.Instance.LoadKingPigFeed(false);
	}

	private void OnUIEvent(UIEvent data)
	{
		if (data.type == UIEvent.Type.ClosedLootWheel)
		{
			this.CheckWiggle();
		}
	}

	[SerializeField]
	private GameObject newTag;

	private bool wiggling;
}
