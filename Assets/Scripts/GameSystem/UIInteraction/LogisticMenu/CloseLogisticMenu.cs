using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseLogisticMenu : MonoBehaviour
{
    public GameObject WindowToClose;
    public GameObject blockInteraction;
    public GameObject Camera;
    public void closeWindowPause(){
        WindowToClose.SetActive(false);
        blockInteraction.SetActive(false);
        Camera.GetComponent<CameraMovement>().enableMove = true;
        Time.timeScale = 1;
    }
}
