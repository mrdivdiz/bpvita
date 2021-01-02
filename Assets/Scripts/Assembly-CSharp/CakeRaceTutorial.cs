using System.Collections.Generic;
using UnityEngine;

public class CakeRaceTutorial : MonoBehaviour
{
	private bool StartTutorialShown
	{
		get
		{
			return GameProgress.GetBool("CakeRaceStartTutorialShown", false, GameProgress.Location.Local, null);
		}
		set
		{
			GameProgress.SetBool("CakeRaceStartTutorialShown", value, GameProgress.Location.Local);
		}
	}

	private bool LootCrateTutorialShown
	{
		get
		{
			return GameProgress.GetBool("LootCrateTutorialShown", false, GameProgress.Location.Local, null);
		}
		set
		{
			GameProgress.SetBool("LootCrateTutorialShown", value, GameProgress.Location.Local);
		}
	}

	private bool BeginOpeningTutorialShown
	{
		get
		{
			return GameProgress.GetBool("BeginOpeninTutorialShown", false, GameProgress.Location.Local, null);
		}
		set
		{
			GameProgress.SetBool("BeginOpeninTutorialShown", value, GameProgress.Location.Local);
		}
	}

	private void Awake()
	{
		if (this.StartTutorialShown && this.LootCrateTutorialShown && this.BeginOpeningTutorialShown)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			GameObject go = UnityEngine.Object.Instantiate<GameObject>(this.pointerPrefab);
			LayerHelper.SetSortingLayer(go, "Popup", true);
			LayerHelper.SetOrderInLayer(go, 0, true);
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.clickPrefab);
			LayerHelper.SetSortingLayer(gameObject, "Popup", true);
			LayerHelper.SetOrderInLayer(gameObject, 0, true);
			gameObject.SetActive(false);
			this.pointer = new Tutorial.Pointer(go, gameObject);
			this.SetActive(false);
		}
	}

	private void Start()
	{
		if (!this.StartTutorialShown)
		{
			this.StartTutorial();
			this.StartTutorialShown = true;
		}
		else if (!this.LootCrateTutorialShown && CakeRaceMenu.WinCount > 0)
		{
			this.LootCrateTutorial();
			this.LootCrateTutorialShown = true;
		}
	}

	private void Update()
	{
		if (this.active && this.currentTutorial != null)
		{
			this.currentTutorial.Update();
			if (this.currentTutorial.IsFinished())
			{
				this.currentTutorial.Start();
			}
		}
	}

	private void StartTutorial()
	{
		if (this.StartTutorialShown)
		{
			return;
		}
		this.currentTutorial = this.CreateStartTutorial();
		this.currentTutorial.Start();
		this.SetActive(true);
	}

	private void LootCrateTutorial()
	{
		if (this.LootCrateTutorialShown)
		{
			return;
		}
		this.currentTutorial = this.CreateLootCrateTutorial(this.lootCrateSlots.FindChildRecursively("Slot1"));
		this.currentTutorial.Start();
		this.SetActive(true);
	}

	public void OpenCrateTutorial(Transform buttonTf)
	{
		if (this.BeginOpeningTutorialShown)
		{
			return;
		}
		this.currentTutorial = this.CreateOpeningTutorial(buttonTf);
		this.currentTutorial.Start();
		this.SetActive(true);
	}

	public void SetActive(bool active)
	{
		this.active = active;
		this.pointer.Show(active);
	}

	private Tutorial.PointerTimeLine CreateStartTutorial()
	{
		Tutorial.PointerTimeLine pointerTimeLine = new Tutorial.PointerTimeLine(this.pointer);
		List<Vector3> list = new List<Vector3>();
		list.Add(this.findOpponentButton.position + 15f * Vector3.down + Vector3.back);
		list.Add(this.findOpponentButton.position + Vector3.back);
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Wait(0.1f));
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Move(list, 2.5f));
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Press());
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Wait(0.5f));
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Release());
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Wait(0.75f));
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Hide());
		return pointerTimeLine;
	}

	private Tutorial.PointerTimeLine CreateLootCrateTutorial(Transform slotTf)
	{
		Tutorial.PointerTimeLine pointerTimeLine = new Tutorial.PointerTimeLine(this.pointer);
		List<Vector3> list = new List<Vector3>();
		list.Add(slotTf.position + 10f * Vector3.down + Vector3.back);
		list.Add(slotTf.position + Vector3.back);
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Wait(0.1f));
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Move(list, 2.5f));
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Press());
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Wait(0.5f));
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Release());
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Wait(0.75f));
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Hide());
		return pointerTimeLine;
	}

	private Tutorial.PointerTimeLine CreateOpeningTutorial(Transform buttonTf)
	{
		Tutorial.PointerTimeLine pointerTimeLine = new Tutorial.PointerTimeLine(this.pointer);
		List<Vector3> list = new List<Vector3>();
		list.Add(buttonTf.position + 15f * Vector3.down + Vector3.back);
		list.Add(buttonTf.position + Vector3.back);
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Wait(0.1f));
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Move(list, 2.5f));
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Press());
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Wait(0.5f));
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Release());
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Wait(0.75f));
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Hide());
		return pointerTimeLine;
	}

	[SerializeField]
	private GameObject pointerPrefab;

	[SerializeField]
	private GameObject clickPrefab;

	[SerializeField]
	private Transform findOpponentButton;

	[SerializeField]
	private Transform lootCrateSlots;

	private Tutorial.Pointer pointer;

	private Tutorial.PointerTimeLine startTutorial;

	private Tutorial.PointerTimeLine lootCrateTutorial;

	private Tutorial.PointerTimeLine beginOpeningTutorial;

	private bool active;

	private Tutorial.PointerTimeLine currentTutorial;
}
