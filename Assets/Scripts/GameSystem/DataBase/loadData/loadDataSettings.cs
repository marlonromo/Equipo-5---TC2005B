using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Unity.IO;
using UnityEngine.UI;
using SimpleJSON;


public class loadDataSettings : MonoBehaviour
{
    public playMusic playMusic;
    public GameObject sliderSettingVolume;
    public GameObject sliderSettingSensibility;
    public GameObject sliderSettingSpeed;
    public Player player;
    float volumeSettings;
    float cameraSensibility;
    float cameraSpeed;

    

    public void loadDataSettingsNow(){
        StartCoroutine(getInfoDatabaseSettings());
        
    }
    IEnumerator getInfoDatabaseSettings(){
        string JSONUrl = "http://localhost:4000/api/getSetting/" + player.IDPlayer;
        UnityWebRequest web = UnityWebRequest.Get(JSONUrl);
        web.useHttpContinue = false;

        yield return web.SendWebRequest();
        if(web.isNetworkError || web.isHttpError){
            Debug.Log("Error API: " + web.error);
        }
        else{
            
            JSONNode userData = SimpleJSON.JSON.Parse(web.downloadHandler.text);
            if(userData.Count != 0){
                volumeSettings = userData[0]["volumeMusic"];
                cameraSensibility = userData[0]["cameraSensibility"];
                cameraSpeed = userData[0]["cameraSpeed"];
                loadVolumeSettings();
            }
            else{
                StartCoroutine(insertNewSettingUser());
            }
            
        }
        
    }

    IEnumerator insertNewSettingUser(){
        string JSONUrl = "http://localhost:4000/api/addSetting";
        OptionsObjectDB optionsData = new OptionsObjectDB();
        optionsData.IDPlayer = player.IDPlayer;
        optionsData.volumeMusic = 4;
        optionsData.cameraSpeed = 4;
        optionsData.cameraSensibility = 4;
        string JSONData = JsonUtility.ToJson(optionsData);
        using(UnityWebRequest www = UnityWebRequest.Put(JSONUrl, JSONData)){
            www.method = UnityWebRequest.kHttpVerbPUT;
            www.SetRequestHeader("Content-type", "application/json");
            www.SetRequestHeader("Accept", "application/json");
            
            yield return www.SendWebRequest();

            if(www.isNetworkError || www.isHttpError){
                Debug.Log(www.error);
            }
            else{
                volumeSettings = 0.5f;
                cameraSensibility = 4;
                cameraSpeed = 4;
                loadVolumeSettings();
            }
        }

    }

    void loadVolumeSettings(){
        playMusic.SetVolumeLevel(volumeSettings);
        sliderSettingVolume.GetComponent<Slider>().value = volumeSettings;
        sliderSettingSensibility.GetComponent<Slider>().value = cameraSensibility;
        sliderSettingSpeed.GetComponent<Slider>().value = cameraSpeed;
    }
}
