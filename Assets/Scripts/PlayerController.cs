using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PrometeoCarController prometeoCarController;
    
    [SerializeField] private float timeToRespawn;

    public void Death()
    {
        prometeoCarController.ResetSpeed();
        prometeoCarController.enabled = false;
        StartCoroutine(RespawnAfterDelay());
    }

    private IEnumerator RespawnAfterDelay()
    {
        yield return new WaitForSeconds(timeToRespawn);    
        GameManager.Instance.HealthsController.DecreaseHealthPoints();
        var respawnPoint = GameManager.Instance.RespawnPoints.GetNearestPoint(transform);
        transform.position = respawnPoint.position;
        transform.rotation = respawnPoint.rotation;
        prometeoCarController.enabled = true;
        prometeoCarController.ResetSpeed();
    }
}
