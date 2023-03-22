using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KeyDetector : MonoBehaviour
{
    private TextMeshPro playerTextOutput;
    public GameObject controllerPrefab;
    bool isActive;
    private void Start()
    {
        playerTextOutput = GameObject.FindGameObjectWithTag("PlayerTextOutput").GetComponent<TextMeshPro>();//<TextMeshPro>();
        controllerPrefab.GetComponent<XRBaseController>().model.gameObject.SetActive(false);
        controllerPrefab.GetComponent<XRRayInteractor>().maxRaycastDistance = 0;

    }
    private void OnTriggerEnter(Collider other)
    {
        var key = other.GetComponentInChildren<TextMeshPro>();
        
        if (key != null)
        {
            var keyboardUI = other.gameObject.GetComponent<KeyboardUI>();

            if (keyboardUI.keyCanBeHitAgain)
            {
                if (key.text == "SPACE")
                {
                    playerTextOutput.text += " ";
                }
                else if (key.text == "<--")
                {
                    playerTextOutput.text = playerTextOutput.text.Substring(0, playerTextOutput.text.Length - 1);
                }
                else if (key.text == "Ray" && isActive)
                {
                    controllerPrefab.GetComponent<XRBaseController>().model.gameObject.SetActive(false);
                    controllerPrefab.GetComponent<XRRayInteractor>().maxRaycastDistance = 0;
                    isActive = false;
                }
                else if(key.text == "Ray" && !isActive)
                {
                    controllerPrefab.GetComponent<XRBaseController>().model.gameObject.SetActive(true);
                    controllerPrefab.GetComponent<XRRayInteractor>().maxRaycastDistance = 10;
                    isActive = true;
                }
                else
                {
                    playerTextOutput.text += key.text;
                }
                keyboardUI.keyHit = true;
            }
        }
    }
}
