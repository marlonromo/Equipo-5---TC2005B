using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModifyPlayer : MonoBehaviour
{
    public Player player;
    public Contract newContract;

    int PlayerIDLocal;
    int PlayerExperienceLocal;
    string PlayerNameLocal;
    int PlayerMoneyLocal;
    float PlayerIronLocal;
    float PlayerUnpackageLocal;
    float PlayerSteelLocal;
    int PlayerDifficultyLocal;

    int ContractIDLocal;
    string ContractTitleLocal;
    string ContractDescriptionLocal;
    int ContractSteelRequirementLocal;
    int ContractMoneyRewardLocal;
    float ContractTimeRemainingLocal;
    float ContractPenalizationLocal;


    //Player
    public void getIDInput(string input){
        if(input.Length != 0){
            PlayerIDLocal = Int32.Parse(input);
        }
    }

    public void getExperienceInput(string input){
        if(input.Length != 0){
            PlayerExperienceLocal = Int32.Parse(input);
        }
    }

    public void getNameInput(string input){
        if(input.Length != 0){
            PlayerNameLocal = input;
        }
    }

    public void getMoneyInput(string input){
        if(input.Length != 0){
            PlayerMoneyLocal = Int32.Parse(input);
        }
    }

    public void getIronInput(string input){
        if(input.Length != 0){
            PlayerIronLocal = float.Parse(input);
        }
    }

    public void getUnpackageInput(string input){
        if(input.Length != 0){
            PlayerUnpackageLocal = float.Parse(input);
        }
    }

    public void getSteelInput(string input){
        if(input.Length != 0){
            PlayerSteelLocal = float.Parse(input);
        }
    }

    public void getDifficultyInput(string input){
        if(input.Length != 0){
            PlayerDifficultyLocal = Int32.Parse(input);
        }
    }

    public void assignValues(){
        player.IDPlayer = PlayerIDLocal;
        player.experience = PlayerExperienceLocal;
        player.playerName = PlayerNameLocal;
        player.scoreMoney = PlayerMoneyLocal;
        player.scoreIron = PlayerIronLocal;
        player.scoreUnpackageSteel = PlayerUnpackageLocal;
        player.scoreSteel = PlayerSteelLocal;
        player.difficulty = PlayerDifficultyLocal;
    }

    //Contract
    public void getIDinputContract(string input){
        if(input.Length != 0){
            ContractIDLocal = Int32.Parse(input);
        }
    }

    public void getTitleInput(string input){
        if(input.Length != 0){
            ContractTitleLocal = input;
        }
    }

    public void getDescriptionInput(string input){
        if(input.Length != 0){
            ContractDescriptionLocal = input;
        }
    }

    public void getSteelRequirementInput(string input){
        if(input.Length != 0){
            ContractSteelRequirementLocal = Int32.Parse(input);
        }
    }

    public void getMoneyRewardInput(string input){
        if(input.Length != 0){
            ContractMoneyRewardLocal = Int32.Parse(input);
        }
    }

    public void getTimeRemainingInput(string input){
        if(input.Length != 0){
            ContractTimeRemainingLocal = float.Parse(input);
        }
    }

    public void getPenalizationInput(string input){
        if(input.Length != 0){
            ContractPenalizationLocal = float.Parse(input);
        }
    }

    public void assignContract(){
        newContract.IDContract = ContractIDLocal;
        newContract.title = ContractTitleLocal;
        newContract.description = ContractDescriptionLocal;
        newContract.steelRequirement = ContractSteelRequirementLocal;
        newContract.moneyReward = ContractMoneyRewardLocal;
        newContract.timeRemaining = ContractTimeRemainingLocal;
        newContract.penalization = ContractPenalizationLocal;
        newContract.success = false;
        newContract.isActive = true;
        player.contract = newContract;
    }
}
