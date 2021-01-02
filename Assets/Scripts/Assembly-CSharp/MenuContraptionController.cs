using System.Collections.Generic;
using UnityEngine;

public class MenuContraptionController : MonoBehaviour
{
	public void StartRemoveTimer(float time)
	{
		this.m_removeTimerStarted = true;
		this.m_removeTime = time;
	}

	public Contraption CreateContraption(TextAsset contraptionData)
	{
		this.m_contraptionData = contraptionData;
		Vector2 v = base.transform.position;
		v.x = -5f + -15f * (float)Screen.width / (float)Screen.height;
		base.transform.position = v;
		Transform transform = UnityEngine.Object.Instantiate<Transform>(this.m_gameData.m_contraptionPrefab, base.transform.position, Quaternion.identity);
		transform.parent = base.transform;
		this.m_contraption = transform.GetComponent<Contraption>();
		ContraptionDataset cds = WPFPrefs.LoadContraptionDataset(this.m_contraptionData);
		this.BuildContraption(cds);
		this.m_contraption.StartContraption();
		this.m_contraption.ActivateAllPoweredParts();
		return this.m_contraption;
	}

	private void Update()
	{
		if (this.m_removeTimerStarted)
		{
			this.m_timer += Time.deltaTime;
			if (this.m_timer > this.m_removeTime)
			{
				this.m_removeTimerStarted = false;
				this.m_removePhase = true;
				this.m_timer = 0f;
				this.m_contraption.DestroyAllJoints();
				this.m_contraption.ActivateParts((BasePart part) => BasePart.BaseType(part.m_partType) == BasePart.PartType.Balloon || BasePart.BaseType(part.m_partType) == BasePart.PartType.Sandbag);
				this.m_partsToRemove = new Queue<BasePart>(this.m_contraption.Parts);
			}
		}
		else if (this.m_removePhase)
		{
			if (this.m_partsToRemove.Count > 0)
			{
				this.m_timer += Time.deltaTime;
				if (this.m_timer > 0.05f)
				{
					this.m_timer -= 0.05f;
					BasePart basePart = this.m_partsToRemove.Dequeue();
					if (basePart)
					{
						WPFMonoBehaviour.effectManager.CreateParticles(this.m_gameData.m_dustParticles.GetComponent<ParticleSystem>(), basePart.transform.position, false);
						basePart.transform.position += 1000f * Vector3.right;
					}
				}
			}
			else
			{
				UnityEngine.Object.Destroy(base.gameObject);
				UnityEngine.Object.Destroy(this.m_contraption.gameObject);
			}
		}
	}

	private void BuildContraption(ContraptionDataset cds)
	{
		Dictionary<BasePart.PartType, int> dictionary = new Dictionary<BasePart.PartType, int>();
		foreach (ContraptionDataset.ContraptionDatasetUnit contraptionDatasetUnit in cds.ContraptionDatasetList)
		{
			BasePart.PartType partType = (BasePart.PartType)contraptionDatasetUnit.partType;
			List<BasePart> list = new List<BasePart>(this.m_gameData.GetCustomPart(partType).PartList);
			for (int i = 0; i < list.Count; i++)
			{
				if (!list[i].craftable && !list[i].lootCrateReward)
				{
					list.RemoveAt(i--);
				}
			}
			BasePart basePart;
			if (dictionary.ContainsKey(partType))
			{
				basePart = ((dictionary[partType] != -1) ? list[dictionary[partType]] : this.m_gameData.GetPart(partType).GetComponent<BasePart>());
			}
			else if (UnityEngine.Random.Range(0, 100) > 50 && list.Count > 0)
			{
				int num = UnityEngine.Random.Range(0, list.Count);
				basePart = list[num];
				dictionary.Add(partType, num);
			}
			else
			{
				basePart = this.m_gameData.GetPart(partType).GetComponent<BasePart>();
				dictionary.Add(partType, -1);
			}
			if (contraptionDatasetUnit == null)
			{
			}
			if (basePart == null)
			{
			}
			this.BuildPart(contraptionDatasetUnit, basePart);
		}
	}

	private BasePart BuildPart(ContraptionDataset.ContraptionDatasetUnit cdu, BasePart partPrefab)
	{
		BasePart basePart = this.InstantiatePart(cdu.x, cdu.y, partPrefab);
		if (cdu.flipped)
		{
			basePart.SetFlipped(true);
		}
		else
		{
			basePart.SetRotation((BasePart.GridRotation)cdu.rot);
		}
		return basePart;
	}

	private BasePart InstantiatePart(int coordX, int coordY, BasePart partPrefab)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(partPrefab.gameObject);
		BasePart component = gameObject.GetComponent<BasePart>();
		component.PrePlaced();
		this.m_contraption.SetPartAt(coordX, coordY, component);
		return component;
	}

	public GameData m_gameData;

	private TextAsset m_contraptionData;

	private Contraption m_contraption;

	private float m_timer;

	private bool m_removeTimerStarted;

	private float m_removeTime;

	private bool m_removePhase;

	private Queue<BasePart> m_partsToRemove = new Queue<BasePart>();
}
