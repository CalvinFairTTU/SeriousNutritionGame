using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrogWins : MonoBehaviour {

    
    public GameObject exit;
    private int cycleCounter;
    private bool victory;
    public int waitToExit;

    //More can be done in this class when the player wins.

    void Start()
    {
        victory = false;
        cycleCounter = 0;
    }

    public void SetVictory()
    {
        this.victory = true;
        Debug.Log("victory = " + victory);
    }

    public void Win()
    {        
        // We might activate the pause menu here.
        exit.GetComponent<Stage3Level1Reload>().Run();
    }

    private void FixedUpdate()
    {
        if (victory && cycleCounter < waitToExit)
        {
            cycleCounter++;
        }
        else if (victory && cycleCounter == waitToExit)
        {
            Debug.Log("ran it");
            Win();
        }
    }
}
