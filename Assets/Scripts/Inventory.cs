using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{

    public GameObject items;
    private bool isItemsActive;
    public Button itemsButton;

    private void Start()
    {
        isItemsActive = false;
        items.SetActive(false);
    }

    public void ActivateItems()
    {
        if (isItemsActive)
        {
            itemsButton.GetComponentInChildren<TextMeshProUGUI>().text = "ITEMS OFF";
            isItemsActive = false;
            items.SetActive(false);
        }
        else if (!isItemsActive)
        {
            itemsButton.GetComponentInChildren<TextMeshProUGUI>().text = "ITEMS ON";
            isItemsActive = true;
            items.SetActive(true);

        }
    }
}
