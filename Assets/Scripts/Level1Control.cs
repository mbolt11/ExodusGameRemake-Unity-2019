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

    public GameObject canvas;

    private void Awake()
    {
        //This calls the methods to reinitialize gameobjects in GameController when the scene is reloaded
        GameController.controller.InitializeGameObjects();
    }

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

    //Accessors for stats to go in canvas
    public string getMannaCollected()
    {
        return manna.ToString() + "/82";
    }

    public string getTreasureCollected()
    {
        return treasure.ToString() + "/5";
    }

    //When you collect manna
    public void addManna()
    {
        manna++;

        canvas.GetComponent<StatBoard>().UpdateManna();

        if (manna >= 82)
            mannaQuotaMet = true;
    }

    //When you collect treasure (equal to question boxes in DOS game)
    public void addTreasure()
    {
        treasure++;

        canvas.GetComponent<StatBoard>().UpdateTreasure();

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

    public void ResetLevel()
    {
        //When the player dies, the level resets
        manna = 0;
        mannaQuotaMet = false;
        treasure = 0;
        treasureQuotaMet = false;
        startTime = 300;
        levelComplete = false;
    }
}
