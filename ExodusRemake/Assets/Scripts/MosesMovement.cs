using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosesMovement : MonoBehaviour 
{
    public float speed;
    private string lastMove;

    private void Start()
    {
        lastMove = "RIGHT";
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
        }
        else if (moveVertical < 0)
        {
            lastMove = "DOWN";
            //Debug.Log("down");
        }
        
        if(moveHorizontal > 0)
        {
            lastMove = "RIGHT";
        }
        else if(moveHorizontal < 0)
        {
            lastMove = "LEFT";
        }       
    }

    public string getLastMove()
    {
        return lastMove;
    }
}
