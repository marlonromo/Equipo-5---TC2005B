using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Camera cameraMain;
    public Transform cameraParent;

    float horizontal, vertical, scrollwheel;
    [SerializeField][Range(1, 8)]public float cameraSpeed;
    public bool enableMove = true;

    private Quaternion m_cameraRotation, m_cameraParent;

    [SerializeField][Range(1, 8)]
    public float mouseSensibilityX = 4f;

    [SerializeField][Range(1, 8)]
    public float mouseSensibilityY = 4f;

    [SerializeField]
    private bool HideTheCursor;

    void Start(){
        cameraMain = GetComponent<Camera>();
        m_cameraRotation = transform.localRotation;
        m_cameraParent = cameraParent.localRotation;
        if(HideTheCursor){
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Application.targetFrameRate = 60;
        }
    }

    void Update(){
        if(enableMove){
            if(Input.GetButton("Fire2")){
                SetRotation();
            }
            MoveCamera();
        }
        
        
    }
    void SetRotation(){
        m_cameraRotation *= Quaternion.Euler(-Input.GetAxis("Mouse Y") * mouseSensibilityX, 0f, 0f);
        m_cameraParent *= Quaternion.Euler(0f, Input.GetAxis("Mouse X") * mouseSensibilityY, 0f);

        transform.localRotation = m_cameraRotation;
        cameraParent.localRotation = m_cameraParent;
    }

    void MoveCamera(){
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        scrollwheel = Input.GetAxis("Mouse ScrollWheel");
        cameraParent.transform.Translate(horizontal*cameraSpeed*Time.deltaTime, 0f, vertical*cameraSpeed*Time.deltaTime);

        cameraParent.transform.position += cameraMain.transform.forward * scrollwheel * cameraSpeed * Time.deltaTime * 150;
    }
}
