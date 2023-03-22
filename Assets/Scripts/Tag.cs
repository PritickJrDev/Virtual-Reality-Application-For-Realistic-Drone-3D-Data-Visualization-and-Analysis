using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tag : MonoBehaviour
{
    private TextMeshPro playerTextOutput;
    public TextMeshPro tagText;

    void Start()
    {
        playerTextOutput = GameObject.FindGameObjectWithTag("PlayerTextOutput").GetComponent<TextMeshPro>();
    }

    public void AddTag()
    {
        tagText.text = playerTextOutput.text;
        playerTextOutput.text = null;
    }
}
