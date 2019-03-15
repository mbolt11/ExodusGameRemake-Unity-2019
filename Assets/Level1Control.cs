using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Control : MonoBehaviour
{
    //These are the stats that do not carry over from level to level
    private int manna;
    private bool mannaQuotaMet;
    private int treasure;
    private bool treasureQuotaMet;
    private int startTime;
    private bool levelComplete;

    // Start is called before the first frame update
    void Start()
    {
        manna = 0;
        mannaQuotaMet = false;
        treasure = 0;
        treasureQuotaMet = false;
        startTime = 300;
        levelComplete = false;
    }

    //When you collect manna
    public void addManna()
    {
        manna++;

        if (manna >= 82)
            mannaQuotaMet = true;
    }

    //When you collect treasure (equal to question boxes in DOS game)
    public void addTreasure()
    {
        treasure++;

        if (treasure >= 5)
            treasureQuotaMet = true;
    }

    private void Update()
    {
        if(mannaQuotaMet && treasureQuotaMet)
        {
            RevealExit();
            mannaQuotaMet = false;
            treasureQuotaMet = false;
        }

    }

    //Method that enables the exit game object
    private void RevealExit()
    {
        //Reveal the exit
    }
}
