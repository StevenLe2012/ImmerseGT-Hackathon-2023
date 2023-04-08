using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Threading.Tasks;

namespace OpenAI
{
    public class GenerateImg : MonoBehaviour
    {
        private OpenAIApi openai = new OpenAIApi();
        //public GameObject quad;
        //private MeshRenderer m_Renderer;
        public Material m;

        private string[] prompts = {"Picasso painting of cat", "Van Gogh painting of cat", "landscape painting", "cute cat", 
    "renaissance painting of cat", "still life painting", "cute puppy", "painting of fish riding a bicycle", "painting of cats swimming"};
    
        void Start()
        {
            //m_Renderer = quad.GetComponent<MeshRenderer> ();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0)) {
                int ind = Random.Range(0, prompts.Length);
                //string prompt = "watermelon";
                SendImageRequest(prompts[ind]);
            }
        }

        private async void SendImageRequest(string prompt)
        {
            var response = await openai.CreateImage(new CreateImageRequest
            {
                Prompt = prompt,
                Size = ImageSize.Size256
            });

            if (response.Data != null && response.Data.Count > 0)
            {
                using(var request = new UnityWebRequest(response.Data[0].Url))
                {
                    request.downloadHandler = new DownloadHandlerBuffer();
                    request.SetRequestHeader("Access-Control-Allow-Origin", "*");
                    request.SendWebRequest();

                    while (!request.isDone) await Task.Yield();

                    Texture2D texture = new Texture2D(1, 1);
                    texture.LoadImage(request.downloadHandler.data);
                    //var sprite = Sprite.Create(texture, new Rect(0, 0, 256, 256), Vector2.zero, 1f);
                    //image.sprite = sprite;

                    //m_Renderer.material.SetTexture("_MainTex", texture);
                    m.SetTexture("_BaseMap", texture);
                    Debug.Log("meow");
                }
            }
            else
            {
                Debug.LogWarning("No image was created from this prompt.");
            }
        }
    }
}
