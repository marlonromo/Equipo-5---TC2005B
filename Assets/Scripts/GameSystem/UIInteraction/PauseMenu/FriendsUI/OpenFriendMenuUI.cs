using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFriendMenuUI : MonoBehaviour
{
    public GameObject FriendMenu;
    public GameObject blockInteraction;
    public GameObject Camera;
    public GameObject audioSettings;

    public void openWindowNow(){
        FriendMenu.SetActive(true);
        blockInteraction.SetActive(true);
        Camera.GetComponent<CameraMovement>().enableMove = false;
        Time.timeScale = 0;
        audioSettings.GetComponent<playMusic>().stopAudio();
    }

    public void closeWindowNow(){
        FriendMenu.SetActive(false);
        blockInteraction.SetActive(false);
        Camera.GetComponent<CameraMovement>().enableMove = true;
        Time.timeScale = 1;
        audioSettings.GetComponent<playMusic>().playAudio();
    }
}
