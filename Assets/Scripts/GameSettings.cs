using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class GameSettings
{
    [field: SerializeField] public int Health { get; private set; }
}
