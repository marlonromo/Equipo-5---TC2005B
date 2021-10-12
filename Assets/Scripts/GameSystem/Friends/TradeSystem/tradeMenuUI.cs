using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class tradeMenuUI : MonoBehaviour
{
    //GENERAL VARIABLES
    public Player player;
    //->Windows
    public friendMenuUI friendMenuUI;
    public loadDataTrade loadDataTrade;
    public GameObject NoCurrentTrade;
    public GameObject CurrentTrade;
    public GameObject CreateTrade;
    public GameObject CheckTrade;
    public GameObject ChangeOfferTrade;
    public GameObject FinishTrade;
    public GameObject WaitFinishTrade;
    public GameObject WaitOfferPlayer;
    public GameObject deleteFriend;
    public int openTradeWindow = 0;

    //->Text
    public Text[] currentTradeAmountText;
    public Text[] currentTradeCostText;
    public Text titleTradeCurrentTrade;
    public Text titleTradeCheckTrade;
    public Text titleTradeCreateTrade;
    public Text titleTradeWarningTrade;
    public Text titleTradeFinishTrade;
    public Text titleTradeChangeTrade;
    public Text titleWaitOfferPlayer;
    public InputField[] inputAmountSteel;
    public InputField[] inputCostSteel;

    public Text placeholderLastTradeSteelAmount;
    public Text placeholderLastTradeCostAmount;

    //Input
    int newTradeSteelAmount;
    int newTradeSteelCost;
    int currentTradePlayerIndex;
    bool tradeDirection;
    public int currentTradePlayer;
    public string currentTradePlayername;

    //FUNCTIONS
    //UI Input
    public void getNewTradeIronAmount(string input){
        if(input != ""){
            newTradeSteelAmount = Int32.Parse(input);
        }
        
    }

    public void getNewTradeIronCost(string input){
        if(input != ""){
            newTradeSteelCost = Int32.Parse(input);
        }
        
    }

    //Function buttons

    public void makeOffer(){
        TradeObject newTrade = new TradeObject();
        newTrade.playerID = player.IDPlayer;
        newTrade.playerToTradeID = currentTradePlayer;
        newTrade.steelAmount = newTradeSteelAmount;
        newTrade.steelCost = newTradeSteelCost;
        newTrade.acceptTrade1 = true;
        newTrade.acceptTrade2 = false;
        newTrade.isComplete1 = false;
        newTrade.isComplete2 = false;
        StartCoroutine(loadDataTrade.makeNewTrade(newTrade));
    }

    public void makeNewOffer(){
        TradeObjectSent newTrade = new TradeObjectSent();
        newTrade.playerID = player.IDPlayer;
        newTrade.playerToTradeID = currentTradePlayer;
        newTrade.steelAmount = newTradeSteelAmount;
        newTrade.steelCost = newTradeSteelCost;
        newTrade.acceptTrade1 = Convert.ToInt32(!player.trade[currentTradePlayerIndex].acceptTrade1);
        newTrade.acceptTrade2 = Convert.ToInt32(!player.trade[currentTradePlayerIndex].acceptTrade2);
        newTrade.isComplete1 = Convert.ToInt32(false);
        newTrade.isComplete2 = Convert.ToInt32(false);
        StartCoroutine(loadDataTrade.makeNewOffer(newTrade));
    }

    public void acceptOffer(){
        if(tradeDirection){
            player.scoreSteel = player.scoreSteel + player.trade[currentTradePlayerIndex].steelAmount;
            player.scoreMoney = player.scoreMoney - player.trade[currentTradePlayerIndex].steelCost;
        }
        else{
            player.scoreSteel = player.scoreSteel - player.trade[currentTradePlayerIndex].steelAmount;
            player.scoreMoney = player.scoreMoney + player.trade[currentTradePlayerIndex].steelCost;
        }
        
        player.savePlayerDataNow();
        StartCoroutine(loadDataTrade.acceptTrade(currentTradePlayer));
    }


    public void rejectTrade(){
        StartCoroutine(loadDataTrade.rejectTrade(currentTradePlayer));
    }

    //Windows
    public void openTrade(int currentTradePlayerInput){
        currentTradePlayer = currentTradePlayerInput;
        closeAllTradeMenu();
        titleTradeCreateTrade.text = "Crear intercambio con: " + currentTradePlayername;
        bool check = false;
        int checkTradePlayer = 0;
        NoCurrentTrade.SetActive(true);
        if(player.trade.Count != 0){
            check = true;
            NoCurrentTrade.SetActive(false);
        }
        while(check){
            if(player.trade[checkTradePlayer].playerToTradeID == currentTradePlayer){
                currentTradePlayerIndex = checkTradePlayer;
                checkStatusTrade();
                check = false;
            }
            else if(player.trade[checkTradePlayer].playerID == currentTradePlayer){
                currentTradePlayerIndex = checkTradePlayer;
                checkStatusTrade();
                check = false;
            }
            else if(checkTradePlayer == player.trade.Count-1){
                check = false;
                NoCurrentTrade.SetActive(true);
            }
            checkTradePlayer++;
        }
        
    }

    public void openNewTradeWindow(){
        NoCurrentTrade.SetActive(false);
        CreateTrade.SetActive(true);
        openTradeWindow = 1;
    }

    public void closeNewTradeWindow(){
        NoCurrentTrade.SetActive(true);
        CreateTrade.SetActive(false);
    }

    public void openChangeTradeWindow(){
        placeholderLastTradeSteelAmount.text = player.trade[currentTradePlayerIndex].steelAmount.ToString();
        placeholderLastTradeCostAmount.text = player.trade[currentTradePlayerIndex].steelCost.ToString();
        titleTradeChangeTrade.text = "¿Qué quieres cambiar de la oferta de " + currentTradePlayername + "?";
        CheckTrade.SetActive(false);
        ChangeOfferTrade.SetActive(true);

    }

    public void closeChangeTradeWindow(){
        CheckTrade.SetActive(true);
        ChangeOfferTrade.SetActive(false);
    }


    public void closeAllTradeMenu(){
        inputAmountSteel[0].text = "";
        inputCostSteel[0].text = "";
        inputAmountSteel[1].text = "";
        inputCostSteel[1].text = "";
        deleteFriend.SetActive(true);
        NoCurrentTrade.SetActive(false);
        CurrentTrade.SetActive(false);
        CreateTrade.SetActive(false);
        CheckTrade.SetActive(false);
        ChangeOfferTrade.SetActive(false);
        FinishTrade.SetActive(false);
        WaitFinishTrade.SetActive(false);
        WaitOfferPlayer.SetActive(false);
        placeholderLastTradeSteelAmount.text = "";
        placeholderLastTradeCostAmount.text = "";
    }

    void checkStatusTrade(){
        bool acceptTradeLocal1 = player.trade[currentTradePlayerIndex].acceptTrade1;
        bool acceptTradeLocal2 = player.trade[currentTradePlayerIndex].acceptTrade2;
        bool isCompleteLocal1 = player.trade[currentTradePlayerIndex].isComplete1;
        bool isCompleteLocal2 = player.trade[currentTradePlayerIndex].isComplete2;
        bool destination = player.trade[currentTradePlayerIndex].playerToTradeID != player.IDPlayer;
        tradeDirection = false;
        for(int x = 0; x < 5;x++){
                currentTradeAmountText[x].text = player.trade[currentTradePlayerIndex].steelAmount.ToString() + " Tons";
                currentTradeCostText[x].text = "$" + player.trade[currentTradePlayerIndex].steelCost.ToString();
            }
        //Out trade
        if(destination){
            Debug.Log("Tu trade");
            tradeDirection = true;
            titleTradeCurrentTrade.text = "Tu intercambio actual a " + currentTradePlayername;
            if(acceptTradeLocal1 && !acceptTradeLocal2 && !isCompleteLocal1 && !isCompleteLocal2){
                CurrentTrade.SetActive(true);
            }
            else if(!acceptTradeLocal1 && acceptTradeLocal2 && !isCompleteLocal1 && !isCompleteLocal2){
                titleTradeCheckTrade.text = currentTradePlayername + " te hizo una oferta";
                tradeDirection = true;
                CheckTrade.SetActive(true);
            }
            else if(acceptTradeLocal1 && acceptTradeLocal2 && isCompleteLocal1 && !isCompleteLocal2){
                deleteFriend.SetActive(false);
                titleTradeWarningTrade.text = currentTradePlayername + " todavia no ha terminado el intercambio, para hacer un nuevo intercambio " + currentTradePlayername + " tiene que finalizar el trato";
                WaitFinishTrade.SetActive(true);
            }
            else if(acceptTradeLocal1 && acceptTradeLocal2 && !isCompleteLocal1 && isCompleteLocal2){
                titleTradeFinishTrade.text = currentTradePlayername + " acepto tu oferta";
                deleteFriend.SetActive(false);
                FinishTrade.SetActive(true);
            }
            else{
                NoCurrentTrade.SetActive(true);
            }
        }
        //In trade
        else{
            Debug.Log("Su trade");
            tradeDirection = false;
            titleTradeCheckTrade.text = currentTradePlayername + " te hizo una oferta";
            if(acceptTradeLocal1 && !acceptTradeLocal2 && !isCompleteLocal1 && !isCompleteLocal2){
                CheckTrade.SetActive(true);
            }
            else if(acceptTradeLocal1 && acceptTradeLocal2 && isCompleteLocal1 && isCompleteLocal2){
                WaitOfferPlayer.SetActive(true);
            }
            else if(acceptTradeLocal1 && acceptTradeLocal2 && isCompleteLocal1 && !isCompleteLocal2){
                tradeDirection = true;
                titleTradeFinishTrade.text = currentTradePlayername + " acepto tu oferta";
                deleteFriend.SetActive(false);
                FinishTrade.SetActive(true);
            }
            else if(acceptTradeLocal1 && acceptTradeLocal2 && !isCompleteLocal1 && isCompleteLocal2){
                deleteFriend.SetActive(false);
                WaitFinishTrade.SetActive(true);
                titleTradeWarningTrade.text = currentTradePlayername + " todavia no ha terminado el intercambio, para hacer un nuevo intercambio " + currentTradePlayername + " tiene que finalizar el trato";
            }
            else if(!acceptTradeLocal1 && acceptTradeLocal2 && !isCompleteLocal1 && !isCompleteLocal2){
                titleWaitOfferPlayer.text = "La oferta que le hiciste a " + currentTradePlayername + " esta en espera de aprobacion o cambios";
                WaitOfferPlayer.SetActive(true);
            }
            else{
                NoCurrentTrade.SetActive(true);
            }

        }
    }
}
