using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WordBehavior : MonoBehaviour
{
    public void Start()
    {
        Destroy(gameObject, 0.5f);
    }

    //Update is called once per frame
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Dirt"))
        {
            other.gameObject.GetComponent<HidingTreasure>().showTreasure();
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag.Equals("Soldier"))
            other.gameObject.GetComponent<EnemyHealth>().WordHit();

        if (other.gameObject.tag.Equals("Wood Block"))
            other.gameObject.GetComponent<BlockController>().WordHit();

        Destroy(gameObject);
    }
}