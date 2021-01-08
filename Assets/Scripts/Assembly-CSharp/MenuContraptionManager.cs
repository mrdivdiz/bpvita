using System.Collections.Generic;
using UnityEngine;

public class MenuContraptionManager : MonoBehaviour
{
	private void Start()
	{
		this.m_camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
		this.m_defaultCameraPosition = this.m_camera.transform.position;
		this.m_zoomOutPosition = this.m_defaultCameraPosition;
        Object[] array = Resources.LoadAll("MenuContraptions");
		foreach (Object @object in array)
		{
			this.m_contraptionAssets.Add(@object as TextAsset);
		}
		this.ShuffleContraptions();
		this.CreateContraption();
	}

	private void SetState(State state)
	{
		this.m_state = state;
		this.m_timer = 0f;
		if (state == MenuContraptionManager.State.Returning)
		{
			this.m_cameraStartPosition = this.m_camera.transform.position;
			this.m_cameraStartSize = this.m_camera.orthographicSize;
			this.m_zoomOutPosition = this.m_defaultCameraPosition;
		}
		if (state == MenuContraptionManager.State.Default)
		{
			this.m_cameraTarget = null;
		}
	}

	private Vector3 CameraTargetPosition()
	{
		float z = this.m_camera.transform.position.z;
		float num = this.m_cameraTarget.transform.position.x;
		float num2 = this.m_cameraTarget.transform.position.y;
		num = Mathf.Clamp(num, -100f, 100f);
		num2 = Mathf.Clamp(num2, -10f, 50f);
		return new Vector3(num, num2, z);
	}

	private void Update()
	{
		if (this.m_contraptionAssets.Count == 0)
		{
			return;
		}
		this.m_timer += Time.deltaTime;
		this.m_resourceUnloadTimer += Time.deltaTime;
		if (this.m_resourceUnloadTimer > 600f)
		{
			this.m_resourceUnloadTimer = 0f;
			Resources.UnloadUnusedAssets();
		}
		float num = 0.666f;
		float num2 = 8f;
		if (this.m_state == MenuContraptionManager.State.Default)
		{
			if (this.m_cameraTarget)
			{
				this.SetState(MenuContraptionManager.State.Zooming);
			}
			else
			{
				this.CreateContraption();
			}
		}
		else if (this.m_state == MenuContraptionManager.State.Zooming)
		{
			float num3 = 4f;
			float t = MathsUtil.EaseInOutQuad(this.m_timer, 0f, 1f, num3);
			Vector3 vector = this.CameraTargetPosition();
			vector = num * vector + (1f - num) * this.m_defaultCameraPosition;
			this.m_camera.transform.position = Vector3.Slerp(this.m_zoomOutPosition, vector, t);
			this.m_camera.orthographicSize = Mathf.Lerp(15f, num2, t);
			if (this.m_timer > num3)
			{
				this.SetState(MenuContraptionManager.State.Following);
			}
		}
		else if (this.m_state == MenuContraptionManager.State.ReturnToZoom)
		{
			this.m_returnTimer += Time.deltaTime;
			float num4 = 5f;
			float t2 = MathsUtil.EaseInOutQuad(this.m_timer, 0f, 1f, num4);
			Vector3 vector2 = this.CameraTargetPosition();
			vector2 = num * vector2 + (1f - num) * this.m_defaultCameraPosition;
			Vector3 vector3 = Vector3.Slerp(this.m_zoomOutPosition, vector2, t2);
			Vector3 a = vector3;
			float num5 = 1f;
			if (this.m_returnTimer < 4f)
			{
				float t3 = MathsUtil.EaseInOutQuad(this.m_returnTimer, 0f, 1f, 4f);
				a = Vector3.Slerp(this.m_cameraStartPosition, this.m_zoomOutPosition, t3);
				num5 = MathsUtil.EaseInOutQuad(Mathf.Clamp(this.m_timer, 0f, 1f), 0f, 1f, 1f);
			}
			this.m_camera.orthographicSize = Mathf.Lerp(15f, num2, t2);
			this.m_camera.transform.position = num5 * vector3 + (1f - num5) * a;
			if (this.m_timer > num4)
			{
				this.SetState(MenuContraptionManager.State.Following);
			}
		}
		else if (this.m_state == MenuContraptionManager.State.Following)
		{
			if (!this.m_cameraTarget)
			{
				this.SetState(MenuContraptionManager.State.Returning);
				return;
			}
			Vector3 vector4 = this.CameraTargetPosition();
			vector4 = num * vector4 + (1f - num) * this.m_defaultCameraPosition;
			this.m_camera.transform.position = vector4;
			this.m_camera.orthographicSize = num2;
			Vector3 position = this.m_cameraTarget.transform.position;
			Vector3 position2 = this.m_camera.transform.position;
			Vector2 vector5 = new Vector2(this.m_camera.orthographicSize * (float)Screen.width / (float)Screen.height, this.m_camera.orthographicSize);
			float num6 = -5f + -15f * (float)Screen.width / (float)Screen.height;
			if (position.x > position2.x + vector5.x - 5f || position.x < num6 - 10f || position.y > position2.y + vector5.y - 5f || position.y < -15f)
			{
				this.m_contraptionController.StartRemoveTimer(4f);
				this.SetState(MenuContraptionManager.State.Returning);
			}
			if (this.m_timer > 30f)
			{
				this.m_contraptionController.StartRemoveTimer(4f);
				this.SetState(MenuContraptionManager.State.Returning);
			}
			if (this.m_contraption.IsMovementStopped())
			{
				this.m_contraptionController.StartRemoveTimer(4f);
				this.SetState(MenuContraptionManager.State.Returning);
			}
		}
		else if (this.m_state == MenuContraptionManager.State.Returning)
		{
			float num7 = 4f;
			float t4 = MathsUtil.EaseInOutQuad(this.m_timer, 0f, 1f, num7);
			float num8 = MathsUtil.EaseInOutQuad(this.m_timer, 0f, 1f, num7 - 1f);
			Vector3 vector6 = Vector3.Slerp(this.m_cameraStartPosition, this.m_zoomOutPosition, t4);
			this.m_camera.orthographicSize = Mathf.Lerp(this.m_cameraStartSize, 15f, num8);
			Vector3 a2 = vector6;
			if (this.m_cameraTarget)
			{
				a2 = this.CameraTargetPosition();
				a2 = num * a2 + (1f - num) * this.m_defaultCameraPosition;
			}
			this.m_camera.transform.position = num8 * vector6 + (1f - num8) * a2;
			if (this.m_timer > num7 - 1f)
			{
				this.m_returnTimer = this.m_timer;
				this.SetState(MenuContraptionManager.State.ReturnToZoom);
				this.CreateContraption();
			}
		}
	}

	private void CreateContraption()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.m_menuContraptionControllerPrefab.gameObject);
		gameObject.transform.parent = base.transform;
		gameObject.transform.localPosition = Vector3.zero;
		this.m_contraptionController = gameObject.GetComponent<MenuContraptionController>();
		Contraption contraption = gameObject.GetComponent<MenuContraptionController>().CreateContraption(this.m_contraptionAssets[this.m_contraptionIndex]);
		this.m_contraption = contraption;
		this.m_cameraTarget = contraption.FindPig().gameObject;
		this.m_contraptionIndex++;
		if (this.m_contraptionIndex >= this.m_contraptionAssets.Count)
		{
			this.m_contraptionIndex = 0;
			this.ShuffleContraptions();
		}
	}

	private void ShuffleContraptions()
	{
		for (int i = 0; i < this.m_contraptionAssets.Count - 1; i++)
		{
			int index = UnityEngine.Random.Range(i, this.m_contraptionAssets.Count);
			TextAsset value = this.m_contraptionAssets[i];
			this.m_contraptionAssets[i] = this.m_contraptionAssets[index];
			this.m_contraptionAssets[index] = value;
		}
	}

	public GameData m_gameData;

	public MenuContraptionController m_menuContraptionControllerPrefab;

	private List<TextAsset> m_contraptionAssets = new List<TextAsset>();

	private int m_contraptionIndex;

	private Contraption m_contraption;

	private MenuContraptionController m_contraptionController;

	private float m_timer;

	private Camera m_camera;

	private GameObject m_cameraTarget;

	private Vector3 m_defaultCameraPosition;

	private float m_cameraStartSize;

	private Vector3 m_cameraStartPosition;

	private Vector3 m_zoomOutPosition;

	private State m_state;

	private float m_returnTimer;

	private float m_resourceUnloadTimer;

	private enum State
	{
		Default,
		Zooming,
		Following,
		Returning,
		ReturnToZoom
	}
}
