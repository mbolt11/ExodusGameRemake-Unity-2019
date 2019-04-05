using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMovement : MonoBehaviour
{
    public int row, col, speed;
    public string cardinalForward;
    private Vector2 locationBoard, destination, destinationBoard;
    private BoardState boardState;
    private string[] orientationDirec = new string[4];
    private float moveHorizontal;
    private float moveVertical;

    private Vector2 location, locationBoard2; //(row, col)

    //For changing the image when he changes direction
    public Sprite[] images;
    private SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        GameObject controller = GameObject.FindGameObjectWithTag("Controller");
        boardState = BoardState.boardState;

        //Get renderer and set initial image
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = images[0];

        //location and destination should be equal during start up
        locationBoard = new Vector2(row, col);
        destinationBoard = new Vector2(row, col);

        location = new Vector2(transform.position.x, transform.position.y);
        locationBoard2 = boardState.findBoardLocation(transform);

        //location = gameObject.transform.position;
        destination = new Vector2(transform.position.x, transform.position.y);

        //set orientation
        updateOrientation();

        //velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        //velocity.Set(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //find where it should go next && check up, down, left, and right
        //all enemies will move in a clockwise pattern (meaning they will always travel left)

        //if location = destination, search for next destination and begin movement
        if(reachedDestination(destination))
        {
            //change locationBoard
            locationBoard.Set(destinationBoard.x, destinationBoard.y);

            //set velocity to zero
            //velocity.Set(Vector2.zero.x, Vector2.zero.y);

            //4 possible moves that all qualify as "edge pieces"
            Vector2[] possMoves = findLocations();
            int index = findDestIndx(possMoves);

            if (index >= 0)
            {
                //Debug.Log("prev cardForward: " + cardinalForward);
                destination.Set(possMoves[index].x, possMoves[index].y);
                //Debug.Log("new destination--> x: "+destination.x+ " y: "+destination.y);

                //set velocity, cardinalForward, and orientationDirec to get to the destination
                if (index == 0) //traveling WEST
                {
                    renderer.sprite = images[2];
                    moveHorizontal = -speed * Time.deltaTime;
                    moveVertical = 0;
                    cardinalForward = "WEST";
                    destinationBoard.Set(destinationBoard.x, destinationBoard.y - 1);
                }
                else if (index == 1) //traveling EAST
                {
                    renderer.sprite = images[3];
                    moveHorizontal = speed * Time.deltaTime;
                    moveVertical = 0;
                    cardinalForward = "EAST";
                    destinationBoard.Set(destinationBoard.x, destinationBoard.y + 1);
                }
                else if (index == 2) //traveling SOUTH
                {
                    renderer.sprite = images[0];
                    moveHorizontal = 0;
                    moveVertical = -speed * Time.deltaTime;
                    cardinalForward = "SOUTH";
                    destinationBoard.Set(destinationBoard.x + 1, destinationBoard.y);
                }
                else //traveling NORTH
                {
                    renderer.sprite = images[1];
                    moveHorizontal = 0;
                    moveVertical = speed * Time.deltaTime;
                    cardinalForward = "NORTH";
                    destinationBoard.Set(destinationBoard.x - 1, destinationBoard.y);
                }

                //Debug.Log("new cardForward: " + cardinalForward);
                updateOrientation();
            }
        }

        if(!GameController.controller.getMosesDead())
            transform.Translate(moveHorizontal, moveVertical, 0f);
        //Debug.Log(transform.position.x);

        //detect movement and update the board
        /*if (Mathf.Abs(location.x - transform.position.x) > 0.9 || Mathf.Abs(location.y - transform.position.y) > 0.9)
        {
            //Debug.Log("MOVE DETECTED");
            locationBoard2 = boardState.findBoardLocation(transform);
            boardState.updateBoard(locationBoard2, 0);
            location.Set(transform.position.x, transform.position.y);
            locationBoard2 = boardState.findBoardLocation(transform);
            boardState.updateBoard(locationBoard2, 1);
        }*/

    }

    bool reachedDestination(Vector2 dest_in)
    {
        if(cardinalForward == "NORTH")
        {
            if (transform.position.y >= dest_in.y)
                return true;
        }
        else if(cardinalForward == "SOUTH")
        {
            if (transform.position.y <= dest_in.y)
                return true;
        }
        else if(cardinalForward == "WEST")
        {
            if (transform.position.x <= dest_in.x)
                return true;
        }
        else if(cardinalForward == "EAST")
        {
            if (transform.position.x >= dest_in.x)
                return true;
        }

        return false;
    }

    int findDestIndx(Vector2[] moveOptions)
    {
        //RULE1: according to orientation, if "left" is available then do it
        //RULE2: if "left" unavailable, then move "forward" or in the same direction as previous
        //RULE3: if "forward is unavailable", then move "right" according to orientation
        //RULE4: if "right" unavailable, then must turn around (in such case there should only be 1 valid move)

        int destIndex = -1;

        int validMoves = 0;
        //check first if need to turn around
        for (int i = 0; i < 4; i++)
        {
            if (Mathf.Abs(moveOptions[i].x - transform.position.x) < 50)
            {
                validMoves++;
                destIndex = i;
            }
        }

        if (validMoves == 1)
        {
            //Debug.Log("only one option");
            return destIndex;
        }
        else if (validMoves == 0)
        {    //Debug.Log("No moves found, ERROR");
        }

        //if "left" available, do it
        for(int i = 0; i < 4; i++)
        {
            //if the tile to the "left" is valid, then move there
            if (orientationDirec[i].Equals("left") && Mathf.Abs(moveOptions[i].x - transform.position.x) < 50)
            {
                //Debug.Log("moving 'left'");
                return i;
            }
        }

        //if "left", unavailable move "forward"
        for (int i = 0; i < 4; i++)
        {
            //if the tile to the "forward" is valid, then move there
            if (orientationDirec[i].Equals("forward") && Mathf.Abs(moveOptions[i].x - transform.position.x) < 50)
            {
                //Debug.Log("moving 'forward'");
                return i;
            }
        }

        //if "forward" unavailable, then move "right"
        for (int i = 0; i < 4; i++)
        {
            //if the tile to the "forward" is valid, then move there
            if (orientationDirec[i].Equals("right") && Mathf.Abs(moveOptions[i].x - transform.position.x) < 50)
            {
                //Debug.Log("moving 'right'");
                return i;
            }
        }

        //Debug.Log("DIDNT FIND VALID DIRECTION: " + destIndex);
        return destIndex;
    }

    void updateOrientation()
    {
        //orientationDirec[] --> 0: WEST, 1:EAST, 2:SOUTH, 3:NORTH
        if (cardinalForward.Equals("NORTH"))
        {
            orientationDirec[0] = "left";
            orientationDirec[1] = "right";
            orientationDirec[2] = "back";
            orientationDirec[3] = "forward";
        }
        else if(cardinalForward.Equals("SOUTH"))
        {
            orientationDirec[0] = "right";
            orientationDirec[1] = "left";
            orientationDirec[2] = "forward";
            orientationDirec[3] = "back";
        }
        else if(cardinalForward.Equals("EAST"))
        {
            orientationDirec[0] = "back";
            orientationDirec[1] = "forward";
            orientationDirec[2] = "right";
            orientationDirec[3] = "left";
        }
        else //"WEST"
        {
            orientationDirec[0] = "forward";
            orientationDirec[1] = "back";
            orientationDirec[2] = "left";
            orientationDirec[3] = "right";
        }
    }

    //0:WEST, 1:EAST, 2:SOUTH, 3:NORTH
    Vector2[] findLocations()
    {
        //only 4 possible moves
        Vector2[] moves = new Vector2[4];

        //EACH MUST CHECK IF ITS AN EDGE PIECE
        //check WEST
        if (boardState.locationValue((int)locationBoard.x, (int)locationBoard.y - 1) == 0 /*&& isEdgePiece(new Vector2((int)locationBoard.x - 1, (int)locationBoard.y))*/)
        {
            moves[0].Set(transform.position.x - 1, transform.position.y);
            //Debug.Log("West = 0");
        }
        else
        {
            moves[0].Set(transform.position.x - 100, transform.position.y - 100);
            //Debug.Log("West = 1");
        }

        //check EAST
        if (boardState.locationValue((int)locationBoard.x, (int)locationBoard.y + 1) == 0 /*&& isEdgePiece(new Vector2((int)locationBoard.x + 1, (int)locationBoard.y))*/)
        {
            moves[1].Set(transform.position.x + 1, transform.position.y);
            //Debug.Log("East = 0");
        }
        else
        {
            //Debug.Log("East = 1");
            moves[1].Set(transform.position.x + 100, transform.position.y + 100);
        }

        //check SOUTH
        if (boardState.locationValue((int)locationBoard.x + 1, (int)locationBoard.y) == 0 /*&& isEdgePiece(new Vector2((int)locationBoard.x, (int)locationBoard.y - 1))*/)
        {
            //Debug.Log("South = 0");
            moves[2].Set(transform.position.x, transform.position.y - 1);
        }
        else
        {
            //Debug.Log("South = 1");
            moves[2].Set(transform.position.x - 100, transform.position.y - 100);
        }

        //check NORTH
        if (boardState.locationValue((int)locationBoard.x - 1, (int)locationBoard.y) == 0 /*&& isEdgePiece(new Vector2((int)locationBoard.x, (int)locationBoard.y + 1))*/)
        {
            moves[3].Set(transform.position.x, transform.position.y + 1);
            //Debug.Log("North = 0");
        }
        else
        {
            //Debug.Log("North = 1");
            moves[3].Set(transform.position.x + 100, transform.position.y + 100);
        }

        return moves;
    }

    /*bool isEdgePiece(Vector2 spot)
    {
        int freeSpaceCount = 0;

        //check WEST
        if (boardState.locationValue((int)spot.x - 1, (int)spot.y) == 0)
            freeSpaceCount++;

        //check EAST
        if (boardState.locationValue((int)spot.x + 1, (int)spot.y) == 0)
            freeSpaceCount++;

        //check SOUTH
        if (boardState.locationValue((int)spot.x, (int)spot.y - 1) == 0)
            freeSpaceCount++;

        //check NORTH
        if (boardState.locationValue((int)spot.x, (int)spot.y + 1) == 0)
            freeSpaceCount++;

        if (freeSpaceCount > 3)
        {

            Debug.Log("Not edge piece at x:" + spot.x + " y:" + spot.y);
            return false;
        }
        else
            return true;
    }*/
}
