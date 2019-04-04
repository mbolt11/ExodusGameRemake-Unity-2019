using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
    }

    public void WordHit()
    {
        if (tag.Equals("Wood Block"))
        {
            health--;
            Debug.Log("Lost health");
        }
    }

    private void Update()
    {
        if (health == 0 && tag.Equals("Wood Block"))
        {
            Destroy(gameObject);
        }
    }
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        //soldier crushed
        if (other.gameObject.tag.Equals("Soldier"))
        {
            if (Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.y) > 1)
                Destroy(other.gameObject);
            else
            {
                Debug.Log("block velocity: " + gameObject.GetComponent<Rigidbody2D>().velocity.magnitude);
            }
        }

        if(other.gameObject.tag.Equals("Moses"))
        {
            //no rigidbody on wood blocks so this throws an error
            if (Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.y) > 1)
                other.gameObject.GetComponent<MosesCollision>().mosesDeath();
        }
    }
}
