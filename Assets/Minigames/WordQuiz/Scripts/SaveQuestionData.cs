using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Unity.IO;
using SimpleJSON;


public class SaveQuestionData : MonoBehaviour
{
    public Player player;
    public playMusic musicSettings;
    public CameraMovement cameraMovement;
    string JSONUrl;

    public void SaveQuizNow()
    {
        StartCoroutine(Upload());
    }

    public int GetQuizID()
    {
        string JSONurl = "http://localhost:4000/api/getChoiceQuiz/" + player.IDPlayer;
        UnityWebRequest web = UnityWebRequest.Get(JSONurl);
        web.useHttpContinue = false;

        web.SendWebRequest();

        if (web.isNetworkError || web.isHttpError)
        {
            Debug.Log("Error API: " + web.error);
            return 0;
        }
        else
        {
            JSONNode quizData = SimpleJSON.JSON.Parse(web.downloadHandler.text);
            return quizData[0]["QuizID"];
        }
    }

    IEnumerator Upload()
    {
        JSONUrl = "http://localhost:4000/api/updateSetting/" + player.IDPlayer + "/" + GetQuizID();
        ChoiceQuizObjectDB questionData = new ChoiceQuizObjectDB();

        questionData.playerID = player.IDPlayer;
        questionData.quizID = GetQuizID();


        string JSONData = JsonUtility.ToJson(questionData);
        using (UnityWebRequest www = UnityWebRequest.Put(JSONUrl, JSONData))
        {
            www.method = UnityWebRequest.kHttpVerbPUT;
            www.SetRequestHeader("Content-type", "application/json");
            www.SetRequestHeader("Accept", "application/json");
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
            }
        }
    }
}
