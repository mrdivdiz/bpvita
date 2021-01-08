using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace Spine.Unity.Modules
{
	[RequireComponent(typeof(SkeletonRenderer))]
	public class SkeletonGhost : MonoBehaviour
	{
		private void Start()
		{
			if (this.ghostShader == null)
			{
				this.ghostShader = Shader.Find("Spine/Special/SkeletonGhost");
			}
			this.skeletonRenderer = base.GetComponent<SkeletonRenderer>();
			this.meshFilter = base.GetComponent<MeshFilter>();
			this.meshRenderer = base.GetComponent<MeshRenderer>();
			this.nextSpawnTime = Time.time + this.spawnRate;
			this.pool = new SkeletonGhostRenderer[this.maximumGhosts];
			for (int i = 0; i < this.maximumGhosts; i++)
			{
				GameObject gameObject = new GameObject(base.gameObject.name + " Ghost", new Type[]
				{
					typeof(SkeletonGhostRenderer)
				});
				this.pool[i] = gameObject.GetComponent<SkeletonGhostRenderer>();
				gameObject.SetActive(false);
				gameObject.hideFlags = HideFlags.HideInHierarchy;
			}
			if (this.skeletonRenderer is SkeletonAnimation)
			{
				((SkeletonAnimation)this.skeletonRenderer).state.Event += this.OnEvent;
			}
		}

		private void OnEvent(AnimationState state, int trackIndex, Event e)
		{
			if (e.Data.Name == "Ghosting")
			{
				this.ghostingEnabled = (e.Int > 0);
				if (e.Float > 0f)
				{
					this.spawnRate = e.Float;
				}
				if (e.String != null)
				{
					this.color = SkeletonGhost.HexToColor(e.String);
				}
			}
		}

		private void Ghosting(float val)
		{
			this.ghostingEnabled = (val > 0f);
		}

		private void Update()
		{
			if (!this.ghostingEnabled)
			{
				return;
			}
			if (Time.time >= this.nextSpawnTime)
			{
				GameObject gameObject = this.pool[this.poolIndex].gameObject;
				Material[] sharedMaterials = this.meshRenderer.sharedMaterials;
				for (int i = 0; i < sharedMaterials.Length; i++)
				{
					Material material = sharedMaterials[i];
					Material material2;
					if (!this.materialTable.ContainsKey(material))
					{
						material2 = new Material(material);
						material2.shader = this.ghostShader;
						material2.color = Color.white;
						if (material2.HasProperty("_TextureFade"))
						{
							material2.SetFloat("_TextureFade", this.textureFade);
						}
						this.materialTable.Add(material, material2);
					}
					else
					{
						material2 = this.materialTable[material];
					}
					sharedMaterials[i] = material2;
				}
				Transform transform = gameObject.transform;
				transform.parent = base.transform;
				this.pool[this.poolIndex].Initialize(this.meshFilter.sharedMesh, sharedMaterials, this.color, this.additive, this.fadeSpeed, this.meshRenderer.sortingLayerID, (!this.sortWithDistanceOnly) ? (this.meshRenderer.sortingOrder - 1) : this.meshRenderer.sortingOrder);
				transform.localPosition = new Vector3(0f, 0f, this.zOffset);
				transform.localRotation = Quaternion.identity;
				transform.localScale = Vector3.one;
				transform.parent = null;
				this.poolIndex++;
				if (this.poolIndex == this.pool.Length)
				{
					this.poolIndex = 0;
				}
				this.nextSpawnTime = Time.time + this.spawnRate;
			}
		}

		private void OnDestroy()
		{
			for (int i = 0; i < this.maximumGhosts; i++)
			{
				if (this.pool[i] != null)
				{
					this.pool[i].Cleanup();
				}
			}
			foreach (Material obj in this.materialTable.Values)
			{
				UnityEngine.Object.Destroy(obj);
			}
		}

		private static Color32 HexToColor(string hex)
		{
			if (hex.Length < 6)
			{
				return Color.magenta;
			}
			hex = hex.Replace("#", string.Empty);
			byte r = byte.Parse(hex.Substring(0, 2), NumberStyles.HexNumber);
			byte g = byte.Parse(hex.Substring(2, 2), NumberStyles.HexNumber);
			byte b = byte.Parse(hex.Substring(4, 2), NumberStyles.HexNumber);
			byte a = byte.MaxValue;
			if (hex.Length == 8)
			{
				a = byte.Parse(hex.Substring(6, 2), NumberStyles.HexNumber);
			}
			return new Color32(r, g, b, a);
		}

		public bool ghostingEnabled = true;

		public float spawnRate = 0.05f;

		public Color32 color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 0);

		[Tooltip("Remember to set color alpha to 0 if Additive is true")]
		public bool additive = true;

		public int maximumGhosts = 10;

		public float fadeSpeed = 10f;

		public Shader ghostShader;

		[Tooltip("0 is Color and Alpha, 1 is Alpha only.")]
		[Range(0f, 1f)]
		public float textureFade = 1f;

		[Header("Sorting")]
		public bool sortWithDistanceOnly;

		public float zOffset;

		private float nextSpawnTime;

		private SkeletonGhostRenderer[] pool;

		private int poolIndex;

		private SkeletonRenderer skeletonRenderer;

		private MeshRenderer meshRenderer;

		private MeshFilter meshFilter;

		private Dictionary<Material, Material> materialTable = new Dictionary<Material, Material>();
	}
}
