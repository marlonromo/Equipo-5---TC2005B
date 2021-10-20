using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPauseMenu : MonoBehaviour
{
    public GameObject WindowToOpen;
    public GameObject blockInteraction;
    public GameObject Camera;
    public GameObject audioSettings;
    public void openWindowNow(){
        WindowToOpen.SetActive(true);
        blockInteraction.SetActive(true);
        Camera.GetComponent<CameraMovement>().enableMove = false;
        Time.timeScale = 0;
        audioSettings.GetComponent<playMusic>().stopAudio();
    }
}
