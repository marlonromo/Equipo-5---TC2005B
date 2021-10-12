using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class juego : MonoBehaviour
{
    public Text ui;
    public Text ui1;
    public Text ui2;


    public void incrementar()
    {
        if(gameManager.contador < 100)
        {
            gameManager.contador += 1;
        }
        
    }

    public void decrementar()
    {
        if (gameManager.contador > 0)
        {
            gameManager.contador -= 1;
        }
    }


    public void incrementar1()
    {
        if (gameManager.contador1 < 100)
        {
            gameManager.contador1 += 1;
        }

    }

    public void decrementar1()
    {
        if (gameManager.contador1 > 0)
        {
            gameManager.contador1 -= 1;
        }
    }


    public void incrementar2()
    {
        if (gameManager.contador2 < 100)
        {
            gameManager.contador2 += 1;
        }

    }

    public void decrementar2()
    {
        if (gameManager.contador2 > 0)
        {
            gameManager.contador2 -= 1;
        }
    }

    

    void Update()
    {
        
            ui.text = gameManager.contador + " %";
            ui1.text = gameManager.contador1 + " %";
            ui2.text = gameManager.contador2 + " %";

            if ((gameManager.contador == 7) && (gameManager.contador1 == 3) && (gameManager.contador2 == 90))
            {
                SceneManager.LoadScene("Scene2");
            }
    }
}
