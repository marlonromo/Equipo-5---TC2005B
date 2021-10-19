using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contractGoal : MonoBehaviour
{
    public Player player;
    public GameObject contractMenu;
    public GameObject Camera;
    public GameObject blockInteraction;
    public void completeContract(){
        if(player.scoreSteel >= player.contract.steelRequirement && player.contract.isActive == true && player.contract.timeRemaining > 0){
            player.scoreMoney += player.contract.moneyReward;
            player.scoreSteel -= player.contract.steelRequirement;
            player.contract.success = true;
            player.contract.isActive = false;
            contractMenu.SetActive(false);
            blockInteraction.SetActive(false);
            Camera.GetComponent<CameraMovement>().enableMove = true;
            Time.timeScale = 1;
            player.savePlayerDataNow();
        }
        else if(player.contract.success == false && player.contract.timeRemaining <= 0 && player.contract.isActive == true){
            player.scoreMoney += player.contract.moneyReward;

            player.contract.success = false;
            player.contract.isActive = false;
            contractMenu.SetActive(false);
            blockInteraction.SetActive(false);
            Camera.GetComponent<CameraMovement>().enableMove = true;
            Time.timeScale = 1;
            player.savePlayerDataNow();
        }
    }
}
