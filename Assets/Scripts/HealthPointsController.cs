using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPointsController : MonoBehaviour
{
    [SerializeField] private Image healthPointPrefab;
    [SerializeField] private GameSettingsSO gameSettingsSO;
    [SerializeField] private Color normalColor;
    [SerializeField] private Color grayedColor;

    private GameSettings currentSettings => gameSettingsSO.CurrentSettings;

    private List<Image> healthPoints = new List<Image>();

    private int currentHealthPoints;

    private void Start()
    {
        currentHealthPoints = currentSettings.Health;
        for (int i = 0; i < currentSettings.Health; i++)
        {
            healthPoints.Add(Instantiate(healthPointPrefab, transform));
        } 
    }

    public void DecreaseHealthPoints()
    {
        currentHealthPoints--;
        RefreshVisualisation();
    }

    private void RefreshVisualisation()
    {
        healthPoints.ForEach(healthPoint => healthPoint.color = grayedColor);
        for (int i = 0; i < currentHealthPoints; i++)
        {
            healthPoints[i].color = normalColor;
        }
    }
}
