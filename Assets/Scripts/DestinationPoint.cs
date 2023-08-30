using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationPoint : MonoBehaviour
{
    [SerializeField] private Vector2 positionRange;

    private void Start()
    {
        RespawnPoint();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Get a point");
        RespawnPoint();
    }

    private void RespawnPoint()
    {
        float randomizedX = Random.Range(-positionRange.x, positionRange.x);
        float randomizedZ = Random.Range(-positionRange.y, positionRange.y);
        transform.position = new Vector3(randomizedX,transform.position.y, randomizedZ);
    }
}
