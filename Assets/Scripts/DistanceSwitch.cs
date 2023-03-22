using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DistanceSwitch : MonoBehaviour
{
    public GameObject measureTool;
    public GameObject measureCanvas;
    private bool isToolActive;
    public Button toolButton;

    private void Start()
    {
        isToolActive = false;
        measureTool.SetActive(false);
        measureCanvas.SetActive(false);
    }

    public void ActivateTools()
    {
        if (isToolActive)
        {
            //lightButton.GetComponentInChildren<TextMeshProUGUI>().text = "NIGHT TIME";
            toolButton.GetComponentInChildren<TextMeshProUGUI>().text = "TOOL OFF";
            isToolActive = false;
            measureTool.SetActive(false);
            measureCanvas.SetActive(false);
        }
        else if (!isToolActive)
        {
            toolButton.GetComponentInChildren<TextMeshProUGUI>().text = "TOOL ON";
            isToolActive = true;
            measureTool.SetActive(true);
            measureCanvas.SetActive(true);

        }
    }
}
