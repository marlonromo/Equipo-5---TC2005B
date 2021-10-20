using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Unity.IO;
using SimpleJSON;

public class loadDataTrade : MonoBehaviour
{
    public Player player;
    public tradeMenuUI tradeMenuUI;

    string JSONUrl;
    JSONNode userData;


    public void loadDataTradeNow(){
        StartCoroutine(connectDatabasePlayer());
    }

    IEnumerator connectDatabasePlayer(){
        JSONUrl = "http://localhost:4000/api/getTrade/" + player.IDPlayer;
        UnityWebRequest web = UnityWebRequest.Get(JSONUrl);
        web.useHttpContinue = false;

        yield return web.SendWebRequest();

        if(web.isNetworkError || web.isHttpError){
            Debug.Log("Error API Load Trade");
        }
        else{
            player.trade.Clear();
            userData = SimpleJSON.JSONNode.Parse(web.downloadHandler.text);
            if(userData != null){
                for(int x = 0; x < userData.Count; x++){
                    TradeObject newTrade = new TradeObject();
                    newTrade.playerID = userData[x]["playerID"];
                    newTrade.playerToTradeID = userData[x]["playerToTradeID"];
                    newTrade.steelAmount = userData[x]["steelAmount"];
                    newTrade.steelCost = userData[x]["steelCost"];
                    newTrade.acceptTrade1 = Convert.ToBoolean(Int32.Parse(userData[x]["acceptTradeP1"]));
                    newTrade.acceptTrade2 = Convert.ToBoolean(Int32.Parse(userData[x]["acceptTradeP2"]));
                    newTrade.isComplete1 = Convert.ToBoolean(Int32.Parse(userData[x]["isComplete1"]));
                    newTrade.isComplete2 = Convert.ToBoolean(Int32.Parse(userData[x]["isComplete2"]));
                    player.trade.Add(newTrade);
                    newTrade = null;
                }
            }
            tradeMenuUI.openTrade(tradeMenuUI.currentTradePlayer);
        }
    }

    public IEnumerator makeNewTrade(TradeObject newTrade){
        JSONUrl = "http://localhost:4000/api/createTrade/" + newTrade.playerID + "/" + newTrade.playerToTradeID;
        string JSONData = JsonUtility.ToJson(newTrade);
        using(UnityWebRequest web = UnityWebRequest.Put(JSONUrl, JSONData)){
            web.method = UnityWebRequest.kHttpVerbPUT;
            web.SetRequestHeader("Content-type", "application/json");
            web.SetRequestHeader("Accept", "application/json");

            yield return web.SendWebRequest();

            if(web.isNetworkError || web.isHttpError){
                Debug.Log(web.error);
            }
            else{
                StartCoroutine(connectDatabasePlayer());
            }
        }
    }

    public IEnumerator makeNewOffer(TradeObjectSent newTrade){
        JSONUrl = "http://localhost:4000/api/modifyTrade/" + newTrade.playerID + "/" + newTrade.playerToTradeID;
        string JSONData = JsonUtility.ToJson(newTrade);
        using(UnityWebRequest web = UnityWebRequest.Put(JSONUrl, JSONData)){
            web.method = UnityWebRequest.kHttpVerbPUT;
            web.SetRequestHeader("Content-type", "application/json");
            web.SetRequestHeader("Accept", "application/json");

            yield return web.SendWebRequest();

            if(web.isNetworkError || web.isHttpError){
                Debug.Log(web.error);
            }
            else{
                StartCoroutine(connectDatabasePlayer());
            }
        }
    }

    public IEnumerator acceptTrade(int currentTradePlayer){
        JSONUrl = "http://localhost:4000/api/acceptTrade/" + player.IDPlayer + "/" + currentTradePlayer;
        UnityWebRequest web = UnityWebRequest.Get(JSONUrl);
        web.useHttpContinue = false;

        yield return web.SendWebRequest();

        if(web.isNetworkError || web.isHttpError){
            Debug.Log("Error API Accept Trade");
        }
        else{
            StartCoroutine(connectDatabasePlayer());
        }
    }

        public IEnumerator rejectTrade(int currentTradePlayer){
        JSONUrl = "http://localhost:4000/api/deleteTrade/" + player.IDPlayer + "/" + currentTradePlayer;
        UnityWebRequest web = UnityWebRequest.Get(JSONUrl);
        web.useHttpContinue = false;

        yield return web.SendWebRequest();

        if(web.isNetworkError || web.isHttpError){
            Debug.Log("Error API Accept Trade");
        }
        else{
            StartCoroutine(connectDatabasePlayer());
        }
    }
}
