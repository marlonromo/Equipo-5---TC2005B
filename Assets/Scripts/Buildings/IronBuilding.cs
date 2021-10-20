using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronBuilding : MonoBehaviour
{
    public int IDBuilding;
    public int buildingLevel;
    public int maintenanceCost;
    public float amountGenerated;
    public bool boost;
    public bool enabledBuilding;

    public buildingManagement buildingManagement;


    void upgradeBuilding(){
        amountGenerated += 2;
        maintenanceCost++;
    }

    public void defaultValues(){
        amountGenerated = 5;
        buildingLevel = 10;
        maintenanceCost = 12;
        enabled = true;

        IDBuilding = buildingManagement.GenerateNewIDBuilding();
    }

    public string stringAttribute(){
        string attributeData = "";
        attributeData = buildingLevel.ToString() + "," + maintenanceCost.ToString() + "," + amountGenerated.ToString() + "," + Convert.ToInt32(boost) + "," + Convert.ToInt32(enabledBuilding);
        return attributeData;
    }

    public string getID(){
        return IDBuilding.ToString();
    }
}
