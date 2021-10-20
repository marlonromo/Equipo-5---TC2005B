using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWindow : MonoBehaviour
{
    public GameObject WindowToOpen;
    public GameObject blockInteraction;
    public void openWindowNow(){
        WindowToOpen.SetActive(true);
        blockInteraction.SetActive(true);
        Time.timeScale = 0;
    }
}
