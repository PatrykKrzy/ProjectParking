using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingPointsRandomizer : MonoBehaviour
{
    [SerializeField] private ParkingPoint[] parkingPoints;

    private ParkingPoint currentPoint;

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
        int randomizedIndex; 
        do
        {
            randomizedIndex = Random.Range(0, parkingPoints.Length);
        } while(currentPoint == parkingPoints[randomizedIndex]);
        currentPoint = parkingPoints[randomizedIndex];
        currentPoint.gameObject.SetActive(true);
    }
}
