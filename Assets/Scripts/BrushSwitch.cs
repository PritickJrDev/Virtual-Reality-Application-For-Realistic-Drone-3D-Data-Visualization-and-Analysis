using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BrushSwitch : MonoBehaviour
{
    public GameObject brush;
    private bool isBrushActive;
    public Button brushButton;

    private void Start()
    {
        isBrushActive = false;
        brush.SetActive(false);
    }

    public void ActivateBrush()
    {
        if(isBrushActive)
        {
            //lightButton.GetComponentInChildren<TextMeshProUGUI>().text = "NIGHT TIME";
            brushButton.GetComponentInChildren<TextMeshProUGUI>().text = "MARKING OFF";
            isBrushActive = false;
            brush.SetActive(false);
        }
        else if(!isBrushActive)
        {
            brushButton.GetComponentInChildren<TextMeshProUGUI>().text = "MARKING ON";
            isBrushActive = true;
            brush.SetActive(true);

        }
    }


}
