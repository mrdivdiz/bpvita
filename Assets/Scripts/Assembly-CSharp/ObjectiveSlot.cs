using System;
using UnityEngine;

public class ObjectiveSlot : MonoBehaviour
{
	private void Awake()
	{
		this.m_succeededImage = base.transform.Find("Succeeded").gameObject;
		this.m_succeededImage.GetComponent<Renderer>().enabled = false;
		this.bShrinking = false;
		this.bGrowing = false;
	}

	public void SetSucceeded()
	{
		this.bGrowing = true;
		this.animTimer = 0.2f;
	}

	public void SetSucceededImmediate()
	{
		base.GetComponent<Renderer>().enabled = false;
		this.m_succeededImage.GetComponent<Renderer>().enabled = true;
	}

	public void SetChallenge(Challenge challenge)
	{
		foreach (Challenge.IconPlacement iconPlacement in challenge.Icons)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(iconPlacement.icon);
			gameObject.transform.parent = base.transform;
			gameObject.transform.localPosition = iconPlacement.position;
			Material sharedMaterial = gameObject.GetComponent<Renderer>().sharedMaterial;
			gameObject.GetComponent<Renderer>().sharedMaterial = AtlasMaterials.Instance.GetCachedMaterialInstance(sharedMaterial, AtlasMaterials.MaterialType.PartZ);
			gameObject.transform.localScale = new Vector3(iconPlacement.scale, iconPlacement.scale, 1f);
			TimeChallenge timeChallenge = challenge as TimeChallenge;
			if (timeChallenge)
			{
				TimeSpan timeSpan = TimeSpan.FromSeconds((double)timeChallenge.TimeLimit());
				string text = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
				TextMesh[] componentsInChildren = base.GetComponentsInChildren<TextMesh>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].text = text;
				}
			}
		}
	}

	public void SetChallenge(GoalChallenge challenge)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(challenge.Icon.icon);
		gameObject.transform.parent = base.transform;
		gameObject.transform.localPosition = challenge.Icon.position;
		gameObject.transform.localScale = new Vector3(challenge.Icon.scale, challenge.Icon.scale, 1f);
		Material sharedMaterial = gameObject.GetComponent<Renderer>().sharedMaterial;
		gameObject.GetComponent<Renderer>().sharedMaterial = AtlasMaterials.Instance.GetCachedMaterialInstance(sharedMaterial, AtlasMaterials.MaterialType.PartZ);
	}

	public void ShowSnoutReward(bool show = true, int count = 0, bool parentToParent = true)
	{
		Transform transform = base.transform.Find("SnoutReward");
		if (transform != null)
		{
			transform.gameObject.SetActive(show);
			if (show)
			{
				for (int i = 0; i < 5; i++)
				{
					Transform transform2 = transform.Find(string.Format("SnoutReward{0:00}", i + 1));
					if (transform2)
					{
						transform2.gameObject.SetActive(i < count);
					}
				}
			}
		}
		if (parentToParent)
		{
			transform.parent = transform.parent.parent;
		}
	}

	private void Update()
	{
		if (this.bGrowing)
		{
			if (this.animTimer > 0f)
			{
				base.transform.localScale += Vector3.one * Time.deltaTime;
				this.animTimer -= Time.deltaTime;
			}
			else
			{
				this.bGrowing = false;
				this.bShrinking = true;
				this.animTimer = 0.2f;
				base.GetComponent<Renderer>().enabled = false;
				this.m_succeededImage.GetComponent<Renderer>().enabled = true;
			}
		}
		else if (this.bShrinking)
		{
			if (this.animTimer > 0f)
			{
				if (base.transform.localScale.x - Time.deltaTime >= 1f)
				{
					base.transform.localScale -= Vector3.one * Time.deltaTime;
				}
				this.animTimer -= Time.deltaTime;
			}
			else
			{
				this.bShrinking = false;
				this.animTimer = 0f;
			}
		}
	}

	private GameObject m_succeededImage;

	private bool bShrinking;

	private bool bGrowing;

	private float animTimer;
}
