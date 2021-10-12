using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class streetBuilding : MonoBehaviour
    
{
    public int IDBuilding;
    public buildingManagement buildingManagement;


    public void defaultValues(){
        IDBuilding = buildingManagement.GenerateNewIDBuilding();
    }

    public string stringAttribute(){
        return "";
    }

    public string getID(){
        return IDBuilding.ToString();
    }
}
