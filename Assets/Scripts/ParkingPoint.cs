using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingPoint : MonoBehaviour
{
    [SerializeField] private BoxCollider myCollider;
    
    public ParkingPointsRandomizer Randomizer;

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        Randomizer.ActivateRandomizedPoint();
        PointsController.Instance.IncrementPoints();
    }
}
