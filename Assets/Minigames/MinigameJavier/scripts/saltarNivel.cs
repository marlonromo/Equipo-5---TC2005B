using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class saltarNivel : MonoBehaviour
{

    static double punishmentValor = .10;
    public void siguienteEscena2()
    {
        gameManager.punishment -= punishmentValor;
        SceneManager.LoadScene("Scene2");
    }

    public void siguienteEscena3()
    {
        gameManager.punishment -= punishmentValor;
        SceneManager.LoadScene("Scene3");
    }

    public void siguienteEscena4()
    {
        gameManager.punishment -= punishmentValor;
        SceneManager.LoadScene("Scene4");
    }

    public void siguienteEscena5()
    {
        gameManager.punishment -= punishmentValor;
        SceneManager.LoadScene("Scene5");
    }

    public void siguienteEscena6()
    {
        gameManager.punishment -= punishmentValor;
        SceneManager.LoadScene("Scene6");
    }

    public void siguienteEscena7()
    {
        gameManager.punishment -= punishmentValor;
        SceneManager.LoadScene("Scene7");
    }

    public void siguienteEscenaFin()
    {
        gameManager.punishment -= punishmentValor;
        SceneManager.LoadScene("SceneFin");
    }
}
