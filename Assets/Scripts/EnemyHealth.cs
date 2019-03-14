using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
    }

    public void WordHit()
    {
        health--;
    }

    private void Update()
    {
        if(health == 0)
        {
            Destroy(gameObject);
        }
    }
}
