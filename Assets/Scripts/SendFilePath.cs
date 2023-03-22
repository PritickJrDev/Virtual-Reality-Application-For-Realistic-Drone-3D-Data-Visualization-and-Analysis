using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SendFilePath : MonoBehaviour
{
    public static SendFilePath Instance;
    public InputField filePath;
    public InputField texturePath;
    public bool isObjectActive;
    string error = string.Empty;
    public Animator transitionAnim;
    public Texture2D newTexture;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ActivateObject()
    {
        if (!File.Exists(filePath.text) || !File.Exists(texturePath.text))
        {
            error = "File doesn't exist.";
        }
        else
        {
            error = string.Empty;
            isObjectActive = true;
            newTexture = FindObjectOfType<Explorer>().textureImage;
            StartCoroutine(LoadImportedScene());
           
        }
    }

    private void OnGUI()
    {
        if (!string.IsNullOrWhiteSpace(error))
        {
            GUI.color = Color.red;
            GUI.Box(new Rect(0, 64, 256 + 64, 32), error);
            GUI.color = Color.white;
        }
    }

    IEnumerator LoadImportedScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadSceneAsync("ImportedScene");
    }
}
