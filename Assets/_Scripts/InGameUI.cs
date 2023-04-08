using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private MultimodalUICanvas mainUICanvas;

    private MultimodalUICanvas[] _childrenCanvases;
    void Start()
    {
        _childrenCanvases = GetComponentsInChildren<MultimodalUICanvas>();
        foreach (var childCanvas in _childrenCanvases)
        {
            childCanvas.gameObject.SetActive(false);
        }
    }

    public void ToggleMainUI()
    {
        mainUICanvas.gameObject.SetActive(!mainUICanvas.gameObject.activeSelf);
    }
}
