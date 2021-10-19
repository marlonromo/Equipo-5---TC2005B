using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class finishGame : MonoBehaviour
{
    public void returnAndReward(){
        minigameData.win = true;
        minigameData.reward = "money";
        minigameData.amountReward = 3000;
        SceneManager.LoadScene("Playgame");
    }
}
