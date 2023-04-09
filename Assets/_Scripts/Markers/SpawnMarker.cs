using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMarker : MonoBehaviour
{
    public static SpawnMarker Instance;
    
    public enum MarkerType
    {
        Black,
        Red,
        Green,
        Blue,
        Eraser
    }
    
    public enum MarketSize
    {
        Small,
        Medium,
        Large
    }
    
    [SerializeField] private GameObject blackMarkerPrefab;
    [SerializeField] private GameObject redMarkerPrefab;
    [SerializeField] private GameObject greenMarkerPrefab;
    [SerializeField] private GameObject blueMarkerPrefab;
    [SerializeField] private GameObject eraserPrefab;

    [SerializeField] private GameObject _currentMarker;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
    
    
    
    public void ReplaceMarker(int markerNumber)
    {
        if (markerNumber > 5) return;
        MarkerType markerType = MarkerType.Black;
        switch (markerNumber)
        {
            case 1:
                markerType = MarkerType.Black;
                break;
            case 2:
                markerType = MarkerType.Red;
                break;
            case 3:
                markerType = MarkerType.Green;
                break;
            case 4:
                markerType = MarkerType.Blue;
                break;
            case 5:
                markerType = MarkerType.Eraser;
                break; 
        }
        
        var currentMarkerPosition = _currentMarker.transform.position;
        if (_currentMarker != null) Destroy(_currentMarker);
        switch (markerType)
        {
            case MarkerType.Black:
                _currentMarker = Instantiate(blackMarkerPrefab, currentMarkerPosition, Quaternion.identity);
                break;
            case MarkerType.Red:
                _currentMarker = Instantiate(redMarkerPrefab, currentMarkerPosition, Quaternion.identity);
                break;
            case MarkerType.Green:
                _currentMarker = Instantiate(greenMarkerPrefab, currentMarkerPosition, Quaternion.identity);
                break;
            case MarkerType.Blue:
                _currentMarker = Instantiate(blueMarkerPrefab, currentMarkerPosition, Quaternion.identity);
                break;
            case MarkerType.Eraser:
                _currentMarker = Instantiate(eraserPrefab, currentMarkerPosition, Quaternion.identity);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(markerType), markerType, null);
        }
    }
    
    
}
