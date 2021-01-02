using System;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMask : MonoBehaviour
{
	private static BackgroundMask Instance
	{
		get
		{
			if (BackgroundMask.isExiting)
			{
				return null;
			}
			if (BackgroundMask.instance == null)
			{
				GameObject gameObject = Resources.Load<GameObject>("UI/BackgroundMask");
				if (gameObject != null)
				{
					GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(gameObject);
					gameObject2.name = "BackgroundMask";
					BackgroundMask.instance = gameObject2.GetComponent<BackgroundMask>();
				}
			}
			if (BackgroundMask.instance == null)
			{
				GameObject gameObject3 = new GameObject("BackgroundMask", new Type[]
				{
					typeof(BackgroundMask)
				});
				BackgroundMask.instance = gameObject3.GetComponent<BackgroundMask>();
			}
			if (BackgroundMask.depthPositions == null)
			{
				BackgroundMask.depthPositions = new StackList<BackgroundData>();
			}
			return BackgroundMask.instance;
		}
	}

	public static bool Instantiated
	{
		get
		{
			return BackgroundMask.instance != null;
		}
	}

	public static void Show(bool show, object owner, string sortingLayerName = "", Transform target = null, Vector3 offset = default(Vector3), bool smoothFade = false)
	{
		if (owner == null)
		{
			throw new ArgumentException("Argument 'owner' cannot be null!");
		}
		if (BackgroundMask.Instance == null)
		{
			return;
		}
		BackgroundMask.applySmoothFade = smoothFade;
		if (show)
		{
            BackgroundData backgroundData = new BackgroundData(sortingLayerName, target, offset, owner);
			if (!BackgroundMask.Add(backgroundData))
			{
				return;
			}
			BackgroundMask.prevDepth = BackgroundMask.depth++;
			BackgroundMask.SetBackground(backgroundData);
			BackgroundMask.showing = true;
		}
		else if (!show && BackgroundMask.depthPositions.Count > 0)
		{
			if (!BackgroundMask.Remove(owner))
			{
				return;
			}
			BackgroundMask.prevDepth = BackgroundMask.depth--;
			if (BackgroundMask.depthPositions.Count > 0)
			{
				BackgroundMask.SetBackground(BackgroundMask.depthPositions.Peek());
			}
			BackgroundMask.showing = (BackgroundMask.depth > 0);
		}
		if (BackgroundMask.applySmoothFade)
		{
			BackgroundMask.instance.gameObject.SetActive(true);
		}
		else
		{
			BackgroundMask.instance.gameObject.SetActive(BackgroundMask.showing);
		}
	}

	private static void SetBackground(BackgroundData data)
	{
		if (BackgroundMask.instance == null)
		{
			return;
		}
		BackgroundMask.instance.transform.position = data.TargetPosition;
		if (BackgroundMask.instanceRenderer == null)
		{
			BackgroundMask.instanceRenderer = BackgroundMask.instance.GetComponent<MeshRenderer>();
			if (BackgroundMask.instanceRenderer != null)
			{
				AtlasMaterials.Instance.AddMaterialInstance(BackgroundMask.instanceRenderer.material);
			}
		}
		if (BackgroundMask.instanceRenderer != null)
		{
			BackgroundMask.instanceRenderer.sortingLayerName = data.sortingLayerName;
			if (BackgroundMask.depth == 1 && BackgroundMask.prevDepth == 0)
			{
				BackgroundMask.instanceRenderer.material.color = ((!BackgroundMask.applySmoothFade) ? Color.white : BackgroundMask.transparentBlack);
			}
		}
	}

	private void OnDestroy()
	{
		if (BackgroundMask.instance == null || !AtlasMaterials.IsInstantiated)
		{
			return;
		}
		if (BackgroundMask.instanceRenderer == null)
		{
			BackgroundMask.instanceRenderer = BackgroundMask.instance.GetComponent<MeshRenderer>();
			if (BackgroundMask.instanceRenderer != null)
			{
				AtlasMaterials.Instance.RemoveMaterialInstance(BackgroundMask.instanceRenderer.material);
			}
		}
	}

	public static void SetParent(Transform parent)
	{
		if (BackgroundMask.instance == null)
		{
			return;
		}
		BackgroundMask.instance.transform.parent = parent;
	}

	private void Update()
	{
		if (!BackgroundMask.applySmoothFade || BackgroundMask.instance == null || BackgroundMask.instanceRenderer == null)
		{
			return;
		}
		if (!BackgroundMask.showing && Mathf.Approximately(BackgroundMask.fade, 0f))
		{
			BackgroundMask.instance.gameObject.SetActive(false);
		}
		BackgroundMask.fade += GameTime.RealTimeDelta * ((!BackgroundMask.showing) ? -2f : 2f);
		if (BackgroundMask.fade < 0f)
		{
			BackgroundMask.fade = 0f;
		}
		else if (BackgroundMask.fade > 1f)
		{
			BackgroundMask.fade = 1f;
		}
		BackgroundMask.instanceRenderer.material.color = Color.Lerp(BackgroundMask.transparentBlack, Color.white, BackgroundMask.fade);
	}

	private void LateUpdate()
	{
		if (BackgroundMask.depthPositions.Count > 0)
		{
			base.transform.position = BackgroundMask.depthPositions.Peek().TargetPosition;
		}
	}

	private static bool Remove(object owner)
	{
		for (int i = 0; i < BackgroundMask.depthPositions.Count; i++)
		{
			if (BackgroundMask.depthPositions.list[i].owner == owner)
			{
				BackgroundMask.depthPositions.list.RemoveAt(i);
				return true;
			}
		}
		return false;
	}

	private static bool Add(BackgroundData data)
	{
		for (int i = 0; i < BackgroundMask.depthPositions.Count; i++)
		{
			if (BackgroundMask.depthPositions.list[i].owner == data.owner)
			{
				return false;
			}
		}
		BackgroundMask.depthPositions.Push(data);
		return true;
	}

	private void OnApplicationQuit()
	{
		BackgroundMask.isExiting = true;
	}

	private static int depth = 0;

	private static int prevDepth = 0;

	private static StackList<BackgroundData> depthPositions = null;

	private static MeshRenderer instanceRenderer = null;

	private static BackgroundMask instance = null;

	private static float fade = 0f;

	private static bool showing = false;

	private static bool applySmoothFade = false;

	private static Color transparentBlack = new Color(0f, 0f, 0f, 0f);

	private static bool isExiting = false;

	private struct BackgroundData
	{
		public BackgroundData(string sortingLayerName, Transform target, Vector3 offset, object owner)
		{
			this.sortingLayerName = sortingLayerName;
			this.target = target;
			this.offset = offset;
			this.owner = owner;
		}

		public Vector3 TargetPosition
		{
			get
			{
				return ((!(this.target != null)) ? Vector3.zero : this.target.position) + this.offset;
			}
		}

		public string sortingLayerName;

		public Transform target;

		public Vector3 offset;

		public object owner;
	}

	private class StackList<T>
	{
		public StackList()
		{
			this.list = new List<T>();
		}

		public int Count
		{
			get
			{
				return this.list.Count;
			}
		}

		private int Head
		{
			get
			{
				return this.Count - 1;
			}
		}

		public void Push(T element)
		{
			this.list.Add(element);
		}

		public T Pop()
		{
			if (this.Count <= 0)
			{
				return default(T);
			}
			T result = this.list[this.Head];
			this.list.RemoveAt(this.Head);
			return result;
		}

		public T Peek()
		{
			if (this.Count <= 0)
			{
				return default(T);
			}
			return this.list[this.Head];
		}

		public List<T> list;
	}
}
