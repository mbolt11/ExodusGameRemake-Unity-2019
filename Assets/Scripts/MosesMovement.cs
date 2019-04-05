using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosesMovement : MonoBehaviour 
{
    public float speed;
    private string lastMove;
    private bool moving;

    //For which picture displays
    public Sprite[] images;
    private SpriteRenderer renderer;

    private bool restrictLeft, restrictRight, restrictUp, restrictDown;


    private void Start()
    {
        lastMove = "RIGHT";
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = images[0];
        restrictLeft = false;
        restrictRight = false;
        restrictUp = false;
        restrictDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<Rigidbody2D>().

        //His movement based on arrow keys
        float moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float moveVertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        if (restrictLeft && moveHorizontal < 0)
            moveHorizontal = 0;
        if (restrictRight && moveHorizontal > 0)
            moveHorizontal = 0;
        if (restrictUp && moveVertical > 0)
            moveVertical = 0;
        if (restrictDown && moveVertical < 0)
            moveVertical = 0;


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

        if (moveVertical == 0 && moveHorizontal == 0)
            moving = false;
        else
            moving = true;
    }

    public void restrictMovement(string direction)
    {
        if (direction.Equals("left"))
            restrictLeft = true;
        else if (direction.Equals("right"))
            restrictRight = true;
        else if (direction.Equals("up"))
            restrictUp = true;
        else if (direction.Equals("down"))
            restrictDown = true;
    }

    public void freeMovement(string direction)
    {
        if (direction.Equals("left"))
            restrictLeft = false;
        else if (direction.Equals("right"))
            restrictRight = false;
        else if (direction.Equals("up"))
            restrictUp = false;
        else if (direction.Equals("down"))
            restrictDown = false;
    }


    public string getLastMove()
    {
        return lastMove;
    }

    public bool isMoving()
    {
        return moving;
    }
}
