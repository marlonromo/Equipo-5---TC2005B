using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class LightningManager : MonoBehaviour
{
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightningPreset Preset;
    [SerializeField] private float daySpeed;
    [SerializeField, Range(0,24)] private float TimeOfDay;

    private void Update(){
        if(Preset == null){
            return;
        }
        if(Application.isPlaying){
            TimeOfDay += Time.deltaTime / daySpeed;
            TimeOfDay %= 24;
            UpdateLighting(TimeOfDay / 24);
        }
        else{
            UpdateLighting(TimeOfDay / 24f);
        }
    }
    private void UpdateLighting(float timePercent){
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);
        if(DirectionalLight != null){
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }
    }
    private void OnValidate(){
        if(DirectionalLight != null){
            return;
        }
        if(RenderSettings.sun != null){
            DirectionalLight = RenderSettings.sun;
        }
        else{
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach(Light light in lights){
                DirectionalLight = light;
                return;
            }
        }
    }
}
