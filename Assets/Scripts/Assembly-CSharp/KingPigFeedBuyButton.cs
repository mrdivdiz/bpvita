using UnityEngine;

public class KingPigFeedBuyButton : MonoBehaviour
{
	public void TextUpdated(GameObject textObject)
	{
		TextMesh component = textObject.GetComponent<TextMesh>();
		if (component.text.Contains("%"))
		{
			component.text = component.text.Replace("%3", base.gameObject.transform.FindChildRecursively("PriceText").GetComponent<TextMesh>().text);
		}
	}
}
