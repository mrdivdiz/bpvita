using CakeRace;
using UnityEngine;

public class CakeCompass : WPFMonoBehaviour
{
	private void OnEnable()
	{
		for (int i = base.transform.childCount - 1; i >= 0; i--)
		{
			UnityEngine.Object.Destroy(base.transform.GetChild(i).gameObject);
		}
		this.m_cakes = UnityEngine.Object.FindObjectsOfType<Cake>();
		this.m_indicators = new CakeCompassIndicator[this.m_cakes.Length];
		for (int j = 0; j < this.m_cakes.Length; j++)
		{
			float z = -98f + 0.1f * (float)j;
			CakeCompassIndicator cakeCompassIndicator = UnityEngine.Object.Instantiate<CakeCompassIndicator>(this.m_indicatorPrefab, new Vector3(0f, 15f, z), new Quaternion(0f, 0f, 0f, 0f));
			cakeCompassIndicator.AttachToCake(this.m_cakes[j]);
			cakeCompassIndicator.transform.parent = base.transform;
			this.m_indicators[j] = cakeCompassIndicator;
		}
	}

	private void Update()
	{
		foreach (CakeCompassIndicator cakeCompassIndicator in this.m_indicators)
		{
			if (!cakeCompassIndicator.Done)
			{
				if (cakeCompassIndicator.CheckCakeOnScreen())
				{
					cakeCompassIndicator.Hide();
				}
				else
				{
					cakeCompassIndicator.Show();
				}
			}
		}
	}

	[SerializeField]
	private CakeCompassIndicator m_indicatorPrefab;

	private Cake[] m_cakes;

	private CakeCompassIndicator[] m_indicators;
}
