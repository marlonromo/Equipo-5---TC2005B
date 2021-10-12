using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Unity.IO;

using SimpleJSON;
using Newtonsoft.Json;

public class saveBuildingData : MonoBehaviour
{
    public Player player;
    // string tagEdificioData;
    // float posXData;
    // float posZData;
    // float rotacionData;
    // string attributeData;

    List<string> tagBuilding = new List<string>();
    List<string> buildingValues = new List<string>();
    GameObject[] buildingsToSave;
    string JSONData;
    void Awake(){
        tagBuilding.Add("IronGenerator");
        tagBuilding.Add("FurnaceGenerator");
        tagBuilding.Add("PackageGenerator");
        tagBuilding.Add("EnergyGenerator");
        tagBuilding.Add("SalesGenerator");
        tagBuilding.Add("StreetStraight");
    }

    public void saveBuildingsNow(){
        StartCoroutine(getBuildingInfo());
    }

    IEnumerator getBuildingInfo(){
        
        buildingObjectDB buildingData = new buildingObjectDB();
        for(int x = 0; x < 6; x++){
            if(GameObject.FindGameObjectsWithTag(tagBuilding[x]) != null){
                buildingsToSave = GameObject.FindGameObjectsWithTag(tagBuilding[x]);
                for(int i = 0; i < buildingsToSave.Length; i++){
                    buildingValues.Clear();
                    buildingData.playerID = player.IDPlayer;
                    buildingData.buildingType = tagBuilding[x];
                    buildingData.posX = buildingsToSave[i].transform.position.x;
                    buildingData.posZ = buildingsToSave[i].transform.position.z;
                    buildingData.rotation = buildingsToSave[i].transform.rotation.eulerAngles.y;
                    getAttributes(tagBuilding[x], buildingsToSave[i]);
                    buildingData.buildingGameID = Int32.Parse(buildingValues[0]);
                    buildingData.attributeBuildingData = buildingValues[1];
                    
                    JSONData = JsonConvert.SerializeObject(buildingData);
                    using(UnityWebRequest www = UnityWebRequest.Put("http://localhost:4000/api/updateBuilding", JSONData)){
                        www.method = UnityWebRequest.kHttpVerbPUT;
                        www.SetRequestHeader("Content-type", "application/json");
                        www.SetRequestHeader("Accept", "application/json");
                        yield return www.SendWebRequest();
                        
                        
                        if(www.isNetworkError || www.isHttpError){
                            Debug.Log(www.error);
                        }
                        else{
                        }
                    }
                }
            }
        }
    }

    void getAttributes(string tag, GameObject building){
        List<string> dataToSave = new List<string>();
        if(tag == "SalesGenerator"){
            buildingValues.Add(building.GetComponent<salesBuilding>().getID());
            buildingValues.Add(building.GetComponent<salesBuilding>().stringAttribute());
        }
        else if(tag == "IronGenerator"){
            buildingValues.Add(building.GetComponent<IronBuilding>().getID());
            buildingValues.Add(building.GetComponent<IronBuilding>().stringAttribute());
        }
        else if(tag == "FurnaceGenerator"){
            buildingValues.Add(building.GetComponent<furnaceBuilding>().getID());
            buildingValues.Add(building.GetComponent<furnaceBuilding>().stringAttribute());
        }
        else if(tag == "PackageGenerator"){
            buildingValues.Add(building.GetComponent<packageBuilding>().getID());
            buildingValues.Add(building.GetComponent<packageBuilding>().stringAttribute());
        }
        else if(tag == "EnergyGenerator"){
            buildingValues.Add(building.GetComponent<energyBuilding>().getID());
            buildingValues.Add(building.GetComponent<energyBuilding>().stringAttribute());
        }
        else{
            buildingValues.Add(building.GetComponent<streetBuilding>().getID());
            buildingValues.Add(building.GetComponent<streetBuilding>().stringAttribute());
        }
    }
}
