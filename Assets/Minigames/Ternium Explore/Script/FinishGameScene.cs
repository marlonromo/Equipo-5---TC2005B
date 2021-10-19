using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGameScene : MonoBehaviour
{
    public void returnGame(){
        minigameData.win = true;
        minigameData.reward = "steel";
        minigameData.amountReward = 300;
        SceneManager.LoadScene("Playgame");
    }
}
