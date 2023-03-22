using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Paint : MonoBehaviour
{
    public XRNode inputSource;
    public InputHelpers.Button inputButton;
    public float inputThreshold = 0.1f;
    public Transform movementSource;
    public float newPositionThresholdDistance = 0.05f;
    public GameObject brushPrefab;

    private bool isMoving = false;
    private List<Vector3> positionList = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started");
    }

    // Update is called once per frame
    void Update()
    {
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource), inputButton, out bool isPressed, inputThreshold);
        if (Input.GetKey(KeyCode.Mouse0))
        {
            isPressed = true;
        }
        else
        {
            isPressed = false;
        }

        //Start the movement
        if(!isMoving && isPressed)
        {
            StartMovement();
        }
        //Ending the movement
        else if(isMoving && !isPressed)
        {
            EndMovement();
        }
        //updating the movement
        else if(isMoving && isPressed)
        {
            UpdateMovement();
        }
    }

    void StartMovement()
    {
        isMoving = true;
        positionList.Clear();
        positionList.Add(movementSource.position);

        if (brushPrefab)
            Instantiate(brushPrefab, movementSource.position, Quaternion.identity);
    }

    void EndMovement()
    {
        isMoving = false;
    }

    void UpdateMovement()
    {
        Vector3 lastPositon = positionList[positionList.Count - 1];
        if (Vector3.Distance(movementSource.position, lastPositon) > newPositionThresholdDistance)
        {
            positionList.Add(movementSource.position);
            if (brushPrefab)
                Instantiate(brushPrefab, movementSource.position, Quaternion.identity);
        }
    }   
}
