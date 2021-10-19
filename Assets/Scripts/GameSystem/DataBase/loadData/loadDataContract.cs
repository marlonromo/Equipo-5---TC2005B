using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Unity.IO;
using SimpleJSON;

public class loadDataContract : MonoBehaviour
{
    public Player player;
    public Contract contract;
    public Contract newContract;
    public generateContract generateContract;
    
    
    public void loadContract(){
        StartCoroutine(connectDatabaseContract());
    }

    IEnumerator connectDatabaseContract(){
        string JSONurl = "http://localhost:4000/api/getContract/" + player.IDPlayer;
        UnityWebRequest web = UnityWebRequest.Get(JSONurl);
        web.useHttpContinue = false;

        yield return web.SendWebRequest();

        if(web.isNetworkError || web.isHttpError){
            Debug.Log("Error API: " + web.error);
            
        }
        else{
            JSONNode userData = SimpleJSON.JSON.Parse(web.downloadHandler.text);
            if(userData.Count != 0){
                newContract.IDContract = userData[0]["contractGameID"];
                newContract.title = userData[0]["title"];
                newContract.description = userData[0]["description"];
                newContract.steelRequirement = userData[0]["steelRequirement"];
                newContract.moneyReward = userData[0]["moneyReward"];
                newContract.timeRemaining = userData[0]["timeRemaining"];
                newContract.penalization = userData[0]["penalization"];
                newContract.success = Convert.ToBoolean(Int32.Parse(userData[0]["success"]));
                newContract.isActive =  Convert.ToBoolean(Int32.Parse(userData[0]["isActive"]));
                player.contract = newContract;
                generateContract.IDContractDatabase = userData[0]["contractGameID"];
            }
            else{
                generateContract.IDContractDatabase = 0;
            }
            
            
        }
    }
}