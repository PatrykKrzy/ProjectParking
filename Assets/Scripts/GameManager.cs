using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [field: SerializeField] public HealthPointsController HealthsController { get; private set; }
    [field: SerializeField] public RespawnPoints RespawnPoints { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
}
