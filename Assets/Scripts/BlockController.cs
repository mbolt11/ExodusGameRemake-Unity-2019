﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public int health;
    private bool hitonce;
    private BoardState board;

    // Start is called before the first frame update
    void Start()
    {
        health = 6;
        hitonce = false;
        board = BoardState.boardState;
    }

    public void WordHit()
    {
        if (tag.Equals("Wood Block"))
        {
            health--;
            //Debug.Log("Lost health");
        }
    }

    private void Update()
    {
        if (health <= 0 && tag.Equals("Wood Block"))
        {
            board.updateBoard(GetComponent<ObjectMovement>().getBoardLocation(), 0);
            Destroy(gameObject);
            //must update the board when destroyed
        }
    }
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        //soldier crushed
        if (other.gameObject.tag.Equals("Soldier") || other.gameObject.tag.Equals("Manna"))
        {
            if (Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.y) > 2)
            {
                if(other.gameObject.tag.Equals("Soldier"))
                    board.updateBoard(board.findBoardLocation(other.transform), 0);
                Destroy(other.gameObject);
            }
            else
            {
                //not sure if this will work --> should I disable the gravity?
                GetComponent<ObjectMovement>().changeToNotMove();
            }
        }

        if(other.gameObject.tag.Equals("Moses") && !hitonce)
        {
            //no rigidbody on wood blocks so this throws an error
            if (Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.y) > 2)
            {
                hitonce = true;
                other.gameObject.GetComponent<MosesCollision>().mosesDeath();
                Destroy(gameObject);
            }
        }

    }
}
