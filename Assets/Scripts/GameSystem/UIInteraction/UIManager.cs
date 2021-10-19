using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreMoneyText;
    
    public Text scoreIronText;
    public Text scoreSteelNotReadyText;
    public Text scoreSteelText;
    public Text scoreMainUISteel;
    public Text scoreIronTransformText;
    public Text scoreSteelTransformText;
    public Text generatedIron;
    public Text scoreEnergy;
    public Text playerExperienceText;
    
    public Text playerName;
    public Player player;
    public PointSystem pointSystem;
    
    public static int scoreMoney;
    public static int scoreSteel;

    public float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        scoreMoneyText.text = "$" + player.scoreMoney;
        scoreSteelText.text = player.scoreSteel + " Tons";
        scoreMainUISteel.text = player.scoreSteel + " Tons";
        scoreIronText.text = player.scoreIron + " Iron";
        scoreSteelNotReadyText.text = player.scoreUnpackageSteel + " Tons";

        scoreIronTransformText.text = player.ironToUnpackageSteelPerSecond + " por segundo";
        scoreSteelTransformText.text = player.UnpackagedSteelToSteelPerSecond + " por segundo";
        scoreEnergy.text = pointSystem.totalBuildings + "/" + pointSystem.totalEnergy;
        generatedIron.text = player.rateOfIronGenerated + " por segundo";
        playerExperienceText.text = "Experiencia:   " + player.experience;
        
    }

    // Update is called once per frame
    void Update()
    {
        playerName.text = player.playerName;
        scoreMoneyText.text = "$" + player.scoreMoney;
        scoreSteelText.text = player.scoreSteel + " Tons";
        scoreMainUISteel.text = player.scoreSteel + " Tons";
        scoreIronText.text = player.scoreIron + " Iron";
        scoreSteelNotReadyText.text = player.scoreUnpackageSteel + " Tons";

        scoreIronTransformText.text = player.ironToUnpackageSteelPerSecond + " por segundo";
        scoreSteelTransformText.text = player.UnpackagedSteelToSteelPerSecond + " por segundo";
        scoreEnergy.text = pointSystem.totalBuildings + "/" + pointSystem.totalEnergy;
        generatedIron.text = player.rateOfIronGenerated + " por segundo";
        playerExperienceText.text = "Experiencia:   " + player.experience;
    }


}
