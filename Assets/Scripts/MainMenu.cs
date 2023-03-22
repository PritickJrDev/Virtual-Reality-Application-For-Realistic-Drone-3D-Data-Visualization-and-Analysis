using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private string texturedSceneName = "VRScene";
    public Animator transitionAnim;
    public GameObject textRotator;
    public Vector3 x;
    public void SwitchOFF()
    {
        Debug.Log("Switched off");
        Application.Quit();
    }

    public void LoadTexturedScene()
    {
        StartCoroutine(LoadFirstScene());
    }

    IEnumerator LoadFirstScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(texturedSceneName);

    }

    private void Update()
    {
        textRotator.transform.Rotate(x * Time.deltaTime, Space.World);
    }

}
