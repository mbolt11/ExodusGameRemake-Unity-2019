using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour //attatched to movable interactable objects such as wood/cement boulders and manna jars
{
    private Vector2 location, locationBoard; //(row, col)
    private BoardState board;
    private bool restrictMoses;
    private string pushDirection;
    private GameObject mosesG;
    // Start is called before the first frame update
    void Start()
    {
        location = new Vector2(transform.position.x, transform.position.y);
        board = BoardState.boardState;
        locationBoard = board.findBoardLocation(transform);
        restrictMoses = false;
    }

    // Update is called once per frame
    void Update()
    {
        //detect movement and update the board
        if(Mathf.Abs(location.x - transform.position.x) > 0.9 || Mathf.Abs(location.y - transform.position.y) > 0.9)
        {
            //Debug.Log("MOVE DETECTED");
            locationBoard = board.findBoardLocation(transform);
            board.updateBoard(locationBoard, 0);
            location.Set(transform.position.x, transform.position.y);
            locationBoard = board.findBoardLocation(transform);
            board.updateBoard(locationBoard, 1);
        }
    }

    //the boulders and manna jars will have trigger colliders that will not allow Moses
    //closer to move them
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if Moses is trying to push a wood/blue block
        if((gameObject.tag.Equals("Wood Block") || gameObject.tag.Equals("Blue Block")) && collision.gameObject.tag.Equals("Moses"))
        {
            //find direction that it will be pushed
            pushDirection = directionBlockPushed(collision.gameObject);
            mosesG = collision.gameObject;
            //Debug.Log(gameObject.tag + " will be pushed to the " + pushDirection);

            if (!validPushDirection(pushDirection))
            {
                //stop Moses from moving in this direction until the trigger region is exited
                restrictMoses = true;
                collision.gameObject.GetComponent<MosesMovement>().restrictMovement(pushDirection);
                //Debug.Log(gameObject.tag + " will not be pushed to the " + pushDirection);
            }

        }

        //if boulders land on pots without high y velocity, then they should not move the pots
        if (((gameObject.tag.Equals("Wood Block") || gameObject.tag.Equals("Blue Block"))) && collision.gameObject.tag.Equals("Manna"))
        {
            if (gameObject.GetComponent<Rigidbody2D>().velocity.y > 1)
                Destroy(collision.gameObject);
            else
            {
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Moses") && restrictMoses == true)
        {
            restrictMoses = false;
            mosesG.GetComponent<MosesMovement>().freeMovement(pushDirection);
        }

        if (collision.gameObject.tag.Equals("Manna"))
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
        }

    }

    private bool validPushDirection(string direction)
    {
        if(direction.Equals("left"))
        {
            if (board.locationValue((int)locationBoard.x, (int)locationBoard.y - 1) == 0)
                return true;
            else
                return false;
        }
        else if(direction.Equals("right"))
        {
            if (board.locationValue((int)locationBoard.x, (int)locationBoard.y + 1) == 0)
                return true;
            else
                return false;
        }
        else if(direction.Equals("up"))
        {
            if (board.locationValue((int)locationBoard.x - 1, (int)locationBoard.y) == 0)
                return true;
            else
                return false;
        }
        else if(direction.Equals("down"))
        {
            if (board.locationValue((int)locationBoard.x + 1, (int)locationBoard.y) == 0)
                return true;
            else
                return false;
        }
        else
        {
            return true;
        }
    }

    private string directionBlockPushed(GameObject moses)
    {
        Vector2 mosesLocation = board.findBoardLocation(moses.transform);
        locationBoard = board.findBoardLocation(transform);

        //Debug.Log("Moses: (row, col) (" + mosesLocation.x + ", " + mosesLocation.y + ")");
        //Debug.Log("Boulder: (row, col) (" + locationBoard.x + ", " + locationBoard.y + ")");

        if (locationBoard.x == mosesLocation.x) // same row
        {
            if (locationBoard.y == (mosesLocation.y - 1)) //left
                return "left";
            else if (locationBoard.y == (mosesLocation.y + 1)) //right
                return "right";
            else //in the same column
            {
                return moses.GetComponent<MosesMovement>().getLastMove();
            }
        }
        else if (locationBoard.y == mosesLocation.y) // same column
        {
            if (locationBoard.x == (mosesLocation.x - 1)) //up
                return "up";
            else if (locationBoard.x == (mosesLocation.x + 1)) //down
                return "down";
            else //in the same row
            {
                return moses.GetComponent<MosesMovement>().getLastMove();
            }
        }

        return "invalid";
    }
}
