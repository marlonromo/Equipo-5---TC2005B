using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Unity.IO;
using SimpleJSON;

public class saveOptionsData : MonoBehaviour
{
    public Player player;
    public playMusic musicSettings;
    public CameraMovement cameraMovement;
    string JSONUrl;

    public void saveOptionsNow(){
        StartCoroutine(Upload());
    }

    IEnumerator Upload(){
        JSONUrl = "http://localhost:4000/api/updateSetting/" + player.IDPlayer;
        OptionsObjectDB optionsData = new OptionsObjectDB();

        optionsData.IDPlayer = player.IDPlayer;
        optionsData.volumeMusic = musicSettings.getCurrentVolume();
        optionsData.cameraSensibility = cameraMovement.mouseSensibilityX;
        optionsData.cameraSpeed = cameraMovement.cameraSpeed;

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
            }
        }
    }
}
