using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColMina : MonoBehaviour
{
  public ButtonController cont;

  void Start(){
    Time.timeScale = 1;
    cont = FindObjectOfType<ButtonController>();
  }
    void OnTriggerEnter2D(Collider2D col){
      if(cont.contador == 1){
        if(col.CompareTag("Player")){
          ButtonController.colisionMina = true;
        }
      }
    }
}
