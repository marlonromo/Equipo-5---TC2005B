using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class generateContract : MonoBehaviour
{
    public Player player;
    public saveContractData saveContractData;
    public GameObject newContractMenu;
    public GameObject blockInteraction;
    public GameObject Camera;
    Contract generatedContract;
    public Text IDContractText;
    public Text titleText;
    public Text descriptionText;
    public Text steelRequirementText;
    public Text moneyRewardText;
    public Text timeRemainingText;
    public Text penalizationText;
    public int IDContractDatabase;

    Contract generateNewContract(){
        float newTime = Random.Range(180,300);
        Contract newContract = gameObject.AddComponent<Contract>();
        newContract.IDContract = IDContractDatabase + 1;
        newContract.title = "Primeros pasos";
        newContract.description = "Una empresa interesada en crear electrodomesticos te contacto y te ofrecio una nueva oferta";
        newContract.steelRequirement = (int)(player.UnpackagedSteelToSteelPerSecond * (newTime * 0.5));
        newContract.moneyReward = 2000 + (int)(player.UnpackagedSteelToSteelPerSecond * (newTime * 0.8) * Random.Range(1,2));
        newContract.timeRemaining = newTime;
        newContract.success = false;
        newContract.isActive = false;
        newContract.penalization = 0.5;
        return newContract;
    }

    public void SeeContract(){
        blockInteraction.SetActive(true);
        Camera.GetComponent<CameraMovement>().enableMove = false;
        Time.timeScale = 0;
        generatedContract = generateNewContract();
        newContractMenu.SetActive(true);
        IDContractText.text = generatedContract.IDContract.ToString();
        titleText.text = generatedContract.title;
        descriptionText.text = generatedContract.description;
        steelRequirementText.text = generatedContract.steelRequirement.ToString() + " Toneladas de acero";
        moneyRewardText.text = "$" + generatedContract.moneyReward.ToString();
        timeRemainingText.text = timeRemainingMinutes() + " Minutos";
        penalizationText.text = (generatedContract.penalization * 100).ToString() + "%";

    }

    public void AcceptContract(){
        newContractMenu.SetActive(false);
        generatedContract.isActive = true;
        player.assignNewContract(generatedContract);
        Time.timeScale = 1;
        blockInteraction.SetActive(false);
        Camera.GetComponent<CameraMovement>().enableMove = true;
        player.savePlayerDataNow();
    }

    public void RejectContract(){
        newContractMenu.SetActive(false);
        Time.timeScale = 1;
        blockInteraction.SetActive(false);
        Camera.GetComponent<CameraMovement>().enableMove = true;
    }

    public void FinishContract(){
    }

    string timeRemainingMinutes(){
        float timeRemaining = generatedContract.timeRemaining;
        timeRemaining = timeRemaining / 60;
        int timeRemainingInt = (int)timeRemaining;
        timeRemainingInt++;
        return timeRemainingInt.ToString();
    }
}
