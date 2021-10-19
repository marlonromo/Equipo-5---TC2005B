using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayNameFriend : MonoBehaviour
{
    public Text friendNameText;
    public loadBuildingFriend loadBuildingFriend;
    void Awake(){
        Time.timeScale = 1;
        loadBuildingFriend.loadBuildingData();
    }  
    void Update(){
        friendNameText.text = "Planta de " + minigameData.friendName;
    }
}
