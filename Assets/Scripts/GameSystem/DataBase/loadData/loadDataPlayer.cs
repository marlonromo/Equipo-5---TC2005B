using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Unity.IO;
using SimpleJSON;

public class loadDataPlayer : MonoBehaviour
{
    public Player player;
    
    public loadDataContract loadDataContract;
    
    IEnumerator connectDataBasePlayer(){
        string JSONurl = "http://localhost:4000/api/getPlayerGame/" + player.IDPlayer;
        UnityWebRequest web = UnityWebRequest.Get(JSONurl);
        web.useHttpContinue = false;

        yield return web.SendWebRequest();

        if(web.isNetworkError || web.isHttpError){
            Debug.Log("Error API: " + web.error);
        }
        else{
            JSONNode userData = SimpleJSON.JSON.Parse(web.downloadHandler.text);
            player.IDPlayer = userData[0]["playerID"];
            player.experience = userData[0]["playerExperience"];
            player.playerName = userData[0]["playerName"];
            player.scoreMoney = userData[0]["scoreMoney"];
            player.scoreIron = userData[0]["scoreIron"];
            player.scoreUnpackageSteel = userData[0]["scoreUnpackageSteel"];
            player.scoreSteel = userData[0]["scoreSteel"];
            player.difficulty = userData[0]["difficulty"];
        }
    }

    public void loadScores(){
        StartCoroutine(connectDataBasePlayer());
    }
}
