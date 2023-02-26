using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Canvas joystickCanvas; 
    [SerializeField] GameObject powerSliderCanvas;

    public void TurnOffJoystickCanvas()
    {
        joystickCanvas.enabled = false;
        powerSliderCanvas.SetActive(true);
    }

}
