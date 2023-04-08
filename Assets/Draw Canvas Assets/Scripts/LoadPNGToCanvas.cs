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
        debugCube.GetComponent<MeshRenderer>().material.color = Color.red;
        byte[] imageData = File.ReadAllBytes(imagePath);
        debugCube.GetComponent<MeshRenderer>().material.color = Color.green;
        Texture2D texture = new Texture2D(2048, 2048);
        texture.LoadImage(imageData);
        Material material = GetComponent<MeshRenderer>().material;
        material.mainTexture = texture;

        // rotate the canvas locally by 180 degrees by y axis for offset
        transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self); 
    }
}
