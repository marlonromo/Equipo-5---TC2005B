using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Unity.IO;
using SimpleJSON;

public class loadDataFriend : MonoBehaviour
{
    public Player player;
    public friendManagement friendManagement;
    public friendMenuUI friendMenuUI;
    public GameObject friendMenu;

    JSONNode userData;
    int Status1;
    int Status2;
    int checkUpdate;
    string JSONUrl;

    public void loadDataFriendNow(){
        StartCoroutine(connectDataBasePlayer());
    }



    IEnumerator connectDataBasePlayer(){
        JSONUrl = "http://localhost:4000/api/getFriend/" + player.IDPlayer;
        UnityWebRequest web = UnityWebRequest.Get(JSONUrl);
        web.useHttpContinue = false;
        
        yield return web.SendWebRequest();

        if(web.isNetworkError || web.isHttpError){
            Debug.Log("Error API Load Friend: " + web.error);
        }
        else{
            player.friend.Clear();
            userData = SimpleJSON.JSONNode.Parse(web.downloadHandler.text);
            for(int x = 0; x < userData.Count; x++){
                FriendObject newFriend = new FriendObject();
                newFriend.friendID = userData[x]["playerID"];
                newFriend.friendName = userData[x]["playerName"];
                player.friend.Add(newFriend);
                newFriend = null;
            }
        }
        friendMenuUI.displayCurrentFriends();
        if(friendMenu.activeSelf && friendMenuUI.updateFriend == 1){
            friendMenuUI.displayUICurrentFriends();
            friendMenuUI.updateFriend = 0;
        }
    }

    IEnumerator updateDatabasePlayer(){
        JSONUrl = "http://localhost:4000/api/getFriend/" + player.IDPlayer;
        UnityWebRequest web = UnityWebRequest.Get(JSONUrl);
        web.useHttpContinue = false;
        
        yield return web.SendWebRequest();

        if(web.isNetworkError || web.isHttpError){
            Debug.Log("Error API Load Friend: " + web.error);
        }
        else{
            player.friend.Clear();
            userData = SimpleJSON.JSONNode.Parse(web.downloadHandler.text);
            for(int x = 0; x < userData.Count; x++){
                FriendObject newFriend = new FriendObject();
                newFriend.friendID = userData[x]["playerID"];
                newFriend.friendName = userData[x]["playerName"];
                player.friend.Add(newFriend);
                newFriend = null;
            }
            friendMenuUI.openFriendRequest();
            if(friendMenu.activeSelf && friendMenuUI.updateFriend == 1){
                friendMenuUI.displayUICurrentFriends();
                friendMenuUI.updateFriend = 0;
            }
        }
    }

    public IEnumerator connectDataBasePlayerGetRequest(){
        JSONUrl = "http://localhost:4000/api/getRequest/" + player.IDPlayer;
        UnityWebRequest web = UnityWebRequest.Get(JSONUrl);
        web.useHttpContinue = false;
        
        yield return web.SendWebRequest();

        if(web.isNetworkError || web.isHttpError){
            Debug.Log("Error API Load Friend: " + web.error);
        }
        else{
            friendManagement.friendRequests.Clear();
            userData = SimpleJSON.JSONNode.Parse(web.downloadHandler.text);
            for(int x = 0; x < userData.Count; x++){
                friendRequest newRequest = new friendRequest();
                newRequest.friendRequestID = userData[x]["playerID"];
                newRequest.friendRequestName = userData[x]["playerName"];
                friendManagement.friendRequests.Add(newRequest);
                newRequest = null;
            }
        }
    }

    public IEnumerator acceptFriendRequestDataBase(){
        JSONUrl = "http://localhost:4000/api/acceptFriendRequest/" + player.IDPlayer + "/" + friendManagement.actualFriendID;
        friendManagement.actualFriendID = 0;
        UnityWebRequest web = UnityWebRequest.Get(JSONUrl);
        web.useHttpContinue = false;
        
        yield return web.SendWebRequest();

        if(web.isNetworkError || web.isHttpError){
            Debug.Log("Error API Load Friend: " + web.error);
        }
        else{
            StartCoroutine(updateDatabasePlayer());
        }
    }

    public IEnumerator rejectFriendRequest(){
        JSONUrl = "http://localhost:4000/api/finishFriendRelation/" + player.IDPlayer + "/" + friendManagement.actualFriendID;
        friendManagement.actualFriendID = 0;
        UnityWebRequest web = UnityWebRequest.Get(JSONUrl);
        web.useHttpContinue = false;
        
        yield return web.SendWebRequest();

        if(web.isNetworkError || web.isHttpError){
            Debug.Log("Error API Load Friend: " + web.error);
        }
        else{
            StartCoroutine(updateDatabasePlayer());
        }
    }

    public IEnumerator searchPlayerName(){
        JSONUrl = "http://localhost:4000/api/getPlayername/" + friendManagement.actualSearchPlayerID;
        UnityWebRequest web = UnityWebRequest.Get(JSONUrl);
        web.useHttpContinue = false;
        
        yield return web.SendWebRequest();
        
        if(web.isNetworkError || web.isHttpError){
            Debug.Log("Error API Load Friend: " + web.error);
        }
        else{
            
            userData = SimpleJSON.JSONNode.Parse(web.downloadHandler.text);
            if(userData[0]["playerName"] != null){
                friendMenuUI.playerNameSearch = userData[0]["playerName"];
            }
            else{
                friendMenuUI.playerNameSearch = "";
            }
            friendMenuUI.displayPlayerNameSearch();
        }
    }

    public IEnumerator sendFriendRequest(){
        JSONUrl = "http://localhost:4000/api/sendFriendRequest/" + player.IDPlayer + "/" +friendManagement.actualSearchPlayerID;
        UnityWebRequest web = UnityWebRequest.Get(JSONUrl);
        web.useHttpContinue = false;

        yield return web.SendWebRequest();

        if(web.isNetworkError || web.isHttpError){
            Debug.Log("Error API Load Friend: " + web.error);
        }
        else{
            friendMenuUI.playerNameSearch = "Solicitud enviada a " + userData[0]["playerName"];
            friendMenuUI.displayPlayerNameSearch();
        }
    }
}
