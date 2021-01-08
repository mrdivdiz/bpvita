using System;
using System.Collections.Generic;
using UnityEngine;

public class PartListing : Widget
{
	private int PartTypeCount
	{
		get
		{
			if (this.cachedPartTypeNames == null)
			{
				this.cachedPartTypeNames = Enum.GetNames(typeof(BasePart.PartType));
			}
			return this.cachedPartTypeNames.Length;
		}
	}

	private int PartTierCount
	{
		get
		{
			if (this.cachedPartTierNames == null)
			{
				this.cachedPartTierNames = Enum.GetNames(typeof(BasePart.PartTier));
			}
			return this.cachedPartTierNames.Length;
		}
	}

	private float MoveLimit
	{
		get
		{
			return WPFMonoBehaviour.hudCamera.orthographicSize * (float)Screen.width / (float)Screen.height - this.sideMargin;
		}
	}

	private float RightLimit
	{
		get
		{
			return -this.MoveLimit;
		}
	}

	private float LeftLimit
	{
		get
		{
			if (this.RightLimit < -(this.totalWidth - this.MoveLimit))
			{
				return this.RightLimit;
			}
			return -(this.totalWidth - this.MoveLimit);
		}
	}

	public float LastMovement
	{
		get
		{
			return this.lastMovement;
		}
	}

	private void Awake()
	{
		this.Init();
	}

	public void Init()
	{
		if (this.isInit)
		{
			return;
		}
		this.newButtons = new List<GameObject>();
		this.scrollbarNewTags = new Dictionary<GameObject, GameObject>();
		this.gameData = WPFMonoBehaviour.gameData;
		this.toggleButton.SetActive(false);
		this.emptyParts = new List<GameObject>();
		this.darkMaterials = new Dictionary<string, Material>();
		this.normalMaterials = new Dictionary<string, Material>();
		base.transform.position = WPFMonoBehaviour.hudCamera.transform.position + new Vector3(0f, 0f, 6f);
		this.columns = new List<float>();
		PartListing.instance = this;
		this.FillPartData();
		this.ReadPartOrder();
		this.isInit = true;
	}

	private void OnEnable()
	{
		if (this.scrollPivot == null)
		{
			this.CreateGUI();
		}
		BackgroundMask.Show(true, this, this.sortingLayer, base.transform, new Vector3(0f, 0f, 0.1f), false);
		Singleton<KeyListener>.Instance.GrabFocus(this);
		KeyListener.keyReleased += this.HandleKeyReleased;
	}

	private void OnDisable()
	{
		if (BackgroundMask.Instantiated)
		{
			BackgroundMask.Show(false, this, string.Empty, null, default(Vector3), false);
		}
		if (Singleton<KeyListener>.IsInstantiated())
		{
			Singleton<KeyListener>.Instance.ReleaseFocus(this);
			KeyListener.keyReleased -= this.HandleKeyReleased;
		}
	}

	private void OnDestroy()
	{
		if (!AtlasMaterials.IsInstantiated || this.darkMaterials == null)
		{
			return;
		}
		foreach (KeyValuePair<string, Material> keyValuePair in this.darkMaterials)
		{
			if (keyValuePair.Value != null)
			{
				AtlasMaterials.Instance.RemoveMaterialInstance(keyValuePair.Value);
			}
		}
	}

	public static PartListing Create()
	{
		if (PartListing.instance != null)
		{
			return PartListing.instance;
		}
		PartListing.instance = UnityEngine.Object.Instantiate<GameObject>(WPFMonoBehaviour.gameData.m_partListing).GetComponent<PartListing>();
		return PartListing.instance;
	}

	private void HandleKeyReleased(KeyCode key)
	{
		if (key == KeyCode.Escape)
		{
			this.Close();
		}
	}

	public void CreateSelectionIcons()
	{
		foreach (KeyValuePair<BasePart.PartType, PartData> keyValuePair in this.parts)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.selectedIcon);
			gameObject.transform.parent = this.scrollPivot;
			gameObject.name = keyValuePair.Key.ToString();
			this.SetSortingLayer(gameObject, this.sortingLayer);
		}
	}

	public void UpdateSelectionIcon(BasePart.PartType partType, string partName)
	{
		if (this.parts.ContainsKey(partType))
		{
			this.parts[partType].UpdateSelectionIcon(partName);
		}
	}

	public void ShowExperienceParticles(BasePart.PartType partType, string partName)
	{
		if (this.parts.ContainsKey(partType))
		{
			this.parts[partType].ShowXPParticles(partName);
		}
	}

	public void PlaySelectionAudio(BasePart.PartType partType, string partName)
	{
		if (this.parts.ContainsKey(partType))
		{
			this.parts[partType].PlaySelectionAudio(partName);
		}
	}

	public void OpenList()
	{
		this.SetPartScope(null);
		this.Open(null);
	}

	public void SetPartScope(List<BasePart.PartType> partScope)
	{
		this.customPartScope = partScope;
		if (this.customPartScope == null)
		{
			this.toggleButton.SetActive(false);
			this.showAll = true;
		}
		else
		{
			this.showAll = true;
			this.toggleButton.SetActive(true);
			this.ToggleScope();
		}
	}

	public void ToggleScope()
	{
		if (!this.isInit)
		{
			this.Init();
		}
		this.ClearNewTags(this.toggleButton);
		this.showAll = !this.showAll;
		int num = 0;
		int num2 = 0;
		this.columns.Clear();
		this.DisableEmptyIcons();
		if (this.showAll)
		{
			for (int i = 0; i < this.partOrder.Count; i++)
			{
				BasePart.PartType partType = this.partOrder[i];
				if (this.ValidPart(partType) && this.parts.ContainsKey(partType))
				{
					float num3 = (float)num * this.horizontalPadding + (float)num2 * this.partPadding;
					this.totalWidth = num3 + (float)(this.parts[partType].RowWidth() - 1) * this.horizontalPadding;
					this.RepositionIcons(this.parts[partType], num3);
					this.EnablePartIcons(this.parts[partType], true);
					num2++;
					num += this.parts[partType].RowWidth();
				}
			}
		}
		else if (!this.showAll && this.customPartScope != null)
		{
			for (int j = 0; j < this.partOrder.Count; j++)
			{
				BasePart.PartType partType2 = this.partOrder[j];
				if (this.ValidPart(partType2) && this.parts.ContainsKey(partType2))
				{
					if (this.customPartScope.Contains(partType2))
					{
						float num4 = (float)num * this.horizontalPadding + (float)num2 * this.partPadding;
						this.totalWidth = num4 + (float)(this.parts[partType2].RowWidth() - 1) * this.horizontalPadding;
						this.RepositionIcons(this.parts[partType2], num4);
						num2++;
						num += this.parts[partType2].RowWidth();
						this.EnablePartIcons(this.parts[partType2], true);
					}
					else
					{
						if (this.parts[partType2].ContainsNewParts())
						{
							this.AddNewContentTag(this.toggleButton);
						}
						this.EnablePartIcons(this.parts[partType2], false);
					}
				}
			}
		}
		this.toggleButton.transform.Find("Scoped").gameObject.SetActive(!this.showAll);
		this.toggleButton.transform.Find("Extended").gameObject.SetActive(this.showAll);
		this.targetPosition = this.GetTargetPosition();
		this.scrollbarNewTags.Clear();
		this.scrollbar.ClearNewPartButtons();
		this.InitNewButtons();
	}

	public void CenterOnPart(BasePart.PartType centerPart)
	{
		if (centerPart == BasePart.PartType.Unknown || (this.customPartScope != null && this.customPartScope.Contains(centerPart)))
		{
			this.centerPart = centerPart;
		}
	}

	public void Open(Action onClose)
	{
		this.onClose = onClose;
		this.Init();
		base.gameObject.SetActive(true);
		if (this.parts != null && this.parts.ContainsKey(this.centerPart))
		{
			this.MoveToPart(this.parts[this.centerPart].partInstances[BasePart.PartTier.Regular][0].transform);
		}
		this.scrollbarNewTags.Clear();
		this.scrollbar.ClearNewPartButtons();
		this.InitNewButtons();
	}

	public void Close()
	{
		base.gameObject.SetActive(false);
		if (this.onClose != null)
		{
			this.onClose();
		}
		this.onClose = null;
	}

	public List<GameObject> GetPartTierInstances(BasePart.PartType partType, BasePart.PartTier partTier)
	{
		if (this.parts != null && this.parts.ContainsKey(partType) && this.parts[partType].partInstances != null && this.parts[partType].partInstances.ContainsKey(partTier))
		{
			return this.parts[partType].partInstances[partTier];
		}
		return null;
	}

	public void SetRelativePosition(float x)
	{
		this.deltaX = 0f;
		this.targetPosition = this.GetTargetPosition(-Mathf.Abs(this.LeftLimit - this.RightLimit) * x + this.RightLimit);
	}

	private void FillPartData()
	{
		this.parts = new Dictionary<BasePart.PartType, PartData>();
		for (int i = 0; i < this.PartTypeCount; i++)
		{
			BasePart.PartType partType = (BasePart.PartType)i;
			if (this.ValidPart(partType))
			{
				GameObject part = this.gameData.GetPart(partType);
				if (part != null)
				{
					this.parts.Add(partType, new PartData(part.GetComponent<BasePart>(), this));
				}
			}
		}
	}

	private void ReadPartOrder()
	{
		this.partOrder = new List<BasePart.PartType>();
		string text = this.gameData.m_partOrderList.text;
		string[] array = text.Split(new char[]
		{
			'\n'
		});
		for (int i = 0; i < array.Length; i++)
		{
			if (!string.IsNullOrEmpty(array[i]))
			{
				try
				{
					this.partOrder.Add((BasePart.PartType)Enum.Parse(typeof(BasePart.PartType), array[i]));
				}
				catch
				{
				}
			}
		}
	}

	private bool ValidPart(BasePart.PartType type)
	{
		if (type == BasePart.PartType.Pumpkin)
		{
			return GameProgress.HasKey("SecretPumpkin", GameProgress.Location.Local, null);
		}
		return type != BasePart.PartType.Unknown && type != BasePart.PartType.MAX && type != BasePart.PartType.ObsoleteWheel && type != BasePart.PartType.JetEngine && type != BasePart.PartType.TimeBomb;
	}

	private void ClearGUI()
	{
		if (this.scrollPivot != null)
		{
			UnityEngine.Object.Destroy(this.scrollPivot.gameObject);
		}
		this.columns.Clear();
		for (int i = 0; i < this.PartTypeCount; i++)
		{
			if (this.parts.ContainsKey((BasePart.PartType)i))
			{
				this.parts[(BasePart.PartType)i].ClearPartRoots();
			}
		}
	}

	private void CreateGUI()
	{
		this.ClearNewbuttons();
		int num = 0;
		int num2 = 0;
		GameObject gameObject = new GameObject("Pivot");
		gameObject.transform.parent = base.transform;
		gameObject.transform.localPosition = Vector3.zero;
		this.scrollPivot = gameObject.transform;
		for (int i = 0; i < this.partOrder.Count; i++)
		{
			BasePart.PartType partType = this.partOrder[i];
			if (this.ValidPart(partType))
			{
				float num3 = (float)num * this.horizontalPadding + (float)num2 * this.partPadding;
                PartData partData = this.parts[partType];
				this.totalWidth = num3 + (float)(partData.RowWidth() - 1) * this.horizontalPadding;
				this.CreatePartIcons(partData, num3, gameObject.transform, this.newButtons);
				num2++;
				num += partData.RowWidth();
			}
		}
		this.scrollPivot.localPosition = new Vector3(this.GetTargetPosition(), this.scrollPivot.localPosition.y, this.scrollPivot.localPosition.z);
		this.targetPosition = this.GetTargetPosition();
		this.InitNewButtons();
	}

	private void CreatePartIcons(PartData data, float xPos, Transform parent, List<GameObject> newButtons)
	{
		for (int i = 0; i < this.PartTierCount - 1; i++)
		{
			for (int j = 0; j < data.RowWidth(); j++)
			{
				int index = j;
				Vector3 localPosition = new Vector3(xPos + (float)index * this.horizontalPadding, (float)(this.PartTierCount / 2) - (float)i * this.verticalPadding + this.verticalPadding);
				localPosition.y += ((i != 0) ? 0f : this.firstRowPadding);
				BasePart.PartTier tier = (BasePart.PartTier)i;
				bool flag;
				if (tier == BasePart.PartTier.Epic)
				{
					flag = (index < data.PartCount(tier) || data.PartCount(BasePart.PartTier.Legendary) > 0);
					if (index >= data.PartCount(tier))
					{
						index -= data.PartCount(tier);
						tier = BasePart.PartTier.Legendary;
					}
				}
				else
				{
					flag = (index < data.PartCount(tier));
				}
				if (!this.columns.Contains(localPosition.x))
				{
					this.columns.Add(localPosition.x);
				}
				if (flag)
				{
					GameObject bg = UnityEngine.Object.Instantiate<GameObject>(this.GetIconBackground(tier));
					bg.transform.parent = parent;
					bg.transform.localPosition = localPosition;
                    Sprite icon2 = data.GetIcon(tier, index);
					GameObject icon = null;
					if (icon2 != null)
					{
						icon = UnityEngine.Object.Instantiate<GameObject>(icon2.gameObject);
						icon.transform.parent = bg.transform;
						icon.transform.localPosition = new Vector3(0f, 0f, -0.1f);
						icon.transform.localScale = Vector3.one * this.iconScale;
					}
					if (tier != BasePart.PartTier.Regular)
					{
						this.ToGray(bg, !CustomizationManager.IsPartUnlocked(data.parts[tier][index]));
					}
					if (this.IsKingsFavorite(data.parts[tier][index]))
					{
						GameObject gameObject;
						this.AddKingsFavoriteTag(bg, out gameObject);
					}
					GameObject item;
					if (CustomizationManager.IsPartNew(data.parts[tier][index]) && this.AddNewContentTag(bg, out item))
					{
						newButtons.Add(item);
					}
					data.AddPartRoot(tier, bg);
					Button button = bg.GetComponentInChildren<Button>();
					GameObjectEvents gameObjectEvents = bg.AddComponent<GameObjectEvents>();
					GameObjectEvents gameObjectEvents2 = gameObjectEvents;
					gameObjectEvents2.OnEnabled = (Action<bool>)Delegate.Combine(gameObjectEvents2.OnEnabled, new Action<bool>(delegate(bool enabled)
					{
						if (enabled)
						{
							if (this.IsKingsFavorite(data.parts[tier][index]))
							{
								GameObject gameObject2;
								this.AddKingsFavoriteTag(bg, out gameObject2);
							}
							else
							{
								this.ClearKingsFavoriteTag(bg);
							}
							if (tier != BasePart.PartTier.Regular)
							{
								bool flag2 = CustomizationManager.IsPartUnlocked(data.parts[tier][index]);
								this.ToGray(bg, !flag2);
								Collider component = bg.GetComponent<Collider>();
								component.enabled = flag2;
								button.enabled = flag2;
								if (tier == BasePart.PartTier.Legendary)
								{
									if (icon)
									{
										icon.SetActive(flag2);
									}
									bg.transform.Find("QuestionMark").gameObject.SetActive(!flag2);
								}
								int lastUsedPartIndex = CustomizationManager.GetLastUsedPartIndex(data.PartType);
								data.UpdateSelectionIcon(this.gameData.GetCustomPart(data.PartType, lastUsedPartIndex).name);
								if (CustomizationManager.IsPartNew(data.parts[tier][index]))
								{
									GameObject item2;
									if (this.AddNewContentTag(bg, out item2))
									{
										newButtons.Add(item2);
									}
								}
								else
								{
									this.ClearNewTags(bg);
								}
							}
						}
					}));
					GameObjectEvents gameObjectEvents3 = gameObjectEvents;
					gameObjectEvents3.OnVisible = (Action<bool>)Delegate.Combine(gameObjectEvents3.OnVisible, new Action<bool>(delegate(bool visible)
					{
						button.enabled = visible;
					}));
					this.SetSortingLayer(bg, this.sortingLayer);
				}
			}
		}
	}

	private void EnablePartIcons(PartData data, bool enable)
	{
		if (data.SelectedIcon != null)
		{
			data.SelectedIcon.gameObject.SetActive(enable);
		}
		for (int i = 0; i < this.PartTierCount; i++)
		{
			BasePart.PartTier key = (BasePart.PartTier)i;
			if (data.partInstances != null && data.partInstances.ContainsKey(key))
			{
				for (int j = 0; j < data.partInstances[key].Count; j++)
				{
					data.partInstances[key][j].SetActive(enable);
				}
			}
		}
	}

	private void RepositionIcons(PartData data, float xPos)
	{
		for (int i = 0; i < this.PartTierCount - 1; i++)
		{
			for (int j = 0; j < data.RowWidth(); j++)
			{
				int index = j;
				BasePart.PartTier tier = (BasePart.PartTier)i;
				Vector3 localPosition = new Vector3(xPos + (float)index * this.horizontalPadding, (float)(this.PartTierCount / 2) - (float)i * this.verticalPadding + this.verticalPadding);
				localPosition.y += ((i != 0) ? 0f : this.firstRowPadding);
				if (!this.columns.Contains(localPosition.x))
				{
					this.columns.Add(localPosition.x);
				}
				if (tier == BasePart.PartTier.Epic && index >= data.PartCount(tier))
				{
					index -= data.PartCount(tier);
					tier = BasePart.PartTier.Legendary;
				}
				if (data.partInstances.ContainsKey(tier) && index < data.partInstances[tier].Count)
				{
					data.partInstances[tier][index].transform.localPosition = localPosition;
					if (CustomizationManager.IsPartNew(data.parts[tier][index]))
					{
                        PartData data_ = data;
						GameObject gameObject;
						if (this.AddNewContentTag(data.partInstances[tier][index], out gameObject))
						{
							GameObjectEvents gameObjectEvents = gameObject.AddComponent<GameObjectEvents>();
							GameObjectEvents gameObjectEvents2 = gameObjectEvents;
							gameObjectEvents2.OnVisible = (Action<bool>)Delegate.Combine(gameObjectEvents2.OnVisible, new Action<bool>(delegate(bool visible)
							{
								if (visible)
								{
									CustomizationManager.SetPartNew(data_.parts[tier][index], false);
								}
							}));
							this.newButtons.Add(gameObject);
						}
					}
				}
			}
		}
		int lastUsedPartIndex = CustomizationManager.GetLastUsedPartIndex(data.PartType);
		data.UpdateSelectionIcon(this.gameData.GetCustomPart(data.PartType, lastUsedPartIndex).name);
	}

	private void ClearNewbuttons()
	{
		while (this.newButtons.Count > 0)
		{
			UnityEngine.Object.Destroy(this.newButtons[0]);
			this.newButtons.RemoveAt(0);
		}
		this.scrollbarNewTags.Clear();
		this.scrollbar.ClearNewPartButtons();
	}

	private void ClearNewTags(GameObject go)
	{
		Transform transform = go.transform.Find("NewContentTag");
		if (transform != null)
		{
			for (int i = 0; i < transform.transform.childCount; i++)
			{
				Transform child = transform.GetChild(i);
				if (child.name == "NewTag")
				{
					child.parent = null;
					UnityEngine.Object.Destroy(child.gameObject);
					i--;
				}
			}
		}
	}

	private void ClearKingsFavoriteTag(GameObject go)
	{
		Transform transform = go.transform.Find("NewContentTag");
		if (transform != null)
		{
			for (int i = 0; i < transform.transform.childCount; i++)
			{
				Transform child = transform.GetChild(i);
				if (child.name == "KingsFavorite")
				{
					child.parent = null;
					UnityEngine.Object.Destroy(child.gameObject);
					i--;
				}
			}
		}
	}

	private void InitNewButtons()
	{
		for (int i = 0; i < this.newButtons.Count; i++)
		{
			if (this.newButtons[i] == null)
			{
				this.newButtons.RemoveAt(i--);
			}
			else if (this.newButtons[i].activeInHierarchy && !(this.newButtons[i].transform.parent == null) && !(this.newButtons[i].transform.parent.parent == null))
			{
				GameObject value = this.scrollbar.SetNewPartButton(this.CalculateRelativePosition(this.RightLimit - this.newButtons[i].transform.parent.parent.localPosition.x));
				this.scrollbarNewTags.Add(this.newButtons[i].transform.parent.parent.gameObject, value);
			}
		}
	}

	private void ToDark(GameObject go, bool dark)
	{
		Renderer[] componentsInChildren = go.GetComponentsInChildren<Renderer>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (!(componentsInChildren[i].gameObject.name == "NewTag") && !(componentsInChildren[i].gameObject.name == "New") && !(componentsInChildren[i].gameObject.name == "KingsFavorite"))
			{
				componentsInChildren[i].sharedMaterial = ((!dark) ? this.GetNormalMaterial(componentsInChildren[i].sharedMaterial) : this.GetDarkMaterial(componentsInChildren[i].sharedMaterial));
			}
		}
	}

	private void ToGray(GameObject go, bool gray)
	{
		Renderer[] componentsInChildren = go.GetComponentsInChildren<Renderer>(true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (!(componentsInChildren[i].gameObject.name == "NewTag") && !(componentsInChildren[i].gameObject.name == "New") && !(componentsInChildren[i].gameObject.name == "KingsFavorite"))
			{
				if (!gray || !this.IsGrayMaterial(componentsInChildren[i].sharedMaterial))
				{
					componentsInChildren[i].sharedMaterial = ((!gray) ? this.GetNormalMaterial(componentsInChildren[i].sharedMaterial) : this.GetGreyMaterial(componentsInChildren[i].sharedMaterial));
				}
			}
		}
	}

	private void SetSortingLayer(GameObject go, string layer)
	{
		Renderer[] componentsInChildren = go.GetComponentsInChildren<Renderer>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].sortingLayerName = layer;
		}
	}

	private Material GetDarkMaterial(Material mat)
	{
		if (this.darkMaterials.ContainsKey(mat.name))
		{
			return this.darkMaterials[mat.name];
		}
		Material material = new Material(mat);
		AtlasMaterials.Instance.AddMaterialInstance(material);
		material.color = ((!this.IsGrayMaterial(mat)) ? this.darken : this.darkenGray);
		this.darkMaterials.Add(mat.name, material);
		if (!this.normalMaterials.ContainsKey(mat.name))
		{
			this.normalMaterials.Add(material.name, mat);
		}
		return material;
	}

	private Material GetNormalMaterial(Material mat)
	{
		if (this.normalMaterials.ContainsKey(mat.name))
		{
			return this.normalMaterials[mat.name];
		}
		return mat;
	}

	private bool AddNewContentTag(GameObject parent)
	{
		Transform transform = parent.transform.Find("NewContentTag");
		if (transform != null && transform.childCount <= 0)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.newContentTag);
			gameObject.transform.parent = transform;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.name = "NewTag";
			this.SetSortingLayer(gameObject, this.sortingLayer);
			return true;
		}
		return false;
	}

	private bool AddNewContentTag(GameObject parent, out GameObject tag)
	{
		Transform transform = parent.transform.Find("NewContentTag");
		if (transform != null && transform.childCount <= 0)
		{
			tag = UnityEngine.Object.Instantiate<GameObject>(this.newContentTag);
			tag.transform.parent = transform;
			tag.transform.localPosition = Vector3.zero;
			tag.name = "NewTag";
			this.SetSortingLayer(tag, this.sortingLayer);
			return true;
		}
		tag = null;
		return false;
	}

	private bool AddKingsFavoriteTag(GameObject parent, out GameObject tag)
	{
		Transform transform = parent.transform.Find("NewContentTag");
		if (transform != null && transform.childCount <= 0)
		{
			tag = UnityEngine.Object.Instantiate<GameObject>(this.kingsFavoriteTag);
			tag.transform.parent = transform;
			tag.transform.localPosition = Vector3.zero;
			tag.name = "KingsFavorite";
			this.SetSortingLayer(tag, this.sortingLayer);
			return true;
		}
		tag = null;
		return false;
	}

	private GameObject GetIconBackground(BasePart.PartTier tier)
	{
		switch (tier)
		{
		default:
			return this.regularIcon;
		case BasePart.PartTier.Common:
			return this.commonIcon;
		case BasePart.PartTier.Rare:
			return this.rareIcon;
		case BasePart.PartTier.Epic:
			return this.epicIcon;
		case BasePart.PartTier.Legendary:
			return this.legendaryIcon;
		}
	}

	private void DisableEmptyIcons()
	{
		for (int i = 0; i < this.emptyParts.Count; i++)
		{
			if (this.emptyParts[i] == null)
			{
				this.emptyParts.RemoveAt(i--);
			}
			else
			{
				this.emptyParts[i].SetActive(false);
			}
		}
	}

	private GameObject GetUnusedEmptyIcon()
	{
		for (int i = 0; i < this.emptyParts.Count; i++)
		{
			if (!(this.emptyParts[i] == null))
			{
				if (!this.emptyParts[i].activeSelf)
				{
					return this.emptyParts[i];
				}
			}
		}
		return UnityEngine.Object.Instantiate<GameObject>(this.emptyIcon);
	}

	private bool IsKingsFavorite(BasePart part)
	{
		return (WPFMonoBehaviour.levelManager == null || WPFMonoBehaviour.levelManager.CurrentGameMode is CakeRaceMode) && GameProgress.GetBool("CakeRaceUnlockShown", false, GameProgress.Location.Local, null) && Singleton<CakeRaceKingsFavorite>.Instance.CurrentFavorite != null && Singleton<CakeRaceKingsFavorite>.Instance.CurrentFavorite.name == part.name;
	}

	private void Update()
	{
		GuiManager.Pointer pointer = GuiManager.GetPointer();
		if (pointer.dragging && !this.interacting && this.PointerIsTouching(pointer.position))
		{
			this.lastInputPos = pointer.position;
			this.interacting = true;
			if (this.OnPartListDragBegin != null)
			{
				this.OnPartListDragBegin();
			}
		}
		if (pointer.dragging && this.interacting)
		{
			Vector3 vector = WPFMonoBehaviour.hudCamera.ScreenToWorldPoint(this.lastInputPos);
			Vector3 vector2 = WPFMonoBehaviour.hudCamera.ScreenToWorldPoint(pointer.position);
			this.lastInputPos = pointer.position;
			this.deltaX = vector2.x - vector.x;
			this.lastMovement += Mathf.Abs(this.deltaX);
			if (Mathf.Abs(this.deltaX) > 0f)
			{
				this.Move(this.deltaX, true);
			}
		}
		if (pointer.up && this.interacting)
		{
			this.interacting = false;
			this.lastMovement = 0f;
		}
		if (!this.interacting)
		{
			if (Mathf.Abs(this.deltaX) > 0.1f)
			{
				this.Move(this.deltaX, true);
				this.deltaX -= this.deltaX / (float)this.momentumSlide;
			}
			else
			{
				float num = this.scrollPivot.localPosition.x - this.targetPosition;
				float num2 = Mathf.SmoothDamp(num, 0f, ref this.xVelocity, 0.2f);
				this.Move(num2 - num, false);
			}
		}
	}

	private bool PointerIsTouching(Vector3 pointerPos)
	{
		Vector3 vector = base.transform.InverseTransformPoint(WPFMonoBehaviour.hudCamera.ScreenToWorldPoint(pointerPos));
		return vector.y < 6.5f && vector.y > -6f;
	}

	private void Move(float delta, bool checkTarget = true)
	{
		if (checkTarget && this.scrollPivot.localPosition.x < this.LeftLimit - this.limitMargin && delta < 0f)
		{
			this.deltaX = 0f;
			this.targetPosition = this.GetTargetPosition();
		}
		else if (checkTarget && this.scrollPivot.localPosition.x > this.RightLimit + this.limitMargin && delta > 0f)
		{
			this.deltaX = 0f;
			this.targetPosition = this.GetTargetPosition();
		}
		else
		{
			this.scrollPivot.localPosition = new Vector3(this.scrollPivot.localPosition.x + delta, this.scrollPivot.localPosition.y, this.scrollPivot.localPosition.z);
			if (this.OnPartListingMoved != null)
			{
				this.OnPartListingMoved(this.CalculateRelativePosition(this.scrollPivot.localPosition.x));
			}
		}
		if (checkTarget)
		{
			this.targetPosition = this.GetTargetPosition();
		}
	}

	private void MoveToPart(Transform targetTf)
	{
		if (targetTf == null)
		{
			return;
		}
		this.targetPosition = this.GetTargetPosition(-targetTf.localPosition.x);
		float num = this.scrollPivot.localPosition.x - this.targetPosition;
		this.deltaX = 0f;
		this.Move(-num, false);
	}

	private float GetTargetPosition(float forPosition)
	{
		float num = float.MaxValue;
		int i = 0;
		while (i < this.columns.Count)
		{
			if (num > Mathf.Abs(forPosition + this.columns[i] - this.RightLimit))
			{
				num = Mathf.Abs(forPosition + this.columns[i] - this.RightLimit);
				i++;
			}
			else
			{
				if (i == 1)
				{
					return Mathf.Clamp(-this.columns[i - 1] + this.RightLimit, this.LeftLimit, this.RightLimit);
				}
				return Mathf.Clamp(-this.columns[i - 1] + this.RightLimit - this.sideMargin + this.iconScale, this.LeftLimit, this.RightLimit);
			}
		}
		return Mathf.Clamp(-num, this.LeftLimit, this.RightLimit);
	}

	private float GetTargetPosition()
	{
		return this.GetTargetPosition(this.scrollPivot.localPosition.x);
	}

	private Material GetGreyMaterial(Material material)
	{
		AtlasMaterials atlasMaterials = AtlasMaterials.Instance;
		for (int i = 0; i < atlasMaterials.NormalMaterials.Count; i++)
		{
			if (material.name.Equals(atlasMaterials.NormalMaterials[i].name))
			{
				if (!this.normalMaterials.ContainsKey(atlasMaterials.GrayMaterials[i].name))
				{
					this.normalMaterials.Add(atlasMaterials.GrayMaterials[i].name, material);
				}
				return atlasMaterials.GrayMaterials[i];
			}
		}
		for (int j = 0; j < atlasMaterials.NormalMaterials.Count; j++)
		{
			if (material.name.Equals(atlasMaterials.RenderQueueMaterials[j].name))
			{
				if (!this.normalMaterials.ContainsKey(atlasMaterials.GrayMaterials[j].name))
				{
					this.normalMaterials.Add(atlasMaterials.GrayMaterials[j].name, material);
				}
				return atlasMaterials.GrayMaterials[j];
			}
		}
		if (!this.normalMaterials.ContainsKey(this.grayMaterial.name))
		{
			this.normalMaterials.Add(this.grayMaterial.name, material);
		}
		return this.grayMaterial;
	}

	private bool IsGrayMaterial(Material material)
	{
		AtlasMaterials atlasMaterials = AtlasMaterials.Instance;
		for (int i = 0; i < atlasMaterials.GrayMaterials.Count; i++)
		{
			if (material.name.Equals(atlasMaterials.GrayMaterials[i].name))
			{
				return true;
			}
		}
		return material.name.Contains("Gray");
	}

	private float CalculateRelativePosition(float position)
	{
		float num = Mathf.Abs(position - this.RightLimit);
		float num2 = Mathf.Abs(this.LeftLimit - this.RightLimit);
		if (num2 == 0f)
		{
			return 0.5f;
		}
		if (position > this.RightLimit)
		{
			return Mathf.Clamp01(-(num / num2));
		}
		return Mathf.Clamp01(num / num2);
	}

	public void OpenShop()
	{
		base.gameObject.SetActive(false);
		LevelManager levelManager = WPFMonoBehaviour.levelManager;
		if (levelManager != null)
		{
			levelManager.InGameGUI.Hide();
			Singleton<IapManager>.Instance.OpenShopPage(delegate
			{
				this.gameObject.SetActive(true);
				levelManager.InGameGUI.Show();
			}, "FieldOfDreams");
		}
		else
		{
			Singleton<IapManager>.Instance.OpenShopPage(delegate
			{
				this.gameObject.SetActive(true);
			}, "FieldOfDreams");
		}
	}

	public Action<float> OnPartListingMoved;

	public Action OnPartListDragBegin;

	[SerializeField]
	private float verticalPadding;

	[SerializeField]
	private float horizontalPadding;

	[SerializeField]
	private float partPadding;

	[SerializeField]
	private float firstRowPadding;

	[SerializeField]
	private GameObject regularIcon;

	[SerializeField]
	private GameObject commonIcon;

	[SerializeField]
	private GameObject rareIcon;

	[SerializeField]
	private GameObject epicIcon;

	[SerializeField]
	private GameObject legendaryIcon;

	[SerializeField]
	private GameObject emptyIcon;

	[SerializeField]
	private GameObject selectedIcon;

	[SerializeField]
	private PartListingScrollbar scrollbar;

	[SerializeField]
	private int momentumSlide;

	[SerializeField]
	private float limitMargin;

	[SerializeField]
	private float sideMargin;

	[SerializeField]
	private float iconScale;

	[SerializeField]
	private Color darken;

	[SerializeField]
	private Color darkenGray;

	[SerializeField]
	private Material grayMaterial;

	[SerializeField]
	private GameObject newContentTag;

	[SerializeField]
	private GameObject kingsFavoriteTag;

	[SerializeField]
	private GameObject toggleButton;

	[SerializeField]
	private string sortingLayer;

	private static PartListing instance;

	private Dictionary<string, Material> darkMaterials;

	private Dictionary<string, Material> normalMaterials;

	private Vector2 lastInputPos;

	private float deltaX;

	private float totalWidth;

	private float targetPosition;

	private float lastMovement;

	private bool interacting;

	private bool targeting;

	private Transform scrollPivot;

	private List<float> columns;

	private float xVelocity;

	private bool isInit;

	private bool showAll = true;

	private Action onClose;

	private Dictionary<BasePart.PartType, PartData> parts;

	private Dictionary<GameObject, GameObject> scrollbarNewTags;

	private List<GameObject> newButtons;

	private List<BasePart.PartType> partOrder;

	private List<BasePart.PartType> customPartScope;

	private List<GameObject> emptyParts;

	private BasePart.PartType centerPart;

	private GameData gameData;

	private string[] cachedPartTypeNames;

	private string[] cachedPartTierNames;

	private class PartData
	{
		public PartData(BasePart part, PartListing partListInstance)
		{
			PartListing.PartData.partList = partListInstance;
			this.parts = new Dictionary<BasePart.PartTier, List<BasePart>>();
			this.parts.Add(part.m_partTier, new List<BasePart>());
			this.parts[part.m_partTier].Add(part);
			this.type = part.m_partType;
			CustomPartInfo customPart = WPFMonoBehaviour.gameData.GetCustomPart(part.m_partType);
			this.partInstances = new Dictionary<BasePart.PartTier, List<GameObject>>();
			this.partInstances.Add(part.m_partTier, new List<GameObject>());
			this.selectedIcon = null;
			if (customPart == null)
			{
				return;
			}
			for (int i = 0; i < customPart.PartList.Count; i++)
			{
				if (customPart.PartList[i].VisibleOnPartListBeforeUnlocking)
				{
					if (!this.parts.ContainsKey(customPart.PartList[i].m_partTier))
					{
						this.parts.Add(customPart.PartList[i].m_partTier, new List<BasePart>());
					}
					this.parts[customPart.PartList[i].m_partTier].Add(customPart.PartList[i]);
					if (!this.partInstances.ContainsKey(customPart.PartList[i].m_partTier))
					{
						this.partInstances.Add(customPart.PartList[i].m_partTier, new List<GameObject>());
					}
				}
			}
		}

		public BasePart.PartType PartType
		{
			get
			{
				return this.type;
			}
		}

		public Transform SelectedIcon
		{
			get
			{
				return this.selectedIcon;
			}
		}

		public int PartCount(BasePart.PartTier tier)
		{
			return (!this.parts.ContainsKey(tier)) ? 0 : this.parts[tier].Count;
		}

		public int RowWidth()
		{
			int num = 0;
			foreach (KeyValuePair<BasePart.PartTier, List<BasePart>> keyValuePair in this.parts)
			{
				if (keyValuePair.Value.Count > num)
				{
					num = keyValuePair.Value.Count;
				}
			}
			if (this.parts.ContainsKey(BasePart.PartTier.Epic) && this.parts.ContainsKey(BasePart.PartTier.Legendary))
			{
				int num2 = this.parts[BasePart.PartTier.Epic].Count + this.parts[BasePart.PartTier.Legendary].Count;
				num = ((num2 <= num) ? num : num2);
			}
			return num;
		}

		public Sprite GetIcon(BasePart.PartTier tier, int index)
		{
			BasePart basePart = (index >= this.PartCount(tier)) ? null : this.parts[tier][index];
			return basePart.m_constructionIconSprite;
		}

		public void AddPartRoot(BasePart.PartTier partTier, GameObject partRoot)
		{
			if (this.partInstances.ContainsKey(partTier) && this.parts.ContainsKey(partTier))
			{
				partRoot.name = this.parts[partTier][this.partInstances[partTier].Count].name;
				this.partInstances[partTier].Add(partRoot);
			}
		}

		public void AddSelectedIcon(Transform icon)
		{
			this.selectedIcon = icon;
			int lastUsedPartIndex = CustomizationManager.GetLastUsedPartIndex(this.type);
			this.UpdateSelectionIcon(WPFMonoBehaviour.gameData.GetCustomPart(this.type, lastUsedPartIndex).name);
		}

		public void UpdateSelectionIcon(string partName)
		{
			if (this.partInstances != null)
			{
				foreach (KeyValuePair<BasePart.PartTier, List<GameObject>> keyValuePair in this.partInstances)
				{
					int num = 0;
					foreach (GameObject gameObject in keyValuePair.Value)
					{
						if (partName == gameObject.name)
						{
							PartListing.PartData.partList.ToDark(gameObject, false);
							PartListing.PartData.partList.ClearNewTags(gameObject);
							if (PartListing.PartData.partList.scrollbarNewTags.ContainsKey(gameObject))
							{
								UnityEngine.Object.Destroy(PartListing.PartData.partList.scrollbarNewTags[gameObject]);
								PartListing.PartData.partList.scrollbarNewTags.Remove(gameObject);
							}
						}
						else if (gameObject != null)
						{
							PartListing.PartData.partList.ToDark(gameObject, true);
						}
						num++;
					}
				}
			}
		}

		public void ShowXPParticles(string partName)
		{
			if (this.partInstances == null)
			{
				return;
			}
			foreach (KeyValuePair<BasePart.PartTier, List<GameObject>> keyValuePair in this.partInstances)
			{
				int i = 0;
				while (i < keyValuePair.Value.Count)
				{
					if (partName == keyValuePair.Value[i].name)
					{
						GameObject gameObject;
						switch (keyValuePair.Key)
						{
						case BasePart.PartTier.Common:
							gameObject = WPFMonoBehaviour.gameData.m_xpParticlesSmall;
							break;
						case BasePart.PartTier.Rare:
							gameObject = WPFMonoBehaviour.gameData.m_xpParticlesMedium;
							break;
						case BasePart.PartTier.Epic:
						case BasePart.PartTier.Legendary:
							gameObject = WPFMonoBehaviour.gameData.m_xpParticlesLarge;
							break;
						default:
							gameObject = null;
							break;
						}
						if (gameObject == null)
						{
							return;
						}
						GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(gameObject, keyValuePair.Value[i].transform.position + Vector3.back, Quaternion.identity);
						LayerHelper.SetLayer(gameObject2, keyValuePair.Value[i].layer, true);
						LayerHelper.SetOrderInLayer(gameObject2, 1, true);
						LayerHelper.SetSortingLayer(gameObject2, keyValuePair.Value[i].GetComponent<Renderer>().sortingLayerName, true);
						gameObject2.GetComponent<Renderer>().sortingLayerID = keyValuePair.Value[i].GetComponent<Renderer>().sortingLayerID;
						ParticleSystem component = gameObject2.GetComponent<ParticleSystem>();
						UnityEngine.Object.Destroy(gameObject2, component.time + component.startLifetime);
						return;
					}
					else
					{
						i++;
					}
				}
			}
		}

		public void PlaySelectionAudio(string partName)
		{
			if (this.parts == null)
			{
				return;
			}
			foreach (KeyValuePair<BasePart.PartTier, List<BasePart>> keyValuePair in this.parts)
			{
				for (int i = 0; i < keyValuePair.Value.Count; i++)
				{
					if (keyValuePair.Value[i].name == partName)
					{
						for (int j = 0; j < keyValuePair.Value[i].tags.Count; j++)
						{
							string text = keyValuePair.Value[i].tags[j];
							if (text != null)
							{
								if (!(text == "Xmas_pig"))
								{
									if (!(text == "Alien_pig"))
									{
										if (text == "Alien_part")
										{
											Singleton<AudioManager>.Instance.SpawnOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.alienBeepBoop, WPFMonoBehaviour.mainCamera.transform.position);
										}
									}
									else
									{
										AudioSource[] alienLanguage = WPFMonoBehaviour.gameData.commonAudioCollection.alienLanguage;
										AudioSource effectSource = alienLanguage[UnityEngine.Random.Range(0, alienLanguage.Length)];
										Singleton<AudioManager>.Instance.SpawnOneShotEffect(effectSource, WPFMonoBehaviour.mainCamera.transform.position);
									}
								}
								else
								{
									Singleton<AudioManager>.Instance.SpawnOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.jingleBell, WPFMonoBehaviour.mainCamera.transform.position);
								}
							}
						}
					}
				}
			}
		}

		public bool ContainsNewParts()
		{
			foreach (KeyValuePair<BasePart.PartTier, List<BasePart>> keyValuePair in this.parts)
			{
				for (int i = 0; i < keyValuePair.Value.Count; i++)
				{
					if (CustomizationManager.IsPartNew(keyValuePair.Value[i]))
					{
						return true;
					}
				}
			}
			return false;
		}

		public void ClearPartRoots()
		{
			foreach (KeyValuePair<BasePart.PartTier, List<GameObject>> keyValuePair in this.partInstances)
			{
				keyValuePair.Value.Clear();
			}
		}

		private static PartListing partList;

		public Dictionary<BasePart.PartTier, List<BasePart>> parts;

		public Dictionary<BasePart.PartTier, List<GameObject>> partInstances;

		private Transform selectedIcon;

		private BasePart.PartType type;
	}
}
