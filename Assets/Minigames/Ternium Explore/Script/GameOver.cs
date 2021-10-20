using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
  //Si hace colision con los picos, muestra la pantalla de GameOver
  private void OnTriggerEnter2D(Collider2D collision){
    if(collision.CompareTag("Picos")){
      SceneManager.LoadScene("GameOver");
    }
  }
}
