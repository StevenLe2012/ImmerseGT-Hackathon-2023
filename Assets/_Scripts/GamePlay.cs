using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    private int rounds = 3;
    private int duration = 60;
    private int currentRound = 0; // game not started

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void roundStart() {
        // generate random image with prompt
        // apply texture to grabbable plane
        // instantiates blank canvas for painting
        // timer countdown
    }
    void roundEnd() {
        // save canvas
        currentRound++; // increment current round
    }
}
