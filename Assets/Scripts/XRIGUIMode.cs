using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class XRIGUIMode : MonoBehaviour
{
    public RawImage background;
    public Button lightButton;
    public Button shaderButton;
    public GameObject shaderPanel;
    public Slider distanceSlider;
    public TextMeshProUGUI fontText;
    public Button creditButton;
    public ScrollRect creditInfo;
    public Material skyMaterial;
    public Toggle alphaToggle;

    public Light light;
    public GameObject querry;
    public Material dayMat;
    public Material nightMat;

    private string mainMenuSceneName = "MainMenu";
    public Animator transitionAnim;

    public Camera myCamera;
    public Shader defaultShader;
    public Shader shader1;
    public Shader shader2;
    public Shader shader3;
    public Shader shader4;
    public GameObject pointCloudMesh;
    public Texture texture;

    void Start()
    {
   
        shaderButton.onClick.AddListener(() =>
        {
            shaderPanel.gameObject.SetActive(!shaderPanel.gameObject.activeSelf);
            shaderButton.GetComponentInChildren<TextMeshProUGUI>().text = shaderPanel.gameObject.activeSelf ?
            "SHADER ON" : "SHADER OFF";
        });

        lightButton.onClick.AddListener(() =>
        {
            
            if(skyMaterial.GetFloat("_Exposure") > 0)
            {
                skyMaterial.SetFloat("_Exposure", 0);
                lightButton.GetComponentInChildren<TextMeshProUGUI>().text = "NIGHT TIME";
                light.intensity = 0.5f;
                //clouds.GetComponent<Renderer>().material.color = Color.blue;
                querry.GetComponent<Renderer>().material.color = Color.gray;
                RenderSettings.skybox = nightMat;
            }
            else
            {
                skyMaterial.SetFloat("_Exposure", 1.3f);
                lightButton.GetComponentInChildren<TextMeshProUGUI>().text = "DAY TIME";
                light.intensity = 1;
                querry.GetComponent<Renderer>().material.color = Color.white;
                RenderSettings.skybox = dayMat;
            }
        });

        alphaToggle.onValueChanged.AddListener((value) =>
        {
            Color currColor = background.color;
            currColor.a = value ? 0.7f : 0;
            background.color = currColor;
        });

        distanceSlider.onValueChanged.AddListener((value) =>
        {
            myCamera.farClipPlane = value;
            fontText.text = $"VIEW DISTANCE: {value}";
        });
    }
    public void LoadMainMenuScene()
    {
        StartCoroutine(LoadFirstScene());
    }

    IEnumerator LoadFirstScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(mainMenuSceneName);

    }
    public void DefaultShader()
    {
        Renderer renderer = pointCloudMesh.GetComponent<Renderer>();
        renderer.material = new Material(defaultShader);
        renderer.material.mainTexture = texture;
    }
    public void ShaderOne()
    {
        Renderer renderer = pointCloudMesh.GetComponent<Renderer>();
        renderer.material = new Material(shader1);
        renderer.material.mainTexture = texture;
    }
    public void ShaderTwo()
    {
        Renderer renderer = pointCloudMesh.GetComponent<Renderer>();
        renderer.material = new Material(shader2);
        renderer.material.mainTexture = texture;
    }

    public void ShaderThree()
    {
        Renderer renderer = pointCloudMesh.GetComponent<Renderer>();
        renderer.material = new Material(shader3);
        renderer.material.mainTexture = texture;
    }

    public void ShaderFour()
    {
        Renderer renderer = pointCloudMesh.GetComponent<Renderer>();
        renderer.material = new Material(shader4);
        renderer.material.mainTexture = texture;
    }

    public void PointCloud()
    {
           string pointCloudScene = "PointCloud1";
        StartCoroutine(LoadPointCloudScene(pointCloudScene));

    }
    IEnumerator LoadPointCloudScene(string pointCloudScene)
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(pointCloudScene);
    }
}
