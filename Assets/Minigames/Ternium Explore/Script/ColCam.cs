using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColCam : MonoBehaviour
{
  public ButtonController cont;

  void Start(){
    Time.timeScale = 1;
    cont = FindObjectOfType<ButtonController>();
  }

  void OnTriggerEnter2D(Collider2D col){
    if(cont.contador == 6){
      if(col.CompareTag("Player")){
        ButtonController.colisionCamion = true;
      }
    }
  }
}
