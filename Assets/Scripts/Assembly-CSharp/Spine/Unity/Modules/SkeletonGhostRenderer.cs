using System.Collections;
using UnityEngine;

namespace Spine.Unity.Modules
{
    public class SkeletonGhostRenderer : MonoBehaviour
	{
		private void Awake()
		{
			this.meshRenderer = base.gameObject.AddComponent<MeshRenderer>();
			this.meshFilter = base.gameObject.AddComponent<MeshFilter>();
		}

		public void Initialize(Mesh mesh, Material[] materials, Color32 color, bool additive, float speed, int sortingLayerID, int sortingOrder)
		{
			base.StopAllCoroutines();
			base.gameObject.SetActive(true);
			this.meshRenderer.sharedMaterials = materials;
			this.meshRenderer.sortingLayerID = sortingLayerID;
			this.meshRenderer.sortingOrder = sortingOrder;
			this.meshFilter.sharedMesh = UnityEngine.Object.Instantiate<Mesh>(mesh);
			this.colors = this.meshFilter.sharedMesh.colors32;
			if (color.a + color.r + color.g + color.b > 0)
			{
				for (int i = 0; i < this.colors.Length; i++)
				{
					this.colors[i] = color;
				}
			}
			this.fadeSpeed = speed;
			if (additive)
			{
				base.StartCoroutine(this.FadeAdditive());
			}
			else
			{
				base.StartCoroutine(this.Fade());
			}
		}

		private IEnumerator Fade()
		{
			for (int t = 0; t < 500; t++)
			{
				bool breakout = true;
				for (int i = 0; i < this.colors.Length; i++)
				{
					Color32 c = this.colors[i];
					if (c.a > 0)
					{
						breakout = false;
					}
					this.colors[i] = Color32.Lerp(c, this.black, Time.deltaTime * this.fadeSpeed);
				}
				this.meshFilter.sharedMesh.colors32 = this.colors;
				if (breakout)
				{
					break;
				}
				yield return null;
			}
			UnityEngine.Object.Destroy(this.meshFilter.sharedMesh);
			base.gameObject.SetActive(false);
			yield break;
		}

		private IEnumerator FadeAdditive()
		{
			Color32 black = this.black;
			for (int t = 0; t < 500; t++)
			{
				bool breakout = true;
				for (int i = 0; i < this.colors.Length; i++)
				{
					Color32 c = this.colors[i];
					black.a = c.a;
					if (c.r > 0 || c.g > 0 || c.b > 0)
					{
						breakout = false;
					}
					this.colors[i] = Color32.Lerp(c, black, Time.deltaTime * this.fadeSpeed);
				}
				this.meshFilter.sharedMesh.colors32 = this.colors;
				if (breakout)
				{
					break;
				}
				yield return null;
			}
			UnityEngine.Object.Destroy(this.meshFilter.sharedMesh);
			base.gameObject.SetActive(false);
			yield break;
		}

		public void Cleanup()
		{
			if (this.meshFilter != null && this.meshFilter.sharedMesh != null)
			{
				UnityEngine.Object.Destroy(this.meshFilter.sharedMesh);
			}
			UnityEngine.Object.Destroy(base.gameObject);
		}

		public float fadeSpeed = 10f;

		private Color32[] colors;

		private Color32 black = new Color32(0, 0, 0, 0);

		private MeshFilter meshFilter;

		private MeshRenderer meshRenderer;
	}
}
