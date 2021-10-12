using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class packageBuilding : MonoBehaviour
{
    public int IDBuilding;
    public int buildingLevel;
    public int maintenanceCost;
    public int storageLimit;
    public float transformRate;
    public bool boost;
    public bool enabledBuilding;

    public buildingManagement buildingManagement;
    
    public void defaultValues(){
        buildingLevel = 1;
        transformRate = 10;
        storageLimit = 100;
        maintenanceCost = 20;
        boost = false;
        enabledBuilding = true;
        IDBuilding = buildingManagement.GenerateNewIDBuilding();
    }

    public string stringAttribute(){
        string attributeData = "";
        attributeData = buildingLevel + "," + maintenanceCost.ToString() + "," + storageLimit.ToString() + "," + transformRate.ToString() + "," + Convert.ToInt32(boost) + "," + Convert.ToInt32(enabledBuilding);
        return attributeData;
    }

    public string getID(){
        return IDBuilding.ToString();
    }
}
