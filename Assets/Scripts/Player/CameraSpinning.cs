using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpinning : MonoBehaviour
{
    private float spinningSpeed = 0.03f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, spinningSpeed, 0);
    }
}
