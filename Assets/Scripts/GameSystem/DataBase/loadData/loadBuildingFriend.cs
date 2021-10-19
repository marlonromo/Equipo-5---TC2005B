using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Unity.IO;

using SimpleJSON;

public class loadBuildingFriend : MonoBehaviour
{
    public GameObject salesReference;
    public GameObject ironReference;
    public GameObject furnaceReference;
    public GameObject packageReference;
    public GameObject energyReference;
    public GameObject streetReference;
    public buildingManagement buildingManagement;
    
    string tagEdificioData;
    float posXData;
    float posZData;
    float rotacionData;
    string attributeData;

    List<string> attributeReady = new List<string>();
    Vector3 newBuildingCoordinates;
    Quaternion newBuildingRotation;

    JSONNode userData;
    int currentBuilding;

    public void loadBuildingData(){
        newBuildingCoordinates.y = 0.01f;
        newBuildingRotation.x = 0f;
        newBuildingRotation.y = 0f;
        newBuildingRotation.z = 0f;
        newBuildingRotation.w = 0f;
        
        StartCoroutine(loadDataBaseData());
    }

    void loadBuilding(){
        if(userData != null){
            for(currentBuilding = 0; currentBuilding < userData.Count; currentBuilding++){
                
                posXData = userData[currentBuilding]["posX"];
                posZData = userData[currentBuilding]["posZ"];
                rotacionData = userData[currentBuilding]["rotation"];
                attributeData = userData[currentBuilding]["attributeBuildingData"];
                tagEdificioData = userData[currentBuilding]["buildingType"];
                if(attributeData.Length != 0){
                    decomposeString(attributeData);
                }
                
                generateNewBuilding();
                attributeReady.Clear();
            }
        }
        buildingManagement.getBuildingID();
    }
    
    IEnumerator loadDataBaseData(){
        string JSONUrl = "http://localhost:4000/api/getBuilding/" + minigameData.friendID;
        UnityWebRequest web = UnityWebRequest.Get(JSONUrl);
        web.useHttpContinue = false;

        yield return web.SendWebRequest();

        if(web.isNetworkError || web.isHttpError){
            Debug.Log("Error API: " + web.error);
        }
        else{
            userData = SimpleJSON.JSON.Parse(web.downloadHandler.text);
            loadBuilding();
        }
    }

    void generateNewBuilding(){

        if(tagEdificioData == "StreetStraight"){
            generateStreetBuilding();
        }
        else if(tagEdificioData == "SalesGenerator"){
            generateSalesBuilding();
        }
        else if(tagEdificioData == "FurnaceGenerator"){
            generateFurnaceBuilding();
        }
        else if(tagEdificioData == "IronGenerator"){
            generateIronBuilding();
        }
        else if(tagEdificioData == "EnergyGenerator"){

            generateEnergyBuilding();
        }
        else if(tagEdificioData == "PackageGenerator"){
            generatePackageBuilding();
        }
        
    }

    void generateSalesBuilding(){
        newBuildingCoordinates.x = posXData;
        newBuildingCoordinates.z = posZData;
        GameObject newBuilding = Instantiate(salesReference, newBuildingCoordinates, newBuildingRotation);
        newBuilding.transform.eulerAngles = new Vector3(0f, newBuilding.transform.eulerAngles.y + rotacionData, 0f);
        newBuilding.tag = tagEdificioData;
        newBuilding.GetComponent<salesBuilding>().IDBuilding = userData[currentBuilding]["buildingGameID"];
        newBuilding.GetComponent<salesBuilding>().buildingLevel = Int32.Parse(attributeReady[0]);
        newBuilding.GetComponent<salesBuilding>().enabledBuilding = Convert.ToBoolean(Int32.Parse(attributeReady[1]));
    }

    void generateFurnaceBuilding(){
        newBuildingCoordinates.x = posXData;
        newBuildingCoordinates.z = posZData;
        GameObject newBuilding = Instantiate(furnaceReference, newBuildingCoordinates, newBuildingRotation);
        newBuilding.transform.eulerAngles = new Vector3(0f, newBuilding.transform.eulerAngles.y + rotacionData, 0f);
        newBuilding.tag = tagEdificioData;
        newBuilding.GetComponent<furnaceBuilding>().IDBuilding = userData[currentBuilding]["buildingGameID"];
        newBuilding.GetComponent<furnaceBuilding>().buildingLevel = Int32.Parse(attributeReady[0]);
        newBuilding.GetComponent<furnaceBuilding>().maintenanceCost = Int32.Parse(attributeReady[1]);
        newBuilding.GetComponent<furnaceBuilding>().transformRate = float.Parse(attributeReady[2]);
        newBuilding.GetComponent<furnaceBuilding>().boostPosition = Convert.ToBoolean(Int32.Parse(attributeReady[3]));
        newBuilding.GetComponent<furnaceBuilding>().boostReward = Convert.ToBoolean(Int32.Parse(attributeReady[4]));
        newBuilding.GetComponent<furnaceBuilding>().enabledBuilding = Convert.ToBoolean(Int32.Parse(attributeReady[5]));
    }

    void generateIronBuilding(){
        newBuildingCoordinates.x = posXData;
        newBuildingCoordinates.z = posZData;
        GameObject newBuilding = Instantiate(ironReference, newBuildingCoordinates, newBuildingRotation);
        newBuilding.transform.eulerAngles = new Vector3(0f, newBuilding.transform.eulerAngles.y + rotacionData, 0f);
        newBuilding.tag = tagEdificioData;
        newBuilding.transform.eulerAngles = new Vector3(0f, newBuilding.transform.eulerAngles.y + rotacionData, 0f);
        newBuilding.GetComponent<IronBuilding>().IDBuilding = userData[currentBuilding]["buildingGameID"];
        newBuilding.GetComponent<IronBuilding>().buildingLevel = Int32.Parse(attributeReady[0]);
        newBuilding.GetComponent<IronBuilding>().maintenanceCost = Int32.Parse(attributeReady[1]);
        newBuilding.GetComponent<IronBuilding>().amountGenerated = float.Parse(attributeReady[2]);
        newBuilding.GetComponent<IronBuilding>().boost = Convert.ToBoolean(Int32.Parse(attributeReady[3]));
        newBuilding.GetComponent<IronBuilding>().enabledBuilding = Convert.ToBoolean(Int32.Parse(attributeReady[4]));
    }

    void generatePackageBuilding(){
        newBuildingCoordinates.x = posXData;
        newBuildingCoordinates.z = posZData;
        GameObject newBuilding = Instantiate(packageReference, newBuildingCoordinates, newBuildingRotation);
        newBuilding.transform.eulerAngles = new Vector3(0f, newBuilding.transform.eulerAngles.y + rotacionData, 0f);
        newBuilding.tag = tagEdificioData;
        newBuilding.GetComponent<packageBuilding>().IDBuilding = userData[currentBuilding]["buildingGameID"];
        newBuilding.GetComponent<packageBuilding>().buildingLevel = Int32.Parse(attributeReady[0]);
        newBuilding.GetComponent<packageBuilding>().maintenanceCost = Int32.Parse(attributeReady[1]);
        newBuilding.GetComponent<packageBuilding>().storageLimit = Int32.Parse(attributeReady[2]);
        newBuilding.GetComponent<packageBuilding>().transformRate = float.Parse(attributeReady[3]);
        newBuilding.GetComponent<packageBuilding>().boost = Convert.ToBoolean(Int32.Parse(attributeReady[4]));
        newBuilding.GetComponent<packageBuilding>().enabledBuilding = Convert.ToBoolean(Int32.Parse(attributeReady[5]));
    }

    void generateEnergyBuilding(){
        newBuildingCoordinates.x = posXData;
        newBuildingCoordinates.z = posZData;
        GameObject newBuilding = Instantiate(energyReference, newBuildingCoordinates, newBuildingRotation);
        newBuilding.transform.eulerAngles = new Vector3(0f, newBuilding.transform.eulerAngles.y + rotacionData, 0f);
        newBuilding.tag = tagEdificioData;
        newBuilding.GetComponent<energyBuilding>().IDBuilding = userData[currentBuilding]["buildingGameID"];
        newBuilding.GetComponent<energyBuilding>().energyGeneration = Int32.Parse(attributeReady[0]);
        newBuilding.GetComponent<energyBuilding>().boost = Convert.ToBoolean(Int32.Parse(attributeReady[1]));
        newBuilding.GetComponent<energyBuilding>().enabledBuilding = Convert.ToBoolean(Int32.Parse(attributeReady[2]));
    }

    void generateStreetBuilding(){
        newBuildingCoordinates.x = posXData;
        newBuildingCoordinates.z = posZData;
        GameObject newBuilding = Instantiate(streetReference, newBuildingCoordinates, newBuildingRotation);
        newBuilding.transform.eulerAngles = new Vector3(0f, newBuilding.transform.eulerAngles.y + rotacionData, 0f);
        newBuilding.tag = tagEdificioData;
        newBuilding.GetComponent<streetBuilding>().IDBuilding = userData[currentBuilding]["buildingGameID"];
    }

    void decomposeString(string attributeData){
        string dataString = "";
        for(int x = 0; x < attributeData.Length; x++){
            if(attributeData[x] != ','){
                dataString = dataString + attributeData[x];
                if(x == (attributeData.Length - 1)){
                    attributeReady.Add(dataString);
                }
            }
            else if(attributeData[x] == ','){
                attributeReady.Add(dataString);
                dataString = "";
            }
            
        }
    }
}
