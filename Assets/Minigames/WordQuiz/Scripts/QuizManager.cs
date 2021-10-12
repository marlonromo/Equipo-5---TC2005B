using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public static QuizManager instance; //Instance to make is available in other scripts without reference

    [SerializeField] private GameObject gameComplete;
    //Scriptable data which store our questions data
    [SerializeField] private QuizDataScriptable questionDataScriptable;
    //[SerializeField] private Image questionImage;           //image element to show the image
    [SerializeField] private RawImage questionRawImage;           //image element to show the image
    [SerializeField] private WordData[] answerWordList;     //list of answers word in the game
    [SerializeField] private WordData[] optionsWordList;    //list of options word in the game

    private List<QuestionDataDB> questions;
    private string urlQuestions = "http://localhost:4000/api/json/Terniumeq2.json";
    private string urlImageBase = "http://localhost:3000/images/";
    private string imageExtension = ".png";
    private Texture[] textures;


    private GameStatus gameStatus = GameStatus.Playing;     //to keep track of game status
    private char[] wordsArray = new char[12];               //array which store char of each options

    private List<int> selectedWordsIndex;                   //list which keep track of option word index w.r.t answer word index
    private int currentAnswerIndex = 0, currentQuestionIndex = 0;   //index to keep track of current answer and current question
    private bool correctAnswer = true;                      //bool to decide if answer is correct or not
    private string answerWord;                              //string to store answer of current question
    

    private void Awake()
    {
        Time.timeScale = 1;
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        selectedWordsIndex = new List<int>();           //create a new list at start
        StartCoroutine(LoadDB());

        //SetQuestion();                                  //set question
    }

    IEnumerator LoadDB()
    {
        UnityWebRequest web = UnityWebRequest.Get(urlQuestions);
        web.useHttpContinue = false;

        yield return web.SendWebRequest();

        //if (web.result != UnityWebRequest.Result.Success)
        if(web.isNetworkError || web.isHttpError)
        {
            Debug.Log("Error API: " + web.error);
        }
        else
        {
            questions = JsonConvert.DeserializeObject<List<QuestionDataDB>>(web.downloadHandler.text);
            if (questions.Count > 0)
            {
                textures = new Texture[questions.Count];
                for (int i = 0; i < questions.Count; i++)
                {
                    string url = urlImageBase + questions[i].questionImage + imageExtension;
                    UnityWebRequest webImage = UnityWebRequestTexture.GetTexture(url);
                    yield return webImage.SendWebRequest();

                    if (!webImage.isNetworkError || !webImage.isHttpError)
                    {
                        textures[i] = DownloadHandlerTexture.GetContent(webImage);
                        Debug.Log("Paso 1");
                    }
                    Debug.Log($"Pregunta: {url} - Respuesta: {questions[i].answer}");
                }
                SetQuestion();
            }
        }
    }

    void SetQuestion()
    {
        gameStatus = GameStatus.Playing;                //set GameStatus to playing

        //set the answerWord string variable
        //answerWord = questionDataScriptable.questions[currentQuestionIndex].answer;
        answerWord = questions[currentQuestionIndex].answer;
        //set the image of question
        Debug.Log("Paso 2");
        //questionImage.sprite = questionDataScriptable.questions[currentQuestionIndex].questionImage;
        questionRawImage.texture = textures[currentQuestionIndex];
        ResetQuestion();                               //reset the answers and options value to orignal

        selectedWordsIndex.Clear();                     //clear the list for new question
        Array.Clear(wordsArray, 0, wordsArray.Length);  //clear the array

        //add the correct char to the wordsArray
        for (int i = 0; i < answerWord.Length; i++)
        {
            wordsArray[i] = char.ToUpper(answerWord[i]);
        }

        //add the dummy char to wordsArray
        for (int j = answerWord.Length; j < wordsArray.Length; j++)
        {
            wordsArray[j] = (char)UnityEngine.Random.Range(65, 90);
        }

        wordsArray = ShuffleList.ShuffleListItems<char>(wordsArray.ToList()).ToArray(); //Randomly Shuffle the words array

        //set the options words Text value
        for (int k = 0; k < optionsWordList.Length; k++)
        {
            optionsWordList[k].SetWord(wordsArray[k]);
        }

    }

    //Method called on Reset Button click and on new question
    public void ResetQuestion()
    {
        //activate all the answerWordList gameobject and set their word to "_"
        for (int i = 0; i < answerWordList.Length; i++)
        {
            answerWordList[i].gameObject.SetActive(true);
            answerWordList[i].SetWord('_');
        }

        //Now deactivate the unwanted answerWordList gameobject (object more than answer string length)
        for (int i = answerWord.Length; i < answerWordList.Length; i++)
        {
            answerWordList[i].gameObject.SetActive(false);
        }

        //activate all the optionsWordList objects
        for (int i = 0; i < optionsWordList.Length; i++)
        {
            optionsWordList[i].gameObject.SetActive(true);
        }

        currentAnswerIndex = 0;
    }

    /// <summary>
    /// When we click on any options button this method is called
    /// </summary>
    /// <param name="value"></param>
    public void SelectedOption(WordData value)
    {
        //if gameStatus is next or currentAnswerIndex is more or equal to answerWord length
        if (gameStatus == GameStatus.Next || currentAnswerIndex >= answerWord.Length) return;

        selectedWordsIndex.Add(value.transform.GetSiblingIndex()); //add the child index to selectedWordsIndex list
        value.gameObject.SetActive(false); //deactivate options object
        answerWordList[currentAnswerIndex].SetWord(value.wordValue); //set the answer word list

        currentAnswerIndex++;   //increase currentAnswerIndex

        //if currentAnswerIndex is equal to answerWord length
        if (currentAnswerIndex == answerWord.Length)
        {
            correctAnswer = true;   //default value
            //loop through answerWordList
            for (int i = 0; i < answerWord.Length; i++)
            {
                //if answerWord[i] is not same as answerWordList[i].wordValue
                if (char.ToUpper(answerWord[i]) != char.ToUpper(answerWordList[i].wordValue))
                {
                    correctAnswer = false; //set it false
                    break; //and break from the loop
                }
            }

            //if correctAnswer is true
            if (correctAnswer)
            {
                Debug.Log("Correct Answer");
                gameStatus = GameStatus.Next; //set the game status
                currentQuestionIndex++; //increase currentQuestionIndex

                //if currentQuestionIndex is less that total available questions
                if (currentQuestionIndex < questions.Count)
                    //if (currentQuestionIndex < questionDataScriptable.questions.Count)
                {
                        Invoke("SetQuestion", 0.5f); //go to next question
                }
                else
                {
                    Debug.Log("Game Complete"); //else game is complete
                    StartCoroutine(waitTimeScreen());
                    gameComplete.SetActive(true);
                }
            }
        }
    }

    public void ResetLastWord()
    {
        if (selectedWordsIndex.Count > 0)
        {
            int index = selectedWordsIndex[selectedWordsIndex.Count - 1];
            optionsWordList[index].gameObject.SetActive(true);
            selectedWordsIndex.RemoveAt(selectedWordsIndex.Count - 1);

            currentAnswerIndex--;
            answerWordList[currentAnswerIndex].SetWord('_');
        }
    }

    IEnumerator waitTimeScreen(){
        yield return new WaitForSeconds(5f);
        returnGame();
    }
    void returnGame(){
        minigameData.win = true;
        minigameData.reward = "contract";
        SceneManager.LoadScene("Playgame");
    }

}

[System.Serializable]
public class QuestionData
{
    public Sprite questionImage;
    public string answer;
}

[System.Serializable]
public class QuestionDataDB
{
    public string questionImage;
    public string answer;
}

public enum GameStatus
{
    Next,
    Playing
}
