using System;
using System.Collections;
using UnityEngine;

public class MaterialAnimation : MonoBehaviour
{
	private void Awake()
	{
		this.renderer = base.GetComponent<Renderer>();
		if (this.renderer == null || this.renderer.sharedMaterial == null)
		{
			return;
		}
		this.originalMaterial = this.renderer.sharedMaterial;
		this.animationMaterial = new Material(this.renderer.sharedMaterial.shader);
		this.animationMaterial.CopyPropertiesFromMaterial(this.renderer.sharedMaterial);
		AtlasMaterials.Instance.AddMaterialInstance(this.animationMaterial);
	}

	private void OnDestroy()
	{
		if (this.animationMaterial != null && AtlasMaterials.IsInstantiated)
		{
			AtlasMaterials.Instance.AddMaterialInstance(this.animationMaterial);
		}
	}

	private void Start()
	{
		if (this.autoStart)
		{
			this.PlayAnimation(true, (this.autoStartLoopCount >= 0) ? this.autoStartLoopCount : int.MaxValue);
		}
	}

	private IEnumerator Loop()
	{
		if (this.isLooping || this.animationNodes == null || this.animationNodes.Length == 0 || this.animationMaterial == null)
		{
			yield break;
		}
		this.renderer.sharedMaterial = this.animationMaterial;
		this.isLooping = true;
		Color prevColor = this.animationNodes[0].Color;
		do
		{
			for (int i = 0; i < this.animationNodes.Length; i++)
			{
				if (!this.smoothTransition)
				{
					this.animationMaterial.color = this.animationNodes[i].Color;
				}
				float time = this.animationNodes[i].Time;
				if (Mathf.Approximately(time, 0f) || time < 0f)
				{
					time = 0.01f;
				}
				float waitTime = time;
				while (waitTime > 0f)
				{
					if (this.smoothTransition)
					{
						this.animationMaterial.color = Color.Lerp(prevColor, this.animationNodes[i].Color, waitTime / time);
					}
					waitTime -= GameTime.RealTimeDelta;
					yield return null;
				}
				prevColor = this.animationNodes[i].Color;
			}
			this.loopsLeft--;
		}
		while (this.loopsLeft >= 0);
		this.isLooping = false;
		this.renderer.sharedMaterial = this.originalMaterial;
		yield break;
	}

	public void PlayAnimation(bool loop = false, int loopCount = 0)
	{
		this.loopsLeft = loopCount;
		base.StartCoroutine(this.Loop());
	}

	[SerializeField]
	private AnimationNode[] animationNodes;

	[SerializeField]
	private bool smoothTransition;

	[SerializeField]
	private bool autoStart;

	[SerializeField]
	private int autoStartLoopCount;

	private Material animationMaterial;

	private Material originalMaterial;

	private int loopsLeft = -1;

	private bool isLooping;

	private Renderer renderer;

	[Serializable]
	public class AnimationNode
	{
		public Color Color
		{
			get
			{
				return this.color;
			}
		}

		public float Time
		{
			get
			{
				return this.time;
			}
		}

		[SerializeField]
		private Color color = Color.white;

		[SerializeField]
		private float time = 0.1f;
	}
}
