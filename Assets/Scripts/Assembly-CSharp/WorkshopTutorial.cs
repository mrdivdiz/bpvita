using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkshopTutorial : WPFMonoBehaviour
{
	private void Awake()
	{
		this.stop = false;
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.pointerPrefab);
		GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.clickPrefab);
		gameObject2.SetActive(false);
		EventManager.Connect(new EventManager.OnEvent<WorkshopMenu.CraftingMachineEvent>(this.OnCraftingMachineEvent));
		WorkshopIntro.OnPressedOk = (Action)Delegate.Combine(WorkshopIntro.OnPressedOk, new Action(this.OnPopupWatched));
		this.pointer = new Tutorial.Pointer(gameObject, gameObject2);
		this.SetupTutorials();
	}

	private void OnDestroy()
	{
		WorkshopIntro.OnPressedOk = (Action)Delegate.Remove(WorkshopIntro.OnPressedOk, new Action(this.OnPopupWatched));
		EventManager.Disconnect(new EventManager.OnEvent<WorkshopMenu.CraftingMachineEvent>(this.OnCraftingMachineEvent));
	}

	private void OnCraftingMachineEvent(WorkshopMenu.CraftingMachineEvent data)
	{
		switch (data.action)
		{
		case WorkshopMenu.CraftingMachineAction.Idle:
			this.machineReady = true;
			break;
		case WorkshopMenu.CraftingMachineAction.ResetScrap:
			if (this.mode != WorkshopTutorial.Mode.StartMachine)
			{
				return;
			}
			GameProgress.SetInt("Workshop_Tutorial", 1, GameProgress.Location.Local);
			this.SwitchMode(WorkshopTutorial.Mode.ScrapInsert);
			break;
		case WorkshopMenu.CraftingMachineAction.AddScrap:
			if (this.mode != WorkshopTutorial.Mode.ScrapInsert)
			{
				return;
			}
			GameProgress.SetInt("Workshop_Tutorial", 2, GameProgress.Location.Local);
			this.SwitchMode(WorkshopTutorial.Mode.StartMachine);
			break;
		case WorkshopMenu.CraftingMachineAction.CraftPart:
			if (this.mode != WorkshopTutorial.Mode.StartMachine)
			{
				return;
			}
			GameProgress.SetInt("Workshop_Tutorial", 3, GameProgress.Location.Local);
			this.SwitchMode(WorkshopTutorial.Mode.Finished);
			break;
		}
	}

	private bool CanBegin()
	{
		return this.machineReady && this.popupWatched;
	}

	private void OnPopupWatched()
	{
		GameProgress.SetBool("Workshop_Visited", true, GameProgress.Location.Local);
		GameProgress.SetInt("Workshop_Tutorial", 1, GameProgress.Location.Local);
		this.popupWatched = true;
	}

	private void SetupTutorials()
	{
		if (this.initialized)
		{
			return;
		}
		this.mode = (Mode)GameProgress.GetInt("Workshop_Tutorial", 0, GameProgress.Location.Local, null);
		switch (this.mode)
		{
		case WorkshopTutorial.Mode.None:
			this.scrapInsertTutorial = this.ScrapInsertTutorial();
			this.startMachineTutorial = this.StartMachineTutorial();
			this.pointer.Show(false);
			if (!GameProgress.GetBool("Workshop_Visited", false, GameProgress.Location.Local, null))
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(WPFMonoBehaviour.gameData.m_workshopIntroduction);
				gameObject.transform.position = new Vector3(0f, 0f, -5f);
			}
			else
			{
				this.OnPopupWatched();
			}
			base.StartCoroutine(this.WaitFor(() => this.machineReady && this.popupWatched, delegate
			{
				this.SwitchMode(WorkshopTutorial.Mode.ScrapInsert);
			}));
			break;
		case WorkshopTutorial.Mode.WatchPopup:
			this.scrapInsertTutorial = this.ScrapInsertTutorial();
			this.startMachineTutorial = this.StartMachineTutorial();
			this.pointer.Show(false);
			base.StartCoroutine(this.WaitFor(() => this.machineReady, delegate
			{
				this.SwitchMode(WorkshopTutorial.Mode.ScrapInsert);
			}));
			break;
		case WorkshopTutorial.Mode.ScrapInsert:
			this.scrapInsertTutorial = this.ScrapInsertTutorial();
			this.startMachineTutorial = this.StartMachineTutorial();
			this.pointer.Show(false);
			base.StartCoroutine(this.WaitFor(() => this.machineReady, delegate
			{
				this.SwitchMode(WorkshopTutorial.Mode.StartMachine);
			}));
			break;
		case WorkshopTutorial.Mode.StartMachine:
			UnityEngine.Object.Destroy(base.gameObject);
			break;
		}
		this.initialized = true;
	}

	private Tutorial.PointerTimeLine ScrapInsertTutorial()
	{
		Tutorial.PointerTimeLine pointerTimeLine = new Tutorial.PointerTimeLine(this.pointer);
		GameObject gameObject = GameObject.Find("AddScrap");
		List<Vector3> list = new List<Vector3>();
		list.Add(gameObject.transform.position + 21f * Vector3.down);
		list.Add(gameObject.transform.position);
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Wait(0.1f));
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Move(list, 2.5f));
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Press());
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Wait(0.5f));
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Release());
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Wait(0.75f));
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Hide());
		return pointerTimeLine;
	}

	private Tutorial.PointerTimeLine StartMachineTutorial()
	{
		Tutorial.PointerTimeLine pointerTimeLine = new Tutorial.PointerTimeLine(this.pointer);
		GameObject gameObject = GameObject.Find("CrankLever");
		List<Vector3> list = new List<Vector3>();
		list.Add(gameObject.transform.position + 12f * Vector3.down);
		list.Add(gameObject.transform.position);
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Wait(0.1f));
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Move(list, 2.5f));
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Press());
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Wait(0.5f));
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Release());
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Wait(0.75f));
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Hide());
		return pointerTimeLine;
	}

	private void Update()
	{
		if (this.playing)
		{
			this.timeLine.Update();
		}
		if (this.stop && this.timeLine.IsFinished())
		{
			this.playing = false;
		}
		if (this.playing && this.timeLine.IsFinished())
		{
			this.timeLine.Start();
		}
		if (!this.playing)
		{
			this.pointer.Show(false);
		}
	}

	private void SwitchMode(Mode mode)
	{
		if (this.mode == mode)
		{
			return;
		}
		this.mode = mode;
		if (mode != WorkshopTutorial.Mode.ScrapInsert)
		{
			if (mode != WorkshopTutorial.Mode.StartMachine)
			{
				if (mode == WorkshopTutorial.Mode.Finished)
				{
					this.playing = false;
				}
			}
			else
			{
				this.timeLine = this.startMachineTutorial;
				this.timeLine.Start();
				this.playing = true;
			}
		}
		else
		{
			this.timeLine = this.scrapInsertTutorial;
			this.timeLine.Start();
			this.playing = true;
		}
	}

	private IEnumerator WaitFor(Func<bool> wait, Action exec)
	{
		while (!wait())
		{
			yield return null;
		}
		if (exec != null)
		{
			exec();
		}
		yield break;
	}

	private const string FINISHED_TUTORIAL = "Workshop_Tutorial";

	[SerializeField]
	public GameObject pointerPrefab;

	[SerializeField]
	public GameObject clickPrefab;

	private Tutorial.Pointer pointer;

	private Tutorial.PointerTimeLine scrapInsertTutorial;

	private Tutorial.PointerTimeLine startMachineTutorial;

	private Tutorial.PointerTimeLine timeLine;

	private Mode mode;

	private bool playing;

	private bool initialized;

	private bool stop;

	private bool popupWatched;

	private bool machineReady;

	private enum Mode
	{
		None,
		WatchPopup,
		ScrapInsert,
		StartMachine,
		Finished
	}
}
