using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundChanger : MonoBehaviour {

	// Use this for initialization
	void Start(){
		Debug.Log("lev - " + Singleton<GameManager>.Instance.CurrentLevelIdentifier);
		if(Singleton<GameManager>.Instance.CurrentLevelIdentifier == "5-1" || Singleton<GameManager>.Instance.CurrentLevelIdentifier == "5-2" || Singleton<GameManager>.Instance.CurrentLevelIdentifier == "5-3" || Singleton<GameManager>.Instance.CurrentLevelIdentifier == "5-4" || Singleton<GameManager>.Instance.CurrentLevelIdentifier == "5-5" || Singleton<GameManager>.Instance.CurrentLevelIdentifier == "5-6" || Singleton<GameManager>.Instance.CurrentLevelIdentifier == "5-7" || Singleton<GameManager>.Instance.CurrentLevelIdentifier == "5-8" || Singleton<GameManager>.Instance.CurrentLevelIdentifier == "5-9" || Singleton<GameManager>.Instance.CurrentLevelIdentifier == "5-10" || Singleton<GameManager>.Instance.CurrentLevelIdentifier == "5-11" || Singleton<GameManager>.Instance.CurrentLevelIdentifier == "5-12" || Singleton<GameManager>.Instance.CurrentLevelIdentifier == "5-13" || Singleton<GameManager>.Instance.CurrentLevelIdentifier == "5-14" || Singleton<GameManager>.Instance.CurrentLevelIdentifier == "5-15" || Singleton<GameManager>.Instance.CurrentLevelIdentifier == "5-16" || Singleton<GameManager>.Instance.CurrentLevelIdentifier == "5-17" || Singleton<GameManager>.Instance.CurrentLevelIdentifier == "5-18" || Singleton<GameManager>.Instance.CurrentLevelIdentifier == "5-19" || Singleton<GameManager>.Instance.CurrentLevelIdentifier == "5-20" || Singleton<GameManager>.Instance.CurrentLevelIdentifier == "5-21" || Singleton<GameManager>.Instance.CurrentLevelIdentifier == "5-22" || Singleton<GameManager>.Instance.CurrentLevelIdentifier == "5-23" || Singleton<GameManager>.Instance.CurrentLevelIdentifier == "5-24" || Singleton<GameManager>.Instance.CurrentLevelIdentifier == "5-I" || Singleton<GameManager>.Instance.CurrentLevelIdentifier == "5-II" || Singleton<GameManager>.Instance.CurrentLevelIdentifier == "5-III" || Singleton<GameManager>.Instance.CurrentLevelIdentifier == "5-IV" || Singleton<GameManager>.Instance.CurrentLevelIdentifier == "5-V" || Singleton<GameManager>.Instance.CurrentLevelIdentifier == "5-VI" ){
			gameObject.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("AudioAdd/tusk2dawn") as AudioClip;
			gameObject.GetComponent<AudioSource>().Play();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
