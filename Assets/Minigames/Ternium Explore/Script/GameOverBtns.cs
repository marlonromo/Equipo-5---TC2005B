using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverBtns : MonoBehaviour
{
  public GameObject restartBtn;
  public GameObject exitBtn;

  public void RestartButton(){
    SceneManager.LoadScene("TerniumExplore");
  }
  public void ExitButton(){
    SceneManager.LoadScene("Playgame");
  }
}
