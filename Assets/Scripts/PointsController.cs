using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    public static PointsController Instance { get; private set; }

    [SerializeField] private TMP_Text pointsText;

    private int currentPoints = 0;

    private void Awake() => Instance = this;

    public void IncrementPoints()
    {
        currentPoints++;
        pointsText.text = currentPoints.ToString();
    }
}
