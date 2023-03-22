using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomTeleportSwtich : MonoBehaviour
{
    public GameObject teleportPrefab;
    private bool isActive;
    public TextMeshProUGUI teleportButton;

    public void ActivateTeleportObject()
    {
        if(isActive)
        {
            teleportPrefab.SetActive(false);
            teleportButton.text = "TELEPORTATION OFF";
            isActive = false;
        }
        else if (!isActive)
        {
            teleportPrefab.SetActive(true);
            teleportButton.text = "TELEPORTATION ON";
            isActive = true;
        }
    }
}
