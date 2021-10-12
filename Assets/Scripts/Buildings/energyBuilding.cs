using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energyBuilding : MonoBehaviour
{
    public int IDBuilding;
    public int energyGeneration;
    public bool boost;
    public bool enabledBuilding;

    public buildingManagement buildingManagement;
    
    public void defaultValues(){
        energyGeneration = 5;
        boost = false;
        enabledBuilding = true;
        IDBuilding = buildingManagement.GenerateNewIDBuilding();
    }

    public string stringAttribute(){
        string attributeData = "";
        attributeData = energyGeneration.ToString() + "," + Convert.ToInt32(boost) + "," + Convert.ToInt32(enabledBuilding);
        return attributeData;
    }

    public string getID(){
        return IDBuilding.ToString();
    }
}
