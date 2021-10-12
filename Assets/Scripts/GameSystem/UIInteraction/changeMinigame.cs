using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeMinigame : MonoBehaviour
{
    public Player player;
    public GameObject waitMoment;
    public GameObject contractActive;
    string sceneName;
    public void changeSceneMinigame(string minigameScene){
        if(minigameScene == "WordQuiz"){
            if(player.contract.isActive == true){
                contractActive.SetActive(true);
            }
            else{
                player.savePlayerDataNow();
                Time.timeScale = 1;
                waitMoment.SetActive(true);
                sceneName = minigameScene;
                StartCoroutine(WaitSave());
            }
            
        }
        else{
            player.savePlayerDataNow();
            Time.timeScale = 1;
            waitMoment.SetActive(true);
            sceneName = minigameScene;
            StartCoroutine(WaitSave());
        }
        
    }

    IEnumerator WaitSave(){
        
        yield return new WaitForSeconds(3f);
        waitMoment.SetActive(false);
        SceneManager.LoadScene(sceneName);
        
    }
}
