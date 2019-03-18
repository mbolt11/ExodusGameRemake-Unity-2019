using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMovement : MonoBehaviour
{
    public int row, col;
    private BoardState boardState;

    // Start is called before the first frame update
    void Start()
    {
        GameObject controller = GameObject.FindGameObjectWithTag("Controller");
        boardState = BoardState.getBoard();
    }

    // Update is called once per frame
    void Update()
    {
        //find where it should go next && check up, down, left, and right
        //all enemies will move in a clockwise pattern (meaning they will always travel left)


    }

    /*int[,] findLocations()
    {
        //check left
        if(boardState.locationValue())
    }*/
}
