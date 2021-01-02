using System;
using System.Collections.Generic;
using UnityEngine;

public class CameraPreview : WPFMonoBehaviour
{
	public bool Done
	{
		get
		{
			return this.m_done;
		}
	}

	public List<CameraControlPoint> ControlPoints
	{
		get
		{
			if (Application.isPlaying && WPFMonoBehaviour.levelManager.CustomPreview != null)
			{
				return WPFMonoBehaviour.levelManager.CustomPreview;
			}
			return this.m_controlPoints;
		}
	}

	private void Awake()
	{
	}

	private void Start()
	{
		this.m_controlPoints = this.ControlPoints;
		if (this.m_controlPoints.Count < 3)
		{
			return;
		}
		this.m_controlPoints.Insert(0, this.m_controlPoints[0]);
		this.m_controlPoints.Add(this.m_controlPoints[this.m_controlPoints.Count - 1]);
		if (Singleton<BuildCustomizationLoader>.Instance.IsHDVersion)
		{
			this.m_controlPoints[this.m_controlPoints.Count - 1].zoom += 0.35f;
		}
		int num = WPFMonoBehaviour.levelManager.ConstructionUI.PartSelectorRowCount();
		if (num > 1 && WPFMonoBehaviour.levelManager.m_constructionGridRows.Count - 1 >= 6)
		{
			this.m_controlPoints[this.m_controlPoints.Count - 1].position += -0.5f * Vector2.up;
			this.m_controlPoints[this.m_controlPoints.Count - 1].zoom += 0.5f;
		}
		WPFMonoBehaviour.levelManager.ConstructionUI.SetPartSelectorMaxRowCount(num);
	}

	public void UpdateCameraPreview(ref Vector3 cameraPosition, ref float cameraOrtoSize)
	{
		if (this.m_done)
		{
			return;
		}
		if (GuiManager.GetPointer().down)
		{
			this.m_fastPreviewMultiplier = 6;
		}
		Vector2 a = cameraPosition;
		this.m_timer += Time.deltaTime * (float)this.m_fastPreviewMultiplier;
		float num = (a - new Vector2(this.m_controlPoints[this.m_currentControlPointIndex + 1].position.x, this.m_controlPoints[this.m_currentControlPointIndex + 1].position.y)).magnitude;
		float num2 = Mathf.Abs(cameraOrtoSize - this.m_controlPoints[this.m_currentControlPointIndex + 1].zoom);
		if (this.m_timer > this.m_animationTime / (float)(this.m_controlPoints.Count - 3))
		{
			this.m_timer = this.m_animationTime / (float)(this.m_controlPoints.Count - 3);
			num = 0f;
			num2 = 0f;
		}
		if (num < 0.5f && num2 < 0.5f)
		{
			this.m_currentControlPointIndex++;
			this.m_timer = 0f;
			if (this.m_currentControlPointIndex == this.m_controlPoints.Count - 2)
			{
				this.m_done = true;
				return;
			}
		}
		float i;
		switch (this.m_easing)
		{
		case CameraPreview.EasingAnimation.EasingIn:
			i = MathsUtil.EasingInQuad(this.m_timer, 0f, 1f, this.m_animationTime / (float)(this.m_controlPoints.Count - 3));
			break;
		case CameraPreview.EasingAnimation.EasingOut:
			i = MathsUtil.EasingOutQuad(this.m_timer, 0f, 1f, this.m_animationTime / (float)(this.m_controlPoints.Count - 3));
			break;
		case CameraPreview.EasingAnimation.EasingInOut:
			i = MathsUtil.EaseInOutQuad(this.m_timer, 0f, 1f, this.m_animationTime / (float)(this.m_controlPoints.Count - 3));
			break;
		default:
			i = this.m_timer / (this.m_animationTime / (float)(this.m_controlPoints.Count - 3));
			break;
		}
		float x = MathsUtil.CatmullRomInterpolate(this.m_controlPoints[this.m_currentControlPointIndex - 1].position.x, this.m_controlPoints[this.m_currentControlPointIndex].position.x, this.m_controlPoints[this.m_currentControlPointIndex + 1].position.x, this.m_controlPoints[this.m_currentControlPointIndex + 2].position.x, i);
		float y = MathsUtil.CatmullRomInterpolate(this.m_controlPoints[this.m_currentControlPointIndex - 1].position.y, this.m_controlPoints[this.m_currentControlPointIndex].position.y, this.m_controlPoints[this.m_currentControlPointIndex + 1].position.y, this.m_controlPoints[this.m_currentControlPointIndex + 2].position.y, i);
		float num3 = MathsUtil.CatmullRomInterpolate(this.m_controlPoints[this.m_currentControlPointIndex - 1].zoom, this.m_controlPoints[this.m_currentControlPointIndex].zoom, this.m_controlPoints[this.m_currentControlPointIndex + 1].zoom, this.m_controlPoints[this.m_currentControlPointIndex + 2].zoom, i);
		cameraPosition = new Vector3(x, y, cameraPosition.z);
		cameraOrtoSize = num3;
	}

	public EasingAnimation m_easing;

	[SerializeField]
	private List<CameraControlPoint> m_controlPoints = new List<CameraControlPoint>();

	public float m_animationTime;

	private int m_currentControlPointIndex = 1;

	private float m_timer;

	private bool m_done;

	private int m_fastPreviewMultiplier = 1;

	public enum EasingAnimation
	{
		None,
		EasingIn,
		EasingOut,
		EasingInOut
	}

	[Serializable]
	public class CameraControlPoint
	{
		public CameraControlPoint()
		{
			this.zoom = 1f;
			this.easing = CameraPreview.EasingAnimation.EasingInOut;
		}

		public Vector2 position;

		public float zoom = 2f;

		public EasingAnimation easing;
	}
}
