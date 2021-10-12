using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Unity.IO;

using SimpleJSON;

public class updateFriendStatus : MonoBehaviour
{
    public Player player;
    public loadDataFriend loadDataFriend;
    public loadDataTrade loadDataTrade;
    JSONNode userData;
    float time = 4;
    string JSONUrl;

    void Start(){
        JSONUrl = JSONUrl + player.IDPlayer.ToString();
    }

    void Update(){
        if(time > 2){
            checkFriendData();
            StartCoroutine(loadDataFriend.connectDataBasePlayerGetRequest());
            loadDataFriend.loadDataFriendNow();
            loadDataTrade.loadDataTradeNow();
            time = 0;
        }
        time += Time.deltaTime;
    }

    public void checkFriendData(){
        StartCoroutine(connectToDatabase());
    }

    IEnumerator connectToDatabase()
    {
        JSONUrl = "http://localhost:4000/api/checkFriendUpdate/" + player.IDPlayer;
        UnityWebRequest web = UnityWebRequest.Get(JSONUrl);
        web.useHttpContinue = false;

        yield return web.SendWebRequest();

        if(web.isNetworkError || web.isHttpError){
            Debug.Log("Error Friend API: " + web.error);
        }
        else{
            userData = SimpleJSON.JSONNode.Parse(web.downloadHandler.text);
        }
    }
}
