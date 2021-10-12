using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
    public Player player;
    public buildingManagement buildingManagement;
    public bool checkBuildingPosition;
    public int totalEnergy;
    public int totalBuildings = 0;
    int maintenanceCost;
    float time = 0;
    
    //Iron Generator Buildings
    GameObject[] ironBuilding;
    float generatedIron;

    //Transform Building Iron -> Steel
    GameObject[] furnaceBuilding;
    float transformedIron;

    //Package Steel [Ready to Sell]
    GameObject[] packageBuilding;
    float totalSteel;
    int maxCapacitySteel;
    float penalizationStorage;

    //Energy Building
    GameObject[] energyBuilding;
    

    void Update()
    {
        if(time > 1){
            player.experience = player.scoreMoney + (int)(player.scoreIron / 0.25) +  (int)(player.scoreUnpackageSteel / 0.50) + (int)(player.scoreSteel);
            if(totalEnergy >= totalBuildings && totalEnergy != 0){
                if(ironBuilding != null){
                    obtainIron();
                    player.experience += (ironBuilding.Length * 50);
                }
                if(furnaceBuilding != null){
                    transformIron();
                    player.experience += (furnaceBuilding.Length * 100);
                }
                if(packageBuilding != null){
                    packageSteel(); 
                    player.experience += (packageBuilding.Length * 200);
                }
    
            }
            if(energyBuilding != null){
                energyResources();
            }
            if(checkBuildingPosition){
                checkDistanceBetweenBuilding();
            }
            CheckContract();

            
            
            time = 0;
        }

        

        time += Time.deltaTime;
        
    }

    public void checkBuilding(){
        ironBuilding = GameObject.FindGameObjectsWithTag("IronGenerator"); 
        furnaceBuilding = GameObject.FindGameObjectsWithTag("FurnaceGenerator");
        packageBuilding = GameObject.FindGameObjectsWithTag("PackageGenerator");
        energyBuilding = GameObject.FindGameObjectsWithTag("EnergyGenerator");
        
        totalBuildings = ironBuilding.Length;
        totalBuildings = totalBuildings + packageBuilding.Length;
        totalBuildings = totalBuildings + furnaceBuilding.Length;
    }
    void obtainIron(){
        float generatePerSecondIron = 0;
        for(int i = 0; i < ironBuilding.Length; i++){
            generatedIron = ironBuilding[i].GetComponent<IronBuilding>().amountGenerated;
            maintenanceCost = ironBuilding[i].GetComponent<IronBuilding>().maintenanceCost;
            generatePerSecondIron = generatePerSecondIron + generatedIron;
            player.scoreIron += generatedIron;
            player.scoreMoney -= maintenanceCost;
        }
        player.rateOfIronGenerated = generatePerSecondIron;
        
    }

    void transformIron(){
        float transformPerSecondIron = 0;
        for(int i = 0; i < furnaceBuilding.Length; i++){
            transformedIron = furnaceBuilding[i].GetComponent<furnaceBuilding>().transformRate;
            maintenanceCost = furnaceBuilding[i].GetComponent<furnaceBuilding>().maintenanceCost;
            if(player.scoreIron > transformedIron){
                player.scoreUnpackageSteel += transformedIron;
                player.scoreIron -= transformedIron;
            }
            transformPerSecondIron = transformPerSecondIron + transformedIron;
            player.ironToUnpackageSteelPerSecond = transformPerSecondIron;
            player.scoreMoney -= maintenanceCost;
        }
        player.ironToUnpackageSteelPerSecond = transformPerSecondIron;
    }

    void packageSteel(){
        float transformPerSecondSteel = 0;
        for(int i = 0; i < packageBuilding.Length; i++){
            totalSteel = packageBuilding[i].GetComponent<packageBuilding>().transformRate;
            maintenanceCost = packageBuilding[i].GetComponent<packageBuilding>().maintenanceCost;
            if(player.scoreUnpackageSteel > totalSteel){
                player.scoreSteel += totalSteel;
                player.scoreUnpackageSteel -= totalSteel;
            }
            transformPerSecondSteel = transformPerSecondSteel + totalSteel;
            
            player.scoreMoney -= (int)((float)maintenanceCost * penalizationStorage);
        }
        player.UnpackagedSteelToSteelPerSecond = transformPerSecondSteel;
        minigameData.rateOfSteel = transformPerSecondSteel;
    }

    void energyResources(){
        totalEnergy = 0;
        for(int i = 0; i < energyBuilding.Length; i++){
            totalEnergy += energyBuilding[i].GetComponent<energyBuilding>().energyGeneration;
        }
    }
    
    void CheckContract(){
        if(player.contract != null){
            if(player.contract.timeRemaining >= -2 && player.contract.isActive == true){
                if(player.contract.timeRemaining <= 0){
                    penalizationContract();
                    player.contract.timeRemaining = 0;
                }
                player.contract.timeRemaining--;
            }
        }
    }

    void penalizationContract(){
        if(player.contract.moneyReward > 0){
            double penalizationMoney = player.contract.moneyReward;
            penalizationMoney = -(penalizationMoney * player.contract.penalization);
            player.contract.moneyReward = (int)penalizationMoney;
            player.contract.steelRequirement = 0;
            player.contract.success = false;
        }
        
    }

    void checkDistanceBetweenBuilding(){
        buildingManagement.getIronBuilding();
        buildingManagement.getPackageBuilding();
        if(furnaceBuilding != null){
            for(int x = 0; x < furnaceBuilding.Length; x++){
                furnaceBuilding[x].GetComponent<furnaceBuilding>().checkNearIronBuildings(ironBuilding);
            }
        }
        

        checkBuildingPosition = false;
    }


}
