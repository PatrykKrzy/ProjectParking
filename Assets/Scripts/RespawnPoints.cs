using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RespawnPoints : MonoBehaviour
{
    [SerializeField] private Transform[] respawnPoints;

    public Transform GetNearestPoint(Transform transform)
    {
        return respawnPoints.OrderBy(point => Vector3.Distance(point.position, transform.position)).FirstOrDefault();
    }
}
