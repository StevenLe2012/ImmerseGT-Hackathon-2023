using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BrushScaling : MonoBehaviour
{
    [SerializeField] private Slider scaleSlider;
    [SerializeField] private TMP_Text textArea;

    private float scaleSliderValue;
    private GameObject brushProvider;

    public void DetectBrush()
    {
        brushProvider = GameObject.FindGameObjectWithTag("Marker");
        textArea.text = "Detected " + brushProvider.name + " and brushLocalScale = " + brushProvider.transform.localScale;
    }

    void Update()
    {
        scaleSliderValue = scaleSlider.value;
        Vector3 scale = brushProvider.transform.localScale;
        scale.Set(scaleSliderValue, scaleSliderValue, scaleSliderValue);
        //Vector3 scale = new Vector3(scaleSliderValue, scaleSliderValue, scaleSliderValue);
        brushProvider.transform.localScale = scale;
    }
}
