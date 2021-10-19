using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCameraValues : MonoBehaviour
{
    public CameraMovement cameraMovement;
    public Text sliderValueSensibilityText;
    public Text sliderValueSpeedText;
    float displayNumberValueSensibility;
    float displayNumberValueSpeed;
    public void setCameraSensibility(float sliderValue){
        cameraMovement.mouseSensibilityX = sliderValue;
        cameraMovement.mouseSensibilityY = sliderValue;
        displayNumberValueSensibility = sliderValue;
        sliderValueSensibilityText.text = ((int)displayNumberValueSensibility).ToString();
    }

    public void setCameraSpeed(float sliderValue){
        cameraMovement.cameraSpeed = sliderValue;
        displayNumberValueSpeed = sliderValue;
        sliderValueSpeedText.text = ((int)displayNumberValueSpeed).ToString();
    }
}
