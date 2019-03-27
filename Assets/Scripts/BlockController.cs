using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        health = 2;
    }

    public void WordHit()
    {
        if (!tag.Equals("Blue Block"))
            health--;
    }

    private void Update()
    {
        if (health == 0 && !tag.Equals("Blue Block"))
        {
            Destroy(gameObject);
        }
    }
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        //soldier crushed
        if (other.gameObject.tag.Equals("Soldier"))
        {
            if (Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.y) > 0)
                Destroy(other.gameObject);
            else
            {
                Debug.Log("block velocity: " + gameObject.GetComponent<Rigidbody2D>().velocity.magnitude);
            }
        }

        if(other.gameObject.tag.Equals("Moses"))
        {
            if (Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.y) > 0)
                other.gameObject.GetComponent<MosesCollision>().mosesDeath();
        }
    }
}
