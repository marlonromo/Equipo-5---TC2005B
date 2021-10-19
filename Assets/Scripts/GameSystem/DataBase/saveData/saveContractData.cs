using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Unity.IO;

public class saveContractData : MonoBehaviour
{
    public Player player;
    string JSONUrl;

    public void saveContractDataNow(){
        if(player.contract.IDContract != 0){
            Debug.Log("Hola");
            StartCoroutine(uploadContractData());
        }
    }

    IEnumerator uploadContractData(){
        ContractObjectDB contractData = new ContractObjectDB();
        contractData.IDPlayerContract = player.IDPlayer;
        contractData.IDContract = player.contract.IDContract;
        contractData.title = player.contract.title;
        contractData.description = player.contract.description;
        contractData.steelRequirement = player.contract.steelRequirement;
        contractData.moneyReward = player.contract.moneyReward;
        contractData.timeRemaining = player.contract.timeRemaining;
        contractData.penalization = player.contract.penalization;
        contractData.success = player.contract.success;
        contractData.isActive = player.contract.isActive;

        string JSONData = JsonUtility.ToJson(contractData);
        JSONUrl = "http://localhost:4000/api/updateContract/" + player.IDPlayer + "/" + player.contract.IDContract;
        using(UnityWebRequest www = UnityWebRequest.Put(JSONUrl, JSONData)){
            www.method = UnityWebRequest.kHttpVerbPUT;
            www.SetRequestHeader("Content-type", "application/json");
            www.SetRequestHeader("Accept", "application/json");
            yield return www.SendWebRequest();
            if(www.isNetworkError || www.isHttpError){
                Debug.Log(www.error);
            }
            else{
            }
        }
        
    }

    IEnumerator updateContractData(){
        JSONUrl = "http://localhost:4000/api/updateContract/" + player.IDPlayer + "/" + player.contract.IDContract;
        contractUpdateObjectDB contractDataUpdate = new contractUpdateObjectDB();
        if(player.contract != null){
            contractDataUpdate.success = Convert.ToInt32(player.contract.success);
            contractDataUpdate.isActive = Convert.ToInt32(player.contract.isActive);
            string JSONData = JsonUtility.ToJson(contractDataUpdate);
            using (UnityWebRequest www = UnityWebRequest.Put(JSONUrl, JSONData)){
                www.method = UnityWebRequest.kHttpVerbPUT;
                www.SetRequestHeader("Content-type", "application/json");
                www.SetRequestHeader("Accept", "application/json");
                yield return www.SendWebRequest();
                
                if(www.isNetworkError || www.isHttpError){
                    Debug.Log(www.error);
                }
                else{
                }
            }
        }
    }
}
