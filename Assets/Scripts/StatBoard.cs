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

    public GameObject levelControl;

    // Start is called before the first frame update
    void Start()
    {
        level.text = "Level " + GameController.GetController().getLevelNum();
        score.text = "Score: " + GameController.GetController().getPoints();
        lives.text = "Lives: " + GameController.GetController().getLives();
        manna.text = "Manna: " + levelControl.GetComponent<Level1Control>().getMannaCollected();
        treasure.text = "Treasure: " + levelControl.GetComponent<Level1Control>().getTreasureCollected();
        time.text = "300";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
