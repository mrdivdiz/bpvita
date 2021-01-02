using UnityEngine;

public class CameraExportAction : ExportAction
{
	public override void StartActions()
	{
		CameraPreview component = base.GetComponent<CameraPreview>();
		if (!component || component.ControlPoints == null || component.ControlPoints.Count == 0)
		{
			return;
		}
		Vector2 position = component.ControlPoints[0].position;
		base.transform.position = new Vector3(position.x, position.y, base.transform.position.z);
	}

	public override void EndActions()
	{
	}
}
