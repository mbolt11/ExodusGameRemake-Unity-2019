using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosesCollision : MonoBehaviour 
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        //For colliding with manna
        if(other.gameObject.tag == "Manna")
        {
            Destroy(other.gameObject);
            //Add code to update Moses' manna count
        }

        //Picking up treasure boxes
        if(other.collider.gameObject.tag == "Treasure")
        {
            //Code to add to what Moses has collected

            Destroy(other.gameObject);
        }

        //For colliding with enemy- dies
        if(other.gameObject.tag == "Soldier")
        {
            //He dies... change sprites
        }
    }
}
