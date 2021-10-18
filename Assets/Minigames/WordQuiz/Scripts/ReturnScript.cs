using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnScript : MonoBehaviour
{
    public GameObject exitBtn;

    public void ExitButton()
    {
        SceneManager.LoadScene("Playgame");
    }
}