using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class WristMenu : MonoBehaviour
{
    public GameObject leftWrist;
    public bool activeWrist = true;
    public Animator transitionAnim;

    private void Start()
    {
        //activeWrist = true;
        DisplayWrist();
    }

    //back button for scene 3
    public void MainMenu()
    {
        //SceneManager.LoadScene(0);
        StartCoroutine(LoadMainMenu());
    }

    public void MenuPressed(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            DisplayWrist();
        }
    }

    public void DisplayWrist()
    {
        if(activeWrist)
        {
            leftWrist.SetActive(false);
            activeWrist = false;
        }
        else if(!activeWrist)
        {
            leftWrist.SetActive(true);
            activeWrist = true;
        }
    }

    IEnumerator LoadMainMenu()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(0);
    }
}
