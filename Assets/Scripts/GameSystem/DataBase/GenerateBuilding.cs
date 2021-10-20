using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GenerateBuilding : MonoBehaviour , IPointerDownHandler , IPointerUpHandler
{
    //Variables de objetos
    public Player player;
    public GameObject newBuild;
    public string tagName;
    public int costBuilding;
    private GameObject dragBuildObject;
    public PointSystem pointSystem;
    
    //Permite drag and drop
    float distance;
    Plane plane;
    float yHeight = 0.1f;
    float time;

    //Variables para ver si se genero un nuevo edificio 
    bool isThereNewBuilding = false;
    private bool pointerDown;

    //Funcion que detecta cuando el mouse presiona el boton
    public void OnPointerDown(PointerEventData eventData){
        pointerDown = true;
        //Revisa si hay suficiente dinero
        if(player.scoreMoney >= costBuilding){
            //Genera un nuevo edificio y lo pone en una variable
            dragBuildObject = generateNewBuilding();
            player.scoreMoney -= costBuilding;
            isThereNewBuilding = true;
        }
    }

    //Funcion que detecta cuando suelta el mouse del edificio generado
    public void OnPointerUp(PointerEventData eventData){
        pointerDown = false;
        //Si genero un nuevo edificio y lo solto, le pone un tag para generar recursos
        if(isThereNewBuilding == true){
            dragBuildObject.tag = tagName;
            isThereNewBuilding = false;
            pointSystem.checkBuilding();
            pointSystem.checkBuildingPosition = true;
        }
    }


    void Start(){
        plane = new Plane(Vector3.up, new Vector3(0, yHeight, 0));
        
    }

    private void Update(){
        //Funcion que permite al nuevo objeto solamente para arrastrar en el mapa
        if(pointerDown){
            if(isThereNewBuilding == true){
                DragBuild(dragBuildObject);
            }
        }
        
    }

    public GameObject generateNewBuilding(){        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        GameObject newBuilding = Instantiate(newBuild, ray.GetPoint(distance), transform.rotation);
        assignDefault(newBuilding);
        return newBuilding;
    }

    void DragBuild(GameObject dragBuildObject){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(plane.Raycast(ray, out distance)){
            dragBuildObject.transform.position = ray.GetPoint(distance);
        }

        if(Input.GetButtonUp("Fire2")){
            dragBuildObject.transform.Rotate(0f, 90f,0);
        }
    }

    void assignDefault(GameObject newBuilding){
        if(tagName == "SalesGenerator"){
            newBuilding.GetComponent<salesBuilding>().defaultValues();
        }
        else if(tagName == "IronGenerator"){
            newBuilding.GetComponent<IronBuilding>().defaultValues();
        }
        else if(tagName == "PackageGenerator"){
            newBuilding.GetComponent<packageBuilding>().defaultValues();
        }
        else if(tagName == "EnergyGenerator"){
            newBuilding.GetComponent<energyBuilding>().defaultValues();
        }
        else if(tagName == "FurnaceGenerator"){
            newBuilding.GetComponent<furnaceBuilding>().defaultValues();
        }
        else{
            newBuilding.GetComponent<streetBuilding>().defaultValues();
        }
    }

    
}
