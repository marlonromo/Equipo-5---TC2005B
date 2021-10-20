using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject playerUI;
    public Slider loadingBar;
    public Player player;
    public giveMinigameReward giveMinigameReward;
    float progress;
    float time = 0;

    void Awake(){
        loadingScreen.SetActive(true);
        playerUI.SetActive(false);
        enabled = true;
    }

    void Update(){
        if(time > 3){
            giveMinigameReward.checkRewardAfterLoad();
            loadingScreen.SetActive(false);
            playerUI.SetActive(true);
            enabled = false;
        }
            progress = time / 3;
            loadingBar.value = progress;
        
        time += Time.unscaledDeltaTime;
    }

    
}
