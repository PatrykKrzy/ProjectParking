using Cinemachine;
using UnityEngine;

public class CameraFollow : MonoBehaviour 
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private PrometeoCarController carController;
    [SerializeField] private Transform focusTransform;

    [SerializeField] private Vector2 yOffsetRange;
    [SerializeField] private Vector2 zOffsetRange;
    [SerializeField] private Vector2 zFocusRange;
    [SerializeField] private float smoothSpeed = 0.5f;
    
    private CinemachineTransposer _transposer;

    void Start()
	{
        _transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
    }

	void LateUpdate()
	{
        float blend = carController.carSpeed / carController.maxSpeed; 

        float dampingY = Mathf.Lerp(yOffsetRange.x, yOffsetRange.y, blend);
        float smoothedDampingY = Mathf.Lerp(_transposer.m_FollowOffset.y, dampingY, smoothSpeed * Time.deltaTime);
        _transposer.m_FollowOffset.y = smoothedDampingY;

        float dampingZ = Mathf.Lerp(zOffsetRange.x, zOffsetRange.y, blend);
        float smoothedDampingZ = Mathf.Lerp(_transposer.m_FollowOffset.z, dampingZ, smoothSpeed * Time.deltaTime);
        _transposer.m_FollowOffset.z = smoothedDampingZ;

        float focusZ = Mathf.Lerp(zFocusRange.x, zFocusRange.y, blend);
        float smoothedFocusZ = Mathf.Lerp(focusTransform.localPosition.z, focusZ, smoothSpeed * Time.deltaTime);
        focusTransform.localPosition = new Vector3(focusTransform.localPosition.x, focusTransform.localPosition.y, smoothedFocusZ);
    }
}
