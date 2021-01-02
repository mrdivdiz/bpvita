using System.Collections;
using UnityEngine;

public class SkullPopup : MonoBehaviour
{
	private void Start()
	{
		this.maxCount = GameProgress.MaxSkullCount();
		this.m_skull = base.transform.Find("Skull");
		this.m_skull.localPosition = -Vector3.up * 17f;
		this.m_bgColor = base.transform.Find("BackgroundBox").GetComponent<Renderer>().material;
		int num = 0;
		CollectableType collectableType = this.type;
		if (collectableType != CollectableType.Skull)
		{
			if (collectableType == CollectableType.Statue)
			{
				num = GameProgress.SecretStatueCount();
			}
		}
		else
		{
			num = GameProgress.SecretSkullCount();
		}
		base.transform.Find("Skull/SkullText").GetComponent<TextMesh>().text = ((num >= 10) ? (num + "/" + this.maxCount) : string.Concat(new object[]
		{
			"0",
			num,
			"/",
			this.maxCount
		}));
		base.StartCoroutine(this.PlayAnimation());
	}

	private IEnumerator PlayAnimation()
	{
		float alpha = 0f;
		while (alpha < 1f)
		{
			alpha += Time.deltaTime * 4f;
			this.m_bgColor.SetColor("_Color", new Color(1f, 1f, 1f, alpha));
			yield return new WaitForEndOfFrame();
		}
		while (this.m_skull.localPosition.y < -0.01f)
		{
			this.m_skull.localPosition -= Vector3.up * this.m_skull.localPosition.y * Time.deltaTime * 4f;
			yield return new WaitForEndOfFrame();
		}
		this.m_skull.localPosition = Vector3.up * 0.05f;
		GameObject particles = UnityEngine.Object.Instantiate<GameObject>(this.particlesXP, this.m_skull.position + Vector3.back, Quaternion.identity);
		particles.layer = this.m_skull.gameObject.layer;
		while (this.m_skull.localPosition.y < 17f)
		{
			this.m_skull.localPosition += Vector3.up * this.m_skull.localPosition.y * Time.deltaTime * 12f;
			yield return new WaitForEndOfFrame();
		}
		while (alpha > 0f)
		{
			alpha -= Time.deltaTime * 4f;
			this.m_bgColor.SetColor("_Color", new Color(1f, 1f, 1f, alpha));
			yield return new WaitForEndOfFrame();
		}
		base.gameObject.SetActive(false);
		yield break;
	}

	[SerializeField]
	private CollectableType type;

	[SerializeField]
	private int maxCount = 45;

	[SerializeField]
	private GameObject particlesXP;

	private Transform m_skull;

	private Material m_bgColor;
}
