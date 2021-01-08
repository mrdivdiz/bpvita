using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	public static T Instance
	{
		get
		{
			if (Singleton<T>.instance == null)
			{
				Singleton<T>.instance = UnityEngine.Object.FindObjectOfType<T>();
			}
			return Singleton<T>.instance;
		}
	}

	public static bool IsInstantiated()
	{
        return Singleton<T>.instance != null;
	}

	protected void SetAsPersistant()
	{
		Singleton<T>.instance = (this as T);
		UnityEngine.Object.DontDestroyOnLoad(this);
	}

	protected static T instance;
}
