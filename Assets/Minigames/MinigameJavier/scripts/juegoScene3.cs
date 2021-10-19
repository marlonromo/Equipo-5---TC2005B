using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class juegoScene3 : MonoBehaviour
{
    public Text uiSize1;
    Vector3 tam;

    



    public void sliderSize(float nuevoSize)
    {
        gameManager.uiSize = nuevoSize /1000;


    }



    void Update()
    {
        tam = transform.localScale;

        tam.x = gameManager.uiSize;

       
        transform.localScale = tam;

            uiSize1.text = gameManager.uiSize * 10000  + " kg/cm^2";
            
            if (uiSize1.text == "4200 kg/cm^2")
            {
                SceneManager.LoadScene("SceneFin");
            }

        

        
    }
}
