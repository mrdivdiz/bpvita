using UnityEngine;
using System.IO;
using System;

public class Engine : BasePart
{
	
	public GameObject[] engines;
//public GameObject[] engines2;
	public override bool CanBeEnabled()
	{
		return true;
	}

	public override bool HasOnOffToggle()
	{
		return true;
	}

	public override bool IsEnabled()
	{
		return m_running;
	}

	public override bool IsIntegralPart()
	{
		return true;
	}

	public override bool CanBeEnclosed()
	{
		return true;
	}

	public override bool ValidatePart()
	{
		return m_enclosedInto != null;
	}

	public override void Initialize()
	{
		base.contraption.m_enginesAmount++;
		m_visualizationPart = base.transform.GetChild(0);
		m_visualizationPartPosition = m_visualizationPart.localPosition;
	}

	public override void OnDetach()
	{
		m_engineBroken = true;
		if (m_running)
		{
			SetEnabled(false);
		}
		base.contraption.m_enginesAmount--;
		audioManager.RemoveCombinedLoopingEffect(m_engineSound, loopingSound);
		base.OnDetach();
	}

	private void Start()
	{
		audioManager = Singleton<AudioManager>.Instance;
		BasePart.PartType partType = m_partType;
		if (partType != BasePart.PartType.EngineSmall)
		{
			if (partType != BasePart.PartType.Engine)
			{
				if (partType == BasePart.PartType.EngineBig)
				{
					m_engineSound = new GameObject("FUCKING_ENGINE_228AE").AddComponent<AudioSource>();
					m_engineSound.gameObject.tag = "m_engineSetup";
					m_engineSound.GetComponent<AudioSource>().clip = (AudioClip) Resources.Load("AudioAdd" + Path.DirectorySeparatorChar + "V8_engine");
				//m_engineSound.GetComponent<AudioSource>().Play();
				m_engineSound.GetComponent<AudioSource>().Stop();
				m_engineSound.GetComponent<AudioSource>().loop = true;
				m_engineSound.GetComponent<AudioSource>().volume = 0.3f;
				m_engineSound.transform.parent = transform;
				}
			}
			else
			{
				m_engineSound = new GameObject("FUCKING_ENGINE_228AE").AddComponent<AudioSource>();
				m_engineSound.gameObject.tag = "m_engineSetup";
					m_engineSound.GetComponent<AudioSource>().clip = (AudioClip) Resources.Load("AudioAdd" + Path.DirectorySeparatorChar + "small_engine_22KHz");
				//m_engineSound.GetComponent<AudioSource>().Play();
				m_engineSound.GetComponent<AudioSource>().loop = true;
				m_engineSound.GetComponent<AudioSource>().Stop();
				m_engineSound.GetComponent<AudioSource>().volume = 0.3f;
				m_engineSound.transform.parent = transform;
			}
		}
		else if (base.HasTag("Alien"))
		{
			m_engineSound = new GameObject("FUCKING_ENGINE_228AE").AddComponent<AudioSource>();
			m_engineSound.gameObject.tag = "m_engineSetup";
					m_engineSound.GetComponent<AudioSource>().clip = (AudioClip) Resources.Load("AudioAdd" + Path.DirectorySeparatorChar + "alien_engine_loop_01");
				//m_engineSound.GetComponent<AudioSource>().Play();
				m_engineSound.GetComponent<AudioSource>().loop = true;
				m_engineSound.GetComponent<AudioSource>().Stop();
				m_engineSound.GetComponent<AudioSource>().volume = 0.3f;
				m_engineSound.transform.parent = transform;
		}
		else
		{
			m_engineSound = new GameObject("FUCKING_ENGINE_228AE").AddComponent<AudioSource>();
			m_engineSound.gameObject.tag = "m_engineSetup";
					m_engineSound.GetComponent<AudioSource>().clip = (AudioClip) Resources.Load("AudioAdd" + Path.DirectorySeparatorChar + "small_engine_22KHz");
				//m_engineSound.GetComponent<AudioSource>().Play();
				m_engineSound.GetComponent<AudioSource>().loop = true;
				m_engineSound.GetComponent<AudioSource>().Stop();
				m_engineSound.GetComponent<AudioSource>().volume = 0.3f;
				m_engineSound.transform.parent = transform;
			
		}
		engines = FindGameObjectsWithName("FUCKING_ENGINE_228AE");
	}

	private void Update()
	{
		if (m_running && !loopingSound)
		{
			//loopingSound = audioManager.SpawnCombinedLoopingEffect(m_engineSound, base.gameObject.transform);
			//loopingSound.GetComponent<AudioSource>().pitch = Mathf.Clamp(0.8f + 0.1f * (float)base.contraption.m_enginesAmount, 0f, 1f);
		}
		else if (!m_running)
		{
			//audioManager.RemoveCombinedLoopingEffect(m_engineSound, loopingSound);
			foreach(GameObject engine in engines){
			engine.GetComponent<AudioSource>().Stop();
			}
		}
		if (m_running && !m_engineSound.GetComponent<AudioSource>().isPlaying)
		{
			foreach(GameObject engine in engines){
			engine.GetComponent<AudioSource>().Play();
			PlayEngineAnimation();
			}
		}
	}

	private void PlayEngineAnimation()
	{
		if (Time.deltaTime > 0f)
		{
			m_visualizationPart.localPosition = m_visualizationPartPosition + (Vector3)UnityEngine.Random.insideUnitCircle * 0.1f;
		}
	}

	protected override void OnTouch()
	{
		if (base.contraption.ActivateAllPoweredParts(base.ConnectedComponent) == 0)
		{
			SetEnabled(!m_running);
		}
	}

	public override void SetEnabled(bool enabled)
	{
		m_running = (enabled && !m_engineBroken);
		if (smokeEmitter != null)
		{
			if (m_running)
			{
				smokeEmitter.Play();
			}
			else
			{
				smokeEmitter.Stop();
			}
		}
		if (flameEmitter != null)
		{
			if (m_running)
			{
				flameEmitter.Play();
			}
			else
			{
				flameEmitter.Stop();
			}
		}
	}
	
		GameObject[] FindGameObjectsWithName(string name){
			/*GameObject[] engs;
			engs = GetComponentsInChildren<GameObject>();
         int FluentNumber = 0;
		  GameObject[] arr=new GameObject[engs.Length];
         for (int i=0; i<engs.Length; i++) {
             if (engs[i].name == name) {
                 arr [FluentNumber] = engs[i];
                 FluentNumber++;
             }
         }
         Array.Resize (ref arr, FluentNumber);
         return arr;*/
         int a = GetComponentsInChildren<Transform>().Length;//TOO SLOW
         GameObject[] arr=new GameObject[a];
         int FluentNumber = 0;
         for (int i=0; i<a; i++) {
             if (GetComponentsInChildren<Transform>()[i].gameObject.name == name) {
                 arr [FluentNumber] = GetComponentsInChildren<Transform>()[i].gameObject;
                 FluentNumber++;
             }
         }
         Array.Resize (ref arr, FluentNumber);
         return arr;
     }
	public bool m_running;

	private Transform m_visualizationPart;

	private Vector3 m_visualizationPartPosition;

	private bool m_engineBroken;

	private GameObject loopingSound;

	private AudioSource m_engineSound;

	private AudioManager audioManager;

	public ParticleSystem smokeEmitter;

	public ParticleSystem flameEmitter;
}
