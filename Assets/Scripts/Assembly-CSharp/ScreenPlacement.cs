using UnityEngine;

public class ScreenPlacement : MonoBehaviour
{
	public static bool IsAspectRatioNarrowerThan(float width, float height)
	{
		return (float)Screen.width / (float)Screen.height < width / height - 0.01f;
	}

	private void OnEnable()
	{
		this.PlaceHorizontal();
	}

	private void Update()
	{
		bool flag = Screen.width != this.lastScreenWidth || Screen.height != this.lastScreenHeight;
		if (flag)
		{
			this.PlaceHorizontal();
		}
	}

	private void PlaceHorizontal()
	{
		bool flag = Screen.width > 0 && Screen.height > 0;
		if (flag)
		{
			this.lastScreenWidth = Screen.width;
			this.lastScreenHeight = Screen.height;
		}
		float num = 0f;
		GameObject gameObject = GameObject.FindWithTag("HUDCamera");
		if (gameObject)
		{
			num = gameObject.transform.position.x;
		}
		if (this.m_anchor == ScreenPlacement.Anchor.Left)
		{
			float num2 = 10f * (float)this.lastScreenWidth / (float)this.lastScreenHeight;
			float num3 = (float)this.lastScreenHeight / 768f;
			Vector3 position = base.transform.position;
			position.x = (-0.5f * (float)this.lastScreenWidth + num3 * this.relativePosition) / (0.5f * (float)this.lastScreenWidth) * num2 + num;
			base.transform.position = position;
		}
		else if (this.m_anchor == ScreenPlacement.Anchor.Right)
		{
			float num4 = 10f * (float)this.lastScreenWidth / (float)this.lastScreenHeight;
			float num5 = (float)this.lastScreenHeight / 768f;
			Vector3 position2 = base.transform.position;
			position2.x = (0.5f * (float)this.lastScreenWidth + num5 * this.relativePosition) / (0.5f * (float)this.lastScreenWidth) * num4 + num;
			base.transform.position = position2;
		}
	}

	private void OnDrawGizmos()
	{
		if (!Application.isPlaying)
		{
			this.CalculateHorizontal();
		}
	}

	private void CalculateHorizontal()
	{
		if (this.m_anchor == ScreenPlacement.Anchor.Left)
		{
			this.relativePosition = base.transform.position.x / 13.333333f * 512f + 512f;
		}
		else if (this.m_anchor == ScreenPlacement.Anchor.Right)
		{
			this.relativePosition = base.transform.position.x / 13.333333f * 512f - 512f;
		}
	}

	public Anchor m_anchor;

	public float relativePosition;

	public const float DefaultScreenWidth = 1024f;

	public const float DefaultScreenHeight = 768f;

	public const float DefaultScreenHalfWidth = 512f;

	public const float DefaultScreenHalfHeight = 384f;

	public const float DefaultCameraSize = 10f;

	public const float DefaultViewHalfWidth = 13.333333f;

	private int lastScreenWidth;

	private int lastScreenHeight;

	public enum Anchor
	{
		Left,
		Right
	}
}
