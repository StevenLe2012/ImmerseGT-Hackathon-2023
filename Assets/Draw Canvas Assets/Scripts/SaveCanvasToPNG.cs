using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

public class SaveCanvasToPNG : MonoBehaviour
{
    public GameObject debugCube;
    public RenderTexture rt;
    public InputActionProperty pressed;

    void Start()
    {
        pressed.action.performed += ctx => SaveTextureToPNG();
    }

    private void SaveTextureToPNG() {
        debugCube.GetComponent<MeshRenderer>().material.color = Color.red;
        byte[] bytes = toTexture2D(rt).EncodeToPNG();
        string path = Path.Combine(Application.persistentDataPath, "NewSavedScreen.png");
        System.IO.File.WriteAllBytes(path, bytes);
        debugCube.GetComponent<MeshRenderer>().material.color = Color.green;
    }

     Texture2D toTexture2D(RenderTexture rTex)
    {
        Texture2D tex = new Texture2D(2048, 2048, TextureFormat.RGB24, false);
        RenderTexture.active = rTex;
        tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        tex.Apply();
        return tex;
    }
    
}
