using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class HTTPTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SendPrompt());
    }

    IEnumerator SendPrompt()
    {
        string url = "http://127.0.0.1:5000/api_call";
        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("Content-Type", "application/json");

        string requestData = "{\"request type\":\"dall-e generate challenge image\",\"request content\":\"a monkey writing shakespear on the computer screen\"}";
        byte[] requestDataBytes = Encoding.UTF8.GetBytes(requestData);

        WWW www = new WWW(url, requestDataBytes, headers);
        yield return www;
        GetComponent<Renderer>().material.color = Color.green;
        if (www.error == null)
        {
            Debug.Log("Request sent successfully: " + www.text);
            string jsonString = www.text;
            string pngURL = extract_url(jsonString.ToCharArray());
            StartCoroutine(DownloadAndSave(pngURL));
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

    void displayAsChar(string badValue)
    {
        char[] values = badValue.ToCharArray();
        for (int i = 0; i < values.Length; i++)
        {
            string tempResult = "Value at index " + i + " is: " + values[i];
            Debug.Log(tempResult);
        }
    }
}
