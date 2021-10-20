using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class furnaceBuilding : MonoBehaviour
{
    public int IDBuilding;
    public int buildingLevel;
    public int maintenanceCost;
    public float transformRate;
    public bool boostPosition;
    public bool boostReward;
    public bool enabledBuilding;
    float distance = 1000;
    float newDistance;

    public buildingManagement buildingManagement;
    GameObject activeNearBuilding;

    public void defaultValues(){
        buildingLevel = 1;
        transformRate = 7;
        maintenanceCost = 1;
        boostPosition = false;
        enabledBuilding = true;
        IDBuilding = buildingManagement.GenerateNewIDBuilding();
    }

    public string stringAttribute(){
        string attributeData = "";
        attributeData = buildingLevel + "," + maintenanceCost.ToString() + "," + transformRate.ToString() + "," + Convert.ToInt32(boostPosition) + "," + Convert.ToInt32(boostReward) + "," + Convert.ToInt32(enabledBuilding);
        return attributeData;
    }

    public string getID(){
        return IDBuilding.ToString();
    }

    void enableBoostPosition(bool enableBoostPositionNow){
        if(enableBoostPositionNow && boostPosition == false){
            boostPosition = true;
            transformRate = transformRate * (float)1.5;
            Debug.Log("Tengo boost!: " + transformRate);
        }
        else if(enableBoostPositionNow == false && boostPosition == true){
            boostPosition = false;
            transformRate = transformRate / (float)1.5;
            Debug.Log("Ya no tengo :c: " + transformRate);
        }
    }

    public void checkNearIronBuildings(GameObject[] ironBuilding){
        if(ironBuilding != null){
            if(activeNearBuilding != null){
                newDistance = Vector3.Distance(this.transform.position, activeNearBuilding.transform.position);
                if(newDistance != distance){
                    enableBoostPosition(checkDistanceBetween(ironBuilding));
                }
            }
            else{
                enableBoostPosition(checkDistanceBetween(ironBuilding));
            }
        }
    }

    bool checkDistanceBetween(GameObject [] ironBuilding){
        distance = 1000;
        bool enableBoostPos = false;
        for(int x = 0; x < ironBuilding.Length; x++){
            newDistance = Vector3.Distance(this.transform.position, ironBuilding[x].transform.position);
            if(newDistance < distance){
                distance = newDistance;
            }
        }
        
        if(distance < 6){
            enableBoostPos = true;
        }
        return enableBoostPos;
    }
}
