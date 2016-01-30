using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public float CameraSpeed = 0.1f;
	public float InitialZoom = 7.5f;
	public float ZoomSpeed = 0.4f;
	
	protected bool _isZooming;
	protected float _currentZoom;
	protected float _targetZoom;
	protected Camera _camera;
	
	private float xMin;
	private float xMax;
	private float yMin;
	private float yMax;
	
	protected LevelLimits _levelBounds;
	
	protected Coroutine _zoomCoroutine;
	
	private Vector3 currentVelocity;
	private Vector3 lastPosition;
	private Vector3 targetPos;
	
	void Start() {
		// we get the camera component
		_camera=GetComponent<Camera>();
		
		_currentZoom=InitialZoom;
		
		_levelBounds = GameObject.FindGameObjectWithTag("LevelBounds").GetComponent<LevelLimits>();
		
		SetZoomImmediate(InitialZoom);
	}
	
	void Update() {
	
	#if (UNITY_IPHONE || UNITY_ANDROID) && !UNITY_EDITOR
		Debug.Log (Input.touchCount);
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			targetPos = transform.lastPosition + new Vector3(-touchDeltaPosition.x * CameraSpeed, -touchDeltaPosition.y * CameraSpeed, 0);
		}
		
		if (Input.touchCount >= 2)
		{
			Vector2 touch0, touch1;
			float distance;
			touch0 = Input.GetTouch(0).position;
			touch1 = Input.GetTouch(1).position;
			distance = Vector2.Distance(touch0, touch1);
			this.GetComponent<Camera>().orthographicSize = 
		}
		#else
		if (Input.GetMouseButtonDown(0)) {
			lastPosition = Input.mousePosition;
		}
		
		if (Input.GetMouseButton(0)) {
			Vector3 delta = Input.mousePosition - lastPosition;
			targetPos = transform.position + new Vector3(delta.x * CameraSpeed, delta.y * CameraSpeed, 0);
			lastPosition = Input.mousePosition;
		}
	#endif
	
	}
	
	void LateUpdate() {
		Vector3 newCameraPosition = Vector3.SmoothDamp(transform.position, targetPos, ref currentVelocity, CameraSpeed);
		
		// Clamp to level boundaries
		float posX = Mathf.Clamp(newCameraPosition.x, xMin, xMax);
		float posY = Mathf.Clamp(newCameraPosition.y, yMin, yMax);
		float posZ = newCameraPosition.z;
		
		// We move the actual transform
		transform.position = new Vector3(posX, posY, posZ);
	}
	
	public void ZoomToSizeOverTime(float targetSize, float zoomTime)
	{
		_targetZoom = targetSize;
		
		if (_zoomCoroutine != null)
		{
			StopCoroutine(_zoomCoroutine);
		}
		
		_zoomCoroutine = StartCoroutine (PerformZoomToSizeOverTime (targetSize, zoomTime));
	}
	
	private IEnumerator PerformZoomToSizeOverTime(float targetSize, float zoomTime)
	{
		float currentVelocity = 0f;
		_targetZoom = targetSize;
		
		while (_currentZoom != _targetZoom)
		{
			_currentZoom = Mathf.SmoothDamp(_currentZoom, _targetZoom, ref currentVelocity, zoomTime);
			
			_camera.orthographicSize = _currentZoom;
			GetLevelBounds ();
			
			yield return null;
		}
		
		_zoomCoroutine = null;
	}
	
	public void SetZoomImmediate(float zoomSize)
	{
		_targetZoom = _currentZoom = zoomSize;
		
		_camera.orthographicSize = _currentZoom;
		GetLevelBounds ();
	}
	
	public float GetCurrentZoom()
	{
		return _currentZoom;
	}
	
	/// <summary>
	/// Gets the levelbounds coordinates to lock the camera into the level
	/// </summary>
	private void GetLevelBounds()
	{
		// camera size calculation (orthographicSize is half the height of what the camera sees.
		float cameraHeight = Camera.main.orthographicSize * 2f;
		float cameraWidth = cameraHeight * Camera.main.aspect;
		
		xMin = _levelBounds.LeftLimit+(cameraWidth/2);
		xMax = _levelBounds.RightLimit-(cameraWidth/2);
		yMin = _levelBounds.BottomLimit+(cameraHeight/2);
		yMax = _levelBounds.TopLimit-(cameraHeight/2);
	}
}