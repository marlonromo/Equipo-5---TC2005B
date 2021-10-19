using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class contractMenu : MonoBehaviour
{
    public Player player;
    public GameObject contractMenuUI;
    public GameObject Camera;
    public GameObject blockInteraction;

    public Text titleText;
    public Text descriptionText;
    public Text steelRequirementText;
    public Text moneyRewardText;
    public Text timeRemainingText;
    public Text statusText;

    public void OpenContractMenu()
    {  
        
        if(player.contract.isActive == true && player.contract.moneyReward > 0){
            Camera.GetComponent<CameraMovement>().enableMove = false;
            blockInteraction.SetActive(true);
            Time.timeScale = 0;
            contractMenuUI.SetActive(true);
            titleText.text = player.contract.title;
            descriptionText.text = player.contract.description;
            steelRequirementText.text = "Requisito acero: " + player.contract.steelRequirement.ToString() + " toneladas de acero";
            moneyRewardText.text = "Ganancia: $" + player.contract.moneyReward.ToString();
            timeRemainingText.text = "Tiempo restante: " + timeRemainingMinutes()  + " minutos";
            statusText.text = "Activo";
        }
        else if(player.contract.isActive == true && player.contract.timeRemaining <= 0){
            Camera.GetComponent<CameraMovement>().enableMove = false;
            blockInteraction.SetActive(true);
            Time.timeScale = 0;
            contractMenuUI.SetActive(true);
            titleText.text = player.contract.title;
            descriptionText.text = player.contract.description;
            steelRequirementText.text = " ";
            moneyRewardText.text = "Penalización: -$" + (-player.contract.moneyReward).ToString();
            timeRemainingText.text = " ";
            statusText.text = "No cumplido";
        }
        
    }

    public void CloseContractMenu(){
        contractMenuUI.SetActive(false);
        Camera.GetComponent<CameraMovement>().enableMove = true;
        blockInteraction.SetActive(false);
        Time.timeScale = 1;
    }

    string timeRemainingMinutes(){
        float timeRemaining = player.contract.timeRemaining;
        timeRemaining = timeRemaining / 60;
        int timeRemainingInt = (int)timeRemaining;
        timeRemainingInt++;
        return timeRemainingInt.ToString();
    }
}
