using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer volumeSetting;
    public Text volumeNumber;
    float displayNumberVolume;
    public float volumeMusicValue = 0.01f;
    public void SetVolumeLevel(float sliderValue){
        volumeSetting.SetFloat("MusicVol", Mathf.Log10(sliderValue) *20);
        volumeMusicValue = sliderValue;
        displayNumberVolume = sliderValue*10;
        volumeNumber.text = ((int)displayNumberVolume).ToString();
    }

    public float getMusicAudioVolume(){
        return volumeMusicValue;
    }
}
