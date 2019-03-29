using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosesCollision : MonoBehaviour
{
    public GameObject levelControl;
    public GameObject canvas;
    private BoardState board;

    private void Start()
    {
       board = BoardState.getBoard();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        //For colliding with manna
        if (other.gameObject.tag == "Manna")
        {
            //????
            if (other.gameObject.GetComponent<HidingTreasure>().showTreasure())
            {
                Destroy(other.gameObject);
            }
            else
            {
                Vector2 boardLocation = board.findBoardLocation(other.transform);
                Destroy(other.gameObject);
                board.updateBoard(boardLocation, 0);
            }

            //Update manna count
            levelControl.GetComponent<LevelControl>().addManna();
        }

        //Picking up treasure boxes
        if (other.gameObject.tag == "Treasure")
        {
            Vector2 boardLocation = board.findBoardLocation(other.transform);
            Destroy(other.gameObject);
            board.updateBoard(boardLocation, 0);

            //Update count
            levelControl.GetComponent<LevelControl>().addTreasure();
        }

        //Picking up Bibles
        if (other.gameObject.tag == "Bible")
        {
            Vector2 boardLocation = board.findBoardLocation(other.transform);
            Destroy(other.gameObject);
            board.updateBoard(boardLocation, 0);

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

        //The Word of God PowerUp: adds one to the amount of spoken words shot at a time, max is 5
        if(other.gameObject.tag == "WOG")
        {
            GameController.controller.addWordAtOnce();
        }

        //The Authority of God Powerup: adds to the amount of distance a spoken word can travel
        if(other.gameObject.tag == "AOG")
        {

        }
    }

    public void mosesDeath()
    {
        canvas.GetComponent<StatBoard>().UpdateMessage("You died!");
        GameController.controller.MosesDied();
    }
}


