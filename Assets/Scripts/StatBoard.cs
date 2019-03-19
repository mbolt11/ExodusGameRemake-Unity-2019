using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatBoard : MonoBehaviour
{
    //UI text objects
    public Text level;
    public Text score;
    public Text lives;
    public Text manna;
    public Text treasure;
    public Text time;
    public Text message;

    public GameObject levelControl;
    public GameObject gameControl;

    // Start is called before the first frame update
    void Start()
    {
        message.enabled = false;

        level.text = "Level " + gameControl.GetComponent<GameController>().getLevelNum();
        score.text = "Score: " + gameControl.GetComponent<GameController>().getPoints();
        lives.text = "Lives: " + gameControl.GetComponent<GameController>().getLives();
        manna.text = "Manna: " + levelControl.GetComponent<Level1Control>().getMannaCollected();
        treasure.text = "Treasure: " + levelControl.GetComponent<Level1Control>().getTreasureCollected();
        time.text = "Time: 300";
    }

    //Methods to update
    public void UpdateLevel()
    {
        level.text = "Level " + gameControl.GetComponent<GameController>().getLevelNum();
    }

    public void UpdateScore()
    {
        score.text = "Score: " + gameControl.GetComponent<GameController>().getPoints();
    }

    public void UpdateLives()
    {
        lives.text = "Lives: " + gameControl.GetComponent<GameController>().getLives();
    }

    public void UpdateManna()
    {
        manna.text = "Manna: " + levelControl.GetComponent<Level1Control>().getMannaCollected();
    }

    public void UpdateTreasure()
    {
        treasure.text = "Treasure: " + levelControl.GetComponent<Level1Control>().getTreasureCollected();
    }

    public void UpdateMessage(string message_in)
    {
        message.text = message_in;
        message.enabled = true;
    }
}
