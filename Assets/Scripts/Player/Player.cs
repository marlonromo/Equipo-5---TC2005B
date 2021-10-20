using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //Load data
    public loadDataPlayer loadDataPlayer;
    public loadDataContract loadDataContract;
    public loadDataBuildings loadDataBuildings;
    public loadDataFriend loadDataFriend;
    public loadDataTrade loadDataTrade;
    public loadDataSettings loadDataSettings;

    public savePlayerData savePlayerData;
    public saveBuildingData saveBuildingData;
    public saveContractData saveContractData;
    public saveOptionsData saveOptionsData;

    //Objects
    public Contract contract;
    public List<FriendObject> friend; 
    public List<TradeObject> trade;

    //Properties
    public int IDPlayer;
    public int experience;
    public string playerName;
    public int scoreMoney;
    public float scoreIron;
    public float scoreUnpackageSteel;
    public float scoreSteel;
    public int difficulty;

    //Variables in game
    public float ironToUnpackageSteelPerSecond = 120;
    public float UnpackagedSteelToSteelPerSecond = 100;
    public float rateOfIronGenerated;

    void Awake(){
        getURLID();
        loadDataPlayer.loadScores();
        loadDataContract.loadContract();
        loadDataBuildings.loadBuildingData();
        loadDataFriend.loadDataFriendNow();
        loadDataTrade.loadDataTradeNow();
        loadDataSettings.loadDataSettingsNow();
    }

    public void savePlayerDataNow(){
        savePlayerData.saveGameNow();
        saveBuildingData.saveBuildingsNow();
        saveContractData.saveContractDataNow();
        saveOptionsData.saveOptionsNow();
    }

    public void assignNewContract(Contract newContract){
        contract = newContract;
    }

    void getURLID(){
        int URL = Application.absoluteURL.IndexOf("?");
        if(URL != -1){
            string URLInput = Application.absoluteURL.Split("?"[0])[1];
            int e = URLInput.IndexOf("=");
            if(e != -1){
                IDPlayer = Int32.Parse(URLInput.Split("="[0])[1]);
            }
        }
        else{
            IDPlayer = 2;
        }
    }

    public void finishGame(){
        SceneManager.LoadScene("MainMenu");
    }
}
