﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class juegoScene4 : MonoBehaviour
{
    public Text uiSize44;


    public void boton1()
    {
        gameManager.uiSize4 = 1;
    }

    public void boton2()
    {
        gameManager.uiSize4 = 2;
    }

    public void boton3()
    {
        gameManager.uiSize4 = 3;
    }

    public void boton4()
    {
        gameManager.uiSize4 = 4;
    }

    public void boton5()
    {
        gameManager.uiSize4 = 5;
    }

    public void boton6()
    {
        gameManager.uiSize4 = 6;
    }

    public void boton7()
    {
        gameManager.uiSize4 = 7;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.uiSize4 == 1)
        {
            uiSize44.text = "3 / 8 ″";
        }

        if (gameManager.uiSize4 == 2)
        {
            uiSize44.text = "1 / 2 ″";
        }

        if (gameManager.uiSize4 == 3)
        {
            uiSize44.text = "5 / 8 ″";

            SceneManager.LoadScene("Scene4");




        }

        if (gameManager.uiSize4 == 4)
        {
            uiSize44.text = "3 / 4 ″";
        }

        if (gameManager.uiSize4 == 5)
        {
            uiSize44.text = "1 ″";
        }

        if (gameManager.uiSize4 == 6)
        {
            uiSize44.text = "1 1/4 ″";
        }

        if (gameManager.uiSize4 == 7)
        {
            uiSize44.text = "1 1/2 ″";
        }

    }
}
