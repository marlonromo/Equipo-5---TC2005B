using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class friendManagement : MonoBehaviour
{
    public Player player;
    public loadDataFriend loadData;
    public List<friendRequest> friendRequests;
    public int actualFriendID;
    public int actualSearchPlayerID;

    public void acceptFriendRequest(int friendID){
        actualFriendID = friendID;
        StartCoroutine(loadData.acceptFriendRequestDataBase());
    }

    public void rejectFriendRequest(int friendID){
        actualFriendID = friendID;
        StartCoroutine(loadData.rejectFriendRequest());
    }

    public void updatePlayerFriend(){
        loadData.loadDataFriendNow();
    }

    public void updatePlayerName(int searchPlayerID){
        actualSearchPlayerID = searchPlayerID;
        StartCoroutine(loadData.searchPlayerName());
    }

    public void sendFriendRequest(){
        StartCoroutine(loadData.sendFriendRequest());
    }
}
