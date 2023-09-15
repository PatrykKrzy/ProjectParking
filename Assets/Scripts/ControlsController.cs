using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsController : MonoBehaviour
{
    [SerializeField] private Text controlsText;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            controlsText.enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            controlsText.enabled = false;
        }
    }
}
