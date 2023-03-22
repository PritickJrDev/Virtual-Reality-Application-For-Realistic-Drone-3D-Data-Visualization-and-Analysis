using Dummiesman;
using System.IO;
using UnityEngine;

public class ObjFromFile : MonoBehaviour
{
    string objPath = string.Empty;
    string error = string.Empty;
    GameObject loadedObject;
    public Shader defaultShader;
    public Shader shader1;
    public Shader shader2;
    public Shader shader3;
    public Shader shader4;
    public Texture meshTexture;

    void OnGUI() {
        objPath = SendFilePath.Instance.filePath.text;
        meshTexture = SendFilePath.Instance.newTexture;
       
        if (SendFilePath.Instance.isObjectActive)
        {
            //file path
            if (!File.Exists(objPath))
            {
                error = "File doesn't exist.";
            }
            else
            {
                if (loadedObject != null)
                    Destroy(loadedObject);
                loadedObject = new OBJLoader().Load(objPath);
                MeshRenderer renderer = loadedObject.GetComponentInChildren<MeshRenderer>();
                renderer.material = new Material(defaultShader);
                renderer.material.mainTexture = meshTexture;
                SceneTransform();
                error = string.Empty;
                SendFilePath.Instance.isObjectActive = false;
            }
        }
        if(!string.IsNullOrWhiteSpace(error))
        {
            GUI.color = Color.red;
            GUI.Box(new Rect(0, 64, 256 + 64, 32), error);
            GUI.color = Color.white;
        }
    }

    void SceneTransform()
    {
        //resize transform, add shaders, and reset camera //todolist
        loadedObject.transform.position = new Vector3(0, 5.98f, 0);
        loadedObject.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        loadedObject.transform.rotation = Quaternion.Euler(new Vector3(-90.00001f, 0, 0));
    }

    public void DefaultShader()
    {
        MeshRenderer renderer = loadedObject.GetComponentInChildren<MeshRenderer>();
        renderer.material = new Material(defaultShader);
        renderer.material.mainTexture = meshTexture;
    }
    public void ShaderOne()
    {
        MeshRenderer renderer = loadedObject.GetComponentInChildren<MeshRenderer>();
        renderer.material = new Material(shader1);
        renderer.material.mainTexture = meshTexture;
    }
    public void ShaderTwo()
    {
        MeshRenderer renderer = loadedObject.GetComponentInChildren<MeshRenderer>();
        renderer.material = new Material(shader2);
        renderer.material.mainTexture = meshTexture;
    }

    public void ShaderThree()
    {
        MeshRenderer renderer = loadedObject.GetComponentInChildren<MeshRenderer>();
        renderer.material = new Material(shader3);
        renderer.material.mainTexture = meshTexture;
    }

    public void ShaderFour()
    {
        MeshRenderer renderer = loadedObject.GetComponentInChildren<MeshRenderer>();
        renderer.material = new Material(shader4);
        renderer.material.mainTexture = meshTexture;
    }
}
