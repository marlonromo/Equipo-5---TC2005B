using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class personaje : MonoBehaviour
{
    public float velocidad=5;
    public GameObject mineria;
    public GameObject RD;
    public GameObject HAE;
    public GameObject chatarra;
    public GameObject puerto;
    public GameObject AHorno;
    public GameObject CBOF;
    public GameObject CCD;
    public GameObject CD;
    public GameObject CCDD;
    public GameObject CCP;
    public GameObject LPL;
    public GameObject LC;
    public GameObject BB;
    public GameObject LF;
    public GameObject estañado;
    public GameObject Electro;
    public GameObject Prepintado;
    public GameObject BC;
    public GameObject BGC;
    public GameObject BE;
    public GameObject Plata;
    public GameObject Rojo;
    public GameObject pftp;
    public GameObject alambron;
    public GameObject varillas;
    public GameObject paneles;
    public GameObject electrodomesticos;
    public GameObject techo;
    public GameObject carro;
    public GameObject tubos_perf;
    public GameObject resorte;
    public GameObject barra;
    public GameObject barril;
    public string typeReward;
    public int amountReward;
    public string winMessage;

    void Awake(){
        Time.timeScale = 1;
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.Translate(-velocidad*Time.deltaTime,0,0);
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            transform.Translate(velocidad*Time.deltaTime,0,0);
        }
        if(Input.GetKey(KeyCode.UpArrow)){
            transform.Translate(0,velocidad*Time.deltaTime,0);
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            transform.Translate(0,-velocidad*Time.deltaTime,0);
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag=="stone"){
            if(Input.GetKey(KeyCode.LeftArrow)){
                transform.Translate(velocidad*Time.deltaTime,0,0);
            }
            if(Input.GetKey(KeyCode.RightArrow)){
                transform.Translate(-velocidad*Time.deltaTime,0,0);
            }
            if(Input.GetKey(KeyCode.UpArrow)){
                transform.Translate(0,-velocidad*Time.deltaTime,0);
            }
            if(Input.GetKey(KeyCode.DownArrow)){
                transform.Translate(0,velocidad*Time.deltaTime,0);
            }
        }
        else if(collision.gameObject.tag=="mineria"){
            mineria.SetActive(true);
        }
        else if(collision.gameObject.tag=="RD"){
            RD.SetActive(true);
        }
        else if(collision.gameObject.tag=="HAE"){
            HAE.SetActive(true);
        }
        else if(collision.gameObject.tag=="chatarra"){
            chatarra.SetActive(true);
        }
        else if(collision.gameObject.tag=="puerto"){
            puerto.SetActive(true);
        }
        else if(collision.gameObject.tag=="ahorno"){
            AHorno.SetActive(true);
        }
        else if(collision.gameObject.tag=="cbof"){
            CBOF.SetActive(true);
        }
        else if(collision.gameObject.tag=="ccd"){
            CCD.SetActive(true);
        }
        else if(collision.gameObject.tag=="cd"){
            CD.SetActive(true);
        }
        else if(collision.gameObject.tag=="ccdd"){
            CCDD.SetActive(true);
        }
        else if(collision.gameObject.tag=="ccp"){
            CCP.SetActive(true);
        }
        else if(collision.gameObject.tag=="lpl"){
            LPL.SetActive(true);
        }
        else if(collision.gameObject.tag=="lc"){
            LC.SetActive(true);
        }
        else if(collision.gameObject.tag=="bb"){
            BB.SetActive(true);
        }
        else if(collision.gameObject.tag=="lf"){
            LF.SetActive(true);
        }
        else if(collision.gameObject.tag=="estañado"){
            estañado.SetActive(true);
        }
        else if(collision.gameObject.tag=="electro"){
            Electro.SetActive(true);
        }
        else if(collision.gameObject.tag=="prepintado"){
            Prepintado.SetActive(true);
        }
        else if(collision.gameObject.tag=="bc"){
            BC.SetActive(true);
        }
        else if(collision.gameObject.tag=="bgc"){
            BGC.SetActive(true);
        }
        else if(collision.gameObject.tag=="be"){
            BE.SetActive(true);
        }
        else if(collision.gameObject.tag=="plata"){
            Plata.SetActive(true);
        }
        else if(collision.gameObject.tag=="rojo"){
            Rojo.SetActive(true);
        }
        else if(collision.gameObject.tag=="pftp"){
            pftp.SetActive(true);
        }
        else if(collision.gameObject.tag=="alambron"){
            alambron.SetActive(true);
        }
        else if(collision.gameObject.tag=="varillas"){
            varillas.SetActive(true);
        }
        else if(collision.gameObject.tag=="paneles"){
            minigameData.win = true;
            minigameData.reward = "unpackageSteel";
            minigameData.amountReward = 500;
            paneles.SetActive(true);
        }
        else if(collision.gameObject.tag=="electrodomesticos"){
            minigameData.win = true;
            minigameData.reward = "money";
            minigameData.amountReward = 3000;
            electrodomesticos.SetActive(true);
        }
        else if(collision.gameObject.tag=="techo"){
            minigameData.win = true;
            minigameData.reward = "iron";
            minigameData.amountReward = 300;
            techo.SetActive(true);
        }
        else if(collision.gameObject.tag=="carro"){
            minigameData.win = true;
            minigameData.reward = "money";
            minigameData.amountReward = 5000;
            carro.SetActive(true);
        }
        else if(collision.gameObject.tag=="tubos_perf"){
            minigameData.win = true;
            minigameData.reward = "unpackageSteel";
            minigameData.amountReward = 400;
            tubos_perf.SetActive(true);
        }
        else if(collision.gameObject.tag=="resorte"){
            minigameData.win = true;
            minigameData.reward = "unpackageSteel";
            minigameData.amountReward = 400;
            resorte.SetActive(true);
        }
        else if(collision.gameObject.tag=="barra"){
            minigameData.reward = "packagedSteel";
            minigameData.amountReward = 600;
            barra.SetActive(true);
        }
        else if(collision.gameObject.tag=="barril"){
            minigameData.win = true;
            minigameData.amountReward = 3000;
            minigameData.reward = "money";
            barril.SetActive(false);
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        mineria.SetActive(false);
        RD.SetActive(false);
        HAE.SetActive(false);
        chatarra.SetActive(false);
        puerto.SetActive(false);
        AHorno.SetActive(false);
        CBOF.SetActive(false);
        CCD.SetActive(false);
        CD.SetActive(false);
        CCP.SetActive(false);
        CCDD.SetActive(false);
        LPL.SetActive(false);
        LC.SetActive(false);
        BB.SetActive(false);
        LF.SetActive(false);
        estañado.SetActive(false);
        Electro.SetActive(false);
        Prepintado.SetActive(false);
        BC.SetActive(false);
        BGC.SetActive(false);
        BE.SetActive(false);
        Plata.SetActive(false);
        Rojo.SetActive(false);
        pftp.SetActive(false);
        alambron.SetActive(false);
        varillas.SetActive(false);
        barril.SetActive(false);
    }
}
