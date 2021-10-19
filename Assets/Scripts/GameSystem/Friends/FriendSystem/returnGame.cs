using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class returnGame : MonoBehaviour
{
    public void returnScene(){
        SceneManager.LoadScene("Playgame");
    }
}
