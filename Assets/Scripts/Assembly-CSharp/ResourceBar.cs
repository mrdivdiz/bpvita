using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResourceBar : WPFMonoBehaviour
{
	public static ResourceBar Instance
	{
		get
		{
			if (ResourceBar.instance == null)
			{
				UnityEngine.Object.Instantiate<GameObject>(WPFMonoBehaviour.gameData.m_resourceBar);
			}
			return ResourceBar.instance;
		}
	}

	private void Awake()
	{
		if (ResourceBar.instance != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		ResourceBar.instance = this;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		this.leftItems = base.transform.Find("Left");
		this.rightItems = base.transform.Find("Right");
		this.locked = new Dictionary<Item, bool>
		{
			{
				ResourceBar.Item.PlayerProgress,
				false
			},
			{
				ResourceBar.Item.Scrap,
				false
			},
			{
				ResourceBar.Item.SnoutCoin,
				false
			},
			{
				ResourceBar.Item.StarCounter,
				false
			}
		};
		this.pending = new Dictionary<Item, Tuple<bool, bool>>
		{
			{
				ResourceBar.Item.PlayerProgress,
				new Tuple<bool, bool>(this.IsItemActive(ResourceBar.Item.PlayerProgress), this.IsItemEnabled(ResourceBar.Item.PlayerProgress))
			},
			{
				ResourceBar.Item.Scrap,
				new Tuple<bool, bool>(this.IsItemActive(ResourceBar.Item.Scrap), this.IsItemEnabled(ResourceBar.Item.Scrap))
			},
			{
				ResourceBar.Item.SnoutCoin,
				new Tuple<bool, bool>(this.IsItemActive(ResourceBar.Item.SnoutCoin), this.IsItemEnabled(ResourceBar.Item.SnoutCoin))
			},
			{
				ResourceBar.Item.StarCounter,
				new Tuple<bool, bool>(this.IsItemActive(ResourceBar.Item.StarCounter), this.IsItemEnabled(ResourceBar.Item.StarCounter))
			}
		};
		this.ShowItem(ResourceBar.Item.SnoutCoin, false, true);
		this.ShowItem(ResourceBar.Item.Scrap, false, true);
		this.ShowItem(ResourceBar.Item.PlayerProgress, false, true);
		this.ShowItem(ResourceBar.Item.StarCounter, false, true);
		SceneManager.sceneLoaded += this.OnSceneLoaded;
	}

	private void OnDestroy()
	{
		SceneManager.sceneLoaded -= this.OnSceneLoaded;
	}

	private void UpdateLayout()
	{
		if (WPFMonoBehaviour.hudCamera)
		{
			base.transform.position = WPFMonoBehaviour.hudCamera.transform.position + Vector3.up * WPFMonoBehaviour.hudCamera.orthographicSize + Vector3.forward * 1f;
		}
		float num = 0f;
		if (this.leftItems != null)
		{
			for (int i = 0; i < this.leftItems.childCount; i++)
			{
				Transform child = this.leftItems.GetChild(i);
				if (child.gameObject.activeInHierarchy)
				{
					ResourceBarItem component = child.GetComponent<ResourceBarItem>();
					if (component != null)
					{
						num += component.PaddingLeft;
						component.SetHorizontalPosition(num);
						num += component.PaddingRight;
					}
				}
			}
		}
		num = 0f;
		if (this.rightItems != null)
		{
			for (int j = this.rightItems.childCount - 1; j >= 0; j--)
			{
				Transform child2 = this.rightItems.GetChild(j);
				if (child2.gameObject.activeInHierarchy)
				{
					ResourceBarItem component2 = child2.GetComponent<ResourceBarItem>();
					if (component2 != null)
					{
						num -= component2.PaddingRight;
						component2.SetHorizontalPosition(num);
						num -= component2.PaddingLeft;
					}
				}
			}
		}
	}

	public bool IsItemActive(Item itemToShow)
	{
		if (this.locked[itemToShow])
		{
			return this.pending[itemToShow].Item1;
		}
		return this.items != null && itemToShow < (Item)this.items.Length && this.items[(int)itemToShow] != null && this.items[(int)itemToShow].IsShowing;
	}

	public bool IsItemEnabled(Item itemToShow)
	{
		if (this.locked[itemToShow])
		{
			return this.pending[itemToShow].Item2;
		}
		return this.items != null && itemToShow < (Item)this.items.Length && this.items[(int)itemToShow] != null && this.items[(int)itemToShow].IsEnabled;
	}

	public void ShowItem(Item itemToShow, bool showItem, bool enableItem = true)
	{
		if (this.locked[itemToShow])
		{
			this.pending[itemToShow].Item1 = showItem;
			this.pending[itemToShow].Item2 = enableItem;
		}
		else if (this.items != null && itemToShow < (Item)this.items.Length && this.items[(int)itemToShow] != null)
		{
			this.items[(int)itemToShow].SetItem(showItem, enableItem);
		}
	}

	public void LockItem(Item item, bool showItem, bool enableItem, bool revertable)
	{
		if (this.locked[item])
		{
			return;
		}
		this.pending[item].Item1 = ((!revertable) ? showItem : this.IsItemActive(item));
		this.pending[item].Item2 = ((!revertable) ? enableItem : this.IsItemEnabled(item));
		this.ShowItem(item, showItem, enableItem);
		this.locked[item] = true;
	}

	public void ReleaseItem(Item item)
	{
		if (!this.locked[item])
		{
			return;
		}
		this.locked[item] = false;
		this.ShowItem(item, this.pending[item].Item1, this.pending[item].Item2);
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
	{
		this.UpdateLayout();
	}

	private static ResourceBar instance;

	public ResourceBarItem[] items;

	private Transform leftItems;

	private Transform rightItems;

	private Dictionary<Item, bool> locked;

	private Dictionary<Item, Tuple<bool, bool>> pending;

	public enum Item
	{
		SnoutCoin,
		Scrap,
		PlayerProgress,
		StarCounter
	}
}
