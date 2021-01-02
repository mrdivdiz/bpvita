using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameCamera : WPFMonoBehaviour
{
	public IngameCamera.CameraState State
	{
		get
		{
			return this.m_state;
		}
	}

	public bool IsShowingBuildGrid(float allowedDistance)
	{
		if (this.m_state == IngameCamera.CameraState.Building)
		{
			Vector3 v = this.m_cameraPreview.ControlPoints[this.m_cameraPreview.ControlPoints.Count - 1].position;
			float cameraBuildZoom = this.m_cameraBuildZoom;
			this.EnforceCameraLimits(ref v, ref cameraBuildZoom);
			Vector2 vector = v - this.currentPos;
			float f = cameraBuildZoom - this.currentFOV;
			return vector.magnitude < allowedDistance && Mathf.Abs(f) < allowedDistance;
		}
		return false;
	}

	private void Start()
	{
		this.m_camera = base.GetComponent<Camera>();
		this.m_camera.orthographic = true;
		this.m_cameraLimits = WPFMonoBehaviour.levelManager.CurrentCameraLimits;
		this.m_cameraMaxZoom = Mathf.Min(Mathf.Min(this.m_cameraLimits.size.x, this.m_cameraLimits.size.y) / 2f, 20f);
		this.m_cameraMinZoom = 7f;
		if (Singleton<BuildCustomizationLoader>.Instance.IsHDVersion)
		{
			if (ScreenPlacement.IsAspectRatioNarrowerThan(3f, 2f))
			{
				this.m_cameraMinZoom = 8.4f;
			}
			else
			{
				this.m_cameraMinZoom = 7.7f;
			}
		}
		this.m_camera.orthographicSize = this.m_cameraMinZoom;
		this.m_cameraPreview = base.GetComponent<CameraPreview>();
		this.m_snapshotFX = base.GetComponent<SnapshotEffect>();
		if (this.m_cameraPreview == null && WPFMonoBehaviour.levelManager.GoalPosition != null)
		{
			this.m_cameraPreview = base.gameObject.AddComponent<CameraPreview>();
			CameraPreview.CameraControlPoint cameraControlPoint = new CameraPreview.CameraControlPoint();
			cameraControlPoint.position = WPFMonoBehaviour.levelManager.GoalPosition.transform.position + WPFMonoBehaviour.levelManager.PreviewOffset;
			cameraControlPoint.zoom = WPFMonoBehaviour.levelManager.PreviewOffset.z / 2f;
			this.m_cameraPreview.ControlPoints.Add(cameraControlPoint);
			this.m_cameraPreview.ControlPoints.Add(cameraControlPoint);
			CameraPreview.CameraControlPoint cameraControlPoint2 = new CameraPreview.CameraControlPoint();
			cameraControlPoint2.position = new Vector2(this.m_cameraLimits.topLeft.x + this.m_cameraLimits.size.x / 2f, this.m_cameraLimits.topLeft.y - this.m_cameraLimits.size.y / 2f);
			cameraControlPoint2.zoom = this.m_cameraMaxZoom;
			this.m_cameraPreview.ControlPoints.Add(cameraControlPoint2);
			CameraPreview.CameraControlPoint cameraControlPoint3 = new CameraPreview.CameraControlPoint();
			cameraControlPoint3.position = WPFMonoBehaviour.levelManager.StartingPosition + WPFMonoBehaviour.levelManager.ConstructionOffset;
			cameraControlPoint3.zoom = WPFMonoBehaviour.levelManager.ConstructionOffset.z;
			this.m_cameraPreview.ControlPoints.Add(cameraControlPoint3);
			this.m_cameraPreview.ControlPoints.Add(cameraControlPoint3);
			this.m_cameraPreview.m_animationTime = WPFMonoBehaviour.levelManager.m_previewMoveTime;
			if (this.m_cameraPreview.m_animationTime < 1f)
			{
				this.m_cameraPreview.m_animationTime = 1f;
			}
		}
		if (this.m_cameraPreview != null)
		{
			WPFMonoBehaviour.levelManager.m_previewMoveTime = this.m_cameraPreview.m_animationTime;
		}
		this.m_cameraBuildZoom = this.m_cameraPreview.ControlPoints[this.m_cameraPreview.ControlPoints.Count - 1].zoom;
		base.gameObject.SetActive(true);
	}

	private void OnEnable()
	{
		EventManager.Connect<BirdWakeUpEvent>(new EventManager.OnEvent<BirdWakeUpEvent>(this.ReceiveBirdWakeUpEvent));
		KeyListener.keyPressed += this.HandleKeyInput;
		KeyListener.keyHold += this.HandleKeyInput;
	}

	private void OnDisable()
	{
		EventManager.Disconnect<BirdWakeUpEvent>(new EventManager.OnEvent<BirdWakeUpEvent>(this.ReceiveBirdWakeUpEvent));
		KeyListener.keyPressed -= this.HandleKeyInput;
		KeyListener.keyHold -= this.HandleKeyInput;
	}

	private void Update()
	{
		this.UpdatePosition();
		this.ProcessInput();
		this.m_keyZoomDelta = 0f;
	}

	private void ReceiveBirdWakeUpEvent(BirdWakeUpEvent data)
	{
		if (!this.m_freeCameraMode)
		{
			this.m_autoZoomEnabled = true;
		}
	}

	private IEnumerator EnablePreviewMode()
	{
		this.m_transitionToPreviewActive = true;
		while ((double)(9f - this.currentFOV) > 0.1)
		{
			float ortoPreviewDelta = 9f - this.currentFOV;
			this.currentFOV += ortoPreviewDelta * GameTime.DeltaTime * 4f;
			this.m_camera.orthographicSize = this.currentFOV;
			yield return new WaitForEndOfFrame();
		}
		this.m_transitionToPreviewActive = false;
		yield break;
	}

	private void StopTransitionToPreview()
	{
		base.StopCoroutine("EnablePreviewMode");
		this.m_transitionToPreviewActive = false;
	}

	public void TakeSnapshot(Action handler)
	{
		this.m_snapshotFX.enabled = true;
		this.m_snapshotFX.SnapshotFinished += handler;
	}

	private void ProcessInput()
	{
		if (WPFMonoBehaviour.levelManager.gameState == LevelManager.GameState.Completed)
		{
			this.m_isStartingPan = false;
			this.isPanning = false;
			return;
		}
		if (WPFMonoBehaviour.levelManager.gameState == LevelManager.GameState.Running)
		{
			if (this.m_state == IngameCamera.CameraState.Wait)
			{
				if (this.m_transitionTimer > 0f)
				{
					this.m_transitionTimer -= GameTime.DeltaTime;
				}
				else
				{
					this.m_state = IngameCamera.CameraState.Follow;
				}
			}
			this.DoPanning();
		}
		if (WPFMonoBehaviour.levelManager.gameState == LevelManager.GameState.PreviewWhileBuilding || WPFMonoBehaviour.levelManager.gameState == LevelManager.GameState.PreviewWhileRunning)
		{
			this.DoPanning();
		}
		if (WPFMonoBehaviour.levelManager.gameState == LevelManager.GameState.Building)
		{
			if (!DeviceInfo.UsesTouchInput)
			{
				float num = Input.GetAxis("Mouse ScrollWheel") + this.m_keyZoomDelta;
				if (num < 0f && !WPFMonoBehaviour.levelManager.ConstructionUI.IsDragging())
				{
					WPFMonoBehaviour.levelManager.SetGameState(LevelManager.GameState.PreviewWhileBuilding);
					Singleton<AudioManager>.Instance.Play2dEffect(WPFMonoBehaviour.gameData.commonAudioCollection.cameraZoomOut);
				}
			}
			else if (Input.touchCount == 2)
			{
				Touch touch = Input.GetTouch(0);
				Touch touch2 = Input.GetTouch(1);
				Vector2 vector = touch.position - touch2.position;
				Vector2 vector2 = touch.position - touch.deltaPosition - (touch2.position - touch2.deltaPosition);
				float num2 = vector.magnitude - vector2.magnitude;
				num2 /= (float)Screen.height;
				this.m_zoomGestureDistance += num2;
				if (this.m_zoomGestureDistance < -0.25f && !WPFMonoBehaviour.levelManager.ConstructionUI.IsDragging())
				{
					WPFMonoBehaviour.levelManager.SetGameState(LevelManager.GameState.PreviewWhileBuilding);
					Singleton<AudioManager>.Instance.Play2dEffect(WPFMonoBehaviour.gameData.commonAudioCollection.cameraZoomOut);
				}
			}
			else
			{
				this.m_zoomGestureDistance = 0f;
			}
		}
		if (WPFMonoBehaviour.levelManager.gameState == LevelManager.GameState.PreviewWhileBuilding)
		{
			if (!DeviceInfo.UsesTouchInput)
			{
				if (this.currentFOV <= 9f)
				{
					float num3 = Input.GetAxis("Mouse ScrollWheel") + this.m_keyZoomDelta;
					if (num3 > 0f)
					{
						this.StopTransitionToPreview();
						WPFMonoBehaviour.levelManager.SetGameState(LevelManager.GameState.Building);
						Singleton<AudioManager>.Instance.Play2dEffect(WPFMonoBehaviour.gameData.commonAudioCollection.cameraZoomIn);
					}
				}
			}
			else if (Input.touchCount == 2 && this.currentFOV < 10f)
			{
				Touch touch3 = Input.GetTouch(0);
				Touch touch4 = Input.GetTouch(1);
				Vector2 vector3 = touch3.position - touch4.position;
				Vector2 vector4 = touch3.position - touch3.deltaPosition - (touch4.position - touch4.deltaPosition);
				float num4 = vector3.magnitude - vector4.magnitude;
				num4 /= (float)Screen.height;
				this.m_zoomGestureDistance += num4;
				if (this.m_zoomGestureDistance > 0.25f)
				{
					this.StopTransitionToPreview();
					WPFMonoBehaviour.levelManager.SetGameState(LevelManager.GameState.Building);
					Singleton<AudioManager>.Instance.Play2dEffect(WPFMonoBehaviour.gameData.commonAudioCollection.cameraZoomIn);
				}
			}
			else
			{
				this.m_zoomGestureDistance = 0f;
			}
		}
	}

	private void UpdatePosition()
	{
		LevelManager.GameState gameState = LevelManager.GameState.Building;
		if (WPFMonoBehaviour.levelManager)
		{
			gameState = WPFMonoBehaviour.levelManager.gameState;
		}
		this.currentPos = base.transform.position;
		this.currentFOV = this.m_camera.orthographicSize;
		switch (gameState)
		{
			case LevelManager.GameState.Building:
				if (this.m_state != IngameCamera.CameraState.Building)
				{
					this.StopTransitionToPreview();
				}
				this.m_state = IngameCamera.CameraState.Building;
				this.UpdateGameCamera(ref this.currentPos, ref this.currentFOV);
				break;
			case LevelManager.GameState.Preview:
				this.currentPos = this.m_cameraPreview.ControlPoints[0].position;
				this.currentFOV = this.m_cameraPreview.ControlPoints[0].zoom;
				break;
			case LevelManager.GameState.PreviewMoving:
				this.m_cameraPreview.UpdateCameraPreview(ref this.currentPos, ref this.currentFOV);
				if (this.m_cameraPreview.Done)
				{
					WPFMonoBehaviour.levelManager.CameraPreviewDone();
				}
				break;
			case LevelManager.GameState.PreviewWhileBuilding:
				if (this.m_state == IngameCamera.CameraState.Building)
				{
					this.m_state = IngameCamera.CameraState.Preview;
					base.StartCoroutine("EnablePreviewMode");
				}
				this.UpdateGameCamera(ref this.currentPos, ref this.currentFOV);
				break;
			case LevelManager.GameState.PreviewWhileRunning:
				this.m_state = IngameCamera.CameraState.Preview;
				this.UpdateGameCamera(ref this.currentPos, ref this.currentFOV);
				break;
			case LevelManager.GameState.Running:
				if (!WPFMonoBehaviour.levelManager.ContraptionRunning.m_cameraTarget || GameTime.DeltaTime == 0f)
				{
					return;
				}
				if (this.m_state != IngameCamera.CameraState.Follow)
				{
					this.m_state = IngameCamera.CameraState.Follow;
					this.m_freeCameraMode = false;
					this.m_autoZoomAmount = 0f;
					this.m_autoZoomEnabled = true;
					this.panPosition = Vector3.zero;
					this.m_mouseZoomDelta = 0f;
					this.m_birdsCache = null;
				}
				this.UpdateGameCamera(ref this.currentPos, ref this.currentFOV);
				this.currentFOV = Mathf.Clamp(this.currentFOV, 2f, 20f);
				break;
			case LevelManager.GameState.Completed:
				this.UpdateGameCamera(ref this.currentPos, ref this.currentFOV);
				this.currentFOV = Mathf.Clamp(this.currentFOV, 2f, 20f);
				break;
			case LevelManager.GameState.ShowingUnlockedParts:
				if (this.m_state != IngameCamera.CameraState.Building)
				{
					this.StopTransitionToPreview();
				}
				this.m_state = IngameCamera.CameraState.Building;
				this.UpdateGameCamera(ref this.currentPos, ref this.currentFOV);
				break;
		}
		this.EnforceCameraLimits(ref this.currentPos, ref this.currentFOV);
		if (!float.IsNaN(this.currentPos.x) && !float.IsNaN(this.currentPos.y) && !float.IsNaN(this.currentPos.z))
		{
			base.transform.position = this.currentPos;
		}
		this.m_camera.orthographicSize = this.currentFOV;
	}

	private void UpdateGameCamera(ref Vector3 currentPos, ref float currentFOV)
	{
		switch (this.m_state)
		{
			case IngameCamera.CameraState.Follow:
				this.UpdateCameraFollow(ref currentPos, ref currentFOV);
				break;
			case IngameCamera.CameraState.Building:
				this.UpdateCameraBuilding(ref currentPos, ref currentFOV);
				break;
			case IngameCamera.CameraState.Preview:
				this.UpdateCameraPreview(ref currentPos, ref currentFOV);
				break;
		}
	}

	private void UpdateCameraBuilding(ref Vector3 currentPos, ref float currentFOV)
	{
		Vector3 a = (Vector3)this.m_cameraPreview.ControlPoints[this.m_cameraPreview.ControlPoints.Count - 1].position - currentPos;
		currentPos += a * GameTime.DeltaTime * 4f;
		float num = this.m_cameraBuildZoom - currentFOV;
		currentFOV += num * GameTime.DeltaTime * 4f;
	}

	private void ClampToCameraLimits(ref Rect box)
	{
		Rect rect = new Rect(this.m_cameraLimits.topLeft.x, this.m_cameraLimits.topLeft.y - this.m_cameraLimits.size.y, this.m_cameraLimits.size.x, this.m_cameraLimits.size.y);
		if (box.xMin < rect.xMin)
		{
			box = Rect.MinMaxRect(rect.xMin, box.yMin, Mathf.Max(rect.xMin, box.xMax), box.yMax);
		}
		if (box.yMin < rect.yMin)
		{
			box = Rect.MinMaxRect(box.xMin, rect.yMin, box.xMax, Mathf.Max(rect.yMin, box.yMax));
		}
		if (box.xMax > rect.xMax)
		{
			box = Rect.MinMaxRect(Mathf.Min(box.xMin, rect.xMax), box.yMin, rect.xMax, box.yMax);
		}
		if (box.yMax > rect.yMax)
		{
			box = Rect.MinMaxRect(box.xMin, Mathf.Min(box.yMin, rect.yMax), box.xMax, rect.yMax);
		}
	}

	private void AddBirdsToBoundingBox(ref Rect box)
	{
		if (this.m_birdsCache == null)
		{
			this.m_birdsCache = GameObject.FindGameObjectsWithTag("Bird");
		}
		if (this.m_birdsCache != null)
		{
			for (int i = 0; i < this.m_birdsCache.Length; i++)
			{
				GameObject gameObject = this.m_birdsCache[i];
				if (gameObject.GetComponent<Bird>().IsDisturbed() && ((Mathf.Abs(gameObject.transform.position.y - this.currentPos.y) < 20f && Mathf.Abs(gameObject.transform.position.x - this.currentPos.x) < 20f * (float)Screen.width / (float)Screen.height) || gameObject.GetComponent<Bird>().IsAttacking()))
				{
					Vector3 position = gameObject.transform.position;
					Vector2 min = new Vector2(position.x - 8f, position.y - 2f);
					Vector2 max = new Vector2(position.x + 4f, position.y + 2f);
					Contraption.AddToBoundingBox(ref box, min, max);
				}
			}
		}
	}

	private void AutoZoom(ref Vector3 currentPos, ref float currentFOV)
	{
		if (!this.m_autoZoomEnabled || this.m_returningToDefaultPosition)
		{
			return;
		}
		Rect rect = WPFMonoBehaviour.levelManager.ContraptionRunning.BoundingBox();
		Rect rect2 = rect;
		bool flag = false;
		this.AddBirdsToBoundingBox(ref rect2);
		if (rect2.width > rect.width || rect2.height > rect2.height)
		{
			flag = true;
		}
		this.ClampToCameraLimits(ref rect2);
		Vector3 vector = currentPos - new Vector3((float)Screen.width * currentFOV / (float)Screen.height, currentFOV, 0f);
		Vector3 vector2 = currentPos + new Vector3((float)Screen.width * currentFOV / (float)Screen.height, currentFOV, 0f);
		Rect rect3 = default(Rect);
		float num = 0.3f;
		rect3.xMin = vector.x + num;
		rect3.xMax = vector2.x - num;
		rect3.yMin = vector.y + num;
		rect3.yMax = vector2.y - num;
		float num2 = -10f;
		num2 = Mathf.Max(num2, vector.x - rect2.xMin);
		num2 = Mathf.Max(num2, vector.y - rect2.yMin);
		num2 = Mathf.Max(num2, rect2.xMax - vector2.x);
		num2 = Mathf.Max(num2, rect2.yMax - vector2.y);
		num2 = Mathf.Clamp(num2, -4f, 2f);
		if (num2 > 0f)
		{
			float num3 = (!flag) ? 10f : 4f;
			float num4 = num3 * Time.deltaTime * num2;
			if (currentFOV + num4 > 20f)
			{
				num4 = 20f - currentFOV;
			}
			currentFOV += num4;
			this.m_autoZoomAmount += num4;
		}
		else if (this.m_autoZoomAmount > 0f && num2 < -0.5f)
		{
			float b = (num2 + 0.5f) * Time.deltaTime;
			float num5 = (!flag) ? 1f : 2f;
			float num6 = -num5 * Time.deltaTime * this.m_autoZoomAmount;
			num6 = Mathf.Max(num6, b);
			if (currentFOV + num6 < this.m_cameraMinZoom)
			{
				num6 = this.m_cameraMinZoom - currentFOV;
			}
			currentFOV += num6;
			this.m_autoZoomAmount += num6;
		}
	}

	private void UpdateCameraFollow(ref Vector3 currentPos, ref float currentFOV)
	{
		if (WPFMonoBehaviour.levelManager.ContraptionRunning == null)
		{
			return;
		}
		this.AutoZoom(ref currentPos, ref currentFOV);
		float zoomDelta = this.GetZoomDelta();
		if (currentFOV < this.m_cameraMinZoom)
		{
			float num = this.m_cameraMinZoom - currentFOV;
			currentFOV += 3.5f * num * GameTime.DeltaTime;
		}
		Vector3 position = WPFMonoBehaviour.levelManager.ContraptionRunning.m_cameraTarget.transform.position;
		float f = (currentPos.x - position.x) / (currentFOV * ((float)Screen.width / (float)Screen.height));
		float f2 = (currentPos.y - position.y) / currentFOV;
		if ((Mathf.Abs(f) > 1f || Mathf.Abs(f2) > 1f) && !this.m_returningToDefaultPosition)
		{
			if (this.isPanning || zoomDelta != 0f)
			{
				this.m_freeCameraMode = true;
			}
		}
		else if (this.m_freeCameraMode)
		{
			this.m_freeCameraMode = false;
			this.m_returningToDefaultPosition = true;
			this.m_returnToCenterSpeed = 50f;
		}
		Vector3 a;
		if (this.m_freeCameraMode)
		{
			a = Vector3.zero;
		}
		else
		{
			a = position + Vector3.ClampMagnitude(WPFMonoBehaviour.levelManager.ContraptionRunning.m_cameraTarget.GetComponent<Rigidbody>().velocity * 1.5f, 20f) - (currentPos - this.panPosition);
		}
		currentPos += a * GameTime.DeltaTime;
		if (this.isPanning || this.m_panningSpeed > 10f)
		{
			Vector3 vector = this.GetPanDelta();
			if (!this.isPanning)
			{
				vector = Time.deltaTime * (this.m_panningSpeed - 10f) * this.m_panningVelocity.normalized;
				this.m_panningSpeed *= Mathf.Pow(0.925f, Time.deltaTime / 0.0166666675f);
			}
			this.m_autoZoomEnabled = false;
			this.m_autoZoomAmount = 0f;
			Vector3 a2 = currentPos + vector;
			this.EnforceCameraLimits(ref a2, ref currentFOV);
			Vector3 b = a2 - (currentPos + vector);
			vector += b;
			this.panPosition += vector;
			currentPos += vector;
		}
		if (zoomDelta != 0f)
		{
			if (Mathf.Abs(zoomDelta) > 0.01f)
			{
				this.m_returningToDefaultPosition = false;
				this.m_autoZoomEnabled = false;
				this.m_autoZoomAmount = 0f;
			}
			float num2 = currentFOV;
			currentFOV += zoomDelta;
			currentFOV = Mathf.Clamp(currentFOV, this.m_cameraMinZoom, this.m_cameraMaxZoom);
			Vector3 a3 = currentPos;
			this.EnforceCameraLimits(ref a3, ref currentFOV);
			Vector3 b2 = a3 - currentPos;
			this.panPosition += b2;
			float num3 = currentFOV - num2;
			if (num3 < 0f)
			{
				Vector3 a4 = WPFMonoBehaviour.ScreenToZ0(Input.mousePosition) - currentPos;
				a4.z = 0f;
				Vector3 vector2 = -0.15f * num3 * a4;
				Vector3 a5 = currentPos + vector2;
				this.EnforceCameraLimits(ref a5, ref currentFOV);
				Vector3 b3 = a5 - (currentPos + vector2);
				vector2 += b3;
				this.panPosition += vector2;
				currentPos += vector2;
			}
		}
		if (GuiManager.GetPointer().doubleClick && !GuiManager.GetPointer().onWidget)
		{
			this.m_returningToDefaultPosition = true;
			if (this.m_freeCameraMode)
			{
				this.m_returnToCenterSpeed = 50f;
			}
		}
		else if (GuiManager.TouchCount != 0)
		{
			this.m_returningToDefaultPosition = false;
		}
		if (this.m_returningToDefaultPosition)
		{
			if (this.m_freeCameraMode)
			{
				this.m_freeCameraMode = false;
			}
			this.m_autoZoomEnabled = true;
			Vector3 b4 = currentPos - this.panPosition;
			this.EnforceCameraLimits(ref b4, ref currentFOV);
			if (this.m_returnToCenterSpeed < 200f)
			{
				this.m_returnToCenterSpeed += 100f * Time.deltaTime;
			}
			Vector3 a6 = -this.panPosition;
			if (a6.sqrMagnitude > 1f)
			{
				a6 = a6.normalized;
			}
			Vector3 vector3 = this.m_returnToCenterSpeed * Time.deltaTime * a6;
			Vector3 a7 = currentPos + vector3;
			this.EnforceCameraLimits(ref a7, ref currentFOV);
			Vector3 b5 = a7 - (currentPos + vector3);
			vector3 += b5;
			this.panPosition += vector3;
			currentPos += vector3;
			if (Vector3.Distance(currentPos, b4) < 0.01f && Mathf.Abs(this.m_cameraMinZoom - currentFOV) < 0.01f)
			{
				this.m_returningToDefaultPosition = false;
			}
			if (currentFOV > this.m_cameraMinZoom)
			{
				float num4 = this.m_cameraMinZoom - currentFOV;
				num4 = Mathf.Clamp(num4, -1f, 1f);
				currentFOV += 0.2f * this.m_returnToCenterSpeed * num4 * Time.deltaTime;
			}
		}
		else if (!this.isPanning && zoomDelta == 0f)
		{
			this.m_returnToCenterTimer += Time.deltaTime;
			if (this.m_returnToCenterTimer > 4f)
			{
				if (this.m_freeCameraMode)
				{
					this.m_returnToCenterSpeed = 50f;
				}
				this.m_freeCameraMode = false;
				if (this.m_returnToCenterSpeed < 80f)
				{
					this.m_returnToCenterSpeed += 40f * Time.deltaTime;
				}
				Vector3 a8 = -this.panPosition;
				if (a8.sqrMagnitude > 1f)
				{
					a8 = a8.normalized;
				}
				Vector3 vector4 = this.m_returnToCenterSpeed * Time.deltaTime * a8;
				Vector3 a9 = currentPos + vector4;
				this.EnforceCameraLimits(ref a9, ref currentFOV);
				Vector3 b6 = a9 - (currentPos + vector4);
				vector4 += b6;
				this.panPosition += vector4;
				currentPos += vector4;
			}
		}
		else
		{
			this.m_returnToCenterTimer = 0f;
			this.m_returnToCenterSpeed = 0f;
		}
	}

	private void UpdateCameraPreview(ref Vector3 currentPos, ref float currentFOV)
	{
		Vector3 b = this.GetPanDelta();
		if (!this.isPanning && this.m_panningSpeed > 10f)
		{
			b = Time.deltaTime * (this.m_panningSpeed - 10f) * this.m_panningVelocity.normalized;
			this.m_panningSpeed *= Mathf.Pow(0.925f, Time.deltaTime / 0.0166666675f);
		}
		currentPos += b;
		float zoomDelta = this.GetZoomDelta();
		if (!this.m_transitionToPreviewActive || zoomDelta > 0f)
		{
			float num = currentFOV;
			currentFOV += zoomDelta;
			float min = (!this.m_transitionToPreviewActive) ? 9f : this.m_cameraBuildZoom;
			currentFOV = Mathf.Clamp(currentFOV, min, this.m_cameraMaxZoom);
			float num2 = currentFOV - num;
			if (num2 < 0f)
			{
				Vector3 a = WPFMonoBehaviour.ScreenToZ0(Input.mousePosition) - currentPos;
				a.z = 0f;
				Vector3 vector = -0.15f * num2 * a;
				Vector3 a2 = currentPos + vector;
				this.EnforceCameraLimits(ref a2, ref currentFOV);
				Vector3 b2 = a2 - (currentPos + vector);
				vector += b2;
				this.panPosition += vector;
				currentPos += vector;
			}
		}
		if (GuiManager.GetPointer().doubleClick && !GuiManager.GetPointer().onWidget)
		{
			WPFMonoBehaviour.levelManager.SetGameState(LevelManager.GameState.Building);
			Singleton<AudioManager>.Instance.Play2dEffect(WPFMonoBehaviour.gameData.commonAudioCollection.cameraZoomIn);
		}
	}

	private Vector3 GetPanDelta()
	{
		if (!this.isPanning)
		{
			return Vector3.zero;
		}
		if (!DeviceInfo.UsesTouchInput)
		{
			Vector3 vector = WPFMonoBehaviour.ScreenToZ0(this.m_panStartPosition) - WPFMonoBehaviour.ScreenToZ0(Input.mousePosition);
			this.m_panStartPosition = Input.mousePosition;
			this.CalculatePanningSpeed(vector);
			return vector;
		}
		if (Input.touchCount != 1)
		{
			return Vector3.zero;
		}
		Touch touch = Input.GetTouch(0);
		if (touch.fingerId != this.m_panTouchFingerId)
		{
			return Vector3.zero;
		}
		Vector3 vector2 = WPFMonoBehaviour.ScreenToZ0(this.m_panStartPosition) - WPFMonoBehaviour.ScreenToZ0(touch.position);
		this.m_panStartPosition = touch.position;
		this.CalculatePanningSpeed(vector2);
		return vector2;
	}

	private void CalculatePanningSpeed(Vector3 newDelta)
	{
		while (this.m_panningHistory.Count > 0 && this.m_panningHistory.Peek().time < Time.time - 0.1f)
		{
			this.m_panningHistory.Dequeue();
		}
		this.m_panningHistory.Enqueue(new IngameCamera.PanningData(Time.time, newDelta));
		Vector3 vector = Vector3.zero;
		float time = this.m_panningHistory.Peek().time;
		float num = 0f;
		foreach (IngameCamera.PanningData panningData in this.m_panningHistory)
		{
			vector += panningData.delta;
			num = panningData.time - time;
		}
		if (num > 0f)
		{
			vector /= num;
		}
		this.m_panningVelocity = vector;
		this.m_panningSpeed = vector.magnitude;
	}

	public void HandleKeyInput(KeyCode key)
	{
		if (key == KeyCode.KeypadPlus)
		{
			this.m_keyZoomDelta += 1f * Time.deltaTime;
		}
		else if (key == KeyCode.KeypadMinus)
		{
			this.m_keyZoomDelta -= 1f * Time.deltaTime;
		}
	}

	private float GetZoomDelta()
	{
		if (WPFMonoBehaviour.levelManager.gameState == LevelManager.GameState.Completed)
		{
			return 0f;
		}
		if (DeviceInfo.UsesTouchInput)
		{
			if (Input.touchCount != 2)
			{
				return 0f;
			}
			try
			{
				if (GuiManager.GetPointer(0).touchUsed || GuiManager.GetPointer(1).touchUsed)
				{
					return 0f;
				}
				Touch touch = Input.GetTouch(0);
				Touch touch2 = Input.GetTouch(1);
				Vector2 vector = touch.position - touch2.position;
				Vector2 vector2 = touch.position - touch.deltaPosition - (touch2.position - touch2.deltaPosition);
				float num = vector.magnitude - vector2.magnitude;
				return -num * GameTime.DeltaTime;
			}
			catch
			{
				return 0f;
			}
		}
		this.m_mouseZoomDelta += -16f * (Input.GetAxis("Mouse ScrollWheel") + this.m_keyZoomDelta);
		float num2 = 4f * Time.deltaTime * this.m_mouseZoomDelta;
		if (this.m_mouseZoomDelta < 0f)
		{
			num2 = Mathf.Max(num2, this.m_mouseZoomDelta);
		}
		else if (this.m_mouseZoomDelta > 0f)
		{
			num2 = Mathf.Min(num2, this.m_mouseZoomDelta);
		}
		this.m_mouseZoomDelta -= num2;
		return num2;
	}

	private void EnforceCameraLimits(ref Vector3 newPos, ref float ortoSize)
	{
		float num = (float)Screen.width / (float)Screen.height;
		float a = this.m_cameraLimits.size.x / 2f / num;
		float b = this.m_cameraLimits.size.y / 2f;
		float num2 = Mathf.Min(a, b);
		if (ortoSize > num2)
		{
			ortoSize = num2;
		}
		float min = this.m_cameraLimits.topLeft.x + ortoSize * num;
		float max = this.m_cameraLimits.topLeft.x + this.m_cameraLimits.size.x - ortoSize * num;
		float max2 = this.m_cameraLimits.topLeft.y - this.m_camera.orthographicSize;
		float min2 = this.m_cameraLimits.topLeft.y - this.m_cameraLimits.size.y + ortoSize;
		newPos.x = Mathf.Clamp(newPos.x, min, max);
		newPos.y = Mathf.Clamp(newPos.y, min2, max2);
		newPos.z = -15f;
	}

	private void DoPanning()
	{
		if (DeviceInfo.UsesTouchInput)
		{
			if (Input.touchCount == 1)
			{
				if (!this.isPanning)
				{
					if (!this.m_isStartingPan && Input.GetTouch(0).phase == TouchPhase.Began && !GuiManager.GetPointer().onWidget)
					{
						this.m_panStartPosition = Input.GetTouch(0).position;
						this.m_panTouchFingerId = Input.GetTouch(0).fingerId;
						this.m_isStartingPan = true;
					}
					if (this.m_isStartingPan && Input.GetTouch(0).fingerId == this.m_panTouchFingerId && Vector3.Distance(Input.GetTouch(0).position, this.m_panStartPosition) > 30f)
					{
						this.isPanning = true;
						this.m_panningSpeed = 0f;
					}
				}
			}
			else
			{
				this.m_isStartingPan = false;
				this.isPanning = false;
			}
		}
		else
		{
			GuiManager.Pointer pointer = GuiManager.GetPointer();
			if (pointer.down && !pointer.onWidget)
			{
				this.m_panStartPosition = Input.mousePosition;
				this.m_isStartingPan = true;
			}
			if (pointer.dragging)
			{
				if (this.m_isStartingPan && Vector3.Distance(Input.mousePosition, this.m_panStartPosition) > 30f)
				{
					this.isPanning = true;
					this.m_isStartingPan = false;
					this.m_panningSpeed = 0f;
				}
			}
			else
			{
				this.isPanning = false;
				this.m_isStartingPan = false;
			}
		}
	}

	protected Vector3 m_integratedVelocity;

	private LevelManager.CameraLimits m_cameraLimits;

	private const float ShowNextTargetCameraDelay = 2f;

	private const bool ZoomToNextBoxWhenCompleted = false;

	private CameraPreview m_cameraPreview;

	private Camera m_camera;

	private SnapshotEffect m_snapshotFX;

	private Vector3 currentPos;

	private Vector3 followPosition;

	private Vector3 panPosition;

	private bool m_freeCameraMode;

	private float m_mouseZoomDelta;

	private float m_keyZoomDelta;

	private float m_zoomGestureDistance;

	private bool isPanning;

	private float currentFOV;

	private float m_autoZoomAmount;

	private bool m_autoZoomEnabled = true;

	private const float CAMERA_MAX_ZOOM = 20f;

	private const float CAMERA_PREVIEW_ZOOM = 9f;

	private float m_cameraBuildZoom;

	private float m_cameraMaxZoom;

	private float m_cameraMinZoom;

	protected IngameCamera.CameraState m_state;

	private Vector3 m_panStartPosition;

	private int m_panTouchFingerId;

	private float m_transitionTimer;

	private bool m_isStartingPan;

	private bool m_transitionToPreviewActive;

	private float m_returnToCenterTimer;

	private float m_returnToCenterSpeed;

	private Queue<IngameCamera.PanningData> m_panningHistory = new Queue<IngameCamera.PanningData>();

	private float m_panningSpeed;

	private Vector3 m_panningVelocity;

	private bool m_returningToDefaultPosition;

	private GameObject[] m_birdsCache;

	public enum CameraState
	{
		Follow,
		Pan,
		Zoom,
		Wait,
		Building,
		Preview
	}

	private class PanningData
	{
		public PanningData(float time, Vector3 delta)
		{
			this.time = time;
			this.delta = delta;
		}

		public float time;

		public Vector3 delta;
	}
}
