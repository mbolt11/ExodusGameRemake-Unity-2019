using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosesCollision : MonoBehaviour
{
    public GameObject levelControl;
    public GameObject canvas;

    private void OnCollisionEnter2D(Collision2D other)
    {
        //For colliding with manna
        if (other.gameObject.tag == "Manna")
        {
            other.gameObject.GetComponent<HidingTreasure>().showTreasure();
            Destroy(other.gameObject);

            //Update manna count
            levelControl.GetComponent<LevelControl>().addManna();
        }

        //Picking up treasure boxes
        if (other.gameObject.tag == "Treasure")
        {
            Destroy(other.gameObject);

            //Update count
            levelControl.GetComponent<LevelControl>().addTreasure();
        }

        //Picking up Bibles
        if (other.gameObject.tag == "Bible")
        {
            Destroy(other.gameObject);

            //Update count
            GameController.controller.addBible();
        }

        //For colliding with enemy- dies
        if (other.gameObject.tag == "Soldier")
        {
            //Print message and start die logic
            canvas.GetComponent<StatBoard>().UpdateMessage("You died!");
            GameController.controller.MosesDied();
        }

        //For finishing level- load next level
        if(other.gameObject.tag == "Finish")
        {
            //Stop the clock and load next level
            levelControl.GetComponent<LevelControl>().AtFinish();
            GameController.controller.LoadNextLevel();
        }
    }
}


