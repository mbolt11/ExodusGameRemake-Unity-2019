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
    public Text bibles;
    public Text message;
    public Image invincible;

    public GameObject levelControl;

    // Start is called before the first frame update
    void Start()
    {
        message.gameObject.SetActive(false);
        invincible.enabled = false;

        levelControl.GetComponent<LevelControl>().SetQuotas(GameController.controller.getLevelNum());

        level.text = "Level " + GameController.controller.getLevelNum();
        score.text = "Score:\n" + GameController.controller.getPoints();
        lives.text = "Lives: " + GameController.controller.getLives();
        manna.text = "Manna: " + levelControl.GetComponent<LevelControl>().getMannaCollected();
        treasure.text = "Treasure: " + levelControl.GetComponent<LevelControl>().getTreasureCollected();
        bibles.text = "Bibles: " + GameController.controller.getBibles();
        time.text = "Time: 300";
    }

    //Methods to update
    public void UpdateLevel()
    {
        level.text = "Level " + GameController.controller.getLevelNum();
    }

    public void UpdateScore()
    {
        score.text = "Score:\n" + GameController.controller.getPoints();
    }

    public void UpdateLives()
    {
        lives.text = "Lives: " + GameController.controller.getLives();
    }

    public void UpdateManna()
    {
        manna.text = "Manna: " + levelControl.GetComponent<LevelControl>().getMannaCollected();
    }

    public void UpdateTreasure()
    {
        treasure.text = "Treasure: " + levelControl.GetComponent<LevelControl>().getTreasureCollected();
    }

    public void UpdateBibles()
    {
        bibles.text = "Bibles: " + GameController.controller.getBibles();
    }

    public void UpdateMessage(string message_in)
    {
        message.text = message_in;
        message.gameObject.SetActive(true);
    }

    public void UpdateTime()
    {
        time.text = "Time: " + levelControl.GetComponent<LevelControl>().getTime();
    }

    public void InvincibleImageOnOff()
    {
        if(invincible.enabled)
        {
            invincible.enabled = false;
            lives.text = "Lives: " + GameController.controller.getLives();
        }
        else
        {
            invincible.enabled = true;
            lives.text = "Lives: " + GameController.controller.getLives() + "*";
        }
    }
}
