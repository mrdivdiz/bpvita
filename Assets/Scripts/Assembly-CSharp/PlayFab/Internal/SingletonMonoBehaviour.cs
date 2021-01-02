using UnityEngine;

namespace PlayFab.Internal
{
    public class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
	{
		public static T instance
		{
			get
			{
				SingletonMonoBehaviour<T>.CreateInstance();
				return SingletonMonoBehaviour<T>._instance;
			}
		}

		public static void CreateInstance()
		{
			if (SingletonMonoBehaviour<T>._instance == null)
			{
				SingletonMonoBehaviour<T>._instance = UnityEngine.Object.FindObjectOfType<T>();
				if (SingletonMonoBehaviour<T>._instance == null)
				{
					GameObject gameObject = new GameObject(typeof(T).Name);
					SingletonMonoBehaviour<T>._instance = gameObject.AddComponent<T>();
				}
				if (!SingletonMonoBehaviour<T>._instance.initialized)
				{
					SingletonMonoBehaviour<T>._instance.Initialize();
					SingletonMonoBehaviour<T>._instance.initialized = true;
				}
			}
		}

		public virtual void Awake()
		{
			if (Application.isPlaying)
			{
				UnityEngine.Object.DontDestroyOnLoad(this);
			}
			if (SingletonMonoBehaviour<T>._instance != null)
			{
				UnityEngine.Object.DestroyImmediate(base.gameObject);
			}
		}

		protected virtual void Initialize()
		{
		}

		private static T _instance;

		protected bool initialized;
	}
}
