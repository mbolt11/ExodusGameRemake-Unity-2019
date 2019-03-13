using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosesCollision : MonoBehaviour 
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        //For colliding with manna
        if(other.collider.gameObject.tag == "Manna")
        {
            Destroy(other.collider.gameObject);
            //Add code to update Moses' manna count
        }
    }
}
