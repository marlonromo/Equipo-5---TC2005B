using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ResumeGame : MonoBehaviour
{
    public GameObject WindowToClose;
    public GameObject blockInteraction;
    public GameObject Camera;
    public playMusic playMusic;
    public void closeWindowPause(){
        WindowToClose.SetActive(false);
        blockInteraction.SetActive(false);
        Camera.GetComponent<CameraMovement>().enableMove = true;
        Time.timeScale = 1;
        playMusic.playAudio();
    }
}
