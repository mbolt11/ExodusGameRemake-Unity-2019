using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosesCollision : MonoBehaviour
{
    public GameObject levelControl;

    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //For colliding with manna
        if (other.gameObject.tag == "Manna")
        {
            Destroy(other.gameObject);

            //Update manna count
            levelControl.GetComponent<Level1Control>().addManna();
        }

        //Picking up treasure boxes
        if (other.collider.gameObject.tag == "Treasure")
        {
            Destroy(other.gameObject);

            //Update count
            levelControl.GetComponent<Level1Control>().addTreasure();

            //Treasure chests are worth 1000 points
            GameController.GetController().addPoints(1000);
        }

        //For colliding with enemy- dies
        if (other.gameObject.tag == "Soldier")
        {
            //Subtract a life and reset level
            GameController.GetController().MosesDied();
            levelControl.GetComponent<Level1Control>().ResetLevel();

            //Visuals-- change sprite, wait a few secs, reload?
        }
    }
}


