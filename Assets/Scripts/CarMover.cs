using Cinemachine;
using UnityEngine;

public class CarMover : MonoBehaviour
{
    [SerializeField] private CinemachineDollyCart cinemachineCart;

    private float carSpeed;

    public void Init(CinemachineSmoothPath carPath, float carSpeed)
    {
        cinemachineCart.m_Path = carPath;
        this.carSpeed = carSpeed;
    }

    private void Update()
    {
        cinemachineCart.m_Position += carSpeed * Time.deltaTime;
        if (cinemachineCart.m_Position > cinemachineCart.m_Path.PathLength)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bum");
        collision.rigidbody.AddExplosionForce(20000f, transform.position + Vector3.down * 5f, 15f, 1f, ForceMode.Impulse);
    }
}
