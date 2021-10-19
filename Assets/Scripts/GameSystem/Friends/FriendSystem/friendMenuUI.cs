using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class friendMenuUI : MonoBehaviour
{
    //General variables
    public Player player;
    public Text friendRequestText;
    public friendManagement friendData;
    public tradeMenuUI tradeMenuUI;
    //Friend Request / Friend Menu Variables
    public GameObject FriendMenu;
    public GameObject RequestMenu;
    public GameObject newRequestButton;
    
    public GameObject [] listFriend;
    public GameObject [] listButtonFriend;
    public Button sendFriendRequestButton;
    public Text [] listFriendText;
    public int updateFriend = 0;

    int listRequestNumber = 0;
    int currentObjectFriend = 0;
    
    //Send Send Request Menu
    public GameObject FriendRequestMenu;
    public Text playernameSearchText;
    public string playerNameSearch = "";
    public int searchPlayerID;

    //Detail Menu
    public GameObject detailMenu;
    public Text detailTitleFriendText;
    int detailCurrentFriendID;
    string detailCurrentFriendName;
    public Text detailTextVisit;

    public void getInputID(string input){
        if(input.Length != 0){
            searchPlayerID = Int32.Parse(input);
        }
        
    }
    
    public void displayPlayerNameSearch(){
        bool checkFriend = false;
        for(int x = 0; x< player.friend.Count; x++){
            if(player.friend[x].friendID == searchPlayerID){
                checkFriend = true;
            }
        }
        if(searchPlayerID != player.IDPlayer && !checkFriend && playerNameSearch.Length != 0){
            sendFriendRequestButton.interactable = true;
            playernameSearchText.text = "Usuario: " + playerNameSearch;
        }
        else if(searchPlayerID == player.IDPlayer){
            playernameSearchText.text = "No te puedes añadir a ti mismo como amigo";
        }
        else if(playerNameSearch.Length == 0){
            playernameSearchText.text = "Este usuario no existe";
        }
        else if(checkFriend){
            playernameSearchText.text = "Ya tienes a " + playerNameSearch + " en tu lista de amigos";
        }
        else{
            playernameSearchText.text = playerNameSearch;
        }
    }

    public void searchPlayername(){
        resetPage();
        sendFriendRequestButton.interactable = false;
        friendData.updatePlayerName(searchPlayerID);        
    }

    public void sendFriendRequest(){
        playernameSearchText.text = "Solicitud enviada a " + playerNameSearch;
        friendData.sendFriendRequest();
    }
    


    //Friend Request Menu
    public void displayFriendRequest(){
        if(friendData.friendRequests.Count != 0){
            friendRequestText.text = friendData.friendRequests[listRequestNumber].friendRequestName;
        }
        else{
            updateFriend = 1;
            FriendMenu.SetActive(true);
            RequestMenu.SetActive(false);
        }
        
    }

    public void openFriendRequest(){
        if(friendData.friendRequests.Count !=0){
            RequestMenu.SetActive(true);
            FriendMenu.SetActive(false);
            displayFriendRequest();
        }
    }

    public void rightArrow(){
        if(friendData.friendRequests != null){
            int maxNumber = friendData.friendRequests.Count;
            if(listRequestNumber < maxNumber-1){
                listRequestNumber++;
            }
            displayFriendRequest();
        }
        
    }

    public void leftArrow(){
        if(friendData.friendRequests != null){
            if(listRequestNumber > 0){
                listRequestNumber--;
            }
            displayFriendRequest();
        }
    }
    
    public void acceptFriendRequest(){
        friendData.acceptFriendRequest(friendData.friendRequests[listRequestNumber].friendRequestID);
        friendData.friendRequests.RemoveAt(listRequestNumber);
        friendData.updatePlayerFriend();
        displayFriendRequest();
        resetPage();
    }

    public void rejectFriendRequest(){
        friendData.rejectFriendRequest(friendData.friendRequests[listRequestNumber].friendRequestID);
        friendData.friendRequests.RemoveAt(listRequestNumber);
        friendData.updatePlayerFriend();
        displayFriendRequest();
        resetPage();
    }
    
    //Main Friend Menu

    public void displayUICurrentFriends(){
        listFriend[0].SetActive(false);
        listFriend[1].SetActive(false);
        listFriend[2].SetActive(false);
        listFriend[3].SetActive(false);
        if(player.friend.Count != 0){
            int currentGameObject = 0;
            if(player.friend.Count != 0){
                for(int x = currentObjectFriend; x < player.friend.Count + 1 && currentGameObject < 4; x++){
                    if(x < player.friend.Count){
                        listFriend[currentGameObject].SetActive(true);
                        listFriendText[currentGameObject].text = player.friend[x].friendName.ToString();
                        listButtonFriend[currentGameObject].GetComponent<friendButtonData>().friendID = player.friend[x].friendID;
                    }
                    currentGameObject++;
                }
            }
            
        }
    }

    public void displayCurrentFriends(){
        sendFriendRequestButton.interactable = false;
        listFriend[0].SetActive(false);
        listFriend[1].SetActive(false);
        listFriend[2].SetActive(false);
        listFriend[3].SetActive(false);
        if(player.friend.Count != 0){
            int currentGameObject = 0;
            if(player.friend.Count != 0){
                for(int x = currentObjectFriend; x < player.friend.Count && currentGameObject < 4; x++){
                    if(x < player.friend.Count){
                        listFriendText[currentGameObject].text = player.friend[x].friendName.ToString();
                        listButtonFriend[currentGameObject].GetComponent<friendButtonData>().friendID = player.friend[x].friendID;
                    }
                    currentGameObject++;
                }
            }
            
        }
    }

    public void nextPage(){
        int localCurrentFriend = currentObjectFriend;
        localCurrentFriend = localCurrentFriend + 4;
        if(localCurrentFriend < player.friend.Count + 1){
            currentObjectFriend = localCurrentFriend;
            displayUICurrentFriends();
        }
        

    }

    public void lastPage(){
        int localCurrentFriend = currentObjectFriend;
        localCurrentFriend = localCurrentFriend - 4;
        if(localCurrentFriend >= 0){
            currentObjectFriend = localCurrentFriend;
            displayUICurrentFriends();
        }
    }

    public void resetPage(){
        currentObjectFriend = 0;
    }
    //Friend Detail Menu
    public void openDetailMenu(Button buttonDetail){
        detailMenu.SetActive(true);
        FriendMenu.SetActive(false);
        detailCurrentFriendName = player.friend.Find(x => x.friendID == buttonDetail.GetComponent<friendButtonData>().friendID).friendName;
        detailCurrentFriendID = player.friend.Find(x => x.friendID == buttonDetail.GetComponent<friendButtonData>().friendID).friendID;
        detailTitleFriendText.text = detailCurrentFriendName;
        detailTextVisit.text = "Visitar a " + detailCurrentFriendName;
        tradeMenuUI.currentTradePlayername = detailCurrentFriendName;
        tradeMenuUI.openTrade(detailCurrentFriendID);
    }

    public void visitFriend(){
        Time.timeScale = 1;
        player.savePlayerDataNow();
        StartCoroutine(WaitForSecondsTime());
    }

    public void finishFriendRelation(){
        friendData.rejectFriendRequest(detailCurrentFriendID);
        friendData.updatePlayerFriend();
        updateFriend = 1;
        detailMenu.SetActive(false);
        FriendMenu.SetActive(true);
        player.friend.RemoveAt(player.friend.FindIndex(x => x.friendID == detailCurrentFriendID));
        resetPage();
        displayCurrentFriends();
    }

    IEnumerator WaitForSecondsTime(){
        yield return new WaitForSeconds(5f);
        minigameData.friendID = detailCurrentFriendID;
        minigameData.friendName = detailCurrentFriendName;

        SceneManager.LoadScene("VisitFriend");
    }
}
