using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultimodalUICanvas : MonoBehaviour
{
    private MultimodalUICanvas _previousUI;

    public void SetPrevious(MultimodalUICanvas prev)
    {
        _previousUI = prev;
    }

    private void OnDisable()
    {
        if (_previousUI != null)
        {
            _previousUI.gameObject.SetActive(true);
        }
    }
}
