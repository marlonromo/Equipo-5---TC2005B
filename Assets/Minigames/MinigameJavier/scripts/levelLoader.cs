using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLoader : MonoBehaviour
{
    public Animator transicion;

    public float tiempoTransicion = 1;

    // Update is called once per frame
    void Update()
    {
        if (gameManager.contador == 10)
        {
            //LoadNextLevel();
            
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transicion.SetTrigger("start");
        yield return new WaitForSeconds(tiempoTransicion);
        SceneManager.LoadScene("Scene2");
        gameManager.contador = 0;
    
    }
}
