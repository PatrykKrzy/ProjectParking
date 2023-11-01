using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettingsSO", menuName = "ScriptableObjects/GameSettings")]
public class GameSettingsSO : ScriptableObject
{
    public GameSettings CurrentSettings => gameSettings[0];
    [SerializeField] private GameSettings[] gameSettings;
}
