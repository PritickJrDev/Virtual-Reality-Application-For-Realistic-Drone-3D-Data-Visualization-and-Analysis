using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Rotator : MonoBehaviour
{
    public bool isRotate;
    public Vector3 speed;

    // Update is called once per frame
    void Update()
    {
        if (isRotate) 
            transform.Rotate(speed * Time.deltaTime, Space.World);
            
    }

    public void StartRotation()
    {
        isRotate = true;
    }

    public void StopRotation()
    {
        isRotate = false;
    }
}
