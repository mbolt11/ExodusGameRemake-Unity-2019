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
        if(!tag.Equals("Blue Block"))
            health--;
    }

    private void Update()
    {
        if (health == 0 && !tag.Equals("Blue Block"))
        {
            Destroy(gameObject);
        }
    }
}
