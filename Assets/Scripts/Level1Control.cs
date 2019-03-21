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
    private int clockTime;
    private bool levelComplete;

    public GameObject canvas;
    public GameObject finish;

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
        clockTime = 300;
        levelComplete = false;
        finish.SetActive(false);

        //The clock countdown
        StartCoroutine(Countdown());
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

        if (manna >= 82)
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

        if (treasure >= 5)
            treasureQuotaMet = true;
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
        while(clockTime > 0)
        {
            yield return new WaitForSeconds(1f);

            //Decrement time and update the canvas
            clockTime--;
            canvas.GetComponent<StatBoard>().UpdateTime();
        }
    }
}
