using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class DALLEToCanvas : MonoBehaviour
{
    public void LoadTextureFromDALLE(GameObject canvas, string promptID, string prompt)
    {
        // a monkey writing shakespear on the computer screen
    }

    private void DownloadPNGFromDALLE(string prompt) {
        StartCoroutine(SendRequest(prompt));
    }

    IEnumerator SendRequest(string prompt)
    {
        string url = "http://127.0.0.1:5000/api_call";
        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("Content-Type", "application/json");

        string requestData = "{\"request type\":\"dall-e generate challenge image\",\"request content\":\" " + prompt + "  \"}";
        byte[] requestDataBytes = Encoding.UTF8.GetBytes(requestData);

        WWW www = new WWW(url, requestDataBytes, headers);
        yield return www;

        if (www.error == null)
        {
            Debug.Log("Request sent successfully: " + www.text[0]);
            string jsonString = "{\"image_url\": \"url_val\"}";
            Dictionary<string, string> dict = JsonUtility.FromJson<Dictionary<string, string>>(jsonString);
            string url_val = dict["image_url"];
            DownloadAndSave(url_val);
        }
        else
        {
            Debug.LogError("Request failed: " + www.error);
        }
    }

    IEnumerator DownloadAndSave(string pngURL)
    {
        Debug.Log($"Downloading PNG from {pngURL}");
        // Create a UnityWebRequest to download the PNG
        UnityWebRequest request = UnityWebRequest.Get(pngURL);

        // Wait for the request to finish
        yield return request.SendWebRequest();

        // Check for errors
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError($"Failed to download PNG: {request.error}");
            yield break;
        }
        
        string path = Path.Combine(Application.persistentDataPath, "DALLE1.png");
        // Save the PNG to disk using File.WriteAllBytes
        File.WriteAllBytes(path, request.downloadHandler.data);

        // Log success
        Debug.Log($"PNG downloaded and saved to {path}");
    }

    private void LoadPNGToTexture(GameObject canvas, string promptID) {
        string imagePath = Path.Combine(Application.persistentDataPath, "DALLE" + promptID +".png");
        byte[] imageData = File.ReadAllBytes(imagePath);
        Texture2D texture = new Texture2D(2048, 2048);
        texture.LoadImage(imageData);
        Material material = canvas.GetComponent<MeshRenderer>().material;
        material.mainTexture = texture;

        // rotate the canvas locally by 180 degrees by y axis for offset
        canvas.transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self); 
    }
}
