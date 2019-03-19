using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosesMovement : MonoBehaviour 
{
    public float speed;
    private string lastMove;

    //For which picture displays
    public Sprite[] images;
    private SpriteRenderer renderer;

    private void Start()
    {
        lastMove = "RIGHT";
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = images[0];
    }

    // Update is called once per frame
    void Update()
    {
        //His movement based on arrow keys
        float moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float moveVertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.Translate(moveHorizontal, moveVertical, 0f);
        if (moveVertical > 0)
        {
            lastMove = "UP";
            renderer.sprite = images[1];
        }
        else if (moveVertical < 0)
        {
            lastMove = "DOWN";
            renderer.sprite = images[0];
        }

        if(moveHorizontal > 0)
        {
            lastMove = "RIGHT";
            renderer.sprite = images[3];
        }
        else if(moveHorizontal < 0)
        {
            lastMove = "LEFT";
            renderer.sprite = images[2];
        }       
    }

    public string getLastMove()
    {
        return lastMove;
    }
}
