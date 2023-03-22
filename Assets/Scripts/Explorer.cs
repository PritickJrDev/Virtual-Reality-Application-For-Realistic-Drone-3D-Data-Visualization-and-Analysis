using UnityEngine;
using UnityEngine.UI;
using SmartDLL;
using System.IO;

public class Explorer : MonoBehaviour
{
    public InputField filePath;
    public InputField fileTexturePath;
    public Texture2D textureImage;
    byte[] fileData;
    bool readTexture, readObj;
    public Button openExplorerButton;
    public Button openTextureButton;
    public SmartFileExplorer fileExplorer = new SmartFileExplorer();

    private void OnEnable()
    {
        openExplorerButton.onClick.AddListener(delegate { ShowExplorer(); });
        openTextureButton.onClick.AddListener(delegate { ShowTexture(); });
    }

    private void Update()
    {
        if (fileExplorer.resultOK && readObj)
        {
            filePath.text = fileExplorer.fileName;
            readObj = false;
        }

        if (fileExplorer.resultOK && readTexture)
        {
            ReadTexture(fileExplorer.fileName);
            fileTexturePath.text = fileExplorer.fileName;
            readTexture = false;
        }
    }

    void ShowExplorer()
    {
        string initialDir = @"C:\";
        bool restoreDir = true;
        string title = "Open a Obj File";
        string defExt = "obj";
        string filter = "obj files (*.obj) | *.obj";

        fileExplorer.OpenExplorer(initialDir, restoreDir, title, defExt, filter);
        readObj = true;
    }

    void ShowTexture()
    {
        string initialDir = @"C:\";
        bool restoreDir = true;
        string title = "Open a Texture File";
        string defExt = "obj";
        string filter = "Texture files (*.jpeg) | *.jpeg";

        fileExplorer.OpenExplorer(initialDir, restoreDir, title, defExt, filter);
        readTexture = true;
    }

    void ReadTexture(string path)
    {
        fileData = File.ReadAllBytes(path);
        textureImage = new Texture2D(2, 2);
        textureImage.LoadImage(fileData);
    }
}
