using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Bridge : ExportAction
{
	private void Awake()
	{
		EventManager.Connect<GameStateChanged>(new EventManager.OnEvent<GameStateChanged>(this.OnGameStateChanged));
		if (!LevelLoader.IsLoadingLevel())
		{
			this.OnDataLoaded();
		}
	}

	private void OnDestroy()
	{
		EventManager.Disconnect<GameStateChanged>(new EventManager.OnEvent<GameStateChanged>(this.OnGameStateChanged));
	}

	public void OnDataLoaded()
	{
		this.stepParent = base.transform.Find("StepParent");
		this.endPoint = base.transform.Find("EndPoint");
		if (this.stepPrefab == null || this.endPoint == null)
		{
			return;
		}
		Vector3 vector = this.endPoint.position - base.transform.position;
		float magnitude = vector.magnitude;
		float f = magnitude / (this.stepLength + this.stepGap);
		this.steps = new List<Transform>();
		for (int i = 0; i < this.stepParent.childCount; i++)
		{
			Transform child = this.stepParent.GetChild(i);
			this.steps.Add(child);
		}
		int num = this.steps.Count - Mathf.FloorToInt(f);
		if (num > 0)
		{
			for (int j = 0; j < num; j++)
			{
				UnityEngine.Object.DestroyImmediate(this.steps[this.steps.Count - 1].gameObject);
				this.steps.RemoveAt(this.steps.Count - 1);
			}
		}
		int num2 = 0;
		while (this.steps.Count < Mathf.FloorToInt(f) && num2 <= 100)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.stepPrefab);
			gameObject.transform.parent = this.stepParent;
			gameObject.name = string.Format("Step{0:000}", this.steps.Count);
			this.steps.Add(gameObject.transform);
			num2++;
		}
		HingeJoint hingeJoint = null;
		for (int k = 0; k < this.steps.Count; k++)
		{
			this.steps[k].localPosition = Vector3.right * ((float)k * (this.stepLength + this.stepGap) + (this.stepLength + this.stepGap) * 0.5f);
			this.steps[k].localRotation = Quaternion.identity;
			HingeJoint component = this.steps[k].GetComponent<HingeJoint>();
			if (hingeJoint != null)
			{
				component.connectedBody = hingeJoint.GetComponent<Rigidbody>();
			}
			component.autoConfigureConnectedAnchor = true;
			hingeJoint = component;
		}
		Transform transform = base.transform.Find("StepRopeParent");
		if (transform != null)
		{
			UnityEngine.Object.DestroyImmediate(transform.gameObject);
		}
		if (transform == null)
		{
			transform = new GameObject("StepRopeParent").transform;
			transform.parent = base.transform;
		}
		transform.localPosition = Vector3.zero;
		if (this.stepRopes == null)
		{
			this.stepRopes = new List<GameObject>();
		}
		this.stepRopes.Clear();
		for (int l = 0; l < this.steps.Count + 1; l++)
		{
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.stepRopePrefab);
			gameObject2.name = string.Format("StepRope{0:000}", l);
			gameObject2.transform.parent = transform;
			if (l < this.steps.Count)
			{
				gameObject2.transform.position = this.steps[l].position;
			}
			else
			{
				gameObject2.transform.position = this.endPoint.position;
			}
			this.stepRopes.Add(gameObject2);
		}
		for (int m = 0; m < this.stepParent.childCount; m++)
		{
			Transform child2 = this.stepParent.GetChild(m);
			HingeJoint component2 = child2.GetComponent<HingeJoint>();
			if (component2 && this.stepBreakForces.Count > m)
			{
				component2.breakForce = this.stepBreakForces[m];
				if (this.stepBreakForces[m] < 0.1f)
				{
					this.isBroken = true;
				}
			}
		}
		Transform transform2 = this.steps[this.steps.Count - 1];
		HingeJoint component3 = this.endPoint.GetComponent<HingeJoint>();
		component3.connectedBody = transform2.GetComponent<Rigidbody>();
		float d = Mathf.Atan2(vector.y, vector.x) * 57.29578f;
		this.stepParent.localEulerAngles = Vector3.forward * d;
		this.endPoint.position = transform2.position + transform2.right * (this.stepLength * 0.5f + this.stepGap);
		base.transform.rotation = Quaternion.identity;
		if (Application.isPlaying)
		{
			foreach (Transform transform3 in this.steps)
			{
				BridgeStep bridgeStep = transform3.GetComponent<BridgeStep>();
				LevelRigidbody component4 = transform3.GetComponent<LevelRigidbody>();
				if (component4)
				{
					UnityEngine.Object.DestroyImmediate(component4);
				}
				if (!bridgeStep)
				{
					bridgeStep = transform3.gameObject.AddComponent<BridgeStep>();
				}
				bridgeStep.Init(false);
			}
			LevelRigidbody component5 = this.endPoint.GetComponent<LevelRigidbody>();
			if (component5)
			{
				UnityEngine.Object.DestroyImmediate(component5);
			}
			BridgeStep bridgeStep2 = this.endPoint.GetComponent<BridgeStep>();
			if (!bridgeStep2)
			{
				bridgeStep2 = this.endPoint.gameObject.AddComponent<BridgeStep>();
			}
			bridgeStep2.Init(true);
		}
		this.SubscribeToJointBreaks();
	}

	public void ClearAllSteps()
	{
		this.stepBreakForces = new List<float>();
		for (int i = 0; i < this.stepParent.childCount; i++)
		{
			Transform child = this.stepParent.GetChild(i);
			HingeJoint component = child.GetComponent<HingeJoint>();
			if (component)
			{
				this.stepBreakForces.Add(component.breakForce);
			}
		}
		for (int j = this.stepParent.childCount - 1; j >= 0; j--)
		{
			UnityEngine.Object.DestroyImmediate(this.stepParent.GetChild(j).gameObject);
		}
		Transform transform = base.transform.Find("StepRopeParent");
		if (transform != null)
		{
			UnityEngine.Object.DestroyImmediate(transform.gameObject);
		}
	}

	public override void StartActions()
	{
		if (this.stepParent == null)
		{
			this.stepParent = base.transform.Find("StepParent");
		}
		this.stepParent.rotation = Quaternion.identity;
		this.ClearAllSteps();
	}

	public override void EndActions()
	{
		this.OnDataLoaded();
	}

	private void Update()
	{
		if (this.steps == null || this.stepRopes == null || this.endPoint == null)
		{
			return;
		}
		for (int i = 0; i < this.stepRopes.Count; i++)
		{
			if (!(this.stepRopes[i] == null))
			{
				Vector3 vector = base.transform.position;
				Vector3 a = this.endPoint.position;
				Vector3 b = this.steps[(i >= this.steps.Count) ? 0 : i].right * this.stepLength * 0.5f;
				if (i == 0)
				{
					vector = base.transform.position;
					a = this.steps[i].position - b;
				}
				else
				{
					Vector3 b2 = this.steps[i - 1].right * this.stepLength * 0.5f;
					if (i == this.steps.Count)
					{
						vector = this.steps[i - 1].position + b2;
						a = this.endPoint.position;
					}
					else
					{
						vector = this.steps[i - 1].position + b2;
						a = this.steps[i].position - b;
					}
				}
				Vector3 vector2 = a - vector;
				float d = Mathf.Atan2(vector2.y, vector2.x) * 57.29578f;
				this.stepRopes[i].transform.position = vector + Vector3.forward * 0.01f;
				this.stepRopes[i].transform.eulerAngles = Vector3.forward * d;
				this.stepRopes[i].transform.localScale = ((vector2.magnitude >= 1f) ? (Vector3.one * 0.01f) : (Vector3.one - Vector3.right * vector2.magnitude));
			}
		}
	}

	private void OnGameStateChanged(GameStateChanged newState)
	{
		if (newState.state == LevelManager.GameState.Running && newState.prevState == LevelManager.GameState.Building)
		{
			this.SubscribeToJointBreaks();
		}
		if (newState.state == LevelManager.GameState.PreviewMoving && newState.prevState == LevelManager.GameState.Preview)
		{
			this.LoadStepStates();
		}
		if ((newState.state == LevelManager.GameState.Building || newState.state == LevelManager.GameState.ShowingUnlockedParts) && (newState.prevState == LevelManager.GameState.Running || newState.prevState == LevelManager.GameState.PausedWhileRunning) && !this.isBroken)
		{
			this.LoadStepStates();
		}
	}

	private void LoadStepStates()
	{
		List<BridgeStep> list = new List<BridgeStep>();
		int num = 0;
		for (int i = 0; i < this.steps.Count; i++)
		{
			HingeJoint component = this.steps[i].GetComponent<HingeJoint>();
			if (component)
			{
				num++;
			}
			BridgeStep component2 = this.steps[i].GetComponent<BridgeStep>();
			if (component2)
			{
				list.Add(component2);
			}
		}
		if (this.endPoint.GetComponent<HingeJoint>())
		{
			num++;
		}
		if (num == this.steps.Count + 1)
		{
			return;
		}
		for (int j = 0; j < list.Count; j++)
		{
			list[j].LoadState();
		}
		BridgeStep component3 = this.endPoint.GetComponent<BridgeStep>();
		if (component3)
		{
			component3.LoadState();
		}
	}

	private void OnDrawGizmos()
	{
		if (this.endPoint == null)
		{
			return;
		}
		Gizmos.color = Color.green;
		for (int i = 0; i < this.steps.Count; i++)
		{
			Gizmos.color = ((i % 2 != 0) ? Color.red : Color.green);
			Vector3 b = this.steps[i].right * this.stepLength * 0.5f;
			if (i == 0)
			{
				Gizmos.DrawLine(base.transform.position, this.steps[i].position - b);
			}
			else
			{
				Vector3 b2 = this.steps[i - 1].right * this.stepLength * 0.5f;
				Gizmos.DrawLine(this.steps[i - 1].position + b2, this.steps[i].position - b);
				if (i == this.steps.Count - 1)
				{
					Gizmos.color = (((i + 1) % 2 != 0) ? Color.red : Color.green);
					Gizmos.DrawLine(this.steps[i].position + b, this.endPoint.position);
				}
			}
		}
	}

	private void OnBridgeBroken(object sender)
	{
		if (WPFMonoBehaviour.levelManager.gameState == LevelManager.GameState.Running || WPFMonoBehaviour.levelManager.gameState == LevelManager.GameState.PreviewWhileRunning)
		{
			if (!Bridge.achievementSent && DeviceInfo.ActiveDeviceFamily == DeviceInfo.DeviceFamily.Ios)
			{
				Singleton<SocialGameManager>.Instance.ReportAchievementProgress("grp.LPA_BRIDGE_BREAK", 100.0);
			}
			Bridge.achievementSent = true;
			Singleton<AudioManager>.Instance.SpawnOneShotEffect(Singleton<GameManager>.Instance.gameData.commonAudioCollection.bridgeBreak, base.transform.position);
		}
		foreach (JointBreakEvent jointBreakEvent in this.jbEvents)
		{
			JointBreakEvent jointBreakEvent2 = jointBreakEvent;
			jointBreakEvent2.onJointBreak = (JointBreakEvent.JointBreak)Delegate.Remove(jointBreakEvent2.onJointBreak, new JointBreakEvent.JointBreak(this.OnBridgeBroken));
		}
	}

	private void SubscribeToJointBreaks()
	{
		if (DeviceInfo.ActiveDeviceFamily != DeviceInfo.DeviceFamily.Ios)
		{
			return;
		}
		if (string.IsNullOrEmpty("grp.LPA_BRIDGE_BREAK"))
		{
			return;
		}
		if (Singleton<AchievementData>.Instance.GetAchievement("grp.LPA_BRIDGE_BREAK").completed)
		{
			return;
		}
		this.jbEvents = new List<JointBreakEvent>(base.GetComponentsInChildren<JointBreakEvent>());
		foreach (JointBreakEvent jointBreakEvent in this.jbEvents)
		{
			JointBreakEvent jointBreakEvent2 = jointBreakEvent;
			jointBreakEvent2.onJointBreak = (JointBreakEvent.JointBreak)Delegate.Combine(jointBreakEvent2.onJointBreak, new JointBreakEvent.JointBreak(this.OnBridgeBroken));
		}
	}

	private const string achievementId = "grp.LPA_BRIDGE_BREAK";

	private static bool achievementSent;

	public GameObject stepPrefab;

	public GameObject stepRopePrefab;

	public float stepLength = 1f;

	public float stepGap = 0.2f;

	private Transform stepParent;

	private Transform endPoint;

	public List<Transform> steps;

	public List<GameObject> stepRopes;

	private List<JointBreakEvent> jbEvents;

	[SerializeField]
	private List<float> stepBreakForces;

	private bool isBroken;
}
