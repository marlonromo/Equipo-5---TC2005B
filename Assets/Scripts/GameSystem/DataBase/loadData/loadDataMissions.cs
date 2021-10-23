using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Unity.IO;
using UnityEngine.UI;
using SimpleJSON;

public class loadDataMissions : MonoBehaviour
{
    public Player player;
    public Text missionDescription;
    public Image progressBar;
    public Text textGoal;
    public Text missionNumber;
    string progress;
    

    public void loadDataMission(){
        StartCoroutine(getInfoDatabaseMissions());
    }
    IEnumerator getInfoDatabaseMissions(){
        string JSONUrl = "http://localhost:4000/api/getMission/" + player.IDPlayer;
        UnityWebRequest web = UnityWebRequest.Get(JSONUrl);
        web.useHttpContinue = false;

        yield return web.SendWebRequest();
        if(web.isNetworkError || web.isHttpError){
            Debug.Log("Error API: " + web.error);
        }
        else{
            
            JSONNode userData = SimpleJSON.JSON.Parse(web.downloadHandler.text);
            if(userData.Count != 0){
                missionDescription.text = userData[0]["DescriptionMission"];
                progress = userData[0]["ActualProgress"];
                progressBar.fillAmount = userData[0]["ActualProgress"] / userData[0]["GoalNumber"];
                textGoal.text = progress + " / " + userData[0]["GoalNumber"];
                missionNumber.text = userData[0]["MissionID"]; ;
            }
            else{
                
            }
            
        }
    }

}   