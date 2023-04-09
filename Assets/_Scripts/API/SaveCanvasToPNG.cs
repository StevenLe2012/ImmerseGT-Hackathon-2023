using System.IO;
using UnityEngine;

public class SaveCanvasToPNG : MonoBehaviour
{
    public RenderTexture rt;

    public void SaveTextureToPNG() {
        byte[] bytes = toTexture2D(rt).EncodeToPNG();
        string path = Path.Combine(Application.persistentDataPath, "UserSketch.png");
        System.IO.File.WriteAllBytes(path, bytes);
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
