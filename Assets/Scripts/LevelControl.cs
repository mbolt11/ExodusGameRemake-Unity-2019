using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
    //Stats that don't carry over and don't vary from level to level
    private int manna;
    private bool mannaQuotaMet;
    private int treasure;
    private bool treasureQuotaMet;
    private int clockTime;
    private bool levelComplete;
    private int treasureQuota;

    //These don't carry over but do vary from level to level
    private int mannaQuota;
    private bool finished;

    public GameObject canvas;
    public GameObject finish;

    // Start is called before the first frame update
    private void Awake()
    {
        //This calls the methods to reinitialize gameobjects in GameController when the scene is reloaded
        GameController.controller.InitializeGameObjects();
    }

    private void Start()
    {
        //Initialize all variables that don't vary from level to level
        manna = 0;
        mannaQuotaMet = false;
        treasure = 0;
        treasureQuotaMet = false;
        clockTime = 300;
        levelComplete = false;
        finish.SetActive(false);
        finished = false;

        //set up the board
        GameController.controller.setUpBoard();

        //The clock countdown
        StartCoroutine(Countdown());
    }

    //Called by GameController- set manna quota
    public void SetQuotas(int levelnum)
    {
        treasureQuota = 5;
        switch (levelnum)
        {
            case 1:
                mannaQuota = 82;
                break;
            case 2:
                mannaQuota = 33;
                break;
            case 3:
                mannaQuota = 86;
                break;
            case 4:
                mannaQuota = 50;
                break;
            case 5:
                mannaQuota = 1000;
                break;
        }
    }

    //Accessors for stats to go in canvas
    public string getMannaCollected()
    {
        return manna.ToString() + "/" + mannaQuota.ToString();
    }

    public string getTreasureCollected()
    {
        return treasure.ToString() + "/" + treasureQuota.ToString();
    }

    public string getTime()
    {
        return clockTime.ToString();
    }

    //When you collect manna
    public void addManna()
    {
        //Add to the manna count and add 100 points
        manna++;
        GameController.controller.addPoints(100);

        //Update the canvas
        canvas.GetComponent<StatBoard>().UpdateManna();
        canvas.GetComponent<StatBoard>().UpdateScore();

        if (manna >= mannaQuota)
            mannaQuotaMet = true;
    }

    //When you collect treasure (equal to question boxes in DOS game)
    public void addTreasure()
    {
        //Treasure chests are worth 1000 points
        treasure++;
        GameController.controller.addPoints(1000);

        //Update canvas
        canvas.GetComponent<StatBoard>().UpdateTreasure();
        canvas.GetComponent<StatBoard>().UpdateScore();

        if (treasure >= treasureQuota)
            treasureQuotaMet = true;
    }

    public void AtFinish()
    {
        finished = true;
    }

    private void Update()
    {
        if (mannaQuotaMet && treasureQuotaMet)
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
        finish.SetActive(true);
    }

    private IEnumerator Countdown()
    {
        while(clockTime > 0 && !finished)
        {
            yield return new WaitForSeconds(1f);

            //Decrement time and update the canvas
            clockTime--;
            canvas.GetComponent<StatBoard>().UpdateTime();
        }

        //They completed the level
        if(clockTime > 0)
        {
            canvas.GetComponent<StatBoard>().UpdateMessage("Level Complete!");
            GameController.controller.addPoints(clockTime);
            clockTime = 0;
            canvas.GetComponent<StatBoard>().UpdateScore();
            canvas.GetComponent<StatBoard>().UpdateTime();
        }
        //Ran out of time
        else
        {
            canvas.GetComponent<StatBoard>().UpdateMessage("Time's up!");
            GameController.controller.MosesDied();
        }
    }
}
