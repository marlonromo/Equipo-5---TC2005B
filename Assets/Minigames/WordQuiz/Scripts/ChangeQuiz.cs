using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeQuiz : MonoBehaviour
{
    public GameObject choiceBtn;
    public GameObject wordBtn;


    public void ChoiceBtn()
    {
        SceneManager.LoadScene("ChoiceQuiz");
    }

    public void WordBtn()
    {
        SceneManager.LoadScene("WordQuiz");
    }
}