using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animation))]
public class SliderButton : MonoBehaviour
{
	protected virtual void Start()
	{
		this.SetInitialValues();
	}

	public void SetInitialValues()
	{
		int num = 0;
		foreach (string text in this.ButtonOrder)
		{
			Transform transform = base.transform.FindChildRecursively(text);
			if (!(transform == null) && (!(transform.GetComponent<Collider>() != null) || transform.GetComponent<Collider>().enabled))
			{
				if (this.dicOriginalButtonsTransforms.ContainsKey(text))
				{
					transform.localPosition = this.dicOriginalButtonsTransforms[text].position;
					transform.localRotation = this.dicOriginalButtonsTransforms[text].rotation;
					transform.localScale = this.dicOriginalButtonsTransforms[text].scale;
				}
				else
				{
                    OriginalTransform value;
					value.position = transform.localPosition;
					value.rotation = transform.localRotation;
					value.scale = transform.localScale;
					this.dicOriginalButtonsTransforms.Add(text, value);
				}
				float num2 = Mathf.Sign(transform.transform.position.x);
				transform.transform.localRotation *= Quaternion.AngleAxis(num2 * -180f, Vector3.back);
				transform.transform.localScale = Vector3.one * 0.1f;
				num++;
			}
		}
	}

	[SerializeField]
	private List<string> ButtonOrder = new List<string>();

	private Dictionary<string, OriginalTransform> dicOriginalButtonsTransforms = new Dictionary<string, OriginalTransform>();

	private struct OriginalTransform
	{
		public Vector3 position;

		public Quaternion rotation;

		public Vector3 scale;
	}
}
