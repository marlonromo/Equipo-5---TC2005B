using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salesBuilding : MonoBehaviour
{
    //Modify this
    public int IDBuilding;
    public int buildingLevel;
    public bool enabledBuilding;

    public buildingManagement buildingManagement;
    
    public void defaultValues(){
        buildingLevel = 1;
        enabledBuilding = true;
        IDBuilding = buildingManagement.GenerateNewIDBuilding();
    }

    public string stringAttribute(){
        string attributeData = "";
        attributeData = buildingLevel + "," + Convert.ToInt32(enabledBuilding);
        return attributeData;
    }

    public string getID(){
        return IDBuilding.ToString();
    }
}
