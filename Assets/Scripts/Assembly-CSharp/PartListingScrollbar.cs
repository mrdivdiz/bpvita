using System;
using System.Collections.Generic;
using UnityEngine;

public class PartListingScrollbar : MonoBehaviour
{
	private void OnEnable()
	{
		PartListing partListing = this.partListing;
		partListing.OnPartListingMoved = (Action<float>)Delegate.Combine(partListing.OnPartListingMoved, new Action<float>(this.OnPartListMoved));
		PartListing partListing2 = this.partListing;
		partListing2.OnPartListDragBegin = (Action)Delegate.Combine(partListing2.OnPartListDragBegin, new Action(this.OnPartListDragBegin));
		PartListingScrollbutton partListingScrollbutton = this.scrollButton;
		partListingScrollbutton.OnDragBegin = (Action)Delegate.Combine(partListingScrollbutton.OnDragBegin, new Action(this.OnButtonDragBegin));
		PartListingScrollbutton partListingScrollbutton2 = this.scrollButton;
		partListingScrollbutton2.OnDrag = (Action<float>)Delegate.Combine(partListingScrollbutton2.OnDrag, new Action<float>(this.OnButtonDrag));
		PartListingScrollbutton partListingScrollbutton3 = this.scrollButton;
		partListingScrollbutton3.OnDragEnd = (Action)Delegate.Combine(partListingScrollbutton3.OnDragEnd, new Action(this.OnButtonDragEnd));
	}

	private void OnDisable()
	{
		PartListing partListing = this.partListing;
		partListing.OnPartListingMoved = (Action<float>)Delegate.Remove(partListing.OnPartListingMoved, new Action<float>(this.OnPartListMoved));
		PartListing partListing2 = this.partListing;
		partListing2.OnPartListDragBegin = (Action)Delegate.Remove(partListing2.OnPartListDragBegin, new Action(this.OnPartListDragBegin));
		PartListingScrollbutton partListingScrollbutton = this.scrollButton;
		partListingScrollbutton.OnDragBegin = (Action)Delegate.Remove(partListingScrollbutton.OnDragBegin, new Action(this.OnButtonDragBegin));
		PartListingScrollbutton partListingScrollbutton2 = this.scrollButton;
		partListingScrollbutton2.OnDrag = (Action<float>)Delegate.Remove(partListingScrollbutton2.OnDrag, new Action<float>(this.OnButtonDrag));
		PartListingScrollbutton partListingScrollbutton3 = this.scrollButton;
		partListingScrollbutton3.OnDragEnd = (Action)Delegate.Remove(partListingScrollbutton3.OnDragEnd, new Action(this.OnButtonDragEnd));
	}

	private void OnPartListMoved(float relativePosition)
	{
		if (this.waitingPartList)
		{
			this.waitingPartList = (Mathf.Abs(relativePosition - this.lastPartListMovement) > float.Epsilon);
			this.lastPartListMovement = relativePosition;
		}
		else if (!this.draggingButton)
		{
			float x = (relativePosition - 0.5f) * this.moveArea;
			this.scrollButtonTf.localPosition = new Vector3(x, 0f, -1f);
		}
	}

	private void OnButtonDragBegin()
	{
		this.draggingButton = true;
	}

	private void OnButtonDrag(float x)
	{
		this.scrollButtonTf.localPosition = new Vector3(Mathf.Clamp(x, -this.moveArea / 2f, this.moveArea / 2f), 0f, -1f);
		this.partListing.SetRelativePosition(Mathf.Clamp01((x + this.moveArea / 2f) / this.moveArea));
	}

	private void OnButtonDragEnd()
	{
		this.draggingButton = false;
		this.waitingPartList = true;
	}

	private void OnPartListDragBegin()
	{
		this.waitingPartList = false;
		this.draggingButton = false;
	}

	public GameObject SetNewPartButton(float relativePosition)
	{
		if (this.newButtons == null)
		{
			this.newButtons = new Dictionary<int, Tuple<GameObject, float>>();
		}
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.newBtnPrefab);
		gameObject.transform.parent = base.transform;
		gameObject.transform.localPosition = new Vector3((relativePosition - 0.5f) * this.moveArea, 0f, -0.5f);
		Button component = gameObject.GetComponent<Button>();
		component.MethodToCall.SetMethod(this, "OnNewPartButtonPressed", gameObject.GetInstanceID());
		this.newButtons.Add(gameObject.GetInstanceID(), new Tuple<GameObject, float>(gameObject, relativePosition));
		return gameObject;
	}

	public void ClearNewPartButtons()
	{
		if (this.newButtons == null)
		{
			return;
		}
		foreach (KeyValuePair<int, Tuple<GameObject, float>> keyValuePair in this.newButtons)
		{
			UnityEngine.Object.Destroy(this.newButtons[keyValuePair.Key].Item1);
		}
		this.newButtons.Clear();
	}

	public void OnNewPartButtonPressed(int id)
	{
		if (this.newButtons != null && this.newButtons.ContainsKey(id))
		{
			this.partListing.SetRelativePosition(this.newButtons[id].Item2);
		}
	}

	[SerializeField]
	private GameObject newBtnPrefab;

	[SerializeField]
	private Transform scrollButtonTf;

	[SerializeField]
	private PartListing partListing;

	[SerializeField]
	private PartListingScrollbutton scrollButton;

	[SerializeField]
	private float moveArea;

	private Dictionary<int, Tuple<GameObject, float>> newButtons;

	private bool draggingButton;

	private bool waitingPartList;

	private float lastPartListMovement;
}
