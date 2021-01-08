using UnityEngine;

public interface WidgetListener
{
	void Select(Widget widget, object targetObject);

	void StartDrag(Widget widget, object targetObject);

	void CancelDrag(Widget widget, object targetObject);

	void Drop(Widget widget, Vector3 position, object targetObject);
}
