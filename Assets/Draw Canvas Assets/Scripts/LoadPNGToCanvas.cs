using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

public class LoadPNGToCanvas : MonoBehaviour
{
    public GameObject debugCube;
    public InputActionProperty pressed;

    void Start()
    {
        LoadPNGToNormalTexture();
        // pressed.action.performed += ctx => LoadToCanvas();
    } 

    private void LoadPNGToNormalTexture() {
        string imagePath = Path.Combine(Application.persistentDataPath, "NewSavedScreen.png");
        byte[] imageData = File.ReadAllBytes(imagePath);
        Texture2D texture = new Texture2D(2048, 2048);
        texture.LoadImage(imageData);
        // for (int y = 0; y < texture.height; y++) {
        //     for (int x = 0; x < texture.width / 2; x++) {
        //         Color temp = texture.GetPixel(x, y);
        //         texture.SetPixel(x, y, texture.GetPixel(texture.width - x - 1, y));
        //         texture.SetPixel(texture.width - x - 1, y, temp);
        //     }
        // }
        // texture.Apply();
        Material material = GetComponent<MeshRenderer>().material;
        material.mainTexture = texture;

        // rotate the canvas locally by 180 degrees by y axis for offset
        // transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self); 
    }
}
