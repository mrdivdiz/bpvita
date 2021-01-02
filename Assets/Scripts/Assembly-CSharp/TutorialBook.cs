using System.Collections.Generic;
using UnityEngine;

public class TutorialBook : WPFMonoBehaviour
{
	public GameObject GetPage(int pageNumber)
	{
		int num = pageNumber - 1;
		if (num >= 0 && num < this.m_pages.Count)
		{
			return this.m_pages[num];
		}
		return null;
	}

	protected virtual void Awake()
	{
		bool flag = WPFMonoBehaviour.levelManager && WPFMonoBehaviour.levelManager.m_showPowerupTutorial;
		if (!flag && WPFMonoBehaviour.levelManager && WPFMonoBehaviour.levelManager.m_levelCompleteTutorialBookPagePrefab != null)
		{
			this.m_currentPage = this.m_pages.IndexOf(WPFMonoBehaviour.levelManager.m_levelCompleteTutorialBookPagePrefab);
			if (this.m_currentPage == -1)
			{
				this.m_currentPage = 0;
			}
			WPFMonoBehaviour.levelManager.m_levelCompleteTutorialBookPagePrefab = null;
			if (this.m_currentPage > this.m_pages.Count - 1)
			{
				this.m_currentPage = this.m_pages.Count - 1;
			}
			if (this.m_currentPage % 2 != 0)
			{
				this.m_currentPage--;
			}
		}
		else if (!flag && WPFMonoBehaviour.levelManager && WPFMonoBehaviour.levelManager.TutorialBookPage != null)
		{
			this.m_currentPage = this.m_pages.IndexOf(WPFMonoBehaviour.levelManager.TutorialBookPage);
			if (this.m_currentPage == -1)
			{
				this.m_currentPage = 0;
			}
			if (this.m_currentPage > this.m_pages.Count - 1)
			{
				this.m_currentPage = this.m_pages.Count - 1;
			}
			if (this.m_currentPage % 2 != 0)
			{
				this.m_currentPage--;
			}
		}
		else if (flag)
		{
			this.m_currentPage = 119;
		}
		this.m_lastOpenedPage = GameProgress.GetTutorialBookLastOpenedPage();
		if (this.m_currentPage > this.m_lastOpenedPage)
		{
			this.m_lastOpenedPage = this.m_currentPage;
			GameProgress.SetTutorialBookLastOpenedPage(this.m_lastOpenedPage);
		}
		this.m_firstOpenedPage = GameProgress.GetTutorialBookFirstOpenedPage();
		if (this.m_currentPage < this.m_firstOpenedPage)
		{
			this.m_firstOpenedPage = this.m_currentPage;
			GameProgress.SetTutorialBookFirstOpenedPage(this.m_firstOpenedPage);
		}
		if (flag)
		{
			this.m_currentPage = 110;
		}
		this.Initialize();
	}

	protected void Initialize()
	{
		this.m_hinge = base.transform.Find("Hinge").gameObject;
		this.m_leftPages = this.m_hinge.transform.Find("LeftPages").gameObject;
		this.m_cover = this.m_hinge.transform.Find("Cover").gameObject;
		this.m_pagePivot = base.transform.Find("PagePivot").gameObject;
		this.m_flippingPage = this.m_pagePivot.transform.Find("Page").gameObject;
		this.m_flippingPagePosition = this.m_flippingPage.transform.localPosition;
		this.m_rightPagePosition = this.m_flippingPage.transform.localPosition;
		this.m_leftPagePosition = this.m_rightPagePosition;
		this.m_leftPagePosition.x = this.m_leftPagePosition.x + -4.4f;
		this.m_cover.GetComponent<Renderer>().sortingOrder += 100;
		this.SetRightPage(this.m_pages[this.m_currentPage + 1]);
		this.m_leftPages.GetComponent<Renderer>().enabled = false;
		this.m_opening = true;
		this.m_pageState = 0;
		this.m_buttonsPanel = base.transform.Find("Buttons").gameObject;
		this.m_nextPageButton = this.m_buttonsPanel.transform.Find("NextPageButton").gameObject;
		this.m_previousPageButton = this.m_buttonsPanel.transform.Find("PreviousPageButton").gameObject;
		this.m_buttonsPanel.SetActive(false);
	}

	private void Update()
	{
		if (this.m_currentPage == this.m_pages.Count - 2)
		{
			this.m_nextPageButton.SetActive(false);
		}
		if (this.m_opening)
		{
			if (this.m_pageState == 0 && this.m_hinge.transform.rotation.eulerAngles.y > 270f)
			{
				this.m_leftPages.GetComponent<Renderer>().enabled = true;
				this.m_cover.GetComponent<Renderer>().enabled = false;
				this.m_flippingPage = UnityEngine.Object.Instantiate<GameObject>(this.m_pages[this.m_currentPage]);
				this.m_flippingPage.transform.parent = this.m_hinge.transform;
				this.m_flippingPage.transform.localPosition = this.m_leftPages.transform.localPosition + new Vector3(0.43f, -0.045f, 0f);
				this.m_flippingPage.transform.localRotation = Quaternion.AngleAxis(180f, Vector3.up);
				GameObject gameObject = this.m_flippingPage.transform.Find("Content").gameObject;
				Vector3 localScale = gameObject.transform.localScale;
				localScale.x *= -1f;
				gameObject.transform.localScale = localScale;
				gameObject.transform.localPosition += new Vector3(-0.53f, 0f, 0f);
				this.SetPageRenderOrder(this.m_flippingPage, 100);
				this.m_cover.GetComponent<Renderer>().sortingOrder -= 100;
				this.m_pageState = 1;
			}
			if (this.m_pageState == 1 && this.m_hinge.transform.rotation.eulerAngles.y == 0f)
			{
				UnityEngine.Object.Destroy(this.m_flippingPage);
				this.SetLeftPage(this.m_pages[this.m_currentPage]);
				this.m_opening = false;
				this.m_buttonsPanel.SetActive(true);
				if (this.m_currentPage >= this.m_lastOpenedPage - 1)
				{
					this.m_nextPageButton.SetActive(false);
				}
				if (this.m_currentPage < this.m_firstOpenedPage + 2)
				{
					this.m_previousPageButton.SetActive(false);
				}
			}
		}
		if (this.m_turningPageRight)
		{
			if (this.m_pageState == 0 && this.m_pagePivot.transform.rotation.eulerAngles.y > 90f)
			{
				UnityEngine.Object.Destroy(this.m_flippingPage);
				this.m_flippingPage = UnityEngine.Object.Instantiate<GameObject>(this.m_pages[this.m_currentPage]);
				this.SetPageRenderOrder(this.m_flippingPage, 100);
				this.m_flippingPage.transform.parent = this.m_pagePivot.transform;
				this.m_flippingPage.transform.localPosition = this.m_flippingPagePosition;
				this.m_flippingPage.transform.localRotation = Quaternion.identity;
				GameObject gameObject2 = this.m_flippingPage.transform.Find("Content").gameObject;
				Vector3 localScale2 = gameObject2.transform.localScale;
				localScale2.x *= -1f;
				gameObject2.transform.localScale = localScale2;
				gameObject2.transform.localPosition += new Vector3(-0.53f, 0f, 0f);
				this.m_pageState = 1;
			}
			if (this.m_pageState == 1 && this.m_pagePivot.transform.rotation.eulerAngles.y >= 180f)
			{
				this.SetLeftPage(this.m_pages[this.m_currentPage]);
				UnityEngine.Object.Destroy(this.m_flippingPage);
				this.m_turningPageRight = false;
				this.m_previousPageButton.SetActive(true);
				if (this.m_currentPage >= this.m_lastOpenedPage - 1)
				{
					this.m_nextPageButton.SetActive(false);
				}
			}
		}
		if (this.m_turningPageLeft)
		{
			if (this.m_pageState == 0 && this.m_pagePivot.transform.rotation.eulerAngles.y < 90f)
			{
				UnityEngine.Object.Destroy(this.m_flippingPage);
				this.m_flippingPage = UnityEngine.Object.Instantiate<GameObject>(this.m_pages[this.m_currentPage + 1]);
				this.SetPageRenderOrder(this.m_flippingPage, 100);
				this.m_flippingPage.transform.parent = this.m_pagePivot.transform;
				this.m_flippingPage.transform.localPosition = this.m_flippingPagePosition;
				this.m_flippingPage.transform.localRotation = Quaternion.identity;
				this.m_pageState = 1;
			}
			if (this.m_pageState == 1 && this.m_pagePivot.transform.rotation.eulerAngles.y <= 0f)
			{
				this.SetRightPage(this.m_pages[this.m_currentPage + 1]);
				UnityEngine.Object.Destroy(this.m_flippingPage);
				this.m_turningPageLeft = false;
				this.m_nextPageButton.SetActive(true);
				if (this.m_currentPage < this.m_firstOpenedPage + 2)
				{
					this.m_previousPageButton.SetActive(false);
				}
			}
		}
	}

	public virtual void TurnPageLeft()
	{
		if (this.m_opening || this.m_turningPageRight || this.m_turningPageLeft)
		{
			return;
		}
		if (this.m_currentPage >= this.m_firstOpenedPage + 2)
		{
			if (this.m_flippingPage)
			{
				UnityEngine.Object.Destroy(this.m_flippingPage);
			}
			this.m_flippingPage = UnityEngine.Object.Instantiate<GameObject>(this.m_pages[this.m_currentPage]);
			this.SetPageRenderOrder(this.m_flippingPage, 100);
			this.m_flippingPage.transform.parent = this.m_pagePivot.transform;
			this.m_flippingPage.transform.localPosition = this.m_flippingPagePosition;
			this.m_flippingPage.transform.localRotation = Quaternion.identity;
			GameObject gameObject = this.m_flippingPage.transform.Find("Content").gameObject;
			Vector3 localScale = gameObject.transform.localScale;
			localScale.x *= -1f;
			gameObject.transform.localScale = localScale;
			gameObject.transform.localPosition += new Vector3(-0.53f, 0f, 0f);
			this.m_pagePivot.GetComponent<Animation>().Play("PageTurnLeft");
			this.m_pagePivot.GetComponent<Animation>().Sample();
			this.m_turningPageLeft = true;
			this.m_pageState = 0;
			this.m_currentPage -= 2;
			this.SetLeftPage(this.m_pages[this.m_currentPage]);
			Singleton<AudioManager>.Instance.Play2dEffect(WPFMonoBehaviour.gameData.commonAudioCollection.tutorialFlip);
		}
		Resources.UnloadUnusedAssets();
	}

	public virtual void TurnPageRight()
	{
		if (this.m_opening || this.m_turningPageRight || this.m_turningPageLeft)
		{
			return;
		}
		if (this.m_currentPage < this.m_lastOpenedPage - 1)
		{
			if (this.m_flippingPage)
			{
				UnityEngine.Object.Destroy(this.m_flippingPage);
			}
			this.m_flippingPage = UnityEngine.Object.Instantiate<GameObject>(this.m_pages[this.m_currentPage + 1]);
			this.m_flippingPage.transform.parent = this.m_pagePivot.transform;
			this.m_flippingPage.transform.localPosition = this.m_flippingPagePosition;
			this.m_flippingPage.transform.localRotation = Quaternion.identity;
			this.SetPageRenderOrder(this.m_flippingPage, 100);
			this.m_pagePivot.GetComponent<Animation>().Play();
			this.m_pagePivot.GetComponent<Animation>().Sample();
			this.m_turningPageRight = true;
			this.m_pageState = 0;
			this.m_currentPage += 2;
			this.SetRightPage(this.m_pages[this.m_currentPage + 1]);
			Singleton<AudioManager>.Instance.Play2dEffect(WPFMonoBehaviour.gameData.commonAudioCollection.tutorialFlip);
		}
		Resources.UnloadUnusedAssets();
	}

	private void SetLeftPage(GameObject obj)
	{
		if (this.m_leftPage)
		{
			UnityEngine.Object.Destroy(this.m_leftPage);
		}
		this.m_leftPage = UnityEngine.Object.Instantiate<GameObject>(this.m_pages[this.m_currentPage]);
		this.m_leftPage.transform.parent = base.transform;
		this.m_leftPage.transform.localPosition = this.m_leftPagePosition;
		this.m_leftPage.GetComponent<Renderer>().enabled = false;
	}

	private void SetRightPage(GameObject obj)
	{
		if (this.m_rightPage)
		{
			UnityEngine.Object.Destroy(this.m_rightPage);
		}
		this.m_rightPage = UnityEngine.Object.Instantiate<GameObject>(this.m_pages[this.m_currentPage + 1]);
		this.m_rightPage.transform.parent = base.transform;
		this.m_rightPage.transform.localPosition = this.m_rightPagePosition;
		this.m_rightPage.GetComponent<Renderer>().enabled = false;
	}

	private void SetPageRenderOrder(GameObject obj, int sortingOrder)
	{
		if (obj.GetComponent<Renderer>())
		{
			obj.GetComponent<Renderer>().sortingOrder += sortingOrder;
		}
		for (int i = 0; i < obj.transform.childCount; i++)
		{
			this.SetRenderQueueRecursively(obj.transform.GetChild(i).gameObject, sortingOrder + 1);
		}
	}

	private void SetRenderQueueRecursively(GameObject obj, int sortingOrder)
	{
		if (obj.GetComponent<Renderer>())
		{
			obj.GetComponent<Renderer>().sortingOrder += sortingOrder;
		}
		for (int i = 0; i < obj.transform.childCount; i++)
		{
			this.SetRenderQueueRecursively(obj.transform.GetChild(i).gameObject, sortingOrder + 1);
		}
	}

	public List<GameObject> m_pages;

	protected int m_currentPage;

	private GameObject m_pagePivot;

	private Vector3 m_rightPagePosition;

	private Vector3 m_leftPagePosition;

	private GameObject m_leftPage;

	private GameObject m_rightPage;

	private GameObject m_flippingPage;

	private Vector3 m_flippingPagePosition;

	private const float m_leftPageOffset = -4.4f;

	private bool m_opening;

	private bool m_turningPageRight;

	private bool m_turningPageLeft;

	private GameObject m_leftPages;

	private GameObject m_cover;

	private GameObject m_hinge;

	private int m_pageState;

	private const int m_normalRenderQueue = 3000;

	private const int m_renderQueue = 3001;

	private const int m_sortingOrder = 100;

	private GameObject m_buttonsPanel;

	private GameObject m_nextPageButton;

	private GameObject m_previousPageButton;

	protected int m_lastOpenedPage;

	protected int m_firstOpenedPage;
}
