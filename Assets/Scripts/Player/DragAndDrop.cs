using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public float yHeight = 0.1f;
    public PointSystem pointSystem;
    Plane plane;
    float distance;

    //Variables para mover edificios y carreteras en forma de malla
    double compareX;
    double compareZ;

    int wholeX;
    int wholeZ;

    double positionX;
    double positionZ;


    private void Start()
    {
        plane = new Plane (Vector3.up, new Vector3(0, yHeight,0));
    }

    void Update(){
        if(Input.GetMouseButtonUp(0)){
            StartCoroutine(setBuildingDown());
        }
        
    }

    private IEnumerator setBuildingDown(){
        yield return new WaitForSeconds(0.1f);

        Vector3 lastPos = transform.position;
        lastPos.y = 0.01f;

        wholeX = (int)lastPos.x;
        wholeZ = (int)lastPos.z;


        compareX = 0.5;
        compareZ = 0.5;

        if(lastPos.x < 0){
            compareX = -0.5;
        }
        if(lastPos.z < 0){
            compareZ = -0.5;
        }
        
        positionX = wholeX + compareX;
        positionZ = wholeZ + compareZ;

        lastPos.x = (float)positionX;
        lastPos.z = (float)positionZ;
        
        transform.position = lastPos;
        pointSystem.checkBuildingPosition = true;
    }
    void OnMouseDrag(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(plane.Raycast(ray, out distance))
        {
            transform.position = ray.GetPoint(distance);
        }

        if(Input.GetButtonUp("Fire2")){
            transform.Rotate(0f, 90f,0);
        }
    }
}
