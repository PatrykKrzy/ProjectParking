using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float timeToRespawn;

    public void Death()
    {
        StartCoroutine(DeathCoro());
    }

    private IEnumerator DeathCoro()
    {
        yield return new WaitForSeconds(timeToRespawn);    
        GameManager.Instance.HealthsController.DecreaseHealthPoints();
        var respawnPoint = GameManager.Instance.RespawnPoints.GetNearestPoint(transform);
        transform.position = respawnPoint.position;
        transform.rotation = respawnPoint.rotation;
    }
}
