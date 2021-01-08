using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class WPFMonoBehaviour : MonoBehaviour
{
	public new Animation animation
	{
		get
		{
			if (this.cachedAnimation == null)
			{
				this.cachedAnimation = base.GetComponent<Animation>();
			}
			return this.cachedAnimation;
		}
		set
		{
			this.cachedAnimation = value;
		}
	}

	public new Collider collider
	{
		get
		{
			if (this.cachedCollider == null)
			{
				this.cachedCollider = base.GetComponent<Collider>();
			}
			return this.cachedCollider;
		}
		set
		{
			this.cachedCollider = value;
		}
	}

	public new Renderer renderer
	{
		get
		{
			if (this.cachedRenderer == null)
			{
				this.cachedRenderer = base.GetComponent<MeshRenderer>();
			}
			return this.cachedRenderer;
		}
		set
		{
			this.cachedRenderer = value;
		}
	}

	public new Rigidbody rigidbody
	{
		get
		{
			if (this.cachedRigidbody == null)
			{
				this.cachedRigidbody = base.GetComponent<Rigidbody>();
			}
			return this.cachedRigidbody;
		}
		set
		{
			this.cachedRigidbody = value;
		}
	}

	public static IngameCamera ingameCamera
	{
		get
		{
			if (WPFMonoBehaviour.s_ingameCamera)
			{
				return WPFMonoBehaviour.s_ingameCamera;
			}
			IngameCamera[] array = UnityEngine.Object.FindObjectsOfType<IngameCamera>();
			if (array.Length > 0)
			{
				WPFMonoBehaviour.s_ingameCamera = array[0];
			}
			return WPFMonoBehaviour.s_ingameCamera;
		}
	}

	public static LevelSelector levelSelector
	{
		get
		{
			if (WPFMonoBehaviour.s_levelSelector)
			{
				return WPFMonoBehaviour.s_levelSelector;
			}
			WPFMonoBehaviour.s_levelSelector = UnityEngine.Object.FindObjectOfType<LevelSelector>();
			return WPFMonoBehaviour.s_levelSelector;
		}
	}

	public static Camera hudCamera
	{
		get
		{
			if (WPFMonoBehaviour.s_hudCamera)
			{
				return WPFMonoBehaviour.s_hudCamera;
			}
			GameObject gameObject = GameObject.FindGameObjectWithTag("HUDCamera");
			if (gameObject)
			{
				WPFMonoBehaviour.s_hudCamera = gameObject.GetComponent<Camera>();
			}
			return WPFMonoBehaviour.s_hudCamera;
		}
	}

	public static Camera mainCamera
	{
		get
		{
			if (WPFMonoBehaviour.s_mainCamera)
			{
				return WPFMonoBehaviour.s_mainCamera;
			}
			WPFMonoBehaviour.s_mainCamera = Camera.main;
			return WPFMonoBehaviour.s_mainCamera;
		}
	}

	public static LevelManager levelManager
	{
		get
		{
			if (WPFMonoBehaviour.s_levelManager)
			{
				return WPFMonoBehaviour.s_levelManager;
			}
			if (!Singleton<GameManager>.Instance.IsInGame())
			{
				return null;
			}
			LevelManager[] array = UnityEngine.Object.FindObjectsOfType<LevelManager>();
			if (array.Length > 0)
			{
				WPFMonoBehaviour.s_levelManager = array[0];
			}
			return WPFMonoBehaviour.s_levelManager;
		}
	}

	public static EffectManager effectManager
	{
		get
		{
			if (WPFMonoBehaviour.s_effectManager)
			{
				return WPFMonoBehaviour.s_effectManager;
			}
			EffectManager[] array = UnityEngine.Object.FindObjectsOfType<EffectManager>();
			if (array.Length > 0)
			{
				WPFMonoBehaviour.s_effectManager = array[0];
			}
			return WPFMonoBehaviour.s_effectManager;
		}
	}

	public static GameData gameData
	{
		get
		{
			if (WPFMonoBehaviour.s_gameData)
			{
				return WPFMonoBehaviour.s_gameData;
			}
			WPFMonoBehaviour.s_gameData = Singleton<GameManager>.Instance.gameData;
			return WPFMonoBehaviour.s_gameData;
		}
	}

	public static Vector3 ScreenToZ0(Vector3 pos)
	{
		if (WPFMonoBehaviour.ingameCamera && WPFMonoBehaviour.ingameCamera.GetComponent<Camera>().orthographic)
		{
			Camera mainCamera = WPFMonoBehaviour.mainCamera;
			pos.z = mainCamera.farClipPlane;
			Vector3 result = mainCamera.ScreenToWorldPoint(pos);
			result.z = 0f;
			return result;
		}
		Camera mainCamera2 = WPFMonoBehaviour.mainCamera;
		pos.z = mainCamera2.farClipPlane;
		Vector3 result2 = mainCamera2.ScreenToWorldPoint(pos);
		result2.z = 0f;
		return result2;
	}

	public static T FindSceneObjectOfType<T>() where T : Object
    {
		T[] array = UnityEngine.Object.FindObjectsOfType<T>();
		if (array.Length > 0)
		{
			return array[0];
		}
		return (T)((object)null);
	}

	public static int GetNumberOfHighestBit(int val)
	{
		for (int i = 30; i >= 0; i--)
		{
			bool flag = (val & 1 << i) != 0;
			if (flag)
			{
				return i;
			}
		}
		return -1;
	}

	public static Vector3 ClipAgainstViewport(Vector3 pos1, Vector3 pos2)
	{
		Camera mainCamera = WPFMonoBehaviour.mainCamera;
		Vector3 vector = mainCamera.WorldToViewportPoint(pos1);
		Vector3 a = mainCamera.WorldToViewportPoint(pos2);
		Vector3 a2 = a - vector;
		float num = 1f;
		if (a2.x < 0f)
		{
			float num2 = vector.x / -a2.x;
			if (num2 < num)
			{
				num = num2;
			}
		}
		if (a2.y < 0f)
		{
			float num3 = vector.y / -a2.y;
			if (num3 < num)
			{
				num = num3;
			}
		}
		if (a2.x > 0f)
		{
			float num4 = (1f - vector.x) / a2.x;
			if (num4 < num)
			{
				num = num4;
			}
		}
		if (a2.y > 0f)
		{
			float num5 = (1f - vector.y) / a2.y;
			if (num5 < num)
			{
				num = num5;
			}
		}
		return mainCamera.ViewportToWorldPoint(vector + a2 * num);
	}

	public T[] GetComponentsOnlyInChildren<T>() where T : Component
	{
		List<T> list = new List<T>();
		for (int i = 0; i < base.transform.childCount; i++)
		{
			list.AddRange(base.transform.GetChild(i).GetComponentsInChildren<T>());
		}
		return list.ToArray();
	}

	public List<T> GetActiveComponents<T>() where T : Component
	{
		List<T> list = new List<T>(base.GetComponentsInChildren<T>(true));
		int i = 0;
		while (i < list.Count)
		{
			T t = list[i];
			PropertyInfo property = t.GetType().GetProperty("enabled");
			bool flag = true;
			if (property != null && property.PropertyType == typeof(bool))
			{
				flag = (bool)property.GetValue(list[i], null);
			}
			if (!flag)
			{
				goto IL_93;
			}
			T t2 = list[i];
			if (!t2.gameObject.activeSelf)
			{
				goto IL_93;
			}
			IL_9E:
			i++;
			continue;
			IL_93:
			list.RemoveAt(i--);
			goto IL_9E;
		}
		return list;
	}

	private Animation cachedAnimation;

	private Collider cachedCollider;

	private Renderer cachedRenderer;

	private Rigidbody cachedRigidbody;

	protected static IngameCamera s_ingameCamera;

	protected static Camera s_hudCamera;

	protected static Camera s_mainCamera;

	protected static LevelManager s_levelManager;

	protected static GameData s_gameData;

	protected static EffectManager s_effectManager;

	protected static LevelSelector s_levelSelector;
}
