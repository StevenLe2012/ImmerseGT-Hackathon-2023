using UnityEngine;

public class MeshController : MonoBehaviour
{
    // [SerializeField] public MeshRenderer meshRenderer;
    [SerializeField] public GameObject prefabCanvas;

    public void ResetMeshRenderer()
    {
        GameObject prefabObject = GameObject.Find("Draw Canvas");
        var oldPosition = prefabObject.transform.position;
        var oldRotation = prefabObject.transform.rotation;
        DestroyImmediate(prefabObject);
        
        // Instantiate a new instance of the prefab
        GameObject newPrefabInstance = Instantiate(prefabCanvas) as GameObject;
        newPrefabInstance.transform.position = oldPosition;
        newPrefabInstance.transform.rotation = oldRotation;
    }
}