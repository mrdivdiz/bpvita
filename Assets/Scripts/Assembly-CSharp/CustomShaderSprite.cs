using UnityEngine;

public class CustomShaderSprite : MonoBehaviour
{
	public void SetSprite(GameObject sprite)
	{
		if (this.currentSprite != null)
		{
			UnityEngine.Object.Destroy(this.currentSprite);
		}
		this.currentSprite = UnityEngine.Object.Instantiate<GameObject>(sprite);
		this.currentSprite.transform.parent = base.transform;
		this.currentSprite.transform.localPosition = Vector3.zero;
		this.currentSprite.transform.localRotation = Quaternion.identity;
		this.currentSprite.transform.localScale = Vector3.one;
		LayerHelper.SetLayer(this.currentSprite, base.gameObject.layer, true);
		LayerHelper.SetOrderInLayer(this.currentSprite, 1, true);
		LayerHelper.SetSortingLayer(this.currentSprite, "Default", true);
        Sprite[] componentsInChildren = this.currentSprite.GetComponentsInChildren<Sprite>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			Renderer component = componentsInChildren[i].gameObject.GetComponent<Renderer>();
			Material material = component.material;
			material.shader = this.m_shader;
			material.color = this.m_shaderColor;
			component.sharedMaterial = material;
		}
	}

	public void ClearSprite()
	{
		if (this.currentSprite)
		{
			UnityEngine.Object.Destroy(this.currentSprite);
		}
	}

	[SerializeField]
	private Shader m_shader;

	[SerializeField]
	private Color m_shaderColor;

	private GameObject currentSprite;
}
