using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLogisticMenu : MonoBehaviour
{
    public GameObject WindowToOpen;
    public GameObject blockInteraction;
    public GameObject Camera;
    public void openWindowNow(){
        WindowToOpen.SetActive(true);
        blockInteraction.SetActive(true);
        Camera.GetComponent<CameraMovement>().enableMove = false;
        Time.timeScale = 0;
    }
}
