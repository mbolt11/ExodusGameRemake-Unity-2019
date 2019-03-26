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

    //When the enemy is hit by a spoken word, it takes 3 to die
    public void WordHit()
    {
        //Decrease health and he speeds up
        health--;
        GetComponent<SoldierMovement>().speed++;

        if (health == 0)
        {
            Destroy(gameObject);
            GameController.controller.addPoints(100);
        }
    }

    //When a boulder falls on top of the enemy he dies immediately
    public void Crushed()
    {
        Destroy(gameObject);
        GameController.controller.addPoints(400);
    }
}
