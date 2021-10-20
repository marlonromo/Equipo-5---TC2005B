using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class juegoScene6 : MonoBehaviour
{
    public Text uiTemp;


    public void incrementarTemp()
    {
        if (gameManager.uiTemp < 5000)
        {
            gameManager.uiTemp += 1;
        }

    }

    public void decrementarTemp()
    {
        if (gameManager.uiTemp > 0)
        {
            gameManager.uiTemp -= 1;
        }
    }

    public void sliderTemp(float nuevaTemp)
    {
        gameManager.uiTemp = nuevaTemp;

    }



    void Update()
    {

        uiTemp.text = gameManager.uiTemp + " °C";

        if (gameManager.uiTemp == 1200)
        {
            SceneManager.LoadScene("Scene7");
        }
    }
}
