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
    //public GameObject gameControl;

    // Start is called before the first frame update
    void Start()
    {
        message.gameObject.SetActive(false);

        level.text = "Level " + GameController.controller.getLevelNum();
        score.text = "Score: " + GameController.controller.getPoints();
        lives.text = "Lives: " + GameController.controller.getLives();
        manna.text = "Manna: " + levelControl.GetComponent<Level1Control>().getMannaCollected();
        treasure.text = "Treasure: " + levelControl.GetComponent<Level1Control>().getTreasureCollected();
        time.text = "Time: 300";
    }

    //Methods to update
    public void UpdateLevel()
    {
        level.text = "Level " + GameController.controller.getLevelNum();
    }

    public void UpdateScore()
    {
        score.text = "Score: " + GameController.controller.getPoints();
    }

    public void UpdateLives()
    {
        lives.text = "Lives: " + GameController.controller.getLives();
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
        message.gameObject.SetActive(true);
    }
}
