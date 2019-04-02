using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WordBehavior : MonoBehaviour
{
    private BoardState board;
    private GameObject Moses;

    public void Start()
    {
        board = BoardState.boardState;
        Moses = GameObject.FindGameObjectWithTag("Moses");
    }

    /*private void OnCollisionEnter2D(Collision2D other)
    {
        //Keeps them from destroying each other
        if(other.gameObject.tag.Equals("Word"))
        {
            return;
        }

        if (other.gameObject.tag.Equals("Dirt"))
        {
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
        }

        if(other.gameObject.tag.Equals("Blue Dirt"))
        {
            other.gameObject.GetComponent<DestroyDirt>().BlueDirtHit();
        }

        if (other.gameObject.tag.Equals("Soldier"))
        {
            other.gameObject.GetComponent<EnemyHealth>().WordHit();
        }

        if (other.gameObject.tag.Equals("Wood Block"))
        {
            other.gameObject.GetComponent<BlockController>().WordHit();
        }

        Moses.GetComponent<MosesShoot>().subtractShot();
        Destroy(gameObject);
    }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Keeps them from destroying each other
        if (other.gameObject.tag.Equals("Word"))
        {
            return;
        }

        if (other.gameObject.tag.Equals("Dirt"))
        {
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
        }

        if (other.gameObject.tag.Equals("Blue Dirt"))
        {
            other.gameObject.GetComponent<DestroyDirt>().BlueDirtHit();
        }

        if (other.gameObject.tag.Equals("Soldier"))
        {
            other.gameObject.GetComponent<EnemyHealth>().WordHit();
        }

        if (other.gameObject.tag.Equals("Wood Block"))
        {
            other.gameObject.GetComponent<BlockController>().WordHit();
        }

        Moses.GetComponent<MosesShoot>().subtractShot();
        Destroy(gameObject);
    }
}