using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    private Vector2 location, locationBoard;
    private BoardState board;
    // Start is called before the first frame update
    void Start()
    {
        location = new Vector2(transform.position.x, transform.position.y);
        board = BoardState.getBoard();
        locationBoard = board.findBoardLocation(transform);
    }

    // Update is called once per frame
    void Update()
    {
        //detect movement and update the board
        if(Mathf.Abs(location.x - transform.position.x) > 0.9 || Mathf.Abs(location.y - transform.position.y) > 0.9)
        {
            Debug.Log("MOVE DETECTED");
            board.updateBoard(locationBoard, 0);
            location.Set(transform.position.x, transform.position.y);
            locationBoard = board.findBoardLocation(transform);
            board.updateBoard(locationBoard, 1);
        }
    }
}
