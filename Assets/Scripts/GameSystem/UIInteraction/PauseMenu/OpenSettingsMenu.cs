using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSettingsMenu : MonoBehaviour
{
    public GameObject SettingsUI;
    public GameObject PauseUIMenu;
    public bool openUI;
    public void openSettings(){
        SettingsUI.SetActive(openUI);
        PauseUIMenu.SetActive(!openUI);
    }
}
