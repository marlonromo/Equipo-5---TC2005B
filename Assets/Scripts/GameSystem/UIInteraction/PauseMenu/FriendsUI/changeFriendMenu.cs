using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeFriendMenu : MonoBehaviour
{
    public GameObject WindowToOpen;
    public GameObject WindowToClose;

    public void changeWindow(){
        WindowToOpen.SetActive(true);
        WindowToClose.SetActive(false);
    }
}
