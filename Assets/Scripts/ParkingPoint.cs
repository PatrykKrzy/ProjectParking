using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingPoint : MonoBehaviour
{
    [SerializeField] private GameObject visualObject;

    public ParkingPointsRandomizer Randomizer;

    private float maxPositionDiff = 3f;
    private float maxRotationDiff = 5f;

    private void Awake()
    {
        visualObject.SetActive(false);
        gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log($"{transform.eulerAngles.y} - {other.transform.eulerAngles.y} = {Mathf.Abs(transform.eulerAngles.y - other.transform.eulerAngles.y)}");
        var positionCheck = (transform.position - other.transform.position).magnitude < maxPositionDiff;
        var rotationDiff = Mathf.Abs(transform.eulerAngles.y - other.transform.eulerAngles.y);
        var rotationCheck =  rotationDiff < maxRotationDiff || rotationDiff > 360 - maxRotationDiff || 
                             (rotationDiff > 180 - maxRotationDiff & rotationDiff < 180 + maxRotationDiff);
        var speedCheck = Mathf.Approximately(other.attachedRigidbody.gameObject.GetComponent<PrometeoCarController>().carSpeed, 0f);
        if (positionCheck & rotationCheck & speedCheck)
        {
            PointReached();
        }
    }

    private void PointReached()
    {
        gameObject.SetActive(false);
        Randomizer.ActivateRandomizedPoint();
        PointsController.Instance.IncrementPoints();
    }
}
