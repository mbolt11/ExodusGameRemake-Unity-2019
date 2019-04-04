using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosesCollision : MonoBehaviour
{
    public GameObject levelControl;
    public GameObject canvas;
    private BoardState board;

    private bool invincible;
    private GameObject[] enemies;

    private void Start()
    {
        board = BoardState.boardState;
        invincible = false;
        enemies = GameObject.FindGameObjectsWithTag("Soldier");
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
        if (other.gameObject.tag == "Soldier" && !invincible)
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
            Destroy(other.gameObject);
            GameController.controller.AddWordAtOnce();
        }

        //The Authority of God Powerup: adds to the amount of distance a spoken word can travel
        if(other.gameObject.tag == "AOG")
        {
            Destroy(other.gameObject);
            GameController.controller.AddWordLifetime();
        }

        //The invincibility powerup: makes Moses invincible for 20 seconds
        if(other.gameObject.tag == "Invincible")
        {
            Destroy(other.gameObject);

            invincible = true;
            canvas.GetComponent<StatBoard>().InvincibleImageOnOff();

            //Turn off the colliders of all the enemies so Moses can go through them
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<BoxCollider2D>().enabled = false;
            }

            //Start the coroutine to end invincibility after 20 sec
            StartCoroutine(Invinsibility());
        }
    }

    public void mosesDeath()
    {
        canvas.GetComponent<StatBoard>().UpdateMessage("You died!");
        GameController.controller.MosesDied();
    }

    private IEnumerator Invinsibility()
    {
        yield return new WaitForSeconds(20f);
        invincible = false;
        canvas.GetComponent<StatBoard>().InvincibleImageOnOff();

        //Turn all enemy colliders back on
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}


