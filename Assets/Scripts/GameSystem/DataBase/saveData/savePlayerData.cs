using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Unity.IO;
using SimpleJSON;

public class savePlayerData : MonoBehaviour
{
    public Player player;
    string JSONUrl;

    public void saveGameNow(){
        StartCoroutine(Upload());
        StartCoroutine(updateStatistic());
    }

    IEnumerator Upload(){
        PlayerObjectDB playerData = new PlayerObjectDB();

        playerData.playerID = player.IDPlayer;
        playerData.playerExperience = (player.experience / 100);
        playerData.playerName = player.playerName;
        playerData.scoreMoney = player.scoreMoney;
        playerData.scoreIron = player.scoreIron;
        playerData.scoreUnpackageSteel = player.scoreUnpackageSteel;
        playerData.scoreSteel = player.scoreSteel;
        

        string JSONData = JsonUtility.ToJson(playerData);
        JSONUrl = "http://localhost:4000/api/updatePlayerGame/" + player.IDPlayer;
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

    IEnumerator updateStatistic(){
        string JSONUrl = "http://localhost:4000/api/newStatistic/" + player.IDPlayer + "/" + player.UnpackagedSteelToSteelPerSecond;
        UnityWebRequest web = UnityWebRequest.Get(JSONUrl);
        web.useHttpContinue = false;

        yield return web.SendWebRequest();

        if(web.isNetworkError || web.isHttpError){
            Debug.Log("Error API: " + web.error);
        }
        else{
        }
    }
}