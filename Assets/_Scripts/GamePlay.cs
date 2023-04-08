using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    private int rounds = 3;
    private float duration = 60.0f;
    private float timeValue;
    private int currentRound = 0; 

    // Start is called before the first frame update
    void Start()
    {
        timeValue = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }

        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay)
   {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        //float milliseconds = timeToDisplay % 1 * 1000;
        Debug.Log(minutes + " : " + seconds);
   }

    void roundStart() {
        // generate new ref image
        // instantiates blank square canvas for painting
        // timer countdown
    }
    void roundEnd() {
        // save canvas
        currentRound++; // increment current round
    }
}
