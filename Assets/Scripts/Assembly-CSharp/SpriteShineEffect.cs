using UnityEngine;

public class SpriteShineEffect : MonoBehaviour
{
	public void ShineOnce()
	{
		if (!this.isInit)
		{
			this.sprites = base.GetComponentsInChildren<global::Sprite>();
			if (this.sprites == null || this.sprites.Length == 0)
			{
				return;
			}
			this.originalMaterials = new Material[this.sprites.Length];
			this.shineMaterials = new Material[this.sprites.Length];
			for (int i = 0; i < this.sprites.Length; i++)
			{
				this.originalMaterials[i] = this.sprites[i].renderer.sharedMaterial;
				this.shineMaterials[i] = AtlasMaterials.Instance.GetCachedMaterialInstance(this.originalMaterials[i], AtlasMaterials.MaterialType.Shiny);
				if (this.shineMaterials[i] == null)
				{
					return;
				}
				this.shineMaterials[i].SetFloat("_Scale", 1f / this.width);
				this.shineMaterials[i].SetColor("_Color", this.shineColor);
			}
			this.isInit = true;
		}
		for (int j = 0; j < this.sprites.Length; j++)
		{
			this.sprites[j].renderer.sharedMaterial = this.shineMaterials[j];
			this.SetCenter(this.shineMaterials[j]);
		}
		this.shineFade = 0f;
		this.isShining = true;
	}

	private void SetCenter(Material mat)
	{
		if (mat == null)
		{
			return;
		}
		mat.SetFloat("_Center", Mathf.Lerp(this.offsetLeft - this.width, this.offsetRight + this.width, this.shineFade));
	}

	private void Update()
	{
		if (this.isShining)
		{
			this.shineFade += ((!this.unscaledDeltaTime) ? GameTime.DeltaTime : GameTime.RealTimeDelta) * this.shineSpeed;
			for (int i = 0; i < this.sprites.Length; i++)
			{
				this.SetCenter(this.shineMaterials[i]);
				if (this.shineFade >= 1f)
				{
					this.sprites[i].renderer.sharedMaterial = this.originalMaterials[i];
				}
			}
			if (this.shineFade >= 1f)
			{
				this.isShining = false;
				this.shineEnded = Time.realtimeSinceStartup;
			}
		}
		else if (this.alwaysShine && this.shineEnded + this.shineInterval < Time.realtimeSinceStartup)
		{
			this.ShineOnce();
		}
	}

	public static void AddOneTimeShine(GameObject go)
	{
		if (go == null)
		{
			return;
		}
		SpriteShineEffect spriteShineEffect = go.AddComponent<SpriteShineEffect>();
		spriteShineEffect.ShineOnce();
	}

	[SerializeField]
	private Color shineColor = Color.white;

	[SerializeField]
	private float shineSpeed = 1f;

	[SerializeField]
	private bool unscaledDeltaTime = true;

	[SerializeField]
	private bool alwaysShine;

	[SerializeField]
	private float shineInterval = 3f;

	[SerializeField]
	private float offsetLeft;

	[SerializeField]
	private float offsetRight = 1f;

	[SerializeField]
	private float width = 0.1f;

	private Sprite[] sprites;

	private Material[] shineMaterials;

	private Material[] originalMaterials;

	private bool isInit;

	private bool isShining;

	private float shineFade;

	private float shineEnded;
}
