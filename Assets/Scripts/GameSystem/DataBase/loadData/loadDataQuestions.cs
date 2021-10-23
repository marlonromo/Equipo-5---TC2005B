using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Unity.IO;
using UnityEngine.UI;
using SimpleJSON;


public class loadDataQuestions : MonoBehaviour
{
    public Player player;
    public GameObject Question;
    public GameObject RightAnswer;
    public GameObject WrongAnwer1;
    public GameObject WrongAnwer2;
    public GameObject WrongAnwer3;
    public GameObject NoQuiz;

    string WrongAnswers;
    string[] WrongAnswersArray;



    public void LoadQuestion()
    {
        Question = GameObject.FindWithTag("ChoiceQuizQ");
        RightAnswer = GameObject.FindWithTag("ChoiceQuizAns1");
        WrongAnwer1 = GameObject.FindWithTag("ChoiceQuizAns2");
        WrongAnwer2 = GameObject.FindWithTag("ChoiceQuizAns3");
        WrongAnwer3 = GameObject.FindWithTag("ChoiceQuizAns4");
        NoQuiz = GameObject.FindWithTag("NoQuiz");
        StartCoroutine(ConnectDataBaseQuiz());
    }

    IEnumerator ConnectDataBaseQuiz()
    {
        string JSONurl = "http://localhost:4000/api/getChoiceQuiz/" + player.IDPlayer;
        UnityWebRequest web = UnityWebRequest.Get(JSONurl);
        web.useHttpContinue = false;

        yield return web.SendWebRequest();

        if (web.isNetworkError || web.isHttpError)
        {
            Debug.Log("Error API: " + web.error);
        }
        else
        {
            JSONNode quizData = SimpleJSON.JSON.Parse(web.downloadHandler.text);
            if (quizData != 0)
            {
                Question.GetComponent<Text>().text = quizData[0]["Question"];
                RightAnswer.GetComponent<Text>().text = quizData[0]["CorrectAnswer"];
                WrongAnswers = quizData[0]["WrongAnswers"];
                WrongAnswersArray = WrongAnswers.Split(',');
                WrongAnwer1.GetComponent<Text>().text = WrongAnswersArray[0];
                WrongAnwer2.GetComponent<Text>().text = WrongAnswersArray[1];
                WrongAnwer3.GetComponent<Text>().text = WrongAnswersArray[2];
            }
            else
            {
                NoQuiz.SetActive(true);
            }

        }
    }


}
