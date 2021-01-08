using System;
using UnityEngine;

public class PageScroller : MonoBehaviour
{
	public event PageChanged OnPageChanged;

	public int PageCount
	{
		get
		{
			return this.m_pageCount;
		}
		set
		{
			if (value > 0)
			{
				this.m_pageCount = value;
				if (this.m_page >= this.m_pageCount)
				{
					this.ScrollToPage(this.m_pageCount - 1);
				}
				return;
			}
			throw new ArgumentException("PageCount can't be less then 1");
		}
	}

	public int CurrentPage
	{
		get
		{
			return this.m_page;
		}
	}

	private void Start()
	{
		this.m_hudCamera = Singleton<GuiManager>.Instance.FindCamera();
	}

	private void OnEnable()
	{
		this.m_hudCamera = Singleton<GuiManager>.Instance.FindCamera();
	}

	public void ScrollToPage(int newPage)
	{
		if (newPage >= 0 && newPage < this.m_pageCount && newPage != this.m_page)
		{
			if (this.OnPageChanged != null)
			{
				this.OnPageChanged(this.m_page, newPage);
			}
			this.m_page = newPage;
		}
	}

	public void SetPage(int newPage)
	{
		if (newPage >= 0 && newPage < this.m_pageCount && newPage != this.m_page)
		{
			if (this.OnPageChanged != null)
			{
				this.OnPageChanged(this.m_page, newPage);
			}
			this.m_page = newPage;
			this.m_scrollPivot.localPosition = this.GetTargetPosition(this.m_page);
		}
	}

	private Vector3 GetTargetPosition(int pageNum)
	{
		if (!this.m_hudCamera)
		{
			this.m_hudCamera = Singleton<GuiManager>.Instance.FindCamera();
		}
		Vector3 result = new Vector3(-this.m_hudCamera.ScreenToWorldPoint(new Vector3((float)(Screen.width / 2 + Screen.width * pageNum), 0f, 0f)).x + this.m_hudCamera.transform.position.x, this.m_scrollPivot.localPosition.y, this.m_scrollPivot.localPosition.z);
		return result;
	}

	private void Update()
	{
		GuiManager.Pointer pointer = GuiManager.GetPointer();
		if (pointer.down)
		{
			this.m_pointerDownPos = (this.m_lastInputPos = pointer.position);
		}
		if (pointer.dragging && !LootCrateOpenDialog.DialogOpen && !TextDialog.DialogOpen)
		{
			Vector3 vector = this.m_hudCamera.ScreenToWorldPoint(this.m_lastInputPos);
			Vector3 vector2 = this.m_hudCamera.ScreenToWorldPoint(pointer.position);
			this.m_lastInputPos = pointer.position;
			float num = vector2.x - vector.x;
			this.m_scrollPivot.localPosition = new Vector3(this.m_scrollPivot.localPosition.x + num, this.m_scrollPivot.localPosition.y, this.m_scrollPivot.localPosition.z);
			Vector3 vector3 = this.m_hudCamera.ScreenToWorldPoint(this.m_pointerDownPos);
			if (Mathf.Abs(vector2.x - vector3.x) > 1f)
			{
				Singleton<GuiManager>.Instance.ResetFocus();
			}
		}
		if (pointer.up)
		{
			float num2 = this.m_lastInputPos.x - this.m_pointerDownPos.x;
			if (Mathf.Abs(num2) > (float)(Screen.width / 16))
			{
				int page = this.m_page;
				this.m_page += ((num2 >= 0f) ? -1 : 1);
				this.m_page = Mathf.Clamp(this.m_page, 0, this.m_pageCount - 1);
				if (page != this.m_page)
				{
					this.OnPageChanged(page, this.m_page);
				}
			}
		}
		if (!pointer.down && !pointer.dragging)
		{
			Vector3 targetPosition = this.GetTargetPosition(this.m_page);
			if (Vector3.SqrMagnitude(targetPosition - this.m_scrollPivot.localPosition) > 1E-05f)
			{
				this.m_scrollPivot.localPosition += (targetPosition - this.m_scrollPivot.localPosition) * Time.unscaledDeltaTime * 4f;
			}
		}
	}

	[SerializeField]
	private Transform m_scrollPivot;

	private Vector3 m_lastInputPos;

	private Vector3 m_pointerDownPos;

	private Camera m_hudCamera;

	private int m_page;

	private int m_pageCount = 1;

	public delegate void PageChanged(int oldPage, int newPage);
}
