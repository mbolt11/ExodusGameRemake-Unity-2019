using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WordBehavior : MonoBehaviour {

    private Tilemap tilemap;
    private Vector3 startVel;

    public void Start()
    {
        tilemap = GameObject.Find("Tilemap").GetComponent<Tilemap>();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        startVel = rb.velocity;

        Destroy(gameObject, 0.5f);
    }

    //Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //GameObject tileGameObject = collision.otherCollider.gameObject;
        Vector3 offset = Vector3.zero;
        //Debug.Log("Collision: " + collision.gameObject.name);

        if(startVel.x > 0 && startVel.y == 0)
        {
            //Debug.Log("rb is right");
            offset = new Vector3(gameObject.transform.localScale.x, 0f, 0f);
        }
        else if (startVel.x < 0 && startVel.y == 0)
        {
            //Debug.Log("rb is left");
            offset = new Vector3(-gameObject.transform.localScale.x - 1, 0f, 0f);
        }
        else if(startVel.x == 0 && startVel.y > 0)
        {
            //Debug.Log("rb is up");
            offset = new Vector3(0f, gameObject.transform.localScale.y, 0f);
        }
        else if(startVel.x == 0 && startVel.y < 0)
        {
            //Debug.Log("rb is down");
            offset = new Vector3(0f, -gameObject.transform.localScale.y, 0f);
        }
        else
        {
            //Debug.Log("rb velocity: "+startVel);
        }

        Vector3Int positionTile = new Vector3Int((int)(collision.otherCollider.transform.position.x + offset.x), (int)(collision.otherCollider.transform.position.y + offset.y), (int)(collision.otherCollider.transform.position.z + offset.z));
        TileBase tileHit = tilemap.GetTile(tilemap.WorldToCell(positionTile));
        Debug.Log("World Position: " + positionTile);
        Debug.Log(tilemap.WorldToCell(positionTile).ToString());
        if (tileHit != null)
            Debug.Log("Tile: " + tileHit.name);

        if (tileHit != null && tileHit.name.Equals("Dirt"))
        {
            tilemap.SetTile(tilemap.WorldToCell(positionTile), null);
            tilemap.RefreshTile(tilemap.WorldToCell(positionTile));
        }

        Destroy(gameObject);
        //Debug.Log("tile destroyed");
    }
}
