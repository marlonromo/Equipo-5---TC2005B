using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnQuizScript : MonoBehaviour
{
    public GameObject returnBtn;

    public void ExitButton()
    {
        SceneManager.LoadScene("ChooseQuiz");
    }
}