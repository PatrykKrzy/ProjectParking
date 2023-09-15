using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingPointsRandomizer : MonoBehaviour
{
    [SerializeField] private ParkingPoint[] parkingPoints;

    private void Start()
    {
        foreach (var parkingPoint in parkingPoints)
        {
            parkingPoint.Randomizer = this;
        }
        ActivateRandomizedPoint();
    }

    public void ActivateRandomizedPoint()
    {
        int randomizedIndex = Random.Range(0, parkingPoints.Length);
        ParkingPoint randomizedPoint = parkingPoints[randomizedIndex];
        randomizedPoint.gameObject.SetActive(true);
    }
}
