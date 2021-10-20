using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giveMinigameReward : MonoBehaviour
{
    public generateContract generateContract;
    public Player player;
    // void Awake(){
    //     player.UnpackagedSteelToSteelPerSecond = minigameData.rateOfSteel;
    //     if(minigameData.win && minigameData.reward == "contract"){
    //         checkContract();
    //     }
    // }

    void checkContract(){
        if(minigameData.reward == "contract"){
            generateContract.SeeContract();
            
        }
        minigameData.win = false;
    }

    public void checkRewardAfterLoad(){
        if(minigameData.win == true){
            if(minigameData.reward == "contract"){
            generateContract.SeeContract();
            }
            else if(minigameData.reward == "unpackageSteel"){
                player.scoreUnpackageSteel = player.scoreUnpackageSteel + minigameData.amountReward;
            }
            else if(minigameData.reward == "money"){
                player.scoreMoney = player.scoreMoney + minigameData.amountReward;
            }
            else if(minigameData.reward == "steel"){
                player.scoreSteel = player.scoreSteel + minigameData.amountReward;
            }
        }
        minigameData.win = false;
    }
}
