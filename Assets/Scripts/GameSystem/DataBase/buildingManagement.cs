using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingManagement : MonoBehaviour
{
    GameObject[] IDBuildingObject;
    public GameObject[] ironBuilding;
    public GameObject[] packageBuilding;
    List<string> buildingTags = new List<string>();
    List<int> buildingID = new List<int>();

    void Start(){
        
    }

    public void getIronBuilding(){
        ironBuilding = GameObject.FindGameObjectsWithTag("IronGenerator");
    }

    public void getPackageBuilding(){
        packageBuilding = GameObject.FindGameObjectsWithTag("PackageGenerator");
    }

    public void getBuildingID(){
        buildingTags.Clear();
        buildingTags.Add("IronGenerator");
        buildingTags.Add("FurnaceGenerator");
        buildingTags.Add("PackageGenerator");
        buildingTags.Add("EnergyGenerator");
        buildingTags.Add("SalesGenerator");
        buildingTags.Add("StreetStraight");
        if(GameObject.FindGameObjectsWithTag(buildingTags[0]) != null){
            IDBuildingObject = GameObject.FindGameObjectsWithTag(buildingTags[0]);
            for(int x = 0; x < IDBuildingObject.Length; x++){
                buildingID.Add(IDBuildingObject[x].GetComponent<IronBuilding>().IDBuilding);
            }
        }

        if(GameObject.FindGameObjectsWithTag(buildingTags[1]) != null){
            IDBuildingObject = GameObject.FindGameObjectsWithTag(buildingTags[1]);
            for(int x = 0; x < IDBuildingObject.Length; x++){
                buildingID.Add(IDBuildingObject[x].GetComponent<furnaceBuilding>().IDBuilding);
            }
        }

        if(GameObject.FindGameObjectsWithTag(buildingTags[2]) != null){
            IDBuildingObject = GameObject.FindGameObjectsWithTag(buildingTags[2]);
            for(int x = 0; x < IDBuildingObject.Length; x++){
                buildingID.Add(IDBuildingObject[x].GetComponent<packageBuilding>().IDBuilding);
            }
        }

        if(GameObject.FindGameObjectsWithTag(buildingTags[3]) != null){
            IDBuildingObject = GameObject.FindGameObjectsWithTag(buildingTags[3]);
            for(int x = 0; x < IDBuildingObject.Length; x++){
                buildingID.Add(IDBuildingObject[x].GetComponent<energyBuilding>().IDBuilding);
            }
        }

        if(GameObject.FindGameObjectsWithTag(buildingTags[4]) != null){
            IDBuildingObject = GameObject.FindGameObjectsWithTag(buildingTags[4]);
            for(int x = 0; x < IDBuildingObject.Length; x++){
                buildingID.Add(IDBuildingObject[x].GetComponent<salesBuilding>().IDBuilding);
            }
        }

        if(GameObject.FindGameObjectsWithTag(buildingTags[5]) != null){
            IDBuildingObject = GameObject.FindGameObjectsWithTag(buildingTags[5]);
            for(int x = 0; x < IDBuildingObject.Length; x++){
                buildingID.Add(IDBuildingObject[x].GetComponent<streetBuilding>().IDBuilding);
            }
        }
        
    }

    public int GenerateNewIDBuilding(){
        int newBuildingID = 0;
        foreach(int ObjID in buildingID){
            if(newBuildingID < ObjID){
                newBuildingID = ObjID;
            }
            
        }

        newBuildingID = newBuildingID + 1;
        buildingID.Add(newBuildingID);
        return newBuildingID;
    }
}
