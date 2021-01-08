using UnityEngine;

public class CrateCompass : MonoBehaviour
{
	private void OnEnable()
	{
		for (int i = base.transform.childCount - 1; i >= 0; i--)
		{
			UnityEngine.Object.Destroy(base.transform.GetChild(i).gameObject);
		}
		this.m_crates = UnityEngine.Object.FindObjectsOfType<LootCrate>();
		this.m_indicators = new CrateCompassIndicator[this.m_crates.Length];
		for (int j = 0; j < this.m_crates.Length; j++)
		{
			float z = -98f + 0.1f * (float)j;
			CrateCompassIndicator crateCompassIndicator = UnityEngine.Object.Instantiate<CrateCompassIndicator>(this.m_indicatorPrefab, new Vector3(0f, 15f, z), new Quaternion(0f, 0f, 0f, 0f));
			crateCompassIndicator.AttachToCrate(this.m_crates[j]);
			crateCompassIndicator.transform.parent = base.transform;
			this.m_indicators[j] = crateCompassIndicator;
		}
	}

	private void Update()
	{
		foreach (CrateCompassIndicator crateCompassIndicator in this.m_indicators)
		{
			if (!crateCompassIndicator.Done)
			{
				if (crateCompassIndicator.CheckCrateOnScreen())
				{
					crateCompassIndicator.Hide();
				}
				else
				{
					crateCompassIndicator.Show();
				}
			}
		}
	}

	[SerializeField]
	private CrateCompassIndicator m_indicatorPrefab;

	private LootCrate[] m_crates;

	private CrateCompassIndicator[] m_indicators;
}
