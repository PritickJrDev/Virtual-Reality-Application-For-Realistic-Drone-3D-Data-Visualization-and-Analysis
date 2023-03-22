using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ArrowMovement : MonoBehaviour
{

    public Transform arrowPosition;
    public float moveSpeed;
    public GameObject arrow;
    public bool isActive = false;
    public TextMeshProUGUI arrowButton;
    public GameObject leftRay;

    public XRNode inputSource;
    public InputHelpers.Button inputButton;
    public float inputThreshold = 0.1f;

    void FixedUpdate()
    {
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource), inputButton, out bool isPressed, inputThreshold);
        if (Input.GetKey(KeyCode.W) && isActive || isPressed)
        {
            transform.Translate(arrowPosition.forward * Time.deltaTime * moveSpeed, Space.World);
            leftRay.GetComponent<XRRayInteractor>().maxRaycastDistance = 0;
            arrow.SetActive(true);
        }
        else
        {
            leftRay.GetComponent<XRRayInteractor>().maxRaycastDistance = 10;
            arrow.SetActive(false);
        }
    }

    public void ActivateArrow()
    {
        if (isActive)
        {
            arrowButton.text = "ARROW OFF";
            isActive = false;
        } 
        else if (!isActive)
        {
            arrowButton.text = "ARROW ON";
            isActive = true;
        }
    }
}
