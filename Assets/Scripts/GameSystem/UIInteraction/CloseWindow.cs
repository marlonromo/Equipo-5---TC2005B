using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWindow : MonoBehaviour
{
    public GameObject WindowToClose;
    public void closeWindow(){
        WindowToClose.SetActive(false);
        Time.timeScale = 1;
    }
}
