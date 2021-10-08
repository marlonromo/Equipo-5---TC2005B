using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenuUI : MonoBehaviour
{
    public GameObject Menu;
    public GameObject blockInteraction;
    public GameObject Camera;
    public GameObject audioSettings;

    public void openWindowNow(){
        Menu.SetActive(true);
        blockInteraction.SetActive(true);
        Camera.GetComponent<CameraMovement>().enableMove = false;
        Time.timeScale = 0;
        audioSettings.GetComponent<playMusic>().SetVolumeLevel(0.2f);
    }

    public void closeWindowNow(){
        Menu.SetActive(false);
        blockInteraction.SetActive(false);
        Camera.GetComponent<CameraMovement>().enableMove = true;
        Time.timeScale = 1;
        audioSettings.GetComponent<playMusic>().SetVolumeLevel(1f);

    }
}
