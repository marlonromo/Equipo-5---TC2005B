using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class playMusic : MonoBehaviour
{
    public AudioMixer volumeSetting;
    public SetVolume setVolume;
    public AudioSource musicAudio;
    float currentVolume = 0;

    public void playAudio(){
        AudioListener.pause = false;
    }

    public void stopAudio(){
        AudioListener.pause = true;
    }
    public void SetVolumeLevel(float sliderValue){
        setVolume.SetVolumeLevel(sliderValue);
        currentVolume = sliderValue;
    }

    public void getSliderVolume(){
        setVolume.SetVolumeLevel(setVolume.getMusicAudioVolume());
        currentVolume = setVolume.getMusicAudioVolume();
    }

    public float getCurrentVolume(){
        currentVolume = setVolume.getMusicAudioVolume();
        return currentVolume;
    }
}
