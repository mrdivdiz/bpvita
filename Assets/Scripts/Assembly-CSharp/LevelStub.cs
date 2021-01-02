using UnityEngine;

public class LevelStub : MonoBehaviour
{
	private void Awake()
	{
		GameObject gameObject = Singleton<GameManager>.Instance.CurrentLevelLoader().gameObject;
		UnityEngine.Object.Instantiate<GameObject>(gameObject);
		UnityEngine.Object.Destroy(base.gameObject);
	}
}
