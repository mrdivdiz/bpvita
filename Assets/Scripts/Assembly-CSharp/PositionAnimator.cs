using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionAnimator : MonoBehaviour
{
	private void Start()
	{
		this.StartAnimation();
	}

	private void OnEnable()
	{
		this.StartAnimation();
	}

	private void OnDisable()
	{
		this.StopAnimation();
	}

	private void StartAnimation()
	{
		if (!this.animating)
		{
			base.StartCoroutine(this.Animate());
		}
	}

	private void StopAnimation()
	{
		this.animating = false;
	}

	private IEnumerator Animate()
	{
		this.animating = true;
		while (this.animating)
		{
			for (int i = 0; i < this.animStates.Count; i++)
			{
				for (int j = 0; j < this.animStates[i].objectStates.Count; j++)
				{
					Transform obj = this.animStates[i].objectStates[j].obj;
					if (!(obj == null))
					{
						if (this.animStates[i].objectStates[j].enabled)
						{
							obj.gameObject.SetActive(true);
							obj.localPosition = new Vector3(this.animStates[i].objectStates[j].pos.x, this.animStates[i].objectStates[j].pos.y, obj.localPosition.z);
						}
						else
						{
							obj.gameObject.SetActive(false);
						}
					}
				}
				yield return new WaitForSeconds(this.animStates[i].length);
			}
		}
		yield break;
	}

	public List<AnimState> animStates;

	private bool animating;

	[Serializable]
	public class ObjectState
	{
		[SerializeField]
		public Transform obj;

		[SerializeField]
		public Vector2 pos;

		[SerializeField]
		public bool enabled;
	}

	[Serializable]
	public class AnimState
	{
		[SerializeField]
		public List<ObjectState> objectStates;

		[SerializeField]
		public float length;
	}
}
