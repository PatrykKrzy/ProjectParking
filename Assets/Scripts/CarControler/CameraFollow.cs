using Cinemachine;
using UnityEngine;

public class CameraFollow : MonoBehaviour 
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private PrometeoCarController carController;

    private CinemachineTransposer _transposer;

    void Start()
	{
        _transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
    }

	void LateUpdate()
	{
        float blend = carController.carSpeed / carController.maxSpeed; 
        float damping = Mathf.Lerp(-10f, -20f, blend); 
        _transposer.m_FollowOffset.z = damping;
    }
}
