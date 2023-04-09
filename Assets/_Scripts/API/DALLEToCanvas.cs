using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class DALLEToCanvas : MonoBehaviour
{

    private GameObject targetCanvas;
    private string[] prompts = {"Picasso painting of cat", "Van Gogh painting of cat", "landscape painting", "cute cat", "renaissance painting of cat", "still life painting", "cute puppy", "painting of fish riding a bicycle", "painting of cats swimming"};
    
    void Start()
    {
        LoadTextureFromDALLE(gameObject);
    }

    public void LoadTextureFromDALLE(GameObject canvas)
    {
        int randomIndex = Random.Range(0, prompts.Length);
        targetCanvas = canvas;
        DownloadPNGFromDALLE(prompts[randomIndex], randomIndex);
        // a monkey writing shakespear on the computer screen
    }

    private void DownloadPNGFromDALLE(string prompt, int promptIndex) {
        Debug.Log($"Sending prompt to DALLE: {prompt}");
        StartCoroutine(SendRequest(prompt, promptIndex));
    }

    IEnumerator SendRequest(string prompt, int promptIndex)
    {
        string url = "http://127.0.0.1:5000/api_call";
        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("Content-Type", "application/json");

        string requestData = "{\"request type\":\"dall-e generate challenge image\",\"request content\":\" + " + prompt + "\"}";
        byte[] requestDataBytes = Encoding.UTF8.GetBytes(requestData);

        WWW www = new WWW(url, requestDataBytes, headers);
        yield return www;
        GetComponent<Renderer>().material.color = Color.green;
        if (www.error == null)
        {
            Debug.Log("Request sent successfully: " + www.text);
            string jsonString = www.text;
            string pngURL = extract_url(jsonString.ToCharArray());
            StartCoroutine(DownloadAndSave(pngURL, promptIndex));
        }
        else
        {
            Debug.LogError("Request failed: " + www.error);
        }
    }

    IEnumerator DownloadAndSave(string pngURL, int promptIndex)
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
        
        string path = Path.Combine(Application.persistentDataPath, "DALLE" + promptIndex + ".png");
        // Save the PNG to disk using File.WriteAllBytes
        File.WriteAllBytes(path, request.downloadHandler.data);

        // Log success
        Debug.Log($"PNG downloaded and saved to {path}; Loading it to canvas now");
        LoadPNGToTexture(path);
    }

    private void LoadPNGToTexture(string imagePath) {
        byte[] imageData = File.ReadAllBytes(imagePath);
        Texture2D texture = new Texture2D(2048, 2048);
        texture.LoadImage(imageData);
        Material material = this.targetCanvas.GetComponent<MeshRenderer>().material;
        material.color = Color.white;
        material.mainTexture = texture;

        // rotate the canvas locally by 180 degrees by y axis for offset
        this.targetCanvas.transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self); 
    }

        // Stupid stuff that you wrote at a desperate hackathon night :)
    string extract_url(char[] charArray) {
        // Remove the first 11 elements
        charArray = RemoveFirstNElements(charArray, 12);

        // Remove the last 4 elements
        charArray = RemoveLastNElements(charArray, 4);

        // Convert the char[] array to a string
        string myString = new string(charArray);
        Debug.Log("Extracted URL:" + myString);
        return myString;
    }

        // Removes the first n elements from a char[] array
    private char[] RemoveFirstNElements(char[] array, int n)
    {
        char[] result = new char[array.Length - n];
        for (int i = n; i < array.Length; i++)
        {
            result[i - n] = array[i];
        }
        return result;
    }

    // Removes the last n elements from a char[] array
    private char[] RemoveLastNElements(char[] array, int n)
    {
        char[] result = new char[array.Length - n];
        for (int i = 0; i < array.Length - n; i++)
        {
            result[i] = array[i];
        }
        return result;
    }
}
