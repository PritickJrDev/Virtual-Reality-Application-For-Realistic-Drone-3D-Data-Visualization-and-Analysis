using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class KeyboardSwitch : MonoBehaviour
{

    public GameObject keyboard;
    public GameObject drumStick1;
    public GameObject drumStick2;
    public Transform keyboardSpawnPoint;

    private bool isKeyboardActive;
    public Button keyboardButton;

    private void Start()
    {

        isKeyboardActive = false;
        keyboard.SetActive(false);
        drumStick1.SetActive(false);
        drumStick2.SetActive(false);
    }

    public void ActivateVirtualKeyboard()
    {
        if (isKeyboardActive)
        {
            //lightButton.GetComponentInChildren<TextMeshProUGUI>().text = "NIGHT TIME";
            keyboardButton.GetComponentInChildren<TextMeshProUGUI>().text = "VIRTUAL KEYBOARD OFF";
            isKeyboardActive = false;
            keyboard.SetActive(false);
            drumStick1.SetActive(false);
            drumStick2.SetActive(false);
        }
        else if (!isKeyboardActive)
        {
            keyboardButton.GetComponentInChildren<TextMeshProUGUI>().text = "VIRTUAL KEYBOARD ON";
            isKeyboardActive = true;
            keyboard.SetActive(true);
            drumStick1.SetActive(true);
            drumStick2.SetActive(true);
            keyboard.transform.position = keyboardSpawnPoint.position;
        }
    }
}
