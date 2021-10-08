using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColBuilding : MonoBehaviour
{
  public ButtonController cont;
    // Start is called before the first frame update
    void Start()
    {
      Time.timeScale = 1;
      cont = FindObjectOfType<ButtonController>();
    }

    void OnTriggerEnter2D(Collider2D col){
      if(cont.contador == 2){
        if(col.CompareTag("Player")){
          ButtonController.colisionEd = true;
        }
    }
}
}
