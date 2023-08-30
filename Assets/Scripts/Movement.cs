using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    [SerializeField] private float speed = 10f;
    [SerializeField] private float maxSpeed = 50f;
    [SerializeField] private float rotationSpeed = 100f;

    private CinemachineTransposer _transposer;

    private readonly float backwardMulitplier = 0.75f;

    private void Start()
    {
        _transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        rb.centerOfMass = new Vector3 (0, -0.5f, 0);
    }

    private void Update()
    {
        ProccessMovement();
    }

    private void ProccessMovement()
    {
        float moveInput = Input.GetAxis("Vertical");
        float rotationInput = Input.GetAxis("Horizontal");

        // Przyspieszanie i hamowanie
        Vector3 forwardForce = transform.forward * moveInput * speed * Time.deltaTime;
        forwardForce = moveInput > 0 ? forwardForce : forwardForce * backwardMulitplier;

        Vector3 currentVelocity = rb.velocity;
        Vector3 forwardDirection = transform.forward;
        float currentSpeed = currentVelocity.magnitude;
        float movementDirection = Vector3.Dot(currentVelocity, forwardDirection);

        if (currentSpeed < maxSpeed || (moveInput < 0 && movementDirection > 0))
        {
            rb.AddForce(forwardForce);
        }

        // Skrêcanie
        float torque = rotationInput * rotationSpeed * Time.deltaTime;
        torque = movementDirection > 0 ? torque : -torque;
        rb.AddTorque(transform.up * torque);

        float blend = currentSpeed / maxSpeed; // Wartoœæ z przedzia³u 0 do 1

        // Dostosuj wartoœæ oddalania kamery
        float damping = Mathf.Lerp(-15f, -20f, blend); // Eksperymentuj z tymi wartoœciami
        _transposer.m_FollowOffset.z = damping;

        // Przeka¿ prêdkoœæ samochodu do komponentu VirtualCamera
        virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = blend;
    }
}

