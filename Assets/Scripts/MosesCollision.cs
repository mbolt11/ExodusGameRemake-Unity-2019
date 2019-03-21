using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosesCollision : MonoBehaviour
{
    public GameObject levelControl;
    //public GameObject gameControl;

    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //For colliding with manna
        if (other.gameObject.tag == "Manna")
        {
            other.gameObject.GetComponent<HidingTreasure>().showTreasure();
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
        }

        //For colliding with enemy- dies
        if (other.gameObject.tag == "Soldier")
        {
            //Subtract a life and reset level
            GameController.controller.MosesDied();
            //levelControl.GetComponent<Level1Control>().ResetLevel();

            //Visuals-- change sprite, wait a few secs, reload?
        }

        //For finishing level- load next level
        if(other.gameObject.tag == "Finish")
        {
            Debug.Log("Next level should load");
        }
    }
}


