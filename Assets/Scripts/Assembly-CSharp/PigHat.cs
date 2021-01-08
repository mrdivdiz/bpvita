using System;
using System.Collections;
using UnityEngine;

public class PigHat : MonoBehaviour
{
	private void Start()
	{
		this.m_transform = base.transform;
		if (this.m_transform.childCount > 0)
		{
			this.m_hat = this.m_transform.GetChild(0).gameObject;
		}
		if (this.m_hat == null && this.m_hats.Length > 0 && Singleton<GameManager>.IsInstantiated() && Singleton<GameManager>.Instance.GetGameState() == GameManager.GameState.Level && Singleton<GameManager>.Instance.CurrentEpisodeLabel.Equals("6"))
		{
			int num = UnityEngine.Random.Range(0, this.m_hats.Length);
			this.m_hat = UnityEngine.Object.Instantiate<GameObject>(this.m_hats[num], this.m_transform.position, this.m_transform.rotation);
			this.m_hat.transform.parent = this.m_transform;
			this.m_hat.transform.localPosition = this.m_hats[num].transform.position;
			this.m_state = new PigHat.State?(PigHat.State.Inactive);
		}
		if ((Singleton<GameManager>.IsInstantiated() && !Singleton<GameManager>.Instance.CurrentEpisodeLabel.Equals("6")) || this.m_hats.Length <= 0)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private void Update()
	{
        State? state = this.m_state;
		if (state == null)
		{
			return;
		}
        State? state2 = this.m_state;
		if (state2 != null)
		{
            State value = state2.Value;
			if (value != PigHat.State.Inactive)
			{
				if (value != PigHat.State.Moving)
				{
					if (value == PigHat.State.Detaching)
					{
						this.Detaching();
					}
				}
				else
				{
					this.Moving();
				}
			}
			else
			{
				this.Inactive();
			}
		}
	}

	private void Inactive()
	{
		if (WPFMonoBehaviour.levelManager == null || WPFMonoBehaviour.levelManager.gameState != LevelManager.GameState.Running || WPFMonoBehaviour.levelManager.TimeElapsed <= 0f)
		{
			return;
		}
		this.m_lastPos = this.m_transform.position;
		this.m_lastTime = Time.time;
		this.m_state = new PigHat.State?(PigHat.State.Moving);
	}

	private void Moving()
	{
		float time = Time.time;
		float num = time - this.m_lastTime;
		float num2 = Vector3.Distance(this.m_transform.position, this.m_lastPos) / num;
		if (num2 > this.m_speedThreshold)
		{
			this.m_state = new PigHat.State?(PigHat.State.Detaching);
		}
		else
		{
			this.m_lastPos = this.m_transform.position;
			this.m_lastTime = time;
		}
	}

	private void Detaching()
	{
		Transform transform = this.m_hat.transform.Find("Visualization");
		Quaternion rotation = transform.rotation;
		this.m_transform.parent = null;
		this.m_transform.localRotation = Quaternion.identity;
		transform.rotation = rotation;
		this.m_hat.GetComponent<Animation>().Play();
		this.m_state = null;
		base.StartCoroutine(this.DelayedAction(delegate
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}, 1.2f));
	}

	public void Show(bool show)
	{
		if (this.m_hat == null)
		{
			return;
		}
		Renderer[] componentsInChildren = this.m_hat.GetComponentsInChildren<Renderer>(true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].enabled = show;
		}
	}

	private IEnumerator DelayedAction(Action action, float delay)
	{
		yield return new WaitForSeconds(delay);
		action();
		yield break;
	}

	public float m_speedThreshold = 1f;

	public GameObject[] m_hats;

	private State? m_state = new PigHat.State?(PigHat.State.Inactive);

	private Vector3 m_lastPos;

	private float m_lastTime;

	private Transform m_transform;

	private GameObject m_hat;

	private enum State
	{
		Inactive,
		Moving,
		Detaching
	}
}
