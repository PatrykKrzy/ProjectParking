using Cinemachine;
using System.Collections;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private CarMover[] carPrefabs;
    [SerializeField] private CinemachineSmoothPath carPath;

    [SerializeField] private Vector2 timeBetweenCarsRange;
    [SerializeField] private Vector2 carSpeedRange;

    private IEnumerator Start()
    {
        while (true)
        {
            var carToSpawn = carPrefabs[Random.Range(0, carPrefabs.Length)];
            var timeBetweenCars = Random.Range(timeBetweenCarsRange.x, timeBetweenCarsRange.y);
            var carSpeed = Random.Range(carSpeedRange.x, carSpeedRange.y);
            yield return new WaitForSeconds(timeBetweenCars);
            var spawnedCar = Instantiate(carToSpawn, transform);
            spawnedCar.Init(carPath, carSpeed);
        }
    }
}
