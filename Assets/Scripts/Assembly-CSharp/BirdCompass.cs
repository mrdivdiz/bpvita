using UnityEngine;

public class BirdCompass : WPFMonoBehaviour
{
	private void OnEnable()
	{
		for (int i = base.transform.childCount - 1; i >= 0; i--)
		{
			UnityEngine.Object.Destroy(base.transform.GetChild(i).gameObject);
		}
		this.m_birds = UnityEngine.Object.FindObjectsOfType<Bird>();
		this.m_indicators = new BirdCompassIndicator[this.m_birds.Length];
		for (int j = 0; j < this.m_birds.Length; j++)
		{
			float z = -98f + 0.1f * (float)j;
			BirdCompassIndicator birdCompassIndicator = UnityEngine.Object.Instantiate<BirdCompassIndicator>(this.m_indicatorPrefab, new Vector3(0f, 15f, z), new Quaternion(0f, 0f, 0f, 0f));
			birdCompassIndicator.AttachToBird(this.m_birds[j]);
			birdCompassIndicator.transform.parent = base.transform;
			this.m_indicators[j] = birdCompassIndicator;
		}
	}

	private void Update()
	{
		foreach (BirdCompassIndicator birdCompassIndicator in this.m_indicators)
		{
			if (!birdCompassIndicator.Done)
			{
				if (birdCompassIndicator.CheckBirdOnScreen())
				{
					birdCompassIndicator.Hide();
				}
				else
				{
					birdCompassIndicator.Show();
				}
			}
		}
	}

	[SerializeField]
	private BirdCompassIndicator m_indicatorPrefab;

	private Bird[] m_birds;

	private BirdCompassIndicator[] m_indicators;
}
